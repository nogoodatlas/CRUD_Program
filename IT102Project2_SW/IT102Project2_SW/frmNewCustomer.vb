Public Class frmNewCustomer
    Private Sub frmNewCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  On the event Form Load, we are going to populate the State combobox from the database
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State

            ' open the DB
            If OpenDatabaseConnectionSQLServer() = False Then

                ' No, warn the user ...
                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                ' and close the form/application
                Me.Close()

            End If

            ' Build the select statement
            strSelect = "SELECT intStateID, strState FROM TStates"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dts.Load(drSourceTable)


            'load the State result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboStates.ValueMember = "intStateID"
            cboStates.DisplayMember = "strState"
            cboStates.DataSource = dts

            'keep combobox empty upon load
            cboStates.Text = String.Empty

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnCreateCustomer_Click(sender As Object, e As EventArgs) Handles btnCreateCustomer.Click
        'variables for new customer data and select and insert statements
        Dim strSelect As String
        Dim strInsert As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim blnValidated As Boolean = True
        Dim frmCustomer As New frmCustomerMain

        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        ' put values into strings
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strAddress = txtAddress.Text
        strCity = txtCities.Text
        intState = cboStates.SelectedValue
        strZip = txtZip.Text
        strPhoneNumber = txtPhone.Text
        strEmail = txtEmail.Text

        ' validate data is entered
        Call ValidateInput(blnValidated, strEmail)

        If blnValidated = True Then

            Try

                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                strSelect = "SELECT MAX(intPassengerID) + 1 AS intNextPrimaryKey " &
                                " FROM TPassengers"

                ' Execute command
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' Read result( highest ID )
                drSourceTable.Read()

                ' Null? (empty table)
                If drSourceTable.IsDBNull(0) = True Then

                    ' Yes, start numbering at 1
                    intNextPrimaryKey = 1

                Else

                    ' No, get the next highest ID
                    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                End If

                ' build insert statement (columns must match DB columns in name and the # of columns)
                strInsert = "INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastName & "','" & strAddress & "','" & strCity & "'," & intState & ",'" & strZip & "','" & strPhoneNumber & "','" & strEmail & "')"

                'set next primary key equal to global variable for passenger ID
                gblPassengerID = intNextPrimaryKey

                'MessageBox.Show(strInsert)

                ' use insert command with sql string and connection object
                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                ' execute query to insert data
                intRowsAffected = cmdInsert.ExecuteNonQuery()

                ' If not 0 insert successful
                If intRowsAffected > 0 Then
                    MessageBox.Show("Passenger has been added")    ' let user know success
                    ' close new player form
                End If

                CloseDatabaseConnection()       ' close connection if insert didn't work

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'open customer main menu upon creating customer
            frmCustomer.ShowDialog()

            'closes form upon creating customer
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal strEmail As String)
        Call ValidateName(blnValidated)
        Call ValidateAddress(blnValidated)
        Call ValidateCity(blnValidated)
        Call ValidateState(blnValidated)
        Call ValidateZipcode(blnValidated)
        Call ValidatePhone(blnValidated)
        Call ValidateEmail(blnValidated, strEmail)
    End Sub

    Private Sub ValidateName(ByRef blnValidated As Boolean)
        'validate txtfirstname is not empty
        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("Please enter your first name.")
            txtFirstName.Focus()
            blnValidated = False
        End If

        'validate txtlastname is not empty
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please enter your last name.")
            txtLastName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateAddress(ByRef blnValidated As Boolean)
        'validate txtaddress is not empty
        If txtAddress.Text = String.Empty Then
            MessageBox.Show("Please enter your address.")
            txtAddress.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateCity(ByRef blnValidated As Boolean)
        'validate txtcities is not empty
        If txtCities.Text = String.Empty Then
            MessageBox.Show("Please enter your city.")
            txtCities.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateState(ByRef blnValidated As Boolean)
        'validate State combobox is not empty
        If cboStates.Text = String.Empty Then
            MessageBox.Show("Please make a selection.")
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateZipcode(ByRef blnValidated As Boolean)
        'validate txtzip is not empty
        If txtZip.Text = String.Empty Then
            MessageBox.Show("Please enter your zipcode.")
            txtZip.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidatePhone(ByRef blnValidated As Boolean)
        'validate txtphone is not empty
        If txtPhone.Text = String.Empty Then
            MessageBox.Show("Please enter your phone number.")
            txtPhone.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateEmail(ByRef blnValidated As Boolean, ByVal strEmail As String)
        Dim intIndex As Integer
        'validate txtemail is not empty
        If txtEmail.Text = String.Empty Then
            MessageBox.Show("Please enter your email.")
            txtEmail.Focus()
            blnValidated = False
        Else
            'validate that txtemail contains '@'
            intIndex = strEmail.IndexOf("@")
            If intIndex = -1 Then
                MessageBox.Show("Please enter a valid email.")
                txtEmail.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class