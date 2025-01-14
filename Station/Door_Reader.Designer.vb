<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Door_Reader
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Door_Reader))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_Door = New System.Windows.Forms.ComboBox()
        Me.Opt_1_Minute = New System.Windows.Forms.RadioButton()
        Me.Opt_5_minute = New System.Windows.Forms.RadioButton()
        Me.Opt_10_Minute = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV_Reads = New System.Windows.Forms.DataGridView()
        Me.Read_Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Btn_Refresh = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DGV_Reads, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Door"
        '
        'Cmb_Door
        '
        Me.Cmb_Door.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Door.FormattingEnabled = True
        Me.Cmb_Door.Location = New System.Drawing.Point(68, 33)
        Me.Cmb_Door.Name = "Cmb_Door"
        Me.Cmb_Door.Size = New System.Drawing.Size(272, 24)
        Me.Cmb_Door.TabIndex = 1
        '
        'Opt_1_Minute
        '
        Me.Opt_1_Minute.AutoSize = True
        Me.Opt_1_Minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_1_Minute.Location = New System.Drawing.Point(75, 96)
        Me.Opt_1_Minute.Name = "Opt_1_Minute"
        Me.Opt_1_Minute.Size = New System.Drawing.Size(80, 21)
        Me.Opt_1_Minute.TabIndex = 2
        Me.Opt_1_Minute.TabStop = True
        Me.Opt_1_Minute.Text = "1 Minute"
        Me.Opt_1_Minute.UseVisualStyleBackColor = True
        '
        'Opt_5_minute
        '
        Me.Opt_5_minute.AutoSize = True
        Me.Opt_5_minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_5_minute.Location = New System.Drawing.Point(75, 119)
        Me.Opt_5_minute.Name = "Opt_5_minute"
        Me.Opt_5_minute.Size = New System.Drawing.Size(80, 21)
        Me.Opt_5_minute.TabIndex = 3
        Me.Opt_5_minute.TabStop = True
        Me.Opt_5_minute.Text = "5 Minute"
        Me.Opt_5_minute.UseVisualStyleBackColor = True
        '
        'Opt_10_Minute
        '
        Me.Opt_10_Minute.AutoSize = True
        Me.Opt_10_Minute.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_10_Minute.Location = New System.Drawing.Point(75, 142)
        Me.Opt_10_Minute.Name = "Opt_10_Minute"
        Me.Opt_10_Minute.Size = New System.Drawing.Size(88, 21)
        Me.Opt_10_Minute.TabIndex = 4
        Me.Opt_10_Minute.TabStop = True
        Me.Opt_10_Minute.Text = "10 Minute"
        Me.Opt_10_Minute.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(72, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Show Reads in Last:"
        '
        'DGV_Reads
        '
        Me.DGV_Reads.AllowUserToAddRows = False
        Me.DGV_Reads.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Reads.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Reads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Reads.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Read_Time, Me.RFID})
        Me.DGV_Reads.Location = New System.Drawing.Point(383, 12)
        Me.DGV_Reads.Name = "DGV_Reads"
        Me.DGV_Reads.Size = New System.Drawing.Size(624, 958)
        Me.DGV_Reads.TabIndex = 6
        '
        'Read_Time
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Read_Time.DefaultCellStyle = DataGridViewCellStyle2
        Me.Read_Time.HeaderText = "Time Read"
        Me.Read_Time.MinimumWidth = 100
        Me.Read_Time.Name = "Read_Time"
        Me.Read_Time.ReadOnly = True
        Me.Read_Time.Width = 250
        '
        'RFID
        '
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RFID.DefaultCellStyle = DataGridViewCellStyle3
        Me.RFID.HeaderText = "RFID"
        Me.RFID.Name = "RFID"
        Me.RFID.ReadOnly = True
        Me.RFID.Width = 300
        '
        'Btn_Refresh
        '
        Me.Btn_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Refresh.Location = New System.Drawing.Point(75, 196)
        Me.Btn_Refresh.Name = "Btn_Refresh"
        Me.Btn_Refresh.Size = New System.Drawing.Size(88, 31)
        Me.Btn_Refresh.TabIndex = 7
        Me.Btn_Refresh.Text = "Refresh"
        Me.Btn_Refresh.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20000
        '
        'Door_Reader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 982)
        Me.Controls.Add(Me.Btn_Refresh)
        Me.Controls.Add(Me.DGV_Reads)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Opt_10_Minute)
        Me.Controls.Add(Me.Opt_5_minute)
        Me.Controls.Add(Me.Opt_1_Minute)
        Me.Controls.Add(Me.Cmb_Door)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Door_Reader"
        Me.Text = "Door Reader"
        CType(Me.DGV_Reads, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Cmb_Door As ComboBox
    Friend WithEvents Opt_1_Minute As RadioButton
    Friend WithEvents Opt_5_minute As RadioButton
    Friend WithEvents Opt_10_Minute As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents DGV_Reads As DataGridView
    Friend WithEvents Btn_Refresh As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Read_Time As DataGridViewTextBoxColumn
    Friend WithEvents RFID As DataGridViewTextBoxColumn
End Class
