Imports System.ComponentModel
Imports Microsoft.Win32
Imports System.IO.Ports
Imports System.Data.SqlClient
Imports System.Threading
Imports System.Collections.Generic



Public Class NCM_Entry

    Private customer_location As String

    Public Property CustomerLocation As String
        Get
            Return customer_location
        End Get
        Set(value As String)
            customer_location = value
        End Set
    End Property

    Private should_update As Boolean = False

    Public Property ShouldUpdate As Boolean
        Get
            Return should_update
        End Get
        Set(value As Boolean)
            should_update = value
        End Set
    End Property

    Private defect_array As New Dictionary(Of String, String)

    Public Property DefectArray As Dictionary(Of String, String)
        Get
            Return defect_array
        End Get
        Set(value As Dictionary(Of String, String))
            defect_array = value
        End Set
    End Property

    Private WithEvents ScannerPort As New SerialPort

    Private portTimer As Timers.Timer


    Private Sub NCM_Entry_Load() Handles MyBase.Load


        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next


        flowlayoutpanel_Defects.WrapContents = False
        flowlayoutpanel_Defects.AutoScroll = True
        flowlayoutpanel_Defects.SetAutoScrollMargin(0, 0)




        lbl_Title.Text = customer_location & " " & lbl_Title.Text
        line_Title.X2 = lbl_Title.Width + lbl_Title.Location.X - 55

        lbl_Cust_Part_Number.Text = customer_location & " " & lbl_Cust_Part_Number.Text


        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With
        With borderForm
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .BackColor = Color.Black
            .Opacity = 0.25
            Dim r As Rectangle = Me.Bounds
            r.Inflate(2, 2)
            .Bounds = r
            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
            r = New Rectangle(3, 3, Me.Width - 4, Me.Height - 4)
            .Region.Exclude(RoundedRectangle(r, 48))
            .Show(Me)
        End With

        FormatForEntry(True)

        InitializeVariables()

        WriteEvent("Grabbing parts from database.", EventInfo)
        'grab part type data from database when program starts and load it into array.  This data is used to attach the RFID prefix to the part name  
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select Description, RFID_Prefix from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = 150
            Dim ds As New DataSet
            da.Fill(ds, "Part Type")
            ReDim Part_Array(0)
            For Each dr As DataRow In ds.Tables("Part Type").Rows
                ReDim Preserve Part_Array(counter)
                If IsDBNull(dr("Description")) Then
                Else
                    Part_Array(counter).Description = dr("Description")
                End If
                If IsDBNull(dr("RFID_Prefix")) Then
                Else
                    Part_Array(counter).Prefix = dr("RFID_Prefix")
                End If

                counter += 1

            Next



            Dim color_DS As DataSet = toolboxMM.SQLTools.queryDatabase("Select Description from Final_Color Where End_Date > dateadd(year, -2, getdate())", "color")

            For Each dr As DataRow In color_DS.Tables("color").Rows

                combobox_Color.Items.Add(dr("Description"))

            Next

            Dim defect_DS As DataSet = toolboxMM.SQLTools.queryDatabase("Exec Get_NCM_Defects", "defects")

            For Each dr As DataRow In defect_DS.Tables("defects").Rows

                If defect_array.ContainsKey(dr("Defect")) Then

                    If dr("Category") = "Mold/Paint" Then
                        defect_array.Remove(dr("Defect"))

                        defect_array.Add(dr("Defect"), dr("Category"))

                    End If

                Else
                    defect_array.Add(dr("Defect"), dr("Category"))
                End If



            Next


            WriteEvent("Parts succesfully grabbed, starting backgroundworker.")
        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            ' lbl_Comm_Fail.Visible = True
            WriteEvent("Error Getting Part Info from Database: " & Ex.Message, EventError)
            MsgBox("Error Getting Part Info from Database: " & Ex.Message)
        End Try
        txtbox_RFID_Tag.Text = " "
        txtbox_Part_Description.Text = " "


        ' BackgroundWorker1.RunWorkerAsync()
        portTimer = New Timers.Timer(500)
        AddHandler portTimer.Elapsed, AddressOf portTimerElapsed

        FindPort()
        OpenPort()

        WriteEvent("Backgroundworker started, beginning main loop.")





    End Sub

    Private Sub defect_qty_changed(sender As Object, e As EventArgs) Handles combobox_Defect_Quantity.SelectedValueChanged


        Dim passint As Integer

        'MsgBox("yerp")

        If Int32.TryParse(combobox_Defect_Quantity.Text, passint) Then

            Dim label_panel As Defect_Panel = New Defect_Panel

            If flowlayoutpanel_Defects.Controls.Count = 0 Then



                label_panel = label_panel.Label_Panel(flowlayoutpanel_Defects.Height, flowlayoutpanel_Defects.Width)
                flowlayoutpanel_Defects.Controls.Add(label_panel)
                Defect_Panel.Populate_Control(flowlayoutpanel_Defects, passint)

            ElseIf passint >= flowlayoutpanel_Defects.Controls.Count Then

                Defect_Panel.Populate_Control(flowlayoutpanel_Defects, passint)

            ElseIf passint < flowlayoutpanel_Defects.Controls.Count Then

                For i As Integer = (flowlayoutpanel_Defects.Controls.Count - 1) To (passint + 1) Step -1
                    flowlayoutpanel_Defects.Controls.RemoveAt(i)
                Next

            End If


        Else
            MsgBox("Please enter a valid number for the Defect Quantity.", MsgBoxStyle.Exclamation)
        End If


    End Sub




    Public Sub ReorderControls()

        Dim VScrollVis As Boolean = flowlayoutpanel_Defects.VerticalScroll.Visible ' NativeMethods.IsHScrollVisible(flowlayoutpanel_Defects)

        If VScrollVis Then

            For Each ctrl As Control In flowlayoutpanel_Defects.Controls
                ctrl.Height = flowlayoutpanel_Defects.ClientSize.Height
            Next

            flowlayoutpanel_Defects.VerticalScroll.Visible = False

            Return
        End If


    End Sub

    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub



    Private Sub FormatForEntry(no_part As Boolean)



        If no_part Then
            lbl_Color.Visible = False
            combobox_Color.Visible = False
            lbl_Defect_Quantity.Visible = False
            combobox_Defect_Quantity.Visible = False
            lbl_Comments.Visible = False
            txtbox_Comments.ReadOnly = True
            txtbox_Comments.Font = New Font("Tahoma", 16, FontStyle.Bold)
            txtbox_Comments.Text = "Please scan a part."
            txtbox_RFID_Tag.Text = " "
            txtbox_Part_Description.Text = " "


        Else
            lbl_Color.Visible = True
            combobox_Color.Visible = True
            lbl_Defect_Quantity.Visible = True
            combobox_Defect_Quantity.Visible = True
            lbl_Comments.Visible = True

            If txtbox_Comments.Font.Bold Then
                txtbox_Comments.Text = ""
            End If
            txtbox_Comments.ReadOnly = False
            txtbox_Comments.Font = New Font("Tahoma", 12, FontStyle.Regular)




        End If

        txtbox_NCM_Number.Select()

    End Sub



    ' This region allows user to drag form around
