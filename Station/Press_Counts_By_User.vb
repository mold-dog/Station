Imports System.Data
Imports System.Data.SqlClient


Public Class Press_Counts_By_User
    Private bindingsource1 As New BindingSource
    Private Sub Press_Counts_By_User_Load(sender As Object, e As EventArgs) Handles Me.Load


        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Hour, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time
    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String
        Dim counter As Integer = 0

        Dim dup_detected As Boolean

        query = "Exec Get_Press_Users_By_Time '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        Try
            Cmb_Users.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Users")
            SQLCon.Close()
            'ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Users").Rows
                dup_detected = 0
                For Each cboitem As Object In Cmb_Users.Items
                    If cboitem.ToString.Contains(dr("Name")) Then
                        dup_detected = 1
                    End If
                Next
                If dup_detected = 0 Then
                    Cmb_Users.Items.Add(dr("Name"))
                End If
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Area Info from Database: " & Ex.Message)
        End Try

    End Sub

    Private Sub Cmb_Users_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Users.SelectedIndexChanged
        Dim query As String = ""


        Me.Cursor = Cursors.WaitCursor


        query = "Get_Press_Counts_By_User '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "', '" & Cmb_Users.SelectedItem & "'"



        bindingsource1.DataSource = GetData(query)

        DGV_Press_Counts.DataSource = bindingsource1
        DGV_Press_Counts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Press_Counts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default

    End Sub
End Class