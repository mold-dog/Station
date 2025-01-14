<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Molding_Job_Process_Data
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV_Paint_Data = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Txt_RFID = New System.Windows.Forms.TextBox()
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.lblUser1 = New System.Windows.Forms.Label()
        Me.lblUser4 = New System.Windows.Forms.Label()
        Me.lblUser3 = New System.Windows.Forms.Label()
        Me.lblUser2 = New System.Windows.Forms.Label()
        Me.lblUser5 = New System.Windows.Forms.Label()
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Paint_Data
        '
        Me.DGV_Paint_Data.AllowUserToAddRows = False
        Me.DGV_Paint_Data.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DGV_Paint_Data.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Paint_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Paint_Data.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Paint_Data.Location = New System.Drawing.Point(12, 69)
        Me.DGV_Paint_Data.Name = "DGV_Paint_Data"
        Me.DGV_Paint_Data.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Paint_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_Paint_Data.Size = New System.Drawing.Size(929, 676)
        Me.DGV_Paint_Data.TabIndex = 152
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Job RFID"
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "csv"
        Me.SaveFile.FileName = "Paint_Process_Data.csv"
        Me.SaveFile.Filter = """Comma Delimited Text|*.csv"""
        Me.SaveFile.RestoreDirectory = True
        Me.SaveFile.Title = "Save Export Data"
        Me.SaveFile.ValidateNames = False
        '
        'Txt_RFID
        '
        Me.Txt_RFID.Enabled = False
        Me.Txt_RFID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RFID.Location = New System.Drawing.Point(84, 12)
        Me.Txt_RFID.Name = "Txt_RFID"
        Me.Txt_RFID.Size = New System.Drawing.Size(293, 23)
        Me.Txt_RFID.TabIndex = 154
        '
        'Btn_Export
        '
        Me.Btn_Export.Location = New System.Drawing.Point(868, 15)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Export.TabIndex = 153
        Me.Btn_Export.Text = "Export"
        Me.Btn_Export.UseVisualStyleBackColor = True
        '
        'lblUser1
        '
        Me.lblUser1.AutoSize = True
        Me.lblUser1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser1.Location = New System.Drawing.Point(14, 41)
        Me.lblUser1.Name = "lblUser1"
        Me.lblUser1.Size = New System.Drawing.Size(49, 16)
        Me.lblUser1.TabIndex = 155
        Me.lblUser1.Text = "Label2"
        '
        'lblUser4
        '
        Me.lblUser4.AutoSize = True
        Me.lblUser4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser4.Location = New System.Drawing.Point(548, 41)
        Me.lblUser4.Name = "lblUser4"
        Me.lblUser4.Size = New System.Drawing.Size(49, 16)
        Me.lblUser4.TabIndex = 156
        Me.lblUser4.Text = "Label2"
        '
        'lblUser3
        '
        Me.lblUser3.AutoSize = True
        Me.lblUser3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser3.Location = New System.Drawing.Point(370, 41)
        Me.lblUser3.Name = "lblUser3"
        Me.lblUser3.Size = New System.Drawing.Size(49, 16)
        Me.lblUser3.TabIndex = 157
        Me.lblUser3.Text = "Label2"
        '
        'lblUser2
        '
        Me.lblUser2.AutoSize = True
        Me.lblUser2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser2.Location = New System.Drawing.Point(192, 41)
        Me.lblUser2.Name = "lblUser2"
        Me.lblUser2.Size = New System.Drawing.Size(49, 16)
        Me.lblUser2.TabIndex = 158
        Me.lblUser2.Text = "Label2"
        '
        'lblUser5
        '
        Me.lblUser5.AutoSize = True
        Me.lblUser5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser5.Location = New System.Drawing.Point(726, 41)
        Me.lblUser5.Name = "lblUser5"
        Me.lblUser5.Size = New System.Drawing.Size(49, 16)
        Me.lblUser5.TabIndex = 159
        Me.lblUser5.Text = "Label2"
        '
        'Molding_Job_Process_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(955, 756)
        Me.Controls.Add(Me.lblUser5)
        Me.Controls.Add(Me.lblUser2)
        Me.Controls.Add(Me.lblUser3)
        Me.Controls.Add(Me.lblUser4)
        Me.Controls.Add(Me.lblUser1)
        Me.Controls.Add(Me.DGV_Paint_Data)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_RFID)
        Me.Controls.Add(Me.Btn_Export)
        Me.Name = "Molding_Job_Process_Data"
        Me.Text = "Molding_Job_Process_Data"
        CType(Me.DGV_Paint_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Paint_Data As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents Txt_RFID As TextBox
    Friend WithEvents Btn_Export As Button
    Friend WithEvents lblUser1 As Label
    Friend WithEvents lblUser4 As Label
    Friend WithEvents lblUser3 As Label
    Friend WithEvents lblUser2 As Label
    Friend WithEvents lblUser5 As Label
End Class
