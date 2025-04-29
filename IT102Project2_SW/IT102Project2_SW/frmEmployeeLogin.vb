Public Class frmEmployeeLogin
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'declare variables
        Dim strLogin As String
        Dim strPass As String
        Dim intEmployeeID As Integer = 0    'set as 0 by default
        Dim intEmployeeRole As Integer = 0  'set as 0 by default
        Dim intEmployeeNum As Integer = 0   'set as 0 by default
        Dim blnValidated As Boolean = True

        Dim frmPilot As New frmPilotMain
        Dim frmAttendant As New frmAttendantMain
        Dim frmAdmin As New frmAdminMain

        'put values into strings
        strLogin = txtLoginID.Text
        strPass = txtPassword.Text

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

            Call ValidateLogin(blnValidated)
            Call ValidateExistence(blnValidated, strLogin, strPass, intEmployeeID, intEmployeeRole, intEmployeeNum)

            If blnValidated = True Then
                CloseDatabaseConnection()

                If intEmployeeRole = 1 Then         'if employee role is pilot
                    gblPilotID = intEmployeeNum
                    gblEmployeeID = intEmployeeID
                    frmPilot.ShowDialog()
                ElseIf intEmployeeRole = 2 Then     'if employee role is attendant
                    gblAttendantID = intEmployeeNum
                    gblEmployeeID = intEmployeeID
                    frmAttendant.ShowDialog()
                Else                                'if employee role is admin
                    frmAdmin.ShowDialog()
                End If

                'closes form after employee closes their main menu
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ValidateLogin(ByRef blnValidated As Boolean)
        If txtLoginID.Text = String.Empty Or txtPassword.Text = String.Empty Then
            MessageBox.Show("Please enter your Login ID and Password.")
            txtLoginID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateExistence(ByRef blnValidated As Boolean, ByVal strLogin As String, ByVal strPass As String, ByRef intEmployeeID As Integer, ByRef intEmployeeRole As Integer, ByRef intEmployeeNum As Integer)
        'declare variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        Try
            ' Build the select statement using PK from name selected
            strSelect = "SELECT intEmployeeID, intEmployeeRoleID, intEmployeeNum FROM TEmployees " &
            "WHERE strLoginID = '" & strLogin & "' AND strPassword = '" & strPass & "'"

            MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            If drSourceTable.Read() Then
                intEmployeeID = drSourceTable("intEmployeeID")
                intEmployeeRole = drSourceTable("intEmployeeRoleID")
                intEmployeeNum = drSourceTable("intEmployeeNum")
            Else
                MessageBox.Show("Invalid login and/or password")
                drSourceTable.Close()
                txtPassword.Clear()
                blnValidated = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class