Imports System.Data.SqlClient
Public Class Door_Reader
    Dim doors() As Integer

    Private Sub Door_Reader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Doors()
    End Sub

    Sub Load_Doors()

        Dim counter As Integer = 0
        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daDoor As New SqlDataAdapter("Select * from Door_Reader where PLC_Reader_Number > 0", SQLCon)
            daDoor.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsDoor As New DataSet
            daDoor.Fill(dsDoor, "Door_Reader")
            SQLCon.Close()
            ReDim doors(0)
            For Each drDoor As DataRow In dsDoor.Tables("Door_Reader").Rows
                Cmb_Door.Items.Add(drDoor("Description"))

                ReDim Preserve doors(counter)
                doors(counter) = drDoor("PLC_Reader_Number")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Door Readers Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub DGV_Reads_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Reads.CellContentClick

    End Sub

    Private Sub Btn_Refresh_Click(sender As Object, e As EventArgs) Handles Btn_Refresh.Click
        Call Fill_Grid()
    End Sub
    Private Sub Fill_Grid()

        Try
            Dim counter As Integer = 0
            Dim start_time As DateTime


            DGV_Reads.Rows.Clear()

            If Cmb_Door.SelectedIndex < 1 Then
                Exit Sub
            End If
            If Opt_1_Minute.Checked Then
                start_time = DateAdd(DateInterval.Minute, -1, Now)
            Else
                If Opt_5_minute.Checked Then
                    start_time = DateAdd(DateInterval.Minute, -5, Now)
                Else
                    If Opt_10_Minute.Checked Then
                        start_time = DateAdd(DateInterval.Minute, -10, Now)
                    Else
                        start_time = Now
                    End If
                End If
            End If
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daReads As New SqlDataAdapter("Select * from RFID_Door_Read Where PLC_Reader = " & doors(Cmb_Door.SelectedIndex) & " and log_Date > '" & start_time & "'", SQLCon)
            daReads.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsReads As New DataSet
            daReads.Fill(dsReads, "Door_Read")
            SQLCon.Close()
            For Each drReads As DataRow In dsReads.Tables("Door_Read").Rows
                DGV_Reads.Rows.Add()
                DGV_Reads.Rows(counter).Cells.Item(0).Value = drReads("Log_date") & ""
                DGV_Reads.Rows(counter).Cells.Item(1).Value = drReads("RFID") & ""

                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Door Readers Info from Database: " & Ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call Fill_Grid()
    End Sub
End Class