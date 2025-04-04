<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inventory_Clear
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.lbl_end_date = New System.Windows.Forms.Label()
        Me.lbl_start_date = New System.Windows.Forms.Label()
        Me.lbl_title = New System.Windows.Forms.Label()
        Me.dt_picker_end = New System.Windows.Forms.DateTimePicker()
        Me.dt_picker_start = New System.Windows.Forms.DateTimePicker()
        Me.lbl_color = New System.Windows.Forms.Label()
        Me.cmbbox_color = New System.Windows.Forms.ComboBox()
        Me.lbl_part_type = New System.Windows.Forms.Label()
        Me.cmbbox_part_type = New System.Windows.Forms.ComboBox()
        Me.lbl_qty_total = New System.Windows.Forms.Label()
        Me.lbl_qty_type = New System.Windows.Forms.Label()
        Me.lbl_qty_color = New System.Windows.Forms.Label()
        Me.btn_load = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.lbl_narrow_search = New System.Windows.Forms.Label()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.DefaultCellStyle = DataGridViewCellStyle3
        Me.DGV.Location = New System.Drawing.Point(20, 301)
        Me.DGV.Name = "DGV"
        Me.DGV.RowTemplate.Height = 28
        Me.DGV.Size = New System.Drawing.Size(1059, 523)
        Me.DGV.TabIndex = 3
        '
        'lbl_end_date
        '
        Me.lbl_end_date.AutoSize = True
        Me.lbl_end_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_end_date.Location = New System.Drawing.Point(659, 46)
        Me.lbl_end_date.Name = "lbl_end_date"
        Me.lbl_end_date.Size = New System.Drawing.Size(133, 32)
        Me.lbl_end_date.TabIndex = 13
        Me.lbl_end_date.Text = "End Date"
        '
        'lbl_start_date
        '
        Me.lbl_start_date.AutoSize = True
        Me.lbl_start_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_start_date.Location = New System.Drawing.Point(407, 46)
        Me.lbl_start_date.Name = "lbl_start_date"
        Me.lbl_start_date.Size = New System.Drawing.Size(142, 32)
        Me.lbl_start_date.TabIndex = 12
        Me.lbl_start_date.Text = "Start Date"
        '
        'lbl_title
        '
        Me.lbl_title.AutoSize = True
        Me.lbl_title.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_title.Location = New System.Drawing.Point(30, 19)
        Me.lbl_title.Name = "lbl_title"
        Me.lbl_title.Size = New System.Drawing.Size(291, 37)
        Me.lbl_title.TabIndex = 11
        Me.lbl_title.Text = "Inventory Cleanup"
        '
        'dt_picker_end
        '
        Me.dt_picker_end.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dt_picker_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_picker_end.Location = New System.Drawing.Point(659, 91)
        Me.dt_picker_end.Name = "dt_picker_end"
        Me.dt_picker_end.Size = New System.Drawing.Size(240, 35)
        Me.dt_picker_end.TabIndex = 10
        '
        'dt_picker_start
        '
        Me.dt_picker_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dt_picker_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dt_picker_start.Location = New System.Drawing.Point(407, 91)
        Me.dt_picker_start.Name = "dt_picker_start"
        Me.dt_picker_start.Size = New System.Drawing.Size(240, 35)
        Me.dt_picker_start.TabIndex = 9
        '
        'lbl_color
        '
        Me.lbl_color.AutoSize = True
        Me.lbl_color.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_color.Location = New System.Drawing.Point(301, 193)
        Me.lbl_color.Name = "lbl_color"
        Me.lbl_color.Size = New System.Drawing.Size(83, 32)
        Me.lbl_color.TabIndex = 15
        Me.lbl_color.Text = "Color"
        '
        'cmbbox_color
        '
        Me.cmbbox_color.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.cmbbox_color.FormattingEnabled = True
        Me.cmbbox_color.Location = New System.Drawing.Point(301, 236)
        Me.cmbbox_color.Name = "cmbbox_color"
        Me.cmbbox_color.Size = New System.Drawing.Size(297, 28)
        Me.cmbbox_color.TabIndex = 14
        '
        'lbl_part_type
        '
        Me.lbl_part_type.AutoSize = True
        Me.lbl_part_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_part_type.Location = New System.Drawing.Point(606, 192)
        Me.lbl_part_type.Name = "lbl_part_type"
        Me.lbl_part_type.Size = New System.Drawing.Size(137, 32)
        Me.lbl_part_type.TabIndex = 17
        Me.lbl_part_type.Text = "Part Type"
        '
        'cmbbox_part_type
        '
        Me.cmbbox_part_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.cmbbox_part_type.FormattingEnabled = True
        Me.cmbbox_part_type.Location = New System.Drawing.Point(606, 235)
        Me.cmbbox_part_type.Name = "cmbbox_part_type"
        Me.cmbbox_part_type.Size = New System.Drawing.Size(297, 28)
        Me.cmbbox_part_type.TabIndex = 16
        '
        'lbl_qty_total
        '
        Me.lbl_qty_total.AutoSize = True
        Me.lbl_qty_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_qty_total.Location = New System.Drawing.Point(30, 91)
        Me.lbl_qty_total.Name = "lbl_qty_total"
        Me.lbl_qty_total.Size = New System.Drawing.Size(242, 32)
        Me.lbl_qty_total.TabIndex = 18
        Me.lbl_qty_total.Text = "Quantity Affected:"
        '
        'lbl_qty_type
        '
        Me.lbl_qty_type.AutoSize = True
        Me.lbl_qty_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_qty_type.Location = New System.Drawing.Point(30, 163)
        Me.lbl_qty_type.Name = "lbl_qty_type"
        Me.lbl_qty_type.Size = New System.Drawing.Size(212, 32)
        Me.lbl_qty_type.TabIndex = 20
        Me.lbl_qty_type.Text = "Types Affected:"
        '
        'lbl_qty_color
        '
        Me.lbl_qty_color.AutoSize = True
        Me.lbl_qty_color.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_qty_color.Location = New System.Drawing.Point(30, 235)
        Me.lbl_qty_color.Name = "lbl_qty_color"
        Me.lbl_qty_color.Size = New System.Drawing.Size(217, 32)
        Me.lbl_qty_color.TabIndex = 21
        Me.lbl_qty_color.Text = "Colors Affected:"
        '
        'btn_load
        '
        Me.btn_load.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_load.Location = New System.Drawing.Point(914, 78)
        Me.btn_load.Name = "btn_load"
        Me.btn_load.Size = New System.Drawing.Size(166, 92)
        Me.btn_load.TabIndex = 22
        Me.btn_load.Text = "Load"
        Me.btn_load.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btn_delete.Location = New System.Drawing.Point(913, 183)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(166, 92)
        Me.btn_delete.TabIndex = 23
        Me.btn_delete.Text = "DELETE"
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'lbl_narrow_search
        '
        Me.lbl_narrow_search.AutoSize = True
        Me.lbl_narrow_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_narrow_search.Location = New System.Drawing.Point(301, 154)
        Me.lbl_narrow_search.Name = "lbl_narrow_search"
        Me.lbl_narrow_search.Size = New System.Drawing.Size(87, 32)
        Me.lbl_narrow_search.TabIndex = 24
        Me.lbl_narrow_search.Text = "Filter:"
        '
        'Inventory_Clear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 839)
        Me.Controls.Add(Me.lbl_narrow_search)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_load)
        Me.Controls.Add(Me.lbl_qty_color)
        Me.Controls.Add(Me.lbl_qty_type)
        Me.Controls.Add(Me.lbl_qty_total)
        Me.Controls.Add(Me.lbl_part_type)
        Me.Controls.Add(Me.cmbbox_part_type)
        Me.Controls.Add(Me.lbl_color)
        Me.Controls.Add(Me.cmbbox_color)
        Me.Controls.Add(Me.lbl_end_date)
        Me.Controls.Add(Me.lbl_start_date)
        Me.Controls.Add(Me.lbl_title)
        Me.Controls.Add(Me.dt_picker_end)
        Me.Controls.Add(Me.dt_picker_start)
        Me.Controls.Add(Me.DGV)
        Me.Name = "Inventory_Clear"
        Me.Text = "Inventory_Clear"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV As DataGridView
    Friend WithEvents lbl_end_date As Label
    Friend WithEvents lbl_start_date As Label
    Friend WithEvents lbl_title As Label
    Friend WithEvents dt_picker_end As DateTimePicker
    Friend WithEvents dt_picker_start As DateTimePicker
    Friend WithEvents lbl_color As Label
    Friend WithEvents cmbbox_color As ComboBox
    Friend WithEvents lbl_part_type As Label
    Friend WithEvents cmbbox_part_type As ComboBox
    Friend WithEvents lbl_qty_total As Label
    Friend WithEvents lbl_qty_type As Label
    Friend WithEvents lbl_qty_color As Label
    Friend WithEvents btn_load As Button
    Friend WithEvents btn_delete As Button
    Friend WithEvents lbl_narrow_search As Label
End Class
