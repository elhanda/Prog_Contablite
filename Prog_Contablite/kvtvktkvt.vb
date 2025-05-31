
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class kvtvktkvt
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
            If Connectersoc() = True Then
                Try
                    con.Open()
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
    Sub select_facture()
        Try
            Dim req As String = String.Format(" 
select * from FFactClt where FC_EXERC = " & 2010 & "  
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

            'TextBox14.Text = dt.Rows(0)(9).ToString()
            DateTimePicker2.Text = dt.Rows(0)(10).ToString()
        Catch ex As Exception
            MessageBox.Show("Error de  select facture " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "


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
    Dim Fact_Mont As String
    Dim Fact_Mont_Reg As String
    Dim Fact_Res As String
    Dim dialog As DialogResult
    Sub reglement_smole()




        Try

            ComboBox3.Visible = False
            ComboBox4.Visible = False
            TextBox14.Visible = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False
            TextBox14.Enabled = False

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

    Sub test(fact, FF_CODE)
        Try
            Libelle_Compte(ComboBox4.Text)
            Dim Regtament_Libelle1 = value
            Dim sql = "select * from FFactFrs where FF_EXERC = 2010  and FF_NFACT = " & fact & " and FF_CODE  = " & FF_CODE & " "
            cmd = New SqlCommand(sql, con)

            adapt1 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapt1.Fill(dt)

            If dt.Rows.Count <> 0 Then
                MsgBox("there is a row hear")
                Fact_Mont = TextBox14.Text
                Fact_Mont_Reg = dt.Rows(0)(11).ToString()

                Fact_Res = Fact_Mont_Reg + Fact_Mont


                If TextBox8.Text > Fact_Res Then
                    dialog = MessageBox.Show("the reglement is not yet complet in the data  do you whant to compleat", "text", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    If dialog = DialogResult.OK Then



                        ins = 1
                        MsgBox("OK INS fact res  = 1")

                        DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                        DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                    Else

                        ins = 2
                        MsgBox("cansul INS fct res  = 2")
                    End If
                ElseIf TextBox8.Text > Fact_Mont Then
                    MsgBox("too beeg ft res ")
                Else
                    ins = 2
                    MsgBox("egale  INS fact res = 2")

                End If


            Else
                MsgBox("there is no  row hear")
                Fact_Mont = TextBox14.Text
                If TextBox8.Text > Fact_Mont Then
                    dialog = MessageBox.Show("the reglement is not yet complet do you whant to compleat", "text", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                    If dialog = DialogResult.OK Then

                        DataGridView1.Rows.Add("Regtament", ComboBox4.Text, Regtament_Libelle1, TextBox14.Text, "")

                        DataGridView1.Rows.Add("Journal", "Code :" + ComboBox3.Text, "", "", "")
                        'reglement_smole()
                        ins = 1
                        MsgBox("OK INS = 1")


                    Else
                        ins = 2
                        MsgBox("cansul INS = 2")

                    End If
                ElseIf TextBox8.Text > Fact_Mont Then
                    MsgBox("there is no  row hear")
                Else
                    ins = 2
                    MsgBox(" == INS = 2")

                End If












            End If






        Catch ex As Exception
            MessageBox.Show("Error de  test  " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub kvtvktkvt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Connecter()
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

            select_facture()







            'tb1.Name = "Textbox20"
            'tb1.Size = New Size(137, 26)
            'tb1.Location = New Point(487, 167)
            'Panel1.Controls.Add(tb1)

            'select_facture()
            'CB.Name = "ComboBox6"
            'CB.Size = New Size(117, 32)
            'CB.Location = New Point(985, 201)
            'Panel1.Controls.Add(CB)

            'CB1.Name = "ComboBox7"
            'CB1.Size = New Size(134, 32)
            'CB1.Location = New Point(558, 233)
            'Panel1.Controls.Add(CB1)

            'Dim req_FJournal As String = String.Format("select * from FJournal", New FileInfo(Application.ExecutablePath).DirectoryName)
            'Dim req_FPlanComptable As String = String.Format("select * from FPlanComptable", New FileInfo(Application.ExecutablePath).DirectoryName)


            'cmd = New SqlCommand(req_FJournal, con)
            'adapt1 = New SqlDataAdapter(cmd)
            'adapt1.Fill(ds, "FJournal")
            'CB.DisplayMember = "J_CODE"
            'CB.ValueMember = "J_LIBELLE "
            'CB.DataSource = ds.Tables("FJournal")

            'cmd = New SqlCommand(req_FPlanComptable, con)
            'adapt = New SqlDataAdapter(cmd)
            'adapt.Fill(ds, "FPlanComptable")
            'CB1.DisplayMember = "C_CODE"
            'CB1.ValueMember = "C_LIBELLE "
            'CB1.DataSource = ds.Tables("FPlanComptable")
            If ins = 1 Then
                'reglement_smole()
            End If
        Catch ex As Exception
            MessageBox.Show("Error de  select_compte" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cccc
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Try
            If ComboBox3.Text <> "" And ComboBox5.Text <> "" And ComboBox4.Text <> "" And TextBox14.Text Then
                test(ComboBox5.Text, ComboBox3.Text)

            Else
                MessageBox.Show("feild the blanks", "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error de  button" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub
End Class