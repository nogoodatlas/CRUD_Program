<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddAttendant
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAddAttendant = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtmTerminationDate = New System.Windows.Forms.DateTimePicker()
        Me.dtmHireDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTerminationDate = New System.Windows.Forms.Label()
        Me.lblDateofHire = New System.Windows.Forms.Label()
        Me.lblEmployeeID = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtConfirmPass = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtLoginID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(351, 533)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(139, 57)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddAttendant
        '
        Me.btnAddAttendant.Location = New System.Drawing.Point(351, 374)
        Me.btnAddAttendant.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddAttendant.Name = "btnAddAttendant"
        Me.btnAddAttendant.Size = New System.Drawing.Size(139, 57)
        Me.btnAddAttendant.TabIndex = 14
        Me.btnAddAttendant.Text = "&Add Attendant"
        Me.btnAddAttendant.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtmTerminationDate)
        Me.GroupBox1.Controls.Add(Me.dtmHireDate)
        Me.GroupBox1.Controls.Add(Me.lblTerminationDate)
        Me.GroupBox1.Controls.Add(Me.lblDateofHire)
        Me.GroupBox1.Controls.Add(Me.lblEmployeeID)
        Me.GroupBox1.Controls.Add(Me.lblLastName)
        Me.GroupBox1.Controls.Add(Me.lblFirstName)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeID)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 25)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(455, 286)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attendant Info"
        '
        'dtmTerminationDate
        '
        Me.dtmTerminationDate.Location = New System.Drawing.Point(184, 236)
        Me.dtmTerminationDate.Name = "dtmTerminationDate"
        Me.dtmTerminationDate.Size = New System.Drawing.Size(245, 22)
        Me.dtmTerminationDate.TabIndex = 16
        '
        'dtmHireDate
        '
        Me.dtmHireDate.Location = New System.Drawing.Point(184, 188)
        Me.dtmHireDate.Name = "dtmHireDate"
        Me.dtmHireDate.Size = New System.Drawing.Size(245, 22)
        Me.dtmHireDate.TabIndex = 16
        '
        'lblTerminationDate
        '
        Me.lblTerminationDate.AutoSize = True
        Me.lblTerminationDate.Location = New System.Drawing.Point(25, 242)
        Me.lblTerminationDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTerminationDate.Name = "lblTerminationDate"
        Me.lblTerminationDate.Size = New System.Drawing.Size(127, 16)
        Me.lblTerminationDate.TabIndex = 14
        Me.lblTerminationDate.Text = "Date of Termination:"
        '
        'lblDateofHire
        '
        Me.lblDateofHire.AutoSize = True
        Me.lblDateofHire.Location = New System.Drawing.Point(25, 194)
        Me.lblDateofHire.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDateofHire.Name = "lblDateofHire"
        Me.lblDateofHire.Size = New System.Drawing.Size(78, 16)
        Me.lblDateofHire.TabIndex = 12
        Me.lblDateofHire.Text = "Date of Hire"
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(25, 136)
        Me.lblEmployeeID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(88, 16)
        Me.lblEmployeeID.TabIndex = 11
        Me.lblEmployeeID.Text = "Employee ID:"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(25, 84)
        Me.lblLastName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(75, 16)
        Me.lblLastName.TabIndex = 10
        Me.lblLastName.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(25, 32)
        Me.lblFirstName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(75, 16)
        Me.lblFirstName.TabIndex = 9
        Me.lblFirstName.Text = "First Name:"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(184, 130)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(160, 22)
        Me.txtEmployeeID.TabIndex = 2
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(184, 79)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(132, 22)
        Me.txtLastName.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(184, 28)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(132, 22)
        Me.txtFirstName.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtConfirmPass)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtPassword)
        Me.GroupBox2.Controls.Add(Me.txtLoginID)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(35, 342)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(282, 286)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Create Account"
        '
        'txtConfirmPass
        '
        Me.txtConfirmPass.Location = New System.Drawing.Point(30, 226)
        Me.txtConfirmPass.Name = "txtConfirmPass"
        Me.txtConfirmPass.Size = New System.Drawing.Size(226, 22)
        Me.txtConfirmPass.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Confirm Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(30, 149)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(226, 22)
        Me.txtPassword.TabIndex = 4
        '
        'txtLoginID
        '
        Me.txtLoginID.Location = New System.Drawing.Point(30, 67)
        Me.txtLoginID.Name = "txtLoginID"
        Me.txtLoginID.Size = New System.Drawing.Size(226, 22)
        Me.txtLoginID.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Password:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Login ID:"
        '
        'frmAddAttendant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 653)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddAttendant)
        Me.Name = "frmAddAttendant"
        Me.Text = "Add Attendant"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAddAttendant As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtmTerminationDate As DateTimePicker
    Friend WithEvents dtmHireDate As DateTimePicker
    Friend WithEvents lblTerminationDate As Label
    Friend WithEvents lblDateofHire As Label
    Friend WithEvents lblEmployeeID As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtEmployeeID As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLoginID As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
