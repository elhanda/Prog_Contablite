Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class LoginAdministrateur
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public NSoc As String
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
    'Sub ajj(Username, Password)
    '    Try
    '        Dim dialog As DialogResult
    '        dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '        If dialog = DialogResult.Yes Then
    '            Dim req As String = " 

    '                insert into FJournal values(N'" & Username & "',N'" & Password & "')"
    '            cmd = New SqlCommand(req, con)
    '            Dim adapt3 As SqlDataAdapter
    '            adapt3 = New SqlDataAdapter(cmd)
    '            Dim dt = New DataTable()
    '            adapt3.Fill(dt)

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("error de ajoutement  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally

    '    End Try
    'End Sub
    Sub verif(Username, Password, ComboBox1)
        Try
            Dim req1 As String = " 
select * from Futilisat where U_Nom = N'" + Username + "' and U_passe = N'" + Password + "' and U_soc = '" + ComboBox1 + "' AND U_priorit = 'Administrateur'"
            cmd = New SqlCommand(req1, con)

            adapt1 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapt1.Fill(dt)
            If (dt.Rows.Count = 0) Then
                MessageBox.Show("Please inter the Correct username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Clear all fields
                TextBox1.Text = ""
                TextBox2.Text = ""
            Else

                MessageBox.Show("Logged in successfully as " & TextBox1.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Name = TextBox1.Text

                'MessageBox.Show(Name)




                Me.Close()
                Form_Soc.Show()


                'Clear all fields
                TextBox1.Text = ""
                TextBox2.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("Error in the database   " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub LoginAdministrateur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connecter()

            cmd = New SqlCommand("select * from Fsociete ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "Fsociete")

            ComboBox1.DisplayMember = "S_Nom"
            ComboBox1.ValueMember = "S_code"
            ComboBox1.DataSource = ds.Tables("Fsociete")

            NSoc = ComboBox1.SelectedValue
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            con.Close()
            'Whether there is error or not. Close the connection.

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Connecter()
            If TextBox1.Text = "" Then
                MsgBox("enter username", MsgBoxStyle.Critical)

            ElseIf TextBox2.Text = "" Then
                MsgBox("enter password please...", MsgBoxStyle.Critical)
            End If
            verif(TextBox1.Text, TextBox2.Text, ComboBox1.SelectedValue)

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
End Class