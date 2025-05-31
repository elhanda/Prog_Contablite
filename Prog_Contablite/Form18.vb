

Imports System.Data.SqlClient
    Imports System.IO

Public Class Form18
    Dim cmd As SqlCommand
    Dim cmd3 As SqlCommand


    Dim ds As DataSet = New DataSet()

    Dim dt As DataSet = New DataSet()
    Dim dd As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter
    Public value As Integer
    Dim value2 As String
    Dim valueExPres As Integer
    Dim valueExPres100 As Integer
    Dim Designation As String
    Dim Fsocial As String
    Dim Adresos As String
    Dim Ville As String
    Dim Tel As String
    Dim Tva As String
    Dim Email As String
    Dim Dat_Debut As String
    Dim Dat_Fin As String
    Dim x As Integer = 0
    ReadOnly y As Integer
    Dim sum As Integer = 0
    Private i As Integer
    Public ind As Boolean
    '  Dim con As SqlConnection
    '  Dim con1 As SqlConnection
    'Sub Module1.connecter()
    '    'If () Then

    '    Try
    '        'AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory())      " & Access.n2 & "       + " C:\Users\Ismail\Desktop\Nouveau dossier\repos\Prog_Contablite\Prog_Contablite"
    '        Dim chaineDeConnexion As String
    '        'chaineDeConnexion = String.Format(" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\DATA\Base_Compta_001.mdf;Integrated Security=True", New FileInfo(Application.ExecutablePath).DirectoryName)
    '        'chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\DATA\BASE_COMPTA_" + Access.n2 + ".MDF" + ";Integrated Security=True"
    '        chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_" + Access.n2 + ".MDF" + ";Integrated Security=True"
    '        chaineDeConnexion = "Data Source=localhost\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_" + Access.n2 + ".MDF" + ";Integrated Security=True"



    '        con = New SqlConnection(chaineDeConnexion)
    '        con.Open()

    '    Catch ex As Exception
    '        con.Close()

    '    Finally
    '        con.Close()
    '    End Try
    '    'End If
    'End Sub
    'Sub Module1.connecter_soc()()
    '    'If () Then

    '    Try
    '        'AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory())      " & Access.n2 & "       + " C:\Users\Ismail\Desktop\Nouveau dossier\repos\Prog_Contablite\Prog_Contablite"
    '        Dim chaineDeConnexion As String
    '        chaineDeConnexion = String.Format(" Data Source=DESKTOP-C826HA4\SQLEXPRESS;AttachDbFilename={0}\DATA\Base_Compta_Soc.mdf;Integrated Security=True", New FileInfo(Application.ExecutablePath).DirectoryName)
    '        chaineDeConnexion = "Data Source=localhost\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_soc.MDF" + ";Integrated Security=True"

    '        con = New SqlConnection(chaineDeConnexion)
    '        con.Open()

    '    Catch ex As Exception
    '        con.Close()

    '    Finally
    '        con.Close()
    '    End Try
    '    'End If
    'End Sub


    Sub Aff(code, Lign, Column, annee, report)
        Dim V1 As Integer
        Dim v2 As Integer
        Dim i As Integer

        value = 0

        'report.SetParameterValue("zone" & Lign & "" & Column, 0)

        Try

            Dim req As String
            Dim req1 As String
            ' and anne='" & annee & "'
            'req = "select  P_Code_debut,P_Code_fin,anne,sance,Compte_de_Letat from etat_generater 
            '       where (( Ligne_de_etat= " & Lign & " ) and ( Column_de_etat=" & Column & ")  and (code_de_letat= " & code & "))  
            '       order by  Ligne_de_etat,  Column_de_etat, Compte_de_Letat    "
            req = "select  P_Code_debut,P_Code_fin,anne,sance,Compte_de_Letat from etat_generater 
                   where (( Ligne_de_etat= " & Lign & " ) and ( Column_de_etat=" & Column & ")  )  
                   order by  Ligne_de_etat,  Column_de_etat, Compte_de_Letat    "
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)
            'MsgBox(dt.Rows.Count)
            value = 0
            Dim an As Integer
            V1 = dt.Rows(i)(0)
            v2 = dt.Rows(i)(1)
            an = Convert.ToInt32(annee) + Convert.ToInt32(dt.Rows(0)(2))
            'MessageBox.Show("born inf :" + CStr(V1) + "   borne sup :" + CStr(v2))
            Module1.connecter()


            ind = False
            For i = 0 To dt.Rows.Count - 1


                req1 = "Select  sum(iif(er_code='D',er_mont,-er_mont)) as Montant from fecriture 
                    where(er_cpartie > '" & V1 & "' and er_cpartie < '" & v2 & "') and (er_exerc= '" & an & "')"

                cmd = New SqlCommand(req1, con)
                Dim adapt1 As SqlDataAdapter
                adapt1 = New SqlDataAdapter(cmd)
                Dim ds = New DataTable()
                adapt1.Fill(ds)
                'value = value + Convert.ToInt32(ds.Rows(i)(0)) * IIf(dt.Rows(0)(3) = "+", 1, -1)
                value = value + Convert.ToInt32(ds.Rows(i)(0)) '* IIf(dt.Rows(0)(3) = "+", 1, -1)
                'MessageBox.Show("Ligne  :" + CStr(Lign) + " Colonne  : " + CStr(Column) + " annee :" + CStr(an) + " value :" + CStr(value))

                If ds.Rows.Count > 0 Then

                    ind = True

                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("Error de  aff    " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Sub strinfg(code, report)
        Module1.connecter_soc()

        Try
            'MsgBox(code)
            '************************************************
            '* Recherche infos  sociétée
            '***********************************************
            Dim req As String


            req = String.Format(" Select S_pat, S_Nom, S_adr1,s_ville,s_tel,s_tva,s_email  from Fsociete where S_code = '" & code & "'")        ', New FileInfo(Application.ExecutablePath).DirectoryName)
            cmd = New SqlCommand(req, con)
            Dim adaptr2 As SqlDataAdapter
            adaptr2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptr2.Fill(dt)
            'MessageBox.Show("nb lig :" + dt.Rows.Count)

            Designation = Convert.ToString(dt.Rows(0)(1))
            Fsocial = Convert.ToString(dt.Rows(0)(0))
            Adresos = Convert.ToString(dt.Rows(0)(2))
            Ville = Convert.ToString(dt.Rows(0)(3))
            Tel = Convert.ToString(dt.Rows(0)(4))
            Tva = Convert.ToString(dt.Rows(0)(5))
            Email = Convert.ToString(dt.Rows(0)(6))
            report.SetParameterValue("Designation", Convert.ToString(Designation))
            report.SetParameterValue("Adress", Convert.ToString(Adresos))
            report.SetParameterValue("Fsocial", Convert.ToString(Fsocial))
            report.SetParameterValue("Ville", Convert.ToString(Ville))
            report.SetParameterValue("Tel", Convert.ToString(Tel))
            report.SetParameterValue("Tva", Convert.ToString(Tva))
            report.SetParameterValue("Email", Convert.ToString(Email))
            '***********************************************
            '* Recherche période sociétée
            '***********************************************

            req = String.Format(" Select Exercice, Date_Debut,Date_Fin  from Periode_Soc where code_soc = '" & code & "'  and exercice= '" & exec_proc.n1 & "' ")
            cmd = New SqlCommand(req, con)
            Dim adaptr1 As SqlDataAdapter
            adaptr1 = New SqlDataAdapter(cmd)
            Dim dd = New DataTable()
            adaptr1.Fill(dd)

            Dat_Debut = Convert.ToString(dd.Rows(0)(1))
            Dat_Fin = Convert.ToString(dd.Rows(0)(2))



            report.SetParameterValue("Dat_Debut", Convert.ToString(Dat_Debut))
            report.SetParameterValue("Dat_Fin", Convert.ToString(Dat_Fin))

        Catch ex As Exception
            '  MessageBox.Show("Error de  delete string delete" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Module1.connecter()
    End Sub

    Private Function Left(dat_Debut As String, v As Integer) As String
        Throw New NotImplementedException()
    End Function

    Sub aff1(Code, Lign, Annee, report)

        Try
            Dim req As String = String.Format(" 
            select   distinct Titre_de_lign as 'Titre de  Lign '   from Etat_Generater
            where  Ligne_de_etat = " & Lign & "  and  Anne = " & Annee & " and code_de_letat= " & Code & "  
            group by  Titre_de_lign
            order by  Titre_de_lign")



            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)
            If dt.Rows.Count > 0 Then
                value2 = Convert.ToString(dt.Rows(0)(0))
                report.SetParameterValue(" & Code & " + "_Titre" & Lign, value2)

            Else


            End If
            'MsgBox(value)
        Catch ex As Exception
            '   MessageBox.Show("Error de  delete aff 1" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Sub ExPres(Lign, Column, anne, report)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "
            '--  T.Compte_de_Letat like '%' and and anne =  & anne & -- T.Compte_de_Letat like '%' andand anne =  & anne & 
            Dim req As String = String.Format(" 




            DECLARE @sum INT
            DECLARE @sum1 INT
            DECLARE @result INT
            set @sum = (Select  SUM(E.ER_MONT)   from Etat_Generater   T
                 join [{0}\DATA\BASE_COMPTA_001.MDF].[dbo].[fecriture] E on E.ER_Cpartie between T.P_Code_debut and T.P_Code_fin  and T.anne=E.ER_EXERC
                 where  Ligne_de_etat = " & Lign & " and Column_de_etat = " & Column & " and  E.ER_EXERC = " & anne & ")
            set @sum1 = (Select  SUM(E.ER_MONT)   from Etat_Generater T
                 join [{0}\DATA\BASE_COMPTA_001.MDF].[dbo].[fecriture] E on E.ER_Cpartie between T.P_Code_debut and T.P_Code_fin    -- and T.anne=E.ER_EXERC
                 where  Ligne_de_etat = " & Lign & " and Column_de_etat = " & Column + 1 & " and E.ER_EXERC =" & anne & ")
            begin 
              set @result = @sum - @sum1  
              if @result is null 
                begin 
                  set @result= 0
                end
            end
            select @result", New FileInfo(Application.ExecutablePath).DirectoryName, New FileInfo(Application.ExecutablePath).DirectoryName)



            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)
            valueExPres = Convert.ToInt32(dt.Rows(0)(0))
            report.SetParameterValue("zone" & Lign & "4", valueExPres)
            'MsgBox(value)
        Catch ex As Exception
            '   MessageBox.Show("Error de  delete expres " + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Sub ExPres100(Lign, Column, anne, report)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "
            '--  T.Compte_de_Letat like '%' and and anne =  & anne & -- T.Compte_de_Letat like '%' andand anne =  & anne & 
            Dim req As String = String.Format(" 




DECLARE @sum INT
DECLARE @sum1 INT
DECLARE @result INT
set @sum = (Select  SUM(E.ER_MONT)
from Etat_Generater
 T
     join [{0}\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut and T.P_Code_fin  --   and T.anne=E.ER_EXERC
where  Ligne_de_etat = " & Lign & " and Column_de_etat = " & Column & " and  E.ER_EXERC = " & anne & "

)
set @sum1 = (Select  SUM(E.ER_MONT)
from Etat_Generater
 T
     join [{0}\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut and T.P_Code_fin    -- and T.anne=E.ER_EXERC
where  Ligne_de_etat = " & Lign & " and Column_de_etat = " & Column + 1 & " and E.ER_EXERC =" & anne & "

)
begin 
set @result = @sum - @sum1  
if @result is null 
begin 
 set @result= 0
end
end
select @result


", New FileInfo(Application.ExecutablePath).DirectoryName, New FileInfo(Application.ExecutablePath).DirectoryName)




            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)
            valueExPres100 = Convert.ToInt32(dt.Rows(0)(0))
            report.SetParameterValue("zone" & Lign & "3", valueExPres100)
            'MsgBox(value)
        Catch ex As Exception
            '     MessageBox.Show("Error de  delete expres 1" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub


    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

        Dim report As New Liasses_Fiscales  'Rapport1
        Try


            Module1.connecter_soc()
            strinfg(Access.n2, report)
            Dim req1 As String
            req1 = (" Select S_pat, S_Nom, S_adr1,s_ville,s_tel,s_tva,s_email  from Fsociete where S_code =  " & Access.n2 & " ")        ', New FileInfo(Application.ExecutablePath).DirectoryName)
            cmd = New SqlCommand(req1, con)
            Dim adaptr2 As SqlDataAdapter
            adaptr2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptr2.Fill(dt)
            'MsgBox(dt.Rows.Count)




            report.SetParameterValue("Designation", Convert.ToString(dt.Rows(0)(1)))
            report.SetParameterValue("Adress", Convert.ToString(dt.Rows(0)(2)))
            report.SetParameterValue("Fsocial", Convert.ToString(dt.Rows(0)(0)))
            report.SetParameterValue("ville", Convert.ToString(dt.Rows(0)(3)))
            report.SetParameterValue("tel", Convert.ToString(dt.Rows(0)(4)))
            report.SetParameterValue("tva", Convert.ToString(dt.Rows(0)(5)))
            report.SetParameterValue("email", Convert.ToString(dt.Rows(0)(6)))
            Module1.connecter()

        Catch ex As Exception
            'MsgBox("error 1 " + ex.Message)
        End Try



        Try
            'Dim V1 As Integer
            'Dim v2 As Integer
            Dim Net_Courant As Integer
            Dim Net_Precedent As Integer
            'Dim req As String

            Net_Courant = 0
            Net_Precedent = 0






            '***************************************
            '* E1 Bilan Actif
            '***************************************
            For index = 1 To 40
                aff1("E1", index, exec_proc.n1, report)
                For index1 = 1 To 4

                    ind = False
                    Select Case index1
                        Case 1
                            Aff("E1", index, index1, exec_proc.n1, report)
                        Case 2
                            Aff("E1", index, index1, exec_proc.n1, report)
                        Case 3
                            Aff("E1", index, index1, exec_proc.n1, report)
                        Case 4
                            Aff("E1", index, index1, exec_proc.n1 - 1, report)
                    End Select
                    report.SetParameterValue("E1_zone" & index & "" & index1, IIf(value < 0, -1 * value, value))

                Next

            Next

            '***************************************
            '* E1 Bilan Passif
            '***************************************
            For index = 1 To 40
                aff1("E2", index, exec_proc.n1, report)
                For index1 = 1 To 2

                    ind = False
                    Select Case index1
                        Case 1
                            Aff("E2", index, index1, exec_proc.n1, report)
                        Case 2
                            Aff("E2", index, index1, exec_proc.n1, report)
                        Case 3
                            Aff("E2", index, index1, exec_proc.n1, report)
                        Case 4
                            Aff("E2", index, index1, exec_proc.n1 - 1, report)
                    End Select
                    report.SetParameterValue("E2_zone" & index & "" & index1, IIf(value < 0, -1 * value, value))

                Next

            Next

            '***************************************
            '* E1 Bilan Compte Charges e't Produits
            '***************************************
            For index = 1 To 32
                aff1("E3", index, exec_proc.n1, report)
                For index1 = 1 To 4

                    ind = False
                    Select Case index1
                        Case 1
                            Aff("E3", index, index1, exec_proc.n1, report)
                        Case 2
                            Aff("E3", index, index1, exec_proc.n1, report)
                        Case 3
                            Aff("E3", index, index1, exec_proc.n1, report)
                        Case 4
                            Aff("E3", index, index1, exec_proc.n1 - 1, report)
                    End Select
                    report.SetParameterValue("E3_zone" & index & "" & index1, IIf(value < 0, -1 * value, value))

                Next

            Next


        Catch ex As Exception
            'MsgBox("error" + ex.Message)
        End Try



        Me.CrystalReportViewer1.ReportSource = report




    End Sub

    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class