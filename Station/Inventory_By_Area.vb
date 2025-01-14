
Public Class Inventory_By_Area

    Private Sub Inventory_By_Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usrCntl As New Ctr_Inventory_by_Area
        Me.Panel1.Controls.Add(usrCntl)
        usrCntl.Show()
        If Station_ID = 0 Then
            Me.AutoScroll = True
        End If
    End Sub



End Class