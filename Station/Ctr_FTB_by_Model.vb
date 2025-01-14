Imports System.Data.SqlClient

Public Class Ctr_FTB_by_Model
    Private Sub Ctr_FTB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FTB_Loaded = False Then
            FTB_Loaded = True
        Else
            Exit Sub
        End If
        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da_Data As New SqlDataAdapter("Select * From Headers", SQLCon)
        da_Data.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da_Data.Fill(ds, "Headers")
        For Each dr As DataRow In ds.Tables("Headers").Rows
            Lbl_Header_Paint.Text = dr("FTQ_Paint") & ""
            Lbl_Header_Finesse.Text = dr("FTQ_Finesse") & ""
            Lbl_Header_Total.Text = dr("FTQ_Total1") & ""
            Lbl_Header_Total2.Text = dr("FTQ_Total2") & ""
            Lbl_Header_Total3.Text = dr("FTQ_Total3") & ""
            Lbl_Header_Ratio.Text = dr("FTQ_Ratio") & ""
        Next


        Dim da_Data2 As New SqlDataAdapter("select FTB_Model_Date from [Parameters]", SQLCon)
        da_Data2.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds2 As New DataSet
        da_Data2.Fill(ds2, "Model_Date")
        SQLCon.Close()
        DTP_Start_Date.Text = Now()
        For Each dr2 As DataRow In ds2.Tables("Model_Date").Rows
            DTP_Start_Date.Text = dr2("FTB_Model_Date") & ""
        Next

        DTP_End_Date.Text = DateAdd(DateInterval.Day, 1, Now())

        Call Update_data()

    End Sub


    Private Sub Ctr_FTB_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        FTB_Loaded = False
    End Sub
    Sub Update_data()
        Dim day_value As Double
        Dim week_value As Double
        Dim query As String = ""

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            query = "exec Get_FTB_By_Model '" & DTP_Start_Date.Text & "', '" & DTP_End_Date.Text & "'"

            Dim daCounts_Data As New SqlDataAdapter(query, SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                lbl_Paint_Day.Text = Format(drCounts("Paint_Day") & "", "fixed") & " %"
                lbl_Finesse_Day.Text = Format(drCounts("Finesse_Day") & "", "fixed") & " %"
                lbl_Total_Day.Text = Format(drCounts("Total_Day") & "", "fixed") & " %"
                lbl_Total2_Day.Text = Format(drCounts("Total2_Day") & "", "fixed") & " %"
                lbl_Total3_Day.Text = Format(drCounts("Total3_Day") & "", "fixed") & " %"
                lbl_Ratio_Day.Text = Format(drCounts("Ratio_Day") & "", "fixed") & ""

                lbl_Paint_Week.Text = Format(drCounts("Paint_Week") & "", "fixed") & " %"
                lbl_Finesse_Week.Text = Format(drCounts("Finesse_Week") & "", "fixed") & " %"
                lbl_Total_Week.Text = Format(drCounts("Total_Week") & "", "fixed") & " %"
                lbl_Total2_Week.Text = Format(drCounts("Total2_Week") & "", "fixed") & " %"
                lbl_Total3_Week.Text = Format(drCounts("Total3_Week") & "", "fixed") & " %"
                lbl_Ratio_Week.Text = Format(drCounts("Ratio_Week") & "", "fixed") & ""

                lbl_Paint_Month.Text = Format(drCounts("Paint_Month") & "", "fixed") & " %"
                lbl_Finesse_Month.Text = Format(drCounts("Finesse_Month") & "", "fixed") & " %"
                lbl_Total_Month.Text = Format(drCounts("Total_Month") & "", "fixed") & " %"
                lbl_Total2_Month.Text = Format(drCounts("Total2_Month") & "", "fixed") & " %"
                lbl_Total3_Month.Text = Format(drCounts("Total3_Month") & "", "fixed") & " %"
                lbl_Ratio_Month.Text = Format(drCounts("Ratio_Month") & "", "fixed") & ""

                lbl_Paint_90.Text = Format(drCounts("Paint_90") & "", "fixed") & " %"
                lbl_Finesse_90.Text = Format(drCounts("Finesse_90") & "", "fixed") & " %"
                lbl_Total_90.Text = Format(drCounts("Total_90") & "", "fixed") & " %"
                lbl_Total2_90.Text = Format(drCounts("Total2_90") & "", "fixed") & " %"
                lbl_Total3_90.Text = Format(drCounts("Total3_90") & "", "fixed") & " %"
                lbl_Ratio_90.Text = Format(drCounts("Ratio_90") & "", "fixed") & ""

                lbl_Paint_Model.Text = Format(drCounts("Paint_Model") & "", "fixed") & " %"
                lbl_Finesse_Model.Text = Format(drCounts("Finesse_Model") & "", "fixed") & " %"
                lbl_Total_Model.Text = Format(drCounts("Total_Model") & "", "fixed") & " %"
                lbl_Total2_Model.Text = Format(drCounts("Total2_Model") & "", "fixed") & " %"
                lbl_Total3_Model.Text = Format(drCounts("Total3_Model") & "", "fixed") & " %"
                lbl_Ratio_Model.Text = Format(drCounts("Ratio_Model") & "", "fixed") & ""


                If IsNumeric(drCounts("Paint_Day") & "") And IsNumeric(drCounts("Paint_Week") & "") Then
                    day_value = Val(drCounts("Paint_Day") & "")
                    week_value = Val(drCounts("Paint_Week") & "")
                    If day_value > week_value Then
                        lbl_Paint_Status.Text = "↑"
                        Pnl_Paint.BackColor = Color.Green
                    Else
                        If day_value < week_value Then
                            lbl_Paint_Status.Text = "↓"
                            Pnl_Paint.BackColor = Color.Red
                        Else
                            lbl_Paint_Status.Text = "-"
                            Pnl_Paint.BackColor = Color.Gray
                        End If
                    End If
                End If

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

                If IsNumeric(drCounts("Total_Day") & "") And IsNumeric(drCounts("Total_Week") & "") Then
                    day_value = Val(drCounts("Total_Day") & "")
                    week_value = Val(drCounts("Total_Week") & "")
                    If day_value > week_value Then
                        lbl_Total_Status.Text = "↑"
                        Pnl_Total.BackColor = Color.Green
                    Else
                        If day_value < week_value Then
                            lbl_Total_Status.Text = "↓"
                            Pnl_Total.BackColor = Color.Red
                        Else
                            lbl_Total_Status.Text = "-"
                            Pnl_Total.BackColor = Color.Gray
                        End If
                    End If
                End If


                If IsNumeric(drCounts("Total2_Day") & "") And IsNumeric(drCounts("Total2_Week") & "") Then
                    day_value = Val(drCounts("Total2_Day") & "")
                    week_value = Val(drCounts("Total2_Week") & "")
                    If day_value > week_value Then
                        lbl_Total2_Status.Text = "↑"
                        Pnl_Total2.BackColor = Color.Green
                    Else
                        If day_value < week_value Then
                            lbl_Total2_Status.Text = "↓"
                            Pnl_Total2.BackColor = Color.Red
                        Else
                            lbl_Total2_Status.Text = "-"
                            Pnl_Total2.BackColor = Color.Gray
                        End If
                    End If
                End If


                If IsNumeric(drCounts("Total3_Day") & "") And IsNumeric(drCounts("Total3_Week") & "") Then
                    day_value = Val(drCounts("Total3_Day") & "")
                    week_value = Val(drCounts("Total3_Week") & "")
                    If day_value > week_value Then
                        lbl_Total3_Status.Text = "↑"
                        Pnl_Total3.BackColor = Color.Green
                    Else
                        If day_value < week_value Then
                            lbl_Total3_Status.Text = "↓"
                            Pnl_Total3.BackColor = Color.Red
                        Else
                            lbl_Total3_Status.Text = "-"
                            Pnl_Total3.BackColor = Color.Gray
                        End If
                    End If
                End If


                If IsNumeric(drCounts("Ratio_Day") & "") And IsNumeric(drCounts("Ratio_Week") & "") Then
                    day_value = Val(drCounts("Ratio_Day") & "")
                    week_value = Val(drCounts("Ratio_Week") & "")
                    If day_value > week_value Then
                        lbl_Ratio_Status.Text = "↑"
                        Pnl_Ratio.BackColor = Color.Red
                    Else
                        If day_value < week_value Then
                            lbl_Ratio_Status.Text = "↓"
                            Pnl_Ratio.BackColor = Color.Green
                        Else
                            lbl_Ratio_Status.Text = "-"
                            Pnl_Ratio.BackColor = Color.Gray
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

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Call Update_data()

    End Sub
End Class
