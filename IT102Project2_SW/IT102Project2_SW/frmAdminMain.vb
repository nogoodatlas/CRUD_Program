Public Class frmAdminMain
    Private Sub btnManagePilots_Click(sender As Object, e As EventArgs) Handles btnManagePilots.Click
        'declare variable
        Dim frmPilot As New frmManagePilot

        'opens form to manage pilots
        frmPilot.ShowDialog()
    End Sub

    Private Sub btnManageAttendants_Click(sender As Object, e As EventArgs) Handles btnManageAttendants.Click
        'declare variable
        Dim frmAttendant As New frmManageAttendant

        'opens form to manage attendants
        frmAttendant.ShowDialog()
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        'declare variable
        Dim frmStats As New frmAirlineStatistics

        'opens form for statistics
        frmStats.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class