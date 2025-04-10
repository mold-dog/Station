Imports System.Data
Imports System.Data.SqlClient
Public Class Location_Corrections
    Private bindingsource1 As New BindingSource
    Private Sub Location_Corrections_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim table_name As String = ""


        Me.Cursor = Cursors.WaitCursor


        query = "Select RFID, [Part Type], [Original Location], [Correct Location], [Station], [Time] From (Select part.rfid as RFID, part_type.description as [Part Type], from_area.description "
        query = query & "as [Original Location], to_area.description as [Correct Location], station.Description as  [Station], location_Corrections.update_time as [Time] From "
        query = query & "((((location_corrections inner join part on location_corrections.part = part.id) inner join station on Location_Corrections.station = station.PLC_Station_Number And "
        query = query & "station.id Not in (9,170)) Left join area as from_area on Location_Corrections.Old_Area = from_area.id) left join area as to_area on Location_Corrections.new_Area "
        query = query & "= to_area.id) Left join part_Type on part.part_type = part_type.id where Location_Corrections.Update_Time between "
        query = query & "'" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' union "
        query = query & "Select part_History.rfid as RFID, part_type.description as [Part Type], from_area.description as [Original Location], to_area.description as [Correct Location], "
        query = query & "station.Description as  [Station], location_Corrections.update_time as [Time] From ((((location_corrections inner join part_History on location_corrections.part "
        query = query & "= part_History.id) inner join station on Location_Corrections.station = station.PLC_Station_Number And station.id Not in (9,170)) Left join area as from_area "
        query = query & "on Location_Corrections.Old_Area = from_area.id) left join area as to_area on Location_Corrections.new_Area = to_area.id) "
        query = query & "Left join part_Type on part_History.part_type = part_type.id where Location_Corrections.Update_Time between "
        query = query & "'" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' union "
        query = query & "Select part.rfid as RFID, part_type.description as [Part Type], from_area.description as [Original Location], to_area.description as [Correct Location], "
        query = query & "station.Description as  [Station], location_Corrections_History.update_time as [Time] From ((((location_corrections_History inner join part on location_corrections_History.part "
        query = query & "= part.id) inner join station on Location_Corrections_History.station = station.PLC_Station_Number And station.id Not in (9,170)) Left join area as from_area "
        query = query & "on Location_Corrections_History.Old_Area = from_area.id) left join area as to_area on Location_Corrections_History.new_Area = to_area.id) "
        query = query & "Left join part_Type on part.part_type = part_type.id where Location_Corrections_History.Update_Time between "
        query = query & "'" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' union "
        query = query & "Select part_History.rfid as RFID, part_type.description as [Part Type], from_area.description as [Original Location], to_area.description as [Correct Location], "
        query = query & "station.Description as  [Station], location_Corrections_History.update_time as [Time] From ((((location_corrections_History inner join part_History on location_corrections_History.part "
        query = query & "= part_History.id) inner join station on Location_Corrections_History.station = station.PLC_Station_Number And station.id Not in (9,170)) Left join area as from_area "
        query = query & "on Location_Corrections_History.Old_Area = from_area.id) left join area as to_area on Location_Corrections_History.new_Area = to_area.id) "
        query = query & "Left join part_Type on part_History.part_type = part_type.id where Location_Corrections_History.Update_Time between "
        query = query & "'" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' ) as corrections order by [Time]"


        'query = "Select part.rfid as RFID, part_type.description as [Part Type], from_area.description as [Original Location], to_area.description as [Correct Location], "
        'query = query & "station.Description as  [Station], location_Corrections.update_time as [Time] "
        'query = query & " From ((((location_corrections inner join part on location_corrections.part = part.id)"
        'query = query & " inner join station on Location_Corrections.station = station.PLC_Station_Number And station.id Not in (9,170))"
        'query = query & " Left join area as from_area on Location_Corrections.Old_Area = from_area.id) left join area as to_area on Location_Corrections.new_Area = to_area.id)"
        'query = query & " Left join part_Type on part.part_type = part_type.id where Location_Corrections.Update_Time between "
        'query = query & "'" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        'query = query & " order by Location_Corrections.Update_Time"
        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default


    End Sub




    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick

        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
        Paint_Production_RFID_Query_Form.Show()


    End Sub



End Class