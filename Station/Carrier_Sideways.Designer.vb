<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Carrier_Sideways
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Lbl_H_Style = New System.Windows.Forms.Label()
        Me.Lbl_H_Paint = New System.Windows.Forms.Label()
        Me.Lbl_Paint = New System.Windows.Forms.Label()
        Me.Lbl_Quantity = New System.Windows.Forms.Label()
        Me.Lbl_Style = New System.Windows.Forms.Label()
        Me.Lbl_Carrier_Number = New System.Windows.Forms.Label()
        Me.Line_Top = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Line_Middle = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Lbl_H_Style
        '
        Me.Lbl_H_Style.AutoSize = True
        Me.Lbl_H_Style.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_H_Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_H_Style.Location = New System.Drawing.Point(2, 22)
        Me.Lbl_H_Style.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_H_Style.Name = "Lbl_H_Style"
        Me.Lbl_H_Style.Size = New System.Drawing.Size(33, 13)
        Me.Lbl_H_Style.TabIndex = 115
        Me.Lbl_H_Style.Text = "Style:"
        Me.Lbl_H_Style.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_H_Paint
        '
        Me.Lbl_H_Paint.AutoSize = True
        Me.Lbl_H_Paint.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_H_Paint.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_H_Paint.Location = New System.Drawing.Point(1, 34)
        Me.Lbl_H_Paint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_H_Paint.Name = "Lbl_H_Paint"
        Me.Lbl_H_Paint.Size = New System.Drawing.Size(34, 13)
        Me.Lbl_H_Paint.TabIndex = 118
        Me.Lbl_H_Paint.Text = "Paint:"
        Me.Lbl_H_Paint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl_Paint
        '
        Me.Lbl_Paint.AutoSize = True
        Me.Lbl_Paint.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Paint.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Paint.Location = New System.Drawing.Point(31, 34)
        Me.Lbl_Paint.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Paint.Name = "Lbl_Paint"
        Me.Lbl_Paint.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Paint.TabIndex = 117
        Me.Lbl_Paint.Text = "999"
        Me.Lbl_Paint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Quantity
        '
        Me.Lbl_Quantity.AutoSize = True
        Me.Lbl_Quantity.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Quantity.Location = New System.Drawing.Point(31, 3)
        Me.Lbl_Quantity.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Quantity.Name = "Lbl_Quantity"
        Me.Lbl_Quantity.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Quantity.TabIndex = 116
        Me.Lbl_Quantity.Text = "999"
        Me.Lbl_Quantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Style
        '
        Me.Lbl_Style.AutoSize = True
        Me.Lbl_Style.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Style.Location = New System.Drawing.Point(31, 22)
        Me.Lbl_Style.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Style.Name = "Lbl_Style"
        Me.Lbl_Style.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Style.TabIndex = 114
        Me.Lbl_Style.Text = "999"
        Me.Lbl_Style.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Lbl_Carrier_Number
        '
        Me.Lbl_Carrier_Number.AutoSize = True
        Me.Lbl_Carrier_Number.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Carrier_Number.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Carrier_Number.Location = New System.Drawing.Point(5, 3)
        Me.Lbl_Carrier_Number.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Lbl_Carrier_Number.Name = "Lbl_Carrier_Number"
        Me.Lbl_Carrier_Number.Size = New System.Drawing.Size(25, 13)
        Me.Lbl_Carrier_Number.TabIndex = 113
        Me.Lbl_Carrier_Number.Text = "999"
        Me.Lbl_Carrier_Number.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Line_Top
        '
        Me.Line_Top.Name = "Line_Top"
        Me.Line_Top.X1 = 0
        Me.Line_Top.X2 = 56
        Me.Line_Top.Y1 = 20
        Me.Line_Top.Y2 = 20
        '
        'Line_Middle
        '
        Me.Line_Middle.Name = "Line_Middle"
        Me.Line_Middle.X1 = 56
        Me.Line_Middle.X2 = 56
        Me.Line_Middle.Y1 = 9
        Me.Line_Middle.Y2 = 31
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1, Me.Line_Middle, Me.Line_Top})
        Me.ShapeContainer1.Size = New System.Drawing.Size(57, 48)
        Me.ShapeContainer1.TabIndex = 119
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 0
        Me.LineShape1.X2 = 0
        Me.LineShape1.Y1 = 9
        Me.LineShape1.Y2 = 31
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 47)
        Me.Label1.TabIndex = 121
        '
        'Carrier_Sideways
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Lbl_Paint)
        Me.Controls.Add(Me.Lbl_Style)
        Me.Controls.Add(Me.Lbl_H_Style)
        Me.Controls.Add(Me.Lbl_H_Paint)
        Me.Controls.Add(Me.Lbl_Quantity)
        Me.Controls.Add(Me.Lbl_Carrier_Number)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Carrier_Sideways"
        Me.Size = New System.Drawing.Size(57, 48)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_H_Style As Label
    Friend WithEvents Lbl_H_Paint As Label
    Friend WithEvents Lbl_Paint As Label
    Friend WithEvents Lbl_Quantity As Label
    Friend WithEvents Lbl_Style As Label
    Friend WithEvents Lbl_Carrier_Number As Label
    Friend WithEvents Line_Top As PowerPacks.LineShape
    Friend WithEvents Line_Middle As PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As PowerPacks.LineShape

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Friend WithEvents Label1 As Label
End Class