#Region " Move Form "

    ' [ Move Form ]
    '
    ' // By Elektro 

    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown, lbl_Title.MouseDown, line_Title.MouseDown, lbl_NCM_Date.MouseDown, lbl_Color.MouseDown, lbl_picturebox_Part.MouseDown, lbl_Defects.MouseDown,
    lbl_NCM_Number.MouseDown, lbl_Defect_Quantity.MouseDown, lbl_Cust_Part_Number.MouseDown, lbl_Comments.MouseDown, lbl_RFID_Tag.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub

    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove, lbl_Title.MouseMove, line_Title.MouseMove, lbl_NCM_Date.MouseMove, lbl_Color.MouseMove, lbl_picturebox_Part.MouseMove, lbl_Defects.MouseMove,
    lbl_NCM_Number.MouseMove, lbl_Defect_Quantity.MouseMove, lbl_Cust_Part_Number.MouseMove, lbl_Comments.MouseMove, lbl_RFID_Tag.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
            borderForm.Location = borderForm.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub

    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp, lbl_Title.MouseUp, line_Title.MouseUp, lbl_NCM_Date.MouseUp, lbl_Color.MouseUp, lbl_picturebox_Part.MouseUp, lbl_Defects.MouseUp,
    lbl_NCM_Number.MouseUp, lbl_Defect_Quantity.MouseUp, lbl_Cust_Part_Number.MouseUp, lbl_Comments.MouseUp, lbl_RFID_Tag.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If



    End Sub

