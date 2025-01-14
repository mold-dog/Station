Public Class Press_History
    Private Sub Press_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Press_History
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub
End Class