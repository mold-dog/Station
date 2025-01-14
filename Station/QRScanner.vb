' Project: decodeQR
' Description: The purpose of this program is to
' develop a proof of concept for scanning QR codes.
' 
' This program will be used within the new
' Supervisor Press Reporting app.
'
'
' The program attempts to access a webcam, then each
' frame is displayed in a picture box, which the program
' automatically attempts to detect a QR in that frame. 
' The program detection rate is tied to how quickly the 
' computer can decode, not any arbitrary number.
'
' If a QR is detected, the program looks for the information
' it expects, and if it receives valid information, it adds
' it to the database.
' 
'
'
' Libraries available based on current 
' framework are limited. Some notes:
'   - ZXing provides QR decoder, does a decent job
'   - AForge.Video provides the webcam handling
'   - the AForge.Imaging library has some
'     nice image processing algorithms. Not
'     currently in use
'
'
' Revision History:
'
' Author:       Wilhelmina Fredenberg
' Date:         22-Jul-2024
' Description:  Initial Creation
'
'
' ---------------------------------------------------
' QR Code Explanation
'  --> as a reminder, here is a breakdown of a QR Code
'
'     +---+.TsZyFeLk.+---+
'     | @ |.uRaXgDmJ.| @ |
'     +---+.VqBwHcNi.+---+
'     ......wPcViBoH......
'     NmJiFeXoDuJaPgYxSrGf
'     oLkHgDyNeTkZqFzWtQhE
'     ......ZmFsLyRe+-+pId
'     +---+.aLgRmXsD|X|OjC
'     | @ |.BkHqNwTc+-+nKb
'     +---+.cJiPoVuBaVuMlA
'
' the @ boxes are the position patterns. these are recognized
' and used as corners for the transformation filter
'
' there is a quiet zone around the QR code that will be generated 
' based on the position of the position patterns (corners)
'
'
' the |X| is the alignment pattern and is used to orient the code
'
' once the QR Code is transformed, cropped, and oriented, then pass it
' through a QR threshold filter to turn it into a binary bitmap. This
' is easier to decode
'
'


Imports AForge.Video
Imports AForge.Video.DirectShow
' Imports AForge.Imaging.Filters
Imports ZXing
Imports System.Data.SqlClient
Imports Microsoft.Win32
Imports System.Collections.Generic
Imports System.Linq


