Imports System.Data.SqlClient
Public Class Users
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Password.Text = ""
        Txt_Username.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Password.Enabled = True
        Txt_Username.Enabled = True
        Chk_View_Config.Enabled = True
        Chk_Edit_Config.Enabled = True
        Chk_Access_Paint_Area.Enabled = True
        Chk_Access_Targets.Enabled = True
        Chk_User_Management.Enabled = True
        Chk_Operator_Management.Enabled = True
        Chk_Access_Part_Tracking.Enabled = True
        Chk_Access_Defects.Enabled = True
        Chk_Access_Inspections.Enabled = True
        Chk_Change_Robot_Parts.Enabled = True
        Chk_Kill_Tag.Enabled = True
        Chk_Access_Press_Area.Enabled = True

        Chk_View_Config.Checked = False
        Chk_Edit_Config.Checked = False
        Chk_Access_Paint_Area.Checked = False
        Chk_Access_Targets.Checked = False
        Chk_User_Management.Checked = False
        Chk_Operator_Management.Checked = False
        Chk_Access_Part_Tracking.Checked = False
        Chk_Access_Defects.Checked = False
        Chk_Access_Inspections.Checked = False
        Chk_Change_Robot_Parts.Checked = False
        Chk_Kill_Tag.Checked = False
        Chk_Access_Press_Area.Checked = False

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
        txt_Password.Enabled = True
        Txt_Username.Enabled = True
        Txt_Description.Text = Cmb_Description.Text

        Chk_View_Config.Enabled = True
        Chk_Edit_Config.Enabled = True
        Chk_Access_Paint_Area.Enabled = True
        Chk_Access_Targets.Enabled = True
        Chk_User_Management.Enabled = True
        Chk_Operator_Management.Enabled = True
        Chk_Access_Part_Tracking.Enabled = True
        Chk_Access_Defects.Enabled = True
        Chk_Access_Inspections.Enabled = True
        Chk_Change_Robot_Parts.Enabled = True
        Chk_Kill_Tag.Enabled = True
        Chk_Access_Press_Area.Enabled = True


        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data




        If Adding Then
            query = "Insert into users (name, User_Name, password, View_Config, Edit_Config, Access_Paint_Area, Access_Targets,"
            query = query & " User_Management, Access_Part_Tracking, Access_Defects, Access_Inspections, Change_Robot_Parts, "
            query = query & "Access_Kill, Access_Press_Area, Operator_Management) values ('" & Txt_Description.Text & "', '" & Txt_Username.Text & "', '"
            query = query & txt_Password.Text & "', " & IIf(Chk_View_Config.Checked, 1, 0) & ", " & IIf(Chk_Edit_Config.Checked, 1, 0) & ", "
            query = query & IIf(Chk_Access_Paint_Area.Checked, 1, 0) & ", " & IIf(Chk_Access_Targets.Checked, 1, 0) & ", " & IIf(Chk_User_Management.Checked, 1, 0) & ", "
            query = query & IIf(Chk_Access_Part_Tracking.Checked, 1, 0) & ", " & IIf(Chk_Access_Defects.Checked, 1, 0) & ", "
            query = query & IIf(Chk_Access_Inspections.Checked, 1, 0) & ", " & IIf(Chk_Change_Robot_Parts.Checked, 1, 0)
            query = query & ", " & IIf(Chk_Kill_Tag.Checked, 1, 0) & ", " & IIf(Chk_Access_Press_Area.Checked, 1, 0) & ", " & IIf(Chk_Operator_Management.Checked, 1, 0) & ") "
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update users Set name = '" & Txt_Description.Text & "', User_Name = '" & Txt_Username.Text & "', password = '" & txt_Password.Text & "',  "
            query = query & "Edit_Config = " & IIf(Chk_Edit_Config.Checked, 1, 0) & ", access_Targets = " & IIf(Chk_Access_Targets.Checked, 1, 0) & ", View_Config = " & IIf(Chk_View_Config.Checked, 1, 0) & ", "
            query = query & "Access_Paint_Area = " & IIf(Chk_Access_Paint_Area.Checked, 1, 0) & ", User_Management = " & IIf(Chk_User_Management.Checked, 1, 0) & ", "
            query = query & "Access_Part_Tracking = " & IIf(Chk_Access_Part_Tracking.Checked, 1, 0) & ", Access_Defects = " & IIf(Chk_Access_Defects.Checked, 1, 0) & ", "
            query = query & "Access_Inspections = " & IIf(Chk_Access_Inspections.Checked, 1, 0) & ", Change_Robot_Parts = " & IIf(Chk_Change_Robot_Parts.Checked, 1, 0) & ", "
            query = query & "Access_Kill = " & IIf(Chk_Kill_Tag.Checked, 1, 0) & ", Access_Press_Area = " & IIf(Chk_Access_Press_Area.Checked, 1, 0) & ", "
            query = query & "Operator_Management = " & IIf(Chk_Operator_Management.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        txt_Password.Enabled = False
        Txt_Username.Enabled = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Password.Text = ""
        Txt_Username.Text = ""
        Chk_View_Config.Enabled = False
        Chk_Edit_Config.Enabled = False
        Chk_Access_Paint_Area.Enabled = False
        Chk_Access_Targets.Enabled = False
        Chk_User_Management.Enabled = False
        Chk_Operator_Management.Enabled = False
        Chk_Access_Part_Tracking.Enabled = False
        Chk_Access_Defects.Enabled = False
        Chk_Access_Inspections.Enabled = False
        Chk_Change_Robot_Parts.Enabled = False
        Chk_Kill_Tag.Enabled = False
        Chk_Access_Press_Area.Enabled = False

        Chk_View_Config.Checked = False
        Chk_Edit_Config.Checked = False
        Chk_Access_Paint_Area.Checked = False
        Chk_Access_Targets.Checked = False
        Chk_User_Management.Checked = False
        Chk_Operator_Management.Checked = False
        Chk_Access_Part_Tracking.Checked = False
        Chk_Access_Defects.Checked = False
        Chk_Access_Inspections.Checked = False
        Chk_Change_Robot_Parts.Checked = False
        Chk_Kill_Tag.Checked = False
        Chk_Access_Press_Area.Checked = False

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        txt_Password.Enabled = False
        txt_Password.Text = ""
        Txt_Username.Enabled = False
        Txt_Username.Text = ""

        Chk_View_Config.Enabled = False
        Chk_Edit_Config.Enabled = False
        Chk_Access_Paint_Area.Enabled = False
        Chk_Access_Targets.Enabled = False
        Chk_User_Management.Enabled = False
        Chk_Operator_Management.Enabled = False
        Chk_Access_Part_Tracking.Enabled = False
        Chk_Access_Defects.Enabled = False
        Chk_Access_Inspections.Enabled = False
        Chk_Change_Robot_Parts.Enabled = False
        Chk_Kill_Tag.Enabled = False
        Chk_Access_Press_Area.Enabled = False

        Chk_View_Config.Checked = False
        Chk_Edit_Config.Checked = False
        Chk_Access_Paint_Area.Checked = False
        Chk_Access_Targets.Checked = False
        Chk_User_Management.Checked = False
        Chk_Operator_Management.Checked = False
        Chk_Access_Part_Tracking.Checked = False
        Chk_Access_Defects.Checked = False
        Chk_Access_Inspections.Checked = False
        Chk_Change_Robot_Parts.Checked = False
        Chk_Kill_Tag.Checked = False
        Chk_Access_Press_Area.Checked = False


        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from users order by name", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Users")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Users").Rows
                Cmb_Description.Items.Add(dr("Name"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Users Info from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from Users where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Password.Text = ""
        Txt_Username.Text = ""
        Chk_View_Config.Checked = False
        Chk_Edit_Config.Checked = False
        Chk_Access_Paint_Area.Checked = False
        Chk_Access_Targets.Checked = False
        Chk_User_Management.Checked = False
        Chk_Operator_Management.Checked = False
        Chk_Change_Robot_Parts.Checked = False
        Chk_Kill_Tag.Checked = False
        Chk_Access_Press_Area.Checked = False

        Chk_Access_Part_Tracking.Checked = False
        Chk_Access_Defects.Checked = False
        Chk_Access_Inspections.Checked = False

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from Users where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Users")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Users").Rows
            Txt_Username.Text = dr("User_Name") & ""
            txt_Password.Text = dr("Password") & ""
            Chk_Edit_Config.Checked = dr("Edit_Config") & ""
            Chk_Access_Targets.Checked = dr("Access_Targets") & ""
            Chk_View_Config.Checked = dr("View_Config") & ""
            Chk_Access_Paint_Area.Checked = dr("Access_Paint_Area") & ""
            Chk_Access_Part_Tracking.Checked = dr("Access_Part_Tracking") & ""
            Chk_Access_Defects.Checked = dr("Access_Defects") & ""
            Chk_Access_Inspections.Checked = dr("Access_Inspections") & ""
            Chk_User_Management.Checked = dr("User_Management") & ""
            Chk_Operator_Management.Checked = dr("Operator_Management") & ""
            Chk_Change_Robot_Parts.Checked = dr("Change_Robot_Parts") & ""
            Chk_Kill_Tag.Checked = IIf(IsDBNull(dr("Access_Kill")), False, dr("Access_Kill"))
            Chk_Access_Press_Area.Checked = dr("Access_Press_Area") & ""

        Next


    End Sub

    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()

    End Sub


End Class