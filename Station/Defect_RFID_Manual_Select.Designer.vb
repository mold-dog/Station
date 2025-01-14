<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Defect_RFID_Manual_Select
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Lbl_Title = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lbl_Title
        '
        Me.Lbl_Title.AutoSize = True
        Me.Lbl_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Title.Location = New System.Drawing.Point(446, 0)
        Me.Lbl_Title.Name = "Lbl_Title"
        Me.Lbl_Title.Size = New System.Drawing.Size(335, 29)
        Me.Lbl_Title.TabIndex = 0
        Me.Lbl_Title.Text = "Select the part type to work on"
        '
        'Defect_RFID_Manual_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 635)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Title)
        Me.Name = "Defect_RFID_Manual_Select"
        Me.Text = "Defect_RFID_Manual_Select"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Title As Label
End Class
