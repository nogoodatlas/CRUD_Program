<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteAttendant
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
        Me.lblAttendantDelete = New System.Windows.Forms.Label()
        Me.cboAttendants = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(317, 122)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(1)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(159, 54)
        Me.btnExit.TabIndex = 15
        Me.btnExit.Text = "&Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lblAttendantDelete
        '
        Me.lblAttendantDelete.AutoSize = True
        Me.lblAttendantDelete.Location = New System.Drawing.Point(52, 60)
        Me.lblAttendantDelete.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblAttendantDelete.Name = "lblAttendantDelete"
        Me.lblAttendantDelete.Size = New System.Drawing.Size(123, 16)
        Me.lblAttendantDelete.TabIndex = 14
        Me.lblAttendantDelete.Text = "Attendant to Delete:"
        '
        'cboAttendants
        '
        Me.cboAttendants.FormattingEnabled = True
        Me.cboAttendants.Location = New System.Drawing.Point(212, 52)
        Me.cboAttendants.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAttendants.Name = "cboAttendants"
        Me.cboAttendants.Size = New System.Drawing.Size(312, 24)
        Me.cboAttendants.TabIndex = 13
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(101, 122)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(159, 54)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "&Delete Attendant"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmDeleteAttendant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 229)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.lblAttendantDelete)
        Me.Controls.Add(Me.cboAttendants)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "frmDeleteAttendant"
        Me.Text = "frmDeleteAttendant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents lblAttendantDelete As Label
    Friend WithEvents cboAttendants As ComboBox
    Friend WithEvents btnDelete As Button
End Class
