Imports System.Data
Imports System.Data.SqlClient
Public Class Press_Alarm_History
    Dim ID_Array() As Int32


    Dim Query As String
    Private bindingsource1 As New BindingSource


    Private Sub Refresh_Grid()
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Query = "Exec Get_Press_Alarm_History " & ID_Array(Cmb_Press.SelectedIndex) & ", '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"

        bindingsource1.DataSource = GetData(Query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Press_Alarm_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -6, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Combo()
        Call Refresh_Grid()

    End Sub



    Private Sub DGV_Paint_Data_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DGV_Paint_Data.RowPostPaint
        If e.RowIndex < Me.DGV_Paint_Data.RowCount Then
            Dim dgvRow As DataGridViewRow = Me.DGV_Paint_Data.Rows(e.RowIndex)

            Select Case dgvRow.Cells(3).Value.ToString
                Case = "Warning"
                    dgvRow.DefaultCellStyle.BackColor = Color.Orange
                Case = "Fault"
                    dgvRow.DefaultCellStyle.BackColor = Color.Red
                Case Else
                    dgvRow.DefaultCellStyle.BackColor = Color.White
            End Select

        End If

    End Sub


    Sub Load_Combo()

        Dim counter As Integer = 1
        Try
            Cmb_Press.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from press order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Press")
            SQLCon.Close()
            ReDim ID_Array(1)
            Cmb_Press.Items.Add("All Presses")

            For Each dr As DataRow In ds.Tables("Press").Rows
                Cmb_Press.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next

            Cmb_Press.Text = "All Presses"
        Catch Ex As Exception

            MsgBox("Error Getting Press Info from Database: " & Ex.Message)
        End Try
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Call Refresh_Grid()

    End Sub
End Class