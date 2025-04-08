Public Class frmAttendantMain
    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        'clears list box
        lstDisplayFlights.Items.Clear()

        'calls data loads
        Call PastFlights() 'displays data of all past flights for attendants
        Call PastMiles()   'displays total of past miles flown
    End Sub

    Private Sub PastFlights()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our flight result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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
            strSelect = "SELECT DISTINCT TF.dtmFlightDate, TF.strFlightNumber, TF.dtmTimeofDeparture, TF.dtmTimeofLanding, TF.intMilesFlown, " &
                        "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity, " &
                        "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity, " &
                        "(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum " &
                        "FROM TFlights AS TF JOIN TAttendantFlights AS TAF " &
                        "ON TF.intFlightID = TAF.intFlightID " &
                        "JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID " &
                        "WHERE TAF.intAttendantID = " & gblAttendantID & " AND TF.dtmFlightDate <= GETDATE() " &
                        "ORDER BY TF.dtmFlightDate"


            MessageBox.Show(strSelect)

            'retrieve all the records for past flights
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox
            lstDisplayFlights.Items.Add("Roster of All Past Flights")
            lstDisplayFlights.Items.Add("=============================")

            While drSourceTable.Read()

                lstDisplayFlights.Items.Add("  ")

                lstDisplayFlights.Items.Add("Flight Date: " & vbTab & vbTab & drSourceTable("dtmFlightDate"))
                lstDisplayFlights.Items.Add("Flight Number: " & vbTab & vbTab & drSourceTable("strFlightNumber"))
                lstDisplayFlights.Items.Add("Plane Number: " & vbTab & vbTab & drSourceTable("PlaneNum"))
                lstDisplayFlights.Items.Add("City of Departure: " & vbTab & vbTab & drSourceTable("DepartureCity"))
                lstDisplayFlights.Items.Add("Time of Departure: " & vbTab & vbTab & drSourceTable("dtmTimeofDeparture"))
                lstDisplayFlights.Items.Add("City of Landing: " & vbTab & vbTab & drSourceTable("ArrivalCity"))
                lstDisplayFlights.Items.Add("Time of Landing: " & vbTab & vbTab & drSourceTable("dtmTimeofLanding"))
                lstDisplayFlights.Items.Add("Miles Flown: " & vbTab & vbTab & drSourceTable("intMilesFlown"))

                lstDisplayFlights.Items.Add("  ")
                lstDisplayFlights.Items.Add("=============================")

            End While

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub PastMiles()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our flight result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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

            'Build the miles statement
            strSelect = "SELECT SUM(TF.intMilesFlown) AS TotalMiles " &
                        "FROM TFlights AS TF JOIN TAttendantFlights AS TAF " &
                        "ON TF.intFlightID = TAF.intFlightID " &
                        "JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID " &
                        "WHERE TAF.intAttendantID = " & gblAttendantID & " AND TF.dtmFlightDate <= GETDATE()"

            'Retrieve all the records for past miles flown
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lstDisplayFlights.Items.Add("  ")
            lstDisplayFlights.Items.Add("Past Miles Flown: " & vbTab & vbTab & drSourceTable("TotalMiles"))
            lstDisplayFlights.Items.Add("  ")

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnFutureFlights_Click(sender As Object, e As EventArgs) Handles btnFutureFlights.Click
        'clears list box
        lstDisplayFlights.Items.Clear()

        'calls data loads
        Call FutureFlights() 'displays data of all future flights for attendants
        Call PlannedMiles()  'displays total of all future miles planned
    End Sub

    Private Sub FutureFlights()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our flight result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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
            strSelect = "SELECT DISTINCT TF.dtmFlightDate, TF.strFlightNumber, TF.dtmTimeofDeparture, TF.dtmTimeofLanding, TF.intMilesFlown, " &
                        "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity, " &
                        "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity, " &
                        "(SELECT strPlaneNumber FROM TPlanes WHERE intPlaneID = TF.intPlaneID) AS PlaneNum " &
                        "FROM TFlights AS TF JOIN TAttendantFlights AS TAF " &
                        "ON TF.intFlightID = TAF.intFlightID " &
                        "JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID " &
                        "WHERE TAF.intAttendantID = " & gblAttendantID & " AND TF.dtmFlightDate >= GETDATE() " &
                        "ORDER BY TF.dtmFlightDate"


            MessageBox.Show(strSelect)

            'retrieve all the records for past flights
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox
            lstDisplayFlights.Items.Add("Roster of All Future Flights")
            lstDisplayFlights.Items.Add("=============================")

            While drSourceTable.Read()

                lstDisplayFlights.Items.Add("  ")

                lstDisplayFlights.Items.Add("Flight Date: " & vbTab & vbTab & drSourceTable("dtmFlightDate"))
                lstDisplayFlights.Items.Add("Flight Number: " & vbTab & vbTab & drSourceTable("strFlightNumber"))
                lstDisplayFlights.Items.Add("Plane Number: " & vbTab & vbTab & drSourceTable("PlaneNum"))
                lstDisplayFlights.Items.Add("City of Departure: " & vbTab & vbTab & drSourceTable("DepartureCity"))
                lstDisplayFlights.Items.Add("City of Landing: " & vbTab & vbTab & drSourceTable("ArrivalCity"))
                lstDisplayFlights.Items.Add("Miles Flown: " & vbTab & vbTab & drSourceTable("intMilesFlown"))

                lstDisplayFlights.Items.Add("  ")
                lstDisplayFlights.Items.Add("=============================")

            End While

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub PlannedMiles()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our flight result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader


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

            'Build the miles statement
            strSelect = "SELECT SUM(TF.intMilesFlown) AS TotalMiles " &
                        "FROM TFlights AS TF JOIN TAttendantFlights AS TAF " &
                        "ON TF.intFlightID = TAF.intFlightID " &
                        "JOIN TAttendants AS TA ON TA.intAttendantID = TAF.intAttendantID " &
                        "WHERE TAF.intAttendantID = " & gblAttendantID & " AND TF.dtmFlightDate >= GETDATE()"

            'Retrieve all the records for past miles flown
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lstDisplayFlights.Items.Add("  ")
            lstDisplayFlights.Items.Add("Future Miles Scheduled: " & vbTab & vbTab & drSourceTable("TotalMiles"))
            lstDisplayFlights.Items.Add("  ")

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'declare variable
        Dim frmUpdate As New frmUpdateAttendant

        'opens form to update pilot profile
        frmUpdate.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class