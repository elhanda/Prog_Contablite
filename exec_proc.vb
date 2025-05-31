Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
#Disable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Imports Io
#Enable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Public Class exec_proc

    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As String
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
    Sub ver(a, Code_Soc, Date_Debut, Date_Fin)
        Try
            Dim req As String = "
select *  from Periode_Soc  
where Code_Soc = N'" + Access.n2 + "' and Exercice = '" & a & "' "

            cmd = New SqlCommand(req, con)
            adapt1 = New SqlDataAdapter(cmd)

            Dim dt = New DataTable()
            adapt1.Fill(dt)
            If (dt.Rows.Count = 0) Then
                Dim dialog As DialogResult
                dialog = MessageBox.Show("exercice n'est pas incéré voulé vous le cree ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                If dialog = DialogResult.OK Then
                    DateTimePicker1.Enabled = True
                    DateTimePicker2.Enabled = True
                    Button3.Visible = True
                    Button4.Visible = True
                    Button1.Visible = False
                    Button2.Visible = False
                    ' id_period ,


                Else
                    'Clear all fields
                    DateTimePicker1.Text = ""
                    DateTimePicker2.Text = ""
                End If

            Else

                n1 = TextBox1.Text
                Me.Hide()
                Form1.Show()
            End If
        Catch ex As Exception
            MessageBox.Show("home main = " + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try


        'change the data fields names and table according to your database

    End Sub
    Dim rs As New Form_Choix.Resizer
    Private Sub exec_proc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Try
            Connecter()
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            Button3.Visible = False
            Button4.Visible = False
            DateTimePicker3.Enabled = False

        Catch ex As Exception
            MessageBox.Show("form load " + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

        ''textbox1.text = exercice de la societe Fsociete
        'Connecter()

        cmd = New SqlCommand("Select Exercice  from Periode_Soc  
where Code_Soc = N'" + Access.n2 + "'", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "Fsociete")
        For Each dr As DataRow In ds.Tables("Fsociete").Rows

            TextBox1.Text = dr("Exercice").ToString()

        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Try
            Connecter()
            ver(TextBox1.Text, Access.n2, DateTimePicker1.Text, DateTimePicker2.Text)
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Access.Show()

    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            If TextBox1.Text = "" Then
                DateTimePicker1.Value = Now
                DateTimePicker2.Value = Now
            Else

                cmd = New SqlCommand("
Select *  from Periode_Soc  
where Code_Soc = N'" + Access.n2 + "' and Exercice = '" & TextBox1.Text & "' ", con)
                adapt = New SqlDataAdapter(cmd)
                adapt.Fill(ds, "FJol")
                For Each dr As DataRow In ds.Tables("FJol").Rows

                    DateTimePicker1.Text = dr("Date_Debut").ToString()
                    DateTimePicker2.Text = dr("Date_Fin").ToString()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("textbox1  " + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim req3 = "insert into Periode_Soc values('" & Access.n2 & "','" + TextBox1.Text + "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',' " & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "') "
            cmd = New SqlCommand(req3, con)
            adapt3 = New SqlDataAdapter(cmd)

            Dim dtt = New DataTable()
            adapt3.Fill(dtt)
            MessageBox.Show(" Insert avec succsess", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            Button3.Visible = False
            Button4.Visible = False
            Button1.Visible = True
            Button2.Visible = True
        Catch ex As Exception
            MessageBox.Show(" Insert avec error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MessageBox.Show(" annule", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        Button3.Visible = True
        Button4.Visible = True
        Button1.Visible = False
        Button2.Visible = False
    End Sub

    Private Sub TextBox1_TextAlignChanged(sender As Object, e As EventArgs) Handles TextBox1.TextAlignChanged

    End Sub

    Private Sub exec_proc_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    '    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
    '        Try

    '            cmd = New SqlCommand("
    'Select *  from Periode_Soc  
    'where Code_Soc = N'" + Access.n2 + "' and Exercice = '" & TextBox1.Text & "' ", con)
    '            adapt = New SqlDataAdapter(cmd)
    '            adapt.Fill(ds, "FJol")
    '            For Each dr As DataRow In ds.Tables("FJol").Rows

    '                DateTimePicker1.Text = dr("Date_Debut").ToString()
    '                DateTimePicker2.Text = dr("Date_Fin").ToString()
    '            Next
    '        Catch ex As Exception
    '            MessageBox.Show("textbox1_load  " + ex.Message)
    '        End Try

    '    End Sub
End Class