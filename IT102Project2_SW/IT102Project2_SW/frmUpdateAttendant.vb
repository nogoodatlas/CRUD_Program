Public Class frmUpdateAttendant
    Private Sub frmUpdateAttendant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            strSelect = "SELECT strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination " &
                        "FROM TAttendants WHERE intAttendantID = " & gblAttendantID

            ' Retrieve all the records 
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            drSourceTable.Read()

            ' populate the text boxes with the data
            txtFirstName.Text = drSourceTable("strFirstName")
            txtLastName.Text = drSourceTable("strLastName")
            txtEmployeeID.Text = drSourceTable("strEmployeeID")
            dtmHireDate.Value = drSourceTable("dtmDateofHire")
            dtmTerminationDate.Value = drSourceTable("dtmDateofTermination")

            ' close the database connection
            CloseDatabaseConnection()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnUpdateAttendant_Click(sender As Object, e As EventArgs) Handles btnUpdateAttendant.Click
        'declare variables
        Dim strUpdate As String
        Dim strFirstName As String
        Dim strLastName As String
        Dim strEmployeeID As String
        Dim dteHireDate As Date
        Dim dteTerminationDate As Date
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

        ' validate data is entered
        Call ValidateInput(blnValidated, dteHireDate, dteTerminationDate)

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
                strUpdate = "UPDATE TAttendants SET " &
                            "strFirstName = '" & strFirstName & "', " &
                            "strLastName = '" & strLastName & "', " &
                            "strEmployeeID = '" & strEmployeeID & "', " &
                            "dtmDateofHire = '" & dteHireDate & "', " &
                            "dtmDateofTermination = '" & dteTerminationDate & "' " &
                            "WHERE intAttendantID = " & gblAttendantID


                ' uncomment out the following message box line to use as a tool to check your sql statement
                ' remember anything not a numeric value going into SQL Server must have single quotes '
                ' around it, including dates.
                MessageBox.Show(strUpdate)

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

    Private Sub ValidateInput(ByRef blnValidated As Boolean, ByVal dteHireDate As Date, ByVal dteTerminationDate As Date)
        Call ValidateName(blnValidated)
        Call ValidateEmployeeID(blnValidated)
        Call ValidateHireTerminationDate(blnValidated, dteHireDate, dteTerminationDate)
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'closes form
        Close()
    End Sub
End Class