

Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient





Public Class editjournal
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataSet = New DataSet()
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



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        cmd = New SqlCommand("select J_LIBELLE from FJournal where J_CODE =" & ComboBox1.Text & "", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "FJol")
        For Each dr As DataRow In ds.Tables("FJol").Rows
            Label3.Text = dr("J_LIBELLE").ToString()
        Next
        ComboBox1.Text = ComboBox1.SelectedItem(0)
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

        cmd = New SqlCommand("select J_LIBELLE from FJournal where J_CODE =" & ComboBox2.Text & "", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(dt, "FJol")
        For Each dr As DataRow In dt.Tables("FJol").Rows
            Label5.Text = dr("J_LIBELLE").ToString()
        Next

        If ComboBox2.Items.Count > 0 Then
            ComboBox2.Text = ComboBox2.SelectedItem(0)
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()

    End Sub




    Private Sub Edit_Journal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Module1.connecter()

            ' 🗃 Charger la liste des journaux
            Dim query As String = "SELECT J_CODE, J_LIBELLE FROM FJournal ORDER BY J_CODE"
            Dim cmd As New SqlCommand(query, con)
            Dim adapter As New SqlDataAdapter(cmd)
            Dim journalTable As New DataTable()
            adapter.Fill(journalTable)

            ' 🔁 Bind ComboBox1 (début)
            ComboBox1.DisplayMember = "J_CODE"
            ComboBox1.ValueMember = "J_LIBELLE" ' ❌ pas d’espace !
            ComboBox1.DataSource = journalTable.Copy()
            If ComboBox1.Items.Count > 0 Then
                ComboBox1.SelectedIndex = 0
            End If

            ' 🔁 Bind ComboBox2 (fin)
            ComboBox2.DisplayMember = "J_CODE"
            ComboBox2.ValueMember = "J_LIBELLE"
            ComboBox2.DataSource = journalTable.Copy()
            If ComboBox2.Items.Count > 0 Then
                ComboBox2.SelectedIndex = ComboBox2.Items.Count - 1
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur de chargement des journaux : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Button3.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' 🔄 Réinitialise la grille
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            ' 📡 Connexion SQL
            Module1.connecter()
            Dim query As String = "EXEC list_journaux @Exec, @CodeJournal1, @CodeJournal2"




            'MsgBox(exec_proc.n1)
            'MsgBox(exec_proc.n9)
            ''*************************************************
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Exec", exec_proc.n9)
                cmd.Parameters.AddWithValue("@CodeJournal1", ComboBox1.Text)
                cmd.Parameters.AddWithValue("@CodeJournal2", ComboBox2.Text)

                Using adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    ' 📊 Bind des données
                    DataGridView1.DataSource = table
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                    ' 🏷️ Mise à jour des en-têtes
                    For Each column As DataColumn In table.Columns
                        Select Case column.ColumnName
                            Case "code_journal"
                                DataGridView1.Columns("code_journal").HeaderText = "Journal"
                                DataGridView1.Columns("code_journal").Width = 60
                            Case "libelle"
                                DataGridView1.Columns("libelle").HeaderText = "Libellé"
                                DataGridView1.Columns("libelle").Width = 200
                            Case "mois"
                                DataGridView1.Columns("mois").HeaderText = "Mois"
                                DataGridView1.Columns("mois").Width = 50
                            Case "folio"
                                DataGridView1.Columns("folio").HeaderText = "Folio"
                                DataGridView1.Columns("folio").Width = 50
                            Case "nombre_de_lignes"
                                DataGridView1.Columns("nombre_de_lignes").HeaderText = "Nombre de lignes"
                                DataGridView1.Columns("nombre_de_lignes").Width = 100
                            Case "Debit_Cpartie"
                                DataGridView1.Columns("Debit_Cpartie").HeaderText = "Compte Débit"
                            Case "Credit_Cpartie"
                                DataGridView1.Columns("Credit_Cpartie").HeaderText = "Compte Crédit"
                            Case "Total_Debit"
                                DataGridView1.Columns("Total_Debit").HeaderText = "Total Débit"
                            Case "Total_Credit"
                                DataGridView1.Columns("Total_Credit").HeaderText = "Total Crédit"
                            Case "Solde"
                                DataGridView1.Columns("Solde").HeaderText = "Solde"
                        End Select
                    Next
                    '**************************************************
                    '*
                    '**************************************************
                    Dim result = CalculerTotaux(DataGridView1, 8, 9)
                    Dim totalCol4 As Decimal = result.Item1
                    Dim totalCol5 As Decimal = result.Item2
                    Label9.Text = totalCol4
                    Label10.Text = totalCol5
                    Label11.Text = (totalCol4 - totalCol4) '.ToString("N2")
                    'MessageBox.Show($"Total Colonne 4: {totalCol4}" & vbCrLf & $"Total Colonne 5: {totalCol5}")
                    Label9.Refresh()
                    Label10.Refresh()
                    Label10.Refresh()

                    DataGridView1.DataSource = table
                    Button3.Enabled = True
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message, "⚠️ Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try

            'Dim reportPath As String = "e:\crystalreport\Edit_journaux_001.rpt"
            Dim reportPath As String = Access.PathCryst + "Edit_journaux_001.rpt"
            If Not IO.File.Exists(reportPath) Then
                MessageBox.Show("❌ Fichier Crystal introuvable : " & reportPath)
                Exit Sub
            End If

            Dim report As New ReportDocument()
            report.Load(reportPath)
            report.SetDataSource(ds)

            ' 📦 Paramètres
            '    ' ✅ Passage des paramètres sans les @
            report.SetParameterValue("exercice", exec_proc.n1)
            report.SetParameterValue("code_journal_debut", ComboBox1.Text)
            report.SetParameterValue("code_journal_fin", ComboBox2.Text)
            report.SetParameterValue("Nom_soc", Access.nom_soc)

            '   report.SetParameterValue("NomJournal", Label3.Text)


            ' 🖥️ Affichage
            Dim reportForm As New Form()
            Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer() With {
            .Dock = DockStyle.Fill,
            .ReportSource = report
        }
            reportForm.Controls.Add(crystalReportViewer)
            reportForm.WindowState = FormWindowState.Maximized
            reportForm.Show()


        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement du rapport : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub



    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class
