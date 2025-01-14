<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mold_Schedule
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
        Me.btn_Load = New System.Windows.Forms.Button()
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
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Column0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pnl_Recipe.SuspendLayout()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Load
        '
        Me.btn_Load.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Load.Location = New System.Drawing.Point(260, 5)
        Me.btn_Load.Name = "btn_Load"
        Me.btn_Load.Size = New System.Drawing.Size(110, 23)
        Me.btn_Load.TabIndex = 79
        Me.btn_Load.Text = "Load Parts"
        Me.btn_Load.UseVisualStyleBackColor = True
        Me.btn_Load.Visible = False
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
        Me.Pnl_Recipe.Location = New System.Drawing.Point(130, 178)
        Me.Pnl_Recipe.Name = "Pnl_Recipe"
        Me.Pnl_Recipe.Size = New System.Drawing.Size(402, 165)
        Me.Pnl_Recipe.TabIndex = 78
        Me.Pnl_Recipe.Visible = False
        '
        'Txt_Quantity
        '
        Me.Txt_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Quantity.Location = New System.Drawing.Point(98, 78)
        Me.Txt_Quantity.Name = "Txt_Quantity"
        Me.Txt_Quantity.Size = New System.Drawing.Size(100, 23)
        Me.Txt_Quantity.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Add_Sub_Area_Title
        '
        Me.Lbl_Add_Sub_Area_Title.AutoSize = True
        Me.Lbl_Add_Sub_Area_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Add_Sub_Area_Title.Location = New System.Drawing.Point(125, 16)
        Me.Lbl_Add_Sub_Area_Title.Name = "Lbl_Add_Sub_Area_Title"
        Me.Lbl_Add_Sub_Area_Title.Size = New System.Drawing.Size(142, 17)
        Me.Lbl_Add_Sub_Area_Title.TabIndex = 17
        Me.Lbl_Add_Sub_Area_Title.Text = "Add Part to Schedule"
        Me.Lbl_Add_Sub_Area_Title.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Lbl_Sub_Area
        '
        Me.Lbl_Sub_Area.AutoSize = True
        Me.Lbl_Sub_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Sub_Area.Location = New System.Drawing.Point(48, 54)
        Me.Lbl_Sub_Area.Name = "Lbl_Sub_Area"
        Me.Lbl_Sub_Area.Size = New System.Drawing.Size(34, 17)
        Me.Lbl_Sub_Area.TabIndex = 16
        Me.Lbl_Sub_Area.Text = "Part"
        Me.Lbl_Sub_Area.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Btn_Add_Recipe_Cancel
        '
        Me.Btn_Add_Recipe_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add_Recipe_Cancel.Location = New System.Drawing.Point(224, 116)
        Me.Btn_Add_Recipe_Cancel.Name = "Btn_Add_Recipe_Cancel"
        Me.Btn_Add_Recipe_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add_Recipe_Cancel.TabIndex = 22
        Me.Btn_Add_Recipe_Cancel.Text = "Cancel"
        Me.Btn_Add_Recipe_Cancel.UseVisualStyleBackColor = True
        '
        'btn_Add_Recipe_Confirm
        '
        Me.btn_Add_Recipe_Confirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Add_Recipe_Confirm.Location = New System.Drawing.Point(65, 116)
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
        Me.Btn_Delete.Location = New System.Drawing.Point(114, 604)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Delete.TabIndex = 77
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(11, 604)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Add.TabIndex = 76
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
        Me.DGV_Paint_Data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column0, Me.Column1, Me.Column3})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Paint_Data.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(12, 37)
        Me.DGV_Paint_Data.Name = "DGV_Paint_Data"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(670, 556)
        Me.DGV_Paint_Data.TabIndex = 75
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(91, 5)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(134, 23)
        Me.DTP_Start_Date.TabIndex = 74
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 73
        Me.Label2.Text = "Date"
        '
        'Column0
        '
        Me.Column0.HeaderText = "ID"
        Me.Column0.Name = "Column0"
        Me.Column0.Visible = False
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
        Me.Column3.HeaderText = "Quantity"
        Me.Column3.Name = "Column3"
        '
        'Mold_Schedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 633)
        Me.Controls.Add(Me.btn_Load)
        Me.Controls.Add(Me.Pnl_Recipe)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Mold_Schedule"
        Me.Text = "Mold Schedule"
        Me.Pnl_Recipe.ResumeLayout(False)
        Me.Pnl_Recipe.PerformLayout()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Load As Button
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
    Friend WithEvents DTP_Start_Date As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Column0 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
