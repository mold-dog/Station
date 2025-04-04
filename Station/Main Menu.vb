Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Main_Menu


    'Public Const BSF_IGNORECURRENTTASK As Byte = 2 '&H2 'this ignores the current app
    'Public Const BSF_POSTMESSAGE As Byte = 16 '&H10  'This posts the message
    'Public Const BSM_APPLICATIONS As Byte = 8 '&H8  'This tells the windows message to just go to applications
    'Public MessageId As Integer
    'Private m_Mutex As System.Threading.Mutex 'Used to determine if the application is already open
    'Private m_uniqueIdentifier As String = String.Empty 'user to determine if the app is already open

    '<DllImport("USER32.DLL", EntryPoint:="BroadcastSystemMessageA",
    '   SetLastError:=True, CharSet:=CharSet.Unicode,
    '   ExactSpelling:=True,
    '   CallingConvention:=CallingConvention.StdCall)>
    'Public Shared Function BroadcastSystemMessage(ByVal dwFlags As Int32, ByRef pdwRecipients As Int32, ByVal uiMessage As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '    ' Leave function empty - DLLImport attribute forwards calls to BroadcastSystemMessage to
    '    ' BroadcastSystemMessage in USER32.DLL.
    'End Function
    '<DllImport("USER32.DLL", EntryPoint:="RegisterWindowMessageA",
    '   SetLastError:=True, CharSet:=CharSet.Unicode,
    '   ExactSpelling:=True,
    '   CallingConvention:=CallingConvention.StdCall)>
    'Public Shared Function RegisterWindowMessage(ByVal pString As String) As Integer
    '    ' Leave function empty - DLLImport attribute forwards calls to RegisterWindowMessage to
    '    ' RegisterWindowMessage in USER32.DLL.
    'End Function
    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        End
    End Sub

    Private Sub Btn_Defect_Click(sender As Object, e As EventArgs)
        Defect_Form = New Defect
        Defect_Form.Show()
    End Sub

    Private Sub Main_Menu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Version - " & System.Windows.Forms.Application.ProductVersion.ToString & "  Main Menu"

        'checkprevious()
        Btn_Paint_Coveyor.Enabled = User_Permissions_Access_Paint_Area
        Btn_Paint_Data.Enabled = User_Permissions_Access_Paint_Area
        Btn_Paint_Production.Enabled = User_Permissions_Access_Paint_Area
        Btn_Paint_Current_Run.Enabled = User_Permissions_Access_Paint_Area
        Btn_Robot_Data.Enabled = User_Permissions_Access_Paint_Area
        Btn_Robot_Part_History.Enabled = User_Permissions_Access_Paint_Area
        Btn_Robot_Part_Defects.Enabled = User_Permissions_Access_Paint_Area
        Btn_Test_Panels.Enabled = User_Permissions_Access_Paint_Area
        Btn_Test_Panel_History.Enabled = User_Permissions_Access_Paint_Area
        Btn_Film_Check_History.Enabled = User_Permissions_Access_Paint_Area

        Btn_Production_Defects.Enabled = User_Permissions_Access_Defects
        Btn_Production_Inspections.Enabled = User_Permissions_Access_Defects
        Btn_Defects_By_Inspector.Enabled = User_Permissions_Access_Defects
        Btn_Defect_Inspections_by_Inspector.Enabled = User_Permissions_Access_Defects
        btn_Paint_Run_Quality.Enabled = User_Permissions_Access_Defects
        Btn_Area_Quality_Status.Enabled = User_Permissions_Access_Defects
        Btn_Area_Quality_History.Enabled = User_Permissions_Access_Defects
        Btn_Defect_By_Part_Type.Enabled = User_Permissions_Access_Defects
        Btn_FTQ_Summary.Enabled = User_Permissions_Access_Defects
        Btn_Pinstripe_Productivity.Enabled = User_Permissions_Access_Defects
        Btn_TU_Productivity.Enabled = User_Permissions_Access_Defects
        Btn_TU_Quality.Enabled = User_Permissions_Access_Defects
        Btn_Part_Defect_List.Enabled = User_Permissions_Access_Defects
        Btn_FTB.Enabled = User_Permissions_Access_Defects
        Btn_FTB_by_Model.Enabled = User_Permissions_Access_Defects
        Btn_Paint_Operator_Quality.Enabled = User_Permissions_Access_Defects
        Btn_Scrapped_Parts.Enabled = User_Permissions_Access_Defects
        Btn_Parts.Enabled = User_Permissions_Access_Defects

        Btn_Inventory_By_Area.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Inventory_Control.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Inventory.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Inspection_Counts.Enabled = User_Permissions_Access_Part_Tracking
        Btn_Location_Corrections.Enabled = User_Permissions_Access_Part_Tracking

        Btn_Press_Alarms.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_Alarm_History.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_Summary.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_Status.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_History.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_Counts.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_Users.Enabled = User_Permissions_Access_Press_Area
        Btn_Press_RFID.Enabled = User_Permissions_Access_Press_Area



        Btn_Users.Enabled = User_Permissions_User_Management
        Btn_Operators.Enabled = User_Permissions_Operator_Management

        Btn_Robot_Part_Change.Enabled = User_Permissions_Change_Robot_Parts

        Btn_Areas.Enabled = User_Permissions_View_Config
        Btn_Final_Colors.Enabled = User_Permissions_View_Config
        Btn_Paint_Color.Enabled = User_Permissions_View_Config
        Btn_Part_Types.Enabled = User_Permissions_View_Config
        Btn_Stations.Enabled = User_Permissions_View_Config
        Btn_Styles.Enabled = User_Permissions_View_Config
        Btn_Final_Parts.Enabled = User_Permissions_View_Config
        Btn_Defects.Enabled = User_Permissions_View_Config
        Btn_Door_Reads.Enabled = User_Permissions_View_Config
        Btn_Shifts.Enabled = User_Permissions_View_Config
        Btn_Door_Readers.Enabled = User_Permissions_View_Config
        Btn_Devices.Enabled = User_Permissions_View_Config
        Btn_Robot_Parts.Enabled = User_Permissions_View_Config
        Btn_Part_Type_Groups.Enabled = User_Permissions_View_Config
        Btn_Functional_Areas.Enabled = User_Permissions_View_Config
        Btn_RFID_Tag_Compare.Enabled = User_Permissions_View_Config

        Btn_Production_Schedule.Enabled = User_Permissions_Access_Targets
        Btn_Shipping_Schedule.Enabled = User_Permissions_Access_Targets
        Btn_Tartget_Time_per_Part.Enabled = User_Permissions_Access_Targets
        btn_Completed_to_Ship.Enabled = User_Permissions_Access_Targets
        Btn_Mold_Schedule.Enabled = User_Permissions_Access_Targets
        Btn_Mold_Buffer.Enabled = User_Permissions_Access_Targets


        'WriteEvent("Error Registering the app with the Event Viewer: " & ex.Message, EventWarning)

        WriteEvent("RFID App Running", EventWarning)
        Call Comm_Status()
        Call Screen_Status()


    End Sub

    Private Sub Btn_Paint_Coveyor_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Coveyor.Click
        Paint_Conveyor_Form = New Paint_Conveyor
        Paint_Conveyor_Form.Show()
    End Sub

    Private Sub Btn_Door_Reads_Click(sender As Object, e As EventArgs) Handles Btn_Door_Reads.Click
        Door_Reader_Form = New Door_Reader
        Door_Reader_Form.Show()

    End Sub

    Private Sub Btn_Areas_Click(sender As Object, e As EventArgs) Handles Btn_Areas.Click
        Area_Form = New Area
        Area_Form.Show()

    End Sub

    Private Sub Btn_Defects_Click(sender As Object, e As EventArgs) Handles Btn_Defects.Click
        Defects_Form = New Defects
        Defects_Form.Show()
    End Sub

    Private Sub Btn_Paint_Color_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Color.Click
        Paint_Color_Form = New Paint_Color
        Paint_Color_Form.Show()

    End Sub

    Private Sub Btn_Paint_Color_Groups_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Color_Groups.Click
        Paint_Color_Groups_Form = New Paint_Color_Groups
        Paint_Color_Groups_Form.Show()

    End Sub

    Private Sub Btn_Final_Colors_Click(sender As Object, e As EventArgs) Handles Btn_Final_Colors.Click
        Final_Color_Form = New Final_Color
        Final_Color_Form.Show()

    End Sub

    Private Sub Btn_Part_Types_Click(sender As Object, e As EventArgs) Handles Btn_Part_Types.Click
        Part_Type_Form = New Part_Type
        Part_Type_Form.Show()

    End Sub

    Private Sub Btn_Stations_Click(sender As Object, e As EventArgs) Handles Btn_Stations.Click
        Stations_Form = New Stations
        Stations_Form.Show()

    End Sub

    Private Sub Btn_Styles_Click(sender As Object, e As EventArgs) Handles Btn_Styles.Click
        Styles_Form = New Style
        Styles_Form.Show()

    End Sub

    Private Sub Btn_Users_Click(sender As Object, e As EventArgs) Handles Btn_Users.Click
        Users_Form = New Users
        Users_Form.Show()

    End Sub

    Private Sub Btn_Paint_Data_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Data.Click
        Paint_Data_By_Area_Form = New Paint_Data_By_Area
        Paint_Data_By_Area_Form.Show()

    End Sub

    Private Sub Btn_Process_Data_Click(sender As Object, e As EventArgs)
        Paint_Job_Process_Data_Form = New Paint_Job_Process_Data
        Paint_Job_Process_Data_Form.Show()

    End Sub

    Private Sub Btn_Part_Tracking_Click(sender As Object, e As EventArgs)
        Part_Tracking_Form = New Part_Tracking
        Part_Tracking_Form.Show()

    End Sub

    Private Sub Btn_Inventory_By_Area_Click(sender As Object, e As EventArgs) Handles Btn_Inventory_By_Area.Click
        Inventory_By_Area_Form = New Inventory_By_Area
        Inventory_By_Area_Form.Show()

    End Sub

    Private Sub Btn_Final_Parts_Click(sender As Object, e As EventArgs) Handles Btn_Final_Parts.Click
        Final_Part_Form = New Final_Part
        Final_Part_Form.Show()

    End Sub

    Private Sub Btn_Shifts_Click(sender As Object, e As EventArgs) Handles Btn_Shifts.Click
        Shifts_Form = New Shifts
        Shifts_Form.Show()

    End Sub

    Private Sub Btn_Paint_Production_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Production.Click
        Paint_Production_Query_Form = New Paint_Production_Query
        Paint_Production_Query_Form.Show()

    End Sub



    Private Sub Btn_Parts_Click(sender As Object, e As EventArgs) Handles Btn_Parts.Click
        Part_Form = New Part
        Part_Form.Show()

    End Sub

    Private Sub Btn_Inventory_Control_Click(sender As Object, e As EventArgs) Handles Btn_Inventory_Control.Click
        Inventory_Control_Form = New Inventory_Control
        Inventory_Control_Form.Show()

    End Sub

    Private Sub Btn_Inspection_Click(sender As Object, e As EventArgs)
        Inspection_Form = New Inspection
        Inspection_Form.Show()

    End Sub

    Private Sub Btn_Door_Readers_Click(sender As Object, e As EventArgs) Handles Btn_Door_Readers.Click
        RFID_Reader_Door_Form = New RFID_Reader_Door
        RFID_Reader_Door_Form.Show()

    End Sub

    Private Sub Btn_Defect_History_Click(sender As Object, e As EventArgs)
        Defect_History_Form = New Defect_History
        Defect_History_Form.Show()

    End Sub

    Private Sub Btn_Production_Defects_Click(sender As Object, e As EventArgs) Handles Btn_Production_Defects.Click
        Production_Defects_Form = New Production_Defects
        Production_Defects_Form.Show()

    End Sub

    Private Sub Btn_Station_Defects_Click(sender As Object, e As EventArgs)

        MsgBox("The station defects screen is still under construction.")
        'Station_Defects_Form = New Station_Defects
        'Station_Defects_Form.Show()

    End Sub

    Private Sub Btn_Defects_By_Inspector_Click(sender As Object, e As EventArgs) Handles Btn_Defects_By_Inspector.Click
        Defects_By_Inspector_Form = New Defects_By_Inspector
        Defects_By_Inspector_Form.Show()

    End Sub

    Private Sub Btn_Defect_Inspections_by_Inspector_Click(sender As Object, e As EventArgs) Handles Btn_Defect_Inspections_by_Inspector.Click
        Defect_Inspections_By_Inspector_Form = New Defect_Inspections_by_Inspector
        Defect_Inspections_By_Inspector_Form.Show()
    End Sub

    Private Sub Btn_Production_Inspections_Click(sender As Object, e As EventArgs) Handles Btn_Production_Inspections.Click
        Production_Inspections_Form = New Production_Inspections
        Production_Inspections_Form.Show()
    End Sub

    Private Sub Btn_Production_Schedule_Click(sender As Object, e As EventArgs) Handles Btn_Production_Schedule.Click
        Schedule_Production_Form = New Schedule_Production
        Schedule_Production_Form.Show()
    End Sub

    Private Sub Btn_Shipping_Schedule_Click(sender As Object, e As EventArgs) Handles Btn_Shipping_Schedule.Click
        Schedule_Shipping_Form = New Schedule_Shipping
        Schedule_Shipping_Form.Show()
    End Sub

    Private Sub Btn_Inventory_Click(sender As Object, e As EventArgs) Handles Btn_Inventory.Click
        Inventory_Form = New Inventory
        Inventory_Form.Show()

    End Sub

    Private Sub Btn_Paint_Current_Run_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Current_Run.Click
        Paint_Current_Run_Form = New Paint_Current_Run
        Paint_Current_Run_Form.Show()

    End Sub

    Private Sub Btn_Tartget_Time_per_Part_Click(sender As Object, e As EventArgs) Handles Btn_Tartget_Time_per_Part.Click
        Target_Time_Per_Part_Form = New Target_Time_Per_Part
        Target_Time_Per_Part_Form.Show()


    End Sub

    Private Sub Btn_Default_Schedule_Click(sender As Object, e As EventArgs)
        Default_Schedule_Form = New Default_Schedule
        Default_Schedule_Form.Show()


    End Sub

    Private Sub Btn_Devices_Click(sender As Object, e As EventArgs) Handles Btn_Devices.Click
        Ethernet_Devices_Form = New Ethernet_Devices
        Ethernet_Devices_Form.Show()

    End Sub

    Private Sub Btn_Robot_Parts_Click(sender As Object, e As EventArgs) Handles Btn_Robot_Parts.Click
        Robot_Parts_Form = New Robot_Parts
        Robot_Parts_Form.Show()

    End Sub

    Private Sub Btn_Robot_Part_Change_Click(sender As Object, e As EventArgs) Handles Btn_Robot_Part_Change.Click
        Robot_Status_Form = New Robot_Status
        Robot_Status_Form.Show()

    End Sub

    Private Sub Comm_Check_Timer_Tick(sender As Object, e As EventArgs) Handles Comm_Check_Timer.Tick

        Call Comm_Status()
        Call Screen_Status()
    End Sub

    Private Sub Comm_Status()


        Dim counter As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select sum(IIF(status = 1, 1, 0)) as warning, sum(IIF(status = 2, 1, 0)) as fault from Reader_Comm_Status inner join Station on Station.PLC_Station_Number = Reader_Comm_Status.Station where isnull(inactivity_alarm,0) = 1", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Reader_Comm_Status")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Reader_Comm_Status").Rows
                lbl_Comm_Status.Text = dr("warning") & " Warnings, " & dr("fault") & " Faults"
            Next

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True


            '            MsgBox("Error Getting Comm status Info from Database: " & Ex.Message)
        End Try

    End Sub
    Private Sub Screen_Status()


        Dim counter As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select count(1) as screen_count from station where isnull(inactivity_alarm,0) = 1 and last_response < dateadd(minute,-5,getdate())", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Reader_Comm_Status")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Reader_Comm_Status").Rows
                Lbl_Screen_Status.Text = dr("screen_count") & " Screens Not Communicating"
            Next

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True


            '            MsgBox("Error Getting Comm status Info from Database: " & Ex.Message)
        End Try

    End Sub

    Private Sub Btn_Comm_Status_Click(sender As Object, e As EventArgs) Handles Btn_Comm_Status.Click
        Comm_Status_Form = New Comm_Status
        Comm_Status_Form.Show()

    End Sub

    Private Sub Btn_Robot_Data_Click(sender As Object, e As EventArgs) Handles Btn_Robot_Data.Click
        Paint_Robot_Data_Form = New Paint_Robot_Data
        Paint_Robot_Data_Form.Show()

    End Sub

    Private Sub Btn_Test_Panels_Click(sender As Object, e As EventArgs) Handles Btn_Test_Panels.Click
        Test_Panel_Form = New Test_Panel
        Test_Panel_Form.Show()
    End Sub

    Private Sub Btn_Test_Panel_History_Click(sender As Object, e As EventArgs) Handles Btn_Test_Panel_History.Click
        Test_Panel_History_Form = New Test_Panel_History
        Test_Panel_History_Form.Show()
    End Sub

    Private Sub Btn_Operators_Click(sender As Object, e As EventArgs) Handles Btn_Operators.Click
        operator_info_form = New Operator_Info
        operator_info_form.Show()
    End Sub

    Private Sub Btn_Inspection_Counts_Click(sender As Object, e As EventArgs) Handles Btn_Inspection_Counts.Click
        part_inspection_counts_form = New Part_Inspection_Counts
        part_inspection_counts_form.Show()
    End Sub

    Private Sub btn_Paint_Run_Quality_Click(sender As Object, e As EventArgs) Handles btn_Paint_Run_Quality.Click
        Paint_Production_Quality_Form = New Paint_Production_Quality
        Paint_Production_Quality_Form.Show()

    End Sub

    Private Sub Btn_Part_Type_Groups_Click(sender As Object, e As EventArgs) Handles Btn_Part_Type_Groups.Click
        Part_Type_Group_Form = New Part_Type_Group
        Part_Type_Group_Form.Show()

    End Sub

    Private Sub Btn_Functional_Areas_Click(sender As Object, e As EventArgs) Handles Btn_Functional_Areas.Click
        Functional_Area_Form = New Functional_Area
        Functional_Area_Form.Show()

    End Sub

    Private Sub Btn_Area_Quality_Status_Click(sender As Object, e As EventArgs) Handles Btn_Area_Quality_Status.Click
        Operator_Status_By_Function_Control_Form = New Operator_Status_By_Function_Control
        Operator_Status_By_Function_Control_Form.Show()
    End Sub

    Private Sub Btn_Film_Check_History_Click(sender As Object, e As EventArgs) Handles Btn_Film_Check_History.Click
        Film_Check_History_Form = New Film_Check_History
        Film_Check_History_Form.Show()
    End Sub

    Private Sub Btn_Area_Quality_History_Click(sender As Object, e As EventArgs) Handles Btn_Area_Quality_History.Click
        Operator_Status_by_Time_Form = New Operator_Status_by_Time
        Operator_Status_by_Time_Form.Show()

    End Sub

    Private Sub Btn_Defect_By_Part_Type_Click(sender As Object, e As EventArgs) Handles Btn_Defect_By_Part_Type.Click
        Defect_by_Part_Type_Form = New Defect_by_Part_Type
        Defect_by_Part_Type_Form.Show()
    End Sub

    Private Sub Btn_FTQ_Summary_Click(sender As Object, e As EventArgs) Handles Btn_FTQ_Summary.Click
        FTQ_Summary_Form = New FTQ_Summary
        FTQ_Summary_Form.Show()
    End Sub

    Private Sub Btn_Pinstripe_Productivity_Click(sender As Object, e As EventArgs) Handles Btn_Pinstripe_Productivity.Click
        Pinstripe_Productivity_Form = New Pinstripe_Productivity
        Pinstripe_Productivity_Form.Show()
    End Sub

    Private Sub Btn_TU_Productivity_Click(sender As Object, e As EventArgs) Handles Btn_TU_Productivity.Click
        TU_Productivity_Form = New TU_Productivity
        TU_Productivity_Form.Show()
    End Sub

    Private Sub Btn_TU_Quality_Click(sender As Object, e As EventArgs) Handles Btn_TU_Quality.Click
        TU_Quality_Form = New TU_Quality
        TU_Quality_Form.Show()
    End Sub

    Private Sub btn_Complete_to_Ship_Click(sender As Object, e As EventArgs) Handles btn_Completed_to_Ship.Click
        Completed_to_Ship_Form = New Completed_To_Ship
        Completed_to_Ship_Form.Show()
    End Sub

    Private Sub Btn_Operator_Quality_History_Click(sender As Object, e As EventArgs) Handles Btn_Operator_Quality_History.Click
        Operator_Status_by_Part_Form = New Operator_Status_by_Part
        Operator_Status_by_Part_Form.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Part_Status_History_Form = New Part_Status_History
        Part_Status_History_Form.Show()

    End Sub

    Private Sub Btn_Part_Defect_List_Click(sender As Object, e As EventArgs) Handles Btn_Part_Defect_List.Click
        Part_Defect_List_Form = New Part_Defect_List
        Part_Defect_List_Form.Show()

    End Sub

    Private Sub Btn_Press_Alarms_Click(sender As Object, e As EventArgs) Handles Btn_Press_Alarms.Click
        Press_Alarms_Form = New Press_Alarms
        Press_Alarms_Form.Show()

    End Sub

    Private Sub Btn_Press_Alarm_History_Click(sender As Object, e As EventArgs) Handles Btn_Press_Alarm_History.Click
        Press_Alarms_History_Form = New Press_Alarm_History
        Press_Alarms_History_Form.Show()

    End Sub

    Private Sub Btn_Press_Summary_Click(sender As Object, e As EventArgs) Handles Btn_Press_Summary.Click
        Press_Summary_Form = New Press_Summary
        Press_Summary_Form.Show()

    End Sub

    Private Sub Btn_Press_Status_Click(sender As Object, e As EventArgs) Handles Btn_Press_Status.Click
        Press_Status_Form = New Press_Status
        Press_Status_Form.Show()

    End Sub

    Private Sub Btn_Press_History_Click(sender As Object, e As EventArgs) Handles Btn_Press_History.Click
        Press_History_Form = New Press_History
        Press_History_Form.Show()

    End Sub

    Private Sub Btn_Robot_Part_History_Click(sender As Object, e As EventArgs) Handles Btn_Robot_Part_History.Click
        Robot_Part_History_Form = New Robot_Part_History
        Robot_Part_History_Form.Show()

    End Sub

    Private Sub Btn_Robot_Part_Defects_Click(sender As Object, e As EventArgs) Handles Btn_Robot_Part_Defects.Click
        Robot_Part_Defect_Form = New Robot_Part_Defect
        Robot_Part_Defect_Form.Show()

    End Sub

    Private Sub Btn_FTB_Click(sender As Object, e As EventArgs) Handles Btn_FTB.Click
        FTB_Form = New FTB
        FTB_Form.Show()

    End Sub

    Private Sub Btn_Location_Corrections_Click(sender As Object, e As EventArgs) Handles Btn_Location_Corrections.Click
        Location_Corrections_Form = New Location_Corrections
        Location_Corrections_Form.Show()

    End Sub

    Private Sub Btn_Paint_Operator_Quality_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Operator_Quality.Click
        Paint_Operator_Status_by_Date_Form = New Paint_Operator_Status_by_Date
        Paint_Operator_Status_by_Date_Form.Show()

    End Sub

    Private Sub Btn_FTB_by_Model_Click(sender As Object, e As EventArgs) Handles Btn_FTB_by_Model.Click
        FTB_by_Model_Form = New FTB_by_Model
        FTB_by_Model_Form.Show()

    End Sub

    Private Sub Btn_Mold_Schedule_Click(sender As Object, e As EventArgs) Handles Btn_Mold_Schedule.Click
        mold_schedule_Form = New Mold_Schedule
        mold_schedule_Form.Show()

    End Sub

    Private Sub Btn_Mold_Buffer_Click(sender As Object, e As EventArgs) Handles Btn_Mold_Buffer.Click
        mold_buffer_Form = New Mold_Buffer
        mold_buffer_Form.Show()

    End Sub

    Private Sub Btn_Scrapped_Parts_Click(sender As Object, e As EventArgs) Handles Btn_Scrapped_Parts.Click
        Scrapped_Parts_Defects_Form = New Scrapped_Parts_Defects
        Scrapped_Parts_Defects_Form.Show()

    End Sub
    Private Sub Btn_Press_Counts_Click(sender As Object, e As EventArgs) Handles Btn_Press_Counts.Click
        Press_Produced_Form = New Press_Produced
        Press_Produced_Form.Show()

    End Sub

    Private Sub Btn_Press_Users_Click(sender As Object, e As EventArgs) Handles Btn_Press_Users.Click
        Press_Users_Form = New Press_Users
        Press_Users_Form.Show()

    End Sub

    Private Sub Btn_Press_RFID_Click(sender As Object, e As EventArgs) Handles Btn_Press_RFID.Click
        Press_RFID_Form = New Press_RFID
        Press_RFID_Form.Show()

    End Sub

    Private Sub Btn_Press_Counts_User_Click(sender As Object, e As EventArgs) Handles Btn_Press_Counts_User.Click
        Press_Counts_By_User_Form = New Press_Counts_By_User
        Press_Counts_By_User_Form.Show()

    End Sub

    Private Sub btn_Test_Debug_Click(sender As Object, e As EventArgs) Handles btn_Test_Debug.Click

        Rate_Debug_Query_Form = New Rate_Debug_Query
        Rate_Debug_Query_Form.Show()

    End Sub

    Private Sub Btn_Schedule_Status_Click(sender As Object, e As EventArgs) Handles Btn_Schedule_Status.Click
        Schedule_Status_Form = New Schedule_Status
        Schedule_Status_Form.Show()

    End Sub

    Private Sub Btn_Op_Logins_Click(sender As Object, e As EventArgs) Handles Btn_Op_Logins.Click
        Operator_Logins_Form = New Operator_Logins
        Operator_Logins_Form.Show()
    End Sub

    'Protected Overrides Sub DefWndProc(ByRef m As System.Windows.Forms.Message)
    '    'This overrides the windows messaging processing
    '    If m.Msg = MessageId Then 'If we found our message then activate
    '        ' Set the WindowState to normal if the form is minimized.
    '        If (Me.WindowState = FormWindowState.Minimized) Then
    '            Me.Show()
    '            Me.WindowState = FormWindowState.Normal
    '        End If

    '        ' Activate the form.
    '        Me.Activate()
    '        Me.Focus()

    '    Else 'Let the normal windows messaging process it.
    '        MyBase.DefWndProc(m)
    '    End If


    'End Sub

    'Private Sub checkprevious()
    '    'Check for previous instance of this app
    '    m_uniqueIdentifier = Application.ExecutablePath.Replace("\", "_")
    '    m_Mutex = New System.Threading.Mutex(False, m_uniqueIdentifier)
    '    'First register the windows message
    '    MessageId = RegisterWindowMessage(m_uniqueIdentifier)
    '    If m_Mutex.WaitOne(1, True) Then
    '        'we are the first instance don't need to do anything

    '    Else
    '        'Cause the current form to show
    '        'Now brodcast a message to cause the first instance to show up
    '        Dim BSMRecipients As Int32 = BSM_APPLICATIONS 'Only go to applications

    '        Dim tmpuint32 As Int32 = 0
    '        tmpuint32 = tmpuint32 Or BSF_IGNORECURRENTTASK 'Ignore current app
    '        tmpuint32 = tmpuint32 Or BSF_POSTMESSAGE 'Post the windows message
    '        Dim ret As Integer
    '        ret = BroadcastSystemMessage(tmpuint32, BSMRecipients, MessageId, 0, 0)
    '        'A differnt instance already exists exit now.
    '        Application.Exit()
    '    End If
    'End Sub

    Private Sub RFID_Tag_Compare_Click(sender As Object, e As EventArgs) Handles Btn_RFID_Tag_Compare.Click
        New_RFID_Tag_Debug_Form = New New_RFID_Tag_Debug
        New_RFID_Tag_Debug_Form.Show()
    End Sub

    Private Sub Btn_PMC_Reports_Click(sender As Object, e As EventArgs) Handles Btn_PMC_Reports.Click
        PMC_Report_By_Resource_Form = New PMC_Report_By_Resource
        PMC_Report_By_Resource_Form.Show()
    End Sub

    Private Sub btn_PressReporting_Click(sender As Object, e As EventArgs) Handles btn_PressReporting.Click
        SupPressRep.Show()

    End Sub

    Private Sub btn_NCM_Data_Click(sender As Object, e As EventArgs) Handles btn_NCM_Data.Click
        NCM_Data_Form = New NCM_Data
        NCM_Data_Form.Show()
    End Sub

    Private Sub btn_Inventory_Clear_Click(sender As Object, e As EventArgs) Handles btn_Inventory_Clear.Click
        Inventory_Clear_Form = New Inventory_Clear
        Inventory_Clear_Form.Show
    End Sub
End Class