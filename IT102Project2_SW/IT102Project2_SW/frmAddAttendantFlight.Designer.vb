<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddAttendantFlight
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
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblFlightTo = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.lblFlightFrom = New System.Windows.Forms.Label()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblFlightDate = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.cboAttendants = New System.Windows.Forms.ComboBox()
        Me.lblAttendant = New System.Windows.Forms.Label()
        Me.cboFlights = New System.Windows.Forms.ComboBox()
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(252, 210)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 38)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(70, 210)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(91, 38)
        Me.btnSubmit.TabIndex = 2
        Me.btnSubmit.Text = "&Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblFlightTo
        '
        Me.lblFlightTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightTo.Location = New System.Drawing.Point(238, 168)
        Me.lblFlightTo.Name = "lblFlightTo"
        Me.lblFlightTo.Size = New System.Drawing.Size(137, 23)
        Me.lblFlightTo.TabIndex = 19
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(205, 175)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(27, 16)
        Me.lblTo.TabIndex = 18
        Me.lblTo.Text = "To:"
        '
        'lblFlightFrom
        '
        Me.lblFlightFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightFrom.Location = New System.Drawing.Point(84, 168)
        Me.lblFlightFrom.Name = "lblFlightFrom"
        Me.lblFlightFrom.Size = New System.Drawing.Size(115, 23)
        Me.lblFlightFrom.TabIndex = 17
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(37, 175)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(41, 16)
        Me.lblFrom.TabIndex = 16
        Me.lblFrom.Text = "From:"
        '
        'lblFlightDate
        '
        Me.lblFlightDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightDate.Location = New System.Drawing.Point(148, 122)
        Me.lblFlightDate.Name = "lblFlightDate"
        Me.lblFlightDate.Size = New System.Drawing.Size(137, 23)
        Me.lblFlightDate.TabIndex = 15
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(37, 129)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(74, 16)
        Me.lblDate.TabIndex = 14
        Me.lblDate.Text = "Flight Date:"
        '
        'cboAttendants
        '
        Me.cboAttendants.FormattingEnabled = True
        Me.cboAttendants.Location = New System.Drawing.Point(201, 29)
        Me.cboAttendants.Name = "cboAttendants"
        Me.cboAttendants.Size = New System.Drawing.Size(174, 24)
        Me.cboAttendants.TabIndex = 0
        '
        'lblAttendant
        '
        Me.lblAttendant.AutoSize = True
        Me.lblAttendant.Location = New System.Drawing.Point(34, 37)
        Me.lblAttendant.Name = "lblAttendant"
        Me.lblAttendant.Size = New System.Drawing.Size(107, 16)
        Me.lblAttendant.TabIndex = 36
        Me.lblAttendant.Text = "Select Attendant:"
        '
        'cboFlights
        '
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(201, 75)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(174, 24)
        Me.cboFlights.TabIndex = 1
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.Location = New System.Drawing.Point(34, 83)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(83, 16)
        Me.lblSelect.TabIndex = 34
        Me.lblSelect.Text = "Select Flight:"
        '
        'frmAddAttendantFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 276)
        Me.Controls.Add(Me.cboAttendants)
        Me.Controls.Add(Me.lblAttendant)
        Me.Controls.Add(Me.cboFlights)
        Me.Controls.Add(Me.lblSelect)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.lblFlightTo)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFlightFrom)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.lblFlightDate)
        Me.Controls.Add(Me.lblDate)
        Me.Name = "frmAddAttendantFlight"
        Me.Text = "Add Attendant to Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblFlightTo As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents lblFlightFrom As Label
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblFlightDate As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents cboAttendants As ComboBox
    Friend WithEvents lblAttendant As Label
    Friend WithEvents cboFlights As ComboBox
    Friend WithEvents lblSelect As Label
End Class
