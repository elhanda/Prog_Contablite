Imports System.Data.SqlClient

Imports CrystalDecisions.CrystalReports.Engine

Imports CrystalDecisions.Shared

Imports System.Data
Public Class Form2
    Private exer = 2015
    Private a = 1
    Private b = 2
    Dim ds As New DataSet()

    Dim cnn As SqlConnection

    Dim connectionString As String

    Dim sql As String


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'connectionString = "Data Source=.;Initial Catalog=Base_Compta_001;Integrated Security=True"
        'cnn = New SqlConnection(connectionString)
        'cnn.Open()

        'sql = "[list_month] " & 1 & "," & 2 & ", " & 2015 & ""
        'Dim dscmd As New SqlDataAdapter(sql, cnn)
        'dscmd.Fill(ds, "Product")
        'MsgBox(ds)
        'cnn.Close()
        'Dim objRpt As New CrystalReport1
        'objRpt.SetDataSource(ds)
        'CrystalReportViewer1.ReportSource = objRpt
        'CrystalReportViewer1.Refresh()

        Dim cry As ReportDocument = New ReportDocument()


        'cry.Load(@"C:\Users\pc\source\repos\Prog_Contablite\Prog_Contablite\Crystal report\listmunthCR.rpt")
        'connectionString = "Data Source=.;Initial Catalog=Base_Compta_001;Integrated Security=True"
        'cnn = New SqlConnection(connectionString)
        'cnn.Open()
        ''Dim objRpt As New listmunthCR
        ''cnn.Close()
        'Dim listmunthCR As Prog_Contablite.listmunthCR = New listmunthCR()
        'listmunthCR.SetParameterValue("@Exec", 65)
        ''Dim listmunthCR As Prog_Contablite.CrystalReport1.listmunthCR = New CrystalReport.listmunthCR()
        ''listmunthCR.SetParametreValue("@Price", 65)
        ''crvReport.ReportSource = Nothing
        ''crvReport.ReportSource = listmunthCR
        'objRpt.SetDataSource(ds)
        'CrystalReportViewer1.ReportSource = objRpt
        'CrystalReportViewer1.Refresh()

        cry.Load("C:\Users\pc\source\repos\Prog_Contablite\Prog_Contablite\Crystal report\listmunthCR.rpt")
        Dim con As SqlConnection = New SqlConnection("Data Source=.;Initial Catalog=Base_Compta_001;Integrated Security=True")
        Dim sda As SqlDataAdapter = New SqlDataAdapter("list_month", con)

        sda.SelectCommand.CommandType = CommandType.StoredProcedure
        sda.SelectCommand.Parameters.Add("@a", System.Data.SqlDbType.VarChar, 50).Value = a
        sda.SelectCommand.Parameters.Add("@b", System.Data.SqlDbType.VarChar, 50).Value = b
        sda.SelectCommand.Parameters.Add("@Exec", System.Data.SqlDbType.VarChar, 50).Value = exer

        Dim st As DataSet = New System.Data.DataSet()
        sda.Fill(st, "DATAS")
        cry.SetDataSource(st)
        CrystalReportViewer1.ReportSource = cry








    End Sub
End Class
