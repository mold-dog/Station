Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Public Class Defect
    Dim defect_color As Color = Color.Transparent
    Dim defect_number As Integer
    '    Dim ID_Array() As Integer
    Public RFID As String
    Dim Part_ID As Integer = 0
    Dim Part_Type_English As String
    Dim Part_Type_Spanish As String
    Dim Color_English As String
    Dim Color_Spanish As String
    Dim RFID_Defect_Inspection_ID As Integer
    Private bindingsource_part As New BindingSource
    Dim loading As Boolean = False
    Dim Current_RFID As String = ""
    Dim current_enabled_state As Boolean = True
    Dim Set_Color_Required As Boolean = False
    Dim Request_Size As Boolean = False
    Dim save_x As Integer = 0
    Dim save_y As Integer = 0
    Dim Size_Array() As Integer
    Dim Wetsand_Complete As Boolean = False
    Dim Buff_Complete As Boolean = False
    Dim Inspection_Complete As Boolean = False

    Dim Check_For_Login_Start_Time As Date

    Structure Defect_Type
        Public Defect_Number As Int64
        Public Desciption As String
        Public Spanish As String
        Public Visible As Boolean
        Public Color As Integer
        Public Code As String
        Public Request_Size As Boolean
    End Structure

    Dim defect_Types(20) As Defect_Type
    Private Sub Load_Data()

        If Part_ID <= 0 Then
            Exit Sub
        End If

        Dim query As String
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0
        Dim Part_Type As Integer

        Try


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            ' Original Query - Modified 11/1/21 for addition of history tables'
            'query = "Select Part.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, "
            'query = query & " Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, Part_Type.Image_Name as Image, "
            'query = query & " isnull(final_color.id, 0) as color_id from (Part  left join part_type on part.part_type = Part_Type.id) "
            'query = query & " left join final_color on part.color = final_color.id where part.id = " & Part_ID

            query = "Select Part_Type_ID, Part_Type_Desc, Part_Type_Spanish, Color, Color_Spanish, Image, color_id from "
            query = query & "(Select Part.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, "
            query = query & "Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, Part_Type.Image_Name as Image, "
            query = query & "isnull(final_color.id, 0) as color_id from (Part  left join part_type on part.part_type = Part_Type.id) "
            query = query & "left join final_color on part.color = final_color.id where part.id =" & Part_ID & " union "
            query = query & "Select Part_History.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, "
            query = query & "Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, Part_Type.Image_Name as Image, "
            query = query & "isnull(final_color.id, 0) as color_id from (Part_History  left join part_type on Part_History.part_type = Part_Type.id) "
            query = query & "left join final_color on Part_History.color = final_color.id where Part_History.id =" & Part_ID & ") as current_part"

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part")
            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("Part").Rows
                Part_Type = dr("Part_Type_ID")
                Part_Type_English = dr("Part_Type_Desc") & ""
                If Len(dr("Part_Type_Spanish") & "") > 0 Then
                    Part_Type_Spanish = dr("Part_Type_Spanish") & ""
                Else
                    Part_Type_Spanish = dr("Part_Type_Desc") & ""
                End If
                Color_English = dr("Color") & ""
                If Len(dr("Color_Spanish") & "") > 0 Then
                    Color_Spanish = dr("Color_Spanish") & ""
                Else
                    Color_Spanish = dr("Color") & ""
                End If
                If Len(dr("Image") & "") > 0 Then
                    PictureBox1.Image = Image.FromFile(Image_Share & dr("Image"), False)
                Else
                    PictureBox1.Image = Nothing
                End If
                If Station_Area <> 1 And Station_Area <> 11 Then
                    If dr("color_id") = 0 Then
                        Btn_Set_Color.Visible = True
                    Else
                        Btn_Set_Color.Visible = False
                        Lbl_Set_Color.Visible = False
                    End If
                End If
            Next
            If Btn_Language.Text = "English" Then
                Txt_Part_Type.Text = Part_Type_Spanish
                Txt_Color.Text = Color_Spanish
            Else
                Txt_Part_Type.Text = Part_Type_English
                Txt_Color.Text = Color_English
            End If


            query = "Select defect.id, defect.description, defect.spanish, defect.color, defect.code, isnull(defect.request_size,0) as request_size from defect "
            query = query & " inner join part_type_defects on defect.id = part_type_defects.Defect_ID"
            query = query & " where part_Type_Defects.part_Type_id = " & Part_Type
            If Enable_Paint_Defects Then
                If Enable_Finesse_Defects = False Then
                    query = query & " and part_Type_Defects.paint = 1 "
                End If
            Else
                query = query & " and part_Type_Defects.finesse = 1 "
            End If

            query = query & " order by part_Type_Defects.Order_Number"


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
                defect_Types(counter).Code = dr2("Code") & ""
                defect_Types(counter).Visible = True
                If Station_ID = 9 Then
                    defect_Types(counter).Request_Size = dr2("Request_size")
                Else
                    defect_Types(counter).Request_Size = False
                End If
                If Btn_Language.Text = "English" Then
                    Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Spanish)
                Else
                    Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Desciption)
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

            ' Original Query - Modified 11/1/21 for addition of history tables'
            'query = "Select ID, Revision from RFID_Defect_Inspection where Part_Id = " & Part_ID & " And Latest_Revision = 1"

            query = "Select ID, Revision from (Select ID, Revision from RFID_Defect_Inspection where Part_Id = " & Part_ID & " And Latest_Revision = 1 "
            query = query & "union Select ID, Revision from RFID_Defect_Inspection_History where Part_Id = " & Part_ID & " And Latest_Revision = 1) as First_Rev "

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

            Call Load_Sizes()
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 1: " & ex.Message)
        End Try

    End Sub

    Sub Load_Sizes()

        Dim counter As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select id, size from defect_size order by size", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Defect_Size")
            SQLCon.Close()
            ReDim Size_Array(0)
            For Each dr As DataRow In ds.Tables("Defect_Size").Rows
                Select Case counter
                    Case 0
                        Chk_Size_1.Text = dr("size") & ""
                    Case 1
                        Chk_Size_2.Text = dr("size") & ""
                    Case 2
                        Chk_Size_3.Text = dr("size") & ""
                    Case 3
                        Chk_Size_4.Text = dr("size") & ""
                    Case 4
                        Chk_Size_5.Text = dr("size") & ""
                    Case 5
                        Chk_Size_6.Text = dr("size") & ""
                    Case 6
                        Chk_Size_7.Text = dr("size") & ""
                    Case 7
                        Chk_Size_8.Text = dr("size") & ""
                    Case 8
                        Chk_Size_9.Text = dr("size") & ""
                    Case 9
                        Chk_Size_10.Text = dr("size") & ""
                    Case 10
                        Chk_Size_11.Text = dr("size") & ""
                    Case 11
                        Chk_Size_12.Text = dr("size") & ""
                    Case 12
                        Chk_Size_13.Text = dr("size") & ""
                    Case 13
                        Chk_Size_14.Text = dr("size") & ""
                    Case 14
                        Chk_Size_15.Text = dr("size") & ""
                    Case 15
                        Chk_Size_16.Text = dr("size") & ""
                End Select
                ReDim Preserve Size_Array(counter)
                Size_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Defect Size Info from Database: " & Ex.Message)
        End Try



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
        If Box_Select_Size.Visible Then
            Exit Sub
        End If
        If Part_ID <= 0 Then
            Exit Sub
        End If
        If defect_number = 0 Then
            MsgBox("Select a defect before choosing the locations.")
            Exit Sub
        End If

        Try
            If Request_Size Then
                save_x = e.X
                save_y = e.Y
                Chk_Size_1.Checked = False
                Chk_Size_2.Checked = False
                Chk_Size_3.Checked = False
                Chk_Size_4.Checked = False
                Chk_Size_5.Checked = False
                Chk_Size_6.Checked = False
                Chk_Size_7.Checked = False
                Chk_Size_8.Checked = False
                Chk_Size_9.Checked = False
                Chk_Size_10.Checked = False
                Chk_Size_11.Checked = False
                Chk_Size_12.Checked = False
                Chk_Size_13.Checked = False
                Chk_Size_14.Checked = False
                Chk_Size_15.Checked = False
                Chk_Size_16.Checked = False
                Cmb_Distance.SelectedIndex = 0

                Box_Select_Size.Visible = True
            Else
                query = "insert into RFID_Defect (RFID_Defect_Inspection_ID, Defect_ID, X_Pos, Y_Pos, Inspector_ID, size, distance) values(" & RFID_Defect_Inspection_ID & ", " & defect_number & ", " & e.X & ", " & e.Y & ", " & Operator_ID & ", 0, 0)"
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()
                SQLCon.Close()
                g = PictureBox1.CreateGraphics
                g.DrawEllipse(p, e.X - 3, e.Y - 3, 6, 6)
            End If
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 2: " & ex.Message)
        End Try


    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub



    Private Sub Btn_Defect_1_Click(sender As Object, e As EventArgs) Handles Btn_Defect_1.Click
        defect_color = Color_1.BackColor
        defect_number = defect_Types(0).Defect_Number
        Request_Size = defect_Types(0).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_1.ForeColor = Color.Red

    End Sub

    Private Sub Btn_Defect_2_Click(sender As Object, e As EventArgs) Handles Btn_Defect_2.Click
        defect_color = Color_2.BackColor
        defect_number = defect_Types(1).Defect_Number
        Request_Size = defect_Types(1).Request_Size
        Call Clear_Fore_Colors()
        Btn_Defect_2.ForeColor = Color.Red
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Btn_Defect_3.Click
        defect_color = Color_3.BackColor
        defect_number = defect_Types(2).Defect_Number
        Request_Size = defect_Types(2).Request_Size
        Call Clear_Fore_Colors()
        Btn_Defect_3.ForeColor = Color.Red
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Language.Click
        Dim counter As Integer = 0

        If Btn_Language.Text = "Español" Then
            Spanish = True
            Btn_Language.Text = "English"
            If Len(Txt_RFID.Text) > 0 Then
                For counter = 0 To 19
                    If Len(defect_Types(counter).Spanish) > 0 Then
                        Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Spanish)
                    End If
                Next
                Txt_Part_Type.Text = Part_Type_Spanish
                Txt_Color.Text = Color_Spanish
            End If
            update_Language("Spanish")

        Else
            Spanish = False
            Btn_Language.Text = "Español"
            If Len(Txt_RFID.Text) > 0 Then
                For counter = 0 To 19
                    If Len(defect_Types(counter).Desciption) > 0 Then
                        Call Button_Text(Controls("Btn_Defect_" & counter + 1), defect_Types(counter).Code & " - " & defect_Types(counter).Desciption)
                    End If
                Next
                Txt_Part_Type.Text = Part_Type_English
                Txt_Color.Text = Color_English
            End If

            update_Language("English")

        End If

    End Sub

    Private Sub Defect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tab_Control.DrawMode = TabDrawMode.OwnerDrawFixed
        If Station_Area = 1 Then
            Me.Tab_Control.TabPages(8).Text = "Paint"
        Else
            Me.Tab_Control.TabPages(8).Text = "Press"
        End If


        PictureBox1.Image = Nothing

        Call Clear_Defect_inspection()


        Txt_User.Text = get_operator(Str(Operator_ID))
        If PLC_Station > 0 Then

            Me.Text = "Version - " & System.Windows.Forms.Application.ProductVersion.ToString & "  Defect - Station: " & PLC_Station
            Me.ControlBox = False
            Me.MaximizeBox = False
            Me.MinimizeBox = False

            If (Defect_Tabs And 1) = 0 Then
                Tab_Control.TabPages.Remove(TabPage1)
            End If
            If (Defect_Tabs And 2) = 0 Then
                Tab_Control.TabPages.Remove(TabPage2)
            End If
            If (Defect_Tabs And 4) = 0 Then
                Tab_Control.TabPages.Remove(TabPage3)
            End If
            If (Defect_Tabs And 8) = 0 Then
                Tab_Control.TabPages.Remove(TabPage4)
            End If
            If (Defect_Tabs And 16) = 0 Then
                Tab_Control.TabPages.Remove(TabPage5)
            End If
            If (Defect_Tabs And 32) = 0 Then
                Tab_Control.TabPages.Remove(TabPage6)
            End If
            If (Defect_Tabs And 64) = 0 Then
                Tab_Control.TabPages.Remove(TabPage7)
            End If
            If (Defect_Tabs And 128) = 0 Then
                Tab_Control.TabPages.Remove(TabPage8)
            End If
            If (Defect_Tabs And 256) = 0 Then
                Tab_Control.TabPages.Remove(TabPage9)
            End If

        End If

        Select Case Sub_Parameter
            Case 1
                Tab_Control.SelectedTab = TabPage1
            Case 2
                Tab_Control.SelectedTab = TabPage2
            Case 3
                Tab_Control.SelectedTab = TabPage3
            Case 4
                Tab_Control.SelectedTab = TabPage4
            Case 5
                Tab_Control.SelectedTab = TabPage5
            Case 6
                Tab_Control.SelectedTab = TabPage6
            Case 7
                Tab_Control.SelectedTab = TabPage7
            Case 8
                Tab_Control.SelectedTab = TabPage8
            Case 9
                Tab_Control.SelectedTab = TabPage9
        End Select

        update_Language("English")


    End Sub

    Private Sub Btn_Defect_4_Click(sender As Object, e As EventArgs) Handles Btn_Defect_4.Click
        defect_color = Color_4.BackColor
        defect_number = defect_Types(3).Defect_Number
        Request_Size = defect_Types(3).Request_Size
        Call Clear_Fore_Colors()
        Btn_Defect_4.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_5_Click(sender As Object, e As EventArgs) Handles Btn_Defect_5.Click
        defect_color = Color_5.BackColor
        defect_number = defect_Types(4).Defect_Number
        Request_Size = defect_Types(4).Request_Size
        Call Clear_Fore_Colors()
        Btn_Defect_5.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_6_Click(sender As Object, e As EventArgs) Handles Btn_Defect_6.Click
        defect_color = Color_6.BackColor
        defect_number = defect_Types(5).Defect_Number
        Request_Size = defect_Types(5).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_6.ForeColor = Color.Red

    End Sub

    Private Sub Btn_Defect_7_Click(sender As Object, e As EventArgs) Handles Btn_Defect_7.Click
        defect_color = Color_7.BackColor
        defect_number = defect_Types(6).Defect_Number
        Request_Size = defect_Types(6).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_7.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_8_Click(sender As Object, e As EventArgs) Handles Btn_Defect_8.Click
        defect_color = Color_8.BackColor
        defect_number = defect_Types(7).Defect_Number
        Request_Size = defect_Types(7).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_8.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_9_Click(sender As Object, e As EventArgs) Handles Btn_Defect_9.Click
        defect_color = Color_9.BackColor
        defect_number = defect_Types(8).Defect_Number
        Request_Size = defect_Types(8).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_9.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_10_Click(sender As Object, e As EventArgs) Handles Btn_Defect_10.Click
        defect_color = Color_10.BackColor
        defect_number = defect_Types(9).Defect_Number
        Request_Size = defect_Types(9).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_10.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_11_Click(sender As Object, e As EventArgs) Handles Btn_Defect_11.Click
        defect_color = Color_11.BackColor
        defect_number = defect_Types(10).Defect_Number
        Request_Size = defect_Types(10).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_11.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_12_Click(sender As Object, e As EventArgs) Handles Btn_Defect_12.Click
        defect_color = Color_12.BackColor
        defect_number = defect_Types(11).Defect_Number
        Request_Size = defect_Types(11).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_12.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_13_Click(sender As Object, e As EventArgs) Handles Btn_Defect_13.Click
        defect_color = Color_13.BackColor
        defect_number = defect_Types(12).Defect_Number
        Request_Size = defect_Types(12).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_13.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_14_Click(sender As Object, e As EventArgs) Handles Btn_Defect_14.Click
        defect_color = Color_14.BackColor
        defect_number = defect_Types(13).Defect_Number
        Request_Size = defect_Types(13).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_14.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_15_Click(sender As Object, e As EventArgs) Handles Btn_Defect_15.Click
        defect_color = Color_15.BackColor
        defect_number = defect_Types(14).Defect_Number
        Request_Size = defect_Types(14).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_15.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_16_Click(sender As Object, e As EventArgs) Handles Btn_Defect_16.Click
        defect_color = Color_16.BackColor
        defect_number = defect_Types(15).Defect_Number
        Request_Size = defect_Types(15).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_16.ForeColor = Color.Red
    End Sub

    Private Sub New_Part()
        loading = True
        Call Load_Data()
        If Station_Requires_Color And Btn_Set_Color.Visible Then
            Set_Color_Required = Clear_No_Color()
        Else
            Set_Color_Required = False
        End If
        Call Clear_Fore_Colors()
        Call Load_Defect_inspection(RFID_Defect_Inspection_ID)
        Call Load_Defects(RFID_Defect_Inspection_ID)
        If Operator_ID > 0 Then
            enable_disable(True)
        Else
            enable_disable(False)
        End If

        loading = False
    End Sub

    Private Function Clear_No_Color() As Boolean
        Dim query As String
        Dim Clear_Count As Integer = 0

        ' Original Query - Modified 11/1/21 for addition of history tables'
        'query = "Select top 1 paint_color.No_Color as Clear_Count from (paint_load_rfid inner join paint_load on paint_load_rfid.Carrier_ID = paint_load.Carrier_ID) "
        'query = query & " inner join paint_color on paint_load.Color = paint_color.PLC_Color where paint_load_rfid.rfid = '" & Txt_RFID.Text & "' order by paint_load.carrier_id desc"

        query = "Select top 1 Clear_Count from (Select top 1 paint_color.No_Color as Clear_Count from (paint_load_rfid inner join paint_load on paint_load_rfid.Carrier_ID = paint_load.Carrier_ID) "
        query = query & "inner join paint_color on paint_load.Color = paint_color.PLC_Color where paint_load_rfid.rfid = '" & Txt_RFID.Text & "' order by paint_load.carrier_id desc "
        query = query & "union Select top 1 paint_color.No_Color as Clear_Count from (Paint_Load_RFID_History inner join paint_load on Paint_Load_RFID_History.Carrier_ID = paint_load.Carrier_ID) "
        query = query & "inner join paint_color on paint_load.Color = paint_color.PLC_Color where Paint_Load_RFID_History.rfid = '" & Txt_RFID.Text & "' order by paint_load.carrier_id desc "
        query = query & "union Select top 1 paint_color.No_Color as Clear_Count from (paint_load_rfid inner join Paint_Load_History on paint_load_rfid.Carrier_ID = Paint_Load_History.Carrier_ID) "
        query = query & "inner join paint_color on Paint_Load_History.Color = paint_color.PLC_Color where paint_load_rfid.rfid = '" & Txt_RFID.Text & "' order by Paint_Load_History.carrier_id desc "
        query = query & "union Select top 1 paint_color.No_Color as Clear_Count from (Paint_Load_RFID_History inner join Paint_Load_History on Paint_Load_RFID_History.Carrier_ID = Paint_Load_History.Carrier_ID) "
        query = query & "inner join paint_color on Paint_Load_History.Color = paint_color.PLC_Color where Paint_Load_RFID_History.rfid = '" & Txt_RFID.Text & "' order by Paint_Load_History.carrier_id desc) "
        query = query & "as clear_count"



        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Clear")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Clear").Rows
            Clear_Count = dr("Clear_Count") & ""
        Next
        If Clear_Count > 0 Then
            Clear_No_Color = True
        Else
            Clear_No_Color = False
        End If

    End Function
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
        If Part_ID <= 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure you want to clear all defects from this part?", vbOKCancel) = MsgBoxResult.Ok Then

            query = "delete from RFID_Defect where RFID_Defect_Inspection_ID = " & RFID_Defect_Inspection_ID
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()

            Call Load_Defects(RFID_Defect_Inspection_ID)
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim First_RFID As String = ""
        Dim Found_Existing As Boolean = False
        If Operator_ID > 0 Then
            If current_enabled_state = False Or Btn_Defect_1.Enabled = False Then
                enable_disable(True)
            End If
        Else
            If current_enabled_state Or Btn_Defect_1.Enabled Then
                enable_disable(False)
            End If
        End If
        If Timer1.Interval = 100 Then
            Timer1.Interval = 2000
            If Len(RFID) > 0 Then
                Txt_RFID.Text = RFID
                Current_RFID = RFID
                RFID = ""
            End If
            If Station_ID = 0 Then
                Timer1.Enabled = False
            End If
        Else
            Try
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim da As New SqlDataAdapter("Execute Find_Stations_Parts " & PLC_Station & ", " & Operator_ID, SQLCon)
                da.SelectCommand.CommandTimeout = SQL_Timeout
                Dim ds As New DataSet
                da.Fill(ds, "Station")
                SQLCon.Close()
                For Each dr As DataRow In ds.Tables("Station").Rows
                    If Len(First_RFID) < 1 Then
                        First_RFID = dr("RFID") & ""
                    End If
                    If Current_RFID = dr("RFID") & "" Then
                        Found_Existing = True
                    End If
                Next
                If Len(First_RFID) > 0 Then
                    If PLC_Station > 1 And PLC_Station <> 210 And PLC_Station <> 211 And PLC_Station <> 212 Then
                        If Operator_ID > 0 Then
                            Timer1.Interval = 15000
                        Else
                            Timer1.Interval = 120000
                        End If
                    End If
                    If Not Found_Existing Then

                        If Create_New_Version Then
                            Call New_Revision(First_RFID)
                        End If
                        Txt_RFID.Text = First_RFID
                        Current_RFID = First_RFID
                        lbl_Changing_Parts.Visible = True
                        Timer2.Enabled = True
                    End If
                Else
                    If PLC_Station > 1 And PLC_Station <> 210 And PLC_Station <> 211 And PLC_Station <> 212 And Operator_ID = 0 Then
                        Timer1.Interval = 120000
                    Else
                        Timer1.Interval = 2000
                    End If
                End If

                lbl_Comm_Fail.Visible = False

            Catch Ex As Exception
                lbl_Comm_Fail.Visible = True

                MessageBox.Show(ReadException(Ex))
            End Try

        End If
        Call operator_FTQ()
    End Sub
    Private Sub Check_For_New_Operator()

        SQLCon.Open()
        Dim da2 As New SqlDataAdapter("Select User_ID, isnull(login_others,0) as login_others from Station inner join operator on station.user_id = operator.id where User_ID_Update_Time is not null and User_ID_Update_Time > dateadd(minute,-2,getdate()) and station.ID = " & Station_ID, SQLCon)
        da2.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds2 As New DataSet
        da2.Fill(ds2, "Station")
        SQLCon.Close()
        For Each dr2 As DataRow In ds2.Tables("Station").Rows

            If Operator_ID <> Val(dr2("User_ID") & "") Then
                Log_Operator_Change(False)
                If dr2("login_others") Then
                    Timer3.Enabled = False
                    change_operator_form = New Change_Operator
                    change_operator_form.ShowDialog()
                    Txt_User.Text = get_operator(Operator_ID)
                    Call operator_FTQ()
                    If Operator_ID > 0 Then
                        enable_disable(True)
                    Else
                        enable_disable(False)
                    End If
                    Timer1.Interval = 2000

                Else
                    Operator_ID = Val(dr2("User_ID") & "")

                    Txt_User.Text = get_operator(Operator_ID)

                    Call operator_FTQ()
                    If Operator_ID > 0 Then
                        enable_disable(True)
                    Else
                        enable_disable(False)
                    End If
                    Timer3.Enabled = False

                    SQLCon.ConnectionString = DBConnection
                    SQLCon.Open()
                    Dim cmd As New SqlCommand("Update Station Set User_ID_Update_Time = Null where id = " & Station_ID, SQLCon)
                    cmd.ExecuteNonQuery()
                    SQLCon.Close()
                    lbl_Changing_Operators.Visible = True
                    Timer2.Enabled = True

                End If
                Log_Operator_Change(True)
            End If
        Next



    End Sub

    Private Sub operator_FTQ()
        Dim query As String
        Dim tab_selected As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Select Case Tab_Control.SelectedTab.Name
                Case TabPage1.Name
                    tab_selected = 0
                Case TabPage2.Name
                    tab_selected = 1
                Case TabPage3.Name
                    tab_selected = 2
                Case TabPage4.Name
                    tab_selected = 3
                Case TabPage5.Name
                    tab_selected = 4
                Case TabPage6.Name
                    tab_selected = 5
                Case TabPage7.Name
                    tab_selected = 6
                Case TabPage8.Name
                    tab_selected = 7
            End Select

            query = "Exec Operator_Status_Totals " & Operator_ID & ", " & tab_selected

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Operator_ftq")
            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("Operator_ftq").Rows
                lbl_Good.Text = dr("Good")
                Lbl_TU.Text = dr("TU")
                Lbl_Rework.Text = dr("Rework")
                Lbl_Reclear.Text = dr("Reclear")
                Lbl_FTQ.Text = dr("FTQ")
            Next

        Catch ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 4: " & ex.Message)
        End Try

    End Sub

    Private Sub Btn_Defect_17_Click(sender As Object, e As EventArgs) Handles Btn_Defect_17.Click
        defect_color = Color_17.BackColor
        defect_number = defect_Types(16).Defect_Number
        Request_Size = defect_Types(16).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_17.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_18_Click(sender As Object, e As EventArgs) Handles Btn_Defect_18.Click
        defect_color = Color_18.BackColor
        defect_number = defect_Types(17).Defect_Number
        Request_Size = defect_Types(17).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_18.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_19_Click(sender As Object, e As EventArgs) Handles Btn_Defect_19.Click
        defect_color = Color_19.BackColor
        defect_number = defect_Types(18).Defect_Number
        Request_Size = defect_Types(18).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_19.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_20_Click(sender As Object, e As EventArgs) Handles Btn_Defect_20.Click
        defect_color = Color_20.BackColor
        defect_number = defect_Types(19).Defect_Number
        Request_Size = defect_Types(19).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_20.ForeColor = Color.Red
    End Sub



    Private Sub Chk_Online_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Good.CheckedChanged
        If Chk_Online_Good.Checked Then
            Chk_Online_TU.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Rework.Checked = False
            Chk_Online_Spin.Checked = False
            Chk_Online_Pinstripe.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Rework.Checked = False And Chk_Online_Spin.Checked = False And Chk_Online_Pinstripe.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Good.Checked, 1, 0))
        End If
        If Chk_Online_Good.Checked Then
            Chk_Online_Good.BackColor = Color.DarkGray
        Else
            Chk_Online_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Online_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_TU.CheckedChanged
        If Chk_Online_TU.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Rework.Checked = False
            Chk_Online_Spin.Checked = False
            Chk_Online_Pinstripe.Checked = False
        End If
        If Chk_Online_Good.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Rework.Checked = False And Chk_Online_Spin.Checked = False And Chk_Online_Pinstripe.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_TU.Checked, 2, 0))
        End If
        If Chk_Online_TU.Checked Then
            Chk_Online_TU.BackColor = Color.DarkGray
        Else
            Chk_Online_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Online_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Reclear.CheckedChanged
        If Chk_Online_Reclear.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_TU.Checked = False
            Chk_Online_Rework.Checked = False
            Chk_Online_Spin.Checked = False
            Chk_Online_Pinstripe.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Good.Checked = False And Chk_Online_Rework.Checked = False And Chk_Online_Spin.Checked = False And Chk_Online_Pinstripe.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Reclear.Checked, 3, 0))
        End If
        If Chk_Online_Reclear.Checked Then
            Chk_Online_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Online_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Online_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Rework.CheckedChanged
        If Chk_Online_Rework.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_TU.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Spin.Checked = False
            Chk_Online_Pinstripe.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Good.Checked = False And Chk_Online_Spin.Checked = False And Chk_Online_Pinstripe.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Rework.Checked, 4, 0))
        End If
        If Chk_Online_Rework.Checked Then
            Chk_Online_Rework.BackColor = Color.DarkGray
        Else
            Chk_Online_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Wetsand_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_Good.CheckedChanged

        If Wetsand_Complete = True Then
            MsgBox("Part has already been wetsand accepted")
            Chk_Wetsand_Good.Checked = False
            Exit Sub
        End If
        If Chk_Wetsand_Good.Checked Then
            Chk_Wetsand_TU.Checked = False
            Chk_Wetsand_Reclear.Checked = False
            Chk_Wetsand_Rework.Checked = False
        End If
        If Chk_Wetsand_TU.Checked = False And Chk_Wetsand_Reclear.Checked = False And Chk_Wetsand_Rework.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_Good.Checked, 1, 0))
        End If
        If Chk_Wetsand_Good.Checked Then
            Chk_Wetsand_Good.BackColor = Color.DarkGray
        Else
            Chk_Wetsand_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Wetsand_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_TU.CheckedChanged
        If Wetsand_Complete = True Then
            MsgBox("Part has already been wetsand accepted")
            Chk_Wetsand_TU.Checked = False
            Exit Sub
        End If
        If Chk_Wetsand_TU.Checked Then
            Chk_Wetsand_Good.Checked = False
            Chk_Wetsand_Reclear.Checked = False
            Chk_Wetsand_Rework.Checked = False
        End If
        If Chk_Wetsand_Good.Checked = False And Chk_Wetsand_Reclear.Checked = False And Chk_Wetsand_Rework.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_TU.Checked, 2, 0))
        End If
        If Chk_Wetsand_TU.Checked Then
            Chk_Wetsand_TU.BackColor = Color.DarkGray
        Else
            Chk_Wetsand_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Wetsand_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_Reclear.CheckedChanged
        If Wetsand_Complete = True Then
            MsgBox("Part has already been wetsand accepted")
            Chk_Wetsand_Reclear.Checked = False
            Exit Sub
        End If
        If Chk_Wetsand_Reclear.Checked Then
            Chk_Wetsand_Good.Checked = False
            Chk_Wetsand_TU.Checked = False
            Chk_Wetsand_Rework.Checked = False
        End If
        If Chk_Wetsand_TU.Checked = False And Chk_Wetsand_Good.Checked = False And Chk_Wetsand_Rework.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_Reclear.Checked, 3, 0))
        End If
        If Chk_Wetsand_Reclear.Checked Then
            Chk_Wetsand_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Wetsand_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Wetsand_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Wetsand_Rework.CheckedChanged
        If Wetsand_Complete = True Then
            MsgBox("Part has already been wetsand accepted")
            Chk_Wetsand_Rework.Checked = False
            Exit Sub
        End If
        If Chk_Wetsand_Rework.Checked Then
            Chk_Wetsand_Good.Checked = False
            Chk_Wetsand_TU.Checked = False
            Chk_Wetsand_Reclear.Checked = False
        End If
        If Chk_Wetsand_TU.Checked = False And Chk_Wetsand_Reclear.Checked = False And Chk_Wetsand_Good.Checked = False Then
            Call Update_Checked(2, IIf(Chk_Wetsand_Rework.Checked, 4, 0))
        End If
        If Chk_Wetsand_Rework.Checked Then
            Chk_Wetsand_Rework.BackColor = Color.DarkGray
        Else
            Chk_Wetsand_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Buff_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_Good.CheckedChanged
        If Buff_Complete = True Then
            MsgBox("Part has already been finesse accepted")
            Chk_Buff_Good.Checked = False
            Exit Sub
        End If
        If Chk_Buff_Good.Checked Then
            Chk_Buff_TU.Checked = False
            Chk_Buff_Reclear.Checked = False
            Chk_Buff_Rework.Checked = False
        End If
        If Chk_Buff_TU.Checked = False And Chk_Buff_Reclear.Checked = False And Chk_Buff_Rework.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_Good.Checked, 1, 0))
        End If
        If Chk_Buff_Good.Checked Then
            Chk_Buff_Good.BackColor = Color.DarkGray
        Else
            Chk_Buff_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Buff_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_TU.CheckedChanged
        If Buff_Complete = True Then
            MsgBox("Part has already been finesse accepted")
            Chk_Buff_TU.Checked = False
            Exit Sub
        End If
        If Chk_Buff_TU.Checked Then
            Chk_Buff_Good.Checked = False
            Chk_Buff_Reclear.Checked = False
            Chk_Buff_Rework.Checked = False
        End If
        If Chk_Buff_Good.Checked = False And Chk_Buff_Reclear.Checked = False And Chk_Buff_Rework.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_TU.Checked, 2, 0))
        End If
        If Chk_Buff_TU.Checked Then
            Chk_Buff_TU.BackColor = Color.DarkGray
        Else
            Chk_Buff_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Buff_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_Reclear.CheckedChanged
        If Buff_Complete = True Then
            MsgBox("Part has already been finesse accepted")
            Chk_Buff_Reclear.Checked = False
            Exit Sub
        End If
        If Chk_Buff_Reclear.Checked Then
            Chk_Buff_Good.Checked = False
            Chk_Buff_TU.Checked = False
            Chk_Buff_Rework.Checked = False
        End If
        If Chk_Buff_TU.Checked = False And Chk_Buff_Good.Checked = False And Chk_Buff_Rework.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_Reclear.Checked, 3, 0))
        End If
        If Chk_Buff_Reclear.Checked Then
            Chk_Buff_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Buff_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Buff_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Buff_Rework.CheckedChanged
        If Buff_Complete = True Then
            MsgBox("Part has already been finesse accepted")
            Chk_Buff_Rework.Checked = False
            Exit Sub
        End If
        If Chk_Buff_Rework.Checked Then
            Chk_Buff_Good.Checked = False
            Chk_Buff_TU.Checked = False
            Chk_Buff_Reclear.Checked = False
        End If
        If Chk_Buff_TU.Checked = False And Chk_Buff_Reclear.Checked = False And Chk_Buff_Good.Checked = False Then
            Call Update_Checked(3, IIf(Chk_Buff_Rework.Checked, 4, 0))
        End If
        If Chk_Buff_Rework.Checked Then
            Chk_Buff_Rework.BackColor = Color.DarkGray
        Else
            Chk_Buff_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Load_Defects(RFID_Defect_Inspection_ID As Integer)
        Dim query As String
        Dim p As New System.Drawing.Pen(defect_color, 6)
        Dim g As System.Drawing.Graphics
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(defect_color)


        Try


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()


            defect_number = 0
            PictureBox1.Refresh()


            ' Original Query - Modified 11/1/21 for addition of history tables'
            'query = "Select RFID_Defect.X_Pos, RFID_Defect.Y_Pos, defect.color, Defect.Code from RFID_Defect "
            'query = query & " inner join defect on RFID_Defect.Defect_ID = Defect.ID "
            'query = query & " where RFID_Defect.RFID_Defect_Inspection_id = " & RFID_Defect_Inspection_ID

            query = "Select X_Pos, Y_Pos, defect.color, Defect.Code from (Select RFID_Defect.X_Pos, RFID_Defect.Y_Pos, defect.color, Defect.Code from RFID_Defect "
            query = query & "inner join defect on RFID_Defect.Defect_ID = Defect.ID where RFID_Defect.RFID_Defect_Inspection_id = " & RFID_Defect_Inspection_ID & "union "
            query = query & "Select RFID_Defect_History.X_Pos, RFID_Defect_History.Y_Pos, defect.color, Defect.Code from RFID_Defect_History inner join defect on RFID_Defect_History.Defect_ID = Defect.ID "
            query = query & "where RFID_Defect_History.RFID_Defect_Inspection_id = " & RFID_Defect_Inspection_ID & ") as defect"

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "RFID_Defect")
            g = PictureBox1.CreateGraphics

            For Each dr As DataRow In ds.Tables("RFID_Defect").Rows
                p.Color = Color.FromArgb(dr("color"))
                g.DrawEllipse(p, dr("X_Pos") - 3, dr("Y_Pos") - 3, 6, 6)
            Next



            If Show_Paint_Defects Then
                query = "Exec Get_Past_Defects " & RFID_Defect_Inspection_ID & ", 1"
            Else
                query = "Exec Get_Past_Defects " & RFID_Defect_Inspection_ID & ", 0"
            End If


            Dim da2 As New SqlDataAdapter(query, SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "RFID_Old_Defect")
            SQLCon.Close()

            For Each dr As DataRow In ds2.Tables("RFID_Old_Defect").Rows
                drawBrush.Color = Color.FromArgb(dr("color"))
                g.DrawString(dr("Code") & "", drawFont, drawBrush, dr("X_Pos") - 10, dr("Y_Pos") - 10)
            Next
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 5: " & ex.Message)
        End Try


    End Sub
    Private Sub Load_Defect_inspection(RFID_Defect_Inspection_ID As Integer)
        Dim query As String

        Wetsand_Complete = False
        Buff_Complete = False
        Inspection_Complete = False


        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select * from (Select * from RFID_Defect_Inspection where id = " & RFID_Defect_Inspection_ID & " union Select * from RFID_Defect_Inspection_History where id = " & RFID_Defect_Inspection_ID & ") as Inspection"

            Dim temp_date As String = ""

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "RFID_Defect_Inspection")


            query = "Exec Get_Past_Inspections " & RFID_Defect_Inspection_ID


            Dim da2 As New SqlDataAdapter(query, SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Past_Inspections")

            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("RFID_Defect_Inspection").Rows
                If IsDBNull(dr("Wetsand_Complete")) Then
                    Wetsand_Complete = False
                Else
                    If dr("Wetsand_Complete") = True Then
                        Wetsand_Complete = True
                    Else
                        Wetsand_Complete = False
                    End If

                End If

                If IsDBNull(dr("Buff_Complete")) Then
                    Buff_Complete = False
                Else
                    If dr("Buff_Complete") = True Then
                        Buff_Complete = True
                    Else
                        Buff_Complete = False
                    End If

                End If
                If IsDBNull(dr("Final_Inspection_Complete")) Then
                    Inspection_Complete = False
                Else
                    If dr("Final_Inspection_Complete") = True Then
                        Inspection_Complete = True
                    Else
                        Inspection_Complete = False
                    End If

                End If
                Lbl_Online_Inspector.Text = get_operator(dr("Online_Inspector") & "")
                temp_date = dr("Online_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Online_Date.Text = Format(temp_date, "short date")
                    Lbl_Online_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Online_Date.Text = ""
                    Lbl_Online_Time.Text = ""
                End If
                Call Set_Status(dr("Online_Inspection_Status") & "", Chk_Online_Good, Chk_Online_TU, Chk_Online_Reclear, Chk_Online_Rework, Chk_Online_Spin, Chk_Online_Pinstripe)

                Lbl_Wetsand_Inspector.Text = get_operator(dr("Wet_Sander") & "")
                temp_date = dr("Wet_Sand_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Wetsand_Date.Text = Format(temp_date, "short date")
                    Lbl_Wetsand_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Wetsand_Date.Text = ""
                    Lbl_Wetsand_Time.Text = ""
                End If
                Call Set_Status(dr("Wet_Sand_Status") & "", Chk_Wetsand_Good, Chk_Wetsand_TU, Chk_Wetsand_Reclear, Chk_Wetsand_Rework, Chk_Wetsand_Spin, Chk_Wetsand_Pinstripe)

                Lbl_Buff_Inspector.Text = get_operator(dr("Buffer") & "")
                temp_date = dr("Buff_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Buff_Date.Text = Format(temp_date, "short date")
                    Lbl_Buff_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Buff_Date.Text = ""
                    Lbl_Buff_Time.Text = ""
                End If
                Call Set_Status(dr("Buff_Status") & "", Chk_Buff_Good, Chk_Buff_TU, Chk_Buff_Reclear, Chk_Buff_Rework, Chk_Buff_Spin, Chk_Buff_Pinstripe)
                Lbl_Final_Inspector.Text = get_operator(dr("Final_Inspector") & "")
                temp_date = dr("Final_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Final_Date.Text = Format(temp_date, "short date")
                    Lbl_Final_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Final_Date.Text = ""
                    Lbl_Final_Time.Text = ""
                End If
                Call Set_Status(dr("Final_Inspection_Status") & "", Chk_Final_Good, Chk_Final_TU, Chk_Final_Reclear, Chk_Final_Rework, Chk_Final_Spin, Chk_Final_Pinstripe)
                Lbl_Supervisor_Inspector.Text = get_operator(dr("Supervisor_Inspector") & "")
                temp_date = dr("Supervisor_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Supervisor_Date.Text = Format(temp_date, "short date")
                    Lbl_Supervisor_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Supervisor_Date.Text = ""
                    Lbl_Supervisor_Time.Text = ""
                End If
                Call Set_Status(dr("Supervisor_Inspection_Status") & "", Chk_Supervisor_Good, Chk_Supervisor_TU, Chk_Supervisor_Reclear, Chk_Supervisor_Rework, Chk_Supervisor_Spin, Chk_Supervisor_Pinstripe)
                Lbl_Decal_Inspector.Text = get_operator(dr("Decal_Inspector") & "")
                temp_date = dr("Decal_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Decal_Date.Text = Format(temp_date, "short date")
                    Lbl_Decal_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Decal_Date.Text = ""
                    Lbl_Decal_Time.Text = ""
                End If
                Call Set_Status(dr("Decal_Inspection_Status") & "", Chk_Decal_Good, Chk_Decal_TU, Chk_Decal_Reclear, Chk_Decal_Rework, Chk_Decal_Spin, Chk_Decal_Pinstripe)
                Lbl_Pinstripe_Inspector.Text = get_operator(dr("Pinstripe_Inspector") & "")
                temp_date = dr("Pinstripe_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Pinstripe_Date.Text = Format(temp_date, "short date")
                    Lbl_Pinstripe_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Pinstripe_Date.Text = ""
                    Lbl_Pinstripe_Time.Text = ""
                End If
                Call Set_Status(dr("Pinstripe_Inspection_Status") & "", Chk_Pinstripe_Good, Chk_Pinstripe_TU, Chk_Pinstripe_Reclear, Chk_Pinstripe_Rework, Chk_Pinstripe_Spin, Chk_Pinstripe_Pinstripe)
                Lbl_Prep_Inspector.Text = get_operator(dr("Prep_Inspector") & "")
                temp_date = dr("Prep_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Prep_Date.Text = Format(temp_date, "short date")
                    Lbl_Prep_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Prep_Date.Text = ""
                    Lbl_Prep_Time.Text = ""
                End If
                Call Set_Status(dr("Prep_Inspection_Status") & "", Chk_Prep_Good, Chk_Prep_TU, Chk_Prep_Reclear, Chk_Prep_Rework, Chk_Prep_Spin, Chk_Prep_Pinstripe)
                Lbl_Press_Inspector.Text = get_operator(dr("Press_Inspector") & "")
                temp_date = dr("Press_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Press_Date.Text = Format(temp_date, "short date")
                    Lbl_Press_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Press_Date.Text = ""
                    Lbl_Press_Time.Text = ""
                End If
                If dr("Press_Inspection_Status") = 4 Then
                    Chk_Press_Rework.Checked = True
                ElseIf dr("Press_Inspection_Status") = 7 Then
                    Chk_Press_Scrap.Checked = True
                ElseIf dr("Press_Inspection_Status") <> 4 And dr("Press_Inspection_Status") <> 7 Then
                    Chk_Press_Rework.Checked = False
                    Chk_Press_Scrap.Checked = False
                End If
            Next


            For Each dr2 As DataRow In ds2.Tables("Past_Inspections").Rows
                If Len(Lbl_Wetsand_Date.Text) = 0 Then
                    Lbl_Wetsand_Inspector.Text = get_operator(dr2("Wet_Sander") & "")
                    temp_date = dr2("Wet_Sand_Time") & ""
                    If IsDate(temp_date) Then
                        Lbl_Wetsand_Date.Text = Format(temp_date, "short date")
                        Lbl_Wetsand_Time.Text = Format(temp_date, "short time")
                    Else
                        Lbl_Wetsand_Date.Text = ""
                        Lbl_Wetsand_Time.Text = ""
                    End If

                End If

                If Len(Lbl_Buff_Date.Text) = 0 Then
                    Lbl_Buff_Inspector.Text = get_operator(dr2("Buffer") & "")
                    temp_date = dr2("Buff_Time") & ""
                    If IsDate(temp_date) Then
                        Lbl_Buff_Date.Text = Format(temp_date, "short date")
                        Lbl_Buff_Time.Text = Format(temp_date, "short time")
                    Else
                        Lbl_Buff_Date.Text = ""
                        Lbl_Buff_Time.Text = ""
                    End If

                End If

                If IsDBNull(dr2("WS_Complete")) Then
                    Wetsand_Complete = False
                Else
                    If dr2("WS_Complete") = True Then
                        Wetsand_Complete = True
                    Else
                        Wetsand_Complete = False
                    End If

                End If
                If IsDBNull(dr2("B_Complete")) Then
                    Buff_Complete = False
                Else
                    If dr2("B_Complete") = True Then
                        Buff_Complete = True
                    Else
                        Buff_Complete = False
                    End If

                End If
                If IsDBNull(dr2("FI_Complete")) Then
                    Inspection_Complete = False
                Else
                    If dr2("FI_Complete") = True Then
                        Inspection_Complete = True
                    Else
                        Inspection_Complete = False
                    End If

                End If

            Next


            If ds.Tables("RFID_Defect_Inspection").Rows.Count < 1 Then
                Call Clear_Defect_inspection()

            End If
        Catch ex As Exception
            lbl_Comm_Fail.Visible = False
        End Try

    End Sub

    Private Sub Clear_Defect_inspection()
        Try
            Lbl_Online_Inspector.Text = ""
            Lbl_Online_Date.Text = ""
            Lbl_Online_Time.Text = ""
            Call Set_Status(0, Chk_Online_Good, Chk_Online_TU, Chk_Online_Reclear, Chk_Online_Rework, Chk_Online_Spin, Chk_Online_Pinstripe)

            Lbl_Wetsand_Inspector.Text = ""
            Lbl_Wetsand_Date.Text = ""
            Lbl_Wetsand_Time.Text = ""
            Call Set_Status(0, Chk_Wetsand_Good, Chk_Wetsand_TU, Chk_Wetsand_Reclear, Chk_Wetsand_Rework, Chk_Wetsand_Spin, Chk_Wetsand_Pinstripe)

            Lbl_Buff_Inspector.Text = ""
            Lbl_Buff_Date.Text = ""
            Lbl_Buff_Time.Text = ""
            Call Set_Status(0, Chk_Buff_Good, Chk_Buff_TU, Chk_Buff_Reclear, Chk_Buff_Rework, Chk_Buff_Spin, Chk_Buff_Pinstripe)

            Lbl_Final_Inspector.Text = ""
            Lbl_Final_Date.Text = ""
            Lbl_Final_Time.Text = ""
            Call Set_Status(0, Chk_Final_Good, Chk_Final_TU, Chk_Final_Reclear, Chk_Final_Rework, Chk_Final_Spin, Chk_Final_Pinstripe)

            Lbl_Supervisor_Inspector.Text = ""
            Lbl_Supervisor_Date.Text = ""
            Lbl_Supervisor_Time.Text = ""
            Call Set_Status(0, Chk_Supervisor_Good, Chk_Supervisor_TU, Chk_Supervisor_Reclear, Chk_Supervisor_Rework, Chk_Supervisor_Spin, Chk_Supervisor_Pinstripe)

            Lbl_Decal_Inspector.Text = ""
            Lbl_Decal_Date.Text = ""
            Lbl_Decal_Time.Text = ""
            Call Set_Status(0, Chk_Decal_Good, Chk_Decal_TU, Chk_Decal_Reclear, Chk_Decal_Rework, Chk_Decal_Spin, Chk_Decal_Pinstripe)

            Lbl_Pinstripe_Inspector.Text = ""
            Lbl_Pinstripe_Date.Text = ""
            Lbl_Pinstripe_Time.Text = ""
            Call Set_Status(0, Chk_Pinstripe_Good, Chk_Pinstripe_TU, Chk_Pinstripe_Reclear, Chk_Pinstripe_Rework, Chk_Pinstripe_Spin, Chk_Pinstripe_Pinstripe)

            Lbl_Prep_Inspector.Text = ""
            Lbl_Prep_Date.Text = ""
            Lbl_Prep_Time.Text = ""
            Call Set_Status(0, Chk_Prep_Good, Chk_Prep_TU, Chk_Prep_Reclear, Chk_Prep_Rework, Chk_Prep_Spin, Chk_Prep_Pinstripe)

            Lbl_Press_Inspector.Text = ""
            Lbl_Press_Date.Text = ""
            Lbl_Press_Time.Text = ""
            Chk_Press_Rework.Checked = False
            Chk_Press_Scrap.Checked = False
        Catch ex As Exception
            lbl_Comm_Fail.Visible = False
        End Try

    End Sub


    Private Sub Set_Status(Status As String, ByRef good As CheckBox, ByRef Touch_Up As CheckBox, ByRef Reclear As CheckBox, ByRef Rework As CheckBox, ByRef spin As CheckBox, ByRef pinstripe As CheckBox)
        Select Case Status
            Case "1"
                good.Checked = True
            Case "2"
                Touch_Up.Checked = True
            Case "3"
                Reclear.Checked = True
            Case "4"
                Rework.Checked = True
            Case "5"
                spin.Checked = True
            Case "6"
                pinstripe.Checked = True
            Case Else
                good.Checked = False
                Touch_Up.Checked = False
                Reclear.Checked = False
                Rework.Checked = False
                spin.Checked = False
                pinstripe.Checked = False
        End Select

    End Sub
    Private Sub Update_Checked(Group As Integer, Status As Integer)
        Dim query As String

        If Part_ID <= 0 Then
            Exit Sub
        End If
        Try
            query = "Exec Update_RFID_Defect_Inspection " & RFID_Defect_Inspection_ID & ", " & Group & ", " & Status & ", " & Operator_ID & ", " & Station_ID
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 6: " & ex.Message)
        End Try

    End Sub

    Private Sub New_Revision(New_RFID As String)
        Dim query As String

        If Len(New_RFID) <= 0 Then
            Exit Sub
        End If
        Try
            query = "Exec Add_Revision '" & New_RFID & "'"
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 7: " & ex.Message)
        End Try

    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        lbl_Changing_Parts.Visible = False
        lbl_Changing_Operators.Visible = False
        Timer2.Enabled = False
    End Sub

    Private Sub Txt_RFID_TextChanged(sender As Object, e As EventArgs) Handles Txt_RFID.TextChanged
        Dim query As String
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select ID from (Select ID from Part where rfid = '" & Txt_RFID.Text & "' union Select ID from Part_History where rfid = '" & Txt_RFID.Text & "' ) as p_id"

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part")
            SQLCon.Close()

            Part_ID = 0

            For Each dr As DataRow In ds.Tables("Part").Rows
                Part_ID = dr("ID")
            Next

            Call New_Part()
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True

            MessageBox.Show(ReadException(ex))

        End Try

    End Sub

    Private Sub Btn_Change_User_Click(sender As Object, e As EventArgs) Handles Btn_Change_User.Click
        'change_operator_form = New Change_Operator
        'change_operator_form.ShowDialog()
        'Txt_User.Text = get_operator(Operator_ID)
        'Call operator_FTQ()
        'If Operator_ID > 0 Then
        '    enable_disable(True)
        'Else
        '    enable_disable(False)
        'End If
        'Timer1.Interval = 2000

        Check_For_Login_Start_Time = Now
        Timer3.Enabled = True


    End Sub

    Private Sub Chk_Online_Spin_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Spin.CheckedChanged
        If Chk_Online_Spin.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_TU.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Rework.Checked = False
            Chk_Online_Pinstripe.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Good.Checked = False And Chk_Online_Rework.Checked = False And Chk_Online_Pinstripe.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Spin.Checked, 5, 0))
        End If
        If Chk_Online_Spin.Checked Then
            Chk_Online_Spin.BackColor = Color.DarkGray
        Else
            Chk_Online_Spin.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Online_Pinstripe_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Online_Pinstripe.CheckedChanged
        If Chk_Online_Pinstripe.Checked Then
            Chk_Online_Good.Checked = False
            Chk_Online_TU.Checked = False
            Chk_Online_Reclear.Checked = False
            Chk_Online_Spin.Checked = False
            Chk_Online_Rework.Checked = False
        End If
        If Chk_Online_TU.Checked = False And Chk_Online_Reclear.Checked = False And Chk_Online_Good.Checked = False And Chk_Online_Spin.Checked = False And Chk_Online_Rework.Checked = False Then
            Call Update_Checked(1, IIf(Chk_Online_Pinstripe.Checked, 6, 0))
        End If
        If Chk_Online_Pinstripe.Checked Then
            Chk_Online_Pinstripe.BackColor = Color.DarkGray
        Else
            Chk_Online_Pinstripe.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub update_Language(Language As String)
        Dim query As String

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select top 1 * from defect_Screen_Translation where language = '" & Language & "'"

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Translation")
            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("Translation").Rows
                lbl_Part.Text = dr("Part") & ""
                Lbl_Type.Text = dr("Type") & ""
                Lbl_Color.Text = dr("Color") & ""
                TabPage1.Text = dr("Paint_Online") & " "
                TabPage2.Text = dr("wetsand") & " "
                TabPage3.Text = dr("finesse") & " "
                TabPage4.Text = dr("inspect") & " "
                TabPage5.Text = dr("supervisor") & " "
                TabPage6.Text = dr("Decal") & " "
                TabPage7.Text = dr("Pin_prep") & " "
                TabPage8.Text = dr("Part_Prep") & " "
                'TabPage9.Text = dr("Press") & " "
                Label_Online_Inspector.Text = dr("inspector") & ""
                Label_Online_Time.Text = dr("Time") & ""
                Chk_Online_Good.Text = dr("good") & ""
                Chk_Online_TU.Text = dr("touch_up") & ""
                Chk_Online_Reclear.Text = dr("reclear") & ""
                Chk_Online_Rework.Text = dr("rework") & ""
                Chk_Online_Spin.Text = dr("spin") & ""
                Chk_Online_Pinstripe.Text = dr("pinstripe") & ""
                Label_Wetsand_Inspector.Text = dr("inspector") & ""
                Label_Wetsand_Time.Text = dr("Time") & ""
                Chk_Wetsand_Good.Text = dr("good") & ""
                Chk_Wetsand_TU.Text = dr("touch_up") & ""
                Chk_Wetsand_Reclear.Text = dr("reclear") & ""
                Chk_Wetsand_Rework.Text = dr("rework") & ""
                Btn_Wet_Sand_Done.Text = dr("done") & ""
                Label_Buff_Inspector.Text = dr("inspector") & ""
                Label_Buff_Time.Text = dr("Time") & ""
                Chk_Buff_Good.Text = dr("good") & ""
                Chk_Buff_TU.Text = dr("touch_up") & ""
                Chk_Buff_Reclear.Text = dr("reclear") & ""
                Chk_Buff_Rework.Text = dr("reprocess") & ""
                Btn_Buff_Done.Text = dr("done") & ""
                Label_Final_Inspector.Text = dr("inspector") & ""
                Label_Final_Time.Text = dr("Time") & ""
                Chk_Final_Good.Text = dr("good") & ""
                Chk_Final_TU.Text = dr("touch_up") & ""
                Chk_Final_Reclear.Text = dr("reclear") & ""
                Chk_Final_Rework.Text = dr("reprocess") & ""
                Btn_Inspect_Done.Text = dr("done") & ""
                Label_Supervisor_Inspector.Text = dr("inspector") & ""
                Label_Supervisor_Time.Text = dr("Time") & ""
                Chk_Supervisor_Good.Text = dr("good") & ""
                Chk_Supervisor_TU.Text = dr("touch_up") & ""
                Chk_Supervisor_Reclear.Text = dr("reclear") & ""
                Chk_Supervisor_Rework.Text = dr("reprocess") & ""
                Btn_Supervisor_Done.Text = dr("done") & ""
                Label_Decal_Inspector.Text = dr("inspector") & ""
                Label_Decal_Time.Text = dr("Time") & ""
                Chk_Decal_Good.Text = dr("good") & ""
                Chk_Decal_TU.Text = dr("touch_up") & ""
                Chk_Decal_Reclear.Text = dr("reclear") & ""
                Chk_Decal_Rework.Text = dr("rework") & ""
                Btn_Decal_Done.Text = dr("done") & ""
                Label_Pinstripe_Inspector.Text = dr("inspector") & ""
                Label_Pinstripe_Time.Text = dr("Time") & ""
                Chk_Pinstripe_Good.Text = dr("good") & ""
                Chk_Pinstripe_TU.Text = dr("touch_up") & ""
                Chk_Pinstripe_Reclear.Text = dr("reclear") & ""
                Chk_Pinstripe_Rework.Text = dr("rework") & ""
                Btn_Pinstripe_Done.Text = dr("done") & ""
                Label_Prep_Inspector.Text = dr("inspector") & ""
                Label_Prep_Time.Text = dr("Time") & ""
                Chk_Prep_Good.Text = dr("good") & ""
                Chk_Prep_TU.Text = dr("touch_up") & ""
                Chk_Prep_Reclear.Text = dr("reclear") & ""
                Chk_Prep_Rework.Text = dr("rework") & ""
                Btn_Prep_Done.Text = dr("done") & ""
                Btn_Change_User.Text = dr("Change_user") & ""
                Label_Version.Text = dr("version") & ""
                Label_User.Text = dr("user") & ""
                Btn_Logout.Text = dr("Logout") & ""
                Btn_Set_Color.Text = dr("Set") & ""
                Label_Press_Inspector.Text = dr("inspector") & ""
                Label_Press_Time.Text = dr("Time") & ""
                Chk_Press_Rework.Text = dr("rework") & ""
                Chk_Press_Scrap.Text = dr("scrap") & ""
                Btn_Press_Done.Text = dr("done") & ""
            Next
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 9: " & ex.Message)
        End Try


    End Sub


    Private Sub Chk_Final_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Final_Good.CheckedChanged
        If Inspection_Complete = True Then
            MsgBox("Part has already been inspection accepted")
            Chk_Final_Good.Checked = False
            Exit Sub
        End If
        If Not loading Then
            If Chk_Final_Good.Checked Then
                Chk_Final_TU.Checked = False
                Chk_Final_Reclear.Checked = False
                Chk_Final_Rework.Checked = False
                Inspection_Form = New Inspection
                Inspection_Form.RFID = Txt_RFID.Text
                Inspection_Form.Show()
            End If
            If Chk_Final_TU.Checked = False And Chk_Final_Reclear.Checked = False And Chk_Final_Rework.Checked = False Then
                Call Update_Checked(4, IIf(Chk_Final_Good.Checked, 1, 0))
            End If
        End If
        If Chk_Final_Good.Checked Then
            Chk_Final_Good.BackColor = Color.DarkGray
        Else
            Chk_Final_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Final_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Final_TU.CheckedChanged
        If Inspection_Complete = True Then
            MsgBox("Part has already been inspection accepted")
            Chk_Final_TU.Checked = False
            Exit Sub
        End If
        If Chk_Final_TU.Checked Then
            Chk_Final_Good.Checked = False
            Chk_Final_Reclear.Checked = False
            Chk_Final_Rework.Checked = False
        End If
        If Chk_Final_Good.Checked = False And Chk_Final_Reclear.Checked = False And Chk_Final_Rework.Checked = False Then
            Call Update_Checked(4, IIf(Chk_Final_TU.Checked, 2, 0))
        End If
        If Chk_Final_TU.Checked Then
            Chk_Final_TU.BackColor = Color.DarkGray
        Else
            Chk_Final_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Final_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Final_Reclear.CheckedChanged
        If Inspection_Complete = True Then
            MsgBox("Part has already been inspection accepted")
            Chk_Final_Reclear.Checked = False
            Exit Sub
        End If
        If Chk_Final_Reclear.Checked Then
            Chk_Final_Good.Checked = False
            Chk_Final_TU.Checked = False
            Chk_Final_Rework.Checked = False
        End If
        If Chk_Final_Good.Checked = False And Chk_Final_TU.Checked = False And Chk_Final_Rework.Checked = False Then
            Call Update_Checked(4, IIf(Chk_Final_Reclear.Checked, 3, 0))
        End If
        If Chk_Final_Reclear.Checked Then
            Chk_Final_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Final_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Final_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Final_Rework.CheckedChanged
        If Inspection_Complete = True Then
            MsgBox("Part has already been inspection accepted")
            Chk_Final_Rework.Checked = False
            Exit Sub
        End If
        If Chk_Final_Rework.Checked Then
            Chk_Final_Good.Checked = False
            Chk_Final_TU.Checked = False
            Chk_Final_Reclear.Checked = False
        End If
        If Chk_Final_Good.Checked = False And Chk_Final_TU.Checked = False And Chk_Final_Reclear.Checked = False Then
            Call Update_Checked(4, IIf(Chk_Final_Rework.Checked, 4, 0))
        End If
        If Chk_Final_Rework.Checked Then
            Chk_Final_Rework.BackColor = Color.DarkGray
        Else
            Chk_Final_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Supervisor_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Supervisor_Good.CheckedChanged
        If Chk_Supervisor_Good.Checked Then
            Chk_Supervisor_TU.Checked = False
            Chk_Supervisor_Reclear.Checked = False
            Chk_Supervisor_Rework.Checked = False
        End If
        If Chk_Supervisor_TU.Checked = False And Chk_Supervisor_Reclear.Checked = False And Chk_Supervisor_Rework.Checked = False Then
            Call Update_Checked(5, IIf(Chk_Supervisor_Good.Checked, 1, 0))
        End If
        If Chk_Supervisor_Good.Checked Then
            Chk_Supervisor_Good.BackColor = Color.DarkGray
        Else
            Chk_Supervisor_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Supervisor_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Supervisor_TU.CheckedChanged
        If Chk_Supervisor_TU.Checked Then
            Chk_Supervisor_Good.Checked = False
            Chk_Supervisor_Reclear.Checked = False
            Chk_Supervisor_Rework.Checked = False
        End If
        If Chk_Supervisor_Good.Checked = False And Chk_Supervisor_Reclear.Checked = False And Chk_Supervisor_Rework.Checked = False Then
            Call Update_Checked(5, IIf(Chk_Supervisor_TU.Checked, 2, 0))
        End If
        If Chk_Supervisor_TU.Checked Then
            Chk_Supervisor_TU.BackColor = Color.DarkGray
        Else
            Chk_Supervisor_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Supervisor_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Supervisor_Reclear.CheckedChanged
        If Chk_Supervisor_Reclear.Checked Then
            Chk_Supervisor_Good.Checked = False
            Chk_Supervisor_TU.Checked = False
            Chk_Supervisor_Rework.Checked = False
        End If
        If Chk_Supervisor_Good.Checked = False And Chk_Supervisor_TU.Checked = False And Chk_Supervisor_Rework.Checked = False Then
            Call Update_Checked(5, IIf(Chk_Supervisor_Reclear.Checked, 3, 0))
        End If
        If Chk_Supervisor_Reclear.Checked Then
            Chk_Supervisor_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Supervisor_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Supervisor_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Supervisor_Rework.CheckedChanged
        If Chk_Supervisor_Rework.Checked Then
            Chk_Supervisor_Good.Checked = False
            Chk_Supervisor_TU.Checked = False
            Chk_Supervisor_Reclear.Checked = False
        End If
        If Chk_Supervisor_Good.Checked = False And Chk_Supervisor_TU.Checked = False And Chk_Supervisor_Reclear.Checked = False Then
            Call Update_Checked(5, IIf(Chk_Supervisor_Rework.Checked, 4, 0))
        End If
        If Chk_Supervisor_Rework.Checked Then
            Chk_Supervisor_Rework.BackColor = Color.DarkGray
        Else
            Chk_Supervisor_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Decal_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Decal_Good.CheckedChanged
        If Chk_Decal_Good.Checked Then
            Chk_Decal_TU.Checked = False
            Chk_Decal_Reclear.Checked = False
            Chk_Decal_Rework.Checked = False
        End If
        If Chk_Decal_TU.Checked = False And Chk_Decal_Reclear.Checked = False And Chk_Decal_Rework.Checked = False Then
            Call Update_Checked(6, IIf(Chk_Decal_Good.Checked, 1, 0))
        End If
        If Chk_Decal_Good.Checked Then
            Chk_Decal_Good.BackColor = Color.DarkGray
        Else
            Chk_Decal_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Decal_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Decal_TU.CheckedChanged
        If Chk_Decal_TU.Checked Then
            Chk_Decal_Good.Checked = False
            Chk_Decal_Reclear.Checked = False
            Chk_Decal_Rework.Checked = False
        End If
        If Chk_Decal_Good.Checked = False And Chk_Decal_Reclear.Checked = False And Chk_Decal_Rework.Checked = False Then
            Call Update_Checked(6, IIf(Chk_Decal_TU.Checked, 2, 0))
        End If
        If Chk_Decal_TU.Checked Then
            Chk_Decal_TU.BackColor = Color.DarkGray
        Else
            Chk_Decal_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Decal_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Decal_Reclear.CheckedChanged
        If Chk_Decal_Reclear.Checked Then
            Chk_Decal_Good.Checked = False
            Chk_Decal_TU.Checked = False
            Chk_Decal_Rework.Checked = False
        End If
        If Chk_Decal_Good.Checked = False And Chk_Decal_TU.Checked = False And Chk_Decal_Rework.Checked = False Then
            Call Update_Checked(6, IIf(Chk_Decal_Reclear.Checked, 3, 0))
        End If
        If Chk_Decal_Reclear.Checked Then
            Chk_Decal_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Decal_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Decal_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Decal_Rework.CheckedChanged
        If Chk_Decal_Rework.Checked Then
            Chk_Decal_Good.Checked = False
            Chk_Decal_TU.Checked = False
            Chk_Decal_Reclear.Checked = False
        End If
        If Chk_Decal_Good.Checked = False And Chk_Decal_TU.Checked = False And Chk_Decal_Reclear.Checked = False Then
            Call Update_Checked(6, IIf(Chk_Decal_Rework.Checked, 4, 0))
        End If
        If Chk_Decal_Rework.Checked Then
            Chk_Decal_Rework.BackColor = Color.DarkGray
        Else
            Chk_Decal_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Pinstripe_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Pinstripe_Good.CheckedChanged
        If Chk_Pinstripe_Good.Checked Then
            Chk_Pinstripe_TU.Checked = False
            Chk_Pinstripe_Reclear.Checked = False
            Chk_Pinstripe_Rework.Checked = False
        End If
        If Chk_Pinstripe_TU.Checked = False And Chk_Pinstripe_Reclear.Checked = False And Chk_Pinstripe_Rework.Checked = False Then
            Call Update_Checked(7, IIf(Chk_Pinstripe_Good.Checked, 1, 0))
        End If
        If Chk_Pinstripe_Good.Checked Then
            Chk_Pinstripe_Good.BackColor = Color.DarkGray
        Else
            Chk_Pinstripe_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Pinstripe_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Pinstripe_TU.CheckedChanged
        If Chk_Pinstripe_TU.Checked Then
            Chk_Pinstripe_Good.Checked = False
            Chk_Pinstripe_Reclear.Checked = False
            Chk_Pinstripe_Rework.Checked = False
        End If
        If Chk_Pinstripe_Good.Checked = False And Chk_Pinstripe_Reclear.Checked = False And Chk_Pinstripe_Rework.Checked = False Then
            Call Update_Checked(7, IIf(Chk_Pinstripe_TU.Checked, 2, 0))
        End If
        If Chk_Pinstripe_TU.Checked Then
            Chk_Pinstripe_TU.BackColor = Color.DarkGray
        Else
            Chk_Pinstripe_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Pinstripe_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Pinstripe_Reclear.CheckedChanged
        If Chk_Pinstripe_Reclear.Checked Then
            Chk_Pinstripe_Good.Checked = False
            Chk_Pinstripe_TU.Checked = False
            Chk_Pinstripe_Rework.Checked = False
        End If
        If Chk_Pinstripe_Good.Checked = False And Chk_Pinstripe_TU.Checked = False And Chk_Pinstripe_Rework.Checked = False Then
            Call Update_Checked(7, IIf(Chk_Pinstripe_Reclear.Checked, 3, 0))
        End If
        If Chk_Pinstripe_Reclear.Checked Then
            Chk_Pinstripe_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Pinstripe_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Pinstripe_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Pinstripe_Rework.CheckedChanged
        If Chk_Pinstripe_Rework.Checked Then
            Chk_Pinstripe_Good.Checked = False
            Chk_Pinstripe_TU.Checked = False
            Chk_Pinstripe_Reclear.Checked = False
        End If
        If Chk_Pinstripe_Good.Checked = False And Chk_Pinstripe_TU.Checked = False And Chk_Pinstripe_Reclear.Checked = False Then
            Call Update_Checked(7, IIf(Chk_Pinstripe_Rework.Checked, 4, 0))
        End If
        If Chk_Pinstripe_Rework.Checked Then
            Chk_Pinstripe_Rework.BackColor = Color.DarkGray
        Else
            Chk_Pinstripe_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Prep_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Prep_Good.CheckedChanged
        If Chk_Prep_Good.Checked Then
            Chk_Prep_TU.Checked = False
            Chk_Prep_Reclear.Checked = False
            Chk_Prep_Rework.Checked = False
        End If
        If Chk_Prep_TU.Checked = False And Chk_Prep_Reclear.Checked = False And Chk_Prep_Rework.Checked = False Then
            Call Update_Checked(8, IIf(Chk_Prep_Good.Checked, 1, 0))
        End If
        If Chk_Prep_Good.Checked Then
            Chk_Prep_Good.BackColor = Color.DarkGray
        Else
            Chk_Prep_Good.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Prep_TU_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Prep_TU.CheckedChanged
        If Chk_Prep_TU.Checked Then
            Chk_Prep_Good.Checked = False
            Chk_Prep_Reclear.Checked = False
            Chk_Prep_Rework.Checked = False
        End If
        If Chk_Prep_Good.Checked = False And Chk_Prep_Reclear.Checked = False And Chk_Prep_Rework.Checked = False Then
            Call Update_Checked(8, IIf(Chk_Prep_TU.Checked, 2, 0))
        End If
        If Chk_Prep_TU.Checked Then
            Chk_Prep_TU.BackColor = Color.DarkGray
        Else
            Chk_Prep_TU.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Prep_Reclear_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Prep_Reclear.CheckedChanged
        If Chk_Prep_Reclear.Checked Then
            Chk_Prep_Good.Checked = False
            Chk_Prep_TU.Checked = False
            Chk_Prep_Rework.Checked = False
        End If
        If Chk_Prep_Good.Checked = False And Chk_Prep_TU.Checked = False And Chk_Prep_Rework.Checked = False Then
            Call Update_Checked(8, IIf(Chk_Prep_Reclear.Checked, 3, 0))
        End If
        If Chk_Prep_Reclear.Checked Then
            Chk_Prep_Reclear.BackColor = Color.DarkGray
        Else
            Chk_Prep_Reclear.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Prep_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Prep_Rework.CheckedChanged
        If Chk_Prep_Rework.Checked Then
            Chk_Prep_Good.Checked = False
            Chk_Prep_TU.Checked = False
            Chk_Prep_Reclear.Checked = False
        End If
        If Chk_Prep_Good.Checked = False And Chk_Prep_TU.Checked = False And Chk_Prep_Reclear.Checked = False Then
            Call Update_Checked(8, IIf(Chk_Prep_Rework.Checked, 4, 0))
        End If
        If Chk_Prep_Rework.Checked Then
            Chk_Prep_Rework.BackColor = Color.DarkGray
        Else
            Chk_Prep_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Press_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Press_Rework.CheckedChanged
        If Chk_Press_Rework.Checked Then
            Chk_Press_Scrap.Checked = False
        End If
        If Chk_Press_Scrap.Checked = False Then
            Call Update_Checked(9, IIf(Chk_Press_Rework.Checked, 4, 0))
        End If
        If Chk_Press_Rework.Checked Then
            Chk_Press_Rework.BackColor = Color.DarkGray
        Else
            Chk_Press_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Chk_Press_Scrap_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Press_Scrap.CheckedChanged
        If Chk_Press_Scrap.Checked Then
            Chk_Press_Rework.Checked = False
        End If
        If Chk_Press_Rework.Checked = False Then
            Call Update_Checked(9, IIf(Chk_Press_Scrap.Checked, 7, 0))
        End If
        If Chk_Press_Scrap.Checked Then
            Chk_Press_Scrap.BackColor = Color.DarkGray
        Else
            Chk_Press_Scrap.BackColor = Color.WhiteSmoke
        End If

    End Sub

    Private Sub Clear_Data()
        Timer1.Interval = 2000

        loading = True
        Call Clear_Part()
        Call Clear_Fore_Colors()
        Call Clear_Defect_inspection()
        PictureBox1.Refresh()
        loading = False
    End Sub

    Private Sub Clear_Part()
        Dim counter As Integer = 0

        PictureBox1.Image = Nothing

        Txt_RFID.Text = ""
        Txt_Part_Type.Text = ""
        Txt_Color.Text = ""

        For counter = 1 To 20
            Call Invisible(Controls("Btn_Defect_" & counter), Controls("Color_" & counter))
        Next

        RFID_Defect_Inspection_ID = 0
        defect_number = 0
        PictureBox1.Refresh()
        Txt_Revision.Text = ""

    End Sub
    Private Sub Btn_Wet_Sand_Done_Click(sender As Object, e As EventArgs) Handles Btn_Wet_Sand_Done.Click

        If Chk_Wetsand_TU.Checked = True Or Chk_Wetsand_Good.Checked = True Or Chk_Wetsand_Reclear.Checked = True Or Chk_Wetsand_Rework.Checked = True Then
            If Wetsand_Complete = True Then
                MsgBox("Part has already been wetsand accepted")
                Exit Sub
            End If

            Call Update_Checked(2, 99)
            Wetsand_Complete = True


        End If


        'Call Clear_Data()
    End Sub

    Private Sub Btn_Buff_Done_Click(sender As Object, e As EventArgs) Handles Btn_Buff_Done.Click

        If Chk_Buff_Rework.Checked = True Or Chk_Buff_Good.Checked = True Or Chk_Buff_TU.Checked = True Or Chk_Buff_Reclear.Checked = True Then
            If Buff_Complete = True Then
                MsgBox("Part has already been finesse accepted")
                Exit Sub
            End If
            Call Update_Checked(3, 99)
            Buff_Complete = True


        End If

        'Call Clear_Data()

    End Sub

    Private Sub Btn_Inspect_Done_Click(sender As Object, e As EventArgs) Handles Btn_Inspect_Done.Click

        If Chk_Final_TU.Checked = True Or Chk_Final_Good.Checked = True Or Chk_Final_Reclear.Checked = True Or Chk_Final_Rework.Checked = True Then
            If Inspection_Complete = True Then
                MsgBox("Part has already been inspection accepted")
                Exit Sub
            End If
            Call Update_Checked(4, 99)
            Inspection_Complete = True

        End If

        'Call Clear_Data()

    End Sub

    Private Sub Btn_Supervisor_Done_Click(sender As Object, e As EventArgs) Handles Btn_Supervisor_Done.Click
        Call Clear_Data()

    End Sub

    Private Sub Btn_Decal_Done_Click(sender As Object, e As EventArgs) Handles Btn_Decal_Done.Click
        Call Clear_Data()

    End Sub

    Private Sub Btn_Pinstripe_Done_Click(sender As Object, e As EventArgs) Handles Btn_Pinstripe_Done.Click
        Call Clear_Data()

    End Sub

    Private Sub Btn_Prep_Done_Click(sender As Object, e As EventArgs) Handles Btn_Prep_Done.Click
        Call Clear_Data()

    End Sub

    Private Sub Btn_Press_Done_Click(sender As Object, e As EventArgs) Handles Btn_Press_Done.Click
        Call Clear_Data()

    End Sub

    Private Sub Tab_Control_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Tab_Control.DrawItem

        Dim g As Graphics = e.Graphics
        Dim tp As TabPage = Tab_Control.TabPages(e.Index)
        Dim br As Brush
        Dim sf As New StringFormat
        Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)

        sf.Alignment = StringAlignment.Center

        Dim strTitle As String = tp.Text
        'If the current index is the Selected Index, change the color
        If Tab_Control.SelectedIndex = e.Index Then
            'this is the background color of the tabpage
            'you could make this a stndard color for the selected page
            br = New SolidBrush(tp.BackColor)
            'this is the background color of the tab page
            g.FillRectangle(br, e.Bounds)
            'this is the background color of the tab page
            'you could make this a stndard color for the selected page
            If e.Index = 7 Then
                br = New SolidBrush(Color.White)
            Else
                br = New SolidBrush(tp.ForeColor)
            End If
            g.DrawString(strTitle, Tab_Control.Font, br, r, sf)
        Else
            'these are the standard colors for the unselected tab pages
            br = New SolidBrush(Color.WhiteSmoke)
            g.FillRectangle(br, e.Bounds)
            br = New SolidBrush(Color.Black)
            g.DrawString(strTitle, Tab_Control.Font, br, r, sf)
        End If
        operator_FTQ()
    End Sub

    Private Sub Btn_Logout_Click(sender As Object, e As EventArgs) Handles Btn_Logout.Click
        Operator_ID = 0
        Txt_User.Text = ""
        Call operator_FTQ()
        enable_disable(False)
        Log_Operator_Change(False)

    End Sub


    Sub enable_disable(status As Boolean)

        current_enabled_state = status

        If Set_Color_Required And Btn_Set_Color.Visible Then
            Chk_Online_Good.Enabled = False
            Chk_Online_TU.Enabled = False
            Chk_Online_Reclear.Enabled = False
            Chk_Online_Rework.Enabled = False
            Chk_Online_Spin.Enabled = False
            Chk_Online_Pinstripe.Enabled = False
            Lbl_Set_Color.Visible = True
        Else
            Chk_Online_Good.Enabled = status
            Chk_Online_TU.Enabled = status
            Chk_Online_Reclear.Enabled = status
            Chk_Online_Rework.Enabled = status
            Chk_Online_Spin.Enabled = status
            Chk_Online_Pinstripe.Enabled = status
        End If

        Btn_Logout.Enabled = status
        Btn_Defect_1.Enabled = status
        Btn_Defect_2.Enabled = status
        Btn_Defect_3.Enabled = status
        Btn_Defect_4.Enabled = status
        Btn_Defect_5.Enabled = status
        Btn_Defect_6.Enabled = status
        Btn_Defect_7.Enabled = status
        Btn_Defect_8.Enabled = status
        Btn_Defect_9.Enabled = status
        Btn_Defect_10.Enabled = status
        Btn_Defect_11.Enabled = status
        Btn_Defect_12.Enabled = status
        Btn_Defect_13.Enabled = status
        Btn_Defect_14.Enabled = status
        Btn_Defect_15.Enabled = status
        Btn_Defect_16.Enabled = status
        Btn_Defect_17.Enabled = status
        Btn_Defect_18.Enabled = status
        Btn_Defect_19.Enabled = status
        Btn_Defect_20.Enabled = status
        Btn_Clear.Enabled = status
        If PictureBox1.Enabled <> status Then
            PictureBox1.Enabled = status
            Call Load_Defects(RFID_Defect_Inspection_ID)
        End If


        If Btn_Set_Color.Visible Then
            status = False
            If Station_Requires_Color Then
                Lbl_Set_Color.Visible = True
            End If
        End If

        Chk_Wetsand_Good.Enabled = status
        Chk_Wetsand_TU.Enabled = status
        Chk_Wetsand_Reclear.Enabled = status
        Chk_Wetsand_Rework.Enabled = status
        Btn_Wet_Sand_Done.Enabled = status
        Chk_Buff_Good.Enabled = status
        Chk_Buff_TU.Enabled = status
        Chk_Buff_Reclear.Enabled = status
        Chk_Buff_Rework.Enabled = status
        Btn_Buff_Done.Enabled = status
        Chk_Final_Good.Enabled = status
        Chk_Final_TU.Enabled = status
        Chk_Final_Reclear.Enabled = status
        Chk_Final_Rework.Enabled = status
        Btn_Inspect_Done.Enabled = status
        Chk_Supervisor_Good.Enabled = status
        Chk_Supervisor_TU.Enabled = status
        Chk_Supervisor_Reclear.Enabled = status
        Chk_Supervisor_Rework.Enabled = status
        Btn_Supervisor_Done.Enabled = status
        Chk_Decal_Good.Enabled = status
        Chk_Decal_TU.Enabled = status
        Chk_Decal_Reclear.Enabled = status
        Chk_Decal_Rework.Enabled = status
        Btn_Decal_Done.Enabled = status
        Chk_Pinstripe_Good.Enabled = status
        Chk_Pinstripe_TU.Enabled = status
        Chk_Pinstripe_Reclear.Enabled = status
        Chk_Pinstripe_Rework.Enabled = status
        Btn_Pinstripe_Done.Enabled = status
        Chk_Prep_Good.Enabled = status
        Chk_Prep_TU.Enabled = status
        Chk_Prep_Reclear.Enabled = status
        Chk_Prep_Rework.Enabled = status
        Btn_Prep_Done.Enabled = status
        Chk_Press_Rework.Enabled = status
        Chk_Press_Scrap.Enabled = status
        Btn_Press_Done.Enabled = status

    End Sub

    Private Sub Btn_Set_Color_Click(sender As Object, e As EventArgs) Handles Btn_Set_Color.Click
        Dim query As String

        Set_Color_Form = New Set_Color
        Set_Color_Form.Part_ID = Part_ID
        Set_Color_Form.ShowDialog()

        If Part_ID <= 0 Then
            Exit Sub
        End If

        Try


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select Color, Color_Spanish, Color_ID from "
			query = query & "(Select Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, isnull(Final_Color.Id,0) as Color_ID "
            query = query & "from Part left join final_color on part.color = final_color.id where part.id = "& Part_ID & " union "
			query = query & "Select Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, isnull(Final_Color.Id,0) as Color_ID "
            query = query & "from Part_History left join final_color on Part_History.color = final_color.id where Part_History.id = " & Part_ID & ") "
            query = query & "as colr"

            'query = "Select Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, isnull(Final_Color.Id,0) as Color_ID "
            'query = query & " from Part left join final_color on part.color = final_color.id where part.id = " & Part_ID

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part")
            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("Part").Rows
                Color_English = dr("Color") & ""
                If Len(dr("Color_Spanish") & "") > 0 Then
                    Color_Spanish = dr("Color_Spanish") & ""
                Else
                    Color_Spanish = dr("Color") & ""
                End If
                If dr("Color_ID") > 0 Then
                    Btn_Set_Color.Visible = False
                    Lbl_Set_Color.Visible = False
                    enable_disable(current_enabled_state)
                End If
            Next
            If Spanish Then
                Txt_Color.Text = Color_Spanish
            Else
                Txt_Color.Text = Color_English
            End If

        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 10: " & ex.Message)
        End Try


    End Sub


    Private Sub uncheck(checked As Integer)
        If checked <> 1 Then
            Chk_Size_1.Checked = False
        End If
        If checked <> 2 Then
            Chk_Size_2.Checked = False
        End If
        If checked <> 3 Then
            Chk_Size_3.Checked = False
        End If
        If checked <> 4 Then
            Chk_Size_4.Checked = False
        End If
        If checked <> 5 Then
            Chk_Size_5.Checked = False
        End If
        If checked <> 6 Then
            Chk_Size_6.Checked = False
        End If
        If checked <> 7 Then
            Chk_Size_7.Checked = False
        End If
        If checked <> 8 Then
            Chk_Size_8.Checked = False
        End If
        If checked <> 9 Then
            Chk_Size_9.Checked = False
        End If
        If checked <> 10 Then
            Chk_Size_10.Checked = False
        End If
        If checked <> 11 Then
            Chk_Size_11.Checked = False
        End If
        If checked <> 12 Then
            Chk_Size_12.Checked = False
        End If
        If checked <> 13 Then
            Chk_Size_13.Checked = False
        End If
        If checked <> 14 Then
            Chk_Size_14.Checked = False
        End If
        If checked <> 15 Then
            Chk_Size_15.Checked = False
        End If
        If checked <> 16 Then
            Chk_Size_16.Checked = False
        End If
    End Sub


    Private Sub Chk_Size_1_Click(sender As Object, e As EventArgs) Handles Chk_Size_1.Click
        Call uncheck(1)

    End Sub
    Private Sub Chk_Size_2_Click(sender As Object, e As EventArgs) Handles Chk_Size_2.Click
        Call uncheck(2)

    End Sub

    Private Sub Chk_Size_3_Click(sender As Object, e As EventArgs) Handles Chk_Size_3.Click
        Call uncheck(3)

    End Sub

    Private Sub Chk_Size_4_Click(sender As Object, e As EventArgs) Handles Chk_Size_4.Click
        Call uncheck(4)

    End Sub

    Private Sub Chk_Size_5_Click(sender As Object, e As EventArgs) Handles Chk_Size_5.Click
        Call uncheck(5)

    End Sub

    Private Sub Chk_Size_6_Click(sender As Object, e As EventArgs) Handles Chk_Size_6.Click
        Call uncheck(6)

    End Sub

    Private Sub Chk_Size_7_Click(sender As Object, e As EventArgs) Handles Chk_Size_7.Click
        Call uncheck(7)

    End Sub

    Private Sub Chk_Size_8_Click(sender As Object, e As EventArgs) Handles Chk_Size_8.Click
        Call uncheck(8)

    End Sub

    Private Sub Chk_Size_9_Click(sender As Object, e As EventArgs) Handles Chk_Size_9.Click
        Call uncheck(9)

    End Sub

    Private Sub Chk_Size_10_Click(sender As Object, e As EventArgs) Handles Chk_Size_10.Click
        Call uncheck(10)

    End Sub

    Private Sub Chk_Size_11_Click(sender As Object, e As EventArgs) Handles Chk_Size_11.Click
        Call uncheck(11)

    End Sub

    Private Sub Chk_Size_12_Click(sender As Object, e As EventArgs) Handles Chk_Size_12.Click
        Call uncheck(12)

    End Sub

    Private Sub Chk_Size_13_Click(sender As Object, e As EventArgs) Handles Chk_Size_13.Click
        Call uncheck(13)

    End Sub

    Private Sub Chk_Size_14_Click(sender As Object, e As EventArgs) Handles Chk_Size_14.Click
        Call uncheck(14)

    End Sub

    Private Sub Chk_Size_15_Click(sender As Object, e As EventArgs) Handles Chk_Size_15.Click
        Call uncheck(15)

    End Sub

    Private Sub Chk_Size_16_Click(sender As Object, e As EventArgs) Handles Chk_Size_16.Click
        Call uncheck(16)

    End Sub

    Private Sub Btn_Size_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Size_Cancel.Click
        Box_Select_Size.Visible = False
    End Sub

    Private Sub Btn_Size_OK_Click(sender As Object, e As EventArgs) Handles Btn_Size_OK.Click
        Dim query As String
        Dim save_size As Integer = 0


        Dim p As New System.Drawing.Pen(defect_color, 6)
        Dim g As System.Drawing.Graphics
        If Chk_Size_1.Checked Then
            save_size = Size_Array(0)
        End If
        If Chk_Size_2.Checked Then
            save_size = Size_Array(1)
        End If
        If Chk_Size_3.Checked Then
            save_size = Size_Array(2)
        End If
        If Chk_Size_4.Checked Then
            save_size = Size_Array(3)
        End If
        If Chk_Size_5.Checked Then
            save_size = Size_Array(4)
        End If
        If Chk_Size_6.Checked Then
            save_size = Size_Array(5)
        End If
        If Chk_Size_7.Checked Then
            save_size = Size_Array(6)
        End If
        If Chk_Size_8.Checked Then
            save_size = Size_Array(7)
        End If
        If Chk_Size_9.Checked Then
            save_size = Size_Array(8)
        End If
        If Chk_Size_10.Checked Then
            save_size = Size_Array(9)
        End If
        If Chk_Size_11.Checked Then
            save_size = Size_Array(10)
        End If
        If Chk_Size_12.Checked Then
            save_size = Size_Array(11)
        End If
        If Chk_Size_13.Checked Then
            save_size = Size_Array(12)
        End If
        If Chk_Size_14.Checked Then
            save_size = Size_Array(13)
        End If
        If Chk_Size_15.Checked Then
            save_size = Size_Array(14)
        End If
        If Chk_Size_16.Checked Then
            save_size = Size_Array(15)
        End If
        If save_size = 0 Then
            MsgBox("Must select a size before saving.")
            Exit Sub
        End If


        Try
            query = "insert into RFID_Defect (RFID_Defect_Inspection_ID, Defect_ID, X_Pos, Y_Pos, Inspector_ID, size, distance) values(" & RFID_Defect_Inspection_ID & ", " & defect_number & ", " & save_x & ", " & save_y & ", " & Operator_ID & ", " & save_size & ", " & Cmb_Distance.SelectedIndex & ")"
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()
            g = PictureBox1.CreateGraphics
            g.DrawEllipse(p, save_x - 3, save_y - 3, 6, 6)
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database 11: " & ex.Message)
        End Try
        Box_Select_Size.Visible = False

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        Call Check_For_New_Operator()
        If Check_For_Login_Start_Time < DateAdd(DateInterval.Minute, -2, Now) Then
            Timer3.Enabled = False
        End If

    End Sub

    Private Sub Log_Operator_Change(Login As Boolean)
        Dim query As String

        If Login = 0 Then
            Try
                query = "Update Station_Users set End_Time = Getdate() where Station = " & Station_ID & " and End_Time is null"
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()
                SQLCon.Close()
            Catch ex As Exception
                lbl_Comm_Fail.Visible = True
                MsgBox("Error Getting Part Info from Database 12: " & ex.Message)
            End Try
        Else
            Try
                query = "Insert into Station_Users(Operator, Start_Time, Station) values (" & Operator_ID & ", Getdate() ," & Station_ID & ")"
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()
                SQLCon.Close()
            Catch ex As Exception
                lbl_Comm_Fail.Visible = True
                MsgBox("Error Getting Part Info from Database 13: " & ex.Message)
            End Try
        End If


    End Sub

    Public Function ReadException(ByVal ex As Exception) As String
        Dim msg As String = ex.Message
        If ex.InnerException IsNot Nothing Then
            msg = msg & vbCrLf & "---------" & vbCrLf & ReadException(ex.InnerException)
        End If
        Return msg
    End Function



End Class
