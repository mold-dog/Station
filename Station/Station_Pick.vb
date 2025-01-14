Imports System.Data
Imports System.Data.SqlClient
Public Class Station_Pick
    Public RFID As String
    Private bindingsource1 As New BindingSource
    Private Sub Station_Pick_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Call Refresh_Data()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cmd_Refresh_Click(sender As Object, e As EventArgs) Handles Cmd_Refresh.Click

        Call Refresh_Data()
    End Sub

    Private Sub Refresh_Data()
        If PLC_Station > 0 Then
            bindingsource1.DataSource = GetData("Execute Find_Station_Parts " & PLC_Station)

            DGV_Paint_Data.DataSource = bindingsource1
            DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        End If

    End Sub

    Private Sub Refresh_Timer_Tick(sender As Object, e As EventArgs) Handles Refresh_Timer.Tick
        Call Refresh_Data()

    End Sub

    Private Sub DGV_Paint_Data_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Paint_Data.CellContentClick
        Global_RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
        Me.Close()

    End Sub

    Private Sub DGV_Paint_Data_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseClick
        Global_RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
        Me.Close()

    End Sub
End Class