<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPilotMain
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
        Me.lstDisplayFlights = New System.Windows.Forms.ListBox()
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstDisplayFlights
        '
        Me.lstDisplayFlights.FormattingEnabled = True
        Me.lstDisplayFlights.ItemHeight = 16
        Me.lstDisplayFlights.Location = New System.Drawing.Point(35, 36)
        Me.lstDisplayFlights.Name = "lstDisplayFlights"
        Me.lstDisplayFlights.Size = New System.Drawing.Size(313, 276)
        Me.lstDisplayFlights.TabIndex = 10
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Location = New System.Drawing.Point(204, 333)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(144, 38)
        Me.btnFutureFlights.TabIndex = 9
        Me.btnFutureFlights.Text = "Show &Future Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Location = New System.Drawing.Point(35, 333)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(144, 38)
        Me.btnPastFlights.TabIndex = 8
        Me.btnPastFlights.Text = "Show &Past Flights"
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(204, 395)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(144, 38)
        Me.btnDone.TabIndex = 6
        Me.btnDone.Text = "&Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(35, 395)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(144, 38)
        Me.btnUpdate.TabIndex = 5
        Me.btnUpdate.Text = "&Update Profile"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmPilotMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 468)
        Me.Controls.Add(Me.lstDisplayFlights)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.btnPastFlights)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmPilotMain"
        Me.Text = "Pilot Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstDisplayFlights As ListBox
    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnDone As Button
    Friend WithEvents btnUpdate As Button
End Class
