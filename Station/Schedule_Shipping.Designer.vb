<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schedule_Shipping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Schedule_Shipping))
        Me.Opt_Default = New System.Windows.Forms.RadioButton()
        Me.Opt_Exception = New System.Windows.Forms.RadioButton()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Btn_Delete = New System.Windows.Forms.Button()
        Me.Btn_Edit = New System.Windows.Forms.Button()
        Me.Btn_Add = New System.Windows.Forms.Button()
        Me.Lbl_Date = New System.Windows.Forms.Label()
        Me.DTP_Start_Date = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'Opt_Default
        '
        Me.Opt_Default.AutoSize = True
        Me.Opt_Default.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Opt_Default.Enabled = False
        Me.Opt_Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Default.Location = New System.Drawing.Point(14, 25)
        Me.Opt_Default.Name = "Opt_Default"
        Me.Opt_Default.Size = New System.Drawing.Size(71, 21)
        Me.Opt_Default.TabIndex = 52
        Me.Opt_Default.TabStop = True
        Me.Opt_Default.Text = "Default"
        Me.Opt_Default.UseVisualStyleBackColor = True
        '
        'Opt_Exception
        '
        Me.Opt_Exception.AutoSize = True
        Me.Opt_Exception.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Opt_Exception.Enabled = False
        Me.Opt_Exception.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opt_Exception.Location = New System.Drawing.Point(133, 25)
        Me.Opt_Exception.Name = "Opt_Exception"
        Me.Opt_Exception.Size = New System.Drawing.Size(87, 21)
        Me.Opt_Exception.TabIndex = 53
        Me.Opt_Exception.TabStop = True
        Me.Opt_Exception.Text = "Exception"
        Me.Opt_Exception.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(270, 558)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Cancel.TabIndex = 60
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        Me.Btn_Cancel.Visible = False
        '
        'Btn_Save
        '
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.Location = New System.Drawing.Point(133, 558)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Save.TabIndex = 59
        Me.Btn_Save.Text = "Save"
        Me.Btn_Save.UseVisualStyleBackColor = True
        Me.Btn_Save.Visible = False
        '
        'Btn_Delete
        '
        Me.Btn_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Delete.Location = New System.Drawing.Point(336, 510)
        Me.Btn_Delete.Name = "Btn_Delete"
        Me.Btn_Delete.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Delete.TabIndex = 58
        Me.Btn_Delete.Text = "Delete"
        Me.Btn_Delete.UseVisualStyleBackColor = True
        Me.Btn_Delete.Visible = False
        '
        'Btn_Edit
        '
        Me.Btn_Edit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit.Location = New System.Drawing.Point(199, 510)
        Me.Btn_Edit.Name = "Btn_Edit"
        Me.Btn_Edit.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Edit.TabIndex = 57
        Me.Btn_Edit.Text = "Edit"
        Me.Btn_Edit.UseVisualStyleBackColor = True
        Me.Btn_Edit.Visible = False
        '
        'Btn_Add
        '
        Me.Btn_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Add.Location = New System.Drawing.Point(67, 510)
        Me.Btn_Add.Name = "Btn_Add"
        Me.Btn_Add.Size = New System.Drawing.Size(86, 30)
        Me.Btn_Add.TabIndex = 56
        Me.Btn_Add.Text = "Add"
        Me.Btn_Add.UseVisualStyleBackColor = True
        '
        'Lbl_Date
        '
        Me.Lbl_Date.AutoSize = True
        Me.Lbl_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Date.Location = New System.Drawing.Point(235, 28)
        Me.Lbl_Date.Name = "Lbl_Date"
        Me.Lbl_Date.Size = New System.Drawing.Size(38, 17)
        Me.Lbl_Date.TabIndex = 61
        Me.Lbl_Date.Text = "Date"
        '
        'DTP_Start_Date
        '
        Me.DTP_Start_Date.Enabled = False
        Me.DTP_Start_Date.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Start_Date.Location = New System.Drawing.Point(289, 25)
        Me.DTP_Start_Date.Name = "DTP_Start_Date"
        Me.DTP_Start_Date.Size = New System.Drawing.Size(174, 23)
        Me.DTP_Start_Date.TabIndex = 50
        '
        'Schedule_Shipping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 664)
        Me.Controls.Add(Me.Opt_Default)
        Me.Controls.Add(Me.DTP_Start_Date)
        Me.Controls.Add(Me.Opt_Exception)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_Save)
        Me.Controls.Add(Me.Btn_Delete)
        Me.Controls.Add(Me.Btn_Edit)
        Me.Controls.Add(Me.Btn_Add)
        Me.Controls.Add(Me.Lbl_Date)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Schedule_Shipping"
        Me.Text = "Shipping Schedule"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Opt_Default As RadioButton
    Friend WithEvents Opt_Exception As RadioButton
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Save As Button
    Friend WithEvents Btn_Delete As Button
    Friend WithEvents Btn_Edit As Button
    Friend WithEvents Btn_Add As Button
    Friend WithEvents Lbl_Date As Label
    Friend WithEvents DTP_Start_Date As DateTimePicker
End Class
