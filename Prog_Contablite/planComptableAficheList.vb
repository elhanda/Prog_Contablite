Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class planComptableAficheList
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Private n11 As Integer
    Sub Connecter()
        If ConnecterHome() Then
            Try
                'MsgBox("success")
            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    Sub aff()
        Try
            Dim searchQuery As String = "


select P_Code as 'CODE',P_Libelle AS 'LIBELLE',P_CompteDebut as 'CompteDebut',P_CompteFin as 'CompteFin',P_texte as 'Text' from Fparam_Base"
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As Exception
            MessageBox.Show("error de l'affichage" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub planComptableAficheList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()
        aff()
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        'Dim form As New ETATConstruire

        n11 = ETATConstruire.n1

        'MsgBox(DataGridView1.CurrentRow.Cells(0).Value.ToString)
        'MsgBox(n11)
        If n11 = 1 Then
            'MsgBox()
            'MsgBox(DataGridView1.CurrentRow.Cells(1).Value.ToString)
            ETATConstruire.TextBox4.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
            '  ETATConstruire.TextBox8.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString

            ETATConstruire.Show()
            Me.Close()
        End If
        If n11 = 2 Then
            'MsgBox(DataGridView1.CurrentRow.Cells(0).Value.ToString)
            'MsgBox(DataGridView1.CurrentRow.Cells(1).Value.ToString)
            ETATConstruire.TextBox7.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
            '    ETATConstruire.TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString

            ETATConstruire.Show()
            Me.Close()
        End If

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    End Sub
End Class