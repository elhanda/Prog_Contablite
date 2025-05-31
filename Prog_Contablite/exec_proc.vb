
Imports System.Data.SqlClient

Public Class exec_proc
    Public n1 As String
    Public n2 As String
    Public n9 As String

    Private Sub exec_proc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'AfficherBaseActive(Me)
            'Connecter_soc()

            'MessageBox.Show("Accès à la société : " & Access.n2)
            Module1.connecter()
            ' Charger les exercices depuis la table Periode_Soc (ajoute l'année actuelle si vide ou manquante)
            ChargerExercices(ComboBox1, Access.n2)

            ' Sélection de l'exercice actif
            If ComboBox1.SelectedItem IsNot Nothing Then
                n9 = ComboBox1.SelectedValue.ToString()
            Else
                n9 = DateTime.Now.Year.ToString()
            End If
            n1=n9
            'MessageBox.Show("📅 Année sélectionnée : " & n9)

        Catch ex As Exception
            MessageBox.Show("❌ Erreur exec_proc_Load : " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'If ComboBox1.SelectedItem Is Nothing OrElse ComboBox1.Text = "" Then
            '    MessageBox.Show("⚠ Veuillez sélectionner un exercice.", "Alerte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Return
            'End If

            ' Connecter_soc()
            Dim exercice As String = n9 ' ComboBox1.Text.Trim()
            Dim dateDebut As DateTime = DateTimePicker1.Value.Date
            Dim dateFin As DateTime = DateTimePicker2.Value.Date

            ' VerifierOuCreerExercice(exercice, Access.n2, dateDebut, dateFin, ComboBox1)

            Me.Hide()
            Form1.Show()

        Catch ex As Exception
            MessageBox.Show("❌ Erreur dans Button1_Click : " & ex.Message)
        Finally
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Access.Show()
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem IsNot Nothing Then
            n9 = ComboBox1.SelectedValue.ToString()
            n1 = n9
        Else
            n9 = DateTime.Now.Year.ToString()
            n1 = n9
        End If
    End Sub

    ' 🧹 ComboBox1_Click supprimé car redondant avec ChargerExercices


End Class


