Imports System.Data
Imports System.Data.SqlClient

Public Class New_RFID_Tag_Debug


    Public RFID As String = ""


    Dim Part_ID As Integer = 0

    Private Sub new_part_selected_1()
        Call Load_Data_1()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim return_val As String = ""


        return_val = InputBox("Enter the readable information from the RFID Tag:", "Get RFID Number from readable data", "")
        If Len(return_val) >= 8 Then
            Txt_Description_1.Text = Mid(return_val, 1, 4) & Mid(return_val, 5).PadLeft(20, "0")

        End If



    End Sub

    Private Sub Load_Data_1()
        Dim query As String
        If Part_ID <= 0 Then
            Exit Sub
        End If
        query = "Select Part_Type.Description as Part_Type_Desc, Final_Color.Description as Final_Color_Desc, area1.description as Area_Desc, killed, killed_date,"
        query = query & "Part.Add_Time, Part.Last_Update_Time, area2.description as Last_Location_Desc, Door_Reader.Description as Last_Reader_Desc, Part.Location_Alarm "
        query = query & "from (((((Part left join Part_Type on Part.Part_Type = Part_Type.id) left join Area Area1 on Part.Current_Location = area1.id) "
        query = query & " left join Area Area2 on Part.Last_Location = area2.id) left join Door_Reader on Part.Last_Reader = Door_Reader.id) "
        query = query & "left join Final_Color on Part.Color = Final_Color.ID) where Part.id = " & Part_ID


        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Part").Rows
            txt_Part_Type_1.Text = dr("Part_Type_Desc") & ""


        Next



    End Sub
    Private Sub Txt_Description_1_TextChanged(sender As Object, e As EventArgs) Handles Txt_Description_1.TextChanged
        Dim query As String



        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select ID from Part where rfid = '" & Txt_Description_1.Text & "'"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        Part_ID = 0

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_ID = dr("ID")
            Txt_Part_ID_1.Text = Part_ID
        Next

        Call new_part_selected_1()

    End Sub

    Private Sub new_part_selected_2()
        Call Load_Data_2()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim return_val As String = ""


        return_val = InputBox("Enter the readable information from the RFID Tag:", "Get RFID Number from readable data", "")
        If Len(return_val) >= 8 Then
            Txt_Description_2.Text = Mid(return_val, 1, 4) & Mid(return_val, 5).PadLeft(20, "0")

        End If



    End Sub

    Private Sub Load_Data_2()
        Dim query As String
        If Part_ID <= 0 Then
            Exit Sub
        End If
        query = "Select Part_Type.Description as Part_Type_Desc, Final_Color.Description as Final_Color_Desc, area1.description as Area_Desc, killed, killed_date,"
        query = query & "Part.Add_Time, Part.Last_Update_Time, area2.description as Last_Location_Desc, Door_Reader.Description as Last_Reader_Desc, Part.Location_Alarm "
        query = query & "from (((((Part left join Part_Type on Part.Part_Type = Part_Type.id) left join Area Area1 on Part.Current_Location = area1.id) "
        query = query & " left join Area Area2 on Part.Last_Location = area2.id) left join Door_Reader on Part.Last_Reader = Door_Reader.id) "
        query = query & "left join Final_Color on Part.Color = Final_Color.ID) where Part.id = " & Part_ID


        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Part").Rows
            txt_Part_Type_2.Text = dr("Part_Type_Desc") & ""


        Next



    End Sub
    Private Sub Txt_Description_2_TextChanged(sender As Object, e As EventArgs) Handles Txt_Description_2.TextChanged
        Dim query As String



        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select ID from Part where rfid = '" & Txt_Description_2.Text & "'"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        Part_ID = 0

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_ID = dr("ID")
            Txt_Part_ID_2.Text = Part_ID
        Next

        Call new_part_selected_2()

    End Sub

    Private Sub Btn_Compare_Click(sender As Object, e As EventArgs) Handles Btn_Compare.Click
        If Txt_Part_ID_1.Text < 100 Then
            MsgBox("Please select a valid part for part #1")
            Exit Sub
        End If
        If Txt_Part_ID_2.Text < 100 Then
            MsgBox("Please select a valid part for part #2")
            Exit Sub
        End If
        Compare_Part_ID_1 = Txt_Part_ID_1.Text
        Compare_Part_ID_2 = Txt_Part_ID_2.Text
        Tag_Compare_Form = New Tag_Compare
        Tag_Compare_Form.Show()
    End Sub
End Class