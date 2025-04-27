Public Class frmBookFlight
    Private Sub frmBookFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  On the event Form Load, we are going to populate the Flight combobox from the database
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dtf As DataTable = New DataTable ' this is the table we will load from our reader for flights

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
            strSelect = "SELECT TF.intFlightID, 'Flight ' + TF.strFlightNumber + ' - ' + TA.strAirportCode AS FlightInfo " &
                        "FROM TFlights AS TF JOIN TAirports AS TA " &
                        "ON TF.intFromAirportID = TA.intAirportID " &
                        "WHERE TF.dtmFlightDate >= GETDATE()"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtf.Load(drSourceTable)

            'load the State result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboFlights.ValueMember = "intFlightID"
            cboFlights.DisplayMember = "FlightInfo"
            cboFlights.DataSource = dtf

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub cboFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlights.SelectedIndexChanged
        'this Sub() Is called anytime the selected item Is changed in the combo box.
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

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

            ' Build the select statement using PK from flight selected
            strSelect = "SELECT dtmFlightDate, " &
                      "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity, " &
                      "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity " &
                      "FROM TFlights AS TF " &
                      "WHERE TF.intFlightID = " & cboFlights.SelectedValue

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            ' populate the text boxes with the data
            lblFlightDate.Text = drSourceTable("dtmFlightDate")
            lblFlightFrom.Text = drSourceTable("DepartureCity")
            lblFlightTo.Text = drSourceTable("ArrivalCity")

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'declare variables
        Dim intFlightID As Integer
        Dim strSeat As String
        Dim intFlightPassengerID As Integer ' holds next highest PK value
        Dim result As DialogResult  ' this is the result of which button the user selects
        Dim blnValidated As Boolean = True

        Dim cmdInsert As New OleDb.OleDbCommand() ' insert command object
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        'validate inputs
        Call ValidateInput(blnValidated)

        'put values into strings
        intFlightID = cboFlights.SelectedValue
        strSeat = cboSeats.Text

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

                ' always ask before inserting info into the database!!!!
                result = MessageBox.Show("Are you sure you want to book this flight?", "Booking Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow info to be stored
                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.No
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.Yes

                        ' build insert statement (columns must match DB columns in name and the # of columns)
                        cmdInsert.CommandText = "EXECUTE uspBookFlight " & intFlightPassengerID & "," & intFlightID & "," & gblPassengerID & ",'" & strSeat & "'"
                        cmdInsert.CommandType = CommandType.StoredProcedure

                        ' use insert command with sql command and connection object
                        cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                        ' execute query to insert data
                        intRowsAffected = cmdInsert.ExecuteNonQuery()

                        ' If not 0 insert successful
                        If intRowsAffected > 0 Then
                            MessageBox.Show("Passenger flight has been added.")    ' let user know success
                            ' close new player form
                        End If
                End Select

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'close form after submit
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean)
        'validate flight has been chosen
        If cboFlights.Text = String.Empty Then
            MessageBox.Show("Please select a flight.")
            cboFlights.Focus()
            blnValidated = False
        End If

        'validate seat has been chosen
        If cboSeats.Text = String.Empty Then
            MessageBox.Show("Please select a seat.")
            cboSeats.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class