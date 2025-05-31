Imports System.Data.SqlClient
Imports System.IO


Public Class Form6

    Dim cmd As SqlCommand
    Dim cmd3 As SqlCommand


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

    Sub aff(exer, libelle, S_code)

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



", New FileInfo(Application.ExecutablePath).DirectoryName)
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





    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Connecter()

        aff(2010, "MATERIEL ET OUTILLAGE", Access.n2)
        Dim Materiel = value
        aff(2010, "MATERIEL DE TRANSPORT", Access.n2)
        Dim Materiel_tran = value
        aff(2010, "AMORTISSEMENT MATERIEL ET OUTILLAGE", Access.n2)
        Dim Materiel_am_out = value
        aff(2010, "AMORTISSEMENT MATERIEL DE TRANSPORT", Access.n2)
        Dim Materiel_am_tran = value


        'aff(2010, "CHEQUES A ENCAISSER")
        'Dim  = value
        'aff(2010, "BANQUES")
        'Dim  = value
        'aff(2010, "CAISSE,REGIE AVANCE & ACCREDITIFS")
        'Dim  = value
        'aff(2010, "")
        'Dim  = value
        'aff(2010, "")
        'Dim  = value
        'aff(2010, "")
        'Dim  = value




        Dim report As New Bilan_Compta_EX
        report.SetParameterValue("Construction", 0)
        report.SetParameterValue("Instal Materiel er outilage", Materiel)
        report.SetParameterValue("Materiel et transport", Materiel_tran)
        report.SetParameterValue("mob mat bureau amenag div", 0)
        report.SetParameterValue("Immoub corporeles en  coure", 0)
        report.SetParameterValue("Societe name", Access.n9)
        report.SetParameterValue("Immortis counstr", 0)
        report.SetParameterValue("Immort Instal Materi", Materiel_am_out)
        report.SetParameterValue("Immo mat transp", Materiel_am_tran)
        report.SetParameterValue("immoub MOB  mat bur", 0)
        report.SetParameterValue("immoub immoub corpo en cour", 0)

        Me.CrystalReportViewer1.ReportSource = report




    End Sub
End Class