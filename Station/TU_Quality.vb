Imports System.Data
Imports System.Data.SqlClient

Public Class TU_Quality


    Private bindingsource1 As New BindingSource
    Public Start_Date As String = ""
    Public End_Date As String = ""

    Private Sub TU_Quality_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        Dim start_time As DateTime
        Dim End_Time As DateTime

        If Len(Start_Date) > 0 Then
            start_time = Start_Date
        Else
            start_time = DateAdd(DateInterval.Hour, -1, Now)
        End If
        If Len(End_Date) > 0 Then
            End_Time = End_Date
        Else
            End_Time = Now
        End If
        Start_Date = ""
        End_Date = ""

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True



    End Sub


    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Call Update_Screen()
    End Sub
    Private Sub Update_Screen()

        Dim query As String = ""
        Dim table_name As String = ""

        Me.Cursor = Cursors.WaitCursor


        query = "exec Touch_Up_Quality '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default

        Call Get_Totals()

        Me.Cursor = Cursors.Default


    End Sub


    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick

        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(1).Value
        Paint_Production_RFID_Query_Form.Show()


    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles Btn_Export.Click
        Dim filename As String = ""
        Dim row As Integer = 0
        Dim column As Integer = 0
        Dim Row_String As String = ""

        Dim returnValue As DialogResult

        Try

            returnValue = SaveFile.ShowDialog
            If returnValue = DialogResult.Cancel Then
                Exit Sub
            End If

            Me.UseWaitCursor = True

            filename = SaveFile.FileName
            FileOpen(1, filename, OpenMode.Output)

            For column = 0 To DGV_Paint_Data.ColumnCount - 1
                If column = 0 Then
                    Row_String = DGV_Paint_Data.Columns(column).HeaderText & ""
                Else
                    Row_String = Row_String & "," & DGV_Paint_Data.Columns(column).HeaderText
                End If
            Next
            PrintLine(1, Row_String)


            For row = 0 To DGV_Paint_Data.RowCount - 1
                For column = 0 To DGV_Paint_Data.ColumnCount - 1
                    If column = 0 Then
                        Row_String = DGV_Paint_Data.Rows(row).Cells(column).Value & ""
                    Else
                        Row_String = Row_String & "," & DGV_Paint_Data.Rows(row).Cells(column).Value
                    End If
                Next
                PrintLine(1, Row_String)
            Next

            FileClose(1)
            MsgBox("Export Completed: " & filename)
        Catch ex As Exception
            MsgBox("Export Failed: " & ex.Message)
        End Try
        Me.UseWaitCursor = False


    End Sub
    Private Sub Get_Totals()
        Dim query_str As String = ""

        query_str = "exec Touch_Up_Quality_Totals '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query_str, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "TU_Quality")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("TU_Quality").Rows
            lbl_Good.Text = dr("good") & ""
            Lbl_Reclear.Text = dr("Reclear") & ""
            Lbl_Reclear_Good.Text = dr("reclear_good") & ""
            Lbl_Rework.Text = dr("rework") & ""
            Lbl_TU.Text = dr("TU") & ""
            Lbl_Not_Rerun.Text = dr("not_rerun") & ""
        Next

    End Sub


End Class