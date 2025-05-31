Public Class Form_Soc
    Private Sub AnnulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulationToolStripMenuItem.Click
        creat_soc.Show()
    End Sub
    Private Sub UtilisateurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UtilisateurToolStripMenuItem.Click
        Guser.Show()
    End Sub

    Private Sub AnnulationSociétéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulationSociétéToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub AnnulationExerciceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnulationExerciceToolStripMenuItem.Click
        Annul_Exercice.Show()

    End Sub
    Private Sub ParamétrageComptesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParamétrageComptesToolStripMenuItem.Click
        ParametrageCompte.Show()
    End Sub
    Dim rs As New Form_Choix.Resizer
    Private Sub Form_Soc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
    End Sub

    Private Sub Form_Soc_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub ReturnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReturnToolStripMenuItem.Click
        Me.Close()
        Form_Choix.Show()

    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click

        Form_Choix.Close()
        'Me.Close()
    End Sub

    Private Sub Form_Soc_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Form_Choix.Close()
        Me.Close()
    End Sub

    Private Sub SaisieDesParametreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaisieDesParametreToolStripMenuItem.Click
        Me.Hide()
        Saisie_de_Parametre.Show()

    End Sub
End Class