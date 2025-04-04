Imports System.Data
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.IO.Ports

Public Class Defect


    Public Const BSF_IGNORECURRENTTASK As Byte = 2 '&H2 'this ignores the current app
    Public Const BSF_POSTMESSAGE As Byte = 16 '&H10  'This posts the message
    Public Const BSM_APPLICATIONS As Byte = 8 '&H8  'This tells the windows message to just go to applications
    Public MessageId As Integer
    Private m_Mutex As System.Threading.Mutex 'Used to determine if the application is already open
    Private m_uniqueIdentifier As String = String.Empty 'user to determine if the app is already open

    <DllImport("USER32.DLL", EntryPoint:="BroadcastSystemMessageA",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True,
       CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function BroadcastSystemMessage(ByVal dwFlags As Int32, ByRef pdwRecipients As Int32, ByVal uiMessage As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
        ' Leave function empty - DLLImport attribute forwards calls to BroadcastSystemMessage to
        ' BroadcastSystemMessage in USER32.DLL.
    End Function
    <DllImport("USER32.DLL", EntryPoint:="RegisterWindowMessageA",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True,
       CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function RegisterWindowMessage(ByVal pString As String) As Integer
        ' Leave function empty - DLLImport attribute forwards calls to RegisterWindowMessage to
        ' RegisterWindowMessage in USER32.DLL.
    End Function

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
    Dim Wetsander_Complete As String = ""
    Dim Buffer_Complete As String = ""
    Dim Inspector_Complete As String = ""
    Dim Wetsander_Complete_Time As Date
    Dim Buffer_Complete_Time As Date
    Dim Inspector_Complete_Time As Date

    Dim Man_Entry_Msg As String
    Dim Inspection_Already_Complete_Msg As String
    Dim Wetsand_Already_Complete_Msg As String
    Dim Finesse_Already_Complete_Msg As String
    Dim Carrier_Position As String
    Dim Require_Carrier_Position As Integer

    Dim strength_fold As String = "C:\Users\RFID_Station\Desktop" ' My.Computer.FileSystem.SpecialDirectories.Desktop
    Dim strength_path As String = strength_fold & "\strength.txt"
    Dim comm_path As String = strength_fold & "\comm.txt"
    Dim strength_available As Boolean = False

    Private training_station As Boolean = False

    Public Property TrainingStation As Boolean
        Get
            Return training_station
        End Get
        Set(value As Boolean)
            training_station = value
        End Set
    End Property


    Dim Op_Rate As Integer = 0
    Dim Op_Rate_String As String = ""
    Dim Part_Type As Integer
    Dim Part_Type_Group As Integer
    Dim Part_Type_Group_Desc As String = ""

    Dim Check_For_Login_Start_Time As Date
    Dim Counter As Integer

    Structure Defect_Type
        Public Defect_Number As Int64
        Public Desciption As String
        Public Spanish As String
        Public Visible As Boolean
        Public Color As Integer
        Public Code As String
        Public Request_Size As Boolean
    End Structure

    Dim defect_Types(25) As Defect_Type

    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_NCLBUTTONDOWN As Integer = 161
        Const WM_SYSCOMMAND As Integer = 274
        Const HTCAPTION As Integer = 2
        Const SC_MOVE As Integer = 61456

        If (m.Msg = WM_SYSCOMMAND) And (m.WParam.ToInt32() = SC_MOVE) Then
            Return
        End If

        If (m.Msg = WM_NCLBUTTONDOWN) And (m.WParam.ToInt32() = HTCAPTION) Then
            Return
        End If

        MyBase.WndProc(m)
    End Sub



    Private Sub Load_Data()


        If Part_ID <= 0 Then
            Exit Sub
        End If

        Dim query As String = ""
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0


        Try


            query = "Select Part.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, "
            query = query & " Part_Type.Part_Type_Group, part_type_group.Description, "
            query = query & " Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, Part_Type.Image_Name as Image, "

            If training_station Then
                query = query & " isnull(final_color.id, 0) as color_id from (RFID_t.dbo.Part left join part_type on part.part_type = Part_Type.id) "
            Else
                query = query & " isnull(final_color.id, 0) as color_id from (Part left join part_type on part.part_type = Part_Type.id) "
            End If

            query = query & " left join final_color on part.color = final_color.id left join Part_Type_Group on Part_Type.Part_Type_Group = Part_Type_Group.ID where part.id = " & Part_ID


            Dim ds As DataSet = queryDB(query, "Part", False)

            For Each dr As DataRow In ds.Tables("Part").Rows
                Part_Type = dr("Part_Type_ID")
                Part_Type_Group = dr("Part_Type_Group")
                Part_Type_English = dr("Part_Type_Desc") & ""
                Part_Type_Group_Desc = dr("description") & ""
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
                If dr("color_id") = 0 And Tab_Control.SelectedTab.Name <> "TabPage9" Then
                    Btn_Set_Color.Visible = True
                Else
                    Btn_Set_Color.Visible = False
                    Lbl_Set_Color.Visible = False
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
            query = query & " where ((part_Type_Defects.part_Type_id = " & Part_Type & ") Or (Part_Type_Defects.Part_Type_Id = 109)) "

            ' Check if we want to show defects at all, then enable the correct collection of defects based on activity
            If Show_Paint_Defects Then
                If Enable_Paint_Defects Then
                    query = query & " and part_Type_Defects.paint = 1 "
                ElseIf Enable_Finesse_Defects Then
                    query = query & " and part_Type_Defects.finesse = 1 "
                ElseIf Enable_Mold_Defects Then
                    query = query & " and part_Type_Defects.mold = 1 "
                ElseIf Enable_Bond_Defects Then
                    query = query & " and part_Type_Defects.bond = 1 "
                ElseIf Enable_Assembly_Defects Then
                    query = query & " and part_Type_Defects.assembly = 1 "
                ElseIf Enable_Finishing_Defects Then
                    query = query & " and part_Type_Defects.finishing = 1 "
                End If

            End If

            query = query & " order by part_Type_Defects.Order_Number"
            Dim ds2 As DataSet = queryDB(query, "Defect", False)

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
                Controls("Color_" & counter + 1).BringToFront()

                counter += 1
                If counter >= 25 Then
                    Exit For
                End If
            Next

            For counter2 = counter To 24
                Call Invisible(Controls("Btn_Defect_" & counter2 + 1), Controls("Color_" & counter2 + 1))
            Next


            RFID_Defect_Inspection_ID = 0


            defect_number = 0
            PictureBox1.Refresh()


            query = "Select ID, Revision from RFID_Defect_Inspection where Part_Id = " & Part_ID & " And Latest_Revision = 1"
            Dim ds3 As DataSet = queryDB(query, "RFID_Defect_Inspection", True)

            counter = 0
            Txt_Revision.Text = ""
            For Each dr3 As DataRow In ds3.Tables("RFID_Defect_Inspection").Rows
                RFID_Defect_Inspection_ID = dr3("ID")
                Txt_Revision.Text = dr3("revision")
            Next

            query = "Exec Operator_Status_by_Operator " & Operator_ID

            Lbl_Rate.Text = "0"
            Op_Rate_String = ""
            Op_Rate = 0
            Dim ds4 As DataSet = queryDB(query, "Op_Rate", True)

            WriteEvent("Successfully wrote to database:14 " & query, EventInfo)
            For Each dr4 As DataRow In ds4.Tables("Op_Rate").Rows
                If Part_Type_Group = 12 Then
                    If Part_Type_English = dr4("group_desc") Then
                        If Tab_Control.SelectedTab.Name = "TabPage2" And dr4("inspection") = "Wet Sand" Then
                            Op_Rate = dr4("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage3" And dr4("inspection") = "Finesse" Then
                            Op_Rate = dr4("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage4" And dr4("inspection") = "Inspect" Then
                            Op_Rate = dr4("Rate")
                        End If
                    End If
                    Else
                    If Part_Type_Group_Desc = dr4("group_desc") Then
                        If Tab_Control.SelectedTab.Name = "TabPage2" And dr4("inspection") = "Wet Sand" Then
                            Op_Rate = dr4("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage3" And dr4("inspection") = "Finesse" Then
                            Op_Rate = dr4("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage4" And dr4("inspection") = "Inspect" Then
                            Op_Rate = dr4("Rate")
                        End If
                    End If
                End If
            Next
            Op_Rate_String = Op_Rate
            Lbl_Rate.Text = Op_Rate_String
            If Op_Rate > 0 Then
                Lbl_Rate.ForeColor = Color.Green
            ElseIf Op_Rate = 0 Then
                Lbl_Rate.ForeColor = Color.Black
            ElseIf Op_Rate < 0 Then
                Lbl_Rate.ForeColor = Color.Red
            End If


            Call Load_Sizes()
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:14 " & ex.Message)
            WriteEvent("Error Getting Part Info from Database:14 " & query, EventInfo)
        End Try

    End Sub




    Sub Load_Sizes()

        Dim counter As Integer = 0
        Try

            Dim ds As DataSet = queryDB("Select id, size from defect_size order by size", "Defect_Size", False)

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
                queryDB(query, "temp", True)

                g = PictureBox1.CreateGraphics
                g.DrawEllipse(p, e.X - 3, e.Y - 3, 6, 6)
            End If
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:15 " & ex.Message)
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
                For counter = 0 To 24
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
                For counter = 0 To 24
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

        checkprevious()  ' This subroutine is part of the code to make sure only one instance of the app can run on the PC at once

        Tab_Control.DrawMode = TabDrawMode.OwnerDrawFixed

        If Station_Area = 1 Then  ' Station_Area variable populate in Module1 from SQL station table
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

            If ((Defect_Tabs And 1) Or (Defect_Tabs And 64)) Then
                strength_available = True
                'btn_set_strength1.Visible = True
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

        'moved from timer 1 sub 3/27/23
        If Len(RFID) > 0 Then  'RFID variable is passed from Part screen if Defect screen is opened from part screen.  If this is an inspection station and Defect is opened when program starts, RFID variable will be nothing
            Txt_RFID.Text = RFID  ' If opened from Part screen, load the RFID from part screen into the Defect screen varaibles
            Current_RFID = RFID
            RFID = ""  ' Once the RFID variable has been loaded into Defect screen variables load nothing into RFID
        End If
        If Station_ID = 0 Then ' If the Defect screen has been called by the part screen it will be done from a computer that isn't configured in the station table so disable the auto refresh of the screen
            Timer1.Enabled = False
        End If
        If Auto_Scan_Refresh = True Then
            Timer1.Enabled = True
            Btn_Get_Part.Enabled = False
            Btn_Get_Part.Visible = False
        End If
        If PLC_Station = 0 Then
            Btn_Get_Part.Enabled = False
            Btn_Get_Part.Visible = False
        End If

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

        Try

            ' TODO: check if this needs to talk to RFID_t or RFID database when training station

            query = "Select top 1 paint_color.No_Color as Clear_Count from (paint_load_rfid inner join paint_load on paint_load_rfid.Carrier_ID = paint_load.Carrier_ID) "
            query = query & " inner join paint_color on paint_load.Color = paint_color.PLC_Color where paint_load_rfid.rfid = '" & Txt_RFID.Text & "' order by paint_load.carrier_id desc"

            Dim ds As DataSet = queryDB(query, "Clear", False)

            For Each dr As DataRow In ds.Tables("Clear").Rows
                If IsNumeric(dr("Clear_Count")) Then
                    Clear_Count = dr("Clear_Count")
                End If

            Next
            If Clear_Count > 0 Then
                Clear_No_Color = True
            Else
                Clear_No_Color = False
            End If
        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True

            MsgBox("Error Getting Part Info from Database:10 " & Ex.Message)
        End Try

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
        Btn_Defect_21.ForeColor = Btn_Language.ForeColor
        Btn_Defect_22.ForeColor = Btn_Language.ForeColor
        Btn_Defect_23.ForeColor = Btn_Language.ForeColor
        Btn_Defect_24.ForeColor = Btn_Language.ForeColor
        Btn_Defect_25.ForeColor = Btn_Language.ForeColor

    End Sub

    Private Sub Btn_Clear_Click(sender As Object, e As EventArgs) Handles Btn_Clear.Click
        Dim query As String = ""
        If Part_ID <= 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure you want to clear all defects from this part?", vbOKCancel) = MsgBoxResult.Ok Then

            query = "delete from RFID_Defect where RFID_Defect_Inspection_ID = " & RFID_Defect_Inspection_ID
            queryDB(query, "temp", True) ' previousl was false

            Call Load_Defects(RFID_Defect_Inspection_ID)
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim First_RFID As String = ""
        Dim Found_Existing As Boolean = False


        If Timer1.Interval = 1 Then
            Timer1.Interval = 2000
        End If
        If Operator_ID > 0 Then
            If current_enabled_state = False Or Btn_Defect_1.Enabled = False Then
                enable_disable(True)
            End If
        Else
            If current_enabled_state Or Btn_Defect_1.Enabled Then
                enable_disable(False)
            End If
        End If
        'If Timer1.Interval = 100 Then
        '    Timer1.Interval = 2000
        '    If Len(RFID) > 0 Then
        '        Txt_RFID.Text = RFID
        '        Current_RFID = RFID
        '        RFID = ""
        '    End If
        '    If Station_ID = 0 Then
        '        Timer1.Enabled = False
        '    End If
        'Else
        Try

            Dim ds As DataSet = queryDB("Execute Find_Stations_Parts " & PLC_Station & ", " & Operator_ID, "Station", True)

            For Each dr As DataRow In ds.Tables("Station").Rows
                If Len(First_RFID) < 1 Then
                    First_RFID = dr("RFID") & ""
                End If
                If Current_RFID = dr("RFID") & "" Then
                    Found_Existing = True
                End If
                If IsDBNull(dr("Require_Carrier_Position")) Then
                    Require_Carrier_Position = 0
                Else
                    Require_Carrier_Position = dr("Require_Carrier_Position") & ""
                End If

                If IsDBNull(dr("Carrier_Position")) Then
                    Carrier_Position = ""
                Else
                    Carrier_Position = dr("Carrier_Position") & ""
                    Txt_Position.Text = Carrier_Position
                End If
            Next
            If Len(First_RFID) > 0 Then

                'If PLC_Station > 1 And PLC_Station <> 210 And PLC_Station <> 211 And PLC_Station <> 212 Then
                '    If Operator_ID > 0 Then
                '        Timer1.Interval = 15000
                '    Else
                '        Timer1.Interval = 120000
                '    End If
                'End If
                If Not Found_Existing Then


                    If Create_New_Version Then
                        Call New_Revision(First_RFID)
                    End If
                    Txt_RFID.Text = First_RFID
                    Current_RFID = First_RFID
                    lbl_Changing_Parts.Visible = True
                    Timer2.Enabled = True
                End If
                'Else
                '    If PLC_Station > 1 And PLC_Station <> 210 And PLC_Station <> 211 And PLC_Station <> 212 And Operator_ID = 0 Then
                '        Timer1.Interval = 120000
                '    Else
                '        Timer1.Interval = 2000
                '    End If
            End If

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True

            MsgBox("Error Getting Part Info from Database: " & Ex.Message)
        End Try

        'End If

        If Operator_ID <> 0 Then
            Call operator_FTQ()
        End If

    End Sub
    Private Sub Check_For_New_Operator()

        Dim query As String = "Select User_ID, isnull(login_others,0) as login_others, isnull(Supervisor,0) as Supervisor, isnull(Inspector,0) as Inspector, isnull(Allow_Strength_Adjust,0) as Allow_Strength_Adjust from Station inner join operator on station.user_id = operator.id where User_ID_Update_Time is not null and User_ID_Update_Time > dateadd(minute,-2,getdate()) and station.ID = " & Station_ID
        Dim ds2 As DataSet = queryDB(query, "Station", False)

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
                    Timer1.Interval = 2000 '2000

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

                    queryDB("Update Station Set User_ID_Update_Time = Null where id = " & Station_ID, "temp", False)
                    lbl_Changing_Operators.Visible = True
                    Timer2.Enabled = True

                End If
                Log_Operator_Change(True)

            End If

            If Defect_Tabs = 30 Then
                If Me.InvokeRequired Then
                    Me.Invoke(New Action(Of String)(AddressOf Check_For_New_Operator), True)
                    Return
                End If


                If dr2("Supervisor") Then
                    Tab_Control.TabPages.Remove(TabPage4)
                    Tab_Control.TabPages.Remove(TabPage5)

                    Tab_Control.TabPages.Insert(2, TabPage4)
                    Tab_Control.TabPages.Insert(3, TabPage5)
                ElseIf dr2("Inspector") Then
                    Tab_Control.TabPages.Remove(TabPage4)
                    Tab_Control.TabPages.Remove(TabPage5)

                    Tab_Control.TabPages.Insert(2, TabPage4)
                Else
                    Tab_Control.TabPages.Remove(TabPage4)
                    Tab_Control.TabPages.Remove(TabPage5)
                End If
            End If


            If (dr2("Allow_Strength_Adjust") And strength_available) Then
                btn_set_strength1.Visible = True
            Else
                btn_set_strength1.Visible = False
            End If

        Next
        'moved From timer 1 logic 3/27/23
        If Operator_ID > 0 Then
            If current_enabled_state = False Or Btn_Defect_1.Enabled = False Then
                enable_disable(True)
            End If
        Else
            If current_enabled_state Or Btn_Defect_1.Enabled Then
                enable_disable(False)
            End If
        End If


    End Sub

    Private Sub operator_FTQ()
        Dim query As String
        Dim tab_selected As Integer = 0
        Try
            'SQLCon.ConnectionString = DBConnection
            'SQLCon.Open()

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
                Case TabPage9.Name
                    tab_selected = 8
            End Select

            query = "Exec Operator_Status_Totals " & Operator_ID & ", " & tab_selected
            Dim ds As DataSet = queryDB(query, "Operator_ftq", True)

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
            MsgBox("Error Getting Part Info from Database:2 " & ex.Message)
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

    Private Sub Btn_Defect_21_Click(sender As Object, e As EventArgs) Handles Btn_Defect_21.Click
        defect_color = Color_21.BackColor
        defect_number = defect_Types(20).Defect_Number
        Request_Size = defect_Types(20).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_21.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_22_Click(sender As Object, e As EventArgs) Handles Btn_Defect_22.Click
        defect_color = Color_22.BackColor
        defect_number = defect_Types(21).Defect_Number
        Request_Size = defect_Types(21).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_22.ForeColor = Color.Red
    End Sub


    Private Sub Btn_Defect_23_Click(sender As Object, e As EventArgs) Handles Btn_Defect_23.Click
        defect_color = Color_23.BackColor
        defect_number = defect_Types(22).Defect_Number
        Request_Size = defect_Types(22).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_23.ForeColor = Color.Red
    End Sub


    Private Sub Btn_Defect_24_Click(sender As Object, e As EventArgs) Handles Btn_Defect_24.Click
        defect_color = Color_24.BackColor
        defect_number = defect_Types(23).Defect_Number
        Request_Size = defect_Types(23).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_24.ForeColor = Color.Red
    End Sub

    Private Sub Btn_Defect_25_Click(sender As Object, e As EventArgs) Handles Btn_Defect_25.Click
        defect_color = Color_25.BackColor
        defect_number = defect_Types(24).Defect_Number
        Request_Size = defect_Types(24).Request_Size

        Call Clear_Fore_Colors()
        Btn_Defect_25.ForeColor = Color.Red
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
        If Not loading Then
            If Wetsand_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Wetsand_Already_Complete_Msg & " By " & Wetsander_Complete & " On " & Wetsander_Complete_Time)
                Chk_Wetsand_Good.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Wetsand_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Wetsand_Already_Complete_Msg & " By " & Wetsander_Complete & " On " & Wetsander_Complete_Time)
                Chk_Wetsand_TU.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Wetsand_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Wetsand_Already_Complete_Msg & " By " & Wetsander_Complete & " On " & Wetsander_Complete_Time)
                Chk_Wetsand_Reclear.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Wetsand_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Wetsand_Already_Complete_Msg & " By " & Wetsander_Complete & " On " & Wetsander_Complete_Time)
                Chk_Wetsand_Rework.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Buff_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Finesse_Already_Complete_Msg & " By " & Buffer_Complete & " On " & Buffer_Complete_Time)
                Chk_Buff_Good.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Buff_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Finesse_Already_Complete_Msg & " By " & Buffer_Complete & " On " & Buffer_Complete_Time)
                Chk_Buff_TU.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Buff_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Finesse_Already_Complete_Msg & " By " & Buffer_Complete & " On " & Buffer_Complete_Time)
                Chk_Buff_Reclear.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Buff_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Finesse_Already_Complete_Msg & " By " & Buffer_Complete & " On " & Buffer_Complete_Time)
                Chk_Buff_Rework.Checked = False
                Exit Sub
            End If
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

            defect_number = 0
            PictureBox1.Refresh()


            query = "Select RFID_Defect.X_Pos, RFID_Defect.Y_Pos, defect.color, Defect.Code from RFID_Defect "
            If training_station Then
                query = query & " inner join RFID.dbo.defect on RFID_Defect.Defect_ID = Defect.ID "
            Else
                query = query & " inner join defect on RFID_Defect.Defect_ID = Defect.ID "
            End If

            query = query & " where RFID_Defect.RFID_Defect_Inspection_id = " & RFID_Defect_Inspection_ID
            Dim ds As DataSet = queryDB(query, "RFID_Defect", True)

            g = PictureBox1.CreateGraphics

            For Each dr As DataRow In ds.Tables("RFID_Defect").Rows
                p.Color = Color.FromArgb(dr("color"))
                g.DrawEllipse(p, dr("X_Pos") - 3, dr("Y_Pos") - 3, 6, 6)
            Next


            ' Check if we want to generally show defects
            If Show_Paint_Defects Then
                query = "Exec Get_Past_Defects " & RFID_Defect_Inspection_ID & ", 1"
            Else
                query = "Exec Get_Past_Defects " & RFID_Defect_Inspection_ID & ", 0"
            End If

            Dim ds2 As DataSet = queryDB(query, "RFID_Old_Defect", True)

            For Each dr As DataRow In ds2.Tables("RFID_Old_Defect").Rows
                drawBrush.Color = Color.FromArgb(dr("color"))
                g.DrawString(dr("Code") & "", drawFont, drawBrush, dr("X_Pos") - 10, dr("Y_Pos") - 10)
            Next
            Me.Refresh()
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:3 " & ex.Message)
        End Try


    End Sub
    Private Sub Load_Defect_inspection(RFID_Defect_Inspection_ID As Integer)
        Dim query As String

        Wetsand_Complete = False
        Buff_Complete = False
        Inspection_Complete = False



        Try
            WriteEvent("Loading defects.", EventInfo)

            query = "Select * from RFID_Defect_Inspection where id = " & RFID_Defect_Inspection_ID

            Dim temp_date As String = ""
            Dim ds As DataSet = queryDB(query, "RFID_Defect_Inspection", True)

            query = "Exec Get_Past_Inspections " & RFID_Defect_Inspection_ID
            Dim ds2 As DataSet = queryDB(query, "Past_Inspections", True)

            For Each dr As DataRow In ds.Tables("RFID_Defect_Inspection").Rows

                WriteEvent("Updating button colors.", EventInfo)
                If IsDBNull(dr("Wetsand_Complete")) Then
                    Btn_Wet_Sand_Done.BackColor = Color.WhiteSmoke
                    Wetsand_Complete = False
                Else
                    WriteEvent("Wetsand Complete: " & dr("Wetsand_Complete").ToString, EventInfo)
                    If dr("Wetsand_Complete") = True Then

                        Btn_Wet_Sand_Done.BackColor = Color.DarkGray
                        Wetsand_Complete = True
                    Else
                        Btn_Wet_Sand_Done.BackColor = Color.WhiteSmoke
                        Wetsand_Complete = False
                    End If

                End If

                If IsDBNull(dr("Buff_Complete")) Then
                    Btn_Buff_Done.BackColor = Color.WhiteSmoke
                    Buff_Complete = False
                Else
                    WriteEvent("Buff Complete: " & dr("Buff_Complete").ToString, EventInfo)
                    If dr("Buff_Complete") = True Then
                        Btn_Buff_Done.BackColor = Color.DarkGray
                        Buff_Complete = True
                    Else
                        Btn_Buff_Done.BackColor = Color.WhiteSmoke
                        Buff_Complete = False
                    End If

                End If

                If IsDBNull(dr("Final_Inspection_Complete")) Then
                    Btn_Inspect_Done.BackColor = Color.WhiteSmoke
                    Inspection_Complete = False
                Else
                    WriteEvent("Final Inspection Complete: " & dr("Final_Inspection_Complete").ToString, EventInfo)
                    If dr("Final_Inspection_Complete") = True Then
                        Btn_Inspect_Done.BackColor = Color.DarkGray
                        Inspection_Complete = True
                    Else
                        Btn_Inspect_Done.BackColor = Color.WhiteSmoke
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

                Lbl_Scrap_Inspector.Text = get_operator(dr("Press_Inspector") & "")
                temp_date = dr("Press_Inspection_Time") & ""
                If IsDate(temp_date) Then
                    Lbl_Scrap_Date.Text = Format(temp_date, "short date")
                    Lbl_Scrap_Time.Text = Format(temp_date, "short time")
                Else
                    Lbl_Scrap_Date.Text = ""
                    Lbl_Scrap_Time.Text = ""
                End If
                If dr("Press_Inspection_Status") = 4 Then
                    Chk_Scrap_Rework.Checked = True
                ElseIf dr("Press_Inspection_Status") = 7 Then
                    Chk_Scrap_Scrap.Checked = True
                ElseIf dr("Press_Inspection_Status") <> 4 And dr("Press_Inspection_Status") <> 7 Then
                    Chk_Scrap_Rework.Checked = False
                    Chk_Scrap_Scrap.Checked = False
                End If
            Next
            Wetsander_Complete = ""
            Buffer_Complete = ""
            Inspector_Complete = ""


            For Each dr2 As DataRow In ds2.Tables("Past_Inspections").Rows
                'If Len(Lbl_Wetsand_Date.Text) = 0 Then
                Lbl_Wetsand_Inspector.Text = get_operator(dr2("Wet_Sander") & "")
                    Wetsander_Complete = Lbl_Wetsand_Inspector.Text
                    temp_date = dr2("Wet_Sand_Time") & ""
                    If IsDate(temp_date) Then
                        Wetsander_Complete_Time = temp_date
                        Lbl_Wetsand_Date.Text = Format(temp_date, "short date")
                        Lbl_Wetsand_Time.Text = Format(temp_date, "short time")
                    Else

                        Lbl_Wetsand_Date.Text = ""
                        Lbl_Wetsand_Time.Text = ""
                    End If

                'End If

                'If Len(Lbl_Buff_Date.Text) = 0 Then
                Lbl_Buff_Inspector.Text = get_operator(dr2("Buffer") & "")
                    Buffer_Complete = Lbl_Buff_Inspector.Text
                    temp_date = dr2("Buff_Time") & ""
                    If IsDate(temp_date) Then
                        Buffer_Complete_Time = temp_date
                        Lbl_Buff_Date.Text = Format(temp_date, "short date")
                        Lbl_Buff_Time.Text = Format(temp_date, "short time")
                    Else

                        Lbl_Buff_Date.Text = ""
                        Lbl_Buff_Time.Text = ""
                    End If

                'End If

                'If Len(Lbl_Final_Date.Text) = 0 Then
                Lbl_Final_Inspector.Text = get_operator(dr2("Final_Inspector") & "")
                    Inspector_Complete = Lbl_Final_Inspector.Text
                    temp_date = dr2("Inspection_Time") & ""
                    If IsDate(temp_date) Then
                        Inspector_Complete_Time = temp_date
                        Lbl_Final_Date.Text = Format(temp_date, "short date")
                        Lbl_Final_Time.Text = Format(temp_date, "short time")
                    Else

                        Lbl_Final_Date.Text = ""
                        Lbl_Final_Time.Text = ""
                    End If

                'End If
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
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:4 " & ex.Message)
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

            Lbl_Scrap_Inspector.Text = ""
            Lbl_Scrap_Date.Text = ""
            Lbl_Scrap_Time.Text = ""
            Chk_Scrap_Rework.Checked = False
            Chk_Scrap_Scrap.Checked = False

        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:5 " & ex.Message)
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
            queryDB(query, "temp", True)

        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:6 " & ex.Message)
        End Try

    End Sub

    Private Sub New_Revision(New_RFID As String)
        Dim query As String

        If Len(New_RFID) <= 0 Then
            Exit Sub
        End If
        Try
            query = "Exec Add_Revision '" & New_RFID & "'"
            queryDB(query, "temp", True)

        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:7 " & ex.Message)
        End Try

    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'lbl_Changing_Parts.Visible = False
        lbl_Changing_Operators.Visible = False
        Timer2.Enabled = False
        If lbl_Changing_Parts.Visible = True Then
            lbl_Changing_Parts.Visible = False

            Txt_Position.Text = Carrier_Position
            Part_Position_RFID = Current_RFID
            If Require_Carrier_Position > 0 Then
                Txt_Position.Visible = True
                Lbl_Position.Visible = True
            Else
                Txt_Position.Visible = False
                Lbl_Position.Visible = False
            End If
            If Me.Tab_Control.TabPages(0).Text <> "Press" Then
                If Require_Carrier_Position > 0 And Len(Carrier_Position) < 1 And Part_Pos_Form_Open = False Then
                    Part_Type_Positions = Require_Carrier_Position
                    'Timer1.Enabled = False
                    Part_Pos_Form_Open = True
                    Part_Position_Form = New Part_Position
                    Part_Position_Form.ShowDialog()
                End If
            End If


        End If
    End Sub

    Private Sub Txt_RFID_TextChanged(sender As Object, e As EventArgs) Handles Txt_RFID.TextChanged
        Dim query As String
        If Txt_RFID.Text <> "" Then
            Try

                query = "Select ID from Part where rfid = '" & Txt_RFID.Text & "'"
                Dim ds As DataSet = queryDB(query, "Part", True)


                Part_ID = 0

                For Each dr As DataRow In ds.Tables("Part").Rows
                    Part_ID = dr("ID")

                Next


            Catch ex As Exception
                lbl_Comm_Fail.Visible = True
                MsgBox("Error Getting Part Info from Database:8 " & ex.Message)
            End Try

        End If

        Call New_Part()
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

        If (Defect_Tabs And 1) Then
            Chk_Online_Good.Visible = True
            Chk_Online_TU.Visible = True
            Chk_Online_Reclear.Visible = True
            Chk_Online_Rework.Visible = True
            Chk_Online_Spin.Visible = True
            Chk_Online_Pinstripe.Visible = True
        ElseIf (Defect_Tabs And 64) Then
            Chk_Pinstripe_Good.Visible = True
            Chk_Pinstripe_TU.Visible = True
            Chk_Pinstripe_Reclear.Visible = True
            Chk_Pinstripe_Rework.Visible = True
            Btn_Pinstripe_Done.Visible = True
            ' These should not be visible
            ' Chk_Pinstripe_Spin.Visible = True
            ' Chk_Pinstripe_Pinstripe.Visible = True
        End If

        btn_set_strength1.Visible = False
        TrackBar_strength.Visible = False
        lbl_low_strength.Visible = False
        btn_set_strength2.Visible = False
        lbl_high_strength.Visible = False
        lbl_strength_info.Visible = False
        lbl_strength_index.Visible = False

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
            'SQLCon.ConnectionString = DBConnection
            'SQLCon.Open()

            query = "Select top 1 * from defect_Screen_Translation where language = '" & Language & "'"
            Dim ds As DataSet = queryDB(query, "Translation", False)

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
                Label_Scrap_Inspector.Text = dr("inspector") & ""
                Label_Scrap_Time.Text = dr("Time") & ""
                Chk_Scrap_Rework.Text = dr("rework") & ""
                Chk_Scrap_Scrap.Text = dr("scrap") & ""
                Btn_Scrap_Done.Text = dr("done") & ""
                Btn_Get_Part.Text = dr("Get_Part") & ""
                Man_Entry_Msg = dr("Man_Entry_Msg") & ""
                Inspection_Already_Complete_Msg = dr("Inspection_Msg") & ""
                Wetsand_Already_Complete_Msg = dr("Wetsand_Msg") & ""
                Finesse_Already_Complete_Msg = dr("Finesse_Msg") & ""
                Select_Part_Type = dr("Select_Part_Type") & ""
                Man_Entry_Title = dr("Man_Entry_Title") & ""
                First_Four = dr("First_Four") & ""
                Last_Six = dr("Last_Six") & ""
                No_Readable_Code = dr("No_Readable_Code") & ""
                Accept_Exit = dr("Accept_Exit") & ""
                Clear_Exit = dr("Clear_Exit") & ""
                Accept = dr("Accept") & ""
                Exit_Button_Text = dr("Exit") & ""
                Six_Character_Msg = dr("Six_Character_Msg") & ""
                Part_Position_Title = dr("Part_Position_Title") & ""
                Part_Position_Msg = dr("Part_Position_Message") & ""
                Lbl_Position.Text = dr("Part_Position") & ""

                btn_set_strength1.Text = dr("Strength_Button") & ""
                btn_set_strength2.Text = dr("Strength_Button") & ""
                lbl_low_strength.Text = dr("Weak_Label") & ""
                lbl_high_strength.Text = dr("Strong_Label") & ""
                lbl_strength_info.Text = dr("Trackbar_Description") & ""



            Next
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:9 " & ex.Message)
        End Try


    End Sub


    Private Sub Chk_Final_Good_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Final_Good.CheckedChanged

        If Not loading Then
            If Inspection_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Inspection_Already_Complete_Msg & " By " & Inspector_Complete & " On " & Inspector_Complete_Time)
                Chk_Final_Good.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Inspection_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Inspection_Already_Complete_Msg & " By " & Inspector_Complete & " On " & Inspector_Complete_Time)
                Chk_Final_TU.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Inspection_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Inspection_Already_Complete_Msg & " By " & Inspector_Complete & " On " & Inspector_Complete_Time)
                Chk_Final_Reclear.Checked = False
                Exit Sub
            End If
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
        If Not loading Then
            If Inspection_Complete = True And Tab_Control.TabPages.Count < 4 Then
                MsgBox(Inspection_Already_Complete_Msg & " By " & Inspector_Complete & " On " & Inspector_Complete_Time)
                Chk_Final_Rework.Checked = False
                Exit Sub
            End If
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

    Private Sub Chk_Scrap_Rework_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Scrap_Rework.CheckedChanged
        If Chk_Scrap_Rework.Checked Then
            Chk_Scrap_Scrap.Checked = False
        End If
        If Chk_Scrap_Scrap.Checked = False Then
            Call Update_Checked(9, IIf(Chk_Scrap_Rework.Checked, 4, 0))
        End If
        If Chk_Scrap_Rework.Checked Then
            Chk_Scrap_Rework.BackColor = Color.DarkGray
        Else
            Chk_Scrap_Rework.BackColor = Color.WhiteSmoke
        End If

    End Sub


    Private Sub Chk_Scrap_Scrap_CheckedChanged(sender As Object, e As EventArgs) Handles Chk_Scrap_Scrap.CheckedChanged
        If Chk_Scrap_Scrap.Checked Then
            Chk_Scrap_Rework.Checked = False
        End If
        If Chk_Scrap_Rework.Checked = False Then
            Call Update_Checked(9, IIf(Chk_Scrap_Scrap.Checked, 7, 0))
        End If
        If Chk_Scrap_Scrap.Checked Then
            Chk_Scrap_Scrap.BackColor = Color.DarkGray
        Else
            Chk_Scrap_Scrap.BackColor = Color.WhiteSmoke
        End If


    End Sub

    Private Sub Clear_Data()
        Timer1.Interval = 2000

        loading = True
        Call Clear_Part()
        Call Clear_Fore_Colors()
        Call Clear_Defect_inspection()
        PictureBox1.Image = Nothing
        PictureBox1.Update()
        loading = False
    End Sub

    Private Sub Clear_Part()
        Dim counter As Integer = 0


        PictureBox1.Image = Nothing
        PictureBox1.Update()


        Txt_RFID.Text = ""
        Txt_Part_Type.Text = ""
        Txt_Color.Text = ""

        For counter = 1 To 25
            Call Invisible(Controls("Btn_Defect_" & counter), Controls("Color_" & counter))
        Next

        RFID_Defect_Inspection_ID = 0
        defect_number = 0
        PictureBox1.Refresh()
        Txt_Revision.Text = ""

    End Sub
    Private Sub Btn_Wet_Sand_Done_Click(sender As Object, e As EventArgs) Handles Btn_Wet_Sand_Done.Click

        If Not loading Then
            If Chk_Wetsand_TU.Checked = True Or Chk_Wetsand_Good.Checked = True Or Chk_Wetsand_Reclear.Checked = True Or Chk_Wetsand_Rework.Checked = True Then
                If Wetsand_Complete = True And Tab_Control.TabPages.Count < 4 Then
                    MsgBox(Wetsand_Already_Complete_Msg & " By " & Wetsander_Complete & " On " & Wetsander_Complete_Time)
                    Exit Sub
                End If
            End If

            If Wetsand_Complete Then
                Wetsand_Complete = False
                Btn_Wet_Sand_Done.BackColor = Color.WhiteSmoke
                Call Update_Checked(2, 102)
            Else
                Wetsand_Complete = True
                Btn_Wet_Sand_Done.BackColor = Color.DarkGray
                Call Update_Checked(2, 99)
            End If


            Get_Rates(True)


        End If


        'Call Clear_Data()
    End Sub

    Private Sub Btn_Buff_Done_Click(sender As Object, e As EventArgs) Handles Btn_Buff_Done.Click

        If Not loading Then
            If Chk_Buff_Rework.Checked = True Or Chk_Buff_Good.Checked = True Or Chk_Buff_TU.Checked = True Or Chk_Buff_Reclear.Checked = True Then
                If Buff_Complete = True And Tab_Control.TabPages.Count < 4 Then
                    MsgBox(Finesse_Already_Complete_Msg & " By " & Buffer_Complete & " On " & Buffer_Complete_Time)
                    Exit Sub
                End If
            End If

            If Buff_Complete Then
                Buff_Complete = False
                Btn_Buff_Done.BackColor = Color.WhiteSmoke
                Call Update_Checked(3, 104)
            Else
                Buff_Complete = True
                Btn_Buff_Done.BackColor = Color.DarkGray
                Call Update_Checked(3, 99)
            End If


            Get_Rates(True)


        End If

        'Call Clear_Data()

    End Sub

    Private Sub Btn_Inspect_Done_Click(sender As Object, e As EventArgs) Handles Btn_Inspect_Done.Click

        If Not loading Then
            If Chk_Final_TU.Checked = True Or Chk_Final_Good.Checked = True Or Chk_Final_Reclear.Checked = True Or Chk_Final_Rework.Checked = True Then
                If Inspection_Complete = True And Tab_Control.TabPages.Count < 4 Then
                    MsgBox(Inspection_Already_Complete_Msg & " By " & Inspector_Complete & " On " & Inspector_Complete_Time)
                    Exit Sub
                End If
            End If

            If Inspection_Complete Then
                Inspection_Complete = False
                Btn_Inspect_Done.BackColor = Color.WhiteSmoke
                Call Update_Checked(4, 104)
            Else
                Inspection_Complete = True
                Btn_Inspect_Done.BackColor = Color.DarkGray
                Call Update_Checked(4, 99)
            End If


            Get_Rates(True)

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

    Private Sub Btn_Scrap_Done_Click(sender As Object, e As EventArgs) Handles Btn_Scrap_Done.Click
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
        'operator_FTQ()
    End Sub

    Private Sub Btn_Logout_Click(sender As Object, e As EventArgs) Handles Btn_Logout.Click

        If (Defect_Tabs And 1) Then
            Chk_Online_Good.Visible = True
            Chk_Online_TU.Visible = True
            Chk_Online_Reclear.Visible = True
            Chk_Online_Rework.Visible = True
            Chk_Online_Spin.Visible = True
            Chk_Online_Pinstripe.Visible = True
        ElseIf (Defect_Tabs And 64) Then
            Chk_Pinstripe_Good.Visible = True
            Chk_Pinstripe_TU.Visible = True
            Chk_Pinstripe_Reclear.Visible = True
            Chk_Pinstripe_Rework.Visible = True
            Btn_Pinstripe_Done.Visible = True
            ' These should not be visible
            ' Chk_Pinstripe_Spin.Visible = True
            ' Chk_Pinstripe_Pinstripe.Visible = True
        End If


        btn_set_strength1.Visible = False
        TrackBar_strength.Visible = False
        lbl_low_strength.Visible = False
        btn_set_strength2.Visible = False
        lbl_high_strength.Visible = False
        lbl_strength_info.Visible = False
        lbl_strength_index.Visible = False


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
        Btn_Defect_21.Enabled = status
        Btn_Defect_22.Enabled = status
        Btn_Defect_23.Enabled = status
        Btn_Defect_24.Enabled = status
        Btn_Defect_25.Enabled = status

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
        Chk_Scrap_Rework.Enabled = status
        Chk_Scrap_Scrap.Enabled = status
        Btn_Scrap_Done.Enabled = status

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

            query = "Select Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish, isnull(Final_Color.Id,0) as Color_ID "
            If training_station Then
                query = query & " from RFID_t.dbo.Part left join final_color on part.color = final_color.id where part.id = " & Part_ID
            Else
                query = query & " from Part left join final_color on part.color = final_color.id where part.id = " & Part_ID
            End If

            Dim ds As DataSet = queryDB(query, "Part", False)

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
            MsgBox("Error Getting Part Info from Database:10 " & ex.Message)
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
            queryDB(query, "temp", True)

            g = PictureBox1.CreateGraphics
            g.DrawEllipse(p, save_x - 3, save_y - 3, 6, 6)
        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database:11 " & ex.Message)
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
                queryDB(query, "temp", True)

            Catch ex As Exception
                lbl_Comm_Fail.Visible = True
                MsgBox("Error Getting Part Info from Database:12 " & ex.Message)
            End Try
        Else
            Try
                query = "Insert into Station_Users(Operator, Start_Time, Station) values (" & Operator_ID & ", Getdate() ," & Station_ID & ")"
                queryDB(query, "temp", True)

            Catch ex As Exception
                lbl_Comm_Fail.Visible = True
                MsgBox("Error Getting Part Info from Database:13 " & ex.Message)
            End Try
        End If


    End Sub

    Private Sub Chk_Press_Rework_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Chk_Press_Scrap_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Overrides Sub DefWndProc(ByRef m As System.Windows.Forms.Message)
        'This overrides the windows messaging processing
        If m.Msg = MessageId Then 'If we found our message then activate
            ' Set the WindowState to normal if the form is minimized.
            If (Me.WindowState = FormWindowState.Minimized) Then
                Me.Show()
                Me.WindowState = FormWindowState.Normal
            End If

            ' Activate the form.
            Me.Activate()
            Me.Focus()

        Else 'Let the normal windows messaging process it.
            MyBase.DefWndProc(m)
        End If


    End Sub

    Private Sub checkprevious()
        'Check for previous instance of this app
        m_uniqueIdentifier = Application.ExecutablePath.Replace("\", "_")
        m_Mutex = New System.Threading.Mutex(False, m_uniqueIdentifier)
        'First register the windows message
        MessageId = RegisterWindowMessage(m_uniqueIdentifier)
        If m_Mutex.WaitOne(1, True) Then
            'we are the first instance don't need to do anything

        Else
            'Cause the current form to show
            'Now brodcast a message to cause the first instance to show up
            Dim BSMRecipients As Int32 = BSM_APPLICATIONS 'Only go to applications

            Dim tmpuint32 As Int32 = 0
            tmpuint32 = tmpuint32 Or BSF_IGNORECURRENTTASK 'Ignore current app
            tmpuint32 = tmpuint32 Or BSF_POSTMESSAGE 'Post the windows message
            Dim ret As Integer
            ret = BroadcastSystemMessage(tmpuint32, BSMRecipients, MessageId, 0, 0)
            'A differnt instance already exists exit now.
            Application.Exit()
        End If
    End Sub

    Public Sub Btn_Get_Part_Click(sender As Object, e As EventArgs) Handles Btn_Get_Part.Click

        'Timer1.Interval = 1500
        'Manual_Refresh_Request = True
        Refresh_Station_Data()


    End Sub

    Private Sub Defect_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Manual_Defect_Refresh = True Then
            'Timer1.Interval = 1500
            Refresh_Station_Data()
        End If
        If Auto_Scan_Refresh = True Then
            Timer1.Interval = 2000
        End If



    End Sub

    Public Sub Refresh_Station_Data()
        Dim First_RFID As String = ""
        Dim Found_Existing As Boolean = False
        Dim msgbox_response As Integer


        Manual_Refresh_Request = False
        Manual_Defect_Refresh = False
        Carrier_Position = ""
        Require_Carrier_Position = 0
        Try

            Dim ds As DataSet = queryDB("Execute Find_Stations_Parts " & PLC_Station & ", " & Operator_ID, "Station", True)

            For Each dr As DataRow In ds.Tables("Station").Rows
                If Len(First_RFID) < 1 Then
                    First_RFID = dr("RFID") & ""
                End If
                If Current_RFID = dr("RFID") & "" Then
                    Found_Existing = True
                End If
                If IsDBNull(dr("Require_Carrier_Position")) Then
                    Require_Carrier_Position = 0
                Else
                    Require_Carrier_Position = dr("Require_Carrier_Position") & ""
                End If

                If IsDBNull(dr("Carrier_Position")) Then
                    Carrier_Position = ""
                Else
                    Carrier_Position = dr("Carrier_Position") & ""
                    Txt_Position.Text = Carrier_Position
                End If

            Next


            If Len(First_RFID) > 0 Then
                'If PLC_Station > 1 And PLC_Station <> 210 And PLC_Station <> 211 And PLC_Station <> 212 Then
                '    If Operator_ID > 0 Then
                '        Timer1.Interval = 1500
                '    Else
                '        Timer1.Interval = 120000
                '    End If
                '    Manual_Refresh_Request = False

                'End If
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
                'If Manual_Refresh_Request = True Or Manual_Defect_Refresh = True Then

                'Timer1.Interval = 120000
                'Manual_Refresh_Request = False
                'Manual_Defect_Refresh = False
                'If Counter > 5 Then
                '    Counter = 0
                '    Manual_Refresh_Request = False
                If Auto_Scan_Refresh = False Then
                    msgbox_response = MsgBox(Man_Entry_Msg, vbYesNo)
                    If msgbox_response = 6 Then
                        'Timer1.Enabled = False
                        Defect_RFID_Manual_Select_Form = New Defect_RFID_Manual_Select
                        Defect_RFID_Manual_Select_Form.ShowDialog()

                    End If
                End If
                'Timer1.Interval = 50
                'End If
                'If PLC_Station > 1 And PLC_Station <> 210 And PLC_Station <> 211 And PLC_Station <> 212 And Operator_ID = 0 Then
                '    Timer1.Interval = 1500
                'Else
                '    Timer1.Interval = 15000 '2000
                'End If

            End If


            '    Counter += 1
            'End If

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True

            MsgBox("Error Getting Part Info from Database:1 " & Ex.Message)
        End Try

        'Txt_Position.Text = Carrier_Position
        'Part_Position_RFID = First_RFID
        'If Require_Carrier_Position > 0 Then
        '    Txt_Position.Visible = True
        '    Lbl_Position.Visible = True
        'Else
        '    Txt_Position.Visible = False
        '    Lbl_Position.Visible = False
        'End If

        'If Require_Carrier_Position > 0 And Len(Carrier_Position) < 1 And Part_Pos_Form_Open = False Then
        '    Part_Type_Positions = Require_Carrier_Position
        '    Timer1.Enabled = False
        '    Part_Pos_Form_Open = True
        '    Part_Position_Form = New Part_Position
        '    Part_Position_Form.ShowDialog()
        'End If
        'End If
        'End If
        If Manual_Defect_Refresh = True Then

            'Manual_Refresh_Request = False
            Manual_Defect_Refresh = False
        End If
        If Operator_ID <> 0 Then
            Call operator_FTQ()
        End If


    End Sub

    Private Sub Tab_Control_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab_Control.SelectedIndexChanged

        Get_Rates(False)



    End Sub

    Private Sub Get_Rates(Display_Msg As Boolean)
        If Part_ID <= 0 Then
            Exit Sub
        End If

        Dim query As String
        Dim counter As Integer = 0
        Dim counter2 As Integer = 0
        Dim Message_Box_Text As String = ""
        Dim Records As Boolean = False



        Try

            Message_Box_Text = "Current Rates are " & vbCrLf

            query = "Exec Operator_Status_by_Operator " & Operator_ID

            Lbl_Rate.Text = "0"
            Op_Rate_String = ""
            Op_Rate = 0

            Dim ds As DataSet = queryDB(query, "Op_Rate", True)

            For Each dr As DataRow In ds.Tables("Op_Rate").Rows
                Message_Box_Text = Message_Box_Text & dr("inspection") & "  " & dr("group_desc") & "  " & dr("rate") & "  " & vbCrLf
                Records = True
                If Part_Type_Group = 12 Then
                    If Part_Type_English = dr("group_desc") Then
                        If Tab_Control.SelectedTab.Name = "TabPage2" And dr("inspection") = "Wet Sand" Then
                            Op_Rate = dr("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage3" And dr("inspection") = "Finesse" Then
                            Op_Rate = dr("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage4" And dr("inspection") = "Inspect" Then
                            Op_Rate = dr("Rate")
                        End If
                    End If
                Else
                    If Part_Type_Group_Desc = dr("group_desc") Then
                        If Tab_Control.SelectedTab.Name = "TabPage2" And dr("inspection") = "Wet Sand" Then
                            Op_Rate = dr("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage3" And dr("inspection") = "Finesse" Then
                            Op_Rate = dr("Rate")
                        End If
                        If Tab_Control.SelectedTab.Name = "TabPage4" And dr("inspection") = "Inspect" Then
                            Op_Rate = dr("Rate")
                        End If
                    End If
                End If
            Next
            Op_Rate_String = Op_Rate
            Lbl_Rate.Text = Op_Rate_String
            If Op_Rate > 0 Then
                Lbl_Rate.ForeColor = Color.Green
            ElseIf Op_Rate = 0 Then
                Lbl_Rate.ForeColor = Color.Black
            ElseIf Op_Rate < 0 Then
                Lbl_Rate.ForeColor = Color.Red
            End If
            If Display_Msg = True And Records = True Then
                MsgBox(Message_Box_Text)
            End If


        Catch ex As Exception
            lbl_Comm_Fail.Visible = True
            MsgBox("Error Getting Part Info from Database " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click1(sender As Object, e As EventArgs) Handles btn_set_strength1.Click

        ' button2 click:


        btn_set_strength1.Visible = False

        If (Defect_Tabs And 1) Then
            Chk_Online_Good.Visible = False
            Chk_Online_TU.Visible = False
            Chk_Online_Reclear.Visible = False
            Chk_Online_Rework.Visible = False
            Chk_Online_Spin.Visible = False
            Chk_Online_Pinstripe.Visible = False
        ElseIf (Defect_Tabs And 64) Then
            Chk_Pinstripe_Good.Visible = False
            Chk_Pinstripe_TU.Visible = False
            Chk_Pinstripe_Reclear.Visible = False
            Chk_Pinstripe_Rework.Visible = False
            Btn_Pinstripe_Done.Visible = False
            ' I don't believe these are visible anyways
            'Chk_Pinstripe_Spin.Visible = False
            'Chk_Pinstripe_Pinstripe.Visible = False
        End If



        ' read strength value

        If Not System.IO.File.Exists(strength_path) Then
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(strength_path, False)
            file.WriteLine(TrackBar_strength.Minimum.ToString)
            file.Close()
        End If

        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(strength_path)
        Dim strength As String = fileReader
        WriteEvent("text file reads as " & fileReader, EventInfo)

        Dim temp_val As Int32 = Convert.ToInt32(strength)
        If (temp_val >= TrackBar_strength.Minimum) And (temp_val <= TrackBar_strength.Maximum) Then
            TrackBar_strength.Value = temp_val
        ElseIf temp_val < TrackBar_strength.Minimum Then
            TrackBar_strength.Value = TrackBar_strength.Minimum
        ElseIf temp_val > TrackBar_strength.Maximum Then
            TrackBar_strength.Value = TrackBar_strength.Maximum
        Else
            TrackBar_strength.Value = TrackBar_strength.Maximum
        End If
        TrackBar_strength.Value = Convert.ToInt32(strength)


        lbl_low_strength.Visible = True
        lbl_high_strength.Visible = True
        lbl_strength_info.Visible = True
        TrackBar_strength.Visible = True
        btn_set_strength2.Visible = True
        lbl_strength_index.Visible = True



        WriteEvent("User initiated Set Strength", EventInfo)



    End Sub

    Private Sub trackbar_mousedown(sender As Object, e As MouseEventArgs) Handles TrackBar_strength.MouseDown ' acLeftButton As Integer, shift As Integer, X As Single, Y As Single)

        TrackBar_strength.Value = Convert.ToInt32(TrackBar_strength.Minimum + ((e.X / TrackBar_strength.Width) * (TrackBar_strength.Maximum - TrackBar_strength.Minimum)))
    End Sub
    Private Sub Button2_Click1(sender As Object, e As EventArgs) Handles btn_set_strength2.Click


        btn_set_strength1.Visible = True

        If (Defect_Tabs And 1) Then
            Chk_Online_Good.Visible = True
            Chk_Online_TU.Visible = True
            Chk_Online_Reclear.Visible = True
            Chk_Online_Rework.Visible = True
            Chk_Online_Spin.Visible = True
            Chk_Online_Pinstripe.Visible = True
        ElseIf (Defect_Tabs And 64) Then
            Chk_Pinstripe_Good.Visible = True
            Chk_Pinstripe_TU.Visible = True
            Chk_Pinstripe_Reclear.Visible = True
            Chk_Pinstripe_Rework.Visible = True
            Btn_Pinstripe_Done.Visible = True
            ' These should not be visible
            ' Chk_Pinstripe_Spin.Visible = True
            ' Chk_Pinstripe_Pinstripe.Visible = True
        End If


        TrackBar_strength.Visible = False
        lbl_low_strength.Visible = False
        btn_set_strength2.Visible = False
        lbl_high_strength.Visible = False
        lbl_strength_info.Visible = False
        lbl_strength_index.Visible = False

        ' strength = TrackBar1.Value.ToString
        Dim temp_strength As String = TrackBar_strength.Value.ToString
        WriteEvent("User set strength to " & temp_strength, EventInfo)

        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(strength_path, False)
        file.WriteLine(temp_strength)
        file.Close()



    End Sub


    ''' <summary>
    ''' Queries the database and returns the response as a DataSet
    ''' </summary>
    ''' <param name="query">String to query the database</param>
    ''' <param name="table">Name of DataSet.Table data is returned to</param>
    ''' <param name="checkTraining">Determines which database should be queried. False will always use the main "RFID" database. True will either use the "RFID" or "RFID_t" database if it is a standard station or a training station, respectively.</param>
    ''' <returns></returns>
    Public Function queryDB(query As String, table As String, checkTraining As Boolean) As DataSet

        Dim tempDataSet As New DataSet

        Try

            Using newCon As SqlConnection = New SqlConnection(IIf(training_station And checkTraining, DBConnection_t, DBConnection))

                newCon.Open()
                Dim tempAdapter As New SqlDataAdapter(query, newCon)
                tempAdapter.SelectCommand.CommandTimeout = SQL_Timeout
                tempAdapter.Fill(tempDataSet, table)
                newCon.Close()

            End Using

        Catch ex As Exception

            Dim msg As String = "Error communicating with database."
            Dim querystr As String = "Query: " & query
            Dim tablename As String = "Table: " & table

            MsgBox(msg & vbCrLf & query & vbCrLf & tablename & vbCrLf & vbCrLf & ex.Message)

        End Try

        Return tempDataSet

    End Function

End Class
