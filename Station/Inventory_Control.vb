Imports System.Data
Imports System.Data.SqlClient
Public Class Inventory_Control
    Private bindingsource1 As New BindingSource
    Dim ID_Array() As Int32

    Private Sub Inventory_Control_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Combo()

    End Sub
    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from area where shipped = 1 or scrap = 1 or [Exit] = 1 order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try



    End Sub
    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim reader_names As String = ""
        Dim door_readers As String = ""
        Dim door_readers_History As String = ""

        If Cmb_Area.SelectedIndex < 0 Then
            MsgBox("Please select a valid area.")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        If Opt_Totals.Checked Then
            '            query = "Select Part_Type.Description as [Part Type], Final_Color.Description as [Color], Count(Part.RFID) as [Quantity] from ((Part_Locations "
            '            query = query & " inner join Part on Part_Locations.Part = Part.id) left join Part_Type on Part.Part_Type = Part_Type.id)"
            '            query = query & " left join Final_Color on Part.Color = Final_Color.Id"
            '            query = query & " where (Part_Locations.Enter_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "')"
            '            query = query & " and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ") "
            '            query = query & " Group by Part_Type.Description, Final_Color.Description order by Part_Type.Description, Final_Color.Description"
            'SUM(IIF(part.Last_Reader = 12,1,0)) as [Ship - East]

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select id, description from door_reader where to_area = " & ID_Array(Cmb_Area.SelectedIndex), SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "door_reader")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("door_reader").Rows
                reader_names = reader_names & ", SUM([" & dr("Description") & "]) as [" & dr("Description") & "]"
                door_readers = door_readers & ", SUM(IIF(part.Last_Reader = " & dr("ID") & ",1,0)) as [" & dr("Description") & "]"
                door_readers_History = door_readers_History & ", SUM(IIF(part_history.Last_Reader = " & dr("ID") & ",1,0)) as [" & dr("Description") & "]"
            Next
            If ID_Array(Cmb_Area.SelectedIndex) = 9 Then
                reader_names = reader_names & ", SUM([Press 663]) as [Press 663], SUM([Press 007]) as [Press 007], SUM([Press 747]) as [Press 747]"
                reader_names = reader_names & ", SUM([Press 23]) as [Press 23], SUM([Press 7]) as [Press 7], SUM([Press 8]) as [Press 8]"
                reader_names = reader_names & ", SUM([Press 17]) as [Press 17], SUM([Press 18]) as [Press 18]"
                door_readers = door_readers & ", SUM(IIF(part.Last_Reader = 180,1,0)) as [Press 663], SUM(IIF(part.Last_Reader = 181,1,0)) as [Press 007]"
                door_readers = door_readers & ", SUM(IIF(part.Last_Reader = 182,1,0)) as [Press 747], SUM(IIF(part.Last_Reader = 183,1,0)) as [Press 23]"
                door_readers = door_readers & ", SUM(IIF(part.Last_Reader = 184,1,0)) as [Press 7], SUM(IIF(part.Last_Reader = 185,1,0)) as [Press 8]"
                door_readers = door_readers & ", SUM(IIF(part.Last_Reader = 186,1,0)) as [Press 17], SUM(IIF(part.Last_Reader = 187,1,0)) as [Press 18]"
                door_readers_History = door_readers_History & ", SUM(IIF(part_History.Last_Reader = 180,1,0)) as [Press 663], SUM(IIF(part_History.Last_Reader = 181,1,0)) as [Press 007]"
                door_readers_History = door_readers_History & ", SUM(IIF(part_History.Last_Reader = 182,1,0)) as [Press 747], SUM(IIF(part_History.Last_Reader = 183,1,0)) as [Press 23]"
                door_readers_History = door_readers_History & ", SUM(IIF(part_History.Last_Reader = 184,1,0)) as [Press 7], SUM(IIF(part_History.Last_Reader = 185,1,0)) as [Press 8]"
                door_readers_History = door_readers_History & ", SUM(IIF(part_History.Last_Reader = 186,1,0)) as [Press 17], SUM(IIF(part_History.Last_Reader = 187,1,0)) as [Press 18]"
            End If
            query = "Select [Part Type], [Color]" & reader_names & " , Sum([Total]) as [Total] from (Select Part_Type.Description as [Part Type], Final_Color.Description as [Color]" & door_readers & ", "
            query = query & "Count(Part.RFID) as [Total] from ((Part_Locations inner join Part on Part_Locations.Part = Part.id) left join Part_Type on Part.Part_Type = Part_Type.id) "
            query = query & "left join Final_Color on Part.Color = Final_Color.Id"
            query = query & " where (Part_Locations.Enter_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "')"
            query = query & " and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ") "
            query = query & "Group by Part_Type.Description, Final_Color.Description union "
            query = query & "Select Part_Type.Description as [Part Type], Final_Color.Description as [Color]" & door_readers_History & ", Count(Part_History.RFID) as [Total] from "
            query = query & "((Part_Locations inner join Part_History on Part_Locations.Part = Part_History.id) left join Part_Type on Part_History.Part_Type = Part_Type.id) "
            query = query & "left join Final_Color on Part_History.Color = Final_Color.Id where (Part_Locations.Enter_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' "
            query = query & "and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "') and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ")  "
            query = query & "Group by Part_Type.Description, Final_Color.Description) as parts Group by [Part Type], [Color] order by [Part Type], [Color]"
        Else
            query = "Select [RFID], [Part Type], [Color], [Time] from (Select Part.RFID As [RFID], Part_Type.Description As [Part Type], Final_Color.Description As [Color], "
            query = query & "Part_Locations.Enter_Time As [Time] from ((Part_Locations inner join Part On Part_Locations.Part = Part.id) left join Part_Type On Part.Part_Type = Part_Type.id) "
            query = query & "left join Final_Color On Part.Color = Final_Color.Id where (Part_Locations.Enter_Time "
            query = query & "between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "') "
            query = query & "and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ") union Select Part_History.RFID As [RFID], "
            query = query & "Part_Type.Description As [Part Type], Final_Color.Description As [Color], Part_Locations.Enter_Time As [Time] from ((Part_Locations inner join "
            query = query & "Part_History On Part_Locations.Part = Part_History.id) left join Part_Type On Part_History.Part_Type = Part_Type.id) left join Final_Color "
            query = query & "On Part_History.Color = Final_Color.Id where (Part_Locations.Enter_Time "
            query = query & "between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "') "
            query = query & "and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ")) as parts order by [Time]"


            '    query = "Select Part_Type.Description As [Part Type], Final_Color.Description As [Color]" & door_readers & ", Count(Part.RFID) As [Total] from ((Part_Locations "
            '    query = query & " inner join Part On Part_Locations.Part = Part.id) left join Part_Type On Part.Part_Type = Part_Type.id)"
            '    query = query & " left join Final_Color On Part.Color = Final_Color.Id"
            '    query = query & " where (Part_Locations.Enter_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "')"
            '    query = query & " and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ") "
            '    query = query & " Group by Part_Type.Description, Final_Color.Description order by Part_Type.Description, Final_Color.Description"
            'Else
            '    query = "Select Part.RFID as [RFID], Part_Type.Description as [Part Type], Final_Color.Description as [Color], Part_Locations.Enter_Time as [Time] from ((Part_Locations "
            '    query = query & " inner join Part on Part_Locations.Part = Part.id) left join Part_Type on Part.Part_Type = Part_Type.id)"
            '    query = query & " left join Final_Color on Part.Color = Final_Color.Id"
            '    query = query & " where (Part_Locations.Enter_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "')"
            '    query = query & " and (Part_Locations.Leave_Time is null) and (Part_Locations.Area = " & ID_Array(Cmb_Area.SelectedIndex) & ") order by Part_Locations.Enter_Time"

        End If


        If ID_Array(Cmb_Area.SelectedIndex) = 9 And Opt_Individual.Checked Then
            query = "exec Scrapped_Parts_Defects1 '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', " & IIf(Opt_Individual.Checked, "1", "0")
            bindingsource1.DataSource = GetData(query)
        Else
            bindingsource1.DataSource = GetData(query)
        End If


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

        If DGV_Paint_Data.Columns(2).HeaderText = "RFID" Then
            Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
            Paint_Production_RFID_Query_Form.RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value
            Paint_Production_RFID_Query_Form.Show()
        End If
        If DGV_Paint_Data.Columns(0).HeaderText = "RFID" Then
            Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
            Paint_Production_RFID_Query_Form.RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
            Paint_Production_RFID_Query_Form.Show()
        End If

    End Sub
End Class