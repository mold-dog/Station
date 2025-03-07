﻿Imports System.Data
Imports System.Data.SqlClient
Public Class Part_Tracking
    Private bindingsource1 As New BindingSource
    '    Dim ID_Array() As Integer
    Dim Part_ID As Integer = 0

    Public RFID As String
    Private bindingsource_part As New BindingSource

    Private Sub Paint_Data_By_Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DGV_Paint_Data.AutoGenerateColumns = True
        Txt_RFID.Text = RFID
    End Sub



    Private Sub New_Part()
        Dim query As String = ""
        Dim RFID As String = ""

        If Part_ID <= 0 Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor


        query = "Select area.Description, Enter_Time as [Enter Time], Leave_Time as [Leave Time], Door_Reader.Description as [Enter Door] from (Part_Locations inner join area on part_locations.area = area.id) left join door_reader on part_locations.enter_door = door_reader.id where part_locations.part = '" & Part_ID & "' order by enter_time"
        bindingsource1.DataSource = GetData(query)

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

    Private Sub Txt_RFID_TextChanged(sender As Object, e As EventArgs) Handles Txt_RFID.TextChanged
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select ID from Part where rfid = '" & Txt_RFID.Text & "'"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        Part_ID = 0

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_ID = dr("ID")
        Next

        Call New_Part()

    End Sub
End Class