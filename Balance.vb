Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.ComponentModel

Public Class Balance
    'Dim con = ConnectionProget1.Connectersoc
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    ReadOnly adapt As SqlDataAdapter
    Private adapt1 As SqlDataAdapter
    Private adapt2 As SqlDataAdapter
    Private ReadOnly adapt3 As SqlDataAdapter
    ReadOnly value As Integer
    Private ReadOnly sum As Integer
    Private ReadOnly cred As Integer
    Private ReadOnly Id_Niv1 As New List(Of String)
    Private ReadOnly Id_Niveau As String
    Public Id_Niv12 As New List(Of Integer)
    Private ReadOnly Id_Niveau2 As String
    Private ReadOnly choix As Integer
    Private ReadOnly exer = exec_proc.n1
    ReadOnly y As Integer
    Sub Connecter()

        'If Connectersoc() Then
        '    Try
        '        '
        '    Catch ex As Exception
        '      
        '    End Try
        'End If
        Try
            If Connectersoc() = True Then
                Try
                    con.Open()
                    'MsgBox("success")
                Catch ex As Exception
                    'MsgBox("Faild" + ex.Message)
                    con.Close()


                End Try
            End If
        Catch ex As Exception
            'MsgBox("faild")
            con.Close()
        Finally
            con.Close()

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Form1.Show()
    End Sub


    Sub CompteBalance(CompteDebut, CompteCredit)
        Dim req As String = " exec BalanceCompte " & exer & "," & exer & "," & CompteDebut & "," & CompteCredit & ""
        cmd = New SqlCommand(req, con)
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
            isi.SubItems.Add(AB(2).ToString - AB(3).ToString)

            'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
            'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
            'Id_Niv12.Add(Id_Niveau2)
        Next


        Dim index As ListViewItem

        Dim debut As Long
        Dim credit As Long

        With ListView1
            '  index = .SelectedIndices(1)
            For Each index In .Items
                debut += CLng(index.SubItems(2).Text)
                credit += credit + CLng(index.SubItems(3).Text)
            Next
        End With
        'MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit), "info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        TextBox8.Text = CStr(credit)
        TextBox7.Text = CStr(debut)
        TextBox9.Text = TextBox8.Text - TextBox7.Text
    End Sub
    Private Sub Balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rs1.FindAllControls(Me)
        Connecter()
        TextBox2.Text = Me.ListView1.Items.Count.ToString()

        Label8.Text = Access.n9

        Me.Label1.Text = exer
        Me.Label3.Text = Access.n2
        Rs1.FindAllControls(Me)


        'CheckBox1.Enabled = False

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE ", con)
        adapt1 = New SqlDataAdapter(cmd)
        adapt1.Fill(Ds1, "FPlanComptable")
        ComboBox3.DisplayMember = "ER_COMPTE"
        ComboBox3.ValueMember = "ER_LIBELLE"
        ComboBox3.DataSource = Ds1.Tables("FPlanComptable")

        '   Grand_Livre.Label4.Text = ComboBox3.ValueMember
        'Grand_Livre.TextBox1.Text = ComboBox3.Text

        ''combobox1 Code Compte :
        cmd = New SqlCommand("select ER_COMPTE from [ECRIT001] group by ER_COMPTE order by ER_COMPTE", con)
        adapt2 = New SqlDataAdapter(cmd)
        adapt2.Fill(Ds1, "Comptable")
        ComboBox4.DisplayMember = "ER_COMPTE"
        ComboBox4.ValueMember = "ER_COMPTE"
        ComboBox4.DataSource = Ds1.Tables("Comptable")



    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub BtnApersue_Click(sender As Object, e As EventArgs) Handles BtnApersue.Click
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
            Form7.CrystalReportViewer1.ReportSource = crystal
            'GrandLivreReportViewer.Refresh()
            Form7.Show()
            'GrandLivreReportViewer.Dispose()




            'test1.CrystalReportViewer1.ReportSource = crystal
            'test1.CrystalReportViewer1.Refresh()

            'test1.Show()




        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub Balance_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Rs1.ResizeAllControls(Me)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        ListView1.Items.Clear()
        CompteBalance(ComboBox3.Text, ComboBox4.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Form1.Show()
        Me.Hide()
    End Sub


End Class