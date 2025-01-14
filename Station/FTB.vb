Public Class FTB
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim usrCntl As New Ctr_FTB
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()

    End Sub
End Class