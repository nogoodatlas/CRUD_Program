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
        Me.btnExit = New System.Windows.Forms.Button()
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
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(326, 383)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(139, 57)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnAddAttendant
        '
        Me.btnAddAttendant.Location = New System.Drawing.Point(121, 383)
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
        Me.GroupBox1.Location = New System.Drawing.Point(43, 38)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(501, 311)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'dtmTerminationDate
        '
        Me.dtmTerminationDate.Location = New System.Drawing.Point(214, 248)
        Me.dtmTerminationDate.Name = "dtmTerminationDate"
        Me.dtmTerminationDate.Size = New System.Drawing.Size(232, 22)
        Me.dtmTerminationDate.TabIndex = 16
        '
        'dtmHireDate
        '
        Me.dtmHireDate.Location = New System.Drawing.Point(214, 200)
        Me.dtmHireDate.Name = "dtmHireDate"
        Me.dtmHireDate.Size = New System.Drawing.Size(232, 22)
        Me.dtmHireDate.TabIndex = 16
        '
        'lblTerminationDate
        '
        Me.lblTerminationDate.AutoSize = True
        Me.lblTerminationDate.Location = New System.Drawing.Point(55, 254)
        Me.lblTerminationDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTerminationDate.Name = "lblTerminationDate"
        Me.lblTerminationDate.Size = New System.Drawing.Size(127, 16)
        Me.lblTerminationDate.TabIndex = 14
        Me.lblTerminationDate.Text = "Date of Termination:"
        '
        'lblDateofHire
        '
        Me.lblDateofHire.AutoSize = True
        Me.lblDateofHire.Location = New System.Drawing.Point(55, 200)
        Me.lblDateofHire.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDateofHire.Name = "lblDateofHire"
        Me.lblDateofHire.Size = New System.Drawing.Size(78, 16)
        Me.lblDateofHire.TabIndex = 12
        Me.lblDateofHire.Text = "Date of Hire"
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(55, 148)
        Me.lblEmployeeID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(88, 16)
        Me.lblEmployeeID.TabIndex = 11
        Me.lblEmployeeID.Text = "Employee ID:"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(55, 96)
        Me.lblLastName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(75, 16)
        Me.lblLastName.TabIndex = 10
        Me.lblLastName.Text = "Last Name:"
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(55, 44)
        Me.lblFirstName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(75, 16)
        Me.lblFirstName.TabIndex = 9
        Me.lblFirstName.Text = "First Name:"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Location = New System.Drawing.Point(214, 142)
        Me.txtEmployeeID.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(160, 22)
        Me.txtEmployeeID.TabIndex = 2
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(214, 91)
        Me.txtLastName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(132, 22)
        Me.txtLastName.TabIndex = 1
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(214, 40)
        Me.txtFirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(132, 22)
        Me.txtFirstName.TabIndex = 0
        '
        'frmAddAttendant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 479)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnAddAttendant)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAddAttendant"
        Me.Text = "frmAddAttendant"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
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
End Class
