Public Class Number_Keyboard




    Private Sub Number_Keyboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        Manual_Suffix = ""
        Btn_Accept.Text = Accept
        Btn_Exit.Text = Exit_Button_Text
    End Sub

    Private Sub Btn_0_Click(sender As Object, e As EventArgs) Handles Btn_0.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "0"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_1_Click(sender As Object, e As EventArgs) Handles Btn_1.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "1"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_2_Click(sender As Object, e As EventArgs) Handles Btn_2.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "2"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_3_Click(sender As Object, e As EventArgs) Handles Btn_3.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "3"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_4_Click(sender As Object, e As EventArgs) Handles Btn_4.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "4"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_5_Click(sender As Object, e As EventArgs) Handles Btn_5.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "5"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_6_Click(sender As Object, e As EventArgs) Handles Btn_6.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "6"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_7_Click(sender As Object, e As EventArgs) Handles Btn_7.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "7"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_8_Click(sender As Object, e As EventArgs) Handles Btn_8.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "8"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_9_Click(sender As Object, e As EventArgs) Handles Btn_9.Click
        If Manual_Suffix.Length < 6 Then
            Manual_Suffix = Manual_Suffix & "9"
        Else
            MsgBox(Six_Character_Msg)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix

    End Sub

    Private Sub Btn_Back_Space_Click(sender As Object, e As EventArgs) Handles Btn_Back_Space.Click
        If Manual_Suffix.Length = 1 Then
            Manual_Suffix = ""
        End If
        If Manual_Suffix.Length = 2 Then
            Manual_Suffix = Manual_Suffix.Substring(0, 1)
        End If
        If Manual_Suffix.Length = 3 Then
            Manual_Suffix = Manual_Suffix.Substring(0, 2)
        End If
        If Manual_Suffix.Length = 4 Then
            Manual_Suffix = Manual_Suffix.Substring(0, 3)
        End If
        If Manual_Suffix.Length = 5 Then
            Manual_Suffix = Manual_Suffix.Substring(0, 4)
        End If
        If Manual_Suffix.Length = 6 Then
            Manual_Suffix = Manual_Suffix.Substring(0, 5)
        End If

        Txt_RFID_Suffix.Text = Manual_Suffix
    End Sub

    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles Btn_Exit.Click
        Manual_Suffix = ""
        Me.Close()
    End Sub

    Private Sub Btn_Accept_Click(sender As Object, e As EventArgs) Handles Btn_Accept.Click
        If Manual_Suffix.Length = 6 Then
            Me.Close()
        Else
            MsgBox(Six_Character_Msg)
        End If

    End Sub
End Class