Imports Microsoft.Office.Interop.Excel
Imports System.Reflection

Public Class Slitter_Import







    Private Sub Extract_Data(filepath As String)






        Try
            Dim xl As Application = New Application()
            Dim wbs As Workbooks = xl.Workbooks
            Dim wb As Workbook = wbs.Open(filepath)

            wb.Activate()

            Dim foundrow As Integer
            Dim rng As Range

            MsgBox(wb.Worksheets.Count.ToString)


            For Each ws As Worksheet In wb.Worksheets


                Try

                    If ws.Visible Then


                        MsgBox("here0")

                        rng = ws.Range("A1").EntireColumn

                        MsgBox("here1")

                        foundrow = rng.Find("Batch Number").Row

                        MsgBox("here2")

                        MsgBox(foundrow.ToString)

                    End If

                Catch ex As Exception

                    MsgBox(ex.Message)

                End Try





                'MsgBox(ws.Range("A1:Z60").Find("BatchNumber").ToString)


            Next


        Catch ex As Exception

            MsgBox(ex.Message)

        End Try





    End Sub




    Private Sub Find_File() Handles Button1.Click

        Try


            Using open_file_dialog As OpenFileDialog = New OpenFileDialog()

                open_file_dialog.InitialDirectory = "C:\\"
                open_file_dialog.Filter = "Excel Worksheets|*.xls;*.xlsx"
                open_file_dialog.FilterIndex = 2
                open_file_dialog.RestoreDirectory = True

                If open_file_dialog.ShowDialog() = DialogResult.OK Then

                    Try
                        Extract_Data(open_file_dialog.FileName)
                    Catch ex As Exception
                        MsgBox("woof")
                    End Try




                End If

            End Using

        Catch ex As Exception

            MsgBox("Invalid File", EventError)
            WriteEvent("Unable to open file in Slitter Import", EventError)

        End Try


    End Sub

End Class