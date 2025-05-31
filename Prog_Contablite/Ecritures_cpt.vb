Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine




Public Class Ecriture
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Dim value As Integer
    Dim x As Integer = 0
    Dim y As Integer
    Dim sum As Integer = 0
    Dim ind As Integer
    Public i As Integer
    Public ind_maj As Integer = 0
    Public nblig As Integer = 0
    Public code_journal As String
    Public mois As String
    Public folio As String



    'Public Sub Module1.connecter()
    '    Dim chaineDeConnexion As String

    '    chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=BASE_COMPTA_" + Access.n2 + ";Integrated Security=True"


    '    con = New SqlConnection(chaineDeConnexion)
    '    Try
    '        con.Open()
    '        ' MsgBox("bien passé")
    '    Catch ex As Exception
    '        Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Console.WriteLine(ex.Message)
    '    End Try
    'End Sub
    ' Dans votre méthode pour agrandir la fenêtre
    Private Sub AgrandirFenetre1()

        Me.WindowState = FormWindowState.Normal
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
    End Sub

    Private Sub AgrandirFenetre()
        ' Déterminez la taille de l'écran principal
        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

        ' Redimensionnez et positionnez le formulaire pour qu'il occupe tout l'écran
        Me.Size = New Size(screenWidth, screenHeight)
        Me.Location = New Point(0, 0)
    End Sub

    Private Sub ResizeControls(ByVal scaleFactor As Double)
        For Each ctrl As Control In Me.Controls
            ctrl.Left = CInt(ctrl.Left * scaleFactor)
            ctrl.Top = CInt(ctrl.Top * scaleFactor)
            ctrl.Width = CInt(ctrl.Width * scaleFactor)
            ctrl.Height = CInt(ctrl.Height * scaleFactor)
        Next
    End Sub



    Sub add(a, ER_EXERC, ER_JOURNL, ER_AN, ER_MOIS, ER_FOLIO, ER_JOUR, ER_LIGNE, ER_CPARTIE, F10, ER_LIBELLE, mont, b, ER_NPIECE)


        Try

            For Each c As Control In Panel3.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Return
                        Exit For
                    End If
                End If
            Next

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you reelly whant To add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try


                    Dim req As String = "exec insert_into_Fecriture " & a & "," & ER_EXERC & ",N'" & ER_JOURNL & "'," & ER_AN & "," & ER_MOIS & "," & ER_FOLIO & "," & ER_JOUR & "," & ER_LIGNE & ",N'" & ER_CPARTIE & "',N'" & F10 & "',N'" & ER_LIBELLE & "'," & mont & "," & b & ",N'" & ER_NPIECE & "'"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer As SqlDataAdapter
                    adaptteeer = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("sub add" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                End Try

                'MessageBox.Show("تم التعديل بنجاح", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                Panel5.Visible = False
                Panel4.Visible = True
                ComboBox3.Enabled = False
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                FilterData(TextBox1.Text)
            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("Not found" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
            End If
        Catch ee As Exception

            MessageBox.Show("warning" + ee.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        End Try




    End Sub
    Sub sup(ER_JOURNL As String, ER_MOIS As Integer, ER_FOLIO As Integer, ER_LIGNE As Integer, ER_EXERC As Integer, ER_JOUR As Integer, ER_CPARTIE As String)
        'Sub sup(ER_JOURNL, ER_MOIS, ER_FOLIO, ER_LIGNE, ER_EXERC, ER_JOUR, ER_CPARTIE)
        Try
            Dim dialog As DialogResult = MessageBox.Show("Do you really want to supprimer ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog <> DialogResult.Yes Then Exit Sub

            ' 🔍 Tentatives de conversion des floats
            Dim mois#, folio#, ligne#, exerc#, jour#


            '    con.Open()
            Using cmd As New SqlCommand("Delete_into_Fecriture", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@ER_JOURNL1", ER_JOURNL)
                cmd.Parameters.AddWithValue("@ER_MOIS1", ER_MOIS)
                cmd.Parameters.AddWithValue("@ER_FOLIO1", ER_FOLIO)
                cmd.Parameters.AddWithValue("@ER_LIGNE1", ER_LIGNE)
                cmd.Parameters.AddWithValue("@ER_EXERC1", ER_EXERC)
                cmd.Parameters.AddWithValue("@ER_JOUR1", ER_JOUR)
                cmd.Parameters.AddWithValue("@ER_CPARTIE", ER_CPARTIE)



                Dim affected As Integer = cmd.ExecuteNonQuery()

                If affected > 0 Then
                    MessageBox.Show("✅ Ligne supprimée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("⚠️ Aucun enregistrement trouvé à supprimer.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End Using
            'End Using

            ' UI updates après suppression
            Panel5.Visible = False
            Panel4.Visible = True
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False
            ComboBox5.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            FilterData(TextBox1.Text)

        Catch ex As Exception
            MessageBox.Show("❌ Erreur : " & ex.Message, "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub modif(ER_CPARTIE, ER_LIBELLE, mont, choix, ER_NPIECE, ER_JOURNL, ER_MOIS, ER_FOLIO, ER_LIGNE, ER_EXERC, ER_JOUR)

        Try

            For Each c As Control In Panel3.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Return
                        Exit For
                    End If
                End If
            Next

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to modify ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try

                    'MsgBox(ER_JOUR)
                    Dim req As String = "exec [update_into_Fecriture] '" & ER_CPARTIE & "','" & ER_LIBELLE & "'," & mont & "," & choix & ",'" & ER_NPIECE & "','" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & "," & ER_LIGNE & "," & ER_EXERC & "," & ComboBox3.Text & " "

                    cmd = New SqlCommand(req, con)

                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("sub update" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

                End Try

                'MessageBox.Show("تم التعديل بنجاح", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                Panel5.Visible = False
                Panel4.Visible = True
                'ComboBox3.Enabled = False
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                FilterData(TextBox1.Text)
            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                ' MessageBox.Show("not found" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            End If
        Catch ee As Exception

            'MessageBox.Show("une erreur" + ee.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

        End Try




    End Sub
    Public Sub count()
        Try
            Label7.Text = DataGridView1.Rows.Count.ToString()
            Label19.Text = Label7.Text + 1

        Catch ex As Exception
            '     MessageBox.Show("count : " + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub Recup_libel()

        If TextBox1.Text = "" Then
            TextBox1.Text = 1
        End If
        cmd = New SqlCommand("Select J_LIBELLE from FJournal where J_CODE ='" & ComboBox1.Text & "'", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "FJol")
        For Each dr As DataRow In ds.Tables("FJol").Rows
            Label3.Text = dr("J_LIBELLE").ToString()
        Next
    End Sub



    Sub aff()
        Try
            If Len(TextBox1.Text) = 0 Or TextBox1.Text = "" Then
                TextBox1.Text = 1
            End If


            Dim searchQuery As String = "exec [FilterFecriture] " & TextBox1.Text & " , " & (ComboBox2.SelectedIndex + 1) & " ," & ComboBox1.Text & " , " & exec_proc.n1 & " "


            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table



            DataGridView1.Columns("er_ligne").HeaderText = "Ligne"
            DataGridView1.Columns("er_jour").HeaderText = "Jour"
            DataGridView1.Columns("er_cpartie").HeaderText = "Compte"
            DataGridView1.Columns("er_npiece").HeaderText = "N.Piece"
            DataGridView1.Columns("er_libelle").HeaderText = "Libelle"
            DataGridView1.Columns("debitt").HeaderText = "Debit"
            DataGridView1.Columns("creditt").HeaderText = "Credit"


            Dim dt As New DataTable()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim newRow As DataRow = dt.NewRow()
                    For Each cell As DataGridViewCell In row.Cells
                        newRow(cell.ColumnIndex) = cell.Value
                    Next
                    dt.Rows.Add(newRow)
                End If
            Next





        Catch ex As Exception
            MessageBox.Show("errrrrrrrload Error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function crystalReportViewer() As Object
        Throw New NotImplementedException()
    End Function

    Public Sub FilterData(valueToSearch As String)
        Try


            Dim searchQuery As String = "exec [FilterFecriture] " & valueToSearch & " , " & (ComboBox2.SelectedIndex + 1) & " , " & ComboBox1.Text & " , " & exec_proc.n1 & " "



            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

            If DataGridView1 IsNot Nothing Then
                If DataGridView1.Columns.Contains("er_ligne") Then
                    DataGridView1.Columns("er_ligne").HeaderText = "Ligne"
                End If
                If DataGridView1.Columns.Contains("er_jour") Then
                    DataGridView1.Columns("er_jour").HeaderText = "Jour"
                End If
                If DataGridView1.Columns.Contains("er_cpartie") Then
                    DataGridView1.Columns("er_cpartie").HeaderText = "Compte"
                End If

                If DataGridView1.Columns.Contains("er_npiece") Then
                    DataGridView1.Columns("er_npiece").HeaderText = "N.Piece"
                End If
                If DataGridView1.Columns.Contains("er_libelle") Then
                    DataGridView1.Columns("er_libelle").HeaderText = "Libelle"
                End If
                If DataGridView1.Columns.Contains("debit") Then
                    DataGridView1.Columns("debit").HeaderText = "Debit"
                End If
                If DataGridView1.Columns.Contains("credit") Then
                    DataGridView1.Columns("credit").HeaderText = "Credit"
                End If
            Else
                MessageBox.Show("DataGridView1 is not initialized.")
            End If


            'Définir la largeur de la première colonne à 150 pixels
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(1).Width = 50
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Width = 400
            DataGridView1.Columns(5).Width = 150



            For Each col As DataGridViewColumn In DataGridView1.Columns
                ' Définir la taille de la police pour chaque cellule dans chaque colonne
                col.DefaultCellStyle.Font = New Font("Arial", 12) ' Changer la police à Arial avec une taille de 10 points
            Next


            DataGridView1.Columns("er_ligne").HeaderText = "Ligne"
            DataGridView1.Columns("er_jour").HeaderText = "Jour"
            DataGridView1.Columns("er_cpartie").HeaderText = "Compte"
            DataGridView1.Columns("er_npiece").HeaderText = "N.Piece"
            DataGridView1.Columns("er_libelle").HeaderText = "Libelle"
            DataGridView1.Columns("debit").HeaderText = "Debit"
            DataGridView1.Columns("credit").HeaderText = "Credit"

            DataGridView1.Sort(DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)


            For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                Dim val As Integer = DataGridView1.Rows(i).Cells(5).Value

                If val = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.CadetBlue
                End If
                If val > 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                End If
            Next
            sum = 0
            x = 0

            For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                sum = sum + DataGridView1.Rows(i).Cells(5).Value
                x = x + DataGridView1.Rows(i).Cells(6).Value
            Next
            Label7.Text = DataGridView1.Rows.Count.ToString()
            Label19.Text = Label7.Text + 1
            TextBox7.Text = sum
            TextBox8.Text = x
            TextBox9.Text = sum - x


        Catch ex As Exception
            'MessageBox.Show("filter" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load





        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Module1.connecter()
        Panel5.Visible = False
        'ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

        'ResizeControls(1.5)


        If TextBox1.Text = "" Then
            TextBox1.Text = 1
        End If
        count()

        Try

            'FilterData(1)
            'combobox1 Code Journal :
            cmd = New SqlCommand("Select * from FJournal", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "FJournal")
            ComboBox1.DisplayMember = "J_CODE"
            ComboBox1.ValueMember = "J_LIBELLE "
            ComboBox1.DataSource = ds.Tables("FJournal")
            ComboBox1.GetItemText(0)
            ComboBox2.GetItemText(0)

            'combobox1 Code Compte :
            cmd = New SqlCommand("Select * from FPlanComptable order by C_CODE ", con)
            adapt1 = New SqlDataAdapter(cmd)
            adapt1.Fill(ds, "FPlanComptable")
            ComboBox4.DisplayMember = "C_CODE"
            ComboBox4.ValueMember = "C_LIBELLE"
            ComboBox4.DataSource = ds.Tables("FPlanComptable")

            cmd = New SqlCommand("Select * from FPlanComptable order by C_CODE ", con)
            adapt2 = New SqlDataAdapter(cmd)
            adapt2.Fill(ds, "FPlanComptable2")
            ComboBox5.DisplayMember = "C_CODE"
            ComboBox5.ValueMember = "C_CODE "
            ComboBox5.DataSource = ds.Tables("FPlanComptable2")
            ''C_Partie ne doit pas saisie tout seul 
            ''**************************************************
            ''*  test sur la base
            ''**************************************************

            'Dim baseActuelle As String = con.Database
            'MessageBox.Show("📂 Tu es connecté à la base : " & baseActuelle, "Info")
            'Dim sql As String = "SELECT physical_name FROM sys.database_files"
            'Dim cmdd As New SqlCommand(sql, con)
            'Dim reader As SqlDataReader = cmdd.ExecuteReader()

            'While reader.Read()
            '    Dim cheminFichier As String = reader("physical_name").ToString()
            '    MessageBox.Show("📁 Chemin du fichier : " & cheminFichier)
            'End While

            'reader.Close()

            'Try
            '    If con Is Nothing OrElse con.State <> ConnectionState.Open Then
            '        MessageBox.Show("🚫 Connexion échouée.")
            '        Return
            '    End If

            '    MessageBox.Show("✅ Connecté à la base : " & con.Database)

            '    ' 🔍 On tente de lire dans sys.tables
            '    Dim sqll As String = "SELECT TOP 1 name FROM sys.tables"
            '    Dim cmd As New SqlCommand(sqll, con)
            '    Dim result As Object = cmd.ExecuteScalar()

            '    If result IsNot Nothing Then
            '        MessageBox.Show("✅ Accès confirmé. Première table : " & result.ToString())
            '    Else
            '        MessageBox.Show("😶 Connexion OK, mais pas de résultat.")
            '    End If

            'Catch ex As SqlException
            '    MessageBox.Show("⚠️ Connexion OK, mais accès refusé : " & ex.Message, "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Catch ex As Exception
            '    MessageBox.Show("❌ Erreur : " & ex.Message, "Erreur générale", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Finally
            '    If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
            '        con.Close()
            '    End If
            'End Try

            ''**************************************************



        Catch ex As Exception
            MessageBox.Show("load Error" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
        'ComboBox1.SelectedIndex = -1
        'ComboBox2.SelectedIndex = -1
        'ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1







    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox1.Text = 1
        End If
        TextBox7.Text = 0
        TextBox8.Text = 0
        TextBox9.Text = 0

        TextBox5.Text = 0
        TextBox6.Text = 0
        Recup_libel()

        FilterData(TextBox1.Text)
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ind_maj = 1
        Panel5.Visible = True
        Panel4.Visible = False
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel5.Visible = False
        Panel4.Visible = True


        If ind_maj = 1 Then
            Try
                '     MessageBox.Show("ajouter")

                If Not String.IsNullOrWhiteSpace(ComboBox4.Text) AndAlso Not String.IsNullOrWhiteSpace(ComboBox5.Text) Then

                    If TextBox5.Text > 0 Then


                        add("null", exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox3.Text, Label19.Text, ComboBox4.Text, "null", TextBox4.Text, TextBox5.Text, 1, TextBox3.Text)
                        add("null", exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox3.Text, Label19.Text + 1, ComboBox5.Text, "null", TextBox4.Text, TextBox5.Text, 2, TextBox3.Text)


                    End If
                    If TextBox6.Text > 0 Then

                        add("null", exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox3.Text, Label19.Text, ComboBox5.Text, "null", TextBox4.Text, TextBox6.Text, 2, TextBox3.Text)
                        add("null", exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox3.Text, Label19.Text + 1, ComboBox4.Text, "null", TextBox4.Text, TextBox6.Text, 1, TextBox3.Text)

                    End If
                Else
                    If TextBox5.Text > 0 Then
                        add("null", exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox3.Text, Label19.Text, IIf(ComboBox4.Text > "0", ComboBox4.Text, ComboBox5.Text), "null", TextBox4.Text, TextBox5.Text, 1, TextBox3.Text)
                    Else
                        add("null", exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox3.Text, Label19.Text, IIf(ComboBox5.Text > "0", ComboBox5.Text, ComboBox4.Text), "null", TextBox4.Text, TextBox6.Text, 2, TextBox3.Text)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("add" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)

            End Try

        ElseIf ind_maj = 2 Then
            Try

                If ComboBox4.Text > "00" And ComboBox5.Text > "00" Then

                ElseIf ComboBox4.Text > "0" Then

                    If (TextBox5.Text > 0) Then ' debit

                        modif(ComboBox4.Text, TextBox4.Text, TextBox5.Text, 1, TextBox3.Text, ComboBox1.Text, ComboBox2.SelectedIndex + 1, TextBox1.Text, TextBox2.Text, exec_proc.n1, ComboBox3.Text)

                    ElseIf (TextBox6.Text > 0) Then

                        modif(ComboBox4.Text, TextBox4.Text, TextBox6.Text, 2, TextBox3.Text, ComboBox1.Text, ComboBox2.SelectedIndex + 1, TextBox1.Text, TextBox2.Text, exec_proc.n1, ComboBox3.Text)
                    End If

                End If

            Catch ex As Exception

                MessageBox.Show("modify" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            End Try
        ElseIf ind_maj = 3 Then
            Try



                sup(ComboBox1.Text, ComboBox2.SelectedIndex + 1, TextBox1.Text, TextBox2.Text, exec_proc.n1, ComboBox3.Text, ComboBox4.Text)

            Catch ex As Exception

                MessageBox.Show("delete" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            End Try
        End If


        ind_maj = 0
        ComboBox4.Text = ""
        ComboBox5.Text = ""
        TextBox3.Text = 0
        TextBox4.Text = ""
        TextBox5.Text = 0
        TextBox6.Text = 0

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer

        'MessageBox.Show("index  = " & e.RowIndex)
        index = e.RowIndex

        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        'Label19



        TextBox2.Text = selecteRow.Cells(0).Value.ToString()
        ComboBox3.Text = selecteRow.Cells(1).Value.ToString()
        ComboBox4.Text = selecteRow.Cells(2).Value.ToString()
        TextBox4.Text = selecteRow.Cells(4).Value.ToString()
        TextBox3.Text = selecteRow.Cells(3).Value.ToString()
        TextBox5.Text = selecteRow.Cells(5).Value.ToString()
        TextBox6.Text = selecteRow.Cells(6).Value.ToString()

        'Label7.Text = DataGridView1.Rows.Count.ToString()
        'Label7.Refresh()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ind_maj = 2

        Panel5.Visible = True
        Panel4.Visible = False
        ComboBox3.Enabled = True
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MessageBox.Show("anuller", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        Panel5.Visible = False
        Panel4.Visible = True
        'ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ind_maj = 3
        Panel5.Visible = True
        Panel4.Visible = False
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If Len(TextBox1.Text) > 0 And Len(ComboBox2.Text) > 0 Then
            Recup_libel()
            FilterData(TextBox1.Text)
        End If
        cmd = New SqlCommand("Select J_LIBELLE from FJournal where J_CODE =" & ComboBox1.Text & "", con)

    End Sub



    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Try
            If Len(TextBox1.Text) > 0 And Len(ComboBox1.Text) > 0 Then
                TextBox1.Text = 1
                Recup_libel()
                FilterData(TextBox1.Text)
            End If
        Catch
        End Try

    End Sub



    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer

        'MessageBox.Show("index  = " & e.RowIndex)
        index = e.RowIndex

        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        'Label19

        TextBox2.Text = selecteRow.Cells(0).Value.ToString()
        ComboBox3.Text = selecteRow.Cells(1).Value.ToString()
        ComboBox4.Text = selecteRow.Cells(2).Value.ToString()
        TextBox4.Text = selecteRow.Cells(4).Value.ToString()
        TextBox3.Text = selecteRow.Cells(3).Value.ToString()
        TextBox5.Text = selecteRow.Cells(5).Value.ToString()
        TextBox6.Text = selecteRow.Cells(6).Value.ToString()
        'Label7.Text = DataGridView1.Rows.Count.ToString()
        'Label7.Refresh()
    End Sub
    Private Sub TextBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseClick
        If TextBox6.Text > "0" Then
            TextBox5.Text = TextBox6.Text
            TextBox6.Text = 0
        End If
    End Sub

    Private Sub TextBox6_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox6.MouseClick
        If TextBox5.Text > "0" Then
            TextBox6.Text = TextBox5.Text
            TextBox5.Text = 0
        End If
        TextBox7.Text = 0
        TextBox8.Text = 0
        TextBox9.Text = 0

    End Sub
    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If TextBox6.Text > "0" Then
            TextBox5.Text = TextBox6.Text
            TextBox6.Text = 0
        End If
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If TextBox5.Text > "0" Then
            TextBox6.Text = TextBox5.Text
            TextBox5.Text = 0
        End If
    End Sub



    Public Class Form20
        Dim con As SqlConnection
        Dim cmd As SqlCommand
        Dim ds As DataSet = New DataSet()
        Dim adapt As SqlDataAdapter
        Dim adapt1 As SqlDataAdapter
        Public Property CrystalReportViewer1 As Object



    End Class




    Dim param_mois As Integer = mois

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


        Module1.connecter()



        ' ✅ Charger le rapport Crystal Reports
        Dim reportPath As String
        'reportPath = Access.PathCryst + "journal_ecritures.rpt"
        reportPath = Access.PathCryst + "journal001.rpt"
        ' ✅ Charger le rapport Crystal Reports
        Dim zfolio As String = TextBox1.Text.PadLeft(3, "0"c)
        Dim zmois As String = (ComboBox2.SelectedIndex + 1).ToString().PadLeft(2, "0"c)


        Dim searchQuery As String = "exec [FilterFecriture] " & TextBox1.Text & " , " & (ComboBox2.SelectedIndex + 1) & " ," & ComboBox1.Text & " , " & exec_proc.n1 & "  "


        Dim command As New SqlCommand(searchQuery, con)

        Dim adapter As New SqlDataAdapter(command)
        Dim table1 As New DataTable()
        adapter.Fill(table1)
        'DataGridView1.DataSource = table1

        Dim report As New ReportDocument()
        report.Load(reportPath)
        ' ✅ Associer la source de données au rapport
        report.SetDataSource(table1)
        report.SetParameterValue("folio2", zfolio)
        report.SetParameterValue("mois2", zmois)
        report.SetParameterValue("journl2", ComboBox1.Text)
        report.SetParameterValue("exerc2", exec_proc.n1)
        report.SetParameterValue("nom_soc", Access.nom_Soc)
        report.SetParameterValue("Nom_Journal", Label3.Text)

        report.SetParameterValue("annee", exec_proc.n1)
        report.SetParameterValue("code_journal", ComboBox1.Text)
        report.SetParameterValue("mois", zmois)
        report.SetParameterValue("folio", zfolio)





        ' ✅ Afficher dans un CrystalReportViewer
        Dim reportForm As New Form()
        Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        crystalReportViewer.Dock = DockStyle.Fill
        crystalReportViewer.ReportSource = report
        reportForm.Controls.Add(crystalReportViewer)
        reportForm.WindowState = FormWindowState.Maximized
        reportForm.Show()






        ''***********************************************************
        'Dim searchQuery As String = "exec [FilterFecriture] " & TextBox1.Text & " , " & (ComboBox2.SelectedIndex + 1) & " ," & ComboBox1.Text & " , " & exec_proc.n1 & "  "
        'Try



        '    ' ✅ Vérifier si les colonnes existent avant de renommer
        '    If DataGridView1.Columns.Contains("ER_ligne") Then DataGridView1.Columns("ER_ligne").HeaderText = "er_ligne"
        '    If DataGridView1.Columns.Contains("ER_JOUR") Then DataGridView1.Columns("ER_JOUR").HeaderText = "Jour"
        '    If DataGridView1.Columns.Contains("ER_CPARTIE") Then DataGridView1.Columns("ER_CPARTIE").HeaderText = "Compte"
        '    If DataGridView1.Columns.Contains("ER_npiece") Then DataGridView1.Columns("ER_npiece").HeaderText = "N.Piece"
        '    If DataGridView1.Columns.Contains("ER_LIBELLE") Then DataGridView1.Columns("ER_LIBELLE").HeaderText = "Libelle"
        '    If DataGridView1.Columns.Contains("DEBIT") Then DataGridView1.Columns("DEBIT").HeaderText = "Debit"
        '    If DataGridView1.Columns.Contains("CREDIT") Then DataGridView1.Columns("CREDIT").HeaderText = "Credit"

        '    Dim originalTable As DataTable = CType(DataGridView1.DataSource, DataTable)
        '    Dim dt As DataTable = originalTable.Copy()


        '    'dt.TableName = "DataTable1"
        '    dt.TableName = "FilterFecriture" ' 🔥 Remplace ici avec le nom exact dans le rapport !
        '    ' Crée un DataSet
        '    Dim ds As New DataSet("NewDataSet")
        '    ds.Tables.Add(dt)



        '    ' 📍 Lien obligatoire avec Crystal Report
        '    Dim reportPath As String = Access.PathCryst + "journal_ecritures.rpt"
        '    If Not IO.File.Exists(reportPath) Then
        '        MessageBox.Show("❌ Fichier Crystal introuvable : " & reportPath)
        '        Exit Sub
        '    End If

        '    Dim report As New ReportDocument()
        '    report.Load(reportPath)
        '    report.SetDataSource(ds)

        '    '******************************************************
        '    '   parametres pour etat
        '    '******************************************************
        '    Dim zfolio As String = TextBox1.Text.PadLeft(3, "0"c)
        '    Dim zmois As String = (ComboBox2.SelectedIndex + 1).ToString().PadLeft(2, "0"c)

        '    report.SetParameterValue("@folio2", zfolio)
        '    report.SetParameterValue("@mois2", zmois)
        '    report.SetParameterValue("@journl2", ComboBox1.Text)
        '    report.SetParameterValue("@exerc2", exec_proc.n1)
        '    report.SetParameterValue("@nom_soc", Access.nom_Soc)
        '    report.SetParameterValue("@Nom_Journal", Label3.Text)
        '    '******************************************************

        '    ' 🖥️ Affichage
        '    Dim reportForm As New Form()
        '    Dim crystalReportViewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer() With {
        '        .Dock = DockStyle.Fill,
        '        .ReportSource = report
        '    }
        '    reportForm.Controls.Add(crystalReportViewer)
        '    reportForm.WindowState = FormWindowState.Maximized
        '    reportForm.Show()





        'Catch ex As Exception
        '    MessageBox.Show("Erreur lors de la connexion à la base de données : " & ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    ' Fermer la connexion si ouverte
        '    If con.State = ConnectionState.Open Then con.Close()
        'End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs)

    End Sub
End Class