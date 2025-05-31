Imports System.Data.SqlClient
Imports System.IO

Public Class RaportBilanActif
    Dim cmd As SqlCommand
    Dim cmd3 As SqlCommand


    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter
    Dim value As Integer
    Dim value2 As String
    Dim valueExPres As Integer
    Dim valueExPres100 As Integer
    Dim Designation As String
    Dim Fsocial As String
    Dim Adresos As String
    Dim x As Integer = 0
    ReadOnly y As Integer
    Dim sum As Integer = 0
    Private i As Integer
    Sub Connecter()
        'If () Then

        Try
            'AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetCurrentDirectory())      " & Access.n2 & "       + " C:\Users\Ismail\Desktop\Nouveau dossier\repos\Prog_Contablite\Prog_Contablite"
            Dim chaineDeConnexion As String
            chaineDeConnexion = String.Format(" Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\DATA\Base_Compta_Soc.mdf;Integrated Security=True", New FileInfo(Application.ExecutablePath).DirectoryName)
            con = New SqlConnection(chaineDeConnexion)
            con.Open()

        Catch ex As Exception
            con.Close()

        Finally
            con.Close()
        End Try
        'End If
    End Sub
    ', S_code, Sance, anne
    Sub aff(Lign, Column, anne, report)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "
            '--  T.Compte_de_Letat like '%' and and anne =  & anne & -- T.Compte_de_Letat like '%' andand anne =  & anne & 
            Dim req As String = String.Format(" 





DECLARE @sum INT
set @sum = (Select  SUM(E.ER_MONT)
from Etat_Generater
 T
     join [{0}\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut and T.P_Code_fin   -- and T.anne=E.ER_EXERC 
where  Ligne_de_etat = " & Lign & " and  E.ER_EXERC = " & anne & " and Column_de_etat = " & Column & " 

)
begin 
if @sum is null 
begin 
 set @sum= 0
end
end
select @sum
", New FileInfo(Application.ExecutablePath).DirectoryName)




            '            If EXISTS(
            '        select SUM(E.ER_MONT) Then
            '                From Etat_Generater
            ' T
            '                Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & "  
            '  ) 
            '    BEGIN

            '                Select Case sum(E.ER_MONT)
            'From Etat_Generater
            ' T
            '                    Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where  Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & " 

            '    End
            '                    Else
            '                    BEGIN
            '                    Select Case 0
            '    End



            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)
            value = Convert.ToInt32(dt.Rows(0)(0))
            report.SetParameterValue("zone" & Lign & "" & Column, value)
            'MsgBox(value)
        Catch ex As Exception
            ' MessageBox.Show("Error de  delete aff" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Sub strinfg(code, report)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "
            '--  T.Compte_de_Letat like '%' and and anne =  & anne & -- T.Compte_de_Letat like '%' andand anne =  & anne & 
            Dim req As String = String.Format(" 

select S_pat,S_Nom,S_adr1  from Fsociete where S_code = '" & code & "'


", New FileInfo(Application.ExecutablePath).DirectoryName)
            cmd = New SqlCommand(req, con)
            Dim adaptr2 As SqlDataAdapter
            adaptr2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptr2.Fill(dt)

            Designation = Convert.ToString(dt.Rows(0)(1))
            Fsocial = Convert.ToString(dt.Rows(0)(0))
            Adresos = Convert.ToString(dt.Rows(0)(2))
            report.SetParameterValue("Designation", Convert.ToString(Designation))
            report.SetParameterValue("Adress", Convert.ToString(Adresos))
            report.SetParameterValue("Fsocial", Convert.ToString(Fsocial))
            MsgBox(Adresos)
        Catch ex As Exception
            '  MessageBox.Show("Error de  delete string delete" + ex.Message, "text", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Sub aff1(Lign, report)

        Try 'exec Ps_UpdateClasses      " & txtId.Text & ",'" & txtName.Text & "'," & cmbFiliere.SelectedValue & ", " & cmbYear.SelectedValue & "
            '--  T.Compte_de_Letat like '%' and and anne =  & anne & -- T.Compte_de_Letat like '%' andand anne =  & anne & 
            Dim req As String = String.Format(" 
select
                                Titre_de_lign as 'Titre de  Lign '
                                 
        
from Etat_Generater
where  Ligne_de_etat = " & Lign & "   
group by Ligne_de_etat , Titre_de_lign

", New FileInfo(Application.ExecutablePath).DirectoryName)




            '            If EXISTS(                        Ligne_de_etat as 'Ligne'
            '        select SUM(E.ER_MONT) Then
            '                From Etat_Generater
            ' T
            '                Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & "  
            '  ) 
            '    BEGIN

            '                Select Case sum(E.ER_MONT)
            'From Etat_Generater
            ' T
            '                    Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where  Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & " 

            '    End
            '                    Else
            '                    BEGIN
            '                    Select Case 0
            '    End






            '   exec Delete_into_Fecriture  '" & ER_JOURNL & "'," & ER_MOIS & "," & ER_FOLIO & ", " & ER_LIGNE & "," & ER_EXERC & "," & ER_JOUR & ""
            cmd = New SqlCommand(req, con)
            Dim adaptteeer2 As SqlDataAdapter
            adaptteeer2 = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adaptteeer2.Fill(dt)
            value2 = Convert.ToString(dt.Rows(0)(0))

            report.SetParameterValue("Titre" & Lign, value2)
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




            '            If EXISTS(
            '        select SUM(E.ER_MONT) Then
            '                From Etat_Generater
            ' T
            '                Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & "  
            '  ) 
            '    BEGIN

            '                Select Case sum(E.ER_MONT)
            'From Etat_Generater
            ' T
            '                    Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where  Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & " 

            '    End
            '                    Else
            '                    BEGIN
            '                    Select Case 0
            '    End






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




            '            If EXISTS(
            '        select SUM(E.ER_MONT) Then
            '                From Etat_Generater
            ' T
            '                Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & "  
            '  ) 
            '    BEGIN

            '                Select Case sum(E.ER_MONT)
            'From Etat_Generater
            ' T
            '                    Join() [C:\USERS\AYOUB\DESKTOP\DATA\BASE_COMPTA_001.MDF].[dbo].[ECRIT001] E on E.ER_COMPTE between T.P_Code_debut And T.P_Code_fin    
            'where  Ligne_de_etat = " & Lign & " And Column_de_etat = " & Column & " 

            '    End
            '                    Else
            '                    BEGIN
            '                    Select Case 0
            '    End






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

    Private Sub RaportBilanActif_Load(sender As Object, e As EventArgs) Handles MyBase.Load






        Connecter()

        'aff(2010, "MATERIEL ET OUTILLAGE", Access.n2)
        'Dim Materiel = value
        'aff(2010, "MATERIEL DE TRANSPORT", Access.n2)
        'Dim Materiel_tran = value
        'aff(2010, "AMORTISSEMENT MATERIEL ET OUTILLAGE", Access.n2)
        'Dim Materiel_am_out = value
        'aff(2010, "AMORTISSEMENT MATERIEL DE TRANSPORT", Access.n2)
        'Dim Materiel_am_tran = value



        Dim report As New Rapport_BilanActif
        Try
            strinfg("001", report)


            '    report.SetParameterValue("Designation", Convert.ToString(Designation))
            '    report.SetParameterValue("Adress", Convert.ToString(Adress))
            '    report.SetParameterValue("Fsocial", Convert.ToString(Fsocial))
        Catch ex As Exception
            '      MsgBox("error 1 " + ex.Message)
        End Try





        '''Dim val As String
        Try

            For index = 1 To 49
                For index1 = 1 To 2
                    'MsgBox(exec_proc.n1)
                    aff(index, index1, exec_proc.n1, report)

                Next

            Next

        Catch ex As Exception

        End Try



        Try
            For index = 1 To 48
                aff1(index, report)

            Next

            For index = 1 To 48

                ExPres(index, 1, exec_proc.n1 - 1, report)

                ExPres100(index, 1, exec_proc.n1, report)

            Next

        Catch ex As Exception
            '    MsgBox("error" + ex.Message)
        End Try



        Me.CrystalReportViewer1.ReportSource = report




    End Sub
End Class