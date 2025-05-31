
Imports System.Data
Imports System.Data.OleDb


Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient





Public Class Edit_journal
    'Dim con As SqlConnection
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
    Sub Connecter()
        Dim chaineDeConnexion As String

        chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_" + Access.n2 + ";Integrated Security=True"


        con = New SqlConnection(chaineDeConnexion)
        Try
            con.Open()
            ' MsgBox("bien passé")
        Catch ex As Exception
            Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.Message)
        End Try


    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        cmd = New SqlCommand("select J_LIBELLE from FJournal where J_CODE =" & ComboBox1.Text & "", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "FJol")
        For Each dr As DataRow In ds.Tables("FJol").Rows
            Label3.Text = dr("J_LIBELLE").ToString()
        Next
        ComboBox1.Text = ComboBox1.SelectedItem(0)
    End Sub
    Sub affich(Mois1, Mois2, Journal)
        Try


            Dim req As String = "
            select  distinct ER_JOUR as 'Jr',ER_LIGNE as 'N°Lign',ER_mois as 'Mois' ,ER_CPARTIE as 'N°Compte','ER_libelle' as 'LIBELLE',ER_NPIECE as 'N°Piece ', IIF ( ER_CODE = 'D' , sum(ER_MONT), '                  ')as 'TYPE_DEBUT'
            ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI' from FEcriture 

            where 
            ER_EXERC = " & exer & " 

            and ER_MOIS between " & Mois1 & " and " & Mois2 & " 
            and ER_JOURNL = " & Journal & " 



               group by ER_CODE,ER_JOUR,ER_LIGNE,ER_FOLIO,ER_CPARTIE,ER_LIBELLE,ER_NPIECE "

            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)




            DataGridView1.DataSource = dt

            If DataGridView1 IsNot Nothing Then
                If DataGridView1.Columns.Contains("er_ligne") Then
                    DataGridView1.Columns("er_ligne").HeaderText = "Ligne"
                End If
                If DataGridView1.Columns.Contains("er_jour") Then
                    DataGridView1.Columns("er_jour").HeaderText = "Jour"
                End If
                If DataGridView1.Columns.Contains("er_cpartie") Then
                    DataGridView1.Columns("er_cpartie").HeaderText = "Compte"
                End If

                If DataGridView1.Columns.Contains("er_npiece") Then
                    DataGridView1.Columns("er_npiece").HeaderText = "N.Piece"
                End If
                If DataGridView1.Columns.Contains("er_libelle") Then
                    DataGridView1.Columns("er_libelle").HeaderText = "Libelle"
                End If
                If DataGridView1.Columns.Contains("debit") Then
                    DataGridView1.Columns("debit").HeaderText = "Debit"
                End If
                If DataGridView1.Columns.Contains("credit") Then
                    DataGridView1.Columns("credit").HeaderText = "Credit"
                End If
            Else
                MessageBox.Show("DataGridView1 is not initialized.")
            End If


            'Définir la largeur de la première colonne à 150 pixels
            'DataGridView1.Columns(0).Width = 50
            'DataGridView1.Columns(1).Width = 50
            'DataGridView1.Columns(2).Width = 100
            'DataGridView1.Columns(3).Width = 100
            'DataGridView1.Columns(4).Width = 400
            'DataGridView1.Columns(5).Width = 150



            For Each col As DataGridViewColumn In DataGridView1.Columns
                ' Définir la taille de la police pour chaque cellule dans chaque colonne
                col.DefaultCellStyle.Font = New Font("Arial", 12) ' Changer la police à Arial avec une taille de 10 points
            Next


            DataGridView1.Columns("er_ligne").HeaderText = "Ligne"
            DataGridView1.Columns("er_jour").HeaderText = "Jour"
            DataGridView1.Columns("er_cpartie").HeaderText = "Compte"
            DataGridView1.Columns("er_npiece").HeaderText = "N.Piece"
            DataGridView1.Columns("er_libelle").HeaderText = "Libelle"
            DataGridView1.Columns("debit").HeaderText = "Debit"
            DataGridView1.Columns("credit").HeaderText = "Credit"

            DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)



        Catch ex As Exception
            'MessageBox.Show("filter" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try




    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()

    End Sub

    '    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim mois1 As String
    '    Dim mois2 As String

    '    mois1 = ComboBox2.SelectedIndex + 1
    '    mois2 = ComboBox3.SelectedIndex + 1



    '    Dim searchQuery As String = "exec [Journaux_choix] " & ComboBox1.Text & " , " & mois1 & " ," & mois2 & " , " & exec_proc.n1 & "  "
    '    Try
    '        ' Ouvrir la connexion
    '        Connecter()
    '        Dim command As New SqlCommand(searchQuery, con)

    '        Dim adapter As New SqlDataAdapter(command)
    '        Dim table As New DataTable()
    '        adapter.Fill(table)

    '        DataGridView1.DataSource = table

    '        ' ✅ Vérifier si les colonnes existent avant de renommer
    '        If DataGridView1.Columns.Contains("ER_ligne") Then DataGridView1.Columns("ER_ligne").HeaderText = "er_ligne"
    '        If DataGridView1.Columns.Contains("ER_JOUR") Then DataGridView1.Columns("ER_JOUR").HeaderText = "Jour"
    '        If DataGridView1.Columns.Contains("ER_CPARTIE") Then DataGridView1.Columns("ER_CPARTIE").HeaderText = "Compte"
    '        If DataGridView1.Columns.Contains("ER_npiece") Then DataGridView1.Columns("ER_npiece").HeaderText = "N.Piece"
    '        If DataGridView1.Columns.Contains("ER_LIBELLE") Then DataGridView1.Columns("ER_LIBELLE").HeaderText = "Libelle"
    '        If DataGridView1.Columns.Contains("DEBIT") Then DataGridView1.Columns("DEBIT").HeaderText = "Debit"
    '        If DataGridView1.Columns.Contains("CREDIT") Then DataGridView1.Columns("CREDIT").HeaderText = "Credit"

    '        ' ✅ Charger le rapport Crystal Reports
    '        Dim reportPath As String = "e:\Prog_ComptabiliteAct\Prog_Contablite\rapport_jrnl" + Access.n2 + ".rpt"
    '        'Dim reportPath As String = "e:\Prog_ComptabiliteAct\Prog_Contablite\rapport" + Access.n2 + ".rpt"

    '        Dim report As New ReportDocument()
    '        report.Load(reportPath)

    '        ' ✅ Associer la source de données au rapport
    '        report.SetDataSource(table)


    '        report.SetParameterValue("code_journal", ComboBox1.Text)
    '        report.SetParameterValue("mois1", ComboBox2.SelectedIndex + 1)
    '        report.SetParameterValue("mois2", (ComboBox3.SelectedIndex + 1))
    '        report.SetParameterValue("exercice", exec_proc.n1)
    '        report.SetParameterValue("nom_soc", Access.nom_soc)


    '        ' ✅ Afficher dans un CrystalReportViewer
    '        Dim reportForm As New Form()
    '        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()

    '        crystalReportViewer.Dock = DockStyle.Fill
    '        crystalReportViewer.ReportSource = report
    '        reportForm.Controls.Add(crystalReportViewer)
    '        reportForm.WindowState = FormWindowState.Maximized
    '        reportForm.Show()

    '    Catch ex As Exception
    '        MessageBox.Show("Erreur lors de la connexion à la base de données : " & ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        ' Fermer la connexion si ouverte
    '        If con.State = ConnectionState.Open Then con.Close()
    '    End Try
    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button3.Click

    'End Sub



    Private Sub Edit_Journaux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connecter()
            Try


                'combobox1 Code Journal :
                cmd = New SqlCommand("select * from FJournal", con)
                adapt = New SqlDataAdapter(cmd)
                adapt.Fill(ds, "FJournal")
                ComboBox1.DisplayMember = "J_CODE"
                ComboBox1.ValueMember = "J_LIBELLE "
                ComboBox1.DataSource = ds.Tables("FJournal")

                'Remettre ComboBox1 au premier élément
                If ComboBox1.Items.Count > 0 Then
                    ComboBox1.SelectedIndex = 0
                End If

            Catch ex As Exception
                MessageBox.Show("load error 1" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("form load 1" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Sauvegarde du DataTable et schéma dans deux fichiers

        Try
            ' 🔄 Réinitialise la grille à chaque appel
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            ' Connexion SQL
            Connecter()
            Dim query As String = "EXEC list_journal @Exec, @CodeJournal, @mois1, @mois2"

            ' Commande avec paramètres
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("Exec", exec_proc.n1)
                cmd.Parameters.AddWithValue("CodeJournal", ComboBox1.Text)
                cmd.Parameters.AddWithValue("mois1", ComboBox2.Text)
                cmd.Parameters.AddWithValue("mois2", ComboBox3.Text)

                ' Adapter pour remplir le DataTable
                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    ' Bind des données
                    DataGridView1.DataSource = table
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                    ' ✅ Headers et mise à jour dynamique des colonnes
                    For Each column As DataColumn In table.Columns
                        Select Case column.ColumnName
                            Case "er_jour"
                                DataGridView1.Columns("er_jour").HeaderText = "Jour"
                                DataGridView1.Columns("er_jour").Width = 60
                            Case "er_folio"
                                DataGridView1.Columns("er_folio").HeaderText = "Folio"
                                DataGridView1.Columns("er_folio").Width = 60
                            Case "ER_LIBELLE"
                                DataGridView1.Columns("ER_LIBELLE").HeaderText = "Libellé"
                                DataGridView1.Columns("ER_LIBELLE").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                                DataGridView1.Columns("ER_LIBELLE").Width = 300
                            Case "Debit_Cpartie"
                                DataGridView1.Columns("Debit_Cpartie").HeaderText = "Compte Débit"
                                DataGridView1.Columns("Debit_Cpartie").Width = 120
                            Case "Credit_Cpartie"
                                DataGridView1.Columns("Credit_Cpartie").HeaderText = "Compte Crédit"
                                DataGridView1.Columns("Credit_Cpartie").Width = 120
                        End Select
                    Next

                    ' ✅ Format numérique : 2 chiffres après la virgule
                    If DataGridView1.Columns.Contains("Montant_Debit") Then
                        DataGridView1.Columns("Montant_Debit").DefaultCellStyle.Format = "N2"
                    End If
                    If DataGridView1.Columns.Contains("Montant_Credit") Then
                        DataGridView1.Columns("Montant_Credit").DefaultCellStyle.Format = "N2"
                    End If

                    ' Calcul des totaux
                    Dim totalDebit As Decimal = 0
                    Dim totalCredit As Decimal = 0
                    For Each row As DataRow In table.Rows
                        If Not IsDBNull(row("Montant_Debit")) Then totalDebit += Convert.ToDecimal(row("Montant_Debit"))
                        If Not IsDBNull(row("Montant_Credit")) Then totalCredit += Convert.ToDecimal(row("Montant_Credit"))
                    Next

                    '' === AJOUT DE LA LIGNE DE TOTAUX ===
                    'Dim totalRow As DataRow = table.NewRow()
                    'totalRow("ER_LIBELLE") = "TOTAL GÉNÉRAL"
                    'totalRow("Montant_Debit") = totalDebit
                    'totalRow("Montant_Credit") = totalCredit
                    'table.Rows.Add(totalRow)

                    '' Mise en forme visuelle du dernier row (total)
                    'Dim lastRow As Integer = DataGridView1.Rows.Count - 1
                    'If lastRow >= 0 Then
                    '    With DataGridView1.Rows(lastRow).DefaultCellStyle
                    '        .BackColor = Color.LightYellow
                    '        .Font = New Font(DataGridView1.Font, FontStyle.Bold)
                    '    End With
                    'End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message, "⚠️ Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Assurez-vous de fermer la connexion SQL proprement
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ' 🔁 Vérifie que le DataGridView a une source
            If DataGridView1.DataSource Is Nothing Then
                MessageBox.Show("Aucune donnée à imprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 🧠 Récupère et clone le DataTable pour ne pas toucher à l'original
            Dim originalTable As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim dt As DataTable = originalTable.Copy()

            ' 🛠 Renomme les colonnes si elles existent
            If dt.Columns.Contains("er_jour") Then dt.Columns("er_jour").ColumnName = "Jour"
            If dt.Columns.Contains("er_folio") Then dt.Columns("er_folio").ColumnName = "Folio"
            If dt.Columns.Contains("ER_LIBELLE") Then dt.Columns("ER_LIBELLE").ColumnName = "Libelle"
            If dt.Columns.Contains("Debit_Cpartie") Then dt.Columns("Debit_Cpartie").ColumnName = "Compte_D"
            If dt.Columns.Contains("Credit_Cpartie") Then dt.Columns("Credit_Cpartie").ColumnName = "Compte_C"
            If dt.Columns.Contains("Montant_Debit") Then dt.Columns("Montant_Debit").ColumnName = "Debit"
            If dt.Columns.Contains("Montant_Credit") Then dt.Columns("Montant_Credit").ColumnName = "Credit"

            ' 🗃 Ajoute au DataSet
            dt.TableName = "DataTable1"
            Dim ds As New DataSet("NewDataSet")
            ds.Tables.Add(dt)

            ' 📄 Chemin du rapport
            Dim reportPath As String = "e:\Prog_ComptabiliteAct\Prog_Contablite\CrystalReport12.rpt"
            If Not System.IO.File.Exists(reportPath) Then
                MessageBox.Show("Fichier Crystal Report introuvable : " & reportPath, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' 📥 Charge le rapport
            Dim report As New ReportDocument()
            report.Load(reportPath)
            report.SetDataSource(ds)

            ' 📦 Paramètres sécurisés
            Dim mois1 As Integer = If(ComboBox2.SelectedIndex >= 0, ComboBox2.SelectedIndex + 1, 1)
            Dim mois2 As Integer = If(ComboBox3.SelectedIndex >= 0, ComboBox3.SelectedIndex + 1, 1)

            report.SetParameterValue("codejournal", ComboBox1.Text)
            report.SetParameterValue("exercice", exec_proc.n1)
            report.SetParameterValue("mois1", mois1)
            report.SetParameterValue("mois2", mois2)
            report.SetParameterValue("NomJournal", Label3.Text)
            report.SetParameterValue("NomSoc", Access.nom_soc)

            ' 🔍 Affiche le rapport dans un formulaire
            Dim reportForm As New Form()
            Dim viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer() With {
            .Dock = DockStyle.Fill,
            .ReportSource = report
        }

            reportForm.Controls.Add(viewer)
            reportForm.WindowState = FormWindowState.Maximized
            reportForm.Show()

        Catch ex As Exception
            MessageBox.Show("Erreur d'affichage Crystal Report : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try




            If DataGridView1.DataSource Is Nothing Then
                MessageBox.Show("Aucune donnée à exporter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 🧠 Récupère le DataTable lié au DataGridView
            Dim dt As DataTable = CType(DataGridView1.DataSource, DataTable)
            dt.TableName = "DataTable1"
            'Dim colonnes = String.Join(vbNewLine, dt.Columns.Cast(Of DataColumn).Select(Function(c) c.ColumnName))
            'MessageBox.Show("Colonnes du DataTable : " & vbNewLine & colonnes)
            ' 📂 Chemin de destination
            Dim dossier As String = "C:\temp"

            ' 🔨 Crée le dossier si besoin
            If Not IO.Directory.Exists(dossier) Then
                IO.Directory.CreateDirectory(dossier)
            End If

            ' 💾 Génère les fichiers
            dt.WriteXml(dossier & "\Dsjournal.xml")
            dt.WriteXmlSchema(dossier & "\Dsjournal.xsd")

            MessageBox.Show("✅ Fichiers XML et XSD générés avec succès dans : " & dossier, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la génération : " & ex.Message)
        End Try
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class