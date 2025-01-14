<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TU_Quality
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
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.DGV_Paint_Data = New System.Windows.Forms.DataGridView()
        Me.DTP_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_Update = New System.Windows.Forms.Button()
        Me.DTP_Start_Time = New System.Windows.Forms.DateTimePicker()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_Good = New System.Windows.Forms.Label()
        Me.Lbl_Reclear_Good = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Lbl_Reclear = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Lbl_TU = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Lbl_Rework = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Lbl_Not_Rerun = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Export
        '
        Me.Btn_Export.Location = New System.Drawing.Point(1312, 6)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Export.TabIndex = 40
        Me.Btn_Export.Text = "Export"
        Me.Btn_Export.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Paint_Data.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(12, 75)
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
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(1375, 541)
        Me.DGV_Paint_Data.TabIndex = 39
        '
        'DTP_End_Date
        '
        Me.DTP_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End_Date.Location = New System.Drawing.Point(383, 6)
        Me.DTP_End_Date.Name = "DTP_End_Date"
        Me.DTP_End_Date.Size = New System.Drawing.Size(134, 23)
        Me.DTP_End_Date.TabIndex = 38
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(135, 6)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(134, 23)
        Me.DTP_Start_Date.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "End Time"
        '
        'DTP_End_Time
        '
        Me.DTP_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_End_Time.Location = New System.Drawing.Point(383, 37)
        Me.DTP_End_Time.Name = "DTP_End_Time"
        Me.DTP_End_Time.ShowUpDown = True
        Me.DTP_End_Time.Size = New System.Drawing.Size(134, 23)
        Me.DTP_End_Time.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Start Time"
        '
        'Btn_Update
        '
        Me.Btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Update.Location = New System.Drawing.Point(554, 20)
        Me.Btn_Update.Name = "Btn_Update"
        Me.Btn_Update.Size = New System.Drawing.Size(75, 24)
        Me.Btn_Update.TabIndex = 33
        Me.Btn_Update.Text = "Update"
        Me.Btn_Update.UseVisualStyleBackColor = True
        '
        'DTP_Start_Time
        '
        Me.DTP_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Start_Time.Location = New System.Drawing.Point(135, 37)
        Me.DTP_Start_Time.Name = "DTP_Start_Time"
        Me.DTP_Start_Time.ShowUpDown = True
        Me.DTP_Start_Time.Size = New System.Drawing.Size(134, 23)
        Me.DTP_Start_Time.TabIndex = 32
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
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(673, 622)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Totals"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(82, 649)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 20)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Good:"
        '
        'lbl_Good
        '
        Me.lbl_Good.BackColor = System.Drawing.Color.White
        Me.lbl_Good.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Good.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Good.Location = New System.Drawing.Point(136, 646)
        Me.lbl_Good.Name = "lbl_Good"
        Me.lbl_Good.Size = New System.Drawing.Size(75, 22)
        Me.lbl_Good.TabIndex = 43
        Me.lbl_Good.Text = "0"
        Me.lbl_Good.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_Reclear_Good
        '
        Me.Lbl_Reclear_Good.BackColor = System.Drawing.Color.White
        Me.Lbl_Reclear_Good.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Reclear_Good.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Reclear_Good.Location = New System.Drawing.Point(356, 646)
        Me.Lbl_Reclear_Good.Name = "Lbl_Reclear_Good"
        Me.Lbl_Reclear_Good.Size = New System.Drawing.Size(75, 22)
        Me.Lbl_Reclear_Good.TabIndex = 45
        Me.Lbl_Reclear_Good.Text = "0"
        Me.Lbl_Reclear_Good.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(243, 649)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 20)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Reclear/Good:"
        '
        'Lbl_Reclear
        '
        Me.Lbl_Reclear.BackColor = System.Drawing.Color.White
        Me.Lbl_Reclear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Reclear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Reclear.Location = New System.Drawing.Point(576, 646)
        Me.Lbl_Reclear.Name = "Lbl_Reclear"
        Me.Lbl_Reclear.Size = New System.Drawing.Size(75, 22)
        Me.Lbl_Reclear.TabIndex = 47
        Me.Lbl_Reclear.Text = "0"
        Me.Lbl_Reclear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(507, 649)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 20)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "Reclear:"
        '
        'Lbl_TU
        '
        Me.Lbl_TU.BackColor = System.Drawing.Color.White
        Me.Lbl_TU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_TU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_TU.Location = New System.Drawing.Point(796, 646)
        Me.Lbl_TU.Name = "Lbl_TU"
        Me.Lbl_TU.Size = New System.Drawing.Size(75, 22)
        Me.Lbl_TU.TabIndex = 49
        Me.Lbl_TU.Text = "0"
        Me.Lbl_TU.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(667, 649)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 20)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "Touch Up Again:"
        '
        'Lbl_Rework
        '
        Me.Lbl_Rework.BackColor = System.Drawing.Color.White
        Me.Lbl_Rework.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Rework.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Rework.Location = New System.Drawing.Point(1016, 646)
        Me.Lbl_Rework.Name = "Lbl_Rework"
        Me.Lbl_Rework.Size = New System.Drawing.Size(75, 22)
        Me.Lbl_Rework.TabIndex = 51
        Me.Lbl_Rework.Text = "0"
        Me.Lbl_Rework.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(948, 649)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 20)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "Rework:"
        '
        'Lbl_Not_Rerun
        '
        Me.Lbl_Not_Rerun.BackColor = System.Drawing.Color.White
        Me.Lbl_Not_Rerun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Lbl_Not_Rerun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Not_Rerun.Location = New System.Drawing.Point(1236, 646)
        Me.Lbl_Not_Rerun.Name = "Lbl_Not_Rerun"
        Me.Lbl_Not_Rerun.Size = New System.Drawing.Size(75, 22)
        Me.Lbl_Not_Rerun.TabIndex = 53
        Me.Lbl_Not_Rerun.Text = "0"
        Me.Lbl_Not_Rerun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1149, 649)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 20)
        Me.Label14.TabIndex = 52
        Me.Label14.Text = "Not Rerun:"
        '
        'TU_Quality
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1399, 676)
        Me.Controls.Add(Me.Lbl_Not_Rerun)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Lbl_Rework)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Lbl_TU)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Lbl_Reclear)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Lbl_Reclear_Good)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbl_Good)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Export)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Controls.Add(Me.DTP_End_Date)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTP_End_Time)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Btn_Update)
        Me.Controls.Add(Me.DTP_Start_Time)
        Me.Name = "TU_Quality"
        Me.Text = "Touch Up Quality"
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Export As Button
    Friend WithEvents DGV_Paint_Data As DataGridView
    Friend WithEvents DTP_End_Date As DateTimePicker
    Friend WithEvents DTP_Start_Date As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DTP_End_Time As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_Update As Button
    Friend WithEvents DTP_Start_Time As DateTimePicker
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_Good As Label
    Friend WithEvents Lbl_Reclear_Good As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Lbl_Reclear As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Lbl_TU As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Lbl_Rework As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Lbl_Not_Rerun As Label
    Friend WithEvents Label14 As Label
End Class
