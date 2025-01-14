<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Press_Alarm_History
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV_Paint_Data = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Press = New System.Windows.Forms.ComboBox()
        Me.DTP_End_Date = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTP_End_Time = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Update = New System.Windows.Forms.Button()
        Me.DTP_Start_Time = New System.Windows.Forms.DateTimePicker()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Paint_Data
        '
        Me.DGV_Paint_Data.AllowUserToAddRows = False
        Me.DGV_Paint_Data.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DGV_Paint_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Paint_Data.DefaultCellStyle = DataGridViewCellStyle8
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(12, 103)
        Me.DGV_Paint_Data.Name = "DGV_Paint_Data"
        Me.DGV_Paint_Data.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(1193, 515)
        Me.DGV_Paint_Data.TabIndex = 46
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(435, -3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(346, 42)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Press Alarm History"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(640, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Press"
        '
        'Cmb_Press
        '
        Me.Cmb_Press.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Press.FormattingEnabled = True
        Me.Cmb_Press.Location = New System.Drawing.Point(708, 57)
        Me.Cmb_Press.Name = "Cmb_Press"
        Me.Cmb_Press.Size = New System.Drawing.Size(259, 24)
        Me.Cmb_Press.TabIndex = 61
        '
        'DTP_End_Date
        '
        Me.DTP_End_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_End_Date.Location = New System.Drawing.Point(417, 40)
        Me.DTP_End_Date.Name = "DTP_End_Date"
        Me.DTP_End_Date.Size = New System.Drawing.Size(134, 23)
        Me.DTP_End_Date.TabIndex = 60
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(169, 40)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(134, 23)
        Me.DTP_Start_Date.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(330, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 17)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "End Time"
        '
        'DTP_End_Time
        '
        Me.DTP_End_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_End_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_End_Time.Location = New System.Drawing.Point(417, 71)
        Me.DTP_End_Time.Name = "DTP_End_Time"
        Me.DTP_End_Time.ShowUpDown = True
        Me.DTP_End_Time.Size = New System.Drawing.Size(134, 23)
        Me.DTP_End_Time.TabIndex = 57
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(69, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Start Time"
        '
        'Btn_Update
        '
        Me.Btn_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Update.Location = New System.Drawing.Point(1014, 55)
        Me.Btn_Update.Name = "Btn_Update"
        Me.Btn_Update.Size = New System.Drawing.Size(75, 24)
        Me.Btn_Update.TabIndex = 55
        Me.Btn_Update.Text = "Update"
        Me.Btn_Update.UseVisualStyleBackColor = True
        '
        'DTP_Start_Time
        '
        Me.DTP_Start_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Start_Time.Location = New System.Drawing.Point(169, 71)
        Me.DTP_Start_Time.Name = "DTP_Start_Time"
        Me.DTP_Start_Time.ShowUpDown = True
        Me.DTP_Start_Time.Size = New System.Drawing.Size(134, 23)
        Me.DTP_Start_Time.TabIndex = 54
        '
        'Press_Alarm_History
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 630)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmb_Press)
        Me.Controls.Add(Me.DTP_End_Date)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DTP_End_Time)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Btn_Update)
        Me.Controls.Add(Me.DTP_Start_Time)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Press_Alarm_History"
        Me.Text = "Press Alarm History"
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Paint_Data As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmb_Press As ComboBox
    Friend WithEvents DTP_End_Date As DateTimePicker
    Friend WithEvents DTP_Start_Date As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents DTP_End_Time As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn_Update As Button
    Friend WithEvents DTP_Start_Time As DateTimePicker
End Class
