
Imports System.Data.SqlClient
Public Class Test
    Dim Logout As Boolean
    Dim Wetsand_Complete As Boolean
    Dim Buff_Complete As Boolean
    Dim Inspection_Complete As Boolean

    Private Sub Log_Operator_Change(Logout As Boolean)
        Dim query As String
        Dim Operator_ID As Integer
        Dim Station_ID As Integer

        Operator_ID = 900
        Station_ID = 900

        If Logout = True Then
            Try
                query = "Update Station_Users set End_Time = Getdate() where Station = " & Station_ID & " and End_Time is null"
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()
                SQLCon.Close()
                Logout = False
            Catch ex As Exception
                MsgBox("Failed")
            End Try
        Else
            Try
                query = "Insert into Station_Users(Operator, Start_Time, Station) values (" & Operator_ID & ", Getdate() ," & Station_ID & ")"
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()
                SQLCon.Close()
                Logout = True
            Catch ex As Exception
                MsgBox("Failed")
            End Try
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String

        Wetsand_Complete = False
        Buff_Complete = False
        Inspection_Complete = False


        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            query = "Select * from RFID_Defect_Inspection where id = 756206"

            Dim temp_date As String = ""

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "RFID_Defect_Inspection")

            SQLCon.Close()

            For Each dr As DataRow In ds.Tables("RFID_Defect_Inspection").Rows
                If IsDBNull(dr("Wetsand_Complete")) Then
                    Wetsand_Complete = False
                Else
                    If dr("Wetsand_Complete") = True Then
                        Wetsand_Complete = True
                    Else
                        Wetsand_Complete = False
                    End If

                End If

            Next
            If Wetsand_Complete = True Then
                MsgBox("Part has already been wetsand accepted")
                Exit Sub
            End If



        Catch ex As Exception

        End Try

        'Log_Operator_Change(True)
    End Sub
End Class