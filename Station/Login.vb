Imports System.Data.SqlClient
Public Class Login
    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        Dim found As Boolean = False
        Dim Message_Response As Integer = 0

        Try

            If Len(txt_Username.Text) = 0 Then
                MsgBox("Please enter a valid Username.")
                Exit Sub
            End If
            If Len(Txt_Password.Text) = 0 Then
                MsgBox("Please enter a valid Password.")
                Exit Sub
            End If


            found = Verify_User(txt_Username.Text, Txt_Password.Text)
            If Not found Then
                MsgBox("User not found with entered Username and Password.  Please try again.")
            End If
            Me.Close()

        Catch Ex As Exception
            MsgBox("Error Getting User Info from Database: " & Ex.Message)
        End Try

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        End

    End Sub
End Class