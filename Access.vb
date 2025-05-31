Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
#Disable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Imports Io
#Enable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Public Class Access
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n2 As String
    Public n9 As String
#Disable Warning BC40004 ' variable 'Name' est en conflit avec property 'Name' dans le class 'Control' de base et doit être déclaré 'Shadows'.
    Public Name As String
#Enable Warning BC40004 ' variable 'Name' est en conflit avec property 'Name' dans le class 'Control' de base et doit être déclaré 'Shadows'.
    Sub Connecter()
        'Dim chaineDeConnexion As String
        'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_Soc;Integrated Security=True"
        'con = New SqlConnection(chaineDeConnexion)
        'Try
        '    con.Open()
        'Catch ex As Exception
        '    Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Console.WriteLine(ex.Message)
        'End Try
#Disable Warning BC42016 ' Implicit conversion
        If ConnecterHome() Then
#Enable Warning BC42016 ' Implicit conversion
            Try
                'MsgBox("success")
            Catch ex As Exception
                Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Console.WriteLine(ex.Message)
                con.Close()
            End Try
        End If
    End Sub

    Sub verif()
        Try


            'change the data fields names and table according to your database
            Dim req As String = "
select * from Futilisat where U_Nom = N'" + TextBox1.Text + "' and U_passe = N'" + TextBox3.Text + "' and U_soc = '" + ComboBox1.SelectedValue + "' "

            cmd = New SqlCommand(req, con)
            adapt1 = New SqlDataAdapter(cmd)

            Dim dt = New DataTable()
            adapt1.Fill(dt)


            If (dt.Rows.Count = 0) Then
                MessageBox.Show("Please inter the Correct username and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Clear all fields
                TextBox1.Text = ""
                TextBox3.Text = ""
            Else

                MessageBox.Show("Logged in successfully as " & TextBox1.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Name = TextBox1.Text
                n2 = ComboBox1.SelectedValue
                ' MessageBox.Show(n2)
                exec_proc.Show()



                Me.Hide()

                'Clear all fields
                TextBox1.Text = ""
                TextBox3.Text = ""
            End If
        Catch ex As Exception
            MessageBox.Show("acsess" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub
    Dim rs As New Form_Choix.Resizer
    Private Sub Access_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        'combobox1 Fsociete
        Connecter()
        Try
            cmd = New SqlCommand("select * from Fsociete ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "Fsociete")

            ComboBox1.DisplayMember = "S_Nom"
            ComboBox1.ValueMember = "S_code"
            ComboBox1.DataSource = ds.Tables("Fsociete")
            n2 = ComboBox1.SelectedValue

            ''''''cmd = New SqlCommand("select S_Nom from Fsociete where S_code = " & n2 & " ", con)
            ''''''Dim myreader As SqlDataReader
            ''''''myreader = cmd.ExecuteReader()
            ''''''myreader.Read()
            ''''''If myreader.HasRows Then
            n9 = ComboBox1.Text
            '''''End If
            '''''txtname.DataBindings.Add("Text", dt, "Firstname")
            'n9 = ds.Tables("Fsociete").Rows.ToString

            'MessageBox.Show(n2)
            'MessageBox.Show(n9)
            'MessageBox.Show()
        Catch ex As Exception
            MessageBox.Show("error de les combobox " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            con.Close()
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Connecter()
            If TextBox1.Text = "" Then
                MsgBox("enter username", MsgBoxStyle.Critical)

            ElseIf TextBox3.Text = "" Then
                MsgBox("enter password please...", MsgBoxStyle.Critical)
            End If
            verif()
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            con.Close()
            'Whether there is error or not. Close the connection.

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Form_Choix.Show()
        Me.Close()
    End Sub



    Private Sub Access_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class