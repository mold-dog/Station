Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Threading
Imports System.IO.Ports
Imports System.Collections.Generic

Imports System.Runtime.InteropServices

Imports System.ComponentModel.Component
Imports System.Collections.ObjectModel
Imports System.Management
Imports System


Public Class Slitter_Scanner


    Private WithEvents ScannerPort As New SerialPort

    Private portTimer As Timers.Timer






    Private Sub loading() Handles MyBase.Load

        lbl_scannerstatus.NoPortsFound()

        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With
        With borderForm
            .ShowInTaskbar = False
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .BackColor = Color.Black
            .Opacity = 0.25
            Dim r As Rectangle = Me.Bounds
            r.Inflate(2, 2)
            .Bounds = r
            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
            r = New Rectangle(3, 3, Me.Width - 4, Me.Height - 4)
            .Region.Exclude(RoundedRectangle(r, 48))
            .Show(Me)
        End With


        portTimer = New Timers.Timer(500)
        AddHandler portTimer.Elapsed, AddressOf portTimerElapsed

        FindPort()
        OpenPort()



    End Sub


#Region " Serial Connection"


    Private Sub portTimerElapsed()

        ' SerialPort.GetPortNames()
        If Not ScannerPort.IsOpen() Then
            FindPort()
            OpenPort()

        End If

    End Sub



    Private Sub DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles ScannerPort.DataReceived


        Dim current_read As String = ""

        Try
            current_read = ScannerPort.ReadExisting
        Catch ex As Exception
            ' MsgBox("Unable to read data from port." & vbCrLf & vbCrLf & ex.Message)
        End Try

        Dim tableName As String = "Fiberglass_Info"

        Dim parsed_string As String() = ParseString(current_read)
        Dim dataDictionary As Dictionary(Of String, String()) = createDictionary(tableName)
        Dim sortedArray As String(,) = btrSort(parsed_string, dataDictionary)


        If sortedArray IsNot Nothing Then

            addtoDatabase(sortedArray, tableName)



        End If


        If Not ScannerPort.IsOpen Then

            FindPort()
            OpenPort()

        End If

    End Sub


    Private Sub ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles ScannerPort.ErrorReceived

        ' MsgBox("Error received on scanner port." & vbCrLf & vbCrLf & e.ToString)

        If ScannerPort.IsOpen Then
            Try
                ScannerPort.Close()
            Catch ex As Exception

            End Try
        End If

        FindPort()
        OpenPort()

    End Sub

    Private Sub PinChanged(sender As Object, e As SerialPinChangedEventArgs) Handles ScannerPort.PinChanged

        If ScannerPort.IsOpen Then
            Try
                ScannerPort.Close()
            Catch ex As Exception

            End Try

        End If

        portTimer.Interval = 500
        portTimer.Start()
        'FindPort()
        'OpenPort()

    End Sub



    Private Sub FindPort()

        Dim scanning_ports As Boolean = True

        For i As Integer = 0 To 5


            Dim ports() As String = SerialPort.GetPortNames()

            If ports.Length = 0 Then
                If InvokeRequired Then
                    Invoke(Sub() lbl_scannerstatus.NoPortsFound())
                Else
                    lbl_scannerstatus.NoPortsFound()
                End If


            Else
                If InvokeRequired Then
                    Invoke(Sub() lbl_scannerstatus.ScanningPorts())
                Else
                    lbl_scannerstatus.ScanningPorts()
                End If

            End If

            For Each port_name As String In ports

                If scanning_ports Then

                    Dim port As New SerialPort(port_name)
                    Dim return_val As String = ""
                    Dim Command As String = ""

                    Try
                        If port.IsOpen Then
                            port.Close()
                        End If

                        port.ReadTimeout = 1000
                        port.BaudRate = 115200 '9600
                        port.DataBits = 8
                        port.Parity = IO.Ports.Parity.None
                        port.StopBits = IO.Ports.StopBits.One


                        port.Open()


                    Catch ex As Exception
                        ' MsgBox("Unable to open serial port." & vbCrLf & vbCrLf & ex.Message)
                    End Try

                    Try

                        'port.Write(Chr(&H16) & "M" & Chr(&HD) & "DEFOVR.")
                        'port.ReadExisting()

                        'port.Write(Chr(&H16) & "M" & Chr(&HD) & "DEFALT.")
                        'port.ReadExisting()

                        ' Thread.Sleep(500)


                        port.Write(Chr(&H16) & "M" & Chr(&HD) & "REVINF.")

                        Thread.Sleep(100)

                        Dim temp As String = port.ReadExisting()

                        ' MsgBox(temp)

                        If temp.Contains("Granit") Then

                            'port.Write(Chr(&H16) & "M" & Chr(&HD) & "TRMUSB130.")
                            'Thread.Sleep(200)

                            'MsgBox(port.ReadExisting())

                            'port.Write(Chr(&H16) & "M" & Chr(&HD) & "232CTS2.")
                            'Thread.Sleep(200)

                            'MsgBox(port.ReadExisting())

                            port.Close()

                            portTimer.Enabled = False

                            If InvokeRequired Then
                                Invoke(Sub() lbl_scannerstatus.PortConnected())
                            Else
                                lbl_scannerstatus.PortConnected()
                            End If

                            ScannerPort = port
                            scanning_ports = False

                            Return

                        End If

                    Catch ex As Exception
                        ' MsgBox("Unable to communicate with port." & vbCrLf & vbCrLf & ex.Message)
                    End Try

                End If
            Next

        Next

        If scanning_ports Then
            portTimer.Start()
        End If


    End Sub

    Private Sub OpenPort()


        If Not portTimer.Enabled Then



            Try
                If ScannerPort.IsOpen Then
                    Try
                        ScannerPort.Close()
                    Catch ex As Exception

                    End Try

                End If

                ScannerPort.ReadTimeout = 1000
                ScannerPort.BaudRate = 115200 '9600
                ScannerPort.DataBits = 8
                ScannerPort.Parity = IO.Ports.Parity.None
                ScannerPort.StopBits = IO.Ports.StopBits.One

                ScannerPort.Open()
                ScannerPort.RtsEnable = True


            Catch ex As Exception
                ' MsgBox("Unable to open main serial port." & vbCrLf & vbCrLf & ex.Message)
            End Try

        End If

    End Sub

