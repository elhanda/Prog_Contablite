Public Class Form15
    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        Dim report As New CachedCrystalReport11  'Rapport1
        Try
            Connecter_soc()

            Dim req1 As String
            req1 = (" Select S_pat, S_Nom, S_adr1,s_ville,s_tel,s_tva,s_email  from Fsociete where S_code =  " & Access.n2 & " ")
            cmd = New SqlCommand(req1, con)
            Dim adaptr2 As SqlDataAdapter
            adaptr2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptr2.Fill(dt)
            MsgBox(dt.Rows.Count)



            report.SetParameterValue("Designation", Convert.ToString(dt.Rows(0)(1)))
            report.SetParameterValue("Adress", Convert.ToString(dt.Rows(0)(2)))
            report.SetParameterValue("Fsocial", Convert.ToString(dt.Rows(0)(0)))
            report.SetParameterValue("ville", Convert.ToString(dt.Rows(0)(3)))
            report.SetParameterValue("tel", Convert.ToString(dt.Rows(0)(4)))
            report.SetParameterValue("tva", Convert.ToString(dt.Rows(0)(5)))
            report.SetParameterValue("email", Convert.ToString(dt.Rows(0)(6)))
            Connecter()

        Catch ex As Exception
            'MsgBox("error 1 " + ex.Message)
        End Try
    End Sub
End Class