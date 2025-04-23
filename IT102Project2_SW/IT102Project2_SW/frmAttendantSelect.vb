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

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'declare variables
        Dim frmAttendant As New frmAttendantMain
        Dim blnValidated As Boolean = True

        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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

                ' Build the select statement using PK from name selected
                strSelect = "SELECT TA.intAttendantID, TA.strFirstName + ' ' + TA.strLastName AS AttendantName FROM TAttendants AS TA"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                ' populate the variable with the data
                gblAttendantID = cboAttendants.SelectedValue


                strSelect = "SELECT intEmployeeID " &
                            "FROM TEmployees WHERE intEmployeeRoleID = 2 AND intEmployeeNum = " & gblAttendantID

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                ' populate the variable with the data
                gblEmployeeID = drSourceTable("intEmployeeID")

                ' close the database connection
                CloseDatabaseConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            frmAttendant.ShowDialog()        'opens form for attendant main menu
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean)
        'validate combobox is not empty
        If cboAttendants.Text = String.Empty Then
            MessageBox.Show("Please make a selection.")
            blnValidated = False
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class