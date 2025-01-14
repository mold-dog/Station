<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Local_Read
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Local_Read))
        Me.Btn_Get_Data = New System.Windows.Forms.Button()
        Me.Lbl_RFID_Data = New System.Windows.Forms.Label()
        Me.Txt_Data = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cmb_Serial_Ports = New System.Windows.Forms.ComboBox()
        Me.Btn_OK = New System.Windows.Forms.Button()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btn_Get_Data
        '
        Me.Btn_Get_Data.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Get_Data.Location = New System.Drawing.Point(295, 28)
        Me.Btn_Get_Data.Name = "Btn_Get_Data"
        Me.Btn_Get_Data.Size = New System.Drawing.Size(75, 26)
        Me.Btn_Get_Data.TabIndex = 0
        Me.Btn_Get_Data.Text = "Get Data"
        Me.Btn_Get_Data.UseVisualStyleBackColor = True
        '
        'Lbl_RFID_Data
        '
        Me.Lbl_RFID_Data.AutoSize = True
        Me.Lbl_RFID_Data.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_RFID_Data.Location = New System.Drawing.Point(26, 94)
        Me.Lbl_RFID_Data.Name = "Lbl_RFID_Data"
        Me.Lbl_RFID_Data.Size = New System.Drawing.Size(73, 17)
        Me.Lbl_RFID_Data.TabIndex = 1
        Me.Lbl_RFID_Data.Text = "RFID Data"
        '
        'Txt_Data
        '
        Me.Txt_Data.Enabled = False
        Me.Txt_Data.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Data.Location = New System.Drawing.Point(120, 91)
        Me.Txt_Data.Name = "Txt_Data"
        Me.Txt_Data.Size = New System.Drawing.Size(299, 23)
        Me.Txt_Data.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Serial Port"
        '
        'Cmb_Serial_Ports
        '
        Me.Cmb_Serial_Ports.FormattingEnabled = True
        Me.Cmb_Serial_Ports.Location = New System.Drawing.Point(120, 30)
        Me.Cmb_Serial_Ports.Name = "Cmb_Serial_Ports"
        Me.Cmb_Serial_Ports.Size = New System.Drawing.Size(121, 21)
        Me.Cmb_Serial_Ports.TabIndex = 4
        '
        'Btn_OK
        '
        Me.Btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_OK.Location = New System.Drawing.Point(115, 128)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 26)
        Me.Btn_OK.TabIndex = 5
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(251, 128)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(75, 26)
        Me.Btn_Cancel.TabIndex = 6
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Local_Read
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 166)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_OK)
        Me.Controls.Add(Me.Cmb_Serial_Ports)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_Data)
        Me.Controls.Add(Me.Lbl_RFID_Data)
        Me.Controls.Add(Me.Btn_Get_Data)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Local_Read"
        Me.Text = "Local Part Lookup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Get_Data As Button
    Friend WithEvents Lbl_RFID_Data As Label
    Friend WithEvents Txt_Data As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Cmb_Serial_Ports As ComboBox
    Friend WithEvents Btn_OK As Button
    Friend WithEvents Btn_Cancel As Button
End Class
