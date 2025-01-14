Imports System.Data.SqlClient
Imports System.Drawing.Printing


Public Class Operator_Info
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim Printer_Exists As Boolean = False
    Dim ID_Array() As Int32
    Dim print_BC() As Struct_New_BC
    Dim label_printer As String
    Dim WithEvents new_bc As New PrintDocument

    Public Structure Struct_New_BC
        Dim Name As String
        Dim Employee_Number As String
        Dim Employee_ID As String
    End Structure
    Private Sub Btn_Add_Click(sender As Object, e As EventArgs) Handles Btn_Add.Click
        Txt_Name.Text = ""
        txt_RFID.Text = ""
        txt_Employee_Number.Text = ""

        DTP_Start_Date.Text = Format(Now, "M/d/yyyy")
        DTP_End_Date.Text = "1/1/3000"

        Txt_Name.Visible = True
        Cmb_Name.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_RFID.Enabled = True
        txt_Employee_Number.Enabled = True
        DTP_Start_Date.Enabled = True
        DTP_End_Date.Enabled = True
        Btn_Print.Visible = False

        Adding = True


    End Sub

    Private Sub Btn_Edit_Click(sender As Object, e As EventArgs) Handles Btn_Edit.Click
        Txt_Name.Visible = True
        Cmb_Name.Visible = False
        Btn_Save.Visible = True
        Btn_Cancel.Visible = True
        Btn_Add.Visible = False
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_RFID.Enabled = True
        txt_Employee_Number.Enabled = True
        DTP_Start_Date.Enabled = True
        DTP_End_Date.Enabled = True
        Btn_Print.Visible = False


        Txt_Name.Text = Cmb_Name.Text

        Editing = True
        Initialize_Screen()
    End Sub

    Private Sub Btn_Save_Click(sender As Object, e As EventArgs) Handles Btn_Save.Click

        Dim update_string As String
        Dim counter As Integer = 1
        Dim response As Integer

        If txt_Employee_Number.Text = "" Then
            MsgBox("Employee Number Cannot Be Blank")
            Exit Sub
        End If

        If Adding = False And Editing = True Then
            update_string = "update operator Set name = '" & Txt_Name.Text & "', rfid_tag = '" & txt_RFID.Text & "', employee_number = '" & txt_Employee_Number.Text & "', start_date = '" & DTP_Start_Date.Text & "', end_date = '" & DTP_End_Date.Text & "' where id = " & txt_ID.Text
            Do While Me.Controls("txt_RFID" & counter).Visible = True
                update_string = update_string & "  update operator Set name = '" & Txt_Name.Text & "', rfid_tag = '" & Me.Controls("txt_RFID" & counter).Text & "', employee_number = '" & Me.Controls("txt_Employee_Number" & counter).Text & "', start_date = '" & Me.Controls("DTP_Start_Date" & counter).Text & "', end_date = '" & Me.Controls("DTP_End_Date" & counter).Text & "' where id = " & Me.Controls("txt_ID" & counter).Text
                counter += 1
            Loop
        End If

        SQLCon.Open()
        Dim cmd As New SqlCommand("", SQLCon)

        If Adding Then
            cmd.CommandText = "Insert into operator (name, rfid_tag, employee_number, start_date, end_date) values ('" & Txt_Name.Text & "', '" & txt_RFID.Text & "', '" & txt_Employee_Number.Text & "', '" & DTP_Start_Date.Text & "', '" & DTP_End_Date.Text & "')"
        Else
            If Cmb_Name.SelectedIndex < 0 Then
                SQLCon.Close()
                Exit Sub
            End If
            cmd.CommandText = update_string
        End If
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        If Printer_Exists Then
            response = MsgBox("Would you like to print a barcode label?", vbYesNo)
            If response = 6 Then
                ReDim print_BC(0)
                print_BC(0).Name = Txt_Name.Text
                print_BC(0).Employee_Number = txt_Employee_Number.Text
                If counter > 1 Then
                    print_BC(0).Employee_ID = Me.Controls("txt_RFID" & (counter - 1)).Text
                Else
                    print_BC(0).Employee_ID = txt_RFID.Text
                End If
                Print_BC_Request(sender, e)
            End If
        End If

        Cmb_Name.Visible = True
        Txt_Name.Visible = False
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_RFID.Enabled = False
        txt_Employee_Number.Enabled = False
        DTP_Start_Date.Enabled = False
        DTP_End_Date.Enabled = False
        Btn_Print.Visible = False


        Editing = False
        Adding = False

        Call Load_Combo()
        Cmb_Name.Text = ""
        txt_RFID.Text = ""
        txt_Employee_Number.Text = ""
        DTP_Start_Date.Text = Format(Now, "M/d/yyyy")
        DTP_End_Date.Text = "1/1/3000"




    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click

        Txt_Name.Visible = False
        Cmb_Name.Visible = True
        Btn_Save.Visible = False
        Btn_Cancel.Visible = False
        Btn_Add.Visible = True
        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        txt_RFID.Enabled = False
        txt_Employee_Number.Enabled = False
        DTP_Start_Date.Enabled = False
        DTP_End_Date.Enabled = False
        Btn_Print.Visible = False

        Cmb_Name.Text = ""
        txt_RFID.Text = ""
        txt_Employee_Number.Text = ""
        DTP_Start_Date.Text = Format(Now, "M/d/yyyy")
        DTP_End_Date.Text = "1/1/3000"


        Editing = False
        Adding = False
        Initialize_Screen()

    End Sub

    Sub Load_Combo()

        Dim counter As Integer = 0
        Initialize_Screen()
        Try
            Cmb_Name.Items.Clear()
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select * from operator order by name", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "operator")
            SQLCon.Close()
            ReDim ID_Array(0)
            For Each dr As DataRow In ds.Tables("operator").Rows
                Cmb_Name.Items.Add(dr("name"))
                ReDim Preserve ID_Array(counter)
                ID_Array(counter) = dr("ID")
                counter += 1
            Next


        Catch Ex As Exception

            MsgBox("Error Getting Operators from Database: " & Ex.Message)
        End Try



    End Sub



    Private Sub Cmb_Description_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_Name.SelectedIndexChanged
        Call Load_Data()

    End Sub

    Private Sub Btn_Delete_Click(sender As Object, e As EventArgs) Handles Btn_Delete.Click
        If Cmb_Name.SelectedIndex < 0 Then
            Exit Sub
        End If

        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim cmd As New SqlCommand("delete from operator where name = '" & Cmb_Name.SelectedItem & "'", SQLCon)
        cmd.ExecuteNonQuery()
        SQLCon.Close()
        Call Load_Combo()
        Cmb_Name.Text = ""
        txt_RFID.Text = ""
        txt_Employee_Number.Text = ""
        DTP_Start_Date.Text = Format(Now, "M/d/yyyy")
        DTP_End_Date.Text = "1/1/3000"

        Btn_Edit.Visible = False
        Btn_Delete.Visible = False
        Btn_Print.Visible = False

    End Sub
    Private Sub Load_Data()
        Dim counter As Integer = 0
        If Cmb_Name.SelectedIndex < 0 Or Cmb_Name.Text = "" Then
            Exit Sub
        End If
        Btn_Edit.Visible = True
        Btn_Delete.Visible = True
        If Printer_Exists Then
            Btn_Print.Visible = True
        End If
        ReDim print_BC(0)


        SQLCon.ConnectionString = DBConnection
        SQLCon.Open()
        Dim da As New SqlDataAdapter("Select * from operator where name = '" & Cmb_Name.SelectedItem & "'", SQLCon)
        da.SelectCommand.CommandTimeout = SQL_Timeout
        Dim ds As New DataSet
        da.Fill(ds, "operator")
        SQLCon.Close()
        Initialize_Screen()
        For Each dr As DataRow In ds.Tables("operator").Rows
            If counter = 0 Then
                txt_RFID.Text = dr("rfid_tag") & ""
                txt_Employee_Number.Text = dr("employee_number") & ""
                DTP_Start_Date.Text = dr("start_date") & ""
                DTP_End_Date.Text = dr("end_date") & ""
                txt_ID.Text = dr("id") & ""
            Else
                Me.Width += (counter - 1) * 100
                Me.Controls("txt_RFID" & counter).Text = dr("rfid_tag") & ""
                Me.Controls("txt_Employee_Number" & counter).Text = dr("employee_number") & ""
                Me.Controls("DTP_Start_Date" & counter).Text = dr("start_date") & ""
                Me.Controls("DTP_End_Date" & counter).Text = dr("end_date") & ""
                Me.Controls("txt_ID" & counter).Text = dr("id") & ""
                Me.Controls("txt_RFID" & counter).Visible = True
                Me.Controls("txt_Employee_Number" & counter).Visible = True
                Me.Controls("DTP_Start_Date" & counter).Visible = True
                Me.Controls("DTP_End_Date" & counter).Visible = True
                Me.Controls("txt_ID" & counter).Visible = False
            End If
            counter += 1
            print_BC(0).Name = Cmb_Name.SelectedItem
            print_BC(0).Employee_Number = dr("employee_number")
            print_BC(0).Employee_ID = dr("rfid_tag")
        Next


    End Sub

    Private Sub Operator_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim computer As String
        Dim printerName As String
        Dim printerExists As Boolean
        Dim wmiService As Object
        Dim installedPrinters As Object
        Dim printer As Object


        Try
            SQLCon.ConnectionString = DBConnection
            SQLCon.Open()
            Dim da As New SqlDataAdapter("Select Barcode_Printer from Parameters", SQLCon)
            da.SelectCommand.CommandTimeout = SQL_Timeout
            Dim ds As New DataSet
            da.Fill(ds, "printer")
            SQLCon.Close()
            For Each dr As DataRow In ds.Tables("printer").Rows
                label_printer = (dr("Barcode_Printer"))
            Next


        Catch Ex As Exception
            SQLCon.Close()
            MsgBox("Error Getting Label Printer from Database: " & Ex.Message)
        End Try

        computer = "."
        wmiService = GetObject("winmgmts:" & "{impersonationLevel=impersonate}!\\" & computer & "\root\cimv2")
        installedPrinters = wmiService.ExecQuery("Select * from Win32_Printer")



        For Each printer In installedPrinters
            If UCase(printer.Name) = UCase(label_printer) Then
                printerExists = True
                Printer_Exists = True
            End If
        Next printer

        Call Load_Combo()
        Initialize_Screen()
        Btn_Add.Enabled = User_Permissions_Operator_Management
        Btn_Edit.Enabled = User_Permissions_Operator_Management
        Btn_Delete.Enabled = User_Permissions_Operator_Management

    End Sub


    Private Sub Initialize_Screen()
        Dim counter As Integer = 1

        Me.Width = 500


        For counter = 1 To 9
            If Editing Then
                Me.Controls("txt_RFID" & counter).Enabled = True
                Me.Controls("txt_Employee_Number" & counter).Enabled = True
                Me.Controls("DTP_Start_Date" & counter).Enabled = True
                Me.Controls("DTP_End_Date" & counter).Enabled = True
                Me.Controls("txt_ID" & counter).Enabled = True
            Else
                Me.Controls("txt_RFID" & counter).Text = ""
                Me.Controls("txt_Employee_Number" & counter).Text = ""
                Me.Controls("DTP_Start_Date" & counter).Text = ""
                Me.Controls("DTP_End_Date" & counter).Text = ""
                Me.Controls("txt_ID" & counter).Text = ""
                Me.Controls("txt_RFID" & counter).Visible = False
                Me.Controls("txt_Employee_Number" & counter).Visible = False
                Me.Controls("DTP_Start_Date" & counter).Visible = False
                Me.Controls("DTP_End_Date" & counter).Visible = False
                Me.Controls("txt_ID" & counter).Visible = False
                Me.Controls("txt_RFID" & counter).Enabled = False
                Me.Controls("txt_Employee_Number" & counter).Enabled = False
                Me.Controls("DTP_Start_Date" & counter).Enabled = False
                Me.Controls("DTP_End_Date" & counter).Enabled = False
                Me.Controls("txt_ID" & counter).Enabled = False

            End If
        Next
    End Sub

    Private Sub PrintNewBarcode(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal print_all As Boolean)

        Dim img As Image
        Dim g As Graphics
        Dim p As New Pen(Color.Black, 3)
        Dim br As New System.Drawing.SolidBrush(Color.Black)
        Dim Header_font As New Font("Arial", 18)
        Dim detail_y_diff As Int16
        Dim current_y As Int16
        Dim current_x As Int16
        Dim detail_font As Font
        Dim strFormat As New StringFormat
        strFormat.Alignment = StringAlignment.Far
        Dim Font1 As New Font("Arial", 8)
        Dim Font2 As New Font("Arial", 9)
        Dim Font3 As New Font("IDAutomationHC39M Free Version", 10)
        Dim Font4 As New Font("Arial", 14, FontStyle.Bold)
        Dim Report_Date As String
        Dim Report_Time As String
        Dim part_bc As String
        Dim seq_bc As String
        Dim serial_bc As String




        detail_font = Font4
        detail_y_diff = 24
        Try
            g = e.Graphics
            img = Image.FromFile("c:\Test\Doc1.jpg")
            g.DrawImage(img, 0, 0)
        Catch ex As Exception

            MsgBox("Error drawing backgroung image" + ControlChars.CrLf + ex.Message, MsgBoxStyle.Critical)



        End Try
        Try

            Report_Date = Format(Now(), "Long Date")
            Report_Time = Format(Now(), "HH:mm:ss")
            current_y = 20
            current_x = 20
            serial_bc = "*" & print_BC(0).Employee_ID & "*"

            g.DrawString(print_BC(0).Name, detail_font, br, current_x, current_y + 5)
            g.DrawString("Employee Number", detail_font, br, current_x, current_y + 45)
            g.DrawString(print_BC(0).Employee_Number, detail_font, br, current_x + 180, current_y + 45)
            g.DrawString("Badge ID", detail_font, br, current_x + 75, current_y + 80)
            g.DrawString(serial_bc, Font3, br, current_x + 50, current_y + 105)
            g.DrawString(Report_Date, Font2, br, 10, 185)
            g.DrawString(Report_Time, Font2, br, 195, 185)


        Catch ex As Exception

            MsgBox("Error printing data" + ControlChars.CrLf + ex.Message, MsgBoxStyle.Critical)


        End Try

    End Sub



    Public Sub report_new_bc(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles new_bc.PrintPage

        Call PrintNewBarcode(sender, e, False)

    End Sub

    Private Sub Btn_Print_Click(sender As Object, e As EventArgs) Handles Btn_Print.Click
        Print_BC_Request(sender, e)
    End Sub

    Private Sub Print_BC_Request(sender As Object, e As EventArgs)

        new_bc.PrinterSettings.PrinterName = label_printer

        Try
            new_bc.Print()
        Catch ex As Exception
            MsgBox("Error printing data" + ControlChars.CrLf + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class