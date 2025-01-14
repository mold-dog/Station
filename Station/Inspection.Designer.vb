<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inspection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Inspection))
        Me.Lbl_Part = New System.Windows.Forms.Label()
        Me.CLB_Inspection_Items = New System.Windows.Forms.CheckedListBox()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Txt_Color = New System.Windows.Forms.TextBox()
        Me.Txt_Part_Type = New System.Windows.Forms.TextBox()
        Me.Lbl_Color = New System.Windows.Forms.Label()
        Me.Lbl_Type = New System.Windows.Forms.Label()
        Me.Txt_RFID = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Lbl_Part
        '
        Me.Lbl_Part.AutoSize = True
        Me.Lbl_Part.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Part.Location = New System.Drawing.Point(15, 23)
        Me.Lbl_Part.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Part.Name = "Lbl_Part"
        Me.Lbl_Part.Size = New System.Drawing.Size(47, 25)
        Me.Lbl_Part.TabIndex = 40
        Me.Lbl_Part.Text = "Part"
        '
        'CLB_Inspection_Items
        '
        Me.CLB_Inspection_Items.CheckOnClick = True
        Me.CLB_Inspection_Items.Enabled = False
        Me.CLB_Inspection_Items.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.CLB_Inspection_Items.FormattingEnabled = True
        Me.CLB_Inspection_Items.HorizontalScrollbar = True
        Me.CLB_Inspection_Items.Location = New System.Drawing.Point(18, 118)
        Me.CLB_Inspection_Items.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CLB_Inspection_Items.Name = "CLB_Inspection_Items"
        Me.CLB_Inspection_Items.ScrollAlwaysVisible = True
        Me.CLB_Inspection_Items.Size = New System.Drawing.Size(1210, 548)
        Me.CLB_Inspection_Items.TabIndex = 42
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(20, 63)
        Me.Btn_Edit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(129, 46)
        Me.Btn_Edit.TabIndex = 67
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Txt_Color
        '
        Me.Txt_Color.Enabled = False
        Me.Txt_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Color.Location = New System.Drawing.Point(690, 63)
        Me.Txt_Color.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_Color.Name = "Txt_Color"
        Me.Txt_Color.Size = New System.Drawing.Size(438, 30)
        Me.Txt_Color.TabIndex = 71
        '
        'Txt_Part_Type
        '
        Me.Txt_Part_Type.Enabled = False
        Me.Txt_Part_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Part_Type.Location = New System.Drawing.Point(690, 20)
        Me.Txt_Part_Type.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_Part_Type.Name = "Txt_Part_Type"
        Me.Txt_Part_Type.Size = New System.Drawing.Size(438, 30)
        Me.Txt_Part_Type.TabIndex = 70
        '
        'Lbl_Color
        '
        Me.Lbl_Color.AutoSize = True
        Me.Lbl_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Color.Location = New System.Drawing.Point(606, 68)
        Me.Lbl_Color.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Color.Name = "Lbl_Color"
        Me.Lbl_Color.Size = New System.Drawing.Size(59, 25)
        Me.Lbl_Color.TabIndex = 69
        Me.Lbl_Color.Text = "Color"
        '
        'Lbl_Type
        '
        Me.Lbl_Type.AutoSize = True
        Me.Lbl_Type.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Type.Location = New System.Drawing.Point(608, 25)
        Me.Lbl_Type.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lbl_Type.Name = "Lbl_Type"
        Me.Lbl_Type.Size = New System.Drawing.Size(57, 25)
        Me.Lbl_Type.TabIndex = 68
        Me.Lbl_Type.Text = "Type"
        '
        'Txt_RFID
        '
        Me.Txt_RFID.Enabled = False
        Me.Txt_RFID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFID.Location = New System.Drawing.Point(75, 20)
        Me.Txt_RFID.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Txt_RFID.Name = "Txt_RFID"
        Me.Txt_RFID.Size = New System.Drawing.Size(438, 30)
        Me.Txt_RFID.TabIndex = 150
        '
        'Inspection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1252, 724)
        Me.Controls.Add(Me.Txt_RFID)
        Me.Controls.Add(Me.Txt_Color)
        Me.Controls.Add(Me.Txt_Part_Type)
        Me.Controls.Add(Me.Lbl_Color)
        Me.Controls.Add(Me.Lbl_Type)
        Me.Controls.Add(Me.Btn_Edit)
        Me.Controls.Add(Me.CLB_Inspection_Items)
        Me.Controls.Add(Me.Lbl_Part)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Inspection"
        Me.Text = "Inspection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Part As Label
    Friend WithEvents CLB_Inspection_Items As CheckedListBox
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Txt_Color As TextBox
    Friend WithEvents Txt_Part_Type As TextBox
    Friend WithEvents Lbl_Color As Label
    Friend WithEvents Lbl_Type As Label
    Friend WithEvents Txt_RFID As TextBox
End Class
