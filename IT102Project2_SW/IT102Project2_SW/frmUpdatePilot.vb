﻿Public Class frmUpdatePilot
    Private Sub frmUpdatePilot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'declare variables
        Dim strSelect As String = ""
        Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
        Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
        Dim dt As DataTable = New DataTable ' this is the table we will load from our reader
        Dim dtp As DataTable = New DataTable ' this is the table we will load from our reader for pilot roles
        Dim objParam As OleDb.OleDbParameter ' this will be used to add parameters needed for stored procedures

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

            ' Build the select statement using the stored procedure uspPilotDataCall
            cmdSelect = New OleDb.OleDbCommand("uspPilotDataCall", m_conAdministrator)
            cmdSelect.CommandType = CommandType.StoredProcedure

            ' here we are defining the parameter used within uspPilotDataCall
            objParam = cmdSelect.Parameters.Add("@intPilotID", OleDb.OleDbType.Integer)
            objParam.Direction = ParameterDirection.Input
            objParam.Value = gblPilotID

            ' Retrieve all the records 
            drSourceTable = cmdSelect.ExecuteReader
            drSourceTable.Read()

            ' populate the text boxes with the data
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmHireDate.Value = drSourceTable("dtmDateofHire")
            dtmTerminationDate.Value = drSourceTable("dtmDateofTermination")
            dtmLicenseDate.Value = drSourceTable("dtmDateofLicense")
            cboPilotRoles.SelectedValue = drSourceTable("intPilotRoleID")

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdatePilot_Click(sender As Object, e As EventArgs) Handles btnUpdatePilot.Click
        'declare variables
        Dim strUpdate As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dteHireDate As Date
        Dim dteTerminationDate As Date
        Dim dteLicenseDate As Date
        Dim intPilotRole As Integer
        Dim blnValidated As Boolean = True
        Dim intRowsAffected As Integer

        ' this will hold our Update statement
        Dim cmdUpdate As OleDb.OleDbCommand

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

                ' open database this is in module
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
                strUpdate = "UPDATE TPilots SET " &
                            "strFirstName = '" & strFirstName & "', " &
                            "strLastName = '" & strLastName & "', " &
                            "strEmployeeID = '" & strEmployeeID & "', " &
                            "dtmDateofHire = '" & dteHireDate & "', " &
                            "dtmDateofTermination = '" & dteTerminationDate & "', " &
                            "dtmDateofLicense = '" & dteLicenseDate & "', " &
                            "intPilotRoleID = " & intPilotRole & " " &
                            "WHERE intPilotID = " & gblPilotID


                ' uncomment out the following message box line to use as a tool to check your sql statement
                ' remember anything not a numeric value going into SQL Server must have single quotes '
                ' around it, including dates.
                'MessageBox.Show(strUpdate)

                ' make the connection
                cmdUpdate = New OleDb.OleDbCommand(strUpdate, m_conAdministrator)

                ' IUpdate the row with execute the statement
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                ' have to let the user know what happened 
                If intRowsAffected >= 1 Then
                    MessageBox.Show("Update successful")
                Else
                    MessageBox.Show("Update failed")
                End If

                ' close the database connection
                CloseDatabaseConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            'closes form upon update
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
            MessageBox.Show("Please enter your first name.")
            txtFirstName.Focus()
            blnValidated = False
        End If

        'validate txtlastname is not empty
        If txtLastName.Text = String.Empty Then
            MessageBox.Show("Please enter your last name.")
            txtLastName.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateEmployeeID(ByRef blnValidated As Boolean)
        'validate txtemployeeid is not empty
        If txtEmployeeID.Text = String.Empty Then
            MessageBox.Show("Please enter your first name.")
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