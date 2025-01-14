Imports System.Data
Imports System.Data.SqlClient

Public Class FTQ_Summary

    Dim Area_Array() As Int32
    Dim Part_Type_Array() As Int32
    Dim Color_Array() As Int32

    Private bindingsource1 As New BindingSource
    Private Sub FTQ_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Area_Combo()
        Call Load_Part_Type_Combo()
        Call Load_Color_Combo()



    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim table_name As String = ""


        If Cmb_Area.SelectedIndex < 0 Then
            MsgBox("You must select a valid Area.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor


        query = "exec FTQ_Summary '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', " & Area_Array(Cmb_Area.SelectedIndex) & ", " & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", " & Color_Array(Cmb_Color.SelectedIndex)
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

    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick

        Dim Query As String


        Query = "exec FTQ_Summary_Parts '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(1).Value & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value & "'"
        Paint_Production_Parts_Query_Form = New Paint_Production_Parts_Query
        Paint_Production_Parts_Query_Form.Query = Query
        Paint_Production_Parts_Query_Form.Show()


    End Sub

    Sub Load_Area_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from functional_area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim Area_Array(0)
            Area_Array(counter) = 0
            Cmb_Area.Items.Add("All Areas")
            counter += 1
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr("ID")
                counter += 1
            Next
            Cmb_Area.Text = "All Areas"


        Catch Ex As Exception

            MsgBox("Error Getting Functional Area Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Part_Type_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Part_Type.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from part_type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            ReDim Part_Type_Array(0)
            Part_Type_Array(counter) = 0
            Cmb_Part_Type.Items.Add("All Part Types")
            counter += 1
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Part_Type.Items.Add(dr("Description"))
                ReDim Preserve Part_Type_Array(counter)
                Part_Type_Array(counter) = dr("ID")
                counter += 1
            Next
            Cmb_Part_Type.Text = "All Part Types"


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Color_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Color.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from final_color where getdate() between start_date and end_date order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Color")
            SQLCon.Close()
            ReDim Color_Array(0)
            Color_Array(counter) = 0
            Cmb_Color.Items.Add("All Colors")
            counter += 1
            For Each dr As DataRow In ds.Tables("Color").Rows
                Cmb_Color.Items.Add(dr("Description"))
                ReDim Preserve Color_Array(counter)
                Color_Array(counter) = dr("ID")
                counter += 1
            Next

            Cmb_Color.Text = "All Colors"


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub

End Class