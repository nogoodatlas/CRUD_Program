Public Class frmUpdateCustomer
    Private Sub frmUpdateCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'declare variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dts As DataTable = New DataTable ' this is the table we will load from our reader for State

        Try
            ' open the database this is in module
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

            ' Build the select statement using PK from name selected
            strSelect = "SELECT strFirstName, strLastName, dtmDOB, strAddress, strCity, intStateID, strZip, strLoginID, strPassword, strPhoneNumber, strEmail " &
                        "FROM TPassengers WHERE intPassengerID = " & gblPassengerID

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            ' populate the text boxes with the data
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            dtmDOB.Value = drSourceTable("dtmDOB")
            txtAddress.Text = drSourceTable("strAddress")
            txtCities.Text = drSourceTable("strCity")
            cboStates.SelectedValue = drSourceTable("intStateID")
            txtZip.Text = drSourceTable("strZip")
            txtLoginID.Text = drSourceTable("strLoginID")
            txtPassword.Text = drSourceTable("strPassword")
            txtConfirmPass.Text = drSourceTable("strPassword")
            txtPhone.Text = drSourceTable("strPhoneNumber")
            txtEmail.Text = drSourceTable("strEmail")

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdateCustomer_Click(sender As Object, e As EventArgs) Handles btnUpdateCustomer.Click
        'declare variables
        Dim strFirstName As String
        Dim dteDOB As Date
        Dim strLastName As String
        Dim strAddress As String
        Dim strCity As String
        Dim intState As Integer
        Dim strZip As String
        Dim strLogin As String
        Dim strPassword As String
        Dim strPhoneNumber As String
        Dim strEmail As String
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        ' this will hold our Update command
        Dim cmdUpdate As New OleDb.OleDbCommand()

        ' put values into strings
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        dteDOB = dtmDOB.Value
        strAddress = txtAddress.Text
        strCity = txtCities.Text
        intState = cboStates.SelectedValue
        strZip = txtZip.Text
        strLogin = txtLoginID.Text
        strPassword = txtPassword.Text
        strPhoneNumber = txtPhone.Text
        strEmail = txtEmail.Text

        ' validate data is entered
        Call ValidateInput(blnValidated, dteDOB, strLogin, strPassword, strEmail)

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

                cmdUpdate.CommandText = "EXECUTE uspUpdateCustomer " & gblPassengerID & ", '" & strFirstName & "', '" & strLastName & "', '" & dteDOB & "', '" &
                strAddress & "', '" & strCity & "'," & intState & ", '" & strZip & "', '" & strLogin & "', '" & strPassword & "', '" & strPhoneNumber & "', '" & strEmail & "'"
                cmdUpdate.CommandType = CommandType.StoredProcedure

                ' call stored procedures which will insert the record
                cmdUpdate = New OleDb.OleDbCommand(cmdUpdate.CommandText, m_conAdministrator)

                ' execute query to insert data
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected >= 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                ' close the database connection
                CloseDatabaseConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'closes form upon update
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal dteDOB As Date, ByVal strLogin As String, ByVal strPassword As String, ByVal strEmail As String)
        Call ValidateName(blnValidated)
        Call ValidateDOB(blnValidated, dteDOB)
        Call ValidateAddress(blnValidated)
        Call ValidateCity(blnValidated)
        Call ValidateState(blnValidated)
        Call ValidateZipcode(blnValidated)
        Call ValidateLogin(blnValidated, strLogin, strPassword)
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

    Private Sub ValidateDOB(ByRef blnValidated As Boolean, ByVal dteDOB As Date)
        'declare variables
        Dim dteCurrentDate As Date = DateTime.Now
        Dim dteDifference As TimeSpan = dteCurrentDate - dteDOB 'used stack overflow to learn this
        Dim intAge As Integer

        'calculate customer's current age
        intAge = dteDifference.TotalDays / 365

        'validate that customer is at least 18 years old
        If intAge < 18 Then
            MessageBox.Show("You must be 18 or older to create an account.")
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

    Private Sub ValidateLogin(ByRef blnValidated As Boolean, ByVal strLogin As String, ByVal strPassword As String)
        'Validates that the login/password fields are not empty
        If txtLoginID.Text = String.Empty Or txtPassword.Text = String.Empty Or txtConfirmPass.Text = String.Empty Then
            MessageBox.Show("You must create a Login ID and Password to continue.")
            txtLoginID.Focus()
            blnValidated = False
        End If

        'Validates that the login/password is at least 5 characters long
        If strLogin.Length < 5 Then
            MessageBox.Show("Login ID must be at least 5 characters in length.")
            txtLoginID.Focus()
            blnValidated = False
        ElseIf strPassword.Length < 5 Then
            MessageBox.Show("Password must be at least 5 characters in length.")
            txtPassword.Focus()
            blnValidated = False
        End If

        'validates that both input passwords match
        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords must be identical")
            txtPassword.Focus()
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class