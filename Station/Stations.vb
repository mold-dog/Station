Imports System.Data.SqlClient
Public Class Stations
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Area_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Area.Text = ""
        Cmb_Area.Text = ""
        Txt_Screen_Name.Text = ""
        Cmb_Screen_Name.Text = ""
        txt_sub_parameter.Text = ""
        Chk_Show_Paint_Defects.Checked = False
        Chk_Create_New_Version.Checked = False
        Chk_Inactivity_Alarm.Checked = False
        Chk_Auto_Scan_Refresh.Checked = False
        Chk_Tab1.Checked = False
        Chk_Tab2.Checked = False
        Chk_Tab3.Checked = False
        Chk_Tab4.Checked = False
        Chk_Tab5.Checked = False
        Chk_Tab6.Checked = False
        Chk_Tab7.Checked = False
        Chk_Tab8.Checked = False
        Chk_Tab9.Checked = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Checked = False


        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Area.Visible = False
        Cmb_Area.Visible = True
        Txt_PLC.Enabled = True
        Txt_Client_Name.Enabled = True
        txt_sub_parameter.Enabled = True
        Chk_Show_Paint_Defects.Enabled = True
        Chk_Create_New_Version.Enabled = True
        Chk_Inactivity_Alarm.Enabled = True
        Chk_Auto_Scan_Refresh.Enabled = True
        Chk_Tab1.Enabled = False
        Chk_Tab2.Enabled = False
        Chk_Tab3.Enabled = False
        Chk_Tab4.Enabled = False
        Chk_Tab5.Enabled = False
        Chk_Tab6.Enabled = False
        Chk_Tab7.Enabled = False
        Chk_Tab8.Enabled = False
        Chk_Tab9.Enabled = False
        Cbx_Body.Enabled = False
        Cbx_Fendoor.Enabled = False
        Cbx_Press.Enabled = False
        Cbx_Assembly.Enabled = False
        Cbx_Mold.Enabled = False
        Cbx_Paint_Fin.Enabled = False
        Cbx_HCC.Enabled = False
        Cbx_Bonding.Enabled = False
        Cbx_Machining.Enabled = False
        Cbx_Paint.Enabled = False


        Txt_Screen_Name.Visible = False
        Cmb_Screen_Name.Visible = True

        Txt_PLC.Text = ""
        Txt_Client_Name.Text = ""

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
        Txt_Description.Text = Cmb_Description.Text
        Txt_Screen_Name.Visible = False

        Txt_PLC.Enabled = True
        Txt_Client_Name.Enabled = True
        txt_sub_parameter.Enabled = True
        Chk_Show_Paint_Defects.Enabled = True
        Chk_Create_New_Version.Enabled = True
        Chk_Inactivity_Alarm.Enabled = True
        Chk_Auto_Scan_Refresh.Enabled = True
        Chk_Tab1.Enabled = True
        Chk_Tab2.Enabled = True
        Chk_Tab3.Enabled = True
        Chk_Tab4.Enabled = True
        Chk_Tab5.Enabled = True
        Chk_Tab6.Enabled = True
        Chk_Tab7.Enabled = True
        Chk_Tab8.Enabled = True
        Chk_Tab9.Enabled = True
        Cbx_Body.Enabled = True
        Cbx_Fendoor.Enabled = True
        Cbx_Press.Enabled = True
        Cbx_Assembly.Enabled = True
        Cbx_Mold.Enabled = True
        Cbx_Paint_Fin.Enabled = True
        Cbx_HCC.Enabled = True
        Cbx_Bonding.Enabled = True
        Cbx_Machining.Enabled = True
        Cbx_Paint.Enabled = True

        Cmb_Area.Text = txt_Area.Text
        Cmb_Area.Visible = True
        Cmb_Screen_Name.Text = Txt_Screen_Name.Text
        Cmb_Screen_Name.Visible = True



        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        Dim tab_total As Int16 = 0
        Dim int_Valid_Parts As Integer
        'Check for Valid Data

        If Cmb_Area.SelectedIndex < 0 Then
            MsgBox("Please select a valid Area")
            Exit Sub
        End If
        If Chk_Tab1.Checked Then
            tab_total = tab_total + 1
        End If
        If Chk_Tab2.Checked Then
            tab_total = tab_total + 2
        End If
        If Chk_Tab3.Checked Then
            tab_total = tab_total + 4
        End If
        If Chk_Tab4.Checked Then
            tab_total = tab_total + 8
        End If
        If Chk_Tab5.Checked Then
            tab_total = tab_total + 16
        End If
        If Chk_Tab6.Checked Then
            tab_total = tab_total + 32
        End If
        If Chk_Tab7.Checked Then
            tab_total = tab_total + 64
        End If
        If Chk_Tab8.Checked Then
            tab_total = tab_total + 128
        End If
        If Chk_Tab9.Checked Then
            tab_total = tab_total + 256
        End If
        If Cbx_Body.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 1
        End If
        If Cbx_Fendoor.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 2
        End If
        If Cbx_Press.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 4
        End If
        If Cbx_Assembly.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 8
        End If
        If Cbx_Mold.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 16
        End If
        If Cbx_Paint_Fin.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 32
        End If
        If Cbx_HCC.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 64
        End If
        If Cbx_Bonding.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 128
        End If
        If Cbx_Machining.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 256
        End If
        If Cbx_Paint.Checked = True Then
            int_Valid_Parts = int_Valid_Parts Or 512
        End If


        If Adding Then
            query = "Insert into Station (description, Area, PLC_Station_Number, Client_Name, Screen_Name, Screen_Sub_Parameter, Show_Paint_Defects, Create_New_Version, Inactivity_Alarm, tabs, Valid_Parts, Scan_Auto_Refresh) "
            query = query & " values ('" & Txt_Description.Text & "', " & Area_Array(Cmb_Area.SelectedIndex) & ", " & Txt_PLC.Text
            query = query & ", '" & Txt_Client_Name.Text & "', '" & Cmb_Screen_Name.Text & "', " & Val(txt_sub_parameter.Text) & ", " & IIf(Chk_Show_Paint_Defects.Checked, 1, 0) & ", "
            query = query & IIf(Chk_Create_New_Version.Checked, 1, 0) & ", " & IIf(Chk_Inactivity_Alarm.Checked, 1, 0) & ", " & tab_total & ", " & int_Valid_Parts & ", " & IIf(Chk_Auto_Scan_Refresh.Checked, 1, 0) & ")"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update Station Set description = '" & Txt_Description.Text & "', Area = " & Area_Array(Cmb_Area.SelectedIndex) & ", PLC_Station_Number = " & Txt_PLC.Text & ", "
            query = query & "Client_Name = '" & Txt_Client_Name.Text & "', Screen_Name = '" & Cmb_Screen_Name.Text & "', Screen_Sub_Parameter = " & Val(txt_sub_parameter.Text)
            query = query & ", Show_Paint_Defects = " & IIf(Chk_Show_Paint_Defects.Checked, 1, 0) & ", Create_New_Version = " & IIf(Chk_Create_New_Version.Checked, 1, 0)
            query = query & ", Inactivity_Alarm = " & IIf(Chk_Inactivity_Alarm.Checked, 1, 0) & ", tabs = " & tab_total & ", Valid_Parts = " & int_Valid_Parts & ", Scan_Auto_Refresh = " & IIf(Chk_Auto_Scan_Refresh.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
        End If






        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
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
        Txt_Screen_Name.Visible = True
        Cmb_Screen_Name.Visible = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Area.Text = ""
        Txt_PLC.Enabled = False
        Txt_Client_Name.Enabled = False
        txt_sub_parameter.Enabled = False
        Chk_Show_Paint_Defects.Enabled = False
        Chk_Create_New_Version.Enabled = False
        Chk_Inactivity_Alarm.Enabled = False
        Chk_Auto_Scan_Refresh.Enabled = False
        Txt_Screen_Name.Text = ""
        Chk_Tab1.Enabled = False
        Chk_Tab2.Enabled = False
        Chk_Tab3.Enabled = False
        Chk_Tab4.Enabled = False
        Chk_Tab5.Enabled = False
        Chk_Tab6.Enabled = False
        Chk_Tab7.Enabled = False
        Chk_Tab8.Enabled = False
        Chk_Tab9.Enabled = False
        Cbx_Body.Enabled = False
        Cbx_Fendoor.Enabled = False
        Cbx_Press.Enabled = False
        Cbx_Assembly.Enabled = False
        Cbx_Mold.Enabled = False
        Cbx_Paint_Fin.Enabled = False
        Cbx_HCC.Enabled = False
        Cbx_Bonding.Enabled = False
        Cbx_Machining.Enabled = False
        Cbx_Paint.Enabled = False

        Txt_PLC.Text = ""
        Txt_Client_Name.Text = ""
        txt_sub_parameter.Text = ""
        Chk_Show_Paint_Defects.Checked = False
        Chk_Create_New_Version.Checked = False
        Chk_Inactivity_Alarm.Checked = False
        Chk_Auto_Scan_Refresh.Checked = False
        Chk_Tab1.Checked = False
        Chk_Tab2.Checked = False
        Chk_Tab3.Checked = False
        Chk_Tab4.Checked = False
        Chk_Tab5.Checked = False
        Chk_Tab6.Checked = False
        Chk_Tab7.Checked = False
        Chk_Tab8.Checked = False
        Chk_Tab9.Checked = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Checked = False



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

        Txt_PLC.Enabled = False
        Txt_Client_Name.Enabled = False
        txt_sub_parameter.Enabled = False
        Chk_Show_Paint_Defects.Enabled = False
        Chk_Create_New_Version.Enabled = False
        Chk_Inactivity_Alarm.Enabled = False
        Chk_Auto_Scan_Refresh.Enabled = False
        Chk_Tab1.Enabled = False
        Chk_Tab2.Enabled = False
        Chk_Tab3.Enabled = False
        Chk_Tab4.Enabled = False
        Chk_Tab5.Enabled = False
        Chk_Tab6.Enabled = False
        Chk_Tab7.Enabled = False
        Chk_Tab8.Enabled = False
        Chk_Tab9.Enabled = False
        Cbx_Body.Enabled = False
        Cbx_Fendoor.Enabled = False
        Cbx_Press.Enabled = False
        Cbx_Assembly.Enabled = False
        Cbx_Mold.Enabled = False
        Cbx_Paint_Fin.Enabled = False
        Cbx_HCC.Enabled = False
        Cbx_Bonding.Enabled = False
        Cbx_Machining.Enabled = False
        Cbx_Paint.Enabled = False

        Txt_Screen_Name.Visible = True
        Cmb_Screen_Name.Visible = False
        Txt_Screen_Name.Text = ""

        Txt_PLC.Text = ""
        Txt_Client_Name.Text = ""
        txt_sub_parameter.Text = ""
        Chk_Show_Paint_Defects.Checked = False
        Chk_Create_New_Version.Checked = False
        Chk_Inactivity_Alarm.Checked = False
        Chk_Auto_Scan_Refresh.Checked = False
        Chk_Tab1.Checked = False
        Chk_Tab2.Checked = False
        Chk_Tab3.Checked = False
        Chk_Tab4.Checked = False
        Chk_Tab5.Checked = False
        Chk_Tab6.Checked = False
        Chk_Tab7.Checked = False
        Chk_Tab8.Checked = False
        Chk_Tab9.Checked = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Checked = False


        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Station order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Station")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Station").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Station Info from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from Station where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Area.Text = ""
        Txt_PLC.Text = ""
        Txt_Client_Name.Text = ""
        Txt_Screen_Name.Text = ""
        txt_sub_parameter.Text = ""
        Chk_Show_Paint_Defects.Checked = False
        Chk_Create_New_Version.Checked = False
        Chk_Inactivity_Alarm.Checked = False
        Chk_Auto_Scan_Refresh.Checked = False
        Chk_Tab1.Checked = False
        Chk_Tab2.Checked = False
        Chk_Tab3.Checked = False
        Chk_Tab4.Checked = False
        Chk_Tab5.Checked = False
        Chk_Tab6.Checked = False
        Chk_Tab7.Checked = False
        Chk_Tab8.Checked = False
        Chk_Tab9.Checked = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Checked = False

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

    End Sub
    Private Sub Load_Data()
        Dim tab_total As Int16 = 0
        Dim int_Valid_Parts As Integer

        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select area.Description as Area_Description, Client_Name, PLC_Station_Number, Screen_Name, Screen_Sub_Parameter, isnull(Show_Paint_Defects,0) as Show_Paint_Defects, isnull(Create_New_Version,0) as Create_New_Version, isnull(Inactivity_Alarm,0) as Inactivity_Alarm, tabs, Valid_Parts, isnull(Scan_Auto_Refresh,0) as Scan_Auto_Refresh from Station inner join area on station.area = area.id where station.id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Station")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Station").Rows
            txt_Area.Text = dr("Area_Description") & ""
            Txt_Client_Name.Text = dr("Client_Name") & ""
            Txt_PLC.Text = dr("PLC_Station_Number") & ""
            Txt_Screen_Name.Text = dr("Screen_Name") & ""
            txt_sub_parameter.Text = dr("Screen_Sub_Parameter") & ""
            Chk_Show_Paint_Defects.Checked = dr("Show_Paint_Defects")
            Chk_Create_New_Version.Checked = dr("Create_New_Version")
            Chk_Inactivity_Alarm.Checked = dr("Inactivity_Alarm")
            Chk_Auto_Scan_Refresh.Checked = dr("Scan_Auto_Refresh")
            tab_total = Val(dr("tabs") & "")
            If (tab_total And 1) > 0 Then
                Chk_Tab1.Checked = True
            Else
                Chk_Tab1.Checked = False
            End If
            If (tab_total And 2) > 0 Then
                Chk_Tab2.Checked = True
            Else
                Chk_Tab2.Checked = False
            End If
            If (tab_total And 4) > 0 Then
                Chk_Tab3.Checked = True
            Else
                Chk_Tab3.Checked = False
            End If
            If (tab_total And 8) > 0 Then
                Chk_Tab4.Checked = True
            Else
                Chk_Tab4.Checked = False
            End If
            If (tab_total And 16) > 0 Then
                Chk_Tab5.Checked = True
            Else
                Chk_Tab5.Checked = False
            End If
            If (tab_total And 32) > 0 Then
                Chk_Tab6.Checked = True
            Else
                Chk_Tab6.Checked = False
            End If
            If (tab_total And 64) > 0 Then
                Chk_Tab7.Checked = True
            Else
                Chk_Tab7.Checked = False
            End If
            If (tab_total And 128) > 0 Then
                Chk_Tab8.Checked = True
            Else
                Chk_Tab8.Checked = False
            End If
            If (tab_total And 256) > 0 Then
                Chk_Tab9.Checked = True
            Else
                Chk_Tab9.Checked = False
            End If
            If IsDBNull(dr("Valid_Parts")) Then
                int_Valid_Parts = 0
            Else
                int_Valid_Parts = dr("Valid_Parts")
            End If
            Cbx_Body.Checked = False
            Cbx_Fendoor.Checked = False
            Cbx_Press.Checked = False
            Cbx_Assembly.Checked = False
            Cbx_Mold.Checked = False
            Cbx_Paint_Fin.Checked = False
            Cbx_HCC.Checked = False
            Cbx_Bonding.Checked = False
            Cbx_Machining.Checked = False
            Cbx_Paint.Checked = False

            If int_Valid_Parts And 1 Then
                Cbx_Body.Checked = True
            End If
            If int_Valid_Parts And 2 Then
                Cbx_Fendoor.Checked = True
            End If
            If int_Valid_Parts And 4 Then
                Cbx_Press.Checked = True
            End If
            If int_Valid_Parts And 8 Then
                Cbx_Assembly.Checked = True
            End If
            If int_Valid_Parts And 16 Then
                Cbx_Mold.Checked = True
            End If
            If int_Valid_Parts And 32 Then
                Cbx_Paint_Fin.Checked = True
            End If
            If int_Valid_Parts And 64 Then
                Cbx_HCC.Checked = True
            End If
            If int_Valid_Parts And 128 Then
                Cbx_Bonding.Checked = True
            End If
            If int_Valid_Parts And 256 Then
                Cbx_Machining.Checked = True
            End If
            If int_Valid_Parts And 512 Then
                Cbx_Paint.Checked = True
            End If
        Next


    End Sub

    Private Sub Stations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Call Load_Areas()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

    End Sub

    Sub Load_Areas()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim Area_Array(0)
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try



    End Sub


End Class