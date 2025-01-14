Imports System.Data
Imports System.Data.SqlClient


Public Class Ctr_Paint_Conveyor

    Dim carrier_consecutive_fail_count As Integer = 0
    Dim counts_consecutive_fail_count As Integer = 0
    Dim film_check_consecutive_fail_count As Integer = 0
    Private Sub Ctr_Paint_Conveyor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Load_Data()
        Call Load_Counts()
        Call Load_Film_Check()

    End Sub

    Sub Load_Data()
        Dim Carrier_Station As Integer = 1
        Dim Max_Carriers As Integer = 166


        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()

            Dim daCarrier_Data As New SqlDataAdapter("Exec Paint_Conveyor", SQLCon)
            daCarrier_Data.SelectCommand.CommandTimeout = 120
            Dim dsCarrier As New DataSet
            daCarrier_Data.Fill(dsCarrier, "Carrier")
            SQLCon.Close()
            For Each drCarrier As DataRow In dsCarrier.Tables("Carrier").Rows
                Do While Carrier_Station < drCarrier("Carrier_Station") And Carrier_Station <= Max_Carriers
                    Me.Controls("Carrier" & Carrier_Station).Visible = False
                    Carrier_Station += 1
                Loop
                If Carrier_Station = drCarrier("Carrier_Station") And Carrier_Station <= Max_Carriers Then
                    If drCarrier("Carrier_Number") > 0 Then
                        If TypeOf Me.Controls("Carrier" & Carrier_Station) Is Carrier Then
                            Write_Carrier_Data(Me.Controls("Carrier" & Carrier_Station), drCarrier("Carrier_Number"), drCarrier("Style"), drCarrier("Color"), drCarrier("Quantity"))
                        End If
                        If TypeOf Me.Controls("Carrier" & Carrier_Station) Is Carrier_Sideways Then
                            Write_Carrier_Sideways_Data(Me.Controls("Carrier" & Carrier_Station), drCarrier("Carrier_Number"), drCarrier("Style"), drCarrier("Color"), drCarrier("Quantity"))
                        End If
                    Else
                        Me.Controls("Carrier" & Carrier_Station).Visible = False
                    End If

                    Carrier_Station += 1
                End If
            Next
            Do While Carrier_Station <= Max_Carriers
                Me.Controls("Carrier" & Carrier_Station).Visible = False
                Carrier_Station += 1
            Loop
            carrier_consecutive_fail_count = 0
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Paint Conveyor Screen(Carrier Refresh): " & Ex.Message, EventError)
            carrier_consecutive_fail_count += 1
            If carrier_consecutive_fail_count > 5 Then
                lbl_Comm_Fail.Visible = True
                'MsgBox("Error Getting Carrier Info from Database: " & Ex.Message)
            End If
        End Try



    End Sub

    Sub Write_Carrier_Data(ByRef Carrier_Control As Carrier, ByVal carrier_number As Integer, ByVal Style As String, ByVal Color As String, ByVal Quantity As Integer)
        If carrier_number > 0 Then
            Carrier_Control.Visible = True
        Else
            Carrier_Control.Visible = False
        End If
        Carrier_Control.Carrier_Number = carrier_number
        Carrier_Control.Style = Style
        Carrier_Control.Paint_Color = Color
        Carrier_Control.Quantity = Quantity
    End Sub
    Sub Write_Carrier_Sideways_Data(ByRef Carrier_Control As Carrier_Sideways, ByVal carrier_number As Integer, ByVal Style As String, ByVal Color As String, ByVal Quantity As Integer)
        If carrier_number > 0 Then
            Carrier_Control.Visible = True
        Else
            Carrier_Control.Visible = False
        End If
        Carrier_Control.Carrier_Number = carrier_number
        Carrier_Control.Style = Style
        Carrier_Control.Paint_Color = Color
        Carrier_Control.Quantity = Quantity
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call Load_Data()
        Call Load_Counts()
        If Station_ID > 0 Then
            Call Update_Station_Status
        End If


    End Sub
    Sub update_station_status()

        Try

            SQLCon.Open()
            Dim cmd As New SqlCommand("", SQLCon)

            cmd.CommandText = "update station set Last_Response = getdate() where id = " & Station_ID
            cmd.ExecuteNonQuery()
            SQLCon.Close()
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Paint Conveyor Screen(Update Station): " & Ex.Message, EventError)

        End Try

    End Sub
    Sub Load_Counts()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 50


        Try

            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim daCounts_Data As New SqlDataAdapter("Exec Paint_Conveyor_Counts", SQLCon)
            daCounts_Data.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsCounts As New DataSet
            daCounts_Data.Fill(dsCounts, "Counts")
            SQLCon.Close()
            For Each drCounts As DataRow In dsCounts.Tables("Counts").Rows
                If Quantity_Count <= Max_Counts Then
                    '                    Write_Carrier_Data(Me.Controls("Carrier" & Quantity_Count), drCarrier("Carrier_Number"), drCarrier("Style"), drCarrier("Color"), drCarrier("Quantity"))
                    Me.Controls("lbl_Part_Type" & Quantity_Count).Text = Mid(drCounts("Part_Type") & "", 1, 25)
                    Me.Controls("lbl_Color" & Quantity_Count).Text = Mid(drCounts("color") & "", 1, 25)
                    Me.Controls("lbl_Qty" & Quantity_Count).Text = drCounts("quantity") & ""
                    Me.Controls("lbl_Process" & Quantity_Count).Text = drCounts("Process_Name") & ""
                    Me.Controls("lbl_Time" & Quantity_Count).Text = Format(DateAdd(DateInterval.Second, Val(drCounts("Time_out") & ""), Now), "short time")

                    Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Color" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Qty" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Process" & Quantity_Count).Visible = True
                    Me.Controls("lbl_Time" & Quantity_Count).Visible = True
                    Quantity_Count += 1
                End If
            Next
            Do While Quantity_Count <= Max_Counts
                Me.Controls("lbl_Part_Type" & Quantity_Count).Visible = False
                Me.Controls("lbl_Color" & Quantity_Count).Visible = False
                Me.Controls("lbl_Qty" & Quantity_Count).Visible = False
                Me.Controls("lbl_Process" & Quantity_Count).Visible = False
                Me.Controls("lbl_Time" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop

            counts_consecutive_fail_count = 0
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Paint Conveyor Screen(Update Counts): " & Ex.Message, EventError)
            counts_consecutive_fail_count += 1
            If counts_consecutive_fail_count > 5 Then
                lbl_Comm_Fail.Visible = True
                'MsgBox("Error Getting Count Info from Database: " & Ex.Message)
            End If
        End Try



    End Sub

    Private Sub Film_Check_Timer_Tick(sender As Object, e As EventArgs) Handles Film_Check_Timer.Tick
        Call Load_Film_Check()
    End Sub

    Sub Load_Film_Check()
        Dim Quantity_Count As Integer = 1
        Dim Max_Counts As Integer = 7
        Dim query As String = ""


        Try
            query = "SELECT Film_Check_Parts.RFID, Film_Check_Parts.Failed_Clear, Film_Check_Parts.Failed_Base, part_type.Description as Part_type_desc, final_color.Description as color_desc "
            query = query & "FROM ((Film_Check_Parts inner join part on Film_check_Parts.RFID = part.RFID) inner join Part_Type on part.Part_Type = part_type.id) "
            query = query & "left join Final_Color on part.color = final_color.id"
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim dafilm_check As New SqlDataAdapter(query, SQLCon)
            dafilm_check.SelectCommand.CommandTimeout = SQL_Timeout
            Dim dsfilm_check As New DataSet
            dafilm_check.Fill(dsfilm_check, "Film_Check")
            SQLCon.Close()
            For Each drfilm_check As DataRow In dsfilm_check.Tables("Film_Check").Rows
                If Quantity_Count <= Max_Counts Then
                    Me.Controls("FC_Part_" & Quantity_Count).Text = Mid(drfilm_check("RFID") & "", 1, 25)
                    Me.Controls("FC_Part_Type_" & Quantity_Count).Text = Mid(drfilm_check("Part_type_desc") & "", 1, 25)
                    Me.Controls("FC_Color_" & Quantity_Count).Text = Mid(drfilm_check("color_desc") & "", 1, 25)

                    Me.Controls("FC_Part_" & Quantity_Count).Visible = True
                    Me.Controls("FC_Part_Type_" & Quantity_Count).Visible = True
                    Me.Controls("FC_Color_" & Quantity_Count).Visible = True

                    If drfilm_check("Failed_Clear") Or drfilm_check("Failed_Base") Then
                        Me.Controls("FC_Part_" & Quantity_Count).ForeColor = Color.Red
                        Me.Controls("FC_Part_Type_" & Quantity_Count).ForeColor = Color.Red
                        Me.Controls("FC_Color_" & Quantity_Count).ForeColor = Color.Red
                    Else
                        Me.Controls("FC_Part_" & Quantity_Count).ForeColor = Color.Black
                        Me.Controls("FC_Part_Type_" & Quantity_Count).ForeColor = Color.Black
                        Me.Controls("FC_Color_" & Quantity_Count).ForeColor = Color.Black
                    End If
                    Quantity_Count += 1
                End If
            Next
            Do While Quantity_Count <= Max_Counts
                Me.Controls("FC_Part_" & Quantity_Count).Visible = False
                Me.Controls("FC_Part_Type_" & Quantity_Count).Visible = False
                Me.Controls("FC_Color_" & Quantity_Count).Visible = False

                Quantity_Count += 1
            Loop

            film_check_consecutive_fail_count = 0
            lbl_Comm_Fail.Visible = False

        Catch Ex As Exception
            If SQLCon.State = ConnectionState.Open Then
                SQLCon.Close()
            End If
            lbl_Comm_Fail.Visible = True
            WriteEvent("Error registered on Paint Conveyor Screen(Film Check): " & Ex.Message, EventError)
            film_check_consecutive_fail_count += 1
            If film_check_consecutive_fail_count > 5 Then
                lbl_Comm_Fail.Visible = True
                'MsgBox("Error Getting Film Check Info from Database: " & Ex.Message)
            End If

        End Try



    End Sub

    Private Sub FC_Part_1_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_1.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_1.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub

    Private Sub FC_Part_2_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_2.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_2.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub
    Private Sub FC_Part_3_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_3.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_3.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub
    Private Sub FC_Part_4_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_4.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_4.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub
    Private Sub FC_Part_5_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_5.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_5.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub
    Private Sub FC_Part_6_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_6.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_6.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub
    Private Sub FC_Part_7_DoubleClick(sender As Object, e As EventArgs) Handles FC_Part_7.DoubleClick
        Paint_Production_RFID_Query_Form = New Paint_Production_RFID_Query
        Paint_Production_RFID_Query_Form.RFID = FC_Part_7.Text
        Paint_Production_RFID_Query_Form.Show()

    End Sub


End Class
