Imports System.Data.SqlClient
Public Class Final_Part
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Part_Type_Array() As Int32
    Dim Final_Color_Array() As Int32
    Dim recipe_Array() As Int32
    Dim paint_Color_Array() As Int32
    Dim Area_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Part_Type.Text = ""
        Cmb_Part_Type.Text = ""
        Txt_Final_Color.Text = ""
        Cmb_Final_Color.Text = ""
        Txt_Base.Text = ""
        Txt_Clear.Text = ""
        Chk_Schedule.Checked = False

        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Part_Type.Visible = False
        Cmb_Part_Type.Visible = True
        Txt_Part_Number.Enabled = True
        Txt_Base.Enabled = True
        Txt_Clear.Enabled = True
        Txt_Final_Color.Visible = False
        Cmb_Final_Color.Visible = True
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False


        Txt_Part_Number.Text = ""

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
        txt_Part_Type.Visible = False
        Txt_Description.Text = Cmb_Description.Text
        Txt_Final_Color.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False

        Txt_Part_Number.Enabled = True
        Txt_Base.Enabled = True
        Txt_Clear.Enabled = True
        Chk_Schedule.Enabled = True

        Cmb_Part_Type.Text = txt_Part_Type.Text
        Cmb_Part_Type.Visible = True
        Cmb_Final_Color.Text = Txt_Final_Color.Text
        Cmb_Final_Color.Visible = True


        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data

        If Cmb_Part_Type.SelectedIndex < 0 Then
            MsgBox("Please select a valid Part Type")
            Exit Sub
        End If
        If Cmb_Final_Color.SelectedIndex < 0 Then
            MsgBox("Please select a valid Color")
            Exit Sub
        End If
        If Not IsNumeric(Txt_Base.Text) Then
            MsgBox("Film check runs - Base - must be a valid number")
            Exit Sub
        End If
        If Not IsNumeric(Txt_Clear.Text) Then
            MsgBox("Film check runs - Clear - must be a valid number")
            Exit Sub
        End If


        If Adding Then
            query = "Insert into Final_Part (description, Part_Type_ID, Part_Number, Final_Color_ID, film_check_base, film_check_clear, schedule) "
            query = query & " values ('" & Txt_Description.Text & "', " & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", '" & Txt_Part_Number.Text
            query = query & "', " & Final_Color_Array(Cmb_Final_Color.SelectedIndex) & ", " & Val(Txt_Base.Text) & ", " & Val(Txt_Clear.Text) & ", " & IIf(Chk_Schedule.Checked, 1, 0) & ")"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update Final_Part Set description = '" & Txt_Description.Text & "', Part_Type_ID = " & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", Part_Number = '" & Txt_Part_Number.Text & "', "
            query = query & "Final_Color_ID = " & Final_Color_Array(Cmb_Final_Color.SelectedIndex) & ", film_check_base = " & Val(Txt_Base.Text) & ", film_check_clear = " & Val(Txt_Clear.Text)
            query = query & ", schedule = " & IIf(Chk_Schedule.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        txt_Part_Type.Visible = True
        Cmb_Part_Type.Visible = False
        Txt_Final_Color.Visible = True
        Cmb_Final_Color.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False


        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Part_Type.Text = ""
        Txt_Part_Number.Enabled = False
        Txt_Final_Color.Text = ""

        Txt_Part_Number.Text = ""
        Txt_Base.Text = ""
        Txt_Clear.Text = ""
        Chk_Schedule.Checked = False

        Txt_Base.Enabled = False
        Txt_Clear.Enabled = False
        Chk_Schedule.Enabled = False



    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        txt_Part_Type.Visible = True
        Cmb_Part_Type.Visible = False
        txt_Part_Type.Text = ""
        Cmb_Description.Text = ""
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True

        Txt_Part_Number.Enabled = False
        Txt_Base.Enabled = False
        Txt_Clear.Enabled = False
        Chk_Schedule.Enabled = False

        Txt_Final_Color.Visible = True
        Cmb_Final_Color.Visible = False
        Txt_Final_Color.Text = ""

        Txt_Part_Number.Text = ""
        Txt_Base.Text = ""
        Txt_Clear.Text = ""
        Chk_Schedule.Checked = False


        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Final_Part order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Final_Part")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Final_Part").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Part Info from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Description.SelectedIndexChanged
        Call Load_Data()
        Btn_Edit.Visible = True
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
        Dim cmd As New SqlCommand("delete from Final_Part where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Part_Type.Text = ""
        Txt_Part_Number.Text = ""
        Txt_Base.Text = ""
        Txt_Clear.Text = ""
        Txt_Final_Color.Text = ""
        Chk_Schedule.Checked = False


        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False


    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select Part_Type.Description as Part_Type_Desc, Final_Color.Description as Final_Color_Desc, Final_Part.Description as Final_Part_Desc, Part_Number, Final_Part.Film_Check_Base, Final_Part.Film_Check_Clear, Final_Part.schedule from (Final_Part left join Part_Type on Final_Part.Part_Type_ID = Part_Type.id) left join Final_Color on Final_Part.Final_Color_ID = Final_Color.ID  where Final_Part.id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Final_Part")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Final_Part").Rows
            txt_Part_Type.Text = dr("Part_Type_Desc") & ""
            Txt_Part_Number.Text = dr("Part_Number") & ""
            Txt_Final_Color.Text = dr("Final_Color_Desc") & ""
            Txt_Base.Text = dr("Film_Check_Base") & ""
            Txt_Clear.Text = dr("Film_Check_Clear") & ""
            Chk_Schedule.Checked = IIf((dr("schedule") & "") = "True", True, False)

        Next
        Call Load_Recipes()


    End Sub

    Private Sub Final_Part_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Call Load_Part_Types()
        Call Load_Colors()
        Call Load_Add_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config
        Btn_Recipe_Add.Enabled = User_Permissions_Edit_Config
        Btn_Recipe_Delete.Enabled = User_Permissions_Edit_Config

    End Sub

    Sub Load_Part_Types()

        Dim counter As Integer = 0
        Try
            Cmb_Part_Type.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            ReDim Part_Type_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Part_Type.Items.Add(dr("Description"))
                ReDim Preserve Part_Type_Array(counter)
                Part_Type_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Colors()

        Dim counter As Integer = 0
        Try
            Cmb_Final_Color.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Final_Color order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Final_Color")
            SQLCon.Close()
            ReDim Final_Color_Array(0)
            For Each dr As DataRow In ds.Tables("Final_Color").Rows
                Cmb_Final_Color.Items.Add(dr("Description"))
                ReDim Preserve Final_Color_Array(counter)
                Final_Color_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Recipe_Add_Click(sender As Object, e As EventArgs) Handles Btn_Recipe_Add.Click

        Txt_Recipe_Description.Text = ""
        Cmb_Recipe.Text = ""
        Cmb_Recipe2.Text = ""


        Pnl_Recipe.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Recipe_Add.Visible = False
        Btn_Recipe_Delete.Visible = False

    End Sub

    Private Sub Btn_Recipe_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Recipe_Delete.Click
        If LB_Recipe.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("exec Delete_Final_Part_Recipe " & recipe_Array(LB_Recipe.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Recipes()

    End Sub

    Private Sub btn_Add_Recipe_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Add_Recipe_Confirm.Click
        Dim query As String = ""

        If Chk_Paint_Process.Checked Then
            If Cmb_Recipe.SelectedIndex < 0 Then
                MsgBox("Select a valid Paint Color to add to the recipe.")
                Exit Sub
            End If
            query = "Exec Add_Final_Part_Recipe " & ID_Array(Cmb_Description.SelectedIndex) & ", '" & Txt_Recipe_Description.Text & "', 1," & paint_Color_Array(Cmb_Recipe.SelectedIndex) & ", 0"
        Else
            If Cmb_Recipe2.SelectedIndex < 0 Then
                MsgBox("Select a valid Area to add to the recipe.")
                Exit Sub
            End If
            query = "Exec Add_Final_Part_Recipe " & ID_Array(Cmb_Description.SelectedIndex) & ", '" & Txt_Recipe_Description.Text & "', 0, 0," & Area_Array(Cmb_Recipe2.SelectedIndex)
        End If
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Recipes()



        Pnl_Recipe.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True

    End Sub

    Private Sub Btn_Add_Recipe_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Add_Recipe_Cancel.Click
        Pnl_Recipe.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Recipe_Add.Visible = True
        Btn_Recipe_Delete.Visible = True

    End Sub
    Sub Load_Recipes()
        Dim Query As String
        Dim counter As Integer = 0
        Try

            Query = "Select Final_Part_Recipe.id, Description from Final_Part_Recipe "
            Query = Query & "where Final_Part_Recipe.Final_Part_ID = " & ID_Array(Cmb_Description.SelectedIndex) & " Order by Recipe_Step"

            LB_Recipe.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(Query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Recipe")
            SQLCon.Close()
            ReDim Recipe_Array(0)
            For Each dr As DataRow In ds.Tables("Recipe").Rows

                LB_Recipe.Items.Add(dr("Description"))

                ReDim Preserve Recipe_Array(counter)
                Recipe_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Part Recipe Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Add_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Recipe.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Paint_color order by PLC_Color", SQLCon)
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
            counter = 0
            Dim da2 As New SqlDataAdapter("Select * from area order by Description", SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Area")
            SQLCon.Close()
            ReDim Area_Array(0)
            For Each dr2 As DataRow In ds2.Tables("Area").Rows
                Cmb_Recipe2.Items.Add(dr2("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr2("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Chk_Paint_Process_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Paint_Process.CheckedChanged
        If Chk_Paint_Process.Checked Then
            Lbl_Cmb_Area.Visible = False
            Cmb_Recipe2.Visible = False
            Lbl_Cmb_Color.Visible = True
            Cmb_Recipe.Visible = True
        Else
            Lbl_Cmb_Area.Visible = True
            Cmb_Recipe2.Visible = True
            Lbl_Cmb_Color.Visible = False
            Cmb_Recipe.Visible = False
        End If
    End Sub
End Class