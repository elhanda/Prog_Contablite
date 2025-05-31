Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class ParametrageCompte

    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Private n1 As Integer
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
            Dim searchQuery As String = "select * from Fparam_Base"
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As Exception
            MessageBox.Show("error de l'affichage" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub add(TextBox1, TextBox2, ComboBox1, ComboBox2, TextBox3)
        Try
            For Each c As Control In GroupBox2.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "info", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Return
                        Exit For
                    End If
                End If
            Next
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to insert ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    '    '''''''''''''''''''' insert the data  ''''''''''''


                    Connecter()
                    Dim req As String = "insert into Fparam_Base values('" & TextBox1 & "','" & TextBox2 & "','" & ComboBox1 & "','" & ComboBox2 & "','" & TextBox3 & "')"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show("error in requette insert " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            MessageBox.Show("insert successfulle", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Visible = False
            Button2.Visible = False
            Button5.Visible = True
            Button6.Visible = True
            Button7.Visible = True
            Button8.Visible = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
        Catch ex As Exception

        End Try

    End Sub
    Sub modif(TextBox1, TextBox2, ComboBox1, ComboBox2, TextBox3)
        Try
            For Each c As Control In GroupBox2.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Return
                        Exit For
                    End If
                End If
            Next
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to modify ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    '    '''''''''''''''''''' update the data  ''''''''''''


                    Connecter()
                    Dim req As String = "update Fparam_Base set P_Libelle = '" & TextBox2 & "' ,P_CompteDebut='" & ComboBox1 & "',P_CompteFin='" & ComboBox2 & "',P_texte='" & TextBox3 & "'
where P_Code='" & TextBox1 & "'"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show("error in requette update " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            MessageBox.Show("update successfulle", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Visible = False
            Button2.Visible = False
            Button5.Visible = True
            Button6.Visible = True
            Button7.Visible = True
            Button8.Visible = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
        Catch ex As Exception

        End Try

    End Sub
    Sub sup(TextBox1)
        Try
            For Each c As Control In GroupBox2.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Return
                        Exit For
                    End If
                End If
            Next
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to delete ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    '    '''''''''''''''''''' dalete the data  ''''''''''''


                    Connecter()
                    Dim req As String = "delete from Fparam_Base where P_Code='" & TextBox1 & "'"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show("error in requette delete " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
            MessageBox.Show("delete successfulle", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Visible = False
            Button2.Visible = False
            Button5.Visible = True
            Button6.Visible = True
            Button7.Visible = True
            Button8.Visible = True
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form_Soc.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        n1 = 1
        Button1.Visible = True
        Button2.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
    End Sub
    Dim rs As New Form_Choix.Resizer

    Private Sub ParametrageCompte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)

        Connecter()
        aff()
        Try
            'combobox1 Code Journal :
            cmd = New SqlCommand("select * from FPlanComptable", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "Comptable")
            ComboBox1.DisplayMember = "C_CODE"
            ComboBox1.ValueMember = "J_LIBELLE "
            ComboBox1.DataSource = ds.Tables("Comptable")
            Dim dadadapt = New SqlDataAdapter(cmd)
            dadadapt.Fill(ds, "FPlanComptable")
            ComboBox2.DisplayMember = "C_CODE"
            ComboBox2.ValueMember = "C_LIBELLE"
            ComboBox2.DataSource = ds.Tables("FPlanComptable")
        Catch ex As Exception

        End Try
        Button1.Visible = False
        Button2.Visible = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        n1 = 2

        Button1.Visible = True
        Button2.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        n1 = 3
        Button1.Visible = True
        Button2.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (n1 = 1) Then
            '   MessageBox.Show("ajouter")
            add(TextBox1.Text, TextBox2.Text, ComboBox1.Text, ComboBox2.Text, TextBox3.Text)
        End If
        If (n1 = 2) Then
            '  MessageBox.Show("modifier")
            modif(TextBox1.Text, TextBox2.Text, ComboBox1.Text, ComboBox2.Text, TextBox3.Text)
        End If
        If (n1 = 3) Then
            '   MessageBox.Show("supprimer")
            sup(TextBox1.Text)
        End If



    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        'Label19
        TextBox1.Text = selecteRow.Cells(0).Value.ToString()
        TextBox2.Text = selecteRow.Cells(1).Value.ToString()
        TextBox3.Text = selecteRow.Cells(4).Value.ToString()
        ComboBox1.Text = selecteRow.Cells(2).Value.ToString()
        ComboBox2.Text = selecteRow.Cells(3).Value.ToString()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("anulation", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Button1.Visible = False
        Button2.Visible = False
        Button5.Visible = True
        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
    End Sub

    Private Sub ParametrageCompte_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)

    End Sub
End Class