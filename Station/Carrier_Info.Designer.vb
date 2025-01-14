<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Carrier_Info
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Carrier_Info))
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.DGV_Paint_Data = New System.Windows.Forms.DataGridView()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_Carrier_Number = New System.Windows.Forms.Label()
        Me.Lbl_Log_Time = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Lbl_Style = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Lbl_Color = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Export
        '
        Me.Btn_Export.Location = New System.Drawing.Point(701, 12)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Export.TabIndex = 23
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
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(12, 170)
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
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(763, 450)
        Me.DGV_Paint_Data.TabIndex = 22
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "csv"
        Me.SaveFile.FileName = "Paint_Production_Parts.csv"
        Me.SaveFile.Filter = """Comma Delimited Text|*.csv"""
        Me.SaveFile.RestoreDirectory = True
        Me.SaveFile.Title = "Save Export Data"
        Me.SaveFile.ValidateNames = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 17)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Carrier Number"
        '
        'Lbl_Carrier_Number
        '
        Me.Lbl_Carrier_Number.AutoSize = True
        Me.Lbl_Carrier_Number.BackColor = System.Drawing.Color.White
        Me.Lbl_Carrier_Number.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Carrier_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Carrier_Number.Location = New System.Drawing.Point(137, 17)
        Me.Lbl_Carrier_Number.Name = "Lbl_Carrier_Number"
        Me.Lbl_Carrier_Number.Size = New System.Drawing.Size(53, 19)
        Me.Lbl_Carrier_Number.TabIndex = 25
        Me.Lbl_Carrier_Number.Text = "Label2"
        '
        'Lbl_Log_Time
        '
        Me.Lbl_Log_Time.AutoSize = True
        Me.Lbl_Log_Time.BackColor = System.Drawing.Color.White
        Me.Lbl_Log_Time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Log_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Log_Time.Location = New System.Drawing.Point(137, 52)
        Me.Lbl_Log_Time.Name = "Lbl_Log_Time"
        Me.Lbl_Log_Time.Size = New System.Drawing.Size(53, 19)
        Me.Lbl_Log_Time.TabIndex = 27
        Me.Lbl_Log_Time.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Entered System"
        '
        'Lbl_Style
        '
        Me.Lbl_Style.AutoSize = True
        Me.Lbl_Style.BackColor = System.Drawing.Color.White
        Me.Lbl_Style.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Style.Location = New System.Drawing.Point(137, 89)
        Me.Lbl_Style.Name = "Lbl_Style"
        Me.Lbl_Style.Size = New System.Drawing.Size(53, 19)
        Me.Lbl_Style.TabIndex = 29
        Me.Lbl_Style.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(85, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 17)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Style"
        '
        'Lbl_Color
        '
        Me.Lbl_Color.AutoSize = True
        Me.Lbl_Color.BackColor = System.Drawing.Color.White
        Me.Lbl_Color.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Color.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Color.Location = New System.Drawing.Point(137, 123)
        Me.Lbl_Color.Name = "Lbl_Color"
        Me.Lbl_Color.Size = New System.Drawing.Size(53, 19)
        Me.Lbl_Color.TabIndex = 31
        Me.Lbl_Color.Text = "Label7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(83, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Color"
        '
        'Carrier_Info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 632)
        Me.Controls.Add(Me.Lbl_Color)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Lbl_Style)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lbl_Log_Time)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lbl_Carrier_Number)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Export)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Carrier_Info"
        Me.Text = "Carrier Information"
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Export As Button
    Friend WithEvents DGV_Paint_Data As DataGridView
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_Carrier_Number As Label
    Friend WithEvents Lbl_Log_Time As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Lbl_Style As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Lbl_Color As Label
    Friend WithEvents Label8 As Label
End Class
