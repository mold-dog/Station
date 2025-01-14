Imports System.Data
Imports System.Data.SqlClient
Public Class Press_Produced
    Private bindingsource1 As New BindingSource

    Private Sub Press_Produced_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True


    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim door_readers As String = ""

        Me.Cursor = Cursors.WaitCursor

        If Cbx_By_Hour.Checked Then
            query = "Exec Get_Press_Counts '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        Else
            query = "Exec Get_Press_Counts_Combined '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        End If



        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = Nothing
        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default


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
    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick

        Dim Query As String
        Dim Start_Date As Date
        Dim Start_Time As DateTime
        Dim End_Time As DateTime
        If DGV_Paint_Data.ColumnCount < 9 Then
            Exit Sub
        End If

        Start_Date = DTP_Start_Date.Text
        Start_Time = DTP_Start_Time.Text
        End_Time = DTP_End_Time.Text
        Query = "Select start_time as [Press Cycle Start], RFID, log_time as [RFID Log Time], press_cycle.press_run from press_cycle left join Press_RFID on press_cycle.press_run = Press_RFID.press_run and Press_RFID.press = press_cycle.press "
        Query = Query & "left join Part on Part.ID = Press_RFID.Part_ID Where Press_cycle.press = (select ID from press Where Description = '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value & "') "
        Query = Query & "and DATEPART(YY, Start_Time) = '" & DateAndTime.DatePart(DateInterval.Year, Start_Date) & "' And DATEPART(mm, Start_Time) = '" & DateAndTime.DatePart(DateInterval.Month, Start_Date) & "' "
        Query = Query & "And DATEPART(dd, Start_Time) = '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(1).Value & "' And DATEPART(hh, Start_Time) = '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value & "' "
        If DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value = DateAndTime.DatePart(DateInterval.Hour, End_Time) Then
            Query = Query & "and DATEPART(MI, Start_Time) < '" & DateAndTime.DatePart(DateInterval.Minute, End_Time) & "' "
        ElseIf DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value = DateAndTime.DatePart(DateInterval.Hour, Start_Time) Then
            Query = Query & "and DATEPART(MI, Start_Time) > '" & DateAndTime.DatePart(DateInterval.Minute, Start_Time) & "' "
        ElseIf DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value <> DateAndTime.DatePart(DateInterval.Hour, Start_Time) And DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value <> DateAndTime.DatePart(DateInterval.Hour, End_Time) Then
            Start_Time = "00:00:00"
            Query = Query & "and DATEPART(MI, Start_Time) > '" & DateAndTime.DatePart(DateInterval.Minute, Start_Time) & "' "
        End If


        Paint_Production_Parts_Query_Form = New Paint_Production_Parts_Query
        Paint_Production_Parts_Query_Form.Query = Query
        Paint_Production_Parts_Query_Form.Text = "Press Produced Parts"
        Paint_Production_Parts_Query_Form.Show()


    End Sub

End Class