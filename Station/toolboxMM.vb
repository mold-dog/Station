Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Reflection
Imports System.Collections.Generic
Imports System.Linq




Namespace toolboxMM

    Public Class General

        Shared Function formatString(str As String) As String



            For i As Integer = 0 To (str.Length - 1)
                If Char.IsLetter(str, i) Then

                    Dim tempDateTime As New DateTime
                    If DateTime.TryParse(str, tempDateTime) Then

                        ' Hack, but if a person manages to hit a scan at 00:000, good for them
                        If (tempDateTime.Second = "00" And tempDateTime.Millisecond = "000") Then
                            Return (tempDateTime.ToString("yyyy-MM-dd"))
                        Else
                            Return (tempDateTime.ToString("hh:mm tt"))
                        End If

                    Else
                        Dim myTI As TextInfo = New CultureInfo("en-US", False).TextInfo
                        str = myTI.ToLower(str)
                        Return myTI.ToTitleCase(str)
                    End If





                End If
            Next


            Dim tempDouble As New Double
            If (Double.TryParse(str, tempDouble)) Then
                tempDouble = Math.Round(tempDouble, 2)
            End If

            Return tempDouble.ToString

        End Function

    End Class

    Public Structure server
        Public Info As String
        Public UID As String
        Public Password As String
    End Structure


    Public Class SQLServer


        Private chosen_location As String

        Public Property ChosenLocation As String
            Get
                Return chosen_location
            End Get
            Set(value As String)
                chosen_location = value
            End Set
        End Property

        Private db_connection As String

        Public Property DBConnection As String
            Get
                Return db_connection
            End Get
            Set(value As String)
                db_connection = value
            End Set
        End Property


        Public Sub initializeConnection()

            Try
                Dim DBConnection As String


                Dim HRes As Integer = 1920
                Dim VRes As Integer = 1080

                Dim Image_Share As String

                Dim strDBServer As String = ""
                Dim strDBUID As String = ""
                Dim strDBpassword As String = ""
                Dim strHRes As String = ""
                Dim strVRes As String = ""



                Dim regsoftwarekey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE")
                If Not (regsoftwarekey Is Nothing) Then
                    Dim regoraclekey As RegistryKey = regsoftwarekey.OpenSubKey("ASA")
                    If Not (regoraclekey Is Nothing) Then
                        Dim regpaintprocesskey As RegistryKey = regoraclekey.OpenSubKey("RFID")
                        If Not (regpaintprocesskey Is Nothing) Then
                            If Not (regsoftwarekey Is Nothing) Then
                                strDBServer = regpaintprocesskey.GetValue("DBServer" & chosen_location, "")
                                strDBUID = regpaintprocesskey.GetValue("DBUID", "")
                                strDBpassword = regpaintprocesskey.GetValue("DBpassword", "")
                                strHRes = regpaintprocesskey.GetValue("HRes", "1920")
                                strVRes = regpaintprocesskey.GetValue("VRes", "1080")
                            End If
                            regpaintprocesskey.Close()
                        End If
                        regoraclekey.Close()
                    End If
                    regsoftwarekey.Close()
                End If
                DBConnection = "Server=" + strDBServer + ";uid=" + strDBUID + ";pwd=" + strDBpassword + ";database=RFID;Connection Timeout=30;"
                Image_Share = "\\" & strDBServer & "\Images\"
                'Image_Share = "C:\Images\"
                If IsNumeric(strHRes) Then
                    HRes = Val(strHRes)
                End If
                If IsNumeric(strVRes) Then
                    VRes = Val(strVRes)
                End If


            Catch ex As Exception

            End Try



        End Sub

        Public Function altConnection() As String


            Try
                Dim DBConnection As String


                Dim HRes As Integer = 1920
                Dim VRes As Integer = 1080

                Dim Image_Share As String

                Dim strDBServer As String = ""
                Dim strDBUID As String = ""
                Dim strDBpassword As String = ""
                Dim strHRes As String = ""
                Dim strVRes As String = ""



                Dim regsoftwarekey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE")
                If Not (regsoftwarekey Is Nothing) Then
                    Dim regoraclekey As RegistryKey = regsoftwarekey.OpenSubKey("ASA")
                    If Not (regoraclekey Is Nothing) Then
                        Dim regpaintprocesskey As RegistryKey = regoraclekey.OpenSubKey("RFID")
                        If Not (regpaintprocesskey Is Nothing) Then
                            If Not (regsoftwarekey Is Nothing) Then
                                Dim location As String
                                If chosen_location = "JC" Then
                                    location = "MA"
                                Else
                                    location = "JC"
                                End If

                                strDBServer = regpaintprocesskey.GetValue("DBServer" & location, "")

                                strDBUID = regpaintprocesskey.GetValue("DBUID", "")
                                strDBpassword = regpaintprocesskey.GetValue("DBpassword", "")
                                strHRes = regpaintprocesskey.GetValue("HRes", "1920")
                                strVRes = regpaintprocesskey.GetValue("VRes", "1080")
                            End If
                            regpaintprocesskey.Close()
                        End If
                        regoraclekey.Close()
                    End If
                    regsoftwarekey.Close()
                End If
                DBConnection = "Server=" + strDBServer + ";uid=" + strDBUID + ";pwd=" + strDBpassword + ";database=RFID;Connection Timeout=30;"
                Image_Share = "\\" & strDBServer & "\Images\"
                'Image_Share = "C:\Images\"
                If IsNumeric(strHRes) Then
                    HRes = Val(strHRes)
                End If
                If IsNumeric(strVRes) Then
                    VRes = Val(strVRes)
                End If

                Return DBConnection

            Catch ex As Exception

                Return ""

            End Try

        End Function






    End Class

    Public Class SQLTools


        ''' <summary>
        ''' Gets database connection as string from the information in the registry.
        ''' </summary>
        ''' <returns></returns>
        Shared Function getDBConnection() As String


            Try
                Dim DBConnection As String


                Dim HRes As Integer = 1920
                Dim VRes As Integer = 1080

                Dim Image_Share As String

                Dim strDBServer As String = ""
                Dim strDBUID As String = ""
                Dim strDBpassword As String = ""
                Dim strHRes As String = ""
                Dim strVRes As String = ""



                Dim regsoftwarekey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE")
                If Not (regsoftwarekey Is Nothing) Then
                    Dim regoraclekey As RegistryKey = regsoftwarekey.OpenSubKey("ASA")
                    If Not (regoraclekey Is Nothing) Then
                        Dim regpaintprocesskey As RegistryKey = regoraclekey.OpenSubKey("RFID")
                        If Not (regpaintprocesskey Is Nothing) Then
                            If Not (regsoftwarekey Is Nothing) Then
                                strDBServer = regpaintprocesskey.GetValue("DBServer", "")


                                strDBUID = regpaintprocesskey.GetValue("DBUID", "")
                                strDBpassword = regpaintprocesskey.GetValue("DBpassword", "")
                                strHRes = regpaintprocesskey.GetValue("HRes", "1920")
                                strVRes = regpaintprocesskey.GetValue("VRes", "1080")
                            End If
                            regpaintprocesskey.Close()
                        End If
                        regoraclekey.Close()
                    End If
                    regsoftwarekey.Close()
                End If
                DBConnection = "Server=" + strDBServer + ";uid=" + strDBUID + ";pwd=" + strDBpassword + ";database=RFID;Connection Timeout=30;"
                Image_Share = "\\" & strDBServer & "\Images\"
                'Image_Share = "C:\Images\"
                If IsNumeric(strHRes) Then
                    HRes = Val(strHRes)
                End If
                If IsNumeric(strVRes) Then
                    VRes = Val(strVRes)
                End If

                Return DBConnection

            Catch ex As Exception

                Return ""

            End Try

        End Function


        Shared Function queryDatabase(query As String, table As String) As DataSet

            Dim tempDataSet As New DataSet

            Try

                Dim SQLCon As New SqlConnection

                SQLCon.ConnectionString = getDBConnection()
                Dim SQL_Timeout As Integer = 150

                SQLCon.Open()

                Dim tempDataQuery As New SqlDataAdapter(query, SQLCon)
                tempDataQuery.SelectCommand.CommandTimeout = SQL_Timeout
                tempDataQuery.Fill(tempDataSet, table)

            Catch ex As Exception

                MsgBox(ex.ToString)
            End Try

            Return tempDataSet


        End Function





    End Class







    Public Class PressBox

        ' Inherits System.Windows.Forms.TextBox
        Inherits System.Windows.Forms.FlowLayoutPanel




        Private box_height As Integer = (SupPressRep.Height / 2.3)

        Public Property BoxHeight As Integer
            Get
                Return box_height
            End Get
            Set(value As Integer)
                box_height = value
            End Set
        End Property

        Private box_width As Integer = (SupPressRep.Width / 6) - (SupPressRep.Width / 60)

        Public Property BoxWidth As Integer
            Get
                Return box_width
            End Get
            Set(value As Integer)
                box_width = value
            End Set
        End Property

        Private font_size As Integer = box_height / 34

        Public Property FontSize As Integer
            Get
                Return font_size
            End Get
            Set(value As Integer)
                font_size = value
            End Set
        End Property

        Private font_scale As Double = 1

        Public Property FontScale As Double
            Get
                Return font_scale
            End Get
            Set(value As Double)
                font_scale = value
            End Set
        End Property

        Private height_scale As Double = 1

        Public Property HeightScale As Double
            Get
                Return height_scale
            End Get
            Set(value As Double)
                height_scale = value
            End Set
        End Property



        ''' <summary>
        ''' Generates the textboxes to display information based on current property values.
        ''' See GetProperties for a list of properties to Set.
        ''' </summary>
        Public Sub GenerateText()


            Me.Controls.Clear()

            Dim totalWidth As Integer = SupPressRep.Width
            Dim totalHeight As Integer = SupPressRep.Height



            ' Dim wid As Integer = (totalWidth / 6) ' 250
            ' wid = wid - (wid / 10)
            FlowDirection = FlowDirection.TopDown

            ' Dim hit As Integer = totalHeight / 2.3
            ' Dim fontSize As Double = box_height / 34

            Height = (box_height - (box_height / 10))
            Width = box_width

            Dim titleBox As New TextBox
            titleBox = createPressBox(titleBox, column_name, (fontSize + 4), (box_height / 8))
            Controls.Add(titleBox)

            If property_dictionary.ContainsKey("Supervisor Name") Then



                Dim extraInfo As String = " (" & getSupervisorName() & ")"
                titleBox.Text = titleBox.Text & extraInfo

                Dim recValue As DateTime = New DateTime(1800, 1, 1)

                Dim timeList As List(Of String) = data_matrix(property_dictionary("Time"))

                For i As Integer = 0 To (timeList.Count - 1)
                    Dim tempValue As DateTime = (timeList.Item(i))

                    If (tempValue > recValue) Then
                        recValue = tempValue
                    End If

                Next

                ' this will not work if there is ever a timedate inaccuracy on the machine
                If ((System.DateTime.Now - recValue).TotalHours > 2) Then
                    MsgBox("No punch found in last two hours." & vbCrLf & "Consider scanning tag at RFID reader.")
                End If



                If supervisor_name <> "" Then

                    Dim suplist As List(Of String) = data_matrix(property_dictionary("Supervisor Name"))
                    Dim q As Integer = 0
                    Dim removeList As New List(Of Integer)

                    For Each tempStr As String In suplist

                        If tempStr <> supervisor_name Then

                            removeList.Add(q)

                        End If

                        q += 1
                    Next


                    If removeList.Count > 0 Then

                        For j As Integer = removeList.Count - 1 To 0 Step -1

                            Dim tempMatrix As New List(Of List(Of String))

                            For Each tempList As List(Of String) In data_matrix
                                tempList.RemoveAt(removeList.Item(j))
                                tempMatrix.Add(tempList)

                            Next

                            data_matrix = tempMatrix


                        Next
                    End If

                End If

                data_matrix.RemoveAt(property_dictionary("Supervisor Name"))
                property_dictionary.Remove("Supervisor Name")

            End If

                Dim lineBox As New TextBox
            lineBox = createPressBox(lineBox, " ", (fontSize / 2), (box_height / 20))
            lineBox.BackColor = line_color
            Controls.Add(lineBox)


            ' choose controls based on counts of strings
            ' Three possible options
            ' Single Column
            ' Multiple Columns and Rows
            ' Single Row
            ' 
            ' Single column and single row format similarly

            FontSize = FontSize * FontScale
            BoxHeight = BoxHeight * HeightScale

            If data_matrix.Count = 1 Then


                Dim tempList As List(Of String) = data_matrix.Item(0)

                Dim temp As List(Of String) = property_dictionary.Keys.ToList()
                Dim keyString As String = temp(0)

                ' TODO: add autosizing based on count of list
                ' If nothing in list, notify user, else add lines
                If tempList.Count = 0 Then
                    Dim noInfo As New TextBox
                    noInfo = createPressBox(noInfo, error_message, fontSize, (box_height / 8))
                    Controls.Add(noInfo)
                Else
                    For i As Integer = 0 To (tempList.Count - 1)
                        Dim tempBox As New TextBox
                        tempBox = createPressBox(tempBox, keyString & ": " & tempList.Item(i), fontSize, (box_height / 8))
                        Controls.Add(tempBox)

                    Next

                End If

            ElseIf data_matrix.Item(0).Count > 1 Then

                Dim firstList As List(Of String) = data_matrix.Item(0)





                If property_dictionary.Count > 2 Then
                    Width = Width * 2
                    box_width = Width / 4
                    titleBox.Width = Width
                    lineBox.Width = Width
                    fontSize = fontSize / 1.5
                Else

                    box_width = Width / 2

                End If




                Dim newbox As New TableLayoutPanel
                newbox.Width = Width
                newbox.Height = (box_height / 1.5)


                newbox.RowCount = firstList.Count + 1
                newbox.ColumnCount = property_dictionary.Count


                For i As Integer = 0 To firstList.Count

                    If i = 0 Then

                        For Each tempkey As String In property_dictionary.Keys

                            Dim tempbox As New TextBox
                            tempbox.ReadOnly = True
                            tempbox.Font = New Font("Times New Roman", fontSize / 1.2)
                            tempbox.Height = Height / 8
                            tempbox.Width = box_width
                            tempbox.Text = tempkey
                            'MsgBox(tempkey & vbCrLf & property_dictionary(tempkey).ToString & ", " & i.ToString)

                            newbox.Controls.Add(tempbox, property_dictionary(tempkey), i)



                        Next

                    Else



                        For Each tempkey As String In property_dictionary.Keys

                            Dim templist As List(Of String) = data_matrix.Item(property_dictionary(tempkey))
                            Dim tempString As String = toolboxMM.General.formatString(templist(i - 1))

                            Dim tempbox As New TextBox
                            tempbox.ReadOnly = True
                            tempbox.Font = New Font("Times New Roman", fontSize / 1.2)
                            tempbox.Height = Height / 8
                            tempbox.Width = box_width
                            tempbox.Text = tempString

                            newbox.Controls.Add(tempbox, property_dictionary(tempkey), i)

                        Next

                    End If

                Next

                Controls.Add(newbox)


            Else

                Dim tempList As List(Of String) = data_matrix(0)

                If tempList.Count = 0 Then

                    If property_dictionary.ContainsKey("Supervisor Name") Then
                        MsgBox("No punch found during this shift." & vbCrLf & "Consider scanning tag at RFID reader.")
                    End If

                    Dim noInfo As New TextBox
                    noInfo = createPressBox(noInfo, error_message, fontSize, (box_height / 8))
                    Controls.Add(noInfo)

                Else


                    If property_dictionary.Count > 4 Then

                        fontSize = fontSize / 1.3
                        box_height = box_height / 2

                    End If


                    For Each tempKey As String In property_dictionary.Keys

                        Dim tempString As String = tempKey
                        tempList = data_matrix(property_dictionary(tempKey))


                        tempString = tempString & ": " & toolboxMM.General.formatString(tempList.Item(0))


                        Dim tempBox As New TextBox
                        tempBox = createPressBox(tempBox, tempString, (fontSize), (box_height / 8))
                        Controls.Add(tempBox)

                    Next

                    If called_from_populate Then
                        AddHandler Click, AddressOf loadSpecific
                    End If

                End If





            End If



        End Sub



        Public Function createPressBox(targetObj As TextBox, targetString As String, fontSize As Double, hit As Integer) As Object

            targetObj.ReadOnly = True
            targetObj.Font = New Font("Times New Roman", fontSize)
            targetObj.Text = targetString
            targetObj.Height = hit
            targetObj.Width = Width
            targetObj.Multiline = True

            If called_from_populate Then
                AddHandler targetObj.Click, AddressOf loadSpecific
            End If


            Return targetObj

        End Function

        Private line_color As Color = Color.DarkBlue

        Public Property LineColor() As Color
            Get
                Return line_color
            End Get
            Set(value As Color)
                line_color = value
            End Set
        End Property

        Private error_message As String = "No data available."

        Public Property ErrorMessage() As String
            Get
                Return error_message
            End Get
            Set(value As String)
                error_message = value
            End Set
        End Property

        Private supervisor_name As String = ""

        Public Property SupervisorName() As String
            Get
                Return supervisor_name
            End Get
            Set(value As String)
                supervisor_name = value
            End Set
        End Property

        Private Function getSupervisorName() As String

            Dim tempList As List(Of String) = data_matrix.Item(property_dictionary("Supervisor Name"))

            If supervisor_name = "" Then
                If tempList.Count = 0 Then
                    MsgBox("No punch found during this shift." & vbCrLf & "Consider scanning tag at RFID reader.")
                    supervisor_name = ""


                ElseIf tempList.Count = 1 Then
                    supervisor_name = tempList.Item(0)

                Else

                    Dim lastStr As String = tempList.Item(0)
                    Dim oneName As Boolean = True

                    For Each tempStr As String In tempList
                        If Not tempStr = lastStr Then
                            oneName = False
                        End If
                    Next

                    If oneName Then

                        supervisor_name = lastStr
                    Else



                        Dim UserIn As New UserInput
                        UserIn.DropdownList = tempList.Distinct().ToList
                        UserIn.DropdownLabel = "Select a supervisor."
                        UserIn.Show()


                        supervisor_name = ""

                    End If



                End If
            End If


            SupPressRep.SupervisorName = supervisor_name
            Return supervisor_name

        End Function



        ' values are column names
        Private property_dictionary As New Dictionary(Of String, Integer)

        Public Property PropertyDictionary() As Dictionary(Of String, Integer)
            Get
                Return property_dictionary
            End Get
            Set(value As Dictionary(Of String, Integer))
                property_dictionary = value
            End Set
        End Property

        Private data_matrix As New List(Of List(Of String))

        Public Property DataMatrix() As List(Of List(Of String))
            Get
                Return data_matrix
            End Get
            Set(value As List(Of List(Of String)))
                data_matrix = value
            End Set
        End Property


        ''' <summary>
        ''' Returns the below property names as a string array
        ''' </summary>
        ''' <returns></returns>
        Public Function GetProperties() As List(Of String)
            Return property_dictionary.Keys.ToList()
        End Function

        ' When the box was last updated
        Private last_update As DateTime

        Public Property LastUpdate() As DateTime
            Get
                Return last_update
            End Get
            Set(value As DateTime)
                last_update = value
            End Set
        End Property


        Private sql_query As String
        ''' <summary>
        ''' Name of SQL Stored Procedure to be queried
        ''' </summary>
        ''' <returns></returns>
        Public Property SQLQuery() As String
            Get
                Return sql_query
            End Get
            Set(value As String)
                sql_query = value
            End Set
        End Property


        Private stored_procedure As String

        Public Property StoredProcedure() As String
            Get
                Return stored_procedure
            End Get
            Set(value As String)
                stored_procedure = value
            End Set
        End Property


        Private column_name As String
        ''' <summary>
        ''' Title of box
        ''' </summary>
        ''' <returns></returns>
        Public Property ColumnName() As String
            Get
                Return column_name
            End Get
            Set(value As String)
                column_name = value
            End Set
        End Property




        Public Overridable Sub createDictionary(procedure As String, query As String)

            sql_query = query
            stored_procedure = procedure
            UpdateData()

        End Sub

        Public Sub RefreshData()

            If ((Now - last_update).TotalSeconds < 30) Then
                MsgBox("Data updated within last minute; please wait longer before refreshing.")

            ElseIf Not dead Then

                Me.Dispose()
                For Each tempcontrol As Control In SupPressRep.PressLayoutPanel.Controls
                    tempcontrol.Dispose()
                Next
                dead = True
                SupPressRep.LoadPressSpecifics(column_name, data_matrix)
            End If

            SupPressRep.buttonOverview.Select()

        End Sub

        Private dead As Boolean = False

        Public Sub UpdateData()

            last_update = Now

            Try


                property_dictionary.Clear()
                data_matrix.Clear()

                Dim daTable As DataSet = toolboxMM.SQLTools.queryDatabase(stored_procedure, "Data")



                ' TODO: add a Clear() function somewhere in this class'
                For Each temp_dc As DataColumn In daTable.Tables("Data").Columns


                    If Not (property_dictionary.ContainsKey(temp_dc.ColumnName)) Then
                        property_dictionary.Add(temp_dc.ColumnName, property_dictionary.Count)
                    End If

                    Dim temp_list As New List(Of String)



                    For Each temp_dr As DataRow In daTable.Tables("Data").Rows


                        Dim tempString As String = " "
                        If Not IsDBNull(temp_dr(temp_dc.ColumnName)) Then
                            tempString = ((temp_dr(temp_dc.ColumnName)).ToString)
                        End If

                        temp_list.Add(tempString)

                    Next

                    data_matrix.Add(temp_list)


                Next

                GenerateText()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try



        End Sub

        Private called_from_populate As Boolean = False

        Public Property CalledFromPopulate As Boolean
            Get
                Return called_from_populate
            End Get
            Set(value As Boolean)
                called_from_populate = value
            End Set
        End Property

        ''' <summary>
        ''' Adds PressBoxes to tempcontrol (generally a FlowLayoutPanel) based on quantity returned from
        ''' the query
        ''' </summary>
        ''' <param name="tempcontrol">control to be filled</param>
        ''' <param name="query">SQL query that returns single column with name of boxes</param>
        Shared Sub populateControl(tempcontrol As Control, query As String, procedure As String)


            Dim daTableInfo As DataSet = toolboxMM.SQLTools.queryDatabase(query, "Names")

            For Each temp_dr As DataRow In daTableInfo.Tables("Names").Rows

                Dim tempbox As New toolboxMM.PressBox
                tempbox.CalledFromPopulate = True
                tempbox.ColumnName = temp_dr.Item(0)
                tempbox.createDictionary("Exec " & procedure & " '" & tempbox.ColumnName & "'", query)
                tempcontrol.Controls.Add(tempbox)


            Next

        End Sub


        Private Sub loadSpecific(sender As Object, e As EventArgs)
            SupPressRep.LoadPressSpecifics(column_name, data_matrix)
        End Sub




        Public Sub RemoveClickEvent()

            RemoveHandler Click, AddressOf loadSpecific

            For Each tempControl As Control In Me.Controls.Cast(Of Control)
                RemoveHandler tempControl.Click, AddressOf loadSpecific
            Next

        End Sub


    End Class





End Namespace

