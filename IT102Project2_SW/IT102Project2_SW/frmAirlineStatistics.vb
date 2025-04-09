Public Class frmAirlineStatistics
    Private Sub frmAirlineStatistics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'call displays
        Call PilotMiles()
        Call AttendantMiles()
        Call CustomerStats()
    End Sub

    Private Sub PilotMiles()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
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
            strSelect = "SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles, " &
                        "TP.strFirstName + ' ' + TP.strLastName AS PilotName " &
                        "FROM TPilots AS TP LEFT JOIN TPilotFlights AS TPF " &
                        "ON TP.intPilotID = TPF.intPilotID  " &
                        "LEFT JOIN TFlights AS TF ON TF.intFlightID = TPF.intFlightID " &
                        "AND TF.dtmFlightDate <= GETDATE() " &
                        "GROUP BY TP.strFirstName, TP.strLastName"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox
            lstPilotMiles.Items.Add("Roster of All Pilots")
            lstPilotMiles.Items.Add("=============================")

            While drSourceTable.Read()

                lstPilotMiles.Items.Add("  ")

                lstPilotMiles.Items.Add("Pilot Name: " & vbTab & drSourceTable("PilotName"))
                lstPilotMiles.Items.Add("Total Miles Flown: " & vbTab & drSourceTable("TotalMiles"))

                lstPilotMiles.Items.Add("  ")
                lstPilotMiles.Items.Add("=============================")

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

    Private Sub AttendantMiles()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our result set will 
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
            strSelect = "SELECT ISNULL(SUM(TF.intMilesFlown), 0) AS TotalMiles, " &
                        "TA.strFirstName + ' ' + TA.strLastName as AttendantName " &
                        "FROM TAttendants AS TA LEFT JOIN TAttendantFlights AS TAF " &
                        "ON TA.intAttendantID = TAF.intAttendantID " &
                        "LEFT JOIN TFlights AS TF ON TAF.intFlightID = TF.intFlightID " &
                        "AND TF.dtmFlightDate <= GETDATE() " &
                        "GROUP BY TA.strFirstName, TA.strLastName"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox
            lstAttendantMiles.Items.Add("Roster of All Attendants")
            lstAttendantMiles.Items.Add("=============================")

            While drSourceTable.Read()

                lstAttendantMiles.Items.Add("  ")

                lstAttendantMiles.Items.Add("Attendant Name: " & vbTab & drSourceTable("AttendantName"))
                lstAttendantMiles.Items.Add("Total Miles Flown: " & vbTab & drSourceTable("TotalMiles"))

                lstAttendantMiles.Items.Add("  ")
                lstAttendantMiles.Items.Add("=============================")

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

    Private Sub CustomerStats()
        'declare variables
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

            ' Build the select statement using PK from name selected
            strSelect = "SELECT COUNT(DISTINCT TP.intPassengerID) AS TotalCustomers, " &
                        "COUNT(TFP.intFlightPassengerID) AS TotalFlights, " &
                        "AVG(TF.intMilesFlown) AS AvgMiles " &
                        "FROM TPassengers AS TP JOIN TFlightPassengers AS TFP " &
                        "ON TP.intPassengerID = TFP.intPassengerID " &
                        "JOIN TFlights AS TF " &
                        "ON TF.intFlightID = TFP.intFlightID"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            ' populate the text boxes with the data
            lblTotalCustomers.Text = drSourceTable("TotalCustomers")
            lblTotalFlights.Text = drSourceTable("TotalFlights")
            lblAvgMiles.Text = drSourceTable("AvgMiles")

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class