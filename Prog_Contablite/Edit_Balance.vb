Imports System.Data
Imports System.Data.OleDb


Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class Edit_Balance
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim cmd1 As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim ds1 As DataSet = New DataSet()
    Dim ds2 As DataSet = New DataSet()
    Dim ds3 As DataSet = New DataSet()
    Dim ds4 As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Dim value As Integer
    Private sum As Integer
    Private cred As Integer
    Private Id_Niv1 As New List(Of String)
    Private Id_Niveau As String
    Private Id_Niv12 As New List(Of String)
    Private Id_Niveau2 As String
    Private choix As Integer
    Private choix2 As Integer
    Private exer = exec_proc.n1
    Private chk1 As Integer
    Private chk2 As Integer
    Private chk3 As Integer
    Private chk4 As Integer
    Private chk5 As Integer
    Private chk6 As Integer
    Public nbcol As Integer = 0

    'Sub Module1.connecter()
    '    Dim chaineDeConnexion As String

    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_" + Access.n2 + ";Integrated Security=True"


    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '        MsgBox("bien passé")
    '    Catch ex As Exception
    '        Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Console.WriteLine(ex.Message)
    '    End Try


    'End Sub


    'Public conn As SqlConnection

    'Public Sub Module1.connecter()
    '    Try
    '        ' 🔧 Ta chaîne de connexion — AJUSTE ICI si nécessaire
    '        Dim serveur As String = ".\SQLEXPRESS" ' ou "localhost" ou "DESKTOP-XXX\SQLInstance"
    '        Dim baseDeDonnees As String = "base_compta_001" ' ← ta base ici
    '        Dim authentificationWindows As Boolean = True

    '        Dim chaine As String

    '        If authentificationWindows Then
    '            chaine = $"Data Source={serveur};Initial Catalog={baseDeDonnees};Integrated Security=True;"
    '        Else
    '            Dim utilisateur As String = "ton_user"
    '            Dim motDePasse As String = "ton_mot_de_passe"
    '            chaine = $"Data Source={serveur};Initial Catalog={baseDeDonnees};User ID={utilisateur};Password={motDePasse};"
    '        End If

    '        ' 🔍 Affiche la chaîne (juste pour debug, à désactiver plus tard)
    '        ' MessageBox.Show("Chaîne de connexion utilisée : " & chaine)

    '        con = New SqlConnection(chaine)

    '        If con.State = ConnectionState.Closed Then
    '            con.Open()
    '            MessageBox.Show("✅ Connexion réussie à la base : " & con.Database, "Connecter", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        End If

    '    Catch ex As SqlException
    '        MessageBox.Show("❌ SQL Exception : " & ex.Message, "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    Catch ex As Exception
    '        MessageBox.Show("❌ Erreur générale : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Private Sub Edit_Balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter()
        Label7.Text = exec_proc.n1
        Label9.Text = Access.n2
        Try
            ''C_Partie ne doit pas saisie tout seul 

            cmd = New SqlCommand("select distinct ER_CPARTIE from [Fecriture] where len(er_cpartie) >0 group by ER_CPARTIE order by ER_CPARTIE ", con)
        adapt1 = New SqlDataAdapter(cmd)
        adapt1.Fill(ds, "Fecriture")
        ComboBox1.DisplayMember = "ER_CPARTIE"
        ComboBox1.ValueMember = "ER_LIBELLE"
        ComboBox1.DataSource = ds.Tables("Fecriture")
        ComboBox1.GetItemText(0)


        ''combobox1 Code Compte :
        cmd = New SqlCommand("select distinct ER_Cpartie from [Fecriture] where len(er_cpartie) >0 group by ER_CPARTIE order by ER_CPARTIE   desc ", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(ds1, "Fecriture")
        ComboBox2.DisplayMember = "ER_CPARTIE"
        ComboBox2.ValueMember = "ER_LIBELLE"
        ComboBox2.DataSource = ds1.Tables("Fecriture")
        ComboBox2.GetItemText(0)

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        RadioButton6.Checked = True
        chk1 = 0
        chk2 = 0
        chk3 = 0
        chk4 = 0
        chk5 = 0
        chk6 = 8

            'MsgBox("tres bien passé")
        Catch ex As Exception
            Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()
    End Sub



    Private Sub Afficher_Click(sender As Object, e As EventArgs) Handles Afficher.Click

        Module1.connecter()
        ' ✅ Charger le rapport Crystal Reports

        Dim reportPath As String
        Dim compte1 As String
        Dim compte2 As String
        compte1 = ComboBox1.Text
        compte2 = ComboBox2.Text
        choix = chk1 + chk2 + chk3 + chk4 + chk5 + chk6
        Dim searchQueryy As String = "exec [Balance] " & (exec_proc.n1) & ", '" & compte1 & "' ,'" & compte2 & "'," & choix & ""

        Try
            Module1.connecter()
            ' Ouvrir la connexion
            Dim commandd As New SqlCommand(searchQueryy, con)

            Dim adapter As New SqlDataAdapter(commandd)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
            ' ✅ Vérifier si les colonnes existent avant de renommer

            If DataGridView1.Columns.Contains("ER_CPARTIE") Then DataGridView1.Columns("ER_CPARTIE").HeaderText = "ER_CPARTIE"
            If DataGridView1.Columns.Contains("c_LIBELLE") Then DataGridView1.Columns("c_LIBELLE").HeaderText = "c_Libelle"
            If DataGridView1.Columns.Contains("DEBIT") Then DataGridView1.Columns("DEBIT").HeaderText = "Debit"
            If DataGridView1.Columns.Contains("CREDIT") Then DataGridView1.Columns("CREDIT").HeaderText = "Credit"
            If DataGridView1.Columns.Contains("DEBIT-CREDIT") Then DataGridView1.Columns("DEBIT-CREDIT").HeaderText = "SOLDE"

            Dim result = CalculerTotaux(DataGridView1, 2, 3)
            Dim totalCol4 As Decimal = result.Item1
            Dim totalCol5 As Decimal = result.Item2
            Label12.Text = totalCol4
            Label5.Text = totalCol5
            Label3.Text = (totalCol4 - totalCol4) '.ToString("N2")
            'MessageBox.Show($"Total Colonne 4: {totalCol4}" & vbCrLf & $"Total Colonne 5: {totalCol5}")
            Label9.Refresh()
            Label5.Refresh()
            Label3.Refresh()
        Catch ex As Exception

            MessageBox.Show("Erreur lors de la connexion à la base de données : " & ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion si ouverte
            If con.State = ConnectionState.Open Then con.Close()
        End Try

    End Sub

    Private Sub Appercu_Click(sender As Object, e As EventArgs) Handles Appercu.Click
        Module1.connecter()
        ' ✅ Charger le rapport Crystal Reports
        Dim reportPath As String
        choix = chk1 + chk2 + chk3 + chk4 + chk5 + chk6
        'reportPath = "e:\gestion commerciale\Prog_Contablite\Balance_Report_Final.rpt"
        'reportPath = "e:\CrystalReport17.rpt"
        reportPath = Access.PathCryst + "Edit_balance_001.rpt"
        '
        'MsgBox(reportPath)
        Module1.connecter()
        ' ✅ Charger le rapport Crystal Reports
        Dim compte1 As String
        Dim compte2 As String
        Dim nsoc As String
        compte1 = ComboBox1.Text
        compte2 = ComboBox2.Text
        nom_soc = Access.nom_soc



        Dim searchQuery As String = "exec [Balance] " & (exec_proc.n1) & ", '" & compte1 & "' ,'" & compte2 & "'," & choix & ""

        Dim command As New SqlCommand(searchQuery, con)

        Dim adapter As New SqlDataAdapter(command)
        Dim table1 As New DataTable()
        adapter.Fill(table1)
        DataGridView1.DataSource = table1

        Dim report As New ReportDocument()
        report.Load(reportPath)
        ' ✅ Associer la source de données au rapport
        report.SetDataSource(table1)
        report.SetParameterValue("Exec", exec_proc.n1)
        report.SetParameterValue("CompteDebut", compte1)
        report.SetParameterValue("CompteFin", compte2)

        report.SetParameterValue("chk", 8)
        report.SetParameterValue("Exercice", exec_proc.n1)
        report.SetParameterValue("compte11", compte1)
        report.SetParameterValue("Compte12", compte2)
        report.SetParameterValue("Nom_Soc", Access.nom_Soc)






        ' ✅ Afficher dans un CrystalReportViewer
        Dim reportForm As New Form()
        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        crystalReportViewer.Dock = DockStyle.Fill
        crystalReportViewer.ReportSource = report
        reportForm.Controls.Add(crystalReportViewer)
        reportForm.WindowState = FormWindowState.Maximized
        reportForm.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If chk1 = 0 Then chk1 = 1 Else chk1 = 0
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If chk2 = 0 Then chk2 = 2 Else chk2 = 0
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If chk3 = 0 Then chk3 = 3 Else chk3 = 0
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If chk4 = 0 Then chk4 = 4 Else chk4 = 0
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If chk5 = 0 Then chk5 = 5 Else chk5 = 0
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        If chk6 = 0 Then chk6 = 8 Else chk6 = 0
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class




