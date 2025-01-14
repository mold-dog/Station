<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Carrier
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Line_Middle = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Top = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Bottom = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Lbl_H_Style = New System.Windows.Forms.Label()
        Me.Lbl_H_Paint = New System.Windows.Forms.Label()
        Me.Lbl_Paint = New System.Windows.Forms.Label()
        Me.Lbl_Quantity = New System.Windows.Forms.Label()
        Me.Lbl_Style = New System.Windows.Forms.Label()
        Me.Lbl_Carrier_Number = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Line_Middle
        '
        Me.Line_Middle.Name = "Line_Middle"
        Me.Line_Middle.X1 = 34
        Me.Line_Middle.X2 = 34
        Me.Line_Middle.Y1 = 0
        Me.Line_Middle.Y2 = 42
        '
        'Line_Top
        '
        Me.Line_Top.Name = "Line_Top"
        Me.Line_Top.X1 = 24
        Me.Line_Top.X2 = 45
        Me.Line_Top.Y1 = 0
        Me.Line_Top.Y2 = 0
        '
        'Line_Bottom
        '
        Me.Line_Bottom.Name = "Line_Bottom"
        Me.Line_Bottom.X1 = 24
        Me.Line_Bottom.X2 = 45
        Me.Line_Bottom.Y1 = 43
        Me.Line_Bottom.Y2 = 43
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Line_Bottom, Me.Line_Top, Me.Line_Middle})
        Me.ShapeContainer1.Size = New System.Drawing.Size(62, 44)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'Lbl_H_Style
        '
        Me.Lbl_H_Style.AutoSize = True
        Me.Lbl_H_Style.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_H_Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_H_Style.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_H_Style.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Lbl_H_Style.Location = New System.Drawing.Point(4, 16)
        Me.Lbl_H_Style.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_H_Style.Name = "Lbl_H_Style"
        Me.Lbl_H_Style.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_H_Style.TabIndex = 108
        Me.Lbl_H_Style.Text = "Style:"
        Me.Lbl_H_Style.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Lbl_H_Paint
        '
        Me.Lbl_H_Paint.AutoSize = True
        Me.Lbl_H_Paint.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_H_Paint.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_H_Paint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_H_Paint.Location = New System.Drawing.Point(3, 28)
        Me.Lbl_H_Paint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_H_Paint.Name = "Lbl_H_Paint"
        Me.Lbl_H_Paint.Size = New System.Drawing.Size(34, 13)
        Me.Lbl_H_Paint.TabIndex = 112
        Me.Lbl_H_Paint.Text = "Paint:"
        Me.Lbl_H_Paint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Paint
        '
        Me.Lbl_Paint.AutoSize = True
        Me.Lbl_Paint.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Paint.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Paint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Paint.Location = New System.Drawing.Point(35, 28)
        Me.Lbl_Paint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Paint.Name = "Lbl_Paint"
        Me.Lbl_Paint.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Paint.TabIndex = 111
        Me.Lbl_Paint.Text = "999"
        Me.Lbl_Paint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Quantity
        '
        Me.Lbl_Quantity.AutoSize = True
        Me.Lbl_Quantity.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Quantity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Quantity.Location = New System.Drawing.Point(35, 4)
        Me.Lbl_Quantity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Quantity.Name = "Lbl_Quantity"
        Me.Lbl_Quantity.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Quantity.TabIndex = 109
        Me.Lbl_Quantity.Text = "999"
        Me.Lbl_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Style
        '
        Me.Lbl_Style.AutoSize = True
        Me.Lbl_Style.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Style.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Style.Location = New System.Drawing.Point(35, 16)
        Me.Lbl_Style.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Style.Name = "Lbl_Style"
        Me.Lbl_Style.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Style.TabIndex = 107
        Me.Lbl_Style.Text = "999"
        Me.Lbl_Style.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Carrier_Number
        '
        Me.Lbl_Carrier_Number.AutoSize = True
        Me.Lbl_Carrier_Number.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Carrier_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Carrier_Number.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Lbl_Carrier_Number.Location = New System.Drawing.Point(10, 4)
        Me.Lbl_Carrier_Number.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Carrier_Number.Name = "Lbl_Carrier_Number"
        Me.Lbl_Carrier_Number.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Carrier_Number.TabIndex = 105
        Me.Lbl_Carrier_Number.Text = "999"
        Me.Lbl_Carrier_Number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 40)
        Me.Label1.TabIndex = 113
        '
        'Carrier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Lbl_Paint)
        Me.Controls.Add(Me.Lbl_Quantity)
        Me.Controls.Add(Me.Lbl_Style)
        Me.Controls.Add(Me.Lbl_H_Style)
        Me.Controls.Add(Me.Lbl_H_Paint)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Controls.Add(Me.Lbl_Carrier_Number)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Carrier"
        Me.Size = New System.Drawing.Size(62, 44)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Line_Middle As PowerPacks.LineShape
    Friend WithEvents Line_Top As PowerPacks.LineShape
    Friend WithEvents Line_Bottom As PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents Lbl_H_Style As Label
    Friend WithEvents Lbl_H_Paint As Label
    Friend WithEvents Lbl_Paint As Label
    Friend WithEvents Lbl_Quantity As Label
    Friend WithEvents Lbl_Style As Label
    Friend WithEvents Lbl_Carrier_Number As Label
    Friend WithEvents Label1 As Label
End Class
