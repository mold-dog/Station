Imports System.Data
Imports System.Data.SqlClient
Public Class Inventory
    Private bindingsource1 As New BindingSource
    Dim Part_Type_ID_Array() As Int32
    Dim Color_ID_Array() As Int32

    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Part_Types()
        Call Load_Colors()

    End Sub
    Sub Load_Part_Types()

        Dim counter As Integer = 1
        Try
            Cmb_Part_Type.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Part_Type order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Part_Type")
            SQLCon.Close()
            Cmb_Part_Type.Items.Add("All Part Types")

            ReDim Part_Type_ID_Array(1)
            For Each dr As DataRow In ds.Tables("Part_Type").Rows
                Cmb_Part_Type.Items.Add(dr("Description"))
                ReDim Preserve Part_Type_ID_Array(counter)
                Part_Type_ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part Type Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Colors()

        Dim counter As Integer = 1
        Try
            Cmb_Color.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Final_Color order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Final_Color")
            SQLCon.Close()
            Cmb_Color.Items.Add("All Colors")

            ReDim Color_ID_Array(1)
            For Each dr As DataRow In ds.Tables("Final_Color").Rows
                Cmb_Color.Items.Add(dr("Description"))
                ReDim Preserve Color_ID_Array(counter)
                Color_ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Color Info from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""

        If Cmb_Part_Type.SelectedIndex < 0 Then
            MsgBox("Please select a valid part type.")
            Exit Sub
        End If
        If Cmb_Color.SelectedIndex < 0 Then
            MsgBox("Please select a valid color.")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        query = "Select [Part Type], [Color], [Location], Sum([Quantity]) from (Select Part_Type.Description as [Part Type], Final_Color.Description as [Color], Area.Description as [Location]"
        query = query & ", Count(Part.RFID) as [Quantity] from ((Part inner join Area on Part.Current_Location = Area.id) left join Part_Type on Part.Part_Type = Part_Type.id) left join "
        query = query & " Final_Color on Part.Color = Final_Color.Id Where 1 = 1"
        If Cmb_Part_Type.SelectedIndex > 0 Then
            query = query & " and (Part_Type.ID = " & Part_Type_ID_Array(Cmb_Part_Type.SelectedIndex) & ")"
        End If
        If Cmb_Color.SelectedIndex > 0 Then
            query = query & " and (Final_Color.ID = " & Color_ID_Array(Cmb_Color.SelectedIndex) & ")"
        End If
        query = query & " Group by Part_Type.Description, Final_Color.Description, Area.Description union Select Part_Type.Description as [Part Type], Final_Color.Description as [Color], "
        query = query & "Area.Description as [Location], Count(Part_History.RFID) as [Quantity] from ((Part_History inner join Area on Part_History.Current_Location = Area.id)"
        query = query & " left join Part_Type on Part_History.Part_Type = Part_Type.id) left join Final_Color on Part_History.Color = Final_Color.Id Where 1 = 1"
        If Cmb_Part_Type.SelectedIndex > 0 Then
            query = query & " and (Part_Type.ID = " & Part_Type_ID_Array(Cmb_Part_Type.SelectedIndex) & ")"
        End If
        If Cmb_Color.SelectedIndex > 0 Then
            query = query & " and (Final_Color.ID = " & Color_ID_Array(Cmb_Color.SelectedIndex) & ")"
        End If
        query = query & " Group by Part_Type.Description, Final_Color.Description, Area.Description) as Inventory Group by [Part Type], [Color], [Location] order by [Part Type], [Color]"

        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Btn_Export_Click(sender As Object, e As EventArgs) Handles Btn_Export.Click
        Dim filename As String = ""
        Dim row As Integer = 0
        Dim column As Integer = 0
        Dim Row_String As String = ""

        Dim returnValue As DialogResult

        Try

            returnValue = SaveFile.ShowDialog
            If returnValue = DialogResult.Cancel Then
                Exit Sub
            End If

            Me.UseWaitCursor = True

            filename = SaveFile.FileName
            FileOpen(1, filename, OpenMode.Output)



            For row = 0 To DGV_Paint_Data.RowCount - 1
                For column = 0 To DGV_Paint_Data.ColumnCount - 1
                    If column = 0 Then
                        Row_String = DGV_Paint_Data.Rows(row).Cells(column).Value & ""
                    Else
                        Row_String = Row_String & "," & DGV_Paint_Data.Rows(row).Cells(column).Value
                    End If
                Next
                PrintLine(1, Row_String)
            Next

            FileClose(1)
            MsgBox("Export Completed: " & filename)
        Catch ex As Exception
            MsgBox("Export Failed: " & ex.Message)
        End Try
        Me.UseWaitCursor = False


    End Sub

    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_Paint_Data.RowHeaderMouseDoubleClick
        Dim Query As String


        Query = "exec Parts_at_Location '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(0).Value & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(1).Value & "', '" & DGV_Paint_Data.Rows(e.RowIndex).Cells(2).Value & "'"
        Paint_Production_Parts_Query_Form = New Paint_Production_Parts_Query
        Paint_Production_Parts_Query_Form.Query = Query
        Paint_Production_Parts_Query_Form.Show()

    End Sub
End Class