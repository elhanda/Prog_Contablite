Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System
Public Class Access
    Public n2 As String
    Public nom_Soc As String
    Public exercice As String
    Public adr1_soc As String
    Public PathCryst As String
    Public n9 As String
    Public ok As Integer
    'Public con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim ds1 As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public Name1 As String
    Public chaineDeConnexion As String
    Public chaineDeConnexion2 As String


    Sub verif()
        Try

            Dim req As String = "Select * from Futilisat where U_Nom = N'" + TextBox1.Text + "' and U_passe = N'" + TextBox3.Text + "' and U_soc = '" + n2 + "' "
            cmd = New SqlCommand(req, con)
            adapt1 = New SqlDataAdapter(cmd)

            Dim dt = New DataTable()
            adapt1.Fill(dt)
            Ok = 0
            If (dt.Rows.Count > 0) Then

                Name = TextBox1.Text

                ok = 1

            Else

                MessageBox.Show("Please inter the Correct username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As Exception
            MessageBox.Show("acsess" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Module1.connecter_soc()
            ' On suppose que Module1.connecter_soc()() a été appelé avant et con est initialisé
            'If con Is Nothing OrElse con.State <> ConnectionState.Open Then
            '    MessageBox.Show("La connexion n'est pas ouverte. Appelle Module1.connecter_soc()() avant.")
            '    Return
            'End If

            Dim cmd As New SqlCommand("SELECT s_code FROM fsociete", con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            ComboBox1.Items.Clear()
            While reader.Read()
                ComboBox1.Items.Add(reader("s_code").ToString())
            End While

            reader.Close()
            If ComboBox1.Items.Count > 0 Then
                ComboBox1.SelectedIndex = 0
                n2 = ComboBox1.Items(0).ToString()
            Else
                MessageBox.Show("ComboBox1 est vide, impossible d'assigner n2.")
            End If


        Catch ex As Exception
            MessageBox.Show("Erreur remplissage ComboBox : " & ex.Message)
        End Try




    End Sub
    Public Sub rechercher_societe()



        Try
            If con Is Nothing OrElse con.State <> ConnectionState.Open Then
                MessageBox.Show("La connexion n'est pas ouverte. Appelle connecter_soc() avant.")
                Return
            End If

            Dim cmd As New SqlCommand("SELECT * FROM fsociete WHERE s_code = @code", con)
            cmd.Parameters.AddWithValue("@code", n2)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            'Dim PathCryst As String = If(pathValue Is DBNull.Value OrElse pathValue.ToString() = "", "c:\Crystal_Report\", pathValue.ToString())
            If reader.Read() Then
                ' Stocker dans variables globales

                PathCryst = IIf(reader("s_PathCryst") Is DBNull.Value OrElse reader("s_PathCryst").ToString() = "", "c:\Crystal_Report\", reader("s_PathCryst").ToString())
                nom_Soc = reader("s_nom").ToString()
                exercice = reader("s_excerc").ToString()
                adr1_soc = reader("s_adr1").ToString()
                ' PathCryst = If(reader("s_pathCryst").ToString() Is DBNull.Value OrElse reader("s_pathCryst").ToString() = "", "c:\Crystal_Report\", reader("s_pathCryst").ToString())
                n9 = exercice
            Else
                PathCryst = "c:\crystalReport\"
                MessageBox.Show("Aucune société trouvée pour le code : " & n2)
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Erreur recherche société : " & ex.Message)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Module1.connecter_soc()
            If TextBox1.Text = "" Then
                MsgBox("enter username", MsgBoxStyle.Critical)

            ElseIf TextBox3.Text = "" Then
                MsgBox("enter password please...", MsgBoxStyle.Critical)
            End If
            verif()
            If ok = 1 Then
                exec_proc.Show()
            End If
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            con.Close()
            'Whether there is error or not. Close the connection.

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

        Form_Choix.Show()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        n2 = ComboBox1.SelectedItem.ToString().Trim() ' Récupérer la valeur sélectionnée
        rechercher_societe()


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    'Public Sub RecupererSocieteInfo()
    '    Try
    '        Module1.Module1.connecter()

    '        ' 🔎 On prend le code sélectionné dans le ComboBox
    '        Dim codeSociete As String = n2 ' ComboBox1.Text.Trim()

    '        ' 💬 Requête paramétrée = sécurité + propreté
    '        Dim sql As String = "SELECT s_nom, s_repCryst FROM FSociete WHERE s_code = @code"
    '        Dim cmd As New SqlCommand(sql, con)
    '        cmd.Parameters.AddWithValue("@code", codeSociete)

    '        Dim reader As SqlDataReader = cmd.ExecuteReader()

    '        If reader.Read() Then
    '            'Dim nomSociete As String = reader("s_nom").ToString()
    '            'Dim repertoireCrystal As String = reader("s_repCryst").ToString()

    '            'MessageBox.Show("✅ Société : " & nomSociete & vbCrLf & "📁 Répertoire : " & repertoireCrystal, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            ' Stocker dans Access si tu veux
    '            If reader.Read() Then
    '                nom_soc = reader("s_nom").ToString()  ' Récupérer s_nom
    '                adr1_soc = reader("s_adr1").ToString() ' Récupérer s_adr
    '                PathCryst = reader("s_PathCrystl").ToString() ' Récupérer path crystal report
    '            Else
    '                nom_soc = ""
    '                adr1_soc = ""
    '                PathCryst = "c:\crystalReport\"
    '            End If
    '        Else
    '            MessageBox.Show("🚫 Aucune société trouvée avec ce code.")
    '        End If

    '        reader.Close()

    '    Catch ex As Exception
    '        MessageBox.Show("❌ Erreur : " & ex.Message)
    '    Finally
    '        If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then con.Close()
    '    End Try
    'End Sub





End Class