' TODO: add events to logger for better debugging
Public Class QRScanner

    ' Create an object for the webcam to be used
    Dim newCam As DirectShow.VideoCaptureDevice

    Dim detectTimer As Timers.Timer

    Dim shouldClose As Boolean = False

    Private press_name As String = SupPressRep.PressName

    Public Property PressName As String
        Get
            Return press_name
        End Get
        Set(value As String)
            press_name = value
        End Set
    End Property

    ' Could improve this with threading or different data structure.
    ' Would a queue be too slow and memory intensive?
    Dim readytoDecode As Boolean = False
    Dim buffPic As Bitmap = New Bitmap(190, 190)

    Dim webcamNOTWorking As Boolean = True



    ' Consider removing this subroutine being tied to a button

    ' This sub starts the webcam and autodetection
    ' eventually the entire Class will be generated as a pop-up window and will not rely on a button clicks (aside from stop)
    Private Sub startQR(sender As Object, e As EventArgs) Handles btn_startQR.Click

        btn_startQR.Visible = False

        Try

            addProperties()


            If newCam IsNot Nothing Then

                AddHandler newCam.NewFrame, New NewFrameEventHandler(AddressOf dispVideo)
                newCam.Start()

                ' This timer initially checks if the webcam successfully starts, but then is later used to detect the QR code.
                ' If no frames are added, then the webcam is already in use and this program should alert user and close
                detectTimer = New System.Timers.Timer(5000)
                detectTimer.AutoReset = False
                AddHandler detectTimer.Elapsed, New Timers.ElapsedEventHandler(AddressOf detectQR)
                detectTimer.Start()

            End If


        Catch ex As Exception

            MsgBox("Issue starting the webcam." & vbCrLf & "Please close any program that is already accessing the webcam, or restart the device.", MsgBoxStyle.Exclamation)
            closeForm()


        End Try


    End Sub


    ''' <summary>
    ''' Attempts to detect a QR code. If detected, decodes QR, parses and sorts the string, adds the information to the database, then closes form.
    ''' </summary>
    Private Sub detectQR()

        If webcamNOTWorking Then

            MsgBox("Issue starting the webcam." & vbCrLf & "Please close any program that is already accessing the webcam, or restart the device.", MsgBoxStyle.Exclamation)
            closeForm()
        End If

        ' Create new bitmap to decode
        Dim pic As Bitmap = New Bitmap(190, 190)
        pic = buffPic

        ' this is where image processing would go

        Dim res As String = ""

        Try

            If pic IsNot Nothing Then
                res = decodeQR(pic)
            End If


            If res <> "" Then

                Dim tableName As String = "Fiberglass_Info"

                Dim infoArray As String() = parseCode(res)
                Dim dataDictionary As Dictionary(Of String, String()) = createDictionary(tableName)
                Dim prevArray As String() = prevSort(infoArray)
                Dim sortedArray As String(,) = btrSort(prevArray, dataDictionary)

                If sortedArray IsNot Nothing Then

                    If addtoDatabase(sortedArray, tableName) Then
                        newCam.Stop()
                        detectTimer.Dispose()
                        closeForm()
                    End If


                End If


            End If

            If shouldClose Then
                closeForm()
            End If


            readytoDecode = True

        Catch ex As Exception

        End Try


    End Sub






    ''' <summary>
    ''' Attempts to decode the bitmap image. Returns information string if successful, otherwise returns ""
    ''' </summary>
    ''' <param name="tempPic">image to be decoded</param>
    ''' <returns></returns>
    Private Function decodeQR(tempPic As Bitmap) As String

        Dim Reader As New BarcodeReader 'QRCodeReader()
        Reader.AutoRotate = True
        Reader.Options.TryHarder = True

        Dim newpic As Bitmap = New Bitmap(190, 190)
        newpic = tempPic

        Try
            Dim res As Result = Reader.Decode(tempPic) ' binBMP if

            If res IsNot Nothing Then

                textBox_QR.Text = res.Text

                Return res.Text
            Else
                Return ""
            End If

        Catch ex As Exception

            MsgBox("error: " & ex.ToString)
            Return ""
        End Try


    End Function




    ''' <summary>
    ''' Separates a string delimited by commas. Returns a unsorted string array.
    ''' Expected to return in the following order: material, date, viscosity,
    ''' roll/lot number, specific gravity, and net weight.
    ''' </summary>
    ''' <param name="qrString">comma delimited string outputted from QR code</param>
    ''' <returns></returns>
    Private Function parseCode(qrString As String) As String()

        ' Originally made this to handle a list of strings, list could still be nice
        Dim strList As New List(Of String)

        Dim prevIndex As Integer = 0
        Dim maxLen As Integer = qrString.Length - 1

        Dim tempString As String = ""


        For i As Integer = 0 To maxLen

            If qrString(i) = "," And i <> 0 Then

                ' I think it may reference a bad index if i = 0, so have it pass that logic first
                If qrString(i - 1) <> "," Then
                    strList.Add(tempString)
                ElseIf qrString(i - 1) = "," Then
                    strList.Add("null")
                End If


                tempString = ""


            ElseIf qrString(i) <> "," Then
                tempString = tempString & qrString(i)
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




    ''' <summary>
    ''' Assigns column name to each piece of information passed in. Also adds
    ''' single quotes based on data type required by that column
    ''' </summary>
    ''' <param name="inputArray"></param>
    ''' <returns></returns>
    Private Function btrSort(inputArray As String(), sortDictionary As Dictionary(Of String, String())) As String(,)


        ' TODO: handle blank dictionary
        ' ^^^ isn't this handled by never having sortDictionary.ContainsKey(tla) return True?

        Dim arrMax As Integer = inputArray.Count - 1



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

                Dim catString As String = ""
                For q As Integer = 0 To arrMax
                    catString += inputArray(q)
                Next


                MsgBox("QR contained unexpected information:" & vbCrLf & catString, MsgBoxStyle.Exclamation)

                ' return empty string array
                Dim badArray(arrMax, 1) As String
                Return badArray


            End If
        Next

        Return newArray

    End Function


    Private Function prevSort(inputArray As String()) As String()


        Dim arrMax As Integer = inputArray.Length - 1

        Dim acroArray As String() = New String() {"typ", "man", "vis", "bat", "spe", "pro", "gla", "gel", "cur", "rol", "mat", "sto", "edg", "she"}

        Dim tempArray(arrMax) As String

        For i As Integer = 0 To arrMax

            tempArray(i) = acroArray(i) & inputArray(i)

        Next


        Return tempArray


    End Function

    ''' <summary>
    ''' Creates a dictionary where the keys are the first three letters of a column (as lowercase)
    ''' and the value is the full name of that call in first index and the data taype in the second index.
    ''' </summary>
    ''' <param name="tableName">SQL table to be called</param>
    ''' <returns></returns>
    Private Function createDictionary(tableName As String) As Dictionary(Of String, String())


        ' grab keys based on first three letters of column name

        Dim newDictionary As Dictionary(Of String, String()) = New Dictionary(Of String, String())


        Try

            Dim SQLCon As New SqlConnection

            SQLCon.ConnectionString = getDBConnection()
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
    ''' Gets database connection as string from the information in the registry.
    ''' </summary>
    ''' <returns></returns>
    Private Function getDBConnection() As String


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
                query += ", LogDate, Press"
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
                query += ", GetDate(), (Select ID From Press Where Description = '" & press_name & "')"
            End If

        Next

        query += ")"


        Try

            Dim SQLCon As New SqlConnection
            SQLCon.ConnectionString = getDBConnection()
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






    ''' <summary>
    ''' Displays webcam frames in picture box. Also adds the new frame to buffPic
    ''' if the program is readytoDecode and starts timer, which will attempt to
    ''' decode the image after a short delay.
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="eventArgs"></param>
    Private Sub dispVideo(sender As Object, eventArgs As NewFrameEventArgs)

        ' frame received, set that webcam is working (if not already set)
        If webcamNOTWorking Then
            webcamNOTWorking = False
            If detectTimer.Enabled Then
                detectTimer.Stop()
            End If

            readytoDecode = True
        End If


        ' Checks if there is an image, then disposes of it before grabbing a new one.
        ' without this you will eat RAM
        If camPreview.Image IsNot Nothing Then
            camPreview.Invoke(New MethodInvoker(Sub() camPreview.Image.Dispose()))
        End If

        camPreview.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)

        If readytoDecode Then

            readytoDecode = False
            buffPic.Dispose()
            buffPic = New Bitmap(190, 190)
            buffPic = DirectCast(eventArgs.Frame.Clone(), Bitmap)

            detectTimer.Interval = 100
            detectTimer.Start()

        End If

    End Sub



    ''' <summary>
    ''' Attempts to automatically add properties to webcam. If unable, 
    ''' prompt the user to select their webcam properties
    ''' </summary>
    Private Sub addProperties()

        selectVideoDevice()

        ' if no video device was selected, prompt user to select device and settings
        If newCam Is Nothing Then

            Dim cams As DirectShow.VideoCaptureDeviceForm = New DirectShow.VideoCaptureDeviceForm()


            ' Prompts the dialog box to get webcam properties, starts webcam
            If cams.ShowDialog = DialogResult.OK Then
                newCam = cams.VideoDevice
            End If
        End If


    End Sub


    ''' <summary>
    ''' Looks at available video devices and selects one if it is the only device OR if a device's name contains "back" or "rear". Also, sets resolution to 640 x 480.
    ''' </summary>
    Private Sub selectVideoDevice()

        Dim availableVideoInputs As VideoInput = Nothing

        Dim videoDevices As FilterInfoCollection = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        If videoDevices.Count = 0 Then
            MsgBox("No video capture devices detected!", MsgBoxStyle.Information)

        ElseIf videoDevices.Count = 1 Then

            newCam = New VideoCaptureDevice(videoDevices(0).MonikerString)
            setResolution()

        Else
            For Each device As FilterInfo In videoDevices
                If (device.Name.IndexOf("BACK", 0, StringComparison.CurrentCultureIgnoreCase) > -1) Or (device.Name.IndexOf("REAR", 0, StringComparison.CurrentCultureIgnoreCase) > -1) Then
                    newCam = New VideoCaptureDevice(device.MonikerString)
                    setResolution()
                End If
            Next
        End If




    End Sub


    ''' <summary>
    ''' Looks through available resolutions and sets it to 640 x 480 if possible.
    ''' Otherwise, it arbitrarily grabs the first option.
    ''' </summary>
    Private Sub setResolution()

        Dim videoCapabilities As VideoCapabilities() = newCam.VideoCapabilities

        For Each capability As VideoCapabilities In videoCapabilities
            If capability.FrameSize.Width = 640 And capability.FrameSize.Width = 480 Then
                newCam.VideoResolution = capability
            End If
        Next


        ' If newCam.VideoResolution Is Nothing Then
        ' newCam.VideoResolution = videoCapabilities(0)
        ' End If


    End Sub



    ' Breaking this out into a separate function lets other programs finish their
    ' loop before closing the form out
    Private Sub readytoclose() Handles btn_stopQR.Click
        shouldClose = True

        If webcamNOTWorking Then
            closeForm()
        End If
    End Sub


    ''' <summary>
    ''' Stops functions and disposes of components before closing the form.
    ''' </summary>
    Private Sub closeForm()


        ' timer sometimes causes hang-ups
        Try
            If detectTimer.Enabled Then

                detectTimer.Stop()
                detectTimer.Dispose()
            End If
            If newCam.IsRunning Then
                newCam.Stop()
                newCam.WaitForStop()
            End If

            If camPreview.Image IsNot Nothing Then
                camPreview.Invoke(New MethodInvoker(Sub() camPreview.Image.Dispose()))
            End If

        Catch ex As Exception

        End Try


        ' this should probably be done in 
        Me.Close()

    End Sub

    Private Sub QRScanner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_startQR.PerformClick()
    End Sub
End Class
