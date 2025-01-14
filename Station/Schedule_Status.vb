Imports System.Data.SqlClient



Public Class Schedule_Status

    Private Sub Schedule_Status_Load(sender As Object, e As EventArgs) Handles Me.Load
        Panel1.Visible = True
        Call Update_Completed_to_Ship()
        Call Update_FTB_data()
    End Sub


    Private Sub Tmr_Screen_Update_Tick(sender As Object, e As EventArgs) Handles Tmr_Screen_Update.Tick
        Call Update_Completed_to_Ship()
        Call Update_FTB_data()
    End Sub


    Private Sub Update_Completed_to_Ship()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 58
        Dim plus_value As Integer = 0

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Completed_to_Ship " & 0, SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Completed_to_Ship")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Completed_to_Ship").Rows
                If Quantity_Count <= Max_Counts Then

                    Panel1.Controls("lbl_CTS_Part_Type" & Quantity_Count).Text = Mid(drCounts("part_type") & "", 1, 25)
                    Panel1.Controls("lbl_Color" & Quantity_Count).Text = Mid(drCounts("Color") & "", 1, 25)
                    Panel1.Controls("lbl_Scheduled" & Quantity_Count).Text = drCounts("scheduled") & ""
                    Panel1.Controls("lbl_Complete" & Quantity_Count).Text = drCounts("Complete") & ""
                    plus_value = Val(drCounts("Plus") & "")
                    If plus_value > 0 Then
                        Panel1.Controls("lbl_Plus" & Quantity_Count).Text = "+" & plus_value
                    Else
                        Panel1.Controls("lbl_Plus" & Quantity_Count).Text = plus_value & ""
                    End If
                    Panel1.Controls("lbl_WS" & Quantity_Count).Text = drCounts("WS_Counts") & ""
                    Panel1.Controls("lbl_FI" & Quantity_Count).Text = drCounts("Buff_Counts") & ""
                    Panel1.Controls("lbl_IP" & Quantity_Count).Text = drCounts("FI_Counts") & ""
                    Panel1.Controls("lbl_CTS_Part_Type" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_Color" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_Scheduled" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_Complete" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_Plus" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_WS" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_FI" & Quantity_Count).Visible = True
                    Panel1.Controls("lbl_IP" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
            Panel1.Height = 30 + (Quantity_Count * 14)

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
                Panel1.Controls("lbl_CTS_Part_Type" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_Color" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_Scheduled" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_Complete" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_Plus" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_WS" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_FI" & Quantity_Count).Visible = False
                Panel1.Controls("lbl_IP" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop

            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True

            'MsgBox("Error Getting Completed to Ship Info from Database: " & Ex.Message)
        End Try

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
            '            MsgBox("Error Getting First Time Quality Info from Database: " & Ex.Message)
            lbl_Comm_Fail.Visible = True
        End Try



    End Sub


End Class