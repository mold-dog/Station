Imports System.Collections.Generic

Public Class UserInput

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click

        If ComboBox1.Text = "" And ComboBox1.Visible Then
            MsgBox("Please select a failure mode before submitting.", MsgBoxStyle.MsgBoxHelp)
        ElseIf TextBox1.Text = "" And TextBox1.Visible Then
            MsgBox("Please enter a rationale before submitting.", MsgBoxStyle.MsgBoxHelp)

        Else


            If stored_procedure <> "" Then

                Dim query As String = stored_procedure

                If dropdown_table <> "" Then
                    query += " '" & ComboBox1.Text & "', "
                End If

                query += " '" & TextBox1.Text & "'"


                ' Dim throwaway As New DataSet
                toolboxMM.SQLTools.queryDatabase(query, "nothing")
            Else
                SupPressRep.SupervisorName = ComboBox1.Text
            End If

            SupPressRep.buttonRefresh.PerformClick()
            SupPressRep.buttonOverview.Select()
            Close()
        End If


    End Sub

    Private dropdown_list As New List(Of String)
    Public Property DropdownList As List(Of String)
        Get
            Return dropdown_list
        End Get
        Set(value As List(Of String))
            dropdown_list = value
        End Set
    End Property

    Private dropdown_table As String = ""
    Public Property DropdownTable As String
        Get
            Return dropdown_table
        End Get
        Set(value As String)
            dropdown_table = value
        End Set
    End Property


    Private stored_procedure As String = ""
    Public Property StoredProcedure As String
        Get
            Return stored_procedure
        End Get
        Set(value As String)
            stored_procedure = value
        End Set
    End Property


    Private dropdown_label As String = ""
    Public Property DropdownLabel As String
        Get
            Return dropdown_label
        End Get
        Set(value As String)
            dropdown_label = value
        End Set
    End Property

    Private textbox_label As String = ""
    Public Property TextboxLabel As String
        Get
            Return textbox_label
        End Get
        Set(value As String)
            textbox_label = value
        End Set
    End Property

    Private Sub UserInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_DropDown.Text = dropdown_label
        lbl_TextBox.Text = textbox_label

        If dropdown_table = "" Then

            If dropdown_list Is Nothing Then
                lbl_DropDown.Visible = False
                ComboBox1.Visible = False
                TextBox1.Select()
            Else
                If textbox_label = "" Then
                    lbl_TextBox.Visible = False
                    TextBox1.Visible = False
                End If
                For Each tempStr As String In dropdown_list
                    ComboBox1.Items.Add(tempStr)
                Next
                ComboBox1.Select()
            End If


        Else


            Dim query As String = "Select Failure_Mode From " & dropdown_table
            Dim daTable As DataSet = toolboxMM.SQLTools.queryDatabase(query, "Data")

            For Each daRow As DataRow In daTable.Tables("Data").Rows
                ComboBox1.Items.Add(daRow("Failure_Mode"))
            Next

            ComboBox1.Select()
        End If



    End Sub


End Class