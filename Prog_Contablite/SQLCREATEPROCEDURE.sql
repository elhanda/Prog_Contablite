use Base_Compta_B110
go

CREATE PROCEDURE dbo.CREATE_PROCEDURE
AS
BEGIN



Create proc [dbo].[create_tables] @a varchar(50)
as 
begin

DECLARE @useDatabase VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE1 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE2 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE3 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE4 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE5 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE6 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE7 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE8 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE9 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE10 VARCHAR(MAX)
DECLARE @CREATE_TEMPLATE11 VARCHAR(MAX)

SET @CREATE_TEMPLATE = 'CREATE TABLE FJournal(
   J_Code VARCHAR(3),
   J_Libelle VARCHAR(50),
   J_Compte VARCHAR(10),
  );
  
INSERT INTO FJournal (    
   J_Code ,
   J_Libelle  ,
   J_Compte )
SELECT   
  
   J_Code  ,
   J_Libelle  ,
   J_Compte 
FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.FJournal;
'
  SET @CREATE_TEMPLATE1 ='CREATE TABLE FPlanComptable (
   
   C_Code VARCHAR(10),
   C_Type VARCHAR(1),
   C_Libelle VARCHAR(50),
   C_Lettre VARCHAR(1),
  );
  
  
INSERT INTO FPlanComptable ( 
     C_Code ,
   C_Type ,
   C_Libelle  ,
   C_Lettre 
  )
SELECT 
    
   C_Code ,
   C_Type ,
   C_Libelle  ,
   C_Lettre 
FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.FPlanComptable;
  '
  
  
  SET @CREATE_TEMPLATE2 =' CREATE TABLE FEcriture(
   ER_id INT NOT NULL, 
   ER_EXERC VARCHAR(4),
   ER_JOURNAL VARCHAR(3),
   ER_AN VARCHAR(4),
   ER_MOIS TINYINT,
   ER_FOLIO INTEGER,
   ER_JOUR TINYINT,
  
   ER_LIGNE INTEGER,
   ER_CPARTIE VARCHAR(10),
   F10 VARCHAR(255),
   ER_LIBELLE VARCHAR(255),
   ER_PIECE VARCHAR(20),
   ER_MONT FLOAT,
   ER_CODE NVARCHAR(1),
  );'
  SET @CREATE_TEMPLATE3 =' CREATE TABLE FFactClt (
   FC_id INT NOT NULL, 
   FC_EXERC VARCHAR(4),
   FC_NFACT VARCHAR(20),
   FC_CODE VARCHAR(20),
   FC_DATE DATE,
   FC_NCOMPTE  VARCHAR(10),
   FC_TTC INTEGER,
   FC_TVA INTEGER,
   FC_HT INTEGER,
   FC_REGLE INTEGER,
   FC_DATEECH DATE,
   FC_MTREGLE INTEGER,
  );
--  INSERT INTO FJournal (    J_id , 
--   J_Code ,
--   J_Libelle  ,
--   J_Compte )
--SELECT  J_id  , 
--   J_Code  ,
--   J_Libelle  ,
--   J_Compte 
--FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.FJournal;
'
  SET @CREATE_TEMPLATE4 ='CREATE TABLE FFactFrs(
   FF_id INT NOT NULL, 
   FF_EXERC VARCHAR(4),
   FF_NFACT VARCHAR(20),
   FF_CODE VARCHAR(20),
   FF_DATE DATE,
   FF_NCOMPTE  VARCHAR(10),
   FF_TTC INTEGER,
   FF_TVA INTEGER,
   FF_HT INTEGER,
   FF_REGLE INTEGER,
   FF_DATEECH DATE,
   FF_MTREGLE INTEGER,
  );'
  SET @CREATE_TEMPLATE5 ='CREATE TABLE Fparam (
   P_Code VARCHAR(10),
   P_Libelle VARCHAR(50),
   P_CompteDebut VARCHAR(10),
   P_CompteFin  VARCHAR(10),
   P_texte varchar(50)
   
 );
   INSERT INTO Fparam (    P_Code , 
   P_Libelle ,
   P_CompteDebut  ,
   P_CompteFin ,
   P_texte
   )
SELECT   
   P_Code  ,
   P_Libelle  ,
   P_CompteDebut ,
   P_CompteFin,
   P_texte

FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.Fparam
'

  SET @CREATE_TEMPLATE6 ='CREATE TABLE AA (
   ER_COMPTE nvarchar(255)
   ER_LIBELLE nvarchar(255),
   TYPE_DEBUT fLOAT,
   TYPE_Credit fLOAT
 
 );'
   SET @CREATE_TEMPLATE7 ='CREATE TABLE FPARAM_BASE (
   P_Code VARCHAR(10),
   P_Libelle VARCHAR(50),
   P_CompteDebut VARCHAR(10),
   P_CompteFin  VARCHAR(10),
   P_texte varchar(50)
   
 );

   INSERT INTO FPARAM_BASE (    P_Code , 
   P_Libelle ,
   P_CompteDebut  ,
   P_CompteFin ,
   P_texte
   )
SELECT   
   P_Code  ,
   P_Libelle  ,
   P_CompteDebut ,
   P_CompteFin,
   P_texte

FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.FPARAM_BASE
'

SET @CREATE_TEMPLATE8 ='CREATE TABLE FSOCIETE (
   S_id INT NOT NULL, 
   S_code VARCHAR(30),
   S_Nom VARCHAR(50),
   S_formme  VARCHAR(50),
   S_adr1  VARCHAR(50),
   S_adr2  VARCHAR(50),
   S_ville VARCHAR(50),
   S_codep  VARCHAR(50),
   S_tel VARCHAR(50),
   S_fax  VARCHAR(50),
   S_adm  VARCHAR(50),
   S_igr  VARCHAR(50),
   S_pat  VARCHAR(50),
   S_rc  VARCHAR(50),
   S_tva  VARCHAR(50),
   S_obs  VARCHAR(50),
   S_Email  VARCHAR(50)
 );
  INSERT INTO FSOCIETE (   
   S_id , 
   S_code ,
   S_Nom ,
   S_formme ,
   S_adr1 ,
   S_adr2 ,
   S_ville ,
   S_codep  ,
   S_tel,
   S_fax ,
   S_adm  ,
   S_igr ,
   S_pat ,
   S_rc ,
   S_tva,
   S_obs  ,
   S_Email  
   )
SELECT   
    S_id , 
   S_code ,
   S_Nom ,
   S_formme ,
   S_adr1 ,
   S_adr2 ,
   S_ville ,
   S_codep  ,
   S_tel,
   S_fax ,
   S_adm  ,
   S_igr ,
   S_pat ,
   S_rc ,
   S_tva,
   S_obs  ,
   S_Email  
FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.FSOCIETE

'

	SET @CREATE_TEMPLATE9 ='CREATE TABLE Periode_Soc (
   id_period INT,
   Code_Soc VARCHAR(255),
   Exercice VARCHAR(255),
   Date_Debut  DATE,
   Date_Fin DATE
 );'
 
--INSERT INTO Periode_Soc (  id_period ,
--   Code_Soc ,
--   Exercice,
--   Date_Debut ,
--   Date_Fin )
--SELECT id_period ,
--   Code_Soc ,
--   Exercice,
--   Date_Debut ,
--   Date_Fin
--FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.Periode_Soc
 

 
 SET @CREATE_TEMPLATE10 ='CREATE TABLE Saisie_de_Parametre_Table(
   id INT NOT NULL, 
   Code_Journal_Achats int,
   Code_Journal_Vents int,
   Racine_Comptes_Clients  int,
   Racine_Comptes_Fournisseurs int,
   Racine_Comptes_Achats  int,
   Racine_Comptes_Ventes int,
   Compte_TVA_Sur_Achats  int,
   Compte_TVA_Sur_Ventes int,
   Taux_De_TVA_1 float,
   Taux_De_TVA_2  float,
   Taux_De_TVA_3  float,
    Suivi_Factures_CLts_Fournis  nvarchar(50) ,
   Compte_Caisse  int,
   Compte_Banque   int,
   Compte_Cheques_Postaux   int,
   Journal_Compte_Caisse int,
   Journal_Compte_Banque  int,
   Journal_Compte_Cheques_Postaux  int,
   Code_Journal_Des_Reports_a_Nouveau  int
 );
 
