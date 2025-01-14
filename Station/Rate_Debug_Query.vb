Imports System.Data
Imports System.Data.SqlClient
Public Class Rate_Debug_Query
    Dim ID_Array() As Int32


    Dim Query As String
    Private bindingsource1 As New BindingSource


    Private Sub Refresh_Grid()
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Query = "Exec rate_debug_SP 2 , '" & DTP_Start_Date.Text & "'"

        bindingsource1.DataSource = GetData(Query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Rate_Debug_Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -6, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time

        DGV_Paint_Data.AutoGenerateColumns = True


        Call Refresh_Grid()

    End Sub





    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Call Refresh_Grid()

    End Sub
End Class