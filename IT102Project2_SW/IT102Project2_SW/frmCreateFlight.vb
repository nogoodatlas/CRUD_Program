Public Class frmCreateFlight
    Private Sub frmCreateFlight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand  ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dta As DataTable = New DataTable ' this is the table we will load from our reader for airports (arrival)
        Dim dtd As DataTable = New DataTable ' this is the table we will load from our reader for airports (departure)
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader for planes

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

            ' Build the select statement
            strSelect = "SELECT intAirportID, strAirportCity + ' - ' + strAirportCode As AirportName FROM TAirports"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            ' load table from data reader
            dtd.Load(drSourceTable)

            cboArrivals.ValueMember = "intAirportID"
            cboArrivals.DisplayMember = "AirportName"
            cboArrivals.DataSource = dtd

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
        'declare variables
        Dim intFlightID As Integer     'holds highest PK value
        Dim dteFlightDate As Date
        Dim strFlightNumber As String
        Dim dteDates As Date           'this is a placeholder for both time of departure and time of arrival
        Dim intFromAirport As Integer
        Dim intToAirport As Integer
        Dim intMiles As Integer
        Dim intPlane As Integer
        Dim result As DialogResult     'this is the result of which button the user selects
        Dim blnValidated As Boolean = True

        Dim cmdInsert As New OleDb.OleDbCommand() ' insert command object
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed


        'validate inputs
        Call ValidateInput(blnValidated, dteFlightDate, intMiles)

        If blnValidated = True Then

            'put values into variables
            strFlightNumber = txtFlightNumber.Text
            dteFlightDate = dtmFlightDate.Value
            intFromAirport = cboDepartures.SelectedValue
            intToAirport = cboArrivals.SelectedValue
            intMiles = txtFlightDistance.Text
            intPlane = cboPlanes.SelectedValue

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
                result = MessageBox.Show("Are you sure you want to create this flight?", "Flight Creation Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                ' this will figure out which button was selected. Cancel and No does nothing, Yes will allow info to be stored
                Select Case result
                    Case DialogResult.Cancel
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.No
                        MessageBox.Show("Action Canceled")
                    Case DialogResult.Yes

                        ' build insert statement (columns must match DB columns in name and the # of columns)
                        cmdInsert.CommandText = "EXECUTE uspCreateFlight " & intFlightID & ", '" & dteDates & "', '" & dteDates & "', '" &
                        dteFlightDate & "', '" & strFlightNumber & "', " & intFromAirport & ", " & intToAirport & ", " & intMiles & ", " & intPlane
                        cmdInsert.CommandType = CommandType.StoredProcedure

                        MessageBox.Show(cmdInsert.CommandText)

                        ' use insert command with sql command and connection object
                        cmdInsert = New OleDb.OleDbCommand(cmdInsert.CommandText, m_conAdministrator)

                        ' execute query to insert data
                        intRowsAffected = cmdInsert.ExecuteNonQuery()

                        ' If not 0 insert successful
                        If intRowsAffected > 0 Then
                            MessageBox.Show("Future flight has been created.")    ' let user know success
                        End If
                End Select

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'close form after submit
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal dteFlightDate As Date, ByVal intMiles As Integer)
        Call ValidateFlightNumber(blnValidated)
        Call ValidateFlightDate(blnValidated, dteFlightDate)
        Call ValidateAirports(blnValidated)
        Call ValidateFlightMiles(blnValidated, intMiles)
        Call ValidatePlane(blnValidated)
    End Sub

    Private Sub ValidateFlightNumber(ByRef blnValidated As Boolean)
        If txtFlightNumber.Text = String.Empty Then
            MessageBox.Show("Please input a flight number.")
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateFlightDate(ByRef blnValidated As Boolean, ByVal dteFlightDate As Date)
        'validate that flight date is later than current date
        If dteFlightDate > DateTime.Now Then
            MessageBox.Show("Flight date must be later than current date.")
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateAirports(ByRef blnValidated As Boolean)
        'validate that an airport selection has been made for both departure and arrival
        If cboArrivals.Text = String.Empty Or cboDepartures.Text = String.Empty Then
            MessageBox.Show("Please select an airport for both the departure and arrival.")
            cboDepartures.Focus()
            blnValidated = False
        End If

        If cboDepartures.SelectedValue = cboArrivals.SelectedValue Then
            MessageBox.Show("You must select two different airports for departure and arrival.")
            cboDepartures.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateFlightMiles(ByRef blnValidated As Boolean, ByVal intMiles As Integer)
        'validate flight miles field is not empty
        If txtFlightDistance.Text = String.Empty Then
            MessageBox.Show("Please input the distance of the flight.")
            txtFlightDistance.Focus()
            blnValidated = False
        Else
            'validate that flight miles is an integer greater than 0
            If Integer.TryParse(txtFlightDistance.Text, intMiles) Then
                If txtFlightDistance.Text < 1 Then
                    MessageBox.Show("Number of miles must be an integer greater than 0.")
                    txtFlightDistance.Focus()
                    blnValidated = False
                End If
            Else
                MessageBox.Show("Number of miles must be an integer.")
                txtFlightDistance.Focus()
                blnValidated = False
            End If
        End If
    End Sub

    Private Sub ValidatePlane(ByRef blnValidated As Boolean)
        If cboPlanes.Text = String.Empty Then
            MessageBox.Show("Please assign a plane to this flight.")
            cboPlanes.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'closes form
        Close()
    End Sub
End Class