Imports System.Data.SqlClient

Public Class Ctr_Robot_Status
    Dim Robot_Part_Change_Form As Robot_Part_Change
    Private Sub Ctr_Robot_Status_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Data()
        Call Load_Counts()



    End Sub

    Sub Load_Data()
        Dim query As String = ""
        Dim Robot_Number As Integer = 0

        query = "Select Robot_Number, Bell_Table.Description as Bell_Desc, Bell_Updated, Spray_Head_Table.Description as Spray_Head_Desc, Spray_Head_Updated, "
        query = query & " Air_Cap_Table.Description As Air_Cap_Desc, Air_Cap_Updated, Retaining_Ring_Table.Description As Retaining_Ring_Desc, Retaining_Ring_Updated "
        query = query & " from (((Robot_Status left join Robot_Part Bell_Table On Robot_Status.Bell = Bell_Table.id)"
        query = query & " Left Join Robot_Part Spray_Head_Table On Robot_Status.Spray_Head = Spray_Head_Table.Id) "
        query = query & " left join Robot_Part Air_Cap_Table On Robot_Status.Air_Cap = Air_Cap_Table.ID) "
        query = query & " left join Robot_Part Retaining_Ring_Table On Robot_Status.Retaining_Ring = Retaining_Ring_Table.ID order by Robot_Number"
        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = 120
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Status")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Robot_Status").Rows

                Robot_Number = Val(dr("Robot_Number") & "")
                Select Case Robot_Number
                    Case 1
                        Lbl_B1_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_B1_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_B1_Bell_Updated.Text = ""
                        End If
                        Lbl_B1_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_B1_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_B1_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_B1_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_B1_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_B1_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_B1_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_B1_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_B1_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 2
                        Lbl_B2_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_B2_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_B2_Bell_Updated.Text = ""
                        End If
                        Lbl_B2_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_B2_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_B2_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_B2_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_B2_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_B2_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_B2_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_B2_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_B2_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 3
                        Lbl_B3_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_B3_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_B3_Bell_Updated.Text = ""
                        End If
                        Lbl_B3_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_B3_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_B3_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_B3_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_B3_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_B3_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_B3_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_B3_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_B3_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 4
                        Lbl_B4_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_B4_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_B4_Bell_Updated.Text = ""
                        End If
                        Lbl_B4_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_B4_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_B4_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_B4_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_B4_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_B4_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_B4_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_B4_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_B4_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 5
                        Lbl_C1_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_C1_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_C1_Bell_Updated.Text = ""
                        End If
                        Lbl_C1_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_C1_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_C1_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_C1_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_C1_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_C1_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_C1_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_C1_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_C1_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 6
                        Lbl_C2_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_C2_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_C2_Bell_Updated.Text = ""
                        End If
                        Lbl_C2_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_C2_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_C2_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_C2_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_C2_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_C2_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_C2_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_C2_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_C2_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 7
                        Lbl_C3_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_C3_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_C3_Bell_Updated.Text = ""
                        End If
                        Lbl_C3_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_C3_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_C3_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_C3_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_C3_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_C3_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_C3_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_C3_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_C3_Retaining_Ring_Updated.Text = ""
                        End If
                    Case 8
                        Lbl_C4_Bell.Text = dr("Bell_Desc") & ""
                        If IsDate(dr("Bell_Updated") & "") Then
                            Lbl_C4_Bell_Updated.Text = Format(dr("Bell_Updated"), "M/d H:mm")
                        Else
                            Lbl_C4_Bell_Updated.Text = ""
                        End If
                        Lbl_C4_Spray_Head.Text = dr("Spray_Head_Desc") & ""
                        If IsDate(dr("Spray_Head_Updated") & "") Then
                            Lbl_C4_Spray_Head_Updated.Text = Format(dr("Spray_Head_Updated"), "M/d H:mm")
                        Else
                            Lbl_C4_Spray_Head_Updated.Text = ""
                        End If
                        Lbl_C4_Air_Cap.Text = dr("Air_Cap_Desc") & ""
                        If IsDate(dr("Air_Cap_Updated") & "") Then
                            Lbl_C4_Air_Cap_Updated.Text = Format(dr("Air_Cap_Updated"), "M/d H:mm")
                        Else
                            Lbl_C4_Air_Cap_Updated.Text = ""
                        End If
                        Lbl_C4_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
                        If IsDate(dr("Retaining_Ring_Updated") & "") Then
                            Lbl_C4_Retaining_Ring_Updated.Text = Format(dr("Retaining_Ring_Updated"), "M/d H:mm")
                        Else
                            Lbl_C4_Retaining_Ring_Updated.Text = ""
                        End If
                End Select

            Next

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Robot Status Screen(Load_Data): " & Ex.Message, EventError)
            'MsgBox("Error Getting Robot Status Info from Database: " & Ex.Message)
        End Try



    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call Load_Data()
        Call Load_Counts()

    End Sub

    Sub Load_Counts()
        Dim Last_Robot_Number As Integer = 1
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 18

        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Exec Robot_Status_Last2", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Last_Combination")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Last_Combination").Rows
                Me.Controls("Lbl_Last_" & dr("Robot_Number") & "_Bell").Text = dr("Bell") & ""
                Me.Controls("Lbl_Last_" & dr("Robot_Number") & "_Spray_Head").Text = dr("Spray_Head") & ""
                Me.Controls("Lbl_Last_" & dr("Robot_Number") & "_Air_Cap").Text = dr("Air_Cap") & ""
                Me.Controls("Lbl_Last_" & dr("Robot_Number") & "_Retaining_Ring").Text = dr("Retaining_Ring") & ""
                Me.Controls("Lbl_Last_" & dr("Robot_Number") & "_Start_Time").Text = dr("Start_Time") & ""
                Me.Controls("Lbl_Last_" & dr("Robot_Number") & "_End_Time").Text = dr("End_Time") & ""
                Me.Controls("Lbl_" & dr("Robot_Number") & "_Start_Time").Text = dr("End_Time") & ""
            Next


            da.SelectCommand.CommandText = "Robot_Status_Colors"
            da.Fill(ds, "Colors")
            For Each dr As DataRow In ds.Tables("Colors").Rows
