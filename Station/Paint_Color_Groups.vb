Imports System.Data.SqlClient
Public Class Paint_Color_Groups
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Recipe_Array() As Int32
    Dim Paint_Color_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        'Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False


        LB_Recipe.Items.Clear()

        Adding = True


    End Sub

    'Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
    '    Txt_Description.Visible = True
    '    Cmb_Description.Visible = False
    '    Btn_Save.Visible = True
    '    Btn_Cancel.Visible = True
    '    Btn_Add.Visible = False
    '    Btn_Edit.Visible = False
    '    Btn_Delete.Visible = False
    '    Btn_Recipe_Add.Visible = False
    '    Btn_Recipe_Delete.Visible = False

    '    Txt_Description.Text = Cmb_Description.Text


    '    Editing = True

    'End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data




        If Adding Then
            query = "Insert into Paint_Color_Groups (Color_Group_Name) " & " values ('" & Txt_Description.Text & "')"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            'query = "update Final_color Set description = '" & Txt_Description.Text & "', spanish = '" & txt_Spanish.Text & "', Code = '" & Txt_Code.Text & "', "
            'query = query & "Start_Date = '" & DTP_Start_Date.Text & "', end_date = '" & DTP_End_Date.Text & "' where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        'Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False



        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        'Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True


        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Paint_Color_Groups order by Color_Group_Name", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Color_Groups")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Color_Groups").Rows
                Cmb_Description.Items.Add(dr("Color_Group_Name"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Description.SelectedIndexChanged
        Call Load_Data()
        'Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True

    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from Paint_Color_Groups where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        cmd.CommandText = "update paint_color set color_group = 0 where Color_Group =" & ID_Array(Cmb_Description.SelectedIndex)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""


        LB_Recipe.Items.Clear()


        'Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False



    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        'Dim counter As Integer = 0

        'SQLCon.ConnectionString = DBConnection
        'SQLCon.Open()
        'Dim da As New SqlDataAdapter("Select * from Final_Color where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        'da.SelectCommand.CommandTimeout = SQL_Timeout
        'Dim ds As New DataSet
        'da.Fill(ds, "Final_Color")
        'SQLCon.Close()

        'For Each dr As DataRow In ds.Tables("Final_Color").Rows
        '    txt_Spanish.Text = dr("Spanish") & ""
        '    Txt_Code.Text = dr("Code") & ""
        '    DTP_Start_Date.Text = dr("start_date") & ""
        '    DTP_End_Date.Text = dr("end_date") & ""
        'Next

        Call Load_Groups()


    End Sub

    Private Sub Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Call Load_Add_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        'Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config
        Btn_Recipe_Add.Enabled = User_Permissions_Edit_Config
        Btn_Recipe_Delete.Enabled = User_Permissions_Edit_Config

    End Sub

    Private Sub Btn_Add_Recipe_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Add_Recipe_Cancel.Click
        Pnl_Recipe.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        'Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True

    End Sub

    Private Sub btn_Add_Recipe_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Add_Recipe_Confirm.Click
        If Cmb_Recipe.SelectedIndex < 0 Then
            MsgBox("Select a valid Paint Color to add to the recipe.")
            Exit Sub
        End If
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("Update Paint_Color Set Color_Group = " & ID_Array(Cmb_Description.SelectedIndex) & " Where ID = " & Paint_Color_Array(Cmb_Recipe.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Groups()



        Pnl_Recipe.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        'Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True

    End Sub
    Sub Load_Groups()
        Dim Query As String
        Dim counter As Integer = 0
        Try

            Query = "Select ID, Description, PLC_Color from Paint_Color "
            Query = Query & "where Color_Group = " & ID_Array(Cmb_Description.SelectedIndex) & " Order by PLC_Color"

            LB_Recipe.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(Query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Colors")
            SQLCon.Close()
            ReDim Recipe_Array(0)
            For Each dr As DataRow In ds.Tables("Colors").Rows

                LB_Recipe.Items.Add(dr("PLC_Color") & "  " & dr("Description"))

                ReDim Preserve Recipe_Array(counter)
                Recipe_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Color Group Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Recipe_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Recipe_Delete.Click
        If LB_Recipe.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("update paint_color set color_group = 0 where ID = " & Recipe_Array(LB_Recipe.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Groups()

    End Sub

    Private Sub Btn_Recipe_Add_Click(sender As Object, e As EventArgs) Handles Btn_Recipe_Add.Click
        Pnl_Recipe.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        'Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False

    End Sub
    Sub Load_Add_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Recipe.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Paint_color where End_Date > getdate() order by PLC_Color", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Paint_Color")
            SQLCon.Close()
            ReDim Paint_Color_Array(0)
            For Each dr As DataRow In ds.Tables("Paint_Color").Rows
                Cmb_Recipe.Items.Add(dr("PLC_Color") & "  " & dr("Description"))
                ReDim Preserve Paint_Color_Array(counter)
                Paint_Color_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub

End Class