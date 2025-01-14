Imports System.Data.SqlClient
Public Class Paint_Color
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_Spanish.Enabled = True
        Txt_PLC.Enabled = True
        Txt_Abbreviation.Enabled = True
        Txt_Part_Number.Enabled = True
        DTP_Start_Date.Enabled = True
        DTP_End_Date.Enabled = True
        Opt_Prime.Enabled = True
        Opt_Base.Enabled = True
        Opt_Top_Coat.Enabled = True
        Opt_Clear.Enabled = True

        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        Txt_Part_Number.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = "1/1/2999"
        Opt_Prime.Checked = False
        Opt_Base.Checked = False
        Opt_Top_Coat.Checked = False
        Opt_Clear.Checked = False

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

        Txt_PLC.Enabled = True
        Txt_Abbreviation.Enabled = True
        Txt_Part_Number.Enabled = True
        DTP_Start_Date.Enabled = True
        DTP_End_Date.Enabled = True
        Opt_Prime.Enabled = True
        Opt_Base.Enabled = True
        Opt_Top_Coat.Enabled = True
        Opt_Clear.Enabled = True


        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data




        If Adding Then
            query = "Insert into paint_color (description, spanish, PLC_Color, Start_Date, End_Date, Abbreviation, Paint_Part_Number, Base_Color, No_Color, Prime, Top_Coat) "
            query = query & " values ('" & Txt_Description.Text & "', '" & txt_Spanish.Text & "', " & Txt_PLC.Text & ", '" & DTP_Start_Date.Text & "', '"
            query = query & DTP_End_Date.Text & "', '" & Txt_Abbreviation.Text & "', '" & Txt_Part_Number.Text & "', " & IIf(Opt_Base.Checked, 1, 0) & ", "
            query = query & IIf(Opt_Clear.Checked, 1, 0) & ", " & IIf(Opt_Prime.Checked, 1, 0) & ", " & IIf(Opt_Top_Coat.Checked, 1, 0) & ") "
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update paint_color Set description = '" & Txt_Description.Text & "', spanish = '" & txt_Spanish.Text & "', PLC_Color = " & Txt_PLC.Text & ", "
            query = query & "Abbreviation = '" & Txt_Abbreviation.Text & "', Paint_Part_Number = '" & Txt_Part_Number.Text & "', Start_Date = '" & DTP_Start_Date.Text & "', "
            query = query & "end_date = '" & DTP_End_Date.Text & "', Base_Color = " & IIf(Opt_Base.Checked, 1, 0) & ", No_Color = " & IIf(Opt_Clear.Checked, 1, 0) & ", "
            query = query & "Prime = " & IIf(Opt_Prime.Checked, 1, 0) & ", Top_Coat = " & IIf(Opt_Top_Coat.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
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

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_PLC.Enabled = False
        Txt_Abbreviation.Enabled = False
        Txt_Part_Number.Enabled = False
        DTP_Start_Date.Enabled = False
        DTP_End_Date.Enabled = False
        Opt_Prime.Enabled = False
        Opt_Base.Enabled = False
        Opt_Top_Coat.Enabled = False
        Opt_Clear.Enabled = False

        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        Txt_Part_Number.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = ""
        Opt_Prime.Checked = False
        Opt_Base.Checked = False
        Opt_Top_Coat.Checked = False
        Opt_Clear.Checked = False

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        txt_Spanish.Enabled = False
        txt_Spanish.Text = ""

        Txt_PLC.Enabled = False
        Txt_Abbreviation.Enabled = False
        Txt_Part_Number.Enabled = False
        DTP_Start_Date.Enabled = False
        DTP_End_Date.Enabled = False
        Opt_Prime.Enabled = False
        Opt_Base.Enabled = False
        Opt_Top_Coat.Enabled = False
        Opt_Clear.Enabled = False

        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        Txt_Part_Number.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = ""
        Opt_Prime.Checked = False
        Opt_Base.Checked = False
        Opt_Top_Coat.Checked = False
        Opt_Clear.Checked = False


        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from paint_color order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Paint_Color")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Paint_Color").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Paint Color Info from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from Paint_Color where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        Txt_Part_Number.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = ""
        Opt_Prime.Checked = False
        Opt_Base.Checked = False
        Opt_Top_Coat.Checked = False
        Opt_Clear.Checked = False


        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from Paint_Color where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Paint_Color")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Paint_Color").Rows
            txt_Spanish.Text = dr("Spanish") & ""
            Txt_Abbreviation.Text = dr("Abbreviation") & ""
            Txt_Part_Number.Text = dr("Paint_Part_Number") & ""
            Txt_PLC.Text = dr("PLC_Color") & ""
            DTP_Start_Date.Text = dr("start_date") & ""
            DTP_End_Date.Text = dr("end_date") & ""
            Opt_Base.Checked = dr("base_color")
            Opt_Clear.Checked = dr("No_Color")
            Opt_Prime.Checked = dr("Prime")
            Opt_Top_Coat.Checked = dr("Top_Coat")
        Next


    End Sub

    Private Sub Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

    End Sub

End Class