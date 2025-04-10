Imports System.Data
Imports System.Data.SqlClient

Public Class Ctr_Press_History
    Dim ID_Array() As Int16
    Private bindingsource1 As New BindingSource

    Private Sub Ctr_Press_History_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        Dim start_time As DateTime
        Dim End_Time As DateTime

        start_time = DateAdd(DateInterval.Month, -1, Now)
        End_Time = Now

        DTP_Start_Date.Text = start_time
        DTP_Start_Time.Text = start_time
        DTP_End_Date.Text = End_Time
        DTP_End_Time.Text = End_Time

        DGV_Paint_Data.AutoGenerateColumns = True

        Call Load_Combo()
    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Try
            Cmb_Press.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from Press order by description", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Press")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("Press").Rows
                Cmb_Press.Items.Add(dr("Description"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next

            'lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            'lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Press History Screen(Load_Combo): " & Ex.Message, EventError)
        End Try



    End Sub

    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Dim query As String = ""
        Dim table_name As String = ""


        If Cmb_Press.SelectedIndex < 0 Then
            MsgBox("You must select a valid Press.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor


        query = "exec Get_Press_History " & ID_Array(Cmb_Press.SelectedIndex) & ", '" & DTP_Start_Date.Text & " " & DTP_Start_Time.Text & "', '" & DTP_End_Date.Text & " " & DTP_End_Time.Text & "'"
        bindingsource1.DataSource = GetData(query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Me.Cursor = Cursors.Default

    End Sub
End Class
