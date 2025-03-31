Public Class Inventory_Clear

    Private bsrc As BindingSource = New BindingSource()

    Private Sub init() Handles MyBase.Load

        dt_picker_start.CustomFormat = "MMMM yyyy"
        dt_picker_end.CustomFormat = "MMMM yyyy"

        AddHandler cmbbox_part_type.SelectedValueChanged, AddressOf cmbbox_filter
        AddHandler cmbbox_color.SelectedValueChanged, AddressOf cmbbox_filter


        Try

            DGV.AutoGenerateColumns = True
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells



        Catch ex As Exception

        End Try

    End Sub



    Private Sub load_data(sender As Object, e As EventArgs) Handles btn_load.Click

        cmbbox_color.Text = ""
        cmbbox_part_type.Text = ""

        btn_load.Text = "loading..."
        btn_load.BackColor = Color.LightYellow
        Me.Refresh()

        Try


            Dim start_time As String = dt_picker_start.Value.Month.ToString & "/1/" & dt_picker_start.Value.Year.ToString & " 12:00:00 AM"
            Dim end_time As String = dt_picker_end.Value.Month.ToString & "/" & DateTime.DaysInMonth(dt_picker_end.Value.Year, dt_picker_end.Value.Month) & "/" & dt_picker_end.Value.Year.ToString & " 11:59:59 PM"
            Dim where As String = " Where RFID Like '[a-z]%' and Current_Location not in ((Select id From area where Description = 'Shipped'), (Select id From area where Description = 'Scrap'), (Select id From area where Description = 'Exit')) and Last_Update_Time Between '" & start_time & " ' and '" & end_time & "'"

            Dim count_query As String = "Select (Select Count(RFID) From Part" & where & ") as 'Total', (Select Count(Distinct Part_Type) From Part" & where & ") as 'Part Type', (Select Count(Distinct Color) From Part" & where & ") as 'Color'"
            Dim cnt As DataSet = toolboxMM.SQLTools.queryDatabase(count_query, "count")

            For Each dr As DataRow In cnt.Tables("count").Rows
                lbl_qty_total.Text = "Quantity Affected: " & IIf(IsDBNull(dr("Total")), "0", dr("Total").ToString)
                lbl_qty_type.Text = "Types Affected: " & IIf(IsDBNull(dr("Part Type")), "0", dr("Part Type").ToString)
                lbl_qty_color.Text = "Colors Affected: " & IIf(IsDBNull(dr("Color")), "0", dr("Color").ToString)

            Next

            Me.Refresh()




            Dim total_query As String = "Select RFID, Part_Type.description as 'Part Type', IIF(paint_Color.Description is null, 'No Color In Database', paint_color.Description) as 'Color', area.description as 'Location' From Part left join area on part.current_location = area.id left join Part_type On part.part_type = part_type.id left join Paint_Color on part.color = Paint_Color.id" & where & " Order By RFID"

            Dim total As DataSet = toolboxMM.SQLTools.queryDatabase(total_query, "total")
            bsrc.Filter = Nothing
            bsrc.DataSource = total.Tables("total")

            DGV.DataSource = bsrc.DataSource

            populate_comboboxes(total.Tables("total"))

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

        btn_load.Text = "Load"
        btn_load.BackColor = Me.BackColor




    End Sub


    Private Sub populate_comboboxes(dtable As DataTable)

        cmbbox_part_type.Items.Clear()
        cmbbox_color.Items.Clear()

        cmbbox_part_type.Items.Add("")
        For Each dr As DataRow In dtable.DefaultView.ToTable(True, "Part Type").Rows

            cmbbox_part_type.Items.Add(dr("Part Type"))
        Next

        cmbbox_color.Items.Add("")
        For Each dr As DataRow In dtable.DefaultView.ToTable(True, "Color").Rows
            cmbbox_color.Items.Add(dr("Color"))
        Next


    End Sub



    Private Sub clear_data(sender As Object, e As EventArgs) Handles btn_delete.Click


        Try

            Dim result As DialogResult = MessageBox.Show("Clear displayed parts from inventory?", "Confirm", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then

                btn_delete.Text = "deleting..."
                btn_delete.BackColor = Color.PaleVioletRed
                btn_delete.Refresh()


                Dim start_time As String = dt_picker_start.Value.Month.ToString & "/1/" & dt_picker_start.Value.Year.ToString & " 12:00:00 AM"
                Dim end_time As String = dt_picker_end.Value.Month.ToString & "/" & DateTime.DaysInMonth(dt_picker_end.Value.Year, dt_picker_end.Value.Month) & "/" & dt_picker_end.Value.Year.ToString & " 11:59:59 PM"

                Dim where As String = " Where RFID Like '[a-z]%' and Current_Location not in ((Select id From area where Description = 'Shipped'), (Select id From area where Description = 'Scrap'), (Select id From area where Description = 'Exit')) and (Last_Update_Time Between '" & start_time & " ' and '" & end_time & "')"

                If cmbbox_part_type.Text <> "" Then
                    where += " and Part_Type = (Select id from Part_Type Where Description = '" & cmbbox_part_type.Text & "')"
                End If

                If cmbbox_color.Text <> "" Then
                    where += " and Color = (Select id from Paint_Color Where Description = '" & cmbbox_color.Text & "')"
                End If

                ' Dim total_query As String = "Select * From Part" & where
                Dim update_query As String = "Update Part Set Current_Location = (Select id From area where Description = 'Shipped'), Last_Location = Current_Location" & where

                Dim total As DataSet = toolboxMM.SQLTools.queryDatabase(update_query, "none")


                bsrc.DataSource = Nothing
                bsrc.Filter = Nothing
                DGV.DataSource = Nothing


                btn_delete.Text = "DELETE"
                btn_delete.BackColor = Me.BackColor
                btn_delete.Refresh()
                cmbbox_color.Text = ""
                cmbbox_part_type.Text = ""


            End If



        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub cmbbox_filter(sender As Object, e As EventArgs)


        lbl_title.Select()

        btn_load.Text = "loading..."
        btn_load.BackColor = Color.LightYellow
        btn_load.Refresh()


        Dim start_time As String = dt_picker_start.Value.Month.ToString & "/1/" & dt_picker_start.Value.Year.ToString & " 12:00:00 AM"
        Dim end_time As String = dt_picker_end.Value.Month.ToString & "/" & DateTime.DaysInMonth(dt_picker_end.Value.Year, dt_picker_end.Value.Month) & "/" & dt_picker_end.Value.Year.ToString & " 11:59:59 PM"
        Dim where As String = " Where RFID Like '[a-z]%' and Current_Location not in ((Select id From area where Description = 'Shipped'), (Select id From area where Description = 'Scrap'), (Select id From area where Description = 'Exit')) and Last_Update_Time Between '" & start_time & " ' and '" & end_time & "'"

        If cmbbox_part_type.Text <> "" Then
            where += " and Part_Type = (Select id from Part_Type Where Description = '" & cmbbox_part_type.Text & "')"
        End If

        If cmbbox_color.Text <> "" Then
            where += " and Color = (Select id from Paint_Color Where Description = '" & cmbbox_color.Text & "')"
        End If

        Dim count_query As String = "Select (Select Count(RFID) From Part" & where & ") as 'Total', (Select Count(Distinct Part_Type) From Part" & where & ") as 'Part Type', (Select Count(Distinct Color) From Part" & where & ") as 'Color'"
        Dim cnt As DataSet = toolboxMM.SQLTools.queryDatabase(count_query, "count")

        For Each dr As DataRow In cnt.Tables("count").Rows
            lbl_qty_total.Text = "Quantity Affected: " & IIf(IsDBNull(dr("Total")), "0", dr("Total").ToString)
            lbl_qty_type.Text = "Types Affected: " & IIf(IsDBNull(dr("Part Type")), "0", dr("Part Type").ToString)
            lbl_qty_color.Text = "Colors Affected: " & IIf(IsDBNull(dr("Color")), "0", dr("Color").ToString)

        Next

        Me.Refresh()

        Dim filter As String = ""



        If cmbbox_color.Text <> "" Then
            filter = "color = '" & cmbbox_color.Text & "'"

            If cmbbox_part_type.Text <> "" Then
                filter += " AND [part type] = '" & cmbbox_part_type.Text & "'"
            End If

        ElseIf cmbbox_part_type.Text <> "" Then
            filter = "[part type] = '" & cmbbox_part_type.Text & "'"
        End If

        If filter = "" Then
            bsrc.Filter = Nothing
        Else
            bsrc.Filter = filter
        End If




        btn_load.Text = "Load"
        btn_load.BackColor = Me.BackColor



    End Sub


End Class