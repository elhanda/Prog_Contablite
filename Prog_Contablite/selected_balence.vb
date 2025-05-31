
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class selected_balence
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim ds1 As DataSet = New DataSet()
    Dim dt1 As DataSet = New DataSet()
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
    Public CHK1, CHK2, CHK3, CHK4, CHK5, chk8 As Integer
    Public Compteur As Integer






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
                isi = ListView1.Items.Add(AB(0).ToString)
                'isi = Balance.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(4).ToString)
                isi.SubItems.Add(AB(3).ToString - AB(4).ToString)
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
                isi = ListView1.Items.Add(AB(0).ToString)

                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(3).ToString - AB(4).ToString)


            Next

        Catch ex As Exception
            MessageBox.Show("error " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try




    End Sub
    Sub CompteBalance(CompteDebut, CompteFin)
        Dim req As String = "[dbo].[BalanceCompte]"

        Using con As New SqlConnection("Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_" + Access.n2 + ";Integrated Security=True"),
        cmd As New SqlCommand(req, con),
        adapttr As New SqlDataAdapter(cmd),
        ds As New DataTable()

            cmd.CommandType = CommandType.StoredProcedure

            ' Add parameters
            cmd.Parameters.AddWithValue("@anne", exer)
            cmd.Parameters.AddWithValue("@Exec", exer)
            cmd.Parameters.AddWithValue("@CompteDebut", CompteDebut)
            cmd.Parameters.AddWithValue("@CompteFin", CompteFin)
            cmd.Parameters.AddWithValue("@chk1", CHK1)
            cmd.Parameters.AddWithValue("@chk2", CHK2)
            cmd.Parameters.AddWithValue("@chk3", CHK3)
            cmd.Parameters.AddWithValue("@chk4", CHK4)
            cmd.Parameters.AddWithValue("@chk5", CHK5)
            cmd.Parameters.AddWithValue("@chk8", chk8)

            Try
                con.Open()
                adapttr.Fill(ds)

                ListView1.Items.Clear()
                For Each AB As DataRow In ds.Rows
                    Dim isi As New ListViewItem(AB("ER_CPARTIE").ToString())
                    isi.SubItems.Add(AB("er_libelle").ToString())
                    isi.SubItems.Add(AB("Nombre").ToString())
                    isi.SubItems.Add(AB("TYPE_DEBUT").ToString())
                    isi.SubItems.Add(AB("TYPE_Credit").ToString())
                    ListView1.Items.Add(isi)

                    ' Assuming TYPE_DEBUT and TYPE_Credit are numeric columns
                    sum += Convert.ToDecimal(AB("TYPE_DEBUT"))
                    cred += Convert.ToDecimal(AB("TYPE_Credit"))

                Next

            Catch ex As SqlException
                ' Handle SQL exceptions
                MessageBox.Show("A database error occurred: " & ex.Message)
            Catch ex As Exception
                ' Handle other exceptions
                MessageBox.Show("An error occurred: " & ex.Message)
            Finally
                ' Ensure the connection is closed even if an exception occurs
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Sub

    'Sub CompteBalance(CompteDebut, CompteFin)

    '    Dim req As String = "[dbo].[BalanceCompte]"
    '    Dim cmd As New SqlCommand(req, con)
    '    cmd.CommandType = CommandType.StoredProcedure

    '    ' Add parameters
    '    cmd.Parameters.AddWithValue("@anne", exer)
    '    cmd.Parameters.AddWithValue("@Exec", exer)
    '    cmd.Parameters.AddWithValue("@CompteDebut", CompteDebut)
    '    cmd.Parameters.AddWithValue("@CompteFin", CompteFin)
    '    cmd.Parameters.AddWithValue("@chk1", CHK1)
    '    cmd.Parameters.AddWithValue("@chk2", CHK2)
    '    cmd.Parameters.AddWithValue("@chk3", CHK3)
    '    cmd.Parameters.AddWithValue("@chk4", CHK4)
    '    cmd.Parameters.AddWithValue("@chk5", CHK5)
    '    cmd.Parameters.AddWithValue("@chk8", chk8)

    '    Dim adapttr As New SqlDataAdapter(cmd)
    '    Dim ds As New DataTable()

    '    Try
    '        adapttr.Fill(ds)

    '        ' Clear ListView items before adding new ones
    '        ListView1.Items.Clear()

    '        ' Now process the DataTable
    '        Dim sum As Decimal = 0
    '        Dim cred As Decimal = 0
    '        Dim Compteur As Integer = ds.Rows.Count ' Assuming Compteur represents the count of rows

    '        For Each AB As DataRow In ds.Rows
    '            Dim isi As New ListViewItem(AB("ER_COMPTE").ToString())
    '            isi.SubItems.Add(AB("er_libelle").ToString())
    '            isi.SubItems.Add(AB("Nombre").ToString())
    '            isi.SubItems.Add(AB("TYPE_DEBUT").ToString())
    '            isi.SubItems.Add(AB("TYPE_Credit").ToString())
    '            ListView1.Items.Add(isi)

    '            ' Assuming TYPE_DEBUT and TYPE_Credit are numeric columns
    '            sum += Convert.ToDecimal(AB("TYPE_DEBUT"))
    '            cred += Convert.ToDecimal(AB("TYPE_Credit"))
    '        Next

    '        ' Calculate and display averages
    '        Label7.Text = If(Compteur > 0, (cred / Compteur).ToString(), "N/A")
    '        Label6.Text = If(Compteur > 0, (sum / Compteur).ToString(), "N/A")
    '        Label4.Text = If(Compteur > 0, ((sum - cred) / Compteur).ToString(), "N/A")

    '        ' Determine and display balance status
    '        If Label4.Text < 0 Then
    '            Label4.Text = ((cred - sum) * Compteur).ToString()
    '            Label14.Text = "Solde Créditeur"
    '        ElseIf Label4.Text > 0 Then
    '            Label14.Text = "Solde Débiteur"
    '        Else
    '            Label14.Text = "Solde Nul"
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Error: " & ex.Message)
    '    Finally
    '        adapttr.Dispose()
    '        cmd.Dispose()
    '    End Try
    'End Sub



    Private Sub selected_balence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Compteur = 1
        Label11.Text = exer
        Label3.Text = Access.Name
        Label5.Text = Access.n2
        Module1.connecter()

        cmd = New SqlCommand("select distinct ER_CPARTIE from [Fecriture] where len(er_cpartie) >0 group by ER_CPARTIE order by ER_CPARTIE ", con)
        adapt1 = New SqlDataAdapter(cmd)
        adapt1.Fill(ds, "Fecriture")
        ComboBox3.DisplayMember = "ER_CPARTIE"
        ComboBox3.ValueMember = "ER_LIBELLE"
        ComboBox3.DataSource = ds.Tables("Fecriture")
        ComboBox3.GetItemText(0)
        'Label4.Text = ComboBox3.ValueMember
        'Grand_Livre.TextBox1.Text = ComboBox3.Text

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select distinct ER_Cpartie from [Fecriture] where len(er_cpartie) >0 group by ER_CPARTIE order by ER_CPARTIE   desc ", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(ds1, "Fecriture")
        ComboBox4.DisplayMember = "ER_CPARTIE"
        ComboBox4.ValueMember = "ER_LIBELLE"
        ComboBox4.DataSource = ds1.Tables("Fecriture")
        ComboBox4.GetItemText(0)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Form1.Show()
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        chk8 = 8
        Try
            If CheckBox1.Checked = False Then
                ListView1.Items.Clear()
                chk8 = 0
                'MessageBox.Show("select your totaux seul  ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'reaff_touto_seul()
            Else
                'aff_touto_seul()
                'Balance.Show()
                chk8 = 8
            End If
        Catch ex As Exception
            MessageBox.Show("error de la selection your totaux seul" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

        Try

            If CheckBox3.Checked = False Then
                If Compteur > 1 Then
                    Compteur = Compteur - 1
                Else
                    Compteur = 1
                End If
                'MessageBox.Show(" select your number 1 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'Balance.DataGridView1.DataSource = Nothing
                ListView1.Items.Clear()
                CHK1 = 0
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    deremplire()
                'End If

            Else
                Compteur = Compteur + 1
                CHK1 = 1
                'remplire()
            End If
        Catch ex As Exception
            MessageBox.Show("check your number 1" + ex.Message)
        End Try
    End Sub


    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click

        sum = 0
        cred = 0
        CompteBalance(ComboBox3.Text, ComboBox4.Text)
        'Balance.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub


    Private Sub Apercue_Click(sender As Object, e As EventArgs) Handles Apercue.Click
        Try
            Dim dtable = New DataTable()
            With dtable
                .Columns.Add("DATE")
                .Columns.Add("ER_JOURNL")
                .Columns.Add("ER_FOLIO")
                .Columns.Add("ER_LIGNE")
                .Columns.Add("ER_CPARTIE")
                .Columns.Add("ER_NPIECE")
                .Columns.Add("ER_LIBELLE")
                .Columns.Add("TYPE_DEBUT")
                .Columns.Add("TYPE_CREDI")
                .Columns.Add("ER_Compte")
            End With
            Dim columnValues(dtable.Columns.Count - 1) As Object

            For Each lvi As ListViewItem In ListView1.Items
                columnValues(0) = ("")
                columnValues(1) = ("")
                columnValues(2) = ("")
                columnValues(3) = ("")
                columnValues(4) = (lvi.SubItems(0).Text)
                columnValues(5) = ("")
                columnValues(6) = (lvi.SubItems(1).Text)
                columnValues(7) = (lvi.SubItems(2).Text)
                columnValues(8) = (lvi.SubItems(3).Text)
                columnValues(9) = (lvi.SubItems(0).Text)
                dtable.Rows.Add(columnValues)
            Next


            If dtable.Rows.Count = 0 Then
                MessageBox.Show("No data Found", "CrystalReportWithOracle")
                Return
            End If




            Dim crystal As New Balance_Report_Final

            crystal.SetDataSource(dtable)
            Apercu_balance.CrystalReportViewer1.ReportSource = crystal
            'Form10.CrystalReportViewer1.ReportSource = crystal
            ''GrandLivreReportViewer.Refresh()
            'Form10.Show()
            ' 'GrandLivreReportViewer.Dispose()


            Apercu_balance.Show()

            '' 'test1.CrystalReportViewer1.ReportSource = crystal
            '' 'test1.CrystalReportViewer1.Refresh()

            '' 'test1.Show()




        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub



    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

        Try
            If CheckBox4.Checked = False Then
                If Compteur > 0 Then
                    Compteur = Compteur - 1
                Else
                    Compteur = 1
                End If
                'MessageBox.Show("select your number 2 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''  Balance.DataGridView1.DataSource = Nothing
                ListView1.Items.Clear()
                CHK2 = 0
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    '           ListBox1.Items.RemoveAt()
                '    'deremplire()
                'End If
            Else
                CHK2 = 2

                Compteur = Compteur + 1


            End If

        Catch ex As Exception
            '      MessageBox.Show("check your number 2" + ex.Message)
        End Try
    End Sub



    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged

        Try
            If CheckBox5.Checked = False Then
                If Compteur > 0 Then
                    Compteur = Compteur - 1
                Else
                    Compteur = 1
                End If
                CHK3 = 0
                ListView1.Items.Clear()
                'MessageBox.Show(" select your number 3 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''  Balance.DataGridView1.DataSource = Nothing
                ''   ListBox1.Items.Clear()
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    'deremplire()
                'End If

            Else
                CHK3 = 3
                Compteur = Compteur + 1

            End If
        Catch ex As Exception
            '    MessageBox.Show("check your number 3" + ex.Message)
        End Try

    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

        CHK4 = 4
        Try
            If CheckBox6.Checked = False Then
                If Compteur > 0 Then
                    Compteur = Compteur - 1
                Else
                    Compteur = 1
                End If
                CHK4 = 0
                ListView1.Items.Clear()
                'MessageBox.Show(" select your number 4 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '   Balance.DataGridView1.DataSource = Nothing
                '   ListBox1.Items.Clear()
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    deremplire()
                'End If


            Else
                CHK4 = 4
                Compteur = Compteur + 1

            End If
        Catch ex As Exception
            '          MessageBox.Show("check your number 4" + ex.Message)
        End Try
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        CHK5 = 5
        Try
            If CheckBox7.Checked = False Then
                If Compteur > 0 Then
                    Compteur = Compteur - 1
                Else
                    Compteur = 1
                End If
                CHK5 = 0
                ListView1.Items.Clear()
                'MessageBox.Show("  select your number 5 ", "info", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ''  Balance.DataGridView1.DataSource = Nothing
                ''  ListBox1.Items.Clear()
                'If (CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = False And CheckBox6.Checked = False And CheckBox7.Checked = False) Then
                '    MessageBox.Show(" the list is clean every one is out ", "info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                'Else
                '    deremplire()
                'End If

            Else
                CHK5 = 5
                Compteur = Compteur + 1

            End If
        Catch ex As Exception
            '         MessageBox.Show("check your number 5" + ex.Message)
        End Try
    End Sub





    Private Sub ListView1_ColumnClick(ByVal sender As System.Object,
    ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        If Me.ListView1.Sorting = SortOrder.Ascending Then
            Me.ListView1.Sorting = SortOrder.Descending
        Else
            Me.ListView1.Sorting = SortOrder.Ascending
        End If
        ' Me.ListView1.ListViewItemSorter = New ListViewItemComparer(e.Column, Me.ListView1.Sorting)
    End Sub






End Class

