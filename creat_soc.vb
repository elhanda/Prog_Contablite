Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class creat_soc

	Dim con1 As SqlConnection
	Dim sql As SqlConnection
	Dim cmd As SqlCommand
	Dim ds As DataSet = New DataSet()
	Dim adapt As SqlDataAdapter
	Dim adapt1 As SqlDataAdapter
	Dim adapt2 As SqlDataAdapter
	Dim adapt3 As SqlDataAdapter
	Private n1 As String
	Sub Connecter()
		'Dim chaineDeConnexion As String
		'chaineDeConnexion = "Data Source=.;Initial Catalog=Base_Compta_Soc;Integrated Security=True"
		'con1 = New SqlConnection(chaineDeConnexion)
		Try
			If ConnecterHome() = True Then


				Try
					MsgBox("successfully connected")
					con.Open()
				Catch ex As Exception
					MessageBox.Show("Erreur de connexion." + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
					con.Close()
				End Try
			End If
		Catch ex As Exception
			MsgBox("error de connection create soc " + ex.Message)
			con.Close()
		Finally
			con.Close()

		End Try


		'If HasConnection() = True Then
		'	

		'End If
	End Sub


	Sub aff()
		Try

			Dim searchQuery As String = "Select * From Fsociete"
			Dim command As New SqlCommand(searchQuery, con1)
			Dim adapter As New SqlDataAdapter(command)
			Dim table As New DataTable()
			adapter.Fill(table)
			DataGridView1.DataSource = table

			For i As Integer = 0 To DataGridView1.Rows.Count() - 1 Step +1
				Dim val As Integer = DataGridView1.Rows(i).Cells(15).Value


				If val < 2020 Then
					DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.CadetBlue
				End If
				If val > 2020 Then
					DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Coral
				End If
			Next

		Catch ex As Exception
			'Finally
			'	con.Close()
		End Try
	End Sub
	Sub add(S_code, S_Nom, S_formme, S_adr1, S_adr2, S_ville, S_codep, S_tel, S_fax, S_adm, S_igr, S_pat, S_rc, S_tva, S_excerc, S_obs)
		Try
			Connecter()

			For Each c As Control In GroupBox1.Controls

				If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

					If c.Text = "" Then
						MessageBox.Show(" les information ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
						Return
						Exit For
					End If
				End If
			Next

			Dim dialog As DialogResult
			dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
			If dialog = DialogResult.Yes Then
				Try

					'MessageBox.Show("S_code = " & S_code)
					'MessageBox.Show("S_Nom = " & S_Nom)
					'MessageBox.Show("S_formme = " & S_formme)
					'MessageBox.Show("S_adr1 = " & S_adr1)
					'MessageBox.Show("S_adr2 = " & S_adr2)
					'MessageBox.Show("S_ville = " & S_ville)
					'MessageBox.Show("S_codep = " & S_codep)
					'MessageBox.Show("S_tel = " & S_tel)
					'MessageBox.Show("S_fax = " & S_fax)
					'MessageBox.Show("S_adm = " & S_adm)
					'MessageBox.Show("S_igr = " & S_igr)
					'MessageBox.Show("S_pat = " & S_pat)
					'MessageBox.Show("S_rc = " & S_rc)
					'MessageBox.Show("S_tva = " & S_tva)
					'MessageBox.Show("exercice = " & S_excerc)
					'MessageBox.Show("S_obs = " & S_obs)

					''''''''''''''''''insert and  creating database '''''''''''''''''''''''''
					Try
						Dim req As String = "exec insert_into_FSociete '" & S_code & "','" & S_Nom & "','" & S_formme & "','" & S_adr1 & "','" & S_adr2 & "','" & S_ville & "','" & S_codep & "','" & S_tel & "','" & S_fax & "','" & S_adm & "','" & S_igr & "','" & S_pat & "','" & S_rc & "','" & S_tva & "','" & S_excerc & "','" & S_obs & "'"
						cmd = New SqlCommand(req, con)
						Dim adaptteeer As SqlDataAdapter
						adaptteeer = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adaptteeer.Fill(dt)
						aff()
					Catch ex As Exception
						MessageBox.Show("Insert data " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
					End Try

					Try


						Using con
							con.Open()
							Dim sqlreq = String.Format("CREATE DATABASE  Base_Compta_" & S_code & "

								 ON PRIMARY " & "(NAME = Base_Compta_" & S_code & ", " &
											  " FILENAME = '{0}\Data\Base_Compta_" & S_code & ".mdf', " &
											  " SIZE = 2MB, " &
											  " MAXSIZE = 10MB, " &
											  " FILEGROWTH = 10%) " &
											  " LOG ON " &
											  "(NAME = Base_Compta_" & S_code & "_Log, " &
											  " FILENAME = '{0}\Data\Base_Compta_" & S_code & "_Log.ldf', " &
											  " SIZE = 1MB, " &
											  " MAXSIZE = 5MB, " &
											  " FILEGROWTH = 10%) ", New FileInfo(Application.ExecutablePath).DirectoryName)
							'"C:\Users\Ismail\Desktop\Nouveau dossier\repos\Prog_Contablite\Prog_Contablite"


							Dim command As SqlCommand = New SqlCommand(sqlreq, con)
							command.ExecuteNonQuery()
						End Using
						con.Close()
					Catch ex As Exception
						MsgBox("Create Connection query Faild " + ex.Message)
						con.Close()
					Finally
						con.Close()
					End Try



					'''''''''''''''''''' using the data that we created ''''''''''''

					'Dim req2 As String = " use Base_Compta_" & S_code & ""
					'String.Format("Data Source=(LocalDB)\v11.0;Integrated Security=True;AttachDbFileName='{0}\MockDatamart.mdf'", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets"))
					'Dim req2 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ISMAIL\DESKTOP\NOUVEAU DOSSIER\REPOS\PROG_CONTABLITE\PROG_CONTABLITE\BIN\RELEASE\DATA\\Base_Compta_" & S_code & ";Integrated Security=True")
					'cmd = New SqlCommand(req2, con1)
					'	;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework

					Dim chaineConnectionStringgg = String.Format("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0}\Data\Base_Compta_" & S_code & ".mdf;Integrated Security=True; ", New FileInfo(Application.ExecutablePath).DirectoryName)
						Dim sql As SqlConnection = New SqlConnection(chaineConnectionStringgg)



						'sconnection.Open()
						'adapt2 = New SqlDataAdapter(cmd)
						'adapt2.Fill(ds, "use_data")
						sql.Open()

					''''''''''''''''''''''''''''''''''''''''''''create tables''''''''''''''''''''''''
					Try
						Dim req3 As String = String.Format("


												   
													DECLARE @CREATE_TEMPLATE_tables VARCHAR(MAX)
													DECLARE @CREATE_TEMPLATE_tables1 VARCHAR(MAX)
													DECLARE @CREATE_TEMPLATE_tables2 VARCHAR(MAX)
													DECLARE @CREATE_TEMPLATE_tables3 VARCHAR(MAX)
													DECLARE @CREATE_TEMPLATE_tables4 VARCHAR(MAX)
													DECLARE @CREATE_TEMPLATE_tables5 VARCHAR(MAX)
												  
	 SET                                               
@CREATE_TEMPLATE_tables = 'SELECT * INTO Base_Compta_{DBNAME}.DBO.FJournal FROM [{0}\Data\Base_Compta_Soc.mdf].[dbo].FJournal'

	


SET @CREATE_TEMPLATE_tables1 ='SELECT * INTO Base_Compta_{DBNAME}.DBO.FPlanComptable FROM [{0}\Data\Base_Compta_Soc.mdf].[dbo].FPlanComptable  '

SET @CREATE_TEMPLATE_tables2 ='CREATE TABLE [ECRIT001](
	[ER_EXERC] [float] NULL,
	[ER_JOURNL] [nvarchar](255) NULL,
	[ER_AN] [float] NULL,
	[ER_MOIS] [float] NULL,
	[ER_FOLIO] [float] NULL,
	[ER_COMPTE] [nvarchar](255) NULL,
	[ER_CPARTIE] [nvarchar](255) NULL,
	[ER_LIGNE] [float] NULL,
	[ER_JOUR] [float] NULL,
	[ER_LIBELLE] [nvarchar](255) NULL,
	[ER_MONT] [float] NULL,
	[ER_CODE] [nvarchar](255) NULL,
	[ER_NPIECE] [nvarchar](255) NULL
);'

SET @CREATE_TEMPLATE_tables3 =' CREATE TABLE FFactClt (
[FC_id] INT NOT NULL primary key, 
[FC_EXERC] VARCHAR(4),
[FC_NFACT] VARCHAR(255),
[FC_CODE] VARCHAR(255),
[FC_DATE] DATE,
[FC_NCOMPTE]  VARCHAR(255),
[FC_TTC] INT,
[FC_TVA] INT,
[FC_HT] INT,
[FC_REGLE] INT,
[FC_DATEECH] DATE,
[FC_MTREGLE] INT,
);'

SET @CREATE_TEMPLATE_tables4 ='CREATE TABLE FFactFrs(
[FF_id] INT NOT NULL, 
[FF_EXERC] VARCHAR(50),
[FF_NFACT] VARCHAR(50),
[FF_CODE] VARCHAR(50),
[FF_DATE] DATE,
[FF_NCOMPTE]  VARCHAR(50),
[FF_TTC] int,
[FF_TVA] int,
[FF_HT] int,
[FF_REGLE] int,
[FF_DATEECH] DATE,
[FF_MTREGLE] int,
);'

				SET @CREATE_TEMPLATE_tables5 ='SELECT * INTO Base_Compta_{DBNAME}.DBO.Fparam FROM [{0}\Data\Base_Compta_Soc.mdf].[dbo].Fparam '                                                               

													 DECLARE @SQL_SCRIPT_tables VARCHAR(MAX)
													  DECLARE @SQL_SCRIPT_tables1 VARCHAR(MAX)
													   DECLARE @SQL_SCRIPT_tables2 VARCHAR(MAX)
														DECLARE @SQL_SCRIPT_tables3 VARCHAR(MAX)
														 DECLARE @SQL_SCRIPT_tables4 VARCHAR(MAX)
														  DECLARE @SQL_SCRIPT_tables5 VARCHAR(MAX)
														   
													SET @SQL_SCRIPT_tables = REPLACE(@CREATE_TEMPLATE_tables, '{DBNAME}', '" & TextBox1.Text & "')
													SET @SQL_SCRIPT_tables1 = REPLACE(@CREATE_TEMPLATE_tables1, '{DBNAME}', '" & TextBox1.Text & "')
													SET @SQL_SCRIPT_tables2 = @CREATE_TEMPLATE_tables2
													SET @SQL_SCRIPT_tables3 = @CREATE_TEMPLATE_tables3
													SET @SQL_SCRIPT_tables4 = @CREATE_TEMPLATE_tables4
													SET @SQL_SCRIPT_tables5 = REPLACE(@CREATE_TEMPLATE_tables5, '{DBNAME}', '" & TextBox1.Text & "')
													
													EXECUTE (@SQL_SCRIPT_tables)
													EXECUTE (@SQL_SCRIPT_tables1)
													EXECUTE (@SQL_SCRIPT_tables2)
													EXECUTE (@SQL_SCRIPT_tables3)
													EXECUTE (@SQL_SCRIPT_tables4)
													EXECUTE (@SQL_SCRIPT_tables5)
												   

", New FileInfo(Application.ExecutablePath).DirectoryName)
						cmd = New SqlCommand(req3, Sql)

						adapt1 = New SqlDataAdapter(cmd)
						adapt1.Fill(ds, "use_data")

					Catch ex As Exception
						MessageBox.Show("create tables " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
						sql.Close()

					End Try
					Try
						Dim reqAFFLIS As String = "  

Z
CREATE proc [dbo].[afflistClass]
(@a int , @Exec float)
as


 select distinct
concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],SUBSTRING(ER_CPARTIE, 1, @a) as 'ER_CPARTIE',[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from [ECRIT001] 

where ER_AN =@Exec
 group by ER_CODE,concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],SUBSTRING(ER_CPARTIE, 1, @a),[ER_NPIECE],[ER_LIBELLE]
 order by SUBSTRING(ER_CPARTIE, 1, @a),concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN])


				"
						cmd = New SqlCommand(reqAFFLIS, sql)

						Dim adaptAFFLIS = New SqlDataAdapter(cmd)
						adaptAFFLIS.Fill(ds, "afflist")

					Catch ex As Exception
						MessageBox.Show("afflist = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
						sql.Close()

					End Try
					Try


						Dim reqAFFCL As String = "                                         


													CREATE proc [dbo].[afflistClass_FIlter]

@b int 
as

 SELECT distinct SUBSTRING(ER_CPARTIE, 1, 1) AS  'ER_CPARTIE',
IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'

 from [ECRIT001]
  group by SUBSTRING(ER_CPARTIE, 1, 1),ER_CODE
 
 having SUBSTRING(ER_CPARTIE, 1, 1)=@b 		

"
						cmd = New SqlCommand(reqAFFCL, sql)

						Dim adaptv = New SqlDataAdapter(cmd)
						adaptv.Fill(ds, "reqAFFCL")

					Catch ex As Exception
						MessageBox.Show("reqAFFCL = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					Try
						Dim reqAFFS As String = "
CREATE proc [dbo].[affSum]


@b varchar(3) 
as

begin

if @b= 'D'
begin

 SELECT 
IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'

 from FEcriture
  group by ER_CODE;
end
else
 if  @b = 'C'
 begin

 SELECT 
IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDIT'

 from [ECRIT001]
  group by ER_CODE;
 end
 end

"
						cmd = New SqlCommand(reqAFFS, sql)

						Dim adaptreqAFFS = New SqlDataAdapter(cmd)
						adaptreqAFFS.Fill(ds, " reqAFFS")

					Catch ex As Exception
						MessageBox.Show(" reqAFFS = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()


					End Try
					Try
						Dim reqAFFT As String = "


CREATE proc [dbo].[affTotoSeul](@Exec float )
as
begin
--select * from FEcriture
--SUBSTRING(ER_CPARTIE, 1, 1) AS
select distinct
concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_MOIS],[ER_LIGNE],SUBSTRING(ER_CPARTIE, 1, 9),[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from FJournal F join [ECRIT001] E on F.J_CODE = E.ER_JOURNL
and ER_AN = @Exec

 group by concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_MOIS],ER_CODE,[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

 
 end


"
						cmd = New SqlCommand(reqAFFT, sql)

						Dim adaptreqAFFT = New SqlDataAdapter(cmd)
						adaptreqAFFT.Fill(ds, " reqAFFT")

					Catch ex As Exception
						MessageBox.Show(" reqAFFT = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()


					End Try
					Try
						Dim reqDELET As String = "


 CREATE  proc [dbo].[Delete_into_Fecriture]
(
@ER_JOURNL     nvarchar(255),
@ER_MOIS      float,
@ER_FOLIO float ,
 @ER_LIGNE float ,
@ER_EXERC   float,
@ER_JOUR float

 )as 
begin

 
delete from [ECRIT001] where ER_JOURNL  =@ER_JOURNL and ER_MOIS   = @ER_MOIS and ER_FOLIO    =@ER_FOLIO and ER_LIGNE   = @ER_LIGNE and ER_EXERC=@ER_EXERC and ER_JOUR    =@ER_JOUR
end 

"
						cmd = New SqlCommand(reqDELET, sql)

						Dim adaptreqDELET = New SqlDataAdapter(cmd)
						adaptreqDELET.Fill(ds, " reqDELET")

					Catch ex As Exception
						MessageBox.Show(" reqDELET = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					Try
						Dim reqFIL As String = "

CREATE  proc [dbo].[FilterFecriture]
 @ER_FOLIO float,
 @ER_MOIS float,
 @ER_JOURNL nvarchar(255),
@ER_EXERC nvarchar(255)
  as
begin 
 select    
 distinct ER_LIGNE   ,

ER_JOUR    ,
ER_COMPTE,
ER_CPARTIE    ,
ER_LIBELLE      ,



 
IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'    from [ECRIT001] 
 WHERE ER_FOLIO LIKE @ER_FOLIO and   ER_MOIS= @ER_MOIS    And ER_JOURNL=@ER_JOURNL
  And ER_EXERC=@ER_EXERC
  group by ER_CODE ,

ER_JOUR    ,
ER_LIGNE   ,
ER_COMPTE,
ER_CPARTIE    ,

 ER_LIBELLE     

 end 

"
						cmd = New SqlCommand(reqFIL, sql)

						Dim adaptreqFIL = New SqlDataAdapter(cmd)
						adaptreqFIL.Fill(ds, " reqFIL")

					Catch ex As Exception
						MessageBox.Show(" reqFIL = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					Try
						Dim reqINS As String = "



CREATE proc [dbo].[insert_into_ECRIT001]
(
@ER_EXERC   float,
@ER_JOURNL       nvarchar(255),
@ER_AN    float,
@ER_MOIS    float,
@ER_FOLIO    float,
@ER_COMPTE   nvarchar(255),
@ER_CPARTIE     nvarchar(255),
@ER_LIGNE   float,
@ER_JOUR    float,
@ER_LIBELLE      nvarchar(255),
@mont float ,
 @choix int ,
@ER_NPIECE   nvarchar(255)
 )as 
begin
declare @a varchar(20) ,@b varchar(20)set 
@a='D'  set @b = 'C'
if @choix=1
begin
   if @ER_MOIS > 12 
   
	  begin
		 print 'error de lanne'
	  end
	  else 

		if @ER_JOUR > 31 
			begin
		   print 'error'
			end
		else
insert into ECRIT001 values(@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,@ER_COMPTE,@ER_CPARTIE,@ER_LIGNE,@ER_JOUR,@ER_LIBELLE,@mont ,@a,@ER_NPIECE)
end
else if @choix=2
begin
if @ER_MOIS > 12 
   
	  begin
		 print 'error de lanne'
	  end
	  else 

		if @ER_JOUR > 31 
			begin
		   print 'error'
			end
		else
insert into ECRIT001 values(@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,@ER_COMPTE,@ER_CPARTIE,@ER_LIGNE,@ER_JOUR,@ER_LIBELLE,@mont ,@b,@ER_NPIECE)
end
else print 'errer'
end

"
						cmd = New SqlCommand(reqINS, sql)

						Dim adaptreqINS = New SqlDataAdapter(cmd)
						adaptreqINS.Fill(ds, " reqINS")

					Catch ex As Exception
						MessageBox.Show(" reqINS = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					Try
						Dim reqUPd As String = "


CREATE  proc [dbo].[update_into_Fecriture]
(
@ER_CPARTIE     nvarchar(255),
@ER_LIBELLE      nvarchar(255),
@mont float ,
 @choix int ,
@ER_NPIECE   nvarchar(255),
@ER_JOURNL       nvarchar(255),
@ER_MOIS    float,
@ER_FOLIO    float,
@ER_LIGNE   float,
@ER_EXERC   float,
@ER_JOUR    float
 )as 
begin
declare @a varchar(20) ,@b varchar(20)set 
@a='D'  set @b = 'C'
if @choix=1
begin
   if @ER_MOIS > 12    
	  begin
		 print 'error de lanne'
	  end
	  else 
		if @ER_JOUR > 31 
			begin
		   print 'error'
			end
		else
		begin
update ECRIT001 set
ER_CPARTIE  =@ER_CPARTIE,
ER_LIBELLE   =@ER_LIBELLE,
ER_MONT  =@mont ,
ER_CODE  = @a ,
ER_NPIECE    =@ER_NPIECE
  where ER_JOURNL  =@ER_JOURNL and ER_MOIS   =@ER_MOIS and ER_FOLIO    =@ER_FOLIO and ER_LIGNE   = @ER_LIGNE and ER_EXERC=@ER_EXERC and ER_JOUR    =@ER_JOUR
 end
 end
else 
if @choix=2
begin
if @ER_MOIS > 12 
   
	  begin
		 print 'error de lanne'
	  end
	  else 
		if @ER_JOUR > 31 
			begin
		   print 'error'
			end
		else
		begin
		update ECRIT001 set
ER_CPARTIE  =@ER_CPARTIE,
ER_LIBELLE   =@ER_LIBELLE,
ER_MONT  =@mont ,
ER_CODE  = @b ,
ER_NPIECE    =@ER_NPIECE
  where ER_JOURNL  =@ER_JOURNL and ER_MOIS   =@ER_MOIS and ER_FOLIO    =@ER_FOLIO and ER_LIGNE   = @ER_LIGNE and ER_EXERC=@ER_EXERC and ER_JOUR    =@ER_JOUR
 end
 end
 end

 
"

						cmd = New SqlCommand(reqUPd, sql)

						Dim adaptreqINS = New SqlDataAdapter(cmd)
						adaptreqINS.Fill(ds, " reqUPd")

					Catch ex As Exception
						MessageBox.Show(" reqUPd = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''-------------------------------  [select_5_columns]	------------------------------''
					Try

						Dim req As String = "


CREATE proc [dbo].[select_5_columns]	
(@a int,@b int,@c int,@d int,@e int,@Exec float )as
begin

drop table  if exists tablecreated5
create table tablecreated5(
id int identity primary key ,
	DATE varchar(50) ,
	ER_JOURNL varchar(50),
	ER_FOLIO varchar(50),
	ER_LIGNE varchar(50),
	ER_CPARTIE varchar(50),
	ER_NPIECE varchar(50),
	ER_LIBELLE varchar(50),
	TYPE_DEBUT decimal,
	TYPE_CREDI decimal
); 
if @a=1 
insert into tablecreated5  exec [afflistClass]  1 ,2015
if @b=2
insert into tablecreated5  exec [afflistClass] 2 ,2015
if @c=3
insert into tablecreated5  exec [afflistClass] 3 ,2015
if @d=4
insert into tablecreated5  exec [afflistClass] 4 ,2015
if @e=5
insert into tablecreated5  exec [afflistClass] 5 ,2015
select  DATE,[ER_JOURNL],[ER_FOLIO],ER_CPARTIE,[ER_NPIECE],[ER_LIBELLE],sum(TYPE_DEBUT) as 'Debut',sum(TYPE_CREDI) as 'Credit' from tablecreated5 group by DATE,[ER_JOURNL],[ER_FOLIO],ER_CPARTIE,[ER_NPIECE], ER_LIBELLE order by ER_CPARTIE
end

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [select_5_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [select_4_columns]	------------------------------''
					Try

						Dim req As String = "


CREATE proc [dbo].[BalanceCompte]
(@anne int , @Exec float,@CompteDebut nvarchar(255),@CompteCredit nvarchar(255))
as

drop table  if exists aa
create table aa(
[ER_COMPTE] [nvarchar](255) NULL,
	[ER_LIBELLE] [nvarchar](255) NULL,
		TYPE_DEBUT float NULL,
		TYPE_Credit float NULL
);
insert into aa 

select E.[ER_COMPTE],P.C_LIBELLE,IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_Credit'
from [ECRIT001] E join  FPlanComptable P

on ER_AN=@anne and ER_EXERC=@Exec and [ER_COMPTE] between @CompteDebut+'%' and @CompteCredit+'2%' and P.C_CODE = E.ER_COMPTE group by [ER_COMPTE],P.C_LIBELLE,ER_CODE order by [ER_COMPTE]


select ER_COMPTE,ER_LIBELLE,sum(TYPE_DEBUT) as 'Débit',sum(TYPE_Credit)as 'Crédit' from aa group by ER_COMPTE,ER_LIBELLE order by ER_COMPTE

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [select_4_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [select_3_columns]	------------------------------''
					Try

						Dim req As String = "


CREATE proc [dbo].[EcritureCompte] 
(@moisDebut int ,@moiscredit int , @Exec float,@CompteDebut nvarchar(255), @CompteCredit nvarchar(255))
as
select ER_COMPTE from [ECRIT001] where
 ER_COMPTE between   @CompteDebut+'%'  and   @CompteCredit+'%' 
and  ER_MOIS between  @moisDebut  and @moiscredit
and ER_AN = @Exec
 group by ER_COMPTE

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [select_3_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [select_2_columns]	------------------------------''
					Try

						Dim req As String = "


CREATE proc [dbo].[EcritureCompte_All]
(@moisDeut int , @moisfin int,@CompteDebut nvarchar(255),@CompteCredit nvarchar(255),@Exec float)

as


select
concat(E.ER_JOUR , '/', [ER_MOIS], '/',[ER_AN]) 'DATE',ER_JOURNL,ER_FOLIO,ER_LIGNE,ER_COMPTE,ER_CPARTIE,ER_NPIECE,[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from FJournal F join [ECRIT001] as E on F.J_CODE = E.ER_JOURNL
where E.ER_COMPTE between  @CompteDebut+'%'  and   @CompteCredit+'%' 
and  ER_MOIS between  @moisDeut  and @moisfin
and ER_AN = @Exec
 group by concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_MOIS],ER_CODE,[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE],ER_COMPTE
 order by concat(E.ER_JOUR , '/', [ER_MOIS], '/',[ER_AN]),ER_COMPTE

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [select_2_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [list_number]------------------------------''
					Try

						Dim req As String = "


CREATE proc [dbo].[EcritureCompte_WithCompte] 
(@moisDeut int , @moisfin int,@CompteDebut nvarchar(255),@CompteCredit nvarchar(255),@Exec float,@Compte nvarchar(255))

as


select
concat(E.ER_JOUR , '/', [ER_MOIS], '/',[ER_AN]) 'DATE',ER_JOURNL,ER_FOLIO,ER_LIGNE,ER_CPARTIE,ER_NPIECE,[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from FJournal F join [ECRIT001] as E on F.J_CODE = E.ER_JOURNL

where E.ER_COMPTE between   @CompteDebut+'%'  and   @CompteCredit+'%' 
and  ER_MOIS between  @moisDeut  and @moisfin
and ER_AN = @Exec
and ER_COMPTE = @Compte
 group by concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_MOIS],ER_CODE,[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]
 order by concat(E.ER_JOUR , '/', [ER_MOIS], '/',[ER_AN])

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [list_number]: " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [list_month]------------------------------''
					Try

						Dim req As String = "

CREATE proc [dbo].[GrandLivre_AllList] (@a int , @b int,@Exec float,@c int , @d int)
as
begin
--select * from FEcriture
--SUBSTRING(ER_CPARTIE, 1, 1) AS
select distinct
concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_MOIS],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
where E.ER_CPARTIE between   @a  and   @b 
and  ER_MOIS between  @c  and @d 
and ER_AN = @Exec

 group by concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_MOIS],ER_CODE,[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

 end

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [list_month]: " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [list]------------------------------''
					Try

						Dim req As String = "

 CREATE proc [dbo].[list](@Exec float )
as
begin
DROP TABLE IF EXISTS afftout
	create table afftout(
	id int identity primary key ,
	DATE varchar(50) ,
	ER_JOURNL varchar(50),
	ER_FOLIO varchar(50),
	ER_MOIS varchar(50),
	ER_LIGNE varchar(50),
	ER_CPARTIE varchar(50),
	ER_NPIECE varchar(50),
	ER_LIBELLE varchar(50),
	TYPE_DEBUT decimal,
	TYPE_CREDI decimal
	);  
insert into afftout exec [affTotoSeul] 2015 

select distinct ER_MOIS,sum(TYPE_DEBUT),sum(TYPE_CREDI) from afftout group by ER_MOIS order by ER_MOIS
end

"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [list] : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------
					''-------------------------------  [affTotoSeulwith_month]------------------------------''
					Try

						Dim req As String = "


 CREATE proc [dbo].[TotalGrandLivre_month]
 (@Cartier1 int , @Cartier2 int,@Exec float,@datedeb int , @datefin int)
as
begin
	DROP TABLE IF EXISTS afftout
	create table afftout(
	id int identity primary key ,
	DATE varchar(50) ,
	ER_JOURNL varchar(50),
	ER_FOLIO varchar(50),
	ER_MOIS varchar(50),
	ER_LIGNE varchar(50),
	ER_CPARTIE varchar(50),
	ER_NPIECE varchar(50),
	ER_LIBELLE varchar(50),
	TYPE_DEBUT decimal,
	TYPE_CREDI decimal
	);  
	insert into afftout  exec [GrandLivre_AllList]   @Cartier1  , @Cartier2 ,@Exec ,@datedeb  , @datefin

	--select DATE,[ER_JOURNL],[ER_FOLIO],[ER_MOIS],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE],TYPE_DEBUT,TYPE_CREDI  from afftout group by  DATE,[ER_JOURNL],[ER_FOLIO],[ER_MOIS],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE],TYPE_DEBUT,TYPE_CREDI order by ER_MOIS

	select Distinct [ER_MOIS],SUM(TYPE_DEBUT)as 'Debut',SUM(TYPE_CREDI) as 'Credit' from afftout group by   [ER_MOIS],[ER_FOLIO] 


end
"
						cmd = New SqlCommand(req, sql)
						Dim adapttr As SqlDataAdapter
						adapttr = New SqlDataAdapter(cmd)
						Dim dt = New DataTable()
						adapttr.Fill(dt)

					Catch ex As Exception
						MessageBox.Show("check your proce [affTotoSeulwith_month] : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
		)
						sql.Close()

					End Try
					''----------------------------------------------------------------------------------------------------
					''///////////////////////////////////////////////////////////////////////////////////////////////////
					''----------------------------------------------------------------------------------------------------















				Catch ex As Exception
					MessageBox.Show("home = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
					sql.Close()
				Finally
					sql.Close()

				End Try

				MessageBox.Show("تم التعديل بنجاح", "info", MessageBoxButtons.OK, MessageBoxIcon.Information
)
				GroupBox4.Visible = False
				GroupBox2.Visible = True
				TextBox1.Enabled = False
				TextBox2.Enabled = False
				TextBox3.Enabled = False
				TextBox4.Enabled = False
				TextBox5.Enabled = False
				TextBox6.Enabled = False
				TextBox7.Enabled = False
				TextBox8.Enabled = False
				TextBox9.Enabled = False
				TextBox10.Enabled = False
				TextBox11.Enabled = False
				TextBox12.Enabled = False
				TextBox13.Enabled = False
				TextBox14.Enabled = False
				TextBox15.Enabled = False
				TextBox16.Enabled = False
				TextBox1.Clear()

				TextBox2.Clear()
				TextBox3.Clear()
				TextBox4.Clear()
				TextBox5.Clear()
				TextBox6.Clear()
				TextBox7.Clear()
				TextBox8.Clear()
				TextBox9.Clear()
				TextBox10.Clear()
				TextBox11.Clear()
				TextBox12.Clear()
				TextBox13.Clear()
				TextBox14.Clear()
				TextBox15.Clear()
				TextBox16.Clear()
			End If

		Catch ex As SqlException

			If (ex.Number = 3609) Then

				MessageBox.Show("هذا القسم موجود" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning
)
			End If
		Catch ee As Exception

			MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
			'Finally
			'	con1.Close()

		End Try


	End Sub
	Sub modif(S_code, S_Nom, S_formme, S_adr1, S_adr2, S_ville, S_codep, S_tel, S_fax, S_adm, S_igr, S_pat, S_rc, S_tva, S_excerc, S_obs)

		Try

			For Each c As Control In GroupBox1.Controls

				If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then

					If c.Text = "" Then
						MessageBox.Show("المرجوا ملئ جميع الخانات الإجبارية", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning
)
						Return
						Exit For
					End If
				End If
			Next

			Dim dialog As DialogResult
			dialog = MessageBox.Show("do you reelly whant to modify ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
			If dialog = DialogResult.Yes Then
				'Try
				'MessageBox.Show("S_code = " & S_code)
				'MessageBox.Show("S_Nom = " & S_Nom)
				'MessageBox.Show("S_formme = " & S_formme)
				'MessageBox.Show("S_adr1 = " & S_adr1)
				'MessageBox.Show("S_adr2 = " & S_adr2)
				'MessageBox.Show("S_ville = " & S_ville)
				'MessageBox.Show("S_codep = " & S_codep)
				'MessageBox.Show("S_tel = " & S_tel)
				'MessageBox.Show("S_fax = " & S_fax)
				'MessageBox.Show("S_adm = " & S_adm)
				'MessageBox.Show("S_igr = " & S_igr)
				'MessageBox.Show("S_pat = " & S_pat)
				'MessageBox.Show("S_rc = " & S_rc)
				'MessageBox.Show("S_tva = " & S_tva)
				'MessageBox.Show("exercice = " & S_excerc)
				'MessageBox.Show("S_obs = " & S_obs)
				'    '''''''''''''''''''' update the data  ''''''''''''

				Try
					Connecter()
					Dim req As String = "update_into_FSociete  '" & S_code & "','" & S_Nom & "','" & S_formme & "','" & S_adr1 & "','" & S_adr2 & "','" & S_ville & "','" & S_codep & "','" & S_tel & "','" & S_fax & "','" & S_adm & "','" & S_igr & "','" & S_pat & "','" & S_rc & "','" & S_tva & "','" & S_excerc & "','" & S_obs & "'"
					cmd = New SqlCommand(req, con1)
					Dim adaptteeer1 As SqlDataAdapter
					adaptteeer1 = New SqlDataAdapter(cmd)
					Dim dt = New DataTable()
					adaptteeer1.Fill(dt)
				Catch ex As Exception
					MessageBox.Show("update" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
				End Try
				'    '''''''''''''''''''' rename the data ''''''''''''''''''''''''''''''''
				'    '                    Try
				'    '                        MessageBox.Show(oldValue + "," + newValue)
				'    '                        Try
				'    '                            Dim req2 As String = "  
				'    'IF DATABASEPROPERTYEX (N'" & oldValue & "', N'Version') > 0
				'    'BEGIN
				'    'ALTER DATABASE [" & oldValue & "] SET SINGLE_USER
				'    'WITH ROLLBACK IMMEDIATE;
				'    'END

				'    'EXEC sp_renamedb  '" & oldValue & "','" & newValue & "'
				'    'IF DATABASEPROPERTYEX (N'" & newValue & "', N'Version') > 0
				'    'BEGIN
				'    'ALTER DATABASE [" & newValue & "] SET Multi_USER
				'    'WITH ROLLBACK IMMEDIATE;
				'    'END


				'    '"

				'    '                            cmd = New SqlCommand(req2, con)

				'    '                            adapt2 = New SqlDataAdapter(cmd)
				'    '                            adapt2.Fill(ds, "rename_data")
				'    '                        Catch ex As Exception
				'    '                            MessageBox.Show("renaming the data data " + ex.Message)
				'    '                        End Try




				'Catch ex As Exception
				'    MessageBox.Show(ex.Message)

				'End Try

				MessageBox.Show("تم التعديل بنجاح", "info", MessageBoxButtons.OK, MessageBoxIcon.Information
)
				GroupBox4.Visible = False
				GroupBox2.Visible = True
				TextBox1.Enabled = True
				TextBox2.Enabled = False
				TextBox3.Enabled = False
				TextBox4.Enabled = False
				TextBox5.Enabled = False
				TextBox6.Enabled = False
				TextBox7.Enabled = False
				TextBox8.Enabled = False
				TextBox9.Enabled = False
				TextBox10.Enabled = False
				TextBox11.Enabled = False
				TextBox12.Enabled = False
				TextBox13.Enabled = False
				TextBox14.Enabled = False
				TextBox15.Enabled = False
				TextBox16.Enabled = False
				TextBox1.Clear()

				TextBox2.Clear()
				TextBox3.Clear()
				TextBox4.Clear()
				TextBox5.Clear()
				TextBox6.Clear()
				TextBox7.Clear()
				TextBox8.Clear()
				TextBox9.Clear()
				TextBox10.Clear()
				TextBox11.Clear()
				TextBox12.Clear()
				TextBox13.Clear()
				TextBox14.Clear()
				TextBox15.Clear()
				TextBox16.Clear()
			End If

		Catch ex As SqlException

			If (ex.Number = 3609) Then

				MessageBox.Show("هذا القسم موجود" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning
)
			End If
		Catch ee As Exception

			MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning
)
		Finally
			con.Close()
		End Try




	End Sub
	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
		Me.Close()
		Form_Soc.Show()
	End Sub
	Dim rs As New Form_Choix.Resizer
	Private Sub creat_soc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		rs.FindAllControls(Me)
		Connecter()
		GroupBox4.Visible = False
		GroupBox2.Visible = True
		TextBox1.Enabled = False
		TextBox2.Enabled = False
		TextBox3.Enabled = False
		TextBox4.Enabled = False
		TextBox5.Enabled = False
		TextBox6.Enabled = False
		TextBox7.Enabled = False
		TextBox8.Enabled = False
		TextBox9.Enabled = False
		TextBox10.Enabled = False
		TextBox11.Enabled = False
		TextBox12.Enabled = False
		TextBox13.Enabled = False
		TextBox14.Enabled = False
		TextBox15.Enabled = False
		TextBox16.Enabled = False
	End Sub

	Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
		If n1 = 1 Then

			add(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox16.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox15.Text, TextBox8.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox9.Text, TextBox10.Text)
		End If
		If n1 = 2 Then
			MessageBox.Show(oldValue + "," + newValue)
			modif(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox16.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox15.Text, TextBox8.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox9.Text, TextBox10.Text)

		End If

	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		n1 = 1
		GroupBox4.Visible = True
		GroupBox2.Visible = False
		TextBox1.Enabled = True
		TextBox2.Enabled = True
		TextBox3.Enabled = True
		TextBox4.Enabled = True
		TextBox5.Enabled = True
		TextBox6.Enabled = True
		TextBox7.Enabled = True
		TextBox8.Enabled = True
		TextBox9.Enabled = True
		TextBox10.Enabled = True
		TextBox11.Enabled = True
		TextBox12.Enabled = True
		TextBox13.Enabled = True
		TextBox14.Enabled = True
		TextBox15.Enabled = True
		TextBox16.Enabled = True
	End Sub
	Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
		GroupBox4.Visible = False
		GroupBox2.Visible = True
		TextBox1.Enabled = False
		TextBox2.Enabled = False
		TextBox3.Enabled = False
		TextBox4.Enabled = False
		TextBox5.Enabled = False
		TextBox6.Enabled = False
		TextBox7.Enabled = False
		TextBox8.Enabled = False
		TextBox9.Enabled = False
		TextBox10.Enabled = False
		TextBox11.Enabled = False
		TextBox12.Enabled = False
		TextBox13.Enabled = False
		TextBox14.Enabled = False
		TextBox15.Enabled = False
		TextBox16.Enabled = False
		TextBox1.Clear()
		TextBox2.Clear()
		TextBox3.Clear()
		TextBox4.Clear()
		TextBox5.Clear()
		TextBox6.Clear()
		TextBox7.Clear()
		TextBox8.Clear()
		TextBox9.Clear()
		TextBox10.Clear()
		TextBox11.Clear()
		TextBox12.Clear()
		TextBox13.Clear()
		TextBox14.Clear()
		TextBox15.Clear()
		TextBox16.Clear()
	End Sub

	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
		aff()
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		n1 = 2
		GroupBox4.Visible = True
		GroupBox2.Visible = False
		TextBox1.Enabled = True
		TextBox2.Enabled = True
		TextBox3.Enabled = True
		TextBox4.Enabled = True
		TextBox5.Enabled = True
		TextBox6.Enabled = True
		TextBox7.Enabled = True
		TextBox8.Enabled = True
		TextBox9.Enabled = True
		TextBox10.Enabled = True
		TextBox11.Enabled = True
		TextBox12.Enabled = True
		TextBox13.Enabled = True
		TextBox14.Enabled = True
		TextBox15.Enabled = True
		TextBox16.Enabled = True



	End Sub
	Public oldValue As String
	Public newValue As String
	Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
		Dim value = (CType(sender, TextBox)).Text
		newValue = value

	End Sub

	Private Sub TextBox2_Enter(sender As Object, e As EventArgs) Handles TextBox2.Enter
		Dim value = (CType(sender, TextBox)).Text
		oldValue = value
		TextBox3.Text = oldValue
	End Sub

	Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
		Dim index As Integer
		index = e.RowIndex
		Dim selecteRow As DataGridViewRow
		selecteRow = DataGridView1.Rows(index)
		'Label19
		TextBox1.Text = selecteRow.Cells(1).Value.ToString()
		TextBox2.Text = selecteRow.Cells(2).Value.ToString()
		TextBox3.Text = selecteRow.Cells(3).Value.ToString()
		TextBox4.Text = selecteRow.Cells(4).Value.ToString()
		TextBox5.Text = selecteRow.Cells(5).Value.ToString()
		TextBox6.Text = selecteRow.Cells(6).Value.ToString()
		TextBox7.Text = selecteRow.Cells(7).Value.ToString()
		TextBox8.Text = selecteRow.Cells(8).Value.ToString()
		TextBox9.Text = selecteRow.Cells(9).Value.ToString()
		TextBox10.Text = selecteRow.Cells(10).Value.ToString()
		TextBox11.Text = selecteRow.Cells(11).Value.ToString()
		TextBox12.Text = selecteRow.Cells(12).Value.ToString()
		TextBox13.Text = selecteRow.Cells(13).Value.ToString()
		TextBox14.Text = selecteRow.Cells(14).Value.ToString()
		TextBox15.Text = selecteRow.Cells(15).Value.ToString()
		TextBox16.Text = selecteRow.Cells(16).Value.ToString()

	End Sub

	Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub



	Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub TextBox11_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox11.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
		End If
	End Sub

	Private Sub creat_soc_Resize(sender As Object, e As EventArgs) Handles Me.Resize
		rs.ResizeAllControls(Me)
	End Sub
End Class