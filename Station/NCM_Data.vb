Public Class NCM_Data

    Private bsrc As BindingSource = New BindingSource()

    Private Sub init() Handles MyBase.Load

        Try


            Dim cust As DataSet = toolboxMM.SQLTools.queryDatabase("Select Name From Customers", "Cust")

            For Each dr As DataRow In cust.Tables("Cust").Rows
                cmbbox_customers.Items.Add(dr("Name"))
            Next

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        Try

            DGV.AutoGenerateColumns = True
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            DGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells



        Catch ex As Exception

        End Try


    End Sub




    Private Sub load_data(sender As Object, e As EventArgs) Handles btn_update.Click

        Try

            Dim data As DataSet = toolboxMM.SQLTools.queryDatabase("Select * From NCM_" & Replace(cmbbox_customers.Text, " ", "_") & " Where NCM_Date Between '" & dt_picker_start.Value.Date.ToString & "' and '" & dt_picker_end.Value.Date.ToString & "'", "NCM")
            bsrc.DataSource = data.Tables("NCM")

            DGV.DataSource = bsrc.DataSource




        Catch ex As Exception

        End Try

    End Sub




    Private Sub export_data(sender As Object, e As EventArgs) Handles btn_export.Click

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



            For row = 0 To DGV.RowCount - 1
                For column = 0 To DGV.ColumnCount - 1
                    If column = 0 Then
                        Row_String = DGV.Rows(row).Cells(column).Value & ""
                    Else
                        Row_String = Row_String & "," & DGV.Rows(row).Cells(column).Value
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