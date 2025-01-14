<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NCM_Entry
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
        Me.NCM_Date = New System.Windows.Forms.DateTimePicker()
        Me.lbl_NCM_Date = New System.Windows.Forms.Label()
        Me.lbl_RFID_Tag = New System.Windows.Forms.Label()
        Me.lbl_NCM_Number = New System.Windows.Forms.Label()
        Me.txtbox_Comments = New System.Windows.Forms.RichTextBox()
        Me.lbl_Comments = New System.Windows.Forms.Label()
        Me.lbl_Cust_Part_Number = New System.Windows.Forms.Label()
        Me.lbl_Title = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.line_Title = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.combobox_Color = New System.Windows.Forms.ComboBox()
        Me.lbl_Color = New System.Windows.Forms.Label()
        Me.lbl_Defect_Quantity = New System.Windows.Forms.Label()
        Me.flowlayoutpanel_Defects = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.btn_New_Part = New System.Windows.Forms.Button()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.flowlayoutpanel_Buttons = New System.Windows.Forms.FlowLayoutPanel()
        Me.lbl_Defects = New System.Windows.Forms.Label()
        Me.picturebox_Part = New System.Windows.Forms.PictureBox()
        Me.lbl_picturebox_Part = New System.Windows.Forms.Label()
        Me.combobox_Defect_Quantity = New System.Windows.Forms.ComboBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lbl_Part_Description = New System.Windows.Forms.Label()
        Me.txtbox_Part_Description = New RFID_Station.SelectedTextBox()
        Me.txtbox_Cust_Part_Number = New RFID_Station.SelectedTextBox()
        Me.txtbox_NCM_Number = New RFID_Station.SelectedTextBox()
        Me.txtbox_RFID_Tag = New RFID_Station.SelectedTextBox()
        Me.flowlayoutpanel_Buttons.SuspendLayout()
        CType(Me.picturebox_Part, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NCM_Date
        '
        Me.NCM_Date.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.NCM_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.NCM_Date.Location = New System.Drawing.Point(26, 123)
        Me.NCM_Date.Name = "NCM_Date"
        Me.NCM_Date.Size = New System.Drawing.Size(200, 41)
        Me.NCM_Date.TabIndex = 40
        '
        'lbl_NCM_Date
        '
        Me.lbl_NCM_Date.AutoSize = True
        Me.lbl_NCM_Date.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_NCM_Date.Location = New System.Drawing.Point(22, 92)
        Me.lbl_NCM_Date.Name = "lbl_NCM_Date"
        Me.lbl_NCM_Date.Size = New System.Drawing.Size(140, 34)
        Me.lbl_NCM_Date.TabIndex = 31
        Me.lbl_NCM_Date.Text = "NCM Date"
        '
        'lbl_RFID_Tag
        '
        Me.lbl_RFID_Tag.AutoSize = True
        Me.lbl_RFID_Tag.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_RFID_Tag.Location = New System.Drawing.Point(22, 364)
        Me.lbl_RFID_Tag.Name = "lbl_RFID_Tag"
        Me.lbl_RFID_Tag.Size = New System.Drawing.Size(131, 34)
        Me.lbl_RFID_Tag.TabIndex = 34
        Me.lbl_RFID_Tag.Text = "RFID Tag"
        '
        'lbl_NCM_Number
        '
        Me.lbl_NCM_Number.AutoSize = True
        Me.lbl_NCM_Number.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_NCM_Number.Location = New System.Drawing.Point(22, 163)
        Me.lbl_NCM_Number.Name = "lbl_NCM_Number"
        Me.lbl_NCM_Number.Size = New System.Drawing.Size(181, 34)
        Me.lbl_NCM_Number.TabIndex = 32
        Me.lbl_NCM_Number.Text = "NCM Number"
        '
        'txtbox_Comments
        '
        Me.txtbox_Comments.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtbox_Comments.Location = New System.Drawing.Point(380, 259)
        Me.txtbox_Comments.Name = "txtbox_Comments"
        Me.txtbox_Comments.Size = New System.Drawing.Size(382, 166)
        Me.txtbox_Comments.TabIndex = 5
        Me.txtbox_Comments.Text = ""
        '
        'lbl_Comments
        '
        Me.lbl_Comments.AutoSize = True
        Me.lbl_Comments.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_Comments.Location = New System.Drawing.Point(376, 229)
        Me.lbl_Comments.Name = "lbl_Comments"
        Me.lbl_Comments.Size = New System.Drawing.Size(86, 34)
        Me.lbl_Comments.TabIndex = 37
        Me.lbl_Comments.Text = "Notes"
        '
        'lbl_Cust_Part_Number
        '
        Me.lbl_Cust_Part_Number.AutoSize = True
        Me.lbl_Cust_Part_Number.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_Cust_Part_Number.Location = New System.Drawing.Point(22, 229)
        Me.lbl_Cust_Part_Number.Name = "lbl_Cust_Part_Number"
        Me.lbl_Cust_Part_Number.Size = New System.Drawing.Size(60, 34)
        Me.lbl_Cust_Part_Number.TabIndex = 33
        Me.lbl_Cust_Part_Number.Text = "P/N"
        '
        'lbl_Title
        '
        Me.lbl_Title.AutoSize = True
        Me.lbl_Title.Font = New System.Drawing.Font("Tahoma", 26.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_Title.Location = New System.Drawing.Point(17, 18)
        Me.lbl_Title.Name = "lbl_Title"
        Me.lbl_Title.Size = New System.Drawing.Size(303, 63)
        Me.lbl_Title.TabIndex = 30
        Me.lbl_Title.Text = "NCM Entry"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.line_Title})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1370, 897)
        Me.ShapeContainer1.TabIndex = 18
        Me.ShapeContainer1.TabStop = False
        '
        'line_Title
        '
        Me.line_Title.BorderWidth = 3
        Me.line_Title.Name = "line_Title"
        Me.line_Title.X1 = 50
        Me.line_Title.X2 = 450
        Me.line_Title.Y1 = 76
        Me.line_Title.Y2 = 76
        '
        'combobox_Color
        '
        Me.combobox_Color.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.combobox_Color.FormattingEnabled = True
        Me.combobox_Color.Location = New System.Drawing.Point(380, 123)
        Me.combobox_Color.Name = "combobox_Color"
        Me.combobox_Color.Size = New System.Drawing.Size(382, 42)
        Me.combobox_Color.TabIndex = 3
        '
        'lbl_Color
        '
        Me.lbl_Color.AutoSize = True
        Me.lbl_Color.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_Color.Location = New System.Drawing.Point(376, 92)
        Me.lbl_Color.Name = "lbl_Color"
        Me.lbl_Color.Size = New System.Drawing.Size(78, 34)
        Me.lbl_Color.TabIndex = 35
        Me.lbl_Color.Text = "Color"
        '
        'lbl_Defect_Quantity
        '
        Me.lbl_Defect_Quantity.AutoSize = True
        Me.lbl_Defect_Quantity.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_Defect_Quantity.Location = New System.Drawing.Point(376, 163)
        Me.lbl_Defect_Quantity.Name = "lbl_Defect_Quantity"
        Me.lbl_Defect_Quantity.Size = New System.Drawing.Size(278, 34)
        Me.lbl_Defect_Quantity.TabIndex = 36
        Me.lbl_Defect_Quantity.Text = "Defect Type Quantity"
        '
        'flowlayoutpanel_Defects
        '
        Me.flowlayoutpanel_Defects.Location = New System.Drawing.Point(790, 125)
        Me.flowlayoutpanel_Defects.Name = "flowlayoutpanel_Defects"
        Me.flowlayoutpanel_Defects.Size = New System.Drawing.Size(547, 299)
        Me.flowlayoutpanel_Defects.TabIndex = 21
        '
        'btn_Exit
        '
        Me.btn_Exit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Tahoma", 22.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btn_Exit.Location = New System.Drawing.Point(3, 269)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(194, 127)
        Me.btn_Exit.TabIndex = 8
        Me.btn_Exit.Text = "Exit"
        Me.btn_Exit.UseVisualStyleBackColor = False
        '
        'btn_New_Part
        '
        Me.btn_New_Part.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_New_Part.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_New_Part.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.btn_New_Part.Location = New System.Drawing.Point(3, 136)
        Me.btn_New_Part.Name = "btn_New_Part"
        Me.btn_New_Part.Size = New System.Drawing.Size(194, 127)
        Me.btn_New_Part.TabIndex = 7
        Me.btn_New_Part.Text = "New Part"
        Me.btn_New_Part.UseVisualStyleBackColor = False
        '
        'btn_Submit
        '
        Me.btn_Submit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Submit.Font = New System.Drawing.Font("Tahoma", 22.0!)
        Me.btn_Submit.Location = New System.Drawing.Point(3, 3)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(194, 127)
        Me.btn_Submit.TabIndex = 6
        Me.btn_Submit.Text = "Submit"
        Me.btn_Submit.UseVisualStyleBackColor = False
        '
        'flowlayoutpanel_Buttons
        '
        Me.flowlayoutpanel_Buttons.Controls.Add(Me.btn_Submit)
        Me.flowlayoutpanel_Buttons.Controls.Add(Me.btn_New_Part)
        Me.flowlayoutpanel_Buttons.Controls.Add(Me.btn_Exit)
        Me.flowlayoutpanel_Buttons.Location = New System.Drawing.Point(1137, 467)
        Me.flowlayoutpanel_Buttons.Name = "flowlayoutpanel_Buttons"
        Me.flowlayoutpanel_Buttons.Size = New System.Drawing.Size(200, 398)
        Me.flowlayoutpanel_Buttons.TabIndex = 22
        '
        'lbl_Defects
        '
        Me.lbl_Defects.AutoSize = True
        Me.lbl_Defects.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.lbl_Defects.Location = New System.Drawing.Point(791, 88)
        Me.lbl_Defects.Name = "lbl_Defects"
        Me.lbl_Defects.Size = New System.Drawing.Size(137, 43)
        Me.lbl_Defects.TabIndex = 38
        Me.lbl_Defects.Text = "Defects"
        '
        'picturebox_Part
        '
        Me.picturebox_Part.Location = New System.Drawing.Point(26, 467)
        Me.picturebox_Part.Name = "picturebox_Part"
        Me.picturebox_Part.Size = New System.Drawing.Size(1084, 395)
        Me.picturebox_Part.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picturebox_Part.TabIndex = 23
        Me.picturebox_Part.TabStop = False
        '
        'lbl_picturebox_Part
        '
        Me.lbl_picturebox_Part.AutoSize = True
        Me.lbl_picturebox_Part.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.lbl_picturebox_Part.Location = New System.Drawing.Point(22, 424)
        Me.lbl_picturebox_Part.Name = "lbl_picturebox_Part"
        Me.lbl_picturebox_Part.Size = New System.Drawing.Size(203, 43)
        Me.lbl_picturebox_Part.TabIndex = 39
        Me.lbl_picturebox_Part.Text = "Part Picture"
        '
        'combobox_Defect_Quantity
        '
        Me.combobox_Defect_Quantity.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.combobox_Defect_Quantity.FormattingEnabled = True
        Me.combobox_Defect_Quantity.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.combobox_Defect_Quantity.Location = New System.Drawing.Point(380, 194)
        Me.combobox_Defect_Quantity.Name = "combobox_Defect_Quantity"
        Me.combobox_Defect_Quantity.Size = New System.Drawing.Size(382, 42)
        Me.combobox_Defect_Quantity.TabIndex = 4
        '
        'BackgroundWorker1
        '
        '
        'lbl_Part_Description
        '
        Me.lbl_Part_Description.AutoSize = True
        Me.lbl_Part_Description.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.lbl_Part_Description.Location = New System.Drawing.Point(20, 298)
        Me.lbl_Part_Description.Name = "lbl_Part_Description"
        Me.lbl_Part_Description.Size = New System.Drawing.Size(210, 34)
        Me.lbl_Part_Description.TabIndex = 42
        Me.lbl_Part_Description.Text = "Part Description"
        '
        'txtbox_Part_Description
        '
        Me.txtbox_Part_Description.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtbox_Part_Description.Location = New System.Drawing.Point(24, 328)
        Me.txtbox_Part_Description.Name = "txtbox_Part_Description"
        Me.txtbox_Part_Description.ReadOnly = True
        Me.txtbox_Part_Description.Size = New System.Drawing.Size(323, 41)
        Me.txtbox_Part_Description.TabIndex = 41
        '
        'txtbox_Cust_Part_Number
        '
        Me.txtbox_Cust_Part_Number.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtbox_Cust_Part_Number.Location = New System.Drawing.Point(26, 258)
        Me.txtbox_Cust_Part_Number.Name = "txtbox_Cust_Part_Number"
        Me.txtbox_Cust_Part_Number.Size = New System.Drawing.Size(323, 41)
        Me.txtbox_Cust_Part_Number.TabIndex = 2
        '
        'txtbox_NCM_Number
        '
        Me.txtbox_NCM_Number.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtbox_NCM_Number.Location = New System.Drawing.Point(26, 194)
        Me.txtbox_NCM_Number.Name = "txtbox_NCM_Number"
        Me.txtbox_NCM_Number.Size = New System.Drawing.Size(323, 41)
        Me.txtbox_NCM_Number.TabIndex = 1
        '
        'txtbox_RFID_Tag
        '
        Me.txtbox_RFID_Tag.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.txtbox_RFID_Tag.Location = New System.Drawing.Point(26, 395)
        Me.txtbox_RFID_Tag.Name = "txtbox_RFID_Tag"
        Me.txtbox_RFID_Tag.ReadOnly = True
        Me.txtbox_RFID_Tag.Size = New System.Drawing.Size(323, 41)
        Me.txtbox_RFID_Tag.TabIndex = 10
        '
        'NCM_Entry
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1370, 897)
        Me.Controls.Add(Me.lbl_Part_Description)
        Me.Controls.Add(Me.txtbox_Part_Description)
        Me.Controls.Add(Me.combobox_Defect_Quantity)
        Me.Controls.Add(Me.lbl_picturebox_Part)
        Me.Controls.Add(Me.lbl_Defects)
        Me.Controls.Add(Me.flowlayoutpanel_Buttons)
        Me.Controls.Add(Me.flowlayoutpanel_Defects)
        Me.Controls.Add(Me.lbl_Defect_Quantity)
        Me.Controls.Add(Me.lbl_Color)
        Me.Controls.Add(Me.combobox_Color)
        Me.Controls.Add(Me.lbl_Title)
        Me.Controls.Add(Me.txtbox_Cust_Part_Number)
        Me.Controls.Add(Me.lbl_Cust_Part_Number)
        Me.Controls.Add(Me.lbl_Comments)
        Me.Controls.Add(Me.txtbox_Comments)
        Me.Controls.Add(Me.txtbox_NCM_Number)
        Me.Controls.Add(Me.lbl_NCM_Number)
        Me.Controls.Add(Me.lbl_RFID_Tag)
        Me.Controls.Add(Me.txtbox_RFID_Tag)
        Me.Controls.Add(Me.lbl_NCM_Date)
        Me.Controls.Add(Me.NCM_Date)
        Me.Controls.Add(Me.picturebox_Part)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "NCM_Entry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NCM_Entry"
        Me.flowlayoutpanel_Buttons.ResumeLayout(False)
        CType(Me.picturebox_Part, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NCM_Date As DateTimePicker
    Friend WithEvents lbl_NCM_Date As Label
    Friend WithEvents txtbox_RFID_Tag As SelectedTextBox
    Friend WithEvents lbl_RFID_Tag As Label
    Friend WithEvents lbl_NCM_Number As Label
    Friend WithEvents txtbox_NCM_Number As SelectedTextBox
    Friend WithEvents txtbox_Comments As RichTextBox
    Friend WithEvents lbl_Comments As Label
    Friend WithEvents txtbox_Cust_Part_Number As SelectedTextBox
    Friend WithEvents lbl_Cust_Part_Number As Label
    Friend WithEvents lbl_Title As Label
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents line_Title As PowerPacks.LineShape
    Friend WithEvents combobox_Color As ComboBox
    Friend WithEvents lbl_Color As Label
    Friend WithEvents lbl_Defect_Quantity As Label
    Friend WithEvents flowlayoutpanel_Defects As FlowLayoutPanel
    Friend WithEvents btn_Exit As Button
    Friend WithEvents btn_New_Part As Button
    Friend WithEvents btn_Submit As Button
    Friend WithEvents flowlayoutpanel_Buttons As FlowLayoutPanel
    Friend WithEvents lbl_Defects As Label
    Friend WithEvents picturebox_Part As PictureBox
    Friend WithEvents lbl_picturebox_Part As Label
    Friend WithEvents combobox_Defect_Quantity As ComboBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbl_Part_Description As Label
    Friend WithEvents txtbox_Part_Description As SelectedTextBox
End Class
