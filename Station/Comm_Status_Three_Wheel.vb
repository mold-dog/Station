﻿
Public Class Comm_Status_Three_Wheel
    Private Sub Comm_Status_Three_Wheel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Comm_Status_Three_Wheel
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If

    End Sub
End Class