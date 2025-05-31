Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine

Public Class List_Edite_Journalle
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    ReadOnly adapt As SqlDataAdapter
    ReadOnly adapt1 As SqlDataAdapter
    ReadOnly adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter
    ReadOnly value As Integer
    Private ReadOnly sum As Integer
    Private ReadOnly cred As Integer
    Private ReadOnly Id_Niv1 As New List(Of String)
    Private ReadOnly Id_Niveau As String
    Private ReadOnly Id_Niv12 As New List(Of String)
    Private ReadOnly Id_Niveau2 As String
    Private ReadOnly choix As Integer
    Private ReadOnly exer = exec_proc.n1
    ReadOnly y As Integer

    Shared Sub Connecter()
        If Connectersoc() Then
            Try
                'MsgBox("success")

            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    Sub Print()
        Try
            Dim req As String = "
            select  distinct ER_JOUR as 'Jr',ER_LIGNE as 'N°Lign',ER_FOLIO as 'N°Fol' ,ER_COMPTE as 'N°Compte',ER_CPARTIE as 'Compte_Partie',ER_NPIECE as 'N°Piece ', ER_LIBELLE as 'LIBELLE', IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ')as 'TYPE_DEBUT'
            ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI',ER_JOURNL from ECRIT001 where  ER_EXERC = " & exer & " 
            and ER_MOIS between " & Edition_journal.ComboBox2.SelectedIndex + 1 & " and " & Edition_journal.ComboBox3.SelectedIndex + 1 & " and ER_JOURNL = " & Edition_journal.ComboBox1.Text & " 
group by ER_CODE,ER_JOUR,ER_LIGNE,ER_FOLIO,ER_COMPTE,ER_CPARTIE,ER_NPIECE, ER_LIBELLE,ER_JOURNL "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            Dim isi As ListViewItem
            For Each AB As DataRow In dt.Rows
                isi = Me.ListView2.Items.Add(AB(0).ToString)
                isi.SubItems.Add(AB(1).ToString)
                isi.SubItems.Add(AB(2).ToString)
                isi.SubItems.Add(AB(3).ToString)
                isi.SubItems.Add(AB(4).ToString)
                isi.SubItems.Add(AB(5).ToString)
                isi.SubItems.Add(AB(6).ToString)
                isi.SubItems.Add(AB(7).ToString)
                isi.SubItems.Add(AB(8).ToString)
                isi.SubItems.Add(AB(9).ToString)
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            Dim dtable = New DataTable()
            With dtable
                .Columns.Add("JR")
                .Columns.Add("Lign")
                .Columns.Add("Fol")
                .Columns.Add("Compte")
                .Columns.Add("ContrePartie")
                .Columns.Add("Piece")
                .Columns.Add("Libelle")
                .Columns.Add("Debut")
                .Columns.Add("Credit")
                .Columns.Add("journal")
            End With
            Dim columnValues(dtable.Columns.Count - 1) As Object
            For Each lvi As ListViewItem In ListView2.Items
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
                dtable.Rows.Add(columnValues)
            Next

            'MsgBox(dtable.Rows.Count)
            If dtable.Rows.Count = 0 Then
                MessageBox.Show("No data Found", "CrystalReportWithOracle")
                Return
            End If

            Dim crystal As New journalreport_Final

            'Dim txt As TextObject
            'Dim txt1 As TextObject
            'Dim txt2 As TextObject
            'Dim txt3 As TextObject
            'crystal.DataDefinition.FormulaFields.Item("MyFormula").Text = Access.n2
            'If crystal.ReportDefinition.ReportObjects("Text19") IsNot Nothing Then
            '    txt = CType(crystal.ReportDefinition.ReportObjects("Text19"), TextObject)
            '    txt.Text = Access.n2
            'End If
            'If crystal.ReportDefinition.ReportObjects("Text20") IsNot Nothing Then
            '    txt1 = CType(crystal.ReportDefinition.ReportObjects("Text20"), TextObject)
            '    txt1.Text = exer
            'End If
            'If crystal.ReportDefinition.ReportObjects("Text21") IsNot Nothing Then
            '    txt2 = CType(crystal.ReportDefinition.ReportObjects("Text21"), TextObject)
            '    txt2.Text = Edition_journal.ComboBox1.Text
            'End If
            'If crystal.ReportDefinition.ReportObjects("Text22") IsNot Nothing Then
            '    txt3 = CType(crystal.ReportDefinition.ReportObjects("Text22"), TextObject)
            '    txt3.Text = Edition_journal.Label3.Text
            'End If

            'crystal.SetParameterValue("societe", Access.n2)
            'crystal.SetParameterValue("Exercice", exer)
            'crystal.SetParameterValue("code_journal", Edition_journal.ComboBox1.Text)
            'crystal.SetParameterValue("libelle_journal", Edition_journal.Label3.Text)

            crystal.SetDataSource(dtable)



            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = crystal
            GrandLivreReportViewer.Refresh()
            GrandLivreReportViewer.Show()
        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
        Edition_journal.Show()

    End Sub

    ReadOnly rs As New Form_Choix.Resizer
    Dim debut As Long
    Dim credit As Long

    Public Property Ds1 As DataSet
        Get
            Return ds
        End Get
        Set(value As DataSet)
            ds = value
        End Set
    End Property

    Private Sub List_Edite_Journalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)

        Try
            Connecter()

            Label11.Text = exer
            Label12.Text = Access.n2
            Label18.Text = Access.n9
            'ComboBox1.SelectedIndex +1, ComboBox2.SelectedIndex + 1

            ''-------------------------------------------------------------------------------------------
            Dim index As ListViewItem


            With ListView1
                '  index = .SelectedIndices(1)
                For Each index In .Items
                    debut += CLng(index.SubItems(7).Text)
                    credit += CLng(index.SubItems(8).Text)
                Next
            End With
            ' MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit))
            Label15.Text = CStr(credit)
            Label14.Text = CStr(debut)
        Catch ex As Exception
            MessageBox.Show("form load " + ex.Message, "text", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Me.Close()
            Edition_journal.Show()

        Catch ex As Exception
            MessageBox.Show("error de l'affichage " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub

    Private Sub List_Edite_Journalle_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)

    End Sub

    Private Sub BtnApersue_Click(sender As Object, e As EventArgs) Handles BtnApersue.Click

        Print()


    End Sub


End Class