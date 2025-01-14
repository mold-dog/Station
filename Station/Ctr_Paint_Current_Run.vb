Imports System.Data.SqlClient

Public Class Ctr_Paint_Current_Run
    Private Sub Ctr_Paint_Current_Run_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Carrier()
        Call Load_Counts()

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call Load_Carrier()
        Call Load_Counts()

    End Sub


    Sub Load_Counts()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 50
        Dim Top As Integer


        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Paint_Conveyor_Current_Batch2", SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                If Quantity_Count <= Max_Counts Then
                    '                    Write_Carrier_Data(Me.Controls("Carrier" & Quantity_Count), drCarrier("Carrier_Number"), drCarrier("Style"), drCarrier("Color"), drCarrier("Quantity"))
                    Me.Controls("lbl_Part_Type" & Quantity_Count).Text = Mid(drCounts("Part_Type") & "", 1, 25)
                    Me.Controls("lbl_Color" & Quantity_Count).Text = Mid(drCounts("color") & "", 1, 25)
                    Me.Controls("lbl_Qty" & Quantity_Count).Text = drCounts("quantity") & ""

                    Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Color" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Qty" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
            Top = 1852 - (Quantity_Count * 21) + 20
            Lbl_Job_Part_Type.Top = Top
            Lbl_Job_Color.Top = Top
            Lbl_Job_Quantity.Top = Top
            Lbl_Job_Data.Top = Top - 40
            If Lbl_Job_Data.Top < Lbl_Carrier_Style.Top Then
                LbL_Current_Paint_Color.Top = Lbl_Job_Data.Top - 50
                Lbl_Paint_Color.Top = Lbl_Job_Data.Top - 50
            Else
                LbL_Current_Paint_Color.Top = Lbl_Carrier_Style.Top - 50
                Lbl_Paint_Color.Top = Lbl_Carrier_Style.Top - 50
            End If

            Do While Quantity_Count <= Max_Counts
                Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = False
                Me.Controls("lbl_Color" & Quantity_Count).Visible = False
                Me.Controls("lbl_Qty" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop


        Catch Ex As Exception

            MsgBox("Error Getting Count Info from Database: " & Ex.Message)
        End Try



    End Sub

    Sub Load_Carrier()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 50
        Dim Top As Integer


        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Paint_Conveyor_Current_Batch", SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                Lbl_Paint_Color.Text = drCounts("Color") & ""
                If Quantity_Count <= Max_Counts Then
                    '                    Write_Carrier_Data(Me.Controls("Carrier" & Quantity_Count), drCarrier("Carrier_Number"), drCarrier("Style"), drCarrier("Color"), drCarrier("Quantity"))
                    Me.Controls("lbl_Carrier_Part_Type" & Quantity_Count).Text = Mid(drCounts("Part_Type") & "", 1, 25)
                    Me.Controls("lbl_Carrier_Qty" & Quantity_Count).Text = drCounts("quantity") & ""

                    Me.Controls("lbl_Carrier_Part_Type" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Carrier_Qty" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
            Top = 1852 - (Quantity_Count * 21) + 20
            Lbl_Part_Type_Header.Top = Top
            Lbl_Carrier_Quantity.Top = Top
            Lbl_Carrier_Style.Top = Top - 40
            Do While Quantity_Count <= Max_Counts
                Me.Controls("lbl_Carrier_Part_Type" & Quantity_Count).Visible = False
                Me.Controls("lbl_Carrier_Qty" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop



        Catch Ex As Exception

            MsgBox("Error Getting Count Info from Database: " & Ex.Message)
        End Try



    End Sub
End Class
