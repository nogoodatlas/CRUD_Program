Public Class frmCreateFlight
    Private Sub frmCreateFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dta As DataTable = New DataTable ' this is the table we will load from our reader for airports
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader for airports

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
            strSelect = "SELECT intAirportID, strAirportCity + ' - ' + strAirportCode As AirportName FROM TAirports"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dta.Load(drSourceTable)

            ' Add the item to the combo box
            cboDepartures.ValueMember = "intAirportID"
            cboDepartures.DisplayMember = "AirportName"
            cboDepartures.DataSource = dta

            cboArrivals.ValueMember = "intAirportID"
            cboArrivals.DisplayMember = "AirportName"
            cboArrivals.DataSource = dta

            ' Build the select statement
            strSelect = "SELECT TP.intPlaneID, TPT.strPlaneType + '  -  ' + strPlaneNumber As PlaneName " &
                        "FROM TPlanes AS TP JOIN TPlaneTypes AS TPT ON TP.intPlaneTypeID = TPT.intPlaneTypeID"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dtp.Load(drSourceTable)

            ' Add the item to the combo box
            cboPlanes.ValueMember = "TP.intPlaneID"
            cboPlanes.DisplayMember = "PlaneName"
            cboPlanes.DataSource = dtp

            'keep combobox empty upon load
            cboDepartures.Text = String.Empty
            cboArrivals.Text = String.Empty
            cboPlanes.Text = String.Empty

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch excError As Exception

            ' Log and display error message
            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnCreateFlight_Click(sender As Object, e As EventArgs) Handles btnCreateFlight.Click
        ''declare variables
        'Dim intFlightID As Integer
        'Dim strSeat As String
        'Dim intFlightPassengerID As Integer ' holds next highest PK value
        'Dim result As DialogResult  ' this is the result of which button the user selects
        'Dim blnValidated As Boolean = True

        'Dim cmdInsert As New OleDb.OleDbCommand() ' insert command object
        'Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        ''validate inputs
        'Call ValidateInput(blnValidated)

        ''put values into strings
        'intFlightID = cboFlights.SelectedValue
        'strSeat = cboSeats.Text

        'If blnValidated = True Then

        '    Try
        '        ' open the database this is in module
        '        If OpenDatabaseConnectionSQLServer() = False Then

        '            ' No, warn the user ...
        '            MessageBox.Show(Me, "Database connection error." & vbNewLine &
        '                                "The application will now close.",
        '                                Me.Text + " Error",
        '                                MessageBoxButtons.OK, MessageBoxIcon.Error)

        '            ' and close the form/application
        '            Me.Close()

        '        End If

        '        ' always ask before inserting info into the database!!!!
        '        result = MessageBox.Show("Are you sure you want to book this flight?", "Booking Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        '        ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow info to be stored
        '        Select Case result
        '            Case DialogResult.Cancel
        '                MessageBox.Show("Action Canceled")
        '            Case DialogResult.No
        '                MessageBox.Show("Action Canceled")
        '            Case DialogResult.Yes

        '                ' build insert statement (columns must match DB columns in name and the # of columns)
        '                cmdInsert.CommandText = "EXECUTE uspBookFlight " & intFlightPassengerID & "," & intFlightID & "," & gblPassengerID & ",'" & strSeat & "'"
        '                cmdInsert.CommandType = CommandType.StoredProcedure

        '                ' use insert command with sql command and connection object
        '                cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

        '                ' execute query to insert data
        '                intRowsAffected = cmdInsert.ExecuteNonQuery()

        '                ' If not 0 insert successful
        '                If intRowsAffected > 0 Then
        '                    MessageBox.Show("Future flight has been created.")    ' let user know success
        '                End If
        '        End Select

        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try

        '    'close form after submit
        '    Close()
        'End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class