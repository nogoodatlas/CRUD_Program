<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeletePilot
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
        Me.lblPilotDelete = New System.Windows.Forms.Label()
        Me.cboPilots = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(302, 106)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(159, 54)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPilotDelete
        '
        Me.lblPilotDelete.AutoSize = True
        Me.lblPilotDelete.Location = New System.Drawing.Point(36, 44)
        Me.lblPilotDelete.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblPilotDelete.Name = "lblPilotDelete"
        Me.lblPilotDelete.Size = New System.Drawing.Size(93, 16)
        Me.lblPilotDelete.TabIndex = 10
        Me.lblPilotDelete.Text = "Pilot to Delete:"
        '
        'cboPilots
        '
        Me.cboPilots.FormattingEnabled = True
        Me.cboPilots.Location = New System.Drawing.Point(197, 36)
        Me.cboPilots.Margin = New System.Windows.Forms.Padding(1)
        Me.cboPilots.Name = "cboPilots"
        Me.cboPilots.Size = New System.Drawing.Size(312, 24)
        Me.cboPilots.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(86, 106)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(159, 54)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete Pilot"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmDeletePilot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 196)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblPilotDelete)
        Me.Controls.Add(Me.cboPilots)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "frmDeletePilot"
        Me.Text = "Delete Customer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents lblPilotDelete As Label
    Friend WithEvents cboPilots As ComboBox
    Friend WithEvents btnDelete As Button
End Class
