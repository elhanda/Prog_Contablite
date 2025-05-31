Public Class Form_Soc
    Private Sub AnnulationToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        creat_soc.Show()
    End Sub
    Private Sub UtilisateurToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Guser.Show()
    End Sub

    Private Sub AnnulationSociétéToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()

        Form3.Show()
    End Sub

    Private Sub AnnulationExerciceToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        Me.Close()
        Annuler_Exercice.Show()

    End Sub
    Private Sub ParamétrageComptesToolStripMenuItem_Click(sender As Object, e As EventArgs) 
        ParametrageCompte.Show()
    End Sub

    Private Sub Form_Soc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub AnnulationToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AnnulationToolStripMenuItem.Click
        creat_soc.Show()
    End Sub

    Private Sub AnnulationSociétéToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AnnulationSociétéToolStripMenuItem.Click
        Me.Close()

        Form3.Show()
    End Sub

    Private Sub AnnulationExerciceToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AnnulationExerciceToolStripMenuItem.Click
        Me.Close()
        Annuler_Exercice.Show()
    End Sub

    Private Sub UtilisateurToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UtilisateurToolStripMenuItem.Click
        Guser.Show()
    End Sub

    Private Sub EnteteSociétéToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnteteSociétéToolStripMenuItem.Click

    End Sub

    Private Sub ParamétrageComptesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ParamétrageComptesToolStripMenuItem.Click
        ParametrageCompte.Show()
    End Sub
End Class