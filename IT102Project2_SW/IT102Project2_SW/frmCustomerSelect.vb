﻿Public Class frmCustomerSelect
    Private Sub frmCustomerSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  On the event Form Load, we are going to populate the Passenger combobox from the database
        Try
            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand ' this will be used for our Select statement
            Dim drSourceTable As OleDb.OleDbDataReader ' this will be where our data is retrieved to
            Dim dtp As DataTable = New DataTable 'this is the table we will load from our reader for Passengers

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
            strSelect = "SELECT TP.intPassengerID, TP.strFirstName + ' ' + TP.strLastName AS PassengerName FROM TPassengers AS TP"

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader
            dtp.Load(drSourceTable)

            'load the Passenger result set into the combobox.  For VB, we do this by binding the data to the combobox
            cboPassengers.ValueMember = "TP.intPassengerID"
            cboPassengers.DisplayMember = "PassengerName"
            cboPassengers.DataSource = dtp

            'makes combobox empty by default
            cboPassengers.Text = String.Empty

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
        Dim frmCustomer As New frmCustomerMain
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
                strSelect = "SELECT TP.intPassengerID, TP.strFirstName + ' ' + TP.strLastName AS PassengerName FROM TPassengers AS TP"

                ' Retrieve all the records 
                cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
                drSourceTable = cmdSelect.ExecuteReader

                drSourceTable.Read()

                ' populate the variable with the data
                gblPassengerID = cboPassengers.SelectedValue

                ' close the database connection
                CloseDatabaseConnection()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            frmCustomer.ShowDialog()        'opens form for customer main menu
        End If
    End Sub

    Private Sub ValidateInput(ByRef blnValidated As Boolean)
        'validate combobox is not empty
        If cboPassengers.Text = String.Empty Then
            MessageBox.Show("Please make a selection.")
            blnValidated = False
        End If
    End Sub

    Private Sub btnCreateCustomer_Click(sender As Object, e As EventArgs) Handles btnCreateCustomer.Click
        'declare variable
        Dim frmNewCustomer As New frmNewCustomer

        'open form for new customer
        frmNewCustomer.ShowDialog()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub

    Private Sub btnSubmit2_Click(sender As Object, e As EventArgs) Handles btnSubmit2.Click
        'declare variables
        Dim strLogin As String
        Dim strPass As String
        Dim blnValidated As Boolean = True

        'put values into strings
        strLogin = txtLoginID.Text
        strPass = txtPassword.Text

        Call ValidateLogin(blnValidated)

    End Sub

    Private Sub ValidateLogin(ByRef blnValidated As Boolean)
        Call ValidateExistence(blnValidated) 'validates that the login inputs are not empty
        Call ValidateValidity(blnValidated) 'validates that both the login inputs match a specific employee
    End Sub

    Private Sub ValidateExistence(ByRef blnValidated As Boolean)
        If txtLoginID.Text = String.Empty Or txtPassword.Text = String.Empty Then
            MessageBox.Show("Invalid Login ID or Password.")
            txtLoginID.Focus()
            blnValidated = False
        End If
    End Sub

    Private Sub ValidateValidity(blnValidated)

    End Sub
End Class