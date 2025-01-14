<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PMC_History_By_Event
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
        Me.DGV_PMC_Data = New System.Windows.Forms.DataGridView()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.Lbl_Record_Count = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DGV_PMC_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Export
        '
        Me.Btn_Export.Location = New System.Drawing.Point(1183, 12)
        Me.Btn_Export.Name = "Btn_Export"
        Me.Btn_Export.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Export.TabIndex = 25
        Me.Btn_Export.Text = "Export"
        Me.Btn_Export.UseVisualStyleBackColor = True
        '
        'DGV_PMC_Data
        '
        Me.DGV_PMC_Data.AllowUserToAddRows = False
        Me.DGV_PMC_Data.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_PMC_Data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_PMC_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_PMC_Data.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_PMC_Data.Location = New System.Drawing.Point(12, 52)
        Me.DGV_PMC_Data.Name = "DGV_PMC_Data"
        Me.DGV_PMC_Data.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_PMC_Data.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_PMC_Data.Size = New System.Drawing.Size(1246, 570)
        Me.DGV_PMC_Data.TabIndex = 24
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
        'Lbl_Record_Count
        '
        Me.Lbl_Record_Count.AutoSize = True
        Me.Lbl_Record_Count.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Record_Count.Location = New System.Drawing.Point(134, 15)
        Me.Lbl_Record_Count.Name = "Lbl_Record_Count"
        Me.Lbl_Record_Count.Size = New System.Drawing.Size(36, 20)
        Me.Lbl_Record_Count.TabIndex = 27
        Me.Lbl_Record_Count.Text = "###"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Record Count:"
        '
        'PMC_History_By_Event
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1270, 634)
        Me.Controls.Add(Me.Btn_Export)
        Me.Controls.Add(Me.DGV_PMC_Data)
        Me.Controls.Add(Me.Lbl_Record_Count)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PMC_History_By_Event"
        Me.Text = "PMC_History_By_Event"
        CType(Me.DGV_PMC_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Export As Button
    Friend WithEvents DGV_PMC_Data As DataGridView
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents Lbl_Record_Count As Label
    Friend WithEvents Label1 As Label
End Class
