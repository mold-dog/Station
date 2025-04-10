Imports System.Data.SqlClient
Public Class Schedule_Shipping
    Dim Adding As Boolean = False
    Dim Editing As Boolean = False
    Dim ID_Array() As Int32


    Private Sub loading() Handles MyBase.Load
        For Each ctrl As Control In Me.Controls
            If ctrl.GetType = GetType(DateTimePicker) Then
                ctrl = toolboxMM.General.Change_DTPicker(ctrl)
            End If
        Next
    End Sub



End Class