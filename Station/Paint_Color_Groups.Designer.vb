<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Paint_Color_Groups
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
        Me.Lbl_Add_Sub_Area_Title = New System.Windows.Forms.Label()
        Me.Lbl_Sub_Area = New System.Windows.Forms.Label()
        Me.Btn_Add_Recipe_Cancel = New System.Windows.Forms.Button()
        Me.Cmb_Recipe = New System.Windows.Forms.ComboBox()
        Me.Pnl_Recipe = New System.Windows.Forms.Panel()
        Me.btn_Add_Recipe_Confirm = New System.Windows.Forms.Button()
        Me.Btn_Recipe_Delete = New System.Windows.Forms.Button()
        Me.Btn_Recipe_Add = New System.Windows.Forms.Button()
        Me.LB_Recipe = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Cmb_Description = New System.Windows.Forms.ComboBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pnl_Recipe.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lbl_Add_Sub_Area_Title
        '
        Me.Lbl_Add_Sub_Area_Title.AutoSize = True
        Me.Lbl_Add_Sub_Area_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Add_Sub_Area_Title.Location = New System.Drawing.Point(95, 25)
        Me.Lbl_Add_Sub_Area_Title.Name = "Lbl_Add_Sub_Area_Title"
        Me.Lbl_Add_Sub_Area_Title.Size = New System.Drawing.Size(264, 17)
        Me.Lbl_Add_Sub_Area_Title.TabIndex = 17
        Me.Lbl_Add_Sub_Area_Title.Text = "Select a Paint Color to add to the Recipe"
        Me.Lbl_Add_Sub_Area_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Sub_Area
        '
        Me.Lbl_Sub_Area.AutoSize = True
        Me.Lbl_Sub_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Area.Location = New System.Drawing.Point(10, 77)
        Me.Lbl_Sub_Area.Name = "Lbl_Sub_Area"
        Me.Lbl_Sub_Area.Size = New System.Drawing.Size(77, 17)
        Me.Lbl_Sub_Area.TabIndex = 16
        Me.Lbl_Sub_Area.Text = "Paint Color"
        Me.Lbl_Sub_Area.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Btn_Add_Recipe_Cancel
        '
        Me.Btn_Add_Recipe_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add_Recipe_Cancel.Location = New System.Drawing.Point(224, 119)
        Me.Btn_Add_Recipe_Cancel.Name = "Btn_Add_Recipe_Cancel"
        Me.Btn_Add_Recipe_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add_Recipe_Cancel.TabIndex = 22
        Me.Btn_Add_Recipe_Cancel.Text = "Cancel"
        Me.Btn_Add_Recipe_Cancel.UseVisualStyleBackColor = True
        '
        'Cmb_Recipe
        '
        Me.Cmb_Recipe.FormattingEnabled = True
        Me.Cmb_Recipe.Location = New System.Drawing.Point(98, 73)
        Me.Cmb_Recipe.Name = "Cmb_Recipe"
        Me.Cmb_Recipe.Size = New System.Drawing.Size(268, 21)
        Me.Cmb_Recipe.TabIndex = 20
        '
        'Pnl_Recipe
        '
        Me.Pnl_Recipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Recipe.Controls.Add(Me.Lbl_Add_Sub_Area_Title)
        Me.Pnl_Recipe.Controls.Add(Me.Lbl_Sub_Area)
        Me.Pnl_Recipe.Controls.Add(Me.Btn_Add_Recipe_Cancel)
        Me.Pnl_Recipe.Controls.Add(Me.btn_Add_Recipe_Confirm)
        Me.Pnl_Recipe.Controls.Add(Me.Cmb_Recipe)
        Me.Pnl_Recipe.Location = New System.Drawing.Point(256, 131)
        Me.Pnl_Recipe.Name = "Pnl_Recipe"
        Me.Pnl_Recipe.Size = New System.Drawing.Size(402, 185)
        Me.Pnl_Recipe.TabIndex = 91
        Me.Pnl_Recipe.Visible = False
        '
        'btn_Add_Recipe_Confirm
        '
        Me.btn_Add_Recipe_Confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Add_Recipe_Confirm.Location = New System.Drawing.Point(65, 119)
        Me.btn_Add_Recipe_Confirm.Name = "btn_Add_Recipe_Confirm"
        Me.btn_Add_Recipe_Confirm.Size = New System.Drawing.Size(86, 30)
        Me.btn_Add_Recipe_Confirm.TabIndex = 21
        Me.btn_Add_Recipe_Confirm.Text = "Add"
        Me.btn_Add_Recipe_Confirm.UseVisualStyleBackColor = True
        '
        'Btn_Recipe_Delete
        '
        Me.Btn_Recipe_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Recipe_Delete.Location = New System.Drawing.Point(760, 226)
        Me.Btn_Recipe_Delete.Name = "Btn_Recipe_Delete"
        Me.Btn_Recipe_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Recipe_Delete.TabIndex = 84
        Me.Btn_Recipe_Delete.Text = "Delete"
        Me.Btn_Recipe_Delete.UseVisualStyleBackColor = True
        Me.Btn_Recipe_Delete.Visible = False
        '
        'Btn_Recipe_Add
        '
        Me.Btn_Recipe_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Recipe_Add.Location = New System.Drawing.Point(631, 226)
        Me.Btn_Recipe_Add.Name = "Btn_Recipe_Add"
        Me.Btn_Recipe_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Recipe_Add.TabIndex = 83
        Me.Btn_Recipe_Add.Text = "Add"
        Me.Btn_Recipe_Add.UseVisualStyleBackColor = True
        Me.Btn_Recipe_Add.Visible = False
        '
        'LB_Recipe
        '
        Me.LB_Recipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_Recipe.FormattingEnabled = True
        Me.LB_Recipe.ItemHeight = 16
        Me.LB_Recipe.Location = New System.Drawing.Point(591, 90)
        Me.LB_Recipe.Name = "LB_Recipe"
        Me.LB_Recipe.Size = New System.Drawing.Size(299, 116)
        Me.LB_Recipe.TabIndex = 82
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(516, 90)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Recipe"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(238, 352)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 81
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(101, 352)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 80
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(304, 304)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 79
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(35, 304)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 77
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(113, 87)
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Description.TabIndex = 71
        Me.Txt_Description.Visible = False
        '
        'Cmb_Description
        '
        Me.Cmb_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Description.FormattingEnabled = True
        Me.Cmb_Description.Location = New System.Drawing.Point(113, 87)
        Me.Cmb_Description.Name = "Cmb_Description"
        Me.Cmb_Description.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Description.TabIndex = 72
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(22, 90)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(85, 17)
        Me.Lbl_Area.TabIndex = 85
        Me.Lbl_Area.Text = "Color Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(374, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Paint Color Groups"
        '
        'Paint_Color_Groups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 414)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pnl_Recipe)
        Me.Controls.Add(Me.Btn_Recipe_Delete)
        Me.Controls.Add(Me.Btn_Recipe_Add)
        Me.Controls.Add(Me.LB_Recipe)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.Txt_Description)
        Me.Controls.Add(Me.Cmb_Description)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Name = "Paint_Color_Groups"
        Me.Text = "Paint_Color_Groups"
        Me.Pnl_Recipe.ResumeLayout(False)
        Me.Pnl_Recipe.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_Add_Sub_Area_Title As Label
    Friend WithEvents Lbl_Sub_Area As Label
    Friend WithEvents Btn_Add_Recipe_Cancel As Button
    Friend WithEvents Cmb_Recipe As ComboBox
    Friend WithEvents Pnl_Recipe As Panel
    Friend WithEvents btn_Add_Recipe_Confirm As Button
    Friend WithEvents Btn_Recipe_Delete As Button
    Friend WithEvents Btn_Recipe_Add As Button
    Friend WithEvents LB_Recipe As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Txt_Description As TextBox
    Friend WithEvents Cmb_Description As ComboBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Label1 As Label
End Class
