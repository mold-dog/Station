Imports System.Data.SqlClient

Public Class Mold_Schedule
    Private Part_Type_Array() As Integer

    Private Sub Mold_Schedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DTP_Start_Date.Text = Now
        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Part_Types()

    End Sub

    Private Sub Fill_Grid()

        Dim query As String = ""

        If Not IsDate(DTP_Start_Date.Text) Then
            Exit Sub
        End If

        query = "Select mold_target.id, Part_Type.Description as Part_Type, Quantity "
        query = query & "from part_type inner join mold_target on part_type.id = mold_target.part_type where [date] = '" & DateValue(DTP_Start_Date.Text) & "'"
        Dim counter As Integer = 0
        Try
            DGV_Paint_Data.Rows.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "mold_target")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("mold_target").Rows
                DGV_Paint_Data.Rows.Add()
                DGV_Paint_Data.Rows(counter).Cells(0).Value = dr("ID")
                DGV_Paint_Data.Rows(counter).Cells(1).Value = dr("Part_Type")
                DGV_Paint_Data.Rows(counter).Cells(2).Value = dr("Quantity")
                counter += 1
            Next

            Btn_Add.Visible = True
            Btn_Delete.Visible = True

            If DGV_Paint_Data.RowCount > 0 Then
                btn_Load.Visible = False
            Else
                btn_Load.Visible = True
            End If


        Catch Ex As Exception

            MsgBox("Error Getting Mold Schedule Ship Info from Database: " & Ex.Message)
        End Try


        Me.Cursor = Cursors.Default


    End Sub


    Private Sub DTP_Start_Date_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Start_Date.ValueChanged
        Call Fill_Grid()

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
            cmd.CommandText = "Delete from Mold_Target where id = " & data_row.Cells(0).Value
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

        query = "insert into Mold_Target ([date], Part_Type, Quantity) values('" & DTP_Start_Date.Text & "', "
        query = query & Part_Type_Array(Cmb_Part_Type.SelectedIndex) & ", " & Val(Txt_Quantity.Text) & ")"

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Fill_Grid()





        Pnl_Recipe.Visible = False

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

            MsgBox("Error Getting Part Type from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub btn_Load_Click(sender As Object, e As EventArgs) Handles btn_Load.Click
        Dim query As String

        query = "Insert into mold_target ([Date], Part_Type, Quantity) Select '" & DTP_Start_Date.Value & "', id, 0 from part_type where schedule_finish = 1"

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()

        SQLCon.Close()
        Fill_Grid()
    End Sub

    Private Sub DGV_Paint_Data_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Paint_Data.CellEndEdit
        Dim query As String
        If e.ColumnIndex = 2 Then
            If IsNumeric(DGV_Paint_Data.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                query = "Update mold_target set quantity = " & DGV_Paint_Data.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " where id = " & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value

                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()

                SQLCon.Close()

            End If
        End If
    End Sub

End Class