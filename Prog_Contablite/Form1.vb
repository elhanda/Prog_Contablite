Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
'Imports CrystalDecisions

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label6.Text = Access.n9
        Label5.Text = exec_proc.n1
        Label7.Text = Access.Name

    End Sub

    Private Sub ComptableToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Plan_Contable.Show()
        Me.Hide()

    End Sub

    Private Sub SAISIEjOURNAUXToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Saisie_Journaux.Show()
        Me.Hide()
    End Sub

    Private Sub GrandLivreToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        selected_balence.Show()
        Me.Hide()
    End Sub

    Private Sub JournalToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

        Me.Hide()
        Ecriture.Show()
    End Sub

    Private Sub BalanceToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        'Me.Close()
        Me.Hide()
        grindlive_choix.Show()
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs)
        Label5.BackColor = Color.Chocolate
        Label6.BorderStyle = BorderStyle.Fixed3D
        Label7.Cursor = Cursors.Hand
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs)
        Label5.BackColor = Color.BlueViolet
        Label5.BorderStyle = BorderStyle.Fixed3D
        Label7.Cursor = Cursors.Arrow
    End Sub

    Private Sub JournauxToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Edition_journal.Show()


        Me.Hide()

    End Sub

    Private Sub ParametresDiversToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ETATConstruire.Show()

        Me.Hide()
    End Sub



    Private Sub ReportÀNouveauToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Recup_OD.Show()

        Me.Hide()
    End Sub
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        'If (Me.Width = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width) And
        '(Me.Height = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height) Then Exit Sub
        ''ce test est pour éviter que ton événement ne se déclenche une seconde fois ensuite tu peux la redimensionner
        'Me.Width = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width
        'Me.Height = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height
        'Me.Location = New Point(0, 0)
    End Sub



    Private Sub FactureClientsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form2.Show()
    End Sub

    Private Sub ModelEcrituresToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Access.Show()
    End Sub



    Private Sub RetourToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Access.Show()
    End Sub

    Private Sub ComptableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComptableToolStripMenuItem.Click
        Plan_Contable.Show()
        Me.Hide()
    End Sub

    Private Sub sAISIEjOURNAUXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles sAISIEjOURNAUXToolStripMenuItem.Click
        Saisie_Journaux.Show()
        Me.Hide()
    End Sub

    Private Sub ModelEcrituresToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ModelEcrituresToolStripMenuItem.Click
        Me.Hide()
        Edit_journaux.Show()

    End Sub

    Private Sub GrandLivreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrandLivreToolStripMenuItem.Click

        Edit_Balance.Show()
        Me.Hide()
    End Sub

    Private Sub BalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BalanceToolStripMenuItem.Click
        Me.Hide()
        grindlive_choix.Show()
    End Sub

    Private Sub JournauxToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles JournauxToolStripMenuItem.Click
        Me.Hide()
        editjournal.Show()
    End Sub

    Private Sub JournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalToolStripMenuItem.Click

        Me.Hide()
        Ecriture.Show()
    End Sub

    Private Sub CPCToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CPCToolStripMenuItem.Click
        'Form8.Show()

        Me.Hide()
    End Sub

    Private Sub ImporterPlanComptableToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ImporterPlanComptableToolStripMenuItem.Click
        Recup_OD.Show()

        Me.Hide()
    End Sub

    Private Sub ParametresDiversToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ParametresDiversToolStripMenuItem.Click
        ETATConstruire.Show()

        Me.Hide()
    End Sub

    Private Sub TransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferToolStripMenuItem.Click
        transfert.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Me.Hide()
        Edit_journaux.Show()
    End Sub

    Private Sub SaisieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaisieToolStripMenuItem.Click

    End Sub

    Private Sub FactureClientsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles FactureClientsToolStripMenuItem.Click

    End Sub

    Private Sub ConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionToolStripMenuItem.Click
        FormRechercheServeur.Show()
        'Dim f As New ()
        'If f.ShowDialog() = DialogResult.OK Then
        '    Dim chaine As String = f.ChaineConnexionResultat
        '    MessageBox.Show("Chaîne sélectionnée : " & chaine)

        '     🔥 Tu peux l'utiliser pour te connecter directement
        '     Dim con As New SqlConnection(chaine)
        '    con.Open()
        'End If

    End Sub


End Class


