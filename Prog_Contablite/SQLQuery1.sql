
create table Saisie_de_Parametre_Table (
ID int Not null primary key identity(1,1),
Code_Journal_Achats int ,
Code_Journal_Vents int ,
Racine_Comptes_Clients int ,
Racine_Comptes_Fournisseurs int ,
Racine_Comptes_Achats int ,
Racine_Comptes_Ventes int ,
Compte_TVA_Sur_Achats int ,
Compte_TVA_Sur_Ventes int ,
Taux_De_TVA_1 float ,
Taux_De_TVA_2 float ,
Taux_De_TVA_3 float ,
Suivi_Factures_CLts_Fournis nvarchar(50) not null ,
Compte_Caisse int ,
Compte_Banque int ,
Compte_Cheques_Postaux int , 
Journal_Compte_Caisse int ,
Journal_Compte_Banque int ,
Journal_Compte_Cheques_Postaux int , 
Code_Journal_Des_Reports_a_Nouveau int  
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Code_Journal_Achats) references FJournal(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Code_Journal_Vents) references FJournal(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Racine_Comptes_Clients) references FPlanComptable(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Racine_Comptes_Fournisseurs) references FPlanComptable(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Racine_Comptes_Achats) references FPlanComptable(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Racine_Comptes_Ventes) references FPlanComptable(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Compte_TVA_Sur_Achats) references FPlanComptable(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Compte_TVA_Sur_Ventes) references FPlanComptable(J_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Compte_Caisse) references FPlanComptable(C_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Compte_Banque) references FPlanComptable(C_CODE)
--Constraint  fk_Saisie_de_Parametre_Table foreign key (Compte_Cheques_Postaux) references FPlanComptable(C_CODE)
);


select * from FJournal

select * from FPlanComptable where C_CODE like '59%'
















insert into Saisie_de_Parametre_Table  values(600,700,3421,4411,611,711,3455,4456,20,0,0,'O',5161,5141,5146,0,0,0,59);

