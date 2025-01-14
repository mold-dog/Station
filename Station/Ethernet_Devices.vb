Imports System.Data.SqlClient
Public Class Ethernet_Devices
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Description.Text = ""
        txt_IP_Address.Text = ""
        Txt_Code.Text = ""
        Txt_Description.Visible = True
        Cmb_Description.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_IP_Address.Enabled = True
        Txt_Code.Enabled = True
        Chk_Inactivity_Alarm.Checked = False
        Chk_Inactivity_Alarm.Enabled = True


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
        txt_IP_Address.Enabled = True
        Txt_Code.Enabled = True
        Txt_Description.Text = Cmb_Description.Text
        Chk_Inactivity_Alarm.Enabled = True

        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        SQLCon.Open()
        Dim cmd As New SqlCommand("", SQLCon)

        If Adding Then
            cmd.CommandText = "Insert into ethernet_devices (description, IP_Address, station_code, Inactivity_Alarm) values ('" & Txt_Description.Text & "', '" & txt_IP_Address.Text & "', '" & Txt_Code.Text & "', " & IIf(Chk_Inactivity_Alarm.Checked, 1, 0) & ")"
        Else
            If Cmb_Description.SelectedIndex < 0 Then
                SQLCon.Close()
                Exit Sub
            End If
            cmd.CommandText = "update ethernet_devices Set description = '" & Txt_Description.Text & "', IP_Address = '" & txt_IP_Address.Text & "', station_code = '" & Txt_Code.Text & "', Inactivity_Alarm = " & IIf(Chk_Inactivity_Alarm.Checked, 1, 0) & " where id = " & ID_Array(Cmb_Description.SelectedIndex)
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
        txt_IP_Address.Enabled = False
        Txt_Code.Enabled = False

        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_IP_Address.Text = ""
        Txt_Code.Text = ""
        Txt_Last_Communicaitons.Text = ""
        Chk_Inactivity_Alarm.Enabled = False
        Chk_Inactivity_Alarm.Checked = False


    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Description.Visible = False
        Cmb_Description.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        txt_IP_Address.Enabled = False
        txt_IP_Address.Text = ""
        Txt_Code.Enabled = False
        Txt_Code.Text = ""
        Txt_Last_Communicaitons.Text = ""
        Chk_Inactivity_Alarm.Enabled = False
        Chk_Inactivity_Alarm.Checked = False

        Editing = False
        Adding = False

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Ethernet_Devices order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Ethernet_Devices")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Ethernet_Devices").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Ethernet Devices from Database: " & Ex.Message)
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
        Dim cmd As New SqlCommand("delete from Ethernet_Devices where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Description.Text = ""
        txt_IP_Address.Text = ""
        Txt_Code.Text = ""
        Txt_Last_Communicaitons.Text = ""

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False




    End Sub
    Private Sub Load_Data()
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from ethernet_Devices where id = " & ID_Array(Cmb_Description.SelectedIndex), SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "ethernet_Devices")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("ethernet_Devices").Rows
            txt_IP_Address.Text = dr("IP_Address") & ""
            Txt_Last_Communicaitons.Text = dr("Last_Response") & ""
            Txt_Code.Text = dr("station_code") & ""
            Chk_Inactivity_Alarm.Checked = dr("Inactivity_Alarm")
        Next

    End Sub

    Private Sub Defects_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Combo()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

    End Sub


End Class