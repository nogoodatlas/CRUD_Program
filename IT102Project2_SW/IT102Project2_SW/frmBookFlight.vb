Public Class frmBookFlight
    'declare variable
    Dim dblTotalCost As Double  'Allows entire form to access and process the total cost for the booking

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

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtf.Load(drSourceTable)

            'load the flight result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboFlights.ValueMember = "TF.intFlightID"
            cboFlights.DisplayMember = "FlightInfo"
            cboFlights.DataSource = dtf

            'make sure cboFlights and labels are empty upon load
            cboFlights.Text = String.Empty
            lblFlightDate.Text = String.Empty
            lblFlightFrom.Text = String.Empty
            lblFlightTo.Text = String.Empty
            lstFlightCost.Items.Clear()

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try

        'ensure radio buttons are invisible and false upon form load
        radReserved.Visible = False
        radAssigned.Visible = False

        radReserved.Checked = False
        radAssigned.Checked = False
    End Sub


    Private Sub cboFlights_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlights.SelectedIndexChanged
        'this Sub() Is called anytime the selected item Is changed in the combo box.
        Dim strSelect As String = ""
        Dim intPassengerCount As Integer    'keep track of how many passengers are on a given flight
        Dim intPlaneType As Integer         'keeps track of plane type (used to determine plane's passenger capacity)
        Dim intFlightMiles As Integer       'keeps track of miles a flight is traveling
        Dim blnAvailable As Boolean = True  'to validate if flight is full

        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader

        'get details on selected flight
        Call FlightDetails(intPassengerCount, intPlaneType, intFlightMiles)

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

            'determine if the selected flight is at capacity
            If intPlaneType = 1 And intPassengerCount = 48 Then         'for plane type Airbus A350
                MessageBox.Show("This flight is currently full!")
                cboFlights.Text = String.Empty
                blnAvailable = False
            ElseIf intPlaneType = 2 And intPassengerCount = 60 Then     'for plane type Boeing 747-8
                MessageBox.Show("This flight is currently full!")
                cboFlights.Text = String.Empty
                blnAvailable = False
            ElseIf intPlaneType = 3 And intPassengerCount = 90 Then     'for plane type Boeing 767-300F
                MessageBox.Show("This flight is currently full!")
                cboFlights.Text = String.Empty
                blnAvailable = False
            End If

            If blnAvailable = True Then
                'make radio buttons visible
                radReserved.Visible = True
                radAssigned.Visible = True


                ' Build the select statement using PK from flight selected
                strSelect = "SELECT dtmFlightDate, " &
                            "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intFromAirportID) AS DepartureCity, " &
                            "(SELECT strAirportCity FROM TAirports WHERE intAirportID = TF.intToAirportID) AS ArrivalCity " &
                            "FROM TFlights AS TF WHERE TF.intFlightID = " & cboFlights.SelectedValue

                'MessageBox.Show(strSelect)

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                ' populate the text boxes with the data
                lblFlightDate.Text = drSourceTable("dtmFlightDate")
                lblFlightFrom.Text = drSourceTable("DepartureCity")
                lblFlightTo.Text = drSourceTable("ArrivalCity")
            End If

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub FlightDetails(ByRef intPassengerCount As Integer, ByRef intPlaneType As Integer, ByRef intFlightMiles As Integer)
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

            'build the select statement
            strSelect = "SELECT COUNT(TFP.intFlightPassengerID) AS PassengerCount, TP.intPlaneTypeID, TF.intMilesFlown " &
                        "FROM TFlights AS TF LEFT JOIN TFlightPassengers AS TFP ON TF.intFlightID = TFP.intFlightID " &
                        "JOIN TPlanes AS TP ON TP.intPlaneID = TF.intPlaneID " &
                        "WHERE TF.intFlightID = " & cboFlights.SelectedValue & " GROUP BY TP.intPlaneTypeID, TF.intMilesFlown"

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            'populate the variables with the data
            intPassengerCount = drSourceTable("PassengerCount")
            intPlaneType = drSourceTable("intPlaneTypeID")
            intFlightMiles = drSourceTable("intMilesFlown")

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub radReserved_CheckedChanged(sender As Object, e As EventArgs) Handles radReserved.CheckedChanged
        'declare variables
        Dim intPassengerCount As Integer
        Dim intPlaneType As Integer
        Dim intFlightMiles As Integer
        Dim blnValidated As Boolean = True

        Dim frmAirbus As New frmAirbusA350
        Dim frmBoeing747 As New frmBoeing7478
        Dim frmBoeing767 As New frmBoeing767300F

        'clear lstFlightCost upon click in case it's already displaying costs
        lstFlightCost.Items.Clear()

        Call FlightDetails(intPassengerCount, intPlaneType, intFlightMiles)

        'set global variable for seating forms to reference
        gblFlightID = cboFlights.SelectedValue

        'direct customer to seating form dependant on which plane type the flight is
        If intPlaneType = 1 Then
            frmAirbus.ShowDialog()
        ElseIf intPlaneType = 2 Then
            frmBoeing747.ShowDialog()
        ElseIf intPlaneType = 3 Then
            frmBoeing767.ShowDialog()
            End If

        If gblSeat = "" Then
            radReserved.Checked = False
            blnValidated = False
        End If

        If blnValidated = True Then
            Call CalculateDisplayTotal()
        End If
    End Sub

    Private Sub radAssigned_CheckedChanged(sender As Object, e As EventArgs) Handles radAssigned.CheckedChanged
        'clear lstFlightCost upon click in case it's already displaying costs
        lstFlightCost.Items.Clear()

        gblSeat = "Assigned by Airline"

        Call CalculateDisplayTotal()
    End Sub


    Private Sub CalculateDisplayTotal()
        'declare variables
        Dim intPassengerCount As Integer
        Dim intPlaneType As Integer
        Dim intFlightMiles As Integer

        Dim dblSubtotal As Double
        Dim dblDiscounts As Double
        Dim blnValidated As Boolean = True

        Call FlightDetails(intPassengerCount, intPlaneType, intFlightMiles)

        dblSubtotal = CalculateSubtotal(intPassengerCount, intPlaneType, intFlightMiles)
        dblDiscounts = CalculateDiscounts(dblSubtotal)

        dblTotalCost = dblSubtotal - dblDiscounts

        If gblSeat = "" Then
            blnValidated = False
        End If

        If blnValidated = True Then
            'display totals
            lstFlightCost.Items.Add(vbTab & "------ Ticket Total ------")
            lstFlightCost.Items.Add("")

            lstFlightCost.Items.Add("Seat : " & gblSeat)
            lstFlightCost.Items.Add("")

            lstFlightCost.Items.Add("Subtotal: " & dblSubtotal.ToString("c"))
            lstFlightCost.Items.Add("Discounts: - " & dblDiscounts.ToString("c"))
            lstFlightCost.Items.Add("Total: " & dblTotalCost.ToString("c"))

        End If
    End Sub

    Private Function CalculateSubtotal(ByVal intPassengerCount As Integer, ByVal intPlaneType As Integer, ByVal intFlightMiles As Integer) As Double
        'declare variable
        Dim subtotal As Double = 250
        Dim dblSeatCost As Double

        If intFlightMiles > 750 Then
            subtotal += 50
        End If

        If intPassengerCount > 8 Then
            subtotal += 100
        ElseIf intPassengerCount < 4 Then
            subtotal -= 50
        End If

        dblSeatCost = CalculateSeatCost(intPlaneType)

        If lblFlightTo.Text = "Miami" Then
            subtotal += 15
        End If

        Return subtotal + dblSeatCost
    End Function

    Private Function CalculateSeatCost(ByVal intPlaneType As Integer) As Double
        'declare variables
        Dim strSeat As String   'represents seat section (letter)
        Dim strRowNum As String 'represents seat row number
        Dim cost As Double = 0  'set as 0 by default

        'calculate seating prices
        If gblSeat = "" Then
            Return 0

        ElseIf gblSeat <> "Assigned by Airline" Then
            strSeat = gblSeat.Substring(0, 1)
            strRowNum = gblSeat.Substring(1)

            If intPlaneType = 1 Then        'for Airbus A350

                If strRowNum = "1" Or strRowNum = "2" Or strRowNum = "3" Or strRowNum = "4" Then
                    cost += 50
                ElseIf strRowNum = "5" Or strRowNum = "6" Or strRowNum = "7" Or strRowNum = "8" Then
                    cost += 25
                ElseIf strRowNum = "9" Or strRowNum = "10" Or strRowNum = "11" Or strRowNum = "12" Then
                    cost += 10
                End If

            ElseIf intPlaneType = 2 Then    'for Boeing 747-8

                If strRowNum = "1" Or strRowNum = "2" Or strRowNum = "3" Then
                    cost += 50
                ElseIf strRowNum = "4" Or strRowNum = "5" Or strRowNum = "6" Or strRowNum = "7" Or strRowNum = "8" Then
                    cost += 25
                ElseIf strRowNum = "9" Or strRowNum = "10" Then
                    cost += 10
                End If

            ElseIf intPlaneType = 3 Then    'for Boeing 767-300F

                If strRowNum = "1" Or strRowNum = "2" Or strRowNum = "3" Then
                    cost += 150
                ElseIf strRowNum = "4" Or strRowNum = "5" Or strRowNum = "6" Or strRowNum = "7" Or strRowNum = "8" Then
                    cost += 50
                ElseIf strRowNum = "9" Or strRowNum = "10" Then
                    cost += 20
                End If

                If strSeat = "D" Or strSeat = "E" Or strSeat = "F" Then
                    cost -= 10
                End If

            End If
        End If

        Return cost
    End Function

    Private Function CalculateDiscounts(ByVal dblSubtotal As Double) As Double
        'declare variables
        Dim intPassengerFlights As Integer
        Dim intAge As Integer
        Dim discount As Double  'stores discount as a decimal

        Call CustomerDetails(intAge, intPassengerFlights)

        If intAge >= 65 Then
            discount += 0.2
        ElseIf intAge < 5 Then
            discount += 0.65
        End If

        If intPassengerFlights > 5 Then
            discount += 0.1
        ElseIf intPassengerFlights > 10 Then
            discount += 0.2
        End If

        Return discount * dblSubtotal
    End Function

    Private Sub CustomerDetails(ByRef intAge As Integer, ByRef intPassengerFlights As Integer)
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

            Call GetPassengerFlights(intPassengerFlights)

            Call GetPassengerAge(intAge)

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetPassengerFlights(ByRef intPassengerFlights As Integer)
        'declare variables
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures

        Try

            ' Build the select statement using the stored procedure uspCustomerPastFlights
            cmdSelect = New OleDb.OleDbCommand("uspCustomerDetails", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' here we are defining the parameter used within uspCustomerPastFlights
            objParam = cmdSelect.Parameters.Add("@intPassengerID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = gblPassengerID

            ' Retrieve all the records 
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            intPassengerFlights = drSourceTable("PassengerFlights")

            ' Clean up
            drSourceTable.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetPassengerAge(ByRef intAge As Integer)
        'declare variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to

        Try

            'build the select statement
            strSelect = "SELECT DATEDIFF(YY,dtmDOB,GETDATE()) AS PassengerAge " &
                        "FROM TPassengers WHERE intPassengerID = " & gblPassengerID

            'MessageBox.Show(strSelect)

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            intAge = drSourceTable("PassengerAge")

            ' Clean up
            drSourceTable.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'declare variables
        Dim intFlightID As Integer
        Dim intFlightPassengerID As Integer ' holds next highest PK value
        Dim result As DialogResult  ' this is the result of which button the user selects
        Dim blnValidated As Boolean = True

        Dim cmdInsert As New OleDb.OleDbCommand() ' insert command object
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        'validate inputs
        Call ValidateInput(blnValidated)

        'put values into strings
        intFlightID = cboFlights.SelectedValue

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
                        cmdInsert.CommandText = "EXECUTE uspBookFlight " & intFlightPassengerID & "," & intFlightID & "," & gblPassengerID & ",'" & gblSeat & "', " & dblTotalCost.ToString("c")
                        cmdInsert.CommandType = CommandType.StoredProcedure

                        ' use insert command with sql command and connection object
                        cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                        ' execute query to insert data
                        intRowsAffected = cmdInsert.ExecuteNonQuery()

                        ' If not 0 insert successful
                        If intRowsAffected > 0 Then
                            MessageBox.Show("Passenger flight has been added.")    ' let user know success
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

        'validate seat selection has been chosen
        If radReserved.Checked = False And radAssigned.Checked = False Then
            MessageBox.Show("Please select whether you'd like to reserve a seat or have one assigned to you.")
            blnValidated = False
        End If

        'validate a seat selection has been made
        If gblSeat = "" Then
            MessageBox.Show("Please make a seat selection.")
            radReserved.Checked = False
            radAssigned.Checked = False
            blnValidated = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class