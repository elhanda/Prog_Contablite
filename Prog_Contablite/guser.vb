Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class Guser

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As String
    Public oldValue As String
    Public newValue As String

    Sub aff()
        Try

            Dim searchQuery As String = "Select * from Futilisat"
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

            For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                Dim val As Integer = DataGridView1.Rows(i).Cells(7).Value


                If val = 1 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.CadetBlue
                End If
                If val = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("affiche data Of Futilisateur the Error Is  = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub add(priority, U_SOC, U_Nom, U_passe, U_Date, U_heure, U_connect)
        Try

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you reelly whant To add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then

                Try


                    '                Dim searchQuery As String = " INSERT INTO Futilisat values (N'" & priority & "','" & U_SOC & "',N'" & U_Nom & "',
                    '                                                  N'" & U_passe & "',N'" & U_Date & "','" & U_heure & "'," & U_connect & ")
                    '"
                    '                Dim command As New SqlCommand(searchQuery, con)

                    Dim searchQuery As String = "INSERT INTO Futilisat VALUES (@priority, @U_SOC, @U_Nom, @U_passe, @U_Date, @U_heure, @U_connect)"
                    Dim command As New SqlCommand(searchQuery, con)

                    ' Add parameters with correct data types
                    command.Parameters.AddWithValue("@priority", priority)
                    command.Parameters.AddWithValue("@U_SOC", U_SOC)
                    command.Parameters.AddWithValue("@U_Nom", U_Nom)
                    command.Parameters.AddWithValue("@U_passe", U_passe)
                    command.Parameters.AddWithValue("@U_Date", Convert.ToDateTime(U_Date)) ' Assuming U_Date is a string representing a date
                    command.Parameters.AddWithValue("@U_heure", U_heure) ' Assuming U_heure is a string representing time
                    command.Parameters.AddWithValue("@U_connect", U_connect)


                    Dim adapter As New SqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    'MsgBox(priority)
                    'MsgBox(U_SOC)
                    'MsgBox(U_Nom)
                    'MsgBox(U_passe)
                    'MsgBox(U_Date)
                    'MsgBox(U_heure)
                    'MsgBox(U_connect)



                    aff()
                Catch ex As Exception
                    MessageBox.Show("the user is used !!! please use another user    " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                'MessageBox.Show("insert succsess", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            GroupBox4.Visible = False
            GroupBox2.Visible = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox3.Enabled = False
            ComboBox2.Enabled = False
            ComboBox1.Enabled = False
        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub




    Sub modify(U_Nom, U_passe)
        Try

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to modify ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    Dim searchQuery As String = "update Futilisat set U_passe = N'" & U_passe & "'  where U_Nom = N'" & U_Nom & "'"
                    Dim command As New SqlCommand(searchQuery, con)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    aff()
                Catch ex As Exception
                    MessageBox.Show("erroe de la modification : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

                End Try


                MessageBox.Show("modify suv=csee", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            GroupBox4.Visible = False
            GroupBox2.Visible = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox3.Enabled = False
            ComboBox2.Enabled = False
            ComboBox1.Enabled = False
        Catch ex As SqlException

            If (ex.Number = 3609) Then
                MessageBox.Show("هذا القسم موجود" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Hand)

            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Sub sup(U_Nom)
        Try

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Dim searchQuery As String = " delete from Futilisat where U_Nom =N'" & U_Nom & "'"
                Dim command As New SqlCommand(searchQuery, con)
                Dim adapter As New SqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)
                aff()

                MessageBox.Show("delete suv=csee", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            GroupBox4.Visible = False
            GroupBox2.Visible = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox3.Enabled = False
            ComboBox2.Enabled = False
            ComboBox1.Enabled = False
        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If n1 = 1 Then
            '     MessageBox.Show("ajouter")

            add(ComboBox1.Text, ComboBox3.Text, TextBox2.Text, TextBox3.Text, DateTimePicker1.Text, "Null", ComboBox2.Text)

        End If
        If n1 = 2 Then
            '  MessageBox.Show("modifier")
            modify(TextBox2.Text, TextBox3.Text)

        End If
        If n1 = 3 Then
            '    MessageBox.Show("supprimer")
            sup(TextBox2.Text)

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        n1 = 1
        GroupBox4.Visible = True
        GroupBox2.Visible = False

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox3.Enabled = True
        ComboBox2.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        n1 = 2
        GroupBox4.Visible = True
        GroupBox2.Visible = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = True
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        n1 = 3
        GroupBox4.Visible = True
        GroupBox2.Visible = False
    End Sub



    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        GroupBox4.Visible = False
        GroupBox2.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False
    End Sub

    Private Sub Guser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter_soc()

        aff()
        GroupBox4.Visible = False
        GroupBox2.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox3.Enabled = False
        ComboBox2.Enabled = False
        ComboBox1.Enabled = False

        'combobox3.text  code de la sosiete 
        'combobox1 Fsociete


        cmd = New SqlCommand("select * from Fsociete ", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "Fsociete")

        ComboBox3.DisplayMember = "S_code"
        ComboBox3.ValueMember = "S_Nom"
        ComboBox3.DataSource = ds.Tables("Fsociete")






        'Dim value = (CType(sender, TextBox)).Text
        'newValue = value

        'Dim value = (CType(sender, TextBox)).Text
        'oldValue = value
        'TextBox3.Text = oldValue
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Me.Close()
        Form_Soc.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        TextBox2.Text = selecteRow.Cells(3).Value.ToString()
        TextBox3.Text = selecteRow.Cells(4).Value.ToString()
        ComboBox1.Text = selecteRow.Cells(1).Value.ToString()
        ComboBox2.Text = selecteRow.Cells(7).Value.ToString()
        ComboBox3.Text = selecteRow.Cells(2).Value.ToString()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        TextBox1.Text = ComboBox3.SelectedValue

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class