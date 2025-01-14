Imports System.Data
Imports System.Data.SqlClient
Public Class Comm_Status_Wetsand
    Private Sub Comm_Status_Wetsand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Comm_Status_Wetsand
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub
End Class