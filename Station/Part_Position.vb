Imports System.Data.SqlClient

Public Class Part_Position
    Dim New_Pos As String
    Dim Local_Part_Position_RFID As String
    Private Sub Part_Position_Load(sender As Object, e As EventArgs) Handles Me.Load

        Local_Part_Position_RFID = Part_Position_RFID
        Lbl_Title.Text = Part_Position_Title
        Btn_Accept.Text = Accept_Exit
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * From Carrier_Part_Positions where ID = " & Part_Type_Positions, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Positions")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Positions").Rows
                If Not IsDBNull(dr("Pos1")) Then
                    Btn_Pos1.Visible = True
                    Btn_Pos1.Text = dr("Pos1")
                Else
                    Btn_Pos1.Visible = False
                End If
                If Not IsDBNull(dr("Pos2")) Then
                    Btn_Pos2.Visible = True
                    Btn_Pos2.Text = dr("Pos2")
                Else
                    Btn_Pos2.Visible = False
                End If
                If Not IsDBNull(dr("Pos3")) Then
                    Btn_Pos3.Visible = True
                    Btn_Pos3.Text = dr("Pos3")
                Else
                    Btn_Pos3.Visible = False
                End If
                If Not IsDBNull(dr("Pos4")) Then
                    Btn_Pos4.Visible = True
                    Btn_Pos4.Text = dr("Pos4")
                Else
                    Btn_Pos4.Visible = False
                End If
                If Not IsDBNull(dr("Pos5")) Then
                    Btn_Pos5.Visible = True
                    Btn_Pos5.Text = dr("Pos5")
                Else
                    Btn_Pos5.Visible = False
                End If
                If Not IsDBNull(dr("Pos6")) Then
                    Btn_Pos6.Visible = True
                    Btn_Pos6.Text = dr("Pos6")
                Else
                    Btn_Pos6.Visible = False
                End If
                If Not IsDBNull(dr("Pos7")) Then
                    Btn_Pos7.Visible = True
                    Btn_Pos7.Text = dr("Pos7")
                Else
                    Btn_Pos7.Visible = False
                End If
                If Not IsDBNull(dr("Pos8")) Then
                    Btn_Pos8.Visible = True
                    Btn_Pos8.Text = dr("Pos8")
                Else
                    Btn_Pos8.Visible = False
                End If
                If Not IsDBNull(dr("Pos9")) Then
                    Btn_Pos9.Visible = True
                    Btn_Pos9.Text = dr("Pos9")
                Else
                    Btn_Pos9.Visible = False
                End If
                If Not IsDBNull(dr("Pos10")) Then
                    Btn_Pos10.Visible = True
                    Btn_Pos10.Text = dr("Pos10")
                Else
                    Btn_Pos10.Visible = False
                End If
                If Not IsDBNull(dr("Pos11")) Then
                    Btn_Pos11.Visible = True
                    Btn_Pos11.Text = dr("Pos11")
                Else
                    Btn_Pos11.Visible = False
                End If
                If Not IsDBNull(dr("Pos12")) Then
                    Btn_Pos12.Visible = True
                    Btn_Pos12.Text = dr("Pos12")
                Else
                    Btn_Pos12.Visible = False
                End If
                If Not IsDBNull(dr("Pos13")) Then
                    Btn_Pos13.Visible = True
                    Btn_Pos13.Text = dr("Pos13")
                Else
                    Btn_Pos13.Visible = False
                End If
                If Not IsDBNull(dr("Pos14")) Then
                    Btn_Pos14.Visible = True
                    Btn_Pos14.Text = dr("Pos14")
                Else
                    Btn_Pos14.Visible = False
                End If

            Next
        Catch Ex As Exception
            lbl_Comm_Fail.Visible = True

            MsgBox("Error Getting Part Info from Database: " & Ex.Message)
        End Try

    End Sub

    Private Sub Btn_Pos1_Click(sender As Object, e As EventArgs) Handles Btn_Pos1.Click

        Btn_Pos1.BackColor = Color.Green
        New_Pos = Btn_Pos1.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control


    End Sub

    Private Sub Btn_Pos2_Click(sender As Object, e As EventArgs) Handles Btn_Pos2.Click

        Btn_Pos2.BackColor = Color.Green
        New_Pos = Btn_Pos2.Text
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos3_Click(sender As Object, e As EventArgs) Handles Btn_Pos3.Click
        Btn_Pos3.BackColor = Color.Green
        New_Pos = Btn_Pos3.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos4_Click(sender As Object, e As EventArgs) Handles Btn_Pos4.Click
        Btn_Pos4.BackColor = Color.Green
        New_Pos = Btn_Pos4.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos5_Click(sender As Object, e As EventArgs) Handles Btn_Pos5.Click
        Btn_Pos5.BackColor = Color.Green
        New_Pos = Btn_Pos5.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos6_Click(sender As Object, e As EventArgs) Handles Btn_Pos6.Click
        Btn_Pos6.BackColor = Color.Green
        New_Pos = Btn_Pos6.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos7_Click(sender As Object, e As EventArgs) Handles Btn_Pos7.Click
        Btn_Pos7.BackColor = Color.Green
        New_Pos = Btn_Pos7.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos8_Click(sender As Object, e As EventArgs) Handles Btn_Pos8.Click
        Btn_Pos8.BackColor = Color.Green
        New_Pos = Btn_Pos8.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos9_Click(sender As Object, e As EventArgs) Handles Btn_Pos9.Click
        Btn_Pos9.BackColor = Color.Green
        New_Pos = Btn_Pos9.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos10_Click(sender As Object, e As EventArgs) Handles Btn_Pos10.Click
        Btn_Pos10.BackColor = Color.Green
        New_Pos = Btn_Pos10.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos11_Click(sender As Object, e As EventArgs) Handles Btn_Pos11.Click
        Btn_Pos11.BackColor = Color.Green
        New_Pos = Btn_Pos11.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos12_Click(sender As Object, e As EventArgs) Handles Btn_Pos12.Click
        Btn_Pos12.BackColor = Color.Green
        New_Pos = Btn_Pos12.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos13_Click(sender As Object, e As EventArgs) Handles Btn_Pos13.Click
        Btn_Pos13.BackColor = Color.Green
        New_Pos = Btn_Pos13.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control
        Btn_Pos14.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Pos14_Click(sender As Object, e As EventArgs) Handles Btn_Pos14.Click
        Btn_Pos14.BackColor = Color.Green
        New_Pos = Btn_Pos14.Text
        Btn_Pos2.BackColor = SystemColors.Control
        Btn_Pos3.BackColor = SystemColors.Control
        Btn_Pos4.BackColor = SystemColors.Control
        Btn_Pos5.BackColor = SystemColors.Control
        Btn_Pos6.BackColor = SystemColors.Control
        Btn_Pos7.BackColor = SystemColors.Control
        Btn_Pos8.BackColor = SystemColors.Control
        Btn_Pos9.BackColor = SystemColors.Control
        Btn_Pos10.BackColor = SystemColors.Control
        Btn_Pos11.BackColor = SystemColors.Control
        Btn_Pos12.BackColor = SystemColors.Control
        Btn_Pos13.BackColor = SystemColors.Control
        Btn_Pos1.BackColor = SystemColors.Control

    End Sub

    Private Sub Btn_Accept_Click(sender As Object, e As EventArgs) Handles Btn_Accept.Click
        Dim query As String
        If Btn_Pos1.BackColor = Color.Green Or Btn_Pos2.BackColor = Color.Green Or Btn_Pos3.BackColor = Color.Green Or Btn_Pos4.BackColor = Color.Green Or
            Btn_Pos5.BackColor = Color.Green Or Btn_Pos6.BackColor = Color.Green Or
            Btn_Pos7.BackColor = Color.Green Or Btn_Pos8.BackColor = Color.Green Or Btn_Pos9.BackColor = Color.Green Or Btn_Pos10.BackColor = Color.Green Or
            Btn_Pos11.BackColor = Color.Green Or Btn_Pos12.BackColor = Color.Green Or Btn_Pos13.BackColor = Color.Green Or Btn_Pos14.BackColor = Color.Green Then
            query = "Update Part set Carrier_Position = '" & New_Pos & "' where RFID = '" & Local_Part_Position_RFID & "'  "
            query = query & "Update RFID_Defect_Inspection set Carrier_Position = '" & New_Pos & "' where ID = (Select Max(ID) from RFID_Defect_Inspection where "
            query = query & "Part_ID = (Select ID from Part where RFID = '" & Local_Part_Position_RFID & "'))"
            Try
                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()
                SQLCon.Close()
            Catch
                lbl_Comm_Fail.Visible = True
            End Try
            Threading.Thread.Sleep(1000)
            'Defect.Timer1.Enabled = True
            Manual_Defect_Refresh = True
            Part_Position_RFID = Local_Part_Position_RFID
            Me.Close()
        Else
            MsgBox(Part_Position_Msg)
        End If


    End Sub


End Class