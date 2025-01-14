<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Robot_Parts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Robot_Parts))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Opt_Air_Cap = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Opt_Spray_Head = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Opt_Bell = New System.Windows.Forms.RadioButton()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Cmb_Description = New System.Windows.Forms.ComboBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Chk_Base = New System.Windows.Forms.CheckBox()
        Me.Chk_Clear = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Chk_In_Service = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Opt_Retaining_Ring = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(55, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Air Cap"
        '
        'Opt_Air_Cap
        '
        Me.Opt_Air_Cap.AutoSize = True
        Me.Opt_Air_Cap.Enabled = False
        Me.Opt_Air_Cap.Location = New System.Drawing.Point(129, 121)
        Me.Opt_Air_Cap.Name = "Opt_Air_Cap"
        Me.Opt_Air_Cap.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Air_Cap.TabIndex = 37
        Me.Opt_Air_Cap.TabStop = True
        Me.Opt_Air_Cap.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 17)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Spray Head"
        '
        'Opt_Spray_Head
        '
        Me.Opt_Spray_Head.AutoSize = True
        Me.Opt_Spray_Head.Enabled = False
        Me.Opt_Spray_Head.Location = New System.Drawing.Point(129, 91)
        Me.Opt_Spray_Head.Name = "Opt_Spray_Head"
        Me.Opt_Spray_Head.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Spray_Head.TabIndex = 35
        Me.Opt_Spray_Head.TabStop = True
        Me.Opt_Spray_Head.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 17)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Gun/Bell"
        '
        'Opt_Bell
        '
        Me.Opt_Bell.AutoSize = True
        Me.Opt_Bell.Enabled = False
        Me.Opt_Bell.Location = New System.Drawing.Point(129, 61)
        Me.Opt_Bell.Name = "Opt_Bell"
        Me.Opt_Bell.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Bell.TabIndex = 33
        Me.Opt_Bell.TabStop = True
        Me.Opt_Bell.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(273, 280)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 32
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(136, 280)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 31
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(339, 232)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 30
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(202, 232)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Edit.TabIndex = 29
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(70, 232)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 28
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(129, 26)
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Description.TabIndex = 27
        Me.Txt_Description.Visible = False
        '
        'Cmb_Description
        '
        Me.Cmb_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Description.FormattingEnabled = True
        Me.Cmb_Description.Location = New System.Drawing.Point(129, 26)
        Me.Cmb_Description.Name = "Cmb_Description"
        Me.Cmb_Description.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Description.TabIndex = 26
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(30, 29)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(79, 17)
        Me.Lbl_Area.TabIndex = 25
        Me.Lbl_Area.Text = "Description"
        '
        'Chk_Base
        '
        Me.Chk_Base.AutoSize = True
        Me.Chk_Base.Enabled = False
        Me.Chk_Base.Location = New System.Drawing.Point(401, 92)
        Me.Chk_Base.Name = "Chk_Base"
        Me.Chk_Base.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Base.TabIndex = 39
        Me.Chk_Base.UseVisualStyleBackColor = True
        '
        'Chk_Clear
        '
        Me.Chk_Clear.AutoSize = True
        Me.Chk_Clear.Enabled = False
        Me.Chk_Clear.Location = New System.Drawing.Point(401, 122)
        Me.Chk_Clear.Name = "Chk_Clear"
        Me.Chk_Clear.Size = New System.Drawing.Size(15, 14)
        Me.Chk_Clear.TabIndex = 40
        Me.Chk_Clear.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(298, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Base Robot"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(297, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 17)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Clear Robot"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(322, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 17)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Part Used On"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 17)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "In Service"
        '
        'Chk_In_Service
        '
        Me.Chk_In_Service.AutoSize = True
        Me.Chk_In_Service.Enabled = False
        Me.Chk_In_Service.Location = New System.Drawing.Point(128, 193)
        Me.Chk_In_Service.Name = "Chk_In_Service"
        Me.Chk_In_Service.Size = New System.Drawing.Size(15, 14)
        Me.Chk_In_Service.TabIndex = 44
        Me.Chk_In_Service.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 150)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 17)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Retaining Ring"
        '
        'Opt_Retaining_Ring
        '
        Me.Opt_Retaining_Ring.AutoSize = True
        Me.Opt_Retaining_Ring.Enabled = False
        Me.Opt_Retaining_Ring.Location = New System.Drawing.Point(129, 152)
        Me.Opt_Retaining_Ring.Name = "Opt_Retaining_Ring"
        Me.Opt_Retaining_Ring.Size = New System.Drawing.Size(14, 13)
        Me.Opt_Retaining_Ring.TabIndex = 46
        Me.Opt_Retaining_Ring.TabStop = True
        Me.Opt_Retaining_Ring.UseVisualStyleBackColor = True
        '
        'Robot_Parts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 335)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Opt_Retaining_Ring)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Chk_In_Service)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Chk_Clear)
        Me.Controls.Add(Me.Chk_Base)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Opt_Air_Cap)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Opt_Spray_Head)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Opt_Bell)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Edit)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.Txt_Description)
        Me.Controls.Add(Me.Cmb_Description)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Robot_Parts"
        Me.Text = "Robot Parts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Opt_Air_Cap As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Opt_Spray_Head As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Opt_Bell As RadioButton
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Txt_Description As TextBox
    Friend WithEvents Cmb_Description As ComboBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Chk_Base As CheckBox
    Friend WithEvents Chk_Clear As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Chk_In_Service As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Opt_Retaining_Ring As RadioButton
End Class
