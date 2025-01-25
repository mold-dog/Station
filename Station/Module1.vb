Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

' VB.net




Public Class SelectedTextBox

    Inherits System.Windows.Forms.TextBox

    Private Sub SelectedTextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter

        Me.SelectAll()

    End Sub



    Private Sub SelectedTextBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        Me.SelectAll()

    End Sub

End Class


Public Class UserPermissions

    Private show_location_screen As Boolean = False
    Public Property ShowLocationScreen As Boolean
        Get
            Return show_location_screen
        End Get
        Set(value As Boolean)
            show_location_screen = value
        End Set
    End Property

    Private johnson_creek As Boolean = False

    Public Property JohnsonCreek As Boolean
        Get
            Return johnson_creek
        End Get
        Set(value As Boolean)
            johnson_creek = value

            If johnson_creek And _mauston Then
                show_location_screen = True
            End If
        End Set
    End Property

    Private _mauston As Boolean = False

    Public Property Mauston As Boolean
        Get
            Return _mauston
        End Get
        Set(value As Boolean)
            _mauston = value
            If johnson_creek And _mauston Then
                show_location_screen = True
            End If
        End Set
    End Property


    Private ncm_entry As Integer = 0

    Public Property NCMEntry As Integer
        Get
            Return ncm_entry
        End Get
        Set(value As Integer)
            ncm_entry = value

        End Set
    End Property

End Class

