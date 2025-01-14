Imports System.Collections.Generic
Public Class SupPressRep

    Dim buttonQR As New Button
    Dim buttonExport As New Button
    Public buttonOverview As New OverviewButton
    Public buttonRefresh As New Button
    Dim instructions As New TextBox

    Private press_name As String

    Public Property PressName As String
        Get
            Return press_name
        End Get
        Set(value As String)
            press_name = value
        End Set
    End Property

    Private supervisor_name As String

    Public Property SupervisorName As String
        Get
            Return supervisor_name
        End Get
        Set(value As String)
            supervisor_name = value
        End Set
    End Property



    Public Sub LoadPressOverview()

        supervisor_name = ""


        If (((Now - buttonOverview.LastUpdate).TotalSeconds < 30)) Then
            MsgBox("Data updated within last minute; please wait longer before refreshing.")

        Else

            For Each tempcontrol As Control In PressLayoutPanel.Controls
                tempcontrol.Dispose()
            Next

            buttonOverview.LastUpdate = Now

            PressLayoutPanel.Controls.Clear()
            ButtonLayoutPanel.Controls.Clear()

            PressLayoutPanel.Visible = False
            'ButtonLayoutPanel.Visible = False

            buttonOverview.Text = "Refresh"
            instructions.Text = "Click on a press for details and to input information."
            ButtonLayoutPanel.Controls.Add(buttonOverview)
            ButtonLayoutPanel.Controls.Add(buttonExport)


            Dim Query As String = "Select Description From Press Union All Select Description From Bonder"
            toolboxMM.PressBox.populateControl(PressLayoutPanel, Query, "Get_Press_Overview1")

            PressLayoutPanel.Visible = True
            'ButtonLayoutPanel.Visible = True

        End If

    End Sub


    Public Sub LoadPressSpecifics(pressName As String, pressData As List(Of List(Of String)))

        ButtonLayoutPanel.Controls.Remove(buttonExport)
        press_name = pressName

        buttonOverview.LastUpdate = New DateTime(1800, 1, 1)
        PressLayoutPanel.Visible = False


        For Each tempcontrol As toolboxMM.PressBox In PressLayoutPanel.Controls
            tempcontrol.RemoveClickEvent()
            tempcontrol.Dispose()
        Next

        PressLayoutPanel.Controls.Clear()


        buttonOverview.Text = "Overview"
        instructions.Text = "Click 'Overview' to return to main screen."



        Dim genBox As New toolboxMM.PressBox
        genBox.ColumnName = press_name
        genBox.createDictionary("Exec Get_Press_Overview1 '" & press_name & "'", "Select '" & press_name & "'")
        PressLayoutPanel.Controls.Add(genBox)
        AddHandler buttonRefresh.Click, AddressOf genBox.RefreshData

        If supervisor_name = "" Then
            genBox.LastUpdate = New DateTime(1800, 1, 1)
        End If



        Dim userBox As New toolboxMM.PressBox
        If genBox.ColumnName.Contains("Press") Then
            userBox.ColumnName = "Press Users"

        Else
            userBox.ColumnName = "Bonder Users"
        End If

        userBox.createDictionary("Exec Get_Mold_Operators '" & genBox.ColumnName & "'", "Select '" & userBox.ColumnName & "'")
        PressLayoutPanel.Controls.Add(userBox)
        ' AddHandler buttonRefresh.Click, AddressOf userBox.UpdateData


        Dim rateBox As New toolboxMM.PressBox
        rateBox.ColumnName = "Hourly Rates"
        rateBox.createDictionary("Exec Get_Press_Rates_Overview '" & genBox.ColumnName & "'", "Select '" & rateBox.ColumnName & "'")
        PressLayoutPanel.Controls.Add(rateBox)
        'AddHandler buttonRefresh.Click, AddressOf rateBox.UpdateData

        Dim supBox As New toolboxMM.PressBox
        supBox.ColumnName = "Supervisor Rates"
        supBox.SupervisorName = supervisor_name
        supBox.createDictionary("Exec Get_Supervisor_Overview '" & genBox.ColumnName & "'", "Select '" & supBox.ColumnName & "'")
        PressLayoutPanel.Controls.Add(supBox)
        'AddHandler buttonRefresh.Click, AddressOf supBox.UpdateData


        If press_name.Contains("Press") Then
            ButtonLayoutPanel.Controls.Add(buttonQR)

            Dim fiberBox As New toolboxMM.PressBox
            fiberBox.ColumnName = "Fiberglass Info"
            fiberBox.createDictionary("Exec Get_FiberGlassInfo '" & genBox.ColumnName & "'", "Select '" & fiberBox.ColumnName & "'")
            PressLayoutPanel.Controls.Add(fiberBox)
            'AddHandler buttonRefresh.Click, AddressOf fiberBox.UpdateData
        End If


        Dim scrapBox As New toolboxMM.PressBox
        scrapBox.ColumnName = "Hourly Scrap"
        scrapBox.createDictionary("Exec Get_Scrap_Overview '" & genBox.ColumnName & "'", "Select '" & scrapBox.ColumnName & "'")
        PressLayoutPanel.Controls.Add(scrapBox)
        'AddHandler buttonRefresh.Click, AddressOf scrapBox.UpdateData

        Dim perfBox As New PerformanceBox
        perfBox.FontScale = 0.75
        perfBox.HeightScale = 2
        'perfBox.FontSize = perfBox.FontSize / 1.5
        ' perfBox.BoxHeight = perfBox.BoxHeight * 1.5
        perfBox.ColumnName = "Performance"
        perfBox.createDictionary("Exec Get_Mold_Performance '" & genBox.ColumnName & "', '" & supBox.SupervisorName & "'", "Select '" & perfBox.ColumnName & "'", genBox.SupervisorName)
        PressLayoutPanel.Controls.Add(perfBox)


        If perfBox.NoFailureMode Then

            genBox.LastUpdate = New DateTime(1800, 1, 1)
            Dim temp As New UserInput
            temp.TextboxLabel = "Please provide a rationale and steps towards improvement."
            temp.DropdownLabel = "Select a failure mode."
            temp.DropdownTable = "Press_Rates_Failure_Modes"

            Dim query As String = "Exec Insert_Supervisor_Rationale '" & press_name & "', '" & SupervisorName & "', "
            temp.StoredProcedure = query

            temp.Show()
        End If


        PressLayoutPanel.Visible = True

        ButtonLayoutPanel.Controls.Add(buttonRefresh)
        buttonOverview.Select()


    End Sub

    Private Sub QR_Start_Click(sender As Object, e As EventArgs)
        QRScanner.Show()

    End Sub

    Private Sub Export_Click(sender As Object, e As EventArgs)
        PressDataExport.Show()
    End Sub

    Public Sub Export_Data(selected_date As Date, selected_shift As Integer)


        PressDataExport.Show()

        Dim SaveFile As New SaveFileDialog





        Dim DataGrid As New DataGridView
        Dim bindingsource1 As New BindingSource

        Dim selectedDate As Date = selected_date 'New Date(2024, 9, 24)
        Dim selectedShift As Integer = selected_shift ' 1
        Dim tempdataset As DataSet = toolboxMM.SQLTools.queryDatabase("Exec Get_Supervisor_Press_Reporting_Data '" & selectedDate.ToString("d") & "', " & selectedShift.ToString, "temp")

        Dim tempdata As DataTable = tempdataset.Tables("temp")

        For ii As Integer = tempdata.Columns.Count - 1 To 0 Step -1
            Dim colName As String = tempdata.Columns.Item(ii).ColumnName
            If colName.Contains("ID") Or colName.Contains("oldID") Or colName.Contains("Press_Number") Then
                tempdata.Columns.RemoveAt(ii)
            End If
        Next


        ' MsgBox("DataTableRows: " & tempdata.Rows.Count.ToString & vbCrLf & "DataTableCols: " & tempdata.Columns.Count.ToString)
        bindingsource1.DataSource = tempdata

        SaveFile.DefaultExt = "csv"
        ' TODO add selected date and shift to FileNAme
        SaveFile.FileName = "PressReport_" & "_shift" & selectedShift.ToString & "_" & DateAndTime.Day(selectedDate).ToString & Strings.Left(MonthName(Month(selectedDate)), 3) & Year(selectedDate) & ".csv"
        SaveFile.Filter = """Comma Delimited Text|*.csv"""
        SaveFile.RestoreDirectory = True
        SaveFile.Title = "Save Export Data"
        SaveFile.ValidateNames = False

        DataGrid.DataSource = bindingsource1
        DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells


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


            Dim i As Integer = 0
            Dim addName As Boolean = True
            For Each tempRow As DataRow In tempdata.Rows
                i = 0
                For Each tempCol As DataColumn In tempdata.Columns
                    If addName Then
                        If i = 0 Then
                            Row_String = tempCol.ColumnName
                        Else
                            Row_String = Row_String & "," & tempCol.ColumnName
                        End If

                    ElseIf i = 0 Then
                        Row_String = tempRow.Item(tempCol) & "" ' DataGrid.Rows(row).Cells(column).Value & ""
                    Else
                        Row_String = Row_String & "," & tempRow.Item(tempCol) ' Row_String & "," & DataGrid.Rows(row).Cells(column).Value
                    End If
                    i += 1


                Next
                addName = False

                PrintLine(1, Row_String)
            Next

            'For row = 0 To DataGrid.RowCount - 1
            '    For column = 0 To DataGrid.ColumnCount - 1
            '        If column = 0 Then
            '            Row_String = DataGrid.Rows(row).Cells(column).Value & ""
            '        Else
            '            Row_String = Row_String & "," & DataGrid.Rows(row).Cells(column).Value
            '        End If
            '    Next
            '    PrintLine(1, Row_String)
            'Next

            FileClose(1)
            MsgBox("Export Completed: " & filename)
        Catch ex As Exception
            MsgBox("Export Failed: " & ex.Message)
        End Try
        Me.UseWaitCursor = False

    End Sub


    Public Sub LoadButtonPanel()



        createButton(buttonRefresh, "Refresh")
        ' AddHandler buttonRefresh.Click, AddressOf QR_Start_Click;

        createButton(buttonQR, "Scan QR")
        AddHandler buttonQR.Click, AddressOf QR_Start_Click


        createButton(buttonOverview, "Refresh")
        AddHandler buttonOverview.Click, AddressOf LoadPressOverview
        ButtonLayoutPanel.Controls.Add(buttonOverview)
        buttonOverview.LastUpdate = New DateTime(1800, 1, 1)

        createButton(buttonExport, "Export Data")
        AddHandler buttonExport.Click, AddressOf Export_Click
        ButtonLayoutPanel.Controls.Add(buttonExport)

    End Sub


    Private Sub createButton(targetObj As Object, targetText As String)

        Dim fontSize As Double = ButtonLayoutPanel.Height / 7.5

        targetObj.Height = ButtonLayoutPanel.Height - (ButtonLayoutPanel.Height / 10)
        targetObj.Width = ButtonLayoutPanel.Width / 10
        targetObj.Font = New Font("Times New Roman", fontSize)
        targetObj.Text = targetText


    End Sub

    Private Sub RemoveClickEvent(btn As Object)


    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PressLayoutPanel.Width = Width
        PressLayoutPanel.Height = Height - (Height / 6)

        ButtonLayoutPanel.Width = Width - (Width / 10)
        ButtonLayoutPanel.Height = Height - PressLayoutPanel.Height - (PressLayoutPanel.Height / 10) ' Height / 15


        instructions.Multiline = True
        instructions.ReadOnly = True
        createButton(instructions, "Click on a press for details and to input information.")
        instructions.Width = ButtonLayoutPanel.Width / 6



        Dim xCoord As Integer = (ButtonLayoutPanel.Location.X + ButtonLayoutPanel.Width - instructions.Width)
        Dim yCoord As Integer = PressLayoutPanel.Location.Y + PressLayoutPanel.Height ' (ButtonLayoutPanel.Location.Y)
        ButtonLayoutPanel.Location = New Point(PressLayoutPanel.Location.X, yCoord)
        instructions.Location = New Point(xCoord, yCoord)
        ButtonLayoutPanel.Width = ButtonLayoutPanel.Width - (instructions.Width)
        Me.Controls.Add(instructions)


        LoadButtonPanel()
        LoadPressOverview()

    End Sub

    Private Sub Form_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

    End Sub

