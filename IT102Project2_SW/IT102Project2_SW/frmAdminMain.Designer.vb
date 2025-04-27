<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminMain
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
        Me.btnManageAttendants = New System.Windows.Forms.Button()
        Me.btnManagePilots = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.btnStatistics = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnManageAttendants
        '
        Me.btnManageAttendants.Location = New System.Drawing.Point(229, 43)
        Me.btnManageAttendants.Name = "btnManageAttendants"
        Me.btnManageAttendants.Size = New System.Drawing.Size(160, 59)
        Me.btnManageAttendants.TabIndex = 13
        Me.btnManageAttendants.Text = "Manage &Attendants"
        Me.btnManageAttendants.UseVisualStyleBackColor = True
        '
        'btnManagePilots
        '
        Me.btnManagePilots.Location = New System.Drawing.Point(24, 43)
        Me.btnManagePilots.Name = "btnManagePilots"
        Me.btnManagePilots.Size = New System.Drawing.Size(160, 59)
        Me.btnManagePilots.TabIndex = 12
        Me.btnManagePilots.Text = "Manage &Pilots"
        Me.btnManagePilots.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(229, 143)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(160, 59)
        Me.btnDone.TabIndex = 11
        Me.btnDone.Text = "&Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnStatistics
        '
        Me.btnStatistics.Location = New System.Drawing.Point(24, 143)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Size = New System.Drawing.Size(160, 59)
        Me.btnStatistics.TabIndex = 10
        Me.btnStatistics.Text = "Airline &Statistics"
        Me.btnStatistics.UseVisualStyleBackColor = True
        '
        'frmAdminMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 244)
        Me.Controls.Add(Me.btnManageAttendants)
        Me.Controls.Add(Me.btnManagePilots)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnStatistics)
        Me.Name = "frmAdminMain"
        Me.Text = "Admin Main Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnManageAttendants As Button
    Friend WithEvents btnManagePilots As Button
    Friend WithEvents btnDone As Button
    Friend WithEvents btnStatistics As Button
End Class
