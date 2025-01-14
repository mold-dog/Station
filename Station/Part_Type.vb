Imports System.Data.SqlClient
Public Class Part_Type
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Add_Defect_Array() As Int32
    Dim Inspections_Array() As Int32
    Dim Inspection_ID As Int32
    Dim Group_Array() As Int32
    Dim Area_Array() As Int32


    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Prefix.Text = ""
        Txt_Alt_Prefix.Text = ""
        Txt_ERP_Part_Number.Text = ""
        Txt_Image_Location.Text = ""
        Txt_Body_Image.Text = ""
        Txt_Fendoor_Image.Text = ""
        Txt_Press_Image.Text = ""
        Txt_Assembly_Image.Text = ""
        Txt_Mold_Fin_Image.Text = ""
        Txt_Paint_Fin_Image.Text = ""
        Txt_HCC_Image.Text = ""
        Txt_Bonding_Image.Text = ""
        Txt_Machining_Image.Text = ""
        Txt_Paint_Image.Text = ""
        txt_Online_Good.Text = "0"
        txt_Online_TU.Text = "0"
        txt_Online_Reclear.Text = "0"
        txt_Online_Rework.Text = "0"
        txt_Wetsand_Good.Text = "0"
        txt_Wetsand_TU.Text = "0"
        txt_Wetsand_Reclear.Text = "0"
        txt_Wetsand_Rework.Text = "0"
        txt_Finesse_Good.Text = "0"
        txt_Finesse_TU.Text = "0"
        txt_Finesse_Reclear.Text = "0"
        txt_Finesse_Rework.Text = "0"
        txt_Final_Good.Text = "0"
        txt_Final_TU.Text = "0"
        txt_Final_Reclear.Text = "0"
        txt_Final_Rework.Text = "0"
        txt_Supervisor_Good.Text = "0"
        txt_Supervisor_TU.Text = "0"
        txt_Supervisor_Reclear.Text = "0"
        txt_Supervisor_Rework.Text = "0"
        txt_Decal_Good.Text = "0"
        txt_Decal_TU.Text = "0"
        txt_Decal_Reclear.Text = "0"
        txt_Decal_Rework.Text = "0"
        txt_Pinstripe_Good.Text = "0"
        txt_Pinstripe_TU.Text = "0"
        txt_Pinstripe_Reclear.Text = "0"
        txt_Pinstripe_Rework.Text = "0"
        txt_Prep_Good.Text = "0"
        txt_Prep_TU.Text = "0"
        txt_Prep_Reclear.Text = "0"
        txt_Prep_Rework.Text = "0"
        Cmb_Group.Text = ""
        Cmb_Area.Text = ""
        CheckBox_Schedule.Checked = False
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
        txt_Spanish.Enabled = True
        Txt_Prefix.Enabled = True
        Txt_Alt_Prefix.Enabled = True
        Txt_ERP_Part_Number.Enabled = True
        Txt_Image_Location.Enabled = True
        Txt_Body_Image.Enabled = True
        Txt_Fendoor_Image.Enabled = True
        Txt_Press_Image.Enabled = True
        Txt_Assembly_Image.Enabled = True
        Txt_Mold_Fin_Image.Enabled = True
        Txt_Paint_Fin_Image.Enabled = True
        Txt_HCC_Image.Enabled = True
        Txt_Bonding_Image.Enabled = True
        Txt_Machining_Image.Enabled = True
        Txt_Paint_Image.Enabled = True
        Cmb_Area.Enabled = True
        Cmb_Group.Enabled = True
        txt_Online_Good.Enabled = True
        txt_Online_TU.Enabled = True
        txt_Online_Reclear.Enabled = True
        txt_Online_Rework.Enabled = True
        txt_Wetsand_Good.Enabled = True
        txt_Wetsand_TU.Enabled = True
        txt_Wetsand_Reclear.Enabled = True
        txt_Wetsand_Rework.Enabled = True
        txt_Finesse_Good.Enabled = True
        txt_Finesse_TU.Enabled = True
        txt_Finesse_Reclear.Enabled = True
        txt_Finesse_Rework.Enabled = True
        txt_Final_Good.Enabled = True
        txt_Final_TU.Enabled = True
        txt_Final_Reclear.Enabled = True
        txt_Final_Rework.Enabled = True
        txt_Supervisor_Good.Enabled = True
        txt_Supervisor_TU.Enabled = True
        txt_Supervisor_Reclear.Enabled = True
        txt_Supervisor_Rework.Enabled = True
        txt_Decal_Good.Enabled = True
        txt_Decal_TU.Enabled = True
        txt_Decal_Reclear.Enabled = True
        txt_Decal_Rework.Enabled = True
        txt_Pinstripe_Good.Enabled = True
        txt_Pinstripe_TU.Enabled = True
        txt_Pinstripe_Reclear.Enabled = True
        txt_Pinstripe_Rework.Enabled = True
        txt_Prep_Good.Enabled = True
        txt_Prep_TU.Enabled = True
        txt_Prep_Reclear.Enabled = True
        txt_Prep_Rework.Enabled = True
        CheckBox_Schedule.Enabled = True
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


        LB_Defects.Rows.Clear()
        LB_Inspections.Items.Clear()


        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False
        Btn_Get_Image_Location.Visible = True
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
        txt_Spanish.Enabled = True
        Txt_Description.Text = Cmb_Description.Text
        Txt_Image_Location.Enabled = True
        Txt_Body_Image.Enabled = True
        Txt_Fendoor_Image.Enabled = True
        Txt_Press_Image.Enabled = True
        Txt_Assembly_Image.Enabled = True
        Txt_Mold_Fin_Image.Enabled = True
        Txt_Paint_Fin_Image.Enabled = True
        Txt_HCC_Image.Enabled = True
        Txt_Bonding_Image.Enabled = True
        Txt_Machining_Image.Enabled = True
        Txt_Paint_Image.Enabled = True
        Cmb_Area.Enabled = True
        Cmb_Group.Enabled = True
        txt_Online_Good.Enabled = True
        txt_Online_TU.Enabled = True
        txt_Online_Reclear.Enabled = True
        txt_Online_Rework.Enabled = True
        txt_Wetsand_Good.Enabled = True
        txt_Wetsand_TU.Enabled = True
        txt_Wetsand_Reclear.Enabled = True
        txt_Wetsand_Rework.Enabled = True
        txt_Finesse_Good.Enabled = True
        txt_Finesse_TU.Enabled = True
        txt_Finesse_Reclear.Enabled = True
        txt_Finesse_Rework.Enabled = True
        txt_Final_Good.Enabled = True
        txt_Final_TU.Enabled = True
        txt_Final_Reclear.Enabled = True
        txt_Final_Rework.Enabled = True
        txt_Supervisor_Good.Enabled = True
        txt_Supervisor_TU.Enabled = True
        txt_Supervisor_Reclear.Enabled = True
        txt_Supervisor_Rework.Enabled = True
        txt_Decal_Good.Enabled = True
        txt_Decal_TU.Enabled = True
        txt_Decal_Reclear.Enabled = True
        txt_Decal_Rework.Enabled = True
        txt_Pinstripe_Good.Enabled = True
        txt_Pinstripe_TU.Enabled = True
        txt_Pinstripe_Reclear.Enabled = True
        txt_Pinstripe_Rework.Enabled = True
        txt_Prep_Good.Enabled = True
        txt_Prep_TU.Enabled = True
        txt_Prep_Reclear.Enabled = True
        txt_Prep_Rework.Enabled = True
        CheckBox_Schedule.Enabled = True
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


        Txt_Prefix.Enabled = True
        Txt_Alt_Prefix.Enabled = True
        Txt_ERP_Part_Number.Enabled = True
        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False
        Btn_Get_Image_Location.Visible = True


        Editing = True
        Arrange_Image_Text()

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        Dim int_Valid_Stations As Integer
        'Check for Valid Data
        If Cmb_Group.SelectedIndex < 0 Then
            MsgBox("Please select a valid group.")
            Exit Sub
        End If
        If Cmb_Area.SelectedIndex < 0 Then
            MsgBox("Please select a valid area.")
            Exit Sub
        End If
        If Cbx_Body.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 1
        End If
        If Cbx_Fendoor.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 2
        End If
        If Cbx_Press.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 4
        End If
        If Cbx_Assembly.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 8
        End If
        If Cbx_Mold.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 16
        End If
        If Cbx_Paint_Fin.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 32
        End If
        If Cbx_HCC.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 64
        End If
        If Cbx_Bonding.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 128
        End If
        If Cbx_Machining.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 256
        End If
        If Cbx_Paint.Checked = True Then
            int_Valid_Stations = int_Valid_Stations Or 512
        End If
        If Adding Then
            query = "Insert into Part_Type (description, spanish, RFID_Prefix, Alt_Prefix, ERP_Part_Number, Image_Name, part_type_group, functional_area, "
            query = query & "online_good, online_tu, online_reclear, online_rework, wetsand_good, wetsand_tu, wetsand_reclear, wetsand_rework, "
            query = query & "finesse_good, finesse_tu, finesse_reclear, finesse_rework, final_good, final_tu, final_reclear, final_rework, "
            query = query & "supervisor_good, supervisor_tu, supervisor_reclear, supervisor_rework, decal_good, decal_tu, decal_reclear, decal_rework, "
            query = query & "pinstripe_good, pinstripe_tu, pinstripe_reclear, pinstripe_rework, prep_good, prep_tu, prep_reclear, prep_rework, schedule_finish, Valid_Stations, "
            query = query & "Paint_Image_Name, Body_Image_Name, Press_Image_Name, HCC_Image_Name, Bonding_Image_Name, Machining_Image_Name, Assembly_Image_Name, "
            query = query & "Fender_Door_Image_Name, Mold_Finish_Image_Name, Paint_Finish_Image_Name) "
            query = query & " values ('" & Txt_Description.Text & "', '" & txt_Spanish.Text & "', '" & Txt_Prefix.Text & "', '" & Txt_Alt_Prefix.Text & "', '"
            query = query & Txt_ERP_Part_Number.Text & "', '" & Txt_Image_Location.Text & "', " & Group_Array(Cmb_Group.SelectedIndex) & ", " & Area_Array(Cmb_Area.SelectedIndex) & ", "
            query = query & Val(txt_Online_Good.Text) & ", " & Val(txt_Online_TU.Text) & ", " & Val(txt_Online_Reclear.Text) & ", " & Val(txt_Online_Rework.Text) & ", "
            query = query & Val(txt_Wetsand_Good.Text) & ", " & Val(txt_Wetsand_TU.Text) & ", " & Val(txt_Wetsand_Reclear.Text) & ", " & Val(txt_Wetsand_Rework.Text) & ", "
            query = query & Val(txt_Finesse_Good.Text) & ", " & Val(txt_Finesse_TU.Text) & ", " & Val(txt_Finesse_Reclear.Text) & ", " & Val(txt_Finesse_Rework.Text) & ", "
            query = query & Val(txt_Final_Good.Text) & ", " & Val(txt_Final_TU.Text) & ", " & Val(txt_Final_Reclear.Text) & ", " & Val(txt_Final_Rework.Text) & ", "
            query = query & Val(txt_Supervisor_Good.Text) & ", " & Val(txt_Supervisor_TU.Text) & ", " & Val(txt_Supervisor_Reclear.Text) & ", " & Val(txt_Supervisor_Rework.Text) & ", "
            query = query & Val(txt_Decal_Good.Text) & ", " & Val(txt_Decal_TU.Text) & ", " & Val(txt_Decal_Reclear.Text) & ", " & Val(txt_Decal_Rework.Text) & ", "
            query = query & Val(txt_Pinstripe_Good.Text) & ", " & Val(txt_Pinstripe_TU.Text) & ", " & Val(txt_Pinstripe_Reclear.Text) & ", " & Val(txt_Pinstripe_Rework.Text) & ", "
            query = query & Val(txt_Prep_Good.Text) & ", " & Val(txt_Prep_TU.Text) & ", " & Val(txt_Prep_Reclear.Text) & ", " & Val(txt_Prep_Rework.Text) & ", "
            query = query & IIf(CheckBox_Schedule.Checked, 1, 0) & ", " & int_Valid_Stations & ", '" & Txt_Paint_Image.Text & "', '" & Txt_Body_Image.Text & "', '" & Txt_Press_Image.Text & "', '"
            query = query & Txt_HCC_Image.Text & "', '" & Txt_Bonding_Image.Text & "', '" & Txt_Machining_Image.Text & "', '" & Txt_Assembly_Image.Text & "', '" & Txt_Fendoor_Image.Text & "', '"
            query = query & Txt_Mold_Fin_Image.Text & "', '" & Txt_Paint_Fin_Image.Text & "')"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update Part_Type Set description = '" & Txt_Description.Text & "', spanish = '" & txt_Spanish.Text & "', RFID_Prefix = '" & Txt_Prefix.Text & "', Alt_Prefix = '"
            query = query & Txt_Alt_Prefix.Text & "', ERP_Part_Number = '" & Txt_ERP_Part_Number.Text & "', Image_Name = '" & Txt_Image_Location.Text & "', part_type_group = "
            query = query & Group_Array(Cmb_Group.SelectedIndex) & ", functional_area = " & Area_Array(Cmb_Area.SelectedIndex) & ", online_good = " & Val(txt_Online_Good.Text)
            query = query & ", online_tu = " & Val(txt_Online_TU.Text) & ", online_reclear = " & Val(txt_Online_Reclear.Text) & ", online_rework = " & Val(txt_Online_Rework.Text)
            query = query & ", wetsand_good = " & Val(txt_Wetsand_Good.Text) & ", wetsand_tu = " & Val(txt_Wetsand_TU.Text) & ", wetsand_reclear = " & Val(txt_Wetsand_Reclear.Text) & ", wetsand_rework = " & Val(txt_Wetsand_Rework.Text)
            query = query & ", finesse_good = " & Val(txt_Finesse_Good.Text) & ", finesse_tu = " & Val(txt_Finesse_TU.Text) & ", finesse_reclear = " & Val(txt_Finesse_Reclear.Text) & ", finesse_rework = " & Val(txt_Finesse_Rework.Text)
            query = query & ", final_good = " & Val(txt_Final_Good.Text) & ", final_tu = " & Val(txt_Final_TU.Text) & ", final_reclear = " & Val(txt_Final_Reclear.Text) & ", final_rework = " & Val(txt_Final_Rework.Text)
            query = query & ", supervisor_good = " & Val(txt_Supervisor_Good.Text) & ", supervisor_tu = " & Val(txt_Supervisor_TU.Text) & ", supervisor_reclear = " & Val(txt_Supervisor_Reclear.Text) & ", supervisor_rework = " & Val(txt_Supervisor_Rework.Text)
            query = query & ", decal_good = " & Val(txt_Decal_Good.Text) & ", decal_tu = " & Val(txt_Decal_TU.Text) & ", decal_reclear = " & Val(txt_Decal_Reclear.Text) & ", decal_rework = " & Val(txt_Decal_Rework.Text)
            query = query & ", pinstripe_good = " & Val(txt_Pinstripe_Good.Text) & ", pinstripe_tu = " & Val(txt_Pinstripe_TU.Text) & ", pinstripe_reclear = " & Val(txt_Pinstripe_Reclear.Text) & ", pinstripe_rework = " & Val(txt_Pinstripe_Rework.Text)
            query = query & ", prep_good = " & Val(txt_Prep_Good.Text) & ", prep_tu = " & Val(txt_Prep_TU.Text) & ", prep_reclear = " & Val(txt_Prep_Reclear.Text) & ", prep_rework = " & Val(txt_Prep_Rework.Text)
            query = query & ", schedule_finish = " & IIf(CheckBox_Schedule.Checked, 1, 0) & ", Valid_Stations = " & int_Valid_Stations & ", Paint_Image_Name = '" & Txt_Paint_Image.Text & "', Body_Image_Name = '" & Txt_Body_Image.Text
            query = query & "', Press_Image_Name = '" & Txt_Press_Image.Text & "', HCC_Image_Name = '" & Txt_HCC_Image.Text & "', Bonding_Image_Name = '" & Txt_Bonding_Image.Text & "', Machining_Image_Name = '" & Txt_Machining_Image.Text
            query = query & "', Assembly_Image_Name = '" & Txt_Assembly_Image.Text & "', Fender_Door_Image_Name = '" & Txt_Fendoor_Image.Text & "', Mold_Finish_Image_Name = '" & Txt_Mold_Fin_Image.Text & "', Paint_Finish_Image_Name = '" & Txt_Paint_Fin_Image.Text
            query = query & "' where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        txt_Spanish.Enabled = False
        Btn_Get_Image_Location.Visible = False



        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Prefix.Enabled = False
        Txt_Alt_Prefix.Enabled = False
        Txt_ERP_Part_Number.Enabled = False
        Txt_Image_Location.Enabled = False
        Txt_Body_Image.Enabled = False
        Txt_Fendoor_Image.Enabled = False
        Txt_Press_Image.Enabled = False
        Txt_Assembly_Image.Enabled = False
        Txt_Mold_Fin_Image.Enabled = False
        Txt_Paint_Fin_Image.Enabled = False
        Txt_HCC_Image.Enabled = False
        Txt_Bonding_Image.Enabled = False
        Txt_Machining_Image.Enabled = False
        Txt_Paint_Image.Enabled = False
        Cmb_Area.Enabled = False
        Cmb_Group.Enabled = False
        txt_Online_Good.Enabled = False
        txt_Online_TU.Enabled = False
        txt_Online_Reclear.Enabled = False
        txt_Online_Rework.Enabled = False
        txt_Wetsand_Good.Enabled = False
        txt_Wetsand_TU.Enabled = False
        txt_Wetsand_Reclear.Enabled = False
        txt_Wetsand_Rework.Enabled = False
        txt_Finesse_Good.Enabled = False
        txt_Finesse_TU.Enabled = False
        txt_Finesse_Reclear.Enabled = False
        txt_Finesse_Rework.Enabled = False
        txt_Final_Good.Enabled = False
        txt_Final_TU.Enabled = False
        txt_Final_Reclear.Enabled = False
        txt_Final_Rework.Enabled = False
        txt_Supervisor_Good.Enabled = False
        txt_Supervisor_TU.Enabled = False
        txt_Supervisor_Reclear.Enabled = False
        txt_Supervisor_Rework.Enabled = False
        txt_Decal_Good.Enabled = False
        txt_Decal_TU.Enabled = False
        txt_Decal_Reclear.Enabled = False
        txt_Decal_Rework.Enabled = False
        txt_Pinstripe_Good.Enabled = False
        txt_Pinstripe_TU.Enabled = False
        txt_Pinstripe_Reclear.Enabled = False
        txt_Pinstripe_Rework.Enabled = False
        txt_Prep_Good.Enabled = False
        txt_Prep_TU.Enabled = False
        txt_Prep_Reclear.Enabled = False
        txt_Prep_Rework.Enabled = False
        CheckBox_Schedule.Enabled = False
        CheckBox_Schedule.Checked = False
        Cbx_Body.Enabled = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Enabled = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Enabled = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Enabled = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Enabled = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Enabled = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Enabled = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Enabled = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Enabled = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Enabled = False
        Cbx_Paint.Checked = False



        Txt_Prefix.Text = ""
        Txt_Alt_Prefix.Text = ""
        Txt_ERP_Part_Number.Text = ""
        Txt_Image_Location.Text = ""
        Cmb_Area.Text = ""
        Cmb_Group.Text = ""

        Arrange_Image_Text()


    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Get_Image_Location.Visible = False
        txt_Spanish.Enabled = False
        txt_Spanish.Text = ""

        Txt_Prefix.Enabled = False
        Txt_Alt_Prefix.Enabled = False
        Txt_ERP_Part_Number.Enabled = False
        Txt_Image_Location.Enabled = False
        Txt_Body_Image.Enabled = False
        Txt_Fendoor_Image.Enabled = False
        Txt_Press_Image.Enabled = False
        Txt_Assembly_Image.Enabled = False
        Txt_Mold_Fin_Image.Enabled = False
        Txt_Paint_Fin_Image.Enabled = False
        Txt_HCC_Image.Enabled = False
        Txt_Bonding_Image.Enabled = False
        Txt_Machining_Image.Enabled = False
        Txt_Paint_Image.Enabled = False
        Cmb_Area.Enabled = False
        Cmb_Group.Enabled = False
        txt_Online_Good.Enabled = False
        txt_Online_TU.Enabled = False
        txt_Online_Reclear.Enabled = False
        txt_Online_Rework.Enabled = False
        txt_Wetsand_Good.Enabled = False
        txt_Wetsand_TU.Enabled = False
        txt_Wetsand_Reclear.Enabled = False
        txt_Wetsand_Rework.Enabled = False
        txt_Finesse_Good.Enabled = False
        txt_Finesse_TU.Enabled = False
        txt_Finesse_Reclear.Enabled = False
        txt_Finesse_Rework.Enabled = False
        txt_Final_Good.Enabled = False
        txt_Final_TU.Enabled = False
        txt_Final_Reclear.Enabled = False
        txt_Final_Rework.Enabled = False
        txt_Supervisor_Good.Enabled = False
        txt_Supervisor_TU.Enabled = False
        txt_Supervisor_Reclear.Enabled = False
        txt_Supervisor_Rework.Enabled = False
        txt_Decal_Good.Enabled = False
        txt_Decal_TU.Enabled = False
        txt_Decal_Reclear.Enabled = False
        txt_Decal_Rework.Enabled = False
        txt_Pinstripe_Good.Enabled = False
        txt_Pinstripe_TU.Enabled = False
        txt_Pinstripe_Reclear.Enabled = False
        txt_Pinstripe_Rework.Enabled = False
        txt_Prep_Good.Enabled = False
        txt_Prep_TU.Enabled = False
        txt_Prep_Reclear.Enabled = False
        txt_Prep_Rework.Enabled = False
        CheckBox_Schedule.Enabled = False
        CheckBox_Schedule.Checked = False
        Cbx_Body.Enabled = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Enabled = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Enabled = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Enabled = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Enabled = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Enabled = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Enabled = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Enabled = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Enabled = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Enabled = False
        Cbx_Paint.Checked = False


        Txt_Prefix.Text = ""
        Txt_Alt_Prefix.Text = ""
        Txt_ERP_Part_Number.Text = ""
        Txt_Image_Location.Text = ""
        Txt_Body_Image.Text = ""
        Txt_Fendoor_Image.Text = ""
        Txt_Press_Image.Text = ""
        Txt_Assembly_Image.Text = ""
        Txt_Mold_Fin_Image.Text = ""
        Txt_Paint_Fin_Image.Text = ""
        Txt_HCC_Image.Text = ""
        Txt_Bonding_Image.Text = ""
        Txt_Machining_Image.Text = ""
        Txt_Paint_Image.Text = ""
        Cmb_Area.Text = ""
        Cmb_Group.Text = ""

        Editing = False
        Adding = False

        Arrange_Image_Text()

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Info from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Description.SelectedIndexChanged
        Call Load_Data()
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True

        Btn_Defects_Add.Visible = True
        Btn_Defects_Edit.Visible = True
        Btn_Defects_Delete.Visible = True
        Btn_Inspections_Add.Visible = True
        Btn_Inspections_Edit.Visible = True
        Btn_Inspections_Delete.Visible = True

    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from Part_Type where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Prefix.Text = ""
        Txt_Alt_Prefix.Text = ""
        Txt_ERP_Part_Number.Text = ""
        Txt_Image_Location.Text = ""
        Txt_Body_Image.Text = ""
        Txt_Fendoor_Image.Text = ""
        Txt_Press_Image.Text = ""
        Txt_Assembly_Image.Text = ""
        Txt_Mold_Fin_Image.Text = ""
        Txt_Paint_Fin_Image.Text = ""
        Txt_HCC_Image.Text = ""
        Txt_Bonding_Image.Text = ""
        Txt_Machining_Image.Text = ""
        Txt_Paint_Image.Text = ""
        Cmb_Area.Text = ""
        Cmb_Group.Text = ""
        txt_Online_Good.Text = "0"
        txt_Online_TU.Text = "0"
        txt_Online_Reclear.Text = "0"
        txt_Online_Rework.Text = "0"
        txt_Wetsand_Good.Text = "0"
        txt_Wetsand_TU.Text = "0"
        txt_Wetsand_Reclear.Text = "0"
        txt_Wetsand_Rework.Text = "0"
        txt_Finesse_Good.Text = "0"
        txt_Finesse_TU.Text = "0"
        txt_Finesse_Reclear.Text = "0"
        txt_Finesse_Rework.Text = "0"
        txt_Final_Good.Text = "0"
        txt_Final_TU.Text = "0"
        txt_Final_Reclear.Text = "0"
        txt_Final_Rework.Text = "0"
        txt_Supervisor_Good.Text = "0"
        txt_Supervisor_TU.Text = "0"
        txt_Supervisor_Reclear.Text = "0"
        txt_Supervisor_Rework.Text = "0"
        txt_Decal_Good.Text = "0"
        txt_Decal_TU.Text = "0"
        txt_Decal_Reclear.Text = "0"
        txt_Decal_Rework.Text = "0"
        txt_Pinstripe_Good.Text = "0"
        txt_Pinstripe_TU.Text = "0"
        txt_Pinstripe_Reclear.Text = "0"
        txt_Pinstripe_Rework.Text = "0"
        txt_Prep_Good.Text = "0"
        txt_Prep_TU.Text = "0"
        txt_Prep_Reclear.Text = "0"
        txt_Prep_Rework.Text = "0"
        CheckBox_Schedule.Enabled = False
        CheckBox_Schedule.Checked = False
        Cbx_Body.Enabled = False
        Cbx_Body.Checked = False
        Cbx_Fendoor.Enabled = False
        Cbx_Fendoor.Checked = False
        Cbx_Press.Enabled = False
        Cbx_Press.Checked = False
        Cbx_Assembly.Enabled = False
        Cbx_Assembly.Checked = False
        Cbx_Mold.Enabled = False
        Cbx_Mold.Checked = False
        Cbx_Paint_Fin.Enabled = False
        Cbx_Paint_Fin.Checked = False
        Cbx_HCC.Enabled = False
        Cbx_HCC.Checked = False
        Cbx_Bonding.Enabled = False
        Cbx_Bonding.Checked = False
        Cbx_Machining.Enabled = False
        Cbx_Machining.Checked = False
        Cbx_Paint.Enabled = False
        Cbx_Paint.Checked = False



        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False



    End Sub
    Private Sub Load_Data()
        Dim query As String = ""
        Dim int_Valid_Stations As Integer

        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        query = "Select part_type.*, part_type_group.description as type_group, functional_area.description as area from "
        query = query & "(Part_Type left join part_type_group on part_type.part_type_group = part_type_group.id) "
        query = query & "left join functional_area on part_type.functional_area = functional_area.id  where part_type.id = " & ID_Array(Cmb_Description.SelectedIndex)

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part_Type")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Part_Type").Rows
            txt_Spanish.Text = dr("Spanish") & ""
            Txt_Alt_Prefix.Text = dr("RFID_Prefix") & ""
            Txt_Prefix.Text = dr("Alt_Prefix") & ""
            Txt_ERP_Part_Number.Text = dr("ERP_Part_Number") & ""
            Txt_Image_Location.Text = dr("Image_Name") & ""
            Txt_Body_Image.Text = dr("Body_Image_Name") & ""
            Txt_Fendoor_Image.Text = dr("Fender_Door_Image_Name") & ""
            Txt_Press_Image.Text = dr("Press_Image_Name") & ""
            Txt_Assembly_Image.Text = dr("Assembly_Image_Name") & ""
            Txt_Mold_Fin_Image.Text = dr("Mold_Finish_Image_Name") & ""
            Txt_Paint_Fin_Image.Text = dr("Paint_Finish_Image_Name") & ""
            Txt_HCC_Image.Text = dr("HCC_Image_Name") & ""
            Txt_Bonding_Image.Text = dr("Bonding_Image_Name") & ""
            Txt_Machining_Image.Text = dr("Machining_Image_Name") & ""
            Txt_Paint_Image.Text = dr("Paint_Image_Name") & ""
            Cmb_Group.Text = dr("type_group") & ""
            Cmb_Area.Text = dr("area") & ""

            txt_Online_Good.Text = dr("Online_Good") & ""
            txt_Online_TU.Text = dr("Online_TU") & ""
            txt_Online_Reclear.Text = dr("Online_Reclear") & ""
            txt_Online_Rework.Text = dr("Online_Rework") & ""
            txt_Wetsand_Good.Text = dr("Wetsand_Good") & ""
            txt_Wetsand_TU.Text = dr("Wetsand_TU") & ""
            txt_Wetsand_Reclear.Text = dr("Wetsand_Reclear") & ""
            txt_Wetsand_Rework.Text = dr("Wetsand_Rework") & ""
            txt_Finesse_Good.Text = dr("Finesse_Good") & ""
            txt_Finesse_TU.Text = dr("Finesse_TU") & ""
            txt_Finesse_Reclear.Text = dr("Finesse_Reclear") & ""
            txt_Finesse_Rework.Text = dr("Finesse_Rework") & ""
            txt_Final_Good.Text = dr("Final_Good") & ""
            txt_Final_TU.Text = dr("Final_TU") & ""
            txt_Final_Reclear.Text = dr("Final_Reclear") & ""
            txt_Final_Rework.Text = dr("Final_Rework") & ""
            txt_Supervisor_Good.Text = dr("Supervisor_Good") & ""
            txt_Supervisor_TU.Text = dr("Supervisor_TU") & ""
            txt_Supervisor_Reclear.Text = dr("Supervisor_Reclear") & ""
            txt_Supervisor_Rework.Text = dr("Supervisor_Rework") & ""
            txt_Decal_Good.Text = dr("Decal_Good") & ""
            txt_Decal_TU.Text = dr("Decal_TU") & ""
            txt_Decal_Reclear.Text = dr("Decal_Reclear") & ""
            txt_Decal_Rework.Text = dr("Decal_Rework") & ""
            txt_Pinstripe_Good.Text = dr("Pinstripe_Good") & ""
            txt_Pinstripe_TU.Text = dr("Pinstripe_TU") & ""
            txt_Pinstripe_Reclear.Text = dr("Pinstripe_Reclear") & ""
            txt_Pinstripe_Rework.Text = dr("Pinstripe_Rework") & ""
            txt_Prep_Good.Text = dr("Prep_Good") & ""
            txt_Prep_TU.Text = dr("Prep_TU") & ""
            txt_Prep_Reclear.Text = dr("Prep_Reclear") & ""
            txt_Prep_Rework.Text = dr("Prep_Rework") & ""
            If IsDBNull(dr("Schedule_Finish")) Then
                CheckBox_Schedule.Checked = False
            Else
                CheckBox_Schedule.Checked = dr("Schedule_Finish")
            End If
            If IsDBNull(dr("Valid_Stations")) Then
                int_Valid_Stations = 0
            Else
                int_Valid_Stations = dr("Valid_Stations")
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
            If int_Valid_Stations And 1 Then
                Cbx_Body.Checked = True
            End If
            If int_Valid_Stations And 2 Then
                Cbx_Fendoor.Checked = True
            End If
            If int_Valid_Stations And 4 Then
                Cbx_Press.Checked = True
            End If
            If int_Valid_Stations And 8 Then
                Cbx_Assembly.Checked = True
            End If
            If int_Valid_Stations And 16 Then
                Cbx_Mold.Checked = True
            End If
            If int_Valid_Stations And 32 Then
                Cbx_Paint_Fin.Checked = True
            End If
            If int_Valid_Stations And 64 Then
                Cbx_HCC.Checked = True
            End If
            If int_Valid_Stations And 128 Then
                Cbx_Bonding.Checked = True
            End If
            If int_Valid_Stations And 256 Then
                Cbx_Machining.Checked = True
            End If
            If int_Valid_Stations And 512 Then
                Cbx_Paint.Checked = True
            End If







        Next

        Arrange_Image_Text()
        Load_Defects()
        Load_Inspections()

    End Sub

    Private Sub Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Call Load_Add_Combo()
        Call Load_Area_Combo()
        Call Load_Group_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config
        Btn_Defects_Add.Enabled = User_Permissions_Edit_Config
        Btn_Defects_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Defects_Delete.Enabled = User_Permissions_Edit_Config
        Btn_Inspections_Add.Enabled = User_Permissions_Edit_Config
        Btn_Inspections_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Inspections_Delete.Enabled = User_Permissions_Edit_Config


    End Sub
    Private Sub Btn_Recipe_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Defects_Delete.Click
        If LB_Defects.SelectedRows.Count < 1 Then
            MsgBox("No row selected to delete.")
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("exec Delete_Part_Type_Defect " & LB_Defects.CurrentRow.Cells("Col_ID").Value, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Defects()

    End Sub

    Private Sub Btn_Recipe_Add_Click(sender As Object, e As EventArgs) Handles Btn_Defects_Add.Click
        Chk_Paint.Checked = True
        Chk_Finesse.Checked = True

        btn_Save_Defects_Confirm.Visible = False
        btn_Add_Defects_Confirm.Visible = True

        Pnl_Defects.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False



    End Sub
    Private Sub Btn_Add_Recipe_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Add_Defects_Cancel.Click
        Pnl_Defects.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Defects_Add.Visible = True
        Btn_Defects_Edit.Visible = True
        Btn_Defects_Delete.Visible = True
        Btn_Inspections_Add.Visible = True
        Btn_Inspections_Edit.Visible = True
        Btn_Inspections_Delete.Visible = True


    End Sub

    Private Sub btn_Add_Recipe_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Add_Defects_Confirm.Click
        Dim Query As String

        If Cmb_Defects.SelectedIndex < 0 Then
            MsgBox("Select a valid Defect To add To the Part Type.")
            Exit Sub
        End If

        Query = "Exec Add_Part_Type_Defects2 " & ID_Array(Cmb_Description.SelectedIndex) & ", " & Add_Defect_Array(Cmb_Defects.SelectedIndex) & ", " & IIf(Chk_Paint.Checked, 1, 0)
        Query = Query & ", " & IIf(Chk_Finesse.Checked, 1, 0) & ", " & IIf(Chk_Mold.Checked, 1, 0) & ", " & IIf(Chk_Bond.Checked, 1, 0) & ", " & IIf(Chk_Assembly.Checked, 1, 0) & ", " & IIf(Chk_Finishing.Checked, 1, 0)

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(Query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Defects()



        Pnl_Defects.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Defects_Add.Visible = True
        Btn_Defects_Edit.Visible = True
        Btn_Defects_Delete.Visible = True
        Btn_Inspections_Add.Visible = True
        Btn_Inspections_Edit.Visible = True
        Btn_Inspections_Delete.Visible = True


    End Sub
    Sub Load_Defects()
        Dim Query As String
        Dim counter As Integer = 0
        Try

            Query = "Select Part_Type_Defects.id As Part_Type_Defects_ID, Defect.ID as Defect_ID, Defect.Description, Part_Type_Defects.Paint, Part_Type_Defects.Finesse, Part_Type_Defects.Mold, "
            Query = Query & "Part_Type_Defects.Bond, Part_Type_Defects.Assembly, Part_Type_Defects.Finishing from Part_Type_Defects inner join Defect On Part_Type_Defects.Defect_ID = defect.id "
            Query = Query & "where Part_Type_Defects.Part_Type_ID = " & ID_Array(Cmb_Description.SelectedIndex) & " Order by Order_Number"

            LB_Defects.Rows.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(Query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type_Defects")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Part_Type_Defects").Rows

                LB_Defects.Rows.Add()
                LB_Defects.Rows(counter).Cells("Col_Id").Value = dr("Part_Type_Defects_ID")
                LB_Defects.Rows(counter).Cells("Col_Defect_ID").Value = dr("Defect_ID")
                LB_Defects.Rows(counter).Cells("Col_Defect").Value = dr("Description")
                LB_Defects.Rows(counter).Cells("Col_Paint").Value = dr("Paint")
                LB_Defects.Rows(counter).Cells("Col_Finesse").Value = dr("Finesse")
                LB_Defects.Rows(counter).Cells("Col_Mold").Value = dr("Mold")
                LB_Defects.Rows(counter).Cells("Col_Bond").Value = dr("Bond")
                LB_Defects.Rows(counter).Cells("Col_Assembly").Value = dr("Assembly")
                LB_Defects.Rows(counter).Cells("Col_Finishing").Value = dr("Finishing")

                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Defects Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Add_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Defects.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Defect order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Defect")
            SQLCon.Close()
            ReDim Add_Defect_Array(0)
            For Each dr As DataRow In ds.Tables("Defect").Rows
                Cmb_Defects.Items.Add(dr("Description"))
                ReDim Preserve Add_Defect_Array(counter)
                Add_Defect_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Defect Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Inspections()
        Dim Query As String
        Dim counter As Integer = 0
        Try

            Query = "Select * from Inspection_Items where Part_Type_ID = " & ID_Array(Cmb_Description.SelectedIndex) & " Order by Inspection_Number"

            LB_Inspections.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(Query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Inspection_Items")
            SQLCon.Close()
            ReDim Inspections_Array(0)
            For Each dr As DataRow In ds.Tables("Inspection_Items").Rows

                LB_Inspections.Items.Add(dr("Description"))

                ReDim Preserve Inspections_Array(counter)
                Inspections_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Inspection Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Inspections_Add_Click(sender As Object, e As EventArgs) Handles Btn_Inspections_Add.Click
        Inspection_ID = 0
        Txt_Inspection.Text = ""
        Pnl_Inspection.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False


    End Sub

    Private Sub Btn_Inspections_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Inspections_Edit.Click

        If LB_Inspections.SelectedIndex < 0 Then
            MsgBox("Please select an Inspection to edit.")
            Exit Sub
        End If
        Inspection_ID = Inspections_Array(LB_Inspections.SelectedIndex)
        Txt_Inspection.Text = LB_Inspections.Items(LB_Inspections.SelectedIndex).ToString
        Pnl_Inspection.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False

    End Sub

    Private Sub Btn_Inspections_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Inspections_Delete.Click
        If LB_Inspections.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("exec Delete_Inspection_Items " & Inspections_Array(LB_Inspections.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Inspections()

    End Sub

    Private Sub Btn_Inspection_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Inspection_Cancel.Click
        Pnl_Inspection.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Defects_Add.Visible = True
        Btn_Defects_Edit.Visible = True
        Btn_Defects_Delete.Visible = True
        Btn_Inspections_Add.Visible = True
        Btn_Inspections_Edit.Visible = True
        Btn_Inspections_Delete.Visible = True

    End Sub

    Private Sub Btn_Inspection_Save_Click(sender As Object, e As EventArgs) Handles Btn_Inspection_Save.Click
        Dim query As String = ""

        If Len(Txt_Inspection.Text) < 1 Then
            MsgBox("Enter a valid Inspection to save to the Part Type.")
            Exit Sub
        End If
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        If Inspection_ID > 0 Then
            query = "Update Inspection_Items Set Description = '" & Txt_Inspection.Text & "' where ID = " & Inspection_ID
        Else
            query = "Exec Add_Inspection_Item " & ID_Array(Cmb_Description.SelectedIndex) & ", '" & Txt_Inspection.Text & "'"
        End If
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Inspections()



        Pnl_Inspection.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Defects_Add.Visible = True
        Btn_Defects_Edit.Visible = True
        Btn_Defects_Delete.Visible = True
        Btn_Inspections_Add.Visible = True
        Btn_Inspections_Edit.Visible = True
        Btn_Inspections_Delete.Visible = True

    End Sub


    Private Sub Btn_Get_Image_Location_Click(sender As Object, e As EventArgs) Handles Btn_Get_Image_Location.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Image_Location.Text = Dlg_Get_Image.SafeFileName
        End If

    End Sub

    Sub Load_Group_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Group.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type_Group order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "part_type_group")
            SQLCon.Close()
            ReDim Group_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type_group").Rows
                Cmb_Group.Items.Add(dr("Description"))
                ReDim Preserve Group_Array(counter)
                Group_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Group Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Area_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Functional_Area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Functional_Area")
            SQLCon.Close()
            ReDim Area_Array(0)
            For Each dr As DataRow In ds.Tables("Functional_Area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Functional Area Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Defects_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Defects_Edit.Click
        If LB_Defects.SelectedRows.Count < 1 Then
            MsgBox("No row selected to edit")
            Exit Sub
        End If

        Cmb_Defects.Text = LB_Defects.CurrentRow.Cells("Col_Defect").Value
        Chk_Paint.Checked = LB_Defects.CurrentRow.Cells("Col_Paint").Value
        Chk_Finesse.Checked = LB_Defects.CurrentRow.Cells("Col_Finesse").Value
        Chk_Mold.Checked = LB_Defects.CurrentRow.Cells("Col_Mold").Value
        Chk_Bond.Checked = LB_Defects.CurrentRow.Cells("Col_Bond").Value
        Chk_Assembly.Checked = LB_Defects.CurrentRow.Cells("Col_Assembly").Value
        Chk_Finishing.Checked = LB_Defects.CurrentRow.Cells("Col_Finishing").Value


        btn_Save_Defects_Confirm.Visible = True
        btn_Add_Defects_Confirm.Visible = False

        Pnl_Defects.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Defects_Add.Visible = False
        Btn_Defects_Edit.Visible = False
        Btn_Defects_Delete.Visible = False
        Btn_Inspections_Add.Visible = False
        Btn_Inspections_Edit.Visible = False
        Btn_Inspections_Delete.Visible = False


    End Sub

    Private Sub btn_Save_Defects_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Save_Defects_Confirm.Click
        Dim Query As String

        If Cmb_Defects.SelectedIndex < 0 Then
            MsgBox("Select a valid Defect To Update To the Part Type.")
            Exit Sub
        End If
        Query = "Update Part_Type_Defects set Defect_ID = " & Add_Defect_Array(Cmb_Defects.SelectedIndex) & ", Paint = " & IIf(Chk_Paint.Checked, 1, 0)
        Query = Query & ", Finesse = " & IIf(Chk_Finesse.Checked, 1, 0) & ", Mold = " & IIf(Chk_Mold.Checked, 1, 0) & ", Bond = " & IIf(Chk_Bond.Checked, 1, 0)
        Query = Query & ", Assembly = " & IIf(Chk_Assembly.Checked, 1, 0) & ", Finishing = " & IIf(Chk_Finishing.Checked, 1, 0) & " where id = " & LB_Defects.CurrentRow.Cells("Col_ID").Value

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(Query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Defects()



        Pnl_Defects.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Defects_Add.Visible = True
        Btn_Defects_Edit.Visible = True
        Btn_Defects_Delete.Visible = True
        Btn_Inspections_Add.Visible = True
        Btn_Inspections_Edit.Visible = True
        Btn_Inspections_Delete.Visible = True
    End Sub

    Sub Arrange_Image_Text()
        Dim int_Visible_Count As Integer = 0



        Lbl_Body_Image.Visible = False
        Txt_Body_Image.Visible = False
        Lbl_Fendoor_Image.Visible = False
        Txt_Fendoor_Image.Visible = False
        Lbl_Press_Image.Visible = False
        Txt_Press_Image.Visible = False
        Lbl_Assembly_Image.Visible = False
        Txt_Assembly_Image.Visible = False
        Lbl_Mold_Fin_Image.Visible = False
        Txt_Mold_Fin_Image.Visible = False
        Lbl_Paint_Fin_Image.Visible = False
        Txt_Paint_Fin_Image.Visible = False
        Lbl_HCC_Image.Visible = False
        Txt_HCC_Image.Visible = False
        Lbl_Bonding_Image.Visible = False
        Txt_Bonding_Image.Visible = False
        Lbl_Machining_Image.Visible = False
        Txt_Machining_Image.Visible = False
        Lbl_Paint_Image.Visible = False
        Txt_Paint_Image.Visible = False


        If Cbx_Body.Checked = True Then
            Lbl_Body_Image.Location = New Point(4, 642)
            Txt_Body_Image.Location = New Point(112, 639)
            Btn_Get_Body_Image.Location = New Point(382, 638)
            Lbl_Body_Image.Visible = True
            Txt_Body_Image.Visible = True
            int_Visible_Count += 1
            If Adding = True Or Editing = True Then
                Btn_Get_Body_Image.Visible = True
            Else
                Btn_Get_Body_Image.Visible = False
            End If
        Else
            Btn_Get_Body_Image.Visible = False
        End If

        If Cbx_Press.Checked = True Then
            Lbl_Press_Image.Location = New Point(4, 671)
            Txt_Press_Image.Location = New Point(112, 668)
            Btn_Get_Press_Image.Location = New Point(382, 667)
            Lbl_Press_Image.Visible = True
            Txt_Press_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Press_Image.Location = New Point(4, 642)
                Txt_Press_Image.Location = New Point(112, 639)
                Btn_Get_Press_Image.Location = New Point(382, 638)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Press_Image.Visible = True
            Else
                Btn_Get_Press_Image.Visible = False
            End If
        Else
            Btn_Get_Press_Image.Visible = False
        End If

        If Cbx_HCC.Checked = True Then
            Lbl_HCC_Image.Location = New Point(4, 700)
            Txt_HCC_Image.Location = New Point(112, 697)
            Btn_Get_HCC_Image.Location = New Point(382, 696)
            Lbl_HCC_Image.Visible = True
            Txt_HCC_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_HCC_Image.Location = New Point(4, 642)
                Txt_HCC_Image.Location = New Point(112, 639)
                Btn_Get_HCC_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_HCC_Image.Location = New Point(4, 671)
                Txt_HCC_Image.Location = New Point(112, 668)
                Btn_Get_HCC_Image.Location = New Point(382, 667)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_HCC_Image.Visible = True
            Else
                Btn_Get_HCC_Image.Visible = False
            End If
        Else
            Btn_Get_HCC_Image.Visible = False
        End If

        If Cbx_Bonding.Checked = True Then
            Lbl_Bonding_Image.Location = New Point(4, 729)
            Txt_Bonding_Image.Location = New Point(112, 726)
            Btn_Get_Bonding_Image.Location = New Point(382, 725)
            Lbl_Bonding_Image.Visible = True
            Txt_Bonding_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Bonding_Image.Location = New Point(4, 642)
                Txt_Bonding_Image.Location = New Point(112, 639)
                Btn_Get_Bonding_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Bonding_Image.Location = New Point(4, 671)
                Txt_Bonding_Image.Location = New Point(112, 668)
                Btn_Get_Bonding_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Bonding_Image.Location = New Point(4, 700)
                Txt_Bonding_Image.Location = New Point(112, 697)
                Btn_Get_Bonding_Image.Location = New Point(382, 696)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Bonding_Image.Visible = True
            Else
                Btn_Get_Bonding_Image.Visible = False
            End If
        Else
            Btn_Get_Bonding_Image.Visible = False
        End If

        If Cbx_Machining.Checked = True Then
            Lbl_Machining_Image.Location = New Point(4, 758)
            Txt_Machining_Image.Location = New Point(112, 755)
            Btn_Get_Machining_Image.Location = New Point(382, 754)
            Lbl_Machining_Image.Visible = True
            Txt_Machining_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Machining_Image.Location = New Point(4, 642)
                Txt_Machining_Image.Location = New Point(112, 639)
                Btn_Get_Machining_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Machining_Image.Location = New Point(4, 671)
                Txt_Machining_Image.Location = New Point(112, 668)
                Btn_Get_Machining_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Machining_Image.Location = New Point(4, 700)
                Txt_Machining_Image.Location = New Point(112, 697)
                Btn_Get_Machining_Image.Location = New Point(382, 696)
            End If
            If int_Visible_Count = 4 Then
                Lbl_Machining_Image.Location = New Point(4, 729)
                Txt_Machining_Image.Location = New Point(112, 726)
                Btn_Get_Machining_Image.Location = New Point(382, 725)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Machining_Image.Visible = True
            Else
                Btn_Get_Machining_Image.Visible = False
            End If
        Else
            Btn_Get_Machining_Image.Visible = False
        End If

        If Cbx_Assembly.Checked = True Then
            Lbl_Assembly_Image.Location = New Point(4, 787)
            Txt_Assembly_Image.Location = New Point(112, 784)
            Btn_Get_Assembly_Image.Location = New Point(382, 783)
            Lbl_Assembly_Image.Visible = True
            Txt_Assembly_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Assembly_Image.Location = New Point(4, 642)
                Txt_Assembly_Image.Location = New Point(112, 639)
                Btn_Get_Assembly_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Assembly_Image.Location = New Point(4, 671)
                Txt_Assembly_Image.Location = New Point(112, 668)
                Btn_Get_Assembly_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Assembly_Image.Location = New Point(4, 700)
                Txt_Assembly_Image.Location = New Point(112, 697)
                Btn_Get_Assembly_Image.Location = New Point(382, 696)
            End If
            If int_Visible_Count = 4 Then
                Lbl_Assembly_Image.Location = New Point(4, 729)
                Txt_Assembly_Image.Location = New Point(112, 726)
                Btn_Get_Assembly_Image.Location = New Point(382, 725)
            End If
            If int_Visible_Count = 5 Then
                Lbl_Assembly_Image.Location = New Point(4, 758)
                Txt_Assembly_Image.Location = New Point(112, 755)
                Btn_Get_Assembly_Image.Location = New Point(382, 754)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Assembly_Image.Visible = True
            Else
                Btn_Get_Assembly_Image.Visible = False
            End If
        Else
            Btn_Get_Assembly_Image.Visible = False
        End If

        If Cbx_Fendoor.Checked = True Then
            Lbl_Fendoor_Image.Location = New Point(417, 642)
            Txt_Fendoor_Image.Location = New Point(519, 639)
            Btn_Get_Fendoor_Image.Location = New Point(790, 638)
            Lbl_Fendoor_Image.Visible = True
            Txt_Fendoor_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Fendoor_Image.Location = New Point(4, 642)
                Txt_Fendoor_Image.Location = New Point(112, 639)
                Btn_Get_Fendoor_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Fendoor_Image.Location = New Point(4, 671)
                Txt_Fendoor_Image.Location = New Point(112, 668)
                Btn_Get_Fendoor_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Fendoor_Image.Location = New Point(4, 700)
                Txt_Fendoor_Image.Location = New Point(112, 697)
                Btn_Get_Fendoor_Image.Location = New Point(382, 696)
            End If
            If int_Visible_Count = 4 Then
                Lbl_Fendoor_Image.Location = New Point(4, 729)
                Txt_Fendoor_Image.Location = New Point(112, 726)
                Btn_Get_Fendoor_Image.Location = New Point(382, 725)
            End If
            If int_Visible_Count = 5 Then
                Lbl_Fendoor_Image.Location = New Point(4, 758)
                Txt_Fendoor_Image.Location = New Point(112, 755)
                Btn_Get_Fendoor_Image.Location = New Point(382, 754)
            End If
            If int_Visible_Count = 6 Then
                Lbl_Fendoor_Image.Location = New Point(4, 787)
                Txt_Fendoor_Image.Location = New Point(112, 784)
                Btn_Get_Fendoor_Image.Location = New Point(382, 783)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Fendoor_Image.Visible = True
            Else
                Btn_Get_Fendoor_Image.Visible = False
            End If
        Else
            Btn_Get_Fendoor_Image.Visible = False
        End If

        If Cbx_Mold.Checked = True Then
            Lbl_Mold_Fin_Image.Location = New Point(417, 671)
            Txt_Mold_Fin_Image.Location = New Point(519, 668)
            Btn_Get_Mold_Fin_Image.Location = New Point(790, 667)
            Lbl_Mold_Fin_Image.Visible = True
            Txt_Mold_Fin_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Mold_Fin_Image.Location = New Point(4, 642)
                Txt_Mold_Fin_Image.Location = New Point(112, 639)
                Btn_Get_Mold_Fin_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Mold_Fin_Image.Location = New Point(4, 671)
                Txt_Mold_Fin_Image.Location = New Point(112, 668)
                Btn_Get_Mold_Fin_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Mold_Fin_Image.Location = New Point(4, 700)
                Txt_Mold_Fin_Image.Location = New Point(112, 697)
                Btn_Get_Mold_Fin_Image.Location = New Point(382, 696)
            End If
            If int_Visible_Count = 4 Then
                Lbl_Mold_Fin_Image.Location = New Point(4, 729)
                Txt_Mold_Fin_Image.Location = New Point(112, 726)
                Btn_Get_Mold_Fin_Image.Location = New Point(382, 725)
            End If
            If int_Visible_Count = 5 Then
                Lbl_Mold_Fin_Image.Location = New Point(4, 758)
                Txt_Mold_Fin_Image.Location = New Point(112, 755)
                Btn_Get_Mold_Fin_Image.Location = New Point(382, 754)
            End If
            If int_Visible_Count = 6 Then
                Lbl_Mold_Fin_Image.Location = New Point(4, 787)
                Txt_Mold_Fin_Image.Location = New Point(112, 784)
                Btn_Get_Mold_Fin_Image.Location = New Point(382, 783)
            End If
            If int_Visible_Count = 7 Then
                Lbl_Mold_Fin_Image.Location = New Point(417, 642)
                Txt_Mold_Fin_Image.Location = New Point(519, 639)
                Btn_Get_Mold_Fin_Image.Location = New Point(790, 638)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Mold_Fin_Image.Visible = True
            Else
                Btn_Get_Mold_Fin_Image.Visible = False
            End If
        Else
            Btn_Get_Mold_Fin_Image.Visible = False
        End If

        If Cbx_Paint_Fin.Checked = True Then
            Lbl_Paint_Fin_Image.Location = New Point(417, 700)
            Txt_Paint_Fin_Image.Location = New Point(519, 697)
            Btn_Get_Paint_Fin_Image.Location = New Point(790, 696)
            Lbl_Paint_Fin_Image.Visible = True
            Txt_Paint_Fin_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Paint_Fin_Image.Location = New Point(4, 642)
                Txt_Paint_Fin_Image.Location = New Point(112, 639)
                Btn_Get_Paint_Fin_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Paint_Fin_Image.Location = New Point(4, 671)
                Txt_Paint_Fin_Image.Location = New Point(112, 668)
                Btn_Get_Paint_Fin_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Paint_Fin_Image.Location = New Point(4, 700)
                Txt_Paint_Fin_Image.Location = New Point(112, 697)
                Btn_Get_Paint_Fin_Image.Location = New Point(382, 696)
            End If
            If int_Visible_Count = 4 Then
                Lbl_Paint_Fin_Image.Location = New Point(4, 729)
                Txt_Paint_Fin_Image.Location = New Point(112, 726)
                Btn_Get_Paint_Fin_Image.Location = New Point(382, 725)
            End If
            If int_Visible_Count = 5 Then
                Lbl_Paint_Fin_Image.Location = New Point(4, 758)
                Txt_Paint_Fin_Image.Location = New Point(112, 755)
                Btn_Get_Paint_Fin_Image.Location = New Point(382, 754)
            End If
            If int_Visible_Count = 6 Then
                Lbl_Paint_Fin_Image.Location = New Point(4, 787)
                Txt_Paint_Fin_Image.Location = New Point(112, 784)
                Btn_Get_Paint_Fin_Image.Location = New Point(382, 783)
            End If
            If int_Visible_Count = 7 Then
                Lbl_Paint_Fin_Image.Location = New Point(417, 642)
                Txt_Paint_Fin_Image.Location = New Point(519, 639)
                Btn_Get_Paint_Fin_Image.Location = New Point(790, 638)
            End If
            If int_Visible_Count = 8 Then
                Lbl_Paint_Fin_Image.Location = New Point(417, 671)
                Txt_Paint_Fin_Image.Location = New Point(519, 668)
                Btn_Get_Paint_Fin_Image.Location = New Point(790, 667)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Paint_Fin_Image.Visible = True
            Else
                Btn_Get_Paint_Fin_Image.Visible = False
            End If
        Else
            Btn_Get_Paint_Fin_Image.Visible = False
        End If

        If Cbx_Paint.Checked = True Then
            Lbl_Paint_Image.Location = New Point(417, 729)
            Txt_Paint_Image.Location = New Point(519, 726)
            Btn_Get_Paint_Image.Location = New Point(790, 725)
            Lbl_Paint_Image.Visible = True
            Txt_Paint_Image.Visible = True
            int_Visible_Count += 1
            If int_Visible_Count = 1 Then
                Lbl_Paint_Image.Location = New Point(4, 642)
                Txt_Paint_Image.Location = New Point(112, 639)
                Btn_Get_Paint_Image.Location = New Point(382, 638)
            End If
            If int_Visible_Count = 2 Then
                Lbl_Paint_Image.Location = New Point(4, 671)
                Txt_Paint_Image.Location = New Point(112, 668)
                Btn_Get_Paint_Image.Location = New Point(382, 667)
            End If
            If int_Visible_Count = 3 Then
                Lbl_Paint_Image.Location = New Point(4, 700)
                Txt_Paint_Image.Location = New Point(112, 697)
                Btn_Get_Paint_Image.Location = New Point(382, 696)
            End If
            If int_Visible_Count = 4 Then
                Lbl_Paint_Image.Location = New Point(4, 729)
                Txt_Paint_Image.Location = New Point(112, 726)
                Btn_Get_Paint_Image.Location = New Point(382, 725)
            End If
            If int_Visible_Count = 5 Then
                Lbl_Paint_Image.Location = New Point(4, 758)
                Txt_Paint_Image.Location = New Point(112, 755)
                Btn_Get_Paint_Image.Location = New Point(382, 754)
            End If
            If int_Visible_Count = 6 Then
                Lbl_Paint_Image.Location = New Point(4, 787)
                Txt_Paint_Image.Location = New Point(112, 784)
                Btn_Get_Paint_Image.Location = New Point(382, 783)
            End If
            If int_Visible_Count = 7 Then
                Lbl_Paint_Image.Location = New Point(417, 642)
                Txt_Paint_Image.Location = New Point(519, 639)
                Btn_Get_Paint_Image.Location = New Point(790, 638)
            End If
            If int_Visible_Count = 8 Then
                Lbl_Paint_Image.Location = New Point(417, 671)
                Txt_Paint_Image.Location = New Point(519, 668)
                Btn_Get_Paint_Image.Location = New Point(790, 667)
            End If
            If int_Visible_Count = 9 Then
                Lbl_Paint_Image.Location = New Point(417, 700)
                Txt_Paint_Image.Location = New Point(519, 697)
                Btn_Get_Paint_Image.Location = New Point(790, 696)
            End If
            If Adding = True Or Editing = True Then
                Btn_Get_Paint_Image.Visible = True
            Else
                Btn_Get_Paint_Image.Visible = False
            End If
        Else
            Btn_Get_Paint_Image.Visible = False
        End If

    End Sub

    Private Sub Cbx_Body_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Body.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Press_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Press.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_HCC_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_HCC.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Bonding_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Bonding.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Machining_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Machining.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Assembly_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Assembly.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Fendoor_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Fendoor.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Mold_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Mold.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Paint_Fin_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Paint_Fin.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Cbx_Paint_CheckedChanged(sender As Object, e As EventArgs) Handles Cbx_Paint.CheckedChanged
        Arrange_Image_Text()
    End Sub

    Private Sub Btn_Get_Body_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Body_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Body_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Press_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Press_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Press_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_HCC_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_HCC_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_HCC_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Bonding_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Bonding_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Bonding_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Machining_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Machining_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Machining_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Assembly_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Assembly_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Assembly_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Fendoor_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Fendoor_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Fendoor_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Mold_Fin_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Mold_Fin_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Mold_Fin_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Paint_Fin_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Paint_Fin_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Paint_Fin_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub

    Private Sub Btn_Get_Paint_Image_Click(sender As Object, e As EventArgs) Handles Btn_Get_Paint_Image.Click
        Dim result As DialogResult
        result = Dlg_Get_Image.ShowDialog()

        If result = DialogResult.OK Then
            Txt_Paint_Image.Text = Dlg_Get_Image.SafeFileName
        End If
    End Sub
End Class