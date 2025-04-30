Imports System.Globalization

Public Class frmCustomerMain
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'declare variable
        Dim frmUpdate As New frmUpdateCustomer

        'opens form to update customer profile
        frmUpdate.ShowDialog()
    End Sub

    Private Sub btnBookFlight_Click(sender As Object, e As EventArgs) Handles btnBookFlight.Click
        'opens form to book flight
        frmBookFlight.ShowDialog()
    End Sub

    Private Sub btnPastFlights_Click(sender As Object, e As EventArgs) Handles btnPastFlights.Click
        'clears list box
        lstDisplayFlights.Items.Clear()

        'calls data loads
        Call PastFlights() 'displays data of all past flights for passenger
        Call PastMiles()   'displays total of past miles flown
    End Sub

    Private Sub PastFlights()
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our flight result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader
            Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures


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

            ' Build the select statement using the stored procedure uspCustomerPastFlights
            cmdSelect = New OleDb.OleDbCommand("uspCustomerPastFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' here we are defining the parameter used within uspCustomerPastFlights
            objParam = cmdSelect.Parameters.Add("@intPassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = gblPassengerID

            ' Retrieve all the records 
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
            Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures


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

            ' Build the select statement using the stored procedure uspCustomerPastMiles
            cmdSelect = New OleDb.OleDbCommand("uspCustomerPastMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' here we are defining the parameter used within uspCustomerPastMiles
            objParam = cmdSelect.Parameters.Add("@intPassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = gblPassengerID

            ' Retrieve all the records 
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
        Call FutureFlights() 'displays data of all future flights for passenger
        Call PlannedMiles()  'displays total of all future miles planned
    End Sub

    Private Sub FutureFlights()
        Try

            Dim strSelect As String = ""
            Dim dblTotalCost As Double
            Dim cmdSelect As OleDb.OleDbCommand            ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader     ' this will be where our flight result set will 
            Dim dt As DataTable = New DataTable            ' this is the table we will load from our reader
            Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures


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

            ' Build the select statement using the stored procedure uspCustomerFutureFlights
            cmdSelect = New OleDb.OleDbCommand("uspCustomerFutureFlights", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' here we are defining the parameter used within uspCustomerFutureFlights
            objParam = cmdSelect.Parameters.Add("@intPassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = gblPassengerID

            ' Retrieve all the records 
            drSourceTable = cmdSelect.ExecuteReader

            'loop through result set and display in Listbox
            lstDisplayFlights.Items.Add("Roster of All Future Flights")
            lstDisplayFlights.Items.Add("=============================")

            While drSourceTable.Read()

                dblTotalCost = drSourceTable("monTotalCost")

                lstDisplayFlights.Items.Add("  ")


                lstDisplayFlights.Items.Add("Flight Date: " & vbTab & vbTab & drSourceTable("dtmFlightDate"))
                lstDisplayFlights.Items.Add("Flight Number: " & vbTab & vbTab & drSourceTable("strFlightNumber"))
                lstDisplayFlights.Items.Add("Plane Number: " & vbTab & vbTab & drSourceTable("PlaneNum"))
                lstDisplayFlights.Items.Add("Seat Number: " & vbTab & vbTab & drSourceTable("strSeat"))
                lstDisplayFlights.Items.Add("City of Departure: " & vbTab & vbTab & drSourceTable("DepartureCity"))
                lstDisplayFlights.Items.Add("City of Landing: " & vbTab & vbTab & drSourceTable("ArrivalCity"))
                lstDisplayFlights.Items.Add("Miles Flown: " & vbTab & vbTab & drSourceTable("intMilesFlown"))

                lstDisplayFlights.Items.Add("")
                lstDisplayFlights.Items.Add("Ticket Cost: " & vbTab & vbTab & dblTotalCost.ToString("c"))

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
            Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures


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

            ' Build the select statement using the stored procedure uspCustomerFutureMiles
            cmdSelect = New OleDb.OleDbCommand("uspCustomerFutureMiles", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' here we are defining the parameter used within uspCustomerFutureMiles
            objParam = cmdSelect.Parameters.Add("@intPassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = gblPassengerID

            ' Retrieve all the records 
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            lstDisplayFlights.Items.Add("  ")
            lstDisplayFlights.Items.Add("Future Miles Planned: " & vbTab & vbTab & drSourceTable("TotalMiles"))
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

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        'closes form
        Close()
    End Sub
End Class