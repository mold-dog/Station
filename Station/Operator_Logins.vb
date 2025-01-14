Imports System.Data
Imports System.Data.SqlClient
Public Class Operator_Logins
    Dim ID_Array() As Int32


    Dim Query As String
    Private bindingsource1 As New BindingSource

    Private Sub Operator_Logins_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Refresh_Grid()

    End Sub


    Private Sub Refresh_Grid()
        DGV_Paint_Data.AutoGenerateColumns = True
        Me.Cursor = Cursors.WaitCursor

        Query = "Select Operator.Name, Station.description as [Description] from Operator inner join station on station.[user_id] = Operator.id " &
        "Union " &
        "Select Operator.Name, press.description from press inner join operator on user_Id1 = Operator.id or user_Id2 = Operator.id or user_Id3 = Operator.id or user_Id4 = Operator.id or user_Id5 = Operator.id " &
        "Order by Name"

        bindingsource1.DataSource = GetData(Query)

        DGV_Paint_Data.DataSource = bindingsource1
        DGV_Paint_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV_Paint_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub Btn_Update_Click(sender As Object, e As EventArgs) Handles Btn_Update.Click
        Call Refresh_Grid()

    End Sub
End Class