End Class


Public Class PerformanceBox

    Inherits toolboxMM.PressBox

    Public Overloads Sub createDictionary(procedure As String, query As String, supervisor As String)

        SQLQuery = query
        StoredProcedure = procedure
        SupervisorName = supervisor
        GetData()

    End Sub

    Private Sub GetData()

        LastUpdate = Now

        ' no_FailureMode = False

        Try


            Dim tempDictionary As New Dictionary(Of String, Integer)
            Dim tempMatrix As New List(Of List(Of String))


            Dim daTable As DataSet = toolboxMM.SQLTools.queryDatabase(StoredProcedure, "Data")

            Dim no_data As Boolean = True
            Dim low_rate As Boolean = False



            ' If daTable.Tables("Data").

            ' TODO: add a Clear() function somewhere in this class'
            For Each temp_dr As DataRow In daTable.Tables("Data").Rows
                If temp_dr("Low Rate") Then
                    low_rate = True
                End If
            Next

            For Each temp_dc As DataColumn In daTable.Tables("Data").Columns


                If Not (tempDictionary.ContainsKey(temp_dc.ColumnName)) Then
                    tempDictionary.Add(temp_dc.ColumnName, tempDictionary.Count)
                End If

                Dim temp_list As New List(Of String)





                For Each temp_dr As DataRow In daTable.Tables("Data").Rows

                    Dim tempString As String = ""

                    If low_rate Then
                        tempString = "Awaiting input."
                        If Not IsDBNull(temp_dr(temp_dc.ColumnName)) And Not (temp_dc.ColumnName = "Low Rate") Then
                            tempString = ""
                            no_data = False
                            tempString = ((temp_dr(temp_dc.ColumnName)).ToString)

                        End If

                        If tempString = "Awaiting input." And Not (temp_dc.ColumnName = "Low Rate") Then
                            no_FailureMode = True
                        End If
                    Else
                        tempString = "No input needed."
                        no_data = False
                        no_FailureMode = False
                        If Not IsDBNull(temp_dr(temp_dc.ColumnName)) And Not (temp_dc.ColumnName = "Low Rate") Then
                            tempString = ""
                            tempString = ((temp_dr(temp_dc.ColumnName)).ToString)

                        End If


                    End If


                    temp_list.Add(tempString)

                Next

                tempMatrix.Add(temp_list)


            Next

            tempMatrix.RemoveAt(tempDictionary("Low Rate"))
            tempDictionary.Remove("Low Rate")


            PropertyDictionary = tempDictionary
            DataMatrix = tempMatrix


            If no_FailureMode Then

                LineColor = Color.Red


            End If

            If no_data Then

                LineColor = Color.Red
                ErrorMessage = "Scan badge at station."
                ' no_FailureMode = False

            End If





            GenerateText()





        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private no_FailureMode As Boolean

    Public Property NoFailureMode As Boolean
        Get
            Return no_FailureMode
        End Get
        Set(value As Boolean)
            no_FailureMode = value
        End Set
    End Property


End Class







Public Class OverviewButton

    Inherits Button

    Private last_update As DateTime

    Public Property LastUpdate() As DateTime
        Get
            Return last_update
        End Get
        Set(value As DateTime)
            last_update = value
        End Set
    End Property

End Class




