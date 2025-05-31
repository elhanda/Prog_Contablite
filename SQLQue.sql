
use [D:\Prog_Contablite\Prog_Contablite\bin\project\Data\Base_Compta_Soc.mdf]

select  * from Etat_Generater
update Etat_Generater set Code_de_Letat='100' ,Nom_de_etat='ismail' , Titre_de_etat='hhhh' ,Ligne_de_etat=1 ,Column_de_etat=2 ,P_Code_debut='10',P_Code_fin='10' where id = (
select  id from Etat_Generater where Code_de_Letat=10 and Nom_de_etat='ff' and Titre_de_etat = 'ddd'
) 

--use 



select P_Code as 'CODE',P_Libelle AS 'LIBELLE',P_CompteDebut as 'CompteDebut',P_CompteFin as 'CompteFin',P_texte as 'Text' from Fparam_Base



 --e join FPlanComptable j on e.P_Code_debut = 


SELECT * from Etat_Generater1 
select * from Fparam
select * from [D:\Prog_Contablite\Prog_Contablite\bin\project\Data\Base_Compta_Soc.mdf].[dbo].ECRIT001
select * from FPlanComptable

update  Etat_Generater set Compte_de_Letat = 5 where id = 13


select 





select * from Etat_Generater  e join  ECRIT001 j on e.anne = j.ER_AN and e.Compte_de_Letat  = j.ER_COMPTE 













--from [D:\Prog_Contablite\Prog_Contablite\bin\project\Data\New folder\Base_Compta_Soc.mdf].[dbo].Etat_Generater

--  drop table Etat_Generater(
--                                    id int not null primary key identity,
--                                    Code_de_Letat nvarchar(100),
--                                    Nom_de_etat nvarchar(100),
--                                    Titre_de_etat nvarchar(100),
--                                    Ligne_de_etat float,
--                                    Column_de_etat float,
--                                    P_Code_debut varchar(10) ,
--                                    P_Code_fin varchar(10) ,
--                                    anne nvarchar(100),
--                                    Titre_de_Lign nvarchar(50),
--                                    Compte_de_Letat nvarchar(50)





----                                    );
--SELECT * INTO Etat_Generater

--from  Etat_Generater1 


--alter table Etat_Generater add   Compte_de_Letat nvarchar(100)

--DECLARE @i int = 0,@a int =(SELECT * from Etat_Generater1)

--WHILE @i <= @a
--BEGIN
   
--update  Etat_Generater1 set Titre_de_Lign=(select Titre_de_etat from Etat_Generater where id = @i ) where id = @i
--    SET @i = @i + 1;
--END






--DECLARE @i int =(SELECT  from Etat_Generater where id = ) ,@a int =(SELECT  from Etat_Generater where id = )

select F.P_CompteDebut ,F.P_CompteFin  from Fparam F join Etat_Generater E on  F.P_Code between 600 and 620 and E.P_Code_debut = 600 and E.P_Code_fin = 620

















--select distinct
--concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]) 'DATE',[ER_JOURNL],[ER_FOLIO],[ER_MOIS],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE], IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
--,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
--from FJournal F join FEcriture E on F.J_CODE = E.ER_JOURNL
--where E.ER_CPARTIE between   @a  and   @b 
--and  ER_MOIS between  @c  and @d 
--and ER_AN = @Exec

-- group by concat(E.ER_JOUR, '/', [ER_MOIS], '/',[ER_AN]),[ER_MOIS],ER_CODE,[ER_JOURNL],[ER_FOLIO],[ER_LIGNE],[ER_CPARTIE],[ER_NPIECE],[ER_LIBELLE]
