INSERT INTO Saisie_de_Parametre_Table (   id  , 
   Code_Journal_Achats ,
   Code_Journal_Vents  ,
   Racine_Comptes_Clients  ,
   Racine_Comptes_Fournisseurs  ,
   Racine_Comptes_Achats  ,
   Racine_Comptes_Ventes ,
   Compte_TVA_Sur_Achats   ,
   Compte_TVA_Sur_Ventes  ,
   Taux_De_TVA_1  ,
   Taux_De_TVA_2  ,
   Taux_De_TVA_3   ,
   Suivi_Factures_CLts_Fournis   ,
   Compte_Caisse  ,
   Compte_Banque   ,
   Compte_Cheques_Postaux   ,
   Journal_Compte_Caisse,
   Journal_Compte_Banque  ,
   Journal_Compte_Cheques_Postaux  ,
   Code_Journal_Des_Reports_a_Nouveau   

   )

SELECT id  , 
 Code_Journal_Achats ,
   Code_Journal_Vents  ,
   Racine_Comptes_Clients  ,
   Racine_Comptes_Fournisseurs  ,
   Racine_Comptes_Achats  ,
   Racine_Comptes_Ventes ,
   Compte_TVA_Sur_Achats   ,
   Compte_TVA_Sur_Ventes  ,
   Taux_De_TVA_1  ,
   Taux_De_TVA_2  ,
   Taux_De_TVA_3   ,
   Suivi_Factures_CLts_Fournis   ,
   Compte_Caisse  ,
   Compte_Banque   ,
   Compte_Cheques_Postaux   ,
   Journal_Compte_Caisse,
   Journal_Compte_Banque  ,
   Journal_Compte_Cheques_Postaux  ,
   Code_Journal_Des_Reports_a_Nouveau   

FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.Saisie_de_Parametre_Table
 
 '

	SET @CREATE_TEMPLATE11 ='CREATE TABLE ssa (
   P_Code  VARCHAR(100),
   p_compteDebut VARCHAR(100),
   P_CompteFin  VARCHAR(100),
   P_text   VARCHAR(100),
   TYPE_DEBUT decimal(18, 0)
   TYPE_CREDI decimal(18, 0)
 );
 
INSERT INTO ssa ( P_Code ,
   p_compteDebut ,
   P_CompteFin  ,
   P_text   ,
   TYPE_DEBUT  ,
   TYPE_CREDI  )
SELECT P_Code ,
   p_compteDebut ,
   P_CompteFin  ,
   P_text   ,
   TYPE_DEBUT  ,
   TYPE_CREDI 
FROM [D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\BASE_COMPTA_SOC.MDF].dbo.ssa;
 
'



 DECLARE @SQL_SCRIPT VARCHAR(MAX)
  DECLARE @SQL_SCRIPT1 VARCHAR(MAX)
   DECLARE @SQL_SCRIPT2 VARCHAR(MAX)
    DECLARE @SQL_SCRIPT3 VARCHAR(MAX)
	 DECLARE @SQL_SCRIPT4 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT5 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT6 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT7 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT8 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT9 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT10 VARCHAR(MAX)
	  DECLARE @SQL_SCRIPT11 VARCHAR(MAX)
	  DECLARE @executeUse VARCHAR(MAX)

