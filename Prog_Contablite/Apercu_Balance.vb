Public Class Apercu_balance
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

        Dim report As New Balance_Report_Final

        Dim param_compte1 As String
        Dim param_compte2 As String
        param_compte1 = selected_balence.ComboBox3.Text
        param_compte2 = selected_balence.ComboBox4.Text

        report.SetParameterValue("Compte1", param_compte1)
        report.SetParameterValue("Compte2", param_compte2)
        report.SetParameterValue("exercice", exec_proc.n1)

        Me.CrystalReportViewer1.ReportSource = report

    End Sub

    Private Sub Apercu_balance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class