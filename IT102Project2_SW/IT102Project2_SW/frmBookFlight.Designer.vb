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
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.radReserved = New System.Windows.Forms.RadioButton()
        Me.radAssigned = New System.Windows.Forms.RadioButton()
        Me.lstFlightCost = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.Location = New System.Drawing.Point(27, 40)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(83, 16)
        Me.lblSelect.TabIndex = 0
        Me.lblSelect.Text = "Select Flight:"
        '
        'cboFlights
        '
        Me.cboFlights.FormattingEnabled = True
        Me.cboFlights.Location = New System.Drawing.Point(191, 32)
        Me.cboFlights.Name = "cboFlights"
        Me.cboFlights.Size = New System.Drawing.Size(174, 24)
        Me.cboFlights.TabIndex = 1
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(28, 89)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(74, 16)
        Me.lblDate.TabIndex = 2
        Me.lblDate.Text = "Flight Date:"
        '
        'lblFlightDate
        '
        Me.lblFlightDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightDate.Location = New System.Drawing.Point(139, 82)
        Me.lblFlightDate.Name = "lblFlightDate"
        Me.lblFlightDate.Size = New System.Drawing.Size(137, 23)
        Me.lblFlightDate.TabIndex = 3
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(28, 135)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(41, 16)
        Me.lblFrom.TabIndex = 4
        Me.lblFrom.Text = "From:"
        '
        'lblFlightFrom
        '
        Me.lblFlightFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightFrom.Location = New System.Drawing.Point(75, 128)
        Me.lblFlightFrom.Name = "lblFlightFrom"
        Me.lblFlightFrom.Size = New System.Drawing.Size(115, 23)
        Me.lblFlightFrom.TabIndex = 5
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(196, 135)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(27, 16)
        Me.lblTo.TabIndex = 6
        Me.lblTo.Text = "To:"
        '
        'lblFlightTo
        '
        Me.lblFlightTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFlightTo.Location = New System.Drawing.Point(229, 128)
        Me.lblFlightTo.Name = "lblFlightTo"
        Me.lblFlightTo.Size = New System.Drawing.Size(137, 23)
        Me.lblFlightTo.TabIndex = 7
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(60, 375)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(91, 38)
        Me.btnSubmit.TabIndex = 4
        Me.btnSubmit.Text = "&Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(242, 375)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 38)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'radReserved
        '
        Me.radReserved.AutoSize = True
        Me.radReserved.Location = New System.Drawing.Point(12, 21)
        Me.radReserved.Name = "radReserved"
        Me.radReserved.Size = New System.Drawing.Size(119, 20)
        Me.radReserved.TabIndex = 2
        Me.radReserved.TabStop = True
        Me.radReserved.Text = "Reserved Seat"
        Me.radReserved.UseVisualStyleBackColor = True
        '
        'radAssigned
        '
        Me.radAssigned.AutoSize = True
        Me.radAssigned.Location = New System.Drawing.Point(169, 21)
        Me.radAssigned.Name = "radAssigned"
        Me.radAssigned.Size = New System.Drawing.Size(116, 20)
        Me.radAssigned.TabIndex = 3
        Me.radAssigned.TabStop = True
        Me.radAssigned.Text = "Assigned Seat"
        Me.radAssigned.UseVisualStyleBackColor = True
        '
        'lstFlightCost
        '
        Me.lstFlightCost.FormattingEnabled = True
        Me.lstFlightCost.ItemHeight = 16
        Me.lstFlightCost.Location = New System.Drawing.Point(48, 218)
        Me.lstFlightCost.Name = "lstFlightCost"
        Me.lstFlightCost.Size = New System.Drawing.Size(297, 132)
        Me.lstFlightCost.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radAssigned)
        Me.GroupBox1.Controls.Add(Me.radReserved)
        Me.GroupBox1.Location = New System.Drawing.Point(48, 154)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(297, 55)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'frmBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 444)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lstFlightCost)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents radReserved As RadioButton
    Friend WithEvents radAssigned As RadioButton
    Friend WithEvents lstFlightCost As ListBox
    Friend WithEvents GroupBox1 As GroupBox
End Class
