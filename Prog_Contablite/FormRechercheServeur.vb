Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FormRechercheServeur

    Public Property ChaineConnexionResultat As String

    Private Sub FormRechercheServeur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemplirComboBoxServeurs()
    End Sub

    Private Sub RemplirComboBoxServeurs()
        Try
            Dim tableServeurs As DataTable = SqlDataSourceEnumerator.Instance.GetDataSources()
            ComboBoxServeurs.Items.Clear()

            For Each row As DataRow In tableServeurs.Rows
                Dim nomServeur As String = row("ServerName").ToString()
                Dim instance As String = row("InstanceName").ToString()

                If Not String.IsNullOrEmpty(instance) Then
                    nomServeur &= "\" & instance
                End If

                ComboBoxServeurs.Items.Add(nomServeur)
            Next

            If ComboBoxServeurs.Items.Count > 0 Then
                ComboBoxServeurs.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur serveur : " & ex.Message)
        End Try
    End Sub

    Private Sub ComboBoxServeurs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServeurs.SelectedIndexChanged
        Dim serveurSelectionne As String = ComboBoxServeurs.SelectedItem.ToString()
        RemplirComboBoxBasesEtChemins(serveurSelectionne)
    End Sub

    Private Sub RemplirComboBoxBasesEtChemins(nomServeur As String)
        Try
            ComboBoxBases.Items.Clear()

            Dim connectionString As String = $"Data Source={nomServeur};Initial Catalog=master;Integrated Security=True"

            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "
                    SELECT 
                        d.name AS BaseDeDonnees, 
                        mf.physical_name AS Emplacement 
                    FROM sys.databases d
                    JOIN sys.master_files mf ON d.database_id = mf.database_id
                    WHERE mf.file_id = 1
                    ORDER BY d.name
                "

                Using cmd As New SqlCommand(query, con)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim base As String = reader("BaseDeDonnees").ToString()
                        Dim chemin As String = reader("Emplacement").ToString()
                        ComboBoxBases.Items.Add($"{base} --> {chemin}")
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erreur base : " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonConnecter_Click(sender As Object, e As EventArgs) Handles ButtonConnecter.Click
        If ComboBoxServeurs.SelectedItem Is Nothing OrElse ComboBoxBases.SelectedItem Is Nothing Then
            MessageBox.Show("Sélectionne un serveur et une base de données.")
            Return
        End If

        ' Récupération simple du nom de la base
        Dim baseName As String = ComboBoxBases.SelectedItem.ToString().Split(" -->")(0)
        Dim serveurName As String = ComboBoxServeurs.SelectedItem.ToString()

        ChaineConnexionResultat = $"Data Source={serveurName};Initial Catalog={baseName};Integrated Security=True"

        ' Fermer le form et retourner la chaîne
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class