Imports System.Data.SqlClient
Public Class Target_Time_Per_Part
    Private ID_Array() As Integer
    Private Part_Type_Array() As Integer

    Private Sub Schedule_Production_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Combo()
        Call Load_Part_Types()

    End Sub

    Private Sub Fill_Grid()

        Dim query As String = ""

        If Cmb_Area.SelectedIndex < 0 Then
            Exit Sub
        End If

        query = "Select Target_Per_Part.ID, Part_Type.Description as Part_Type, Minutes "
        query = query & "from Target_Per_Part inner join part_type on Target_Per_Part.Part_Type = Part_Type.ID"
        query = query & " where area = " & ID_Array(Cmb_Area.SelectedIndex)
        Dim counter As Integer = 0
        Try
            DGV_Paint_Data.Rows.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Target_Per_Part")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Target_Per_Part").Rows
                DGV_Paint_Data.Rows.Add()
                DGV_Paint_Data.Rows(counter).Cells(0).Value = dr("ID")
                DGV_Paint_Data.Rows(counter).Cells(1).Value = dr("Part_Type")
                DGV_Paint_Data.Rows(counter).Cells(2).Value = dr("Minutes")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try

        Me.Cursor = Cursors.Default


    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Area.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from area where Targets = 1 order by description", SQLCon)
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

    Private Sub Cmb_Area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Area.SelectedIndexChanged
        Call Fill_Grid()

        Btn_Add.Visible = True
        Btn_Delete.Visible = True

    End Sub



    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Pnl_Recipe.Visible = True
        Btn_Add.Visible = False
        Btn_Delete.Visible = False
    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If DGV_Paint_Data.SelectedRows.Count < 1 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("", SQLCon)
        Dim data_row As DataGridViewRow

        For Each data_row In DGV_Paint_Data.SelectedRows
            cmd.CommandText = "Delete from Target_Per_Part where id = " & data_row.Cells(0).Value
            cmd.ExecuteNonQuery()
        Next

        SQLCon.Close()
        Fill_Grid()
    End Sub

    Private Sub Btn_Add_Recipe_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Add_Recipe_Cancel.Click
        Pnl_Recipe.Visible = False
        Btn_Add.Visible = True
        Btn_Delete.Visible = True
    End Sub

    Private Sub btn_Add_Recipe_Confirm_Click(sender As Object, e As EventArgs) Handles btn_Add_Recipe_Confirm.Click
        Dim query As String = ""
        If Cmb_Part_Type.SelectedIndex < 0 Then
            MsgBox("Please select a valid part type.")
            Exit Sub
        End If

        If Len(Txt_Quantity.Text) < 0 Or Not IsNumeric(Txt_Quantity.Text) Then
            MsgBox("Please enter a valid quantity.")
            Exit Sub
        End If

        query = "insert into Target_Per_Part (Area, Part_Type, Minutes) values(" & ID_Array(Cmb_Area.SelectedIndex) & ", "
        query = query & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", " & Val(Txt_Quantity.Text) & ")"

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Fill_Grid()





        Pnl_Recipe.Visible = False
        Btn_Add.Visible = True
        Btn_Delete.Visible = True
    End Sub

    Sub Load_Part_Types()

        Dim counter As Integer = 0
        Try
            Cmb_Part_Type.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            ReDim Part_Type_Array(0)
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Part_Type.Items.Add(dr("Description"))
                ReDim Preserve Part_Type_Array(counter)
                Part_Type_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Info from Database: " & Ex.Message)
        End Try



    End Sub


End Class