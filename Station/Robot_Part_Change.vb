Imports System.Data.SqlClient
Public Class Robot_Part_Change
    Public Robot_Number As Integer = 0
    Dim Bell_Array() As Int32
    Dim Spray_Head_Array() As Int32
    Dim Air_Cap_Array() As Int32
    Dim Retaining_Ring_Array() As Int32
    Dim Reason_Array() As Int32

    Dim Bell As Int32
    Dim Spray_Head As Int32
    Dim Air_Cap As Int32
    Dim Retaining_Ring As Int32


    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        Dim Query As String = ""
        Dim Update_Found As Boolean = False


        If Cmb_Bell.SelectedIndex < 0 Then
            MsgBox("Please select a valid Gun\Bell.")
            Exit Sub
        End If
        If Cmb_Spray_Head.SelectedIndex < 0 Then
            MsgBox("Please select a valid spray head.")
            Exit Sub
        End If
        If Cmb_Air_Cap.SelectedIndex < 0 Then
            MsgBox("Please select a valid Air Cap.")
            Exit Sub
        End If
        If Cmb_Retaining_Ring.SelectedIndex < 0 Then
            MsgBox("Please select a valid Retaining Ring.")
            Exit Sub
        End If
        If Cmb_Reason.SelectedIndex < 0 Then
            MsgBox("Please select a valid reason for updating the parts.")
            Exit Sub
        End If


        Query = "Update Robot_Status Set "
        If Bell <> Bell_Array(Cmb_Bell.SelectedIndex) Then
            Query = Query & " Bell = " & Bell_Array(Cmb_Bell.SelectedIndex) & ", Bell_Updated = '" & DTP_Change_Date.Text & " " & DTP_Change_Time.Text & "'"
            Update_Found = True
        End If

        If Spray_Head <> Spray_Head_Array(Cmb_Spray_Head.SelectedIndex) Then
            If Update_Found Then
                Query = Query & ", "
            End If
            Query = Query & " Spray_Head = " & Spray_Head_Array(Cmb_Spray_Head.SelectedIndex) & ", Spray_Head_Updated = '" & DTP_Change_Date.Text & " " & DTP_Change_Time.Text & "'"
            Update_Found = True
        End If

        If Air_Cap <> Air_Cap_Array(Cmb_Air_Cap.SelectedIndex) Then
            If Update_Found Then
                Query = Query & ", "
            End If
            Query = Query & "  Air_Cap = " & Air_Cap_Array(Cmb_Air_Cap.SelectedIndex) & ", Air_Cap_Updated = '" & DTP_Change_Date.Text & " " & DTP_Change_Time.Text & "'"
            Update_Found = True
        End If
        If Retaining_Ring <> Retaining_Ring_Array(Cmb_Retaining_Ring.SelectedIndex) Then
            If Update_Found Then
                Query = Query & ", "
            End If
            Query = Query & "  Retaining_Ring = " & Retaining_Ring_Array(Cmb_Retaining_Ring.SelectedIndex) & ", Retaining_Ring_Updated = '" & DTP_Change_Date.Text & " " & DTP_Change_Time.Text & "'"
            Update_Found = True
        End If
        If Update_Found Then
            Query = Query & " where Robot_Number = " & Robot_Number

            SQLCon.Open()
            Dim cmd As New SqlCommand("", SQLCon)

            cmd.CommandText = Query
            cmd.ExecuteNonQuery()

            Query = "Insert into Robot_History (Robot, Bell, Spray_Head, Air_Cap, Retaining_Ring, Updated, Update_Reason) values(" & Robot_Number & ", " & Bell_Array(Cmb_Bell.SelectedIndex) & ", "
            Query = Query & Spray_Head_Array(Cmb_Spray_Head.SelectedIndex) & ", " & Air_Cap_Array(Cmb_Air_Cap.SelectedIndex) & ", " & Retaining_Ring_Array(Cmb_Retaining_Ring.SelectedIndex) & ", '" & DTP_Change_Date.Text & " " & DTP_Change_Time.Text & "', " & Reason_Array(Cmb_Reason.SelectedIndex) & ")"

            cmd.CommandText = Query
            cmd.ExecuteNonQuery()

            SQLCon.Close()
        End If
        Me.Close()

    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Me.Close()

    End Sub

    Sub Load_Bells()
        Dim query As String = ""
        Dim counter As Integer = 0

        query = "Select ID, Description from Robot_Part where Bell = 1 and In_Service = 1 and ID not in (Select Bell from Robot_Status where Bell is not null and Robot_Number <> " & Robot_Number & ") "
        If Robot_Number < 5 Then
            query = query & " and Base = 1 "
        Else
            query = query & " and Clear = 1 "
        End If
        query = query & " order by Description"
        Try
            Cmb_Bell.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Parts")
            SQLCon.Close()
            ReDim Bell_Array(0)
            For Each dr As DataRow In ds.Tables("Robot_Parts").Rows
                Cmb_Bell.Items.Add(dr("Description"))
                ReDim Preserve Bell_Array(counter)
                Bell_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Robot Part Info from Database: " & Ex.Message)
        End Try



    End Sub

    Sub Load_Spray_Head()
        Dim query As String = ""
        Dim counter As Integer = 0

        query = "Select ID, Description from Robot_Part where Spray_Head = 1 and In_Service = 1 and ID not in (Select Spray_Head from Robot_Status where Spray_Head is not null and Robot_Number <> " & Robot_Number & ") "
        If Robot_Number < 5 Then
            query = query & " and Base = 1 "
        Else
            query = query & " and Clear = 1 "
        End If
        query = query & " order by Description"
        Try
            Cmb_Spray_Head.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Parts")
            SQLCon.Close()
            ReDim Spray_Head_Array(0)
            For Each dr As DataRow In ds.Tables("Robot_Parts").Rows
                Cmb_Spray_Head.Items.Add(dr("Description"))
                ReDim Preserve Spray_Head_Array(counter)
                Spray_Head_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Robot Part Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Air_Cap()
        Dim query As String = ""

        Dim counter As Integer = 0

        query = "Select ID, Description from Robot_Part where Air_Cap = 1 and In_Service = 1 and ID not in (Select Air_Cap from Robot_Status where Air_Cap is not null and Robot_Number <> " & Robot_Number & ") "
        If Robot_Number < 5 Then
            query = query & " and Base = 1 "
        Else
            query = query & " and Clear = 1 "
        End If
        query = query & " order by Description"

        Try
            Cmb_Air_Cap.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Parts")
            SQLCon.Close()
            ReDim Air_Cap_Array(0)
            For Each dr As DataRow In ds.Tables("Robot_Parts").Rows
                Cmb_Air_Cap.Items.Add(dr("Description"))
                ReDim Preserve Air_Cap_Array(counter)
                Air_Cap_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Robot Part Info from Database: " & Ex.Message)
        End Try



    End Sub
    Sub Load_Retaining_Ring()
        Dim query As String = ""

        Dim counter As Integer = 0

        query = "Select ID, Description from Robot_Part where Retaining_Ring = 1 and In_Service = 1 and ID not in (Select retaining_ring from Robot_Status where retaining_ring is not null and Robot_Number <> " & Robot_Number & ") "
        If Robot_Number < 5 Then
            query = query & " and Base = 1 "
        Else
            query = query & " and Clear = 1 "
        End If
        query = query & " order by Description"

        Try
            Cmb_Retaining_Ring.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Parts")
            SQLCon.Close()
            ReDim Retaining_Ring_Array(0)
            For Each dr As DataRow In ds.Tables("Robot_Parts").Rows
                Cmb_Retaining_Ring.Items.Add(dr("Description"))
                ReDim Preserve Retaining_Ring_Array(counter)
                Retaining_Ring_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Robot Part Info from Database: " & Ex.Message)
        End Try



    End Sub

    Sub Load_Reason()
        Dim query As String = ""

        Dim counter As Integer = 0

        query = "Select ID, Reason from Robot_Update_Reason order by reason"

        Try
            Cmb_Reason.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim da As New SqlDataAdapter(query, SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "Robot_Update_Reason")
            SQLCon.Close()
            ReDim Reason_Array(0)
            For Each dr As DataRow In ds.Tables("Robot_Update_Reason").Rows
                Cmb_Reason.Items.Add(dr("Reason"))
                ReDim Preserve Reason_Array(counter)
                Reason_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Robot Update Reason Info from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Load_Data()
        Dim query As String = ""

        query = "Select Robot_Number, Robot_Name, Robot_Status.Bell, Bell_Table.Description as Bell_Desc, Robot_Status.Spray_Head, Spray_Head_Table.Description as Spray_Head_Desc, Robot_Status.Air_Cap, "
        query = query & " Air_Cap_Table.Description as Air_Cap_Desc, Robot_Status.Retaining_Ring, Retaining_Ring_Table.Description as Retaining_Ring_Desc "
        query = query & " from (((Robot_Status left join Robot_Part Bell_Table on Robot_Status.Bell = Bell_Table.id) left join Robot_Part Spray_Head_Table on Robot_Status.Spray_Head = Spray_Head_Table.Id) "
        query = query & " left join Robot_Part Air_Cap_Table on Robot_Status.Air_Cap = Air_Cap_Table.ID) left join Robot_Part Retaining_Ring_Table on Robot_Status.Retaining_Ring = Retaining_Ring_Table.ID where Robot_Number = " & Robot_Number

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter(query, SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "Robot_Status")
        SQLCon.Close()
        For Each dr As DataRow In ds.Tables("Robot_Status").Rows
            Lbl_Robot.Text = dr("Robot_Name") & ""
            Cmb_Bell.Text = dr("Bell_Desc") & ""
            Cmb_Spray_Head.Text = dr("Spray_Head_Desc") & ""
            Cmb_Air_Cap.Text = dr("Air_Cap_Desc") & ""
            Cmb_Retaining_Ring.Text = dr("Retaining_Ring_Desc") & ""
            Bell = dr("Bell") & ""
            Spray_Head = dr("Spray_Head") & ""
            Air_Cap = dr("Air_Cap") & ""
            Retaining_Ring = dr("Retaining_Ring") & ""
            Cmb_Reason.Text = ""
        Next

    End Sub

    Private Sub Robot_Part_Change_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next

        Call Load_Bells()
        Call Load_Spray_Head()
        Call Load_Air_Cap()
        Call Load_Retaining_Ring()
        Call Load_Reason()
        Call Load_Data()

    End Sub


End Class