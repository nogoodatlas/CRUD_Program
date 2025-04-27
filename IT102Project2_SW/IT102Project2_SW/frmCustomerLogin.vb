Public Class frmCustomerLogin

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'declare variables
        Dim strLogin As String
        Dim strPass As String
        Dim intPassengerID As Integer = 0    'set as 0 by default
        Dim blnValidated As Boolean = True

        Dim frmCustomer As New frmCustomerMain

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
            Call ValidateExistence(blnValidated, strLogin, strPass, intPassengerID)

            If blnValidated = True Then
                CloseDatabaseConnection()

                gblPassengerID = intPassengerID
                frmCustomer.ShowDialog()

                'closes form after customer closes main menu
                Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ValidateLogin(ByRef blnValidated As Boolean)
        If txtLoginID.Text = String.Empty Or txtPassword.Text = String.Empty Then
            MessageBox.Show("Invalid Login ID or Password.")
            txtLoginID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateExistence(ByRef blnValidated As Boolean, ByVal strLogin As String, ByVal strPass As String, ByRef intPassengerID As Integer)
        'declare variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        Try
            ' Build the select statement using PK from name selected
            strSelect = "SELECT intPassengerID FROM TPassengers " &
            "WHERE strLoginID = '" & strLogin & "' AND strPassword = '" & strPass & "'"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            If drSourceTable.Read() Then
                intPassengerID = CInt(drSourceTable("intPassengerID"))
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

    Private Sub btnCreateCustomer_Click(sender As Object, e As EventArgs) Handles btnCreateCustomer.Click
        'declare variable
        Dim frmNewCustomer As New frmNewCustomer

        'open form for new customer
        frmNewCustomer.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class