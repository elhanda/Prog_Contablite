Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class Form3
    ' Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As String
    'Public Sub Connecter_soc()

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
    'Sub Module1.Module1.Module1.Module1.connecter()
    '    Dim chaineDeConnexion As String
    '    'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_Soc;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABILITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"

    '    'chaineDeConnexion = "Data Source=localhost\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_001.mdf;Integrated Security=True"
    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try
    'End Sub
    Sub ver(code)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If dialog = DialogResult.Yes Then
                Dim searchQuery As String = "  EXEC DELETE_DB '" & code & "'"
                Dim command As New SqlCommand(searchQuery, con)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                MessageBox.Show("DATABASE DELETED avec sucsses", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("error de la delete DE DATABASE " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter_soc()
        Try
            cmd = New SqlCommand("Select s_code,s_nom  from fsociete ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "fsociete")
            ComboBox2.DisplayMember = "s_code"
            ComboBox2.ValueMember = "scode "
            ComboBox2.DataSource = ds.Tables("fsociete")
        Catch ex As Exception
            MessageBox.Show("load error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

        ComboBox2.Text = ComboBox2.SelectedItem(0)
        TextBox2.Text = ComboBox2.SelectedItem(1)

    End Sub



    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'TextBox2.Text = ComboBox2.SelectedValue
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ver(ComboBox2.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form_Soc.Show()
    End Sub





    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub
End Class