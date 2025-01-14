Imports System.Data
Imports System.Data.SqlClient

Public Class Tag_Compare
    Private bindingsource1 As New BindingSource

    Private Sub Tag_Compare_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Txt_Part_ID_1.Text = Compare_Part_ID_1
        Txt_Part_ID_2.Text = Compare_Part_ID_2

        DGV_Compare.AutoGenerateColumns = True

        Call Update_Screen()


    End Sub

    Private Sub Update_Screen()

        Dim query As String = ""
        Dim table_name As String = ""

        Me.Cursor = Cursors.WaitCursor


        query = "exec RFID_Tag_Compare " & Compare_Part_ID_1 & ", " & Compare_Part_ID_2
        bindingsource1.DataSource = GetData(query)

        DGV_Compare.DataSource = bindingsource1
        DGV_Compare.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Compare.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
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

            For column = 0 To DGV_Compare.ColumnCount - 1
                If column = 0 Then
                    Row_String = DGV_Compare.Columns(column).HeaderText & ""
                Else
                    Row_String = Row_String & "," & DGV_Compare.Columns(column).HeaderText
                End If
            Next
            PrintLine(1, Row_String)


            For row = 0 To DGV_Compare.RowCount - 1
                For column = 0 To DGV_Compare.ColumnCount - 1
                    If column = 0 Then
                        Row_String = DGV_Compare.Rows(row).Cells(column).Value & ""
                    Else
                        Row_String = Row_String & "," & DGV_Compare.Rows(row).Cells(column).Value
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