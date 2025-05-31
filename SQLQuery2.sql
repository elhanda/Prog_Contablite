USE  [D:\Prog_Contablite\Prog_Contablite\bin\project\Data\BASE_COMPTA_SOC.MDF]
create table Etat_Generater(
id int not null primary key identity,
Code_de_Letat nvarchar(100),
Nom_de_etat nvarchar(100),
Titre_de_etat nvarchar(100),
Ligne_de_etat float,
Column_de_etat float,
P_Code_debut varchar(10) ,
P_Code_fin varchar(10) ,
anne nvarchar(100),


);

select * from Etat_Generater