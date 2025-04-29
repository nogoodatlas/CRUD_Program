Public Class frmAirbusA350
    Private Sub frmAirbusA350_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'declare variable
        Dim strSeat As String = ""

        For Each cb As CheckBox In Controls.OfType(Of CheckBox)
            If strSeat = cb.Name Then
                cb.Checked = True
                cb.Enabled = False
            End If
        Next
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click

    End Sub
End Class