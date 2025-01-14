<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tag_Compare
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
        Me.DGV_Compare = New System.Windows.Forms.DataGridView()
        Me.Btn_Export = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Txt_Part_ID_1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Part_ID_2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DGV_Compare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Compare
        '
        Me.DGV_Compare.AllowUserToAddRows = False
        Me.DGV_Compare.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Compare.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DGV_Compare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Compare.DefaultCellStyle = DataGridViewCellStyle11
        Me.DGV_Compare.Location = New System.Drawing.Point(12, 89)
        Me.DGV_Compare.Name = "DGV_Compare"
        Me.DGV_Compare.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Compare.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DGV_Compare.Size = New System.Drawing.Size(1300, 586)
        Me.DGV_Compare.TabIndex = 31
        '
        'Btn_Export
        '
        Me.Btn_Export.Location = New System.Drawing.Point(1213, 23)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Export.TabIndex = 32
        Me.Btn_Export.Text = "Export"
        Me.Btn_Export.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(463, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 25)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "RFID Test Tag Comparison"
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "csv"
        Me.SaveFile.FileName = "Test_Panel_History.csv"
        Me.SaveFile.Filter = """Comma Delimited Text|*.csv"""
        Me.SaveFile.RestoreDirectory = True
        Me.SaveFile.Title = "Save Export Data"
        Me.SaveFile.ValidateNames = False
        '
        'Txt_Part_ID_1
        '
        Me.Txt_Part_ID_1.Enabled = False
        Me.Txt_Part_ID_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Part_ID_1.Location = New System.Drawing.Point(101, 6)
        Me.Txt_Part_ID_1.Name = "Txt_Part_ID_1"
        Me.Txt_Part_ID_1.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Part_ID_1.TabIndex = 136
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 17)
        Me.Label6.TabIndex = 137
        Me.Label6.Text = "Part ID #1"
        '
        'Txt_Part_ID_2
        '
        Me.Txt_Part_ID_2.Enabled = False
        Me.Txt_Part_ID_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Part_ID_2.Location = New System.Drawing.Point(101, 48)
        Me.Txt_Part_ID_2.Name = "Txt_Part_ID_2"
        Me.Txt_Part_ID_2.Size = New System.Drawing.Size(287, 23)
        Me.Txt_Part_ID_2.TabIndex = 138
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 139
        Me.Label2.Text = "Part ID #2"
        '
        'Tag_Compare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1324, 687)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Part_ID_2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Txt_Part_ID_1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Export)
        Me.Controls.Add(Me.DGV_Compare)
        Me.Name = "Tag_Compare"
        Me.Text = "RFID Tag Compare"
        CType(Me.DGV_Compare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Compare As DataGridView
    Friend WithEvents Btn_Export As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents Txt_Part_ID_1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Txt_Part_ID_2 As TextBox
    Friend WithEvents Label2 As Label
End Class
