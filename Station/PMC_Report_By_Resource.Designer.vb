<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PMC_Report_By_Resource
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.DGV_PMC_Data = New System.Windows.Forms.DataGridView()
        Me.DTP_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Update = New System.Windows.Forms.Button()
        Me.DTP_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_Resource = New System.Windows.Forms.ComboBox()
        Me.digital_CheckBox = New System.Windows.Forms.CheckBox()
        Me.analog_CheckBox = New System.Windows.Forms.CheckBox()
        Me.block1_CheckBox = New System.Windows.Forms.CheckBox()
        Me.block2_Checkbox = New System.Windows.Forms.CheckBox()
        Me.lbl_Analog_Datablock = New System.Windows.Forms.Label()
        Me.block3_CheckBox = New System.Windows.Forms.CheckBox()
        CType(Me.DGV_PMC_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Export
        '
        Me.Btn_Export.Location = New System.Drawing.Point(1842, 37)
        Me.Btn_Export.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(112, 35)
        Me.Btn_Export.TabIndex = 51
        Me.Btn_Export.Text = "Export"
        Me.Btn_Export.UseVisualStyleBackColor = True
        '
        'DGV_PMC_Data
        '
        Me.DGV_PMC_Data.AllowUserToAddRows = False
        Me.DGV_PMC_Data.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_PMC_Data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGV_PMC_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_PMC_Data.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGV_PMC_Data.Location = New System.Drawing.Point(10, 143)
        Me.DGV_PMC_Data.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV_PMC_Data.Name = "DGV_PMC_Data"
        Me.DGV_PMC_Data.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_PMC_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGV_PMC_Data.Size = New System.Drawing.Size(1944, 832)
        Me.DGV_PMC_Data.TabIndex = 50
        '
        'DTP_End_Date
        '
        Me.DTP_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End_Date.Location = New System.Drawing.Point(567, 37)
        Me.DTP_End_Date.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_End_Date.Name = "DTP_End_Date"
        Me.DTP_End_Date.Size = New System.Drawing.Size(199, 30)
        Me.DTP_End_Date.TabIndex = 49
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(195, 37)
        Me.DTP_Start_Date.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(199, 30)
        Me.DTP_Start_Date.TabIndex = 48
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(436, 63)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 25)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "End Time"
        '
        'DTP_End_Time
        '
        Me.DTP_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_End_Time.Location = New System.Drawing.Point(567, 85)
        Me.DTP_End_Time.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_End_Time.Name = "DTP_End_Time"
        Me.DTP_End_Time.ShowUpDown = True
        Me.DTP_End_Time.Size = New System.Drawing.Size(199, 30)
        Me.DTP_End_Time.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 25)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Start Time"
        '
        'Btn_Update
        '
        Me.Btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Update.Location = New System.Drawing.Point(1462, 60)
        Me.Btn_Update.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Btn_Update.Name = "Btn_Update"
        Me.Btn_Update.Size = New System.Drawing.Size(112, 37)
        Me.Btn_Update.TabIndex = 44
        Me.Btn_Update.Text = "Update"
        Me.Btn_Update.UseVisualStyleBackColor = True
        '
        'DTP_Start_Time
        '
        Me.DTP_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Start_Time.Location = New System.Drawing.Point(195, 85)
        Me.DTP_Start_Time.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_Start_Time.Name = "DTP_Start_Time"
        Me.DTP_Start_Time.ShowUpDown = True
        Me.DTP_Start_Time.Size = New System.Drawing.Size(199, 30)
        Me.DTP_Start_Time.TabIndex = 43
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "csv"
        Me.SaveFile.FileName = "Paint_Production.csv"
        Me.SaveFile.Filter = """Comma Delimited Text|*.csv"""
        Me.SaveFile.RestoreDirectory = True
        Me.SaveFile.Title = "Save Export Data"
        Me.SaveFile.ValidateNames = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(831, 66)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 25)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "PMC Resource"
        '
        'Cmb_Resource
        '
        Me.Cmb_Resource.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Resource.FormattingEnabled = True
        Me.Cmb_Resource.Location = New System.Drawing.Point(1004, 63)
        Me.Cmb_Resource.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Cmb_Resource.Name = "Cmb_Resource"
        Me.Cmb_Resource.Size = New System.Drawing.Size(386, 33)
        Me.Cmb_Resource.TabIndex = 52
        '
        'digital_CheckBox
        '
        Me.digital_CheckBox.AutoSize = True
        Me.digital_CheckBox.Location = New System.Drawing.Point(1004, 11)
        Me.digital_CheckBox.Name = "digital_CheckBox"
        Me.digital_CheckBox.Size = New System.Drawing.Size(134, 24)
        Me.digital_CheckBox.TabIndex = 54
        Me.digital_CheckBox.Text = "Display Digital"
        Me.digital_CheckBox.UseVisualStyleBackColor = True
        Me.digital_CheckBox.Visible = False
        '
        'analog_CheckBox
        '
        Me.analog_CheckBox.AutoSize = True
        Me.analog_CheckBox.Location = New System.Drawing.Point(1004, 37)
        Me.analog_CheckBox.Name = "analog_CheckBox"
        Me.analog_CheckBox.Size = New System.Drawing.Size(140, 24)
        Me.analog_CheckBox.TabIndex = 55
        Me.analog_CheckBox.Text = "Display Analog"
        Me.analog_CheckBox.UseVisualStyleBackColor = True
        Me.analog_CheckBox.Visible = False
        '
        'block1_CheckBox
        '
        Me.block1_CheckBox.AutoSize = True
        Me.block1_CheckBox.Location = New System.Drawing.Point(1161, 37)
        Me.block1_CheckBox.Name = "block1_CheckBox"
        Me.block1_CheckBox.Size = New System.Drawing.Size(57, 24)
        Me.block1_CheckBox.TabIndex = 56
        Me.block1_CheckBox.Text = "1st"
        Me.block1_CheckBox.UseVisualStyleBackColor = True
        Me.block1_CheckBox.Visible = False
        '
        'block2_Checkbox
        '
        Me.block2_Checkbox.AutoSize = True
        Me.block2_Checkbox.Location = New System.Drawing.Point(1237, 37)
        Me.block2_Checkbox.Name = "block2_Checkbox"
        Me.block2_Checkbox.Size = New System.Drawing.Size(62, 24)
        Me.block2_Checkbox.TabIndex = 57
        Me.block2_Checkbox.Text = "2nd"
        Me.block2_Checkbox.UseVisualStyleBackColor = True
        Me.block2_Checkbox.Visible = False
        '
        'lbl_Analog_Datablock
        '
        Me.lbl_Analog_Datablock.AutoSize = True
        Me.lbl_Analog_Datablock.Location = New System.Drawing.Point(1157, 11)
        Me.lbl_Analog_Datablock.Name = "lbl_Analog_Datablock"
        Me.lbl_Analog_Datablock.Size = New System.Drawing.Size(257, 20)
        Me.lbl_Analog_Datablock.TabIndex = 58
        Me.lbl_Analog_Datablock.Text = "Select Analog Datablock to Display"
        Me.lbl_Analog_Datablock.Visible = False
        '
        'block3_CheckBox
        '
        Me.block3_CheckBox.AutoSize = True
        Me.block3_CheckBox.Location = New System.Drawing.Point(1321, 37)
        Me.block3_CheckBox.Name = "block3_CheckBox"
        Me.block3_CheckBox.Size = New System.Drawing.Size(62, 24)
        Me.block3_CheckBox.TabIndex = 59
        Me.block3_CheckBox.Text = "3nd"
        Me.block3_CheckBox.UseVisualStyleBackColor = True
        Me.block3_CheckBox.Visible = False
        '
        'PMC_Report_By_Resource
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1980, 971)
        Me.Controls.Add(Me.block3_CheckBox)
        Me.Controls.Add(Me.lbl_Analog_Datablock)
        Me.Controls.Add(Me.block2_Checkbox)
        Me.Controls.Add(Me.block1_CheckBox)
        Me.Controls.Add(Me.analog_CheckBox)
        Me.Controls.Add(Me.digital_CheckBox)
        Me.Controls.Add(Me.Btn_Export)
        Me.Controls.Add(Me.DGV_PMC_Data)
        Me.Controls.Add(Me.DTP_End_Date)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTP_End_Time)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn_Update)
        Me.Controls.Add(Me.DTP_Start_Time)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmb_Resource)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "PMC_Report_By_Resource"
        Me.Text = "PMC_Report_By_Resource"
        CType(Me.DGV_PMC_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Export As Button
    Friend WithEvents DGV_PMC_Data As DataGridView
    Friend WithEvents DTP_End_Date As DateTimePicker
    Friend WithEvents DTP_Start_Date As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DTP_End_Time As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Update As Button
    Friend WithEvents DTP_Start_Time As DateTimePicker
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Cmb_Resource As ComboBox
    Friend WithEvents digital_CheckBox As CheckBox
    Friend WithEvents analog_CheckBox As CheckBox
    Friend WithEvents block1_CheckBox As CheckBox
    Friend WithEvents block2_Checkbox As CheckBox
    Friend WithEvents lbl_Analog_Datablock As Label
    Friend WithEvents block3_CheckBox As CheckBox
End Class
