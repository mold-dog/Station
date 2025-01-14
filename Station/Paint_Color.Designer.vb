<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Paint_Color
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Paint_Color))
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
        Me.Txt_PLC = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Abbreviation = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Opt_Base = New System.Windows.Forms.RadioButton()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Opt_Prime = New System.Windows.Forms.RadioButton()
        Me.Opt_Clear = New System.Windows.Forms.RadioButton()
        Me.Opt_Top_Coat = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.Txt_Part_Number = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_Spanish
        '
        Me.txt_Spanish.Enabled = False
        Me.txt_Spanish.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Spanish.Location = New System.Drawing.Point(106, 72)
        Me.txt_Spanish.MaxLength = 50
        Me.txt_Spanish.Name = "txt_Spanish"
        Me.txt_Spanish.Size = New System.Drawing.Size(287, 23)
        Me.txt_Spanish.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 17)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Spanish"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(265, 524)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 29
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(128, 524)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 28
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(331, 476)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 27
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(194, 476)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Edit.TabIndex = 26
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(62, 476)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 25
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(106, 31)
        Me.Txt_Description.MaxLength = 50
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Description.TabIndex = 15
        Me.Txt_Description.Visible = False
        '
        'Cmb_Description
        '
        Me.Cmb_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Description.FormattingEnabled = True
        Me.Cmb_Description.Location = New System.Drawing.Point(106, 31)
        Me.Cmb_Description.Name = "Cmb_Description"
        Me.Cmb_Description.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Description.TabIndex = 14
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(56, 34)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(41, 17)
        Me.Lbl_Area.TabIndex = 30
        Me.Lbl_Area.Text = "Color"
        '
        'Txt_PLC
        '
        Me.Txt_PLC.Enabled = False
        Me.Txt_PLC.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PLC.Location = New System.Drawing.Point(106, 113)
        Me.Txt_PLC.Name = "Txt_PLC"
        Me.Txt_PLC.Size = New System.Drawing.Size(137, 23)
        Me.Txt_PLC.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "PLC #"
        '
        'Txt_Abbreviation
        '
        Me.Txt_Abbreviation.Enabled = False
        Me.Txt_Abbreviation.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Abbreviation.Location = New System.Drawing.Point(106, 154)
        Me.Txt_Abbreviation.MaxLength = 5
        Me.Txt_Abbreviation.Name = "Txt_Abbreviation"
        Me.Txt_Abbreviation.Size = New System.Drawing.Size(137, 23)
        Me.Txt_Abbreviation.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Abbreviation"
        '
        'Opt_Base
        '
        Me.Opt_Base.AutoSize = True
        Me.Opt_Base.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Opt_Base.Enabled = False
        Me.Opt_Base.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Base.Location = New System.Drawing.Point(62, 360)
        Me.Opt_Base.Name = "Opt_Base"
        Me.Opt_Base.Size = New System.Drawing.Size(58, 21)
        Me.Opt_Base.TabIndex = 22
        Me.Opt_Base.TabStop = True
        Me.Opt_Base.Text = "Base"
        Me.Opt_Base.UseVisualStyleBackColor = True
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Enabled = False
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(106, 239)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(174, 23)
        Me.DTP_Start_Date.TabIndex = 19
        '
        'Opt_Prime
        '
        Me.Opt_Prime.AutoSize = True
        Me.Opt_Prime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Opt_Prime.Enabled = False
        Me.Opt_Prime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Prime.Location = New System.Drawing.Point(58, 321)
        Me.Opt_Prime.Name = "Opt_Prime"
        Me.Opt_Prime.Size = New System.Drawing.Size(62, 21)
        Me.Opt_Prime.TabIndex = 21
        Me.Opt_Prime.TabStop = True
        Me.Opt_Prime.Text = "Prime"
        Me.Opt_Prime.UseVisualStyleBackColor = True
        '
        'Opt_Clear
        '
        Me.Opt_Clear.AutoSize = True
        Me.Opt_Clear.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Opt_Clear.Enabled = False
        Me.Opt_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Clear.Location = New System.Drawing.Point(61, 438)
        Me.Opt_Clear.Name = "Opt_Clear"
        Me.Opt_Clear.Size = New System.Drawing.Size(59, 21)
        Me.Opt_Clear.TabIndex = 24
        Me.Opt_Clear.TabStop = True
        Me.Opt_Clear.Text = "Clear"
        Me.Opt_Clear.UseVisualStyleBackColor = True
        '
        'Opt_Top_Coat
        '
        Me.Opt_Top_Coat.AutoSize = True
        Me.Opt_Top_Coat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Opt_Top_Coat.Enabled = False
        Me.Opt_Top_Coat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Top_Coat.Location = New System.Drawing.Point(36, 399)
        Me.Opt_Top_Coat.Name = "Opt_Top_Coat"
        Me.Opt_Top_Coat.Size = New System.Drawing.Size(84, 21)
        Me.Opt_Top_Coat.TabIndex = 23
        Me.Opt_Top_Coat.TabStop = True
        Me.Opt_Top_Coat.Text = "Top Coat"
        Me.Opt_Top_Coat.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 285)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "End Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 17)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Start Date"
        '
        'DTP_End_Date
        '
        Me.DTP_End_Date.Checked = False
        Me.DTP_End_Date.Enabled = False
        Me.DTP_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End_Date.Location = New System.Drawing.Point(106, 280)
        Me.DTP_End_Date.Name = "DTP_End_Date"
        Me.DTP_End_Date.Size = New System.Drawing.Size(174, 23)
        Me.DTP_End_Date.TabIndex = 20
        '
        'Txt_Part_Number
        '
        Me.Txt_Part_Number.Enabled = False
        Me.Txt_Part_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Part_Number.Location = New System.Drawing.Point(106, 196)
        Me.Txt_Part_Number.MaxLength = 10
        Me.Txt_Part_Number.Name = "Txt_Part_Number"
        Me.Txt_Part_Number.Size = New System.Drawing.Size(162, 23)
        Me.Txt_Part_Number.TabIndex = 43
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 17)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Part Number"
        '
        'Paint_Color
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 600)
        Me.Controls.Add(Me.Txt_Part_Number)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DTP_End_Date)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Opt_Top_Coat)
        Me.Controls.Add(Me.Opt_Clear)
        Me.Controls.Add(Me.Opt_Prime)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Opt_Base)
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
        Me.Name = "Paint_Color"
        Me.Text = "Paint Colors"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents Txt_PLC As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Abbreviation As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Opt_Base As RadioButton
    Friend WithEvents DTP_Start_Date As DateTimePicker
    Friend WithEvents Opt_Prime As RadioButton
    Friend WithEvents Opt_Clear As RadioButton
    Friend WithEvents Opt_Top_Coat As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DTP_End_Date As DateTimePicker
    Friend WithEvents Txt_Part_Number As TextBox
    Friend WithEvents Label6 As Label
End Class
