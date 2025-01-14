Imports System.Data
Imports System.Data.SqlClient
Public Class TU_Productivity


    Private bindingsource1 As New BindingSource
    Public Start_Date As String = ""
    Public End_Date As String = ""
    Private Query_Type As String = ""

    Private Sub TU_Productivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        If Opt_Booth.Checked = False And Opt_Color.Checked = False And Opt_Run.Checked = False And Opt_By_Day.Checked = False Then
            MsgBox("Please select a query option.")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        If Opt_Booth.Checked Then
            If Query_Type <> "Booth" Then
                DGV_Paint_Data.DataSource = ""
            End If
            query = "exec Touch_Up_Productivity_by_Booth "
            Query_Type = "Booth"
        End If
        If Opt_Color.Checked Then
            If Query_Type <> "Color" Then
                DGV_Paint_Data.DataSource = ""
            End If
            query = "exec Touch_Up_Productivity_by_Color "
            Query_Type = "Color"
        End If
        If Opt_Run.Checked Then
            If Query_Type <> "Run" Then
                DGV_Paint_Data.DataSource = ""
            End If
            query = "exec Touch_Up_Productivity_by_Run "
            Query_Type = "Run"
        End If
        If Opt_By_Day.Checked Then
            If Query_Type <> "Day" Then
                DGV_Paint_Data.DataSource = ""
            End If
            query = "exec Touch_Up_Productivity_by_Day "
            Query_Type = "Day"
        End If

        query = query & " '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        If Query_Type = "Run" Then
            DGV_Paint_Data.Columns(0).Visible = False
        Else
            DGV_Paint_Data.Columns(0).Visible = True
        End If
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default


    End Sub


    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick

        Dim Query As String

        Select Case Query_Type
            Case "Booth"
                Query = "exec Touch_Up_Productivity_by_Booth_Parts '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value & "'"
            Case "Color"
                Query = "exec Touch_Up_Productivity_by_Color_Parts '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value & "'"
            Case "Run"
                Query = "exec Touch_Up_Productivity_by_Run_Parts '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', " & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
            Case "Day"
                Query = "exec Touch_Up_Productivity_by_Day_Parts '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(1).Value & "'"
            Case Else
                Exit Sub

        End Select
        Paint_Production_Parts_Query_Form = New Paint_Production_Parts_Query
        Paint_Production_Parts_Query_Form.Query = Query
        Paint_Production_Parts_Query_Form.Show()


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



End Class