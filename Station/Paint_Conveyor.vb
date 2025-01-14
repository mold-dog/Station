Imports System.Data.SqlClient
Public Class Paint_Conveyor
    Private Sub Paint_Conveyor_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim usrCntl As New Ctr_Paint_Conveyor
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub
End Class