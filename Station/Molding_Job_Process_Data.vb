Imports System.Data
Imports System.Data.SqlClient

Public Class Molding_Job_Process_Data
    Private bindingsource1 As New BindingSource
    Public RFID As String = ""
    Private bindingsource_part As New BindingSource
    Dim Part_ID As Integer = 0


    Private Sub Molding_Data_By_Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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


        query = "EXEC Molding_Job '" & Txt_RFID.Text & "'"
        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        DGV_Paint_Data.Columns(4).DefaultCellStyle.Format = "MM/dd/yy H:mm:ss:ms"
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
        Dim Query2 As String
        Dim row_num As Integer

        lblUser1.Visible = False
        lblUser2.Visible = False
        lblUser3.Visible = False
        lblUser4.Visible = False
        lblUser5.Visible = False
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select ID from (Select ID from Part where rfid = '" & Txt_RFID.Text & "' union Select ID from Part_History where rfid = '" & Txt_RFID.Text & "') as part_id"

            Query2 = "Select Name, Min(Press_Cycle_5_Sec_Data.rec_time) from Press_Users inner join press_RFID on Press_RFID.Press = press_users.press "
            Query2 = Query2 & "inner join Press_Cycle_5_Sec_Data on Press_RFID.press = Press_Cycle_5_Sec_Data.press and Press_RFID.press_Run = Press_Cycle_5_Sec_Data.press_Run "
            Query2 = Query2 & "inner join Operator on Operator.id = Press_Users.operator "
            Query2 = Query2 & "Where (Press_RFID.part_id = (Select ID from part where RFID = '" & Txt_RFID.Text & "')) "
            Query2 = Query2 & "and (Press_Cycle_5_Sec_Data.rec_time between Press_Users.Start_Time And iif(Press_Users.End_Time Is Null, GetDate(), Press_Users.End_Time)) "
            Query2 = Query2 & "Group by Name"


            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part")
            Dim daOperators As New SqlDataAdapter(Query2, SQLCon)
            daOperators.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsOperators As New DataSet
            daOperators.Fill(dsOperators, "Operator")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Part").Rows
                Part_ID = dr("ID")
            Next
            row_num = 1
            For Each dr As DataRow In dsOperators.Tables("Operator").Rows
                Controls("lblUser" & row_num).Visible = True
                Controls("lblUser" & row_num).Text = dr("Name")
                row_num += 1
            Next
        Catch Ex As Exception
            MsgBox("User Query Failed: " & ex.Message)
        End Try
        'Part_ID = 0



        Call New_Part()

    End Sub


End Class