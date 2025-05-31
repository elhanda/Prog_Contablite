Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Windows.Forms
Public Class Edition_journal
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
    Private Id_Niv12 As New List(Of String)
    Private Id_Niveau2 As String
    Private choix As Integer
    Private exer = exec_proc.n1

    Dim y As Integer

    Public Sub ResizeControls(ByVal scaleFactor As Double)
        For Each ctrl As Control In Me.Controls
            ctrl.Left = CInt(ctrl.Left * scaleFactor)
            ctrl.Top = CInt(ctrl.Top * scaleFactor)
            ctrl.Width = CInt(ctrl.Width * scaleFactor)
            ctrl.Height = CInt(ctrl.Height * scaleFactor)
        Next
    End Sub
    Private Sub Edition_journal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ResizeControls(1.5)
        Try
            Module1.connecter()
            Try
                list_Edite_Journalle.Label11.Text = exer
                list_Edite_Journalle.Label12.Text = Access.n2

                'combobox1 Code Journal :
                cmd = New SqlCommand("select * from FJournal", con)
                adapt = New SqlDataAdapter(cmd)
                adapt.Fill(ds, "FJournal")
                ComboBox1.DisplayMember = "J_CODE"
                ComboBox1.ValueMember = "J_LIBELLE "
                ComboBox1.DataSource = ds.Tables("FJournal")
            Catch ex As Exception
                MessageBox.Show("load error 1" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("form load 1" + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        cmd = New SqlCommand("select J_LIBELLE from FJournal where J_CODE =" & ComboBox1.Text & "", con)
        adapt = New SqlDataAdapter(cmd)
        adapt.Fill(ds, "FJol")
        For Each dr As DataRow In ds.Tables("FJol").Rows
            Label3.Text = dr("J_LIBELLE").ToString()
        Next
    End Sub
    Sub affich(Mois1, Mois2, Journal)
        Try
            list_Edite_Journalle.Label11.Text = exer
            list_Edite_Journalle.Label12.Text = Access.n2

            list_Edite_Journalle.Label3.Text = Journal
            list_Edite_Journalle.Label5.Text = ComboBox2.Text

            list_Edite_Journalle.Label7.Text = ComboBox3.Text



            'MessageBox.Show("" & Mois1 & " , " & Mois2 & "  , " & Journal & "")
            Dim req As String = "

            select  distinct ER_JOUR as 'Jr',ER_LIGNE as 'N°Lign',ER_FOLIO as 'N°Fol' ,ER_CPARTIE as 'N°Compte',ER_CPARTIE as 'Compte_Partie',ER_NPIECE as 'N°Piece ', ER_LIBELLE as 'LIBELLE', IIF ( ER_CODE = 'D' , sum(ER_MONT), '                  ')as 'TYPE_DEBUT'
            ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI' from FEcriture 

            where 
            ER_EXERC = " & exer & " 

            and ER_MOIS between " & Mois1 & " and " & Mois2 & " 
            and ER_JOURNL = " & Journal & " 



               group by ER_CODE,ER_JOUR,ER_LIGNE,ER_FOLIO,ER_CPARTIE,ER_CPARTIE,ER_NPIECE, ER_LIBELLE "

            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            '   Balance.DataGridView1.DataSource = dt


            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = list_Edite_Journalle.ListView1.Items.Add(AB(0).ToString)
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(4).ToString)
                isi.SubItems.Add(AB(5).ToString)
                isi.SubItems.Add(AB(6).ToString)
                isi.SubItems.Add(AB(7).ToString)
                isi.SubItems.Add(AB(8).ToString)

            Next

            Me.Hide()
            list_Edite_Journalle.Show()

        Catch ex As Exception
            MessageBox.Show("error de la proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            affich(ComboBox2.SelectedIndex + 1, ComboBox3.SelectedIndex + 1, ComboBox1.Text)
        Catch ex As Exception
            MessageBox.Show("error de la buton aff  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub
End Class