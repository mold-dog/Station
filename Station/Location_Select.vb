Public Class Location_Select

    Private borderForm As New Form
    Private Sub splashload() Handles MyBase.Load

        If Not johnson_creek Then
            btn_location1.Visible = False
        End If
        If Not _mauston Then
            btn_location2.Visible = False
        End If

        If ncm_entry Then
            If ncm_entry = 1 Then
                btn_location4.Visible = False
            ElseIf ncm_entry = 2 Then
                btn_location3.Visible = False
            End If
        Else
            btn_location3.Visible = False
            btn_location4.Visible = False
        End If

        AddHandler btn_location1.Click, AddressOf locationselected
        AddHandler btn_location2.Click, AddressOf locationselected
        AddHandler btn_location3.Click, AddressOf locationselected
        AddHandler btn_location4.Click, AddressOf locationselected


        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With
        With borderForm
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .BackColor = Color.Black
            .Opacity = 0.25
            Dim r As Rectangle = Me.Bounds
            r.Inflate(2, 2)
            .Bounds = r
            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
            r = New Rectangle(3, 3, Me.Width - 4, Me.Height - 4)
            .Region.Exclude(RoundedRectangle(r, 48))
            .Show(Me)
        End With

    End Sub

    Private selected_location As String = ""

    Public Property SelectedLocation As String
        Get
            Return selected_location
        End Get
        Set(value As String)
            selected_location = value
        End Set
    End Property


    Private Sub locationselected(sender As Button, e As EventArgs)
        selected_location = sender.Text

        Me.Close()
    End Sub


    Private johnson_creek As Boolean

    Public Property JohnsonCreek As Boolean
        Get
            Return johnson_creek
        End Get
        Set(value As Boolean)
            johnson_creek = value
        End Set
    End Property

    Private _mauston As Boolean

    Public Property Mauston As Boolean
        Get
            Return _mauston
        End Get
        Set(value As Boolean)
            _mauston = value
        End Set
    End Property

    Private ncm_entry As Integer

    Public Property NCMEntry As Integer
        Get
            Return ncm_entry
        End Get
        Set(value As Integer)
            ncm_entry = value
        End Set
    End Property



#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown, lbl_welcome.MouseDown, lbl_instruction.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove, lbl_welcome.MouseMove, lbl_instruction.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
            borderForm.Location = borderForm.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp, lbl_welcome.MouseUp, lbl_instruction.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If



    End Sub

#End Region



    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.Black, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub

End Class