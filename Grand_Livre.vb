Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Grand_Livre
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
    Sub A(ComboBox1)
        Try
            Dim req As String = "EcritureCompte_WithCompte " & grindlive_choix.ComboBox1.SelectedIndex + 1 & "," & grindlive_choix.ComboBox2.SelectedIndex + 1 & "," & grindlive_choix.ComboBox3.Text & "," & grindlive_choix.ComboBox4.Text & "," & exer & "," & ComboBox1 & "
"
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            Dim isi As ListViewItem
            Me.ListView1.Items.Clear()

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
                'Balance.ListBox1.Items.Add(AB(0) & " " & vbTab & " " & vbTab & " " & vbTab & "  |  " & vbTab & " " & vbTab & "  " & AB(1).ToString())
                'Id_Niveau2 = AB(0) & " " & vbTab & "  " & vbTab & " " & vbTab & "  | " & vbTab & " " & vbTab & "  " & vbTab & "" & vbTab & "" & AB(1).ToString()
                'Id_Niv12.Add(Id_Niveau2)
            Next
            Label13.Text = Me.ListView1.Items.Count.ToString()

            Dim index As ListViewItem

            Dim debut As Long
            Dim credit As Long
            With ListView1
                '  index = .SelectedIndices(1)
                For Each index In .Items
                    debut += CLng(index.SubItems(7).Text)
                    credit += CLng(index.SubItems(8).Text)
                Next
            End With
            ' MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit))
            TextBox8.Text = CStr(credit)
            TextBox7.Text = CStr(debut)

            TextBox9.Text = TextBox8.Text - TextBox7.Text
        Catch ex As Exception
            MessageBox.Show("error de totaux month proc asa " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Print()
        Dim req = "EcritureCompte_All " & grindlive_choix.ComboBox1.SelectedIndex + 1 & "," & grindlive_choix.ComboBox2.SelectedIndex + 1 & "," & grindlive_choix.ComboBox3.Text & "," & grindlive_choix.ComboBox4.Text & "," & exer & ""

        cmd = New SqlCommand(req, con)
        Dim adapttr As SqlDataAdapter
        adapttr = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        adapttr.Fill(dt)
        Dim isi As ListViewItem
        Me.ListView2.Items.Clear()

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

    Private Sub Grand_Livre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Rs1.FindAllControls(Me)
        Connecter()

        Try
            Dim req As String = " EcritureCompte " & grindlive_choix.ComboBox1.SelectedIndex + 1 & ",  " & grindlive_choix.ComboBox2.SelectedIndex + 1 & "," & exer & "," & grindlive_choix.ComboBox3.Text & "," & grindlive_choix.ComboBox4.Text & "
"
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(Ds1, "FPlanComptable")

            ComboBox1.DisplayMember = "ER_COMPTE"
            ComboBox1.ValueMember = "ER_COMPTE"
            ComboBox1.DataSource = Ds1.Tables("FPlanComptable")


        Catch ex As Exception
            MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try





        'Dim index As ListViewItem

        'Dim debut As Long
        'Dim credit As Long
        'With ListView1
        '    '  index = .SelectedIndices(1)
        '    For Each index In .Items
        '        debut = debut + CLng(index.SubItems(7).Text)
        '        credit = credit + CLng(index.SubItems(8).Text)
        '    Next
        'End With
        '' MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit))
        'TextBox8.Text = CStr(credit)
        'TextBox7.Text = CStr(debut)

        'TextBox9.Text = TextBox8.Text - TextBox7.Text
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ComboBox1.SelectedIndex < ComboBox1.Items.Count - 1 Then
            ComboBox1.SelectedIndex = ComboBox1.SelectedIndex + 1
        End If
    End Sub

    Private Sub BtnApersue_Click(sender As Object, e As EventArgs) Handles BtnApersue.Click
        Try
            Print()
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

            For Each lvi As ListViewItem In ListView2.Items
                columnValues(0) = (lvi.SubItems(0).Text)
                columnValues(1) = (lvi.SubItems(1).Text)
                columnValues(2) = (lvi.SubItems(2).Text)
                columnValues(3) = (lvi.SubItems(3).Text)
                columnValues(4) = (lvi.SubItems(5).Text)
                columnValues(5) = (lvi.SubItems(6).Text)
                columnValues(6) = (lvi.SubItems(7).Text)
                columnValues(7) = (lvi.SubItems(8).Text)
                columnValues(8) = (lvi.SubItems(9).Text)
                columnValues(9) = (lvi.SubItems(4).Text)
                dtable.Rows.Add(columnValues)
            Next

            'MsgBox(dtable.Rows.Count)

            If dtable.Rows.Count = 0 Then
                MessageBox.Show("No data Found", "CrystalReportWithOracle")
                Return
            End If
            ''Using connection As New SqlConnection(connectionString)
            ''  Using command As New SqlCommand("dbo.PO_INSERT_WITH_LINE_ITEM", connection)
            ''  Command.CommandType = CommandType.StoredProcedure
            ''connection.Open()
            ''add other parameters here
            ''add TVP parameter
            '' Dim tvpParameter = command.Parameters.Add("@tvp", SqlDbType.Structured)
            ''  tvpParameter.Value = dt
            ''      command.ExecuteNonQuery()
            ''get output parameter value here
            ''  End Using
            '' End Using
            Dim dt As New DataTable

            'With dt
            '    .Columns.Add("Date", GetType(String))
            '    .Columns.Add("Jnl", GetType(String))
            '    .Columns.Add("Fol", GetType(Decimal))
            '    .Columns.Add("Lign", GetType(Decimal))
            '    .Columns.Add("Centre Partie", GetType(Int32))
            '    .Columns.Add("Piece", GetType(Decimal))
            '    .Columns.Add("Libelle", GetType(String))
            '    .Columns.Add("Debut", GetType(Int32))
            '    .Columns.Add("Credit", GetType(Int32))
            'End With


            'Dim columnValues(dt.Columns.Count - 1) As Object
            'For Each dr As ListViewItem In ListView1.Items
            '    columnValues(0) = (dr.SubItems(0).Text)
            '    columnValues(1) = (dr.SubItems(1).Text)
            '    columnValues(2) = (dr.SubItems(2).Text)
            '    columnValues(3) = (dr.SubItems(3).Text)
            '    columnValues(4) = (dr.SubItems(4).Text)
            '    columnValues(5) = Decimal.Parse(dr.SubItems(5).Text)
            '    columnValues(6) = (dr.SubItems(6).Text)
            '    columnValues(7) = Int32.Parse(dr.SubItems(7).Text)
            '    columnValues(8) = Int32.Parse(dr.SubItems(8).Text)
            '    dt.Rows.Add(columnValues)
            'Next
            'Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument

            Dim crystal As New GrandLivreReport_Final

            crystal.SetDataSource(dtable)
            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = crystal
            GrandLivreReportViewer.Refresh()
            GrandLivreReportViewer.Show()
            'GrandLivreReportViewer.Dispose()




            'test1.CrystalReportViewer1.ReportSource = crystal
            'test1.CrystalReportViewer1.Refresh()

            'test1.Show()




        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        A(ComboBox1.Text)
        TextBox2.Text = ComboBox1.SelectedIndex + 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedIndex > 0 Then
            ComboBox1.SelectedIndex = ComboBox1.SelectedIndex - 1
        End If
    End Sub

    Private Sub Grand_Livre_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Rs1.ResizeAllControls(Me)
    End Sub
End Class