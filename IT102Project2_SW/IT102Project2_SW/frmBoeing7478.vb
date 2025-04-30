Public Class frmBoeing7478
    Private Sub frmBoeing7478_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'declare variables
        Dim strSelect As String = ""
        Dim strSeat As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader for seats

        'On the event Form Load, we are going to check and disable checkboxes of filled seats
        Try

            ' open the DB
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
            strSelect = "SELECT strSeat FROM TFlightPassengers WHERE intFlightID = " & gblFlightID

            'Execute command
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'Read result
            While drSourceTable.Read()
                strSeat = drSourceTable("strSeat")

                For Each cb As CheckBox In Controls.OfType(Of CheckBox)
                    If strSeat = cb.Name Then
                        cb.Checked = True
                        cb.Enabled = False
                    End If
                Next

            End While

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dt.Load(drSourceTable)

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        'declare variables
        Dim strSeat As String = ""
        Dim blnValidated As Boolean = True

        For Each cb As CheckBox In Controls.OfType(Of CheckBox)
            If cb.Checked = True And cb.Enabled = True Then
                If strSeat <> "" Then
                    MessageBox.Show("Please only choose one seat.")
                    blnValidated = False
                Else
                    strSeat = cb.Name
                End If
            End If
        Next

        If blnValidated = True Then
            gblSeat = strSeat
        Else
            gblSeat = ""
        End If

        'closes form
        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class