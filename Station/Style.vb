Imports System.Data.SqlClient
Public Class Style
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Part_Type_Array() As Int32
    Dim Add_Part_Type_Array() As Int32

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
        DTP_Start_Date.Enabled = True
        DTP_End_Date.Enabled = True

        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = "1/1/2999"

        Btn_Part_Types_Add.Visible = False
        Btn_Part_Types_Delete.Visible = False

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
        DTP_Start_Date.Enabled = True
        DTP_End_Date.Enabled = True

        Btn_Part_Types_Add.Visible = False
        Btn_Part_Types_Delete.Visible = False

        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data




        If Adding Then
            query = "Insert into Style (description, spanish, PLC_Style, Start_Date, End_Date, Abbreviation) "
            query = query & " values ('" & Txt_Description.Text & "', '" & txt_Spanish.Text & "', " & Txt_PLC.Text & ", '" & DTP_Start_Date.Text & "', '"
            query = query & DTP_End_Date.Text & "', '" & Txt_Abbreviation.Text & "') "
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update Style Set description = '" & Txt_Description.Text & "', spanish = '" & txt_Spanish.Text & "', PLC_Style = " & Txt_PLC.Text & ", "
            query = query & "Abbreviation = '" & Txt_Abbreviation.Text & "', Start_Date = '" & DTP_Start_Date.Text & "', end_date = '" & DTP_End_Date.Text & "' "
            query = query & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        DTP_Start_Date.Enabled = False
        DTP_End_Date.Enabled = False

        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = ""




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
        DTP_Start_Date.Enabled = False
        DTP_End_Date.Enabled = False

        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = ""

        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Style order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Style")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Style").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Style Info from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Description.SelectedIndexChanged
        Call Load_Data()
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True

        Btn_Part_Types_Add.Visible = True
        Btn_Part_Types_Delete.Visible = True

    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from Style where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_PLC.Text = ""
        Txt_Abbreviation.Text = ""
        DTP_Start_Date.Text = ""
        DTP_End_Date.Text = ""

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

        Btn_Part_Types_Add.Visible = False
        Btn_Part_Types_Delete.Visible = False


    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from Style where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Style")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Style").Rows
            txt_Spanish.Text = dr("Spanish") & ""
            Txt_Abbreviation.Text = dr("Abbreviation") & ""
            Txt_PLC.Text = dr("PLC_Style") & ""
            DTP_Start_Date.Text = dr("start_date") & ""
            DTP_End_Date.Text = dr("end_date") & ""
        Next

        Load_Part_Types()


    End Sub

    Private Sub Style_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Call Load_Add_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config
        Btn_Part_Types_Add.Enabled = User_Permissions_Edit_Config
        Btn_Part_Types_Delete.Enabled = User_Permissions_Edit_Config


    End Sub

    Private Sub Btn_Part_Types_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Part_Types_Delete.Click
        If LB_Part_Types.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("Delete from Part_Type_to_Style where id = " & Part_Type_Array(LB_Part_Types.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Part_Types()

    End Sub

    Private Sub Btn_Part_Types_Add_Click(sender As Object, e As EventArgs) Handles Btn_Part_Types_Add.Click
        Pnl_Part_Types.Visible = True

        Cmb_Description.Enabled = False
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Part_Types_Add.Visible = False
        Btn_Part_Types_Delete.Visible = False

    End Sub
    Private Sub Btn_Add_Part_Types_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Add_Part_Types_Cancel.Click
        Pnl_Part_Types.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Part_Types_Add.Visible = True
        Btn_Part_Types_Delete.Visible = True

    End Sub

    Private Sub btn_Add_Part_Types_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Add_Part_Types_Confirm.Click
        If Cmb_Part_Types.SelectedIndex < 0 Then
            MsgBox("Select a valid Defect to add to the Part Type.")
            Exit Sub
        End If
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("Insert into part_type_to_style (Style_ID, Part_Type_ID) Values (" & ID_Array(Cmb_Description.SelectedIndex) & ", " & Add_Part_Type_Array(Cmb_Part_Types.SelectedIndex) & ")", SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Load_Part_Types()



        Pnl_Part_Types.Visible = False

        Cmb_Description.Enabled = True
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Part_Types_Add.Visible = True
        Btn_Part_Types_Delete.Visible = True

    End Sub
    Sub Load_Part_Types()
        Dim Query As String
        Dim counter As Integer = 0
        Try

            Query = "Select Part_Type_to_Style.id as Part_Type_to_Style_ID, Part_Type.Description"
            Query = Query & " from Part_Type_to_Style inner join Part_Type on Part_Type_to_Style.Part_Type_ID = Part_Type.id "
            Query = Query & "where Part_Type_to_Style.Style_ID = " & ID_Array(Cmb_Description.SelectedIndex)

            LB_Part_Types.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(Query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type_to_Style")
            SQLCon.Close()
            ReDim Part_Type_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type_to_Style").Rows

                LB_Part_Types.Items.Add(dr("Description"))

                ReDim Preserve Part_Type_Array(counter)
                Part_Type_Array(counter) = dr("Part_Type_to_Style_ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Types Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Add_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Part_Types.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            ReDim Add_Part_Type_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Part_Types.Items.Add(dr("Description"))
                ReDim Preserve Add_Part_Type_Array(counter)
                Add_Part_Type_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Types Info from Database: " & Ex.Message)
        End Try



    End Sub
End Class