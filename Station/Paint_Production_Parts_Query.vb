Imports System.Data
Imports System.Data.SqlClient
Public Class Paint_Production_Parts_Query
    Public Query As String
    Private bindingsource1 As New BindingSource
    Private Sub Paint_Data_By_Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        If Len(Query) > 0 Then
            bindingsource1.DataSource = GetData(Query)

            DGV_Paint_Data.DataSource = bindingsource1
            DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        End If

        Me.Cursor = Cursors.Default
        Lbl_Record_Count.Text = DGV_Paint_Data.RowCount



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

End Class