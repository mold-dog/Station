Imports System.Data
Imports System.Data.SqlClient

Public Class PMC_Report_By_Resource


    Dim ID_Array() As Int32
    Dim analogResources As New Generic.Dictionary(Of String, Integer)


    Private bindingsource1 As New BindingSource

    Private Sub PMC_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_PMC_Data.AutoGenerateColumns = True

        Call Load_Combo()

        AddHandler analog_CheckBox.CheckedChanged, AddressOf flipcheck
        AddHandler digital_CheckBox.CheckedChanged, AddressOf flipcheck
        AddHandler block1_CheckBox.CheckedChanged, AddressOf flipcheck
        AddHandler block2_Checkbox.CheckedChanged, AddressOf flipcheck
        AddHandler block3_CheckBox.CheckedChanged, AddressOf flipcheck



    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim table_name As String = ""

        Me.Cursor = Cursors.WaitCursor


        query = "exec PMC_History_By_Resource2 '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', " & ID_Array(Cmb_Resource.SelectedIndex)

        If (analog_CheckBox.Visible And analog_CheckBox.Checked) Then
            query = query & ", 0, "
        Else
            query = query & ", 1, "
        End If

        If ((block1_CheckBox.Visible Or block2_Checkbox.Visible) And (block2_Checkbox.Checked)) Then
            query = query & "1"
        ElseIf ((block1_CheckBox.Visible Or block2_Checkbox.Visible) And (block3_Checkbox.Checked)) Then
            query = query & "2"
        Else
            query = query & "0"
        End If

        'MsgBox(query)
        bindingsource1.DataSource = GetData(query)

        DGV_PMC_Data.DataSource = bindingsource1
        DGV_PMC_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_PMC_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Checkbox_Display(sender As Object, e As EventArgs) Handles Cmb_Resource.SelectedIndexChanged
        Try

            If analogResources.ContainsKey(Cmb_Resource.Text) Then
                digital_CheckBox.Visible = True
                analog_CheckBox.Visible = True

                If analogResources(Cmb_Resource.Text) Then
                    lbl_Analog_Datablock.Visible = True
                    block1_CheckBox.Visible = True
                    block2_Checkbox.Visible = True

                    If analogResources(Cmb_Resource.Text) > 1 Then
                        block3_CheckBox.Visible = True
                    End If

                Else
                    lbl_Analog_Datablock.Visible = False
                    block1_CheckBox.Visible = False
                    block2_Checkbox.Visible = False
                    block3_CheckBox.Visible = False
                End If

            Else
                lbl_Analog_Datablock.Visible = False
                digital_CheckBox.Visible = False
                analog_CheckBox.Visible = False
                block1_CheckBox.Visible = False
                block2_Checkbox.Visible = False
                block3_CheckBox.Visible = False


            End If
        Catch ex As Exception

        End Try


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

            For column = 0 To DGV_PMC_Data.ColumnCount - 1
                If column = 0 Then
                    Row_String = DGV_PMC_Data.Columns(column).HeaderText & ""
                Else
                    Row_String = Row_String & "," & DGV_PMC_Data.Columns(column).HeaderText
                End If
            Next
            PrintLine(1, Row_String)


            For row = 0 To DGV_PMC_Data.RowCount - 1
                For column = 0 To DGV_PMC_Data.ColumnCount - 1
                    If column = 0 Then
                        Row_String = DGV_PMC_Data.Rows(row).Cells(column).Value & ""
                    Else
                        Row_String = Row_String & "," & DGV_PMC_Data.Rows(row).Cells(column).Value
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

    Private Sub DGV_Paint_Data_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_PMC_Data.RowHeaderMouseDoubleClick

        Dim Query As String


        Query = "exec PMC_History_By_Event_Type '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', '" & DGV_PMC_Data.Rows(e.RowIndex).Cells(0).Value & "', '" & DGV_PMC_Data.Rows(e.RowIndex).Cells(1).Value & "'"
        PMC_History_By_Event_Form = New PMC_History_By_Event
        PMC_History_By_Event_Form.Query = Query
        PMC_History_By_Event_Form.Show()


    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Resource.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from PMC_Resources order by ID", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "resources")

            ReDim ID_Array(0)
            Cmb_Resource.Items.Add("All Resources")
            ID_Array(counter) = 0
            counter += 1

            For Each dr As DataRow In ds.Tables("resources").Rows
                Cmb_Resource.Items.Add(dr("resource"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next

            Cmb_Resource.Text = "All Resources"

            Dim query As String = "Select Resource, count(PMC_Logged_Data_Point_Name.PMC_Resource) As [BlockCount] From PMC_Resources, PMC_Logged_Data_Point_Name Where PMC_Resources.ID = PMC_Logged_Data_Point_Name.PMC_Resource group by Resource"

            Dim newDA As New SqlDataAdapter(query, SQLCon)
            newDA.SelectCommand.CommandTimeout = SQL_Timeout
            Dim newDS As New DataSet
            newDA.Fill(newDS, "analog")

            'If analogResources.Count > 6 Then
            '    analogResources.Clear()
            'End If

            For Each newDR As DataRow In newDS.Tables("analog").Rows


                analogResources.Add(newDR("Resource"), newDR("BlockCount") - 1)


                'If (newDR("BlockCount") = "1") Then
                '    analogResources.Add(newDR("Resource"), 0)

                'Else
                '    ' why minus 1
                '    analogResources.Add(newDR("Resource"), newDR("BlockCount"))

                'End If

            Next


            SQLCon.Close()


        Catch Ex As Exception

            MsgBox("Error Getting Resources from Database: " & Ex.Message)
        End Try



        End Sub



    Private Sub flipcheck(sender As Object, e As EventArgs)

        If (sender.text = analog_CheckBox.Text) Then
            digital_CheckBox.Checked = Not (analog_CheckBox.Checked)

        ElseIf (sender.text = digital_CheckBox.text) Then
            analog_CheckBox.Checked = Not (digital_CheckBox.Checked)

        ElseIf ((sender.text = block1_CheckBox.text) And (analog_CheckBox.checked)) Then
            block2_Checkbox.Checked = Not (block1_CheckBox.Checked)
            block3_CheckBox.Checked = Not (block1_CheckBox.Checked)

        ElseIf ((sender.text = block2_Checkbox.text) And (analog_CheckBox.checked)) Then
            block1_CheckBox.Checked = Not (block2_Checkbox.Checked)
            block3_CheckBox.Checked = Not (block2_Checkbox.Checked)

        ElseIf ((sender.text = block3_CheckBox.text) And (analog_CheckBox.checked)) Then
            block1_CheckBox.Checked = Not (block3_CheckBox.Checked)
            block2_Checkbox.Checked = Not (block3_CheckBox.Checked)
        End If


        If digital_CheckBox.Checked And (block1_CheckBox.Visible Or block2_Checkbox.Visible) Then
            block1_CheckBox.Checked = False
            block2_Checkbox.Checked = False
            block3_CheckBox.Checked = False

        End If

    End Sub


End Class

