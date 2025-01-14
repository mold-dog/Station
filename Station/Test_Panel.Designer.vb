<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Test_Panel
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Lbl_Tag_Killed = New System.Windows.Forms.Label()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Btn_Part_Info = New System.Windows.Forms.Button()
        Me.DGV_Paint_Data = New System.Windows.Forms.DataGridView()
        Me.Txt_RFID = New System.Windows.Forms.TextBox()
        Me.Cmb_Serial_Ports = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Connect = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Cmb_Location = New System.Windows.Forms.ComboBox()
        Me.Txt_Tested_By = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Lbl_Double_Rub = New System.Windows.Forms.Label()
        Me.Lbl_Color = New System.Windows.Forms.Label()
        Me.Lbl_Adhesion = New System.Windows.Forms.Label()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Cmb_Reclear_Location = New System.Windows.Forms.ComboBox()
        Me.Txt_Reclear_Tested_By = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Lbl_Reclear_Double_Rub = New System.Windows.Forms.Label()
        Me.Lbl_Reclear_Color = New System.Windows.Forms.Label()
        Me.Lbl_Reclear_Adhesion = New System.Windows.Forms.Label()
        Me.Btn_Reclear_Save = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Cmb_M5_Double_Rub2_PT = New System.Windows.Forms.ComboBox()
        Me.Cmb_M5_Double_Rub2_GL = New System.Windows.Forms.ComboBox()
        Me.Cmb_M5_Hardness = New System.Windows.Forms.ComboBox()
        Me.Cmb_M5_Adhesion = New System.Windows.Forms.ComboBox()
        Me.Lbl_M5_Double_Rub2_PT = New System.Windows.Forms.Label()
        Me.Txt_M5_Gloss = New System.Windows.Forms.TextBox()
        Me.Lbl_M5_Gloss = New System.Windows.Forms.Label()
        Me.Lbl_M5_Hardness = New System.Windows.Forms.Label()
        Me.Txt_M5_Orange_Peel = New System.Windows.Forms.TextBox()
        Me.Lbl_M5_Orange_Peel = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Cmb_M5_Location = New System.Windows.Forms.ComboBox()
        Me.Txt_M5_Tested_By = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Lbl_M5_Double_Rub2_GL = New System.Windows.Forms.Label()
        Me.Txt_M5_Color = New System.Windows.Forms.TextBox()
        Me.Lbl_M5_Color = New System.Windows.Forms.Label()
        Me.Lbl_M5_Adhesion = New System.Windows.Forms.Label()
        Me.Btn_M5_Save = New System.Windows.Forms.Button()
        Me.Cmb_Adhesion = New System.Windows.Forms.ComboBox()
        Me.Cmb_Double_Rub = New System.Windows.Forms.ComboBox()
        Me.Cmb_Color = New System.Windows.Forms.ComboBox()
        Me.Cmb_Reclear_Color = New System.Windows.Forms.ComboBox()
        Me.Cmb_Reclear_Double_Rub = New System.Windows.Forms.ComboBox()
        Me.Cmb_Reclear_Adhesion = New System.Windows.Forms.ComboBox()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Tag_Killed
        '
        Me.Lbl_Tag_Killed.AutoSize = True
        Me.Lbl_Tag_Killed.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Tag_Killed.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Tag_Killed.Location = New System.Drawing.Point(579, 121)
        Me.Lbl_Tag_Killed.Name = "Lbl_Tag_Killed"
        Me.Lbl_Tag_Killed.Size = New System.Drawing.Size(350, 37)
        Me.Lbl_Tag_Killed.TabIndex = 144
        Me.Lbl_Tag_Killed.Text = "TAG KILLED - 1/1/2017"
        Me.Lbl_Tag_Killed.Visible = False
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(75, 60)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(39, 17)
        Me.Lbl_Area.TabIndex = 130
        Me.Lbl_Area.Text = "RFID"
        '
        'Btn_Part_Info
        '
        Me.Btn_Part_Info.Location = New System.Drawing.Point(356, 92)
        Me.Btn_Part_Info.Name = "Btn_Part_Info"
        Me.Btn_Part_Info.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Part_Info.TabIndex = 146
        Me.Btn_Part_Info.Text = "Part Info"
        Me.Btn_Part_Info.UseVisualStyleBackColor = True
        '
        'DGV_Paint_Data
        '
        Me.DGV_Paint_Data.AllowUserToAddRows = False
        Me.DGV_Paint_Data.AllowUserToDeleteRows = False
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DGV_Paint_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Paint_Data.DefaultCellStyle = DataGridViewCellStyle14
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(447, 12)
        Me.DGV_Paint_Data.Name = "DGV_Paint_Data"
        Me.DGV_Paint_Data.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(712, 415)
        Me.DGV_Paint_Data.TabIndex = 145
        '
        'Txt_RFID
        '
        Me.Txt_RFID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFID.Location = New System.Drawing.Point(119, 57)
        Me.Txt_RFID.MaxLength = 50
        Me.Txt_RFID.Name = "Txt_RFID"
        Me.Txt_RFID.Size = New System.Drawing.Size(287, 23)
        Me.Txt_RFID.TabIndex = 147
        '
        'Cmb_Serial_Ports
        '
        Me.Cmb_Serial_Ports.FormattingEnabled = True
        Me.Cmb_Serial_Ports.Location = New System.Drawing.Point(119, 12)
        Me.Cmb_Serial_Ports.Name = "Cmb_Serial_Ports"
        Me.Cmb_Serial_Ports.Size = New System.Drawing.Size(187, 21)
        Me.Cmb_Serial_Ports.TabIndex = 149
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Serial Port"
        '
        'Btn_Connect
        '
        Me.Btn_Connect.Location = New System.Drawing.Point(356, 8)
        Me.Btn_Connect.Name = "Btn_Connect"
        Me.Btn_Connect.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Connect.TabIndex = 150
        Me.Btn_Connect.Text = "Get Part"
        Me.Btn_Connect.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(17, 121)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(414, 310)
        Me.TabControl1.TabIndex = 151
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.Cmb_Color)
        Me.TabPage1.Controls.Add(Me.Cmb_Double_Rub)
        Me.TabPage1.Controls.Add(Me.Cmb_Adhesion)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Cmb_Location)
        Me.TabPage1.Controls.Add(Me.Txt_Tested_By)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Lbl_Double_Rub)
        Me.TabPage1.Controls.Add(Me.Lbl_Color)
        Me.TabPage1.Controls.Add(Me.Lbl_Adhesion)
        Me.TabPage1.Controls.Add(Me.Btn_Save)
        Me.TabPage1.Location = New System.Drawing.Point(4, 33)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(406, 273)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "   Paint Run     "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(53, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 17)
        Me.Label7.TabIndex = 154
        Me.Label7.Text = "Location"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_Location
        '
        Me.Cmb_Location.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Location.FormattingEnabled = True
        Me.Cmb_Location.Location = New System.Drawing.Point(115, 12)
        Me.Cmb_Location.Name = "Cmb_Location"
        Me.Cmb_Location.Size = New System.Drawing.Size(84, 24)
        Me.Cmb_Location.TabIndex = 153
        '
        'Txt_Tested_By
        '
        Me.Txt_Tested_By.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tested_By.Location = New System.Drawing.Point(115, 180)
        Me.Txt_Tested_By.MaxLength = 50
        Me.Txt_Tested_By.Name = "Txt_Tested_By"
        Me.Txt_Tested_By.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Tested_By.TabIndex = 151
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "Tested By"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Double_Rub
        '
        Me.Lbl_Double_Rub.AutoSize = True
        Me.Lbl_Double_Rub.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Double_Rub.Location = New System.Drawing.Point(3, 143)
        Me.Lbl_Double_Rub.Name = "Lbl_Double_Rub"
        Me.Lbl_Double_Rub.Size = New System.Drawing.Size(112, 17)
        Me.Lbl_Double_Rub.TabIndex = 150
        Me.Lbl_Double_Rub.Text = "Double Rub: P/F"
        Me.Lbl_Double_Rub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Color
        '
        Me.Lbl_Color.AutoSize = True
        Me.Lbl_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Color.Location = New System.Drawing.Point(45, 102)
        Me.Lbl_Color.Name = "Lbl_Color"
        Me.Lbl_Color.Size = New System.Drawing.Size(70, 17)
        Me.Lbl_Color.TabIndex = 148
        Me.Lbl_Color.Text = "Color: P/F"
        Me.Lbl_Color.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Adhesion
        '
        Me.Lbl_Adhesion.AutoSize = True
        Me.Lbl_Adhesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Adhesion.Location = New System.Drawing.Point(19, 62)
        Me.Lbl_Adhesion.Name = "Lbl_Adhesion"
        Me.Lbl_Adhesion.Size = New System.Drawing.Size(96, 17)
        Me.Lbl_Adhesion.TabIndex = 146
        Me.Lbl_Adhesion.Text = "Adhesion: P/F"
        Me.Lbl_Adhesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(172, 233)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 144
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.LightGray
        Me.TabPage2.Controls.Add(Me.Cmb_Reclear_Color)
        Me.TabPage2.Controls.Add(Me.Cmb_Reclear_Double_Rub)
        Me.TabPage2.Controls.Add(Me.Cmb_Reclear_Adhesion)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Cmb_Reclear_Location)
        Me.TabPage2.Controls.Add(Me.Txt_Reclear_Tested_By)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Lbl_Reclear_Double_Rub)
        Me.TabPage2.Controls.Add(Me.Lbl_Reclear_Color)
        Me.TabPage2.Controls.Add(Me.Lbl_Reclear_Adhesion)
        Me.TabPage2.Controls.Add(Me.Btn_Reclear_Save)
        Me.TabPage2.Location = New System.Drawing.Point(4, 33)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(406, 273)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "   Reclear      "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(53, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 17)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "Location"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_Reclear_Location
        '
        Me.Cmb_Reclear_Location.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Reclear_Location.FormattingEnabled = True
        Me.Cmb_Reclear_Location.Location = New System.Drawing.Point(116, 11)
        Me.Cmb_Reclear_Location.Name = "Cmb_Reclear_Location"
        Me.Cmb_Reclear_Location.Size = New System.Drawing.Size(84, 24)
        Me.Cmb_Reclear_Location.TabIndex = 164
        '
        'Txt_Reclear_Tested_By
        '
        Me.Txt_Reclear_Tested_By.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Reclear_Tested_By.Location = New System.Drawing.Point(116, 179)
        Me.Txt_Reclear_Tested_By.MaxLength = 50
        Me.Txt_Reclear_Tested_By.Name = "Txt_Reclear_Tested_By"
        Me.Txt_Reclear_Tested_By.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Reclear_Tested_By.TabIndex = 162
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(43, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 17)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Tested By"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Reclear_Double_Rub
        '
        Me.Lbl_Reclear_Double_Rub.AutoSize = True
        Me.Lbl_Reclear_Double_Rub.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Reclear_Double_Rub.Location = New System.Drawing.Point(3, 142)
        Me.Lbl_Reclear_Double_Rub.Name = "Lbl_Reclear_Double_Rub"
        Me.Lbl_Reclear_Double_Rub.Size = New System.Drawing.Size(112, 17)
        Me.Lbl_Reclear_Double_Rub.TabIndex = 161
        Me.Lbl_Reclear_Double_Rub.Text = "Double Rub: P/F"
        Me.Lbl_Reclear_Double_Rub.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Reclear_Color
        '
        Me.Lbl_Reclear_Color.AutoSize = True
        Me.Lbl_Reclear_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Reclear_Color.Location = New System.Drawing.Point(45, 101)
        Me.Lbl_Reclear_Color.Name = "Lbl_Reclear_Color"
        Me.Lbl_Reclear_Color.Size = New System.Drawing.Size(70, 17)
        Me.Lbl_Reclear_Color.TabIndex = 159
        Me.Lbl_Reclear_Color.Text = "Color: P/F"
        Me.Lbl_Reclear_Color.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Reclear_Adhesion
        '
        Me.Lbl_Reclear_Adhesion.AutoSize = True
        Me.Lbl_Reclear_Adhesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Reclear_Adhesion.Location = New System.Drawing.Point(19, 61)
        Me.Lbl_Reclear_Adhesion.Name = "Lbl_Reclear_Adhesion"
        Me.Lbl_Reclear_Adhesion.Size = New System.Drawing.Size(96, 17)
        Me.Lbl_Reclear_Adhesion.TabIndex = 157
        Me.Lbl_Reclear_Adhesion.Text = "Adhesion: P/F"
        Me.Lbl_Reclear_Adhesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Btn_Reclear_Save
        '
        Me.Btn_Reclear_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Reclear_Save.Location = New System.Drawing.Point(176, 232)
        Me.Btn_Reclear_Save.Name = "Btn_Reclear_Save"
        Me.Btn_Reclear_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Reclear_Save.TabIndex = 155
        Me.Btn_Reclear_Save.Text = "Save"
        Me.Btn_Reclear_Save.UseVisualStyleBackColor = True
        Me.Btn_Reclear_Save.Visible = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Silver
        Me.TabPage3.Controls.Add(Me.Cmb_M5_Double_Rub2_PT)
        Me.TabPage3.Controls.Add(Me.Cmb_M5_Double_Rub2_GL)
        Me.TabPage3.Controls.Add(Me.Cmb_M5_Hardness)
        Me.TabPage3.Controls.Add(Me.Cmb_M5_Adhesion)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Double_Rub2_PT)
        Me.TabPage3.Controls.Add(Me.Txt_M5_Gloss)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Gloss)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Hardness)
        Me.TabPage3.Controls.Add(Me.Txt_M5_Orange_Peel)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Orange_Peel)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Cmb_M5_Location)
        Me.TabPage3.Controls.Add(Me.Txt_M5_Tested_By)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Double_Rub2_GL)
        Me.TabPage3.Controls.Add(Me.Txt_M5_Color)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Color)
        Me.TabPage3.Controls.Add(Me.Lbl_M5_Adhesion)
        Me.TabPage3.Controls.Add(Me.Btn_M5_Save)
        Me.TabPage3.Location = New System.Drawing.Point(4, 33)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(406, 273)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "   Magic 5   "
        '
        'Cmb_M5_Double_Rub2_PT
        '
        Me.Cmb_M5_Double_Rub2_PT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_M5_Double_Rub2_PT.FormattingEnabled = True
        Me.Cmb_M5_Double_Rub2_PT.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_M5_Double_Rub2_PT.Location = New System.Drawing.Point(307, 161)
        Me.Cmb_M5_Double_Rub2_PT.Name = "Cmb_M5_Double_Rub2_PT"
        Me.Cmb_M5_Double_Rub2_PT.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_M5_Double_Rub2_PT.TabIndex = 178
        '
        'Cmb_M5_Double_Rub2_GL
        '
        Me.Cmb_M5_Double_Rub2_GL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_M5_Double_Rub2_GL.FormattingEnabled = True
        Me.Cmb_M5_Double_Rub2_GL.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_M5_Double_Rub2_GL.Location = New System.Drawing.Point(307, 122)
        Me.Cmb_M5_Double_Rub2_GL.Name = "Cmb_M5_Double_Rub2_GL"
        Me.Cmb_M5_Double_Rub2_GL.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_M5_Double_Rub2_GL.TabIndex = 177
        '
        'Cmb_M5_Hardness
        '
        Me.Cmb_M5_Hardness.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_M5_Hardness.FormattingEnabled = True
        Me.Cmb_M5_Hardness.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_M5_Hardness.Location = New System.Drawing.Point(339, 44)
        Me.Cmb_M5_Hardness.Name = "Cmb_M5_Hardness"
        Me.Cmb_M5_Hardness.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_M5_Hardness.TabIndex = 176
        '
        'Cmb_M5_Adhesion
        '
        Me.Cmb_M5_Adhesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_M5_Adhesion.FormattingEnabled = True
        Me.Cmb_M5_Adhesion.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_M5_Adhesion.Location = New System.Drawing.Point(142, 44)
        Me.Cmb_M5_Adhesion.Name = "Cmb_M5_Adhesion"
        Me.Cmb_M5_Adhesion.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_M5_Adhesion.TabIndex = 175
        '
        'Lbl_M5_Double_Rub2_PT
        '
        Me.Lbl_M5_Double_Rub2_PT.AutoSize = True
        Me.Lbl_M5_Double_Rub2_PT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Double_Rub2_PT.Location = New System.Drawing.Point(79, 165)
        Me.Lbl_M5_Double_Rub2_PT.Name = "Lbl_M5_Double_Rub2_PT"
        Me.Lbl_M5_Double_Rub2_PT.Size = New System.Drawing.Size(206, 17)
        Me.Lbl_M5_Double_Rub2_PT.TabIndex = 173
        Me.Lbl_M5_Double_Rub2_PT.Text = "Double Rub Paint Transfer: P/F"
        Me.Lbl_M5_Double_Rub2_PT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_M5_Gloss
        '
        Me.Txt_M5_Gloss.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_M5_Gloss.Location = New System.Drawing.Point(339, 84)
        Me.Txt_M5_Gloss.MaxLength = 5
        Me.Txt_M5_Gloss.Name = "Txt_M5_Gloss"
        Me.Txt_M5_Gloss.Size = New System.Drawing.Size(37, 23)
        Me.Txt_M5_Gloss.TabIndex = 170
        '
        'Lbl_M5_Gloss
        '
        Me.Lbl_M5_Gloss.AutoSize = True
        Me.Lbl_M5_Gloss.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Gloss.Location = New System.Drawing.Point(240, 87)
        Me.Lbl_M5_Gloss.Name = "Lbl_M5_Gloss"
        Me.Lbl_M5_Gloss.Size = New System.Drawing.Size(89, 17)
        Me.Lbl_M5_Gloss.TabIndex = 171
        Me.Lbl_M5_Gloss.Text = "Gloss: 0-100"
        Me.Lbl_M5_Gloss.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_M5_Hardness
        '
        Me.Lbl_M5_Hardness.AutoSize = True
        Me.Lbl_M5_Hardness.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Hardness.Location = New System.Drawing.Point(231, 48)
        Me.Lbl_M5_Hardness.Name = "Lbl_M5_Hardness"
        Me.Lbl_M5_Hardness.Size = New System.Drawing.Size(98, 17)
        Me.Lbl_M5_Hardness.TabIndex = 169
        Me.Lbl_M5_Hardness.Text = "Hardness: P/F"
        Me.Lbl_M5_Hardness.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_M5_Orange_Peel
        '
        Me.Txt_M5_Orange_Peel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_M5_Orange_Peel.Location = New System.Drawing.Point(339, 6)
        Me.Txt_M5_Orange_Peel.MaxLength = 4
        Me.Txt_M5_Orange_Peel.Name = "Txt_M5_Orange_Peel"
        Me.Txt_M5_Orange_Peel.Size = New System.Drawing.Size(37, 23)
        Me.Txt_M5_Orange_Peel.TabIndex = 166
        '
        'Lbl_M5_Orange_Peel
        '
        Me.Lbl_M5_Orange_Peel.AutoSize = True
        Me.Lbl_M5_Orange_Peel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Orange_Peel.Location = New System.Drawing.Point(204, 9)
        Me.Lbl_M5_Orange_Peel.Name = "Lbl_M5_Orange_Peel"
        Me.Lbl_M5_Orange_Peel.Size = New System.Drawing.Size(125, 17)
        Me.Lbl_M5_Orange_Peel.TabIndex = 167
        Me.Lbl_M5_Orange_Peel.Text = "Orange Peel: 1-10"
        Me.Lbl_M5_Orange_Peel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(28, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 17)
        Me.Label12.TabIndex = 165
        Me.Label12.Text = "Location"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Cmb_M5_Location
        '
        Me.Cmb_M5_Location.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_M5_Location.FormattingEnabled = True
        Me.Cmb_M5_Location.Location = New System.Drawing.Point(95, 5)
        Me.Cmb_M5_Location.Name = "Cmb_M5_Location"
        Me.Cmb_M5_Location.Size = New System.Drawing.Size(84, 24)
        Me.Cmb_M5_Location.TabIndex = 164
        '
        'Txt_M5_Tested_By
        '
        Me.Txt_M5_Tested_By.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_M5_Tested_By.Location = New System.Drawing.Point(89, 203)
        Me.Txt_M5_Tested_By.MaxLength = 50
        Me.Txt_M5_Tested_By.Name = "Txt_M5_Tested_By"
        Me.Txt_M5_Tested_By.Size = New System.Drawing.Size(287, 23)
        Me.Txt_M5_Tested_By.TabIndex = 162
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 206)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 17)
        Me.Label13.TabIndex = 163
        Me.Label13.Text = "Tested By"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_M5_Double_Rub2_GL
        '
        Me.Lbl_M5_Double_Rub2_GL.AutoSize = True
        Me.Lbl_M5_Double_Rub2_GL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Double_Rub2_GL.Location = New System.Drawing.Point(99, 126)
        Me.Lbl_M5_Double_Rub2_GL.Name = "Lbl_M5_Double_Rub2_GL"
        Me.Lbl_M5_Double_Rub2_GL.Size = New System.Drawing.Size(186, 17)
        Me.Lbl_M5_Double_Rub2_GL.TabIndex = 161
        Me.Lbl_M5_Double_Rub2_GL.Text = "Double Rub Gloss Loss: P/F"
        Me.Lbl_M5_Double_Rub2_GL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_M5_Color
        '
        Me.Txt_M5_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_M5_Color.Location = New System.Drawing.Point(142, 84)
        Me.Txt_M5_Color.MaxLength = 5
        Me.Txt_M5_Color.Name = "Txt_M5_Color"
        Me.Txt_M5_Color.Size = New System.Drawing.Size(37, 23)
        Me.Txt_M5_Color.TabIndex = 158
        '
        'Lbl_M5_Color
        '
        Me.Lbl_M5_Color.AutoSize = True
        Me.Lbl_M5_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Color.Location = New System.Drawing.Point(58, 87)
        Me.Lbl_M5_Color.Name = "Lbl_M5_Color"
        Me.Lbl_M5_Color.Size = New System.Drawing.Size(78, 17)
        Me.Lbl_M5_Color.TabIndex = 159
        Me.Lbl_M5_Color.Text = "Color: 0-10"
        Me.Lbl_M5_Color.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_M5_Adhesion
        '
        Me.Lbl_M5_Adhesion.AutoSize = True
        Me.Lbl_M5_Adhesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_M5_Adhesion.Location = New System.Drawing.Point(40, 48)
        Me.Lbl_M5_Adhesion.Name = "Lbl_M5_Adhesion"
        Me.Lbl_M5_Adhesion.Size = New System.Drawing.Size(96, 17)
        Me.Lbl_M5_Adhesion.TabIndex = 157
        Me.Lbl_M5_Adhesion.Text = "Adhesion: P/F"
        Me.Lbl_M5_Adhesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Btn_M5_Save
        '
        Me.Btn_M5_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_M5_Save.Location = New System.Drawing.Point(160, 237)
        Me.Btn_M5_Save.Name = "Btn_M5_Save"
        Me.Btn_M5_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_M5_Save.TabIndex = 155
        Me.Btn_M5_Save.Text = "Save"
        Me.Btn_M5_Save.UseVisualStyleBackColor = True
        Me.Btn_M5_Save.Visible = False
        '
        'Cmb_Adhesion
        '
        Me.Cmb_Adhesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Adhesion.FormattingEnabled = True
        Me.Cmb_Adhesion.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_Adhesion.Location = New System.Drawing.Point(115, 58)
        Me.Cmb_Adhesion.Name = "Cmb_Adhesion"
        Me.Cmb_Adhesion.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_Adhesion.TabIndex = 176
        '
        'Cmb_Double_Rub
        '
        Me.Cmb_Double_Rub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Double_Rub.FormattingEnabled = True
        Me.Cmb_Double_Rub.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_Double_Rub.Location = New System.Drawing.Point(115, 139)
        Me.Cmb_Double_Rub.Name = "Cmb_Double_Rub"
        Me.Cmb_Double_Rub.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_Double_Rub.TabIndex = 177
        '
        'Cmb_Color
        '
        Me.Cmb_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Color.FormattingEnabled = True
        Me.Cmb_Color.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_Color.Location = New System.Drawing.Point(115, 98)
        Me.Cmb_Color.Name = "Cmb_Color"
        Me.Cmb_Color.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_Color.TabIndex = 178
        '
        'Cmb_Reclear_Color
        '
        Me.Cmb_Reclear_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Reclear_Color.FormattingEnabled = True
        Me.Cmb_Reclear_Color.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_Reclear_Color.Location = New System.Drawing.Point(116, 97)
        Me.Cmb_Reclear_Color.Name = "Cmb_Reclear_Color"
        Me.Cmb_Reclear_Color.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_Reclear_Color.TabIndex = 181
        '
        'Cmb_Reclear_Double_Rub
        '
        Me.Cmb_Reclear_Double_Rub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Reclear_Double_Rub.FormattingEnabled = True
        Me.Cmb_Reclear_Double_Rub.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_Reclear_Double_Rub.Location = New System.Drawing.Point(116, 138)
        Me.Cmb_Reclear_Double_Rub.Name = "Cmb_Reclear_Double_Rub"
        Me.Cmb_Reclear_Double_Rub.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_Reclear_Double_Rub.TabIndex = 180
        '
        'Cmb_Reclear_Adhesion
        '
        Me.Cmb_Reclear_Adhesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Reclear_Adhesion.FormattingEnabled = True
        Me.Cmb_Reclear_Adhesion.Items.AddRange(New Object() {"P", "F"})
        Me.Cmb_Reclear_Adhesion.Location = New System.Drawing.Point(116, 57)
        Me.Cmb_Reclear_Adhesion.Name = "Cmb_Reclear_Adhesion"
        Me.Cmb_Reclear_Adhesion.Size = New System.Drawing.Size(39, 24)
        Me.Cmb_Reclear_Adhesion.TabIndex = 179
        '
        'Test_Panel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1170, 442)
        Me.Controls.Add(Me.Lbl_Tag_Killed)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Btn_Connect)
        Me.Controls.Add(Me.Cmb_Serial_Ports)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_RFID)
        Me.Controls.Add(Me.Btn_Part_Info)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Name = "Test_Panel"
        Me.Text = "Test_Panel"
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Tag_Killed As Label
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Btn_Part_Info As Button
    Friend WithEvents DGV_Paint_Data As DataGridView
    Friend WithEvents Txt_RFID As TextBox
    Friend WithEvents Cmb_Serial_Ports As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Connect As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents Cmb_Location As ComboBox
    Friend WithEvents Txt_Tested_By As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Lbl_Double_Rub As Label
    Friend WithEvents Lbl_Color As Label
    Friend WithEvents Lbl_Adhesion As Label
    Friend WithEvents Btn_Save As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents Cmb_Reclear_Location As ComboBox
    Friend WithEvents Txt_Reclear_Tested_By As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Lbl_Reclear_Double_Rub As Label
    Friend WithEvents Lbl_Reclear_Color As Label
    Friend WithEvents Lbl_Reclear_Adhesion As Label
    Friend WithEvents Btn_Reclear_Save As Button
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Txt_M5_Gloss As TextBox
    Friend WithEvents Lbl_M5_Gloss As Label
    Friend WithEvents Lbl_M5_Hardness As Label
    Friend WithEvents Txt_M5_Orange_Peel As TextBox
    Friend WithEvents Lbl_M5_Orange_Peel As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Cmb_M5_Location As ComboBox
    Friend WithEvents Txt_M5_Tested_By As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Lbl_M5_Double_Rub2_GL As Label
    Friend WithEvents Txt_M5_Color As TextBox
    Friend WithEvents Lbl_M5_Color As Label
    Friend WithEvents Lbl_M5_Adhesion As Label
    Friend WithEvents Btn_M5_Save As Button
    Friend WithEvents Lbl_M5_Double_Rub2_PT As Label
    Friend WithEvents Cmb_M5_Adhesion As ComboBox
    Friend WithEvents Cmb_M5_Hardness As ComboBox
    Friend WithEvents Cmb_M5_Double_Rub2_PT As ComboBox
    Friend WithEvents Cmb_M5_Double_Rub2_GL As ComboBox
    Friend WithEvents Cmb_Adhesion As ComboBox
    Friend WithEvents Cmb_Color As ComboBox
    Friend WithEvents Cmb_Double_Rub As ComboBox
    Friend WithEvents Cmb_Reclear_Color As ComboBox
    Friend WithEvents Cmb_Reclear_Double_Rub As ComboBox
    Friend WithEvents Cmb_Reclear_Adhesion As ComboBox
End Class