#End Region


#Region " Data Handling "

    Private Function ParseString(data As String) As String()

        ' Originally made this to handle a list of strings, list could still be nice
        Dim strList As New List(Of String)

        Dim prevIndex As Integer = 0
        Dim maxLen As Integer = data.Length - 1

        Dim tempString As String = ""


        For i As Integer = 0 To maxLen

            If data(i) = "," And i <> 0 Then

                ' I think it may reference a bad index if i = 0, so have it pass that logic first
                If data(i - 1) <> "," Then
                    strList.Add(tempString)
                ElseIf data(i - 1) = "," Then
                    strList.Add("null")
                End If


                tempString = ""


            ElseIf data(i) <> "," Then
                tempString = tempString & data(i)
            End If

        Next


        If strList.Count < 2 And strList.Item(0) <> "" Then

            MsgBox("QR contained unexpected information:" & vbCrLf & strList.Item(0), MsgBoxStyle.Exclamation)

            Dim badArray As String() = {""}
            Return badArray

        End If

        Dim strArray As String() = strList.ToArray
        Return strArray



    End Function

    Private Function createDictionary(tableName As String) As Dictionary(Of String, String())


        ' grab keys based on first three letters of column name

        Dim newDictionary As Dictionary(Of String, String()) = New Dictionary(Of String, String())


        Try

            Dim SQLCon As New SqlConnection

            SQLCon.ConnectionString = toolboxMM.SQLTools.getDBConnection()
            Dim SQL_Timeout As Integer = 150

            SQLCon.Open()
            Dim daStation_Data As New SqlDataAdapter("Select COLUMN_NAME, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" & tableName & "'", SQLCon)
            daStation_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsStation As New DataSet
            'update name
            daStation_Data.Fill(dsStation, "columns")
            SQLCon.Close()

            ' go through each row and populate dictionary based on keys
            For Each columnName As DataRow In dsStation.Tables("columns").Rows

                ' ignore ID string
                If columnName.Item(0).ToString = "ID" Then

                Else

                    Dim keyString As String = Strings.LCase(Strings.Left(columnName.Item(0).ToString, 3))
                    Dim valString As String() = {columnName.Item(0).ToString, columnName.Item(1).ToString}

                    newDictionary.Add(keyString, valString)

                End If



            Next

        Catch Ex As Exception

            MsgBox("Error getting information from database: " & Ex.Message)
            newDictionary.Clear()

        End Try


        Return newDictionary

    End Function


    Private Function btrSort(inputArray As String(), sortDictionary As Dictionary(Of String, String())) As String(,)


        ' TODO: handle blank dictionary
        ' ^^^ isn't this handled by never having sortDictionary.ContainsKey(tla) return True?

        Dim arrMax As Integer = inputArray.Length - 1



        ' Dim arrIndex As Integer = 0
        Dim newArray(arrMax, 1) As String

        If arrMax = 0 Then
            Return newArray
        End If

        Dim dispStr As String = ""


        For i As Integer = 0 To arrMax

            Dim tla As String = Strings.Left(inputArray(i), 3)

            If sortDictionary.ContainsKey(tla) Then

                Dim tempArray As String() = sortDictionary(tla)
                ' newArray(i, 0) = Strings.Right(inputArray(i), inputArray(i).Length - 3)

                ' check if its a varchar, if not, then check to make sure it can be parsed
                If requireSingleQuotes(tempArray(1)) And Not (inputArray(i) = "null") Then

                    If tempArray(1).Contains("date") Then
                        Dim tempDate As New DateTime

                        If DateTime.TryParse(inputArray(i), tempDate) Then
                            newArray(i, 0) = "'" & Strings.Right(inputArray(i), inputArray(i).Length - 3) & "'"
                        Else
                            newArray(i, 0) = ""
                        End If

                    Else
                        newArray(i, 0) = "'" & Strings.Right(inputArray(i), inputArray(i).Length - 3) & "'"
                    End If



                Else
                    newArray(i, 0) = checkNumberValidity(Strings.Right(inputArray(i), inputArray(i).Length - 3), tempArray(0))
                End If

                newArray(i, 1) = tempArray(0)


            Else


                Dim invalid As Boolean = True

                For Each str As String In sortDictionary.Keys

                    If inputArray(i).Contains(str) Then
                        invalid = False

                        Dim zeroindex As Integer = inputArray(i).IndexOf(str)
                        Dim newstring As String = Strings.Mid(inputArray(i), zeroindex + 4)

                        If newstring.Contains("date") Then
                            Dim tempDate As New DateTime

                            If DateTime.TryParse(inputArray(i), tempDate) Then
                                newArray(i, 0) = "'" & Strings.Right(inputArray(i), inputArray(i).Length - 3) & "'"
                            Else
                                newArray(i, 0) = ""
                            End If

                        Else
                            newArray(i, 0) = "'" & Strings.Right(inputArray(i), inputArray(i).Length - 3) & "'"
                        End If

                    End If

                Next




                Dim catString As String = ""
                For q As Integer = 0 To arrMax
                    catString += inputArray(q)
                Next


                MsgBox("QR contained unexpected information:" & vbCrLf & inputArray(i) & vbCrLf & vbCrLf & "Full String:" & vbCrLf & catString, MsgBoxStyle.Exclamation)

                ' return empty string array
                Dim badArray(arrMax, 1) As String
                Return badArray


            End If
        Next

        Return newArray

    End Function

    Private Function checkNumberValidity(infoString As String, dataString As String) As String

        Dim tempDouble As Double

        If Double.TryParse(infoString, tempDouble) Then
            Return infoString
        Else
            'MsgBox("Unexpected data type, this information will not be added to the Database:" & vbCrLf & dataString & ": " & infoString)
            Return ""
        End If


    End Function


    Private Function requireSingleQuotes(dataType As String) As Boolean

        If dataType.Contains("var") Or dataType.Contains("char") Or dataType.Contains("date") Then ' = "varchar" Or dataType = "date" Or dataType = "datetime" Then
            Return True
        End If

        Return False

    End Function


    ''' <summary>
    ''' Takes a string array and attempts to add information contained in the first dimension into the database based on 
    ''' the second dimension of the array, which contains the column names.
    ''' </summary>
    ''' <param name="stringArray">parsed list of strings parsed from a QR code</param>
    Private Function addtoDatabase(stringArray As String(,), tableName As String) As Boolean

        Dim arrLength As Integer = stringArray.GetUpperBound(0)


        ' check if a bad array was passed before addng to the database
        For i As Integer = 0 To arrLength
            If stringArray(i, 0) Is Nothing Then
                Return False
            End If
        Next


        Dim query As String = "insert into " & tableName & " ("

        For i As Integer = 0 To arrLength

            query += stringArray(i, 1)

            If i < arrLength Then
                query += ", "

            Else
                query += ", LogDate"
            End If

        Next

        query += ") values("

        For i As Integer = 0 To arrLength


            If stringArray(i, 0) = "" Then
                query += "null"
            Else
                query += stringArray(i, 0)
            End If


            If i < arrLength Then
                query += ", "

            Else
                query += ", GetDate()"
            End If

        Next

        query += ")"


        Try

            'MsgBox("query")
            Dim SQLCon As New SqlConnection
            SQLCon.ConnectionString = toolboxMM.SQLTools.getDBConnection()
            SQLCon.Open()
            Dim cmd As New SqlCommand(query, SQLCon)
            cmd.ExecuteNonQuery()
            SQLCon.Close()
            Return True

        Catch ex As Exception

            MsgBox("Error adding information to database:" & vbCrLf & ex.ToString)
            Return False

        End Try




    End Function

#End Region




    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Me.Close()
    End Sub



#Region " Form Rounder "

    Private borderForm As New Form

    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.Black, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub



#End Region

End Class



Public Class SerialStatusLabel

    Inherits Label

    Public Sub NoPortsFound()



        Text = "No devices found!"
        BackColor = Color.PaleVioletRed

    End Sub


    Public Sub ScanningPorts()

        Text = "Scanning devices..."
        BackColor = Color.LightYellow



    End Sub


    Public Sub PortConnected()

        Text = "Device connected."
        BackColor = Color.LightGreen


    End Sub

End Class

'Friend Class USBNotification

'    Public Const DbtDevicearrival As Integer = &H8000
'    Public Const DbtDeviceremovecomplete As Integer = &H8004
'    Public Const WmDevicechange As Integer = &H219
'    Private Const DbtDevtypDeviceinterface As Integer = 5
'    Private Shared ReadOnly GuidDevinterfaceUSBDevice As Guid = New Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED")
'    Private Shared notificationHandle As IntPtr


'    Public Shared Sub RegisterUSBDeviceNotification(windowHandle As IntPtr)

'        Dim dbi As DevBroadcastDeviceInterface = New DevBroadcastDeviceInterface
'        dbi.DeviceType = DbtDevtypDeviceinterface
'        dbi.Reserved = 0
'        dbi.ClassGUID = GuidDevinterfaceUSBDevice
'        dbi.Name = 0
'        dbi.Size = Marshal.SizeOf(dbi)
'        Dim buffer As IntPtr = Marshal.AllocHGlobal(dbi.Size)
'        Marshal.StructureToPtr(dbi, buffer, True)

'        notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0)


'    End Sub


'    <DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = True)>
'    Private Shared RegisterDeviceNotification(recipient As IntPtr, notificationFilter As IntPtr, flags As Integer) As IntPtr

'    <DllImport("user32.dll")>
'    Private Shared UnregisterDeviceNotification(handle As IntPtr) As Boolean


'    <StructLayout(LayoutKind.Sequential)>
'    Private Structure DevBroadcastDeviceInterface
'        Friend Size As Integer
'        Friend DeviceType As Integer
'        Friend Reserved As Integer
'        Friend ClassGUID As Guid
'        Friend Name As Short
'    End Structure




'End Class

Public Class SerialPortWatcher



    Public Sub SerialPortWatcher()




    End Sub


End Class