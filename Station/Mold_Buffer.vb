Public Class Mold_Buffer
    Private Sub Mold_Buffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Mold_Buffer
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub
End Class