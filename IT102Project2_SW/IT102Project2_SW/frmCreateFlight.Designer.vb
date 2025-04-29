<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateFlight
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtmFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDepartures = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboArrivals = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFlightDistance = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPlanes = New System.Windows.Forms.ComboBox()
        Me.btnCreateFlight = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPlanes)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFlightNumber)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFlightDistance)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboArrivals)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cboDepartures)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtmFlightDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(31, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 302)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Flight Info"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date of Flight:"
        '
        'dtmFlightDate
        '
        Me.dtmFlightDate.Location = New System.Drawing.Point(136, 73)
        Me.dtmFlightDate.Name = "dtmFlightDate"
        Me.dtmFlightDate.Size = New System.Drawing.Size(250, 22)
        Me.dtmFlightDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Departure Airport:"
        '
        'cboDepartures
        '
        Me.cboDepartures.FormattingEnabled = True
        Me.cboDepartures.Location = New System.Drawing.Point(235, 116)
        Me.cboDepartures.Name = "cboDepartures"
        Me.cboDepartures.Size = New System.Drawing.Size(151, 24)
        Me.cboDepartures.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Arrival Airport:"
        '
        'cboArrivals
        '
        Me.cboArrivals.FormattingEnabled = True
        Me.cboArrivals.Location = New System.Drawing.Point(235, 161)
        Me.cboArrivals.Name = "cboArrivals"
        Me.cboArrivals.Size = New System.Drawing.Size(151, 24)
        Me.cboArrivals.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Flight Distance:"
        '
        'txtFlightDistance
        '
        Me.txtFlightDistance.Location = New System.Drawing.Point(256, 206)
        Me.txtFlightDistance.Name = "txtFlightDistance"
        Me.txtFlightDistance.Size = New System.Drawing.Size(130, 22)
        Me.txtFlightDistance.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Flight Number:"
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(286, 30)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(100, 22)
        Me.txtFlightNumber.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 257)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Plane:"
        '
        'cboPlanes
        '
        Me.cboPlanes.FormattingEnabled = True
        Me.cboPlanes.Location = New System.Drawing.Point(176, 249)
        Me.cboPlanes.Name = "cboPlanes"
        Me.cboPlanes.Size = New System.Drawing.Size(210, 24)
        Me.cboPlanes.TabIndex = 5
        '
        'btnCreateFlight
        '
        Me.btnCreateFlight.Location = New System.Drawing.Point(83, 353)
        Me.btnCreateFlight.Name = "btnCreateFlight"
        Me.btnCreateFlight.Size = New System.Drawing.Size(121, 53)
        Me.btnCreateFlight.TabIndex = 6
        Me.btnCreateFlight.Text = "&Create Flight"
        Me.btnCreateFlight.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(266, 353)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(121, 53)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmCreateFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 429)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCreateFlight)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCreateFlight"
        Me.Text = "Create Future Flight"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtmFlightDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFlightDistance As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboArrivals As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboDepartures As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboPlanes As ComboBox
    Friend WithEvents btnCreateFlight As Button
    Friend WithEvents btnCancel As Button
End Class
