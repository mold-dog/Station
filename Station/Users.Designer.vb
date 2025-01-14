<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Users
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Users))
        Me.txt_Password = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Cmb_Description = New System.Windows.Forms.ComboBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Chk_View_Config = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_Edit_Config = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Chk_Access_Paint_Area = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Chk_Access_Targets = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Chk_User_Management = New System.Windows.Forms.CheckBox()
        Me.Txt_Username = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Access_Part_Tracking = New System.Windows.Forms.Label()
        Me.Chk_Access_Part_Tracking = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Chk_Access_Defects = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Chk_Access_Inspections = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Chk_Change_Robot_Parts = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Chk_Kill_Tag = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Chk_Access_Press_Area = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Chk_Operator_Management = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txt_Password
        '
        Me.txt_Password.Enabled = False
        Me.txt_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Password.Location = New System.Drawing.Point(153, 107)
        Me.txt_Password.Name = "txt_Password"
        Me.txt_Password.Size = New System.Drawing.Size(287, 23)
        Me.txt_Password.TabIndex = 4
        Me.txt_Password.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 17)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Password"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(266, 472)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 14
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(129, 472)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 13
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(332, 424)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 12
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(195, 424)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Edit.TabIndex = 11
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(63, 424)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 10
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(153, 23)
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Description.TabIndex = 2
        Me.Txt_Description.Visible = False
        '
        'Cmb_Description
        '
        Me.Cmb_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Description.FormattingEnabled = True
        Me.Cmb_Description.Location = New System.Drawing.Point(153, 23)
        Me.Cmb_Description.Name = "Cmb_Description"
        Me.Cmb_Description.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Description.TabIndex = 1
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(111, 26)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(38, 17)
        Me.Lbl_Area.TabIndex = 52
        Me.Lbl_Area.Text = "User"
        '
        'Chk_View_Config
        '
        Me.Chk_View_Config.AutoSize = True
        Me.Chk_View_Config.Enabled = False
        Me.Chk_View_Config.Location = New System.Drawing.Point(171, 165)
        Me.Chk_View_Config.Name = "Chk_View_Config"
        Me.Chk_View_Config.Size = New System.Drawing.Size(15, 14)
        Me.Chk_View_Config.TabIndex = 5
        Me.Chk_View_Config.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "View Config"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(91, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Edit Config"
        '
        'Chk_Edit_Config
        '
        Me.Chk_Edit_Config.AutoSize = True
        Me.Chk_Edit_Config.Enabled = False
        Me.Chk_Edit_Config.Location = New System.Drawing.Point(171, 201)
        Me.Chk_Edit_Config.Name = "Chk_Edit_Config"
        Me.Chk_Edit_Config.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Edit_Config.TabIndex = 6
        Me.Chk_Edit_Config.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 17)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Access Paint Area"
        '
        'Chk_Access_Paint_Area
        '
        Me.Chk_Access_Paint_Area.AutoSize = True
        Me.Chk_Access_Paint_Area.Enabled = False
        Me.Chk_Access_Paint_Area.Location = New System.Drawing.Point(438, 165)
        Me.Chk_Access_Paint_Area.Name = "Chk_Access_Paint_Area"
        Me.Chk_Access_Paint_Area.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Access_Paint_Area.TabIndex = 7
        Me.Chk_Access_Paint_Area.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(61, 270)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Access Targets"
        '
        'Chk_Access_Targets
        '
        Me.Chk_Access_Targets.AutoSize = True
        Me.Chk_Access_Targets.Enabled = False
        Me.Chk_Access_Targets.Location = New System.Drawing.Point(171, 273)
        Me.Chk_Access_Targets.Name = "Chk_Access_Targets"
        Me.Chk_Access_Targets.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Access_Targets.TabIndex = 8
        Me.Chk_Access_Targets.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 17)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "User Management"
        '
        'Chk_User_Management
        '
        Me.Chk_User_Management.AutoSize = True
        Me.Chk_User_Management.Enabled = False
        Me.Chk_User_Management.Location = New System.Drawing.Point(171, 233)
        Me.Chk_User_Management.Name = "Chk_User_Management"
        Me.Chk_User_Management.Size = New System.Drawing.Size(15, 14)
        Me.Chk_User_Management.TabIndex = 9
        Me.Chk_User_Management.UseVisualStyleBackColor = True
        '
        'Txt_Username
        '
        Me.Txt_Username.Enabled = False
        Me.Txt_Username.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Username.Location = New System.Drawing.Point(153, 65)
        Me.Txt_Username.Name = "Txt_Username"
        Me.Txt_Username.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Username.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(80, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 17)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Username"
        '
        'Access_Part_Tracking
        '
        Me.Access_Part_Tracking.AutoSize = True
        Me.Access_Part_Tracking.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Access_Part_Tracking.Location = New System.Drawing.Point(260, 198)
        Me.Access_Part_Tracking.Name = "Access_Part_Tracking"
        Me.Access_Part_Tracking.Size = New System.Drawing.Size(174, 17)
        Me.Access_Part_Tracking.TabIndex = 76
        Me.Access_Part_Tracking.Text = "Access Inventory Tracking"
        '
        'Chk_Access_Part_Tracking
        '
        Me.Chk_Access_Part_Tracking.AutoSize = True
        Me.Chk_Access_Part_Tracking.Enabled = False
        Me.Chk_Access_Part_Tracking.Location = New System.Drawing.Point(438, 201)
        Me.Chk_Access_Part_Tracking.Name = "Chk_Access_Part_Tracking"
        Me.Chk_Access_Part_Tracking.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Access_Part_Tracking.TabIndex = 75
        Me.Chk_Access_Part_Tracking.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(329, 234)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 17)
        Me.Label9.TabIndex = 78
        Me.Label9.Text = "Access Defects"
        '
        'Chk_Access_Defects
        '
        Me.Chk_Access_Defects.AutoSize = True
        Me.Chk_Access_Defects.Enabled = False
        Me.Chk_Access_Defects.Location = New System.Drawing.Point(438, 237)
        Me.Chk_Access_Defects.Name = "Chk_Access_Defects"
        Me.Chk_Access_Defects.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Access_Defects.TabIndex = 77
        Me.Chk_Access_Defects.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(306, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 17)
        Me.Label10.TabIndex = 80
        Me.Label10.Text = "Access Inspections"
        '
        'Chk_Access_Inspections
        '
        Me.Chk_Access_Inspections.AutoSize = True
        Me.Chk_Access_Inspections.Enabled = False
        Me.Chk_Access_Inspections.Location = New System.Drawing.Point(438, 273)
        Me.Chk_Access_Inspections.Name = "Chk_Access_Inspections"
        Me.Chk_Access_Inspections.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Access_Inspections.TabIndex = 79
        Me.Chk_Access_Inspections.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 308)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 17)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "Change Robot Parts"
        '
        'Chk_Change_Robot_Parts
        '
        Me.Chk_Change_Robot_Parts.AutoSize = True
        Me.Chk_Change_Robot_Parts.Enabled = False
        Me.Chk_Change_Robot_Parts.Location = New System.Drawing.Point(171, 311)
        Me.Chk_Change_Robot_Parts.Name = "Chk_Change_Robot_Parts"
        Me.Chk_Change_Robot_Parts.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Change_Robot_Parts.TabIndex = 81
        Me.Chk_Change_Robot_Parts.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(112, 380)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 17)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Kill Tag"
        '
        'Chk_Kill_Tag
        '
        Me.Chk_Kill_Tag.AutoSize = True
        Me.Chk_Kill_Tag.Enabled = False
        Me.Chk_Kill_Tag.Location = New System.Drawing.Point(171, 383)
        Me.Chk_Kill_Tag.Name = "Chk_Kill_Tag"
        Me.Chk_Kill_Tag.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Kill_Tag.TabIndex = 83
        Me.Chk_Kill_Tag.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(311, 308)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(127, 17)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "Access Press Area"
        '
        'Chk_Access_Press_Area
        '
        Me.Chk_Access_Press_Area.AutoSize = True
        Me.Chk_Access_Press_Area.Enabled = False
        Me.Chk_Access_Press_Area.Location = New System.Drawing.Point(438, 311)
        Me.Chk_Access_Press_Area.Name = "Chk_Access_Press_Area"
        Me.Chk_Access_Press_Area.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Access_Press_Area.TabIndex = 85
        Me.Chk_Access_Press_Area.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 346)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(151, 17)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "Operator Management"
        '
        'Chk_Operator_Management
        '
        Me.Chk_Operator_Management.AutoSize = True
        Me.Chk_Operator_Management.Enabled = False
        Me.Chk_Operator_Management.Location = New System.Drawing.Point(171, 347)
        Me.Chk_Operator_Management.Name = "Chk_Operator_Management"
        Me.Chk_Operator_Management.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Operator_Management.TabIndex = 87
        Me.Chk_Operator_Management.UseVisualStyleBackColor = True
        '
        'Users
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 526)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Chk_Operator_Management)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Chk_Access_Press_Area)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Chk_Kill_Tag)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Chk_Change_Robot_Parts)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Chk_Access_Inspections)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Chk_Access_Defects)
        Me.Controls.Add(Me.Access_Part_Tracking)
        Me.Controls.Add(Me.Chk_Access_Part_Tracking)
        Me.Controls.Add(Me.Txt_Username)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Chk_User_Management)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Chk_Access_Targets)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chk_Access_Paint_Area)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_Edit_Config)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Chk_View_Config)
        Me.Controls.Add(Me.txt_Password)
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
        Me.Name = "Users"
        Me.Text = "Users"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_Password As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Txt_Description As TextBox
    Friend WithEvents Cmb_Description As ComboBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Chk_View_Config As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Chk_Edit_Config As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Chk_Access_Paint_Area As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Chk_Access_Targets As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Chk_User_Management As CheckBox
    Friend WithEvents Txt_Username As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Access_Part_Tracking As Label
    Friend WithEvents Chk_Access_Part_Tracking As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Chk_Access_Defects As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Chk_Access_Inspections As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Chk_Change_Robot_Parts As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Chk_Kill_Tag As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Chk_Access_Press_Area As CheckBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Chk_Operator_Management As CheckBox
End Class
