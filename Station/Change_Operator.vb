Imports System.Data.SqlClient

Public Class Change_Operator
    Dim ID_array() As Integer
    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()

    End Sub

    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        If Cmb_Operator.SelectedIndex >= 0 Then
            Operator_ID = ID_array(Cmb_Operator.SelectedIndex)
            Me.Close()
        Else
            MsgBox("Please select a valid operator.")
        End If
    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Operator.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from operator where getdate() between start_date and end_date order by name ", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "operator")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("operator").Rows
                If Len(dr("Employee_Number") & "") > 0 Then
                    Cmb_Operator.Items.Add(dr("name") & " - " & dr("Employee_Number"))
                Else
                    Cmb_Operator.Items.Add(dr("name") & "")
                End If

                ReDim Preserve ID_array(counter)
                ID_array(counter) = dr("ID")
                    counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Operators from Database: " & Ex.Message)
        End Try



    End Sub

    Private Sub Change_Operator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Combo()

        Cmb_Operator.Text = get_operator(Str(Operator_ID))
    End Sub
End Class