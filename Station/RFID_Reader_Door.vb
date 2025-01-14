Imports System.Data.SqlClient
Public Class RFID_Reader_Door
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Dim Area_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        Cmb_To_Location.Text = ""
        Cmb_From_Location.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Txt_PLC.Enabled = True
        Chk_Pass_Back.Enabled = True
        Chk_Repair.Enabled = True

        Cmb_From_Location.Visible = True
        Txt_From_Location.Visible = False
        Cmb_To_Location.Visible = True
        Txt_To_Location.Visible = False

        Txt_PLC.Text = ""
        Chk_Pass_Back.Checked = False
        Chk_Repair.Checked = False

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
        Txt_Description.Text = Cmb_Description.Text
        Cmb_From_Location.Visible = True
        Txt_From_Location.Visible = False
        Cmb_To_Location.Visible = True
        Txt_To_Location.Visible = False
        Cmb_From_Location.Text = Txt_From_Location.Text
        Cmb_To_Location.Text = Txt_To_Location.Text

        Txt_PLC.Enabled = True
        Chk_Pass_Back.Enabled = True
        Chk_Repair.Enabled = True



        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data




        If Adding Then
            query = "Insert into Door_Reader (description, PLC_Reader_Number, From_Area, To_Area, Pass_Back, Repair) "
            query = query & " values ('" & Txt_Description.Text & "', " & Txt_PLC.Text & ", " & Area_Array(Cmb_From_Location.SelectedIndex)
            query = query & ", " & Area_Array(Cmb_To_Location.SelectedIndex) & ", " & IIf(Chk_Pass_Back.Checked, 1, 0) & ", " & IIf(Chk_Repair.Checked, 1, 0) & ") "
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "update Door_Reader Set description = '" & Txt_Description.Text & "', PLC_Reader_Number = " & Txt_PLC.Text & ", "
            query = query & "From_Area = " & Area_Array(Cmb_From_Location.SelectedIndex) & ", To_Area = " & Area_Array(Cmb_To_Location.SelectedIndex)
            query = query & ", Pass_Back = " & IIf(Chk_Pass_Back.Checked, 1, 0) & ", repair = " & IIf(Chk_Repair.Checked, 1, 0)
            query = query & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
        End If






        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

        Cmb_Description.Visible = True
        Txt_Description.Visible = False

        Cmb_From_Location.Visible = False
        Txt_From_Location.Visible = True
        Cmb_To_Location.Visible = False
        Txt_To_Location.Visible = True



        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        Txt_PLC.Enabled = False
        Chk_Pass_Back.Enabled = False
        Chk_Repair.Enabled = False

        Txt_PLC.Text = ""
        Txt_From_Location.Text = ""
        Txt_To_Location.Text = ""
        Chk_Pass_Back.Checked = False
        Chk_Repair.Checked = False

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Cmb_From_Location.Visible = False
        Txt_From_Location.Visible = True
        Cmb_To_Location.Visible = False
        Txt_To_Location.Visible = True

        Txt_PLC.Enabled = False
        Chk_Pass_Back.Enabled = False
        Chk_Repair.Enabled = False

        Txt_PLC.Text = ""
        Txt_From_Location.Text = ""
        Txt_To_Location.Text = ""
        Chk_Pass_Back.Checked = False
        Chk_Repair.Checked = False


        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()
        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Door_Reader order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Door_Reader")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Door_Reader").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Door Reader Info from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from Door_Reader where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        Txt_PLC.Text = ""
        Cmb_From_Location.Text = ""
        Cmb_To_Location.Text = ""
        Txt_From_Location.Text = ""
        Txt_To_Location.Text = ""
        Chk_Pass_Back.Checked = False
        Chk_Repair.Checked = False

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False

    End Sub
    Private Sub Load_Data()
        Dim query As String = ""

        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        query = "Select PLC_Reader_Number, Pass_Back, Repair, To_Area.Description as To_Location, From_Area.Description as From_Location "
        query = query & " from (Door_Reader left join Area To_Area on Door_Reader.To_Area = To_Area.ID) "
        query = query & " left join Area From_Area on Door_Reader.From_Area = From_Area.ID where Door_Reader.id = " & ID_Array(Cmb_Description.SelectedIndex)
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Door_Reader")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Door_Reader").Rows
            Txt_PLC.Text = dr("PLC_Reader_Number") & ""
            Txt_From_Location.Text = dr("From_Location") & ""
            If Len(Txt_From_Location.Text) < 1 Then
                Txt_From_Location.Text = "Any Location"
            End If
            Txt_To_Location.Text = dr("To_Location") & ""
            Chk_Pass_Back.Checked = dr("Pass_Back")
            Chk_Repair.Checked = dr("Repair")
        Next
    End Sub

    Private Sub RFID_Reader_Door_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Call Load_Areas()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

    End Sub
    Sub Load_Areas()

        Dim counter As Integer = 0
        Try
            Cmb_From_Location.Items.Clear()
            Cmb_To_Location.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim Area_Array(0)
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_From_Location.Items.Add(dr("Description"))
                Cmb_To_Location.Items.Add(dr("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr("ID")
                counter += 1
            Next
            ReDim Preserve Area_Array(counter)
            Area_Array(counter) = 0
            Cmb_From_Location.Items.Add("Any Location")


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try



    End Sub
End Class