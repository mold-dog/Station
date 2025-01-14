<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QRScanner
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
        Me.camPreview = New System.Windows.Forms.PictureBox()
        Me.btn_startQR = New System.Windows.Forms.Button()
        Me.btn_stopQR = New System.Windows.Forms.Button()
        Me.textBox_QR = New System.Windows.Forms.TextBox()
        CType(Me.camPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'camPreview
        '
        Me.camPreview.Location = New System.Drawing.Point(20, 25)
        Me.camPreview.Name = "camPreview"
        Me.camPreview.Size = New System.Drawing.Size(450, 450)
        Me.camPreview.TabIndex = 0
        Me.camPreview.TabStop = False
        '
        'btn_startQR
        '
        Me.btn_startQR.Location = New System.Drawing.Point(20, 532)
        Me.btn_startQR.Name = "btn_startQR"
        Me.btn_startQR.Size = New System.Drawing.Size(200, 50)
        Me.btn_startQR.TabIndex = 1
        Me.btn_startQR.Text = "Start"
        Me.btn_startQR.UseVisualStyleBackColor = True
        '
        'btn_stopQR
        '
        Me.btn_stopQR.Location = New System.Drawing.Point(270, 532)
        Me.btn_stopQR.Name = "btn_stopQR"
        Me.btn_stopQR.Size = New System.Drawing.Size(200, 50)
        Me.btn_stopQR.TabIndex = 3
        Me.btn_stopQR.Text = "Stop"
        Me.btn_stopQR.UseVisualStyleBackColor = True
        '
        'textBox_QR
        '
        Me.textBox_QR.Location = New System.Drawing.Point(20, 492)
        Me.textBox_QR.Name = "textBox_QR"
        Me.textBox_QR.Size = New System.Drawing.Size(450, 26)
        Me.textBox_QR.TabIndex = 4
        '
        'QRScanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 606)
        Me.Controls.Add(Me.textBox_QR)
        Me.Controls.Add(Me.btn_stopQR)
        Me.Controls.Add(Me.btn_startQR)
        Me.Controls.Add(Me.camPreview)
        Me.Name = "QRScanner"
        Me.Text = "QR Scanner"
        CType(Me.camPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents camPreview As PictureBox
    Friend WithEvents btn_startQR As Button
    Friend WithEvents btn_stopQR As Button
    Friend WithEvents textBox_QR As TextBox


End Class
