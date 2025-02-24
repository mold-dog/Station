<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Slitter_Scanner
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.e = New System.Windows.Forms.Label()
        Me.line_Title = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_scannerstatus = New RFID_Station.SerialStatusLabel()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Exit
        '
        Me.btn_Exit.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Tahoma", 22.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.btn_Exit.Location = New System.Drawing.Point(425, 159)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(194, 127)
        Me.btn_Exit.TabIndex = 8
        Me.btn_Exit.Text = "Exit"
        Me.btn_Exit.UseVisualStyleBackColor = False
        '
        'e
        '
        Me.e.AutoSize = True
        Me.e.Font = New System.Drawing.Font("Tahoma", 26.0!, System.Drawing.FontStyle.Bold)
        Me.e.Location = New System.Drawing.Point(19, 11)
        Me.e.Name = "e"
        Me.e.Size = New System.Drawing.Size(624, 63)
        Me.e.TabIndex = 24
        Me.e.Text = "QR Scanner Data Entry"
        '
        'line_Title
        '
        Me.line_Title.BorderWidth = 3
        Me.line_Title.Name = "line_Title"
        Me.line_Title.X1 = 29
        Me.line_Title.X2 = 630
        Me.line_Title.Y1 = 52
        Me.line_Title.Y2 = 52
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.line_Title})
        Me.ShapeContainer1.Size = New System.Drawing.Size(648, 315)
        Me.ShapeContainer1.TabIndex = 25
        Me.ShapeContainer1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(425, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(212, 31)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Scanner Status"
        '
        'lbl_scannerstatus
        '
        Me.lbl_scannerstatus.AutoSize = True
        Me.lbl_scannerstatus.Location = New System.Drawing.Point(425, 118)
        Me.lbl_scannerstatus.Name = "lbl_scannerstatus"
        Me.lbl_scannerstatus.Size = New System.Drawing.Size(134, 20)
        Me.lbl_scannerstatus.TabIndex = 1
        Me.lbl_scannerstatus.Text = "lbl_scannerstatus"
        '
        'Slitter_Scanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.ClientSize = New System.Drawing.Size(648, 315)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.e)
        Me.Controls.Add(Me.lbl_scannerstatus)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Slitter_Scanner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Slitter_Scanner"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents lbl_scannerstatus As SerialStatusLabel
    Friend WithEvents btn_Exit As Button
    Friend WithEvents e As Label
    Friend WithEvents line_Title As PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents Label2 As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class
