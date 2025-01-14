Imports System.Data
Imports System.Data.SqlClient
Public Class Test_Panel
    Private bindingsource1 As New BindingSource
    Private bindingsource_part As New BindingSource
    Dim Location_Array() As Int32
    Dim Part_ID As Integer
    Dim Log_ID As Integer



    Sub Change_RFID()
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        If Part_ID > 0 Then
            Btn_Save.Visible = True
            Btn_Reclear_Save.Visible = True
            Btn_M5_Save.Visible = True
        Else
            Btn_Save.Visible = False
            Btn_Reclear_Save.Visible = False
            Btn_M5_Save.Visible = False
        End If

        bindingsource1.DataSource = GetData("Select Paint_Load.Log_Time as Timestamp, Paint_Color.PLC_Color as [Color Code], Paint_Color.Description as [Paint Color] from ((part inner join paint_load_RFID on part.rfid = paint_load_rfid.rfid) inner join Paint_Load on Paint_Load_RFID.Carrier_ID = paint_load.carrier_ID) inner join Paint_Color on paint_load.color = Paint_Color.PLC_Color where paint_load.log_time between paint_color.start_date and paint_color.end_date and part.id = " & Part_ID & " and Paint_Load_RFID.Carrier_ID <> 0 order by Paint_Load.Log_Time")

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells




        Me.Cursor = Cursors.Default
    End Sub

    Sub Load_Locations()

        Dim counter As Integer = 0
        Try
            Cmb_Location.Items.Clear()
            Cmb_Reclear_Location.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Test_Panel_Location order by Location", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Test_Panel_Location")
            SQLCon.Close()
            ReDim Location_Array(0)
            For Each dr As DataRow In ds.Tables("Test_Panel_Location").Rows
                Cmb_Location.Items.Add(dr("Location"))
                Cmb_Reclear_Location.Items.Add(dr("Location"))
                Cmb_M5_Location.Items.Add(dr("Location"))
                ReDim Preserve Location_Array(counter)
                Location_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Test Panel Locations Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Dim query As String = ""
        'Check for Valid Data

        If Part_ID = 0 Then
            MsgBox("RFID Tag not in system")
            Exit Sub
        End If

        If Cmb_Location.SelectedIndex < 0 Then
            MsgBox("Please select a valid Location")
            Exit Sub
        End If


        If Log_ID <= 0 Then
            query = "Insert into Test_Panel_Log (Part_ID, Location_ID, Adhesion, Color, Double_Rub, Tested_By, User_ID, Logged_Date) "
            query = query & " values (" & Part_ID & ", " & Location_Array(Cmb_Location.SelectedIndex) & ", '" & Cmb_Adhesion.Text & "', '"
            query = query & Cmb_Color.Text & "', '" & Cmb_Double_Rub.Text & "', '" & Txt_Tested_By.Text & "', " & USer_ID & ", getdate())"
        Else
            If Part_ID <= 0 Then
                Exit Sub
            End If
            query = "update test_panel_log Set location_id = " & Location_Array(Cmb_Location.SelectedIndex) & ", adhesion = '" & Cmb_Adhesion.Text & "',"
            query = query & "color = '" & Cmb_Color.Text & "', Double_Rub = '" & Cmb_Double_Rub.Text & "', tested_by = '" & Txt_Tested_By.Text & "' where id = " & Log_ID
        End If

        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

    End Sub

    Private Sub Test_Panel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Cmb_Serial_Ports.Items.Add(sp)
        Next


        Call Load_Locations()
    End Sub

    Private Sub Txt_RFID_TextChanged(sender As Object, e As EventArgs) Handles Txt_RFID.TextChanged

        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        Dim daTest_Panel_Info As New SqlDataAdapter("Get_Test_Panel_Info '" & Txt_RFID.Text & "'", SQLCon)
        daTest_Panel_Info.SelectCommand.CommandTimeout = SQL_Timeout
        Dim dsTest_Panel_Info As New DataSet
        daTest_Panel_Info.Fill(dsTest_Panel_Info, "Test_Panel_Info")

        'query = "Select ID, isnull(killed,0) as killed, killed_date from Part where rfid = '" & Txt_RFID.Text & "'"

        'Dim da As New SqlDataAdapter(query, SQLCon)
        'da.SelectCommand.CommandTimeout = SQL_Timeout
        'Dim ds As New DataSet
        'da.Fill(ds, "Part")
        SQLCon.Close()

        Log_ID = 0

        Part_ID = 0
        Lbl_Tag_Killed.Visible = False

        For Each dr As DataRow In dsTest_Panel_Info.Tables("Test_Panel_Info").Rows
            Part_ID = dr("Part ID")
            If dr("killed") = 1 Then
                Lbl_Tag_Killed.Text = "Tag Killed - " & dr("killed date")
                Lbl_Tag_Killed.Visible = True
            End If
            Log_ID = dr("ID")
            Cmb_Location.Text = dr("paint_Location") & ""
            Cmb_Adhesion.Text = dr("adhesion") & ""
            Cmb_Double_Rub.Text = dr("double_rub") & ""
            Cmb_Color.Text = dr("color") & ""
            Txt_Tested_By.Text = dr("tested_by") & ""
            Cmb_Reclear_Location.Text = dr("reclear_Location") & ""
            Cmb_Reclear_Adhesion.Text = dr("reclear_adhesion") & ""
            Cmb_Reclear_Double_Rub.Text = dr("reclear_double_rub") & ""
            Cmb_Reclear_Color.Text = dr("reclear_color") & ""
            Txt_Reclear_Tested_By.Text = dr("reclear_tested_by") & ""
            Cmb_M5_Location.Text = dr("M5_Location") & ""
            Cmb_M5_Adhesion.Text = dr("M5_adhesion") & ""
            Cmb_M5_Double_Rub2_GL.Text = dr("M5_Rub_Gloss_Loss") & ""
            Cmb_M5_Double_Rub2_PT.Text = dr("M5_Rub_Paint_Transfer") & ""
            Txt_M5_Color.Text = dr("M5_Color") & ""
            Txt_M5_Orange_Peel.Text = dr("M5_Orange_Peel") & ""
            Txt_M5_Gloss.Text = dr("M5_Gloss") & ""
            Cmb_M5_Hardness.Text = dr("M5_Hardness") & ""
            Txt_M5_Tested_By.Text = dr("M5_tested_by") & ""
        Next

        'query = "Select Test_Panel_Log.id, adhesion, color, double_rub, tested_by, tpl1.Location as paint_location, reclear_adhesion, reclear_color, reclear_double_rub, "
        'query = query & "reclear_tested_by, tpl2.Location as reclear_location, M5_Adhesion, M5_Color, M5_Orange_Peel, M5_Gloss, M5_Rub_Gloss_Loss, M5_Rub_Paint_Transfer, M5_Hardness, "
        'query = query & "M5_Tested_By, tpl3.Location as M5_location from ((Test_Panel_Log left join test_panel_location tpl1 on test_panel_log.location_id = tpl1.id)"
        'query = query & " left join test_panel_location tpl2 on test_panel_log.reclear_location_id = tpl2.id) left join test_panel_location tpl3 on test_panel_log.M5_location_id = tpl3.id "
        'query = query & "where Part_ID = " & Part_ID

        'Dim da2 As New SqlDataAdapter(query, SQLCon)
        'Dim ds2 As New DataSet
        'da2.Fill(ds2, "Test_Panel_Log")


        'For Each dr2 As DataRow In ds2.Tables("Test_Panel_Log").Rows
        '    Log_ID = dr2("ID")
        '    Cmb_Location.Text = dr2("paint_Location") & ""
        '    Cmb_Adhesion.Text = dr2("adhesion") & ""
        '    Cmb_Double_Rub.Text = dr2("double_rub") & ""
        '    Cmb_Color.Text = dr2("color") & ""
        '    Txt_Tested_By.Text = dr2("tested_by") & ""
        '    Cmb_Reclear_Location.Text = dr2("reclear_Location") & ""
        '    Cmb_Reclear_Adhesion.Text = dr2("reclear_adhesion") & ""
        '    Cmb_Reclear_Double_Rub.Text = dr2("reclear_double_rub") & ""
        '    Cmb_Reclear_Color.Text = dr2("reclear_color") & ""
        '    Txt_Reclear_Tested_By.Text = dr2("reclear_tested_by") & ""
        '    Cmb_M5_Location.Text = dr2("M5_Location") & ""
        '    Cmb_M5_Adhesion.Text = dr2("M5_adhesion") & ""
        '    Cmb_M5_Double_Rub2_GL.Text = dr2("M5_Rub_Gloss_Loss") & ""
        '    Cmb_M5_Double_Rub2_PT.Text = dr2("M5_Rub_Paint_Transfer") & ""
        '    Txt_M5_Color.Text = dr2("M5_Color") & ""
        '    Txt_M5_Orange_Peel.Text = dr2("M5_Orange_Peel") & ""
        '    Txt_M5_Gloss.Text = dr2("M5_Gloss") & ""
        '    Cmb_M5_Hardness.Text = dr2("M5_Hardness") & ""
        '    Txt_M5_Tested_By.Text = dr2("M5_tested_by") & ""
        'Next
        If Log_ID = 0 Then
            Cmb_Location.Text = ""
            Cmb_Adhesion.Text = ""
            Cmb_Double_Rub.Text = ""
            Cmb_Color.Text = ""
            Txt_Tested_By.Text = ""
            Cmb_Reclear_Location.Text = ""
            Cmb_Reclear_Adhesion.Text = ""
            Cmb_Reclear_Double_Rub.Text = ""
            Cmb_Reclear_Color.Text = ""
            Txt_Reclear_Tested_By.Text = ""
            Cmb_M5_Location.Text = ""
            Cmb_M5_Adhesion.Text = ""
            Cmb_M5_Double_Rub2_GL.Text = ""
            Cmb_M5_Double_Rub2_PT.Text = ""
            Txt_M5_Color.Text = ""
            Txt_M5_Gloss.Text = ""
            Cmb_M5_Hardness.Text = ""
            Txt_M5_Tested_By.Text = ""
        End If




        Call Change_RFID()

    End Sub

    Private Sub Btn_Connect_Click(sender As Object, e As EventArgs) Handles Btn_Connect.Click
        Call ReceiveSerialData()

    End Sub

    Private Sub ReceiveSerialData()
        ' Receive strings from a serial port.
        Timer1.Enabled = False
        Dim counter As Integer = 0
        Dim good_Data As Boolean = False
        Dim Ascii_Value As Integer = 0
        Dim Incoming As String = ""
        '        Me.Cursor = Cursors.WaitCursor
        Dim returnStr As String = ""
        If Cmb_Serial_Ports.SelectedIndex < 0 Then
            MsgBox("Please pick a valid serial port.")
            Exit Sub
        End If
        Dim com1 As IO.Ports.SerialPort = Nothing
        Dim End_Time As DateTime
        End_Time = DateAdd(DateInterval.Second, 30, Now)

        Try
            com1 = My.Computer.Ports.OpenSerialPort(Cmb_Serial_Ports.Text)
            com1.ReadTimeout = 10000
            com1.BaudRate = 115200

            com1.DataBits = 8
            com1.Handshake = IO.Ports.Handshake.None
            com1.Parity = IO.Ports.Parity.None
            com1.StopBits = IO.Ports.StopBits.One

            Do While End_Time > Now
                Incoming = com1.ReadLine()
                If Incoming Is Nothing Then
                    'Exit Do
                Else
                    Incoming = Strings.Replace(Incoming, vbNullChar, "")
                    If (Len(Incoming)) >= 24 Then
                        Incoming = Mid(Incoming, 1, 24)
                        good_Data = True
                        For counter = 1 To Len(Incoming)
                            Ascii_Value = Asc(Mid(Incoming, counter, 1))
                            If (Ascii_Value < 48) Or ((Ascii_Value > 57) And (Ascii_Value < 65)) Or ((Ascii_Value > 70) And (Ascii_Value < 97)) Or (Ascii_Value > 102) Then
                                good_Data = False
                            End If
                        Next
                        If good_Data Then
                            returnStr &= Incoming
                            Exit Do
                        End If
                    End If
                End If

            Loop

        Catch ex As TimeoutException
            MsgBox("Error: Serial Port read timed out.")
        Finally
            If com1 IsNot Nothing Then com1.Close()
        End Try
        Txt_RFID.Text = returnStr
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Btn_Reclear_Save_Click(sender As Object, e As EventArgs) Handles Btn_Reclear_Save.Click
        Dim query As String = ""
        'Check for Valid Data

        If Part_ID = 0 Then
            MsgBox("RFID Tag not in system")
            Exit Sub
        End If

        If Cmb_Reclear_Location.SelectedIndex < 0 Then
            MsgBox("Please select a valid Location")
            Exit Sub
        End If


        If Log_ID <= 0 Then
            query = "Insert into Test_Panel_Log (Part_ID, Reclear_Location_ID, Reclear_Adhesion, Reclear_Color, Reclear_Double_Rub, Reclear_Tested_By, Reclear_Logged_Date) "
            query = query & " values (" & Part_ID & ", " & Location_Array(Cmb_Reclear_Location.SelectedIndex) & ", '" & Cmb_Reclear_Adhesion.Text & "', '"
            query = query & Cmb_Reclear_Color.Text & "', '" & Cmb_Reclear_Double_Rub.Text & "', '" & Txt_Reclear_Tested_By.Text & "', getdate())"
        Else
            If Part_ID <= 0 Then
                Exit Sub
            End If
            query = "update test_panel_log Set reclear_location_id = " & Location_Array(Cmb_Reclear_Location.SelectedIndex) & ", reclear_adhesion = '" & Cmb_Reclear_Adhesion.Text & "',"
            query = query & "reclear_color = '" & Cmb_Reclear_Color.Text & "', reclear_Double_Rub = '" & Cmb_Reclear_Double_Rub.Text & "', reclear_tested_by = '" & Txt_Reclear_Tested_By.Text & "', Reclear_Logged_Date = getdate() where id = " & Log_ID
        End If

        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

    End Sub


    Private Sub Btn_M5_Save_Click(sender As Object, e As EventArgs) Handles Btn_M5_Save.Click
        Dim query As String = ""
        'Check for Valid Data

        If Part_ID = 0 Then
            MsgBox("RFID Tag not in system")
            Exit Sub
        End If

        If Cmb_M5_Location.SelectedIndex < 0 Then
            MsgBox("Please select a valid Location")
            Exit Sub
        End If


        If Log_ID <= 0 Then
            query = "Insert into Test_Panel_Log (Part_ID, M5_Location_ID, M5_Adhesion, M5_Color, M5_Rub_Gloss_Loss, M5_Rub_Paint_Transfer, M5_Hardness, M5_Orange_Peel, M5_Gloss, M5_Tested_By, M5_Logged_Date) "
            query = query & " values (" & Part_ID & ", " & Location_Array(Cmb_M5_Location.SelectedIndex) & ", '" & Cmb_M5_Adhesion.Text & "', '"
            query = query & Txt_M5_Color.Text & "', '" & Cmb_M5_Double_Rub2_GL.Text & "', '" & Cmb_M5_Double_Rub2_PT.Text & "', '" & Cmb_M5_Hardness.Text & "', '" & Txt_M5_Orange_Peel.Text & "', '" & Txt_M5_Gloss.Text & "', '" & Txt_M5_Tested_By.Text & "', getdate())"
        Else
            If Part_ID <= 0 Then
                Exit Sub
            End If
            query = "update test_panel_log Set M5_location_id = " & Location_Array(Cmb_M5_Location.SelectedIndex) & ", M5_adhesion = '" & Cmb_M5_Adhesion.Text & "',"
            query = query & "M5_color = '" & Txt_M5_Color.Text & "', M5_Rub_Gloss_Loss = '" & Cmb_M5_Double_Rub2_GL.Text & "', M5_Rub_Paint_Transfer = '" & Cmb_M5_Double_Rub2_PT.Text & "',"
            query = query & "M5_Hardness = '" & Cmb_M5_Hardness.Text & "', M5_Orange_Peel = '" & Txt_M5_Orange_Peel.Text & "', M5_Gloss = '" & Txt_M5_Gloss.Text & "', M5_tested_by = '" & Txt_M5_Tested_By.Text & "', M5_Logged_Date = getdate() where id = " & Log_ID
        End If

        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()

    End Sub

    Private Sub Cmb_M5_Adhesion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_M5_Adhesion.SelectedIndexChanged
        If Cmb_M5_Adhesion.Text = "P" Then
            Cmb_M5_Adhesion.BackColor = Color.Green
            Lbl_M5_Adhesion.BackColor = Color.Green
        End If
        If Cmb_M5_Adhesion.Text = "F" Then
            Cmb_M5_Adhesion.BackColor = Color.Red
            Lbl_M5_Adhesion.BackColor = Color.Red
        End If

    End Sub

    Private Sub Cmb_M5_Hardness_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_M5_Hardness.SelectedIndexChanged
        If Cmb_M5_Hardness.Text = "P" Then
            Cmb_M5_Hardness.BackColor = Color.Green
            Lbl_M5_Hardness.BackColor = Color.Green
        End If
        If Cmb_M5_Hardness.Text = "F" Then
            Cmb_M5_Hardness.BackColor = Color.Red
            Lbl_M5_Hardness.BackColor = Color.Red
        End If

    End Sub

    Private Sub Cmb_M5_Double_Rub2_GL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_M5_Double_Rub2_GL.SelectedIndexChanged
        If Cmb_M5_Double_Rub2_GL.Text = "P" Then
            Cmb_M5_Double_Rub2_GL.BackColor = Color.Green
            Lbl_M5_Double_Rub2_GL.BackColor = Color.Green
        End If
        If Cmb_M5_Double_Rub2_GL.Text = "F" Then
            Cmb_M5_Double_Rub2_GL.BackColor = Color.Red
            Lbl_M5_Double_Rub2_GL.BackColor = Color.Red
        End If

    End Sub

    Private Sub Cmb_M5_Double_Rub2_PT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_M5_Double_Rub2_PT.SelectedIndexChanged
        If Cmb_M5_Double_Rub2_PT.Text = "P" Then
            Cmb_M5_Double_Rub2_PT.BackColor = Color.Green
            Lbl_M5_Double_Rub2_PT.BackColor = Color.Green
        End If
        If Cmb_M5_Double_Rub2_PT.Text = "F" Then
            Cmb_M5_Double_Rub2_PT.BackColor = Color.Red
            Lbl_M5_Double_Rub2_PT.BackColor = Color.Red
        End If

    End Sub

    Private Sub Txt_M5_Orange_Peel_TextChanged(sender As Object, e As EventArgs) Handles Txt_M5_Orange_Peel.LostFocus
        If Txt_M5_Orange_Peel.Text = "" Then
        Else
            If Not IsNumeric(Txt_M5_Orange_Peel.Text) Then
                MsgBox("Please enter a number between 1 and 10")
                Txt_M5_Orange_Peel.Text = ""
                Txt_M5_Orange_Peel.BackColor = Color.Red
                Lbl_M5_Orange_Peel.BackColor = Color.Red
            Else
                If Txt_M5_Orange_Peel.Text < 1 Or Txt_M5_Orange_Peel.Text > 10 Then
                    MsgBox("Value is out of range")
                    Txt_M5_Orange_Peel.Text = ""
                    Txt_M5_Orange_Peel.BackColor = Color.Red
                    Lbl_M5_Orange_Peel.BackColor = Color.Red
                End If
            End If
        End If
        If IsNumeric(Txt_M5_Orange_Peel.Text) Then
            If Txt_M5_Orange_Peel.Text < 6 Then
                Txt_M5_Orange_Peel.BackColor = Color.Red
                Lbl_M5_Orange_Peel.BackColor = Color.Red
            Else
                Txt_M5_Orange_Peel.BackColor = Color.Green
                Lbl_M5_Orange_Peel.BackColor = Color.Green
            End If
        End If


    End Sub

    Private Sub Cmb_Adhesion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Adhesion.SelectedIndexChanged
        If Cmb_Adhesion.Text = "P" Then
            Cmb_Adhesion.BackColor = Color.Green
            Lbl_Adhesion.BackColor = Color.Green
        End If
        If Cmb_Adhesion.Text = "F" Then
            Cmb_Adhesion.BackColor = Color.Red
            Lbl_Adhesion.BackColor = Color.Red
        End If

    End Sub

    Private Sub Cmb_Color_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Color.SelectedIndexChanged
        If Cmb_Color.Text = "P" Then
            Cmb_Color.BackColor = Color.Green
            Lbl_Color.BackColor = Color.Green
        End If
        If Cmb_Color.Text = "F" Then
            Cmb_Color.BackColor = Color.Red
            Lbl_Color.BackColor = Color.Red
        End If
    End Sub

    Private Sub Cmb_Double_Rub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Double_Rub.SelectedIndexChanged
        If Cmb_Double_Rub.Text = "P" Then
            Cmb_Double_Rub.BackColor = Color.Green
            Lbl_Double_Rub.BackColor = Color.Green
        End If
        If Cmb_Double_Rub.Text = "F" Then
            Cmb_Double_Rub.BackColor = Color.Red
            Lbl_Double_Rub.BackColor = Color.Red
        End If
    End Sub

    Private Sub Cmb_Reclear_Adhesion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Reclear_Adhesion.SelectedIndexChanged
        If Cmb_Reclear_Adhesion.Text = "P" Then
            Cmb_Reclear_Adhesion.BackColor = Color.Green
            Lbl_Reclear_Adhesion.BackColor = Color.Green
        End If
        If Cmb_Reclear_Adhesion.Text = "F" Then
            Cmb_Reclear_Adhesion.BackColor = Color.Red
            Lbl_Reclear_Adhesion.BackColor = Color.Red
        End If
    End Sub

    Private Sub Cmb_Reclear_Color_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Reclear_Color.SelectedIndexChanged
        If Cmb_Reclear_Color.Text = "P" Then
            Cmb_Reclear_Color.BackColor = Color.Green
            Lbl_Reclear_Color.BackColor = Color.Green
        End If
        If Cmb_Reclear_Color.Text = "F" Then
            Cmb_Reclear_Color.BackColor = Color.Red
            Lbl_Reclear_Color.BackColor = Color.Red
        End If
    End Sub

    Private Sub Cmb_Reclear_Double_Rub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Reclear_Double_Rub.SelectedIndexChanged
        If Cmb_Reclear_Double_Rub.Text = "P" Then
            Cmb_Reclear_Double_Rub.BackColor = Color.Green
            Lbl_Reclear_Double_Rub.BackColor = Color.Green
        End If
        If Cmb_Reclear_Double_Rub.Text = "F" Then
            Cmb_Reclear_Double_Rub.BackColor = Color.Red
            Lbl_Reclear_Double_Rub.BackColor = Color.Red
        End If
    End Sub

    Private Sub Txt_M5_Color_TextChanged(sender As Object, e As EventArgs) Handles Txt_M5_Color.LostFocus
        If Txt_M5_Color.Text = "" Then
        Else
            If Not IsNumeric(Txt_M5_Color.Text) Then
                MsgBox("Please enter a number between 0 and 10")
                Txt_M5_Color.Text = ""
                Txt_M5_Color.BackColor = Color.Red
                Lbl_M5_Color.BackColor = Color.Red
            Else
                If Txt_M5_Color.Text < 0 Or Txt_M5_Color.Text > 10 Then
                    MsgBox("Value is out of range")
                    Txt_M5_Color.Text = ""
                    Txt_M5_Color.BackColor = Color.Red
                    Lbl_M5_Color.BackColor = Color.Red
                End If
            End If
        End If
        If IsNumeric(Txt_M5_Color.Text) Then
            If Txt_M5_Color.Text < 1 Then
                Txt_M5_Color.BackColor = Color.Green
                Lbl_M5_Color.BackColor = Color.Green
            Else
                Txt_M5_Color.BackColor = Color.Red
                Lbl_M5_Color.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub Txt_M5_Gloss_TextChanged(sender As Object, e As EventArgs) Handles Txt_M5_Gloss.Validating
        If Txt_M5_Gloss.Text = "" Then
        Else
            If Not IsNumeric(Txt_M5_Gloss.Text) Then
                MsgBox("Please enter a number between 1 and 100")
                Txt_M5_Gloss.Text = ""
                Txt_M5_Gloss.BackColor = Color.Red
                Lbl_M5_Gloss.BackColor = Color.Red
            Else
                If Txt_M5_Gloss.Text < 0 Or Txt_M5_Gloss.Text > 100 Then
                    MsgBox("Value is out of range")
                    Txt_M5_Gloss.Text = ""
                    Txt_M5_Gloss.BackColor = Color.Red
                    Lbl_M5_Gloss.BackColor = Color.Red
                End If
            End If
        End If
        If IsNumeric(Txt_M5_Gloss.Text) Then
            If Txt_M5_Gloss.Text < 90 Then
                Txt_M5_Gloss.BackColor = Color.Red
                Lbl_M5_Gloss.BackColor = Color.Red
            Else
                Txt_M5_Gloss.BackColor = Color.Green
                Lbl_M5_Gloss.BackColor = Color.Green
            End If
        End If
    End Sub
End Class