SET @SQL_SCRIPT = REPLACE(@CREATE_TEMPLATE, '{DBNAME}', @a)
SET @SQL_SCRIPT1 = REPLACE(@CREATE_TEMPLATE1, '{DBNAME}', @a)
SET @SQL_SCRIPT2 = REPLACE(@CREATE_TEMPLATE2, '{DBNAME}', @a)
SET @SQL_SCRIPT3 = REPLACE(@CREATE_TEMPLATE3, '{DBNAME}', @a)
SET @SQL_SCRIPT4 = REPLACE(@CREATE_TEMPLATE4, '{DBNAME}', @a)
SET @SQL_SCRIPT5 = REPLACE(@CREATE_TEMPLATE5, '{DBNAME}', @a)
SET @SQL_SCRIPT6 = REPLACE(@CREATE_TEMPLATE6, '{DBNAME}', @a)
SET @SQL_SCRIPT7 = REPLACE(@CREATE_TEMPLATE7, '{DBNAME}', @a)
SET @SQL_SCRIPT8 = REPLACE(@CREATE_TEMPLATE8, '{DBNAME}', @a)
SET @SQL_SCRIPT9 = REPLACE(@CREATE_TEMPLATE9, '{DBNAME}', @a)
SET @SQL_SCRIPT10 = REPLACE(@CREATE_TEMPLATE10, '{DBNAME}', @a)
SET @SQL_SCRIPT11 = REPLACE(@CREATE_TEMPLATE11, '{DBNAME}', @a)
--EXECUTE (@executeUse)
--EXECUTE (@SQL_SCRIPT)
--EXECUTE (@SQL_SCRIPT1)
--EXECUTE (@SQL_SCRIPT2)
--EXECUTE (@SQL_SCRIPT3)
--EXECUTE (@SQL_SCRIPT4)
--EXECUTE (@SQL_SCRIPT5)
 DECLARE @ExecuteScript NVARCHAR(MAX)
    SET @ExecuteScript = '
    USE Base_Compta_' + @a + ';
    EXECUTE(''' + @SQL_SCRIPT + ''');
    EXECUTE(''' + @SQL_SCRIPT1 + ''');
    EXECUTE(''' + @SQL_SCRIPT2 + ''');
    EXECUTE(''' + @SQL_SCRIPT3 + ''');
    EXECUTE(''' + @SQL_SCRIPT4 + ''');
    EXECUTE(''' + @SQL_SCRIPT5 + ''');
    EXECUTE(''' + @SQL_SCRIPT6 + ''');
    EXECUTE(''' + @SQL_SCRIPT7 + ''');
    EXECUTE(''' + @SQL_SCRIPT8 + ''');
    EXECUTE(''' + @SQL_SCRIPT9 + ''');
    EXECUTE(''' + @SQL_SCRIPT10 + ''');
    EXECUTE(''' + @SQL_SCRIPT11 + ''');
    '
	print  ' Base_Compta_' + @a + '';
   EXEC sp_executesql @ExecuteScript;
end


CREATE proc [dbo].[afflistClass]
(@a int , @Exec float)
as

begin
 select distinct
concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],SUBSTRING(ER_CPARTIE, 1, @a) as 'ER_CPARTIE',[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
from [fecriture] 

where ER_AN =@Exec
 group by ER_CODE,concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],SUBSTRING(ER_CPARTIE, 1, @a),[ER_NPIECE],[ER_LIBELLE]
 order by SUBSTRING(ER_CPARTIE, 1, @a),concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN])

 end
 

 
CREATE proc [dbo].[afflistClass_FIlter]

@b int 
as

 SELECT distinct SUBSTRING(ER_CPARTIE, 1, 1) AS  'ER_CPARTIE',
IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'

 from [fecriture]
  group by SUBSTRING(ER_CPARTIE, 1, 1),ER_CODE
 
 having SUBSTRING(ER_CPARTIE, 1, 1)=@b 

 --*************************************************

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

 from [fecriture]
  group by ER_CODE;
 end
 end

 /****** Object:  StoredProcedure [dbo].[affTotoSeul]    Script Date: 30/05/2023 12:59:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[affTotoSeul](@Exec float )
as
begin

--select distinct
--concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_MOIS],[ER_LIGNE],SUBSTRING(ER_CPARTIE, 1, 8),[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
--,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
--from Fecriture
-- WHERE ER_EXERC=@Exec
-- group by concat(ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_MOIS],ER_CODE,[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

 
 

select distinct
concat(E.ER_JOUR, '/',E.[ER_MOIS], '/',E.[ER_AN]) 'DATE',E.[ER_JOURNL],E.[ER_FOLIO],E.[ER_MOIS],E.[ER_LIGNE],SUBSTRING(E.ER_CPARTIE, 1, 8),E.[ER_NPIECE],P.[C_LIBELLE], IIF (E.ER_CODE = 'D' , sum(E.ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( E.ER_CODE = 'C' , sum(E.ER_MONT),  '                 ' )as 'TYPE_CREDI'
from Fecriture E join fplancomptable P ON E.ER_CPARTIE = P.C_CODE
 WHERE E.ER_EXERC=@Exec
 group by concat(E.ER_JOUR, '/', E.[ER_MOIS], '/',E.[ER_AN]),E.[ER_MOIS],E.ER_CODE,[ER_JOURNL],E.[ER_FOLIO],E.[ER_LIGNE],E.[ER_CPARTIE],E.[ER_NPIECE],P.[C_LIBELLE]


 end

 --------------------------------------------

 /****** Object:  StoredProcedure [dbo].[BalanceCompte]    Script Date: 30/05/2023 13:02:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[BalanceCompte]
(@anne int , @Exec float,@CompteDebut nvarchar(50),@CompteFin nvarchar(50),@chk1 int,@chk2 int,@chk3 int,@chk4 int,@chk5 int,@chk8 int )
as




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

insert into afftout exec [affTotoSeul] @exec


drop table  if exists aa
create table aa(
[ER_COMPTE] varchar(50),
er_libelle varchar(50),
	[Nombre] float NULL,
		TYPE_DEBUT float NULL,
		TYPE_Credit float NULL
);


if @chk1=1
begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@chk1),null,COUNT(substring(er_cpartie,1,@chk1)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@chk1))= @chk1 and [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@chk1) order by substring(er_cpartie,1,@chk1)
end


if @chk2=2
begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@chk2),null,COUNT(substring(er_cpartie,1,@chk2)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@chk2))= @chk2 and [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@chk2) order by substring(er_cpartie,1,@chk2)
end

if @chk3=3
begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@chk3),null,COUNT(substring(er_cpartie,1,@chk3)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@chk3))= @chk3 and [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@chk3) order by substring(er_cpartie,1,@chk3)
end


if @chk4=4
begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@chk4),null,COUNT(substring(er_cpartie,1,@chk4)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@chk4))= @chk4 and [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@chk4) order by substring(er_cpartie,1,@chk4)
end



if @chk5=5
begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@chk5),null,COUNT(substring(er_cpartie,1,@chk5)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@chk5))= @chk5 and [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@chk5) order by substring(er_cpartie,1,@chk5)
end


if @chk8=8
begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@chk8),er_libelle,COUNT(substring(er_cpartie,1,@chk8)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@chk8),er_libelle order by substring(er_cpartie,1,@chk8),er_libelle
end


select er_compte,er_libelle,Nombre,TYPE_DEBUT,TYPE_Credit from aa



/****** Object:  StoredProcedure [dbo].[Delete_into_Fecriture]    Script Date: 30/05/2023 13:04:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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

 
delete from [Fecriture] where ER_JOURNL  =@ER_JOURNL and ER_MOIS   = @ER_MOIS and ER_FOLIO    =@ER_FOLIO and ER_LIGNE   = @ER_LIGNE and ER_EXERC=@ER_EXERC and ER_JOUR    =@ER_JOUR
end 
 
 /****** Object:  StoredProcedure [dbo].[DeleteDuplicateRows]    Script Date: 30/05/2023 13:05:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[DeleteDuplicateRows] (@tableName nvarchar(255))
AS
BEGIN
    DECLARE @sqlCommand nvarchar(MAX);

    SET @sqlCommand = 'WITH CTE_Dupes AS 
                       (
                           SELECT *, 
                                  ROW_NUMBER() OVER (PARTITION BY ' + 
                                 (SELECT 
                                      STUFF((SELECT ', ' + c.name
                                       FROM sys.columns c
                                       WHERE c.object_id = OBJECT_ID(@tableName)
                                       AND c.is_identity = 0
                                       FOR XML PATH('')), 1, 2, '')) +
                                 ' ORDER BY ' + 
                                 (SELECT 
                                      STUFF((SELECT ', ' + c.name
                                       FROM sys.columns c
                                       WHERE c.object_id = OBJECT_ID(@tableName)
                                       AND c.is_identity = 0
                                       FOR XML PATH('')), 1, 2, '')) + 
                                 ') as RowNum 
                           FROM ' + @tableName + '
                       ) 
                       DELETE FROM CTE_Dupes 
                       WHERE RowNum > 1';

    EXEC sp_executesql @sqlCommand;
END;


/****** Object:  StoredProcedure [dbo].[EcritureCompte]    Script Date: 30/05/2023 13:06:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[EcritureCompte] 
(@moisDebut int ,@moiscredit int , @Exec float,@CompteDebut nvarchar(255), @CompteCredit nvarchar(255))
as
select ER_Cpartie from [fecriture] where
 ER_Cpartie between   @CompteDebut+'%'  and   @CompteCredit+'%' 
and  ER_MOIS between  @moisDebut  and @moiscredit
and ER_AN = @Exec
 group by ER_Cpartie

 /****** Object:  StoredProcedure [dbo].[EcritureCompte_All]    Script Date: 30/05/2023 13:07:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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

 /****** Object:  StoredProcedure [dbo].[EcritureCompte_WithCompte]    Script Date: 30/05/2023 13:08:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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


 /****** Object:  StoredProcedure [dbo].[FilterFecriture]    Script Date: 30/05/2023 13:09:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[FilterFecriture]
 @ER_FOLIO float,
 @ER_MOIS float,
 @ER_JOURNL nvarchar(255),
 @ER_EXERC nvarchar(255)
  

as
begin 

 select  distinct ER_LIGNE,ER_JOUR,ER_CPARTIE,ER_LIBELLE ,er_npiece,
 
     IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'DEBIT'
    ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'CREDIT'    from fecriture 
 WHERE ER_FOLIO LIKE @ER_FOLIO and   ER_MOIS= @ER_MOIS    And ER_JOURNL=@ER_JOURNL
     And ER_EXERC=@ER_EXERC
 GROUP by ER_LIGNE,ER_JOUR,ER_Cpartie,ER_CPARTIE,ER_LIBELLE,er_npiece,ER_CODE

 end 

 /****** Object:  StoredProcedure [dbo].[GrandLivre_AllList]    Script Date: 30/05/2023 13:09:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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

 /****** Object:  StoredProcedure [dbo].[GrandLivrechoix]    Script Date: 30/05/2023 13:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[GrandLivrechoix] 

(

@EXERC   float,
@Compte1  nvarchar(255),
@Compte2       nvarchar(255),
@Mois1 int,
@Mois2 int,  
@totmois int,
@totgen int

)as 


begin


if @totgen=1  
  begin
   select distinct
      [ER_CPARTIE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
   ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
   from FEcriture 
   where ER_CPARTIE between   @Compte1  and   @Compte2 
   and  ER_MOIS between  @Mois1  and @Mois2 
   and ER_AN = @Exerc
   group by [ER_CPARTIE],[ER_LIBELLE],ER_CODE,ER_AN

  end
else 
  if @totmois=1 
    begin
     select distinct
	  concat( '/',[ER_AN]) 'DATE',null,null,null,null,[ER_CPARTIE],null,[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
	 from FEcriture 
	 where ER_CPARTIE between   @Compte1  and   @Compte2 
	 and  ER_MOIS between  @Mois1  and @Mois2 
	 and ER_AN = @Exerc
	 group by concat('/',[ER_AN]),[ER_MOIS],[ER_CPARTIE],[ER_LIBELLE],ER_CODE

    end
  else
    begin 
	 select distinct

	 concat([ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_MOIS],null,[ER_CPARTIE],null,[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'

	 ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
	 from FEcriture 
	 where ER_CPARTIE between   @Compte1  and   @Compte2 
	 and  ER_MOIS between  @Mois1  and @Mois2 
	 and ER_AN = @Exerc
	 group by concat([ER_MOIS], '/',[ER_AN]),[ER_MOIS],[ER_CODE],[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]

	end

end  



--      null,null,null,null,null,[ER_CPARTIE],null,[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
--	 concat([ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_MOIS],null,[ER_CPARTIE],null,[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'


 select distinct
      [ER_CPARTIE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
   ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
   from FEcriture 
   where ER_CPARTIE between   '00000'  and   '99999999'
   and  ER_MOIS between 01  and 12
   and ER_AN = 2015
   group by [ER_CPARTIE],[ER_LIBELLE],ER_CODE



   /****** Object:  StoredProcedure [dbo].[insert_into_Fecriture]    Script Date: 30/05/2023 13:11:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[insert_into_Fecriture]
(
@0      float,
@ER_EXERC   float,
@ER_JOURNL       nvarchar(255),
@ER_AN    float,
@ER_MOIS    float,
@ER_FOLIO    float,
@ER_JOUR    float,
@ER_LIGNE   float,
@ER_CPARTIE     nvarchar(255),
@F10       nvarchar(255),
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
insert into FEcriture values(@0,@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,@ER_JOUR,@ER_LIGNE,@ER_CPARTIE,@F10,@ER_LIBELLE,@mont ,@a,@ER_NPIECE)
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
insert into FEcriture values(@0,@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,@ER_JOUR,@ER_LIGNE,@ER_CPARTIE,@F10,@ER_LIBELLE,@mont,@b,@ER_NPIECE)
end
else print 'errer'
end
/****** Object:  StoredProcedure [dbo].[list]    Script Date: 30/05/2023 13:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 CREATE proc [dbo].[list](@b int,@Exec float )
  --ALTER proc [dbo].[list](@Exec float )


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

insert into afftout exec [affTotoSeul] @exec

select distinct substring(ER_CPARTIE,1,@b),COUNT(substring(er_cpartie,1,@b)) ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@b))= @b 
group by substring(er_cpartie,1,@b) order by substring(er_cpartie,1,@b)


end
/****** Object:  StoredProcedure [dbo].[select_5_columns]    Script Date: 30/05/2023 13:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[select_5_columns]	(@a int,@b int,@c int,@d int,@e int,@Exec float )as

begin

drop table  if exists tablecreated5
create table tablecreated5(
id int identity primary key ,
    ER_CPARTIE varchar(50),
 	ER_LIBELLE varchar(50),
	TYPE_DEBUT decimal,
	TYPE_CREDI decimal
); 
if @a=1  
begin
  insert into tablecreated5  exec [afflistClass]  1 ,@Exec
end
if @a=2  
  insert into tablecreated5  exec [afflistClass] 2 ,@Exec
end
if @a=3
begin
  insert into tablecreated5  exec [afflistClass] 3 ,@Exec
end
if @a=3  
begin
  insert into tablecreated5  exec [afflistClass] 4 ,@Exec
end
if @a=5  
begin
  insert into tablecreated5  exec [afflistClass] 5 ,@Exec
end

select * from tablecreated5 

/****** Object:  StoredProcedure [dbo].[TotalGrandLivre_month]    Script Date: 30/05/2023 13:16:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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

/****** Object:  StoredProcedure [dbo].[TotauxBalance]    Script Date: 30/05/2023 13:17:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[TotauxBalance]
(@anne int , @Exec float,@CompteDebut nvarchar(255),@CompteFin nvarchar(255),@b int )
as






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

insert into afftout exec [affTotoSeul] @exec


drop table  if exists aa
create table aa(
id int identity primary key ,
[ER_COMPTE] [nvarchar](255) NULL,
	[Nombre] float NULL,
		TYPE_DEBUT float NULL,
		TYPE_Credit float NULL
);




begin
insert into aa 
select distinct substring(ER_CPARTIE,1,@b),COUNT(substring(er_cpartie,1,@b)) Nombre ,sum(TYPE_DEBUT) 'debit',sum(TYPE_CREDI) 'credit'  from afftout 
where len(substring(ER_CPARTIE,1,@b))= @b and [ER_CPARTIE] between @CompteDebut+'%' and @CompteFin+'2%' 
group by substring(er_cpartie,1,@b) order by substring(er_cpartie,1,@b)
end

select sum(Nombre),sum(TYPE_DEBUT),sum(TYPE_Credit) from aa  



/****** Object:  StoredProcedure [dbo].[update_into_Fecriture]    Script Date: 30/05/2023 13:18:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec [FilterFecriture] 1,1 ,900,2015
CREATE  proc [dbo].[update_into_Fecriture]

@ER_COMPTE varchar(10),
@ER_LIBELLE varchar(50),
@mont float ,
@choix int ,
@ER_NPIECE nvarchar(50),
@ER_JOURNL nvarchar(10),
@ER_MOIS   int,
@ER_FOLIO   int,
@ER_LIGNE   int,
@ER_EXERC   varchar(12),
@ER_JOUR float

 
 as
begin

declare @a varchar(20) ,@b varchar(20)
set @a='D' 
set @b='C'

--if @choix = 1  
--  begin
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
          update fecriture set ER_CPARTIE  =@ER_COMPTE,ER_LIBELLE   =@ER_LIBELLE,ER_MONT  =@mont ,ER_CODE  = iif(@choix=1,@a,@b), ER_NPIECE    =@ER_NPIECE, ER_JOUR =@ER_JOUR
		  where ER_JOURNL  =@ER_JOURNL and ER_MOIS   =@ER_MOIS and ER_FOLIO    =@ER_FOLIO and ER_LIGNE   = @ER_LIGNE and ER_EXERC=@ER_EXERC
        end
    --end
end

