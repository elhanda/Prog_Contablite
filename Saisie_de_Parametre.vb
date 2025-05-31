Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb




Public Class Saisie_de_Parametre

    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter




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



        'Try
        '    If ConnecterHome() = True Then
        '        Try
        '            con.Open()
        '            'MsgBox("success")
        '        Catch ex As Exception
        '            'MsgBox("Faild" + ex.Message)
        '            con.Close()


        '        End Try
        '    End If
        'Catch ex As Exception
        '    'MsgBox("faild")
        '    con.Close()
        'Finally
        '    con.Close()

        'End Try
    End Sub

    Sub Aff()

        Try


            Dim sql As String = "select * from Saisie_de_Parametre_Table "

            cmd = New SqlCommand(sql, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)


            TextBox1.Text = dt.Rows(0)(0).ToString()
            TextBox2.Text = dt.Rows(0)(1).ToString()
            TextBox3.Text = dt.Rows(0)(2).ToString()
            TextBox4.Text = dt.Rows(0)(3).ToString()
            TextBox5.Text = dt.Rows(0)(4).ToString()
            TextBox6.Text = dt.Rows(0)(5).ToString()
            TextBox7.Text = dt.Rows(0)(6).ToString()
            TextBox8.Text = dt.Rows(0)(7).ToString()
            TextBox9.Text = dt.Rows(0)(8).ToString()
            TextBox10.Text = dt.Rows(0)(9).ToString()
            TextBox11.Text = dt.Rows(0)(10).ToString()
            TextBox12.Text = dt.Rows(0)(11).ToString()
            TextBox13.Text = dt.Rows(0)(12).ToString()
            TextBox14.Text = dt.Rows(0)(13).ToString()
            TextBox15.Text = dt.Rows(0)(14).ToString()
            TextBox16.Text = dt.Rows(0)(15).ToString()
            TextBox17.Text = dt.Rows(0)(16).ToString()
            TextBox18.Text = dt.Rows(0)(17).ToString()
            TextBox19.Text = dt.Rows(0)(18).ToString()


        Catch ex As Exception
            MsgBox("faild" + ex.Message)
        End Try



    End Sub













    Private Sub Saisie_de_Parametre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connecter()
            Aff()
        Catch ex As Exception
            MsgBox("Faild load " + ex.Message)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form_Soc.Show()

    End Sub
End Class