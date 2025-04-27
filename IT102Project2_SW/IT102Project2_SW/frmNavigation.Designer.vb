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
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.btnEmployee = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCustomer
        '
        Me.btnCustomer.Location = New System.Drawing.Point(308, 34)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(119, 54)
        Me.btnCustomer.TabIndex = 2
        Me.btnCustomer.Text = "&Customer Login"
        Me.btnCustomer.UseVisualStyleBackColor = True
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(28, 34)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(119, 54)
        Me.btnEmployee.TabIndex = 1
        Me.btnEmployee.Text = "&Employee Login"
        Me.btnEmployee.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(168, 34)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(119, 54)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'frmNavigation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 122)
        Me.Controls.Add(Me.btnEmployee)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnCustomer)
        Me.Name = "frmNavigation"
        Me.Text = "Navigation"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCustomer As Button
    Friend WithEvents btnEmployee As Button
    Friend WithEvents btnExit As Button
End Class
