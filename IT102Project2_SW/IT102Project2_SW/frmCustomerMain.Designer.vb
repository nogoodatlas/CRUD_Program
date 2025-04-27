<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCustomerMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnBookFlight = New System.Windows.Forms.Button()
        Me.btnPastFlights = New System.Windows.Forms.Button()
        Me.btnFutureFlights = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.lstDisplayFlights = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(32, 390)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(144, 38)
        Me.btnUpdate.TabIndex = 0
        Me.btnUpdate.Text = "&Update Profile"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnBookFlight
        '
        Me.btnBookFlight.Location = New System.Drawing.Point(201, 390)
        Me.btnBookFlight.Name = "btnBookFlight"
        Me.btnBookFlight.Size = New System.Drawing.Size(144, 38)
        Me.btnBookFlight.TabIndex = 1
        Me.btnBookFlight.Text = "&Book Flight"
        Me.btnBookFlight.UseVisualStyleBackColor = True
        '
        'btnPastFlights
        '
        Me.btnPastFlights.Location = New System.Drawing.Point(32, 328)
        Me.btnPastFlights.Name = "btnPastFlights"
        Me.btnPastFlights.Size = New System.Drawing.Size(144, 38)
        Me.btnPastFlights.TabIndex = 2
        Me.btnPastFlights.Text = "Show &Past Flights"
        Me.btnPastFlights.UseVisualStyleBackColor = True
        '
        'btnFutureFlights
        '
        Me.btnFutureFlights.Location = New System.Drawing.Point(201, 328)
        Me.btnFutureFlights.Name = "btnFutureFlights"
        Me.btnFutureFlights.Size = New System.Drawing.Size(144, 38)
        Me.btnFutureFlights.TabIndex = 3
        Me.btnFutureFlights.Text = "Show &Future Flights"
        Me.btnFutureFlights.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(113, 453)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(144, 38)
        Me.btnDone.TabIndex = 1
        Me.btnDone.Text = "&Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'lstDisplayFlights
        '
        Me.lstDisplayFlights.FormattingEnabled = True
        Me.lstDisplayFlights.ItemHeight = 16
        Me.lstDisplayFlights.Location = New System.Drawing.Point(32, 31)
        Me.lstDisplayFlights.Name = "lstDisplayFlights"
        Me.lstDisplayFlights.Size = New System.Drawing.Size(313, 276)
        Me.lstDisplayFlights.TabIndex = 4
        '
        'frmCustomerMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 522)
        Me.Controls.Add(Me.lstDisplayFlights)
        Me.Controls.Add(Me.btnFutureFlights)
        Me.Controls.Add(Me.btnPastFlights)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnBookFlight)
        Me.Controls.Add(Me.btnUpdate)
        Me.Name = "frmCustomerMain"
        Me.Text = "Customer Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnBookFlight As Button
    Friend WithEvents btnPastFlights As Button
    Friend WithEvents btnFutureFlights As Button
    Friend WithEvents btnDone As Button
    Friend WithEvents lstDisplayFlights As ListBox
End Class
