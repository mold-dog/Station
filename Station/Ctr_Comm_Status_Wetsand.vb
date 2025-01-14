Imports System.Data
Imports System.Data.SqlClient


Public Class Ctr_Comm_Status_Wetsand
    Dim Query As String
    Private bindingsource1 As New BindingSource

    Private Sub Ctr_Comm_Status_Wetsand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Refresh_Grid()
        Call Refresh_Map()

    End Sub

    Private Sub Refresh_Grid()
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Query = "Exec Get_Comm_Alarms"

        bindingsource1.DataSource = GetData(Query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Me.Cursor = Cursors.Default

    End Sub
    Sub Refresh_Map()


        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim daComm_Status As New SqlDataAdapter("Exec Get_Comm_Status", SQLCon)
            daComm_Status.SelectCommand.CommandTimeout = 120
            Dim dsComm_Status As New DataSet
            daComm_Status.Fill(dsComm_Status, "Comm_Status")
            SQLCon.Close()
            For Each drComm_Status As DataRow In dsComm_Status.Tables("Comm_Status").Rows
                If Me.Controls.Find(drComm_Status("Station_code") & "", True).Length > 0 Then
                    Change_Color(Me.Controls(drComm_Status("Station_code") & ""), drComm_Status("Status"))
                End If
            Next

        Catch Ex As Exception

            MsgBox("Error Getting Communications Info from Database: " & Ex.Message)
        End Try
    End Sub

    Private Sub Change_Color(Station As Button, Status As Integer)
        Select Case Status
            Case 0
                Station.BackColor = Color.Green
                Station.Visible = False
            Case 1
                Station.BackColor = Color.Yellow
                Station.Visible = True
            Case 2
                Station.BackColor = Color.Red
                Station.Visible = True
        End Select

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Call Refresh_Grid()
        Call Refresh_Map()

    End Sub
End Class
