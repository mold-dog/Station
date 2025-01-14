Imports System.Data.SqlClient
Public Class Defects
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Code.Text = ""
        Chk_Request_Size.Checked = False
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Change_Color.Visible = True
        txt_Spanish.Enabled = True
        Txt_Code.Enabled = True
        Chk_Request_Size.Enabled = True

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
        Btn_Change_Color.Visible = True
        txt_Spanish.Enabled = True
        Txt_Code.Enabled = True
        Chk_Request_Size.Enabled = True
        Txt_Description.Text = Cmb_Description.Text

        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        SQLCon.Open()
        Dim cmd As New SqlCommand("", SQLCon)

        If Adding Then
            cmd.CommandText = "Insert into defect (description, spanish, color, code, request_size) values ('" & Txt_Description.Text & "', '" & txt_Spanish.Text & "', '" & Lbl_Color.BackColor.ToArgb & "', '" & Txt_Code.Text & "', " & IIf(Chk_Request_Size.Checked, 1, 0) & ")"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                SQLCon.Close()
                Exit Sub
            End If
            cmd.CommandText = "update defect Set description = '" & Txt_Description.Text & "', spanish = '" & txt_Spanish.Text & "', color = '" & Lbl_Color.BackColor.ToArgb & "', code = '" & Txt_Code.Text & "', request_size = " & IIf(Chk_Request_Size.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        Btn_Change_Color.Visible = False
        txt_Spanish.Enabled = False
        Txt_Code.Enabled = False
        Chk_Request_Size.Enabled = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Code.Text = ""
        Chk_Request_Size.Checked = False



    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Change_Color.Visible = False
        txt_Spanish.Enabled = False
        txt_Spanish.Text = ""
        Txt_Code.Enabled = False
        Txt_Code.Text = ""
        Chk_Request_Size.Enabled = False
        Chk_Request_Size.Checked = False

        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from defect order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Defect")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Defect").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Defects Info from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from defect where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_Spanish.Text = ""
        Txt_Code.Text = ""
        Chk_Request_Size.Checked = False

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False




    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from defect where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Defect")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Defect").Rows
            txt_Spanish.Text = dr("Spanish") & ""
            Lbl_Color.BackColor = Color.FromArgb(dr("Color") & "")
            Txt_Code.Text = dr("Code") & ""
            Chk_Request_Size.Checked = IIf(dr("request_size") & "" = "True", True, False)
        Next

    End Sub

    Private Sub Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

    End Sub

    Private Sub Btn_Change_Color_Click(sender As Object, e As EventArgs) Handles Btn_Change_Color.Click
        Dim response As DialogResult
        response = ColorDialog.ShowDialog()
        If Not response = DialogResult.Cancel Then
            Lbl_Color.BackColor = ColorDialog.Color
        End If
    End Sub


End Class