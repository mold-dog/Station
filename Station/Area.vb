Imports System.Data.SqlClient
Public Class Area
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim areas() As Int32
    Dim sub_areas() As Int32
    Private Sub Btn_Area_Add_Click(sender As Object, e As EventArgs) Handles Btn_Area_Add.Click
        Txt_Area.Text = ""
        Txt_Area.Visible = True
        Cmb_Area.Visible = False
        Btn_Area_Save.Visible = True
        Btn_Area_Cancel.Visible = True
        Btn_Area_Add.Visible = False
        Btn_Area_Edit.Visible = False
        Btn_Area_Delete.Visible = False
        Btn_Sub_Area_Add.Visible = False
        Btn_Sub_Area_Delete.Visible = False
        Opt_None.Enabled = True
        Opt_Scrap.Enabled = True
        Opt_Ship.Enabled = True
        Opt_Exit.Enabled = True
        Chk_Targets.Enabled = True


        LB_Sub_area.Items.Clear()
        Adding = True


    End Sub

    Private Sub Btn_Area_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Area_Edit.Click
        Txt_Area.Visible = True
        Cmb_Area.Visible = False
        Btn_Area_Save.Visible = True
        Btn_Area_Cancel.Visible = True
        Btn_Area_Add.Visible = False
        Btn_Area_Edit.Visible = False
        Btn_Area_Delete.Visible = False
        Btn_Sub_Area_Add.Visible = False
        Btn_Sub_Area_Delete.Visible = False
        Txt_Area.Text = Cmb_Area.Text
        Opt_None.Enabled = True
        Opt_Scrap.Enabled = True
        Opt_Ship.Enabled = True
        Opt_Exit.Enabled = True
        Chk_Targets.Enabled = True


        Editing = True

    End Sub

    Private Sub Btn_Area_Save_Click(sender As Object, e As EventArgs) Handles Btn_Area_Save.Click
        SQLCon.Open()
        Dim cmd As New SqlCommand("", SQLCon)

        If Adding Then
            cmd.CommandText = "Insert into area (description, Shipped, Scrap, [Exit], Targets) values ('" & Txt_Area.Text & "', " & IIf(Opt_Ship.Checked, 1, 0) & ", " & IIf(Opt_Scrap.Checked, 1, 0) & ", " & IIf(Opt_Exit.Checked, 1, 0) & ", " & IIf(Chk_Targets.Checked, 1, 0) & ")"
        Else
            cmd.CommandText = "update area Set description = '" & Txt_Area.Text & "', Shipped = " & IIf(Opt_Ship.Checked, 1, 0) & ", Scrap = " & IIf(Opt_Scrap.Checked, 1, 0) & ", [Exit] = " & IIf(Opt_Exit.Checked, 1, 0) & ", Targets = " & IIf(Chk_Targets.Checked, 1, 0) & " where id = " & areas(Cmb_Area.SelectedIndex)
        End If
        cmd.ExecuteNonQuery()
        SQLCon.Close()

        Cmb_Area.Visible = True
        Txt_Area.Visible = False
        Btn_Area_Save.Visible = False
        Btn_Area_Cancel.Visible = False
        Btn_Area_Add.Visible = True
        Btn_Area_Edit.Visible = False
        Btn_Area_Delete.Visible = False
        Btn_Sub_Area_Add.Visible = False
        Btn_Sub_Area_Delete.Visible = False

        Editing = False
        Adding = False

        Call Load_Areas()
        LB_Sub_area.Items.Clear()
        Cmb_Area.Text = ""
        Opt_None.Enabled = False
        Opt_Scrap.Enabled = False
        Opt_Ship.Enabled = False
        Opt_Exit.Enabled = False
        Chk_Targets.Enabled = False




    End Sub

    Private Sub Btn_Area_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Area_Cancel.Click

        Txt_Area.Visible = False
        Cmb_Area.Visible = True
        Btn_Area_Save.Visible = False
        Btn_Area_Cancel.Visible = False
        Btn_Area_Add.Visible = True
        Btn_Area_Edit.Visible = True
        Btn_Area_Delete.Visible = True
        Btn_Sub_Area_Add.Visible = True
        Btn_Sub_Area_Delete.Visible = True

        Opt_None.Enabled = False
        Opt_Scrap.Enabled = False
        Opt_Ship.Enabled = False
        Opt_Exit.Enabled = False
        Chk_Targets.Enabled = False

        Editing = False
        Adding = False

    End Sub

    Sub Load_Areas()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            Cmb_Sub_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout

            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim areas(0)
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                Cmb_Sub_Area.Items.Add(dr("Description"))
                ReDim Preserve areas(counter)
                areas(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Areas Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Areas()
        Btn_Area_Add.Enabled = User_Permissions_Edit_Config
        Btn_Area_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Area_Delete.Enabled = User_Permissions_Edit_Config
        Btn_Sub_Area_Add.Enabled = User_Permissions_Edit_Config
        Btn_Sub_Area_Delete.Enabled = User_Permissions_Edit_Config
    End Sub
    Sub Load_Sub_Areas()

        Dim counter As Integer = 0
        Try
            Txt_Area.Text = Cmb_Area.Text
            LB_Sub_area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from sub_area inner join area on sub_area.sub_area_id = area.id where sub_area.area_id = " & areas(Cmb_Area.SelectedIndex), SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Sub_Area")
            SQLCon.Close()
            ReDim sub_areas(0)
            For Each dr As DataRow In ds.Tables("Sub_Area").Rows

                LB_Sub_area.Items.Add(dr("Description"))

                ReDim Preserve sub_areas(counter)
                sub_areas(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Areas Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Data()

        Dim counter As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from area where id = " & areas(Cmb_Area.SelectedIndex), SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Area").Rows
                Opt_None.Checked = True
                Opt_Ship.Checked = IIf(dr("Shipped") & "" = "True", True, False)
                Opt_Scrap.Checked = IIf(dr("Scrap") & "" = "True", True, False)
                Opt_Exit.Checked = IIf(dr("Exit") & "" = "True", True, False)
                Chk_Targets.Checked = IIf(dr("Targets") & "" = "True", True, False)
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Areas Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Cmb_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Area.SelectedIndexChanged
        Call Load_Data()
        Call Load_Sub_Areas()
        Btn_Sub_Area_Add.Visible = True
        Btn_Sub_Area_Delete.Visible = True
        Btn_Area_Edit.Visible = True
        Btn_Area_Delete.Visible = True
    End Sub

    Private Sub Btn_Sub_Area_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Sub_Area_Delete.Click
        If LB_Sub_area.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from sub_area where sub_area.id = " & sub_areas(LB_Sub_area.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Sub_Areas()


    End Sub

    Private Sub Btn_Sub_Area_Add_Click(sender As Object, e As EventArgs) Handles Btn_Sub_Area_Add.Click
        Pnl_Sub_Area.Visible = True

        Cmb_Area.Enabled = False
        Btn_Area_Add.Visible = False
        Btn_Area_Edit.Visible = False
        Btn_Area_Delete.Visible = False
        Btn_Sub_Area_Add.Visible = False
        Btn_Sub_Area_Delete.Visible = False

    End Sub

    Private Sub btn_Add_Sub_Area_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Add_Sub_Area_Confirm.Click
        If Cmb_Sub_Area.SelectedIndex < 0 Then
            MsgBox("Select a valid Area to assign as a sub-area.")
            Exit Sub
        End If
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("Insert into sub_area (Area_ID, Sub_Area_ID) values (" & areas(Cmb_Area.SelectedIndex) & ", " & areas(Cmb_Sub_Area.SelectedIndex) & ")", SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Sub_Areas()



        Pnl_Sub_Area.Visible = False

        Cmb_Area.Enabled = True
        Btn_Area_Add.Visible = True
        Btn_Area_Edit.Visible = True
        Btn_Area_Delete.Visible = True
        Btn_Sub_Area_Add.Visible = True
        Btn_Sub_Area_Delete.Visible = True


    End Sub

    Private Sub Btn_Add_Sub_Area_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Add_Sub_Area_Cancel.Click
        Pnl_Sub_Area.Visible = False

        Cmb_Area.Enabled = True
        Btn_Area_Add.Visible = True
        Btn_Area_Edit.Visible = True
        Btn_Area_Delete.Visible = True
        Btn_Sub_Area_Add.Visible = True
        Btn_Sub_Area_Delete.Visible = True

    End Sub

    Private Sub Btn_Area_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Area_Delete.Click
        If Cmb_Area.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from sub_area where sub_area_id = " & areas(Cmb_Area.SelectedIndex) & " Or area_id = " & areas(Cmb_Area.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        cmd.CommandText = "delete from area where id = " & areas(Cmb_Area.SelectedIndex)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Areas()
        LB_Sub_area.Items.Clear()
        Cmb_Area.Text = ""

        Btn_Area_Edit.Visible = False
        Btn_Area_Delete.Visible = False
        Btn_Sub_Area_Add.Visible = False
        Btn_Sub_Area_Delete.Visible = False




    End Sub


End Class