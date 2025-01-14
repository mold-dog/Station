Imports System.Data.SqlClient

Public Class Ctr_Inventory_by_Area
    Dim ID_Array() As Int32
    Dim Area_ID As Integer

    Private Sub Ctr_Inventory_by_Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Station_ID = 0 Then
            Call Load_Combo()
            Cmb_Area.Visible = True
            Lbl_Area_Name.Visible = False
        Else
            Call Load_Label()
            Cmb_Area.Visible = False
            Lbl_Area_Name.Visible = True
        End If
    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from area where shipped = 0 and scrap = 0 and [Exit] = 0 order by description", SQLCon)
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


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Label()

        Dim counter As Integer = 0
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from area where id = " & Station_Area, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Area")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Area").Rows
                Lbl_Area_Name.Text = (dr("Description"))
            Next
            Area_ID = Station_Area

        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
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
    End Sub
    Sub Update_Screen()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 150


        Try
            If Area_ID <= 0 Then
                Exit Sub
            End If
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Inventory_By_Area " & Area_ID, SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                If Quantity_Count <= Max_Counts Then
                    Me.Controls("lbl_Part_Type" & Quantity_Count).Text = Mid(drCounts("Part_Type") & "", 1, 25)
                    Me.Controls("lbl_Color" & Quantity_Count).Text = Mid(drCounts("color") & "", 1, 25)
                    If Me.Controls("lbl_Color" & Quantity_Count).Text = "" Then
                        Me.Controls("lbl_Color" & Quantity_Count).Text = "Unknown"
                    End If
                    Me.Controls("lbl_Qty" & Quantity_Count).Text = drCounts("quantity") & ""

                    Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Color" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Qty" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
            Do While Quantity_Count <= Max_Counts
                Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = False
                Me.Controls("lbl_Color" & Quantity_Count).Visible = False
                Me.Controls("lbl_Qty" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop


        Catch Ex As Exception

            MsgBox("Error Getting Inventory By Area Info from Database: " & Ex.Message)
        End Try



    End Sub

End Class
