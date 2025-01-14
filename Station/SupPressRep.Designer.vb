<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupPressRep
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
        Me.PressLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.ButtonLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.SuspendLayout()
        '
        'PressLayoutPanel
        '
        Me.PressLayoutPanel.Location = New System.Drawing.Point(22, 36)
        Me.PressLayoutPanel.Name = "PressLayoutPanel"
        Me.PressLayoutPanel.Size = New System.Drawing.Size(1741, 1127)
        Me.PressLayoutPanel.TabIndex = 1
        '
        'ButtonLayoutPanel
        '
        Me.ButtonLayoutPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonLayoutPanel.Location = New System.Drawing.Point(22, 1168)
        Me.ButtonLayoutPanel.Name = "ButtonLayoutPanel"
        Me.ButtonLayoutPanel.Size = New System.Drawing.Size(1742, 93)
        Me.ButtonLayoutPanel.TabIndex = 3
        '
        'SupPressRep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1797, 1326)
        Me.Controls.Add(Me.ButtonLayoutPanel)
        Me.Controls.Add(Me.PressLayoutPanel)
        Me.Name = "SupPressRep"
        Me.Text = "Supervisor Press Reporting"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PressLayoutPanel As FlowLayoutPanel
    Friend WithEvents ButtonLayoutPanel As FlowLayoutPanel
End Class
