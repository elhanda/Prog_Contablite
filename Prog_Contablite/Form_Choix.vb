


Public Class Form_Choix
    Public n2 As String
    Public n9 As String
    Public zuser As String
    Public zpass As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim choix = ComboBox1.SelectedIndex
        If choix = 0 Then
            Access.Show()
        Else
            If choix = 1 Then
                Form_Soc.Show()

            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Form_Choix_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.SelectedIndex = 0
        Me.Left = (Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

'Private Sub exec_proc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    '    If (Me.Width = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width) And
    '    (Me.Height = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height) Then Exit Sub
    '    'ce test est pour éviter que ton événement ne se déclenche une seconde fois ensuite tu peux la redimensionner
    '    Me.Width = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width
    '    Me.Height = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height
    '    Me.Location = New Point(0, 0)
    'End Sub
End Class
