Imports System.Data
Imports System.Data.SqlClient
Public Class Press_Alarms
    Dim Query As String
    Private bindingsource1 As New BindingSource


    Private Sub Refresh_Grid()
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Query = "Exec Get_Press_Alarms 0"

        bindingsource1.DataSource = GetData(Query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Press_Alarms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Refresh_Grid()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Call Refresh_Grid()

    End Sub


    Private Sub DGV_Paint_Data_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DGV_Paint_Data.RowPostPaint
        If e.RowIndex < Me.DGV_Paint_Data.RowCount Then
            Dim dgvRow As DataGridViewRow = Me.DGV_Paint_Data.Rows(e.RowIndex)

            Select Case dgvRow.Cells(2).Value.ToString
                Case = "Warning"
                    dgvRow.DefaultCellStyle.BackColor = Color.Orange
                Case = "Fault"
                    dgvRow.DefaultCellStyle.BackColor = Color.Red
                Case Else
                    dgvRow.DefaultCellStyle.BackColor = Color.White
            End Select

        End If


    End Sub
End Class