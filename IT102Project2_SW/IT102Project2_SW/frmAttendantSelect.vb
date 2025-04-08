Public Class frmAttendantSelect
    Private Sub frmAttendantSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  On the event Form Load, we are going to populate the Attendant combobox from the database
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dta As DataTable = New DataTable 'this is the table we will load from our reader for Attendants

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
            strSelect = "SELECT TA.intAttendantID, TA.strFirstName + ' ' + TA.strLastName AS AttendantName FROM TAttendants AS TA"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dta.Load(drSourceTable)

            'load the Passenger result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboAttendants.ValueMember = "TA.intAttendantID"
            cboAttendants.DisplayMember = "AttendantName"
            cboAttendants.DataSource = dta

            'makes combobox empty by default
            cboAttendants.Text = String.Empty

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub
End Class