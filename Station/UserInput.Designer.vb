<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInput
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.lbl_DropDown = New System.Windows.Forms.Label()
        Me.lbl_TextBox = New System.Windows.Forms.Label()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(21, 61)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(1051, 40)
        Me.ComboBox1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.TextBox1.Location = New System.Drawing.Point(21, 156)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1051, 553)
        Me.TextBox1.TabIndex = 1
        '
        'lbl_DropDown
        '
        Me.lbl_DropDown.AutoSize = True
        Me.lbl_DropDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_DropDown.Location = New System.Drawing.Point(21, 19)
        Me.lbl_DropDown.Name = "lbl_DropDown"
        Me.lbl_DropDown.Size = New System.Drawing.Size(102, 32)
        Me.lbl_DropDown.TabIndex = 2
        Me.lbl_DropDown.Text = "Label1"
        '
        'lbl_TextBox
        '
        Me.lbl_TextBox.AutoSize = True
        Me.lbl_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lbl_TextBox.Location = New System.Drawing.Point(21, 113)
        Me.lbl_TextBox.Name = "lbl_TextBox"
        Me.lbl_TextBox.Size = New System.Drawing.Size(102, 32)
        Me.lbl_TextBox.TabIndex = 3
        Me.lbl_TextBox.Text = "Label2"
        '
        'btn_Submit
        '
        Me.btn_Submit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btn_Submit.Location = New System.Drawing.Point(931, 724)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(141, 51)
        Me.btn_Submit.TabIndex = 4
        Me.btn_Submit.Text = "Submit"
        Me.btn_Submit.UseVisualStyleBackColor = True
        '
        'UserInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 800)
        Me.Controls.Add(Me.btn_Submit)
        Me.Controls.Add(Me.lbl_TextBox)
        Me.Controls.Add(Me.lbl_DropDown)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "UserInput"
        Me.Text = "UserInput"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents lbl_DropDown As Label
    Friend WithEvents lbl_TextBox As Label
    Friend WithEvents btn_Submit As Button
End Class
