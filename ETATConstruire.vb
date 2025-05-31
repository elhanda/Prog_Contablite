Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class ETATConstruire
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Public n1 As Integer
    Sub Connecter()
        If ConnecterHome() Then
            Try
                'MsgBox("success" & New FileInfo(Application.ExecutablePath).DirectoryName)

            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    Sub aff()
        Try
            Dim searchQuery As String = "select id,
Code_de_Letat,
                                Nom_de_etat,
                                Titre_de_lign as 'Titre de  Lign ',
                                Titre_de_etat AS 'Titre de Column',
                                 
                                Ligne_de_etat as 'Ligne',
                                Column_de_etat as 'Columne',
 Compte_de_Letat as 'Compte',
                                P_Code_debut as 'Code debut',
                                P_Code_fin as 'Code Fin',
                                anne ,
                             
                                 Sance as 'Sens' 
from Etat_Generater order by Nom_de_etat,


Ligne_de_etat,
Column_de_etat ,Compte_de_Letat 

"
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table





















            For Each row As DataGridViewRow In DataGridView1.Rows

                If row.Cells("anne").Value = 0 Then
                    row.Cells("anne").Value = exec_proc.n1 - 1
                ElseIf row.Cells("anne").Value = 1 Then
                    row.Cells("anne").Value = exec_proc.n1
                End If
            Next



























        Catch ex As Exception
            MessageBox.Show("error de l'affichage" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub add(TextBox8, TextBox5, TextBox6, TextBox2, TextBox3, TextBox4, textbox7, anne, textbox9, combobox3, combobox4)
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
                    'Connecter()
                    Dim req As String = "insert into Etat_Generater values('" & TextBox8 & "','" & TextBox5 & "','" & TextBox6 & "'," & TextBox2 & "," & TextBox3 & ",'" & TextBox4 & "','" & textbox7 & "','" & anne & "','" & textbox9 & "','" & combobox3 & "', '" & combobox4 & "')"
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
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            TextBox4.Enabled = False
        Catch ex As Exception

        End Try

    End Sub
    Sub modif(TextBox8, TextBox5, TextBox9, TextBox2, TextBox3, TextBox4, textbox1, textbox7, combobox2, textbox6, combobox3, combobox4)
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


                    '      Connecter()'Code_de_Letat','Nom_de_etat','Titre_de_etat',Ligne_de_etat,Column_de_etat,'P_Code'
                    'update Etat_Generater set Code_de_Letat= '" & TextBox8 & "',Nom_de_etat= '" & TextBox5 & "', Titre_de_etat= '" & TextBox6 & "',
                    'Ligne_de_etat = " & TextBox2 & ",Column_de_etat= " & TextBox3 & ",P_Code_debut= '" & TextBox4 & "',P_Code_fin='" & textbox7 & "' where
                    '
                    Dim req As String = "update Etat_Generater set Code_de_Letat= '" & TextBox8 & "',Nom_de_etat= '" & TextBox5 & "', Titre_de_etat= '" & textbox6 & "',Compte_de_Letat = '" & combobox3 & "',
                    Ligne_de_etat = " & TextBox2 & ",Column_de_etat= " & TextBox3 & ",P_Code_debut= '" & TextBox4 & "',P_Code_fin='" & textbox7 & "',anne ='" & combobox2 & "',Titre_de_Lign='" & TextBox9 & "' , Sance='" & combobox4 & "' where
                     id = " & textbox1 & "
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
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            'ComboBox2.Enabled = False
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
                    '    ''''''''''''''''''' dalete the data  ''''''''''''


                    '   Connecter()
                    Dim req As String = "delete  from Etat_Generater where id = " & TextBox1 & ""
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
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            'ComboBox2.Enabled = False
        Catch ex As Exception

        End Try

    End Sub


    Dim rs As New Form_Choix.Resizer

    Private Sub ETATConstruire_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Try
            Connecter()
            aff() 'exec_proc.n1
            ComboBox2.Items.Add("anne Precedant")
            ComboBox2.Items.Add("Anne Courant")
            Dim dt As New DataTable

            cmd = New SqlCommand("select Nom_de_etat from Etat_Generater group by Nom_de_etat", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(dt)
            ComboBox1.DisplayMember = "Nom_de_etat"
            ComboBox1.ValueMember = "Nom_de_etat "
            ComboBox1.DataSource = dt




            'table.Columns.Add("id", Type.GetType("System.Int32"))
            'table.Columns.Add("Code_de_Letat", Type.GetType("System.String"))
            'table.Columns.Add("Nom_de_etat", Type.GetType("System.String"))
            'table.Columns.Add("Titre_de_etat", Type.GetType("System.String"))
            'table.Columns.Add("Ligne_de_etat", Type.GetType("System.Int32"))
            'table.Columns.Add("Column_de_etat", Type.GetType("System.Int32"))
            'table.Columns.Add("P_Code_debut", Type.GetType("System.String"))
            'table.Columns.Add("P_Code_fin", Type.GetType("System.String"))
            'table.Columns.Add("anne", Type.GetType("System.String"))


            With table

                .Columns.Add("id")
                .Columns.Add("Code_de_Letat")
                .Columns.Add("Nom_de_etat")
                .Columns.Add("Titre_de_etat")
                .Columns.Add("Ligne_de_etat")
                .Columns.Add("Column_de_etat")
                .Columns.Add("P_Code_debut")
                .Columns.Add("P_Code_fin")
                .Columns.Add("anne")
                .Columns.Add("Titre_de_lign")
                .Columns.Add("Compte_de_Letat")
                .Columns.Add("Sance")
            End With
            For i As Integer = 0 To DataGridView1.Rows.Count
                table = DataGridView1.DataSource
            Next

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            'DataGridView1.Columns(10).Visible = False

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
        ComboBox1.Enabled = True
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
        ComboBox1.Enabled = True
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
        ComboBox1.Enabled = True
        'ComboBox2.Enabled = True
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (n1 = 1) Then
            '   MessageBox.Show("ajouter")
            If ComboBox2.SelectedIndex = 1 Then
                add(TextBox8.Text, ComboBox1.Text, TextBox6.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text, 1, TextBox9.Text, ComboBox3.Text, ComboBox4.Text)
            ElseIf ComboBox2.SelectedIndex = 0 Then
                add(TextBox8.Text, ComboBox1.Text, TextBox6.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox7.Text, 0, TextBox9.Text, ComboBox3.Text, ComboBox4.Text)

            End If
        End If
        If (n1 = 2) Then
            '  MessageBox.Show("modifier")
            If ComboBox2.SelectedIndex = 1 Then
                modif(TextBox8.Text, ComboBox1.Text, TextBox9.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox7.Text, 1, TextBox6.Text, ComboBox3.Text, ComboBox4.Text)
            ElseIf ComboBox2.SelectedIndex = 0 Then
                modif(TextBox8.Text, ComboBox1.Text, TextBox9.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox1.Text, TextBox7.Text, 0, TextBox6.Text, ComboBox3.Text, ComboBox4.Text)

            End If

        End If
        If (n1 = 3) Then
            '   MessageBox.Show("supprimer")
            sup(TextBox1.Text)
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaportBilanActif.Show()

    End Sub

    Private Sub ETATConstruire_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox4_Click(sender As Object, e As EventArgs) Handles TextBox4.Click
        n1 = 1
        planComptableAficheList.Show()

    End Sub

    Private Sub TextBox7_Click(sender As Object, e As EventArgs) Handles TextBox7.Click
        n1 = 2
        planComptableAficheList.Show()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        TextBox1.Text = selecteRow.Cells(0).Value.ToString()
        TextBox8.Text = selecteRow.Cells(1).Value.ToString()
        ComboBox1.Text = selecteRow.Cells(2).Value.ToString()
        TextBox9.Text = selecteRow.Cells(3).Value.ToString()
        TextBox6.Text = selecteRow.Cells(4).Value.ToString()
        TextBox2.Text = selecteRow.Cells(5).Value.ToString()
        TextBox3.Text = selecteRow.Cells(6).Value.ToString()
        ComboBox3.Text = selecteRow.Cells(7).Value.ToString()
        TextBox4.Text = selecteRow.Cells(8).Value.ToString()
        TextBox7.Text = selecteRow.Cells(9).Value.ToString()
        ComboBox2.Text = selecteRow.Cells(10).Value.ToString()
        ComboBox4.Text = selecteRow.Cells(11).Value.ToString()


    End Sub
    Dim rowIndex As Integer
    Dim table As New DataTable("Table")
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If table.Rows.Count = 0 Then
                MessageBox.Show("No data Found")
                Return
            Else

                rowIndex = DataGridView1.SelectedCells(0).OwningRow.Index
                Dim row As DataRow
                '    MsgBox(rowIndex)
                row = table.NewRow()

                row(0) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(0).Value.ToString)
                row(1) = DataGridView1.Rows(rowIndex).Cells(1).Value.ToString
                row(2) = DataGridView1.Rows(rowIndex).Cells(2).Value.ToString
                row(3) = DataGridView1.Rows(rowIndex).Cells(3).Value.ToString
                row(4) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(4).Value.ToString)
                row(5) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(5).Value.ToString)
                row(6) = DataGridView1.Rows(rowIndex).Cells(6).Value.ToString
                row(7) = DataGridView1.Rows(rowIndex).Cells(7).Value.ToString
                row(8) = DataGridView1.Rows(rowIndex).Cells(8).Value.ToString
                row(9) = DataGridView1.Rows(rowIndex).Cells(9).Value.ToString
                row(10) = DataGridView1.Rows(rowIndex).Cells(10).Value.ToString
                row(11) = DataGridView1.Rows(rowIndex).Cells(11).Value.ToString
                If rowIndex > 0 Then
                    table.Rows.RemoveAt(rowIndex)
                    table.Rows.InsertAt(row, rowIndex - 1)
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(rowIndex - 1).Selected = True

                End If
                'DataGridView1.Rows(rowIndex - 1).Selected = False
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

                rowIndex = DataGridView1.SelectedCells(0).OwningRow.Index
                Dim row As DataRow
                '   MsgBox(rowIndex)
                row = table.NewRow()

                row(0) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(0).Value.ToString)
                row(1) = DataGridView1.Rows(rowIndex).Cells(1).Value.ToString
                row(2) = DataGridView1.Rows(rowIndex).Cells(2).Value.ToString
                row(3) = DataGridView1.Rows(rowIndex).Cells(3).Value.ToString
                row(4) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(4).Value.ToString)
                row(5) = Integer.Parse(DataGridView1.Rows(rowIndex).Cells(5).Value.ToString)
                row(6) = DataGridView1.Rows(rowIndex).Cells(6).Value.ToString
                row(7) = DataGridView1.Rows(rowIndex).Cells(7).Value.ToString
                row(8) = DataGridView1.Rows(rowIndex).Cells(8).Value.ToString
                row(9) = DataGridView1.Rows(rowIndex).Cells(9).Value.ToString
                row(10) = DataGridView1.Rows(rowIndex).Cells(10).Value.ToString
                row(11) = DataGridView1.Rows(rowIndex).Cells(11).Value.ToString


                If rowIndex < DataGridView1.Rows.Count Then
                    table.Rows.RemoveAt(rowIndex)
                    table.Rows.InsertAt(row, rowIndex + 1)
                    DataGridView1.ClearSelection()
                    DataGridView1.Rows(rowIndex + 1).Selected = True


                End If
                'DataGridView1.Rows(rowIndex + 1).Selected = False

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
                ' Connecter()
                Using cmd1 As New SqlCommand(" drop table Etat_Generater
                                    create table Etat_Generater(
                                    id int not null primary key identity,
                                    Code_de_Letat nvarchar(100),
                                    Nom_de_etat nvarchar(100),
                                    Titre_de_etat nvarchar(100),
                                    Ligne_de_etat float,
                                    Column_de_etat float,
                                    P_Code_debut varchar(10) ,
                                    P_Code_fin varchar(10) ,
                                    anne nvarchar(100),
                                    Titre_de_lign nvarchar(100),
                                    Compte_de_Letat nvarchar(100),
Sance nvarchar(50)
                                    );

                    ", con)
                    Dim adapt As New SqlDataAdapter(cmd1)
                    Dim dt = New DataTable()
                    adapt.Fill(dt)


                    For Each row As DataGridViewRow In DataGridView1.Rows
                        '= "Data Source=.\SQL2008R2;Initial Catalog=AjaxSamples;Integrated Security=true"
                        Dim chaineDeConnexion As String = String.Format(" Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename={0}\Data\Base_Compta_Soc.mdf;Integrated Security=True", New FileInfo(Application.ExecutablePath).DirectoryName)

                        Using con As New SqlConnection(chaineDeConnexion)
                            'Code_de_Letat','Nom_de_etat','Titre_de_etat',Ligne_de_etat,Column_de_etat,'P_Code','anne' .Columns.Add("id")
                            '.Columns.Add("Code_de_Letat")
                            '.Columns.Add("Nom_de_etat")
                            '.Columns.Add("Titre_de_etat")
                            '.Columns.Add("Ligne_de_etat")
                            '.Columns.Add("Column_de_etat")
                            '.Columns.Add("P_Code_debut")
                            '.Columns.Add("P_Code_fin")
                            '.Columns.Add("anne")
                            '   MsgBox("connect success")


                            Using cmd As New SqlCommand("
                                        
                    
                    INSERT INTO Etat_Generater VALUES( @Code_de_Letat, @Nom_de_etat, @Titre_de_lign, @Ligne_de_etat, @Column_de_etat, @P_Code_debut, @P_Code_fin, @anne,@Titre_de_etat,@compte_de_letat,@Sance)", con)
                                cmd.Parameters.AddWithValue("@Code_de_Letat", row.Cells("Code_de_Letat").Value)
                                cmd.Parameters.AddWithValue("@Nom_de_etat", row.Cells("Nom_de_etat").Value)
                                cmd.Parameters.AddWithValue("@Titre_de_etat", row.Cells("Titre_de_Lign").Value)
                                cmd.Parameters.AddWithValue("@Ligne_de_etat", row.Cells("Ligne_de_etat").Value)
                                cmd.Parameters.AddWithValue("@Column_de_etat", row.Cells("Column_de_etat").Value)
                                cmd.Parameters.AddWithValue("@P_Code_debut", row.Cells("P_Code_debut").Value)
                                cmd.Parameters.AddWithValue("@P_Code_fin", row.Cells("P_Code_fin").Value)
                                cmd.Parameters.AddWithValue("@anne", row.Cells("anne").Value)
                                cmd.Parameters.AddWithValue("@Titre_de_lign", row.Cells("Titre_de_etat").Value)
                                cmd.Parameters.AddWithValue("@Compte_de_Letat", row.Cells("Compte_de_Letat").Value)
                                cmd.Parameters.AddWithValue("@Sance", row.Cells("Sance").Value)

                                con.Open()


                                'Dim adaptteeer1 As SqlDataAdapter
                                'adaptteeer1 = New SqlDataAdapter(cmd)
                                'dt = New DataTable()
                                'adaptteeer1.Fill(dt)
                                cmd.ExecuteNonQuery()
                                con.Close()
                            End Using
                        End Using

                    Next
                End Using
                MessageBox.Show("Records inserted.")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedValueChanged
        Try
            Dim searchQuery As String = "select id,
Code_de_Letat,
                                Nom_de_etat,
                                Titre_de_lign as 'Titre de  Lign ',
                                Titre_de_etat AS 'Titre de Column',
                                 
                                Ligne_de_etat as 'Ligne',
                                Column_de_etat as 'Columne',
 Compte_de_Letat as 'Compte',
                                P_Code_debut as 'Code debut',
                                P_Code_fin as 'Code Fin',
                                anne ,
                             
                                 Sance as 'Sens' 
from Etat_Generater where Nom_de_etat = '" & ComboBox1.Text & "' order by Nom_de_etat,


Ligne_de_etat,
Column_de_etat ,Compte_de_Letat 

"
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
            For Each row As DataGridViewRow In DataGridView1.Rows

                If row.Cells("anne").Value = 0 Then
                    row.Cells("anne").Value = exec_proc.n1 - 1
                ElseIf row.Cells("anne").Value = 1 Then
                    row.Cells("anne").Value = exec_proc.n1
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("error de l'affichage" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class