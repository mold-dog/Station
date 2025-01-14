Imports System.Data.SqlClient
Imports System.Runtime.InteropServices

Public Class Defect_RFID_Manual_Select
    Dim Part_ID_Array(100) As Integer
    Dim Part_Group_Array(100) As Integer
    Dim Part_Name_Array(100) As String
    Dim RFID_Prefix_Array(100) As String
    Dim Image_Array(100) As String
    Dim counter As Integer


    Private Sub Defect_RFID_Manual_Select_Load(sender As Object, e As EventArgs) Handles Me.Load
        Part_Type_Pic = ""
        Part_Type_Name = ""

        Lbl_Title.Text = Select_Part_Type
        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select id, description, Part_Type_Group, RFID_Prefix, Part_Type.Image_Name as Image from part_type where Manual_Select_Defect_Screen = 1 order by Part_Type_Group", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Parts")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("Parts").Rows
                If IsDBNull(dr("RFID_Prefix")) Or IsDBNull(dr("Part_Type_Group")) Or IsDBNull(dr("description")) Then
                Else
                    Part_ID_Array(counter) = dr("ID")
                    Part_Name_Array(counter) = dr("description")
                    Part_Group_Array(counter) = dr("Part_Type_Group")
                    RFID_Prefix_Array(counter) = dr("RFID_Prefix")
                    If IsDBNull(dr("Image")) Then
                    Else
                        If dr("Image") <> "" Then
                            Image_Array(counter) = dr("Image")
                        End If
                    End If
                End If
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Part_Type Info from Database: " & Ex.Message)
        End Try



        AddButtons()
    End Sub


    Private Sub AddButtons()

        Dim xPos As Integer = 0
        Dim yPos As Integer = 30
        Dim n As Integer = 0
        Dim Part_Group_Last As Integer = Part_Group_Array(0)

        Dim btnArray(counter) As System.Windows.Forms.Button
        Dim PboxArray(counter) As System.Windows.Forms.PictureBox
        For i As Integer = 0 To (counter - 1)
            btnArray(i) = New System.Windows.Forms.Button
            PboxArray(i) = New System.Windows.Forms.PictureBox
        Next i
        While (n < (counter))
            With (btnArray(n))

                .Tag = n + 1 ' Tag of button
                .Width = 200 ' Width of button
                .Height = 40 ' Height of button
                If (Part_Group_Array(n) <> Part_Group_Last) Or yPos > 600 Then

                    xPos = xPos
                    yPos = yPos + 20
                    If yPos > 600 And xPos = 850 Then
                        yPos = 30
                        xPos = 1275
                    End If
                    If yPos > 600 And xPos = 425 Then
                        yPos = 30
                        xPos = 850
                    End If
                    If yPos > 600 Then
                        yPos = 30
                        xPos = 425
                    End If
                End If

                Part_Group_Last = Part_Group_Array(n)
                .Left = xPos
                .Top = yPos

                Me.Controls.Add(btnArray(n))
                .Text = Part_Name_Array(n)

                AddHandler .Click, AddressOf Me.ClickButton

            End With
            With (PboxArray(n))

                .Tag = n + 1 ' Tag of button
                .Width = 200 ' Width of button
                .Height = 45 ' Height of button
                .SizeMode = 1
                .Left = xPos + 200
                .Top = yPos - 2

                Me.Controls.Add(PboxArray(n))
                If Image_Array(n) IsNot Nothing Then
                    PboxArray(n).Image = Image.FromFile(Image_Share & Image_Array(n), False)
                End If


                yPos = yPos + .Height + 5
                n += 1
            End With

        End While


    End Sub



    Public Sub ClickButton(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim btn As Button = sender
        Manual_Prefix = RFID_Prefix_Array(btn.Tag - 1)
        Part_Type_Pic = Image_Array(btn.Tag - 1)
        Part_Type_Name = Part_Name_Array(btn.Tag - 1)
        Defect_RFID_Manual_Entry_Form = New Defect_RFID_Manual_Entry
        Defect_RFID_Manual_Entry_Form.ShowDialog()

        Me.Close()



    End Sub


End Class

