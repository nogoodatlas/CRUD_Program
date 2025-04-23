<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNavigation
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
        Me.cboUserType = New System.Windows.Forms.ComboBox()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.btnEmployee = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboUserType
        '
        Me.cboUserType.FormattingEnabled = True
        Me.cboUserType.Items.AddRange(New Object() {"Customer", "Pilot", "Attendant", "Administrator"})
        Me.cboUserType.Location = New System.Drawing.Point(195, 37)
        Me.cboUserType.Name = "cboUserType"
        Me.cboUserType.Size = New System.Drawing.Size(172, 24)
        Me.cboUserType.TabIndex = 0
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(49, 87)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(95, 40)
        Me.btnSubmit.TabIndex = 1
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Location = New System.Drawing.Point(46, 45)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(115, 16)
        Me.lblUserType.TabIndex = 2
        Me.lblUserType.Text = "Select User Type:"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(272, 87)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(95, 40)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnCustomer
        '
        Me.btnCustomer.Location = New System.Drawing.Point(49, 148)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(95, 40)
        Me.btnCustomer.TabIndex = 1
        Me.btnCustomer.Text = "Customer Login"
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(272, 148)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(95, 40)
        Me.btnEmployee.TabIndex = 1
        Me.btnEmployee.Text = "Employee Login"
        Me.btnEmployee.UseVisualStyleBackColor = True
        '
        'frmNavigation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 211)
        Me.Controls.Add(Me.lblUserType)
        Me.Controls.Add(Me.btnEmployee)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCustomer)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.cboUserType)
        Me.Name = "frmNavigation"
        Me.Text = "Navigation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboUserType As ComboBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents lblUserType As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnCustomer As Button
    Friend WithEvents btnEmployee As Button
End Class
