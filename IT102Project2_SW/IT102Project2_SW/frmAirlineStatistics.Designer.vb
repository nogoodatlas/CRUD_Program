<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAirlineStatistics
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
        Me.lstPilotMiles = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstAttendantMiles = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblAvgMiles = New System.Windows.Forms.Label()
        Me.lblTotalFlights = New System.Windows.Forms.Label()
        Me.lblTotalCustomers = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lstPilotMiles)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(394, 221)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pilot Miles"
        '
        'lstPilotMiles
        '
        Me.lstPilotMiles.FormattingEnabled = True
        Me.lstPilotMiles.ItemHeight = 16
        Me.lstPilotMiles.Location = New System.Drawing.Point(21, 28)
        Me.lstPilotMiles.Name = "lstPilotMiles"
        Me.lstPilotMiles.Size = New System.Drawing.Size(353, 164)
        Me.lstPilotMiles.TabIndex = 11
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstAttendantMiles)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 273)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(394, 221)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Attendant Miles"
        '
        'lstAttendantMiles
        '
        Me.lstAttendantMiles.FormattingEnabled = True
        Me.lstAttendantMiles.ItemHeight = 16
        Me.lstAttendantMiles.Location = New System.Drawing.Point(21, 28)
        Me.lstAttendantMiles.Name = "lstAttendantMiles"
        Me.lstAttendantMiles.Size = New System.Drawing.Size(353, 164)
        Me.lstAttendantMiles.TabIndex = 11
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblAvgMiles)
        Me.GroupBox3.Controls.Add(Me.lblTotalFlights)
        Me.GroupBox3.Controls.Add(Me.lblTotalCustomers)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(32, 519)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(394, 134)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Customer Statistics"
        '
        'lblAvgMiles
        '
        Me.lblAvgMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAvgMiles.Location = New System.Drawing.Point(289, 86)
        Me.lblAvgMiles.Name = "lblAvgMiles"
        Me.lblAvgMiles.Size = New System.Drawing.Size(84, 23)
        Me.lblAvgMiles.TabIndex = 3
        '
        'lblTotalFlights
        '
        Me.lblTotalFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalFlights.Location = New System.Drawing.Point(289, 56)
        Me.lblTotalFlights.Name = "lblTotalFlights"
        Me.lblTotalFlights.Size = New System.Drawing.Size(84, 23)
        Me.lblTotalFlights.TabIndex = 3
        '
        'lblTotalCustomers
        '
        Me.lblTotalCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCustomers.Location = New System.Drawing.Point(289, 26)
        Me.lblTotalCustomers.Name = "lblTotalCustomers"
        Me.lblTotalCustomers.Size = New System.Drawing.Size(84, 23)
        Me.lblTotalCustomers.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Average Miles Flown For All Customers:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(229, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Total Flights Taken By All Customers:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Number of Customers:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(154, 678)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(150, 45)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmAirlineStatistics
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 750)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmAirlineStatistics"
        Me.Text = "Airline Statistics"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lstPilotMiles As ListBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lstAttendantMiles As ListBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblAvgMiles As Label
    Friend WithEvents lblTotalFlights As Label
    Friend WithEvents lblTotalCustomers As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnExit As Button
End Class
