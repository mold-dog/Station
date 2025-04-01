Imports System.Data.SqlClient

Public Class Ctr_Operator_Status_by_Function
    Dim ID_Array() As Int32
    Dim Area_ID As Integer

    Private Sub Ctr_Operator_Status_by_Function_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If Station_ID = 0 Then
            Call Load_Combo()
            Cmb_Area.Visible = True
            Lbl_Area_Name.Visible = False
        Else
            Call Load_Label()
            Cmb_Area.Visible = False
            Lbl_Area_Name.Visible = True
            If Show_Wetsand Then
                CB_Wetsand.Checked = True
            Else
                CB_Wetsand.Checked = False
            End If
            If Show_Finesse Then
                CB_Finesse.Checked = True
            Else
                CB_Finesse.Checked = False
            End If
            If Show_Inspection Then
                CB_Inspect.Checked = True
            Else
                CB_Inspect.Checked = False
            End If
            CB_Wetsand.Enabled = False
            CB_Finesse.Enabled = False
            CB_Inspect.Enabled = False
        End If

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from functional_area order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Area").Rows
                Cmb_Area.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Operator Status Screen(Load Combo): " & Ex.Message, EventError)
            '            MsgBox("Error Getting Functional Area Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Label()

        Dim counter As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from functional_area where id = " & Sub_Parameter, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Area").Rows
                Lbl_Area_Name.Text = (dr("Description"))
            Next
            Area_ID = Sub_Parameter
            Call Update_Screen()
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Operator Status Screen(Load Label): " & Ex.Message, EventError)

            '            MsgBox("Error Getting Functional Area Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Cmb_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Area.SelectedIndexChanged
        If Cmb_Area.SelectedIndex >= 0 Then
            Area_ID = ID_Array(Cmb_Area.SelectedIndex)
        End If
        Call Update_Screen()


    End Sub

    Private Sub Tmr_Screen_Update_Tick(sender As Object, e As EventArgs) Handles Tmr_Screen_Update.Tick
        Call Update_Screen()
        If Station_ID > 0 Then
            Call update_station_status()
        End If

    End Sub
    Sub update_station_status()
        Try

            SQLCon.Open()
            Dim cmd As New SqlCommand("", SQLCon)

            cmd.CommandText = "update station set Last_Response = getdate() where id = " & Station_ID
            cmd.ExecuteNonQuery()
            SQLCon.Close()
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Operator Status Screen(Update Station Status): " & Ex.Message, EventError)

        End Try

    End Sub
    Sub Update_Screen()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 57
        Dim prev_op As String = ""
        Dim first_row As Boolean = True
        Dim max_points As Integer = 0
        Dim Enable_Rate_Lbls As Boolean = False
        Dim Enable_Schedule_Status As Boolean = False
        Dim Schedule_Panel_Bottom As Integer
        Dim Debug_Step As Integer

        WriteEvent("Updating screen.", EventInfo)
        Try
            If Area_ID <= 0 Then
                Exit Sub
            End If

            Call Update_Completed_to_Ship()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Debug_Step = 1
            Dim daCounts_Data As New SqlDataAdapter("Exec Operator_Status_by_Area0 " & Area_ID, SQLCon)
            WriteEvent("Querying Database: " & vbCrLf & "Exec Operator_Status_by_Area0 " & Area_ID, EventInfo)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            Debug_Step = 2
            Dim daView_Rate As New SqlDataAdapter("Select * from Config_View", SQLCon)
            daView_Rate.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsView_Rate As New DataSet
            daView_Rate.Fill(dsView_Rate, "Enable_Rate_View")
            SQLCon.Close()
            Enable_Rate_Lbls = False
            Enable_Schedule_Status = False

            WriteEvent("Data received, looping through data.", EventInfo)
            For Each drRateView As DataRow In dsView_Rate.Tables("Enable_Rate_View").Rows
                If drRateView("Enable_Rate_View") Then
                    Enable_Rate_Lbls = True
                End If
                If drRateView("Show_Schedule_On_Status") Then
                    Enable_Schedule_Status = True
                End If
            Next

            WriteEvent("Moving through counts table.", EventInfo)
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                If Quantity_Count <= Max_Counts Then
                    If first_row Then
                        max_points = Val(drCounts("points") & "")
                        If max_points = 0 Then
                            max_points = 1
                        End If
                        If max_points > 1000 Then
                            max_points = 1000
                        End If
                        first_row = False
                    End If
                    If (CB_Finesse.Checked And drCounts("inspection") = "Finesse") Or (CB_Inspect.Checked And drCounts("inspection") = "Inspection") Or (CB_Wetsand.Checked And drCounts("inspection") = "Wet Sand") Then
                        Me.Controls("lbl_Operator" & Quantity_Count).Text = drCounts("op_name") & ""
                        Me.Controls("lbl_Rate" & Quantity_Count).Text = drCounts("rate") & ""
                        If Me.Controls("lbl_Rate" & Quantity_Count).Text >= 0 Then
                            Me.Controls("lbl_Rate" & Quantity_Count).ForeColor = Color.Green
                            If Me.Controls("lbl_Rate" & Quantity_Count).Text > 0 Then
                                Me.Controls("lbl_Rate" & Quantity_Count).Text = "+" & Me.Controls("lbl_Rate" & Quantity_Count).Text
                            End If
                        Else
                            Me.Controls("lbl_Rate" & Quantity_Count).ForeColor = Color.Red
                        End If
                        Me.Controls("lbl_Inspection" & Quantity_Count).Text = drCounts("inspection") & ""
                        Me.Controls("lbl_Part_Type" & Quantity_Count).Text = drCounts("group_desc") & ""
                        Me.Controls("lbl_Good" & Quantity_Count).Text = drCounts("good") & ""
                        Me.Controls("lbl_TU" & Quantity_Count).Text = drCounts("TU") & ""
                        Me.Controls("lbl_Reclear" & Quantity_Count).Text = drCounts("reclear") & ""
                        Me.Controls("lbl_Rework" & Quantity_Count).Text = drCounts("rework") & ""
                        Me.Controls("lbl_FTQ" & Quantity_Count).Text = drCounts("FTQ") & ""
                        Me.Controls("lbl_Incomplete" & Quantity_Count).Text = drCounts("Incomplete") & ""

                        If drCounts("points") > 1000 Then
                            set_progressbar_value(Me.Controls("ProgressBar" & Quantity_Count), 1000)
                        ElseIf drCounts("points") < 1 Then
                            set_progressbar_value(Me.Controls("ProgressBar" & Quantity_Count), 1)
                        ElseIf drCounts("points") < 1000 And drCounts("points") > 1 Then
                            set_progressbar_value(Me.Controls("ProgressBar" & Quantity_Count), Int((Val(drCounts("points") & "") * 1000) / max_points))
                        End If

                        If Me.Controls("lbl_Operator" & Quantity_Count).Text = prev_op Then
                            Me.Controls("lbl_Operator" & Quantity_Count).Visible = False
                            Line_Visible(Quantity_Count, False)
                            Me.Controls("lbl_FTQ" & Quantity_Count).Visible = False
                            Me.Controls("ProgressBar" & Quantity_Count).Visible = False
                            'Me.Controls("lbl_Incomplete" & Quantity_Count).Visible = False
                        Else
                            Me.Controls("lbl_Operator" & Quantity_Count).Visible = True
                            Line_Visible(Quantity_Count, True)
                            Me.Controls("lbl_FTQ" & Quantity_Count).Visible = True
                            Me.Controls("ProgressBar" & Quantity_Count).Visible = True
                            'Me.Controls("lbl_Incomplete" & Quantity_Count).Visible = True
                            prev_op = Me.Controls("lbl_Operator" & Quantity_Count).Text
                        End If

                        If Enable_Rate_Lbls Then
                            Me.Controls("lbl_Rate" & Quantity_Count).Visible = True
                        End If
                        Me.Controls("lbl_Inspection" & Quantity_Count).Visible = True
                        Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = True
                        Me.Controls("lbl_Good" & Quantity_Count).Visible = True
                        Me.Controls("lbl_TU" & Quantity_Count).Visible = True
                        Me.Controls("lbl_Reclear" & Quantity_Count).Visible = True
                        Me.Controls("lbl_Rework" & Quantity_Count).Visible = True
                        Me.Controls("lbl_Incomplete" & Quantity_Count).Visible = True

                        If Enable_Rate_Lbls Then
                            Me.Controls("lbl_Rate").Visible = True
                        Else
                            Me.Controls("lbl_Rate").Visible = False
                            Me.Controls("lbl_Rate" & Quantity_Count).Visible = False
                        End If


                        Quantity_Count += 1
                    End If
                End If

            Next


            WriteEvent("Counts table complete.", EventInfo)

            If Enable_Schedule_Status Then
                Pnl_Schedule.Top = 45 + (Quantity_Count * 31)
                Schedule_Panel_Bottom = Pnl_Schedule.Top + Pnl_Schedule.Height
                If Schedule_Panel_Bottom > 1825 Then
                    Pnl_Schedule.Top = 1825 - Pnl_Schedule.Height
                End If
                If Schedule_Panel_Bottom > 1740 Then
                    Pnl_Finesse.Visible = False
                Else
                    Pnl_Finesse.Visible = True
                End If

            Else
                Pnl_Schedule.Visible = False
                If Quantity_Count > Max_Counts - 3 Then
                    Pnl_Finesse.Visible = False
                Else
                    Pnl_Finesse.Visible = True
                End If
            End If

            WriteEvent("Making unused controls invisible.", EventInfo)
            Do While Quantity_Count <= Max_Counts
                Me.Controls("lbl_Operator" & Quantity_Count).Visible = False
                Me.Controls("lbl_Rate" & Quantity_Count).Visible = False
                Me.Controls("lbl_Inspection" & Quantity_Count).Visible = False
                Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = False
                Me.Controls("lbl_Good" & Quantity_Count).Visible = False
                Me.Controls("lbl_TU" & Quantity_Count).Visible = False
                Me.Controls("lbl_Reclear" & Quantity_Count).Visible = False
                Me.Controls("lbl_Rework" & Quantity_Count).Visible = False
                Me.Controls("lbl_FTQ" & Quantity_Count).Visible = False
                Me.Controls("ProgressBar" & Quantity_Count).Visible = False
                Me.Controls("lbl_Incomplete" & Quantity_Count).Visible = False
                Line_Visible(Quantity_Count, False)

                Quantity_Count += 1
            Loop
            lbl_Comm_Fail.Visible = False

            WriteEvent("Updating FTB Data.", EventInfo)
            Call Update_FTB_data()
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Operator Status Screen(Update Screen): " & Ex.Message, EventError)
        End Try



    End Sub

    Private Sub set_progressbar_value(ByRef progressbarx As ProgressBar, set_val As Integer)
        If set_val > 1000 Then
            set_val = 1000
        End If
        progressbarx.Value = set_val
        Select Case set_val
            Case > 666
                progressbarx.ForeColor = Color.Green
            Case 333 To 666
                progressbarx.ForeColor = Color.Yellow
            Case < 333
                progressbarx.ForeColor = Color.Red

        End Select
    End Sub

    Private Sub Line_Visible(Line_Number As Integer, Visible As Boolean)
        Select Case Line_Number
            Case 1
                LineShape1.Visible = Visible
            Case 2
                LineShape2.Visible = Visible
            Case 3
                LineShape3.Visible = Visible
            Case 4
                LineShape4.Visible = Visible
            Case 5
                LineShape5.Visible = Visible
            Case 6
                LineShape6.Visible = Visible
            Case 7
                LineShape7.Visible = Visible
            Case 8
                LineShape8.Visible = Visible
            Case 9
                LineShape9.Visible = Visible
            Case 10
                LineShape10.Visible = Visible
            Case 11
                LineShape11.Visible = Visible
            Case 12
                LineShape12.Visible = Visible
            Case 13
                LineShape13.Visible = Visible
            Case 14
                LineShape14.Visible = Visible
            Case 15
                LineShape15.Visible = Visible
            Case 16
                LineShape16.Visible = Visible
            Case 17
                LineShape17.Visible = Visible
            Case 18
                LineShape18.Visible = Visible
            Case 19
                LineShape19.Visible = Visible
            Case 20
                LineShape20.Visible = Visible
            Case 21
                LineShape21.Visible = Visible
            Case 22
                LineShape22.Visible = Visible
            Case 23
                LineShape23.Visible = Visible
            Case 24
                LineShape24.Visible = Visible
            Case 25
                LineShape25.Visible = Visible
            Case 26
                LineShape26.Visible = Visible
            Case 27
                LineShape27.Visible = Visible
            Case 28
                LineShape28.Visible = Visible
            Case 29
                LineShape29.Visible = Visible
            Case 30
                LineShape30.Visible = Visible
            Case 31
                LineShape31.Visible = Visible
            Case 32
                LineShape32.Visible = Visible
            Case 33
                LineShape33.Visible = Visible
            Case 34
                LineShape34.Visible = Visible
            Case 35
                LineShape35.Visible = Visible
            Case 36
                LineShape36.Visible = Visible
            Case 37
                LineShape37.Visible = Visible
            Case 38
                LineShape38.Visible = Visible
            Case 39
                LineShape39.Visible = Visible
            Case 40
                LineShape40.Visible = Visible
            Case 41
                LineShape41.Visible = Visible
            Case 42
                LineShape42.Visible = Visible
            Case 43
                LineShape43.Visible = Visible
            Case 44
                LineShape44.Visible = Visible
            Case 45
                LineShape45.Visible = Visible
            Case 46
                LineShape46.Visible = Visible
            Case 47
                LineShape47.Visible = Visible
            Case 48
                LineShape48.Visible = Visible
            Case 49
                LineShape49.Visible = Visible
            Case 50
                LineShape50.Visible = Visible
            Case 51
                LineShape51.Visible = Visible
            Case 52
                LineShape52.Visible = Visible
            Case 53
                LineShape53.Visible = Visible
            Case 54
                LineShape54.Visible = Visible
            Case 55
                LineShape55.Visible = Visible
            Case 56
                LineShape56.Visible = Visible
            Case 57
                LineShape57.Visible = Visible
            Case 58
                LineShape58.Visible = Visible

        End Select


    End Sub

    Private Sub Update_Completed_to_Ship()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 50
        Dim plus_value As Integer = 0

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Completed_to_Ship " & Area_ID, SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Completed_to_Ship")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Completed_to_Ship").Rows
                If Quantity_Count <= Max_Counts Then
                    Pnl_Schedule.Controls("lbl_CTS_Part_Type" & Quantity_Count).Text = Mid(drCounts("part_type") & "", 1, 25)
                    Pnl_Schedule.Controls("lbl_Color" & Quantity_Count).Text = Mid(drCounts("Color") & "", 1, 25)
                    Pnl_Schedule.Controls("lbl_Scheduled" & Quantity_Count).Text = drCounts("scheduled") & ""
                    Pnl_Schedule.Controls("lbl_Priority" & Quantity_Count).Text = drCounts("Priority") & ""
                    Pnl_Schedule.Controls("lbl_Complete" & Quantity_Count).Text = drCounts("Complete") & ""
                    plus_value = Val(drCounts("Plus") & "")
                    If plus_value > 0 Then
                        Pnl_Schedule.Controls("lbl_Plus" & Quantity_Count).Text = "+" & plus_value
                    Else
                        Pnl_Schedule.Controls("lbl_Plus" & Quantity_Count).Text = plus_value & ""
                    End If
                    Pnl_Schedule.Controls("lbl_WS" & Quantity_Count).Text = drCounts("WS_Counts") & ""
                    Pnl_Schedule.Controls("lbl_FI" & Quantity_Count).Text = drCounts("Buff_Counts") & ""
                    Pnl_Schedule.Controls("lbl_IP" & Quantity_Count).Text = drCounts("FI_Counts") & ""
                    Pnl_Schedule.Controls("lbl_CTS_Part_Type" & Quantity_Count).Visible = True
                    Pnl_Schedule.Controls("lbl_Color" & Quantity_Count).Visible = True
                    Pnl_Schedule.Controls("lbl_Scheduled" & Quantity_Count).Visible = True
                    If Pnl_Schedule.Controls("lbl_Priority" & Quantity_Count).Text <> 99 Then
                        Pnl_Schedule.Controls("lbl_Priority" & Quantity_Count).Visible = True
                    End If
                    Pnl_Schedule.Controls("lbl_Complete" & Quantity_Count).Visible = True
                    Pnl_Schedule.Controls("lbl_Plus" & Quantity_Count).Visible = True
                    Pnl_Schedule.Controls("lbl_WS" & Quantity_Count).Visible = True
                    Pnl_Schedule.Controls("lbl_FI" & Quantity_Count).Visible = True
                    Pnl_Schedule.Controls("lbl_IP" & Quantity_Count).Visible = True
                    Sched_Line_Visible(Quantity_Count, True)
                    Quantity_Count += 1
                End If
            Next
            Pnl_Schedule.Height = 30 + (Quantity_Count * 16)
            'If Quantity_Count > 29 Then
            '    LineShapeVerticle.Visible = True
            '    Lbl_Header_Part_Type.Visible = True
            '    Lbl_Header_Color.Visible = True
            '    Lbl_Header_Schedule.Visible = True
            '    Lbl_Header_Complete.Visible = True
            '    Lbl_Header_Plus.Visible = True
            '    Lbl_Header_WS.Visible = True
            '    Lbl_Header_Buff.Visible = True
            '    Lbl_Header_IP.Visible = True
            'Else
            '    LineShapeVerticle.Visible = False
            '    Lbl_Header_Part_Type.Visible = False
            '    Lbl_Header_Color.Visible = False
            '    Lbl_Header_Schedule.Visible = False
            '    Lbl_Header_Complete.Visible = False
            '    Lbl_Header_Plus.Visible = False
            '    Lbl_Header_WS.Visible = False
            '    Lbl_Header_Buff.Visible = False
            '    Lbl_Header_IP.Visible = False
            'End If
            Do While Quantity_Count <= Max_Counts
                Pnl_Schedule.Controls("lbl_CTS_Part_Type" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_Color" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_Scheduled" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_Priority" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_Complete" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_Plus" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_WS" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_FI" & Quantity_Count).Visible = False
                Pnl_Schedule.Controls("lbl_IP" & Quantity_Count).Visible = False
                Sched_Line_Visible(Quantity_Count, False)
                Quantity_Count += 1
            Loop

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Operator Status Screen(Update Completed to Ship): " & Ex.Message, EventError)

            'MsgBox("Error Getting Completed to Ship Info from Database: " & Ex.Message)
        End Try

    End Sub

    Private Sub Sched_Line_Visible(Line_Number As Integer, Visible As Boolean)
        Select Case Line_Number
            Case 1
                Sched_LineShape1.Visible = Visible
            Case 2
                Sched_LineShape2.Visible = Visible
            Case 3
                Sched_LineShape3.Visible = Visible
            Case 4
                Sched_LineShape4.Visible = Visible
            Case 5
                Sched_LineShape5.Visible = Visible
            Case 6
                Sched_LineShape6.Visible = Visible
            Case 7
                Sched_LineShape7.Visible = Visible
            Case 8
                Sched_LineShape8.Visible = Visible
            Case 9
                Sched_LineShape9.Visible = Visible
            Case 10
                Sched_LineShape10.Visible = Visible
            Case 11
                Sched_LineShape11.Visible = Visible
            Case 12
                Sched_LineShape12.Visible = Visible
            Case 13
                Sched_LineShape13.Visible = Visible
            Case 14
                Sched_LineShape14.Visible = Visible
            Case 15
                Sched_LineShape15.Visible = Visible
            Case 16
                Sched_LineShape16.Visible = Visible
            Case 17
                Sched_LineShape17.Visible = Visible
            Case 18
                Sched_LineShape18.Visible = Visible
            Case 19
                Sched_LineShape19.Visible = Visible
            Case 20
                Sched_LineShape20.Visible = Visible
            Case 21
                Sched_LineShape21.Visible = Visible
            Case 22
                Sched_LineShape22.Visible = Visible
            Case 23
                Sched_LineShape23.Visible = Visible
            Case 24
                Sched_LineShape24.Visible = Visible
            Case 25
                Sched_LineShape25.Visible = Visible
            Case 26
                Sched_LineShape26.Visible = Visible
            Case 27
                Sched_LineShape27.Visible = Visible
            Case 28
                Sched_LineShape28.Visible = Visible
            Case 29
                Sched_LineShape29.Visible = Visible
            Case 30
                Sched_LineShape30.Visible = Visible
            Case 31
                Sched_LineShape31.Visible = Visible
            Case 32
                Sched_LineShape32.Visible = Visible
            Case 33
                Sched_LineShape33.Visible = Visible
            Case 34
                Sched_LineShape34.Visible = Visible
            Case 35
                Sched_LineShape35.Visible = Visible
            Case 36
                Sched_LineShape36.Visible = Visible
            Case 37
                Sched_LineShape37.Visible = Visible
            Case 38
                Sched_LineShape38.Visible = Visible
            Case 39
                Sched_LineShape39.Visible = Visible
            Case 40
                Sched_LineShape40.Visible = Visible
            Case 41
                Sched_LineShape41.Visible = Visible
            Case 42
                Sched_LineShape42.Visible = Visible
            Case 43
                Sched_LineShape43.Visible = Visible
            Case 44
                Sched_LineShape44.Visible = Visible
            Case 45
                Sched_LineShape45.Visible = Visible
            Case 46
                Sched_LineShape46.Visible = Visible
            Case 47
                Sched_LineShape47.Visible = Visible
            Case 48
                Sched_LineShape48.Visible = Visible
            Case 49
                Sched_LineShape49.Visible = Visible
            Case 50
                Sched_LineShape50.Visible = Visible

        End Select


    End Sub

    Sub Update_FTB_data()
        Dim day_value As Double
        Dim week_value As Double
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Select * from FTB_Calculated", SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                lbl_Finesse_Day.Text = Format(drCounts("Finesse_Day") & "", "fixed") & " %"
                lbl_Finesse_Week.Text = Format(drCounts("Finesse_Week") & "", "fixed") & " %"
                lbl_Finesse_Month.Text = Format(drCounts("Finesse_Month") & "", "fixed") & " %"
                lbl_Finesse_90.Text = Format(drCounts("Finesse_90") & "", "fixed") & " %"
                lbl_Finesse_Model.Text = Format(drCounts("Finesse_Model") & "", "fixed") & " %"

                If IsNumeric(drCounts("Finesse_Day") & "") And IsNumeric(drCounts("Finesse_Week") & "") Then
                    day_value = Val(drCounts("Finesse_Day") & "")
                    week_value = Val(drCounts("Finesse_Week") & "")
                    If day_value > week_value Then
                        lbl_Finesse_Status.Text = "↑"
                        Pnl_Finesse.BackColor = Color.Green
                    Else
                        If day_value < week_value Then
                            lbl_Finesse_Status.Text = "↓"
                            Pnl_Finesse.BackColor = Color.Red
                        Else
                            lbl_Finesse_Status.Text = "-"
                            Pnl_Finesse.BackColor = Color.Gray
                        End If
                    End If
                End If

            Next


            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Operator Status Screen(Update FTB Data): " & Ex.Message, EventError)
        End Try

    End Sub

    Private Sub CB_Finesse_CheckStateChanged(sender As Object, e As EventArgs) Handles CB_Finesse.CheckStateChanged

        Update_Screen()

    End Sub

    Private Sub CB_Inspect_CheckStateChanged(sender As Object, e As EventArgs) Handles CB_Inspect.CheckStateChanged

        Update_Screen()

    End Sub

    Private Sub CB_Wetsand_CheckStateChanged(sender As Object, e As EventArgs) Handles CB_Wetsand.CheckStateChanged

        Update_Screen()

    End Sub


End Class