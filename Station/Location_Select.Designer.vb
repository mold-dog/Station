<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Location_Select
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
        Me.lbl_instruction = New System.Windows.Forms.Label()
        Me.lbl_welcome = New System.Windows.Forms.Label()
        Me.btn_location1 = New System.Windows.Forms.Button()
        Me.panel_btn_locations = New System.Windows.Forms.Panel()
        Me.btn_location4 = New System.Windows.Forms.Button()
        Me.btn_location3 = New System.Windows.Forms.Button()
        Me.btn_location2 = New System.Windows.Forms.Button()
        Me.panel_btn_locations.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_instruction
        '
        Me.lbl_instruction.AutoSize = True
        Me.lbl_instruction.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_instruction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_instruction.Location = New System.Drawing.Point(16, 136)
        Me.lbl_instruction.Name = "lbl_instruction"
        Me.lbl_instruction.Size = New System.Drawing.Size(355, 39)
        Me.lbl_instruction.TabIndex = 3
        Me.lbl_instruction.Text = "Please select a location:"
        '
        'lbl_welcome
        '
        Me.lbl_welcome.BackColor = System.Drawing.SystemColors.Control
        Me.lbl_welcome.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_welcome.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_welcome.Location = New System.Drawing.Point(10, 10)
        Me.lbl_welcome.Name = "lbl_welcome"
        Me.lbl_welcome.Size = New System.Drawing.Size(480, 117)
        Me.lbl_welcome.TabIndex = 4
        Me.lbl_welcome.Text = "Welcome to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RFID Station"
        '
        'btn_location1
        '
        Me.btn_location1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_location1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_location1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_location1.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.btn_location1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_location1.Location = New System.Drawing.Point(4, 6)
        Me.btn_location1.Name = "btn_location1"
        Me.btn_location1.Size = New System.Drawing.Size(221, 117)
        Me.btn_location1.TabIndex = 0
        Me.btn_location1.Text = "Johnson Creek"
        Me.btn_location1.UseVisualStyleBackColor = False
        '
        'panel_btn_locations
        '
        Me.panel_btn_locations.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.panel_btn_locations.Controls.Add(Me.btn_location4)
        Me.panel_btn_locations.Controls.Add(Me.btn_location3)
        Me.panel_btn_locations.Controls.Add(Me.btn_location2)
        Me.panel_btn_locations.Controls.Add(Me.btn_location1)
        Me.panel_btn_locations.Location = New System.Drawing.Point(22, 184)
        Me.panel_btn_locations.Name = "panel_btn_locations"
        Me.panel_btn_locations.Size = New System.Drawing.Size(456, 253)
        Me.panel_btn_locations.TabIndex = 5
        '
        'btn_location4
        '
        Me.btn_location4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_location4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_location4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_location4.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.btn_location4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_location4.Location = New System.Drawing.Point(229, 127)
        Me.btn_location4.Name = "btn_location4"
        Me.btn_location4.Size = New System.Drawing.Size(221, 117)
        Me.btn_location4.TabIndex = 3
        Me.btn_location4.Text = "Harley Davidson"
        Me.btn_location4.UseVisualStyleBackColor = False
        '
        'btn_location3
        '
        Me.btn_location3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_location3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_location3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_location3.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.btn_location3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_location3.Location = New System.Drawing.Point(4, 127)
        Me.btn_location3.Name = "btn_location3"
        Me.btn_location3.Size = New System.Drawing.Size(221, 117)
        Me.btn_location3.TabIndex = 2
        Me.btn_location3.Text = "Mercury"
        Me.btn_location3.UseVisualStyleBackColor = False
        '
        'btn_location2
        '
        Me.btn_location2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_location2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_location2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_location2.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.btn_location2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btn_location2.Location = New System.Drawing.Point(229, 6)
        Me.btn_location2.Name = "btn_location2"
        Me.btn_location2.Size = New System.Drawing.Size(221, 117)
        Me.btn_location2.TabIndex = 1
        Me.btn_location2.Text = "Mauston"
        Me.btn_location2.UseVisualStyleBackColor = False
        '
        'Location_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(500, 455)
        Me.Controls.Add(Me.panel_btn_locations)
        Me.Controls.Add(Me.lbl_welcome)
        Me.Controls.Add(Me.lbl_instruction)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Location_Select"
        Me.Text = "Location_Select"
        Me.panel_btn_locations.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_instruction As Label
    Friend WithEvents lbl_welcome As Label
    Friend WithEvents btn_location1 As Button
    Friend WithEvents panel_btn_locations As Panel
    Friend WithEvents btn_location4 As Button
    Friend WithEvents btn_location3 As Button
    Friend WithEvents btn_location2 As Button
End Class
