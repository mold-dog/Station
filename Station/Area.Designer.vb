<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Area
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Area))
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Cmb_Area = New System.Windows.Forms.ComboBox()
        Me.Txt_Area = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LB_Sub_area = New System.Windows.Forms.ListBox()
        Me.Btn_Area_Add = New System.Windows.Forms.Button()
        Me.Btn_Area_Edit = New System.Windows.Forms.Button()
        Me.Btn_Area_Delete = New System.Windows.Forms.Button()
        Me.Btn_Sub_Area_Delete = New System.Windows.Forms.Button()
        Me.Btn_Sub_Area_Add = New System.Windows.Forms.Button()
        Me.Btn_Area_Save = New System.Windows.Forms.Button()
        Me.Btn_Area_Cancel = New System.Windows.Forms.Button()
        Me.Cmb_Sub_Area = New System.Windows.Forms.ComboBox()
        Me.Pnl_Sub_Area = New System.Windows.Forms.Panel()
        Me.Lbl_Add_Sub_Area_Title = New System.Windows.Forms.Label()
        Me.Lbl_Sub_Area = New System.Windows.Forms.Label()
        Me.Btn_Add_Sub_Area_Cancel = New System.Windows.Forms.Button()
        Me.btn_Add_Sub_Area_Confirm = New System.Windows.Forms.Button()
        Me.Opt_None = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Opt_Ship = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Opt_Scrap = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Opt_Exit = New System.Windows.Forms.RadioButton()
        Me.Chk_Targets = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Pnl_Sub_Area.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(63, 38)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(38, 17)
        Me.Lbl_Area.TabIndex = 0
        Me.Lbl_Area.Text = "Area"
        '
        'Cmb_Area
        '
        Me.Cmb_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Area.FormattingEnabled = True
        Me.Cmb_Area.Location = New System.Drawing.Point(121, 35)
        Me.Cmb_Area.Name = "Cmb_Area"
        Me.Cmb_Area.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Area.TabIndex = 1
        '
        'Txt_Area
        '
        Me.Txt_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Area.Location = New System.Drawing.Point(121, 35)
        Me.Txt_Area.Name = "Txt_Area"
        Me.Txt_Area.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Area.TabIndex = 2
        Me.Txt_Area.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(559, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sub-Areas"
        '
        'LB_Sub_area
        '
        Me.LB_Sub_area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Sub_area.FormattingEnabled = True
        Me.LB_Sub_area.ItemHeight = 16
        Me.LB_Sub_area.Location = New System.Drawing.Point(666, 32)
        Me.LB_Sub_area.Name = "LB_Sub_area"
        Me.LB_Sub_area.Size = New System.Drawing.Size(299, 276)
        Me.LB_Sub_area.TabIndex = 5
        '
        'Btn_Area_Add
        '
        Me.Btn_Area_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Area_Add.Location = New System.Drawing.Point(78, 233)
        Me.Btn_Area_Add.Name = "Btn_Area_Add"
        Me.Btn_Area_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Area_Add.TabIndex = 6
        Me.Btn_Area_Add.Text = "Add"
        Me.Btn_Area_Add.UseVisualStyleBackColor = True
        '
        'Btn_Area_Edit
        '
        Me.Btn_Area_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Area_Edit.Location = New System.Drawing.Point(210, 233)
        Me.Btn_Area_Edit.Name = "Btn_Area_Edit"
        Me.Btn_Area_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Area_Edit.TabIndex = 7
        Me.Btn_Area_Edit.Text = "Edit"
        Me.Btn_Area_Edit.UseVisualStyleBackColor = True
        Me.Btn_Area_Edit.Visible = False
        '
        'Btn_Area_Delete
        '
        Me.Btn_Area_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Area_Delete.Location = New System.Drawing.Point(347, 233)
        Me.Btn_Area_Delete.Name = "Btn_Area_Delete"
        Me.Btn_Area_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Area_Delete.TabIndex = 8
        Me.Btn_Area_Delete.Text = "Delete"
        Me.Btn_Area_Delete.UseVisualStyleBackColor = True
        Me.Btn_Area_Delete.Visible = False
        '
        'Btn_Sub_Area_Delete
        '
        Me.Btn_Sub_Area_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sub_Area_Delete.Location = New System.Drawing.Point(783, 344)
        Me.Btn_Sub_Area_Delete.Name = "Btn_Sub_Area_Delete"
        Me.Btn_Sub_Area_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Sub_Area_Delete.TabIndex = 10
        Me.Btn_Sub_Area_Delete.Text = "Delete"
        Me.Btn_Sub_Area_Delete.UseVisualStyleBackColor = True
        Me.Btn_Sub_Area_Delete.Visible = False
        '
        'Btn_Sub_Area_Add
        '
        Me.Btn_Sub_Area_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Sub_Area_Add.Location = New System.Drawing.Point(666, 344)
        Me.Btn_Sub_Area_Add.Name = "Btn_Sub_Area_Add"
        Me.Btn_Sub_Area_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Sub_Area_Add.TabIndex = 9
        Me.Btn_Sub_Area_Add.Text = "Add"
        Me.Btn_Sub_Area_Add.UseVisualStyleBackColor = True
        Me.Btn_Sub_Area_Add.Visible = False
        '
        'Btn_Area_Save
        '
        Me.Btn_Area_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Area_Save.Location = New System.Drawing.Point(144, 281)
        Me.Btn_Area_Save.Name = "Btn_Area_Save"
        Me.Btn_Area_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Area_Save.TabIndex = 11
        Me.Btn_Area_Save.Text = "Save"
        Me.Btn_Area_Save.UseVisualStyleBackColor = True
        Me.Btn_Area_Save.Visible = False
        '
        'Btn_Area_Cancel
        '
        Me.Btn_Area_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Area_Cancel.Location = New System.Drawing.Point(281, 281)
        Me.Btn_Area_Cancel.Name = "Btn_Area_Cancel"
        Me.Btn_Area_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Area_Cancel.TabIndex = 12
        Me.Btn_Area_Cancel.Text = "Cancel"
        Me.Btn_Area_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Area_Cancel.Visible = False
        '
        'Cmb_Sub_Area
        '
        Me.Cmb_Sub_Area.FormattingEnabled = True
        Me.Cmb_Sub_Area.Location = New System.Drawing.Point(98, 73)
        Me.Cmb_Sub_Area.Name = "Cmb_Sub_Area"
        Me.Cmb_Sub_Area.Size = New System.Drawing.Size(268, 21)
        Me.Cmb_Sub_Area.TabIndex = 13
        '
        'Pnl_Sub_Area
        '
        Me.Pnl_Sub_Area.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Sub_Area.Controls.Add(Me.Lbl_Add_Sub_Area_Title)
        Me.Pnl_Sub_Area.Controls.Add(Me.Lbl_Sub_Area)
        Me.Pnl_Sub_Area.Controls.Add(Me.Btn_Add_Sub_Area_Cancel)
        Me.Pnl_Sub_Area.Controls.Add(Me.btn_Add_Sub_Area_Confirm)
        Me.Pnl_Sub_Area.Controls.Add(Me.Cmb_Sub_Area)
        Me.Pnl_Sub_Area.Location = New System.Drawing.Point(373, 109)
        Me.Pnl_Sub_Area.Name = "Pnl_Sub_Area"
        Me.Pnl_Sub_Area.Size = New System.Drawing.Size(402, 185)
        Me.Pnl_Sub_Area.TabIndex = 14
        Me.Pnl_Sub_Area.Visible = False
        '
        'Lbl_Add_Sub_Area_Title
        '
        Me.Lbl_Add_Sub_Area_Title.AutoSize = True
        Me.Lbl_Add_Sub_Area_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Add_Sub_Area_Title.Location = New System.Drawing.Point(95, 25)
        Me.Lbl_Add_Sub_Area_Title.Name = "Lbl_Add_Sub_Area_Title"
        Me.Lbl_Add_Sub_Area_Title.Size = New System.Drawing.Size(231, 17)
        Me.Lbl_Add_Sub_Area_Title.TabIndex = 17
        Me.Lbl_Add_Sub_Area_Title.Text = "Select an Area to make a Sub-Area"
        Me.Lbl_Add_Sub_Area_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Sub_Area
        '
        Me.Lbl_Sub_Area.AutoSize = True
        Me.Lbl_Sub_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Area.Location = New System.Drawing.Point(10, 77)
        Me.Lbl_Sub_Area.Name = "Lbl_Sub_Area"
        Me.Lbl_Sub_Area.Size = New System.Drawing.Size(68, 17)
        Me.Lbl_Sub_Area.TabIndex = 16
        Me.Lbl_Sub_Area.Text = "Sub-Area"
        Me.Lbl_Sub_Area.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Btn_Add_Sub_Area_Cancel
        '
        Me.Btn_Add_Sub_Area_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add_Sub_Area_Cancel.Location = New System.Drawing.Point(224, 119)
        Me.Btn_Add_Sub_Area_Cancel.Name = "Btn_Add_Sub_Area_Cancel"
        Me.Btn_Add_Sub_Area_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add_Sub_Area_Cancel.TabIndex = 15
        Me.Btn_Add_Sub_Area_Cancel.Text = "Cancel"
        Me.Btn_Add_Sub_Area_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Add_Sub_Area_Confirm
        '
        Me.btn_Add_Sub_Area_Confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Add_Sub_Area_Confirm.Location = New System.Drawing.Point(65, 119)
        Me.btn_Add_Sub_Area_Confirm.Name = "btn_Add_Sub_Area_Confirm"
        Me.btn_Add_Sub_Area_Confirm.Size = New System.Drawing.Size(86, 30)
        Me.btn_Add_Sub_Area_Confirm.TabIndex = 15
        Me.btn_Add_Sub_Area_Confirm.Text = "Add"
        Me.btn_Add_Sub_Area_Confirm.UseVisualStyleBackColor = True
        '
        'Opt_None
        '
        Me.Opt_None.AutoSize = True
        Me.Opt_None.Enabled = False
        Me.Opt_None.Location = New System.Drawing.Point(121, 70)
        Me.Opt_None.Name = "Opt_None"
        Me.Opt_None.Size = New System.Drawing.Size(14, 13)
        Me.Opt_None.TabIndex = 15
        Me.Opt_None.TabStop = True
        Me.Opt_None.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Internal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Shipped"
        '
        'Opt_Ship
        '
        Me.Opt_Ship.AutoSize = True
        Me.Opt_Ship.Enabled = False
        Me.Opt_Ship.Location = New System.Drawing.Point(121, 100)
        Me.Opt_Ship.Name = "Opt_Ship"
        Me.Opt_Ship.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Ship.TabIndex = 17
        Me.Opt_Ship.TabStop = True
        Me.Opt_Ship.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Scrap"
        '
        'Opt_Scrap
        '
        Me.Opt_Scrap.AutoSize = True
        Me.Opt_Scrap.Enabled = False
        Me.Opt_Scrap.Location = New System.Drawing.Point(121, 130)
        Me.Opt_Scrap.Name = "Opt_Scrap"
        Me.Opt_Scrap.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Scrap.TabIndex = 19
        Me.Opt_Scrap.TabStop = True
        Me.Opt_Scrap.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(71, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 17)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Exit"
        '
        'Opt_Exit
        '
        Me.Opt_Exit.AutoSize = True
        Me.Opt_Exit.Enabled = False
        Me.Opt_Exit.Location = New System.Drawing.Point(121, 160)
        Me.Opt_Exit.Name = "Opt_Exit"
        Me.Opt_Exit.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Exit.TabIndex = 21
        Me.Opt_Exit.TabStop = True
        Me.Opt_Exit.UseVisualStyleBackColor = True
        '
        'Chk_Targets
        '
        Me.Chk_Targets.AutoSize = True
        Me.Chk_Targets.Enabled = False
        Me.Chk_Targets.Location = New System.Drawing.Point(121, 190)
        Me.Chk_Targets.Name = "Chk_Targets"
        Me.Chk_Targets.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Targets.TabIndex = 23
        Me.Chk_Targets.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Has Targets"
        '
        'Area
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 398)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Chk_Targets)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Opt_Exit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Opt_Scrap)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Opt_Ship)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Opt_None)
        Me.Controls.Add(Me.Pnl_Sub_Area)
        Me.Controls.Add(Me.Btn_Area_Cancel)
        Me.Controls.Add(Me.Btn_Area_Save)
        Me.Controls.Add(Me.Btn_Sub_Area_Delete)
        Me.Controls.Add(Me.Btn_Sub_Area_Add)
        Me.Controls.Add(Me.Btn_Area_Delete)
        Me.Controls.Add(Me.Btn_Area_Edit)
        Me.Controls.Add(Me.Btn_Area_Add)
        Me.Controls.Add(Me.LB_Sub_area)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Area)
        Me.Controls.Add(Me.Cmb_Area)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Area"
        Me.Text = "Area Management"
        Me.Pnl_Sub_Area.ResumeLayout(False)
        Me.Pnl_Sub_Area.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Cmb_Area As ComboBox
    Friend WithEvents Txt_Area As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LB_Sub_area As ListBox
    Friend WithEvents Btn_Area_Add As Button
    Friend WithEvents Btn_Area_Edit As Button
    Friend WithEvents Btn_Area_Delete As Button
    Friend WithEvents Btn_Sub_Area_Delete As Button
    Friend WithEvents Btn_Sub_Area_Add As Button
    Friend WithEvents Btn_Area_Save As Button
    Friend WithEvents Btn_Area_Cancel As Button
    Friend WithEvents Cmb_Sub_Area As ComboBox
    Friend WithEvents Pnl_Sub_Area As Panel
    Friend WithEvents Lbl_Sub_Area As Label
    Friend WithEvents Btn_Add_Sub_Area_Cancel As Button
    Friend WithEvents btn_Add_Sub_Area_Confirm As Button
    Friend WithEvents Lbl_Add_Sub_Area_Title As Label
    Friend WithEvents Opt_None As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Opt_Ship As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Opt_Scrap As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Opt_Exit As RadioButton
    Friend WithEvents Chk_Targets As CheckBox
    Friend WithEvents Label6 As Label
End Class
