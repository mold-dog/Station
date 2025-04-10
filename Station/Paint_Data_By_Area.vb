Imports System.Data
Imports System.Data.SqlClient
Public Class Paint_Data_By_Area
    Private bindingsource1 As New BindingSource
    Private Sub Paint_Data_By_Area_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        'TODO: This line of code loads data into the 'RFIDDataSet.Air_Force_1' table. You can move, or remove it, as needed.
        Cmb_Area.Items.Add("Washer 1")
        Cmb_Area.Items.Add("Washer 2")
        Cmb_Area.Items.Add("Washer 3")
        Cmb_Area.Items.Add("Washer 4")
        Cmb_Area.Items.Add("Air Force 1")
        Cmb_Area.Items.Add("Dry Off Oven")
        Cmb_Area.Items.Add("Destat")
        Cmb_Area.Items.Add("Base Booth")
        Cmb_Area.Items.Add("Base Robot 1")
        Cmb_Area.Items.Add("Base Robot 2")
        Cmb_Area.Items.Add("Base Robot 3")
        Cmb_Area.Items.Add("Base Robot 4")
        Cmb_Area.Items.Add("Base Flash")
        Cmb_Area.Items.Add("Base IR")
        Cmb_Area.Items.Add("Base Cool Down")
        Cmb_Area.Items.Add("Clear Coat Booth")
        Cmb_Area.Items.Add("Clear Robot 1")
        Cmb_Area.Items.Add("Clear Robot 2")
        Cmb_Area.Items.Add("Clear Flash")
        Cmb_Area.Items.Add("Clear IR Oven")
        Cmb_Area.Items.Add("Clear Oven")



        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True



    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim table_name As String = ""

        If Cmb_Area.SelectedIndex < 0 Then
            MsgBox("Please select a valid paint area.")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Select Case Cmb_Area.SelectedIndex
            Case 0
                table_name = "Washer_Stage_1"
            Case 1
                table_name = "Washer_Stage_2"
            Case 2
                table_name = "Washer_Stage_3"
            Case 3
                table_name = "Washer_Stage_4"
            Case 4
                table_name = "Air_Force_1"
            Case 5
                table_name = "Dry_Off"
            Case 6
                table_name = "Destat"
            Case 7
                table_name = "Base_Booth"
            Case 8
                table_name = "Base_Robot_1"
            Case 9
                table_name = "Base_Robot_2"
            Case 10
                table_name = "Base_Robot_3"
            Case 11
                table_name = "Base_Robot_4"
            Case 12
                table_name = "Base_Flash"
            Case 13
                table_name = "Base_IR"
            Case 14
                table_name = "Base_CoolDown"
            Case 15
                table_name = "Clear_Coat_Booth"
            Case 16
                table_name = "Clear_Robot_1"
            Case 17
                table_name = "Clear_Robot_2"
            Case 18
                table_name = "Clear_Flash"
            Case 19
                table_name = "Clear_IR"
            Case 20
                table_name = "Clear_Oven"
        End Select


        query = "Select * from (Select * from " & table_name & " where Log_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "' union "
        query = query & "Select * from " & table_name & "_History where Log_Time between '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "' and '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "') as paint_data"

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
End Class