Imports System.Data
Imports System.Data.SqlClient
Public Class Carrier_Info
    Public Carrier_Number As Integer

    Private bindingsource1 As New BindingSource
    Private Sub Carrier_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select top 1 carrier_ID, Log_Time, Style_Desc, Color_Desc from (Select Carrier_ID as carrier_ID, paint_load.ID as ID, Log_Time, "
            query = query & "Style.Description as Style_Desc, Paint_Color.Description as Color_Desc from (paint_load left join Paint_Color "
            query = query & "on paint_load.color = paint_Color.PLC_Color and paint_load.log_time between paint_color.start_date and paint_color.end_date) "
            query = query & "left join style on paint_load.style = style.PLC_Style where Carrier_Number = " & Carrier_Number & " union "
            query = query & "Select Carrier_ID as carrier_ID, paint_load_History.ID as ID, Log_Time, Style.Description as Style_Desc, Paint_Color.Description as Color_Desc "
            query = query & "from (Paint_Load_History left join Paint_Color on paint_load_History.color = paint_Color.PLC_Color and paint_load_History.log_time "
            query = query & "between paint_color.start_date and paint_color.end_date) left join style on paint_load_History.style = style.PLC_Style where Carrier_Number = "
            query = query & "" & Carrier_Number & ") as Carrier_ID order by Id desc"
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Paint_Load")
            SQLCon.Close()
            query = ""
            For Each dr As DataRow In ds.Tables("Paint_Load").Rows
                Lbl_Carrier_Number.Text = Carrier_Number
                Lbl_Log_Time.Text = dr("Log_Time") & ""
                Lbl_Color.Text = dr("Color_Desc") & ""
                Lbl_Style.Text = dr("Style_Desc") & ""
                query = "Select Part.RFID as [RFID Tag], Paint_Load_RFID.Log_Time as [Read Time], Final_Color.Description as [Color], Part_Type.Description as [Part Type] From ((Part "
                query = query & " inner join Paint_Load_RFID on Part.RFID = Paint_Load_RFID.RFID) "
                query = query & " Left Join Final_Color on Part.Color = Final_Color.id) Left Join Part_Type on Part.part_Type = Part_Type.id "
                query = query & " Where Paint_Load_RFID.Carrier_ID = " & dr("Carrier_ID")
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Paint Color Info from Database: " & Ex.Message)
        End Try







        If Len(Query) > 0 Then
            bindingsource1.DataSource = GetData(Query)

            DGV_Paint_Data.DataSource = bindingsource1
            DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        End If

        Me.Cursor = Cursors.Default



    End Sub

    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick

        Part_Form = New Part
        Part_Form.RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
        Part_Form.Show()

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
                    Row_String = DGV_Paint_Data.Columns(column).HeaderText
                Else
                    Row_String = Row_String & "," & DGV_Paint_Data.Columns(column).HeaderText
                End If
            Next
            PrintLine(1, Row_String)


            For row = 0 To DGV_Paint_Data.RowCount - 1
                For column = 0 To DGV_Paint_Data.ColumnCount - 1
                    If column = 0 Then
                        Row_String = DGV_Paint_Data.Rows(row).Cells(column).Value
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
End Class