Public Class FTB_by_Model
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim usrCntl As New Ctr_FTB_by_Model
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()

    End Sub
End Class