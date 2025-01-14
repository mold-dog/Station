<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shifts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shifts))
        Me.DTP_Monday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTP_Monday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.txt_Area = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Cmb_Description = New System.Windows.Forms.ComboBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Cmb_Area = New System.Windows.Forms.ComboBox()
        Me.Txt_Shift = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cbx_Monday = New System.Windows.Forms.CheckBox()
        Me.Cbx_Tuesday = New System.Windows.Forms.CheckBox()
        Me.DTP_Tuesday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Tuesday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.Cbx_Wednesday = New System.Windows.Forms.CheckBox()
        Me.DTP_Wednesday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Wednesday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.Cbx_Thursday = New System.Windows.Forms.CheckBox()
        Me.DTP_Thursday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Thursday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.Cbx_Friday = New System.Windows.Forms.CheckBox()
        Me.DTP_Friday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Friday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.Cbx_Saturday = New System.Windows.Forms.CheckBox()
        Me.DTP_Saturday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Saturday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.Cbx_Sunday = New System.Windows.Forms.CheckBox()
        Me.DTP_Sunday_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Sunday_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'DTP_Monday_End_Time
        '
        Me.DTP_Monday_End_Time.Checked = False
        Me.DTP_Monday_End_Time.Enabled = False
        Me.DTP_Monday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Monday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Monday_End_Time.Location = New System.Drawing.Point(124, 220)
        Me.DTP_Monday_End_Time.Name = "DTP_Monday_End_Time"
        Me.DTP_Monday_End_Time.ShowUpDown = True
        Me.DTP_Monday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Monday_End_Time.TabIndex = 51
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(43, 181)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Start Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "End Time"
        '
        'DTP_Monday_Start_Time
        '
        Me.DTP_Monday_Start_Time.Enabled = False
        Me.DTP_Monday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Monday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Monday_Start_Time.Location = New System.Drawing.Point(124, 179)
        Me.DTP_Monday_Start_Time.Name = "DTP_Monday_Start_Time"
        Me.DTP_Monday_Start_Time.ShowUpDown = True
        Me.DTP_Monday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Monday_Start_Time.TabIndex = 50
        '
        'txt_Area
        '
        Me.txt_Area.Enabled = False
        Me.txt_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Area.Location = New System.Drawing.Point(471, 55)
        Me.txt_Area.MaxLength = 50
        Me.txt_Area.Name = "txt_Area"
        Me.txt_Area.Size = New System.Drawing.Size(175, 23)
        Me.txt_Area.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(425, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Area"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(568, 324)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 60
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(431, 324)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 59
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(634, 276)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 58
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(497, 276)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Edit.TabIndex = 57
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(365, 276)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 56
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(471, 14)
        Me.Txt_Description.MaxLength = 50
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(175, 23)
        Me.Txt_Description.TabIndex = 46
        Me.Txt_Description.Visible = False
        '
        'Cmb_Description
        '
        Me.Cmb_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Description.FormattingEnabled = True
        Me.Cmb_Description.Location = New System.Drawing.Point(471, 14)
        Me.Cmb_Description.Name = "Cmb_Description"
        Me.Cmb_Description.Size = New System.Drawing.Size(195, 24)
        Me.Cmb_Description.TabIndex = 45
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(384, 17)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(79, 17)
        Me.Lbl_Area.TabIndex = 61
        Me.Lbl_Area.Text = "Description"
        '
        'Cmb_Area
        '
        Me.Cmb_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Area.FormattingEnabled = True
        Me.Cmb_Area.Location = New System.Drawing.Point(471, 54)
        Me.Cmb_Area.Name = "Cmb_Area"
        Me.Cmb_Area.Size = New System.Drawing.Size(195, 24)
        Me.Cmb_Area.TabIndex = 67
        Me.Cmb_Area.Visible = False
        '
        'Txt_Shift
        '
        Me.Txt_Shift.Enabled = False
        Me.Txt_Shift.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Shift.Location = New System.Drawing.Point(471, 91)
        Me.Txt_Shift.MaxLength = 1
        Me.Txt_Shift.Name = "Txt_Shift"
        Me.Txt_Shift.Size = New System.Drawing.Size(61, 23)
        Me.Txt_Shift.TabIndex = 68
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(427, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 17)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Shift"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Day of Week"
        '
        'Cbx_Monday
        '
        Me.Cbx_Monday.AutoSize = True
        Me.Cbx_Monday.Location = New System.Drawing.Point(146, 137)
        Me.Cbx_Monday.Name = "Cbx_Monday"
        Me.Cbx_Monday.Size = New System.Drawing.Size(64, 17)
        Me.Cbx_Monday.TabIndex = 72
        Me.Cbx_Monday.Text = "Monday"
        Me.Cbx_Monday.UseVisualStyleBackColor = True
        '
        'Cbx_Tuesday
        '
        Me.Cbx_Tuesday.AutoSize = True
        Me.Cbx_Tuesday.Location = New System.Drawing.Point(280, 137)
        Me.Cbx_Tuesday.Name = "Cbx_Tuesday"
        Me.Cbx_Tuesday.Size = New System.Drawing.Size(67, 17)
        Me.Cbx_Tuesday.TabIndex = 75
        Me.Cbx_Tuesday.Text = "Tuesday"
        Me.Cbx_Tuesday.UseVisualStyleBackColor = True
        '
        'DTP_Tuesday_End_Time
        '
        Me.DTP_Tuesday_End_Time.Checked = False
        Me.DTP_Tuesday_End_Time.Enabled = False
        Me.DTP_Tuesday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Tuesday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Tuesday_End_Time.Location = New System.Drawing.Point(258, 220)
        Me.DTP_Tuesday_End_Time.Name = "DTP_Tuesday_End_Time"
        Me.DTP_Tuesday_End_Time.ShowUpDown = True
        Me.DTP_Tuesday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Tuesday_End_Time.TabIndex = 74
        '
        'DTP_Tuesday_Start_Time
        '
        Me.DTP_Tuesday_Start_Time.Enabled = False
        Me.DTP_Tuesday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Tuesday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Tuesday_Start_Time.Location = New System.Drawing.Point(258, 179)
        Me.DTP_Tuesday_Start_Time.Name = "DTP_Tuesday_Start_Time"
        Me.DTP_Tuesday_Start_Time.ShowUpDown = True
        Me.DTP_Tuesday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Tuesday_Start_Time.TabIndex = 73
        '
        'Cbx_Wednesday
        '
        Me.Cbx_Wednesday.AutoSize = True
        Me.Cbx_Wednesday.Location = New System.Drawing.Point(422, 137)
        Me.Cbx_Wednesday.Name = "Cbx_Wednesday"
        Me.Cbx_Wednesday.Size = New System.Drawing.Size(83, 17)
        Me.Cbx_Wednesday.TabIndex = 78
        Me.Cbx_Wednesday.Text = "Wednesday"
        Me.Cbx_Wednesday.UseVisualStyleBackColor = True
        '
        'DTP_Wednesday_End_Time
        '
        Me.DTP_Wednesday_End_Time.Checked = False
        Me.DTP_Wednesday_End_Time.Enabled = False
        Me.DTP_Wednesday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Wednesday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Wednesday_End_Time.Location = New System.Drawing.Point(400, 220)
        Me.DTP_Wednesday_End_Time.Name = "DTP_Wednesday_End_Time"
        Me.DTP_Wednesday_End_Time.ShowUpDown = True
        Me.DTP_Wednesday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Wednesday_End_Time.TabIndex = 77
        '
        'DTP_Wednesday_Start_Time
        '
        Me.DTP_Wednesday_Start_Time.Enabled = False
        Me.DTP_Wednesday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Wednesday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Wednesday_Start_Time.Location = New System.Drawing.Point(400, 179)
        Me.DTP_Wednesday_Start_Time.Name = "DTP_Wednesday_Start_Time"
        Me.DTP_Wednesday_Start_Time.ShowUpDown = True
        Me.DTP_Wednesday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Wednesday_Start_Time.TabIndex = 76
        '
        'Cbx_Thursday
        '
        Me.Cbx_Thursday.AutoSize = True
        Me.Cbx_Thursday.Location = New System.Drawing.Point(558, 137)
        Me.Cbx_Thursday.Name = "Cbx_Thursday"
        Me.Cbx_Thursday.Size = New System.Drawing.Size(70, 17)
        Me.Cbx_Thursday.TabIndex = 81
        Me.Cbx_Thursday.Text = "Thursday"
        Me.Cbx_Thursday.UseVisualStyleBackColor = True
        '
        'DTP_Thursday_End_Time
        '
        Me.DTP_Thursday_End_Time.Checked = False
        Me.DTP_Thursday_End_Time.Enabled = False
        Me.DTP_Thursday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Thursday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Thursday_End_Time.Location = New System.Drawing.Point(536, 220)
        Me.DTP_Thursday_End_Time.Name = "DTP_Thursday_End_Time"
        Me.DTP_Thursday_End_Time.ShowUpDown = True
        Me.DTP_Thursday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Thursday_End_Time.TabIndex = 80
        '
        'DTP_Thursday_Start_Time
        '
        Me.DTP_Thursday_Start_Time.Enabled = False
        Me.DTP_Thursday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Thursday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Thursday_Start_Time.Location = New System.Drawing.Point(536, 179)
        Me.DTP_Thursday_Start_Time.Name = "DTP_Thursday_Start_Time"
        Me.DTP_Thursday_Start_Time.ShowUpDown = True
        Me.DTP_Thursday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Thursday_Start_Time.TabIndex = 79
        '
        'Cbx_Friday
        '
        Me.Cbx_Friday.AutoSize = True
        Me.Cbx_Friday.Location = New System.Drawing.Point(693, 137)
        Me.Cbx_Friday.Name = "Cbx_Friday"
        Me.Cbx_Friday.Size = New System.Drawing.Size(54, 17)
        Me.Cbx_Friday.TabIndex = 84
        Me.Cbx_Friday.Text = "Friday"
        Me.Cbx_Friday.UseVisualStyleBackColor = True
        '
        'DTP_Friday_End_Time
        '
        Me.DTP_Friday_End_Time.Checked = False
        Me.DTP_Friday_End_Time.Enabled = False
        Me.DTP_Friday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Friday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Friday_End_Time.Location = New System.Drawing.Point(671, 220)
        Me.DTP_Friday_End_Time.Name = "DTP_Friday_End_Time"
        Me.DTP_Friday_End_Time.ShowUpDown = True
        Me.DTP_Friday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Friday_End_Time.TabIndex = 83
        '
        'DTP_Friday_Start_Time
        '
        Me.DTP_Friday_Start_Time.Enabled = False
        Me.DTP_Friday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Friday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Friday_Start_Time.Location = New System.Drawing.Point(671, 179)
        Me.DTP_Friday_Start_Time.Name = "DTP_Friday_Start_Time"
        Me.DTP_Friday_Start_Time.ShowUpDown = True
        Me.DTP_Friday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Friday_Start_Time.TabIndex = 82
        '
        'Cbx_Saturday
        '
        Me.Cbx_Saturday.AutoSize = True
        Me.Cbx_Saturday.Location = New System.Drawing.Point(832, 137)
        Me.Cbx_Saturday.Name = "Cbx_Saturday"
        Me.Cbx_Saturday.Size = New System.Drawing.Size(68, 17)
        Me.Cbx_Saturday.TabIndex = 87
        Me.Cbx_Saturday.Text = "Saturday"
        Me.Cbx_Saturday.UseVisualStyleBackColor = True
        '
        'DTP_Saturday_End_Time
        '
        Me.DTP_Saturday_End_Time.Checked = False
        Me.DTP_Saturday_End_Time.Enabled = False
        Me.DTP_Saturday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Saturday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Saturday_End_Time.Location = New System.Drawing.Point(810, 220)
        Me.DTP_Saturday_End_Time.Name = "DTP_Saturday_End_Time"
        Me.DTP_Saturday_End_Time.ShowUpDown = True
        Me.DTP_Saturday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Saturday_End_Time.TabIndex = 86
        '
        'DTP_Saturday_Start_Time
        '
        Me.DTP_Saturday_Start_Time.Enabled = False
        Me.DTP_Saturday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Saturday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Saturday_Start_Time.Location = New System.Drawing.Point(810, 179)
        Me.DTP_Saturday_Start_Time.Name = "DTP_Saturday_Start_Time"
        Me.DTP_Saturday_Start_Time.ShowUpDown = True
        Me.DTP_Saturday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Saturday_Start_Time.TabIndex = 85
        '
        'Cbx_Sunday
        '
        Me.Cbx_Sunday.AutoSize = True
        Me.Cbx_Sunday.Location = New System.Drawing.Point(972, 137)
        Me.Cbx_Sunday.Name = "Cbx_Sunday"
        Me.Cbx_Sunday.Size = New System.Drawing.Size(62, 17)
        Me.Cbx_Sunday.TabIndex = 90
        Me.Cbx_Sunday.Text = "Sunday"
        Me.Cbx_Sunday.UseVisualStyleBackColor = True
        '
        'DTP_Sunday_End_Time
        '
        Me.DTP_Sunday_End_Time.Checked = False
        Me.DTP_Sunday_End_Time.Enabled = False
        Me.DTP_Sunday_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Sunday_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Sunday_End_Time.Location = New System.Drawing.Point(950, 220)
        Me.DTP_Sunday_End_Time.Name = "DTP_Sunday_End_Time"
        Me.DTP_Sunday_End_Time.ShowUpDown = True
        Me.DTP_Sunday_End_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Sunday_End_Time.TabIndex = 89
        '
        'DTP_Sunday_Start_Time
        '
        Me.DTP_Sunday_Start_Time.Enabled = False
        Me.DTP_Sunday_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Sunday_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Sunday_Start_Time.Location = New System.Drawing.Point(950, 179)
        Me.DTP_Sunday_Start_Time.Name = "DTP_Sunday_Start_Time"
        Me.DTP_Sunday_Start_Time.ShowUpDown = True
        Me.DTP_Sunday_Start_Time.Size = New System.Drawing.Size(119, 23)
        Me.DTP_Sunday_Start_Time.TabIndex = 88
        '
        'Shifts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 381)
        Me.Controls.Add(Me.Cbx_Sunday)
        Me.Controls.Add(Me.DTP_Sunday_End_Time)
        Me.Controls.Add(Me.DTP_Sunday_Start_Time)
        Me.Controls.Add(Me.Cbx_Saturday)
        Me.Controls.Add(Me.DTP_Saturday_End_Time)
        Me.Controls.Add(Me.DTP_Saturday_Start_Time)
        Me.Controls.Add(Me.Cbx_Friday)
        Me.Controls.Add(Me.DTP_Friday_End_Time)
        Me.Controls.Add(Me.DTP_Friday_Start_Time)
        Me.Controls.Add(Me.Cbx_Thursday)
        Me.Controls.Add(Me.DTP_Thursday_End_Time)
        Me.Controls.Add(Me.DTP_Thursday_Start_Time)
        Me.Controls.Add(Me.Cbx_Wednesday)
        Me.Controls.Add(Me.DTP_Wednesday_End_Time)
        Me.Controls.Add(Me.DTP_Wednesday_Start_Time)
        Me.Controls.Add(Me.Cbx_Tuesday)
        Me.Controls.Add(Me.DTP_Tuesday_End_Time)
        Me.Controls.Add(Me.DTP_Tuesday_Start_Time)
        Me.Controls.Add(Me.Cbx_Monday)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Shift)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTP_Monday_End_Time)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DTP_Monday_Start_Time)
        Me.Controls.Add(Me.txt_Area)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Edit)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.Txt_Description)
        Me.Controls.Add(Me.Cmb_Description)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Controls.Add(Me.Cmb_Area)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Shifts"
        Me.Text = "Shifts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTP_Monday_End_Time As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DTP_Monday_Start_Time As DateTimePicker
    Friend WithEvents txt_Area As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Txt_Description As TextBox
    Friend WithEvents Cmb_Description As ComboBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Cmb_Area As ComboBox
    Friend WithEvents Txt_Shift As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Cbx_Monday As CheckBox
    Friend WithEvents Cbx_Tuesday As CheckBox
    Friend WithEvents DTP_Tuesday_End_Time As DateTimePicker
    Friend WithEvents DTP_Tuesday_Start_Time As DateTimePicker
    Friend WithEvents Cbx_Wednesday As CheckBox
    Friend WithEvents DTP_Wednesday_End_Time As DateTimePicker
    Friend WithEvents DTP_Wednesday_Start_Time As DateTimePicker
    Friend WithEvents Cbx_Thursday As CheckBox
    Friend WithEvents DTP_Thursday_End_Time As DateTimePicker
    Friend WithEvents DTP_Thursday_Start_Time As DateTimePicker
    Friend WithEvents Cbx_Friday As CheckBox
    Friend WithEvents DTP_Friday_End_Time As DateTimePicker
    Friend WithEvents DTP_Friday_Start_Time As DateTimePicker
    Friend WithEvents Cbx_Saturday As CheckBox
    Friend WithEvents DTP_Saturday_End_Time As DateTimePicker
    Friend WithEvents DTP_Saturday_Start_Time As DateTimePicker
    Friend WithEvents Cbx_Sunday As CheckBox
    Friend WithEvents DTP_Sunday_End_Time As DateTimePicker
    Friend WithEvents DTP_Sunday_Start_Time As DateTimePicker
End Class
