Imports System.Data.SqlClient
Imports System.IO

Public Class FrmServeurConfig

    Private Sub FrmServeurConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerListeServeurs()
        ActiverChampsAuthSQL(False)
    End Sub

    Private Sub ChargerListeServeurs()
        Try
            Dim cheminFichier As String = Path.Combine(Application.StartupPath, "serveurs.txt")
            If Not File.Exists(cheminFichier) Then
                CmbServeurs.Items.Add("localhost\SQLEXPRESS")
            Else
                Dim lignes() As String = File.ReadAllLines(cheminFichier)
                CmbServeurs.Items.Clear()
                For Each ligne In lignes
                    CmbServeurs.Items.Add(ligne)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lecture du fichier serveurs.txt : " & ex.Message)
        End Try
    End Sub

    Private Sub ActiverChampsAuthSQL(active As Boolean)
        txtLogin.Enabled = active
        txtPassword.Enabled = active
    End Sub

    Private Sub chkAuthSQL_CheckedChanged(sender As Object, e As EventArgs) Handles chkAuthSQL.CheckedChanged
        ActiverChampsAuthSQL(chkAuthSQL.Checked)
    End Sub

    Private Sub cmbServeurs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbServeurs.SelectedIndexChanged
        Try
            Dim builder As New SqlConnectionStringBuilder()
            builder.DataSource = CmbServeurs.SelectedItem.ToString()

            If chkAuthSQL.Checked Then
                builder.UserID = txtLogin.Text
                builder.Password = txtPassword.Text
                builder.IntegratedSecurity = False
            Else
                builder.IntegratedSecurity = True
            End If

            Using con As New SqlConnection(builder.ConnectionString)
                con.Open()
                Dim dt As DataTable = con.GetSchema("Databases")
                CmbBases.Items.Clear()
                For Each row As DataRow In dt.Rows
                    CmbBases.Items.Add(row("database_name").ToString())
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la récupération des bases : " & ex.Message)
        End Try
    End Sub

    Private Sub btnTester_Click(sender As Object, e As EventArgs) Handles btnTester.Click
        Try
            Dim builder As New SqlConnectionStringBuilder()
            builder.DataSource = CmbServeurs.SelectedItem.ToString()

            If chkAuthSQL.Checked Then
                builder.UserID = txtLogin.Text
                builder.Password = txtPassword.Text
                builder.IntegratedSecurity = False
            Else
                builder.IntegratedSecurity = True
            End If

            Using con As New SqlConnection(builder.ConnectionString)
                con.Open()
                MessageBox.Show("✅ Connexion réussie !")
            End Using

        Catch ex As Exception
            MessageBox.Show("❌ Connexion échouée : " & ex.Message)
        End Try
    End Sub

    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles BtnValider.Click
        If CmbServeurs.SelectedItem Is Nothing OrElse CmbBases.SelectedItem Is Nothing Then
            MessageBox.Show("Veuillez sélectionner un serveur et une base.")
            Return
        End If

        Dim builder As New SqlConnectionStringBuilder()
        builder.DataSource = CmbServeurs.SelectedItem.ToString()
        builder.InitialCatalog = CmbBases.SelectedItem.ToString()

        If chkAuthSQL.Checked Then
            builder.UserID = txtLogin.Text
            builder.Password = txtPassword.Text
            builder.IntegratedSecurity = False
        Else
            builder.IntegratedSecurity = True
        End If

        Try
            Using con As New SqlConnection(builder.ConnectionString)
                con.Open()
                Dim cheminComplet = Path.Combine(Application.StartupPath, "connexion.txt")
                File.WriteAllText(cheminComplet, builder.ConnectionString)
                MessageBox.Show("✅ Connexion enregistrée dans connexion.txt")
                Me.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la sauvegarde : " & ex.Message)
        End Try
    End Sub

    Private Sub btnVoirConnexion_Click(sender As Object, e As EventArgs) Handles btnVoirConnexion.Click
        Try
            Dim builder As New SqlConnectionStringBuilder()
            builder.DataSource = CmbServeurs.SelectedItem.ToString()
            builder.InitialCatalog = CmbBases.SelectedItem.ToString()

            If chkAuthSQL.Checked Then
                builder.UserID = txtLogin.Text
                builder.Password = txtPassword.Text
                builder.IntegratedSecurity = False
            Else
                builder.IntegratedSecurity = True
            End If

            MessageBox.Show("Chaîne générée :" & vbCrLf & builder.ConnectionString, "Chaîne de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Erreur : " & ex.Message)
        End Try
    End Sub

    Private Sub btnEditServeurs_Click(sender As Object, e As EventArgs) Handles btnEditServeurs.Click
        Try
            Dim cheminServeurs As String = Path.Combine(Application.StartupPath, "serveurs.txt")
            If File.Exists(cheminServeurs) Then
                Process.Start("notepad.exe", cheminServeurs)
            Else
                MessageBox.Show("Le fichier serveurs.txt est introuvable.")
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ouverture du fichier : " & ex.Message)
        End Try
    End Sub

End Class