#End Region

    ' This region rounds the edges of the form
#Region " Form Rounder "

    Private borderForm As New Form

    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.Black, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click

        If lbl_Color.Visible Then
            Dim sink As New Integer

            If Int32.TryParse(txtbox_NCM_Number.Text, sink) Then



                If should_update Then

                    Dim base As String = "Update NCM_" & customer_location.Replace(" ", "_") & " Set NCM_Number = '" & txtbox_NCM_Number.Text & "', NCM_Date = '" & NCM_Date.Text & "', RFID = '" & txtbox_RFID_Tag.Text & "', Cust_Part_Number = '" & txtbox_Cust_Part_Number.Text & "', Part_ID = (select top 1 id from part_type where description = '" & txtbox_Part_Description.Text & "'), Color = '" & combobox_Color.Text & "', Defect_Qty = " & combobox_Defect_Quantity.Text & ", Notes = '" & txtbox_Comments.Text & "' where RFID = '" & txtbox_RFID_Tag.Text & "'"

                    Dim def As String = ""


                    For Each parent_control As Control In flowlayoutpanel_Defects.Controls
                        For Each ctrl As Control In parent_control.Controls
                            If ctrl.Name.Length > 2 Then

                                def += ", " & ctrl.Name & " = '" & ctrl.Text & "'"


                            End If
                        Next
                    Next

                    For i As Integer = flowlayoutpanel_Defects.Controls.Count To 6
                        Dim label As String = "Defect "
                        Dim dummy_panel As New Defect_Panel

                        For Each str As String In dummy_panel.LabelArray
                            If str <> "Label" Then

                                def += ", " & label.Replace(" ", "") & i.ToString & "_" & str.Replace(" ", "_") & "= null"
                            End If

                        Next

                    Next


                    Dim where As String = " Where RFID = '" & txtbox_RFID_Tag.Text & "'"


                    Dim query As String = base & def

                    Try
                        ' MsgBox(query)
                        toolboxMM.SQLTools.queryDatabase(query, "nada")
                    Catch ex As Exception
                        MsgBox("Unable to add information to database.")
                    End Try


                Else

                    Dim base As String = "Insert Into NCM_" & customer_location.Replace(" ", "_")
                    Dim req_columns As String = "(NCM_Number, NCM_Date, RFID, Cust_Part_Number, Part_ID, Color, Defect_Qty, Notes"

                    Dim def_columns As String = ""
                    Dim def_values As String = ""

                    For Each parent_control As Control In flowlayoutpanel_Defects.Controls
                        For Each ctrl As Control In parent_control.Controls
                            If ctrl.Name.Length > 2 Then
                                def_columns += ", " & ctrl.Name
                                def_values += "', '" & ctrl.Text


                            End If
                        Next
                    Next


                    Dim req_values As String = ") values('" & txtbox_NCM_Number.Text & "', '" & NCM_Date.Text & "', '" & txtbox_RFID_Tag.Text & "', '" & txtbox_Cust_Part_Number.Text & "', (select top 1 id from part_type where description = '" & txtbox_Part_Description.Text & "'), '" & combobox_Color.Text & "', " & combobox_Defect_Quantity.Text & ", '" & txtbox_Comments.Text




                    Dim cap As String = "')"

                    Dim query As String = base & req_columns & def_columns & req_values & def_values & cap

                    Try
                        ' MsgBox(query)
                        toolboxMM.SQLTools.queryDatabase(query, "nada")
                    Catch ex As Exception
                        MsgBox("Unable to add information to database.")
                    End Try

                End If




            Else
                MsgBox("Please enter a valid NCM Number.")
            End If


        Else
            MsgBox("Please scan a part before submitting.")
        End If



    End Sub

    Private Sub btn_New_Part_Click(sender As Object, e As EventArgs) Handles btn_New_Part.Click

        txtbox_NCM_Number.Text = ""
        txtbox_RFID_Tag.Text = ""

        combobox_Color.ResetText()

        If combobox_Defect_Quantity.Text = "6" Then
            combobox_Defect_Quantity.Text = "5"
        Else
            combobox_Defect_Quantity.Text = "6"
        End If


        flowlayoutpanel_Defects.Controls.Clear()
        picturebox_Part.Image = Nothing




        should_update = False

        FormatForEntry(True)

    End Sub


