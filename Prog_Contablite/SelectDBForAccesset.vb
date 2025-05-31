Public Class SelectDBForAccesset
    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        OpenFileDialog1.ShowDialog()
        Label1.Text = OpenFileDialog1.FileName

    End Sub
End Class