Public Class Local_Read
    Private Sub ReceiveSerialData()
        ' Receive strings from a serial port.
        Dim counter As Integer = 0
        Dim good_Data As Boolean = False
        Dim Ascii_Value As Integer = 0
        Me.Cursor = Cursors.WaitCursor
        Dim returnStr As String = ""
        If Cmb_Serial_Ports.SelectedIndex < 0 Then
            MsgBox("Please pick a valid serial port.")
            Exit Sub
        End If
        Dim com1 As IO.Ports.SerialPort = Nothing
        Try
            com1 = My.Computer.Ports.OpenSerialPort(Cmb_Serial_Ports.Text)
            com1.ReadTimeout = 10000
            com1.BaudRate = 115200

            com1.DataBits = 8
            com1.Handshake = IO.Ports.Handshake.None
            com1.Parity = IO.Ports.Parity.None
            com1.StopBits = IO.Ports.StopBits.One
            Do While 1 = 1
                Dim Incoming As String = com1.ReadLine()
                If Incoming Is Nothing Then
                    'Exit Do
                Else
                    If (Len(Incoming)) > 24 Then
                        Incoming = Mid(Incoming, 1, 24)
                    End If
                    good_Data = True
                    For counter = 1 To Len(Incoming)
                        Ascii_Value = Asc(Mid(Incoming, counter, 1))
                        If (Ascii_Value < 48) Or ((Ascii_Value > 57) And (Ascii_Value < 65)) Or ((Ascii_Value > 70) And (Ascii_Value < 97)) Or (Ascii_Value > 102) Then
                            good_Data = False
                        End If
                    Next
                    If good_Data Then
                        returnStr &= Incoming
                        Exit Do
                    End If
                End If

            Loop

        Catch ex As TimeoutException
            MsgBox("Error: Serial Port read timed out.")
        Finally
            If com1 IsNot Nothing Then com1.Close()
        End Try
        Txt_Data.Text = returnStr
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub Local_Read_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show all available COM ports.
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Cmb_Serial_Ports.Items.Add(sp)
        Next
    End Sub

    Private Sub Btn_Get_Data_Click(sender As Object, e As EventArgs) Handles Btn_Get_Data.Click
        Txt_Data.Text = ""
        Call ReceiveSerialData()
    End Sub

    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        Global_RFID = Txt_Data.Text
        Me.Close()
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Global_RFID = ""
        Me.Close()
    End Sub
End Class