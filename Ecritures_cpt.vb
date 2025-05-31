Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Ecriture

    'Dim con = ConnectionProget1.Connectersoc


    Dim cmd As SqlCommand
    Dim cmd3 As SqlCommand


    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter
    ReadOnly value As Integer
    Dim x As Integer = 0
    ReadOnly y As Integer
    Dim sum As Integer = 0
    Private i As Integer
    Sub Connecter()
        'If () Then

        Try
            If Connectersoc() = True Then
                Try
                    con.open()
                    'MsgBox("success")
                Catch ex As Exception
                    'MsgBox("faild")
                    con.Close()
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        'End If
    End Sub
    Sub Add(ER_EXERC, ER_JOURNL, ER_AN, ER_MOIS, ER_FOLIO, ER_COMPTE, ER_CPARTIE, ER_LIGNE, ER_JOUR, ER_LIBELLE, mont, b, ER_NPIECE)


        Try

            For Each c As Control In Panel3.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "text", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                        Exit For
                    End If
                End If
            Next

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    'MessageBox.Show("null" & a)
                    'MessageBox.Show("exercice = " & ER_EXERC)
                    'MessageBox.Show("journal = " & ER_JOURNL)
                    'MessageBox.Show("anne = " & ER_AN)
                    'MessageBox.Show("mont" & ComboBox2.SelectedIndex + 1)
                    'MessageBox.Show("flo = " & TextBox1.Text)
                    'MessageBox.Show("jour = " & ComboBox3.Text)
                    'MessageBox.Show("ligne = " & Label19.Text + (i - 1))
                    'MessageBox.Show("cpartie = " & ComboBox4.Text)
                    'MessageBox.Show("f10 = " & "null")
                    'MessageBox.Show("libelle = " & TextBox4.Text)
                    'MessageBox.Show("mont = " & i)
                    'MessageBox.Show("cho = " & TextBox3.Text)
                    'MessageBox.Show("exercice = " & TextBox5.Text)

                    '@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,@ER_COMPTE,@ER_CPARTIE,@ER_LIGNE,@ER_JOUR,@ER_LIBELLE,@mont ,@b,@ER_NPIECE
                    Dim req As String = "exec [insert_into_ECRIT001] " & ER_EXERC & ",N'" & ER_JOURNL & "'," & ER_AN & "," & ER_MOIS & "," & ER_FOLIO & ",N'" & ER_COMPTE & "',N'" & ER_CPARTIE & "'," & ER_LIGNE & "," & ER_JOUR & ",N'" & ER_LIBELLE & "'," & mont & "," & b & ",N'" & ER_NPIECE & "'"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer As SqlDataAdapter
                    adaptteeer = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("error de add" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                '  MessageBox.Show("تم التعديل بنجاح", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Panel5.Visible = False
                Panel4.Visible = True
                ComboBox3.Enabled = False
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try




    End Sub
    Sub Sup(ER_JOURNL, ER_MOIS, ER_FOLIO, ER_LIGNE, ER_EXERC, ER_JOUR)

        Try

            For Each c As Control In Panel3.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                        Exit For
                    End If
                End If
            Next

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to supprimer ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                'MessageBox.Show("journal = " & ER_JOURNL)
                'MessageBox.Show("mont = " & ER_MOIS)




                'MessageBox.Show("flo = " & ER_FOLIO)
                'MessageBox.Show("ligne = " & ER_LIGNE)
                'MessageBox.Show("exercice = " & ER_EXERC)
                'MessageBox.Show("jour = " & ER_JOUR)

                Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "

                    Dim req As String = "

  exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
                    '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer2 As SqlDataAdapter
                    adaptteeer2 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer2.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("Error de  delete" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try

                MessageBox.Show("la  supprimation  complite", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Panel5.Visible = False
                Panel4.Visible = True
                ComboBox3.Enabled = False
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try


    End Sub
    Sub Modif(ER_Compte, ER_CPARTIE, ER_LIBELLE, mont, choix, ER_NPIECE, ER_JOURNL, ER_MOIS, ER_FOLIO, ER_LIGNE, ER_EXERC, ER_JOUR)

        Try

            For Each c As Control In Panel3.Controls

                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

                    If c.Text = "" Then
                        MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                        Exit For
                    End If
                End If
            Next

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to modify ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    'MessageBox.Show("exercice = " & ER_EXERC)
                    'MessageBox.Show("journal = " & ER_JOURNL)

                    'MessageBox.Show("mois" & ER_MOIS)
                    'MessageBox.Show("flo = " & ER_FOLIO)
                    'MessageBox.Show("jour = " & ER_JOUR)
                    'MessageBox.Show("ligne = " & ER_LIGNE)
                    'MessageBox.Show("cpartie = " & ER_CPARTIE)
                    'MessageBox.Show("f10 = " & "null")
                    'MessageBox.Show("libelle = " & ER_LIBELLE)
                    'MessageBox.Show("mont = " & mont)
                    'MessageBox.Show("cho = " & choix)
                    'MessageBox.Show("ER_NPIECE = " & ER_NPIECE)

                    Dim req As String = "exec [update_into_Fecriture] '" & ER_Compte & "','" & ER_CPARTIE & "','" & ER_LIBELLE & "'," & mont & "," & choix & ",'" & ER_NPIECE & "','" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & "," & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("Error de update" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Try

                MessageBox.Show("تم التعديل بنجاح", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                Panel5.Visible = False
                Panel4.Visible = True
                ComboBox3.Enabled = False
                ComboBox4.Enabled = False
                ComboBox5.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try




    End Sub
    Public Sub Count()
        Try
            Label7.Text = DataGridVw1.Rows.Count.ToString()
            If Label7.Text = 0 Then
                Label19.Text = 1
            End If
            Label19.Text = Label7.Text + 1
        Catch ex As Exception
            MessageBox.Show("count : " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub Print(valueToSearch As String)
        Try
            Dim searchQuery As String = "
 select    
 distinct ER_LIGNE   ,ER_JOUR    ,ER_COMPTE,ER_CPARTIE ,ER_LIBELLE  , 
IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT',
IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI',ER_FOLIO,ER_MOIS,ER_JOURNL,ER_EXERC    from [ECRIT001] 
 WHERE ER_FOLIO LIKE " & valueToSearch & " and   ER_MOIS= " & (ComboBox2.SelectedIndex + 1) & "    And ER_JOURNL= " & ComboBox1.Text & "  And ER_EXERC=" & exec_proc.n1 & "
  group by ER_CODE ,ER_JOUR ,ER_LIGNE   ,ER_COMPTE,ER_CPARTIE, ER_LIBELLE    ,ER_FOLIO,ER_MOIS,ER_JOURNL,ER_EXERC
 "

            cmd = New SqlCommand(searchQuery, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = Me.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(4).ToString)
                isi.SubItems.Add(AB(5).ToString)
                isi.SubItems.Add(AB(6).ToString)
                isi.SubItems.Add(AB(7).ToString)
                isi.SubItems.Add(AB(8).ToString)
                isi.SubItems.Add(AB(9).ToString)
                isi.SubItems.Add(AB(10).ToString)
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            Dim dtable = New DataTable()
            With dtable

                .Columns.Add("Lign")
                .Columns.Add("jour")
                .Columns.Add("compte")
                .Columns.Add("contre_partie")
                .Columns.Add("libelle")
                .Columns.Add("debut")
                .Columns.Add("credit")
                .Columns.Add("Folio")
                .Columns.Add("month")
                .Columns.Add("code_Journal")
                .Columns.Add("ER_EXERC")
            End With

            dtable.Rows.Add()


            Dim columnValues(dtable.Columns.Count - 1) As Object
            For Each lvi As ListViewItem In ListView1.Items
                columnValues(0) = (lvi.SubItems(0).Text)
                columnValues(1) = (lvi.SubItems(1).Text)
                columnValues(2) = (lvi.SubItems(2).Text)
                columnValues(3) = (lvi.SubItems(3).Text)
                columnValues(4) = (lvi.SubItems(4).Text)
                columnValues(5) = (lvi.SubItems(5).Text)
                columnValues(6) = (lvi.SubItems(6).Text)
                columnValues(7) = (lvi.SubItems(7).Text)
                columnValues(8) = (lvi.SubItems(8).Text)
                columnValues(9) = (lvi.SubItems(9).Text)
                columnValues(10) = (lvi.SubItems(10).Text)
                dtable.Rows.Add(columnValues)
            Next

            'MsgBox(dtable.Rows.Count)
            If dtable.Rows.Count = 0 Then
                MessageBox.Show("No data Found", "CrystalReportWithOracle")
                Return
            End If
            Dim crystal As New EcritureReportData_final5
            crystal.SetDataSource(dtable)



            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = crystal
            GrandLivreReportViewer.Refresh()
            GrandLivreReportViewer.Show()
        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Public Sub FilterData(valueToSearch As String)
        Try
            If TextBox1.Text = "" Then
            End If
            Dim searchQuery As String = "select    
 distinct ER_LIGNE   ,

ER_JOUR    ,
ER_COMPTE,
ER_CPARTIE    ,
ER_LIBELLE      ,


 
IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'    from [ECRIT001] 
 WHERE ER_FOLIO LIKE   " & valueToSearch & " and   ER_MOIS=  " & (ComboBox2.SelectedIndex + 1) & "   And  ER_JOURNL=" & ComboBox1.Text & " And ER_EXERC=" & exec_proc.n1 & "
  group by ER_CODE ,

ER_JOUR    ,
ER_LIGNE   ,
ER_COMPTE,
ER_CPARTIE    ,

 ER_LIBELLE     


  "
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridVw1.DataSource = table
            'DataGridView1.DataSource = table
            Count()

            For i As Integer = 0 To DataGridVw1.Rows.Count() - 1 Step +1
                sum += DataGridVw1.Rows(i).Cells(6).Value
                x += DataGridVw1.Rows(i).Cells(5).Value
            Next

            TextBox8.Text = sum
            TextBox7.Text = x
            TextBox9.Text = TextBox8.Text - TextBox7.Text
        Catch ex As Exception
            'MessageBox.Show("filter" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Dim rs As New Form_Choix.Resizer

    Public Property Ds1 As DataSet
        Get
            Return ds
        End Get
        Set(value As DataSet)
            ds = value
        End Set
    End Property



    Public Property Rs1 As Form_Choix.Resizer
        Get
            Return rs
        End Get
        Set(value As Form_Choix.Resizer)
            rs = value
        End Set
    End Property

    Private Sub Form16_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: cette ligne de code charge les données dans la table 'Base_Compta_001DataSet1.ECRIT001'. Vous pouvez la déplacer ou la supprimer selon les besoins.

        Rs1.FindAllControls(Me)
        Connecter()
        Panel5.Visible = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        'count()

        Try

            FilterData(3)
            'combobox1 Code Journal :
            cmd = New SqlCommand("select * from FJournal", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(Ds1, "FJournal")
            ComboBox1.DisplayMember = "J_CODE"
            ComboBox1.ValueMember = "J_LIBELLE "
            ComboBox1.DataSource = Ds1.Tables("FJournal")
            'combobox1 Code Compte :
            cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE    ", con)
            adapt1 = New SqlDataAdapter(cmd)
            adapt1.Fill(Ds1, "ECRIT001")
            ComboBox4.DisplayMember = "ER_COMPTE"
            ComboBox4.ValueMember = "ER_COMPTE"
            ComboBox4.DataSource = Ds1.Tables("ECRIT001")
            cmd3 = New SqlCommand("select ER_CPARTIE from [ECRIT001] group by ER_CPARTIE order by ER_CPARTIE 
", con)
            adapt2 = New SqlDataAdapter(cmd3)
            adapt2.Fill(Ds1, "Fptable2")
            ComboBox5.DisplayMember = "ER_CPARTIE"
            ComboBox5.ValueMember = "ER_CPARTIE "
            ComboBox5.DataSource = Ds1.Tables("Fptable2")
            ''C_Partie ne doit pas saisie tout seul 


        Catch ex As Exception
            MessageBox.Show("load error" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
        End If
        'print(TextBox1.Text)
        FilterData(TextBox1.Text)
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
    Private Sub DataGridView1_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles DataGridVw1.RowPostPaint
        '  Label19.Text = (e.RowIndex + 2).ToString
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        cmd = New SqlCommand("select J_LIBELLE from FJournal where J_CODE =" & ComboBox1.Text & "", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(Ds1, "FJol")
        For Each dr As DataRow In Ds1.Tables("FJol").Rows
            Label3.Text = dr("J_LIBELLE").ToString()
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        i = 1
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



        If i = 1 Then
            '     MessageBox.Show("ajouter")
            Try
                If ComboBox4.Text <> "" And ComboBox5.Text <> "" Then
                    If TextBox5.Text <> "" Then

                        For i = 1 To 2 Step +1
                            '@ER_EXERC,@ER_JOURNL,@ER_AN,                                        @ER_MOIS,@ER_FOLIO,@ER_COMPTE,@ER_CPARTIE,            @ER_LIGNE               ,@ER_JOUR      ,@ER_LIBELLE,    @mont ,@b,@ER_NPIECE

                            Add(exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox4.Text, ComboBox5.Text, Label19.Text + (i - 1), ComboBox3.Text, TextBox4.Text, TextBox5.Text, i, TextBox3.Text)
                        Next

                    End If
                    If TextBox6.Text <> "" Then
                        For i = 2 To 1 Step -1

                            Add(exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox4.Text, ComboBox5.Text, Label19.Text + (i - 1), ComboBox3.Text, TextBox4.Text, TextBox6.Text, i, TextBox3.Text)
                        Next
                    End If
                Else
                    If TextBox5.Text <> "" Then


                        Add(exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox4.Text, ComboBox5.Text, Label19.Text + (i - 1), ComboBox3.Text, TextBox4.Text, TextBox5.Text, 1, TextBox3.Text)
                    Else

                        Add(exec_proc.n1, ComboBox1.Text, exec_proc.n1, ComboBox2.SelectedIndex + 1, TextBox1.Text, ComboBox4.Text, ComboBox5.Text, Label19.Text + (i - 1), ComboBox3.Text, TextBox4.Text, TextBox5.Text, 2, TextBox3.Text)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Error de add" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
        If i = 2 Then
            Try
                ' ER_CPARTIE & "' ,N'" & ER_LIBELLE & "'," & mont & "," &
                'choix & ",N'" & ER_NPIECE & "',N'" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & "
                '," & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR &
                If TextBox5.Text <> "" Then
                    'modif(ER_Compte,       ER_CPARTIE,      ER_LIBELLE, mont,       choix, ER_NPIECE,      ER_JOURNL,         ER_MOIS,                 ER_FOLIO,    ER_LIGNE,        ER_EXERC,       ER_JOUR)
                    Modif(ComboBox4.Text, ComboBox5.Text, TextBox4.Text, TextBox5.Text, 1, TextBox3.Text, ComboBox1.Text, ComboBox2.SelectedIndex + 1, TextBox1.Text, TextBox2.Text, exec_proc.n1, ComboBox3.Text)

                End If
                If TextBox6.Text <> "" Then

                    Modif(ComboBox4.Text, ComboBox5.Text, TextBox4.Text, TextBox6.Text, 2, TextBox3.Text, ComboBox1.Text, ComboBox2.SelectedIndex + 1, TextBox1.Text, TextBox2.Text, exec_proc.n1, ComboBox3.Text)

                End If


            Catch ex As Exception
                MessageBox.Show("modify" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
        If i = 3 Then
            Sup(ComboBox1.Text, ComboBox2.SelectedIndex + 1, TextBox1.Text, TextBox2.Text, exec_proc.n1, ComboBox3.Text)
        End If
    End Sub

    Private Sub TextBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox5.MouseClick
        If TextBox6.Text <> "" Then
            TextBox6.Enabled = False
        Else
            TextBox6.Enabled = True
        End If
    End Sub

    Private Sub TextBox6_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox6.MouseClick
        If TextBox5.Text <> "" Then
            TextBox5.Enabled = False
        Else
            TextBox5.Enabled = True
        End If
    End Sub

    Private Sub ComboBox4_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox4.MouseClick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridVw1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridVw1.Rows(index)
        'Label19
        TextBox2.Text = selecteRow.Cells(0).Value.ToString()
        ComboBox3.Text = selecteRow.Cells(1).Value.ToString()
        ComboBox4.Text = selecteRow.Cells(2).Value.ToString()
        ComboBox5.Text = selecteRow.Cells(3).Value.ToString()

        TextBox4.Text = selecteRow.Cells(4).Value.ToString()

        TextBox5.Text = selecteRow.Cells(5).Value.ToString()
        TextBox6.Text = selecteRow.Cells(6).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        i = 2
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'MessageBox.Show("anuller", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
        Panel5.Visible = False
        Panel4.Visible = True
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        i = 3
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

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click
        'Label7.Text = DataGridView1.Rows.Count.ToString()
        'Label19.Text = Label7.Text + 1
    End Sub

    Private Sub Ecriture_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Rs1.ResizeAllControls(Me)
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Print(TextBox1.Text)
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text <> "" Then
            TextBox5.Enabled = False
        Else
            TextBox5.Enabled = True
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If TextBox5.Text <> "" Then
            TextBox6.Enabled = False
        Else
            TextBox6.Enabled = True
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        'If Label7.Text = "" Then
        '    Label19.Text = 1

        'End If
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    'Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
    '    If TextBox6.Text <> "" Then
    '        TextBox6.Enabled = True
    '    Else
    '        TextBox6.Enabled = False
    '    End If
    'End Sub

    'Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
    '    If TextBox5.Text <> "" Then
    '        TextBox5.Enabled = False
    '    Else
    '        TextBox5.Enabled = True
    '    End If
    'End Sub
End Class