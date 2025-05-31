Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class selected_balence
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Dim value As Integer
    Private sum As Integer
    Private cred As Integer
    Private Id_Niv1 As New List(Of String)
    Private Id_Niveau As String
    Public Id_Niv12 As New List(Of Integer)
    Private Id_Niveau2 As String
    Private choix As Integer
    Private exer = exec_proc.n1
    Dim y As Integer
    Sub Connecter()
        If Connectersoc() Then
            Try
                'MsgBox("success")
            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    Sub aff_touto_seul()


        Try


            Dim req As String = "
 exec list " & exer & ""
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = Balance.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(3).ToString - AB(2).ToString)
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            'Grand_Livre.Show()

        Catch ex As Exception
            MessageBox.Show("error de totaux seul proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


    Sub affClasse(a, b, c, d, e)
        Try
            Dim req As String = "
      
exec [select_5_columns] 
" & a & "," & b & "," & c & "," & d & "," & e & "," & exer & ""
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            '   Balance.DataGridView1.DataSource = dt


            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = Balance.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(3).ToString - AB(2).ToString)

                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            '   ListBox1.Items.Add(Id_Niv1.ToString)
            'Grand_Livre.Show()
        Catch ex As Exception
            MessageBox.Show("error " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try




    End Sub
    Sub CompteBalance(CompteDebut, CompteCredit)
        Dim req As String = "
      


         exec BalanceCompte " & exer & "," & exer & "," & CompteDebut & "," & CompteCredit & ""
        cmd = New SqlCommand(req, con)
        Dim adapttr As SqlDataAdapter
        adapttr = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        adapttr.Fill(dt)

        Dim isi As ListViewItem
        For Each AB As DataRow In dt.Rows
            isi = Balance.ListView1.Items.Add(AB(0).ToString)
            isi.SubItems.Add(AB(1).ToString)
            isi.SubItems.Add(AB(2).ToString)
            isi.SubItems.Add(AB(3).ToString)
            isi.SubItems.Add(AB(2).ToString - AB(3).ToString)

            'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
            'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
            'Id_Niv12.Add(Id_Niveau2)
        Next
    End Sub
    Sub remplire()

        If choix = 1 Then

            affClasse(1, 0, 0, 0, 0)
        End If
        If choix = 2 Then
            '   Balance.ListBox1.Items.Add("   " & vbTab & " " & vbTab & " " & vbTab & "      les  2   Nombre          ")
            affClasse(0, 2, 0, 0, 0)
        End If
        If choix = 3 Then
            '   Balance.ListBox1.Items.Add("      " & vbTab & " " & vbTab & " " & vbTab & "   les 3 Nombre          ")
            affClasse(0, 0, 3, 0, 0)
        End If
        If choix = 4 Then
            '   Balance.ListBox1.Items.Add("    " & vbTab & " " & vbTab & " " & vbTab & "     les 4 Nombre          ")
            affClasse(0, 0, 0, 4, 0)
        End If
        If choix = 5 Then
            '     Balance.ListBox1.Items.Add("    " & vbTab & " " & vbTab & " " & vbTab & "     les 5 Nombre          ")
            affClasse(0, 0, 0, 0, 5)
        End If
    End Sub
    Dim rs As New Form_Choix.Resizer

    Private Sub selected_balence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()
        Balance.Label1.Text = exer
        Balance.Label3.Text = Access.n2
        rs.FindAllControls(Me)


        'CheckBox1.Enabled = False

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE ", con)
        adapt1 = New SqlDataAdapter(cmd)
        adapt1.Fill(ds, "FPlanComptable")
        ComboBox3.DisplayMember = "ER_COMPTE"
        ComboBox3.ValueMember = "ER_LIBELLE"
        ComboBox3.DataSource = ds.Tables("FPlanComptable")

        '   Grand_Livre.Label4.Text = ComboBox3.ValueMember
        'Grand_Livre.TextBox1.Text = ComboBox3.Text

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE    ", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(ds, "Comptable")
        ComboBox4.DisplayMember = "ER_COMPTE"
        ComboBox4.ValueMember = "ER_LIBELLE"
        ComboBox4.DataSource = ds.Tables("Comptable")

    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        CompteBalance(ComboBox3.Text, ComboBox4.Text)
        Balance.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = False Then
                'MessageBox.Show("select your totaux seul  ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'reaff_touto_seul()
            Else
                aff_touto_seul()
                Balance.Show()

            End If
        Catch ex As Exception
            MessageBox.Show("error de la selection your totaux seul" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

        Try
            If CheckBox3.Checked = False Then
                'MessageBox.Show(" select your number 1 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '   Balance.DataGridView1.DataSource = Nothing
                '   ListBox1.Items.Clear()

                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean  ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    deremplire()
                'End If

            Else
                choix = 1

                remplire()
                Balance.Show()

            End If
        Catch ex As Exception
            '    MessageBox.Show("check your number 1" + ex.Message)
        End Try
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

        Try
            If CheckBox4.Checked = False Then
                'MessageBox.Show("select your number 2 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''  Balance.DataGridView1.DataSource = Nothing
                ''    ListBox1.Items.Clear()

                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    '           ListBox1.Items.RemoveAt()
                '    'deremplire()
                'End If
            Else

                choix = 2
                remplire()
                Balance.Show()

            End If

        Catch ex As Exception
            '      MessageBox.Show("check your number 2" + ex.Message)
        End Try
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        Try
            If CheckBox5.Checked = False Then
                'MessageBox.Show(" select your number 3 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''  Balance.DataGridView1.DataSource = Nothing
                ''   ListBox1.Items.Clear()
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    'deremplire()
                'End If

            Else

                choix = 3
                remplire()
                Balance.Show()

            End If
        Catch ex As Exception
            '    MessageBox.Show("check your number 3" + ex.Message)
        End Try

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged


        Try
            If CheckBox6.Checked = False Then
                'MessageBox.Show(" select your number 4 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '   Balance.DataGridView1.DataSource = Nothing
                '   ListBox1.Items.Clear()
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    deremplire()
                'End If


            Else

                choix = 4
                remplire()
                Balance.Show()

            End If
        Catch ex As Exception
            '          MessageBox.Show("check your number 4" + ex.Message)
        End Try
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        Try
            If CheckBox7.Checked = False Then
                'MessageBox.Show("  select your number 5 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''  Balance.DataGridView1.DataSource = Nothing
                ''  ListBox1.Items.Clear()
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    deremplire()
                'End If

            Else

                choix = 5
                remplire()
                Balance.Show()

            End If
        Catch ex As Exception
            '         MessageBox.Show("check your number 5" + ex.Message)
        End Try
    End Sub

    Private Sub Button6_Enter(sender As Object, e As EventArgs) Handles Button6.Enter
        'Balance.ListBox1.Items.Add(" ER_CPARTIE " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & " nombre total ")
    End Sub

    Private Sub selected_balence_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)

    End Sub
End Class