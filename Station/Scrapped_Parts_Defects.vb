Imports System.Data
Imports System.Data.SqlClient
Public Class Scrapped_Parts_Defects

    Private bindingsource1 As New BindingSource

    Private Sub Scrapped_Parts_Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        AddHandler radbtn_Total.CheckedChanged, AddressOf radbtn_Changed
        AddHandler radbtn_Individual.CheckedChanged, AddressOf radbtn_Changed



    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim door_readers As String = ""
        Dim Last_RFID As String = ""


        Me.Cursor = Cursors.WaitCursor

        'DGV_Paint_Data.SelectAll()
        'DGV_Paint_Data.ClearSelection()
        ' bindingsource1.Clear()



        query = "exec Scrapped_Parts_Defects1 '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', " & IIf(radbtn_Individual.Checked, "1", "0")
        Try
            ' DGV_Paint_Data.Rows.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            'Dim ds As New DataSet
            'da.Fill(ds, "Scrap")
            ' bindingsource1.Clear()
            bindingsource1.DataSource = GetData(query)
            SQLCon.Close()
            'For Each dr As DataRow In ds.Tables("Scrap").Rows
            '    If Last_RFID = dr("RFID") Then
            '        DGV_Paint_Data.Rows.Add("", "", "", "", dr("Defect"), "", "")
            '        DGV_Paint_Data.Rows(DGV_Paint_Data.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGray
            '    Else
            '        DGV_Paint_Data.Rows.Add(dr("RFID"), dr("Part Type"), dr("Color"), dr("Scrap Time"), dr("Defect"), dr("Scrap Origin"), dr("Operator"))
            '        Last_RFID = dr("RFID")
            '    End If

            'Next

        Catch Ex As Exception
            MsgBox("Error Filling Grid: " & Ex.Message)
        End Try



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

    Private Sub radbtn_Changed()

        If radbtn_Individual.Checked Then
            radbtn_Total.Checked = False
        Else
            radbtn_Total.Checked = True
        End If

    End Sub


End Class