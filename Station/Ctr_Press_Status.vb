Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Collections.Generic


Public Class Ctr_Press_Status

    Implements INotifyPropertyChanged

    Private bindingsource1 As New BindingSource


    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged


    Private Sub NotifyPropertyChanged(info As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info)) ' New PropertyChangedEventArgs(info))
    End Sub

    Private _press As Boolean = False

    Public Property Press As Boolean
        Get
            Return _press
        End Get
        Set(ByVal value As Boolean)
            If Not (value = _press) Then
                _press = value
                NotifyPropertyChanged("Press")
            End If
        End Set
    End Property

    Private _bonder As Boolean = False

    Public Property Bonder As Boolean
        Get
            Return _bonder
        End Get
        Set(value As Boolean)
            If Not (value = _bonder) Then
                _bonder = value
                NotifyPropertyChanged("Bonder")
            End If
        End Set
    End Property



    Private _router As Boolean

    Public Property Router As Boolean
        Get
            Return _bonder
        End Get
        Set(value As Boolean)
            If Not (value = _router) Then
                _router = value
                NotifyPropertyChanged("Router")
            End If
        End Set
    End Property



    Dim ID_Array() As Int32
    'Dim ID_Array As List(Of Int32)

    Dim Press_ID As Integer
    Dim No_Operator As Integer
    Dim Auto_Logout_Counter As Integer
    'Dim Press As Boolean
    'Dim Bonder As Boolean
    'Dim Router As Boolean
    Dim Alarm_Red_Array(500) As Integer
    Dim Alarm_Green_Array(500) As Integer
    Dim Alarm_Blue_Array(500) As Integer

    Private Sub Ctr_Press_Status_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Station_ID = 0 Then

            Cmb_Press.Visible = True
            Lbl_Press_Name.Visible = False


            Call Load_Combo()


        Else
            Cmb_Press.Visible = False
            Lbl_Press_Name.Visible = True
            Lbl_Press.Visible = False

            Call Load_Label()

        End If

        DGV_Paint_Data.Font = Lbl_Font.Font
        Btn_Clear_Operators.Visible = False
        LB_PMC.DrawMode = DrawMode.OwnerDrawFixed
        LB_PMC.ItemHeight += 15


    End Sub

    Sub Load_Combo()



        Dim counter As Integer = 0
        Try
            Cmb_Press.Items.Clear()
            'ID_Array.clear()
            ReDim ID_Array(0)
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("exec Get_Press_Bonder_Info", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Press")
            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("Press").Rows
                Cmb_Press.Items.Add(dr("Description"))
                'change this to a list or hash map?
                'ID_Array.add(dr("ID"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
                ' MsgBox("Description: " & dr("Description") & vbCrLf & "ID: " & dr("ID"))
            Next

            lbl_Comm_Fail.Visible = False
            Lbl_RFID_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Press Status Screen(Load_Combo): " & Ex.Message, EventError)
            ' MsgBox("Error Getting Press Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub change_labels(sender As Object, e As PropertyChangedEventArgs) Handles Me.PropertyChanged

        ' Dim query As String
        ' Dim Bonder_ID As Integer = 0

        ' MsgBox(e.PropertyName)

        Lbl_Press.Text = e.PropertyName

        If e.PropertyName = "Press" Then

            ' query = "Select * from Press where id = " & Sub_Parameter

            _bonder = Not _press
            _router = Not _press

        ElseIf e.PropertyName = "Bonder" Then

            ' Bonder_ID = (Sub_Parameter - 100) ' not used??
            ' query = "Select * from Bonder Where ID in (1, 2)"

            _press = Not _bonder
            _router = Not _bonder

        ElseIf e.PropertyName = "Router" Then

            ' Bonder_ID = (Sub_Parameter - 100)

            _press = Not _bonder
            _router = Not _bonder

        End If



        Panel1.Visible = _bonder
        Panel3.Visible = _bonder
        Panel5.Visible = _bonder
        Panel7.Visible = _bonder
        Panel9.Visible = _bonder
        Panel11.Visible = _bonder
        Panel13.Visible = _bonder
        Panel15.Visible = _bonder
        Panel17.Visible = _bonder
        Panel19.Visible = _bonder
        Panel21.Visible = _bonder
        Panel23.Visible = _bonder
        Panel25.Visible = _bonder
        Panel27.Visible = _bonder
        Panel29.Visible = _bonder
        Panel31.Visible = _bonder
        Panel33.Visible = _bonder
        Panel35.Visible = _bonder
        Panel37.Visible = _bonder
        Panel39.Visible = _bonder
        Panel41.Visible = _bonder
        Panel43.Visible = _bonder
        Panel45.Visible = _bonder

        Panel2.Visible = _press
        Panel4.Visible = _press
        Panel6.Visible = _press
        Panel8.Visible = _press
        Panel10.Visible = _press
        Panel12.Visible = _press
        Panel14.Visible = _press
        Panel16.Visible = _press
        Panel18.Visible = _press
        Panel20.Visible = _press
        Panel22.Visible = _press
        Panel24.Visible = _press
        Panel26.Visible = _press
        Panel28.Visible = _press
        Panel30.Visible = _press
        Panel32.Visible = _press
        Panel34.Visible = _press
        Panel36.Visible = _press
        Panel38.Visible = _press
        Panel40.Visible = _press
        Panel42.Visible = _press
        Panel44.Visible = _press
        Panel46.Visible = _press


        Btn_Clear_Operators.Visible = User_Permissions_User_Management
        ' Update_Screen()

    End Sub


    Sub Load_Label()

        Dim counter As Integer = 0
        Dim query As String
        Dim Bonder_ID As Integer = 0

        If Sub_Parameter = 101 Then
            query = "Select * From Bonder Where ID in (1, 2)"

            Bonder = True

        ElseIf Sub_Parameter = 103 Then
            query = "Select * From Bonder Where ID in (3, 4, 5)"

            Router = True

        ElseIf Sub_Parameter = 105 Then
            query = "Select * From Bonder Where ID in (6, 7, 8)"

            Router = True
        Else
            query = "Select * from Press Where ID = " & Sub_Parameter

            Press = True

        End If

        ' If Sub_Parameter > 100 Then
        ' Bonder = 1
        ' Press = 0
        ' Bonder_ID = (Sub_Parameter - 100)
        ' query = "Select * from Bonder"
        ' Lbl_Press.Text = "Bonder"
        ' Panel1.Visible = True
        ' Panel3.Visible = True
        ' Panel5.Visible = True
        ' Panel7.Visible = True
        ' Panel9.Visible = True
        ' Panel11.Visible = True
        ' Panel13.Visible = True
        ' Panel15.Visible = True
        ' Panel17.Visible = True
        ' Panel19.Visible = True
        ' Panel21.Visible = True
        ' Panel23.Visible = True
        ' Panel25.Visible = True
        ' Panel27.Visible = True
        ' Panel29.Visible = True
        ' Panel31.Visible = True
        ' Panel33.Visible = True
        ' Panel35.Visible = True
        ' Panel37.Visible = True
        ' Panel39.Visible = True
        ' Panel41.Visible = True
        ' Panel43.Visible = True
        ' Panel45.Visible = True
        ' Panel2.Visible = False
        ' Panel4.Visible = False
        ' Panel6.Visible = False
        ' Panel8.Visible = False
        ' Panel10.Visible = False
        ' Panel12.Visible = False
        ' Panel14.Visible = False
        ' Panel16.Visible = False
        ' Panel18.Visible = False
        ' Panel20.Visible = False
        ' Panel22.Visible = False
        ' Panel24.Visible = False
        ' Panel26.Visible = False
        ' Panel28.Visible = False
        ' Panel30.Visible = False
        ' Panel32.Visible = False
        ' Panel34.Visible = False
        ' Panel36.Visible = False
        ' Panel38.Visible = False
        ' Panel40.Visible = False
        ' Panel42.Visible = False
        ' Panel44.Visible = False
        ' Panel46.Visible = False
        ' Else
        ' Bonder = 0
        ' Press = 1
        ' query = "Select * from Press where id = " & Sub_Parameter
        ' Lbl_Press.Text = "Press"
        ' Panel1.Visible = False
        ' Panel3.Visible = False
        ' Panel5.Visible = False
        ' Panel7.Visible = False
        ' Panel9.Visible = False
        ' Panel11.Visible = False
        ' Panel13.Visible = False
        ' Panel15.Visible = False
        ' Panel17.Visible = False
        ' Panel19.Visible = False
        ' Panel21.Visible = False
        ' Panel23.Visible = False
        ' Panel25.Visible = False
        ' Panel27.Visible = False
        ' Panel29.Visible = False
        ' Panel31.Visible = False
        ' Panel33.Visible = False
        ' Panel35.Visible = False
        ' Panel37.Visible = False
        ' Panel39.Visible = False
        ' Panel41.Visible = False
        ' Panel43.Visible = False
        ' Panel45.Visible = False
        ' Panel2.Visible = True
        ' Panel4.Visible = True
        ' Panel6.Visible = True
        ' Panel8.Visible = True
        ' Panel10.Visible = True
        ' Panel12.Visible = True
        ' Panel16.Visible = True
        ' Panel18.Visible = True
        ' Panel20.Visible = True
        ' Panel22.Visible = True
        ' Panel24.Visible = True
        ' Panel26.Visible = True
        ' Panel28.Visible = True
        ' Panel30.Visible = True
        ' Panel32.Visible = True
        ' Panel34.Visible = True
        ' Panel36.Visible = True
        ' Panel38.Visible = True
        ' Panel40.Visible = True
        ' Panel42.Visible = True
        ' Panel44.Visible = True
        ' Panel46.Visible = True
        ' End If

        Try
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim da As New SqlDataAdapter(query, SQLCon)
                da.SelectCommand.CommandTimeout = SQL_Timeout
                Dim ds As New DataSet
                da.Fill(ds, "Press")
                SQLCon.Close()
                If Press Then
                    For Each dr As DataRow In ds.Tables("Press").Rows
                        Lbl_Press_Name.Text = (dr("Description"))
                        If (dr("PLC_Comm")) <> 0 Then
                            Lbl_RFID_Fail.Visible = True
                        Else
                            Lbl_RFID_Fail.Visible = False
                        End If
                    Next
                End If
                If Bonder Then
                    counter = 0
                    For Each dr As DataRow In ds.Tables("Press").Rows
                        If counter = 0 Then
                            Lbl_Press_Name.Text = (dr("Description"))
                        End If
                        If counter > 0 Then
                            Lbl_Press_Name.Text = Lbl_Press_Name.Text & "/" & (dr("Description"))
                        End If
                        counter += 1
                    Next
                End If
                Press_ID = Sub_Parameter
                Call Update_Screen()
                lbl_Comm_Fail.Visible = False



            Catch Ex As Exception
                If SQLCon.State = ConnectionState.Open Then
                    SQLCon.Close()
                End If
                lbl_Comm_Fail.Visible = True
                WriteEvent("Error registered on Press Status Screen(Load_Label): " & Ex.Message, EventError)
                ' MsgBox("Error Getting Press Info from Database: " & Ex.Message)
            End Try




    End Sub

    Private Sub Cmb_Press_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Press.SelectedIndexChanged
        If Cmb_Press.SelectedIndex >= 0 Then
            Press_ID = ID_Array(Cmb_Press.SelectedIndex)

            If Press_ID = 101 Then
                Lbl_Press.Text = "Bonder"
                Bonder = True

            ElseIf Press_ID = 103 Then
                Lbl_Press.Text = "Router"
                Router = True

            ElseIf Press_ID = 105 Then
                Lbl_Press.Text = "Router"
                Router = True

            Else
                Lbl_Press.Text = "Press"
                Press = True

            End If

            ' If Press_ID > 100 Then
            ' Bonder = 1
            ' Press = 0
            ' Lbl_Press.Text = "Bonder"
            ' Panel1.Visible = True
            ' Panel3.Visible = True
            ' Panel5.Visible = True
            ' Panel7.Visible = True
            ' Panel9.Visible = True
            ' Panel11.Visible = True
            ' Panel13.Visible = True
            ' Panel15.Visible = True
            ' Panel17.Visible = True
            ' Panel19.Visible = True
            ' Panel21.Visible = True
            ' Panel23.Visible = True
            ' Panel25.Visible = True
            ' Panel27.Visible = True
            ' Panel29.Visible = True
            ' Panel31.Visible = True
            ' Panel33.Visible = True
            ' Panel35.Visible = True
            ' Panel37.Visible = True
            ' Panel39.Visible = True
            ' Panel41.Visible = True
            ' Panel43.Visible = True
            ' Panel45.Visible = True
            ' Panel2.Visible = False
            ' Panel4.Visible = False
            ' Panel6.Visible = False
            ' Panel8.Visible = False
            ' Panel10.Visible = False
            ' Panel12.Visible = False
            ' Panel14.Visible = False
            ' Panel16.Visible = False
            ' Panel18.Visible = False
            ' Panel20.Visible = False
            ' Panel22.Visible = False
            ' Panel24.Visible = False
            ' Panel26.Visible = False
            ' Panel28.Visible = False
            ' Panel30.Visible = False
            ' Panel32.Visible = False
            ' Panel34.Visible = False
            ' Panel36.Visible = False
            ' Panel38.Visible = False
            ' Panel40.Visible = False
            ' Panel42.Visible = False
            ' Panel44.Visible = False
            ' Panel46.Visible = False
            ' Else
            ' Bonder = 0
            ' Press = 1
            ' Lbl_Press.Text = "Press"
            ' Panel1.Visible = False
            ' Panel3.Visible = False
            ' Panel5.Visible = False
            ' Panel7.Visible = False
            ' Panel9.Visible = False
            ' Panel11.Visible = False
            ' Panel13.Visible = False
            ' Panel15.Visible = False
            ' Panel17.Visible = False
            ' Panel19.Visible = False
            ' Panel21.Visible = False
            ' Panel23.Visible = False
            ' Panel25.Visible = False
            ' Panel27.Visible = False
            ' Panel29.Visible = False
            ' Panel31.Visible = False
            ' Panel33.Visible = False
            ' Panel35.Visible = False
            ' Panel37.Visible = False
            ' Panel39.Visible = False
            ' Panel41.Visible = False
            ' Panel43.Visible = False
            ' Panel45.Visible = False
            ' Panel2.Visible = True
            ' Panel4.Visible = True
            ' Panel6.Visible = True
            ' Panel8.Visible = True
            ' Panel10.Visible = True
            ' Panel12.Visible = True
            ' Panel16.Visible = True
            ' Panel18.Visible = True
            ' Panel20.Visible = True
            ' Panel22.Visible = True
            ' Panel24.Visible = True
            ' Panel26.Visible = True
            ' Panel28.Visible = True
            ' Panel30.Visible = True
            ' Panel32.Visible = True
            ' Panel34.Visible = True
            ' Panel36.Visible = True
            ' Panel38.Visible = True
            ' Panel40.Visible = True
            ' Panel42.Visible = True
            ' Panel44.Visible = True
            ' Panel46.Visible = True
            ' End If
        End If
        ' If User_Permissions_User_Management = True Then
        ' Btn_Clear_Operators.Visible = True
        ' Else
        ' Btn_Clear_Operators.Visible = False
        ' End If
        Call Update_Screen()

    End Sub

    Private Sub Tmr_Screen_Update_Tick(sender As Object, e As EventArgs) Handles Tmr_Screen_Update.Tick
        Call Update_Screen()
    End Sub


    Sub Update_Screen()
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
        Dim rowcount As Integer
        Dim query As String
        Dim query2 As String
        Dim Bonder_ID As Integer = 0



        ' If Press_ID > 100 Then
        If Bonder Then
            'Bonder = 1
            'Press = 0
            Bonder_ID = (Press_ID - 100)
            query = "Exec Get_Bonder_Status3 " & Bonder_ID
            query2 = "Exec Get_Bonder_Users " & Bonder_ID & "," & Clear_Press_Operators
        Else
            'Bonder = 0
            'Press = 1
            query = "Exec Get_Press_Status3 " & Press_ID
            query2 = "Exec Get_Press_Users " & Press_ID & "," & Clear_Press_Operators
        End If


        Try
            If Press_ID <= 0 Then
                Exit Sub
            End If
            If Press Then
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim daCounts_Data As New SqlDataAdapter(query, SQLCon)
                daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
                Dim dsCounts As New DataSet
                daCounts_Data.Fill(dsCounts, "Counts")
                Dim daUser_Data As New SqlDataAdapter(query2, SQLCon)
                daUser_Data.SelectCommand.CommandTimeout = SQL_Timeout
                Dim dsUser As New DataSet
                daUser_Data.Fill(dsUser, "Users")
                SQLCon.Close()

                Dim daFourthShift_bit As New SqlDataAdapter("Select Enable_Fourth_Shift From Config_View", SQLCon)
                daFourthShift_bit.SelectCommand.CommandTimeout = SQL_Timeout
                Dim daFourthShift As New DataSet
                daFourthShift_bit.Fill(daFourthShift, "Fourth")

                Dim enable_fourth_shift As Boolean = False

                For Each temp_dr As DataRow In daFourthShift.Tables("Fourth").Rows
                    If temp_dr("Enable_Fourth_Shift") Then
                        enable_fourth_shift = True
                    End If
                Next




                For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                    Lbl_Part.Text = drCounts("Part_Name")
                    shift = drCounts("Shift") & ""
                    Select Case shift
                        Case "1"

                            If enable_fourth_shift Then
                                Lbl_Current_Shift.Text = "A"
                                Lbl_Last_Shift.Text = "B"
                                Lbl_Previous_Shift.Text = "C"
                                Lbl_Fourth_Shift.Text = "D"
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
                            'probably don't need this if statement
                            If enable_fourth_shift Then
                                Lbl_Current_Shift.Text = "A"
                                Lbl_Last_Shift.Text = "B"
                                Lbl_Previous_Shift.Text = "C"
                                Lbl_Fourth_Shift.Text = "D"
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


                    If enable_fourth_shift Then

                        Label27.Visible = True
                        Label28.Visible = True
                        Label32.Visible = True
                        'Label32.Text = "Average"
                        'Label28.Text = "Pieces Total"
                        'Label27.Text = "Scrap Total"
                    Else
                        Label27.Visible = False
                        Label28.Visible = False
                        Label32.Visible = False
                        'Label32.Text = ""
                        'Label28.Text = ""
                        'Label27.Text = ""
                    End If

                    If drCounts("PLC_Comm_Fail") <> 0 Then
                        Lbl_RFID_Fail.Visible = True

                    Else
                        Lbl_RFID_Fail.Visible = False
                    End If
                    Lbl_Downtime.Text = Format_Time(drCounts("Downtime") & "")

                    Lbl_Current_Shift_Total.Text = drCounts("A_Shift_Total") & ""
                    Press_Hours = Val(drCounts("A_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_Current_Total_Rate.Text = Format(Val(Lbl_Current_Shift_Total.Text) / Press_Hours, "#.0")
                    Else
                        lbl_Current_Total_Rate.Text = "0.0"
                    End If
                    Lbl_Last_Shift_Total.Text = drCounts("B_Shift_Total") & ""
                    Press_Hours = Val(drCounts("B_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_Last_Total_Rate.Text = Format(Val(Lbl_Last_Shift_Total.Text) / Press_Hours, "#.0")
                    Else
                        lbl_Last_Total_Rate.Text = "0.0"
                    End If
                    Lbl_Previous_Shift_Total.Text = drCounts("C_Shift_Total") & ""
                    Press_Hours = Val(drCounts("C_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_previous_Total_Rate.Text = Format(Val(Lbl_Previous_Shift_Total.Text) / Press_Hours, "#.0")
                    Else
                        lbl_previous_Total_Rate.Text = "0.0"
                    End If
                    Lbl_Fourth_Shift_Total.Text = "" 'drCounts("D_Shift_Total") & ""
                    Press_Hours = Val(drCounts("D_Shift_Hours") & "")

                    If enable_fourth_shift Then
                        If Press_Hours > 0 Then
                            lbl_Fourth_Total_Rate.Text = Format(Val(Lbl_Fourth_Shift_Total.Text) / Press_Hours, "#.0")
                        Else
                            lbl_Fourth_Total_Rate.Text = "0.0"
                        End If

                    Else
                        lbl_Fourth_Total_Rate.Text = ""
                    End If




                    Shift_Parts = drCounts("A_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("A_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Current_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Current_Shift_Rate.Text = "0.0"
                    End If
                    Shift_Parts = drCounts("B_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("B_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Last_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Last_Shift_Rate.Text = "0.0"
                    End If
                    Shift_Parts = drCounts("C_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("C_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Previous_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Previous_Shift_Rate.Text = "0.0"
                    End If
                    Shift_Parts = drCounts("D_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("D_Shift_Last_Hours") & "")

                    If enable_fourth_shift Then
                        If Press_Hours > 0 Then
                            Lbl_Fourth_Shift_Rate.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                        Else
                            Lbl_Fourth_Shift_Rate.Text = "0.0"
                        End If
                    Else
                        Lbl_Fourth_Shift_Rate.Text = ""
                    End If






                    Press_Hours = Val(drCounts("A_Shift_Hours") & "") + Val(drCounts("B_Shift_Hours") & "") + Val(drCounts("C_Shift_Hours") & "") + Val(drCounts("D_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        Total_Parts = Val(drCounts("A_Shift_Total") & "") + Val(drCounts("B_Shift_Total") & "") + Val(drCounts("C_Shift_Total") & "") + Val(drCounts("D_Shift_Total") & "")
                        Lbl_Total_Actual.Text = Format(Total_Parts / Press_Hours, "#.0")
                    Else
                        Lbl_Total_Actual.Text = "0.0"
                    End If

                    Lbl_Current_Actual.Text = drCounts("Current_Hour") & ""


                    Lbl_Current_Expected.Text = Format(Val(drCounts("Rate") & ""), "0.#")
                    planned = Val(Lbl_Current_Expected.Text)
                    Lbl_Total_Expected.Text = Format(Val(drCounts("Rate") & "") * Press_Hours, "0")
                    Lbl_Hours.Text = Format(Press_Hours, "0.#")

                    Lbl_Total_Plus.Text = Val(Lbl_Current_Shift_Total.Text) + Val(Lbl_Last_Shift_Total.Text) + Val(Lbl_Previous_Shift_Total.Text) + Val(Lbl_Fourth_Shift_Total.Text) - Val(Lbl_Total_Expected.Text)
                    Lbl_Total_Plus.ForeColor = Get_Color(Val(Lbl_Total_Plus.Text), planned)

                    If drCounts("Running") & "" = "1" Then
                        Lbl_Running.Text = "Running"
                        Lbl_Current_Plus.Text = Val(Lbl_Current_Actual.Text) - Val(Lbl_Current_Expected.Text)
                        Lbl_Current_Plus.ForeColor = Get_Color(Val(Lbl_Current_Plus.Text), 0)
                    Else
                        Lbl_Running.Text = "Stopped"
                        Lbl_Current_Plus.Text = "0"
                        Lbl_Current_Plus.ForeColor = Get_Color(Val(Lbl_Current_Plus.Text), 0)
                    End If

                    lbl_Current_Scan.Text = drCounts("Current_Hour_Scans") & ""
                    If (drCounts("Current_Hour_Scans") + 1 < drCounts("Current_Hour")) Or (drCounts("Current_Hour_Scans") - 1 > drCounts("Current_Hour")) Then
                        lbl_Current_Scan.BackColor = Color.Red
                    Else
                        lbl_Current_Scan.BackColor = SystemColors.Control
                    End If
                    Lbl_Scrap_Total.Text = drCounts("Total_Scrap") & ""
                    lbl_Current_Shift_Total_Scrap.Text = drCounts("A_Shift_Scrap_Total") & ""
                    lbl_Last_Shift_Total_Scrap.Text = drCounts("B_Shift_Scrap_Total") & ""
                    lbl_Previous_Shift_Total_Scrap.Text = drCounts("C_Shift_Scrap_Total") & ""
                    If enable_fourth_shift Then
                        lbl_Fourth_Shift_Total_Scrap.Text = drCounts("D_Shift_Scrap_Total") & ""
                    Else
                        lbl_Fourth_Shift_Total_Scrap.Text = ""
                    End If


                    'Set colors 
                    lbl_Current_Total_Rate.ForeColor = Get_Color(Val(lbl_Current_Total_Rate.Text), planned)
                    lbl_Last_Total_Rate.ForeColor = Get_Color(Val(lbl_Last_Total_Rate.Text), planned)
                    lbl_previous_Total_Rate.ForeColor = Get_Color(Val(lbl_previous_Total_Rate.Text), planned)
                    lbl_Fourth_Total_Rate.ForeColor = Get_Color(Val(lbl_Fourth_Total_Rate.Text), planned)
                    Lbl_Current_Shift_Rate.ForeColor = Get_Color(Val(Lbl_Current_Shift_Rate.Text), planned)
                    Lbl_Last_Shift_Rate.ForeColor = Get_Color(Val(Lbl_Last_Shift_Rate.Text), planned)
                    Lbl_Previous_Shift_Rate.ForeColor = Get_Color(Val(Lbl_Previous_Shift_Rate.Text), planned)
                    Lbl_Fourth_Shift_Rate.ForeColor = Get_Color(Val(Lbl_Fourth_Shift_Rate.Text), planned)

                    'lbl_Current_Scan.ForeColor = Get_Scrap_Color(Val(lbl_Current_Scan.Text))
                    Lbl_Scrap_Total.ForeColor = Get_Scrap_Color(Val(Lbl_Scrap_Total.Text))
                    lbl_Current_Shift_Total_Scrap.ForeColor = Get_Scrap_Color(Val(lbl_Current_Shift_Total_Scrap.Text))
                    lbl_Last_Shift_Total_Scrap.ForeColor = Get_Scrap_Color(Val(lbl_Last_Shift_Total_Scrap.Text))
                    lbl_Previous_Shift_Total_Scrap.ForeColor = Get_Scrap_Color(Val(lbl_Previous_Shift_Total_Scrap.Text))
                    lbl_Fourth_Shift_Total_Scrap.ForeColor = Get_Scrap_Color(Val(lbl_Fourth_Shift_Total_Scrap.Text))



                Next

                lblUser1.Visible = False
                lblUser2.Visible = False
                lblUser3.Visible = False
                lblUser4.Visible = False
                lblUser5.Visible = False
                rowcount = 0


                For Each drUsers As DataRow In dsUser.Tables("Users").Rows
                    rowcount = rowcount + 1
                    Select Case rowcount
                        Case = 1
                            If drUsers("User") <> "" Then
                                lblUser1.Visible = True
                                lblUser1.Text = drUsers("User")
                            End If
                        Case = 2
                            If drUsers("User") <> "" Then
                                lblUser2.Visible = True
                                lblUser2.Text = drUsers("User")
                            End If
                        Case = 3
                            If drUsers("User") <> "" Then
                                lblUser3.Visible = True
                                lblUser3.Text = drUsers("User")
                            End If
                        Case = 4
                            If drUsers("User") <> "" Then
                                lblUser4.Visible = True
                                lblUser4.Text = drUsers("User")
                            End If
                        Case = 5
                            If drUsers("User") <> "" Then
                                lblUser5.Visible = True
                                lblUser5.Text = drUsers("User")
                            End If

                    End Select



                Next


                If Lbl_Running.Text = "Running" And lblUser1.Visible = False And lblUser2.Visible = False And lblUser3.Visible = False And lblUser4.Visible = False And lblUser5.Visible = False Then
                    No_Operator = No_Operator + 1
                Else
                    No_Operator = 0
                End If
                If Press Then
                    If No_Operator > 5 Then
                        Lbl_Users.ForeColor = Color.Red
                        lbl_Warning.Visible = True
                    Else
                        Lbl_Users.ForeColor = Color.Black
                        lbl_Warning.Visible = False
                    End If
                End If
                Clear_Press_Operators = False

                If Lbl_Running.Text = "Stopped" And (lblUser1.Visible = True Or lblUser2.Visible = True Or lblUser3.Visible = True Or lblUser4.Visible = True Or lblUser5.Visible = True) Then
                    Auto_Logout_Counter = Auto_Logout_Counter + 1
                Else
                    Auto_Logout_Counter = 0
                End If

                If Auto_Logout_Counter > 5 Then
                    Clear_Press_Operators = True
                End If

            End If

            If Bonder Then

                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim daCounts_Data As New SqlDataAdapter(query, SQLCon)
                daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
                Dim dsCounts As New DataSet
                daCounts_Data.Fill(dsCounts, "Counts")
                Dim daUser_Data As New SqlDataAdapter(query2, SQLCon)
                daUser_Data.SelectCommand.CommandTimeout = SQL_Timeout
                Dim dsUser As New DataSet
                daUser_Data.Fill(dsUser, "Users")
                SQLCon.Close()

                Dim daFourthShift_bit As New SqlDataAdapter("Select Enable_Fourth_Shift From Config_View", SQLCon)
                daFourthShift_bit.SelectCommand.CommandTimeout = SQL_Timeout
                Dim daFourthShift As New DataSet
                daFourthShift_bit.Fill(daFourthShift, "Fourth")

                Dim enable_fourth_shift As Boolean = False

                For Each temp_dr As DataRow In daFourthShift.Tables("Fourth").Rows
                    If temp_dr("Enable_Fourth_Shift") Then
                        enable_fourth_shift = True
                    End If
                Next

                For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                    Lbl_Part.Text = drCounts("Part_Name")
                    shift = drCounts("Shift") & ""
                    Select Case shift
                        Case "1"
                            If enable_fourth_shift Then
                                Lbl_Current_Shift.Text = "A"
                                Lbl_Last_Shift.Text = "B"
                                Lbl_Previous_Shift.Text = "C"
                                Lbl_Fourth_Shift.Text = "D"
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


                    If enable_fourth_shift Then

                        Label27.Visible = True
                        Label28.Visible = True
                        Label32.Visible = True
                        'Label32.Text = "Average"
                        'Label28.Text = "Pieces Total"
                        'Label27.Text = "Scrap Total"
                    Else
                        Label27.Visible = False
                        Label28.Visible = False
                        Label32.Visible = False
                        'Label32.Text = ""
                        'Label28.Text = ""
                        'Label27.Text = ""
                    End If
                    Lbl_Downtime.Text = Format_Time(drCounts("Downtime") & "")

                    Lbl_Current_Shift_Total1.Text = drCounts("A_Shift_Total") & ""
                    Press_Hours = Val(drCounts("A_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_Current_Total_Rate1.Text = Format(Val(Lbl_Current_Shift_Total1.Text) / Press_Hours, "#.0")
                    Else
                        lbl_Current_Total_Rate1.Text = "0.0"
                    End If
                    Lbl_Last_Shift_Total1.Text = drCounts("B_Shift_Total") & ""
                    Press_Hours = Val(drCounts("B_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_Last_Total_Rate1.Text = Format(Val(Lbl_Last_Shift_Total1.Text) / Press_Hours, "#.0")
                    Else
                        lbl_Last_Total_Rate1.Text = "0.0"
                    End If
                    Lbl_Previous_Shift_Total1.Text = drCounts("C_Shift_Total") & ""
                    Press_Hours = Val(drCounts("C_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_previous_Total_Rate1.Text = Format(Val(Lbl_Previous_Shift_Total1.Text) / Press_Hours, "#.0")
                    Else
                        lbl_previous_Total_Rate1.Text = "0.0"
                    End If
                    Lbl_Fourth_Shift_Total1.Text = "" 'drCounts("D_Shift_Total") & ""
                    Press_Hours = Val(drCounts("D_Shift_Hours") & "")

                    If enable_fourth_shift Then
                        If Press_Hours > 0 Then
                            lbl_Fourth_Total_Rate1.Text = Format(Val(Lbl_Fourth_Shift_Total1.Text) / Press_Hours, "#.0")
                        Else
                            lbl_Fourth_Total_Rate1.Text = "0.0"
                        End If
                    Else
                        lbl_Fourth_Total_Rate1.Text = ""
                    End If




                    Shift_Parts = drCounts("A_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("A_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Current_Shift_Rate1.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Current_Shift_Rate1.Text = "0.0"
                    End If
                    Shift_Parts = drCounts("B_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("B_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Last_Shift_Rate1.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Last_Shift_Rate1.Text = "0.0"
                    End If
                    Shift_Parts = drCounts("C_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("C_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Previous_Shift_Rate1.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Previous_Shift_Rate1.Text = "0.0"
                    End If
                    Shift_Parts = drCounts("D_Shift_Parts") & ""
                    Press_Hours = Val(drCounts("D_Shift_Last_Hours") & "")

                    If enable_fourth_shift Then
                        If Press_Hours > 0 Then
                            Lbl_Fourth_Shift_Rate1.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                        Else
                            Lbl_Fourth_Shift_Rate1.Text = "0.0"
                        End If
                    Else
                        Lbl_Fourth_Shift_Rate1.Text = ""
                    End If





                    Press_Hours = Val(drCounts("A_Shift_Hours") & "") + Val(drCounts("B_Shift_Hours") & "") + Val(drCounts("C_Shift_Hours") & "") + Val(drCounts("D_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        Total_Parts = Val(drCounts("A_Shift_Total") & "") + Val(drCounts("B_Shift_Total") & "") + Val(drCounts("C_Shift_Total") & "") + Val(drCounts("D_Shift_Total") & "")
                        Lbl_Total_Actual1.Text = Format(Total_Parts / Press_Hours, "#.0")
                    Else
                        Lbl_Total_Actual1.Text = "0.0"
                    End If

                    Lbl_Current_Actual1.Text = drCounts("Current_Hour") & ""


                    Lbl_Current_Expected.Text = Format(Val(drCounts("Rate") & ""), "0.#")
                    planned = Val(Lbl_Current_Expected.Text)
                    Lbl_Total_Expected1.Text = Format(Val(drCounts("Rate") & "") * Press_Hours, "0")
                    Lbl_Hours.Text = Format(Press_Hours, "0.#")

                    Lbl_Total_Plus1.Text = Val(Lbl_Current_Shift_Total1.Text) + Val(Lbl_Last_Shift_Total1.Text) + Val(Lbl_Previous_Shift_Total1.Text) + Val(Lbl_Fourth_Shift_Total1.Text) - Val(Lbl_Total_Expected1.Text)
                    Lbl_Total_Plus1.ForeColor = Get_Color(Val(Lbl_Total_Plus1.Text), planned)

                    If drCounts("Running") & "" = "1" Then
                        Lbl_Running.Text = "Running"
                        Lbl_Current_Plus1.Text = Val(Lbl_Current_Actual1.Text) - Val(Lbl_Current_Expected.Text)
                        Lbl_Current_Plus1.ForeColor = Get_Color(Val(Lbl_Current_Plus1.Text), 0)
                    Else
                        Lbl_Running.Text = "Stopped"
                        Lbl_Current_Plus1.Text = "0"
                        Lbl_Current_Plus1.ForeColor = Get_Color(Val(Lbl_Current_Plus1.Text), 0)
                    End If

                    lbl_Current_Scan1.Text = drCounts("Current_Hour_Scans") & ""
                    If (drCounts("Current_Hour_Scans") + 1 < drCounts("Current_Hour")) Or (drCounts("Current_Hour_Scans") - 1 > drCounts("Current_Hour")) Then
                        lbl_Current_Scan1.BackColor = Color.Red
                    Else
                        lbl_Current_Scan1.BackColor = SystemColors.Control
                    End If
                    Lbl_Scrap_Total1.Text = drCounts("Total_Scrap") & ""
                    lbl_Current_Shift_Total_Scrap1.Text = drCounts("A_Shift_Scrap_Total") & ""
                    lbl_Last_Shift_Total_Scrap1.Text = drCounts("B_Shift_Scrap_Total") & ""
                    lbl_Previous_Shift_Total_Scrap1.Text = drCounts("C_Shift_Scrap_Total") & ""
                    If enable_fourth_shift Then
                        lbl_Fourth_Shift_Total_Scrap1.Text = drCounts("D_Shift_Scrap_Total") & ""
                    Else
                        lbl_Fourth_Shift_Total_Scrap1.Text = ""
                    End If


                    'Set colors 
                    lbl_Current_Total_Rate1.ForeColor = Get_Color(Val(lbl_Current_Total_Rate1.Text), planned)
                    lbl_Last_Total_Rate1.ForeColor = Get_Color(Val(lbl_Last_Total_Rate1.Text), planned)
                    lbl_previous_Total_Rate1.ForeColor = Get_Color(Val(lbl_previous_Total_Rate1.Text), planned)
                    lbl_Fourth_Total_Rate1.ForeColor = Get_Color(Val(lbl_Fourth_Total_Rate1.Text), planned)
                    Lbl_Current_Shift_Rate1.ForeColor = Get_Color(Val(Lbl_Current_Shift_Rate1.Text), planned)
                    Lbl_Last_Shift_Rate1.ForeColor = Get_Color(Val(Lbl_Last_Shift_Rate1.Text), planned)
                    Lbl_Previous_Shift_Rate1.ForeColor = Get_Color(Val(Lbl_Previous_Shift_Rate1.Text), planned)
                    Lbl_Fourth_Shift_Rate1.ForeColor = Get_Color(Val(Lbl_Fourth_Shift_Rate1.Text), planned)

                    'lbl_Current_Scan.ForeColor = Get_Scrap_Color(Val(lbl_Current_Scan.Text))
                    Lbl_Scrap_Total1.ForeColor = Get_Scrap_Color(Val(Lbl_Scrap_Total1.Text))
                    lbl_Current_Shift_Total_Scrap1.ForeColor = Get_Scrap_Color(Val(lbl_Current_Shift_Total_Scrap1.Text))
                    lbl_Last_Shift_Total_Scrap1.ForeColor = Get_Scrap_Color(Val(lbl_Last_Shift_Total_Scrap1.Text))
                    lbl_Previous_Shift_Total_Scrap1.ForeColor = Get_Scrap_Color(Val(lbl_Previous_Shift_Total_Scrap1.Text))
                    lbl_Fourth_Shift_Total_Scrap1.ForeColor = Get_Scrap_Color(Val(lbl_Fourth_Shift_Total_Scrap1.Text))



                Next

                lblUser1.Visible = False
                lblUser2.Visible = False
                lblUser3.Visible = False
                lblUser4.Visible = False
                lblUser5.Visible = False
                rowcount = 0


                For Each drUsers As DataRow In dsUser.Tables("Users").Rows
                    rowcount = rowcount + 1
                    Select Case rowcount
                        Case = 1
                            If drUsers("User") <> "" Then
                                lblUser1.Visible = True
                                lblUser1.Text = drUsers("User")
                            End If
                        Case = 2
                            If drUsers("User") <> "" Then
                                lblUser2.Visible = True
                                lblUser2.Text = drUsers("User")
                            End If
                        Case = 3
                            If drUsers("User") <> "" Then
                                lblUser3.Visible = True
                                lblUser3.Text = drUsers("User")
                            End If
                        Case = 4
                            If drUsers("User") <> "" Then
                                lblUser4.Visible = True
                                lblUser4.Text = drUsers("User")
                            End If
                        Case = 5
                            If drUsers("User") <> "" Then
                                lblUser5.Visible = True
                                lblUser5.Text = drUsers("User")
                            End If

                    End Select



                Next

                If Lbl_Running.Text = "Running" And lblUser1.Visible = False And lblUser2.Visible = False And lblUser3.Visible = False And lblUser4.Visible = False And lblUser5.Visible = False Then
                    No_Operator = No_Operator + 1
                Else
                    No_Operator = 0
                End If
                If Press Then
                    If No_Operator > 5 Then
                        Lbl_Users.ForeColor = Color.Red
                        lbl_Warning.Visible = True
                    Else
                        Lbl_Users.ForeColor = Color.Black
                        lbl_Warning.Visible = False
                    End If
                End If
                Clear_Press_Operators = False

                If Lbl_Running.Text = "Stopped" And (lblUser1.Visible = True Or lblUser2.Visible = True Or lblUser3.Visible = True Or lblUser4.Visible = True Or lblUser5.Visible = True) Then
                    Auto_Logout_Counter = Auto_Logout_Counter + 1
                Else
                    Auto_Logout_Counter = 0
                End If

                If Auto_Logout_Counter > 5 Then
                    Clear_Press_Operators = True
                End If

                query = "Exec Get_Bonder_Status3 2"
                query2 = "Exec Get_Bonder_Users 2," & Clear_Press_Operators

                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim daCounts_Data1 As New SqlDataAdapter(query, SQLCon)
                daCounts_Data1.SelectCommand.CommandTimeout = SQL_Timeout
                Dim dsCounts1 As New DataSet
                daCounts_Data1.Fill(dsCounts1, "Counts")
                Dim daUser_Data1 As New SqlDataAdapter(query2, SQLCon)
                daUser_Data1.SelectCommand.CommandTimeout = SQL_Timeout
                Dim dsUser1 As New DataSet
                daUser_Data1.Fill(dsUser1, "Users")
                SQLCon.Close()
                For Each drCounts1 As DataRow In dsCounts1.Tables("Counts").Rows
                    Lbl_Part.Text = Lbl_Part.Text & "/" & drCounts1("Part_Name")
                    'shift = drCounts("Shift") & ""
                    'Select Case shift
                    '    Case "1"
                    '        Lbl_Current_Shift.Text = "A"
                    '        Lbl_Last_Shift.Text = "B"
                    '        Lbl_Previous_Shift.Text = "C"
                    '        Lbl_Fourth_Shift.Text = "D"
                    '        Lbl_Current_Shift.BorderStyle = BorderStyle.FixedSingle
                    '        Lbl_Last_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Previous_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Fourth_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Current_Shift.BackColor = Color.Lime
                    '        Lbl_Last_Shift.BackColor = SystemColors.Control
                    '        Lbl_Previous_Shift.BackColor = SystemColors.Control
                    '        Lbl_Fourth_Shift.BackColor = SystemColors.Control
                    '    Case "2"
                    '        Lbl_Current_Shift.Text = "A"
                    '        Lbl_Last_Shift.Text = "B"
                    '        Lbl_Previous_Shift.Text = "C"
                    '        Lbl_Fourth_Shift.Text = "D"
                    '        Lbl_Current_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Last_Shift.BorderStyle = BorderStyle.FixedSingle
                    '        Lbl_Previous_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Fourth_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Current_Shift.BackColor = SystemColors.Control
                    '        Lbl_Last_Shift.BackColor = Color.Lime
                    '        Lbl_Previous_Shift.BackColor = SystemColors.Control
                    '        Lbl_Fourth_Shift.BackColor = SystemColors.Control
                    '    Case "3"
                    '        Lbl_Current_Shift.Text = "A"
                    '        Lbl_Last_Shift.Text = "B"
                    '        Lbl_Previous_Shift.Text = "C"
                    '        Lbl_Fourth_Shift.Text = "D"
                    '        Lbl_Current_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Last_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Previous_Shift.BorderStyle = BorderStyle.FixedSingle
                    '        Lbl_Fourth_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Current_Shift.BackColor = SystemColors.Control
                    '        Lbl_Last_Shift.BackColor = SystemColors.Control
                    '        Lbl_Previous_Shift.BackColor = Color.Lime
                    '        Lbl_Fourth_Shift.BackColor = SystemColors.Control
                    '    Case "4"
                    '        Lbl_Current_Shift.Text = "A"
                    '        Lbl_Last_Shift.Text = "B"
                    '        Lbl_Previous_Shift.Text = "C"
                    '        Lbl_Fourth_Shift.Text = "D"
                    '        Lbl_Current_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Last_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Previous_Shift.BorderStyle = BorderStyle.None
                    '        Lbl_Fourth_Shift.BorderStyle = BorderStyle.FixedSingle
                    '        Lbl_Current_Shift.BackColor = SystemColors.Control
                    '        Lbl_Last_Shift.BackColor = SystemColors.Control
                    '        Lbl_Previous_Shift.BackColor = SystemColors.Control
                    '        Lbl_Fourth_Shift.BackColor = Color.Lime
                    'End Select

                    'Lbl_Downtime.Text = Format_Time(drCounts("Downtime") & "")

                    Lbl_Current_Shift_Total2.Text = drCounts1("A_Shift_Total") & ""
                    Press_Hours = Val(drCounts1("A_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_Current_Total_Rate2.Text = Format(Val(Lbl_Current_Shift_Total2.Text) / Press_Hours, "#.0")
                    Else
                        lbl_Current_Total_Rate2.Text = "0.0"
                    End If
                    Lbl_Last_Shift_Total2.Text = drCounts1("B_Shift_Total") & ""
                    Press_Hours = Val(drCounts1("B_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_Last_Total_Rate2.Text = Format(Val(Lbl_Last_Shift_Total2.Text) / Press_Hours, "#.0")
                    Else
                        lbl_Last_Total_Rate2.Text = "0.0"
                    End If
                    Lbl_Previous_Shift_Total2.Text = drCounts1("C_Shift_Total") & ""
                    Press_Hours = Val(drCounts1("C_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        lbl_previous_Total_Rate2.Text = Format(Val(Lbl_Previous_Shift_Total2.Text) / Press_Hours, "#.0")
                    Else
                        lbl_previous_Total_Rate2.Text = "0.0"
                    End If

                    If enable_fourth_shift Then
                        Lbl_Fourth_Shift_Total2.Text = drCounts1("D_Shift_Total") & ""
                    Else
                        Lbl_Fourth_Shift_Total2.Text = ""
                    End If



                    If enable_fourth_shift Then
                        Press_Hours = Val(drCounts1("D_Shift_Hours") & "")

                        If Press_Hours > 0 Then
                            lbl_Fourth_Total_Rate2.Text = Format(Val(Lbl_Fourth_Shift_Total2.Text) / Press_Hours, "#.0")
                        Else
                            lbl_Fourth_Total_Rate2.Text = "0.0"
                        End If
                    Else
                        lbl_Fourth_Total_Rate2.Text = ""
                    End If




                    Shift_Parts = drCounts1("A_Shift_Parts") & ""
                    Press_Hours = Val(drCounts1("A_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Current_Shift_Rate2.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Current_Shift_Rate2.Text = "0.0"
                    End If
                    Shift_Parts = drCounts1("B_Shift_Parts") & ""
                    Press_Hours = Val(drCounts1("B_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Last_Shift_Rate2.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Last_Shift_Rate2.Text = "0.0"
                    End If
                    Shift_Parts = drCounts1("C_Shift_Parts") & ""
                    Press_Hours = Val(drCounts1("C_Shift_Last_Hours") & "")
                    If Press_Hours > 0 Then
                        Lbl_Previous_Shift_Rate2.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                    Else
                        Lbl_Previous_Shift_Rate2.Text = "0.0"
                    End If
                    Shift_Parts = drCounts1("D_Shift_Parts") & ""
                    Press_Hours = Val(drCounts1("D_Shift_Last_Hours") & "")

                    If enable_fourth_shift Then
                        If Press_Hours > 0 Then
                            Lbl_Fourth_Shift_Rate2.Text = Format(Val(Shift_Parts) / Press_Hours, "#.0")
                        Else
                            Lbl_Fourth_Shift_Rate2.Text = "0.0"
                        End If
                    Else
                        Lbl_Fourth_Shift_Rate2.Text = ""
                    End If





                    Press_Hours = Val(drCounts1("A_Shift_Hours") & "") + Val(drCounts1("B_Shift_Hours") & "") + Val(drCounts1("C_Shift_Hours") & "") + Val(drCounts1("D_Shift_Hours") & "")
                    If Press_Hours > 0 Then
                        Total_Parts = Val(drCounts1("A_Shift_Total") & "") + Val(drCounts1("B_Shift_Total") & "") + Val(drCounts1("C_Shift_Total") & "") + Val(drCounts1("D_Shift_Total") & "")
                        Lbl_Total_Actual2.Text = Format(Total_Parts / Press_Hours, "#.0")
                    Else
                        Lbl_Total_Actual2.Text = "0.0"
                    End If

                    Lbl_Current_Actual2.Text = drCounts1("Current_Hour") & ""


                    '    Lbl_Current_Expected.Text = Format(Val(drCounts("Rate") & ""), "0.#")
                    '    planned = Val(Lbl_Current_Expected.Text)
                    Lbl_Total_Expected2.Text = Format(Val(drCounts1("Rate") & "") * Press_Hours, "0")
                    '    Lbl_Hours.Text = Format(Press_Hours, "0.#")

                    Lbl_Total_Plus2.Text = Val(Lbl_Current_Shift_Total2.Text) + Val(Lbl_Last_Shift_Total2.Text) + Val(Lbl_Previous_Shift_Total2.Text) + Val(Lbl_Fourth_Shift_Total2.Text) - Val(Lbl_Total_Expected2.Text)
                    Lbl_Total_Plus2.ForeColor = Get_Color(Val(Lbl_Total_Plus2.Text), planned)

                    If drCounts1("Running") & "" = "1" Then
                        Lbl_Running.Text = "Running"
                        Lbl_Current_Plus2.Text = Val(Lbl_Current_Actual2.Text) - Val(Lbl_Current_Expected.Text)
                        Lbl_Current_Plus2.ForeColor = Get_Color(Val(Lbl_Current_Plus2.Text), 0)
                    Else
                        Lbl_Running.Text = "Stopped"
                        Lbl_Current_Plus2.Text = "0"
                        Lbl_Current_Plus2.ForeColor = Get_Color(Val(Lbl_Current_Plus2.Text), 0)
                    End If

                    lbl_Current_Scan2.Text = drCounts1("Current_Hour_Scans") & ""
                    If (drCounts1("Current_Hour_Scans") + 1 < drCounts1("Current_Hour")) Or (drCounts1("Current_Hour_Scans") - 1 > drCounts1("Current_Hour")) Then
                        lbl_Current_Scan2.BackColor = Color.Red
                    Else
                        lbl_Current_Scan2.BackColor = SystemColors.Control
                    End If
                    Lbl_Scrap_Total2.Text = drCounts1("Total_Scrap") & ""
                    lbl_Current_Shift_Total_Scrap2.Text = drCounts1("A_Shift_Scrap_Total") & ""
                    lbl_Last_Shift_Total_Scrap2.Text = drCounts1("B_Shift_Scrap_Total") & ""
                    lbl_Previous_Shift_Total_Scrap2.Text = drCounts1("C_Shift_Scrap_Total") & ""

                    If enable_fourth_shift Then
                        lbl_Fourth_Shift_Total_Scrap2.Text = drCounts1("D_Shift_Scrap_Total") & ""
                    Else
                        lbl_Fourth_Shift_Total_Scrap2.Text = ""
                    End If


                    '    'Set colors 
                    lbl_Current_Total_Rate2.ForeColor = Get_Color(Val(lbl_Current_Total_Rate2.Text), planned)
                    lbl_Last_Total_Rate2.ForeColor = Get_Color(Val(lbl_Last_Total_Rate2.Text), planned)
                    lbl_previous_Total_Rate2.ForeColor = Get_Color(Val(lbl_previous_Total_Rate2.Text), planned)
                    lbl_Fourth_Total_Rate2.ForeColor = Get_Color(Val(lbl_Fourth_Total_Rate2.Text), planned)
                    Lbl_Current_Shift_Rate2.ForeColor = Get_Color(Val(Lbl_Current_Shift_Rate2.Text), planned)
                    Lbl_Last_Shift_Rate2.ForeColor = Get_Color(Val(Lbl_Last_Shift_Rate2.Text), planned)
                    Lbl_Previous_Shift_Rate2.ForeColor = Get_Color(Val(Lbl_Previous_Shift_Rate2.Text), planned)
                    Lbl_Fourth_Shift_Rate2.ForeColor = Get_Color(Val(Lbl_Fourth_Shift_Rate2.Text), planned)

                    '    'lbl_Current_Scan2.ForeColor = Get_Scrap_Color(Val(lbl_Current_Scan2.Text))
                    Lbl_Scrap_Total2.ForeColor = Get_Scrap_Color(Val(Lbl_Scrap_Total2.Text))
                    lbl_Current_Shift_Total_Scrap2.ForeColor = Get_Scrap_Color(Val(lbl_Current_Shift_Total_Scrap2.Text))
                    lbl_Last_Shift_Total_Scrap2.ForeColor = Get_Scrap_Color(Val(lbl_Last_Shift_Total_Scrap2.Text))
                    lbl_Previous_Shift_Total_Scrap2.ForeColor = Get_Scrap_Color(Val(lbl_Previous_Shift_Total_Scrap2.Text))
                    lbl_Fourth_Shift_Total_Scrap2.ForeColor = Get_Scrap_Color(Val(lbl_Fourth_Shift_Total_Scrap2.Text))



                Next

                'lblUser1.Visible = False
                'lblUser2.Visible = False
                'lblUser3.Visible = False
                'lblUser4.Visible = False
                'lblUser5.Visible = False
                'rowcount = 0


                'For Each drUsers As DataRow In dsUser.Tables("Users").Rows
                '    rowcount = rowcount + 1
                '    Select Case rowcount
                '        Case = 1
                '            If drUsers("User") <> "" Then
                '                lblUser1.Visible = True
                '                lblUser1.Text = drUsers("User")
                '            End If
                '        Case = 2
                '            If drUsers("User") <> "" Then
                '                lblUser2.Visible = True
                '                lblUser2.Text = drUsers("User")
                '            End If
                '        Case = 3
                '            If drUsers("User") <> "" Then
                '                lblUser3.Visible = True
                '                lblUser3.Text = drUsers("User")
                '            End If
                '        Case = 4
                '            If drUsers("User") <> "" Then
                '                lblUser4.Visible = True
                '                lblUser4.Text = drUsers("User")
                '            End If
                '        Case = 5
                '            If drUsers("User") <> "" Then
                '                lblUser5.Visible = True
                '                lblUser5.Text = drUsers("User")
                '            End If

                '    End Select



                'Next

                'If Lbl_Running.Text = "Running" And lblUser1.Visible = False And lblUser2.Visible = False And lblUser3.Visible = False And lblUser4.Visible = False And lblUser5.Visible = False Then
                '    No_Operator = No_Operator + 1
                'Else
                '    No_Operator = 0
                'End If
                'If Press Then
                '    If No_Operator > 5 Then
                '        Lbl_Users.ForeColor = Color.Red
                '        lbl_Warning.Visible = True
                '    Else
                '        Lbl_Users.ForeColor = Color.Black
                '        lbl_Warning.Visible = False
                '    End If
                'End If
                'Clear_Press_Operators = False

                'If Lbl_Running.Text = "Stopped" And (lblUser1.Visible = True Or lblUser2.Visible = True Or lblUser3.Visible = True Or lblUser4.Visible = True Or lblUser5.Visible = True) Then
                '    Auto_Logout_Counter = Auto_Logout_Counter + 1
                'Else
                '    Auto_Logout_Counter = 0
                'End If

                'If Auto_Logout_Counter > 5 Then
                '    Clear_Press_Operators = True
                'End If

            End If


            _press = Not _bonder

            Call Update_Alarms()
            lbl_Comm_Fail.Visible = False


        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Press Status Screen(Update Screen): " & Ex.Message, EventError)
            ' MsgBox("Error Getting Press Info from Database: " & Ex.Message)
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
        Dim query As String
        Dim alarm_counter As Integer
        Dim alarm_string As String
        Dim mid_string As String()


        If Press Then
            DGV_Paint_Data.AutoGenerateColumns = True
            Me.Cursor = Cursors.WaitCursor
            query = "Exec Get_Press_Alarms " & Press_ID
            DGV_Paint_Data.Visible = True
            LB_PMC.Visible = False
            bindingsource1.DataSource = GetData(query)

            DGV_Paint_Data.DataSource = bindingsource1
            DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            Me.Cursor = Cursors.Default
        Else
            query = "Select PMC_Alarm_Current.Description, PMC_Resources.Resource, PMC_Alarm_Config.Event_Type, PMC_Event_Types.Display_Color, PMC_Alarm_Config.PLC, PMC_Alarm_Current.Start_Time from PMC_Alarm_Current " &
            "inner join PMC_Resources on PMC_Alarm_Current.PLC = PMC_Resources.id " &
            "inner join PMC_Alarm_Config on PMC_Alarm_Current.Alarm_Offset = PMC_Alarm_Config.Event_Number and PMC_Alarm_Current.PLC = PMC_Alarm_Config.PLC " &
            "inner join PMC_Event_Types on PMC_Alarm_Config.Event_Type = PMC_Event_Types.ID Where PMC_Resources.Enabled = 'True' and PMC_Resources.Resource = '7913' and isnull(PMC_Alarm_Config.Disabled,0) = 0 and " &
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

                ' MsgBox("Error Communications Info from Database: " & Ex.Message)
            End Try
        End If




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


    Private Sub Btn_Clear_Operators_Click(sender As Object, e As EventArgs) Handles Btn_Clear_Operators.Click
        If Cmb_Press.SelectedIndex >= 0 Then
            Press_ID = ID_Array(Cmb_Press.SelectedIndex)
            Clear_Press_Operators = True
        End If
        Call Update_Screen()
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
