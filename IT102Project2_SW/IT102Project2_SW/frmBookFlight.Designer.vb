<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookFlight
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
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.cboFlights = New System.Windows.Forms.ComboBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblFlightDate = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblFlightFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblFlightTo = New System.Windows.Forms.Label()
        Me.lblSeat = New System.Windows.Forms.Label()
        Me.cboSeats = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.Location = New System.Drawing.Point(27, 39)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(83, 16)
        Me.lblSelect.TabIndex = 0
        Me.lblSelect.Text = "Select Flight:"
        '
        'cboFlights
        '
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(191, 31)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(174, 24)
        Me.cboFlights.TabIndex = 1
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(27, 140)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(74, 16)
        Me.lblDate.TabIndex = 2
        Me.lblDate.Text = "Flight Date:"
        '
        'lblFlightDate
        '
        Me.lblFlightDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightDate.Location = New System.Drawing.Point(138, 133)
        Me.lblFlightDate.Name = "lblFlightDate"
        Me.lblFlightDate.Size = New System.Drawing.Size(137, 23)
        Me.lblFlightDate.TabIndex = 3
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(27, 186)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(41, 16)
        Me.lblFrom.TabIndex = 4
        Me.lblFrom.Text = "From:"
        '
        'lblFlightFrom
        '
        Me.lblFlightFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightFrom.Location = New System.Drawing.Point(74, 179)
        Me.lblFlightFrom.Name = "lblFlightFrom"
        Me.lblFlightFrom.Size = New System.Drawing.Size(115, 23)
        Me.lblFlightFrom.TabIndex = 5
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(195, 186)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(27, 16)
        Me.lblTo.TabIndex = 6
        Me.lblTo.Text = "To:"
        '
        'lblFlightTo
        '
        Me.lblFlightTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightTo.Location = New System.Drawing.Point(228, 179)
        Me.lblFlightTo.Name = "lblFlightTo"
        Me.lblFlightTo.Size = New System.Drawing.Size(137, 23)
        Me.lblFlightTo.TabIndex = 7
        '
        'lblSeat
        '
        Me.lblSeat.AutoSize = True
        Me.lblSeat.Location = New System.Drawing.Point(27, 85)
        Me.lblSeat.Name = "lblSeat"
        Me.lblSeat.Size = New System.Drawing.Size(79, 16)
        Me.lblSeat.TabIndex = 8
        Me.lblSeat.Text = "Select Seat:"
        '
        'cboSeats
        '
        Me.cboSeats.FormattingEnabled = True
        Me.cboSeats.Items.AddRange(New Object() {"1A", "1B", "1C", "1D", "2A", "2B", "2C", "2D"})
        Me.cboSeats.Location = New System.Drawing.Point(191, 77)
        Me.cboSeats.Name = "cboSeats"
        Me.cboSeats.Size = New System.Drawing.Size(121, 24)
        Me.cboSeats.TabIndex = 2
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(60, 221)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(91, 38)
        Me.btnSubmit.TabIndex = 3
        Me.btnSubmit.Text = "&Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(242, 221)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 38)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 290)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboSeats)
        Me.Controls.Add(Me.lblSeat)
        Me.Controls.Add(Me.lblFlightTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFlightFrom)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblFlightDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.cboFlights)
        Me.Controls.Add(Me.lblSelect)
        Me.Name = "frmBookFlight"
        Me.Text = "Book Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSelect As Label
    Friend WithEvents cboFlights As ComboBox
    Friend WithEvents lblDate As Label
    Friend WithEvents lblFlightDate As Label
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblFlightFrom As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents lblFlightTo As Label
    Friend WithEvents lblSeat As Label
    Friend WithEvents cboSeats As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
End Class
