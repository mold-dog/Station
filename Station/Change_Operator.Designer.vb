<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Change_Operator
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
        Me.Lbl_Operator = New System.Windows.Forms.Label()
        Me.Cmb_Operator = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Lbl_Operator
        '
        Me.Lbl_Operator.AutoSize = True
        Me.Lbl_Operator.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Operator.Location = New System.Drawing.Point(12, 75)
        Me.Lbl_Operator.Name = "Lbl_Operator"
        Me.Lbl_Operator.Size = New System.Drawing.Size(96, 25)
        Me.Lbl_Operator.TabIndex = 16
        Me.Lbl_Operator.Text = "Operator"
        '
        'Cmb_Operator
        '
        Me.Cmb_Operator.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Operator.FormattingEnabled = True
        Me.Cmb_Operator.Location = New System.Drawing.Point(130, 72)
        Me.Cmb_Operator.Name = "Cmb_Operator"
        Me.Cmb_Operator.Size = New System.Drawing.Size(329, 33)
        Me.Cmb_Operator.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(150, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 29)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Change Operator"
        '
        'Btn_OK
        '
        Me.Btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_OK.Location = New System.Drawing.Point(129, 144)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(90, 38)
        Me.Btn_OK.TabIndex = 18
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(259, 144)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(90, 38)
        Me.Btn_Cancel.TabIndex = 19
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Change_Operator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 238)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmb_Operator)
        Me.Controls.Add(Me.Lbl_Operator)
        Me.Name = "Change_Operator"
        Me.Text = "Change Operator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Lbl_Operator As Label
    Friend WithEvents Cmb_Operator As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_OK As Button
    Friend WithEvents Btn_Cancel As Button
End Class
