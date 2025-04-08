Public Class frmNavigation
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim blnValidated As Boolean = True
        Dim frmCustomer As New frmCustomerSelect
        Dim frmPilot As New frmPilotMain
        Dim frmAttendant As New frmAttendantMain
        Dim frmAdmin As New frmAdminMain

        Call ValidateInput(blnValidated)

        If blnValidated = True Then
            If cboUserType.Text = "Customer" Then
                frmCustomer.ShowDialog()            'opens form for CustomerSelect (select form for customer)
            ElseIf cboUserType.Text = "Pilot" Then
                frmPilot.ShowDialog()               'opens form for PilotMain (main menu for pilot)
            ElseIf cboUserType.Text = "Attendant" Then
                frmAttendant.ShowDialog()                   'open form for AttendantMain (main menu for attendant)
            ElseIf cboUserType.Text = "Administrator" Then
                frmAdmin.ShowDialog()                       'open form for AdminMain (main menu for admin)
            End If
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean)
        If cboUserType.Text = String.Empty Then
            MessageBox.Show("Please select a user type.")
            cboUserType.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes program
        Close()
    End Sub
End Class
