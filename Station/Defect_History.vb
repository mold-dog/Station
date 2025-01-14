Imports System.Data
Imports System.Data.SqlClient
Public Class Defect_History
    Dim defect_color As Color = Color.Transparent
    Dim defect_number As Integer
    '    Dim ID_Array() As Integer
    Public RFID As String
    Dim Part_Type_English As String
    Dim Part_Type_Spanish As String
    Dim Color_English As String
    Dim Color_Spanish As String
    Dim Revision_Array() As Integer
    Private bindingsource_part As New BindingSource
    Dim Part_ID As Integer = 0
    Dim online_status As String = ""
    Dim wetsand_status As String = ""
    Dim buff_status As String = ""
    Dim Final_status As String = ""
    Dim Supervisor_status As String = ""
    Dim Decal_status As String = ""
    Dim Pinstripe_status As String = ""
    Dim Prep_status As String = ""

    Dim spanish_good As String = ""
    Dim spanish_touch_up As String = ""
    Dim spanish_reclear As String = ""
    Dim spanish_rework As String = ""
    Dim spanish_reprocess As String = ""
    Dim spanish_spin As String = ""
    Dim spanish_pinstripe As String = ""
    Dim spanish_not_checked As String = ""




    Structure Defect_Type
        Public Defect_Number As Int64
        Public Desciption As String
        Public Spanish As String
        Public Visible As Boolean
        Public Color As Integer
        Public Code As String
    End Structure

    Dim defect_Types(20) As Defect_Type
    Private Sub Load_Data()
        Dim query As String
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0
        Dim Part_Type As Integer

        If Part_ID <= 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select Part.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, "
        query = query & " Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, Part_Type.Image_Name as Image from (Part "
        query = query & " left join part_type on part.part_type = Part_Type.id) left join final_color on part.color = final_color.id "
        query = query & " where part.id = " & Part_ID

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_Type = dr("Part_Type_ID")
            Part_Type_English = dr("Part_Type_Desc") & ""
            Part_Type_Spanish = dr("Part_Type_Spanish") & ""
            Color_English = dr("Color") & ""
            Color_Spanish = dr("Color_Spanish") & ""
            If Len(dr("Image") & "") > 0 Then
                PictureBox1.Image = Image.FromFile(Image_Share & dr("Image"), False)
            Else
                PictureBox1.Image = Nothing
            End If
        Next
        If Btn_Language.Text = "English" Then
            Txt_Part_Type.Text = Part_Type_Spanish
            Txt_Color.Text = Color_Spanish
        Else
            Txt_Part_Type.Text = Part_Type_English
            Txt_Color.Text = Color_English
        End If

        query = "Select defect.id, defect.description, defect.spanish, defect.color, defect.code from defect "
        query = query & " inner join 
