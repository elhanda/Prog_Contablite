Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class test1

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
        'Dim chaineDeConnexion As String
        'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_001;Integrated Security=True"
        'con = New SqlConnection(chaineDeConnexion)
        'Try
        '    con.Open()
        'Catch ex As Exception
        '    MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Console.WriteLine()
        'End Try
        If Connectersoc() Then
            Try
                'MsgBox("success")
            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    '    Sub printreport()
    '        Try
    '            Connecter()
    '            '   Dim Ds As DataSet = New DataSet()
    '            'Dim objRpt As CrystalReport3
    '            'objRpt = New CrystalReport3()
    '            Dim dt = New DataTable()
    '            Dim req As String = "select distinct
    'concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
    ',IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
    'from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
    'where E.ER_CPARTIE between   11111111  and  22222222 
    'and  ER_MOIS between   1  and 2 
    'and ER_AN = 2015
    ' group by ER_CODE,concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

    '"
    '            cmd = New SqlCommand(req, con)

    '            adapt = New SqlDataAdapter(cmd)

    '            adapt.Fill(dt)






    '            'If Ds.Tables("GrandLivreData").Rows.Count = 0 Then
    '            '    MessageBox.Show("No data Found", "CrystalReportWithOracle")
    '            '    Return
    '            'End If

    '            'objRpt.SetDataSource(Ds.Tables("GrandLivreData"))
    '            ''Dim root As CrystalDecisions.CrystalReports.Engine
    '            ''root = CType(objRpt.ReportDefinition.ReportObjects("txt_header"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '            ''root.Text = "Sample Report By Using Data Table!!"
    '            'CrystalReportViewer1.ReportSource = objRpt



    '            '            Dim rpt As New CrystalReport1
    '            '            rpt.Database.Tables("DataTable1").SetDataSource(dt)
    '            '#Disable Warning BC30456 ' 'CrystalReportViewer1' n'est pas un membre de 'test2'.

    '            '#Enable Warning BC30456 ' 'CrystalReportViewer1' n'est pas un membre de 'test2'.
    '            '#Disable Warning BC30456 ' 'CrystalReportViewer1' n'est pas un membre de 'test2'.

    '            '#Enable Warning BC30456 ' 'CrystalReportViewer1' n'est pas un membre de 'test2'.
    '            '            test2.ShowDialog()
    '            '            rpt.Close()
    '            '            rpt.Dispose()



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


    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'printreport()
    End Sub

    Private Sub test1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Connecter()

    End Sub

End Class