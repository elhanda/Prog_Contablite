Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class Frm_Total_Compte_Param
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
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

    Sub aff()
        Try
            Dim searchQuery As String = String.Format("
	DROP TABLE IF EXISTS ssa
			create table ssa (

			 P_Code          varchar(100),
			 p_compteDebut  varchar(100),
			 P_CompteFin varchar(100),
			 P_text varchar(100),
				TYPE_DEBUT decimal,
				TYPE_CREDI decimal

			);


			insert into ssa 
select S.P_Code,S.P_CompteDebut,S.P_CompteFin,S.P_texte,IIF ( E.ER_CODE = 'D' , sum(E.ER_MONT),  '                 ')as 'TYPE_DEBUT'
            ,IIF ( E.ER_CODE = 'C' , sum(E.ER_MONT),  '                 ' )as 'TYPE_CREDI'
			from [{0}\Data\Base_Compta_Soc.mdf].[dbo].Fparam S 
			Inner join ECRIT001 E on E.ER_COMPTE between S.P_CompteDebut and S.P_CompteFin 
			group by S.P_Code,E.ER_CODE,E.ER_MONT,S.P_CompteDebut,S.P_CompteFin,S.P_texte order by S.P_Code





			select
P_Code,
p_compteDebut
,P_CompteFin
,P_text
,SUM(TYPE_DEBUT)as 'TYPE_DEBUT',
SUM(TYPE_CREDI)as 'TYPE_CREDI' 

from ssa group by P_Code,p_compteDebut,P_CompteFin,P_text



", New FileInfo(Application.ExecutablePath).DirectoryName)
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)


            DataGridView1.DataSource = table

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub Apersu()
        Try




            Dim dtable = New DataTable()
            With dtable
                .Columns.Add(" P_Code")
                .Columns.Add("p_compteDebut")
                .Columns.Add("P_CompteFin")
                .Columns.Add("P_text")
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

            Dim crystal As New Total_ompte_Param_Report

            crystal.SetDataSource(dtable)



            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = crystal
            GrandLivreReportViewer.Refresh()
            GrandLivreReportViewer.Show()
        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub Frm_Total_Compte_Param_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()

        aff()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Apersu()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        aff()
    End Sub
End Class