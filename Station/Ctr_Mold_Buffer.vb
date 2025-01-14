Imports System.Data.SqlClient

Public Class Ctr_Mold_Buffer
    Dim ID_Array() As Int32
    Dim Area_ID As Integer

    Private Sub Ctr_Mold_Buffer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Update_Screen()
    End Sub



    Private Sub Tmr_Screen_Update_Tick(sender As Object, e As EventArgs) Handles Tmr_Screen_Update.Tick
        Call Update_Screen()
    End Sub
    Sub Update_Screen()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 76
        Dim plus_value As Integer = 0

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Mold_Buffer", SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Mold_Buffer")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Mold_Buffer").Rows
                If Quantity_Count <= Max_Counts Then
                    Me.Controls("lbl_Part_Type" & Quantity_Count).Text = Mid(drCounts("part_type") & "", 1, 25)
                    Me.Controls("lbl_Scheduled" & Quantity_Count).Text = drCounts("scheduled") & ""
                    Me.Controls("lbl_Complete" & Quantity_Count).Text = drCounts("Complete") & ""
                    plus_value = Val(drCounts("Plus") & "")
                    If plus_value > 0 Then
                        Me.Controls("lbl_Plus" & Quantity_Count).Text = "+" & plus_value
                    Else
                        Me.Controls("lbl_Plus" & Quantity_Count).Text = plus_value & ""
                    End If

                    Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Scheduled" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Complete" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Plus" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
            Do While Quantity_Count <= Max_Counts
                Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = False
                Me.Controls("lbl_Scheduled" & Quantity_Count).Visible = False
                Me.Controls("lbl_Complete" & Quantity_Count).Visible = False
                Me.Controls("lbl_Plus" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop

            If Lbl_Part_Type39.Visible Then
                Lbl_Part_Type_Header2.Visible = True
                Lbl_Schedule_Header2.Visible = True
                Lbl_Complete_Header2.Visible = True
                Lbl_Plus_Header2.Visible = True
            Else
                Lbl_Part_Type_Header2.Visible = False
                Lbl_Schedule_Header2.Visible = False
                Lbl_Complete_Header2.Visible = False
                Lbl_Plus_Header2.Visible = False
            End If


            'lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            'lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Mold Buffer Screen(Update Screen): " & Ex.Message, EventError)
        End Try



    End Sub
End Class
