<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Set_Color
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_Final_Color = New System.Windows.Forms.ComboBox()
        Me.Txt_RFID = New System.Windows.Forms.TextBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.txt_Part_Type = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Update = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(182, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Set Color"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(57, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 104
        Me.Label4.Text = "Color"
        '
        'Cmb_Final_Color
        '
        Me.Cmb_Final_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Final_Color.FormattingEnabled = True
        Me.Cmb_Final_Color.Location = New System.Drawing.Point(104, 142)
        Me.Cmb_Final_Color.Name = "Cmb_Final_Color"
        Me.Cmb_Final_Color.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Final_Color.TabIndex = 101
        '
        'Txt_RFID
        '
        Me.Txt_RFID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFID.Location = New System.Drawing.Point(104, 61)
        Me.Txt_RFID.Name = "Txt_RFID"
        Me.Txt_RFID.Size = New System.Drawing.Size(287, 23)
        Me.Txt_RFID.TabIndex = 100
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(59, 64)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(39, 17)
        Me.Lbl_Area.TabIndex = 103
        Me.Lbl_Area.Text = "RFID"
        '
        'txt_Part_Type
        '
        Me.txt_Part_Type.Enabled = False
        Me.txt_Part_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Part_Type.Location = New System.Drawing.Point(104, 101)
        Me.txt_Part_Type.Name = "txt_Part_Type"
        Me.txt_Part_Type.Size = New System.Drawing.Size(287, 23)
        Me.txt_Part_Type.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 17)
        Me.Label2.TabIndex = 107
        Me.Label2.Text = "Part Type"
        '
        'Btn_Update
        '
        Me.Btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Update.Location = New System.Drawing.Point(104, 194)
        Me.Btn_Update.Name = "Btn_Update"
        Me.Btn_Update.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Update.TabIndex = 108
        Me.Btn_Update.Text = "Update"
        Me.Btn_Update.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(233, 194)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 109
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Set_Color
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 274)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Update)
        Me.Controls.Add(Me.txt_Part_Type)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cmb_Final_Color)
        Me.Controls.Add(Me.Txt_RFID)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Set_Color"
        Me.Text = "Set Color"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Cmb_Final_Color As ComboBox
    Friend WithEvents Txt_RFID As TextBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents txt_Part_Type As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Update As Button
    Friend WithEvents Btn_Cancel As Button
End Class
