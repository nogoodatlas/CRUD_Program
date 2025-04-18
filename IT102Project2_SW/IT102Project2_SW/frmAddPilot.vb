﻿Public Class frmAddPilot
    Private Sub frmAddPilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  On the event Form Load, we are going to populate the Pilot Role combobox from the database
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader for pilot roles

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

            ' Build the select statement
            strSelect = "SELECT intPilotRoleID, strPilotRole FROM TPilotRoles"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            'load the Pilot Role result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboPilotRoles.ValueMember = "intPilotRoleID"
            cboPilotRoles.DisplayMember = "strPilotRole"
            cboPilotRoles.DataSource = dtp

            'keep combobox empty upon load
            cboPilotRoles.Text = String.Empty

            ' Clean up
            drSourceTable.Close()

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception

            ' Log and display error message
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnAddPilot_Click(sender As Object, e As EventArgs) Handles btnAddPilot.Click
        'variables for new pilot data and select and insert statements
        Dim strInsert As String
        Dim strSelect As String
        Dim frmPilot As New frmPilotMain
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dteHireDate As Date
        Dim dteTerminationDate As Date
        Dim dteLicenseDate As Date
        Dim intPilotRole As Integer
        Dim blnValidated As Boolean = True

        Dim cmdSelect As OleDb.OleDbCommand ' select command object
        Dim cmdInsert As OleDb.OleDbCommand ' insert command object
        Dim drSourceTable As OleDb.OleDbDataReader ' data reader for pulling info
        Dim intNextPrimaryKey As Integer ' holds next highest PK value
        Dim intRowsAffected As Integer  ' how many rows were affected when sql executed

        ' put values into strings
        strFirstName = txtFirstName.Text
        strLastName = txtLastName.Text
        strEmployeeID = txtEmployeeID.Text
        dteHireDate = dtmHireDate.Value
        dteTerminationDate = dtmTerminationDate.Value
        dteLicenseDate = dtmLicenseDate.Value
        intPilotRole = cboPilotRoles.SelectedValue

        ' validate data is entered
        Call ValidateInput(blnValidated, dteHireDate, dteTerminationDate, dteLicenseDate)

        If blnValidated = True Then

            Try

                If OpenDatabaseConnectionSQLServer() = False Then

                    ' No, warn the user ...
                    MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                    ' and close the form/application
                    Me.Close()

                End If

                strSelect = "SELECT MAX(intPilotID) + 1 AS intNextPrimaryKey " &
                                " FROM TPilots"

                ' Execute command
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                ' Read result( highest ID )
                drSourceTable.Read()

                ' Null? (empty table)
                If drSourceTable.IsDBNull(0) = True Then

                    ' Yes, start numbering at 1
                    intNextPrimaryKey = 1

                Else

                    ' No, get the next highest ID
                    intNextPrimaryKey = CInt(drSourceTable("intNextPrimaryKey"))

                End If

                ' build insert statement (columns must match DB columns in name and the # of columns)
                strInsert = "INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)" &
                    " VALUES (" & intNextPrimaryKey & ",'" & strFirstName & "','" & strLastName & "','" & strEmployeeID & "','" & dteHireDate & "','" & dteTerminationDate & "','" & dteLicenseDate & "'," & intPilotRole & ")"

                'set next primary key equal to global variable for pilot ID
                gblPilotID = intNextPrimaryKey

                'MessageBox.Show(strInsert)

                ' use insert command with sql string and connection object
                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                ' execute query to insert data
                intRowsAffected = cmdInsert.ExecuteNonQuery()

                ' If not 0 insert successful
                If intRowsAffected > 0 Then
                    MessageBox.Show("Pilot has been added")    ' let user know success
                    ' close new player form
                End If

                CloseDatabaseConnection()       ' close connection if insert didn't work

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'open pilot main menu upon creating pilot
            frmPilot.ShowDialog()

            'closes form upon creating pilot
            Close()
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal dteHireDate As Date, ByVal dteTerminationDate As Date, ByVal dteLicenseDate As Date)
        Call ValidateName(blnValidated)
        Call ValidateEmployeeID(blnValidated)
        Call ValidateHireTerminationDate(blnValidated, dteHireDate, dteTerminationDate)
        Call ValidateLicenseDate(blnValidated, dteLicenseDate)
        Call ValidatePilotRole(blnValidated)
    End Sub

    Private Sub ValidateName(ByRef blnValidated As Boolean)
        'validate txtfirstname is not empty
        If txtFirstName.Text = String.Empty Then
            MessageBox.Show("Please enter first name.")
            txtFirstName.Focus()
            blnValidated = False
        End If

        'validate txtlastname is not empty
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please enter last name.")
            txtLastName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateEmployeeID(ByRef blnValidated As Boolean)
        'validate txtemployeeid is not empty
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter employee ID.")
            txtEmployeeID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateHireTerminationDate(ByRef blnValidated As Boolean, ByVal dteHireDate As Date, ByVal dteTerminationDate As Date)
        'validate that hire date is not later than current date
        If dteHireDate > DateTime.Now Then
            MessageBox.Show("Date of hire cannot be later than current date.")
            dtmHireDate.Focus()
            blnValidated = False
        End If

        'validate that termination date later than hire date
        If dteHireDate > dteTerminationDate Then
            MessageBox.Show("Termination date must be later than hire date.")
            dtmTerminationDate.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateLicenseDate(ByRef blnValidated As Boolean, ByVal dteLicenseDate As Date)
        'validate that license date is later than current date
        If dteLicenseDate > DateTime.Now Then
            MessageBox.Show("Date of license cannot be later than current date.")
            dtmLicenseDate.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidatePilotRole(ByRef blnValidated As Boolean)
        'validate that pilot role combobox is not empty
        If cboPilotRoles.Text = String.Empty Then
            MessageBox.Show("Select a pilot role.")
            cboPilotRoles.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class