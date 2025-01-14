Imports System.Data
Imports System.Data.SqlClient
Public Class Robot_Part_History
    Private bindingsource1 As New BindingSource

    Private Sub Robot_Part_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Day, -7, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True

    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim table_name As String = ""


        If Cmb_Robot.SelectedIndex < 0 Then
            MsgBox("You must select a valid Robot.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor


        query = "exec Robot_History_Qry " & (Cmb_Robot.SelectedIndex + 1) & ", '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub DGV_Paint_Data_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DGV_Paint_Data.RowPostPaint
        If e.RowIndex < Me.DGV_Paint_Data.RowCount And e.RowIndex > 0 Then
            Dim dgvRow As DataGridViewRow = Me.DGV_Paint_Data.Rows(e.RowIndex)
            Dim dgvRowPrevious As DataGridViewRow = Me.DGV_Paint_Data.Rows(e.RowIndex - 1)

            If dgvRow.Cells(0).Value.ToString <> dgvRowPrevious.Cells(0).Value.ToString Then
                dgvRow.Cells(0).Style.BackColor = Color.LightGray
            Else
                dgvRow.Cells(0).Style.BackColor = Color.White
            End If
            If dgvRow.Cells(1).Value.ToString <> dgvRowPrevious.Cells(1).Value.ToString Then
                dgvRow.Cells(1).Style.BackColor = Color.LightGray
            Else
                dgvRow.Cells(1).Style.BackColor = Color.White
            End If
            If dgvRow.Cells(2).Value.ToString <> dgvRowPrevious.Cells(2).Value.ToString Then
                dgvRow.Cells(2).Style.BackColor = Color.LightGray
            Else
                dgvRow.Cells(2).Style.BackColor = Color.White
            End If
            If dgvRow.Cells(3).Value.ToString <> dgvRowPrevious.Cells(3).Value.ToString Then
                dgvRow.Cells(3).Style.BackColor = Color.LightGray
            Else
                dgvRow.Cells(3).Style.BackColor = Color.White
            End If

        End If

    End Sub


End Class