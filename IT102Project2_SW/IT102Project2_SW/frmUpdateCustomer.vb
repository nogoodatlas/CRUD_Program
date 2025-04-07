Public Class frmUpdateCustomer
    Private Sub frmUpdateCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  On the event Form Load, we are going to populate the State combobox from the database
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dtp As DataTable = New DataTable 'this is the table we will load from our reader for Passengers
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

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        Dim strUpdate As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer

        ' this will hold our Update statement
        Dim cmdUpdate As OleDb.OleDbCommand

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

                ' open database this is in module
                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                            "The application will now close.",
                                            Me.Text + " Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                ' Build the select statement using PK from name selected
                strUpdate = "UPDATE TPassengers SET " &
                            "strFirstName = '" & strFirstName & "', " &
                            "strLastName = '" & strLastName & "', " &
                            "strAddress = '" & strAddress & "', " &
                            "strCity = '" & strCity & "', " &
                            "intStateID = " & intState & ", " &
                            "strZip = '" & strZip & "', " &
                            "strPhoneNumber = '" & strPhoneNumber & "', " &
                            "strEmail = '" & strEmail & "'" &
                            "WHERE intPassengerID = " & intPassengerID


                ' uncomment out the following message box line to use as a tool to check your sql statement
                ' remember anything not a numeric value going into SQL Server must have single quotes '
                ' around it, including dates.
                'MessageBox.Show(strUpdate)

                ' make the connection
                cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected = 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                ' close the database connection
                CloseDatabaseConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'Clear fields upon button click
            txtFirstName.Clear()
            txtLastName.Clear()
            txtAddress.Clear()
            txtCities.Clear()
            cboStates.ResetText()
            txtZip.Clear()
            txtPhone.Clear()
            txtEmail.Clear()
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