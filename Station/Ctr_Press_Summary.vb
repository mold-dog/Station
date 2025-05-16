Imports System.Data.SqlClient





Public Class Ctr_Press_Summary

    Dim No_Operator(11) As Integer
    Dim Auto_Logout_Counter(11) As Integer
    Dim Auto_Logout(11) As Boolean
    Dim Press As Boolean
    Dim Bonder As Boolean
    Dim DisableRFID As Boolean = False
    Dim Alarm_Red_Array(500) As Integer
    Dim Alarm_Green_Array(500) As Integer
    Dim Alarm_Blue_Array(500) As Integer



    Private Sub Ctr_Press_Summary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If DBConnection <> DBConnection_Ma Then
            Block.Location = New Point(13, 641)
            Block.Size = New Size(1878, 59)
            Block.BringToFront()

            'Mauston
            '20, 794
            '2817, 428

            'Johnson Creek
            '13, 641
            '1878, 59
        End If

        Call Load_Presses()

        DGV_Paint_Data.Font = Block.Font
        LB_PMC.DrawMode = DrawMode.OwnerDrawFixed
        LB_PMC.ItemHeight += 5

        Call Update_Screen()
        Call Update_Alarms()
        Me.Refresh()
    End Sub

    Private bindingsource1 As New BindingSource

    Dim Press_ID_Array() As Int32
    Dim Bond_ID_Array() As Int32
    Dim Num_presses_allowed As Integer = 10


    Sub Load_Presses()
        Dim Press_Number As String
        Dim Bond_Number As String

        Dim counter As Integer = 0
        Try


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Press order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Press")
            Dim da1 As New SqlDataAdapter("Select * from Bonder order by id", SQLCon)
            da1.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds1 As New DataSet
            da1.Fill(ds1, "Bond")
            SQLCon.Close()
            ReDim Press_ID_Array(0)
            For Each dr As DataRow In ds.Tables("Press").Rows
                If counter + 1 <= Num_presses_allowed Then
                    Press_Number = dr("Description") & ""
                    Me.Controls("Lbl_Press_Name" & (counter + 1)).Text = Strings.Mid(Press_Number, 7)
                End If
                ReDim Preserve Press_ID_Array(counter)
                Press_ID_Array(counter) = dr("ID")
                counter += 1
            Next
            counter = 0
            ReDim Bond_ID_Array(0)
            For Each dr As DataRow In ds1.Tables("Bond").Rows
                If counter + 1 <= Num_presses_allowed Then
                    'Bond_Number = dr("ID") & ""
                    Me.Controls("Lbl_Bond_Name" & (counter + 1)).Text = dr("ID")

                End If
                ReDim Preserve Bond_ID_Array(counter)
                Bond_ID_Array(counter) = dr("ID")
                counter += 1
            Next

            'For counter = 1 To 2
            '    Me.Controls("Lbl_Bond_Name" & (counter)).Visible = False
            'Next

            Press = 1

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Press Summary Screen(Load_Presses): " & Ex.Message, EventError)
            'MsgBox("Error Getting Press Info from Database: " & Ex.Message)
        End Try



    End Sub




    Private Sub Tmr_Screen_Update_Tick(sender As Object, e As EventArgs) Handles Tmr_Screen_Update.Tick

        If Not Bonder Then
            Press = 0
            Bonder = 1
        Else
            Press = 1
            Bonder = 0
        End If

        Call Update_Screen()
        Call Update_Alarms()
        Me.Refresh()

    End Sub
    Sub Update_Screen()

        Try


            Dim counter As Integer
            For counter = 0 To UBound(Press_ID_Array)
                If counter <= Num_presses_allowed Then
                    Call update_row(Press_ID_Array(counter), counter + 1)
                End If
            Next
            For counter = 0 To UBound(Bond_ID_Array)
                If counter <= Num_presses_allowed Then
                    Call update_row(Bond_ID_Array(counter) + 100, counter + 11)
                End If
            Next

        Catch ex As Exception
            WriteEvent("Error updating screen: " & ex.Message & vbCrLf & vbCrLf & ex.ToString, EventError)
        End Try

    End Sub
    Sub update_row(press_id As Integer, press_row As Integer)

        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 35
        Dim prev_op As String = ""
        Dim first_row As Boolean = True
        Dim max_points As Integer = 0
        Dim shift As String = ""
        Dim Press_Hours As Double = 0
        Dim Total_Parts As Integer = 0
        Dim Shift_Parts As String = ""
        Dim planned As Double = 0
        Dim rowcount As Integer = 0
        Dim query As String
        Dim query2 As String
        Dim query3 As String



        Try
            If press_id <= 0 Then
                Exit Sub
            End If


            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            If press_id < 100 Then
                query = "Exec Get_Press_Status3 " & press_id
                query2 = "Exec Get_Press_Users " & press_id & "," & Auto_Logout(press_id)
                query3 = "Select Disable_RFID From Press where ID = " & press_id
            Else
                query = "Exec Get_Bonder_Status3 " & press_id - 100
                query2 = "Exec Get_Bonder_Users " & press_id - 100 & "," & 0
                query3 = "Select Disable_RFID From Bonder where ID = " & press_id - 100
            End If

            Dim dsCounts As New DataSet


            Dim daCounts_Data As New SqlDataAdapter(query, SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            daCounts_Data.Fill(dsCounts, "Counts")



            Dim daUser_Data As New SqlDataAdapter(query2, SQLCon)
            daUser_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsUser As New DataSet
            daUser_Data.Fill(dsUser, "Users")

            Dim daFourthShift_bit As New SqlDataAdapter("Select Enable_Fourth_Shift, Enable_Two_Shift From Config_View", SQLCon)
            daFourthShift_bit.SelectCommand.CommandTimeout = SQL_Timeout
            Dim daFourthShift As New DataSet
            daFourthShift_bit.Fill(daFourthShift, "Fourth")

            Dim enable_fourth_shift As Boolean = False
            Dim enable_two_shift As Boolean = False

            For Each temp_dr As DataRow In daFourthShift.Tables("Fourth").Rows
                If temp_dr("Enable_Fourth_Shift") Then
                    enable_fourth_shift = True
                ElseIf temp_dr("Enable_Two_Shift") Then
                    enable_two_Shift = True
                End If
            Next

            Dim daDisableRFID_bit As New SqlDataAdapter(query3, SQLCon)
            daDisableRFID_bit.SelectCommand.CommandTimeout = SQL_Timeout
            Dim daDisableRFID As New DataSet
            daDisableRFID_bit.Fill(daDisableRFID, "RFID")

            For Each temp_dr As DataRow In daDisableRFID.Tables("RFID").Rows
                If temp_dr("Disable_RFID") Then
                    DisableRFID = True
                End If
            Next

            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                Me.Controls("Lbl_Part" & press_row).Text = drCounts("Part_Name")
                shift = drCounts("Shift") & ""
                Select Case shift
                    Case "1"
                        If enable_fourth_shift Then
                            Lbl_Current_Shift.Text = "A"
                            Lbl_Last_Shift.Text = "B"
                            Lbl_Previous_Shift.Text = "C"
                            Lbl_Fourth_Shift.Text = "D"
                        ElseIf enable_two_shift Then
                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = ""
                            Lbl_Fourth_Shift.Text = ""
                        Else

                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = "3"
                            Lbl_Fourth_Shift.Text = ""
                        End If
                        Lbl_Current_Shift.BorderStyle = BorderStyle.FixedSingle
                        Lbl_Last_Shift.BorderStyle = BorderStyle.None
                        Lbl_Previous_Shift.BorderStyle = BorderStyle.None
                        Lbl_Fourth_Shift.BorderStyle = BorderStyle.None
                        Lbl_Current_Shift.BackColor = Color.Lime
                        Lbl_Last_Shift.BackColor = SystemColors.Control
                        Lbl_Previous_Shift.BackColor = SystemColors.Control
                        Lbl_Fourth_Shift.BackColor = SystemColors.Control
                    Case "2"
                        If enable_fourth_shift Then
                            Lbl_Current_Shift.Text = "A"
                            Lbl_Last_Shift.Text = "B"
                            Lbl_Previous_Shift.Text = "C"
                            Lbl_Fourth_Shift.Text = "D"
                        ElseIf enable_two_shift Then
                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = ""
                            Lbl_Fourth_Shift.Text = ""
                        Else

                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = "3"
                            Lbl_Fourth_Shift.Text = ""
                        End If
                        Lbl_Current_Shift.BorderStyle = BorderStyle.None
                        Lbl_Last_Shift.BorderStyle = BorderStyle.FixedSingle
                        Lbl_Previous_Shift.BorderStyle = BorderStyle.None
                        Lbl_Fourth_Shift.BorderStyle = BorderStyle.None
                        Lbl_Current_Shift.BackColor = SystemColors.Control
                        Lbl_Last_Shift.BackColor = Color.Lime
                        Lbl_Previous_Shift.BackColor = SystemColors.Control
                        Lbl_Fourth_Shift.BackColor = SystemColors.Control
                    Case "3"
                        If enable_fourth_shift Then
                            Lbl_Current_Shift.Text = "A"
                            Lbl_Last_Shift.Text = "B"
                            Lbl_Previous_Shift.Text = "C"
                            Lbl_Fourth_Shift.Text = "D"
                        ElseIf enable_two_shift Then
                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = ""
                            Lbl_Fourth_Shift.Text = ""
                        Else

                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = "3"
                            Lbl_Fourth_Shift.Text = ""
                        End If
                        Lbl_Current_Shift.BorderStyle = BorderStyle.None
                        Lbl_Last_Shift.BorderStyle = BorderStyle.None
                        Lbl_Previous_Shift.BorderStyle = BorderStyle.FixedSingle
                        Lbl_Fourth_Shift.BorderStyle = BorderStyle.None
                        Lbl_Current_Shift.BackColor = SystemColors.Control
                        Lbl_Last_Shift.BackColor = SystemColors.Control
                        Lbl_Previous_Shift.BackColor = Color.Lime
                        Lbl_Fourth_Shift.BackColor = SystemColors.Control
                    Case "4"
                        If enable_fourth_shift Then
                            Lbl_Current_Shift.Text = "A"
                            Lbl_Last_Shift.Text = "B"
                            Lbl_Previous_Shift.Text = "C"
                            Lbl_Fourth_Shift.Text = "D"
                        ElseIf enable_two_shift Then
                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = ""
                            Lbl_Fourth_Shift.Text = ""
                        Else

                            Lbl_Current_Shift.Text = "1"
                            Lbl_Last_Shift.Text = "2"
                            Lbl_Previous_Shift.Text = "3"
                            Lbl_Fourth_Shift.Text = ""
                        End If
                        Lbl_Current_Shift.BorderStyle = BorderStyle.None
                        Lbl_Last_Shift.BorderStyle = BorderStyle.None
                        Lbl_Previous_Shift.BorderStyle = BorderStyle.None
                        Lbl_Fourth_Shift.BorderStyle = BorderStyle.FixedSingle
                        Lbl_Current_Shift.BackColor = SystemColors.Control
                        Lbl_Last_Shift.BackColor = SystemColors.Control
                        Lbl_Previous_Shift.BackColor = SystemColors.Control
                        Lbl_Fourth_Shift.BackColor = Color.Lime
                End Select
                ' Me.Controls("Lbl_Downtime" & press_row).Text = Format_Time(drCounts("Downtime") & "")

                'If enable_fourth_shift Then

                '    Label27.Visible = True
                '    Label28.Visible = True
                '    Label32.Visible = True

                'Else
                '    Label27.Visible = False
                '    Label28.Visible = False
                '    Label32.Visible = False

                'End If


                Press_Hours = Val(drCounts("A_Shift_Hours") & "")
                If Press_Hours > 0 Then
                    Me.Controls("lbl_Current_Total_Rate" & press_row).Text = Format(Val(drCounts("A_Shift_Total") & "") / Press_Hours, "#.0")
                Else
                    Me.Controls("lbl_Current_Total_Rate" & press_row).Text = "0.0"
                End If
                'MsgBox("Counts ," & Val(drCounts("A_Shift_Total") & "") & " Hours ," & Press_Hours)
                Press_Hours = Val(drCounts("B_Shift_Hours") & "")
                If Press_Hours > 0 Then
                    Me.Controls("lbl_Last_Total_Rate" & press_row).Text = Format(Val(drCounts("B_Shift_Total") & "") / Press_Hours, "#.0")
                Else
                    Me.Controls("lbl_Last_Total_Rate" & press_row).Text = "0.0"
                End If
                Press_Hours = Val(drCounts("C_Shift_Hours") & "")

                Press_Hours = Val(drCounts("D_Shift_Hours") & "")

                If enable_fourth_shift Then
                    If Press_Hours > 0 Then
                        Me.Controls("lbl_previous_Total_Rate" & press_row).Text = Format(Val(drCounts("C_Shift_Total") & "") / Press_Hours, "#.0")
                    Else
                        Me.Controls("lbl_previous_Total_Rate" & press_row).Text = "0.0"
                    End If

                    If Press_Hours > 0 Then
                        Me.Controls("lbl_fourth_Total_Rate" & press_row).Text = Format(Val(drCounts("D_Shift_Total") & "") / Press_Hours, "#.0")
                    Else
                        Me.Controls("lbl_fourth_Total_Rate" & press_row).Text = "0.0"
                    End If

                Elseif enable_two_shift then
                    Me.Controls("lbl_previous_Total_Rate" & press_row).Text = " "
                    Me.Controls("lbl_fourth_Total_Rate" & press_row).Text = " "
                Else
                    Me.Controls("lbl_fourth_Total_Rate" & press_row).Text = " "
                    If Press_Hours > 0 Then
                        Me.Controls("lbl_previous_Total_Rate" & press_row).Text = Format(Val(drCounts("C_Shift_Total") & "") / Press_Hours, "#.0")
                    Else
                        Me.Controls("lbl_previous_Total_Rate" & press_row).Text = "0.0"
                    End If
                End If





                'Shift_Parts = drCounts("A_Shift_Parts") & ""
                'Press_Hours = Val(drCounts("A_Shift_Last_hours") & "")
                'If Press_Hours > 0 Then
                '    Lbl_Current_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                'Else
                '    Lbl_Current_Shift_Rate.Text = "0.0"
                'End If
                'Shift_Parts = drCounts("B_Shift_Parts") & ""
                'Press_Hours = Val(drCounts("B_Shift_Last_hours") & "")
                'If Press_Hours > 0 Then
                '    Lbl_Last_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                'Else
                '    Lbl_Last_Shift_Rate.Text = "0.0"
                'End If
                'Shift_Parts = drCounts("C_Shift_Parts") & ""
                'Press_Hours = Val(drCounts("C_Shift_Last_hours") & "")
                'If Press_Hours > 0 Then
                '    Lbl_Previous_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                'Else
                '    Lbl_Previous_Shift_Rate.Text = "0.0"
                'End If



                Press_Hours = Val(drCounts("A_Shift_Hours") & "") + Val(drCounts("B_Shift_Hours") & "") + Val(drCounts("C_Shift_Hours") & "") + Val(drCounts("D_Shift_Hours") & "")
                If Press_Hours > 0 Then
                    Total_Parts = Val(drCounts("A_Shift_Total") & "") + Val(drCounts("B_Shift_Total") & "") + Val(drCounts("C_Shift_Total") & "") + Val(drCounts("D_Shift_Total") & "")
                    Me.Controls("Lbl_Total_Actual" & press_row).Text = Format(Total_Parts / Press_Hours, "#.0")
                Else
                    Me.Controls("Lbl_Total_Actual" & press_row).Text = "0.0"
                End If

                Me.Controls("Lbl_Current_Actual" & press_row).Text = Format(Val(drCounts("Current_Hour") & ""), "0")
                Me.Controls("Lbl_Current_Scan" & press_row).Text = Format(Val(drCounts("Current_Hour_Scans") & ""), "0")
                If (drCounts("Current_Hour_Scans") + 1 < drCounts("Current_Hour")) Or (drCounts("Current_Hour_Scans") - 1 > drCounts("Current_Hour")) Then
                    ' DISABLE
                    If Not DisableRFID Then
                        Me.Controls("Lbl_Current_Scan" & press_row).BackColor = Color.Red
                    End If

                Else
                    Me.Controls("Lbl_Current_Scan" & press_row).BackColor = SystemColors.Control
                End If


                Me.Controls("Lbl_Current_Expected" & press_row).Text = Format(Val(drCounts("Rate") & ""), "0.#")
                planned = Val(Me.Controls("Lbl_Current_Expected" & press_row).Text)
                Me.Controls("Lbl_Total_Expected" & press_row).Text = Format(Val(drCounts("Rate") & "") * Press_Hours, "0")
                Me.Controls("Lbl_Total_Parts" & press_row).Text = (Val(drCounts("A_Shift_Total") & "") + Val(drCounts("B_Shift_Total") & "") + Val(drCounts("C_Shift_Total") & "") + Val(drCounts("D_Shift_Total") & "")) - (Val(drCounts("Total_Scrap") & ""))
                Me.Controls("Lbl_Scan_Total" & press_row).Text = Val(drCounts("A_Shift_Scan_Total") & "") + Val(drCounts("B_Shift_Scan_Total") & "") + Val(drCounts("C_Shift_Scan_Total") & "") + Val(drCounts("D_Shift_Scan_Total") & "")

                If drCounts("Running") & "" = "1" Then
                    Me.Controls("Lbl_Running" & press_row).Text = "Run"
                    Me.Controls("Lbl_Current_Plus" & press_row).Text = Val(Me.Controls("Lbl_Current_Actual" & press_row).Text) - Val(Me.Controls("Lbl_Current_Expected" & press_row).Text)
                    Me.Controls("Lbl_Current_Plus" & press_row).ForeColor = Get_Color(Val(Me.Controls("Lbl_Current_Plus" & press_row).Text), 0)
                Else
                    Me.Controls("Lbl_Running" & press_row).Text = "Stop"
                    Me.Controls("Lbl_Current_Plus" & press_row).Text = "0"
                    Me.Controls("Lbl_Current_Plus" & press_row).ForeColor = Get_Color(Val(Me.Controls("Lbl_Current_Plus" & press_row).Text), 0)
                End If

                Me.Controls("Lbl_Total_Plus" & press_row).Text = Val(drCounts("A_Shift_Total") & "") + Val(drCounts("B_Shift_Total") & "") + Val(drCounts("C_Shift_Total") & "") + Val(drCounts("D_Shift_Total") & "") - Val(Me.Controls("Lbl_Total_Expected" & press_row).Text)
                Me.Controls("Lbl_Total_Plus" & press_row).ForeColor = Get_Color(Val(Me.Controls("Lbl_Total_Plus" & press_row).Text), planned)

                Me.Controls("lbl_Scrap_Hour" & press_row).Text = drCounts("Hour_Scrap") & ""
                Me.Controls("Lbl_Scrap_Total" & press_row).Text = drCounts("Total_Scrap") & ""

                'Set colors 
                Me.Controls("lbl_Current_Total_Rate" & press_row).ForeColor = Get_Color(Val(Me.Controls("lbl_Current_Total_Rate" & press_row).Text), planned)
                Me.Controls("lbl_Last_Total_Rate" & press_row).ForeColor = Get_Color(Val(Me.Controls("lbl_Last_Total_Rate" & press_row).Text), planned)
                Me.Controls("lbl_previous_Total_Rate" & press_row).ForeColor = Get_Color(Val(Me.Controls("lbl_previous_Total_Rate" & press_row).Text), planned)
                'If enable_fourth_shift Then
                '    Me.Controls("lbl_fourth_Total_Rate" & press_row).ForeColor = Get_Color(Val(Me.Controls("lbl_fourth_Total_Rate" & press_row).Text), planned)
                'End If

                ' DISABLE?
                If Not DisableRFID Then
                    Me.Controls("lbl_Scrap_Hour" & press_row).ForeColor = Get_Scrap_Color(Val(Me.Controls("lbl_Scrap_Hour" & press_row).Text))
                    Me.Controls("Lbl_Scrap_Total" & press_row).ForeColor = Get_Scrap_Color(Val(Me.Controls("Lbl_Scrap_Total" & press_row).Text))
                End If


                If press_row < 11 Then

                    If drCounts("PLC_Comm_Fail") <> 0 Then
                        Me.Controls("Lbl_RFID_Fail" & press_row).Visible = True
                    Else
                        Me.Controls("Lbl_RFID_Fail" & press_row).Visible = False
                    End If

                    Me.Controls("lblUser1" & press_row).Visible = False
                    Me.Controls("lblUser2" & press_row).Visible = False
                    Me.Controls("lblUser3" & press_row).Visible = False
                    Me.Controls("lblUser4" & press_row).Visible = False
                    Me.Controls("lblUser5" & press_row).Visible = False
                    rowcount = 0


                    For Each drUsers As DataRow In dsUser.Tables("Users").Rows
                        rowcount = rowcount + 1
                        Select Case rowcount
                            Case = 1
                                If drUsers("User") <> "" Then
                                    Me.Controls("lblUser1" & press_row).Visible = True
                                    Me.Controls("lblUser1" & press_row).Text = drUsers("User")
                                End If
                            Case = 2
                                If drUsers("User") <> "" Then
                                    Me.Controls("lblUser2" & press_row).Visible = True
                                    Me.Controls("lblUser2" & press_row).Text = drUsers("User")
                                End If
                            Case = 3
                                If drUsers("User") <> "" Then
                                    Me.Controls("lblUser3" & press_row).Visible = True
                                    Me.Controls("lblUser3" & press_row).Text = drUsers("User")
                                End If
                            Case = 4
                                If drUsers("User") <> "" Then
                                    Me.Controls("lblUser4" & press_row).Visible = True
                                    Me.Controls("lblUser4" & press_row).Text = drUsers("User")
                                End If
                            Case = 5
                                If drUsers("User") <> "" Then
                                    Me.Controls("lblUser5" & press_row).Visible = True
                                    Me.Controls("lblUser5" & press_row).Text = drUsers("User")
                                End If

                        End Select



                    Next


                    If drCounts("Running") & "" = "1" And Me.Controls("lblUser1" & press_row).Visible = False And Me.Controls("lblUser2" & press_row).Visible = False And Me.Controls("lblUser3" & press_row).Visible = False And Me.Controls("lblUser4" & press_row).Visible = False And Me.Controls("lblUser5" & press_row).Visible = False Then
                        No_Operator(press_row) = No_Operator(press_row) + 1
                    Else
                        No_Operator(press_row) = 0
                    End If

                    ' DISABLE
                    If No_Operator(press_row) > 5 Then
                        If not DisableRFID Then
                            Me.Controls("Lbl_Oper" & press_row).ForeColor = Color.Red
                            Me.Controls("lbl_Warning" & press_row).Visible = True
                        End If

                    Else
                        Me.Controls("Lbl_Oper" & press_row).ForeColor = Color.Black
                        Me.Controls("lbl_Warning" & press_row).Visible = False
                    End If

                    Auto_Logout(press_id) = False

                    If drCounts("Running") & "" = "0" And (Me.Controls("lblUser1" & press_row).Visible = True Or Me.Controls("lblUser2" & press_row).Visible = True Or Me.Controls("lblUser3" & press_row).Visible = True Or Me.Controls("lblUser4" & press_row).Visible = True Or Me.Controls("lblUser5" & press_row).Visible = True) Then
                        Auto_Logout_Counter(press_id) = Auto_Logout_Counter(press_id) + 1
                    Else
                        Auto_Logout_Counter(press_id) = 0
                    End If

                    If Auto_Logout_Counter(press_id) > 5 Then
                        Auto_Logout(press_id) = True
                    End If
                End If
            Next


            Label90.Text = No_Operator(1)
            Label91.Text = No_Operator(2)
            Label92.Text = No_Operator(3)
            Label93.Text = No_Operator(4)
            Label94.Text = No_Operator(5)
            Label95.Text = No_Operator(6)
            Label96.Text = No_Operator(7)
            Label97.Text = No_Operator(8)
            Label98.Text = No_Operator(9)
            Label99.Text = No_Operator(10)



            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Press Summary Screen(Update Row): " & Ex.Message, EventError)
        End Try



    End Sub

    Private Function Get_Color(ByVal actual As Double, ByVal expected As Double) As Color
        If actual > expected Then
            Return Color.Green
        Else
            If actual < expected Then
                Return Color.Red
            Else
                Return Color.Black
            End If
        End If

    End Function
    Private Function Get_Scrap_Color(ByVal scrap As Integer) As Color
        If scrap > 0 Then
            Return Color.Red
        Else
            Return Color.Black
        End If

    End Function
    Private Function Format_Time(ByVal Seconds As Integer) As String
        Dim Hours As Integer = 0
        Dim Minutes As Integer = 0

        Dim Time_String As String = ""


        If Seconds >= 3600 Then
            Hours = Seconds \ 3600
            Seconds = Seconds Mod 3600
            Time_String = Hours & ":"
        End If

        Minutes = Seconds \ 60
        Seconds = Seconds Mod 60

        If Minutes < 10 And Hours > 0 Then
            Time_String = Time_String & "0" & Minutes
        Else
            Time_String = Time_String & Minutes
        End If
        If Seconds < 10 Then
            Time_String = Time_String & ":0" & Seconds
        Else
            Time_String = Time_String & ":" & Seconds
        End If

        Return Time_String

    End Function
    Private Sub Update_Alarms()
        'Dim query As String

        'DGV_Paint_Data.AutoGenerateColumns = True
        'Me.Cursor = Cursors.WaitCursor

        'query = "Exec Get_Press_Alarms 0"

        'bindingsource1.DataSource = GetData(query)

        'DGV_Paint_Data.DataSource = bindingsource1
        'DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        'DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        'Me.Cursor = Cursors.Default

        Dim query As String
        Dim alarm_counter As Integer
        Dim alarm_string As String
        Dim mid_string As String()

        ' Need to switch away from Press_Alarms and just show PMC
        'If Press Then
        '    DGV_Paint_Data.AutoGenerateColumns = True
        '    Me.Cursor = Cursors.WaitCursor
        '    query = "Exec Get_Press_Alarms 0"
        '    DGV_Paint_Data.Visible = True
        '    LB_PMC.Visible = False
        '    bindingsource1.DataSource = GetData(query)

        '    DGV_Paint_Data.DataSource = bindingsource1
        '    DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        '    DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        '    Me.Cursor = Cursors.Default
        'Else
        query = "Select PMC_Alarm_Current.Description, PMC_Resources.Resource, PMC_Alarm_Config.Event_Type, PMC_Event_Types.Display_Color, PMC_Alarm_Config.PLC, PMC_Alarm_Current.Start_Time from PMC_Alarm_Current " &
            "inner join PMC_Resources on PMC_Alarm_Current.PLC = PMC_Resources.id " &
            "inner join PMC_Alarm_Config on PMC_Alarm_Current.Alarm_Offset = PMC_Alarm_Config.Event_Number and PMC_Alarm_Current.PLC = PMC_Alarm_Config.PLC " &
            "inner join PMC_Event_Types on PMC_Alarm_Config.Event_Type = PMC_Event_Types.ID Where PMC_Resources.Enabled = 'True' and (PMC_Resources.Resource like 'P%' or PMC_Resources.Resource like '%Rt%' or PMC_Resources.Resource like 'Slitter%' or PMC_Resources.Resource in ('7913', 'RFID PLC')) and not (PMC_Resources.Resource like 'Pa%') and isnull(PMC_Alarm_Config.Disabled,0) = 0 and " &
            "(isnull(PMC_Alarm_Config.shelved,0) = 0 or (PMC_Alarm_Config.shelved = 1 and PMC_Alarm_Config.Shelve_Time < getdate()))" &
            "order by event_type"
        DGV_Paint_Data.Visible = False
            LB_PMC.Visible = True

            Try

                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim daPMC_Status As New SqlDataAdapter(query, SQLCon)
                daPMC_Status.SelectCommand.CommandTimeout = 300
                Dim dsPMC_Status As New DataSet
                daPMC_Status.Fill(dsPMC_Status, "PMC_Status")
                SQLCon.Close()

                LB_PMC.Items.Clear()
                alarm_counter = 0
                For Each drPMC_Status As DataRow In dsPMC_Status.Tables("PMC_Status").Rows
                    alarm_string = drPMC_Status("Start_Time") & "  " & drPMC_Status("Resource") & " " & drPMC_Status("Description")
                    LB_PMC.Items.Add(alarm_string)

                    Alarm_Red_Array(alarm_counter) = Convert.ToInt16(Mid(drPMC_Status("Display_Color"), 1, 3))
                    mid_string = drPMC_Status("Display_Color").split(","c)
                    Alarm_Green_Array(alarm_counter) = Convert.ToInt16(String.Join(",", mid_string, 1, 1))
                    Alarm_Blue_Array(alarm_counter) = Convert.ToInt16(String.Join(",", mid_string, 2, 1))
                    alarm_counter += 1

                Next

            Catch Ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
            WriteEvent("Error Communications Info from Database: " & Ex.Message, EventError)
            'MsgBox("Error Communications Info from Database: " & Ex.Message)
        End Try
        'End If

    End Sub

    Private Sub DGV_Paint_Data_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DGV_Paint_Data.RowPostPaint
        If e.RowIndex < Me.DGV_Paint_Data.RowCount Then
            Dim dgvRow As DataGridViewRow = Me.DGV_Paint_Data.Rows(e.RowIndex)

            Select Case dgvRow.Cells(2).Value.ToString
                Case = "Warning"
                    dgvRow.DefaultCellStyle.BackColor = Color.Orange
                Case = "Fault"
                    dgvRow.DefaultCellStyle.BackColor = Color.Red
                Case Else
                    dgvRow.DefaultCellStyle.BackColor = Color.White
            End Select

        End If
    End Sub


    Sub row_invisible(press_row As Integer)

        Me.Controls("Lbl_Press_Name" & press_row).Visible = False
        Me.Controls("Lbl_Part" & press_row).Visible = False
        'Me.Controls("Lbl_Downtime" & press_row).Visible = False
        Me.Controls("lbl_Current_Total_Rate" & press_row).Visible = False
        Me.Controls("lbl_Last_Total_Rate" & press_row).Visible = False
        Me.Controls("lbl_previous_Total_Rate" & press_row).Visible = False
        Me.Controls("Lbl_Running" & press_row).Visible = False
        Me.Controls("Lbl_Total_Actual" & press_row).Visible = False
        Me.Controls("Lbl_Current_Actual" & press_row).Visible = False
        Me.Controls("Lbl_Current_Expected" & press_row).Visible = False
        Me.Controls("Lbl_Total_Expected" & press_row).Visible = False
        Me.Controls("Lbl_Total_Parts" & press_row).Visible = False
        Me.Controls("Lbl_Total_Plus" & press_row).Visible = False
        Me.Controls("Lbl_Current_Plus" & press_row).Visible = False
        Me.Controls("lbl_Scrap_Hour" & press_row).Visible = False
        Me.Controls("Lbl_Scrap_Total" & press_row).Visible = False
        Me.Controls("Lbl_Current_Scan" & press_row).Visible = False
        Me.Controls("Lbl_Scan_Total" & press_row).Visible = False
    End Sub

    Private Sub LB_PMC_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles LB_PMC.DrawItem
        Dim myBrush As Brush
        Dim myColor As Color

        If e.Index >= 0 Then
            myColor = Color.FromArgb(Alarm_Red_Array(e.Index), Alarm_Green_Array(e.Index), Alarm_Blue_Array(e.Index))
            myBrush = New SolidBrush(myColor)

            'If e.Index Mod 2 = 0 Then
            e.Graphics.FillRectangle(myBrush, e.Bounds)
            'End If

            If LB_PMC.SelectedIndex = e.Index Then
                e.Graphics.FillRectangle(Brushes.Blue, e.Bounds)
                e.Graphics.DrawString(LB_PMC.Items(e.Index).ToString, Me.Font, Brushes.White, 0, e.Bounds.Y + 2)
            Else
                e.Graphics.DrawString(LB_PMC.Items(e.Index).ToString, Me.Font, Brushes.Black, 0, e.Bounds.Y + 2)
            End If
        End If
    End Sub

End Class
