Imports System.Data.SqlClient

Public Class Defect_RFID_Manual_Entry
    Dim Auto_Gen_RFID As String

    Private Sub Defect_RFID_Manual_Entry_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Txt_RFID_Prefix.Text = Manual_Prefix
        Txt_RFID_Suffix.Text = Manual_Suffix
        Lbl_RFID_Label.Text = Manual_Prefix & "00000000000000" & Manual_Suffix
        Lbl_Part_Type.Text = Part_Type_Name

    End Sub

    Private Sub Defect_RFID_Manual_Entry_Load(sender As Object, e As EventArgs) Handles Me.Load
        Manual_Suffix = ""
        Auto_Gen_RFID = ""
        Txt_RFID_Prefix.Text = Manual_Prefix
        Txt_RFID_Suffix.Text = Manual_Suffix
        Lbl_RFID_Label.Text = Manual_Prefix & "00000000000000" & Manual_Suffix
        Lbl_Part_Type.Text = Part_Type_Name
        If Part_Type_Pic IsNot Nothing And Part_Type_Pic <> "" Then
            Pbx_Part_Type.Image = Image.FromFile(Image_Share & Part_Type_Pic, False)
        End If
        Lbl_Man_Entry.Text = Man_Entry_Title
        lbl_Part.Text = First_Four
        Lbl_Last_Six.Text = Last_Six
        Btn_Generate_RFID.Text = No_Readable_Code
        Btn_Accept.Text = Accept_Exit
        Btn_Exit.Text = Clear_Exit

    End Sub

    Private Sub Txt_RFID_Suffix_Click(sender As Object, e As EventArgs) Handles Txt_RFID_Suffix.Click
        Number_Keyboard_Form = New Number_Keyboard
        Number_Keyboard_Form.Show()
    End Sub

    Private Sub Btn_Generate_RFID_Click(sender As Object, e As EventArgs) Handles Btn_Generate_RFID.Click
        Dim Auto_Gen_RFID_Int As Integer = 0


        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select max(RFID) as RFID from part Where RFID Like '" & Manual_Prefix & "01000000000000%'", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Last_RFID")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Last_RFID").Rows
                If IsDBNull(dr("RFID")) Then
                    Auto_Gen_RFID = Manual_Prefix & "01000000000000000001"
                Else
                    Auto_Gen_RFID = dr("RFID")
                    Lbl_RFID_Label.Text = Auto_Gen_RFID
                End If

            Next
            Auto_Gen_RFID = Mid(Auto_Gen_RFID, 19)
            Auto_Gen_RFID_Int = CInt(Auto_Gen_RFID)
            Auto_Gen_RFID_Int += 1
            Auto_Gen_RFID = Manual_Prefix & "01000000000000" & Auto_Gen_RFID_Int.ToString("D6")
            Lbl_RFID_Label.Text = Auto_Gen_RFID
            Txt_RFID_Suffix.Text = Mid(Auto_Gen_RFID, 19)

        Catch Ex As Exception

            MsgBox("Error Getting Last RFID from Database: " & Ex.Message)
        End Try
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click

        Manual_Prefix = ""
        Manual_Suffix = ""
        Auto_Gen_RFID = ""
        Manual_Defect_Refresh = False
        Defect.Timer1.Enabled = False
        Me.Close()


    End Sub

    Private Sub Btn_Accept_Click(sender As Object, e As EventArgs) Handles Btn_Accept.Click
        Dim query As String
        If Txt_RFID_Suffix.TextLength <> 6 Then
            MsgBox(Six_Character_Msg)
            Exit Sub
        End If

        Try
            query = "Exec New_Station_Read '" & Lbl_RFID_Label.Text & "', " & PLC_Station & ", 1 "
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()
        Catch ex As Exception
            MsgBox("Error Inserting RFID into Database: " & ex.Message)
        End Try
        Manual_Defect_Refresh = True
        'Defect.Timer1.Enabled = False
        Me.Close()
    End Sub
End Class