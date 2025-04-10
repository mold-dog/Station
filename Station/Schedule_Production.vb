Imports System.Data.SqlClient
Public Class Schedule_Production
    Private Final_Part_Array() As Integer

    Private Sub Schedule_Production_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        DTP_Start_Date.Text = Now
        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Final_Parts()

    End Sub

    Private Sub Fill_Grid()

        Dim query As String = ""

        If Not IsDate(DTP_Start_Date.Text) Then
            Exit Sub
        End If

        query = "Select schedule_ship.id, Part_Type.Description as Part_Type, Final_Color.Description as Color, Quantity, Priority "
        query = query & "from ((final_part inner join part_type on final_part.Part_Type_id = Part_Type.ID) inner join Final_Color on final_part.Final_color_id = Final_Color.ID) "
        query = query & " inner join schedule_ship on final_part.id = schedule_ship.final_part where [date] = '" & DateValue(DTP_Start_Date.Text) & "'"
        Dim counter As Integer = 0
        Try
            DGV_Paint_Data.Rows.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Schedule_Area")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Schedule_Area").Rows
                DGV_Paint_Data.Rows.Add()
                DGV_Paint_Data.Rows(counter).Cells(0).Value = dr("ID")
                DGV_Paint_Data.Rows(counter).Cells(1).Value = dr("Part_Type")
                DGV_Paint_Data.Rows(counter).Cells(2).Value = dr("Color")
                DGV_Paint_Data.Rows(counter).Cells(3).Value = dr("Quantity")
                DGV_Paint_Data.Rows(counter).Cells(4).Value = dr("Priority")
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

            MsgBox("Error Getting Schedule Ship Info from Database: " & Ex.Message)
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
            cmd.CommandText = "Delete from Schedule_ship where id = " & data_row.Cells(0).Value
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
            MsgBox("Please select a valid final part.")
            Exit Sub
        End If

        If Len(Txt_Quantity.Text) < 0 Or Not IsNumeric(Txt_Quantity.Text) Then
            MsgBox("Please enter a valid quantity.")
            Exit Sub
        End If

        If Len(Txt_Priority.Text) < 0 Or Not IsNumeric(Txt_Priority.Text) Then
            MsgBox("Please enter a valid quantity.")
            Exit Sub
        End If

        query = "insert into Schedule_Ship ([date], Final_Part, Quantity, Priority) values('" & DTP_Start_Date.Text & "', "
        query = query & Final_Part_Array(Cmb_Part_Type.SelectedIndex) & ", " & Val(Txt_Quantity.Text) & ", " & Val(Txt_Priority.Text) & ")"

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Fill_Grid()





        Pnl_Recipe.Visible = False

    End Sub

    Sub Load_Final_Parts()

        Dim counter As Integer = 0
        Try
            Cmb_Part_Type.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Final_Part order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Final_Part")
            SQLCon.Close()
            ReDim Final_Part_Array(0)
            For Each dr As DataRow In ds.Tables("Final_Part").Rows
                Cmb_Part_Type.Items.Add(dr("Description"))
                ReDim Preserve Final_Part_Array(counter)
                Final_Part_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Final Part Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub btn_Load_Click(sender As Object, e As EventArgs) Handles btn_Load.Click
        Dim query As String

        query = "Insert into schedule_ship ([Date], Final_Part, Quantity, Priority) Select '" & DTP_Start_Date.Value & "', id, 0, 0 from final_part where schedule = 1"

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand(query, SQLCon)
        cmd.ExecuteNonQuery()

        SQLCon.Close()
        Fill_Grid()
    End Sub

    Private Sub DGV_Paint_Data_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Paint_Data.CellEndEdit
        Dim query As String
        If e.ColumnIndex = 3 Or e.ColumnIndex = 4 Then
            If IsNumeric(DGV_Paint_Data.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                If e.ColumnIndex = 3 Then
                    query = "Update schedule_ship set quantity = " & DGV_Paint_Data.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " where id = " & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
                End If

                If e.ColumnIndex = 4 Then
                    query = "Update schedule_ship set priority = " & DGV_Paint_Data.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & " where id = " & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value
                End If

                SQLCon.ConnectionString = DBConnection
                SQLCon.Open()
                Dim cmd As New SqlCommand(query, SQLCon)
                cmd.ExecuteNonQuery()

                SQLCon.Close()

            End If
        End If
    End Sub




End Class