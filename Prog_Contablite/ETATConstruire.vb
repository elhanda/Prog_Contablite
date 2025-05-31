Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms

Public Class ETATConstruire
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As Integer
    Public id_val As Integer


    Public Sub ResizeControls(ByVal scaleFactor As Double)
        For Each ctrl As Control In Me.Controls
            ctrl.Left = CInt(ctrl.Left * scaleFactor)
            ctrl.Top = CInt(ctrl.Top * scaleFactor)
            ctrl.Width = CInt(ctrl.Width * scaleFactor)
            ctrl.Height = CInt(ctrl.Height * scaleFactor)
        Next
    End Sub


    Sub aff()
        Try
            'MsgBox(TextBox8.Text)

            Dim searchQuery As String = IIf(Len(TextBox8.Text) = 0,
                                "select 
            id,Code_de_Letat,Nom_de_etat,Titre_de_lign as 'Titre de  Lign ',Titre_de_col AS 'Titre de Column',
                                Compte_de_Letat as 'Compte',Ligne_de_etat as 'Ligne',Column_de_etat as 'Columne',
                                P_Code_debut as 'Code debut',P_Code_fin as 'Code Fin',iif(anne=0,'Année en cours','Année Précédente') as Annee ,Sance as 'Sens' 
                                From Etat_Generater Order By Nom_de_etat, Ligne_de_etat, Column_de_etat, Compte_de_Letat ",
                                "select 
                                id,Code_de_Letat,Nom_de_etat,Titre_de_lign AS 'Titre de Lign',Titre_de_Col as 'Titre de  Column ',
                                Compte_de_Letat as 'Compte',Ligne_de_etat as 'Ligne',Column_de_etat as 'Columne',P_Code_debut as 'Code debut',
                                P_Code_fin as 'Code Fin',anne ,Sance as 'Sens' 
                                From Etat_Generater
                                Where code_de_letat ='" & TextBox8.Text & " '
                                order by Nom_de_etat,Ligne_de_etat,Column_de_etat ,Compte_de_Letat")



            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table

        Catch ex As Exception
            MessageBox.Show("Error de l'affichage" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub Add(TextBox8, TextBox5, TextBox9, TextBox6, combobox3, TextBox2, textbox3, textbox4, textbox7, combobox2, combobox4)

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

                    'insert into Fparam_Base  values('Code_de_Letat','Nom_de_etat','Titre_de_etat',Ligne_de_etat,Column_de_etat,'P_Code','anne')
                    'Module1.connecter()

                    Dim req As String = "insert into Etat_Generater (Code_de_Letat,Nom_de_etat,Titre_de_Lign,Titre_de_col,Compte_de_Letat,
                                                                     Ligne_de_etat,Column_de_etat,P_Code_debut,P_Code_fin,anne, Sance)
                                        values('" & TextBox8 & "','" & TextBox5 & "','" & TextBox9 & "','" & TextBox6 & "'," & combobox3 & "," & TextBox2 & "," & textbox3 & ",'" & textbox4 & "','" & textbox7 & "','" & combobox2 & "', '" & combobox4 & "')"






                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)
                    aff()

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

            TextBox2.Enabled = False
            textbox3.Enabled = False
            'ComboBox1.Enabled = False
            textbox4.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Sub Modif(TextBox8, TextBox5, TextBox9, TextBox6, Combobox3, TextBox2, textbox3, textbox4, combobox7, combobox2, combobox4)
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



                    Dim req As String = "update Etat_Generater set Code_de_Letat= '" & TextBox8 & "',Nom_de_etat= '" & TextBox5 & "',Titre_de_Lign='" & TextBox9 & "', Titre_de_col= '" & TextBox6 & "' ,Compte_de_Letat = '" & Combobox3 & "',
                    Ligne_de_etat = " & TextBox2 & ",Column_de_etat= " & textbox3 & ",P_Code_debut= '" & textbox4 & "',P_Code_fin='" & TextBox7 & "',anne ='" & combobox2 & "', Sance='" & combobox4 & "' where
                     id = " & id_val & "
  "
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)
                    aff()

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

            TextBox2.Enabled = False
            textbox3.Enabled = False
            ' ComboBox1.Enabled = False
            'ComboBox2.Enabled = False
        Catch ex As Exception

        End Try

    End Sub
    Sub sup(TextBox8)
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
                    '    ''''''''''''''''''' dalete the data  ''''''''''''


                    '   Module1.connecter()
                    Dim req As String = "delete  from Etat_Generater where id = " & id_val & ""
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)
                    aff()

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
            'TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            '   ComboBox1.Enabled = False
            'ComboBox2.Enabled = False
        Catch ex As Exception

        End Try

    End Sub


    Dim rs As New Form_Choix

    Private Sub ETATConstruire_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ResizeControls(1.5)
        '   rs.FindAllControls(Me)
        Try

            Module1.connecter()
            aff()
            'ComboBox2.Items.Add(exec_proc.n1)
            'ComboBox2.Items.Add(exec_proc.n1 - 1)
            ComboBox2.Items.Add(0)
            ComboBox2.Items.Add(-1)


            With table
                .Columns.Add("id")
                .Columns.Add("Code_de_Letat")
                .Columns.Add("Nom_de_etat")
                .Columns.Add("Titre_de_Lign")
                .Columns.Add("Titre_de_Col")
                .Columns.Add("Compte_de_Letat")
                .Columns.Add("Ligne_de_etat")
                .Columns.Add("Column_de_etat")
                .Columns.Add("P_Code_debut")
                .Columns.Add("P_Code_fin")
                .Columns.Add("anne")
                .Columns.Add("Sance")

            End With
            For i As Integer = 0 To DataGridView1.Rows.Count
                table = DataGridView1.DataSource
            Next

            'DataGridView1.Columns(0).Visible = False
            'DataGridView1.Columns(1).Visible = False
            'DataGridView1.Columns(2).Visible = False
            ''DataGridView1.Columns(10).Visible = False







            cmd = New SqlCommand("Select * from FPlanComptable order by C_CODE ", con)
            adapt1 = New SqlDataAdapter(cmd)
            adapt1.Fill(ds, "FPlanComptable")
            ComboBox3.DisplayMember = "C_CODE"
            ComboBox3.ValueMember = "C_LIBELLE"
            ComboBox3.DataSource = ds.Tables("FPlanComptable")





        Catch ex As Exception
            MsgBox("load" & ex.Message)
        End Try




    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        n1 = 1
        Button1.Visible = True
        Button2.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False

        TextBox2.Enabled = True
        TextBox3.Enabled = True
        'ComboBox1.Enabled = True
        'ComboBox2.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        n1 = 2

        Button1.Visible = True
        Button2.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False

        TextBox2.Enabled = True
        TextBox3.Enabled = True
        'ComboBox1.Enabled = True
        'ComboBox2.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        n1 = 3
        Button1.Visible = True
        Button2.Visible = True
        Button5.Visible = False
        Button6.Visible = False
        Button7.Visible = False
        Button8.Visible = False
        ' TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        'ComboBox1.Enabled = True
        'ComboBox2.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (n1 = 1) Then
            '   MessageBox.Show("ajouter")
            'add(TextBox8.Text, TextBox5.Text, TextBox9.Text, TextBox6.Text, ComboBox3.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text, ComboBox2.Text, ComboBox4.Text)
            add(TextBox8.Text, TextBox5.Text, TextBox9.Text, TextBox6.Text, ComboBox3.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text, ComboBox2.Text, ComboBox4.Text)
        End If
        If (n1 = 2) Then
            '  MessageBox.Show("modifier")
            'modif(TextBox8.Text, TextBox5.Text, TextBox9.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox7.Text, ComboBox2.Text, TextBox6.Text, ComboBox3.Text, ComboBox4.Text)
            add(TextBox8.Text, TextBox5.Text, TextBox9.Text, TextBox6.Text, ComboBox3.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text, ComboBox2.Text, ComboBox4.Text)
        End If
        If (n1 = 3) Then
            '   MessageBox.Show("supprimer")
            sup(id_val)
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("anulation", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Button1.Visible = False
        Button2.Visible = False
        Button5.Visible = True
        Button6.Visible = True
        Button7.Visible = True
        Button8.Visible = True
        'TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ' ComboBox1.Enabled = False
        ComboBox2.Enabled = False
    End Sub

    Private Sub ETATConstruire_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        '  rs.ResizeAllControls(Me)
    End Sub


    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        n1 = 1
        'planComptableAficheList.Show()

    End Sub

    Private Sub TextBox7_Click(sender As Object, e As EventArgs) Handles TextBox7.Click
        n1 = 2
        ' planComptableAficheList.Show()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)


        ' TextBox1.Text = selecteRow.Cells(0).Value.ToString()
        TextBox8.Text = selecteRow.Cells(1).Value.ToString()
        TextBox5.Text = selecteRow.Cells(2).Value.ToString()
        TextBox9.Text = selecteRow.Cells(3).Value.ToString()
        TextBox6.Text = selecteRow.Cells(4).Value.ToString()
        ComboBox3.Text = selecteRow.Cells(5).Value.ToString()
        TextBox2.Text = selecteRow.Cells(6).Value
        TextBox3.Text = selecteRow.Cells(7).Value

        TextBox4.Text = selecteRow.Cells(8).Value.ToString()

        TextBox7.Text = selecteRow.Cells(9).Value.ToString()
        ComboBox2.Text = selecteRow.Cells(10).Value.ToString()
        ComboBox4.Text = selecteRow.Cells(11).Value.ToString()
        id_val = selecteRow.Cells(0).Value.ToString()
        aff()

    End Sub
    Dim rowIndex As Integer
    Dim table As New DataTable("Table")

    Sub Rafraichir(chx As Integer)
        Try
            Dim t0 As String
            Dim t1 As String
            Dim t2 As String
            Dim t3 As String
            Dim t4 As String
            Dim t5 As String
            Dim t6 As Integer
            Dim t7 As Integer
            Dim t8 As String
            Dim t9 As String
            Dim t10 As String
            Dim t11 As String


            Dim tt0 As String
            Dim tt1 As String
            Dim tt2 As String
            Dim tt3 As String
            Dim tt4 As String
            Dim tt5 As String
            Dim tt6 As Integer
            Dim tt7 As Integer
            Dim tt8 As String
            Dim tt9 As String
            Dim tt10 As String
            Dim tt11 As String


            MessageBox.Show("kjjjjjjjjjjjjjjjjjjjj")
            MsgBox(DataGridView1.Rows.Count())
            rowIndex = DataGridView1.SelectedCells(0).OwningRow.Index

            If rowIndex > 0 Then

                t0 = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(0).Value)
                t1 = DataGridView1.Rows(rowIndex).Cells(1).Value.ToString
                t2 = DataGridView1.Rows(rowIndex).Cells(2).Value.ToString
                t3 = DataGridView1.Rows(rowIndex).Cells(3).Value.ToString
                t4 = DataGridView1.Rows(rowIndex).Cells(4).Value.ToString
                t5 = DataGridView1.Rows(rowIndex).Cells(5).Value.ToString
                t6 = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(6).Value)
                t7 = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(7).Value)
                t8 = DataGridView1.Rows(rowIndex).Cells(8).Value.ToString
                t9 = DataGridView1.Rows(rowIndex).Cells(9).Value.ToString
                t10 = DataGridView1.Rows(rowIndex).Cells(10).Value.ToString
                t11 = DataGridView1.Rows(rowIndex).Cells(11).Value.ToString


                tt0 = Integer.Parse(DataGridView1.Rows(rowIndex + chx).Cells(0).Value)
                tt1 = DataGridView1.Rows(rowIndex +chx).Cells(1).Value.ToString
                tt2 = DataGridView1.Rows(rowIndex +chx).Cells(2).Value.ToString
                tt3 = DataGridView1.Rows(rowIndex +chx).Cells(3).Value.ToString
                tt4 = DataGridView1.Rows(rowIndex +chx).Cells(4).Value.ToString
                tt5 = DataGridView1.Rows(rowIndex +chx).Cells(5).Value.ToString
                tt6 = Integer.Parse(DataGridView1.Rows(rowIndex +chx).Cells(6).Value)
                tt7 = Integer.Parse(DataGridView1.Rows(rowIndex +chx).Cells(7).Value)
                tt8 = DataGridView1.Rows(rowIndex +chx).Cells(8).Value.ToString
                tt9 = DataGridView1.Rows(rowIndex +chx).Cells(9).Value.ToString
                tt10 = DataGridView1.Rows(rowIndex +chx).Cells(10).Value.ToString
                tt11 = DataGridView1.Rows(rowIndex +chx).Cells(11).Value.ToString

           
               

                Dim row As DataRow



                row = table.NewRow()
                row(0) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(0).Value)
                row(1) = DataGridView1.Rows(rowIndex).Cells(1).Value.ToString
                row(2) = DataGridView1.Rows(rowIndex).Cells(2).Value.ToString
                row(3) = DataGridView1.Rows(rowIndex).Cells(3).Value.ToString
                row(4) = DataGridView1.Rows(rowIndex).Cells(4).Value.ToString
                row(5) = DataGridView1.Rows(rowIndex).Cells(5).Value.ToString
                row(6) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(6).Value)
                row(7) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(7).Value)
                row(8) = DataGridView1.Rows(rowIndex).Cells(8).Value.ToString
                row(9) = DataGridView1.Rows(rowIndex).Cells(9).Value.ToString
                row(10) = DataGridView1.Rows(rowIndex).Cells(10).Value.ToString
                row(11) = DataGridView1.Rows(rowIndex).Cells(11).Value.ToString
             
                table.Rows.RemoveAt(rowIndex)
                table.Rows.InsertAt(row, rowIndex+chx)
                DataGridView1.ClearSelection()
                DataGridView1.Rows(rowIndex+chx).Selected = True

                Dim req As String = "update Etat_Generater set Code_de_Letat= '" & tt1 & "',Nom_de_etat= '" & tt2 & "',Titre_de_Lign='" & tt3 & "', Titre_de_col= '" & tt4 & "' ,Compte_de_Letat = '" & tt5 & "',
                    Ligne_de_etat = " & tt6 & ",Column_de_etat= " & tt7 & ",P_Code_debut= '" & tt8 & "',P_Code_fin='" & tt9 & "',anne ='" & tt10 & "', Sance='" & tt11 & "' where
                     id = " & t0 & ""
  
                cmd = New SqlCommand(req, con)
                Dim adaptteeer1 As SqlDataAdapter
                adaptteeer1 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adaptteeer1.Fill(dt)


                Dim req1 As String = "update Etat_Generater set Code_de_Letat= '" & t1 & "',Nom_de_etat= '" & t2 & "',Titre_de_Lign='" & t3 & "', Titre_de_col= '" & t4 & "' ,Compte_de_Letat = '" & t5 & "',
                    Ligne_de_etat = " & t6 & ",Column_de_etat= " & t7 & ",P_Code_debut= '" & t8 & "',P_Code_fin='" & t9 & "',anne ='" & t10 & "', Sance='" & t11 & "' where
                     id = " & tt0 & ""
  
                cmd = New SqlCommand(req1, con)
                Dim adapt As SqlDataAdapter
                adapt = New SqlDataAdapter(cmd)
                Dim dt1 = New DataTable()
                adapt.Fill(dt1)


            End If
        Catch ex As Exception
            MessageBox.Show("error de > " & ex.Message)
        End Try




    End Sub




    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            If table.Rows.Count = 0 Then

                MessageBox.Show("No data Found")
                Return
            Else
                DataGridView1.Refresh()
                MsgBox(DataGridView1.Rows.Count())
                Rafraichir(1)

            End If
        Catch ex As Exception
            MessageBox.Show("error de > " & ex.Message)
        End Try


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            If table.Rows.Count = 0 Then
                MessageBox.Show("No data Found")
                Return
            Else
                DataGridView1.Refresh()
                MsgBox(DataGridView1.Rows.Count())

                Rafraichir(-1)

            End If

        Catch ex As Exception
            MessageBox.Show("error de > " & ex.Message)
        End Try

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If table.Rows.Count = 0 Then
                MessageBox.Show("No data Found")
                Return
            Else
               ' Module1.connecter()
                Using cmd1 As New SqlCommand(" drop table Etat_Generater
                                    create table Etat_Generater(
                                    id int not null primary key identity,
                                    Code_de_Letat nvarchar(100),
                                    Nom_de_etat nvarchar(100),
                                    Titre_de_lign nvarchar(100),
                                    Titre_de_col nvarchar(100),
                                    Compte_de_Letat nvarchar(10),
                                    Ligne_de_etat float,
                                    Column_de_etat float,
                                    P_Code_debut varchar(10) ,
                                    P_Code_fin varchar(10) ,
                                    anne nvarchar(100),
                              
                                    Sance nvarchar(1)
                                    );

                    ", con)
                    Dim adapt As New SqlDataAdapter(cmd1)
                    Dim dt = New DataTable()
                    adapt.Fill(dt)


                    For Each row As DataGridViewRow In DataGridView1.Rows

                        'Dim chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_" + Access.n2 + ".MDF" + ";Integrated Security=True"
                        'Using con As New SqlConnection(chaineDeConnexion)



                        Using cmd As New SqlCommand("
                                        
                    
                    INSERT INTO Etat_Generater VALUES( @Code_de_Letat, @Nom_de_etat, @Titre_de_lign, @Titre_de_col,
                                                       @compte_de_letat,@Ligne_de_etat, @Column_de_etat, @P_Code_debut, @P_Code_fin, 
                                                       @anne,@Sance)", con)

                                cmd.Parameters.AddWithValue("@Code_de_Letat", row.Cells("Code_de_Letat").Value)
                                cmd.Parameters.AddWithValue("@Nom_de_etat", row.Cells("Nom_de_etat").Value)
                                cmd.Parameters.AddWithValue("@Titre_de_lign", row.Cells("Titre_de_lign").Value)
                                cmd.Parameters.AddWithValue("@Titre_de_col", row.Cells("Titre_de_col").Value)
                                cmd.Parameters.AddWithValue("@Compte_de_Letat", row.Cells("Compte_de_Letat").Value)
                                cmd.Parameters.AddWithValue("@Ligne_de_etat", row.Cells("Ligne_de_etat").Value)
                                cmd.Parameters.AddWithValue("@Column_de_etat", row.Cells("Column_de_etat").Value)
                                cmd.Parameters.AddWithValue("@P_Code_debut", row.Cells("P_Code_debut").Value)
                                cmd.Parameters.AddWithValue("@P_Code_fin", row.Cells("P_Code_fin").Value)
                                cmd.Parameters.AddWithValue("@anne", row.Cells("anne").Value)
                                cmd.Parameters.AddWithValue("@Sance", row.Cells("Sance").Value)

                                con.Open()


                                'Dim adaptteeer1 As SqlDataAdapter
                                'adaptteeer1 = New SqlDataAdapter(cmd)
                                'dt = New DataTable()
                                'adaptteeer1.Fill(dt)
                                'cmd.ExecuteNonQuery()
                                'con.Close()
                            End Using
                        'End Using

                    Next
                End Using
                MessageBox.Show("Records inserted.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Function chaineDeConnexion() As String
        Throw New NotImplementedException()
    End Function

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        '  TextBox1.Text = ""
        TextBox8.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox9.Text = ""
        ComboBox3.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

        TextBox7.Text = ""
        ComboBox2.Text = ""
        ComboBox4.Text = ""
        aff()
    End Sub

    Private Sub Apercue_Click(sender As Object, e As EventArgs) Handles Apercue.Click

        Form18.Show()
        Me.Hide()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class