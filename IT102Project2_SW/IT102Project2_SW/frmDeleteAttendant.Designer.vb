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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblAttendantDelete = New System.Windows.Forms.Label()
        Me.cboAttendants = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(300, 106)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(159, 54)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblAttendantDelete
        '
        Me.lblAttendantDelete.AutoSize = True
        Me.lblAttendantDelete.Location = New System.Drawing.Point(35, 44)
        Me.lblAttendantDelete.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.lblAttendantDelete.Name = "lblAttendantDelete"
        Me.lblAttendantDelete.Size = New System.Drawing.Size(123, 16)
        Me.lblAttendantDelete.TabIndex = 14
        Me.lblAttendantDelete.Text = "Attendant to Delete:"
        '
        'cboAttendants
        '
        Me.cboAttendants.FormattingEnabled = True
        Me.cboAttendants.Location = New System.Drawing.Point(195, 36)
        Me.cboAttendants.Margin = New System.Windows.Forms.Padding(1)
        Me.cboAttendants.Name = "cboAttendants"
        Me.cboAttendants.Size = New System.Drawing.Size(312, 24)
        Me.cboAttendants.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(84, 106)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(1)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(159, 54)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete Attendant"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'frmDeleteAttendant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 197)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblAttendantDelete)
        Me.Controls.Add(Me.cboAttendants)
        Me.Controls.Add(Me.btnDelete)
        Me.Name = "frmDeleteAttendant"
        Me.Text = "Delete Attendant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents lblAttendantDelete As Label
    Friend WithEvents cboAttendants As ComboBox
    Friend WithEvents btnDelete As Button
End Class
