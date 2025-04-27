Public Class frmNavigation
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes program
        Close()
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        'declare variable
        Dim frmCustomer As New frmCustomerLogin

        frmCustomer.ShowDialog()
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        'declare variable
        Dim frmEmployee As New frmEmployeeLogin

        frmEmployee.ShowDialog()
    End Sub
End Class