Module Module1
    Public DBConnection As String
    Public DBConnection_t As String
    Public SQLCon As New SqlConnection
    Public SQLCon_t As New SqlConnection
    Public Computer As Boolean
    Public Image_Share As String

    ' Bool just to show defects in general
    Public Show_Paint_Defects As Boolean = True



    Public Create_New_Version As Boolean = False

    Public Defect_Form As Defect
    Public Login_Form As Login
    Public Main_Menu_Form As Main_Menu
    Public Paint_Conveyor_Form As Paint_Conveyor

    Public Door_Reader_Form As Door_Reader
    Public Area_Form As Area
    Public Defects_Form As Defects
    Public Defect_History_Form As Defect_History
    Public Paint_Color_Form As Paint_Color
    Public Paint_Color_Groups_Form As Paint_Color_Groups
    Public Final_Color_Form As Final_Color
    Public Part_Type_Form As Part_Type
    Public Stations_Form As Stations
    Public Styles_Form As Style
    Public Users_Form As Users
    Public Paint_Data_By_Area_Form As Paint_Data_By_Area
    Public Paint_Job_Process_Data_Form As Paint_Job_Process_Data
    Public Molding_Job_Process_Data_Form As Molding_Job_Process_Data
    Public Part_Tracking_Form As Part_Tracking
    Public Part_History_Form As Part_History
    Public Inventory_By_Area_Form As Inventory_By_Area
    Public Final_Part_Form As Final_Part
    Public Shifts_Form As Shifts
    Public Paint_Production_Query_Form As Paint_Production_Query
    Public Marriage_RFID_Query_Form As Marriage_RFID_Query
    Public Paint_Production_Parts_Query_Form As Paint_Production_Parts_Query
    Public Paint_Production_RFID_Query_Form As Paint_Production_RFID_Query
    Public Local_Read_Form As Local_Read
    Public Part_Form As Part
    Public Carrier_Info_Form As Carrier_Info
    Public Inventory_Control_Form As Inventory_Control
    Public Inspection_Form As Inspection
    Public RFID_Reader_Door_Form As RFID_Reader_Door
    Public Station_Defects_Form As Station_Defects
    Public Defects_By_Inspector_Form As Defects_By_Inspector
    Public Defect_Inspections_By_Inspector_Form As Defect_Inspections_by_Inspector
    Public Production_Defects_Form As Production_Defects
    Public Production_Inspections_Form As Production_Inspections
    Public Schedule_Production_Form As Schedule_Production
    Public Schedule_Shipping_Form As Schedule_Shipping
    Public Inventory_Form As Inventory
    Public Paint_Current_Run_Form As Paint_Current_Run
    Public Target_Time_Per_Part_Form As Target_Time_Per_Part
    Public Default_Schedule_Form As Default_Schedule
    Public Robot_Parts_Form As Robot_Parts
    Public Robot_Status_Form As Robot_Status
    Public Robot_Part_Change_Form As Robot_Part_Change
    Public Robot_Part_History_Form As Robot_Part_History
    Public Robot_Part_Defect_Form As Robot_Part_Defect
    Public Ethernet_Devices_Form As Ethernet_Devices
    Public Station_Pick_Form As Station_Pick
    Public Comm_Status_Form As Comm_Status
    Public Comm_Status_HCC_Form As Comm_Status_HCC
    Public Comm_Status_Three_Wheel_Form As Comm_Status_Three_Wheel
    Public Comm_Status_Wetsand_Form As Comm_Status_Wetsand
    Public Comm_Status_Assembly_Form As Comm_Status_Assembly
    Public Paint_Robot_Data_Form As Paint_Robot_Data
    Public Test_Panel_Form As Test_Panel
    Public Test_Panel_History_Form As Test_Panel_History
    Public change_operator_form As Change_Operator
    Public operator_info_form As Operator_Info
    Public part_inspection_counts_form As Part_Inspection_Counts
    Public Paint_Production_Quality_Form As Paint_Production_Quality
    Public Functional_Area_Form As Functional_Area
    Public Part_Type_Group_Form As Part_Type_Group
    Public Operator_Status_by_Time_Form As Operator_Status_by_Time
    Public Operator_Status_by_Part_Form As Operator_Status_by_Part
    Public Paint_Operator_Status_by_Date_Form As Paint_Operator_Status_by_Date
    Public Film_Check_History_Form As Film_Check_History
    Public Defect_by_Part_Type_Form As Defect_by_Part_Type
    Public FTQ_Summary_Form As FTQ_Summary
    Public FTB_Form As FTB
    Public FTB_by_Model_Form As FTB_by_Model
    Public Pinstripe_Productivity_Form As Pinstripe_Productivity
    Public TU_Productivity_Form As TU_Productivity
    Public TU_Quality_Form As TU_Quality
    Public Completed_to_Ship_Form As Completed_To_Ship
    Public Part_Status_History_Form As Part_Status_History
    Public Part_Inspection_History_Form As Part_Inspection_History
    Public Set_Color_Form As Set_Color
    Public Part_Defect_List_Form As Part_Defect_List
    Public Operator_Status_By_Function_Control_Form As Operator_Status_By_Function_Control
    Public Press_Alarms_Form As Press_Alarms
    Public Press_Alarms_History_Form As Press_Alarm_History
    Public Press_Status_Form As Press_Status
    Public Press_History_Form As Press_History
    Public Press_Summary_Form As Press_Summary
    Public Location_Corrections_Form As Location_Corrections
    Public mold_schedule_Form As Mold_Schedule
    Public mold_buffer_Form As Mold_Buffer
    Public Press_Produced_Form As Press_Produced
    Public Press_Users_Form As Press_Users
    Public Press_RFID_Form As Press_RFID
    Public Press_Counts_By_User_Form As Press_Counts_By_User
    Public Schedule_Status_Form As Schedule_Status
    Public Scrapped_Parts_Defects_Form As Scrapped_Parts_Defects
    Public Rate_Debug_Query_Form As Rate_Debug_Query
    Public Operator_Logins_Form As Operator_Logins
    Public New_RFID_Tag_Debug_Form As New_RFID_Tag_Debug
    Public Tag_Compare_Form As Tag_Compare
    Public Defect_RFID_Manual_Entry_Form As Defect_RFID_Manual_Entry
    Public Defect_RFID_Manual_Select_Form As Defect_RFID_Manual_Select
    Public Number_Keyboard_Form As Number_Keyboard
    Public Part_Position_Form As Part_Position
    Public PMC_Report_By_Resource_Form As PMC_Report_By_Resource
    Public PMC_History_By_Event_Form As PMC_History_By_Event
    Public NCM_Form As NCM_Entry


    Public Inspect_Part As Int64

    Public User_Permissions_User_Management As Boolean = False
    Public User_Permissions_Operator_Management As Boolean = False
    Public User_Permissions_Edit_Config As Boolean = False
    Public User_Permissions_View_Config As Boolean = False
    Public User_Permissions_Access_Targets As Boolean = False
    Public User_Permissions_Access_Paint_Area As Boolean = False
    Public User_Permissions_Access_Defects As Boolean = False
    Public User_Permissions_Access_Inspections As Boolean = False
    Public User_Permissions_Access_Part_Tracking As Boolean = False
    Public User_Permissions_Change_Robot_Parts As Boolean = False
    Public User_Permissions_Kill As Boolean = False
    Public User_Permissions_Access_Press_Area As Boolean = False
    Public User_Perms As New UserPermissions



    Public Station_Area As Integer = 0
    Public Station_Name As String = ""
    Public Station_ID As Integer = 0
    Public PLC_Station As Integer = 0
    Public USer_ID As Integer = 0
    Public Sub_Parameter As Integer = 0
    Public Defect_Tabs As Integer = 0
    Public Station_Requires_Color As Boolean = 0
    Public Operator_ID As Integer = 0
    Public Show_Wetsand As Boolean = False
    Public Show_Finesse As Boolean = False
    Public Show_Inspection As Boolean = False
    Public Compare_Part_ID_1 As Integer
    Public Compare_Part_ID_2 As Integer
    Public Auto_Scan_Refresh As Boolean = 0

    Public Spanish As Boolean = False

    Public Global_RFID As String = ""

    Public SQL_Timeout As Integer = 150

    Public FTB_Loaded As Boolean = False

    Public Enable_Paint_Defects As Boolean = False
    Public Enable_Finesse_Defects As Boolean = False
    Public Enable_Mold_Defects As Boolean = False
    Public Enable_Bond_Defects As Boolean = False
    Public Enable_Assembly_Defects As Boolean = False
    Public Enable_Finishing_Defects As Boolean = False


    Public Clear_Press_Operators As Boolean
    Public Manual_Prefix As String
    Public Manual_Suffix As String
    Public Manual_RFID As String
    Public Manual_Defect_Refresh As Boolean = False
    Public Manual_Refresh_Request As Boolean = False
    Public Part_Type_Pic As String
    Public Part_Type_Name As String
    Public Select_Part_Type As String
    Public Man_Entry_Title As String
    Public First_Four As String
    Public Last_Six As String
    Public No_Readable_Code As String
    Public Accept_Exit As String
    Public Clear_Exit As String
    Public Accept As String
    Public Exit_Button_Text As String
    Public Six_Character_Msg As String
    Public Part_Pos_Form_Open As Boolean
    Public Part_Type_Positions As Integer
    Public Part_Position_RFID As String
    Public Part_Position_Title As String
    Public Part_Position_Msg As String


    Public HRes As Integer = 1920
    Public VRes As Integer = 1080

    Public Const EventError As Integer = 1
    Public Const EventWarning As Integer = 2
    Public Const EventInfo As Integer = 3

    Const App_Name As String = "RFID Station"



    Sub main()


        Try

            'WriteEvent("yeeeeehaw", EventError)

            InitializeVariables()




            SQLCon.ConnectionString = DBConnection
            Call Check_Station()


            If Station_ID = 0 Then

                ' Dim location_screen As New Location_Select

                Call Check_User()

                'If System.Environment.MachineName.Contains("Station") Then
                '    location_screen.Show()
                '    While location_screen.SelectedLocation = ""

                '    End While



                'End If

            End If

        Catch Ex As Exception

            MsgBox("Error Initializing Program: " & Ex.Message)
        End Try

    End Sub


    Sub Check_Station()
        Dim found As Boolean = False
        Dim screen_Name As String = ""

        Try
            SQLCon.Open()

            Dim daStation_Data As New SqlDataAdapter("Select * from Station where Client_Name = '" & System.Environment.MachineName & "'", SQLCon)
            daStation_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsStation As New DataSet
            daStation_Data.Fill(dsStation, "Station")
            SQLCon.Close()

            For Each drStation As DataRow In dsStation.Tables("Station").Rows

                ' This does not catch null values
                Station_Area = drStation("area")
                Station_Name = drStation("Description")
                Station_ID = drStation("ID")
                PLC_Station = drStation("PLC_Station_Number")
                Sub_Parameter = drStation("Screen_sub_parameter")

                Station_Requires_Color = drStation("Require_Color")


                Show_Paint_Defects = drStation("Show_Paint_Defects")
                ' Set bools for what defects may be shown, sets to false if a null is returned (default is False)
                If Not IsDBNull(drStation("Enable_Paint_Defects")) Then
                    Enable_Paint_Defects = drStation("Enable_Paint_Defects")
                End If
                If Not IsDBNull(drStation("Enable_Finesse_Defects")) Then
                    Enable_Finesse_Defects = drStation("Enable_Finesse_Defects")
                End If
                If Not IsDBNull(drStation("Enable_Mold_Defects")) Then
                    Enable_Mold_Defects = drStation("Enable_Mold_Defects")
                End If
                If Not IsDBNull(drStation("Enable_Bond_Defects")) Then
                    Enable_Bond_Defects = drStation("Enable_Bond_Defects")
                End If
                If Not IsDBNull(drStation("Enable_Assembly_Defects")) Then
                    Enable_Assembly_Defects = drStation("Enable_Assembly_Defects")
                End If
                If Not IsDBNull(drStation("Enable_Finishing_Defects")) Then
                    Enable_Finishing_Defects = drStation("Enable_Finishing_Defects")
                End If


                Create_New_Version = drStation("Create_New_Version")
                If Not IsDBNull(drStation("Show_Wetsand")) Then
                    Show_Wetsand = drStation("Show_Wetsand")
                Else
                    Show_Wetsand = True
                End If
                If Not IsDBNull(drStation("Show_Finesse")) Then
                    Show_Finesse = drStation("Show_Finesse")
                Else
                    Show_Finesse = True
                End If
                If Not IsDBNull(drStation("Show_Inspection")) Then
                    Show_Inspection = drStation("Show_Inspection")
                Else
                    Show_Inspection = True
                End If
                If Not IsDBNull(drStation("Scan_Auto_Refresh")) Then
                    Auto_Scan_Refresh = drStation("Scan_Auto_Refresh")
                Else
                    Auto_Scan_Refresh = False
                End If

                screen_Name = drStation("Screen_Name") & ""
                Select Case screen_Name
                    Case "Area Quality Status"
                        Operator_Status_By_Function_Control_Form = New Operator_Status_By_Function_Control
                        Operator_Status_By_Function_Control_Form.WindowState = FormWindowState.Maximized
                        Operator_Status_By_Function_Control_Form.ShowDialog()
                    Case "Completed to Ship"
                        Completed_to_Ship_Form = New Completed_To_Ship
                        Paint_Conveyor_Form.WindowState = FormWindowState.Maximized
                        Completed_to_Ship_Form.ShowDialog()
                    Case "Defect"

                        'If Show_Paint_Defects Then
                        'Enable_Finesse_Defects = False
                        'Else
                        'Enable_Paint_Defects = False
                        'End If

                        Defect_Tabs = Val(drStation("tabs") & "")
                        Defect_Form = New Defect
                        Defect_Form.WindowState = FormWindowState.Maximized

                        If Not IsDBNull(drStation("Training_Station")) Then
                            If drStation("Training_Station") Then
                                Defect_Form.TrainingStation = True
                            End If
                        End If

                        Defect_Form.ShowDialog()
                    Case "Inventory by Area"
                        Inventory_By_Area_Form = New Inventory_By_Area
                        Inventory_By_Area_Form.WindowState = FormWindowState.Maximized
                        Inventory_By_Area.ShowDialog()
                    Case "Paint Conveyor"
                        Paint_Conveyor_Form = New Paint_Conveyor
                        Paint_Conveyor_Form.WindowState = FormWindowState.Maximized
                        Paint_Conveyor_Form.ShowDialog()
                    Case "Robot Status"
                        Robot_Status_Form = New Robot_Status
                        Robot_Status_Form.ShowDialog()
                    Case "FTB"
                        FTB_Form = New FTB
                        FTB_Form.WindowState = FormWindowState.Maximized
                        FTB_Form.ShowDialog()
                    Case "Press"
                        Press_Status_Form = New Press_Status
                        Press_Status_Form.WindowState = FormWindowState.Maximized
                        Press_Status_Form.ShowDialog()
                    Case "Mold Buffer"
                        mold_buffer_Form = New Mold_Buffer
                        mold_buffer_Form.WindowState = FormWindowState.Maximized
                        mold_buffer_Form.ShowDialog()
                    Case "Press Summary"
                        Press_Summary_Form = New Press_Summary
                        Press_Summary_Form.WindowState = FormWindowState.Maximized
                        Press_Summary_Form.ShowDialog()
                    Case "Current Run"
                        Paint_Current_Run_Form = New Paint_Current_Run
                        Paint_Current_Run_Form.WindowState = FormWindowState.Maximized
                        Paint_Current_Run_Form.ShowDialog()

                    Case "RFID Display"
                        Press_Summary_Form = New Press_Summary
                        Press_Summary_Form.WindowState = FormWindowState.Maximized
                        Press_Summary_Form.ShowDialog()

                        Paint_Conveyor_Form = New Paint_Conveyor
                        Paint_Conveyor_Form.WindowState = FormWindowState.Maximized
                        Paint_Conveyor_Form.ShowDialog()
                End Select

                found = True
            Next
            If Not found Then
                '                MsgBox("Computer not found in Station Table.  Computer Name: " & System.Environment.MachineName)

            End If


        Catch Ex As Exception

            MsgBox("Error Getting Station from Database: " & Ex.Message)
        End Try
    End Sub
    Sub Check_User()
        Dim found As Boolean = False

        Try
            found = Verify_User(System.Environment.UserName)

            If Not found Then
                Login_Form = New Login
                Login_Form.ShowDialog()
            Else

                Dim location_screen As Location_Select = New Location_Select
                location_screen.JohnsonCreek = User_Perms.JohnsonCreek
                location_screen.Mauston = User_Perms.Mauston
                location_screen.NCMEntry = User_Perms.NCMEntry

                If User_Perms.ShowLocationScreen Or User_Perms.NCMEntry Then
                    ' TODO: change what buttons based on configs

                    location_screen.ShowDialog()
                    If location_screen.SelectedLocation = "Johnson Creek" Or location_screen.SelectedLocation = "Mauston" Then
                        Main_Menu_Form = New Main_Menu
                        Main_Menu_Form.ShowDialog()

                    ElseIf location_screen.SelectedLocation <> "" Then


                        NCM_Form = New NCM_Entry

                        NCM_Form.CustomerLocation = location_screen.SelectedLocation
                        NCM_Form.ShowDialog()

                    End If
                Else

                    Main_Menu_Form = New Main_Menu
                    Main_Menu_Form.ShowDialog()


                End If




            End If







        Catch Ex As Exception

            MsgBox("Error Getting User Info from Database: " & Ex.Message)
        End Try
    End Sub
    Public Function Verify_User(ByVal UserName As String, Optional ByVal Password As String = "") As Boolean
        Dim found As Boolean = False
        Dim query As String = ""

        If Len(Password) > 0 Then
            query = "Select * from Users where User_Name = '" & UserName & "' and password = '" & Password & "'"
        Else
            query = "Select * from Users where User_Name = '" & UserName & "'"
        End If

        Try
            SQLCon.Open()
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Users")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Users").Rows
                found = True
                User_Permissions_User_Management = IIf(IsDBNull(dr("User_Management")), 0, dr("User_Management"))
                User_Permissions_Operator_Management = IIf(IsDBNull(dr("Operator_Management")), 0, dr("Operator_Management"))
                User_Permissions_Edit_Config = IIf(IsDBNull(dr("Edit_Config")), 0, dr("Edit_Config"))
                User_Permissions_View_Config = IIf(IsDBNull(dr("View_Config")), 0, dr("View_Config"))
                User_Permissions_Access_Targets = IIf(IsDBNull(dr("Access_Targets")), 0, dr("Access_Targets"))
                User_Permissions_Access_Paint_Area = IIf(IsDBNull(dr("Access_Paint_Area")), 0, dr("Access_Paint_Area"))
                User_Permissions_Access_Part_Tracking = IIf(IsDBNull(dr("Access_Part_Tracking")), 0, dr("Access_Part_Tracking"))
                User_Permissions_Access_Defects = IIf(IsDBNull(dr("Access_Defects")), 0, dr("Access_Defects"))
                User_Permissions_Access_Inspections = IIf(IsDBNull(dr("Access_Inspections")), 0, dr("Access_Inspections"))
                User_Permissions_Change_Robot_Parts = IIf(IsDBNull(dr("Change_Robot_Parts")), 0, dr("Change_Robot_Parts"))
                User_Permissions_Kill = IIf(IsDBNull(dr("Access_Kill")), 0, dr("Access_Kill"))
                User_Permissions_Access_Press_Area = IIf(IsDBNull(dr("Access_Press_Area")), 0, dr("Access_Press_Area"))
                USer_ID = dr("ID")
                User_Perms.JohnsonCreek = IIf(IsDBNull(dr("Johnson_Creek")), 0, dr("Johnson_Creek"))
                User_Perms.Mauston = IIf(IsDBNull(dr("Mauston")), 0, dr("Mauston"))
                User_Perms.NCMEntry = IIf(IsDBNull(dr("NCM_Entry")), 0, dr("NCM_Entry"))

            Next
        Catch Ex As Exception

            MsgBox("Error Getting User Info from Database: " & Ex.Message)


        End Try
        Return found
    End Function
    Sub InitializeVariables()

        ' grab database information out of registry and register application with event log

        Dim strDBServer As String = ""
        Dim strDBUID As String = ""
        Dim strDBpassword As String = ""
        Dim strHRes As String = ""
        Dim strVRes As String = ""



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
                        strHRes = regpaintprocesskey.GetValue("HRes", "1920")
                        strVRes = regpaintprocesskey.GetValue("VRes", "1080")
                    End If
                    regpaintprocesskey.Close()
                End If
                regoraclekey.Close()
            Else
                strDBServer = "192.168.15.253"
                strDBUID = "VB_Client"
                strDBpassword = "RFID123$"
            End If
            regsoftwarekey.Close()
        End If
        DBConnection = "Server=" + strDBServer + ";uid=" + strDBUID + ";pwd=" + strDBpassword + ";database=RFID;Connection Timeout=30;"

        DBConnection_t = "Server=" + strDBServer + ";uid=" + strDBUID + ";pwd=" + strDBpassword + ";database=RFID_t;Connection Timeout=30;"
        Image_Share = "\\" & strDBServer & "\Images\"
        'Image_Share = "C:\Images\"
        If IsNumeric(strHRes) Then
            HRes = Val(strHRes)
        End If
        If IsNumeric(strVRes) Then
            VRes = Val(strVRes)
        End If

    End Sub

    Public Function GetData(ByVal sqlCommand As String) As DataTable

        Dim command As New SqlCommand(sqlCommand, SQLCon)
        command.CommandTimeout = 900
        Dim adapter As SqlDataAdapter = New SqlDataAdapter()
        adapter.SelectCommand = command

        Dim table As New DataTable
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)

        Return table

    End Function

    Public Function get_operator(ByVal operator_string As String) As String
        Dim Operator_ID As Integer
        Dim query As String
        Dim operator_name As String = ""


        Try

            If operator_string <> "" Then
                Operator_ID = Int(operator_string)
                If Operator_ID > 0 Then
                    SQLCon.ConnectionString = DBConnection
                    SQLCon.Open()

                    query = "Select name from operator where id = " & Operator_ID

                    Dim da As New SqlDataAdapter(query, SQLCon)
                    da.SelectCommand.CommandTimeout = SQL_Timeout
                    Dim ds As New DataSet
                    da.Fill(ds, "operator")
                    SQLCon.Close()

                    For Each dr As DataRow In ds.Tables("operator").Rows
                        operator_name = dr("name") & ""
                    Next

                End If
            End If
            Return operator_name
        Catch ex As Exception
            Return ""
        End Try


    End Function

    Sub WriteEvent(ByVal msg As String, Optional ByVal Style As Int16 = 1, Optional ByVal Error_Number As Int16 = 1000)
        'Style is defined as 1 = Error, 2 = Warning, 3 = Information
        Dim EvLog As New EventLog("Application", ".", App_Name)
        Try

            'Register the Application as an Event Source
            If Not EventLog.SourceExists(App_Name) Then
                EventLog.CreateEventSource(App_Name, "Application")
            End If



            'log the entry
            EvLog.Source = App_Name

            Select Case Style

                Case EventError
                    EvLog.WriteEntry(msg, EventLogEntryType.Error, Error_Number)
                Case EventWarning
                    EvLog.WriteEntry(msg, EventLogEntryType.Warning, Error_Number)
                Case EventInfo
                    EvLog.WriteEntry(msg, EventLogEntryType.Information, Error_Number)
                Case Else
                    EvLog.WriteEntry(msg, EventLogEntryType.Error, Error_Number)

                    'Case EventError
                    '    EvLog.WriteEntry(msg, EventLogEntryType.Error, Error_Number)
                    'Case EventWarning
                    '    EvLog.WriteEntry(msg, EventLogEntryType.Warning, Error_Number)
                    'Case EventInfo
                    '    EvLog.WriteEntry(msg, EventLogEntryType.Information, Error_Number)
                    'Case Else
                    '    EvLog.WriteEntry(msg, EventLogEntryType.Error, Error_Number)
            End Select


        Catch Ex As Exception

            Return

        End Try
        'Select Case Style
        '    Case EventError
        '        EvLog.WriteEntry(msg, EventLogEntryType.Error, Error_Number)
        '    Case EventWarning
        '        EvLog.WriteEntry(msg, EventLogEntryType.Warning, Error_Number)
        '    Case EventInfo
        '        EvLog.WriteEntry(msg, EventLogEntryType.Information, Error_Number)
        '    Case Else
        '        EvLog.WriteEntry(msg, EventLogEntryType.Error, Error_Number)
        'End Select

    End Sub
End Module
