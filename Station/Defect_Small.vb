Imports System.Data
Imports System.Data.SqlClient
Public Class Defect_Small

    Dim defect_color As Color = Color.Transparent
    Dim defect_number As Integer
    '    Dim ID_Array() As Integer
    Public RFID As String
    Dim Part_Type_English As String
    Dim Part_Type_Spanish As String
    Dim Color_English As String
    Dim Color_Spanish As String
    Dim RFID_Defect_Inspection_ID As Integer
    Private bindingsource_part As New BindingSource


    Structure Defect_Type
        Public Defect_Number As Int64
        Public Desciption As String
        Public Spanish As String
        Public Visible As Boolean
        Public Color As Integer
    End Structure

    Dim defect_Types(20) As Defect_Type
    Private Sub Load_Data()
        If Cmb_Area.SelectedIndex <= 0 Then
            Exit Sub
        End If

        Dim query As String
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0
        Dim Part_Type As Integer

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select Part.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, "
        query = query & " Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, Part_Type.Image_Location as Image from (Part "
        query = query & " left join part_type on part.part_type = Part_Type.id) left join final_color on part.color = final_color.id "
        query = query & " where part.id = " & Cmb_Area.SelectedValue

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
                PictureBox1.Image = Image.FromFile(dr("Image"), False)
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

        query = "Select defect.id, defect.description, defect.spanish, defect.color from defect "
        query = query & " inner join part_type_defects on defect.id = part_type_defects.Defect_ID"
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
            defect_Types(counter).Visible = True
            If Btn_Language.Text = "English" Then
                Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Spanish)
            Else
                Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Desciption)
            End If
            Call Button_Color(Controls("Color_" & counter + 1), defect_Types(counter).Color)

            counter += 1
            If counter >= 20 Then
                Exit For
            End If
        Next
        For counter2 = counter To 19
            Call Invisible(Controls("Btn_Defect_" & counter2 + 1), Controls("Color_" & counter2 + 1))
        Next


        RFID_Defect_Inspection_ID = 0


        defect_number = 0
        PictureBox1.Refresh()

        query = "Select ID, Revision from RFID_Defect_Inspection where Part_Id = " & Cmb_Area.SelectedValue & " and Latest_Revision = 1"


        Dim da3 As New SqlDataAdapter(query, SQLCon)
        da3.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds3 As New DataSet
        da3.Fill(ds3, "RFID_Defect_Inspection")
        SQLCon.Close()
        counter = 0
        Txt_Revision.Text = ""
        For Each dr3 As DataRow In ds3.Tables("RFID_Defect_Inspection").Rows
            RFID_Defect_Inspection_ID = dr3("ID")
            Txt_Revision.Text = dr3("revision")
        Next

    End Sub
    Private Sub Invisible(ByRef Set_Button As Button, ByRef Set_color As Label)
        Set_Button.Visible = False
        Set_color.Visible = False
    End Sub

    Private Sub Button_Text(ByRef Set_Button As Button, ByVal Set_Text As String)
        Set_Button.Text = Set_Text
        Set_Button.Visible = True
    End Sub

    Private Sub Button_Color(ByRef Set_Button As Label, ByVal Set_Color As Integer)
        Set_Button.BackColor = Color.FromArgb(Set_Color)
        Set_Button.Visible = True
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        Dim query As String

        Dim p As New System.Drawing.Pen(defect_color, 6)
        Dim g As System.Drawing.Graphics

        If Cmb_Area.SelectedIndex < 0 Then
            Exit Sub
        End If
        If defect_number = 0 Then
            MsgBox("Select a defect before choosing the locations.")
            Exit Sub
        End If
        g = PictureBox1.CreateGraphics
        g.DrawEllipse(p, e.X - 3, e.Y - 3, 6, 6)
        query = "insert into RFID_Defect (RFID_Defect_Inspection_ID, Defect_ID, X_Pos, Y_Pos, Inspector_ID) values(" & RFID_Defect_Inspection_ID & ", " & defect_number & ", " & e.X & ", " & e.Y & ", " & Operator_ID & ")"
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()


    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub



    Private Sub Btn_Defect_1_Click(sender As Object, e As EventArgs) Handles Btn_Defect_1.Click
        defect_color = Color_1.BackColor
        defect_number = defect_Types(0).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_1.ForeColor = Color.Red

    End Sub

    Private Sub Btn_Defect_2_Click(sender As Object, e As EventArgs) Handles Btn_Defect_2.Click
        defect_color = Color_2.BackColor
        defect_number = defect_Types(1).Defect_Number
        Call Clear_Fore_Colors()
        Btn_Defect_2.ForeColor = Color.Red
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_Defect_3.Click
        defect_color = Color_3.BackColor
        defect_number = defect_Types(2).Defect_Number
        Call Clear_Fore_Colors()
        Btn_Defect_3.ForeColor = Color.Red
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Language.Click
        Dim counter As Integer = 0

        If Btn_Language.Text = "Español" Then
            Btn_Language.Text = "English"
            For counter = 0 To 19
                If Len(defect_Types(counter).Spanish) > 0 Then
                    Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Spanish)
                End If
            Next
            Txt_Part_Type.Text = Part_Type_Spanish
            Txt_Color.Text = Color_Spanish

        Else
            Btn_Language.Text = "Español"
            For counter = 0 To 19
                If Len(defect_Types(counter).Desciption) > 0 Then
                    Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Desciption)
                End If
            Next
        End If
        Txt_Part_Type.Text = Part_Type_English
        Txt_Color.Text = Color_English

    End Sub

    Private Sub Defect_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        PictureBox1.Image = Nothing

        Call Fill_Combo()
        Lbl_Online_Inspector.Text = ""
        Lbl_Online_Time.Text = ""
        Chk_Online_Good.Checked = False
        Chk_Online_TU.Checked = False
        Chk_Online_Reclear.Checked = False
        Chk_Online_Rework.Checked = False


        Lbl_Wetsand_Inspector.Text = ""
        Lbl_Wetsand_Time.Text = ""
        Chk_Wetsand_Good.Checked = False
        Chk_Wetsand_TU.Checked = False
        Chk_Wetsand_Reclear.Checked = False
        Chk_Wetsand_Rework.Checked = False

        Lbl_Buff_Inspector.Text = ""
        Lbl_Buff_Time.Text = ""
        Chk_Buff_Good.Checked = False
        Chk_Buff_TU.Checked = False
        Chk_Buff_Reclear.Checked = False
        Chk_Buff_Rework.Checked = False

        Txt_User.Text = Operator_ID

        If PLC_Station = 0 Then
            Cmd_Next_Part.Visible = False
        Else
            Me.Text = "Defect - Station: " & PLC_Station
        End If


    End Sub

    Private Sub Btn_Defect_4_Click(sender As Object, e As EventArgs) Handles Btn_Defect_4.Click
        defect_color = Color_4.BackColor
        defect_number = defect_Types(3).Defect_Number
        Call Clear_Fore_Colors()
        Btn_Defect_4.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_5_Click(sender As Object, e As EventArgs) Handles Btn_Defect_5.Click
        defect_color = Color_5.BackColor
        defect_number = defect_Types(4).Defect_Number
        Call Clear_Fore_Colors()
        Btn_Defect_5.ForeColor = Color.Red
    End Sub
    Private Sub Fill_Combo()
        bindingsource_part.DataSource = GetData("Select ID, RFID from Part order by RFID")

        Cmb_Area.DataSource = bindingsource_part
        Cmb_Area.DisplayMember = "RFID"
        Cmb_Area.ValueMember = "ID"
        Cmb_Area.Refresh()






        'Dim counter As Integer = 0


        'Try
        '    Cmb_Area.Items.Clear()
        '    SQLCon.ConnectionString = DBConnection
        '    SQLCon.Open()
        '    Dim da As New SqlDataAdapter("Select ID, RFID from Part Order by RFID", SQLCon)
        '    da.SelectCommand.CommandTimeout = SQL_Timeout
        '    Dim ds As New DataSet
        '    da.Fill(ds, "Part")
        '    SQLCon.Close()
        '    ReDim ID_Array(counter)
        '    For Each dr As DataRow In ds.Tables("Part").Rows
        '        Cmb_Area.Items.Add(dr("RFID"))

        '        ID_Array(counter) = dr("ID")
        '        counter += 1
        '        ReDim Preserve ID_Array(counter)
        '    Next

        'Catch Ex As Exception

        '    MsgBox("Error Getting Part Info from Database: " & Ex.Message)
        'End Try


    End Sub
    Private Sub Btn_Defect_6_Click(sender As Object, e As EventArgs) Handles Btn_Defect_6.Click
        defect_color = Color_6.BackColor
        defect_number = defect_Types(5).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_6.ForeColor = Color.Red

    End Sub

    Private Sub Btn_Defect_7_Click(sender As Object, e As EventArgs) Handles Btn_Defect_7.Click
        defect_color = Color_7.BackColor
        defect_number = defect_Types(6).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_7.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_8_Click(sender As Object, e As EventArgs) Handles Btn_Defect_8.Click
        defect_color = Color_8.BackColor
        defect_number = defect_Types(7).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_8.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_9_Click(sender As Object, e As EventArgs) Handles Btn_Defect_9.Click
        defect_color = Color_9.BackColor
        defect_number = defect_Types(8).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_9.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_10_Click(sender As Object, e As EventArgs) Handles Btn_Defect_10.Click
        defect_color = Color_10.BackColor
        defect_number = defect_Types(9).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_10.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_11_Click(sender As Object, e As EventArgs) Handles Btn_Defect_11.Click
        defect_color = Color_11.BackColor
        defect_number = defect_Types(10).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_11.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_12_Click(sender As Object, e As EventArgs) Handles Btn_Defect_12.Click
        defect_color = Color_12.BackColor
        defect_number = defect_Types(11).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_12.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_13_Click(sender As Object, e As EventArgs) Handles Btn_Defect_13.Click
        defect_color = Color_13.BackColor
        defect_number = defect_Types(12).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_13.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_14_Click(sender As Object, e As EventArgs) Handles Btn_Defect_14.Click
        defect_color = Color_14.BackColor
        defect_number = defect_Types(13).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_14.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_15_Click(sender As Object, e As EventArgs) Handles Btn_Defect_15.Click
        defect_color = Color_15.BackColor
        defect_number = defect_Types(14).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_15.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_16_Click(sender As Object, e As EventArgs) Handles Btn_Defect_16.Click
        defect_color = Color_16.BackColor
        defect_number = defect_Types(15).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_16.ForeColor = Color.Red
    End Sub

    Private Sub Cmb_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Area.SelectedIndexChanged
        Call Load_Data()
        Call Clear_Fore_Colors()
        Call Load_Defect_inspection(RFID_Defect_Inspection_ID)
        Call Load_Defects(RFID_Defect_Inspection_ID)

    End Sub
    Private Sub Clear_Fore_Colors()
        Btn_Defect_1.ForeColor = Btn_Language.ForeColor
        Btn_Defect_2.ForeColor = Btn_Language.ForeColor
        Btn_Defect_3.ForeColor = Btn_Language.ForeColor
        Btn_Defect_4.ForeColor = Btn_Language.ForeColor
        Btn_Defect_5.ForeColor = Btn_Language.ForeColor
        Btn_Defect_6.ForeColor = Btn_Language.ForeColor
        Btn_Defect_7.ForeColor = Btn_Language.ForeColor
        Btn_Defect_8.ForeColor = Btn_Language.ForeColor
        Btn_Defect_9.ForeColor = Btn_Language.ForeColor
        Btn_Defect_10.ForeColor = Btn_Language.ForeColor
        Btn_Defect_11.ForeColor = Btn_Language.ForeColor
        Btn_Defect_12.ForeColor = Btn_Language.ForeColor
        Btn_Defect_13.ForeColor = Btn_Language.ForeColor
        Btn_Defect_14.ForeColor = Btn_Language.ForeColor
        Btn_Defect_15.ForeColor = Btn_Language.ForeColor
        Btn_Defect_16.ForeColor = Btn_Language.ForeColor
        Btn_Defect_17.ForeColor = Btn_Language.ForeColor
        Btn_Defect_18.ForeColor = Btn_Language.ForeColor
        Btn_Defect_19.ForeColor = Btn_Language.ForeColor
        Btn_Defect_20.ForeColor = Btn_Language.ForeColor
    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        Dim query As String = ""
        If MsgBox("Are you sure you want to clear all defects from this part?", vbOKCancel) = MsgBoxResult.Ok Then

            If Cmb_Area.SelectedIndex < 0 Then
                Exit Sub
            End If
            query = "delete from RFID_Defect where RFID_Defect_Inspection_ID = " & RFID_Defect_Inspection_ID
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()

            PictureBox1.Refresh()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim First_RFID As String = ""
        Dim Found_Existing As Boolean = False

        If Timer1.Interval = 100 Then
            Timer1.Interval = 5000
            If Len(RFID) > 0 Then
                Cmb_Area.Text = RFID
                RFID = ""
            End If
            If Station_ID = 0 Then
                Timer1.Enabled = False
            End If
        Else
            Try
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim da As New SqlDataAdapter("Execute Find_Station_Parts " & PLC_Station, SQLCon)
                da.SelectCommand.CommandTimeout = SQL_Timeout
                Dim ds As New DataSet
                da.Fill(ds, "Station")
                SQLCon.Close()
                For Each dr As DataRow In ds.Tables("Station").Rows
                    If Len(First_RFID) < 1 Then
                        First_RFID = dr("RFID") & ""
                    End If
                    If Cmb_Area.Text = dr("RFID") & "" Then
                        Found_Existing = True
                    End If
                Next
                If Len(First_RFID) > 0 And Not Found_Existing Then
                    Cmb_Area.Text = First_RFID
                    lbl_Changing_Parts.Visible = True
                    Timer2.Enabled = True
                End If


                '               SQLCon.ConnectionString = DBConnection
                '               SQLCon.Open()
                '               Dim da As New SqlDataAdapter("Select User_ID from Station where ID = " & Station_ID, SQLCon)
                '               da.SelectCommand.CommandTimeout = SQL_Timeout
                '               Dim ds As New DataSet
                '               da.Fill(ds, "Station")
                '               SQLCon.Close()
                '               For Each dr As DataRow In ds.Tables("Station").Rows
                '               USer_ID = Val(dr("User_ID") & "")
                '               Txt_User.Text = USer_ID
                '               Next

            Catch Ex As Exception

                MsgBox("Error Getting Part Info from Database: " & Ex.Message)
            End Try

        End If
    End Sub


    Private Sub Btn_Defect_17_Click(sender As Object, e As EventArgs) Handles Btn_Defect_17.Click
        defect_color = Color_17.BackColor
        defect_number = defect_Types(16).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_17.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_18_Click(sender As Object, e As EventArgs) Handles Btn_Defect_18.Click
        defect_color = Color_18.BackColor
        defect_number = defect_Types(17).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_18.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_19_Click(sender As Object, e As EventArgs) Handles Btn_Defect_19.Click
        defect_color = Color_19.BackColor
        defect_number = defect_Types(18).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_19.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_20_Click(sender As Object, e As EventArgs) Handles Btn_Defect_20.Click
        defect_color = Color_20.BackColor
        defect_number = defect_Types(19).Defect_Number

        Call Clear_Fore_Colors()
        Btn_Defect_20.ForeColor = Color.Red
    End Sub



    Private Sub Chk_Online_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Good.CheckedChanged
        If Chk_Online_Good.Checked Then
            Chk_Online_TU.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Rework.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Rework.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Good.Checked, 1, 0))
        End If

    End Sub

    Private Sub Chk_Online_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_TU.CheckedChanged
        If Chk_Online_TU.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Rework.Checked = False
        End If
        If Chk_Online_Good.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Rework.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_TU.Checked, 2, 0))
        End If

    End Sub

    Private Sub Chk_Online_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Reclear.CheckedChanged
        If Chk_Online_Reclear.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_TU.Checked = False
            Chk_Online_Rework.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Good.Checked = False And Chk_Online_Rework.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Reclear.Checked, 3, 0))
        End If

    End Sub

    Private Sub Chk_Online_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Rework.CheckedChanged
        If Chk_Online_Rework.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_TU.Checked = False
            Chk_Online_Reclear.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Good.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Rework.Checked, 4, 0))
        End If

    End Sub

    Private Sub Chk_Wetsand_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_Good.CheckedChanged
        If Chk_Wetsand_Good.Checked Then
            Chk_Wetsand_TU.Checked = False
            Chk_Wetsand_Reclear.Checked = False
            Chk_Wetsand_Rework.Checked = False
        End If
        If Chk_Wetsand_TU.Checked = False And Chk_Wetsand_Reclear.Checked = False And Chk_Wetsand_Rework.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_Good.Checked, 1, 0))
        End If

    End Sub

    Private Sub Chk_Wetsand_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_TU.CheckedChanged
        If Chk_Wetsand_TU.Checked Then
            Chk_Wetsand_Good.Checked = False
            Chk_Wetsand_Reclear.Checked = False
            Chk_Wetsand_Rework.Checked = False
        End If
        If Chk_Wetsand_Good.Checked = False And Chk_Wetsand_Reclear.Checked = False And Chk_Wetsand_Rework.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_TU.Checked, 2, 0))
        End If

    End Sub

    Private Sub Chk_Wetsand_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_Reclear.CheckedChanged
        If Chk_Wetsand_Reclear.Checked Then
            Chk_Wetsand_Good.Checked = False
            Chk_Wetsand_TU.Checked = False
            Chk_Wetsand_Rework.Checked = False
        End If
        If Chk_Wetsand_TU.Checked = False And Chk_Wetsand_Good.Checked = False And Chk_Wetsand_Rework.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_Reclear.Checked, 3, 0))
        End If

    End Sub

    Private Sub Chk_Wetsand_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_Rework.CheckedChanged
        If Chk_Wetsand_Rework.Checked Then
            Chk_Wetsand_Good.Checked = False
            Chk_Wetsand_TU.Checked = False
            Chk_Wetsand_Reclear.Checked = False
        End If
        If Chk_Wetsand_TU.Checked = False And Chk_Wetsand_Reclear.Checked = False And Chk_Wetsand_Good.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_Rework.Checked, 4, 0))
        End If

    End Sub

    Private Sub Chk_Buff_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_Good.CheckedChanged
        If Chk_Buff_Good.Checked Then
            Chk_Buff_TU.Checked = False
            Chk_Buff_Reclear.Checked = False
            Chk_Buff_Rework.Checked = False
        End If
        If Chk_Buff_TU.Checked = False And Chk_Buff_Reclear.Checked = False And Chk_Buff_Rework.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_Good.Checked, 1, 0))
        End If

    End Sub

    Private Sub Chk_Buff_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_TU.CheckedChanged
        If Chk_Buff_TU.Checked Then
            Chk_Buff_Good.Checked = False
            Chk_Buff_Reclear.Checked = False
            Chk_Buff_Rework.Checked = False
        End If
        If Chk_Buff_Good.Checked = False And Chk_Buff_Reclear.Checked = False And Chk_Buff_Rework.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_TU.Checked, 2, 0))
        End If

    End Sub

    Private Sub Chk_Buff_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_Reclear.CheckedChanged
        If Chk_Buff_Reclear.Checked Then
            Chk_Buff_Good.Checked = False
            Chk_Buff_TU.Checked = False
            Chk_Buff_Rework.Checked = False
        End If
        If Chk_Buff_TU.Checked = False And Chk_Buff_Good.Checked = False And Chk_Buff_Rework.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_Reclear.Checked, 3, 0))
        End If

    End Sub

    Private Sub Chk_Buff_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_Rework.CheckedChanged
        If Chk_Buff_Rework.Checked Then
            Chk_Buff_Good.Checked = False
            Chk_Buff_TU.Checked = False
            Chk_Buff_Reclear.Checked = False
        End If
        If Chk_Buff_TU.Checked = False And Chk_Buff_Reclear.Checked = False And Chk_Buff_Good.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_Rework.Checked, 4, 0))
        End If

    End Sub

    Private Sub Load_Defects(RFID_Defect_Inspection_ID As Integer)
        Dim query As String
        Dim p As New System.Drawing.Pen(defect_color, 6)
        Dim g As System.Drawing.Graphics


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
        SQLCon.Close()
        g = PictureBox1.CreateGraphics

        For Each dr As DataRow In ds.Tables("RFID_Defect").Rows
            p.Color = Color.FromArgb(dr("color"))
            g.DrawEllipse(p, dr("X_Pos") - 3, dr("Y_Pos") - 3, 6, 6)
        Next



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
            Lbl_Online_Inspector.Text = dr("Online_Inspector") & ""
            Lbl_Online_Time.Text = dr("Online_Inspection_Time") & ""
            Call Set_Status(dr("Online_Inspection_Status") & "", Chk_Online_Good, Chk_Online_TU, Chk_Online_Reclear, Chk_Online_Rework)

            Lbl_Wetsand_Inspector.Text = dr("Wet_Sander") & ""
            Lbl_Wetsand_Time.Text = dr("Wet_Sand_Time") & ""
            Call Set_Status(dr("Wet_Sand_Status") & "", Chk_Wetsand_Good, Chk_Wetsand_TU, Chk_Wetsand_Reclear, Chk_Wetsand_Rework)

            Lbl_Buff_Inspector.Text = dr("Buffer") & ""
            Lbl_Buff_Time.Text = dr("Buff_Time") & ""
            Call Set_Status(dr("Buff_Status") & "", Chk_Buff_Good, Chk_Buff_TU, Chk_Buff_Reclear, Chk_Buff_Rework)
        Next
        If ds.Tables("RFID_Defect_Inspection").Rows.Count < 1 Then
            Lbl_Online_Inspector.Text = ""
            Lbl_Online_Time.Text = ""
            Call Set_Status(0, Chk_Online_Good, Chk_Online_TU, Chk_Online_Reclear, Chk_Online_Rework)

            Lbl_Wetsand_Inspector.Text = ""
            Lbl_Online_Time.Text = ""
            Call Set_Status(0, Chk_Wetsand_Good, Chk_Wetsand_TU, Chk_Wetsand_Reclear, Chk_Wetsand_Rework)

            Lbl_Buff_Inspector.Text = ""
            Lbl_Buff_Time.Text = ""
            Call Set_Status(0, Chk_Buff_Good, Chk_Buff_TU, Chk_Buff_Reclear, Chk_Buff_Rework)
        End If
    End Sub
    Private Sub Set_Status(Status As String, ByRef good As CheckBox, ByRef Touch_Up As CheckBox, ByRef Reclear As CheckBox, ByRef Rework As CheckBox)
        Select Case Status
            Case "1"
                good.Checked = True
            Case "2"
                Touch_Up.Checked = True
            Case "3"
                Reclear.Checked = True
            Case "4"
                Rework.Checked = True
            Case Else
                good.Checked = False
                Touch_Up.Checked = False
                Reclear.Checked = False
                Rework.Checked = False
        End Select

    End Sub
    Private Sub Update_Checked(Group As Integer, Status As Integer)
        Dim query As String

        If Cmb_Area.SelectedIndex < 0 Then
            Exit Sub
        End If
        query = "Exec Update_RFID_Defect_Inspection " & RFID_Defect_Inspection_ID & ", " & Group & ", " & Status & ", " & Operator_ID & ", " & Station_ID
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
    End Sub

    Private Sub Btn_New_Revision_Click(sender As Object, e As EventArgs) Handles Btn_New_Revision.Click
        Dim query As String


        If Cmb_Area.SelectedIndex <= 0 Then
            Exit Sub
        End If
        query = "Update RFID_Defect_Inspection set Latest_Revision = 0, End_Date = getdate() where ID = " & RFID_Defect_Inspection_ID
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        query = "Insert into RFID_Defect_Inspection (Part_ID, Revision) values(" & Cmb_Area.SelectedValue & ", " & (Val(Txt_Revision.Text) + 1) & ")"
        cmd.CommandText = query
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Data()
        Call Clear_Fore_Colors()
        Call Load_Defect_inspection(RFID_Defect_Inspection_ID)
        Call Load_Defects(RFID_Defect_Inspection_ID)

    End Sub

    Private Sub Cmd_Next_Part_Click(sender As Object, e As EventArgs) Handles Cmd_Next_Part.Click
        Station_Pick_Form = New Station_Pick
        Station_Pick_Form.ShowDialog()
        If Len(Global_RFID) Then
            Cmb_Area.Text = Global_RFID
            Global_RFID = ""
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lbl_Changing_Parts.Visible = False
        Timer2.Enabled = False
    End Sub
End Class