Imports System.Data.SqlClient
Public Class Shifts
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Area_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Area.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Area.Visible = False
        Cmb_Area.Visible = True
        DTP_Monday_Start_Time.Enabled = True
        DTP_Monday_End_Time.Enabled = True
        DTP_Tuesday_Start_Time.Enabled = True
        DTP_Tuesday_End_Time.Enabled = True
        DTP_Wednesday_Start_Time.Enabled = True
        DTP_Wednesday_End_Time.Enabled = True
        DTP_Thursday_Start_Time.Enabled = True
        DTP_Thursday_End_Time.Enabled = True
        DTP_Friday_Start_Time.Enabled = True
        DTP_Friday_End_Time.Enabled = True
        DTP_Saturday_Start_Time.Enabled = True
        DTP_Saturday_End_Time.Enabled = True
        DTP_Sunday_Start_Time.Enabled = True
        DTP_Sunday_End_Time.Enabled = True
        Txt_Shift.Enabled = True


        DTP_Monday_Start_Time.Text = "00:00:00"
        DTP_Monday_End_Time.Text = "00:00:00"
        DTP_Tuesday_Start_Time.Text = "00:00:00"
        DTP_Tuesday_End_Time.Text = "00:00:00"
        DTP_Wednesday_Start_Time.Text = "00:00:00"
        DTP_Wednesday_End_Time.Text = "00:00:00"
        DTP_Thursday_Start_Time.Text = "00:00:00"
        DTP_Thursday_End_Time.Text = "00:00:00"
        DTP_Friday_Start_Time.Text = "00:00:00"
        DTP_Friday_End_Time.Text = "00:00:00"
        DTP_Saturday_Start_Time.Text = "00:00:00"
        DTP_Saturday_End_Time.Text = "00:00:00"
        DTP_Sunday_Start_Time.Text = "00:00:00"
        DTP_Sunday_End_Time.Text = "00:00:00"

        Cbx_Monday.Checked = False
        Cbx_Tuesday.Checked = False
        Cbx_Wednesday.Checked = False
        Cbx_Thursday.Checked = False
        Cbx_Friday.Checked = False
        Cbx_Saturday.Checked = False
        Cbx_Sunday.Checked = False

        Cbx_Monday.Enabled = True
        Cbx_Tuesday.Enabled = True
        Cbx_Wednesday.Enabled = True
        Cbx_Thursday.Enabled = True
        Cbx_Friday.Enabled = True
        Cbx_Saturday.Enabled = True
        Cbx_Sunday.Enabled = True

        Adding = True


    End Sub

    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Area.Visible = False
        Cmb_Area.Visible = True
        Txt_Description.Text = Cmb_Description.Text
        Cmb_Area.Text = txt_Area.Text

        DTP_Monday_Start_Time.Enabled = True
        DTP_Monday_End_Time.Enabled = True
        DTP_Tuesday_Start_Time.Enabled = True
        DTP_Tuesday_End_Time.Enabled = True
        DTP_Wednesday_Start_Time.Enabled = True
        DTP_Wednesday_End_Time.Enabled = True
        DTP_Thursday_Start_Time.Enabled = True
        DTP_Thursday_End_Time.Enabled = True
        DTP_Friday_Start_Time.Enabled = True
        DTP_Friday_End_Time.Enabled = True
        DTP_Saturday_Start_Time.Enabled = True
        DTP_Saturday_End_Time.Enabled = True
        DTP_Sunday_Start_Time.Enabled = True
        DTP_Sunday_End_Time.Enabled = True
        Txt_Shift.Enabled = True

        Cbx_Monday.Enabled = True
        Cbx_Tuesday.Enabled = True
        Cbx_Wednesday.Enabled = True
        Cbx_Thursday.Enabled = True
        Cbx_Friday.Enabled = True
        Cbx_Saturday.Enabled = True
        Cbx_Sunday.Enabled = True



        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        Dim query2 As String = ""
        'Check for Valid Data




        If Adding Then
            query = "Insert into shift (description, area, Shift, Start_Time, End_Time) "
            query = query & " values ('" & Txt_Description.Text & "', " & Area_Array(Cmb_Area.SelectedIndex) & ", " & Txt_Shift.Text & ", '" & DTP_Monday_Start_Time.Text & "', '"
            query = query & DTP_Monday_End_Time.Text & "')"

            query2 = "Insert into Continuous_Operation_Shifts (Description, Area, Shift, Monday, Monday_Start_Time, Monday_End_Time, Tuesday, Tuesday_Start_Time, Tuesday_End_Time, "
            query2 = query2 & "Wednesday, Wednesday_Start_Time, Wednesday_End_Time, Thursday, Thursday_Start_Time, Thursday_End_Time, Friday, Friday_Start_Time, Friday_End_Time, "
            query2 = query2 & "Saturday, Saturday_Start_Time, Saturday_End_Time, Sunday, Sunday_Start_Time, Sunday_End_Time) "
            query2 = query2 & " values ('" & Txt_Description.Text & "', " & Area_Array(Cmb_Area.SelectedIndex) & ", '" & Txt_Shift.Text & "', '" & Cbx_Monday.Checked & "', '"
            query2 = query2 & DTP_Monday_Start_Time.Text & "', '" & DTP_Monday_End_Time.Text & "', '"
            query2 = query2 & Cbx_Tuesday.Checked & "', '" & DTP_Tuesday_Start_Time.Text & "', '" & DTP_Tuesday_End_Time.Text & "', '"
            query2 = query2 & Cbx_Wednesday.Checked & "', '" & DTP_Wednesday_Start_Time.Text & "', '" & DTP_Wednesday_End_Time.Text & "', '"
            query2 = query2 & Cbx_Thursday.Checked & "', '" & DTP_Thursday_Start_Time.Text & "', '" & DTP_Thursday_End_Time.Text & "', '"
            query2 = query2 & Cbx_Friday.Checked & "', '" & DTP_Friday_Start_Time.Text & "', '" & DTP_Friday_End_Time.Text & "', '"
            query2 = query2 & Cbx_Saturday.Checked & "', '" & DTP_Saturday_Start_Time.Text & "', '" & DTP_Saturday_End_Time.Text & "', '"
            query2 = query2 & Cbx_Sunday.Checked & "', '" & DTP_Sunday_Start_Time.Text & "', '" & DTP_Sunday_End_Time.Text & "')"

        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update shift Set description = '" & Txt_Description.Text & "', area = " & Area_Array(Cmb_Area.SelectedIndex) & ", shift = " & Val(Txt_Shift.Text) & ", "
            query = query & "Start_Time = '" & DTP_Monday_Start_Time.Text & "', end_Time = '" & DTP_Monday_End_Time.Text & "' where id = " & ID_Array(Cmb_Description.SelectedIndex)

            query2 = "update Continuous_Operation_Shifts Set description = '" & Txt_Description.Text & "', area = " & Area_Array(Cmb_Area.SelectedIndex) & ", shift = '" & Txt_Shift.Text & "', "
            query2 = query2 & "Monday = '" & Cbx_Monday.Checked & "', Monday_Start_Time = '" & DTP_Monday_Start_Time.Text & "', Monday_End_Time = '" & DTP_Monday_End_Time.Text & "', "
            query2 = query2 & "Tuesday = '" & Cbx_Tuesday.Checked & "', Tuesday_Start_Time = '" & DTP_Tuesday_Start_Time.Text & "', Tuesday_End_Time = '" & DTP_Tuesday_End_Time.Text & "', "
            query2 = query2 & "Wednesday = '" & Cbx_Wednesday.Checked & "', Wednesday_Start_Time = '" & DTP_Wednesday_Start_Time.Text & "', Wednesday_End_Time = '" & DTP_Wednesday_End_Time.Text & "', "
            query2 = query2 & "Thursday = '" & Cbx_Thursday.Checked & "', Thursday_Start_Time = '" & DTP_Thursday_Start_Time.Text & "', Thursday_End_Time = '" & DTP_Thursday_End_Time.Text & "', "
            query2 = query2 & "Friday = '" & Cbx_Friday.Checked & "', Friday_Start_Time = '" & DTP_Friday_Start_Time.Text & "', Friday_End_Time = '" & DTP_Friday_End_Time.Text & "', "
            query2 = query2 & "Saturday = '" & Cbx_Saturday.Checked & "', Saturday_Start_Time = '" & DTP_Saturday_Start_Time.Text & "', Saturday_End_Time = '" & DTP_Saturday_End_Time.Text & "', "
            query2 = query2 & "Sunday = '" & Cbx_Sunday.Checked & "', Sunday_Start_Time = '" & DTP_Sunday_Start_Time.Text & "', Sunday_End_Time = '" & DTP_Sunday_End_Time.Text & "' where id = " & ID_Array(Cmb_Description.SelectedIndex)
        End If

        SQLCon.Open()
        Dim cmd As New SqlCommand(query2, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

        Cmb_Description.Visible = True
        Txt_Description.Visible = False
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Area.Visible = True
        Cmb_Area.Visible = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Area.Text = ""
        Txt_Shift.Enabled = False
        DTP_Monday_Start_Time.Enabled = False
        DTP_Monday_End_Time.Enabled = False
        DTP_Tuesday_Start_Time.Enabled = False
        DTP_Tuesday_End_Time.Enabled = False
        DTP_Wednesday_Start_Time.Enabled = False
        DTP_Wednesday_End_Time.Enabled = False
        DTP_Thursday_Start_Time.Enabled = False
        DTP_Thursday_End_Time.Enabled = False
        DTP_Friday_Start_Time.Enabled = False
        DTP_Friday_End_Time.Enabled = False
        DTP_Saturday_Start_Time.Enabled = False
        DTP_Saturday_End_Time.Enabled = False
        DTP_Sunday_Start_Time.Enabled = False
        DTP_Sunday_End_Time.Enabled = False

        Txt_Shift.Text = ""
        DTP_Monday_Start_Time.Text = "00:00:00"
        DTP_Monday_End_Time.Text = "00:00:00"
        DTP_Tuesday_Start_Time.Text = "00:00:00"
        DTP_Tuesday_End_Time.Text = "00:00:00"
        DTP_Wednesday_Start_Time.Text = "00:00:00"
        DTP_Wednesday_End_Time.Text = "00:00:00"
        DTP_Thursday_Start_Time.Text = "00:00:00"
        DTP_Thursday_End_Time.Text = "00:00:00"
        DTP_Friday_Start_Time.Text = "00:00:00"
        DTP_Friday_End_Time.Text = "00:00:00"
        DTP_Saturday_Start_Time.Text = "00:00:00"
        DTP_Saturday_End_Time.Text = "00:00:00"
        DTP_Sunday_Start_Time.Text = "00:00:00"
        DTP_Sunday_End_Time.Text = "00:00:00"

        Cbx_Monday.Checked = False
        Cbx_Tuesday.Checked = False
        Cbx_Wednesday.Checked = False
        Cbx_Thursday.Checked = False
        Cbx_Friday.Checked = False
        Cbx_Saturday.Checked = False
        Cbx_Sunday.Checked = False

        Cbx_Monday.Enabled = False
        Cbx_Tuesday.Enabled = False
        Cbx_Wednesday.Enabled = False
        Cbx_Thursday.Enabled = False
        Cbx_Friday.Enabled = False
        Cbx_Saturday.Enabled = False
        Cbx_Sunday.Enabled = False

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        txt_Area.Visible = True
        Cmb_Area.Visible = False
        txt_Area.Text = ""

        Txt_Shift.Enabled = False
        DTP_Monday_Start_Time.Enabled = False
        DTP_Monday_End_Time.Enabled = False
        DTP_Tuesday_Start_Time.Enabled = False
        DTP_Tuesday_End_Time.Enabled = False
        DTP_Wednesday_Start_Time.Enabled = False
        DTP_Wednesday_End_Time.Enabled = False
        DTP_Thursday_Start_Time.Enabled = False
        DTP_Thursday_End_Time.Enabled = False
        DTP_Friday_Start_Time.Enabled = False
        DTP_Friday_End_Time.Enabled = False
        DTP_Saturday_Start_Time.Enabled = False
        DTP_Saturday_End_Time.Enabled = False
        DTP_Sunday_Start_Time.Enabled = False
        DTP_Sunday_End_Time.Enabled = False

        Txt_Shift.Text = ""
        DTP_Monday_Start_Time.Text = "00:00:00"
        DTP_Monday_End_Time.Text = "00:00:00"
        DTP_Tuesday_Start_Time.Text = "00:00:00"
        DTP_Tuesday_End_Time.Text = "00:00:00"
        DTP_Wednesday_Start_Time.Text = "00:00:00"
        DTP_Wednesday_End_Time.Text = "00:00:00"
        DTP_Thursday_Start_Time.Text = "00:00:00"
        DTP_Thursday_End_Time.Text = "00:00:00"
        DTP_Friday_Start_Time.Text = "00:00:00"
        DTP_Friday_End_Time.Text = "00:00:00"
        DTP_Saturday_Start_Time.Text = "00:00:00"
        DTP_Saturday_End_Time.Text = "00:00:00"
        DTP_Sunday_Start_Time.Text = "00:00:00"
        DTP_Sunday_End_Time.Text = "00:00:00"
        Cmb_Description.Text = ""

        Cbx_Monday.Checked = False
        Cbx_Tuesday.Checked = False
        Cbx_Wednesday.Checked = False
        Cbx_Thursday.Checked = False
        Cbx_Friday.Checked = False
        Cbx_Saturday.Checked = False
        Cbx_Sunday.Checked = False

        Cbx_Monday.Enabled = False
        Cbx_Tuesday.Enabled = False
        Cbx_Wednesday.Enabled = False
        Cbx_Thursday.Enabled = False
        Cbx_Friday.Enabled = False
        Cbx_Saturday.Enabled = False
        Cbx_Sunday.Enabled = False

        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            'Dim da As New SqlDataAdapter("Select * from shift order by description", SQLCon)
            Dim da As New SqlDataAdapter("Select * from Continuous_Operation_Shifts order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "shift")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("shift").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Shift Info from Database: " & Ex.Message)
        End Try



    End Sub


    Sub Load_Area()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Functional_Area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "area")
            SQLCon.Close()
            ReDim Area_Array(0)
            For Each dr As DataRow In ds.Tables("area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Functional Area Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Description.SelectedIndexChanged
        Call Load_Data()
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        'Dim cmd As New SqlCommand("delete from shift where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        Dim cmd As New SqlCommand("delete from Continuous_Operation_Shifts where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Area.Text = ""
        Txt_Shift.Text = ""
        DTP_Monday_Start_Time.Text = "00:00:00"
        DTP_Monday_End_Time.Text = "00:00:00"
        DTP_Tuesday_Start_Time.Text = "00:00:00"
        DTP_Tuesday_End_Time.Text = "00:00:00"
        DTP_Wednesday_Start_Time.Text = "00:00:00"
        DTP_Wednesday_End_Time.Text = "00:00:00"
        DTP_Thursday_Start_Time.Text = "00:00:00"
        DTP_Thursday_End_Time.Text = "00:00:00"
        DTP_Friday_Start_Time.Text = "00:00:00"
        DTP_Friday_End_Time.Text = "00:00:00"
        DTP_Saturday_Start_Time.Text = "00:00:00"
        DTP_Saturday_End_Time.Text = "00:00:00"
        DTP_Sunday_Start_Time.Text = "00:00:00"
        DTP_Sunday_End_Time.Text = "00:00:00"

        Cbx_Monday.Checked = False
        Cbx_Tuesday.Checked = False
        Cbx_Wednesday.Checked = False
        Cbx_Thursday.Checked = False
        Cbx_Friday.Checked = False
        Cbx_Saturday.Checked = False
        Cbx_Sunday.Checked = False

        Cbx_Monday.Enabled = False
        Cbx_Tuesday.Enabled = False
        Cbx_Wednesday.Enabled = False
        Cbx_Thursday.Enabled = False
        Cbx_Friday.Enabled = False
        Cbx_Saturday.Enabled = False
        Cbx_Sunday.Enabled = False


        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        'Dim da As New SqlDataAdapter("Select shift.*, functional_area.description as area_desc from shift inner join functional_area on shift.area = functional_area.id where shift.id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        Dim da As New SqlDataAdapter("Select Continuous_Operation_Shifts.*, functional_area.description as area_desc from Continuous_Operation_Shifts inner join functional_area on Continuous_Operation_Shifts.area = functional_area.id where Continuous_Operation_Shifts.id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "shift")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("shift").Rows
            txt_Area.Text = dr("area_desc") & ""
            Txt_Shift.Text = dr("Shift") & ""
            Cbx_Monday.Checked = dr("Monday") & ""
            DTP_Monday_Start_Time.Text = dr("Monday_start_time") & ""
            DTP_Monday_End_Time.Text = dr("Monday_end_time") & ""
            Cbx_Tuesday.Checked = dr("Tuesday") & ""
            DTP_Tuesday_Start_Time.Text = dr("Tuesday_start_time") & ""
            DTP_Tuesday_End_Time.Text = dr("Tuesday_end_time") & ""
            Cbx_Wednesday.Checked = dr("Wednesday") & ""
            DTP_Wednesday_Start_Time.Text = dr("Wednesday_start_time") & ""
            DTP_Wednesday_End_Time.Text = dr("Wednesday_end_time") & ""
            Cbx_Thursday.Checked = dr("Thursday") & ""
            DTP_Thursday_Start_Time.Text = dr("Thursday_start_time") & ""
            DTP_Thursday_End_Time.Text = dr("Thursday_end_time") & ""
            Cbx_Friday.Checked = dr("Friday") & ""
            DTP_Friday_Start_Time.Text = dr("Friday_start_time") & ""
            DTP_Friday_End_Time.Text = dr("Friday_end_time") & ""
            Cbx_Saturday.Checked = dr("Saturday") & ""
            DTP_Saturday_Start_Time.Text = dr("Saturday_start_time") & ""
            DTP_Saturday_End_Time.Text = dr("Saturday_end_time") & ""
            Cbx_Sunday.Checked = dr("Sunday") & ""
            DTP_Sunday_Start_Time.Text = dr("Sunday_start_time") & ""
            DTP_Sunday_End_Time.Text = dr("Sunday_end_time") & ""
        Next

        Cbx_Monday.Enabled = False
        Cbx_Tuesday.Enabled = False
        Cbx_Wednesday.Enabled = False
        Cbx_Thursday.Enabled = False
        Cbx_Friday.Enabled = False
        Cbx_Saturday.Enabled = False
        Cbx_Sunday.Enabled = False

        If Cbx_Monday.Checked Then
            DTP_Monday_Start_Time.Visible = True
            DTP_Monday_End_Time.Visible = True
            'Cbx_Monday.Enabled = True
        Else
            DTP_Monday_Start_Time.Visible = False
            DTP_Monday_End_Time.Visible = False
            'Cbx_Monday.Enabled = False
        End If
        If Cbx_Tuesday.Checked Then
            DTP_Tuesday_Start_Time.Visible = True
            DTP_Tuesday_End_Time.Visible = True
            'Cbx_Tuesday.Enabled = True
        Else
            DTP_Tuesday_Start_Time.Visible = False
            DTP_Tuesday_End_Time.Visible = False
            'Cbx_Tuesday.Enabled = False
        End If
        If Cbx_Wednesday.Checked Then
            DTP_Wednesday_Start_Time.Visible = True
            DTP_Wednesday_End_Time.Visible = True
            'Cbx_Wednesday.Enabled = True
        Else
            DTP_Wednesday_Start_Time.Visible = False
            DTP_Wednesday_End_Time.Visible = False
            'Cbx_Wednesday.Enabled = False
        End If
        If Cbx_Thursday.Checked Then
            DTP_Thursday_Start_Time.Visible = True
            DTP_Thursday_End_Time.Visible = True
            'Cbx_Thursday.Enabled = True
        Else
            DTP_Thursday_Start_Time.Visible = False
            DTP_Thursday_End_Time.Visible = False
            'Cbx_Thursday.Enabled = False
        End If
        If Cbx_Friday.Checked Then
            DTP_Friday_Start_Time.Visible = True
            DTP_Friday_End_Time.Visible = True
            'Cbx_Friday.Enabled = True
        Else
            DTP_Friday_Start_Time.Visible = False
            DTP_Friday_End_Time.Visible = False
            'Cbx_Friday.Enabled = False
        End If
        If Cbx_Saturday.Checked Then
            DTP_Saturday_Start_Time.Visible = True
            DTP_Saturday_End_Time.Visible = True
            ' Cbx_Saturday.Enabled = True
        Else
            DTP_Saturday_Start_Time.Visible = False
            DTP_Saturday_End_Time.Visible = False
            'Cbx_Saturday.Enabled = False
        End If
        If Cbx_Sunday.Checked Then
            DTP_Sunday_Start_Time.Visible = True
            DTP_Sunday_End_Time.Visible = True
            'Cbx_Sunday.Enabled = True
        Else
            DTP_Sunday_Start_Time.Visible = False
            DTP_Sunday_End_Time.Visible = False
            'Cbx_Sunday.Enabled = False
        End If


    End Sub

    Private Sub Shifts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        Call Load_Combo()
        Call Load_Area()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

        DTP_Monday_Start_Time.Text = "00:00:00"
        DTP_Monday_End_Time.Text = "00:00:00"
        DTP_Tuesday_Start_Time.Text = "00:00:00"
        DTP_Tuesday_End_Time.Text = "00:00:00"
        DTP_Wednesday_Start_Time.Text = "00:00:00"
        DTP_Wednesday_End_Time.Text = "00:00:00"
        DTP_Thursday_Start_Time.Text = "00:00:00"
        DTP_Thursday_End_Time.Text = "00:00:00"
        DTP_Friday_Start_Time.Text = "00:00:00"
        DTP_Friday_End_Time.Text = "00:00:00"
        DTP_Saturday_Start_Time.Text = "00:00:00"
        DTP_Saturday_End_Time.Text = "00:00:00"
        DTP_Sunday_Start_Time.Text = "00:00:00"
        DTP_Sunday_End_Time.Text = "00:00:00"

        DTP_Monday_Start_Time.Visible = False
        DTP_Monday_End_Time.Visible = False
        DTP_Tuesday_Start_Time.Visible = False
        DTP_Tuesday_End_Time.Visible = False
        DTP_Wednesday_Start_Time.Visible = False
        DTP_Wednesday_End_Time.Visible = False
        DTP_Thursday_Start_Time.Visible = False
        DTP_Thursday_End_Time.Visible = False
        DTP_Friday_Start_Time.Visible = False
        DTP_Friday_End_Time.Visible = False
        DTP_Saturday_Start_Time.Visible = False
        DTP_Saturday_End_Time.Visible = False
        DTP_Sunday_Start_Time.Visible = False
        DTP_Sunday_End_Time.Visible = False

        Cbx_Monday.Enabled = False
        Cbx_Tuesday.Enabled = False
        Cbx_Wednesday.Enabled = False
        Cbx_Thursday.Enabled = False
        Cbx_Friday.Enabled = False
        Cbx_Saturday.Enabled = False
        Cbx_Sunday.Enabled = False

    End Sub

    Private Sub Cbx_Monday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Monday.CheckedChanged
        If Cbx_Monday.Checked Then
            DTP_Monday_Start_Time.Visible = True
            DTP_Monday_End_Time.Visible = True
            'Cbx_Monday.Enabled = True
        Else
            DTP_Monday_Start_Time.Visible = False
            DTP_Monday_End_Time.Visible = False
            'Cbx_Monday.Enabled = False
        End If
    End Sub

    Private Sub Cbx_Tuesday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Tuesday.CheckedChanged
        If Cbx_Tuesday.Checked Then
            DTP_Tuesday_Start_Time.Visible = True
            DTP_Tuesday_End_Time.Visible = True
            'Cbx_Tuesday.Enabled = True
        Else
            DTP_Tuesday_Start_Time.Visible = False
            DTP_Tuesday_End_Time.Visible = False
            ' Cbx_Tuesday.Enabled = False
        End If
    End Sub

    Private Sub Cbx_Wednesday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Wednesday.CheckedChanged
        If Cbx_Wednesday.Checked Then
            DTP_Wednesday_Start_Time.Visible = True
            DTP_Wednesday_End_Time.Visible = True
            'Cbx_Wednesday.Enabled = True
        Else
            DTP_Wednesday_Start_Time.Visible = False
            DTP_Wednesday_End_Time.Visible = False
            ' Cbx_Wednesday.Enabled = False
        End If
    End Sub

    Private Sub Cbx_Thursday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Thursday.CheckedChanged
        If Cbx_Thursday.Checked Then
            DTP_Thursday_Start_Time.Visible = True
            DTP_Thursday_End_Time.Visible = True
            'Cbx_Thursday.Enabled = True
        Else
            DTP_Thursday_Start_Time.Visible = False
            DTP_Thursday_End_Time.Visible = False
            'Cbx_Thursday.Enabled = False
        End If
    End Sub

    Private Sub Cbx_Friday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Friday.CheckedChanged
        If Cbx_Friday.Checked Then
            DTP_Friday_Start_Time.Visible = True
            DTP_Friday_End_Time.Visible = True
            'Cbx_Friday.Enabled = True
        Else
            DTP_Friday_Start_Time.Visible = False
            DTP_Friday_End_Time.Visible = False
            'Cbx_Friday.Enabled = False
        End If
    End Sub

    Private Sub Cbx_Saturday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Saturday.CheckedChanged
        If Cbx_Saturday.Checked Then
            DTP_Saturday_Start_Time.Visible = True
            DTP_Saturday_End_Time.Visible = True
            'Cbx_Saturday.Enabled = True
        Else
            DTP_Saturday_Start_Time.Visible = False
            DTP_Saturday_End_Time.Visible = False
            'Cbx_Saturday.Enabled = False
        End If
    End Sub

    Private Sub Cbx_Sunday_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Sunday.CheckedChanged
        If Cbx_Sunday.Checked Then
            DTP_Sunday_Start_Time.Visible = True
            DTP_Sunday_End_Time.Visible = True
            'Cbx_Sunday.Enabled = True
        Else
            DTP_Sunday_Start_Time.Visible = False
            DTP_Sunday_End_Time.Visible = False
            'Cbx_Sunday.Enabled = False
        End If
    End Sub
End Class