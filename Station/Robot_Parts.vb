Imports System.Data.SqlClient
Public Class Robot_Parts
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Opt_Bell.Enabled = True
        Opt_Spray_Head.Enabled = True
        Opt_Air_Cap.Enabled = True
        Opt_Retaining_Ring.Enabled = True
        Chk_Base.Enabled = True
        Chk_Clear.Enabled = True
        Chk_In_Service.Enabled = True
        Chk_In_Service.Checked = True


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
        Opt_Bell.Enabled = True
        Opt_Spray_Head.Enabled = True
        Opt_Air_Cap.Enabled = True
        Opt_Retaining_Ring.Enabled = True
        Chk_Base.Enabled = True
        Chk_Clear.Enabled = True
        Chk_In_Service.Enabled = True
        Txt_Description.Text = Cmb_Description.Text

        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        SQLCon.Open()
        Dim cmd As New SqlCommand("", SQLCon)

        If Adding Then
            cmd.CommandText = "Insert into Robot_Part (description, Bell, Spray_Head, Air_Cap, Retaining_Ring, Base, Clear, In_Service) values ('" & Txt_Description.Text & "', "
            cmd.CommandText = cmd.CommandText & IIf(Opt_Bell.Checked, 1, 0) & ", " & IIf(Opt_Spray_Head.Checked, 1, 0) & ", " & IIf(Opt_Air_Cap.Checked, 1, 0) & ", " & IIf(Opt_Retaining_Ring.Checked, 1, 0)
            cmd.CommandText = cmd.CommandText & ", " & IIf(Chk_Base.Checked, 1, 0) & ", " & IIf(Chk_Clear.Checked, 1, 0) & ", " & IIf(Chk_In_Service.Checked, 1, 0) & ")"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                SQLCon.Close()
                Exit Sub
            End If
            cmd.CommandText = "update Robot_PArt Set description = '" & Txt_Description.Text & "', Bell = " & IIf(Opt_Bell.Checked, 1, 0) & ", Spray_Head = " & IIf(Opt_Spray_Head.Checked, 1, 0)
            cmd.CommandText = cmd.CommandText & ", Air_Cap = " & IIf(Opt_Air_Cap.Checked, 1, 0) & ", Retaining_Ring = " & IIf(Opt_Retaining_Ring.Checked, 1, 0) & ", Base = " & IIf(Chk_Base.Checked, 1, 0)
            cmd.CommandText = cmd.CommandText & ", Clear = " & IIf(Chk_Clear.Checked, 1, 0) & ", In_Service = " & IIf(Chk_In_Service.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
        End If
        cmd.ExecuteNonQuery()
        SQLCon.Close()

        Cmb_Description.Visible = True
        Txt_Description.Visible = False
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Opt_Bell.Enabled = False
        Opt_Spray_Head.Enabled = False
        Opt_Air_Cap.Enabled = False
        Opt_Retaining_Ring.Enabled = False
        Chk_Base.Enabled = False
        Chk_Clear.Enabled = False
        Chk_In_Service.Enabled = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        Opt_Bell.Checked = False
        Opt_Spray_Head.Checked = False
        Opt_Air_Cap.Checked = False
        Opt_Retaining_Ring.Checked = False
        Chk_Base.Checked = False
        Chk_Clear.Checked = False
        Chk_In_Service.Checked = False




    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Opt_Bell.Enabled = False
        Opt_Spray_Head.Enabled = False
        Opt_Air_Cap.Enabled = False
        Opt_Retaining_Ring.Enabled = False
        Chk_Base.Enabled = False
        Chk_Clear.Enabled = False
        Chk_In_Service.Enabled = False

        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Robot_Part order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Part")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Robot_Part").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Robot Part Info from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from Robot_Part where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        Opt_Bell.Checked = False
        Opt_Spray_Head.Checked = False
        Opt_Air_Cap.Checked = False
        Opt_Retaining_Ring.Checked = False
        Chk_Base.Checked = False
        Chk_Clear.Checked = False
        Chk_In_Service.Checked = False

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False




    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from Robot_Part where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Robot_Part")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Robot_Part").Rows
            Opt_Bell.Checked = dr("Bell") & ""
            Opt_Spray_Head.Checked = dr("Spray_Head") & ""
            Opt_Air_Cap.Checked = dr("Air_Cap") & ""
            Opt_Retaining_Ring.Checked = dr("Retaining_Ring") & ""
            Chk_Base.Checked = dr("Base") & ""
            Chk_Clear.Checked = dr("Clear") & ""
            Chk_In_Service.Checked = dr("In_Service") & ""
        Next

    End Sub

    Private Sub Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

    End Sub

End Class