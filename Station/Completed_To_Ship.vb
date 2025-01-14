
Public Class Completed_To_Ship
    Private Sub Completed_To_Ship_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Completed_To_Ship
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class