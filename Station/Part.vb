Imports System.Data
Imports System.Data.SqlClient

Public Class Part
    Public RFID As String = ""
    Public New_Part As Boolean = False

    Dim Part_ID As Integer = 0


    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim Part_Type_Array() As Int32
    Dim Final_Color_Array() As Int32

    Dim Area_Array() As Int32
    Private bindingsource1 As New BindingSource


    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Adding = True

        Txt_Description.Text = ""
        txt_Part_Type.Text = ""
        Cmb_Part_Type.Text = ""
        Txt_Final_Color.Text = ""
        Cmb_Final_Color.Text = ""
        Cmb_Location.Text = ""
        Txt_Location.Text = ""

        Txt_Added.Text = ""
        Txt_Last_Location.Text = ""
        Txt_Last_Reader.Text = ""
        Txt_Updated.Text = ""

        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Part_Tracking.Visible = False
        Btn_Part_History.Visible = False
        Btn_Paint_Process_Data.Visible = False
        Btn_Molding_Process_Data.Visible = False
        Btn_Defects.Visible = False
        Btn_Defect_History.Visible = False
        Btn_Inspection.Visible = False
        Btn_Inspection_History.Visible = False
        Btn_Paint_Production.Visible = False
        Btn_Marriage_Data.Visible = False
        Btn_Local_Read.Visible = False
        txt_Part_Type.Visible = False
        Cmb_Part_Type.Visible = True
        Txt_Final_Color.Visible = False
        Cmb_Final_Color.Visible = True
        Txt_Location.Visible = False
        Cmb_Location.Visible = True
        Lbl_Tag_Killed.Visible = False
        Btn_Kill_Tag.Visible = False

    End Sub

    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Part_Tracking.Visible = False
        Btn_Part_History.Visible = False
        Btn_Paint_Process_Data.Visible = False
        Btn_Molding_Process_Data.Visible = False
        Btn_Defects.Visible = False
        Btn_Defect_History.Visible = False
        Btn_Inspection.Visible = False
        Btn_Inspection_History.Visible = False
        Btn_Paint_Production.Visible = False
        Btn_Marriage_Data.Visible = False
        Btn_Local_Read.Visible = False
        txt_Part_Type.Visible = False
        Txt_Final_Color.Visible = False
        Txt_Location.Visible = False


        Cmb_Part_Type.Text = txt_Part_Type.Text
        Cmb_Part_Type.Visible = True
        Cmb_Final_Color.Text = Txt_Final_Color.Text
        Cmb_Final_Color.Visible = True
        Cmb_Location.Text = Txt_Location.Text
        Cmb_Location.Visible = True


        Editing = True

    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data

        If Cmb_Part_Type.SelectedIndex < 0 Then
            MsgBox("Please select a valid Part Type")
            Exit Sub
        End If
        If Cmb_Location.SelectedIndex < 0 Then
            MsgBox("Please select a valid Location")
            Exit Sub
        End If


        If Adding Then
            query = "Insert into Part (RFID, Part_Type, Add_Time, Last_Update_Time, Current_Location, Last_Location, Last_Reader, Color, Location_Alarm) "
            query = query & " values ('" & Txt_Description.Text & "', " & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", getdate(), getdate(),"
            query = query & Area_Array(Cmb_Location.SelectedIndex) & ", 0, " & Final_Color_Array(Cmb_Final_Color.SelectedIndex) & ", 0)"
        Else
            If Part_ID <= 0 Then
                Exit Sub
            End If
            query = "update Part Set RFID = '" & Txt_Description.Text & "', Part_Type = " & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", Last_Update_Time = getdate(), "
            query = query & "Current_Location = " & Area_Array(Cmb_Location.SelectedIndex) & ", Color = " & Final_Color_Array(Cmb_Final_Color.SelectedIndex)
            If Cmb_Final_Color.Text <> Txt_Final_Color.Text Then
                query = query & ", Color_Override = 1"
            End If
            query = query & " where id = " & Part_ID
        End If

        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Part_Tracking.Visible = False
        Btn_Part_History.Visible = False
        Btn_Paint_Process_Data.Visible = False
        Btn_Molding_Process_Data.Visible = False
        Btn_Defects.Visible = False
        Btn_Defect_History.Visible = False
        Btn_Inspection.Visible = False
        Btn_Inspection_History.Visible = False
        Btn_Paint_Production.Visible = False
        Btn_Marriage_Data.Visible = False
        Btn_Local_Read.Visible = True
        txt_Part_Type.Visible = True
        Cmb_Part_Type.Visible = False
        Txt_Final_Color.Visible = True
        Cmb_Final_Color.Visible = False
        Txt_Location.Visible = True
        Cmb_Location.Visible = False
        Btn_Kill_Tag.Visible = False


        Editing = False
        Adding = False

        txt_Part_Type.Text = ""
        Txt_Final_Color.Text = ""
        Txt_Location.Text = ""

        Txt_Added.Text = ""
        Txt_Last_Location.Text = ""
        Txt_Last_Reader.Text = ""
        Txt_Updated.Text = ""
        Lbl_Tag_Killed.Visible = False




    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Part_Tracking.Visible = False
        Btn_Part_History.Visible = False
        Btn_Paint_Process_Data.Visible = False
        Btn_Molding_Process_Data.Visible = False
        Btn_Defects.Visible = False
        Btn_Defect_History.Visible = False
        Btn_Inspection.Visible = False
        Btn_Inspection_History.Visible = False
        Btn_Paint_Production.Visible = False
        Btn_Marriage_Data.Visible = False
        Btn_Local_Read.Visible = True
        txt_Part_Type.Visible = True
        Cmb_Part_Type.Visible = False
        txt_Part_Type.Text = ""
        Btn_Kill_Tag.Visible = False


        Txt_Final_Color.Visible = True
        Cmb_Final_Color.Visible = False
        Txt_Final_Color.Text = ""

        Txt_Location.Visible = True
        Cmb_Location.Visible = False
        Txt_Location.Text = ""

        Txt_Added.Text = ""
        Txt_Last_Location.Text = ""
        Txt_Last_Reader.Text = ""
        Txt_Updated.Text = ""
        Lbl_Tag_Killed.Visible = False


        Editing = False
        Adding = False

    End Sub





    Private Sub new_part_selected()
        Dim LikeResult As Boolean = 0
        LikeResult = RFID Like "*Z100*"
        Call Load_Data()
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        Btn_Part_Tracking.Visible = True
        Btn_Part_History.Visible = True
        Btn_Paint_Process_Data.Visible = True
        Btn_Molding_Process_Data.Visible = True
        Btn_Defects.Visible = True
        Btn_Defect_History.Visible = True
        Btn_Inspection.Visible = True
        Btn_Inspection_History.Visible = True
        Btn_Paint_Production.Visible = True
        If LikeResult Then
            Btn_Marriage_Data.Visible = True
        End If
        Btn_Unlock.Visible = True
        If User_Permissions_Kill Then
            Btn_Kill_Tag.Visible = True
        End If

    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If Part_ID <= 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from Part where id = " & Part_ID, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        txt_Part_Type.Text = ""
        Txt_Final_Color.Text = ""
        Txt_Location.Text = ""
        Txt_Added.Text = ""
        Txt_Last_Location.Text = ""
        Txt_Last_Reader.Text = ""
        Txt_Updated.Text = ""
        Lbl_Tag_Killed.Visible = False


        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Part_Tracking.Visible = False
        Btn_Part_History.Visible = False
        Btn_Paint_Process_Data.Visible = False
        Btn_Molding_Process_Data.Visible = False
        Btn_Defects.Visible = False
        Btn_Defect_History.Visible = False
        Btn_Inspection.Visible = False
        Btn_Inspection_History.Visible = False
        Btn_Paint_Production.Visible = False
        Btn_Marriage_Data.Visible = False
        Btn_Kill_Tag.Visible = False


    End Sub
    Private Sub Load_Data()
        Dim query As String
        Dim query1 As String
        If Part_ID <= 0 Then
            Exit Sub
        End If
        query = "Select Part_Type.Description as Part_Type_Desc, Final_Color.Description as Final_Color_Desc, area1.description as Area_Desc, killed, killed_date,"
        query = query & "Part.Add_Time, Part.Last_Update_Time, area2.description as Last_Location_Desc, Door_Reader.Description as Last_Reader_Desc, Part.Location_Alarm "
        query = query & "from (((((Part left join Part_Type on Part.Part_Type = Part_Type.id) left join Area Area1 on Part.Current_Location = area1.id) "
        query = query & " left join Area Area2 on Part.Last_Location = area2.id) left join Door_Reader on Part.Last_Reader = Door_Reader.id) "
        query = query & "left join Final_Color on Part.Color = Final_Color.ID) where Part.id = " & Part_ID

        query1 = "Select Wetsand_Complete, Buff_Complete, Final_Inspection_Complete from RFID_Defect_Inspection Where Part_ID = " & Part_ID
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        Dim da1 As New SqlDataAdapter(query1, SQLCon)
        da1.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds1 As New DataSet
        da1.Fill(ds1, "Complete_Bits")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Part").Rows
            txt_Part_Type.Text = dr("Part_Type_Desc") & ""
            Txt_Final_Color.Text = dr("Final_Color_Desc") & ""
            Txt_Location.Text = dr("Area_Desc") & ""
            Txt_Added.Text = dr("Add_Time") & ""
            Txt_Updated.Text = dr("Last_Update_Time") & ""
            Txt_Last_Reader.Text = dr("Last_Reader_Desc") & ""
            Txt_Last_Location.Text = dr("Last_Location_Desc") & ""
            If IIf(IsDBNull(dr("Killed")), False, dr("Killed")) Then
                Lbl_Tag_Killed.Text = "TAG KILLED - " & dr("killed_date")
                Lbl_Tag_Killed.Visible = True
            Else
                Lbl_Tag_Killed.Visible = False
            End If

        Next
        ChkBox_Wetsand.Checked = False
        ChkBox_Buff.Checked = False
        ChkBox_Final_Inspection.Checked = False


        For Each dr As DataRow In ds1.Tables("Complete_Bits").Rows
            If IIf(IsDBNull(dr("Wetsand_Complete")), False, dr("Wetsand_Complete")) Then
                ChkBox_Wetsand.Checked = True
            End If
            If IIf(IsDBNull(dr("Buff_Complete")), False, dr("Buff_Complete")) Then
                ChkBox_Buff.Checked = True
            End If
            If IIf(IsDBNull(dr("Final_Inspection_Complete")), False, dr("Final_Inspection_Complete")) Then
                ChkBox_Final_Inspection.Checked = True
            End If
        Next


    End Sub

    Private Sub Final_Part_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Part_Types()
        Call Load_Colors()
        Call Load_Areas()
        Btn_Add.Enabled = User_Permissions_Edit_Config
        Btn_Edit.Enabled = User_Permissions_Edit_Config
        Btn_Delete.Enabled = User_Permissions_Edit_Config

        Txt_Description.Text = RFID
        Btn_Part_Tracking.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Part_History.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Paint_Process_Data.Enabled = User_Permissions_Access_Paint_Area
        Btn_Molding_Process_Data.Enabled = User_Permissions_Access_Press_Area
        Btn_Defects.Enabled = User_Permissions_Access_Defects
        Btn_Defect_History.Enabled = User_Permissions_Access_Defects
        Btn_Inspection.Enabled = User_Permissions_Access_Inspections
        Btn_Inspection_History.Enabled = User_Permissions_Access_Defects
        Btn_Paint_Production.Enabled = User_Permissions_Access_Paint_Area
        Btn_Marriage_Data.Enabled = User_Permissions_Access_Paint_Area
        Btn_Unlock.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Kill_Tag.Enabled = User_Permissions_Kill


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

    Sub Load_Areas()

        Dim counter As Integer = 0
        Try
            Cmb_Location.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim Area_Array(0)
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_Location.Items.Add(dr("Description"))
                ReDim Preserve Area_Array(counter)
                Area_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Paint_Process_Data_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Process_Data.Click
        Paint_Job_Process_Data_Form = New Paint_Job_Process_Data
        Paint_Job_Process_Data_Form.RFID = Txt_Description.Text
        Paint_Job_Process_Data_Form.Show()
    End Sub

    Private Sub Btn_Molding_Process_Data_Click(sender As Object, e As EventArgs) Handles Btn_Molding_Process_Data.Click
        Molding_Job_Process_Data_Form = New Molding_Job_Process_Data
        Molding_Job_Process_Data_Form.RFID = Txt_Description.Text
        Molding_Job_Process_Data_Form.Show()
    End Sub

    Private Sub Btn_Part_Tracking_Click(sender As Object, e As EventArgs) Handles Btn_Part_Tracking.Click
        Part_Tracking_Form = New Part_Tracking
        Part_Tracking_Form.RFID = Txt_Description.Text
        Part_Tracking_Form.Show()

    End Sub

    Private Sub Btn_Defects_Click(sender As Object, e As EventArgs) Handles Btn_Defects.Click
        Defect_Form = New Defect
        Defect_Form.RFID = Txt_Description.Text
        Defect_Form.Show()

    End Sub

    Private Sub Btn_Inspection_Click(sender As Object, e As EventArgs) Handles Btn_Inspection.Click
        Inspection_Form = New Inspection
        Inspection_Form.RFID = Txt_Description.Text
        Inspection_Form.Show()
    End Sub

    Private Sub Btn_Defect_History_Click(sender As Object, e As EventArgs) Handles Btn_Defect_History.Click
        Defect_History_Form = New Defect_History
        Defect_History_Form.RFID = Txt_Description.Text
        Defect_History_Form.Show()

    End Sub

    Private Sub Btn_Local_Read_Click(sender As Object, e As EventArgs) Handles Btn_Local_Read.Click
        Local_Read_Form = New Local_Read
        Local_Read_Form.ShowDialog()
        If Len(Global_RFID) > 0 Then
            Txt_Description.Text = Global_RFID
        End If

    End Sub

    Private Sub Btn_Paint_Production_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Production.Click
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = Txt_Description.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub

    Private Sub Btn_Marriage_Data_Click(sender As Object, e As EventArgs) Handles Btn_Marriage_Data.Click
        Marriage_RFID_Query_Form = New Marriage_RFID_Query
        Marriage_RFID_Query_Form.RFID = Txt_Description.Text
        Marriage_RFID_Query_Form.Show()

    End Sub

    Private Sub Btn_Kill_Tag_Click(sender As Object, e As EventArgs) Handles Btn_Kill_Tag.Click
        Dim query As String = ""
        If Part_ID <= 0 Then
            MsgBox("Must Select a valid tag to kill.")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to kill the selected tag?  All future reads by this tag will be ignored by the server.", vbYesNo, "Kill Tag") = vbYes Then
            'Check for Valid Data

            query = "update Part Set killed = 1, killed_date = getdate() where id = " & Part_ID

            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()
            Call Load_Data()

        End If
    End Sub

    Private Sub Txt_Description_TextChanged(sender As Object, e As EventArgs) Handles Txt_Description.TextChanged
        Dim query As String

        If Adding Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select ID from Part where rfid = '" & Txt_Description.Text & "'"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        Part_ID = 0

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_ID = dr("ID")
        Next

        Call new_part_selected()

    End Sub

    Private Sub Btn_Part_History_Click(sender As Object, e As EventArgs) Handles Btn_Part_History.Click
        Part_History_Form = New Part_History
        Part_History_Form.RFID = Txt_Description.Text
        Part_History_Form.Show()

    End Sub

    Private Sub Btn_Inspection_History_Click(sender As Object, e As EventArgs) Handles Btn_Inspection_History.Click
        Part_Inspection_History_Form = New Part_Inspection_History
        Part_Inspection_History_Form.RFID = Txt_Description.Text
        Part_Inspection_History_Form.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim return_val As String = ""


        return_val = InputBox("Enter the readable information from the RFID Tag:", "Get RFID Number from readable data", "")
        If Len(return_val) >= 8 Then
            Txt_Description.Text = Mid(return_val, 1, 4) & Mid(return_val, 5).PadLeft(20, "0")

        End If



    End Sub

    Private Sub Btn_Unlock_Click(sender As Object, e As EventArgs) Handles Btn_Unlock.Click
        Dim query As String

        query = "update RFID_Defect_Inspection Set Wetsand_Complete = 0, Buff_Complete = 0, Final_Inspection_Complete = 0 where Part_id = " & Part_ID

        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

        Call Load_Data()
    End Sub
End Class