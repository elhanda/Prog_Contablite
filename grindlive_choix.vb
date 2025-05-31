Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class grindlive_choix
    'Dim con = ConnectionProget1.Connectersoc()
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
    Private Id_Niv12 As New List(Of String)
    Private Id_Niveau2 As String
    Private choix As Integer
    Private exer = exec_proc.n1
    Dim y As Integer
    Sub Connecter()
        'If Connectersoc() Then


        'MsgBox("success")
        Try
            If Connectersoc() = True Then
                Try
                    con.Open()
                Catch ex As Exception
                    MsgBox("faild GrandLivre = " + ex.Message)
                    con.Close()
                End Try
            End If
        Catch ex As Exception
            MsgBox("Faild GrandLivre All = " + ex.Message)
        Finally
            con.Close()

        End Try


        'End If
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
                isi = Grand_Livre.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add("null")
                isi.SubItems.Add("null")
                isi.SubItems.Add("null")
                isi.SubItems.Add("null")
                isi.SubItems.Add("null")
                isi.SubItems.Add("null")
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            Grand_Livre.Show()

        Catch ex As Exception
            MessageBox.Show("error de totaux seul proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Sub reaff_touto_seul()
        Try
            Dim req As String = "
 exec list " & exer & " "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = Grand_Livre.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            Grand_Livre.Show()
        Catch ex As Exception
            MessageBox.Show("error de totaux seul proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
        End Try
    End Sub
    Sub aff_moix(a, b, datedeb, datefin)
        Try
            Dim req As String = "
[TotalGrandLivre_month] " & a & "," & b & ", " & exer & "," & datedeb & " , " & datefin & ""
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = Grand_Livre.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            Grand_Livre.Show()

        Catch ex As Exception
            MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
        End Try
    End Sub
    Sub reaff_moix(a, b)
        Try
            Dim req As String = "
[list_month] " & a & "," & b & "," & exer & " "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            'GrindLivre.ListBox1.Items.Remove(" ER_CPARTIE " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & " nombre total ")
            'For Each AB As DataRow In dt.Rows
            '    GrindLivre.ListBox1.Items.Remove(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
            '    'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
            '    'Id_Niv12.Remove(Id_Niveau2)
            'Next
        Catch ex As Exception
            MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
        End Try
    End Sub
    Dim rs As New Form_Choix.Resizer
    Private Sub grindlive_choix_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)

        Connecter()
        Grand_Livre.Label11.Text = exec_proc.n1
        Grand_Livre.Label9.Text = Access.n2
        Grand_Livre.Label14.Text = Access.n9
        CheckBox1.Enabled = False

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE ", con)
        adapt1 = New SqlDataAdapter(cmd)
        adapt1.Fill(ds, "FPlanComptable")
        ComboBox3.DisplayMember = "ER_COMPTE"
        ComboBox3.ValueMember = "ER_COMPTE"
        ComboBox3.DataSource = ds.Tables("FPlanComptable")

        Grand_Livre.Label4.Text = ComboBox3.ValueMember
        'Grand_Livre.TextBox1.Text = ComboBox3.Text

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE ", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(ds, "Comptable")
        ComboBox4.DisplayMember = "ER_COMPTE"
        ComboBox4.ValueMember = "ER_COMPTE"
        ComboBox4.DataSource = ds.Tables("Comptable")

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Try
            If CheckBox2.Checked = False Then
                ' MessageBox.Show("select your totaux seul  ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ' reaff_touto_seul()
            Else
                aff_touto_seul()
            End If
        Catch ex As Exception
            MessageBox.Show("error de la selection your totaux seul" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try
            If CheckBox1.Checked = False Then
                ' MessageBox.Show("select your totaux month  ", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '  aff_moix(ComboBox1.SelectedIndex + 1, ComboBox2.SelectedIndex + 1)
            Else
                aff_moix(ComboBox3.Text, ComboBox4.Text, ComboBox1.SelectedIndex + 1, ComboBox2.SelectedIndex + 1)
            End If
        Catch ex As Exception
            MessageBox.Show("error de la selection your totaux seul" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
        End Try
    End Sub
    Sub aff(a, b, c, d)



        'Try
        '            Dim req As String = "  EcritureCompte " & c & ",  " & d & "," & exer & "," & a & "," & b & "

        '"
        '            cmd = New SqlCommand(req, con)
        '            Dim adapttr As SqlDataAdapter
        '            adapttr = New SqlDataAdapter(cmd)
        '            Dim dt = New DataTable()
        '            adapttr.Fill(dt)
        '            Dim isi As ListViewItem


        '            Grand_Livre.ComboBox1.DisplayMember = "ER_COMPTE"
        '            Grand_Livre.ComboBox1.ValueMember = "ER_COMPTE"
        '            Grand_Livre.ComboBox1.DataSource = dt

        '            'For Each AB As DataRow In dt.Rows
        '            '    'Form5.DataGridView1.Rows.Add()
        '            '    'With Form5.DataGridView1.Rows(90000)
        '            '    '    .Cells("Date").Value = AB(0).ToString
        '            '    '    .Cells("Jnl").Value = (AB(1).ToString)
        '            '    '    .Cells("Fol").Value = (AB(2).ToString)
        '            '    '    .Cells("Lign").Value = (AB(3).ToString)
        '            '    '    .Cells("Centre Partie").Value = (AB(4).ToString)
        '            '    '    .Cells("Piece").Value = (AB(5).ToString)
        '            '    '    .Cells("Libelle").Value = (AB(6).ToString)
        '            '    '    .Cells("Debut").Value = (AB(7).ToString)
        '            '    '    .Cells("Credit").Value = (AB(8).ToString)
        '            '    'End With
        '            '    isi = Grand_Livre.ListView1.Items.Add(AB(0).ToString)
        '            '    isi.SubItems.Add(AB(1).ToString)
        '            '    isi.SubItems.Add(AB(2).ToString)
        '            '    isi.SubItems.Add(AB(3).ToString)
        '            '    isi.SubItems.Add(AB(4).ToString)
        '            '    isi.SubItems.Add(AB(5).ToString)
        '            '    isi.SubItems.Add(AB(6).ToString)
        '            '    isi.SubItems.Add(AB(7).ToString)
        '            '    isi.SubItems.Add(AB(8).ToString)

        '            '    'Grand_Livre.ListView1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
        '            '    'Id_Niveau2 = AB(0) & "  | " & AB(1).ToString() & "  | " & AB(2).ToString() & "  | " & AB(3).ToString() & "  | " & AB(4).ToString() & "  | " & AB(5).ToString() & "  | " & AB(6).ToString() & "  | " & AB(7).ToString() & "  | " & AB(8).ToString()
        '            '    'Id_Niv12.Add(Id_Niveau2)
        '            'Next

        '        Catch ex As Exception
        '            MessageBox.Show("error de affiche proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        End Try





        '        Select E.ER_JOUR,[ER_MOIS],[ER_AN],[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE],[J_LIBELLE],[J_COMPTE] from FJournal F join FEcriture E On F.J_CODE = E.ER_JOURNL
        'where E.ER_CPARTIE between  11111111 And 33333333
        'And  ER_MOIS between  1 And 12 
        'And ER_AN = 2015




    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If CheckBox1.Checked = False And CheckBox2.Checked = False Then
            'MessageBox.Show(ComboBox3.Text)
            'MessageBox.Show(ComboBox4.Text)

            'Try
            '                Dim req As String = "
            'select ER_COMPTE from [ECRIT001] where
            ' ER_COMPTE between  '" & ComboBox3.Text & "%'  and   '" & ComboBox4.Text & "%' 
            'and  ER_MOIS between   " & ComboBox1.SelectedIndex + 1 & "  and " & ComboBox2.SelectedIndex + 1 & "
            'and ER_AN =  " & exer & "
            ' group by ER_COMPTE

            '"
            '                cmd = New SqlCommand(req, con)
            '                Dim adapttr As SqlDataAdapter
            '                adapttr = New SqlDataAdapter(cmd)
            '                Dim dt = New DataTable()
            '                adapttr.Fill(dt)
            '            cmd = New SqlCommand("
            'select ER_COMPTE from [ECRIT001] where
            ' ER_COMPTE between  '" & ComboBox3.Text & "%'  and   '" & ComboBox4.Text & "%' 
            'and  ER_MOIS between   " & ComboBox1.SelectedIndex + 1 & "  and " & ComboBox2.SelectedIndex + 1 & "
            'and ER_AN =  " & exer & "
            ' group by ER_COMPTE ", con)
            '            adapt1 = New SqlDataAdapter(cmd)
            '            adapt1.Fill(ds, "FPlantable")

            '            Grand_Livre.ComboBox1.DisplayMember = "ER_COMPTE"
            '            Grand_Livre.ComboBox1.ValueMember = "ER_COMPTE"
            '            Grand_Livre.ComboBox1.DataSource = ds.Tables("FPlantable")


            'Catch ex As Exception
            '    MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'End Try
            aff(ComboBox3.Text, ComboBox4.Text, ComboBox1.SelectedIndex + 1, ComboBox2.SelectedIndex + 1)
        End If

        'Me.Close()
        Grand_Livre.Show()
        ' Form2.ShowDialog()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub


    Private Sub grindlive_choix_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ComboBox1.SelectedIndex >= 0 And ComboBox2.SelectedIndex >= 0 Then
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        'MessageBox.Show("combo box 1 = " & ComboBox1.SelectedIndex + 1)
        'MessageBox.Show("combo box 3 = " & ComboBox3.Text)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        'MessageBox.Show("combo box 2 = " & ComboBox2.SelectedIndex + 1)
        'MessageBox.Show("combo box 4 = " & ComboBox4.Text)
    End Sub

    Private Sub grindlive_choix_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class