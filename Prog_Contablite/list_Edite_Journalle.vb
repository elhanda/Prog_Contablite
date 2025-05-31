Imports System.Data
Imports System.Data.OleDb


Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class list_Edite_Journalle
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
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
    Private exer = exec_proc.n1
    Dim y As Integer






    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        'Edition_journal.Show()

    End Sub

    Private Sub list_Edite_Journalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Module1.connecter()

            Label11.Text = exer
            Label12.Text = Access.n2

            'ComboBox1.SelectedIndex +1, ComboBox2.SelectedIndex + 1

            ''-------------------------------------------------------------------------------------------
            Dim index As ListViewItem

            Dim debut As Long
            Dim credit As Long
            With ListView1
                '  index = .SelectedIndices(1)
                For Each index In .Items
                    debut = debut + CLng(index.SubItems(7).Text)
                    credit = credit + CLng(index.SubItems(8).Text)
                Next
            End With
            Label15.Text = CStr(credit)
            Label14.Text = CStr(debut)

        Catch ex As Exception
            MessageBox.Show("form load " + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Me.Close()
            'Edition_journal.Show()

        Catch ex As Exception
            MessageBox.Show("error de l'affichage " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub



    'Private Sub Apercu_Click(sender As Object, e As EventArgs) Handles Apercu.Click
    'Module1.connecter()
    'Dim etat As String
    'etat = "rapport_jrn" + Access.n2

    'Dim report As New Rapport2

    'Dim param_mois1 As Integer
    'Dim param_mois2 As Integer
    'Dim param_jrnl As Integer
    'Dim param_base As String

    'param_jrnl = Convert.ToInt32(Edition_journal.ComboBox1.Text)
    'param_mois1 = Convert.ToInt32(Edition_journal.ComboBox2.SelectedIndex + 1)
    'param_mois2 = Convert.ToInt32(Edition_journal.ComboBox3.SelectedIndex + 1)
    'param_base = "Base_compta_" + Convert.ToString(Access.n2)

    'report.SetParameterValue("Base_Compta", param_base)
    'report.SetParameterValue("j", param_jrnl)
    'report.SetParameterValue("mois1", param_mois1)
    'report.SetParameterValue("Mois2", param_mois2)
    'report.SetParameterValue("exercice", exec_proc.n1)

    'Me.CrystalReportViewer1.ReportSource = report

    Private Sub Apercu_Click(sender As Object, e As EventArgs) Handles Apercu.Click
        Try
            ' Se connecter à la base de données
            Module1.connecter()

            ' Déclarer et charger le rapport Crystal (.rpt)
            Dim report As New ReportDocument()
            ' Remplacer par le chemin d'accès à ton fichier Crystal Report
            Dim etat As String = "e:\prog_comptabiliteAct\prog_contablite\Rapport_jrnl001.rpt"

            ' Vérifier si le fichier existe
            If Not File.Exists(etat) Then
                MessageBox.Show("Le fichier du rapport n'existe pas : " & etat, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Charger le rapport
            report.Load(etat)

            ' Paramètres pour la requête SQL
            Dim param_jrnl As Integer = Convert.ToInt32(Edit_journaux.ComboBox1.Text)
            Dim param_mois1 As Integer = Convert.ToInt32(Edit_journaux.ComboBox2.SelectedIndex + 1)
            Dim param_mois2 As Integer = Convert.ToInt32(Edit_journaux.ComboBox3.SelectedIndex + 1)

            'Dim param_base As String = "Base_compta_" & Access.n2

            ' Passer les paramètres au rapport
            'report.SetParameterValue("Base_Compta", param_base)
            report.SetParameterValue("j", param_jrnl)
            report.SetParameterValue("mois1", param_mois1)
            report.SetParameterValue("Mois2", param_mois2)
            report.SetParameterValue("exercice", exec_proc.n1)

            ' Requête SQL à exécuter pour remplir le rapport
            Dim req As String = "SELECT ER_JOUR as 'Jr', ER_LIGNE as 'N°Lign', ER_FOLIO as 'N°Fol', ER_CPARTIE as 'N°Compte', " &
                            "ER_CPARTIE as 'Compte_Partie', ER_NPIECE as 'N°Piece', ER_LIBELLE as 'LIBELLE', " &
                            "IIF(ER_CODE = 'D', SUM(ER_MONT), ' ') as 'TYPE_DEBUT', IIF(ER_CODE = 'C', SUM(ER_MONT), ' ') as 'TYPE_CREDI' " &
                            "FROM FEcriture " &
                            "WHERE ER_EXERC = @exercice " &
                            "AND ER_MOIS BETWEEN @mois1 AND @mois2 " &
                            "AND ER_JOURNL = @journal " &
                            "GROUP BY ER_CODE, ER_JOUR, ER_LIGNE, ER_FOLIO, ER_CPARTIE, ER_NPIECE, ER_LIBELLE"

            ' Exécuter la requête SQL
            cmd = New SqlCommand(req, con)
            cmd.Parameters.AddWithValue("@exercice", exec_proc.n1)
            cmd.Parameters.AddWithValue("@mois1", param_mois1)
            cmd.Parameters.AddWithValue("@mois2", param_mois2)
            cmd.Parameters.AddWithValue("@journal", param_jrnl)

            ' Charger les données dans un DataSet
            Dim adapt As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            adapt.Fill(ds, "FEcriture")

            ' Passer le DataSet au rapport (si besoin, pour lier les données)
            report.SetDataSource(ds)

            ' Afficher le rapport dans le CrystalReportViewer
            ' Assurez-vous que CrystalReportViewer1 est ajouté dans le formulaire pour l'affichage du rapport
            'CrystalReportViewer1.ReportSource = report
            'CrystalReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'affichage du rapport : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




End Class