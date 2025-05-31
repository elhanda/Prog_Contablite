Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Annul_Exercice
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand

    Dim an As String
    Dim ds As DataSet = New DataSet()
    Dim dt As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As String








    'Public Sub Module1.Module1.connecter_soc()()()

    '    Dim chaineDeConnexion As String
    '    'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_Soc;Integrated Security=True"
    '    ' = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=localhost\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_001.mdf;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABILITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub
    'Sub Module1.connecter()
    '    Dim chaineDeConnexion As String
    '    'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_Soc;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABILITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_SOC.MDF;Integrated Security=True"

    '    'chaineDeConnexion = "Data Source=localhost\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_001.mdf;Integrated Security=True"

    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub

    Sub ver(a, code)
        '    Try
        '        Dim dialog As DialogResult
        '        dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        '        If dialog = DialogResult.Yes Then
        '            Dim searchQuery As String = "
        'delete from Periode_Soc where Exercice = '" & a & "'
        'use Base_Compta_" & code & "
        'delete from FEcriture where ER_EXERC = '" & a & "' "
        '            Dim command As New SqlCommand(searchQuery, con)
        '            Dim adapter As New SqlDataAdapter(command)
        '            Dim table As New DataTable()
        '            adapter.Fill(table)
        '            MessageBox.Show("delete avec sucsses", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show("error de la delete" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try

        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            'If dialog = DialogResult.Yes Then
            '    Dim searchQuery As String = "  EXEC DELETE_DB '" & code & "'"
            '    Dim command As New SqlCommand(searchQuery, con)
            '    Dim adapter As New SqlDataAdapter(command)
            '    Dim table As New DataTable()
            '    adapter.Fill(table)
            '    MessageBox.Show("DATABASE DELETED avec sucsses", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            MessageBox.Show("error de la delete DE DATABASE " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
    Private Sub Annul_Exercice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter_soc()

    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'ver(ComboBox1.SelectedValue, ComboBox2.SelectedValue)
        'ver(ComboBox2.Text)
    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs)

        cmd = New SqlCommand("
        select *  from Fsociete where S_code = '" & ComboBox2.SelectedValue & "' ", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "FJol")
        For Each dr As DataRow In ds.Tables("FJol").Rows
            TextBox2.Text = dr("S_Nom").ToString()
        Next
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form_Soc.Show()
    End Sub




    Private Sub Annul_Soc_Enter(sender As Object, e As EventArgs) Handles Annul_Soc.Enter
        Module1.connecter_soc()



        Try
            Dim cmd As SqlCommand = New SqlCommand("select * from Fsociete ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(dt, "Fsociete")

            ComboBox2.DisplayMember = "S_code"
            ComboBox2.ValueMember = "S_Nom"
            ComboBox2.DataSource = dt.Tables("Fsociete")

            'combobox1 Fsociete 
        Catch ex As Exception
            MessageBox.Show("load error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

        '    Connecter(ComboBox2.SelectedValue)

        'Try
        '    cmd = New SqlCommand("select * from Periode_Soc ", con)
        '    adapt = New SqlDataAdapter(cmd)
        '    adapt.Fill(ds, "Periode_Soc")

        '    ComboBox1.DisplayMember = "Exercice"
        '    ComboBox1.ValueMember = "Exercice"
        '    ComboBox1.DataSource = ds.Tables("Periode_Soc")

        'Catch ex As Exception
        '    MessageBox.Show("load error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        'End Try










    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox2.Text = ComboBox2.SelectedItem(0)
    End Sub
End Class