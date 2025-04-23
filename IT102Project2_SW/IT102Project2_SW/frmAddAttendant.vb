Imports System.Data.OleDb

Public Class frmAddAttendant
    Private Sub btnAddAttendant_Click(sender As Object, e As EventArgs) Handles btnAddAttendant.Click
        'variables for new attendant data and select and insert statements
        Dim strSelect As String
        Dim frmAttendant As New frmAttendantMain
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dteHireDate As Date
        Dim dteTerminationDate As Date
        Dim strLogin As String
        Dim strPassword As String
        Dim blnValidated As Boolean = True

        Dim cmdCreateAttendant As New OleDb.OleDbCommand() 'select command object
        Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures
        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        ' put values into strings
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strEmployeeID = txtEmployeeID.Text
        dteHireDate = dtmHireDate.Value
        dteTerminationDate = dtmTerminationDate.Value
        strLogin = txtLoginID.Text
        strPassword = txtPassword.Text

        ' validate data is entered
        Call ValidateInput(blnValidated, dteHireDate, dteTerminationDate, strLogin, strPassword)

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

                'strSelect = "SELECT MAX(intAttendantID) + 1 AS intNextPrimaryKey " &
                '                " FROM TAttendants"

                '' Execute command
                'cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                'drSourceTable = cmdSelect.ExecuteReader

                '' Read result( highest ID )
                'drSourceTable.Read()

                '' Null? (empty table)
                'If drSourceTable.IsDBNull(0) = True Then

                '    ' Yes, start numbering at 1
                '    intNextPrimaryKey = 1

                'Else

                '    ' No, get the next highest ID
                '    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                'End If

                ' text to call stored procedures
                'cmdCreateAttendant.CommandText = "EXECUTE uspCreateAttendant @intEmployeeID OUTPUT, @intEmployeeRoleID OUTPUT, " & intNextPrimaryKey & ", '" & strLogin & "', '" & strPassword & "', '" & strFirstName & "', '" & strLastName & "', '" & strEmployeeID & "', '" & dteHireDate & "', '" & dteTerminationDate & "'"

                cmdCreateAttendant = New OleDb.OleDbCommand("uspCreateAttendant", m_conAdministrator)
                cmdCreateAttendant.CommandType = CommandType.StoredProcedure

                objParam = cmdCreateAttendant.Parameters.Add("@intEmployeeID", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Output

                objParam = cmdCreateAttendant.Parameters.Add("@intEmployeeRoleID", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Output

                objParam = cmdCreateAttendant.Parameters.Add("@intAttendantID", OleDb.OleDbType.Integer)
                objParam.Direction = ParameterDirection.Output

                drSourceTable = cmdCreateAttendant.ExecuteReader

                '' call stored procedures which will insert the record
                'cmdCreateAttendant = New OleDb.OleDbCommand(cmdCreateAttendant.CommandText, m_conAdministrator)
                'gblAttendantID = intNextPrimaryKey

                ' execute query to insert data
                intRowsAffected = cmdCreateAttendant.ExecuteNonQuery()

                ' If not 0 insert successful
                If intRowsAffected > 0 Then
                    MessageBox.Show("Attendant has been added")    ' let user know success
                    ' close new player form
                End If

                CloseDatabaseConnection()       ' close connection if insert didn't work

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'open attendant main menu upon creating attendant
            frmAttendant.ShowDialog()

            'closes form upon creating attendant
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal dteHireDate As Date, ByVal dteTerminationDate As Date, ByVal strLogin As String, ByVal strPassword As String)
        Call ValidateName(blnValidated)
        Call ValidateEmployeeID(blnValidated)
        Call ValidateHireTerminationDate(blnValidated, dteHireDate, dteTerminationDate)
        Call ValidateLogin(blnValidated, strLogin, strPassword)
    End Sub

    Private Sub ValidateName(ByRef blnValidated As Boolean)
        'validate txtfirstname is not empty
        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("Please enter first name.")
            txtFirstName.Focus()
            blnValidated = False
        End If

        'validate txtlastname is not empty
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please enter last name.")
            txtLastName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateEmployeeID(ByRef blnValidated As Boolean)
        'validate txtemployeeid is not empty
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter employee ID.")
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
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class