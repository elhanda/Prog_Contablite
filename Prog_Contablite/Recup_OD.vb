
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class Recup_OD

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As Integer
    Public id_val As Integer
    Dim z_exerc As Integer




    Public Sub FilterData()
        Try


            '    Dim searchQuery As String = "exec [FilterFecriture] " & valueToSearch & " , " & (ComboBox2.SelectedIndex + 1) & " , " & ComboBox1.Text & " , " & exec_proc.n1 & " "

            Dim searchQuery As String = "Select  er_exerc,er_journl,er_cpartie,er_mont as debit ,er_mont as credit from Fecriture where er_exerc='" & Label_an_precedent.Text & " '  and  er_journl= '100' "

            Dim command As New SqlCommand(searchQuery, con)
        Dim adapter As New SqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        DataGridView1.DataSource = table

            If DataGridView1 IsNot Nothing Then
                If DataGridView1.Columns.Contains("er_exerc") Then
                    DataGridView1.Columns("er_exerc").HeaderText = "er_exerc"
                End If
                If DataGridView1.Columns.Contains("er_journl") Then
                    DataGridView1.Columns("er_journl").HeaderText = "er_journl"
                End If
                If DataGridView1.Columns.Contains("er_cpartie") Then
                    DataGridView1.Columns("er_cpartie").HeaderText = "er_cpartie"
                End If
                If DataGridView1.Columns.Contains("debit") Then
                    DataGridView1.Columns("debit").HeaderText = "debit"
                End If
                If DataGridView1.Columns.Contains("credit") Then
                    DataGridView1.Columns("credit").HeaderText = "credit"
                End If
            Else
                MessageBox.Show("DataGridView1 is not initialized.")
        End If

            DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)

            For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                Dim val As Integer = DataGridView1.Rows(i).Cells(4).Value

                If val = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.CadetBlue
                End If
                If val > 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                End If
            Next

            'sum = 0
            'x = 0
            'For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
            '    sum = sum + DataGridView1.Rows(i).Cells(4).Value
            '    x = x + DataGridView1.Rows(i).Cells(6).Value
            'Next
            'Label7.Text = DataGridView1.Rows.Count.ToString()
            'Label19.Text = Label7.Text + 1
            'TextBox7.Text = sum
            'TextBox8.Text = x
            'TextBox9.Text = sum - x

        Catch ex As Exception
            'MessageBox.Show("filter" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Recup_OD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter()

        Label_An_Actuel.Text = exec_proc.n9
        Label_an_precedent.Text = exec_proc.n9 - 1
        Label_Lib_Od.Text = "OD  Operations diverses  "
        Label_An_Actuel.Refresh()
        Label_an_precedent.Refresh()
        Label_Lib_Od.Refresh()

        Try

            Dim searchQuery As String
            searchQuery = "Select distinct [ER_EXERC],'100  A NOUVEAUX     ' as lib_an,fe.[ER_CPARTIE],fp.[C_LIBELLE],sum(iif(fe.[ER_CODE]='D',fe.[er_mont],0)) as debit ,sum(iif(fe.[ER_CODE]='C',fe.[er_mont],0)) as credit "
            searchQuery = searchQuery + "From [FEcriture] fe  inner Join FPlanComptable fp  on fe.ER_CPARTIE=fp.C_CODE  where [ER_EXERC] = '" & Label_an_precedent.Text & "'"

            searchQuery = searchQuery + "group by  fe.[ER_EXERC], fe.[ER_CPARTIE], fp.[C_LIBELLE]   order by fe.[ER_EXERC], fe.[ER_CPARTIE]"

            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.Refresh()

            If DataGridView1 IsNot Nothing Then
                If DataGridView1.Columns.Contains("er_exerc") Then
                    DataGridView1.Columns("er_exerc").HeaderText = "Année de l'exercice"
                End If
                If DataGridView1.Columns.Contains("Lib_an") Then
                    DataGridView1.Columns("Lib_an").HeaderText = "A Nouvraux"
                End If

                If DataGridView1.Columns.Contains("er_cpartie") Then
                    DataGridView1.Columns("er_cpartie").HeaderText = "Compte Comptable"
                End If
                If DataGridView1.Columns.Contains("C_libelle") Then
                    DataGridView1.Columns("C_libelle").HeaderText = "      Libelle Comptable      "
                End If

                If DataGridView1.Columns.Contains("debit") Then
                    DataGridView1.Columns("debit").HeaderText = "Montant debit"
                End If
                If DataGridView1.Columns.Contains("credit") Then
                    DataGridView1.Columns("credit").HeaderText = "Montant credit"
                End If
            Else
                MessageBox.Show("DataGridView1 is not initialized.")
            End If

        Catch ex As Exception
            'MessageBox.Show("filter" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    If TextBox1.Text = "" Then

        '    End If
        '    TextBox7.Text = 0
        '    TextBox8.Text = 0
        '    TextBox9.Text = 0

        '    TextBox5.Text = 0
        '    TextBox6.Text = 0
        '    Recup_libel()

        '    FilterData(TextBox1.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


        '  FilterData()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        'Dim index As Integer

        'MessageBox.Show("index  = " & e.RowIndex)
        'index = e.RowIndex

        'Dim selecteRow As DataGridViewRow
        'selecteRow = DataGridView1.Rows(index)




    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        'Dim index As Integer

        ''MessageBox.Show("index  = " & e.RowIndex)
        'index = e.RowIndex

        'Dim selecteRow As DataGridViewRow
        'selecteRow = DataGridView1.Rows(index)
        ''Label19

        'TextBox2.Text = selecteRow.Cells(0).Value.ToString()
        'ComboBox3.Text = selecteRow.Cells(1).Value.ToString()
        'ComboBox4.Text = selecteRow.Cells(2).Value.ToString()
        'TextBox4.Text = selecteRow.Cells(3).Value.ToString()
        'TextBox3.Text = selecteRow.Cells(4).Value.ToString()
        'TextBox5.Text = selecteRow.Cells(5).Value.ToString()
        'TextBox6.Text = selecteRow.Cells(6).Value.ToString()

        ''Label7.Text = DataGridView1.Rows.Count.ToString()
        ''Label7.Refresh()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()

    End Sub
    Public Sub supprimer_inserer_od()
        Dim index As Integer
        'Dim z_exerc As String
        Dim z_journl As String
        Dim z_mois As Integer
        Dim z_jour As Integer
        Dim z_cpartie As String
        Dim z_folio As Integer
        Dim z_ligne As Integer
        Dim z_libelle As String
        Dim z_an As Integer
        Dim z_code As String
        Dim z_mont As Double
        Dim z_npiece As String
        Dim z_debit As Double
        Dim z_credit As Double
        Dim req As String
        Dim z_j As Integer

        z_debit = 0
        z_credit = 0
        index = DataGridView1.Rows.Count - 1
        z_exerc = Val(exec_proc.n9)

        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to add?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dialog = DialogResult.Yes Then
            Try


                ' Supprimer les enregistrements avec er_journl="100" et er_an=er_an+1
                'Dim deleteReq As String = "DELETE FROM FEcriture WHERE ER_JOURNL = '100' AND ER_AN = @An"
                Dim deleteReq As String = "DELETE FROM FEcriture WHERE ER_JOURNL = '100' AND ER_AN = @an"
                cmd = New SqlCommand(deleteReq, con)
                cmd.Parameters.AddWithValue("@An", Val(exec_proc.n9) + 1)
                cmd.ExecuteNonQuery()

                If index > 0 Then
                    Dim selectedRow As DataGridViewRow

                    For z_j = 0 To index - 1
                        selectedRow = DataGridView1.Rows(z_j)
                        z_exerc = exec_proc.n9
                        z_journl = "100"
                        z_an = Val(exec_proc.n9)
                        z_mois = 1
                        z_folio = 1
                        z_jour = 1
                        z_ligne = 1
                        z_cpartie = selectedRow.Cells(2).Value.ToString
                        z_libelle = selectedRow.Cells(3).Value.ToString

                        If selectedRow.Cells(4).Value - selectedRow.Cells(5).Value > 0 Then
                            z_mont = selectedRow.Cells(4).Value - selectedRow.Cells(5).Value
                            z_code = "D"
                        Else
                            z_mont = selectedRow.Cells(5).Value - selectedRow.Cells(4).Value
                            z_code = "C"
                        End If

                        z_npiece = "AN 01"

                        z_debit += selectedRow.Cells(4).Value
                        z_credit += selectedRow.Cells(5).Value

                        req = "INSERT INTO FEcriture (ER_EXERC, ER_JOURNL, ER_AN, ER_MOIS, ER_FOLIO, ER_JOUR, ER_LIGNE, ER_CPARTIE, ER_LIBELLE, ER_MONT, ER_CODE, Er_NPIECE) " &
                              "VALUES (@Exerc, @Journl,@an, @Mois, @Folio, @Jour, @Ligne, @Cpartie, @Libelle, @Mont, @Code, @Npiece)"

                        cmd = New SqlCommand(req, con)
                        cmd.Parameters.AddWithValue("@Exerc", z_exerc)
                        cmd.Parameters.AddWithValue("@Journl", z_journl)
                        cmd.Parameters.AddWithValue("@An", z_an)
                        cmd.Parameters.AddWithValue("@Mois", z_mois)
                        cmd.Parameters.AddWithValue("@Folio", z_folio)
                        cmd.Parameters.AddWithValue("@Jour", z_jour)
                        cmd.Parameters.AddWithValue("@Ligne", z_ligne)
                        cmd.Parameters.AddWithValue("@Cpartie", z_cpartie)
                        cmd.Parameters.AddWithValue("@Libelle", z_libelle)
                        cmd.Parameters.AddWithValue("@Mont", z_mont)
                        cmd.Parameters.AddWithValue("@Code", z_code)
                        cmd.Parameters.AddWithValue("@Npiece", z_npiece)

                        cmd.ExecuteNonQuery()
                    Next

                    Label3.Text = z_debit
                    Label5.Text = z_credit
                    Label3.Refresh()
                    Label5.Refresh()
                End If


            Catch ex As Exception
                MessageBox.Show("Error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                'If con.State = ConnectionState.Open Then
                '    con.Close()
                'End If
            End Try
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        supprimer_inserer_od()
        'Recuperer_od()
    End Sub




End Class