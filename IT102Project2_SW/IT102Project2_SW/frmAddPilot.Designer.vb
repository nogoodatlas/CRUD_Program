<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPilot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnAddPilot = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblTerminationDate = New System.Windows.Forms.Label()
        Me.lblPilotRole = New System.Windows.Forms.Label()
        Me.lblDateofHire = New System.Windows.Forms.Label()
        Me.lblEmployeeID = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.cboPilotRoles = New System.Windows.Forms.ComboBox()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.dtmHireDate = New System.Windows.Forms.DateTimePicker()
        Me.dtmTerminationDate = New System.Windows.Forms.DateTimePicker()
        Me.dtmLicenseDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(325, 469)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(139, 57)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddPilot
        '
        Me.btnAddPilot.Location = New System.Drawing.Point(120, 469)
        Me.btnAddPilot.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddPilot.Name = "btnAddPilot"
        Me.btnAddPilot.Size = New System.Drawing.Size(139, 57)
        Me.btnAddPilot.TabIndex = 11
        Me.btnAddPilot.Text = "&Add Pilot"
        Me.btnAddPilot.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtmLicenseDate)
        Me.GroupBox1.Controls.Add(Me.dtmTerminationDate)
        Me.GroupBox1.Controls.Add(Me.dtmHireDate)
        Me.GroupBox1.Controls.Add(Me.lblPhone)
        Me.GroupBox1.Controls.Add(Me.lblTerminationDate)
        Me.GroupBox1.Controls.Add(Me.lblPilotRole)
        Me.GroupBox1.Controls.Add(Me.lblDateofHire)
        Me.GroupBox1.Controls.Add(Me.lblEmployeeID)
        Me.GroupBox1.Controls.Add(Me.lblLastName)
        Me.GroupBox1.Controls.Add(Me.lblFirstName)
        Me.GroupBox1.Controls.Add(Me.cboPilotRoles)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeID)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Location = New System.Drawing.Point(42, 31)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(501, 411)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(55, 304)
        Me.lblPhone.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(103, 16)
        Me.lblPhone.TabIndex = 15
        Me.lblPhone.Text = "Date of License:"
        '
        'lblTerminationDate
        '
        Me.lblTerminationDate.AutoSize = True
        Me.lblTerminationDate.Location = New System.Drawing.Point(55, 253)
        Me.lblTerminationDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTerminationDate.Name = "lblTerminationDate"
        Me.lblTerminationDate.Size = New System.Drawing.Size(127, 16)
        Me.lblTerminationDate.TabIndex = 14
        Me.lblTerminationDate.Text = "Date of Termination:"
        '
        'lblPilotRole
        '
        Me.lblPilotRole.AutoSize = True
        Me.lblPilotRole.Location = New System.Drawing.Point(55, 355)
        Me.lblPilotRole.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPilotRole.Name = "lblPilotRole"
        Me.lblPilotRole.Size = New System.Drawing.Size(68, 16)
        Me.lblPilotRole.TabIndex = 13
        Me.lblPilotRole.Text = "Pilot Role:"
        '
        'lblDateofHire
        '
        Me.lblDateofHire.AutoSize = True
        Me.lblDateofHire.Location = New System.Drawing.Point(55, 199)
        Me.lblDateofHire.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDateofHire.Name = "lblDateofHire"
        Me.lblDateofHire.Size = New System.Drawing.Size(78, 16)
        Me.lblDateofHire.TabIndex = 12
        Me.lblDateofHire.Text = "Date of Hire"
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(55, 147)
        Me.lblEmployeeID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(88, 16)
        Me.lblEmployeeID.TabIndex = 11
        Me.lblEmployeeID.Text = "Employee ID:"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(55, 95)
        Me.lblLastName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(75, 16)
        Me.lblLastName.TabIndex = 10
        Me.lblLastName.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(55, 43)
        Me.lblFirstName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(75, 16)
        Me.lblFirstName.TabIndex = 9
        Me.lblFirstName.Text = "First Name:"
        '
        'cboPilotRoles
        '
        Me.cboPilotRoles.FormattingEnabled = True
        Me.cboPilotRoles.Location = New System.Drawing.Point(214, 347)
        Me.cboPilotRoles.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPilotRoles.Name = "cboPilotRoles"
        Me.cboPilotRoles.Size = New System.Drawing.Size(160, 24)
        Me.cboPilotRoles.TabIndex = 4
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(214, 141)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(160, 22)
        Me.txtEmployeeID.TabIndex = 2
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(214, 90)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(132, 22)
        Me.txtLastName.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(214, 39)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(132, 22)
        Me.txtFirstName.TabIndex = 0
        '
        'dtmHireDate
        '
        Me.dtmHireDate.Location = New System.Drawing.Point(214, 199)
        Me.dtmHireDate.Name = "dtmHireDate"
        Me.dtmHireDate.Size = New System.Drawing.Size(232, 22)
        Me.dtmHireDate.TabIndex = 16
        '
        'dtmTerminationDate
        '
        Me.dtmTerminationDate.Location = New System.Drawing.Point(214, 247)
        Me.dtmTerminationDate.Name = "dtmTerminationDate"
        Me.dtmTerminationDate.Size = New System.Drawing.Size(232, 22)
        Me.dtmTerminationDate.TabIndex = 16
        '
        'dtmLicenseDate
        '
        Me.dtmLicenseDate.Location = New System.Drawing.Point(214, 298)
        Me.dtmLicenseDate.Name = "dtmLicenseDate"
        Me.dtmLicenseDate.Size = New System.Drawing.Size(232, 22)
        Me.dtmLicenseDate.TabIndex = 16
        '
        'frmAddPilot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 557)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddPilot)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAddPilot"
        Me.Text = "frmAddPilot"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnAddPilot As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblTerminationDate As Label
    Friend WithEvents lblPilotRole As Label
    Friend WithEvents lblDateofHire As Label
    Friend WithEvents lblEmployeeID As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents cboPilotRoles As ComboBox
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents dtmLicenseDate As DateTimePicker
    Friend WithEvents dtmTerminationDate As DateTimePicker
    Friend WithEvents dtmHireDate As DateTimePicker
End Class