#End Region


    Private Sub portTimerElapsed()

        ' SerialPort.GetPortNames()
        If Not ScannerPort.IsOpen() Then
            FindPort()
            OpenPort()

        End If

    End Sub



    Private Sub DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles ScannerPort.DataReceived


        Dim current_read As String = ""

        Try
            current_read = ScannerPort.ReadExisting
        Catch ex As Exception
            ' MsgBox("Unable to read data from port." & vbCrLf & vbCrLf & ex.Message)
        End Try

        '
        'MsgBox(ExtractTag(current_read))

        Dim parsed_read As String = ExtractTag(current_read)

        If parsed_read <> "" Then
            RFID_Tag = parsed_read
            If InvokeRequired Then
                Invoke(Sub() Update_Screen())
            Else
                Update_Screen()
            End If


        End If

        ' RFID_Tag = current_read



        If Not ScannerPort.IsOpen Then

            FindPort()
            OpenPort()

        End If

    End Sub


    Private Function ExtractTag(raw As String) As String

        If raw.Contains("EP: ") Then

            Dim zeroindex As Integer = raw.IndexOf("EP: ")
            Dim newstring As String = Strings.Mid(raw, zeroindex + 5, zeroindex + 19 + 5)

            Try
                ' check if string is too short
                If newstring.Length < 23 Then
                    Return ""
                End If

            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try


            Try



                ' check for white space
                For i As Integer = 0 To newstring.Length - 1
                    If i > 0 And String.IsNullOrWhiteSpace(newstring(i)) Then
                        Return ""
                    End If
                Next

                Return newstring
            Catch ex As Exception
                'MsgBox("Issue parsing string: " & vbCrLf & vbCrLf & ex.Message)

            End Try


        End If


        Return ""

    End Function


    Private Sub ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles ScannerPort.ErrorReceived

        ' MsgBox("Error received on scanner port." & vbCrLf & vbCrLf & e.ToString)

        If ScannerPort.IsOpen Then
            Try
                ScannerPort.Close()
            Catch ex As Exception

            End Try
        End If

        FindPort()
        OpenPort()

    End Sub

    Private Sub PinChanged(sender As Object, e As SerialPinChangedEventArgs) Handles ScannerPort.PinChanged

        If ScannerPort.IsOpen Then
            Try
                ScannerPort.Close()
            Catch ex As Exception

            End Try

        End If

        portTimer.Interval = 500
        portTimer.Start()
        'FindPort()
        'OpenPort()

    End Sub



    Private Sub FindPort()

        Dim scanning_ports As Boolean = True

        For i As Integer = 0 To 5


            Dim ports() As String = SerialPort.GetPortNames()

            If ports.Length = 0 Then
                If InvokeRequired Then
                    Invoke(Sub() lbl_scannerstatus.NoPortsFound())
                Else
                    lbl_scannerstatus.NoPortsFound()
                End If


            Else
                If InvokeRequired Then
                    Invoke(Sub() lbl_scannerstatus.ScanningPorts())
                Else
                    lbl_scannerstatus.ScanningPorts()
                End If

            End If

            For Each port_name As String In ports

                If scanning_ports Then

                    Dim port As New SerialPort(port_name)
                    Dim return_val As String = ""
                    Dim Command As String = ""

                    Try
                        If port.IsOpen Then
                            port.Close()
                        End If

                        port.ReadTimeout = 1000
                        port.BaudRate = 115200 '9600
                        port.DataBits = 8
                        port.Parity = IO.Ports.Parity.None
                        port.StopBits = IO.Ports.StopBits.One
                        port.Handshake = IO.Ports.Handshake.None


                        port.Open()


                    Catch ex As Exception
                        ' MsgBox("Unable to open serial port." & vbCrLf & vbCrLf & ex.Message)
                    End Try

                    Try



                        ''                    return_val = port.ReadExisting()
                        ''                    WriteEvent(return_val & port.PortName, EventInfo)
                        ''                    If return_val = "CS: .fd -x" & vbCrLf & "OK:" & vbCrLf & vbCrLf Then
                        ''                        WriteEvent("Proper Response Detected", EventInfo)
                        ''                        port.WriteLine(".iv -fs on -o " & strength & " -n" & vbCr)
                        ''                        Thread.Sleep(250)
                        ''                        port.WriteLine(".bl")
                        ''                        Thread.Sleep(250)
                        ''                        port.WriteLine(".sa -aon -soff -doff" & vbCr)
                        ''                        Thread.Sleep(250)
                        ''                        return_val = port.ReadExisting()
                        ''                        WriteEvent(return_val, EventInfo)
                        ''                        Return port
                        ''                    End If

                        port.Write(".fd -x" & vbCr)
                        port.RtsEnable = True

                        Thread.Sleep(200)

                        Dim temp As String = port.ReadExisting()




                        If temp.Contains("CS: .fd -x" & vbCrLf & "OK:" & vbCrLf & vbCrLf) Then

                            port.WriteLine(".iv -fs on -o " & strength & " -n" & vbCr)
                            ''                        Thread.Sleep(250)
                            ''                        port.WriteLine(".bl")
                            ''                        Thread.Sleep(250)
                            ''                        port.WriteLine(".sa -aon -soff -doff" & vbCr)
                            ''                        Thread.Sleep(250)
                            ''                        return_val = port.ReadExisting()
                            ''                        WriteEvent(return_val, EventInfo)

                            port.Close()

                            portTimer.Enabled = False

                            If InvokeRequired Then
                                Invoke(Sub() lbl_scannerstatus.PortConnected())
                            Else
                                lbl_scannerstatus.PortConnected()
                            End If

                            ScannerPort = port
                            scanning_ports = False
                            ' MsgBox("success")

                            Return

                        End If

                    Catch ex As Exception
                        ' MsgBox("Unable to communicate with port." & vbCrLf & vbCrLf & ex.Message)
                    End Try

                End If
            Next

        Next

        If scanning_ports Then
            portTimer.Start()
        End If


    End Sub

    Private Sub OpenPort()


        If Not portTimer.Enabled Then



            Try
                If ScannerPort.IsOpen Then
                    Try
                        ScannerPort.Close()
                    Catch ex As Exception

                    End Try

                End If

                ScannerPort.ReadTimeout = 1000
                ScannerPort.BaudRate = 115200 '9600
                ScannerPort.DataBits = 8
                ScannerPort.Parity = IO.Ports.Parity.None
                ScannerPort.StopBits = IO.Ports.StopBits.One
                ScannerPort.Handshake = IO.Ports.Handshake.None

                ScannerPort.Open()
                ScannerPort.RtsEnable = True
                ScannerPort.WriteLine(".iv -fs on -o " & strength & " -n" & vbCr)



            Catch ex As Exception
                ' MsgBox("Unable to open main serial port." & vbCrLf & vbCrLf & ex.Message)
            End Try

        End If

    End Sub



    ' This region handles activity related to the handscanner. It listens on the com port and updates the textboxes for RFID Tag, Part Description, and Color
