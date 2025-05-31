Imports System.Data
Imports System.Data.OleDb


Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class grindlive_choix
    ' Dim con As SqlConnection
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
    Public nbcol As Integer = 0
    Public mois1 As Integer
    Public mois2 As Integer
    Dim y As Integer
    Private totalCol4 As Object


    Sub aff_touto_seul()
        '       Try


        '           Dim req As String = "
        'exec list " & exer & ""
        '           cmd = New SqlCommand(req, con)
        '           Dim adapttr As SqlDataAdapter
        '           adapttr = New SqlDataAdapter(cmd)
        '           Dim dt = New DataTable()
        '           adapttr.Fill(dt)
        '           Dim isi As ListViewItem
        '           For Each AB As DataRow In dt.Rows
        '               isi = GrindLivre.ListView1.Items.Add(AB(0).ToString)
        '               isi.SubItems.Add(AB(1).ToString)
        '               isi.SubItems.Add(AB(2).ToString)
        '               isi.SubItems.Add(AB(3).ToString)
        '               Balance.ListView1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
        '               Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
        '               Id_Niv12.Add(Id_Niveau2)
        '           Next

        '       Catch ex As Exception
        '           MessageBox.Show("error de totaux seul proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '       End Try


    End Sub
    Sub reaff_touto_seul()
        '        Try
        '            Dim req As String = "
        ' exec list " & exer & " "
        '            cmd = New SqlCommand(req, con)
        '            Dim adapttr As SqlDataAdapter
        '            adapttr = New SqlDataAdapter(cmd)
        '            Dim dt = New DataTable()
        '            adapttr.Fill(dt)
        '            Dim isi As ListViewItem
        '            For Each AB As DataRow In dt.Rows
        '                isi = Balance.ListView1.Items.Add(AB(0).ToString)
        '                isi.SubItems.Add(AB(1).ToString)
        '                Balance.ListView1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
        '                Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
        '                Id_Niv12.Add(Id_Niveau2)
        '            Next

        '        Catch ex As Exception
        '            MessageBox.Show("error de totaux seul proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        ')
        '        End Try
    End Sub
    Sub aff_moix(a, b)
        '        Try
        '            Dim req As String = "
        '[list_month] " & a & "," & b & ", " & exer & ""
        '            cmd = New SqlCommand(req, con)
        '            Dim adapttr As SqlDataAdapter
        '            adapttr = New SqlDataAdapter(cmd)
        '            Dim dt = New DataTable()
        '            adapttr.Fill(dt)
        '            Dim isi As ListViewItem
        '            For Each AB As DataRow In dt.Rows
        '                isi = Grand_Livre.ListView1.Items.Add(AB(0).ToString)
        '                isi.SubItems.Add(AB(1).ToString)
        '                isi.SubItems.Add(AB(2).ToString)
        '                isi.SubItems.Add(AB(3).ToString)
        '                Grand_Livre.ListView1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
        '                Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
        '                Id_Niv12.Add(Id_Niveau2)
        '            Next

        '        Catch ex As Exception
        '            MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        ')
        '        End Try
    End Sub
    Sub reaff_moix(a, b)
        '        Try
        '            Dim req As String = "
        '        [list_month] " & a & "," & b & "," & exer & " "
        '            cmd = New SqlCommand(req, con)
        '            Dim adapttr As SqlDataAdapter
        '            adapttr = New SqlDataAdapter(cmd)
        '            Dim dt = New DataTable()
        '            adapttr.Fill(dt)
        '            'GrindLivre.ListView1.Items.Remove(" ER_CPARTIE " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & " nombre total ")
        '            '     GrindLivre.ListView1.Items.Remove("ComboBox3.Text" & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & " nombre total ")
        '            For Each AB As DataRow In dt.Rows

        '                GrindLivre.ListView1.Items.Remove(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
        '                Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
        '                Id_Niv12.Remove(Id_Niveau2)
        '            Next
        '        Catch ex As Exception
        '            MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        ')
        '        End Try
    End Sub
    Private Sub grindlive_choix_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter()
        'Label11.Text = exec_proc.n1
        'MsgBox(exec_proc.n1)
        'Label9.Text = Access.n2
        'CheckBox1.Enabled = False

        DateTimePicker1.Value = New DateTime(exec_proc.n9, 1, 1)    ' 1er Janvier
        DateTimePicker2.Value = New DateTime(exec_proc.n9, 12, 31)  ' 31 Décembre
        mois1 = 1
        mois2 = 12
        Dim jour1 = 1
        Dim jour2 = 31


        ''C_Partie ne doit pas saisie tout seul 

        cmd = New SqlCommand("select distinct ER_CPARTIE from [Fecriture] where len(er_cpartie) >0 group by ER_CPARTIE order by ER_CPARTIE ", con)
        adapt1 = New SqlDataAdapter(cmd)
        adapt1.Fill(ds, "Fecriture")
        ComboBox3.DisplayMember = "ER_CPARTIE"
        ComboBox3.ValueMember = "ER_LIBELLE"
        ComboBox3.DataSource = ds.Tables("Fecriture")
        ComboBox3.GetItemText(0)
        'Label4.Text = ComboBox3.ValueMember
        'Grand_Livre.TextBox1.Text = ComboBox3.Text

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select distinct ER_Cpartie from [Fecriture] where len(er_cpartie) >0 group by ER_CPARTIE order by ER_CPARTIE   desc ", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(ds1, "Fecriture")
        ComboBox4.DisplayMember = "ER_CPARTIE"
        ComboBox4.ValueMember = "ER_LIBELLE"
        ComboBox4.DataSource = ds1.Tables("Fecriture")
        ComboBox4.GetItemText(0)

        CheckBox1.Checked = False
        CheckBox2.Checked = False

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
        'Try

        '    aff_touto_seul()

        'Catch ex As Exception
        '    MessageBox.Show("error de la selection your totaux seul" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        '        Try

        '            aff_moix(ComboBox1.SelectedIndex + 1, ComboBox2.SelectedIndex + 1)

        '        Catch ex As Exception
        '            MessageBox.Show("error de la selection your totaux seul" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        ')
        '        End Try
    End Sub
    Sub affich(Mois1 As Integer, Mois2 As Integer, Compte1 As String, compte2 As String, exercice As Integer)

        'Try
        '    Dim req As String = "
        '    select  distinct ER_JOUR as 'Jr',ER_LIGNE as 'N°Lign',ER_FOLIO as 'N°Fol' ,ER_CPARTIE as 'N°Compte',ER_CPARTIE as 'Compte_Partie',ER_NPIECE as 'N°Piece ', ER_LIBELLE as 'LIBELLE', IIF ( ER_CODE = 'D' , sum(ER_MONT), '                  ')as 'TYPE_DEBUT'
        '    ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI' from FEcriture 

        '    where 
        '     (er_mois >= " & Mois1 & " and er_mois <= " & Mois2 & ")  AND
        '     (er_cpartie >= " & Compte1 & " and er_cpartie <= " & compte2 & ") AND (ER_EXERC=" & exercice & ")
        '    Group by ER_CODE,ER_JOUR,ER_LIGNE,ER_FOLIO,ER_CPARTIE,ER_CPARTIE,ER_NPIECE, ER_LIBELLE "
        '    cmd = New SqlCommand(req, con)
        '    adapt3 = New SqlDataAdapter(cmd)
        '    adapt3.Fill(ds)
        '    DataGridView1.DataSource = ds
        '    DataGridView1.Refresh()
        '    con.Close()

        'Catch ex As Exception
        '    MessageBox.Show("error de la proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub


    Private Sub Apercu_Click(sender As Object, e As EventArgs) Handles Apercu.Click

        Module1.connecter()


        'Dim reportPath As String = Access.PathCryst + "Edit_Glivre_001.rpt"

        Dim compte1 As String
        Dim compte2 As String

        compte1 = ComboBox3.Text
        compte2 = ComboBox4.Text

        mois1 = DateTimePicker1.Value.Month
        Dim jour1 As Integer = DateTimePicker1.Value.Day

        mois2 = DateTimePicker2.Value.Month
        Dim jour2 As Integer = DateTimePicker2.Value.Day



        Dim searchQuery As String = "exec [grand_livre] " & CInt(exec_proc.n1) & ",'" & compte1 & "' ,'" & compte2 & "', " & CInt(mois1) & " ," & CInt(mois2) & ", " & CInt(jour1) & " ," & CInt(jour2) & ", '1', '1' "

        Try
            ' Ouvrir la connexion

            Dim command As New SqlCommand(searchQuery, con)

            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)

            DataGridView1.DataSource = table

            ' ✅ Vérifier si les colonnes existent avant de renommer


            If DataGridView1.Columns.Contains("ER_mois") Then DataGridView1.Columns("ER_mois").HeaderText = "er_mois"
            If DataGridView1.Columns.Contains("ER_folio") Then DataGridView1.Columns("ER_folio").HeaderText = "er_folio"
            If DataGridView1.Columns.Contains("ER_JOUR") Then DataGridView1.Columns("ER_JOUR").HeaderText = "er_Jour"
            If DataGridView1.Columns.Contains("ER_CPARTIE") Then DataGridView1.Columns("ER_CPARTIE").HeaderText = "Compte"
            If DataGridView1.Columns.Contains("ER_npiece") Then DataGridView1.Columns("ER_npiece").HeaderText = "ER_npiece"
            If DataGridView1.Columns.Contains("ER_LIBELLE") Then DataGridView1.Columns("ER_LIBELLE").HeaderText = "Libelle"
            If DataGridView1.Columns.Contains("DEBIT") Then DataGridView1.Columns("DEBIT").HeaderText = "Debit"
            If DataGridView1.Columns.Contains("CREDIT") Then DataGridView1.Columns("CREDIT").HeaderText = "Credit"



            Dim result = CalculerTotaux(DataGridView1, 7, 8)
            Dim totalCol4 As Decimal = result.Item1
            Dim totalCol5 As Decimal = result.Item2
            Label9.Text = totalCol4
            Label10.Text = totalCol5
            Label11.Text = (totalCol4 - totalCol4) '.ToString("N2")
            'MessageBox.Show($"Total Colonne 4: {totalCol4}" & vbCrLf & $"Total Colonne 5: {totalCol5}")
            Label9.Refresh()
            Label10.Refresh()
            Label10.Refresh()
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la connexion à la base de données : " & ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion si ouverte
            If con.State = ConnectionState.Open Then con.Close()
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' 🔁 Vérifie que le DataGridView a une source
            If DataGridView1.DataSource Is Nothing Then
                MessageBox.Show("Aucune donnée à imprimer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' 🧠 Clone le DataTable pour ne pas toucher à l'original
            Dim originalTable As DataTable = CType(DataGridView1.DataSource, DataTable)
            Dim dt As DataTable = originalTable.Copy()

            ' 🗃 Ajout au DataSet
            dt.TableName = "DataTable1"
            Dim ds As New DataSet("NewDataSet")
            ds.Tables.Add(dt)

            ' 📊 Debug : combien de lignes ?
            'MessageBox.Show("📊 Nombre de lignes envoyées au rapport : " & dt.Rows.Count)



            ' 📍 Lien obligatoire avec Crystal Report
            Dim reportPath As String = Access.PathCryst + "Edit_Glivre_001.rpt"
            If Not IO.File.Exists(reportPath) Then
                MessageBox.Show("❌ Fichier Crystal introuvable : " & reportPath)
                Exit Sub
            End If
            'Dim exercice = exec_proc.n1
            Dim compte1 = ComboBox3.Text
            Dim compte2 = ComboBox4.Text
            Dim mois1 = DateTimePicker1.Value.Month
            Dim jour1 As Integer = DateTimePicker1.Value.Day
            Dim mois2 = DateTimePicker2.Value.Month
            Dim jour2 As Integer = DateTimePicker2.Value.Day

            Dim report As New ReportDocument()
            report.Load(reportPath)
            report.SetDataSource(ds)


            'MsgBox(PathCryst)
            'MsgBox(exec_proc.n1)
            'MsgBox(compte1)
            'MsgBox(compte2)
            'MsgBox(mois1)
            'MsgBox(mois2)

            'MsgBox(jour1)
            'MsgBox(jour2)
            'Dim currentDirectory As String = System.IO.Directory.GetCurrentDirectory()
            'MessageBox.Show("📂 Répertoire actuel : " & currentDirectory)
            'MsgBox(reportPath)

            ' 📦 Paramètres
            report.SetParameterValue("Exec", 2004)
            report.SetParameterValue("CompteDebut", compte1)
            report.SetParameterValue("CompteFin", compte2)
            report.SetParameterValue("mois1", 1)
            report.SetParameterValue("mois2", 12)
            report.SetParameterValue("jour1", 1)
            report.SetParameterValue("jour2", 31)
            report.SetParameterValue("chk1", 1)
            report.SetParameterValue("chk2", 1)

            report.SetParameterValue("Nom_Soc", Access.nom_soc)


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
            MessageBox.Show("❌ Erreur d'affichage Crystal Report : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        '  Try



        ' 🧠 Clone le DataTable pour ne pas toucher à l'original
        '    Dim originalTable As DataTable = CType(DataGridView1.DataSource, DataTable)
        '    Dim dt As DataTable = originalTable.Copy()



        '    ' 🗃 Ajout au DataSet
        '    dt.TableName = "DataTable1"
        '    Dim ds As New DataSet("NewDataSet")
        '    ds.Tables.Add(dt)



        '    ' ✅ Chemin du rapport .rpt
        '    Dim reportPath As String = Access.PathCryst + "Edit_Glivre_001.rpt"
        '    'Dim reportPath As String = Access.PathCryst + "crystalreport15.rpt"


        '    If Not IO.File.Exists(reportPath) Then
        '        MessageBox.Show("Fichier Crystal Report introuvable : " & reportPath, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If

        '    ' 📦 Charger le rapport
        '    Dim report As New ReportDocument()
        '    report.Load(reportPath)
        '    report.SetDataSource(ds)


        '    ' 📋 Lire les paramètres
        '    'Dim exercice = exec_proc.n1
        '    Dim compte1 = ComboBox3.Text
        '    Dim compte2 = ComboBox4.Text
        '    Dim moiss1 = DateTimePicker1.Value.Month
        '    Dim jour1 As Integer = DateTimePicker1.Value.Day

        '    Dim moiss2 = DateTimePicker2.Value.Month
        '    Dim jour2 As Integer = DateTimePicker2.Value.Day


        '    ' 🎯 Passer les paramètres au rapport

        '    report.SetParameterValue("Exec", exec_proc.n1)
        '    report.SetParameterValue("CompteDebut", compte1)
        '    report.SetParameterValue("CompteFin", compte2)
        '    report.SetParameterValue("mois1", moiss1)
        '    report.SetParameterValue("mois2", moiss2)
        '    report.SetParameterValue("jour1", jour1)
        '    report.SetParameterValue("jour2", jour2)
        '    report.SetParameterValue("chk1", 1)
        '    report.SetParameterValue("chk2", 1)
        '    report.SetParameterValue("Nom_soc", Access.nom_soc)


        '    ' 🖥️ Affichage
        '    Dim reportForm As New Form()
        '    Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer() With {
        '    .Dock = DockStyle.Fill,
        '    .ReportSource = report
        '}
        '    reportForm.Controls.Add(crystalReportViewer)
        '    reportForm.WindowState = FormWindowState.Maximized
        '    reportForm.Show()

        'Catch ex As Exception
        '    MessageBox.Show("Erreur Crystal : " & ex.Message, "💥 Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim testReport As New ReportDocument()
        testReport.Load("C:\test\rapport1.rpt") ' juste un champ texte
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If DateTimePicker1.Value > DateTimePicker2.Value Then
            MsgBox("Date1 doit etre inferieur à Date2")
            Apercu.Enabled = False
            Button2.Enabled = False
        Else
            Apercu.Enabled = True
            Button2.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        'If DateTimePicker2.Value < DateTimePicker1.Value Then
        '    MsgBox("Date2 doit etre Superieur à Date1")
        '    Apercu.Enabled = False
        '    Button2.Enabled = False
        'Else
        '    Apercu.Enabled = True
        '    Button2.Enabled = True
        'End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            ' ✅ Chemin du rapport .rpt
            ' Dim reportPath As String = "e:\Prog_ComptabiliteAct\Prog_Contablite\crystalreprt14" & Access.n2 & ".rpt"
            'Dim reportPath As String = "e:\gestion commerciale\Prog_Contablite\crystalreport15.rpt"
            Dim reportPath As String = Access.PathCryst + "grandLivre1.rpt"

            If Not IO.File.Exists(reportPath) Then
                MessageBox.Show("Fichier Crystal Report introuvable : " & reportPath, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' 📦 Charger le rapport
            Dim report As New ReportDocument()
            report.Load(reportPath)


            ' 📋 Lire les paramètres
            'Dim exec = 2004 'CInt(Access.n2)
            Dim compte1 = ComboBox3.Text
            Dim compte2 = ComboBox4.Text

            Dim mois1 = DateTimePicker1.Value.Month
            Dim jour1 As Integer = DateTimePicker1.Value.Day

            Dim mois2 As Integer = DateTimePicker2.Value.Month
            Dim jour2 As Integer = DateTimePicker2.Value.Day

            ' 🎯 Passer les paramètres au rapport
            report.SetParameterValue("mois1", mois1)

            report.SetParameterValue("Exercice", exec_proc.n9)
            report.SetParameterValue("mois2", mois2)

            report.SetParameterValue("Compte1", compte1)
            report.SetParameterValue("Compte2", compte2)
            report.SetParameterValue("jour1", jour1)
            report.SetParameterValue("jour2", jour2)

            report.SetParameterValue("Nom_soc", Access.nom_soc)


            ' 🖥️ Affichage Crystal
            Dim viewerForm As New Form()
            Dim viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer With {
                .Dock = DockStyle.Fill,
                .ReportSource = report
            }

            viewerForm.Controls.Add(viewer)
            viewerForm.WindowState = FormWindowState.Maximized
            viewerForm.Show()



            '****************************************************
            '*
            '****************************************************


            '****************************************************




        Catch ex As Exception
            MessageBox.Show("Erreur Crystal : " & ex.Message, "💥 Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class