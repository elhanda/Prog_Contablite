Public Class GrindLivre
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        grindlive_choix.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub



    Private Sub GrindLivre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index As ListViewItem

        Dim debut As Long
        Dim credit As Long
        With ListView1
            '  index = .SelectedIndices(1)
            For Each index In .Items
                debut = debut + CLng(index.SubItems(2).Text)
                credit = credit + CLng(index.SubItems(3).Text)
            Next
        End With
        ' MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit))
        Label7.Text = CStr(credit)
        Label6.Text = CStr(debut)
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class