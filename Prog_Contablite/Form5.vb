Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class Form5
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
    'Private exer = exec_proc.n1
    Dim y As Integer
    Sub Connecter()
        If Connectersoc() Then
            Try
                'MsgBox("success")
            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    Sub printreport()
        Try
            '            '   Dim Ds As DataSet = New DataSet()
            '            'Dim objRpt As CrystalReport3
            '            'objRpt = New CrystalReport3()
            Dim dtable = New DataTable()
            'Dim req As String = "select distinct
            'concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
            ',IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
            'from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
            'where E.ER_CPARTIE between   11111111  and  22222222 
            'and  ER_MOIS between   1  and 2 
            'and ER_AN = 2015
            ' group by ER_CODE,concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]
            '"
            'cmd = New SqlCommand(req, con)
            'adapt = New SqlDataAdapter(cmd)
            'adapt.Fill(dt)
            '            'If Ds.Tables("GrandLivreData").Rows.Count = 0 Then
            '            '    MessageBox.Show("No data Found", "CrystalReportWithOracle")
            '            '    Return
            '            'End If
            '            'objRpt.SetDataSource(Ds.Tables("GrandLivreData"))
            '            ''Dim root As CrystalDecisions.CrystalReports.Engine
            '            ''root = CType(objRpt.ReportDefinition.ReportObjects("txt_header"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '            ''root.Text = "Sample Report By Using Data Table!!"
            '            'CrystalReportViewer1.ReportSource = objRpt
            '            Dim rpt As New CrystalReport1
            '            rpt.Database.Tables(1).SetDataSource(dt)
            '            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = Nothing
            '            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = rpt
            '            'ShowDialog()
            '            'GrandLivreReportViewer.Dispose()
            '            'Dim rpt As CrystalReport3 = New CrystalReport3()
            '            'rpt.SetDataSource(CType(dt, DataTable))
            '            ''rpt.Database.Tables("dtData").SetDataSource((DataTable)ds.GrandLivreData)
            '            ''rptDoc = New CrystalReport1
            '            ''rptDoc.SetDataSource(dtt)
            '            ''GrandLivreReportViewer.CrystalReportViewer1.ReportSource = Nothing
            '            ''GrandLivreReportViewer.CrystalReportViewer1.ReportSource = rpt
            '            'GrandLivreReportViewer.ShowDialog()
            '            'GrandLivreReportViewer.Dispose()
            '            Dim dt As New DataTable
            ''''''''''Dim objRpt As CrystalReport3
            ''''''''''objRpt = New CrystalReport3()
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
            End With

            For i As Integer = 0 To DataGridView1.Rows.Count
                dtable = DataGridView1.DataSource
            Next


            MsgBox(dtable.Rows.Count)

            If dtable.Rows.Count = 0 Then
                MessageBox.Show("No data Found", "CrystalReportWithOracle")
                Return
            End If
            ''''''''''objRpt.SetDataSource(ds.Tables("DataTable1"))
            '''''''''''   objRpt.SetDataSource(dtable)
            '''''''''''Dim root As CrystalDecisions.CrystalReports.Engine.TextObject
            '''''''''''root = CType(objRpt.ReportDefinition.ReportObjects("txt_header"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '''''''''''root.Text = "Sample Report By Using Data Table!!"
            '''''''''''  test1.CrystalReportViewer1.ReportSource = objRpt
            ''''''''''With test1
            ''''''''''    .CrystalReportViewer1.ReportSource = objRpt
            ''''''''''    '.CrystalReportViewer1.Dock = DockStyle.Fill
            ''''''''''    .CrystalReportViewer1.Refresh()
            ''''''''''    .Show()
            ''''''''''End With






            '            For Each dr As DataGridViewRow In Me.DataGridView1.Rows
            '                dtable.Rows.Add(dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value, dr.Cells(3).Value, dr.Cells(4).Value, dr.Cells(5).Value,
            'dr.Cells(6).Value, dr.Cells(7).Value, dr.Cells(8).Value)
            '            Next
            '            Dim reportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
            '            reportDocument = New CrystalReport3
            '            reportDocument.SetDataSource(dtable)
            '            test1.CrystalReportViewer1.ReportSource = reportDocument
            '            test1.ShowDialog()
            '            test1.Dispose()


            ''            Dim req As String = "select distinct
            ''concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
            '',IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
            ''from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
            ''where E.ER_CPARTIE between   11111111  and  22222222 
            ''and  ER_MOIS between   1  and 2 
            ''and ER_AN = 2015
            '' group by ER_CODE,concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

            ''"
            ''            cmd = New SqlCommand(req, con)
            ''            Dim adapttr As SqlDataAdapter
            ''            adapttr = New SqlDataAdapter(cmd)
            ''            Dim dt = New DataTable()
            ''            adapttr.Fill(dt)

            'Dim crystal As New CrystalReport1
            'crystal.SetDataSource(dt)
            ''CrystalReportViewer1.ReportSource = crystal
            ''CrystalReportViewer1.Refresh()

            'test2.CrystalReportViewer1.ReportSource = crystal
            'test2.CrystalReportViewer1.Refresh()

            'Dim req As String = "select distinct
            'concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
            ',IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
            'from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
            'where E.ER_CPARTIE between   11111111  and  22222222 
            'and  ER_MOIS between   1  and 2 
            'and ER_AN = 2015
            ' group by ER_CODE,concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

            '"
            'cmd = New SqlCommand(req, con)
            'Dim adapttr As SqlDataAdapter
            'adapttr = New SqlDataAdapter(cmd)
            'Dim dt = New DataTable()
            'adapttr.Fill(dt)
            'MsgBox(dt.Rows.Count)
            Dim crystal As New CrystalReport1
            crystal.SetDataSource(dtable)

            'test1.CrystalReportViewer1.ReportSource = crystal
            'test1.CrystalReportViewer1.Refresh()

            test1.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        printreport()

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles Me.Load
        Connecter()

        Try
            Dim req As String = "select distinct
concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
where E.ER_CPARTIE between   11111111  and  22222222 
and  ER_MOIS between   1  and 2 
and ER_AN = 2015
 group by ER_CODE,concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

"
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            DataGridView1.DataSource = dt
            Dim sumDebut As Integer = 0
            Dim sumCredit As Integer = 0
            For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
                sumDebut += DataGridView1.Rows(i).Cells(7).Value
                sumCredit += DataGridView1.Rows(i).Cells(8).Value
            Next
            ' MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit))
            TextBox8.Text = sumCredit
            TextBox7.Text = sumDebut
            TextBox9.Text = TextBox8.Text - TextBox7.Text
        Catch ex As Exception
            MessageBox.Show("error de affiche proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class