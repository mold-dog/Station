Imports System.Data
Imports System.Data.SqlClient

Public Class Defect_by_Part_Type

    Dim ID_Array() As Integer
    Dim Defect_ID(26) As Int32
    Dim Color_Array() As Int32
    Dim g1 As System.Drawing.Graphics
    Dim Carrier_Positions As Integer


    Private Sub Load_Part_Type_Data()

        Dim counter As Integer = 1
        Dim counter2 As Integer = 1
        If Cmb_Description.SelectedIndex < 0 Then
            Exit Sub
        End If

        Dim query As String

        Try


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select Image_Name, Require_Carrier_Position from part_type where id = " & ID_Array(Cmb_Description.SelectedIndex)

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                If Len(dr("Image_Name") & "") > 0 Then
                    PictureBox1.Image = Image.FromFile(Image_Share & dr("Image_Name"), False)
                Else
                    PictureBox1.Image = Nothing
                End If

                If Not IsDBNull(dr("Require_Carrier_Position")) Then
                    If dr("Require_Carrier_Position") > 0 Then
                        Carrier_Positions = dr("Require_Carrier_Position")
                        Pnl_Part_Position.Visible = True
                    End If
                Else
                    Carrier_Positions = 0
                    Pnl_Part_Position.Visible = False
                End If

            Next



            query = "Select defect.id, defect.description, defect.spanish, defect.color, defect.code from defect "
            query = query & " inner join part_type_defects on defect.id = part_type_defects.Defect_ID"
            query = query & " where ((part_Type_Defects.part_Type_id = " & ID_Array(Cmb_Description.SelectedIndex) & ") Or (Part_Type_Defects.Part_Type_Id = 109)) order by part_Type_Defects.Order_Number"



            Dim da2 As New SqlDataAdapter(query, SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Defect")
            SQLCon.Close()

            For Each dr2 As DataRow In ds2.Tables("Defect").Rows
                Call Button_Text(Controls("Btn_Defect_" & counter), dr2("Code") & " - " & dr2("Description"))
                Call Button_Color(Controls("Color_" & counter), Val(dr2("Color") & ""))
                Defect_ID(counter) = dr2("id")
                Controls("Color_" & counter).BringToFront()
                counter += 1
                If counter >= 25 Then
                    Exit For
                End If
            Next
            For counter2 = counter To 25
                Call Invisible(Controls("Btn_Defect_" & counter2), Controls("Color_" & counter2))
            Next


            Dim da3 As New SqlDataAdapter("Select * From Carrier_Part_Positions where ID = " & Carrier_Positions, SQLCon)
            da3.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds3 As New DataSet
            da3.Fill(ds3, "Positions")
            SQLCon.Close()
            For Each dr As DataRow In ds3.Tables("Positions").Rows
                If Not IsDBNull(dr("Pos1")) Then
                    Cbx_Pos1.Visible = True
                    Cbx_Pos1.Text = dr("Pos1")
                Else
                    Cbx_Pos1.Visible = False
                    Cbx_Pos1.Text = ""
                    Cbx_Pos1.Checked = False
                End If
                If Not IsDBNull(dr("Pos2")) Then
                    Cbx_Pos2.Visible = True
                    Cbx_Pos2.Text = dr("Pos2")
                Else
                    Cbx_Pos2.Visible = False
                    Cbx_Pos2.Text = ""
                    Cbx_Pos2.Checked = False
                End If
                If Not IsDBNull(dr("Pos3")) Then
                    Cbx_Pos3.Visible = True
                    Cbx_Pos3.Text = dr("Pos3")
                Else
                    Cbx_Pos3.Visible = False
                    Cbx_Pos3.Text = ""
                    Cbx_Pos3.Checked = False
                End If
                If Not IsDBNull(dr("Pos4")) Then
                    Cbx_Pos4.Visible = True
                    Cbx_Pos4.Text = dr("Pos4")
                Else
                    Cbx_Pos4.Visible = False
                    Cbx_Pos4.Text = ""
                    Cbx_Pos4.Checked = False
                End If
                If Not IsDBNull(dr("Pos5")) Then
                    Cbx_Pos5.Visible = True
                    Cbx_Pos5.Text = dr("Pos5")
                Else
                    Cbx_Pos5.Visible = False
                    Cbx_Pos5.Text = ""
                    Cbx_Pos5.Checked = False
                End If
                If Not IsDBNull(dr("Pos6")) Then
                    Cbx_Pos6.Visible = True
                    Cbx_Pos6.Text = dr("Pos6")
                Else
                    Cbx_Pos6.Visible = False
                    Cbx_Pos6.Text = ""
                    Cbx_Pos6.Checked = False
                End If
                If Not IsDBNull(dr("Pos7")) Then
                    Cbx_Pos7.Visible = True
                    Cbx_Pos7.Text = dr("Pos7")
                Else
                    Cbx_Pos7.Visible = False
                    Cbx_Pos7.Text = ""
                    Cbx_Pos7.Checked = False
                End If
                If Not IsDBNull(dr("Pos8")) Then
                    Cbx_Pos8.Visible = True
                    Cbx_Pos8.Text = dr("Pos8")
                Else
                    Cbx_Pos8.Visible = False
                    Cbx_Pos8.Text = ""
                    Cbx_Pos8.Checked = False
                End If
                If Not IsDBNull(dr("Pos9")) Then
                    Cbx_Pos9.Visible = True
                    Cbx_Pos9.Text = dr("Pos9")
                Else
                    Cbx_Pos9.Visible = False
                    Cbx_Pos9.Text = ""
                    Cbx_Pos9.Checked = False
                End If
                If Not IsDBNull(dr("Pos10")) Then
                    Cbx_Pos10.Visible = True
                    Cbx_Pos10.Text = dr("Pos10")
                Else
                    Cbx_Pos10.Visible = False
                    Cbx_Pos10.Text = ""
                    Cbx_Pos10.Checked = False
                End If
                If Not IsDBNull(dr("Pos11")) Then
                    Cbx_Pos11.Visible = True
                    Cbx_Pos11.Text = dr("Pos11")
                Else
                    Cbx_Pos11.Visible = False
                    Cbx_Pos11.Text = ""
                    Cbx_Pos11.Checked = False
                End If
                If Not IsDBNull(dr("Pos12")) Then
                    Cbx_Pos12.Visible = True
                    Cbx_Pos12.Text = dr("Pos12")
                Else
                    Cbx_Pos12.Visible = False
                    Cbx_Pos12.Text = ""
                    Cbx_Pos12.Checked = False
                End If
                If Not IsDBNull(dr("Pos13")) Then
                    Cbx_Pos13.Visible = True
                    Cbx_Pos13.Text = dr("Pos13")
                Else
                    Cbx_Pos13.Visible = False
                    Cbx_Pos13.Text = ""
                    Cbx_Pos13.Checked = False
                End If
                If Not IsDBNull(dr("Pos14")) Then
                    Cbx_Pos14.Visible = True
                    Cbx_Pos14.Text = dr("Pos14")
                Else
                    Cbx_Pos14.Visible = False
                    Cbx_Pos14.Text = ""
                    Cbx_Pos14.Checked = False
                End If

            Next

            PictureBox1.Refresh()

        Catch ex As Exception
            MsgBox("Failed to get part type data from database.", ex.Message)
        End Try

    End Sub
    Private Sub Invisible(ByRef Set_Button As CheckBox, ByRef Set_color As Label)
        Set_Button.Visible = False
        Set_color.Visible = False
    End Sub

    Private Sub Button_Text(ByRef Set_Button As CheckBox, ByVal Set_Text As String)
        Set_Button.Text = Set_Text
        Set_Button.Visible = True
        Set_Button.Checked = False
    End Sub

    Private Sub Button_Color(ByRef Set_Button As Label, ByVal Set_Color As Integer)
        Set_Button.BackColor = Color.FromArgb(Set_Color)
        Set_Button.Visible = True
    End Sub

    Private Function defect_selected(Set_Button As CheckBox) As Boolean
        If Set_Button.Visible And Set_Button.Checked Then
            defect_selected = True
        Else
            defect_selected = False
        End If

    End Function

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Description.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Description.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Info from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Defect_by_Part_Type_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Start_Time As DateTime
        Dim End_Time As DateTime

        PictureBox1.Image = Nothing

        Call Load_Combo()
        Call Load_Color_Combo()



        Start_Time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time


    End Sub


    Private Sub New_Part_Type()
        Call Load_Part_Type_Data()
    End Sub






    Private Sub Load_Defects()
        Dim query As String
        Dim p As New System.Drawing.Pen(Color.Black, 6)
        Dim g As System.Drawing.Graphics
        Dim drawFont As New Font("Arial", 16)
        Dim drawBrush As New SolidBrush(Color.Black)
        Dim defect_list As String = ""
        Dim first_defect As Boolean = True
        Dim counter As Integer = 1
        Dim inspection_type_list As String = ""
        Dim inspection_type_selected As Boolean = False
        Dim Part_Position_Query As String = ""

        Try
            If Cmb_Description.SelectedIndex < 0 Then
                MsgBox("Please select a valid part type.")
                Exit Sub
            End If
            If PictureBox1.Image Is Nothing Then
                MsgBox("Please select a part type with an image.")
                Exit Sub
            End If
            For counter = 1 To 25
                If defect_selected(Controls("Btn_Defect_" & counter)) Then
                    If first_defect Then
                        first_defect = False
                        defect_list = Defect_ID(counter) & ""
                    Else
                        defect_list = defect_list & ", " & Defect_ID(counter)
                    End If
                End If
            Next

            If Len(defect_list) < 1 Then
                MsgBox("Please select at least one defect to display.")
                Exit Sub
            End If

            If Chk_Online.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Online_Inspection_Status > 0"
            End If
            If Chk_Wetsand.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Wet_sand_Status > 0"
            End If
            If Chk_Finesse.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Buff_Status > 0"
            End If
            If Chk_Final.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Final_Inspection_Status > 0"
            End If
            If Chk_Supervisor.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Supervisor_Inspection_Status > 0"
            End If
            If Chk_Decal.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Decal_Inspection_Status > 0"
            End If
            If Chk_Pinstripe.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Pinstripe_Inspection_Status > 0"
            End If
            If Chk_Prep.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Prep_Inspection_Status > 0"
            End If

            If inspection_type_selected = False Then
                MsgBox("Please select at least one inspection type.")
                Exit Sub
            End If

            If Cbx_Pos1.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos1.Text
            End If
            If Cbx_Pos2.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos2.Text
            End If
            If Cbx_Pos3.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos3.Text
            End If
            If Cbx_Pos4.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos4.Text
            End If
            If Cbx_Pos5.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos5.Text
            End If
            If Cbx_Pos6.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos6.Text
            End If
            If Cbx_Pos7.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos7.Text
            End If
            If Cbx_Pos8.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos8.Text
            End If
            If Cbx_Pos9.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos9.Text
            End If
            If Cbx_Pos10.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos10.Text
            End If
            If Cbx_Pos11.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos11.Text
            End If
            If Cbx_Pos12.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos12.Text
            End If
            If Cbx_Pos13.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos13.Text
            End If
            If Cbx_Pos14.Checked = True Then
                If Part_Position_Query = "" Then
                    Part_Position_Query = " And RFID_Defect_Inspection.Carrier_Position in ("
                Else
                    Part_Position_Query = Part_Position_Query & ", "
                End If
                Part_Position_Query = Part_Position_Query & Cbx_Pos14.Text
            End If
            If Part_Position_Query <> "" Then
                Part_Position_Query = Part_Position_Query & ")"
            End If


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()


            PictureBox1.Refresh()

            query = "Select RFID_Defect.X_Pos, RFID_Defect.Y_Pos, defect.Color, defect.code, isnull(Defect_Size.size,0) as Size, isnull(RFID_Defect.Distance,0) as Distance From (RFID_Defect inner Join defect On RFID_Defect.Defect_ID = defect.id) left join Defect_Size on RFID_Defect.size = Defect_Size.ID "
            query = query & "Where RFID_Defect.Log_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' And "
            query = query & "defect.id in (" & defect_list & ") And "
            query = query & "RFID_Defect_Inspection_ID in (select RFID_Defect_Inspection.id from RFID_Defect_Inspection inner join part on RFID_Defect_Inspection.Part_ID = part.id "
            query = query & "where part.Part_Type = " & ID_Array(Cmb_Description.SelectedIndex) & " and (part.color = " & Color_Array(Cmb_Color.SelectedIndex) & " or " & Color_Array(Cmb_Color.SelectedIndex) & " = 0)"
            If Part_Position_Query = "" Then
                query = query & " and (" & inspection_type_list & "))"
            Else
                query = query & " and ((" & inspection_type_list & "))" & Part_Position_Query & ")"
            End If


            Dim da2 As New SqlDataAdapter(query, SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "RFID_Old_Defect")
            SQLCon.Close()

            g = PictureBox1.CreateGraphics

            For Each dr As DataRow In ds2.Tables("RFID_Old_Defect").Rows
                drawBrush.Color = Color.FromArgb(dr("color"))
                If Chk_Show_Size.Checked And dr("Size") > 0 Then
                    g.DrawString(dr("Size") & "\" & dr("Distance"), drawFont, drawBrush, dr("X_Pos") - 10, dr("Y_Pos") - 10)
                Else
                    g.DrawString(dr("Code") & "", drawFont, drawBrush, dr("X_Pos") - 10, dr("Y_Pos") - 10)
                End If

            Next

        Catch ex As Exception
            MsgBox("Error getting defects from database: " & ex.Message)
        End Try


    End Sub

    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Description.SelectedIndexChanged
        Call Load_Part_Type_Data()
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Call Load_Defects()
    End Sub

    Sub Load_Color_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Color.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from final_color where getdate() between start_date and end_date order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Color")
            SQLCon.Close()
            ReDim Color_Array(0)
            Color_Array(counter) = 0
            Cmb_Color.Items.Add("All Colors")
            counter += 1
            For Each dr As DataRow In ds.Tables("Color").Rows
                Cmb_Color.Items.Add(dr("Description"))
                ReDim Preserve Color_Array(counter)
                Color_Array(counter) = dr("ID")
                counter += 1
            Next

            Cmb_Color.Text = "All Colors"


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_All_Click(sender As Object, e As EventArgs) Handles Btn_All.Click
        Call Change_all(True)

    End Sub

    Private Sub Change_all(Checked As Boolean)
        If Btn_Defect_1.Visible Then
            Btn_Defect_1.Checked = Checked
        End If
        If Btn_Defect_2.Visible Then
            Btn_Defect_2.Checked = Checked
        End If
        If Btn_Defect_3.Visible Then
            Btn_Defect_3.Checked = Checked
        End If
        If Btn_Defect_4.Visible Then
            Btn_Defect_4.Checked = Checked
        End If
        If Btn_Defect_5.Visible Then
            Btn_Defect_5.Checked = Checked
        End If
        If Btn_Defect_6.Visible Then
            Btn_Defect_6.Checked = Checked
        End If
        If Btn_Defect_7.Visible Then
            Btn_Defect_7.Checked = Checked
        End If
        If Btn_Defect_8.Visible Then
            Btn_Defect_8.Checked = Checked
        End If
        If Btn_Defect_9.Visible Then
            Btn_Defect_9.Checked = Checked
        End If
        If Btn_Defect_10.Visible Then
            Btn_Defect_10.Checked = Checked
        End If
        If Btn_Defect_11.Visible Then
            Btn_Defect_11.Checked = Checked
        End If
        If Btn_Defect_12.Visible Then
            Btn_Defect_12.Checked = Checked
        End If
        If Btn_Defect_13.Visible Then
            Btn_Defect_13.Checked = Checked
        End If
        If Btn_Defect_14.Visible Then
            Btn_Defect_14.Checked = Checked
        End If
        If Btn_Defect_15.Visible Then
            Btn_Defect_15.Checked = Checked
        End If
        If Btn_Defect_16.Visible Then
            Btn_Defect_16.Checked = Checked
        End If
        If Btn_Defect_17.Visible Then
            Btn_Defect_17.Checked = Checked
        End If
        If Btn_Defect_18.Visible Then
            Btn_Defect_18.Checked = Checked
        End If
        If Btn_Defect_19.Visible Then
            Btn_Defect_19.Checked = Checked
        End If
        If Btn_Defect_20.Visible Then
            Btn_Defect_20.Checked = Checked
        End If
        If Btn_Defect_21.Visible Then
            Btn_Defect_21.Checked = Checked
        End If
        If Btn_Defect_22.Visible Then
            Btn_Defect_22.Checked = Checked
        End If
        If Btn_Defect_23.Visible Then
            Btn_Defect_23.Checked = Checked
        End If
        If Btn_Defect_24.Visible Then
            Btn_Defect_24.Checked = Checked
        End If
        If Btn_Defect_25.Visible Then
            Btn_Defect_25.Checked = Checked
        End If
    End Sub

    Private Sub Btn_None_Click(sender As Object, e As EventArgs) Handles Btn_None.Click
        Call Change_all(False)

    End Sub

    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr

    Private Declare Function GetWindowRect Lib "user32" _
                (ByVal hwnd As IntPtr,
                ByRef lpRect As RECT) _
                As Integer

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure


    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim filename As String = ""
        Dim returnValue As DialogResult
        Dim graph As Graphics = Nothing
        Dim frmleft As System.Drawing.Point = Me.Bounds.Location
        Dim Horizontal_Size As Integer
        Dim Vertical_Size As Integer
        Dim r As New RECT


        Dim Horizontal_Multiplier As Double
        Dim Verticle_Multiplier As Double



        GetWindowRect(GetActiveWindow, r)

        ''Horizontal_Multiplier = HRes / 1920.0
        ''Verticle_Multiplier = VRes / 1080.0


        ''If Horizontal_Multiplier = 1 Then
        ''    Horizontal_Size = Me.Width - 30
        ''    Vertical_Size = Me.Height - 40
        ''Else
        ''    Horizontal_Size = Horizontal_Multiplier * Me.Width
        ''    Vertical_Size = Verticle_Multiplier * Me.Height
        ''End If

        '        Dim bmp As New Bitmap(Me.Bounds.Width - 30, Me.Bounds.Height - 40)


        '        Dim bmp As New Bitmap(Me.Width - 30, Me.Height - 40)
        'Dim bmp As New Bitmap(Horizontal_Size, Vertical_Size)
        Dim bmp As New Bitmap(r.Right - r.Left, r.Bottom - r.Top)

        '        MsgBox(Me.Bounds.Width & ";" & Me.Width)

        Try
            graph = Graphics.FromImage(bmp)
            'Dim screenx As Integer = 0
            'Dim screeny As Integer = 0

            'If Horizontal_Multiplier = 1 Then
            '    screenx = frmleft.X + 15
            '    screeny = frmleft.Y + 30
            'Else
            '    screenx = frmleft.X
            '    screeny = frmleft.Y
            'End If

            ' The - 5 here allows more of the form to be shown for the top and left sides.
            graph.CopyFromScreen(New Point(r.Left, r.Top), Point.Empty, bmp.Size)

            returnValue = SaveFile.ShowDialog
            If returnValue = DialogResult.Cancel Then
                Exit Sub
            End If

            filename = SaveFile.FileName


            ' Save the Screenshot to a file
            bmp.Save(filename)

            bmp.Dispose()
            graph.Dispose()


        Catch ex As Exception
            MsgBox("Save Image Failed: " & ex.Message)
        End Try

    End Sub

    Private Sub Export_Job_Info()
        Dim query As String
        Dim defect_list As String = ""
        Dim defect_list2 As String = ""
        Dim first_defect As Boolean = True
        Dim counter As Integer = 1
        Dim inspection_type_list As String = ""
        Dim inspection_type_selected As Boolean = False
        Dim station_list As String = ""
        Dim defect_desc_list As String = ""
        Dim reject_time As String = ""
        Dim station_list2 As String = ""
        Dim Export_All As String = ""
        Dim Reject_RFID As String = ""


        Try
            If Cmb_Description.SelectedIndex < 0 Then
                MsgBox("Please select a valid part type.")
                Exit Sub
            End If
            If PictureBox1.Image Is Nothing Then
                MsgBox("Please select a part type with an image.")
                Exit Sub
            End If
            For counter = 1 To 25
                If defect_selected(Controls("Btn_Defect_" & counter)) Then
                    If first_defect Then
                        first_defect = False
                        defect_list = Defect_ID(counter) & ""
                    Else
                        defect_list = defect_list & ", " & Defect_ID(counter)
                    End If
                    defect_desc_list = defect_desc_list & ", " & Controls("Btn_Defect_" & counter).Text
                    defect_list2 = defect_list2 & ", " & Defect_ID(counter)
                Else
                    defect_list2 = defect_list2 & ", 0"
                End If
            Next

            If Len(defect_list) < 1 Then
                MsgBox("Please select at least one defect to display.")
                Exit Sub
            End If

            If Chk_Online.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Online_Inspection_Status > 0"
                station_list = station_list & ", Online"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If

            If Chk_Wetsand.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Wet_sand_Status > 0"
                station_list = station_list & ", Wetsand"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If
            If Chk_Finesse.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Buff_Status > 0"
                station_list = station_list & ", Finesse"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If
            If Chk_Final.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Final_Inspection_Status > 0"
                station_list = station_list & ", Inspection"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If
            If Chk_Supervisor.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Supervisor_Inspection_Status > 0"
                station_list = station_list & ", Supervisor"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If
            If Chk_Decal.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Decal_Inspection_Status > 0"
                station_list = station_list & ", Decal"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If
            If Chk_Pinstripe.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Pinstripe_Inspection_Status > 0"
                station_list = station_list & ", Pinstripe"
                station_list2 = station_list2 & "1,"
            Else
                station_list2 = station_list2 & "0,"
            End If
            If Chk_Prep.Checked Then
                If inspection_type_selected Then
                    inspection_type_list = inspection_type_list & " or "
                Else
                    inspection_type_selected = True
                End If
                inspection_type_list = inspection_type_list & "RFID_Defect_Inspection.Prep_Inspection_Status > 0"
                station_list = station_list & ", Part Prep"
                station_list2 = station_list2 & "1"
            Else
                station_list2 = station_list2 & "0"
            End If

            If Chk_Export_All.Checked Then
                Export_All = ",1"
            Else
                Export_All = ",0"
            End If
            If inspection_type_selected = False Then
                MsgBox("Please select at least one inspection type.")
                Exit Sub
            End If
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()



            query = "Select distinct RFID_Defect_Inspection.Part_ID From (RFID_Defect inner Join defect On RFID_Defect.Defect_ID = defect.id)"
            query = query & " inner join RFID_Defect_Inspection on RFID_Defect.RFID_Defect_Inspection_ID = RFID_Defect_Inspection.id"
            query = query & " Where RFID_Defect.Log_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' And "
            query = query & "defect.id in (" & defect_list & ") and (" & inspection_type_list & ") And "
            query = query & "RFID_Defect_Inspection.Part_ID in (select part.id from part "
            query = query & "where part.Part_Type = " & ID_Array(Cmb_Description.SelectedIndex) & " and (part.color = " & Color_Array(Cmb_Color.SelectedIndex) & " or " & Color_Array(Cmb_Color.SelectedIndex) & " = 0))"


            Dim da2 As New SqlDataAdapter(query, SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "Defect_Parts")

            If ds2.Tables("Defect_Parts").Rows.Count = 0 Then
                SQLCon.Close()
                MsgBox("No Parts in selected range.")
                Exit Sub
            End If

            Dim filename As String = ""
            Dim row As Integer = 0
            Dim column As Integer = 0
            Dim Row_String As String = ""

            Dim returnValue As DialogResult


            returnValue = SaveFile2.ShowDialog
            If returnValue = DialogResult.Cancel Then
                SQLCon.Close()
                Exit Sub
            End If

            Me.UseWaitCursor = True

            filename = SaveFile2.FileName
            FileOpen(2, filename, OpenMode.Output)


            PrintLine(2, "Part Type:," & Cmb_Description.Text)
            PrintLine(2, "Color:," & Cmb_Color.Text)
            PrintLine(2, "Date Range: ," & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & " - " & DTP_End_Date.Text & " " & DTP_End_Time.Text)
            PrintLine(2, "Stations:" & station_list)
            PrintLine(2, "Defects: " & defect_desc_list)
            PrintLine(2, "")

            If Color_Array(Cmb_Color.SelectedIndex) = 0 Then
                PrintLine(2, "RFID, Color, Prime, Base, Top Coat, Clear, Touch Up, Rejected Area, Defect, Operator, Reject Time")
            Else
                PrintLine(2, "RFID, Prime, Base, Top Coat, Clear, Touch Up, Rejected Area, Defect, Operator, Reject Time")
            End If

            For Each dr2 As DataRow In ds2.Tables("Defect_Parts").Rows
                query = "Exec Rejected_Part_History " & dr2("Part_ID") & ", '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' , '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', " & station_list2 & defect_list2 & Export_All
                da2.SelectCommand.CommandText = query
                da2.Fill(ds2, "Rejected")
                Reject_RFID = ""
                For Each dr3 As DataRow In ds2.Tables("Rejected").Rows
                    Row_String = dr3("RFID")
                    Reject_RFID = dr3("RFID")
                    If Color_Array(Cmb_Color.SelectedIndex) = 0 Then
                        Row_String = Row_String & "," & dr3("Color")
                    End If
                    Row_String = Row_String & "," & dr3("Prime_Time") & "," & dr3("Base_Time") & "," & dr3("Top_Time") & "," & dr3("Clear_Time") & ","
                    Row_String = Row_String & dr3("TU_Time") & "," & dr3("Reject_Area") & "," & dr3("Defect") & "," & dr3("Operator") & "," & dr3("Reject_Time")
                    PrintLine(2, Row_String)
                    reject_time = dr3("Reject_Time") & ""
                Next
                If Reject_RFID <> "" Then
                    query = "Exec Rejected_Part_History_Good " & dr2("Part_ID") & ", '" & reject_time & "'"
                    da2.SelectCommand.CommandText = query
                    da2.Fill(ds2, "Good")
                    For Each dr4 As DataRow In ds2.Tables("Good").Rows
                        Row_String = dr4("Type") & "," & dr4("Operator") & "," & dr4("Time") & "," & dr4("Status")
                        PrintLine(2, Row_String)
                    Next

                End If

                PrintLine(2, "")
                ds2.Tables("rejected").Clear()
                ds2.Tables("Good").Clear()

            Next

            SQLCon.Close()
            FileClose(2)
            Me.UseWaitCursor = False

            MsgBox("Export Complete.")



        Catch ex As Exception
            Me.UseWaitCursor = False

            MsgBox("Error getting defects from database: " & ex.Message)
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
        End Try


    End Sub

    Private Sub Btn_Part_Export_Click(sender As Object, e As EventArgs) Handles Btn_Part_Export.Click
        Call Export_Job_Info()
    End Sub



    'Imports System.Runtime.InteropServices

    'Public Class Form1
    '    Private Const DESKTOPVERTRES As Integer = &H75
    '    Private Const DESKTOPHORZRES As Integer = &H76

    '    <DllImport("gdi32.dll")> Private Shared Function GetDeviceCaps(ByVal hdc As IntPtr, ByVal nIndex As Integer) As Integer
    '    End Function

    '    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '        Dim ss As New Size(0, 0)

    '        Using g As Graphics = Graphics.FromHwnd(IntPtr.Zero)
    '            Dim hDc As IntPtr = g.GetHdc
    '            ss.Width = GetDeviceCaps(hDc, DESKTOPHORZRES)
    '            ss.Height = GetDeviceCaps(hDc, DESKTOPVERTRES)
    '            g.ReleaseHdc(hDc)
    '        End Using

    '        Using bm As New Bitmap(ss.Width, ss.Height)
    '            Using g As Graphics = Graphics.FromImage(bm)
    '                g.CopyFromScreen(Point.Empty, Point.Empty, ss, CopyPixelOperation.SourceCopy)
    '            End Using

    '            bm.Save("C:\testfolder\ScreenShot.png", Imaging.ImageFormat.Png)
    '        End Using
    '    End Sub
    'End Class


End Class