<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Style
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Style))
        Me.DTP_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Txt_Abbreviation = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_PLC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Spanish = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Cmb_Description = New System.Windows.Forms.ComboBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Pnl_Part_Types = New System.Windows.Forms.Panel()
        Me.Lbl_Add_Sub_Area_Title = New System.Windows.Forms.Label()
        Me.Lbl_Sub_Area = New System.Windows.Forms.Label()
        Me.Btn_Add_Part_Types_Cancel = New System.Windows.Forms.Button()
        Me.btn_Add_Part_Types_Confirm = New System.Windows.Forms.Button()
        Me.Cmb_Part_Types = New System.Windows.Forms.ComboBox()
        Me.Btn_Part_Types_Delete = New System.Windows.Forms.Button()
        Me.Btn_Part_Types_Add = New System.Windows.Forms.Button()
        Me.LB_Part_Types = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Pnl_Part_Types.SuspendLayout()
        Me.SuspendLayout()
        '
        'DTP_End_Date
        '
        Me.DTP_End_Date.Checked = False
        Me.DTP_End_Date.Enabled = False
        Me.DTP_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End_Date.Location = New System.Drawing.Point(120, 231)
        Me.DTP_End_Date.Name = "DTP_End_Date"
        Me.DTP_End_Date.Size = New System.Drawing.Size(174, 23)
        Me.DTP_End_Date.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 17)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Start Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "End Date"
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Enabled = False
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(120, 190)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(174, 23)
        Me.DTP_Start_Date.TabIndex = 45
        '
        'Txt_Abbreviation
        '
        Me.Txt_Abbreviation.Enabled = False
        Me.Txt_Abbreviation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Abbreviation.Location = New System.Drawing.Point(120, 149)
        Me.Txt_Abbreviation.Name = "Txt_Abbreviation"
        Me.Txt_Abbreviation.Size = New System.Drawing.Size(137, 23)
        Me.Txt_Abbreviation.TabIndex = 44
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Abbreviation"
        '
        'Txt_PLC
        '
        Me.Txt_PLC.Enabled = False
        Me.Txt_PLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PLC.Location = New System.Drawing.Point(120, 108)
        Me.Txt_PLC.Name = "Txt_PLC"
        Me.Txt_PLC.Size = New System.Drawing.Size(137, 23)
        Me.Txt_PLC.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "PLC #"
        '
        'txt_Spanish
        '
        Me.txt_Spanish.Enabled = False
        Me.txt_Spanish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Spanish.Location = New System.Drawing.Point(120, 67)
        Me.txt_Spanish.Name = "txt_Spanish"
        Me.txt_Spanish.Size = New System.Drawing.Size(287, 23)
        Me.txt_Spanish.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Spanish"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(279, 347)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 51
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(142, 347)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 50
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(345, 299)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 49
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(208, 299)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Edit.TabIndex = 48
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(76, 299)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 47
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(120, 26)
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Description.TabIndex = 41
        Me.Txt_Description.Visible = False
        '
        'Cmb_Description
        '
        Me.Cmb_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Description.FormattingEnabled = True
        Me.Cmb_Description.Location = New System.Drawing.Point(120, 26)
        Me.Cmb_Description.Name = "Cmb_Description"
        Me.Cmb_Description.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Description.TabIndex = 40
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(70, 29)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(39, 17)
        Me.Lbl_Area.TabIndex = 52
        Me.Lbl_Area.Text = "Style"
        '
        'Pnl_Part_Types
        '
        Me.Pnl_Part_Types.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Part_Types.Controls.Add(Me.Lbl_Add_Sub_Area_Title)
        Me.Pnl_Part_Types.Controls.Add(Me.Lbl_Sub_Area)
        Me.Pnl_Part_Types.Controls.Add(Me.Btn_Add_Part_Types_Cancel)
        Me.Pnl_Part_Types.Controls.Add(Me.btn_Add_Part_Types_Confirm)
        Me.Pnl_Part_Types.Controls.Add(Me.Cmb_Part_Types)
        Me.Pnl_Part_Types.Location = New System.Drawing.Point(308, 67)
        Me.Pnl_Part_Types.Name = "Pnl_Part_Types"
        Me.Pnl_Part_Types.Size = New System.Drawing.Size(402, 185)
        Me.Pnl_Part_Types.TabIndex = 80
        Me.Pnl_Part_Types.Visible = False
        '
        'Lbl_Add_Sub_Area_Title
        '
        Me.Lbl_Add_Sub_Area_Title.AutoSize = True
        Me.Lbl_Add_Sub_Area_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Add_Sub_Area_Title.Location = New System.Drawing.Point(95, 25)
        Me.Lbl_Add_Sub_Area_Title.Name = "Lbl_Add_Sub_Area_Title"
        Me.Lbl_Add_Sub_Area_Title.Size = New System.Drawing.Size(199, 17)
        Me.Lbl_Add_Sub_Area_Title.TabIndex = 17
        Me.Lbl_Add_Sub_Area_Title.Text = "Select a part type for this style"
        Me.Lbl_Add_Sub_Area_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Sub_Area
        '
        Me.Lbl_Sub_Area.AutoSize = True
        Me.Lbl_Sub_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Area.Location = New System.Drawing.Point(10, 77)
        Me.Lbl_Sub_Area.Name = "Lbl_Sub_Area"
        Me.Lbl_Sub_Area.Size = New System.Drawing.Size(70, 17)
        Me.Lbl_Sub_Area.TabIndex = 16
        Me.Lbl_Sub_Area.Text = "Part Type"
        Me.Lbl_Sub_Area.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Btn_Add_Part_Types_Cancel
        '
        Me.Btn_Add_Part_Types_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add_Part_Types_Cancel.Location = New System.Drawing.Point(224, 119)
        Me.Btn_Add_Part_Types_Cancel.Name = "Btn_Add_Part_Types_Cancel"
        Me.Btn_Add_Part_Types_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add_Part_Types_Cancel.TabIndex = 15
        Me.Btn_Add_Part_Types_Cancel.Text = "Cancel"
        Me.Btn_Add_Part_Types_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Add_Part_Types_Confirm
        '
        Me.btn_Add_Part_Types_Confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Add_Part_Types_Confirm.Location = New System.Drawing.Point(65, 119)
        Me.btn_Add_Part_Types_Confirm.Name = "btn_Add_Part_Types_Confirm"
        Me.btn_Add_Part_Types_Confirm.Size = New System.Drawing.Size(86, 30)
        Me.btn_Add_Part_Types_Confirm.TabIndex = 14
        Me.btn_Add_Part_Types_Confirm.Text = "Add"
        Me.btn_Add_Part_Types_Confirm.UseVisualStyleBackColor = True
        '
        'Cmb_Part_Types
        '
        Me.Cmb_Part_Types.FormattingEnabled = True
        Me.Cmb_Part_Types.Location = New System.Drawing.Point(98, 73)
        Me.Cmb_Part_Types.Name = "Cmb_Part_Types"
        Me.Cmb_Part_Types.Size = New System.Drawing.Size(268, 21)
        Me.Cmb_Part_Types.TabIndex = 13
        '
        'Btn_Part_Types_Delete
        '
        Me.Btn_Part_Types_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Part_Types_Delete.Location = New System.Drawing.Point(803, 299)
        Me.Btn_Part_Types_Delete.Name = "Btn_Part_Types_Delete"
        Me.Btn_Part_Types_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Part_Types_Delete.TabIndex = 79
        Me.Btn_Part_Types_Delete.Text = "Delete"
        Me.Btn_Part_Types_Delete.UseVisualStyleBackColor = True
        Me.Btn_Part_Types_Delete.Visible = False
        '
        'Btn_Part_Types_Add
        '
        Me.Btn_Part_Types_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Part_Types_Add.Location = New System.Drawing.Point(674, 299)
        Me.Btn_Part_Types_Add.Name = "Btn_Part_Types_Add"
        Me.Btn_Part_Types_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Part_Types_Add.TabIndex = 78
        Me.Btn_Part_Types_Add.Text = "Add"
        Me.Btn_Part_Types_Add.UseVisualStyleBackColor = True
        Me.Btn_Part_Types_Add.Visible = False
        '
        'LB_Part_Types
        '
        Me.LB_Part_Types.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Part_Types.FormattingEnabled = True
        Me.LB_Part_Types.ItemHeight = 16
        Me.LB_Part_Types.Location = New System.Drawing.Point(643, 42)
        Me.LB_Part_Types.Name = "LB_Part_Types"
        Me.LB_Part_Types.Size = New System.Drawing.Size(299, 244)
        Me.LB_Part_Types.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(548, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 17)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Part Types"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(599, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(313, 13)
        Me.Label7.TabIndex = 81
        Me.Label7.Text = "Note:  Add as many of each part type that will be on each carrier."
        '
        'Style
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 400)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Pnl_Part_Types)
        Me.Controls.Add(Me.Btn_Part_Types_Delete)
        Me.Controls.Add(Me.Btn_Part_Types_Add)
        Me.Controls.Add(Me.LB_Part_Types)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DTP_End_Date)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Txt_Abbreviation)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_PLC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txt_Spanish)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Edit)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.Txt_Description)
        Me.Controls.Add(Me.Cmb_Description)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Style"
        Me.Text = "Styles"
        Me.Pnl_Part_Types.ResumeLayout(False)
        Me.Pnl_Part_Types.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DTP_End_Date As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DTP_Start_Date As DateTimePicker
    Friend WithEvents Txt_Abbreviation As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_PLC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_Spanish As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Txt_Description As TextBox
    Friend WithEvents Cmb_Description As ComboBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Pnl_Part_Types As Panel
    Friend WithEvents Lbl_Add_Sub_Area_Title As Label
    Friend WithEvents Lbl_Sub_Area As Label
    Friend WithEvents Btn_Add_Part_Types_Cancel As Button
    Friend WithEvents btn_Add_Part_Types_Confirm As Button
    Friend WithEvents Cmb_Part_Types As ComboBox
    Friend WithEvents Btn_Part_Types_Delete As Button
    Friend WithEvents Btn_Part_Types_Add As Button
    Friend WithEvents LB_Part_Types As ListBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
