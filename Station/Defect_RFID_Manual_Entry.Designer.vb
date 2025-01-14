<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Defect_RFID_Manual_Entry
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
        Me.Txt_RFID_Prefix = New System.Windows.Forms.TextBox()
        Me.lbl_Part = New System.Windows.Forms.Label()
        Me.Lbl_Man_Entry = New System.Windows.Forms.Label()
        Me.Txt_RFID_Suffix = New System.Windows.Forms.TextBox()
        Me.Lbl_Last_Six = New System.Windows.Forms.Label()
        Me.Lbl_RFID_Label = New System.Windows.Forms.Label()
        Me.Btn_Generate_RFID = New System.Windows.Forms.Button()
        Me.Btn_Accept = New System.Windows.Forms.Button()
        Me.Btn_Exit = New System.Windows.Forms.Button()
        Me.Pbx_Part_Type = New System.Windows.Forms.PictureBox()
        Me.Lbl_Part_Type = New System.Windows.Forms.Label()
        CType(Me.Pbx_Part_Type, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txt_RFID_Prefix
        '
        Me.Txt_RFID_Prefix.Enabled = False
        Me.Txt_RFID_Prefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFID_Prefix.Location = New System.Drawing.Point(54, 59)
        Me.Txt_RFID_Prefix.Name = "Txt_RFID_Prefix"
        Me.Txt_RFID_Prefix.Size = New System.Drawing.Size(59, 26)
        Me.Txt_RFID_Prefix.TabIndex = 75
        '
        'lbl_Part
        '
        Me.lbl_Part.AutoSize = True
        Me.lbl_Part.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Part.Location = New System.Drawing.Point(29, 36)
        Me.lbl_Part.Name = "lbl_Part"
        Me.lbl_Part.Size = New System.Drawing.Size(126, 20)
        Me.lbl_Part.TabIndex = 74
        Me.lbl_Part.Text = "1st 4 Characters"
        '
        'Lbl_Man_Entry
        '
        Me.Lbl_Man_Entry.AutoSize = True
        Me.Lbl_Man_Entry.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Man_Entry.Location = New System.Drawing.Point(76, 9)
        Me.Lbl_Man_Entry.Name = "Lbl_Man_Entry"
        Me.Lbl_Man_Entry.Size = New System.Drawing.Size(199, 20)
        Me.Lbl_Man_Entry.TabIndex = 76
        Me.Lbl_Man_Entry.Text = "Manually Enter RFID Code"
        '
        'Txt_RFID_Suffix
        '
        Me.Txt_RFID_Suffix.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFID_Suffix.Location = New System.Drawing.Point(235, 59)
        Me.Txt_RFID_Suffix.Name = "Txt_RFID_Suffix"
        Me.Txt_RFID_Suffix.Size = New System.Drawing.Size(71, 26)
        Me.Txt_RFID_Suffix.TabIndex = 78
        '
        'Lbl_Last_Six
        '
        Me.Lbl_Last_Six.AutoSize = True
        Me.Lbl_Last_Six.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Last_Six.Location = New System.Drawing.Point(210, 36)
        Me.Lbl_Last_Six.Name = "Lbl_Last_Six"
        Me.Lbl_Last_Six.Size = New System.Drawing.Size(135, 20)
        Me.Lbl_Last_Six.TabIndex = 77
        Me.Lbl_Last_Six.Text = "Last 6 Characters"
        '
        'Lbl_RFID_Label
        '
        Me.Lbl_RFID_Label.AutoSize = True
        Me.Lbl_RFID_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RFID_Label.Location = New System.Drawing.Point(76, 96)
        Me.Lbl_RFID_Label.Name = "Lbl_RFID_Label"
        Me.Lbl_RFID_Label.Size = New System.Drawing.Size(135, 20)
        Me.Lbl_RFID_Label.TabIndex = 79
        Me.Lbl_RFID_Label.Text = "00000000000000"
        '
        'Btn_Generate_RFID
        '
        Me.Btn_Generate_RFID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Generate_RFID.Location = New System.Drawing.Point(54, 123)
        Me.Btn_Generate_RFID.Name = "Btn_Generate_RFID"
        Me.Btn_Generate_RFID.Size = New System.Drawing.Size(252, 26)
        Me.Btn_Generate_RFID.TabIndex = 119
        Me.Btn_Generate_RFID.Text = "No Readable Code"
        Me.Btn_Generate_RFID.UseVisualStyleBackColor = True
        '
        'Btn_Accept
        '
        Me.Btn_Accept.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Accept.Location = New System.Drawing.Point(12, 155)
        Me.Btn_Accept.Name = "Btn_Accept"
        Me.Btn_Accept.Size = New System.Drawing.Size(150, 26)
        Me.Btn_Accept.TabIndex = 120
        Me.Btn_Accept.Text = "Accept and Exit"
        Me.Btn_Accept.UseVisualStyleBackColor = True
        '
        'Btn_Exit
        '
        Me.Btn_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Exit.Location = New System.Drawing.Point(195, 155)
        Me.Btn_Exit.Name = "Btn_Exit"
        Me.Btn_Exit.Size = New System.Drawing.Size(150, 26)
        Me.Btn_Exit.TabIndex = 121
        Me.Btn_Exit.Text = "Clear and Exit"
        Me.Btn_Exit.UseVisualStyleBackColor = True
        '
        'Pbx_Part_Type
        '
        Me.Pbx_Part_Type.Location = New System.Drawing.Point(395, 12)
        Me.Pbx_Part_Type.Name = "Pbx_Part_Type"
        Me.Pbx_Part_Type.Size = New System.Drawing.Size(290, 126)
        Me.Pbx_Part_Type.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pbx_Part_Type.TabIndex = 122
        Me.Pbx_Part_Type.TabStop = False
        '
        'Lbl_Part_Type
        '
        Me.Lbl_Part_Type.AutoSize = True
        Me.Lbl_Part_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Part_Type.Location = New System.Drawing.Point(486, 155)
        Me.Lbl_Part_Type.Name = "Lbl_Part_Type"
        Me.Lbl_Part_Type.Size = New System.Drawing.Size(86, 20)
        Me.Lbl_Part_Type.TabIndex = 123
        Me.Lbl_Part_Type.Text = "part_name"
        Me.Lbl_Part_Type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Defect_RFID_Manual_Entry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.Lbl_Part_Type)
        Me.Controls.Add(Me.Pbx_Part_Type)
        Me.Controls.Add(Me.Btn_Exit)
        Me.Controls.Add(Me.Btn_Accept)
        Me.Controls.Add(Me.Btn_Generate_RFID)
        Me.Controls.Add(Me.Lbl_RFID_Label)
        Me.Controls.Add(Me.Txt_RFID_Suffix)
        Me.Controls.Add(Me.Lbl_Last_Six)
        Me.Controls.Add(Me.Lbl_Man_Entry)
        Me.Controls.Add(Me.Txt_RFID_Prefix)
        Me.Controls.Add(Me.lbl_Part)
        Me.Name = "Defect_RFID_Manual_Entry"
        Me.Text = "Defect_RFID_Manual_Entry"
        CType(Me.Pbx_Part_Type, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txt_RFID_Prefix As TextBox
    Friend WithEvents lbl_Part As Label
    Friend WithEvents Lbl_Man_Entry As Label
    Friend WithEvents Txt_RFID_Suffix As TextBox
    Friend WithEvents Lbl_Last_Six As Label
    Friend WithEvents Lbl_RFID_Label As Label
    Friend WithEvents Btn_Generate_RFID As Button
    Friend WithEvents Btn_Accept As Button
    Friend WithEvents Btn_Exit As Button
    Friend WithEvents Pbx_Part_Type As PictureBox
    Friend WithEvents Lbl_Part_Type As Label
End Class
