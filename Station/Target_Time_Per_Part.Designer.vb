<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Target_Time_Per_Part
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Target_Time_Per_Part))
        Me.Pnl_Recipe = New System.Windows.Forms.Panel()
        Me.Txt_Quantity = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Add_Sub_Area_Title = New System.Windows.Forms.Label()
        Me.Lbl_Sub_Area = New System.Windows.Forms.Label()
        Me.Btn_Add_Recipe_Cancel = New System.Windows.Forms.Button()
        Me.btn_Add_Recipe_Confirm = New System.Windows.Forms.Button()
        Me.Cmb_Part_Type = New System.Windows.Forms.ComboBox()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.DGV_Paint_Data = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_Area = New System.Windows.Forms.ComboBox()
        Me.Pnl_Recipe.SuspendLayout()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl_Recipe
        '
        Me.Pnl_Recipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pnl_Recipe.Controls.Add(Me.Txt_Quantity)
        Me.Pnl_Recipe.Controls.Add(Me.Label4)
        Me.Pnl_Recipe.Controls.Add(Me.Lbl_Add_Sub_Area_Title)
        Me.Pnl_Recipe.Controls.Add(Me.Lbl_Sub_Area)
        Me.Pnl_Recipe.Controls.Add(Me.Btn_Add_Recipe_Cancel)
        Me.Pnl_Recipe.Controls.Add(Me.btn_Add_Recipe_Confirm)
        Me.Pnl_Recipe.Controls.Add(Me.Cmb_Part_Type)
        Me.Pnl_Recipe.Location = New System.Drawing.Point(39, 218)
        Me.Pnl_Recipe.Name = "Pnl_Recipe"
        Me.Pnl_Recipe.Size = New System.Drawing.Size(402, 169)
        Me.Pnl_Recipe.TabIndex = 79
        Me.Pnl_Recipe.Visible = False
        '
        'Txt_Quantity
        '
        Me.Txt_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Quantity.Location = New System.Drawing.Point(98, 82)
        Me.Txt_Quantity.Name = "Txt_Quantity"
        Me.Txt_Quantity.Size = New System.Drawing.Size(100, 23)
        Me.Txt_Quantity.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Minutes"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Add_Sub_Area_Title
        '
        Me.Lbl_Add_Sub_Area_Title.AutoSize = True
        Me.Lbl_Add_Sub_Area_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Add_Sub_Area_Title.Location = New System.Drawing.Point(125, 16)
        Me.Lbl_Add_Sub_Area_Title.Name = "Lbl_Add_Sub_Area_Title"
        Me.Lbl_Add_Sub_Area_Title.Size = New System.Drawing.Size(112, 17)
        Me.Lbl_Add_Sub_Area_Title.TabIndex = 17
        Me.Lbl_Add_Sub_Area_Title.Text = "Minutes per Part"
        Me.Lbl_Add_Sub_Area_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Sub_Area
        '
        Me.Lbl_Sub_Area.AutoSize = True
        Me.Lbl_Sub_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Area.Location = New System.Drawing.Point(17, 54)
        Me.Lbl_Sub_Area.Name = "Lbl_Sub_Area"
        Me.Lbl_Sub_Area.Size = New System.Drawing.Size(70, 17)
        Me.Lbl_Sub_Area.TabIndex = 16
        Me.Lbl_Sub_Area.Text = "Part Type"
        Me.Lbl_Sub_Area.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Btn_Add_Recipe_Cancel
        '
        Me.Btn_Add_Recipe_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add_Recipe_Cancel.Location = New System.Drawing.Point(224, 123)
        Me.Btn_Add_Recipe_Cancel.Name = "Btn_Add_Recipe_Cancel"
        Me.Btn_Add_Recipe_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add_Recipe_Cancel.TabIndex = 22
        Me.Btn_Add_Recipe_Cancel.Text = "Cancel"
        Me.Btn_Add_Recipe_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Add_Recipe_Confirm
        '
        Me.btn_Add_Recipe_Confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Add_Recipe_Confirm.Location = New System.Drawing.Point(65, 123)
        Me.btn_Add_Recipe_Confirm.Name = "btn_Add_Recipe_Confirm"
        Me.btn_Add_Recipe_Confirm.Size = New System.Drawing.Size(86, 30)
        Me.btn_Add_Recipe_Confirm.TabIndex = 21
        Me.btn_Add_Recipe_Confirm.Text = "Add"
        Me.btn_Add_Recipe_Confirm.UseVisualStyleBackColor = True
        '
        'Cmb_Part_Type
        '
        Me.Cmb_Part_Type.FormattingEnabled = True
        Me.Cmb_Part_Type.Location = New System.Drawing.Point(98, 50)
        Me.Cmb_Part_Type.Name = "Cmb_Part_Type"
        Me.Cmb_Part_Type.Size = New System.Drawing.Size(268, 21)
        Me.Cmb_Part_Type.TabIndex = 20
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(131, 628)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Delete.TabIndex = 78
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(12, 628)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Add.TabIndex = 77
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        Me.Btn_Add.Visible = False
        '
        'DGV_Paint_Data
        '
        Me.DGV_Paint_Data.AllowUserToAddRows = False
        Me.DGV_Paint_Data.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Paint_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Paint_Data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column1, Me.Column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Paint_Data.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(12, 55)
        Me.DGV_Paint_Data.Name = "DGV_Paint_Data"
        Me.DGV_Paint_Data.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(463, 556)
        Me.DGV_Paint_Data.TabIndex = 76
        '
        'Column4
        '
        Me.Column4.HeaderText = "ID"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Part Type"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 250
        '
        'Column3
        '
        Me.Column3.HeaderText = "Minutes"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Area"
        '
        'Cmb_Area
        '
        Me.Cmb_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Area.FormattingEnabled = True
        Me.Cmb_Area.Location = New System.Drawing.Point(118, 13)
        Me.Cmb_Area.Name = "Cmb_Area"
        Me.Cmb_Area.Size = New System.Drawing.Size(276, 24)
        Me.Cmb_Area.TabIndex = 72
        '
        'Target_Time_Per_Part
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 673)
        Me.Controls.Add(Me.Pnl_Recipe)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmb_Area)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Target_Time_Per_Part"
        Me.Text = "Target Time Per Part"
        Me.Pnl_Recipe.ResumeLayout(False)
        Me.Pnl_Recipe.PerformLayout()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pnl_Recipe As Panel
    Friend WithEvents Txt_Quantity As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Lbl_Add_Sub_Area_Title As Label
    Friend WithEvents Lbl_Sub_Area As Label
    Friend WithEvents Btn_Add_Recipe_Cancel As Button
    Friend WithEvents btn_Add_Recipe_Confirm As Button
    Friend WithEvents Cmb_Part_Type As ComboBox
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents DGV_Paint_Data As DataGridView
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents Cmb_Area As ComboBox
End Class
