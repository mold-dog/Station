Public Class Carrier

    Public Property Carrier_Number As Integer
        Get
            Return Lbl_Carrier_Number.Text & ""
        End Get
        Set(value As Integer)
            Lbl_Carrier_Number.Text = value & ""
        End Set
    End Property

    Public Property Quantity As Integer
        Get
            Return Lbl_Quantity.Text & ""
        End Get
        Set(value As Integer)
            Lbl_Quantity.Text = value & ""
        End Set
    End Property

    Public Property Paint_Color As String
        Get
            Return Lbl_Paint.Text & ""
        End Get
        Set(value As String)
            Lbl_Paint.Text = value & ""
        End Set
    End Property

    Public Property Style As String
        Get
            Return Lbl_Style.Text & ""
        End Get
        Set(value As String)
            Lbl_Style.Text = value & ""
        End Set
    End Property

    Private Sub Open_Carrier_Info()
        Carrier_Info_Form = New Carrier_Info
        Carrier_Info_Form.Carrier_Number = Carrier_Number
        Carrier_Info_Form.Show()
    End Sub


    Private Sub Label1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Label1.MouseDoubleClick
        Call Open_Carrier_Info()
    End Sub

    Private Sub Lbl_Quantity_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Quantity.DoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Lbl_Carrier_Number_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Carrier_Number.DoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Lbl_H_Paint_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_H_Paint.DoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Lbl_H_Style_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_H_Style.DoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Lbl_Paint_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Paint.DoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Lbl_Style_DoubleClick(sender As Object, e As EventArgs) Handles Lbl_Style.DoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Line_Bottom_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Line_Bottom.MouseDoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Line_Middle_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Line_Middle.MouseDoubleClick
        Call Open_Carrier_Info()

    End Sub

    Private Sub Line_Top_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Line_Top.MouseDoubleClick
        Call Open_Carrier_Info()

    End Sub
End Class