#Region " Hand Scanner "


    Structure Part_Type
        Dim Description As String
        Dim Prefix As String
    End Structure

    Public strength As String
    Public RFID_Tag As String
    Dim Part_Array() As Part_Type
    Dim counter As Integer



    Sub InitializeVariables()

        Dim strDBServer As String = ""
        Dim strDBUID As String = ""
        Dim strDBpassword As String = ""

        Dim regsoftwarekey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE")
        If Not (regsoftwarekey Is Nothing) Then
            Dim regoraclekey As RegistryKey = regsoftwarekey.OpenSubKey("ASA")
            If Not (regoraclekey Is Nothing) Then
                Dim regpaintprocesskey As RegistryKey = regoraclekey.OpenSubKey("RFID")
                If Not (regpaintprocesskey Is Nothing) Then
                    If Not (regsoftwarekey Is Nothing) Then
                        strDBServer = regpaintprocesskey.GetValue("DBServer", "")
                        strDBUID = regpaintprocesskey.GetValue("DBUID", "")
                        strDBpassword = regpaintprocesskey.GetValue("DBpassword", "")
                        strength = regpaintprocesskey.GetValue("ReadStrength", "")
                    End If
                    regpaintprocesskey.Close()
                End If
                regoraclekey.Close()
            End If
            regsoftwarekey.Close()
        End If
        If strDBServer = "" Then

            WriteEvent("Database is not configured in the registry.", EventError)
        Else
            DBConnection = "Server=" + strDBServer + ";uid=" + strDBUID + ";pwd=" + strDBpassword + ";database=RFID;Connection Timeout=30;"
        End If

    End Sub



    Private Sub Update_Screen()

        WriteEvent("Updating screen, setting RFID to " & RFID_Tag, EventInfo)
        txtbox_RFID_Tag.Text = RFID_Tag
        combobox_Color.Text = ""

        Dim RFID_Prefix As String = Strings.Left(RFID_Tag, 4)

        'find the part name by looping through the part type table and comparing RFID prefix
        For part_counter As Integer = 1 To Part_Array.Length
            If RFID_Prefix = Part_Array(part_counter - 1).Prefix Then
                txtbox_Part_Description.Text = Part_Array(part_counter - 1).Description
            End If
        Next

        FormatForEntry(False)

        Get_Part_Info(RFID_Tag)

        Get_Picture(RFID_Prefix)



    End Sub

    Private Sub Get_Part_Info(RFID_Tag As String)


        Dim temp_DS1 As DataSet = toolboxMM.SQLTools.queryDatabase("Select top 1 * From NCM_" & customer_location.Replace(" ", "_") & " Where RFID = '" & RFID_Tag & "'", "NCM")

        Dim NCM_DR As DataRow = Nothing
        For Each temp_dr1 As DataRow In temp_DS1.Tables("NCM").Rows
            NCM_DR = temp_dr1
        Next


        If NCM_DR Is Nothing Then

            Dim temp_DS2 As DataSet = toolboxMM.SQLTools.queryDatabase("Select Final_Color.Description From Part left join Final_Color On Part.Color = Final_Color.ID  Where RFID = '" & RFID_Tag & "'", "part")

            For Each temp_dr2 As DataRow In temp_DS2.Tables("part").Rows
                If Not IsDBNull(temp_dr2("Description")) Then
                    combobox_Color.Text = temp_dr2("Description")
                End If
            Next

        Else

            should_update = True

            ' could just not hardcode this :/

            txtbox_NCM_Number.Text = NCM_DR("NCM_Number")
            txtbox_Cust_Part_Number.Text = NCM_DR("Cust_Part_Number")
            NCM_Date.Text = NCM_DR("NCM_Date")
            combobox_Color.Text = NCM_DR("Color")

            combobox_Defect_Quantity.Text = NCM_DR("Defect_Qty")

            txtbox_Comments.Text = NCM_DR("Notes")

            For Each parent_control As Control In flowlayoutpanel_Defects.Controls
                For Each ctrl As Control In parent_control.Controls
                    If ctrl.Name.Length > 2 Then

                        ctrl.Text = NCM_DR(ctrl.Name)


                    End If
                Next
            Next



        End If





    End Sub

    Private Sub Get_Picture(RFID_Prefix As String)

        Dim picturetable As DataSet = toolboxMM.SQLTools.queryDatabase("Select Part_Type.Image_Name as Image From Part_Type Where RFID_Prefix = '" & RFID_Prefix & "'", "picture")

        Try
            For Each dr As DataRow In picturetable.Tables("picture").Rows
                picturebox_Part.Image = Image.FromFile(Image_Share & dr("Image"), False)
            Next
        Catch ex As Exception

        End Try


    End Sub


