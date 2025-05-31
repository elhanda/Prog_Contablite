Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO


Public Class Annuler_Exercice
    'Dim con As SqlConnection
    'Dim con1 As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As String
    'Public Sub Connecter_soc()
    '    Dim chaineDeConnexion As String
    '    'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABILITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF;Integrated Security=True"
    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_SOC.MDF;Integrated Security=True"

    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Sub Connecter(cod As String)
    '    Dim chaineDeConnexion As String
    '    'If cod = "001" Then
    '    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_001.MDF;Integrated Security=True"
    '    'Else
    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_" + cod + ";Integrated Security=True"
    '    'End If
    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '    Catch ex As Exception
    '        MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    Sub ver(code)

        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If dialog = DialogResult.Yes Then
                Try
                    'Au niveau des periodes 
                    Dim searchQuery As String = "DELETE FROM Periode_Soc  WHERE code_soc= '" & ComboBox2.Text & "' and exercice = '" & ComboBox1.Text & "'  "
                    Dim command As New SqlCommand(searchQuery, con)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    MessageBox.Show("Exercice supprimé avec sucsses au niveau des periodes", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch
                    MessageBox.Show("error au niveau des periodes ")
                End Try
                Try
                    'Dim searchQuery As String = "  EXEC DELETE_EXERCICE '" & code & "'"
                    'Au niveau des ecritures
                    Dim searchQuery As String = "DELETE FROM Fecriture  WHERE  er_exerc = '" & ComboBox1.Text & "'  "
                    Dim command As New SqlCommand(searchQuery, con)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    MessageBox.Show("Exercice supprimé avec sucsses au niveau des ecritures", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch
                    MessageBox.Show("error au niveau des ecritures ")
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("error de la delete DE DATABASE " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Annuler_Exercice_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter_soc()



    End Sub


    'Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
    '    TextBox2.Text = ComboBox2.SelectedItem(1)
    '    ChargerComboBox1()

    'End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ver(ComboBox2.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Close()
        Form_Soc.Show()
    End Sub

    Private Sub Annul_Exercice_Enter(sender As Object, e As EventArgs) Handles Annul_Exercice.Enter

        Try
            cmd = New SqlCommand("Select s_code,s_nom  from fsociete ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "fsociete")
            ComboBox2.DisplayMember = "s_code"
            ComboBox2.ValueMember = "scode "
            ComboBox2.DataSource = ds.Tables("fsociete")


        Catch ex As Exception
            MessageBox.Show("load error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
        ComboBox2.Text = ComboBox2.SelectedItem(0)
        TextBox2.Text = ComboBox2.SelectedItem(1)




    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        TextBox2.Text = ComboBox2.SelectedItem(1)

        ChargerComboBox2()
        ChargerComboBox1()

    End Sub


    Private Sub ChargerComboBox1()
        ComboBox1.DataSource = Nothing ' Réinitialiser la source de données à Nothing
        ComboBox1.Items.Clear() ' Effacer la liste des éléments

        ' Assurez-vous qu'un élément est sélectionné dans ComboBox2
        If ComboBox2.SelectedItem IsNot Nothing Then
            'Dim code As String = ComboBox2.SelectedItem.ToString()

            Try
                'If con.State = ConnectionState.Open Then
                '    con.Close()
                'End If

                Module1.connecter()
                Dim dt As New DataTable()
                Using cmd As New SqlCommand("SELECT code_soc, exercice FROM Periode_Soc ", con)
                    Using adapt1 As New SqlDataAdapter(cmd)
                        adapt1.Fill(dt)
                    End Using
                End Using

                ComboBox1.DisplayMember = "exercice"
                ComboBox1.ValueMember = "code_soc"
                ComboBox1.DataSource = dt
            Catch ex As Exception
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Assurez-vous de fermer la connexion après utilisation
                con.Close()
            End Try
        End If
    End Sub


    Private Sub ChargerComboBox2()
        'Try
        '    cmd = New SqlCommand("Select s_code,s_nom  from fsociete ", con)
        '    adapt = New SqlDataAdapter(cmd)
        '    adapt.Fill(ds, "fsociete")
        '    ComboBox2.DisplayMember = "s_code"
        '    ComboBox2.ValueMember = "scode "
        '    ComboBox2.DataSource = ds.Tables("fsociete")


        'Catch ex As Exception
        '    MessageBox.Show("load error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        'End Try
        'ComboBox2.Text = ComboBox2.SelectedItem(0)
        'TextBox2.Text = ComboBox2.SelectedItem(1)

    End Sub
End Class