Public Class frmManagePilot
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'declare variable
        Dim frmAdd As New frmAddPilot

        'opens form to add pilots
        frmAdd.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'declare variable
        Dim frmDelete As New frmDeletePilot

        'opens form to delete pilots
        frmDelete.ShowDialog()
    End Sub

    Private Sub btnAddFlight_Click(sender As Object, e As EventArgs) Handles btnAddFlight.Click
        'declare variable
        Dim frmAddFlight As New frmAddPilotFlight

        'opens form to add pilots to flights
        frmAddFlight.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class