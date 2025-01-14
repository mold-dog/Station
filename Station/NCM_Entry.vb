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


    Private Sub NCM_Entry_Load() Handles MyBase.Load

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
        BackgroundWorker1.RunWorkerAsync()
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

                If Int32.TryParse(txtbox_Cust_Part_Number.Text, sink) Then

                    If should_update Then

                        Dim base As String = "Update NCM_" & customer_location.Replace(" ", "_") & " Set NCM_Number = '" & txtbox_NCM_Number.Text & "', NCM_Date = '" & NCM_Date.Text & "', RFID = '" & txtbox_RFID_Tag.Text & "', Cust_Part_Number = '" & txtbox_Cust_Part_Number.Text & "', Part_ID = (select top 1 id from part_type where description = '" & txtbox_Part_Description.Text & "'), Color = '" & combobox_Color.Text & "', Defect_Qty = " & combobox_Defect_Quantity.Text & ", Notes = '" & txtbox_Comments.Text & "'"

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
                    MsgBox("Please enter a valid Part Number")
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

    ' This region handles activity related to the handscanner. It listens on the com port and updates the textboxes for RFID Tag, Part Description, and Color
#Region " Hand Scanner "




    Structure RFID_Data
        Dim Index As Integer
        Dim RFID_Tag As String
        Dim Part_Name As String
        Dim RSSI_text As String
    End Structure

    Structure Part_Type
        Dim Description As String
        Dim Prefix As String
    End Structure

    Structure Part_Count
        Dim Index As Integer
        Dim Description As String
        Dim Count As Integer
    End Structure

    Public SQLCon As New SqlConnection

    Public DBConnection As String
    Public comm_port As String
    Public strength As String
    Public Station As String
    Public RFID_Tag As String
    Dim RFID_Tag_Buffered As String
    Public RSSI_Value As String = ""

    Dim update_string As String
    Dim eval_job As Integer
    Dim Database_Good As Boolean = True
    Dim RFID_Array() As RFID_Data
    Dim Mem_Array() As RFID_Data
    Dim overall_count As Integer = 1
    Dim Part_Array() As Part_Type
    Dim Count_Array() As Part_Count
    Dim counter As Integer
    Dim Array_Clear As Boolean
    Dim Screen_Updating As Boolean
    Dim pending_user As Boolean = False



    Const User_Interaction As Boolean = True


    'set up the thread that monitors serial comms with handheld reader 
    Public Sub New()
        InitializeComponent()
        BackgroundWorker1.WorkerReportsProgress = True
        BackgroundWorker1.WorkerSupportsCancellation = True


    End Sub

    Private Function open_port() As SerialPort

        txtbox_RFID_Tag.Text = " "
        txtbox_Part_Description.Text = " "

        Dim ports() As String = SerialPort.GetPortNames()
        Dim str_ports As String = ""

        For Each port_piece As String In ports
            If str_ports = "" Then
                str_ports += port_piece
            Else
                str_ports += ", " & port_piece
            End If
            'str_ports += port_piece & ", "
        Next
        WriteEvent("Available ports:  " + str_ports, EventInfo)

        While True


            ports = SerialPort.GetPortNames()


            For Each portName As String In ports
                Dim port As New SerialPort(portName)
                Dim return_val As String = ""
                Dim Command As String = ""
                Try
                    'TODO: take a look at order re: potential hangup/slowdown
                    port.Open()
                    port.ReadTimeout = 1000
                    port.BaudRate = 115200
                    port.DataBits = 8
                    port.Handshake = IO.Ports.Handshake.None
                    port.Parity = IO.Ports.Parity.None
                    port.StopBits = IO.Ports.StopBits.One

                    port.WriteLine(".fd -x" & vbCr)
                    port.RtsEnable = True
                    'TODO: alternatives to sleep
                    Thread.Sleep(500)
                    return_val = port.ReadExisting()
                    WriteEvent(return_val & port.PortName, EventInfo)
                    If return_val = "CS: .fd -x" & vbCrLf & "OK:" & vbCrLf & vbCrLf Then
                        WriteEvent("Proper Response Detected", EventInfo)
                        port.WriteLine(".iv -fs on -o " & strength & " -n" & vbCr)
                        Thread.Sleep(250)
                        port.WriteLine(".bl")
                        Thread.Sleep(250)
                        port.WriteLine(".sa -aon -soff -doff" & vbCr)
                        Thread.Sleep(250)
                        return_val = port.ReadExisting()
                        WriteEvent(return_val, EventInfo)
                        Return port
                    End If


                Catch ex As Exception
                    WriteEvent(return_val & port.PortName & "Catch", EventInfo)
                    If port IsNot Nothing Then port.Close()
                    WriteEvent(("Error connecting to port " & portName & ": " & ex.Message))
                Finally
                    WriteEvent(return_val & port.PortName & "Finally", EventInfo)
                    ' Ensure the port is closed after attempting to open it
                    If port.IsOpen Then
                        port.Close()
                    End If
                    port.Dispose() ' Dispose of the SerialPort object

                End Try
            Next
            Thread.Sleep(5000)
        End While
    End Function



    ' This event handler is where the time-consuming work is done.
    Private Sub backgroundWorker1_DoWork(ByVal sender As System.Object,
    ByVal e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        Dim wait_time As Date = Now()

        Dim return_val As String = ""
        Dim command As String


        Dim counter As Integer = 0
        Dim good_Data As Boolean = False
        Dim Ascii_Value As Integer = 0
        Dim returnStr As String = ""
        Dim Incoming As String = ""
        Dim read_timeout_count As Integer = 0

        Dim com1 As SerialPort = open_port()
        com1.Open()

        ' Start the serial communications loop in the background worker thread
        Do While 1 = 1


            Database_Good = True


            'Open the serial port and send the .fd command to set the handheld reader to factory defaults
            Try


ConnectionStart:


                Try

                    Do While True ' Database_Good

                        ' WriteEvent("in while loop", EventInfo)
Retry:

                        ' If reconfig_reader Then GoTo ConnectionStart 'And Not pending_user


                        'WriteEvent("trying to read com1", EventInfo)
                        Incoming = com1.ReadLine()
                        ' WriteEvent("reading com1: " & Incoming, EventInfo)

                        ' TODO: add something to not let the user scan in more items
                        If Incoming IsNot Nothing Then
                            ' TODO: move if statement to a better spot
                            ' If lbl_Scan_Fail.Visible = True Then LabelUpdate(False)
                            read_timeout_count = 0

                            If Mid(Incoming, 1, 10) = "SW: single" Then
                                WriteEvent("Trigger press detected", EventInfo)
                                com1.WriteLine(".iv" & vbCr)
                            End If

                            If Mid(Incoming, 1, 2) = "EP" Then  ' When the reader sends tag data it is preceded by the two characters EP
                                Incoming = Mid(Incoming, 5, 24)
                                RSSI_Value = ""
                                RSSI_Value = com1.ReadLine()

                                'Do While RSSI_Value Is Nothing
                                '    RSSI_Value = com1.ReadLine()
                                'Loop


                                ' RSSI_Value = Mid(RSSI_Value, 6, 2)
                                ' MsgBox(Incoming + " // " + RSSI_Value)
                            End If

                            ' WriteEvent(RSSI_Value)
                            ' Dim RSSI_Int As String = RSSI_Value
                            ' MsgBox((Convert.ToInt16(RSSI_Int)).ToString)
                            ' If Convert.ToInt16(RSSI_Int) < 1000 Then
                            good_Data = True
                            For counter = 1 To Len(Incoming)
                                Ascii_Value = Asc(Mid(Incoming, counter, 1))
                                If counter = 1 Then
                                    If Ascii_Value < 65 Or Ascii_Value > 70 Or Ascii_Value = 69 Then  ' Check to make sure the tag data starts with A,B,C,D,F.  Leave out E because 
                                        good_Data = False                                             '  that is an employee tag
                                    End If
                                End If
                                'loop through tag checking for valid characters
                                If (Ascii_Value < 48) Or ((Ascii_Value > 57) And (Ascii_Value < 65)) Or ((Ascii_Value > 70) And (Ascii_Value < 97)) Or (Ascii_Value > 102) Then
                                    good_Data = False
                                End If
                            Next
                            ' If good data is detected put the RFID tag into a string variable and trigger the update from the background thread to the main user interface thread
                            If good_Data Then
                                RFID_Tag_Buffered = Incoming
                                worker.ReportProgress(1)

                            End If
                            ' End If

                            ' Consider Else statement to good data for false

                        End If


                    Loop

                Catch time_ex As TimeoutException
                    read_timeout_count += 1
                    If (read_timeout_count Mod 5) = 0 Then
                        com1.WriteLine(".bl")
                    End If

                    If read_timeout_count > 8 Then
                        If com1 IsNot Nothing Then com1.Close()
                        WriteEvent("No serial communications for over 4 seconds.  Attempt to reset port.", EventInfo)
                        ' If Not (pending_user Or reconfig_reader) Then LabelUpdate(True)

                        ' WriteEvent("visible", EventInfo)
                        Threading.Thread.Sleep(250)
                        com1 = My.Computer.Ports.OpenSerialPort(comm_port)
                        com1.ReadTimeout = 500
                        command = ".fd"
                        com1.WriteLine(command)
                        return_val = com1.ReadExisting()
                        command = ".iv -r on -o " & strength & " -p -n" ' added -p to return -fs on
                        ' TODO: look into -fs parameter and whether is is necessary
                        com1.WriteLine(command)
                        Threading.Thread.Sleep(250)
                        return_val = com1.ReadExisting()
                        WriteEvent(return_val, EventInfo)
                        com1.WriteLine(command)
                        Threading.Thread.Sleep(100)
                        GoTo Retry
                    Else
                        GoTo Retry
                    End If

                Catch ex As Exception
                    MsgBox(ex.ToString)



                End Try


            Catch ex As Exception
                If read_timeout_count > 180 Then
                    MsgBox("Error Opening Serial Port: " & comm_port & ex.Message, EventError)
                    WriteEvent("Error Opening Serial Port: " & comm_port & ex.Message, EventError)
                    Application.Exit()
                    Process.Start(Application.ExecutablePath)
                End If
                ' WriteEvent("Error Opening Serial Port: " & comm_port & ex.Message, EventError)
                ' If Not (pending_user Or reconfig_reader) Then LabelUpdate(True)


            End Try

            wait_time = DateAdd(DateInterval.Second, 0.125, Now())
            Do Until wait_time < Now()
            Loop

        Loop


    End Sub

    ' This event handler updates the progress.
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As System.Object,
    ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'This event is triggered from the background serial comms thread.  Transfer the RFID tag into a string variable once and do not allow the data to change until the screen
        ' is done updating
        If Screen_Updating = False Then
            RFID_Tag = RFID_Tag_Buffered
            Screen_Updating = True
            Update_Screen()
            Screen_Updating = False
        End If


    End Sub

    ' This event handler deals with the results of the background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            'resultLabel.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            'resultLabel.Text = "Error: " & e.Error.Message
        Else
            'resultLabel.Text = "Done!"
        End If
    End Sub




    Sub InitializeVariables()
        ' grab database information out of registry and register application with event log
        'Try
        '    EventLog.CreateEventSource(App_Name, "Application")
        'Catch ex As Exception
        '    If ex.Message <> "Source Shipping Reader already exists on the local computer." Then

        '        If User_Interaction Then
        '            MsgBox("Error Registering the app with the Event Viewer: " & ex.Message)
        '        End If
        '        WriteEvent("Error Registering the app with the Event Viewer: " & ex.Message, EventWarning)
        '    End If

        'End Try

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
                        comm_port = regpaintprocesskey.GetValue("Port1", "")
                        strength = regpaintprocesskey.GetValue("ReadStrength", "")
                        Station = regpaintprocesskey.GetValue("Station", "")
                    End If
                    regpaintprocesskey.Close()
                End If
                regoraclekey.Close()
            End If
            regsoftwarekey.Close()
        End If
        If strDBServer = "" Then
            If User_Interaction Then
                MsgBox("Database is not configured in the registry.")
            End If
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

        For Each dr As DataRow In picturetable.Tables("picture").Rows
            picturebox_Part.Image = Image.FromFile(Image_Share & dr("Image"), False)
        Next

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