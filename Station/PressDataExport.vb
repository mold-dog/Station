Public Class PressDataExport


    Private Sub exportClicked(sender As Object, e As EventArgs) Handles btn_export.Click

        selected_date = MonthCalendar1.SelectionRange.Start.Date

        SupPressRep.Export_Data(selected_date, selected_shift)
        Close()
        ''MsgBox("Date:" & selected_date.ToString("d") & vbCrLf & "Shift: " & selected_shift.ToString)


    End Sub






    Private selected_date As Date

    Public Property SelectedDate() As Date
        Get
            Return selected_date
        End Get
        Set(value As Date)
            selected_date = value
        End Set
    End Property

    Private selected_shift As Integer = 1

    Public Property SelectedShift() As Integer
        Get
            Return selected_shift
        End Get
        Set(value As Integer)
            selected_shift = value
        End Set
    End Property

    Private Sub RadioClicked()

        If radio_btn_A.Checked Then
            radio_btn_B.Checked = False
            radio_btn_C.Checked = False
            radio_btn_D.Checked = False
            selected_shift = 1

        ElseIf radio_btn_B.Checked Then
            radio_btn_A.Checked = False
            radio_btn_C.Checked = False
            radio_btn_D.Checked = False
            selected_shift = 2

        ElseIf radio_btn_C.Checked Then
            radio_btn_A.Checked = False
            radio_btn_B.Checked = False
            radio_btn_D.Checked = False
            selected_shift = 3

        ElseIf radio_btn_D.Checked Then
            radio_btn_A.Checked = False
            radio_btn_B.Checked = False
            radio_btn_C.Checked = False
            selected_shift = 4

        End If

    End Sub
    Private Sub PressDataExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AddHandler radio_btn_A.Click, AddressOf RadioClicked
        AddHandler radio_btn_B.Click, AddressOf RadioClicked
        AddHandler radio_btn_C.Click, AddressOf RadioClicked
        AddHandler radio_btn_D.Click, AddressOf RadioClicked

    End Sub
End Class