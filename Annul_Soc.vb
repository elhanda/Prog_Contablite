Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
#Disable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Imports Io
#Enable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.

Public Class Form3
    Dim rs As New Form_Choix.Resizer
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As String
    Sub Connecter()
        'Dim chaineDeConnexion As String
        'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_Soc;Integrated Security=True"
        'con = New SqlConnection(chaineDeConnexion)
        If ConnecterHome() Then


            Try
                con.Open()
            Catch ex As Exception
                MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End If
    End Sub
    Sub ver(code)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If dialog = DialogResult.Yes Then
                Dim searchQuery As String = "  EXEC DELETE_DB '" & code & "'"
                Dim command As New SqlCommand(searchQuery, con)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                MessageBox.Show("DATABASE DELITED avec sucsses", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("error de la delete DE DATABASE " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()
        rs.FindAllControls(Me)
        'combobox1 Fsociete


        Try


            cmd = New SqlCommand("select * from Fsociete ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "Fsociete")

            ComboBox2.DisplayMember = "S_code"
            ComboBox2.ValueMember = "S_Nom"
            ComboBox2.DataSource = ds.Tables("Fsociete")
        Catch ex As Exception
            MessageBox.Show("error de les combobox " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

    End Sub

    '    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
    '        cmd = New SqlCommand("
    'select *  from Fsociete where S_code = '" & ComboBox2.Text & "' ", con)
    '        adapt = New SqlDataAdapter(cmd)
    '        adapt.Fill(ds, "FJol")
    '        For Each dr As DataRow In ds.Tables("FJol").Rows
    '            TextBox2.Text = dr("S_Nom").ToString()
    '        Next
    '    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox2.Text = ComboBox2.SelectedValue
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ver(ComboBox2.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form_Soc.Show()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form3_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class