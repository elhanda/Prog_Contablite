Public Class Form1
    Dim rs As New Form_Choix.Resizer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        '  Label1.Text = exec_proc.n1
        '  Label2.Text = Access.n2
        Label3.Text = Access.Name

    End Sub

    Private Sub ComptableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptableToolStripMenuItem.Click
        Plan_Contable.Show()
        Me.Hide()

    End Sub

    Private Sub sAISIEjOURNAUXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles sAISIEjOURNAUXToolStripMenuItem.Click
        Saisie_Journaux.Show()
        Me.Hide()
    End Sub

    Private Sub GrandLivreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrandLivreToolStripMenuItem.Click
        Balance.Show()
        Me.Hide()
    End Sub

    Private Sub JournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalToolStripMenuItem.Click

        Me.Hide()
        Ecriture.Show()
    End Sub



    Private Sub BalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BalanceToolStripMenuItem.Click
        Me.Close()
        grindlive_choix.Show()

    End Sub



    Private Sub JournauxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournauxToolStripMenuItem.Click
        Me.Hide()
        Edition_journal.Show()

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitterToolStripMenuItem.Click
        Me.Close()
        Form_Choix.Close()


    End Sub

    Private Sub ModelEcrituresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModelEcrituresToolStripMenuItem.Click

    End Sub

    Private Sub ParametresDiversToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParametresDiversToolStripMenuItem.Click

    End Sub

    Private Sub TotalCompteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Frm_Total_Compte_Param.Show()


    End Sub

    Private Sub ActifToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActifToolStripMenuItem.Click
        Form6.Show()

    End Sub

    Private Sub PASSIFToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PASSIFToolStripMenuItem.Click
        PassifForm.Show()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub FactureClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FactureClientsToolStripMenuItem.Click
        Facture_Client.Show()
        Me.Hide()
    End Sub

    Private Sub FactureFournisseursToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FactureFournisseursToolStripMenuItem.Click
        Facture_Fournisseur.Show()
        Me.Hide()
    End Sub

    Private Sub FACTURECLIENTSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FACTURECLIENTSToolStripMenuItem1.Click
        Edition_Fact_Client.Show()
        Me.Hide()
    End Sub

    Private Sub FACTURESFOURNISSEURSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FACTURESFOURNISSEURSToolStripMenuItem.Click
        Edition_Facture_Fourniss.Show()
        Me.Hide()

    End Sub

    Private Sub EtatConstructerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EtatConstructerToolStripMenuItem.Click
        ETATConstruire.Show()
        Me.Hide()
    End Sub
End Class