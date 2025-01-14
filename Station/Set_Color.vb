Imports System.Data
Imports System.Data.SqlClient

Public Class Set_Color
    Public Part_ID As Integer = 0

    Dim Final_Color_Array() As Int32

    Private Sub Set_Color_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim query As String
        Dim Part_Type_ID As Integer = 0

        If Part_ID <= 0 Then
            Exit Sub
        End If
        query = "Select Part_Type.ID as Part_Type_ID, Part_Type.Description as Part_Type_Desc, part.rfid "

        If Defect_Form.TrainingStation Then
            query = query & "from Part left join RFID.dbo.Part_Type on Part.Part_Type = Part_Type.id where Part.id = " & Part_ID
        Else
            query = query & "from Part left join Part_Type on Part.Part_Type = Part_Type.id where Part.id = " & Part_ID
        End If



        'SQLCon.ConnectionString = DBConnection
        'SQLCon.Open()
        'Dim da As New SqlDataAdapter(query, SQLCon)
        ' da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As DataSet = Defect_Form.queryDB(query, "Part", True)
        'da.Fill(ds, "Part")
        'SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Part").Rows
            Txt_RFID.Text = dr("rfid") & ""
            txt_Part_Type.Text = dr("Part_Type_Desc") & ""
            Part_Type_ID = Val(dr("Part_Type_ID") & "")
        Next

        Call Load_Colors(Part_Type_ID)

    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        'Check for Valid Data

        If Cmb_Final_Color.SelectedIndex < 0 Then
            MsgBox("Please select a valid Color")
            Exit Sub
        End If
        If Part_ID <= 0 Then
            MsgBox("Invalid Part, unable to set color.")
            Me.Close()
            Exit Sub
        End If
        query = "update Part Set Color = " & Final_Color_Array(Cmb_Final_Color.SelectedIndex) & ", Color_Override = 1 where id = " & Part_ID
        Defect_Form.queryDB(query, "temp", True)
        'SQLCon.Open()
        'Dim cmd As New SqlCommand(query, SQLCon)
        'cmd.ExecuteNonQuery()
        'SQLCon.Close()

        Me.Close()

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub

    Sub Load_Colors(Part_Type_ID As Integer)
        Dim query As String = ""
        Dim counter As Integer = 0
        Try

            query = "Select distinct Final_Color.ID, Final_Color.Description, Final_Color.Spanish from Final_Color inner join Final_Part on Final_Color.id = final_Part.final_color_id "
            query = query & " where final_part.part_type_id = " & Part_Type_ID & " and getdate() between final_color.start_date and final_color.end_date "
            query = query & " order by final_color.description"
            Cmb_Final_Color.Items.Clear()
            'SQLCon.ConnectionString = DBConnection
            'SQLCon.Open()
            'Dim da As New SqlDataAdapter(query, SQLCon)
            'da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As DataSet = Defect_Form.queryDB(query, "Final_Color", False)
            'da.Fill(ds, "Final_Color")
            SQLCon.Close()
            ReDim Final_Color_Array(0)
            For Each dr As DataRow In ds.Tables("Final_Color").Rows
                If Spanish Then
                    If Len(dr("Spanish") & "") > 0 Then
                        Cmb_Final_Color.Items.Add(dr("Spanish") & "")
                    Else
                        Cmb_Final_Color.Items.Add(dr("Description") & "")
                    End If
                Else
                    Cmb_Final_Color.Items.Add(dr("Description") & "")
                End If
                ReDim Preserve Final_Color_Array(counter)
                Final_Color_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Color Info from Database: " & Ex.Message)
        End Try



    End Sub

End Class