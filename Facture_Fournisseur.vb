Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class Facture_Fournisseur
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim dt As DataTable = New DataTable()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim index As Integer
    Dim value As String
    Dim x As Integer = 0
    Dim sum As Integer = 0
    Dim C_CODE As Integer
    Private exer = exec_proc.n1
    Dim ins As Integer = 0
    Dim tb1 As New TextBox
    Dim CB1 As New ComboBox
    Dim CB As New ComboBox
    'Private combo As ComboBox


    Sub Connecter()
        'If () Then

        Try
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf;Integrated Security=True;")
            'If Connectersoc() = True Then
            Try
                    con.Open()
                    'MsgBox("success")
                Catch ex As Exception
                    'MsgBox("faild")
                    con.Close()
                End Try
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        'End If
    End Sub
    Sub Libelle_Compte(code)
        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "

            Dim req As String = String.Format(" 
                             SELECT *  FROM [FPlanComptable]  where C_CODE = '" & code & "' 
", New FileInfo(Application.ExecutablePath).DirectoryName)

            cmd = New SqlCommand(req, con)

            adapt1 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapt1.Fill(dt)
            value = dt.Rows(0)(2).ToString()



        Catch ex As Exception
            MessageBox.Show("Error de  select_compte" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub



    Sub insert(id, FF_NFACT, FF_CODE, FF_DATE, FF_NCOMPTE, FF_TTC, FF_TVA, FF_HT, FF_REGLE, Ff_DATEECHAN, FF_MNREGLE)
        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "
            '(" & id & "," & FC_NFACT & "," & FC_CODE & ",'" & FC_DATE & "'," & FC_NCOMPTE & "," & FC_TTC & "," & FC_TVA & "," & FC_HT & "," & FC_REGLE & ",'" & FC_DATEECHAN & "'," & FC_MNREGLE & ")
            Dim req As String = String.Format(" 
   insert into [C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf].[dbo].FFactFrs values(" & id & ",2010," & FF_NFACT & "," & FF_CODE & ",'" & FF_DATE & "'," & FF_NCOMPTE & "," & FF_TTC & "," & FF_TVA & "," & FF_HT & "," & FF_REGLE & ",'" & Ff_DATEECHAN & "'," & FF_MNREGLE & ")
", New FileInfo(Application.ExecutablePath).DirectoryName)

            cmd = New SqlCommand(req, con)

            adapt1 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapt1.Fill(dt)
            MessageBox.Show("insert avec succ ")



        Catch ex As Exception
            MessageBox.Show("Error de  insert" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Sub insert_Ecrit(ER_EXERC, ER_JOURNL, ER_AN, ER_MOIS, ER_FOLIO, ER_COMPTE, ER_CPARTIE, ER_LIGNE, ER_JOUR, ER_LIBELLE, mont, b, ER_NPIECE)

        Try

            'For Each c As Control In Panel1.Controls

            '    If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

            '        If c.Text = "" Then
            '            MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "text", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            Return
            '            Exit For
            '        End If
            '    End If
            'Next

            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Try
                    '" & ER_EXERC & ",N'" & ER_JOURNL & "'," & ER_AN & "," & ER_MOIS & "," & ER_FOLIO & ",N'" & ER_COMPTE & "',N'" & ER_CPARTIE & "'," & ER_LIGNE & "," & ER_JOUR & ",N'" & ER_LIBELLE & "'," & mont & "," & b & ",N'" & ER_NPIECE & "'" & ER_NPIECE & "
                    Dim req As String = "insert into ECRIT001 values(" & ER_EXERC & ",N'" & ER_JOURNL & "'," & ER_AN & "," & ER_MOIS & "," & ER_FOLIO & ",N'" & ER_COMPTE & "',N'" & ER_CPARTIE & "'," & ER_LIGNE & "," & ER_JOUR & ",N'" & ER_LIBELLE & "'," & mont & ",'" & b & "',N'" & ER_NPIECE & "')"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer As SqlDataAdapter
                    adaptteeer = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("error de add" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                MessageBox.Show("insert success", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)


            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try



    End Sub




    Sub select_facture()
        Try
            Dim req As String = String.Format(" 
select * from [C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf].[dbo].FFactFrs  where FF_EXERC = 2010  
", New FileInfo(Application.ExecutablePath).DirectoryName)

            cmd = New SqlCommand(req, con)

            adapt1 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapt1.Fill(dt)
            ComboBox5.DisplayMember = "FF_NFACT"
            ComboBox5.ValueMember = "FF_NFACT"
            ComboBox5.DataSource = dt
            'TextBox1.Text = dt.Rows(0)(3).ToString()

            'ComboBox5.Text = dt.Rows(0)(2).ToString()

            'TextBox8.Text = dt.Rows(0)(6).ToString()

            'TextBox10.Text = dt.Rows(0)(7).ToString()

            'TextBox12.Text = dt.Rows(0)(8).ToString()

            'TextBox14.Text = dt.Rows(0)(9).ToString()
            'DateTimePicker2.Text = dt.Rows(0)(10).ToString()
        Catch ex As Exception
            MessageBox.Show("Error de  select facture " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "


    End Sub


    Sub select_facture_choix(fact, FF_CODE, FF_NCOMPTE)
        Try
            Dim req As String = String.Format(" 
select * from [C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf].[dbo].FFactFrs where FF_EXERC = 2010  and FF_NFACT = " & fact & " and FF_CODE  = " & FF_CODE & " and FF_NCOMPTE = " & FF_NCOMPTE & " 
", New FileInfo(Application.ExecutablePath).DirectoryName)

            cmd = New SqlCommand(req, con)

            adapt1 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapt1.Fill(dt)
            ComboBox5.DisplayMember = "FF_NFACT"
            ComboBox5.ValueMember = "FF_NFACT"
            ComboBox5.DataSource = dt
            TextBox1.Text = dt.Rows(0)(3).ToString()

            ComboBox5.Text = dt.Rows(0)(2).ToString()

            TextBox8.Text = dt.Rows(0)(6).ToString()

            TextBox10.Text = dt.Rows(0)(7).ToString()

            TextBox12.Text = dt.Rows(0)(8).ToString()

            TextBox14.Text = dt.Rows(0)(9).ToString()
            DateTimePicker2.Text = dt.Rows(0)(10).ToString()
            select_facture()
        Catch ex As Exception
            MessageBox.Show("Error de  select facture " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "


    End Sub


    Dim Fact_Mont As String
    Dim Fact_Mont_Reg As String
    'Fact_Res As Integer
    Dim dialog As DialogResult

    Sub test(fact, FF_CODE, FF_NCOMPTE)
        Try
            If ComboBox3.Text <> "" And ComboBox4.Text <> "" And TextBox14.Text <> "" And ComboBox5.Text <> "" Then


                Fact_Mont = TextBox14.Text

                Dim sql = "select * from [C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf].[dbo].FFactFrs where FF_EXERC = 2010  and FF_NFACT = " & fact & " and FF_CODE  = " & FF_CODE & " and FF_NCOMPTE = " & FF_NCOMPTE & " "
                cmd = New SqlCommand(sql, con)

                adapt1 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt1.Fill(dt)


                If dt.Rows.Count <> 0 Then
                    MsgBox("there is a row hear")
                    Fact_Mont_Reg = dt.Rows(0)(9)

                    Dim Fact_Res = Convert.ToInt32(TextBox14.Text) + Convert.ToInt32(Fact_Mont_Reg)
                    MsgBox(Fact_Res)
                    If TextBox8.Text > Fact_Res Then
                        dialog = MessageBox.Show("the reglement is not yet complet in the data  do you whant to compleat", "text", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        If dialog = DialogResult.OK Then



                            ins = 1
                            MsgBox("OK INS fact res  = 1")

                            'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                            'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                        Else
                            'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                            'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                            ins = 2
                            MsgBox("cansul INS fct res  = 2")
                        End If
                    ElseIf TextBox8.Text < Fact_Res Then

                        MsgBox("too beeg ft res ")
                    Else
                        'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                        'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                        ins = 2
                        MsgBox("egale  INS fact res = 2")


                    End If







                Else
                    MsgBox("there is no  row hear")
                    Fact_Mont = TextBox14.Text
                    If TextBox8.Text > Fact_Mont Then
                        dialog = MessageBox.Show("the reglement is not yet complet do you whant to compleat", "text", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                        If dialog = DialogResult.OK Then

                            'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                            'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                            'reglement_smole()
                            ins = 1
                            MsgBox("OK INS = 1")


                        Else
                            'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                            'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                            ins = 2
                            MsgBox("cansul INS = 2")

                        End If
                    ElseIf TextBox8.Text > Fact_Mont Then
                        MsgBox("there is no  row hear")
                    Else
                        'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                        'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                        ins = 2
                        MsgBox(" == INS = 2")

                    End If






                End If






            Else



                MsgBox(" field the blanks")




            End If






        Catch ex As Exception
            MessageBox.Show("Error de  test  " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

















    Sub reglement_smole()




        Try



            tb1.Name = "Textbox20"
            tb1.Size = New Size(137, 26)
            tb1.Location = New Point(487, 167)
            Panel1.Controls.Add(tb1)


            CB.Name = "ComboBox6"
            CB.Size = New Size(117, 32)
            CB.Location = New Point(985, 201)
            Panel1.Controls.Add(CB)

            CB1.Name = "ComboBox7"
            CB1.Size = New Size(134, 32)
            CB1.Location = New Point(558, 233)
            Panel1.Controls.Add(CB1)

            Dim req_FJournal As String = String.Format("select * from FJournal", New FileInfo(Application.ExecutablePath).DirectoryName)
            Dim req_FPlanComptable As String = String.Format("select * from FPlanComptable", New FileInfo(Application.ExecutablePath).DirectoryName)


            cmd = New SqlCommand(req_FJournal, con)
            adapt1 = New SqlDataAdapter(cmd)
            adapt1.Fill(ds, "FJournal")
            CB.DisplayMember = "J_CODE"
            CB.ValueMember = "J_LIBELLE "
            CB.DataSource = ds.Tables("FJournal")

            cmd = New SqlCommand(req_FPlanComptable, con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "FPlanComptable")
            CB1.DisplayMember = "C_CODE"
            CB1.ValueMember = "C_LIBELLE "
            CB1.DataSource = ds.Tables("FPlanComptable")






        Catch ex As Exception
            MessageBox.Show("Error de  reglement_smole" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


    End Sub






















    Private Sub Facture_Fournisseur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf;Integrated Security=True;")
            select_facture()
            'Dim conlist As String = String.Format("select * from [{0}\Data\BASE_COMPTA_001].[dbo].FFactClt where FC_EXERC = " & exec_proc.n1 & "", New FileInfo(Application.ExecutablePath).DirectoryName)
            'cmd = New SqlCommand(conlist, con)

            'adapt1 = New SqlDataAdapter(cmd)
            'Dim dt = New DataTable()
            'adapt1.Fill(dt)
            'MsgBox(dt)


            DataGridView1.Rows.Add("Client")
            DataGridView1.Rows.Add("TVA")
            DataGridView1.Rows.Add("Vente")
            DataGridView1.Rows.Add("Regtament")
            DataGridView1.Rows.Add("Client")
            DataGridView1.Rows.Add("Journal")
            'Dim req As String = String.Format(" 
            'select * from FFactClt where FC_EXERC = '" & exec_proc.n1 & "'  
            '", New FileInfo(Application.ExecutablePath).DirectoryName)

            'cmd = New SqlCommand(req, con)

            'adapt1 = New SqlDataAdapter(cmd)
            'Dim dt1 = New DataTable()
            'adapt1.Fill(dt1)
            'ComboBox5.DisplayMember = "FC_NFACT"
            'ComboBox5.ValueMember = "FC_NFACT"
            'ComboBox5.DataSource = dt1

            Try
                ConnecterHome()
                con.Open()
                Dim req11 As String = String.Format("select * from Saisie_de_Parametre_Table", New FileInfo(Application.ExecutablePath).DirectoryName)
                cmd = New SqlCommand(req11, con)
                adapt = New SqlDataAdapter(cmd)
                'Dim dt = New DataTable()
                adapt.Fill(dt)
                TextBox1.Text = dt.Rows(0)(1).ToString()
                TextBox3.Text = dt.Rows(0)(9).ToString()
                TextBox9.Text = dt.Rows(0)(4).ToString()
                TextBox11.Text = dt.Rows(0)(7).ToString()
                TextBox13.Text = dt.Rows(0)(5).ToString()
                con.Close()
            Catch ex As Exception
                MessageBox.Show("Error de  connect home  " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End Try

            '[{0}\Data\BASE_COMPTA_Soc].[dbo].

            Dim req_FJournal As String = String.Format("select * from FJournal", New FileInfo(Application.ExecutablePath).DirectoryName)
            Dim req_FPlanComptable As String = String.Format("select * from FPlanComptable", New FileInfo(Application.ExecutablePath).DirectoryName)


            cmd = New SqlCommand(req_FJournal, con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "FJournal")
            ComboBox3.DisplayMember = "J_CODE"
            ComboBox3.ValueMember = "J_LIBELLE "
            ComboBox3.DataSource = ds.Tables("FJournal")

            cmd = New SqlCommand(req_FPlanComptable, con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, "FPlanComptable")
            ComboBox4.DisplayMember = "C_CODE"
            ComboBox4.ValueMember = "C_LIBELLE "
            ComboBox4.DataSource = ds.Tables("FPlanComptable")



            'For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
            '    sum += DataGridView1.Rows(i).Cells(4).Value
            '    x += DataGridView1.Rows(i).Cells(3).Value
            'Next

            'TextBox18.Text = sum
            'TextBox19.Text = x
            'TextBox17.Text = TextBox18.Text - TextBox19.Text




            'If ins <> 0 Then
            '    reglement_smole()

            'End If






            '            'ComboBox3.SelectedIndex = -1
            '            'ComboBox4.SelectedIndex = -1
        Catch ex As Exception
            MsgBox("Faild load " + ex.Message)
        End Try


    End Sub



    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Try
            If TextBox8.Text = "" Then
                TextBox12.Text = ""
                TextBox10.Text = ""
            Else
                Dim value1 = TextBox8.Text / 1.2
                TextBox12.Text = value1
                TextBox10.Text = TextBox8.Text - value1
                DataGridView1.Refresh()

                Libelle_Compte(TextBox9.Text)
                Dim Client_Libelle = value


                Libelle_Compte(TextBox11.Text)
                Dim TVA_Libelle = value


                Libelle_Compte(TextBox13.Text)
                Dim Vente_Libelle = value


                Libelle_Compte(ComboBox4.Text)
                Dim Regtament_Libelle = value


                'Libelle_Compte(TextBox9.Text)
                'Dim Journal_Libelle = value

                DataGridView1.Rows.Clear()
                DataGridView1.Rows.Add("Client", TextBox9.Text, Client_Libelle, "", TextBox8.Text)
                DataGridView1.Rows.Add("TVA", TextBox11.Text, TVA_Libelle, TextBox10.Text, "")
                DataGridView1.Rows.Add("Vente", TextBox13.Text, Vente_Libelle, TextBox12.Text, "")
                DataGridView1.Rows.Add("Autre Mont")
                DataGridView1.Rows.Add("Autre Mont")
                DataGridView1.Rows.Add("Autre Mont")
                DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle, "", TextBox14.Text)
                DataGridView1.Rows.Add("Client", TextBox9.Text, Client_Libelle, TextBox14.Text, "")
                DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")




            End If

        Catch ex As Exception
            MsgBox("Faild" + ex.Message)
        End Try
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        index = e.RowIndex
        Dim SelectedRow As DataGridViewRow
        SelectedRow = DataGridView1.Rows(index)




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'DataGridView1.Item(1, 1).Value = "Client"


        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add("Client")
        DataGridView1.Rows.Add("TVA")
        DataGridView1.Rows.Add("Vente")
        DataGridView1.Rows.Add("Autre Mont")
        DataGridView1.Rows.Add("Autre Mont")
        DataGridView1.Rows.Add("Autre Mont")
        DataGridView1.Rows.Add("Regtament")
        DataGridView1.Rows.Add("Client")
        DataGridView1.Rows.Add("Journal")

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        TextBox13.Enabled = True

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

        TextBox10.Text = ""

        TextBox12.Text = ""

        TextBox14.Text = ""

    End Sub





    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If e.ThrowException = True Then
            e.ThrowException = False

        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.ModifiedChanged
        'TextBox4.Text =
        'TextBox7.Text = "Num Facture :" + TextBox4.Text
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "C" Then
            TextBox16.Text = "caisse"

        End If
        If ComboBox2.Text = "B" Then
            TextBox16.Text = "Bank"
        End If
        If ComboBox2.Text = "P" Then
            TextBox16.Text = "Post"
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        'Libelle_Compte(TextBox9.Text)
        'Dim Client_Libelle = value


        'Libelle_Compte(TextBox11.Text)
        'Dim TVA_Libelle = value


        'Libelle_Compte(TextBox13.Text)
        'Dim Vente_Libelle = value


        'Libelle_Compte(ComboBox4.Text)
        'Dim Regtament_Libelle = value


        'Libelle_Compte(TextBox9.Text)
        'Dim Journal_Libelle = value

        'DataGridView1.Rows.Clear()
        'DataGridView1.Rows.Add("Client", TextBox9.Text, Client_Libelle, TextBox8.Text, "")
        'DataGridView1.Rows.Add("TVA", TextBox11.Text, TVA_Libelle, "", TextBox10.Text)
        'DataGridView1.Rows.Add("Vente", TextBox13.Text, Vente_Libelle, "", TextBox12.Text)
        'DataGridView1.Rows.Add("Autre Mont")
        'DataGridView1.Rows.Add("Autre Mont")
        'DataGridView1.Rows.Add("Autre Mont")
        'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle, TextBox14.Text, "")
        'DataGridView1.Rows.Add("Client", TextBox9.Text, Client_Libelle, "", TextBox14.Text)
        'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
        'Try
        '    If ComboBox3.Text <> "" And ComboBox5.Text <> "" And ComboBox4.Text <> "" And TextBox14.Text <> "" Then
        '        test(ComboBox5.Text, ComboBox3.Text)

        '    Else
        '        MessageBox.Show("feild the blanks", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Error de  button" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'End Try


    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Libelle_Compte(TextBox9.Text)
        Dim Client_Libelle = value


        Libelle_Compte(TextBox11.Text)
        Dim TVA_Libelle = value


        Libelle_Compte(TextBox13.Text)
        Dim Vente_Libelle = value


        Libelle_Compte(ComboBox4.Text)
        Dim Regtament_Libelle = value


        'Libelle_Compte(TextBox9.Text)
        'Dim Journal_Libelle = value

        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add("Client", TextBox9.Text, Client_Libelle, TextBox8.Text, "")
        DataGridView1.Rows.Add("TVA", TextBox11.Text, TVA_Libelle, "", TextBox10.Text)
        DataGridView1.Rows.Add("Vente", TextBox13.Text, Vente_Libelle, "", TextBox12.Text)
        DataGridView1.Rows.Add("Autre Mont")
        DataGridView1.Rows.Add("Autre Mont")
        DataGridView1.Rows.Add("Autre Mont")
        DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle, TextBox14.Text, "")
        DataGridView1.Rows.Add("Client", TextBox9.Text, Client_Libelle, "", TextBox14.Text)
        DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")


    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Dim i As Integer = 0

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        're
        i += 1
        Libelle_Compte(ComboBox4.Text)
        Dim Regtament_Libelle1 = value

        If ins = 1 Then
            'Dim sql = "select * from [C:\Users\ayoub\Desktop\Data\Base_Compta_001.mdf].[dbo].FFactFrs where FF_EXERC = 2010  and FF_NFACT = " & fact & " and FF_CODE  = " & FF_CODE & " and FF_NCOMPTE = " & FF_NCOMPTE & " "
            'cmd = New SqlCommand(sql, con)

            'adapt1 = New SqlDataAdapter(cmd)
            'Dim dt = New DataTable()
            'adapt1.Fill(dt)

            'If dt.Rows.Count <> 0 Then
            '    req = " "
            'End If




















            MessageBox.Show("1", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

            DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
            insert(i, ComboBox5.Text, TextBox1.Text, DateTimePicker1.Value, TextBox9.Text, TextBox8.Text, TextBox10.Text, TextBox12.Text, TextBox14.Text, DateTimePicker2.Value, TextBox14.Text)
            '        insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox9.Text, TextBox9.Text, 1, DateTime.Now.Day, Client_Libelle, TextBox8.Text, "C", TextBox6.Text)
            '        insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox11.Text, TextBox11.Text, 1, DateTime.Now.Day, TVA_Libelle, TextBox8.Text, "C", TextBox6.Text)
            '        insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox13.Text, TextBox13.Text, 1, DateTime.Now.Day, Vente_Libelle, TextBox8.Text, "C", TextBox6.Text)
            ins = 0
        Else
            MessageBox.Show("2", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

            DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
            insert(i, ComboBox5.Text, TextBox1.Text, DateTimePicker1.Value, TextBox9.Text, TextBox8.Text, TextBox10.Text, TextBox12.Text, TextBox14.Text, DateTimePicker2.Value, TextBox14.Text)
            ins = 0
        End If

        'Dim dialog As DialogResult
        'Libelle_Compte(TextBox9.Text)
        'Dim Client_Libelle = value
        'Libelle_Compte(TextBox11.Text)
        'Dim TVA_Libelle = value
        'Libelle_Compte(TextBox13.Text)
        'Dim Vente_Libelle = value
        'Libelle_Compte(ComboBox4.Text)
        'Dim Regtament_Libelle = value
        'Libelle_Compte(CB1.Text)
        'Dim Regtament_Libelle1 = value
        'If TextBox14.Text < TextBox8.Text Then
        '    dialog = MessageBox.Show("the reglement is not yet complet do you whant to compleat", "text", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        '    If dialog = DialogResult.OK Then
        '        'TextBox1.Enabled = False
        '        'TextBox2.Enabled = False
        '        'TextBox3.Enabled = False
        '        'ComboBox5.Enabled = False
        '        'TextBox6.Enabled = False
        '        'TextBox7.Enabled = False
        '        'TextBox8.Enabled = False
        '        'TextBox9.Enabled = False
        '        ''TextBox10.Enabled = False
        '        ''TextBox11.Enabled = False
        '        'TextBox12.Enabled = False
        '        'TextBox13.Enabled = False
        '        ''TextBox14.Visible = False
        '        ''ComboBox3.Visible = False
        '        ''ComboBox4.Visible = False
        '        'ComboBox1.Enabled = False
        '        'DateTimePicker1.Enabled = False
        '        'Libelle_Compte(ComboBox4.Text)
        '        'Dim Regtament_Libelle = value

        '        'DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle, TextBox14.Text, "")

        '        'DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
        '        ins = 1
        '    Else
        '        MessageBox.Show("the  sql statement is here 1 ")
        '        insert(1, ComboBox5.Text, TextBox1.Text, DateTimePicker1.Value, TextBox9.Text, TextBox8.Text, TextBox10.Text, TextBox12.Text, TextBox14.Text, DateTimePicker2.Value, TextBox14.Text)
        '        insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox9.Text, TextBox9.Text, 1, DateTime.Now.Day, Client_Libelle, TextBox8.Text, "C", TextBox6.Text)
        '        insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox11.Text, TextBox11.Text, 1, DateTime.Now.Day, TVA_Libelle, TextBox8.Text, "C", TextBox6.Text)
        '        insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox13.Text, TextBox13.Text, 1, DateTime.Now.Day, Vente_Libelle, TextBox8.Text, "C", TextBox6.Text)
        '        ' insert_Ecrit(ER_EXERC, ER_JOURNL, ER_AN, ER_MOIS, ER_FOLIO, ER_COMPTE, ER_CPARTIE, ER_LIGNE, ER_JOUR, ER_LIBELLE, mont, b, ER_NPIECE)
        '        MessageBox.Show("ok ")
        '    End If
        'ElseIf TextBox14.Text > TextBox8.Text Then
        '    MessageBox.Show("the reglement is too beeg ", "text", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'ElseIf TextBox14.Text = TextBox8.Text Then
        '    insert(1, ComboBox5.Text, TextBox1.Text, DateTimePicker1.Value, TextBox9.Text, TextBox8.Text, TextBox10.Text, TextBox12.Text, TextBox14.Text, DateTimePicker2.Value, TextBox14.Text)
        '    insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox9.Text, TextBox9.Text, 1, DateTime.Now.Day, Client_Libelle, TextBox8.Text, "C", TextBox6.Text)
        '    insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox11.Text, TextBox11.Text, 1, DateTime.Now.Day, TVA_Libelle, TextBox8.Text, "C", TextBox6.Text)
        '    insert_Ecrit(exec_proc.n1, TextBox1.Text, DateTime.Now.Year, DateTime.Now.Month, TextBox2.Text, TextBox13.Text, TextBox13.Text, 1, DateTime.Now.Day, Vente_Libelle, TextBox8.Text, "C", TextBox6.Text)
        '    MessageBox.Show("the  sql statement is here 2 ")
        'End If
        'If ins <> 0 Then
        'End If
    End Sub

    Private Sub TextBox14_TextChanged(sender As Object, e As EventArgs) Handles TextBox14.TextChanged
        If ins <> 0 Then





            'tb1.Name = "Textbox20"
            'tb1.Size = New Size(137, 26)
            'tb1.Location = New Point(487, 167)
            'Me.Controls.Add(tb1)

            'Dim CB As New ComboBox
            'CB.Name = "ComboBox6"
            'CB.Size = New Size(117, 32)
            'CB.Location = New Point(985, 201)
            'Me.Controls.Add(CB)
            'Dim CB1 As New ComboBox
            'CB1.Name = "ComboBox7"
            'CB1.Size = New Size(134, 32)
            'CB1.Location = New Point(558, 233)
            'Me.Controls.Add(CB1)

            'Dim req_FJournal As String = String.Format("select * from FJournal", New FileInfo(Application.ExecutablePath).DirectoryName)
            'Dim req_FPlanComptable As String = String.Format("select * from FPlanComptable", New FileInfo(Application.ExecutablePath).DirectoryName)


            'cmd = New SqlCommand(req_FJournal, con)
            'adapt = New SqlDataAdapter(cmd)
            'adapt.Fill(ds, "FJournal")
            'CB.DisplayMember = "J_CODE"
            'CB.ValueMember = "J_LIBELLE "
            'CB.DataSource = ds.Tables("FJournal")

            'cmd = New SqlCommand(req_FPlanComptable, con)
            'adapt = New SqlDataAdapter(cmd)
            'adapt.Fill(ds, "FPlanComptable")
            'CB1.DisplayMember = "C_CODE"
            'CB1.ValueMember = "C_LIBELLE "
            'CB1.DataSource = ds.Tables("FPlanComptable")











        End If

    End Sub





    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        select_facture_choix(ComboBox5.Text, ComboBox3.Text, ComboBox4.Text)
        TextBox7.Text = "Num Facture :" + ComboBox5.Text
    End Sub

    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave

    End Sub

    Private Sub Panel1_MouseEnter(sender As Object, e As EventArgs) Handles Panel1.MouseEnter
        Try
            test(ComboBox5.Text, ComboBox3.Text, ComboBox4.Text)
        Catch ex As Exception
            MsgBox("error de panel" + ex.Message)
        End Try
    End Sub
End Class