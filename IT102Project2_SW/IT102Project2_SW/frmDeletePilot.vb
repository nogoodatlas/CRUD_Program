Public Class frmDeletePilot
    Private Sub frmDeletePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Try

            ' open the DB this is in module
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
            strSelect = "SELECT intPilotID, strFirstName + ' ' + strLastName as PilotName FROM TPilots"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dt.Load(drSourceTable)

            ' Add the item to the combo box. We need the player ID associated with the name so 
            ' when we click on the name we can then use the ID to pull the rest of the players data.
            ' We are binding the column name to the combo box display and value members. 
            cboPilots.ValueMember = "intPilotID"
            cboPilots.DisplayMember = "PilotName"
            cboPilots.DataSource = dt

            ' Select the first item in the list by default
            If cboPilots.Items.Count > 0 Then cboPilots.SelectedIndex = 0

            'keep combobox empty upon load
            cboPilots.Text = String.Empty

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim frmPilot As New frmPilotSelect
        Dim intRowsAffected As Integer
        Dim blnValidated As Boolean = True

        Dim cmdDelete As New OleDb.OleDbCommand() ' this will be used for our Delete statement
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim result As DialogResult  ' this is the result of which button the user selects


        Call ValidateInput(blnValidated)

        If blnValidated = True Then

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

                ' always ask before deleting!!!!
                result = MessageBox.Show("Are you sure you want to Delete Pilot: " & cboPilots.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow deletion
                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.No
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.Yes

                        ' Build the delete statement using the stored procedure uspDeletePilot
                        cmdDelete.CommandText = "EXECUTE uspDeletePilot " & cboPilots.SelectedValue
                        cmdDelete.CommandType = CommandType.StoredProcedure

                        ' call stored procedures which will insert the record
                        cmdDelete = New OleDb.OleDbCommand(cmdDelete.CommandText, m_conAdministrator)

                        ' Delete the record(s) 
                        intRowsAffected = cmdDelete.ExecuteNonQuery()

                        ' Did it work?
                        If intRowsAffected > 0 Then

                            ' Yes, success
                            MessageBox.Show("Delete successful")

                        End If
                End Select

                ' close the database connection
                CloseDatabaseConnection()

                ' call the Form Load sub to refresh the combo box data after a delete
                frmDeletePilot_Load(sender, e)

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'open pilot select upon deleting pilot
            frmPilot.ShowDialog()

            'closes form upon deleting pilot
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean)
        'validate combobox is not empty
        If cboPilots.Text = String.Empty Then
            MessageBox.Show("Please make a selection.")
            blnValidated = False
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class