
Public Class Paint_Current_Run
    Private Sub Paint_Current_Run_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Paint_Current_Run
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub
End Class