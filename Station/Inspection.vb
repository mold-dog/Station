Imports System.Data
Imports System.Data.SqlClient
Public Class Inspection

    '    Dim ID_Array() As Integer
    '    Dim Part_Type_Array() As Integer
    Dim Inspection_Array() As Integer
    Public RFID As String
    Private bindingsource_part As New BindingSource
    Dim Part_ID As Integer = 0
    Dim edit_text As String = ""
    Dim save_text As String = ""

    Private Sub Inspection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Spanish Then
            get_spanish()
        Else
            edit_text = "Edit"
            save_text = "Save"
        End If


        Txt_RFID.Text = RFID

        Me.Text = "Inspection - Station: " & PLC_Station
        Btn_Edit.Text = edit_text

    End Sub
    Private Sub Load_Inspections()
        Dim counter As Integer = 0
        Dim query As String = ""

        If Part_ID <= 0 Then
            Exit Sub
        End If

        Try
            CLB_Inspection_Items.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Inspection_Items where Part_Type_ID = (select Insps from (select part_type as Insps from part where id = " & Part_ID & " union select part_type as Insps from part_History where id = " & Part_ID & ") as Insp_Item) order by Inspection_Number", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Inspection_Items")
            SQLCon.Close()
            ReDim Inspection_Array(counter)
            For Each dr As DataRow In ds.Tables("Inspection_Items").Rows
                If Spanish Then
                    CLB_Inspection_Items.Items.Add(dr("Spanish"))
                Else
                    CLB_Inspection_Items.Items.Add(dr("Description"))
                End If
                Inspection_Array(counter) = dr("ID")
                counter += 1
                ReDim Preserve Inspection_Array(counter)

            Next
        Catch Ex As Exception

            MsgBox("Error Getting Inspection Items from Database: " & Ex.Message)
        End Try

        Try
            SQLCon.Open()
            query = "Select Inspection_Number from (Select Inspection_Number from RFID_Inspection inner join Inspection_Items on RFID_Inspection.Inspection_ID = Inspection_Items.ID where "
            query = query & "checked = 1 and Part_ID = " & Part_ID & " union "
            query = query & "Select Inspection_Number from RFID_Inspection_History inner join Inspection_Items on RFID_Inspection_History.Inspection_ID = Inspection_Items.ID where checked = 1 and Part_ID = " & Part_ID & ") as Insp"
            Dim da2 As New SqlDataAdapter(query, SQLCon)
            da2.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds2 As New DataSet
            da2.Fill(ds2, "RFID_Inspection")
            SQLCon.Close()
            For Each dr2 As DataRow In ds2.Tables("RFID_Inspection").Rows
                CLB_Inspection_Items.SetItemChecked(dr2("Inspection_Number") - 1, True)
            Next
        Catch Ex As Exception

            MsgBox("Error Getting Inspection Results from Database: " & Ex.Message)
        End Try


    End Sub

    Private Sub Load_Data()
        Dim counter As Integer = 0
        Dim query As String = ""

        If Part_ID <= 0 Then
            Exit Sub
        End If

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            query = "Select Part_Type_ID, Part_Type_Desc, Part_Type_Spanish, Color, Color_Spanish from (Select Part.Part_Type as Part_Type_ID, Part_Type.description as Part_Type_Desc, "
            query = query & "Part_Type.Spanish as Part_Type_Spanish, Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish from (Part left join part_type on  part.part_type = "
            query = query & "Part_Type.id) left join final_color on part.color = final_color.id where part.id = " & Part_ID & " union Select Part_History.Part_Type as Part_Type_ID, "
            query = query & "Part_Type.description as Part_Type_Desc, Part_Type.Spanish as Part_Type_Spanish, Final_Color.Description as Color, Final_Color.Spanish as Color_Spanish "
            query = query & "from (Part_History left join part_type on part_History.part_type = Part_Type.id) left join final_color on part_History.color = final_color.id "
            query = query & "where part_History.id = " & Part_ID & ") as part"
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Parts")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Parts").Rows
                If Spanish Then
                    Txt_Part_Type.Text = dr("Part_Type_Spanish") & ""
                    Txt_Color.Text = dr("Color_Spanish") & ""
                Else
                    Txt_Part_Type.Text = dr("Part_Type_Desc") & ""
                    Txt_Color.Text = dr("Color") & ""
                End If
            Next
        Catch Ex As Exception

            MsgBox("Error Getting Part Info from Database: " & Ex.Message)
        End Try



    End Sub


    Private Sub New_Part()
        If Part_ID >= 0 Then
            Call Load_Inspections()
            Call Load_Data()
            Btn_Edit.Visible = True
        End If
    End Sub

    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
        If Btn_Edit.Text = edit_text Then
            Btn_Edit.Text = save_text
            CLB_Inspection_Items.Enabled = True
        Else
            Btn_Edit.Text = edit_text
            CLB_Inspection_Items.Enabled = False
            Call Save_Inspection()
            Me.Close()
        End If
    End Sub

    Private Sub Save_Inspection()
        Dim counter As Integer = 0
        Dim Checked_Array(CLB_Inspection_Items.Items.Count) As Boolean

        Dim indexChecked As Integer
        For Each indexChecked In CLB_Inspection_Items.CheckedIndices
            Checked_Array(indexChecked) = True
        Next

        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim cmd As New SqlCommand("", SQLCon)

            For counter = 0 To CLB_Inspection_Items.Items.Count - 1
                cmd.CommandText = "Update_Inspection " & Part_ID & ", " & Inspection_Array(counter) & ", " & IIf(Checked_Array(counter), 1, 0)
                cmd.ExecuteNonQuery()
            Next

            SQLCon.Close()

        Catch Ex As Exception

            MsgBox("Error Saving Inspection from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Cmd_Next_Part_Click(sender As Object, e As EventArgs)
        Station_Pick_Form = New Station_Pick
        Station_Pick_Form.ShowDialog()
        If Len(Global_RFID) Then
            Txt_RFID.Text = Global_RFID
            Global_RFID = ""
        End If
    End Sub

    Private Sub Txt_RFID_TextChanged(sender As Object, e As EventArgs) Handles Txt_RFID.TextChanged
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select ID from (Select ID from Part where rfid = '" & Txt_RFID.Text & "' union Select ID from Part_History where rfid = '" & Txt_RFID.Text & "') as Part_ID"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Part")
        SQLCon.Close()

        Part_ID = 0

        For Each dr As DataRow In ds.Tables("Part").Rows
            Part_ID = dr("ID")
        Next

        Call New_Part()

    End Sub



    Private Sub get_spanish()
        Dim query As String

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()

        query = "Select top 1 * from defect_Screen_Translation"

        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Translation")
        SQLCon.Close()

        For Each dr As DataRow In ds.Tables("Translation").Rows
            Lbl_Part.Text = dr("Part") & ""
            Lbl_Type.Text = dr("Type") & ""
            Lbl_Color.Text = dr("Color") & ""
            edit_text = dr("edit") & ""
            save_text = dr("save") & ""
        Next

    End Sub


End Class