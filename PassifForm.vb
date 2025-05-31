Imports System.Data.SqlClient
Imports System.IO


Public Class PassifForm
    Dim cmd As SqlCommand
    Dim cmd3 As SqlCommand

    Dim Exercice As String = exec_proc.n1
    Dim Exercice1 As String = exec_proc.n1 - 1
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter
    Dim value As Integer
    Dim x As Integer = 0
    ReadOnly y As Integer
    Dim sum As Integer = 0
    Private i As Integer
    Sub Connecter()
        'If () Then

        Try
            'AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory())             + " C:\Users\Ismail\Desktop\Nouveau dossier\repos\Prog_Contablite\Prog_Contablite"
            Dim chaineDeConnexion As String
            chaineDeConnexion = String.Format(" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\Data\Base_Compta_" & Access.n2 & ".mdf;Integrated Security=True", New FileInfo(Application.ExecutablePath).DirectoryName)
            con = New SqlConnection(chaineDeConnexion)
            con.Open()

        Catch ex As Exception
            con.Close()

        Finally
            con.Close()
        End Try
        'End If
    End Sub
    Sub aff(exer, libelle)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "

            Dim req As String = String.Format(" 




IF EXISTS ( SELECT  SUM(E.ER_MONT)  FROM [FPlanComptable]   F join [ECRIT001] E on E.ER_COMPTE = F.C_CODE 
 where ER_EXERC =  " & exer & "  and  F.C_LIBELLE = '" & libelle & "'   group by  F.C_CODE  ) 
BEGIN
   
  SELECT  SUM(E.ER_MONT)  FROM [FPlanComptable]   F join [ECRIT001] E on E.ER_COMPTE = F.C_CODE 
 where ER_EXERC =  " & exer & "  and  F.C_LIBELLE = '" & libelle & "'   group by  F.C_CODE order by C_CODE asc

END
ELSE
BEGIN
    select  0
END



", New FileInfo(Application.ExecutablePath).DirectoryName, New FileInfo(Application.ExecutablePath).DirectoryName)
            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)

            value = dt.Rows(0)(0).ToString()

        Catch ex As Exception
            MessageBox.Show("Error de  delete" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Sub affS(exer, libelle)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "

            Dim req As String = String.Format(" 




IF EXISTS ( SELECT  SUM(E.ER_MONT)  FROM [FPlanComptable]   F join [ECRIT001] E on E.ER_COMPTE = F.C_CODE 
 where ER_EXERC =  " & exer & "  and  F.C_LIBELLE = '" & libelle & "'   group by  F.C_CODE  ) 
BEGIN
   
  SELECT  SUM(E.ER_MONT)  FROM [FPlanComptable]   F join [ECRIT001] E on E.ER_COMPTE = F.C_CODE 
 where ER_EXERC =  " & exer & "  and  F.C_LIBELLE = '" & libelle & "'   group by  F.C_CODE order by C_CODE asc

END
ELSE
BEGIN
    select  0
END



", New FileInfo(Application.ExecutablePath).DirectoryName, New FileInfo(Application.ExecutablePath).DirectoryName)
            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)

            value = dt.Rows(0)(0).ToString()



        Catch ex As Exception
            MessageBox.Show("Error de  delete1" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub


    Private Sub PassifForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()

        aff(exec_proc.n1, "CAPITAL SOCIAL")
        Dim Capital_social = value
        affS((exec_proc.n1 - 1), "CAPITAL SOCIAL")
        Dim EX_Capital_social = value
        aff(exec_proc.n1, "RESERUE LEGALE")
        Dim reserue_legale = value
        affS((exec_proc.n1 - 1), "RESERUE LEGALE")
        Dim EX_reserue_legale = value
        aff(exec_proc.n1, "REPORT A NOUVEAU SOLDE CREDITEURS")
        Dim Report_A_Nouv_Sold_CREDITEUR = value
        affS((exec_proc.n1 - 1), "REPORT A NOUVEAU SOLDE CREDITEURS")
        Dim EX_Report_A_Nouv_Sold_CREDITEUR = value
        aff(exec_proc.n1, "RESULTAT NET EN LINSTANCE AFF SC")
        Dim RESULT_net_INSTANCE_AFF_SC = value
        affS((exec_proc.n1 - 1), "RESULTAT NET EN LINSTANCE AFF SC")
        Dim EX_RESULT_net_INSTANCE_AFF_SC = value
        aff(exec_proc.n1, "RESULTAT NET DE LEXERCICE")
        Dim RESULT_NET_LEXERCICE = value
        affS((exec_proc.n1 - 1), "RESULTAT NET DE LEXERCICE")
        Dim EX_RESULT_NET_LEXERCICE = value
        aff(exec_proc.n1, "WAFASALAF")
        Dim WAFASALAF = value
        affS((exec_proc.n1 - 1), "WAFASALAF")
        Dim EX_WAFASALAF = value
        aff(exec_proc.n1, "FOURNISSEUR")
        Dim FOURNISSEUR = value
        affS((exec_proc.n1 - 1), "FOURNISSEUR")
        Dim EX_FOURNISSEUR = value
        aff(exec_proc.n1, "CLIENT - AUCE ET ACPTES RECUS S/CD")
        Dim CLIENT_AUCE_ET_ACPTES = value
        affS((exec_proc.n1 - 1), "CLIENT - AUCE ET ACPTES RECUS S/CD")
        Dim EX_CLIENT_AUCE_ET_ACPTES = value
        aff(exec_proc.n1, "ROMPUS S/SALAIRES")
        Dim ROMPUS = value
        affS((exec_proc.n1 - 1), "ROMPUS S/SALAIRES")
        Dim EX_ROMPUS = value
        aff(exec_proc.n1, "ORGANISMES SOCIAUX")
        Dim ORGANISME_SOCIAL = value
        affS((exec_proc.n1 - 1), "ORGANISMES SOCIAUX")
        Dim EX_ORGANISME_SOCIAL = value
        aff(exec_proc.n1, "ETAT CREDITEUR")
        Dim ETAT_CREDITEUR = value
        affS((exec_proc.n1 - 1), "ETAT CREDITEUR")
        Dim EX_ETAT_CREDITEUR = value
        aff(exec_proc.n1, "COMPTES ASSOCIES CREDITEUR")
        Dim COMPTES_ASSOC_CREDI = value
        affS((exec_proc.n1 - 1), "COMPTES ASSOCIES CREDITEUR")
        Dim EX_COMPTES_ASSOC_CREDI = value
        aff(exec_proc.n1, "FOURNISSEUR DIMMOBILISATION")
        Dim FOURNISS_DAMMBILISATION = value
        affS((exec_proc.n1 - 1), "FOURNISSEUR DIMMOBILISATION")
        Dim EX_FOURNISS_DAMMBILISATION = value
        aff(exec_proc.n1, "FRAIS BANCAIRES A PAYER")
        Dim FRAIS_BANCAIRES_A_PAIER = value
        affS((exec_proc.n1 - 1), "FRAIS BANCAIRES A PAYER")
        Dim EX_FRAIS_BANCAIRES_A_PAIER = value
        aff(Exercice, "DETTES DU PASSIF CIRCULANT")
        Dim DETTES_DU_PASSIF_CIRCUL = value
        affS(exec_proc.n1, "DETTES DU PASSIF CIRCULANT")
        Dim EX_DETTES_DU_PASSIF_CIRCUL = value







        Dim report As New PassifReport
        report.SetParameterValue("Societe name", Access.n9)

        report.SetParameterValue("Capital_social", Capital_social)
        report.SetParameterValue("reserue_legale", reserue_legale)
        report.SetParameterValue("Report_A_Nouv_Sold_CREDITEUR", Report_A_Nouv_Sold_CREDITEUR)
        report.SetParameterValue("RESULT_net_INSTANCE_AFF_SC", RESULT_net_INSTANCE_AFF_SC)
        report.SetParameterValue("RESULT_NET_LEXERCICE", 0)

        report.SetParameterValue("WAFASALAF", WAFASALAF)
        report.SetParameterValue("FOURNISSEUR", FOURNISSEUR)
        report.SetParameterValue("CLIENT_AUCE_ET_ACPTES", CLIENT_AUCE_ET_ACPTES)
        report.SetParameterValue("ROMPUS", ROMPUS)
        report.SetParameterValue("ORGANISME_SOCIAL", ORGANISME_SOCIAL)

        report.SetParameterValue("ETAT_CREDITEUR", ETAT_CREDITEUR)
        report.SetParameterValue("COMPTES_ASSOC_CREDI", COMPTES_ASSOC_CREDI)
        report.SetParameterValue("FOURNISS_DAMMBILISATION", FOURNISS_DAMMBILISATION)
        report.SetParameterValue("FRAIS_BANCAIRES_A_PAIER", FRAIS_BANCAIRES_A_PAIER)
        'report.SetParameterValue("DETTES_DU_PASSIF_CIRCUL", DETTES_DU_PASSIF_CIRCUL)

        report.SetParameterValue("EX_Capital_social", EX_Capital_social)
        report.SetParameterValue("EX_reserue_legale", EX_reserue_legale)
        report.SetParameterValue("EX_Report_A_Nouv_Sold_CREDITEUR", EX_Report_A_Nouv_Sold_CREDITEUR)
        report.SetParameterValue("EX_RESULT_net_INSTANCE_AFF_SC", EX_RESULT_net_INSTANCE_AFF_SC)
        report.SetParameterValue("EX_RESULT_NET_LEXERCICE", EX_RESULT_NET_LEXERCICE)

        report.SetParameterValue("EX_WAFASALAF", EX_WAFASALAF)
        report.SetParameterValue("EX_FOURNISSEUR", EX_FOURNISSEUR)
        report.SetParameterValue("EX_CLIENT_AUCE_ET_ACPTES", EX_CLIENT_AUCE_ET_ACPTES)
        report.SetParameterValue("EX_ROMPUS", EX_ROMPUS)
        report.SetParameterValue("EX_ORGANISME_SOCIAL", EX_ORGANISME_SOCIAL)

        report.SetParameterValue("EX_ETAT_CREDITEUR", EX_ETAT_CREDITEUR)
        report.SetParameterValue("EX_COMPTES_ASSOC_CREDI", EX_COMPTES_ASSOC_CREDI)
        report.SetParameterValue("EX_FOURNISS_DAMMBILISATION", EX_FOURNISS_DAMMBILISATION)
        report.SetParameterValue("EX_FRAIS_BANCAIRES_A_PAIER", EX_FRAIS_BANCAIRES_A_PAIER)
        'report.SetParameterValue("EX_DETTES_DU_PASSIF_CIRCUL", EX_DETTES_DU_PASSIF_CIRCUL)
        Me.CrystalReportViewer1.ReportSource = report






    End Sub
End Class