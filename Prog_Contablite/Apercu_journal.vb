
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Apercu_Journal

    '   Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter


    'Public Sub Module1.Module1.connecter()
    '    Dim chaineDeConnexion As String
    '    'chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_001.mdf;Integrated Security=True;Connect Timeout=30"
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_Soc.mdf;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=desktop-c826ha4 \ localdb#cd9038a6.D: \PROG_CONTABILITE\PROG_CONTABLITE\DATA\BASE_COMPTA_001.MDF;Integrated Security=True"
    '    'chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_001.mdf;Integrated Security=True;Connect Timeout=30"

    '    chaineDeConnexion = "Data Source=localhost\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_001.mdf;Integrated Security=True"


    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '    Catch ex As Exception
    '        Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Console.WriteLine(ex.Message)
    '    End Try
    'End Sub
    'Public Sub Connecter_soc()
    '    'Dim chaineDeConnexion As String
    '    ''chaineDeConnexion = "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=E:\PROG_CONTABLITE\PROG_CONTABLITE\BIN\DEBUG\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    ''chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\BIN\DEBUG\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    ''chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    ''chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_001.mdf;Integrated Security=True;Connect Timeout=30"
    '    'chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_Soc.mdf;Integrated Security=True;Connect Timeout=30"
    '    ''chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_Soc.mdf;Integrated Security=True"

    '    ''chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_001.mdf;Integrated Security=True;Connect Timeout=30"

    '    'con = New SqlConnection(chaineDeConnexion)
    '    'Try
    '    '    con.Open()
    '    'Catch ex As Exception
    '    '    Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    '    Console.WriteLine(ex.Message)
    '    'End Try
    'End Sub
    Private Sub CrystalReportViewer1_Load_1(sender As Object, e As EventArgs)
        ''Dim designation As String


        'Try
        '    'Connecter_soc()

        '    'Dim req As String
        '    Dim report As New EditionjournalCR_select5

        '    'req = String.Format(" Select S_pat, S_Nom, S_adr1,s_ville,s_tel,s_tva,s_email  from Fsociete where S_code = '" & Access.n2 & "'")
        '    'cmd = New SqlCommand(req, con)
        '    'Dim adaptr2 As SqlDataAdapter
        '    'adaptr2 = New SqlDataAdapter(cmd)
        '    'Dim dt = New DataTable()
        '    'adaptr2.Fill(dt)
        '    ''MessageBox.Show("nb lig :" + dt.Rows.Count)
        '    'designation = Convert.ToString(dt.Rows(0)(1))

        '    'report.SetParameterValue("Designation", Convert.ToString(dt.Rows(0)(1)))
        '    Module1.Module1.connecter()
        '    Dim param_mois1 As String
        '    Dim param_mois2 As String
        '    Dim param_jrnl As Integer
        '    param_jrnl = Convert.ToString(Edition_journal.ComboBox1.Text)
        '    param_mois1 = Convert.ToString(Edition_journal.ComboBox2.SelectedIndex + 1)
        '    param_mois2 = Convert.ToString(Edition_journal.ComboBox3.SelectedIndex + 1)
        '    Dim req1 As String = "

        '    select  distinct ER_JOUR as 'Jr',ER_LIGNE as 'N°Lign',ER_FOLIO as 'N°Fol' ,ER_CPARTIE as 'N°Compte',ER_CPARTIE as 'Compte_Partie',ER_NPIECE as 'N°Piece ',
        '                     ER_LIBELLE as 'LIBELLE', IIF ( ER_CODE = 'D' , sum(ER_MONT), '                  ') as 'TYPE_DEBUT',
        '                     IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI' 
        '                     from FEcriture  where 
        '                     ER_EXERC = " & Access.n2 & " and ER_MOIS between " & param_mois1 & " and " & param_mois2 & " and ER_JOURNL = " & param_jrnl & " 
        '                     group by ER_CODE,ER_JOUR,ER_LIGNE,ER_FOLIO,ER_CPARTIE,ER_CPARTIE,ER_NPIECE, ER_LIBELLE "

        '    cmd = New SqlCommand(req1, con)
        '    Dim adapttr As SqlDataAdapter
        '    adapttr = New SqlDataAdapter(cmd)
        '    Dim dt1 = New DataTable()
        '    adapttr.Fill(dt1)


        '    'MsgBox(param_jrnl)
        '    'MsgBox(param_mois1)
        '    'MsgBox(param_mois2)

        '    report.SetParameterValue("mois1", param_mois1)
        '    report.SetParameterValue("Mois2", param_mois2)
        '    report.SetParameterValue("exercice", exec_proc.n1)
        '    report.SetParameterValue("codjrnl", param_jrnl)

        '    Me.CrystalReportViewer1.ReportSource = report


        'Catch ex As Exception
        '    MsgBox("error 1 " + ex.Message)
        'End Try

    End Sub


End Class