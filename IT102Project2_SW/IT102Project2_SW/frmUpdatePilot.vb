Public Class frmUpdatePilot
    Private Sub frmUpdatePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'declare variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader for pilot roles

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
            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            'load the Pilot Role result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboPilotRoles.ValueMember = "intPilotRoleID"
            cboPilotRoles.DisplayMember = "strPilotRole"
            cboPilotRoles.DataSource = dtp

            ' Build the select statement using PK from name selected
            strSelect = "SELECT strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID " &
                        "FROM TPilots WHERE intPilotID = " & gblPilotID

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            ' populate the text boxes with the data
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmHireDate.Value = drSourceTable("dtmDateofHire")
            dtmTerminationDate.Value = drSourceTable("dtmDateofTermination")
            dtmLicenseDate.Value = drSourceTable("dtmDateofLicense")
            cboPilotRoles.SelectedValue = drSourceTable("intPilotRoleID")

            strSelect = "SELECT strLoginID, strPassword " &
                        "FROM TEmployees WHERE intEmployeeRoleID = 1 AND intEmployeeNum = " & gblPilotID

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            'populate the textboxes with the data
            txtLoginID.Text = drSourceTable("strLoginID")
            txtPassword.Text = drSourceTable("strPassword")
            txtConfirmPass.Text = drSourceTable("strPassword")
            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdatePilot_Click(sender As Object, e As EventArgs) Handles btnUpdatePilot.Click
        'declare variables
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dteHireDate As Date
        Dim dteTerminationDate As Date
        Dim dteLicenseDate As Date
        Dim intPilotRole As Integer
        Dim strLogin As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer

        ' this will hold our Update statement
        Dim cmdUpdate As New OleDb.OleDbCommand()

        ' put values into strings
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strEmployeeID = txtEmployeeID.Text
        dteHireDate = dtmHireDate.Value
        dteTerminationDate = dtmTerminationDate.Value
        dteLicenseDate = dtmLicenseDate.Value
        intPilotRole = cboPilotRoles.SelectedValue
        strLogin = txtLoginID.Text
        strPassword = txtPassword.Text


        ' validate data is entered
        Call ValidateInput(blnValidated, dteHireDate, dteTerminationDate, dteLicenseDate, strLogin, strPassword)

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

                ' text to call stored procedures
                cmdUpdate.CommandText = "EXECUTE uspUpdatePilot " & gblEmployeeID & ", " & gblPilotID & ", '" & strFirstName & "', '" & strLastName & "', '" &
                strLogin & "', '" & strPassword & "', '" & strEmployeeID & "', '" & dteHireDate & "', '" & dteTerminationDate & "', '" & dteLicenseDate & "', " & intPilotRole
                cmdUpdate.CommandType = CommandType.StoredProcedure

                ' call stored procedures which will update the record
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

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal dteHireDate As Date, ByVal dteTerminationDate As Date, ByVal dteLicenseDate As Date, ByVal strLogin As String, ByVal strPassword As String)
        Call ValidateName(blnValidated)
        Call ValidateEmployeeID(blnValidated)
        Call ValidateHireTerminationDate(blnValidated, dteHireDate, dteTerminationDate)
        Call ValidateLicenseDate(blnValidated, dteLicenseDate)
        Call ValidatePilotRole(blnValidated)
        Call ValidateLogin(blnValidated, strLogin, strPassword)
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

    Private Sub ValidateEmployeeID(ByRef blnValidated As Boolean)
        'validate txtemployeeid is not empty
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter your first name.")
            txtEmployeeID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateHireTerminationDate(ByRef blnValidated As Boolean, ByVal dteHireDate As Date, ByVal dteTerminationDate As Date)
        'validate that hire date is not later than current date
        If dteHireDate > DateTime.Now Then
            MessageBox.Show("Date of hire cannot be later than current date.")
            dtmHireDate.Focus()
            blnValidated = False
        End If

        'validate that termination date later than hire date
        If dteHireDate > dteTerminationDate Then
            MessageBox.Show("Termination date must be later than hire date.")
            dtmTerminationDate.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateLicenseDate(ByRef blnValidated As Boolean, ByVal dteLicenseDate As Date)
        'validate that license date is later than current date
        If dteLicenseDate > DateTime.Now Then
            MessageBox.Show("Date of license cannot be later than current date.")
            dtmLicenseDate.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidatePilotRole(ByRef blnValidated As Boolean)
        'validate that pilot role combobox is not empty
        If cboPilotRoles.Text = String.Empty Then
            MessageBox.Show("Select a pilot role.")
            cboPilotRoles.Focus()
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class