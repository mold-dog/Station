<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PressDataExport
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
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.radio_btn_A = New System.Windows.Forms.RadioButton()
        Me.lbl_Calendar = New System.Windows.Forms.Label()
        Me.lbl_Shift = New System.Windows.Forms.Label()
        Me.radio_btn_B = New System.Windows.Forms.RadioButton()
        Me.radio_btn_C = New System.Windows.Forms.RadioButton()
        Me.radio_btn_D = New System.Windows.Forms.RadioButton()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(16, 65)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'radio_btn_A
        '
        Me.radio_btn_A.AutoSize = True
        Me.radio_btn_A.Checked = True
        Me.radio_btn_A.Location = New System.Drawing.Point(379, 65)
        Me.radio_btn_A.Name = "radio_btn_A"
        Me.radio_btn_A.Size = New System.Drawing.Size(80, 24)
        Me.radio_btn_A.TabIndex = 1
        Me.radio_btn_A.TabStop = True
        Me.radio_btn_A.Text = "Shift 1"
        Me.radio_btn_A.UseVisualStyleBackColor = True
        '
        'lbl_Calendar
        '
        Me.lbl_Calendar.AutoSize = True
        Me.lbl_Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_Calendar.Location = New System.Drawing.Point(22, 22)
        Me.lbl_Calendar.Name = "lbl_Calendar"
        Me.lbl_Calendar.Size = New System.Drawing.Size(229, 32)
        Me.lbl_Calendar.TabIndex = 2
        Me.lbl_Calendar.Text = "Select Start Date"
        '
        'lbl_Shift
        '
        Me.lbl_Shift.AutoSize = True
        Me.lbl_Shift.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_Shift.Location = New System.Drawing.Point(379, 22)
        Me.lbl_Shift.Name = "lbl_Shift"
        Me.lbl_Shift.Size = New System.Drawing.Size(160, 32)
        Me.lbl_Shift.TabIndex = 3
        Me.lbl_Shift.Text = "Select Shift"
        '
        'radio_btn_B
        '
        Me.radio_btn_B.AutoSize = True
        Me.radio_btn_B.Location = New System.Drawing.Point(379, 100)
        Me.radio_btn_B.Name = "radio_btn_B"
        Me.radio_btn_B.Size = New System.Drawing.Size(80, 24)
        Me.radio_btn_B.TabIndex = 4
        Me.radio_btn_B.Text = "Shift 2"
        Me.radio_btn_B.UseVisualStyleBackColor = True
        '
        'radio_btn_C
        '
        Me.radio_btn_C.AutoSize = True
        Me.radio_btn_C.Location = New System.Drawing.Point(379, 135)
        Me.radio_btn_C.Name = "radio_btn_C"
        Me.radio_btn_C.Size = New System.Drawing.Size(80, 24)
        Me.radio_btn_C.TabIndex = 5
        Me.radio_btn_C.Text = "Shift 3"
        Me.radio_btn_C.UseVisualStyleBackColor = True
        '
        'radio_btn_D
        '
        Me.radio_btn_D.AutoSize = True
        Me.radio_btn_D.Location = New System.Drawing.Point(379, 170)
        Me.radio_btn_D.Name = "radio_btn_D"
        Me.radio_btn_D.Size = New System.Drawing.Size(83, 24)
        Me.radio_btn_D.TabIndex = 6
        Me.radio_btn_D.Text = "Shift D"
        Me.radio_btn_D.UseVisualStyleBackColor = True
        Me.radio_btn_D.Visible = False
        '
        'btn_export
        '
        Me.btn_export.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btn_export.Location = New System.Drawing.Point(379, 262)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(163, 55)
        Me.btn_export.TabIndex = 7
        Me.btn_export.Text = "Export"
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'PressDataExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 344)
        Me.Controls.Add(Me.btn_export)
        Me.Controls.Add(Me.radio_btn_D)
        Me.Controls.Add(Me.radio_btn_C)
        Me.Controls.Add(Me.radio_btn_B)
        Me.Controls.Add(Me.lbl_Shift)
        Me.Controls.Add(Me.lbl_Calendar)
        Me.Controls.Add(Me.radio_btn_A)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Name = "PressDataExport"
        Me.Text = "PressDataExport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents radio_btn_A As RadioButton
    Friend WithEvents lbl_Calendar As Label
    Friend WithEvents lbl_Shift As Label
    Friend WithEvents radio_btn_B As RadioButton
    Friend WithEvents radio_btn_C As RadioButton
    Friend WithEvents radio_btn_D As RadioButton
    Friend WithEvents btn_export As Button
End Class
