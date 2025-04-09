Public Class frmManageAttendant
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'declare variable
        Dim frmAdd As New frmAddAttendant

        'opens form to add attendants
        frmAdd.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'declare variable
        Dim frmDelete As New frmDeleteAttendant

        'opens form to delete attendants
        frmDelete.ShowDialog()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        'declare variable
        Dim frmAddFlight As New frmAddAttendantFlight

        'opens form to add attendants to flights
        frmAddFlight.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class