Next_Robot:
                If Last_Robot_Number > 8 Then
                    Exit Sub
                End If
                If dr("Robot_Number") <> Last_Robot_Number Then
                    Do While Quantity_Count <= Max_Counts
                        Me.Controls("Lbl_" & Last_Robot_Number & "_Color_" & Quantity_Count).Visible = False
                        Quantity_Count += 1
                    Loop
                    Last_Robot_Number += 1
                    Quantity_Count = 1
                    GoTo Next_Robot
                End If
                If Quantity_Count <= Max_Counts Then
                    Me.Controls("Lbl_" & Last_Robot_Number & "_Color_" & Quantity_Count).Text = Mid(dr("Color") & "", 1, 32)
                    Me.Controls("Lbl_" & Last_Robot_Number & "_Color_" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
Finish_Robots:

            If Last_Robot_Number > 8 Then
                Exit Sub
            End If
            Do While Quantity_Count <= Max_Counts
                Me.Controls("Lbl_" & Last_Robot_Number & "_Color_" & Quantity_Count).Visible = False
                Quantity_Count += 1
            Loop
            Last_Robot_Number += 1
            Quantity_Count = 1
            GoTo Finish_Robots


            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Robot Status Screen(Load_Counts): " & Ex.Message, EventError)

            'MsgBox("Error Getting Count Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Update_B1_Click(sender As Object, e As EventArgs) Handles Btn_Update_B1.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 1
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()


    End Sub

    Private Sub Btn_Update_B2_Click(sender As Object, e As EventArgs) Handles Btn_Update_B2.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 2
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_Update_B3_Click(sender As Object, e As EventArgs) Handles Btn_Update_B3.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 3
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_Update_B4_Click(sender As Object, e As EventArgs) Handles Btn_Update_B4.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 4
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_Update_C1_Click(sender As Object, e As EventArgs) Handles Btn_Update_C1.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 5
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_Update_C2_Click(sender As Object, e As EventArgs) Handles Btn_Update_C2.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 6
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_Update_C3_Click(sender As Object, e As EventArgs) Handles Btn_Update_C3.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 7
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_Update_C4_Click(sender As Object, e As EventArgs) Handles Btn_Update_C4.Click
        Robot_Part_Change_Form = New Robot_Part_Change
        Robot_Part_Change_Form.Robot_Number = 8
        Robot_Part_Change_Form.ShowDialog()
        Call Load_Data()

    End Sub

    Private Sub Btn_B1_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_B1_View_Parts.Click
        Call Get_Conveyor_Times(1, Lbl_1_Start_Time.Text, Now)
    End Sub

    Private Sub Get_Conveyor_Times(ByVal Robot As Integer, ByVal Start_Time As String, ByVal End_Time As String)
        Dim query As String = ""
        Dim Return_Start_Time As String = ""
        Dim Return_End_Time As String = ""

        query = "Exec Get_Robot_Conveyor_Times " & Robot & ", '" & Start_Time & "', '" & End_Time & "'"
        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = 120
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Conveyor_Times")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Robot_Conveyor_Times").Rows
                Return_Start_Time = dr("Start_Time") & ""
                Return_End_Time = dr("End_Time") & ""
            Next


            Paint_Production_Query_Form = New Paint_Production_Query
            Paint_Production_Query_Form.Start_Date = Return_Start_Time
            Paint_Production_Query_Form.End_Date = Return_End_Time
            Paint_Production_Query_Form.Show()
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Robot Status Screen(Get Conveyor Times): " & Ex.Message, EventError)
        End Try



    End Sub

    Private Sub Btn_B2_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_B2_View_Parts.Click
        Call Get_Conveyor_Times(2, Lbl_2_Start_Time.Text, Now)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Get_Conveyor_Times(3, Lbl_3_Start_Time.Text, Now)

    End Sub

    Private Sub Btn_B4_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_B4_View_Parts.Click
        Call Get_Conveyor_Times(4, Lbl_4_Start_Time.Text, Now)

    End Sub

    Private Sub Btn_C1_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_C1_View_Parts.Click
        Call Get_Conveyor_Times(5, Lbl_5_Start_Time.Text, Now)

    End Sub

    Private Sub Btn_C2_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_C2_View_Parts.Click
        Call Get_Conveyor_Times(6, Lbl_6_Start_Time.Text, Now)

    End Sub

    Private Sub Btn_C3_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_C3_View_Parts.Click
        Call Get_Conveyor_Times(7, Lbl_7_Start_Time.Text, Now)

    End Sub

    Private Sub Btn_C4_View_Parts_Click(sender As Object, e As EventArgs) Handles Btn_C4_View_Parts.Click
        Call Get_Conveyor_Times(8, Lbl_8_Start_Time.Text, Now)

    End Sub

    Private Sub Btn_Last_B1_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_B1_View.Click
        Call Get_Conveyor_Times(1, Lbl_Last_1_Start_Time.Text, Lbl_Last_1_End_Time.Text)

    End Sub

    Private Sub Btn_Last_B2_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_B2_View.Click
        Call Get_Conveyor_Times(2, Lbl_Last_2_Start_Time.Text, Lbl_Last_2_End_Time.Text)

    End Sub

    Private Sub Btn_Last_B3_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_B3_View.Click
        Call Get_Conveyor_Times(3, Lbl_Last_3_Start_Time.Text, Lbl_Last_3_End_Time.Text)

    End Sub

    Private Sub Btn_Last_B4_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_B4_View.Click
        Call Get_Conveyor_Times(4, Lbl_Last_4_Start_Time.Text, Lbl_Last_4_End_Time.Text)

    End Sub

    Private Sub Btn_Last_C1_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_C1_View.Click
        Call Get_Conveyor_Times(5, Lbl_Last_5_Start_Time.Text, Lbl_Last_5_End_Time.Text)

    End Sub

    Private Sub Btn_Last_C2_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_C2_View.Click
        Call Get_Conveyor_Times(6, Lbl_Last_6_Start_Time.Text, Lbl_Last_6_End_Time.Text)

    End Sub

    Private Sub Btn_Last_C3_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_C3_View.Click
        Call Get_Conveyor_Times(7, Lbl_Last_7_Start_Time.Text, Lbl_Last_7_End_Time.Text)

    End Sub

    Private Sub Btn_Last_C4_View_Click(sender As Object, e As EventArgs) Handles Btn_Last_C4_View.Click
        Call Get_Conveyor_Times(8, Lbl_Last_8_Start_Time.Text, Lbl_Last_8_End_Time.Text)

    End Sub

    Private Sub Btn_Paint_Coveyor_Click(sender As Object, e As EventArgs) Handles Btn_Paint_Coveyor.Click
        Paint_Conveyor_Form = New Paint_Conveyor
        Paint_Conveyor_Form.Show()

    End Sub



    Private Sub Btn_Test_Panel_Click(sender As Object, e As EventArgs) Handles Btn_Test_Panel.Click
        Test_Panel_Form = New Test_Panel
        Test_Panel_Form.Show()
    End Sub
End Class
