<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Robot_Part_Change
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Robot_Part_Change))
        Me.Cmb_Bell = New System.Windows.Forms.ComboBox()
        Me.Lbl_Area = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_Robot = New System.Windows.Forms.Label()
        Me.Cmb_Spray_Head = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmb_Air_Cap = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTP_Change_Date = New System.Windows.Forms.DateTimePicker()
        Me.DTP_Change_Time = New System.Windows.Forms.DateTimePicker()
        Me.Cmb_Retaining_Ring = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmb_Reason = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Cmb_Bell
        '
        Me.Cmb_Bell.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Bell.FormattingEnabled = True
        Me.Cmb_Bell.Location = New System.Drawing.Point(137, 82)
        Me.Cmb_Bell.Name = "Cmb_Bell"
        Me.Cmb_Bell.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Bell.TabIndex = 29
        '
        'Lbl_Area
        '
        Me.Lbl_Area.AutoSize = True
        Me.Lbl_Area.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Area.Location = New System.Drawing.Point(47, 85)
        Me.Lbl_Area.Name = "Lbl_Area"
        Me.Lbl_Area.Size = New System.Drawing.Size(70, 17)
        Me.Lbl_Area.TabIndex = 28
        Me.Lbl_Area.Text = "Gun / Bell"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 17)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Robot"
        '
        'Lbl_Robot
        '
        Me.Lbl_Robot.BackColor = System.Drawing.SystemColors.Control
        Me.Lbl_Robot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Lbl_Robot.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Robot.Location = New System.Drawing.Point(137, 33)
        Me.Lbl_Robot.Name = "Lbl_Robot"
        Me.Lbl_Robot.Size = New System.Drawing.Size(248, 25)
        Me.Lbl_Robot.TabIndex = 31
        Me.Lbl_Robot.Text = "Robot"
        '
        'Cmb_Spray_Head
        '
        Me.Cmb_Spray_Head.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Spray_Head.FormattingEnabled = True
        Me.Cmb_Spray_Head.Location = New System.Drawing.Point(137, 126)
        Me.Cmb_Spray_Head.Name = "Cmb_Spray_Head"
        Me.Cmb_Spray_Head.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Spray_Head.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Spray Head"
        '
        'Cmb_Air_Cap
        '
        Me.Cmb_Air_Cap.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Air_Cap.FormattingEnabled = True
        Me.Cmb_Air_Cap.Location = New System.Drawing.Point(137, 170)
        Me.Cmb_Air_Cap.Name = "Cmb_Air_Cap"
        Me.Cmb_Air_Cap.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Air_Cap.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 17)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Air Cap"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(268, 353)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 37
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(131, 353)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 36
        Me.Btn_Save.Text = "Update"
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 261)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 17)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Change Time"
        '
        'DTP_Change_Date
        '
        Me.DTP_Change_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Change_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Change_Date.Location = New System.Drawing.Point(137, 258)
        Me.DTP_Change_Date.Name = "DTP_Change_Date"
        Me.DTP_Change_Date.Size = New System.Drawing.Size(150, 23)
        Me.DTP_Change_Date.TabIndex = 65
        '
        'DTP_Change_Time
        '
        Me.DTP_Change_Time.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Change_Time.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DTP_Change_Time.Location = New System.Drawing.Point(307, 258)
        Me.DTP_Change_Time.Name = "DTP_Change_Time"
        Me.DTP_Change_Time.ShowUpDown = True
        Me.DTP_Change_Time.Size = New System.Drawing.Size(141, 23)
        Me.DTP_Change_Time.TabIndex = 67
        '
        'Cmb_Retaining_Ring
        '
        Me.Cmb_Retaining_Ring.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Retaining_Ring.FormattingEnabled = True
        Me.Cmb_Retaining_Ring.Location = New System.Drawing.Point(137, 214)
        Me.Cmb_Retaining_Ring.Name = "Cmb_Retaining_Ring"
        Me.Cmb_Retaining_Ring.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Retaining_Ring.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 17)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Retaining Ring"
        '
        'Cmb_Reason
        '
        Me.Cmb_Reason.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Reason.FormattingEnabled = True
        Me.Cmb_Reason.Location = New System.Drawing.Point(137, 301)
        Me.Cmb_Reason.Name = "Cmb_Reason"
        Me.Cmb_Reason.Size = New System.Drawing.Size(311, 24)
        Me.Cmb_Reason.TabIndex = 71
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(60, 304)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 17)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Reason"
        '
        'Robot_Part_Change
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 406)
        Me.Controls.Add(Me.Cmb_Reason)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cmb_Retaining_Ring)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTP_Change_Time)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DTP_Change_Date)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Cmb_Air_Cap)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Cmb_Spray_Head)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Lbl_Robot)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmb_Bell)
        Me.Controls.Add(Me.Lbl_Area)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Robot_Part_Change"
        Me.Text = "Robot Part Change"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Cmb_Bell As ComboBox
    Friend WithEvents Lbl_Area As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_Robot As Label
    Friend WithEvents Cmb_Spray_Head As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Cmb_Air_Cap As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents DTP_Change_Date As DateTimePicker
    Friend WithEvents DTP_Change_Time As DateTimePicker
    Friend WithEvents Cmb_Retaining_Ring As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmb_Reason As ComboBox
    Friend WithEvents Label6 As Label
End Class
