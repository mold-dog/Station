<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NCM_Data
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
        Me.btn_update = New System.Windows.Forms.Button()
        Me.cmbbox_customers = New System.Windows.Forms.ComboBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.dt_picker_start = New System.Windows.Forms.DateTimePicker()
        Me.dt_picker_end = New System.Windows.Forms.DateTimePicker()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_update
        '
        Me.btn_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_update.Location = New System.Drawing.Point(1018, 5)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(125, 73)
        Me.btn_update.TabIndex = 0
        Me.btn_update.Text = "Update"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'cmbbox_customers
        '
        Me.cmbbox_customers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbbox_customers.FormattingEnabled = True
        Me.cmbbox_customers.Location = New System.Drawing.Point(773, 41)
        Me.cmbbox_customers.Name = "cmbbox_customers"
        Me.cmbbox_customers.Size = New System.Drawing.Size(223, 37)
        Me.cmbbox_customers.TabIndex = 1
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(28, 90)
        Me.DGV.Name = "DGV"
        Me.DGV.RowTemplate.Height = 28
        Me.DGV.Size = New System.Drawing.Size(1253, 693)
        Me.DGV.TabIndex = 2
        '
        'dt_picker_start
        '
        Me.dt_picker_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dt_picker_start.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_picker_start.Location = New System.Drawing.Point(352, 43)
        Me.dt_picker_start.Name = "dt_picker_start"
        Me.dt_picker_start.Size = New System.Drawing.Size(200, 35)
        Me.dt_picker_start.TabIndex = 3
        '
        'dt_picker_end
        '
        Me.dt_picker_end.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dt_picker_end.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt_picker_end.Location = New System.Drawing.Point(564, 43)
        Me.dt_picker_end.Name = "dt_picker_end"
        Me.dt_picker_end.Size = New System.Drawing.Size(200, 35)
        Me.dt_picker_end.TabIndex = 4
        '
        'btn_export
        '
        Me.btn_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_export.Location = New System.Drawing.Point(1156, 5)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(125, 73)
        Me.btn_export.TabIndex = 5
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.Label1.Location = New System.Drawing.Point(33, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(268, 37)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "NCM Data Export"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label2.Location = New System.Drawing.Point(352, -2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 32)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Start Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label3.Location = New System.Drawing.Point(564, -2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 32)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "End Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.Label4.Location = New System.Drawing.Point(773, -2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 32)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Customer"
        '
        'SaveFile
        '
        Me.SaveFile.DefaultExt = "csv"
        Me.SaveFile.FileName = "NCM_Data.csv"
        Me.SaveFile.Filter = """Comma Delimited Text|*.csv"""
        Me.SaveFile.RestoreDirectory = True
        Me.SaveFile.Title = "Save Export Data"
        Me.SaveFile.ValidateNames = False
        '
        'NCM_Data
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1304, 800)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.dt_picker_end)
        Me.Controls.Add(Me.dt_picker_start)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.cmbbox_customers)
        Me.Controls.Add(Me.btn_update)
        Me.Name = "NCM_Data"
        Me.Text = "NCM_Data"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_update As Button
    Friend WithEvents cmbbox_customers As ComboBox
    Friend WithEvents DGV As DataGridView
    Friend WithEvents dt_picker_start As DateTimePicker
    Friend WithEvents dt_picker_end As DateTimePicker
    Friend WithEvents btn_export As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents SaveFile As SaveFileDialog
End Class