on defect.id = part_type_defects.Defect_ID"
        query = query & " where part_Type_Defects.part_Type_id = " & Part_Type & " order by part_Type_Defects.Order_Number"


        Dim da2 As New SqlDataAdapter(query, SQLCon)
        da2.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Defect")
        SQLCon.Close()

        For Each dr2 As DataRow In ds2.Tables("Defect").Rows

            defect_Types(counter).Defect_Number = dr2("id")
            defect_Types(counter).Desciption = dr2("Description") & ""
            defect_Types(counter).Spanish = dr2("Spanish") & ""
            defect_Types(counter).Color = Val(dr2("Color") & "")
            defect_Types(counter).Code = dr2("code") & ""
            defect_Types(counter).Visible = True
            If Btn_Language.Text = "English" Then
                Call Button_Text(Controls("Lbl_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Spanish)
            Else
                Call Button_Text(Controls("Lbl_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Desciption)
            End If
            Call Button_Color(Controls("Color_" & counter + 1), defect_Types(counter).Color)

            counter += 1
            If counter >= 20 Then
                Exit For
            End If
        Next
        For counter2 = counter To 19
            Call Invisible(Controls("Lbl_Defect_" & counter2 + 1), Controls("Color_" & counter2 + 1))
        Next

        defect_number = 0
        PictureBox1.Refresh()

        query = "Select ID, Revision from RFID_Defect_Inspection where Part_Id = " & Part_ID & " Order by Revision"


        Dim da3 As New SqlDataAdapter(query, SQLCon)
        da3.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds3 As New DataSet
        da3.Fill(ds3, "RFID_Defect_Inspection")
        SQLCon.Close()
        counter = 0
        Cmb_Revision.Items.Clear()
        ReDim Revision_Array(counter)
        For Each dr3 As DataRow In ds3.Tables("RFID_Defect_Inspection").Rows
            Cmb_Revision.Items.Add(dr3("Revision"))

            Revision_Array(counter) = dr3("ID")
            counter += 1
            ReDim Preserve Revision_Array(counter)
        Next
        If counter > 0 Then
            Cmb_Revision.SelectedIndex = counter - 1
        End If
        If counter > 1 Then
            Cmb_Revision.Visible = True
            Lbl_Revision.Visible = True
        Else
            Cmb_Revision.Visible = False
            Lbl_Revision.Visible = False
        End If



    End Sub

    Private Sub Load_Defects(RFID_Defect_Inspection_ID As Integer)
        Dim query As String
        Dim p As New System.Drawing.Pen(defect_color, 6)
        Dim g As System.Drawing.Graphics
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(defect_color)

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()


        defect_number = 0
        PictureBox1.Refresh()

        query = "Select RFID_Defect.X_Pos, RFID_Defect.Y_Pos, defect.color from RFID_Defect "
        query = query & " inner join defect on RFID_Defect.Defect_ID = Defect.ID "
        query = query & " where RFID_Defect.RFID_Defect_Inspection_id = " & RFID_Defect_Inspection_ID


        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "RFID_Defect")
        g = PictureBox1.CreateGraphics

        For Each dr As DataRow In ds.Tables("RFID_Defect").Rows
            p.Color = Color.FromArgb(dr("color"))
            g.DrawEllipse(p, dr("X_Pos") - 3, dr("Y_Pos") - 3, 6, 6)
        Next

        query = "Select RFID_Defect.X_Pos, RFID_Defect.Y_Pos, defect.color, Defect.Code from RFID_Defect "
        query = query & " inner join defect on RFID_Defect.Defect_ID = Defect.ID "
        query = query & " where RFID_Defect.RFID_Defect_Inspection_id in (Select DI2.ID from RFID_Defect_Inspection DI1 "
        query = query & " inner join RFID_Defect_Inspection DI2 on DI1.Part_ID = DI2.Part_ID and DI1.ID = " & RFID_Defect_Inspection_ID
        query = query & " and DI2.ID <> " & RFID_Defect_Inspection_ID & ")"


        Dim da2 As New SqlDataAdapter(query, SQLCon)
        da2.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds2 As New DataSet
        da2.Fill(ds2, "RFID_Old_Defect")
        SQLCon.Close()

        For Each dr As DataRow In ds2.Tables("RFID_Old_Defect").Rows
            drawBrush.Color = Color.FromArgb(dr("color"))
            g.DrawString(dr("Code") & "", drawFont, drawBrush, dr("X_Pos") - 10, dr("Y_Pos") - 10)
        Next
        SQLCon.Close()



    End Sub
    Private Sub Invisible(ByRef Set_Button As Label, ByRef Set_color As Label)
        Set_Button.Visible = False
        Set_color.Visible = False
    End Sub

    Private Sub Button_Text(ByRef Set_Button As Label, ByVal Set_Text As String)
        Set_Button.Text = Set_Text
        Set_Button.Visible = True
    End Sub

    Private Sub Button_Color(ByRef Set_Button As Label, ByVal Set_Color As Integer)
        Set_Button.BackColor = Color.FromArgb(Set_Color)
        Set_Button.Visible = True
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Me.Close()
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Language.Click
        Dim counter As Integer = 0

        If Btn_Language.Text = "Español" Then
            Spanish = True
            Btn_Language.Text = "English"
            For counter = 0 To 19
                If Len(defect_Types(counter).Spanish) > 0 Then
                    Call Button_Text(Controls("Lbl_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Spanish)
                End If
            Next
            Txt_Part_Type.Text = Part_Type_Spanish
            Txt_Color.Text = Color_Spanish
            update_to_spanish()
        Else
            Spanish = False
            Btn_Language.Text = "Español"
            For counter = 0 To 19
                If Len(defect_Types(counter).Desciption) > 0 Then
                    Call Button_Text(Controls("Lbl_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Desciption)
                End If
            Next
            Txt_Part_Type.Text = Part_Type_English
            Txt_Color.Text = Color_English
            update_to_english()
        End If
        Lbl_Online_Status.Text = Get_Status(online_status, True)
        Lbl_Wetsand_Status.Text = Get_Status(wetsand_status, False)
        Lbl_Buff_Status.Text = Get_Status(buff_status, False)
        Lbl_Final_Status.Text = Get_Status(Final_status, False)
        Lbl_Supervisor_Status.Text = Get_Status(Supervisor_status, False)
        Lbl_Decal_Status.Text = Get_Status(Decal_status, True)
        Lbl_Pinstripe_Status.Text = Get_Status(Pinstripe_status, True)
        Lbl_Prep_Status.Text = Get_Status(Prep_status, True)

    End Sub

    Private Sub Defect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lbl_Online_Inspector.Text = ""
        Lbl_Online_Time.Text = ""
        Lbl_Online_Status.Text = ""

        Lbl_Wetsand_Inspector.Text = ""
        Lbl_Wetsand_Time.Text = ""
        Lbl_Wetsand_Status.Text = ""

        Lbl_Buff_Inspector.Text = ""
        Lbl_Buff_Time.Text = ""
        Lbl_Buff_Status.Text = ""

        Lbl_Final_Inspector.Text = ""
        Lbl_Final_Time.Text = ""
        Lbl_Final_Status.Text = ""

        Lbl_Supervisor_Inspector.Text = ""
        Lbl_Supervisor_Time.Text = ""
        Lbl_Supervisor_Status.Text = ""

        Lbl_Decal_Inspector.Text = ""
        Lbl_Decal_Time.Text = ""
        Lbl_Decal_Status.Text = ""

        Lbl_Pinstripe_Inspector.Text = ""
        Lbl_Pinstripe_Time.Text = ""
        Lbl_Pinstripe_Status.Text = ""

        Lbl_Prep_Inspector.Text = ""
        Lbl_Prep_Time.Text = ""
        Lbl_Prep_Status.Text = ""

        get_translation()

    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Len(RFID) > 0 Then
            Txt_RFID.Text = RFID
            RFID = ""
        End If
        Timer1.Enabled = False
    End Sub

    Private Sub Cmb_Revision_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Revision.SelectedIndexChanged
        Call Load_Defect_inspection(Revision_Array(Cmb_Revision.SelectedIndex))
        Call Load_Defects(Revision_Array(Cmb_Revision.SelectedIndex))
    End Sub
    Private Sub Load_Defect_inspection(RFID_Defect_Inspection_ID As Integer)
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select * from RFID_Defect_Inspection where id = " & RFID_Defect_Inspection_ID

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "RFID_Defect_Inspection")
        SQLCon.Close()

        For Each dr As DataRow In ds.Tables("RFID_Defect_Inspection").Rows
            Lbl_Online_Inspector.Text = get_operator(dr("Online_Inspector") & "")
            Lbl_Online_Time.Text = dr("Online_Inspection_Time") & ""
            online_status = dr("Online_Inspection_Status") & ""
            Lbl_Online_Status.Text = Get_Status(online_status, True)

            Lbl_Wetsand_Inspector.Text = get_operator(dr("Wet_Sander") & "")
            Lbl_Wetsand_Time.Text = dr("Wet_Sand_Time") & ""
            wetsand_status = dr("Wet_Sand_Status") & ""
            Lbl_Wetsand_Status.Text = Get_Status(wetsand_status, False)

            Lbl_Buff_Inspector.Text = get_operator(dr("Buffer") & "")
            Lbl_Buff_Time.Text = dr("Buff_Time") & ""
            buff_status = dr("Buff_Status") & ""
            Lbl_Buff_Status.Text = Get_Status(buff_status, False)

            Lbl_Final_Inspector.Text = get_operator(dr("Final_Inspector") & "")
            Lbl_Final_Time.Text = dr("Final_Inspection_Time") & ""
            Final_status = dr("Final_Inspection_Status") & ""
            Lbl_Final_Status.Text = Get_Status(Final_status, False)

            Lbl_Supervisor_Inspector.Text = get_operator(dr("Supervisor_Inspector") & "")
            Lbl_Supervisor_Time.Text = dr("Supervisor_Inspection_Time") & ""
            Supervisor_status = dr("Supervisor_Inspection_Status") & ""
            Lbl_Supervisor_Status.Text = Get_Status(Supervisor_status, False)

            Lbl_Decal_Inspector.Text = get_operator(dr("Decal_Inspector") & "")
            Lbl_Decal_Time.Text = dr("Decal_Inspection_Time") & ""
            Decal_status = dr("Decal_Inspection_Status") & ""
            Lbl_Decal_Status.Text = Get_Status(Decal_status, True)

            Lbl_Pinstripe_Inspector.Text = get_operator(dr("Pinstripe_Inspector") & "")
            Lbl_Pinstripe_Time.Text = dr("Pinstripe_Inspection_Time") & ""
            Pinstripe_status = dr("Pinstripe_Inspection_Status") & ""
            Lbl_Pinstripe_Status.Text = Get_Status(Pinstripe_status, True)

            Lbl_Prep_Inspector.Text = get_operator(dr("Prep_Inspector") & "")
            Lbl_Prep_Time.Text = dr("Prep_Inspection_Time") & ""
            Prep_status = dr("Prep_Inspection_Status") & ""
            Lbl_Prep_Status.Text = Get_Status(Prep_status, True)
        Next
    End Sub
    Private Function Get_Status(Status As String, Rework As Boolean) As String
        If Btn_Language.Text = "English" Then
            Select Case Status
                Case "1"
                    Get_Status = spanish_good
                Case "2"
                    Get_Status = spanish_touch_up
                Case "3"
                    Get_Status = spanish_reclear
                Case "4"
                    If Rework Then
                        Get_Status = spanish_rework
                    Else
                        Get_Status = spanish_reprocess
                    End If
                Case "5"
                    Get_Status = spanish_spin
                Case "6"
                    Get_Status = spanish_pinstripe
                Case Else
                    Get_Status = spanish_not_checked
            End Select
        Else
            Select Case Status
                Case "1"
                    Get_Status = "Good"
                Case "2"
                    Get_Status = "Touch Up"
                Case "3"
                    Get_Status = "Reclear"
                Case "4"
                    If Rework Then
                        Get_Status = "Rework"
                    Else
                        Get_Status = "Reprocess"
                    End If
                Case "5"
                    Get_Status = "Spin"
                Case "6"
                    Get_Status = "Pinstripe"
                Case Else
                    Get_Status = "Not Checked"
            End Select
        End If

    End Function

    Private Sub Txt_RFID_TextChanged(sender As Object, e As EventArgs) Handles Txt_RFID.TextChanged
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select ID from Part where rfid = '" & Txt_RFID.Text & "'"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        Part_ID = 0

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_ID = dr("ID")
        Next

        Call Load_Data()

    End Sub

    Private Sub update_to_spanish()
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select * from defect_Screen_Translation where id = 1"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Translation")
        SQLCon.Close()

        For Each dr As DataRow In ds.Tables("Translation").Rows
            lbl_part.Text = dr("Part") & ""
            lbl_Type.Text = dr("Type") & ""
            Lbl_Color.Text = dr("Color") & ""
            lbl_Online.Text = dr("Paint_Online") & ""
            Lbl_Wetsand.Text = dr("wetsand") & ""
            Lbl_Buff.Text = dr("buff") & ""
            Lbl_Inspection.Text = dr("inspect") & ""
            Lbl_Supervisor.Text = dr("supervisor") & ""
            Lbl_Decal.Text = dr("decal") & ""
            Lbl_Pinstripe.Text = dr("pinstripe") & ""
            Lbl_Prep.Text = dr("part_prep") & ""
            Label_Online_Inspector.Text = dr("inspector") & ""
            Label_Online_Time.Text = dr("Time") & ""
            Label_Online_Status.Text = dr("status") & ""
            Label_Wetsand_Inspector.Text = dr("inspector") & ""
            Label_Wetsand_Time.Text = dr("Time") & ""
            Label_Wetsand_Status.Text = dr("status") & ""
            Label_Buff_Inspector.Text = dr("inspector") & ""
            Label_Buff_Time.Text = dr("Time") & ""
            Label_Buff_Status.Text = dr("status") & ""
            Label_Final_Inspector.Text = dr("inspector") & ""
            Label_Final_Time.Text = dr("Time") & ""
            Label_Final_Status.Text = dr("status") & ""
            Label_Supervisor_Inspector.Text = dr("inspector") & ""
            Label_Supervisor_Time.Text = dr("Time") & ""
            Label_Supervisor_Status.Text = dr("status") & ""
            Label_Decal_Inspector.Text = dr("inspector") & ""
            Label_Decal_Time.Text = dr("Time") & ""
            Label_Decal_Status.Text = dr("status") & ""
            Label_Pinstripe_Inspector.Text = dr("inspector") & ""
            Label_Pinstripe_Time.Text = dr("Time") & ""
            Label_Pinstripe_Status.Text = dr("status") & ""
            Label_Prep_Inspector.Text = dr("inspector") & ""
            Label_Prep_Time.Text = dr("Time") & ""
            Label_Prep_Status.Text = dr("status") & ""
            Lbl_Revision.Text = dr("version") & ""
        Next

    End Sub

    Private Sub update_to_english()
        lbl_Part.Text = "Part"
        Lbl_Type.Text = "Type"
        Lbl_Color.Text = "Color"
        lbl_Online.Text = "Paint Online"
        Lbl_Wetsand.Text = "Wetsand"
        Lbl_Buff.Text = "Finesse"
        Lbl_Inspection.Text = "Inspector"
        Lbl_Supervisor.Text = "Supervisor"
        Lbl_Decal.Text = "Decal"
        Lbl_Pinstripe.Text = "Pinstripe"
        Lbl_Prep.Text = "Part Prep"
        Label_Online_Inspector.Text = "Inspector"
        Label_Online_Time.Text = "Time"
        Label_Online_Status.Text = "Status"
        Label_Wetsand_Inspector.Text = "Inspector"
        Label_Wetsand_Time.Text = "Time"
        Label_Wetsand_Status.Text = "Status"
        Label_Buff_Inspector.Text = "Inspector"
        Label_Buff_Time.Text = "Time"
        Label_Buff_Status.Text = "Status"
        Label_Final_Inspector.Text = "Inspector"
        Label_Final_Time.Text = "Time"
        Label_Final_Status.Text = "Status"
        Label_Supervisor_Inspector.Text = "Inspector"
        Label_Supervisor_Time.Text = "Time"
        Label_Supervisor_Status.Text = "Status"
        Label_Decal_Inspector.Text = "Inspector"
        Label_Decal_Time.Text = "Time"
        Label_Decal_Status.Text = "Status"
        Label_Pinstripe_Inspector.Text = "Inspector"
        Label_Pinstripe_Time.Text = "Time"
        Label_Pinstripe_Status.Text = "Status"
        Label_Prep_Inspector.Text = "Inspector"
        Label_Prep_Time.Text = "Time"
        Label_Prep_Status.Text = "Status"
        Lbl_Revision.Text = "Version"
    End Sub

    Private Sub get_translation()
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select * from defect_Screen_Translation where id = 1"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "translation")
        SQLCon.Close()

        For Each dr As DataRow In ds.Tables("translation").Rows
            spanish_good = dr("good") & ""
            spanish_touch_up = dr("touch_up") & ""
            spanish_reclear = dr("reclear") & ""
            spanish_rework = dr("rework") & ""
            spanish_reprocess = dr("reprocess") & ""
            spanish_spin = dr("spin") & ""
            spanish_pinstripe = dr("pinstripe") & ""
            spanish_not_checked = dr("not_checked") & ""
        Next
    End Sub

End Class