#End Region



End Class


#Region " Defect Panel "

Public Class Defect_Panel


    Inherits TableLayoutPanel

    Private label_array As String() = {"Label", "Category", "Defect", "Cust Findings", "MM Findings"}

    Public Property LabelArray As String()
        Get
            Return label_array
        End Get
        Set(value As String())
            label_array = value
        End Set
    End Property

    Shared Sub Populate_Control(temp_control As FlowLayoutPanel, obj_count As Integer)

        Dim height As Integer = temp_control.Height / 1.2
        Dim Width As Integer = temp_control.Width / 3.1

        Dim cat_array() As String = {"Mold", "Paint", "Mold/Paint", "Unknown"}

        Dim label As String = "Defect "


        For i As Integer = (temp_control.Controls.Count) To obj_count



            Dim temp_panel As New Defect_Panel

            temp_panel.Name = label.Replace(" ", "") & i.ToString

            temp_panel.Height = height
            temp_panel.Width = Width

            temp_panel.RowCount = 5
            temp_panel.ColumnCount = 1

            For Each str As String In temp_panel.LabelArray

                If temp_panel.Controls.Count = 0 Then

                    Dim tempbox As TextBox = New TextBox
                    tempbox.ReadOnly = True
                    ' tempbox.Name = label.Replace(" ", "") & i.ToString
                    tempbox.Text = label & i.ToString
                    tempbox.Font = temp_panel.getfont(True, False)

                    tempbox.Height = temp_panel.Height / temp_panel.RowCount
                    tempbox.Width = temp_panel.Width

                    temp_panel.Controls.Add(tempbox)

                Else



                    Dim tempbox As ComboBox = New ComboBox
                    tempbox.Name = label.Replace(" ", "") & i.ToString & "_" & str.Replace(" ", "_")
                    tempbox.Font = temp_panel.getfont(False, False)

                    tempbox.Height = temp_panel.Height / temp_panel.RowCount
                    tempbox.Width = temp_panel.Width

                    tempbox.DropDownWidth = 350

                    If str = "Defect" Then
                        For Each defect As String In NCM_Form.DefectArray.Keys
                            tempbox.Items.Add(defect)
                        Next

                        AddHandler tempbox.SelectedValueChanged, AddressOf temp_panel.defect_changed

                    ElseIf str = "Category" Then

                        For Each cat As String In cat_array
                            tempbox.Items.Add(cat)
                        Next

                    End If

                    temp_panel.Controls.Add(tempbox)

                End If

            Next

            temp_control.Controls.Add(temp_panel)

        Next





    End Sub

    Public Sub defect_changed(sender As Object, e As EventArgs)

        ' MsgBox(sender.Name & vbCrLf & sender.Parent.Name)

        For Each ctrl As Control In sender.Parent.Controls

            If ctrl.Name = sender.Parent.Name & "_Category" Then

                If NCM_Form.DefectArray.ContainsKey(sender.text) Then
                    ctrl.Text = NCM_Form.DefectArray.Item(sender.text)
                End If

            End If

        Next


    End Sub

    Public Function Label_Panel(height As Integer, width As Integer) As Defect_Panel

        Dim temp_Panel As Defect_Panel = New Defect_Panel

        temp_Panel.Height = height / 1.2
        temp_Panel.Width = width / 3.1

        temp_Panel.RowCount = 5
        temp_Panel.ColumnCount = 1



        Dim reg_font As Font = getfont(True, False)

        For Each str As String In label_array

            Dim tempbox As TextBox = New TextBox

            tempbox.Height = temp_Panel.Height / temp_Panel.RowCount
            tempbox.Width = temp_Panel.Width
            tempbox.ReadOnly = True

            tempbox.Font = reg_font



                tempbox.Text = str

            temp_Panel.Controls.Add(tempbox)


        Next

        Return temp_Panel


    End Function




    Private Function getfont(should_bold As Boolean, should_italicize As Boolean) As Font

        ' 0 = regular
        ' 1 = bold
        ' 2 = italic
        ' 3 = bold and italic

        Dim font_style As FontStyle


        If (Not should_bold) And (Not should_italicize) Then
            font_style = FontStyle.Regular

        ElseIf should_bold Then
            font_style = FontStyle.Bold

        ElseIf should_italicize Then
            font_style = FontStyle.Italic

        Else
            font_style = FontStyle.Bold Or FontStyle.Italic

        End If



        Dim temp_font As Font = New Font("Tahoma", 12, font_style)

        Return temp_font


    End Function




End Class
#End Region