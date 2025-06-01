Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class creat_soc

    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Private n1 As String





    Sub aff()
        connecter_soc()

        Try
            Dim searchQuery As String = "Select * From Fsociete"
            Dim command As New SqlCommand(searchQuery, con)
            Dim adapter As New SqlDataAdapter(command)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des sociétés : " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub CreateDatabase(dbName As String, CodeSoc As String)
        Try
            connecter_soc()

            Dim command As New SqlCommand("[CreateDatabase_base01]", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@DBName", dbName)
            command.ExecuteNonQuery()
            Console.WriteLine("La base de données '" & dbName & "' a été créée avec succès.")

            ' Call the stored procedure to create tables in the newly created database
            Dim createTablesCommand As New SqlCommand("[CreateTablesInthe_DB]", con)
            createTablesCommand.CommandType = CommandType.StoredProcedure
            createTablesCommand.Parameters.AddWithValue("@DBName", dbName)
            createTablesCommand.Parameters.AddWithValue("@codeSoc", CodeSoc)
            createTablesCommand.ExecuteNonQuery()
            Console.WriteLine("Les tables ont été créées dans la base de données '" & dbName & "'.")
        Catch ex As Exception
            MessageBox.Show("using the data data " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        ''//////////////////////////////////////////////////////////////////////////////////////////////////////
        '--------------------------- using the data that we created -------------------------
        Try
            'Dim req2 As String = " use " & S_code & ""
            Dim req2 As String = " use " & dbName & ""

            cmd = New SqlCommand(req2, con)

            adapt2 = New SqlDataAdapter(cmd)
            adapt2.Fill(ds, "use_data")
        Catch ex As Exception
            MessageBox.Show("using the data data " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Try
            Dim reqAFFLIS As String = "
                                CREATE proc [dbo].[afflistClass](
                                @a int,@Exec float )
                                as

                                 SELECT distinct SUBSTRING(ER_CPARTIE, 1, @a) AS  'ER_CPARTIE',   (ER_LIBELLE),
                                IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' ) as 'TYPE_DEBUT' ,
                                IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as ' TYPE_CREDI'

                                  from FEcriture
                                  where ER_EXERC = @Exec
                                  group by SUBSTRING(ER_CPARTIE, 1, @a),ER_CODE,ER_LIBELLE
                                                "
            cmd = New SqlCommand(reqAFFLIS, con)

            Dim adaptAFFLIS = New SqlDataAdapter(cmd)
            adaptAFFLIS.Fill(ds, "afflist")
            'MsgBox("afflistClass")
        Catch ex As Exception
            MessageBox.Show("afflist = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try


            Dim reqAFFCL As String = "                                         



                                                                            CREATE proc [dbo].[afflistClass_FIlter]
                                                                            @bc int 
                                                                            as
                                                                             SELECT distinct SUBSTRING(ER_CPARTIE, 1, 1) AS  'ER_CPARTIE', (ER_LIBELLE),
                                                                            IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
                                                                            ,IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'
                                                                             from FEcriture
                                                                              group by SUBSTRING(ER_CPARTIE, 1, 1),ER_CODE , (ER_LIBELLE)
                                                                             having SUBSTRING(ER_CPARTIE, 1, 1)=@bc 


                    "
            cmd = New SqlCommand(reqAFFCL, con)

            Dim adaptv = New SqlDataAdapter(cmd)
            adaptv.Fill(ds, "afflistClass_FIlter")

            ' MsgBox("afflistClass")
        Catch ex As Exception
            MessageBox.Show("reqAFFCL = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim reqAFFS As String = "

                                                                                create proc [dbo].[affSum]
                                                                                @bb varchar(3) 
                                                                                as
                                                                                begin
                                                                                if @bb= 'D'
                                                                                begin
                                                                                 SELECT 
                                                                                IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' )as 'TYPE_DEBUT'
                                                                                 from FEcriture
                                                                                  group by ER_CODE;
                                                                                end
                                                                                else
                                                                                 if  @bb = 'C'
                                                                                 begin
                                                                                 SELECT 
                                                                                IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDIT'
                                                                                 from FEcriture
                                                                                  group by ER_CODE;
                                                                                 end
                                                                                 end

                    "
            cmd = New SqlCommand(reqAFFS, con)

            Dim adaptreqAFFS = New SqlDataAdapter(cmd)
            adaptreqAFFS.Fill(ds, " reqAFFS")

            ' MsgBox("affSum")

        Catch ex As Exception
            MessageBox.Show(" reqAFFS = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
    )
        End Try
        Try
            Dim reqAFFT As String = "



                            CREATE proc [dbo].[affTotoSeul](@Exec float )
                            as
                            begin

   

 
 

                            select distinct
                            concat(E.ER_JOUR, '/',E.[ER_MOIS], '/',E.[ER_AN]) 'DATE',E.[ER_JOURNL],E.[ER_FOLIO],E.[ER_MOIS],E.[ER_LIGNE],SUBSTRING(E.ER_CPARTIE, 1, 8) as 'ER_CPARTIE',E.[ER_NPIECE],P.[C_LIBELLE], IIF (E.ER_CODE = 'D' , sum(E.ER_MONT),  '                 ' )as 'TYPE_DEBUT'
                            ,IIF ( E.ER_CODE = 'C' , sum(E.ER_MONT),  '                 ' )as 'TYPE_CREDI'
                            from Fecriture E join fplancomptable P ON E.ER_CPARTIE = P.C_CODE
                             WHERE E.ER_EXERC=@Exec
                             group by concat(E.ER_JOUR, '/', E.[ER_MOIS], '/',E.[ER_AN]),E.[ER_MOIS],E.ER_CODE,[ER_JOURNL],E.[ER_FOLIO],E.[ER_LIGNE],E.[ER_CPARTIE],E.[ER_NPIECE],P.[C_LIBELLE]


                             end


                            "
            cmd = New SqlCommand(reqAFFT, con)

            Dim adaptreqAFFT = New SqlDataAdapter(cmd)
            adaptreqAFFT.Fill(ds, " reqAFFT")

            ' MsgBox("affTotoSeul")

        Catch ex As Exception
            MessageBox.Show(" reqAFFT = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '*************************************************************************************************




        Try
            Dim reqAFFT As String = "



                            CREATE proc [dbo].[affTotoSeulwith_month](@a int , @b int,@Exec float )
                            as
                            begin
                                                      
                            SELECT  distinct   ER_CPARTIE,   (ER_LIBELLE),
                            (IIF ( ER_CODE = 'D' , sum(ER_MONT),  '                 ' ))as 'TYPE_DEBUT',
                            IIF ( ER_CODE = 'C' , sum(ER_MONT),  '                 ' )as 'TYPE_CREDI'

                             from FEcriture
                            where ER_Mois between @a and @b  and ER_EXERC = @Exec
                              group by ER_CPARTIE,ER_CODE ,ER_LIBELLE
 
                       
                             end

                            "
            cmd = New SqlCommand(reqAFFT, con)

            Dim adaptreqAFFT = New SqlDataAdapter(cmd)
            adaptreqAFFT.Fill(ds, " reqAFFT")

            ' MsgBox("affTotoSeulwith_month")

        Catch ex As Exception
            MessageBox.Show(" reqAFFT = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '*************************************************************************************************
        '*************************************************************************************************
        Try

            Dim reqbal As String = "


                             create  PROCEDURE [dbo].[Balance]
                            (
                             @Exec INT,
                            @CompteDebut NVARCHAR(50),
                            @CompteFin NVARCHAR(50),
                            @chk INT
                            )as 
                            begin
                                    SET NOCOUNT ON;

                                    SELECT  
                                        SUBSTRING(e.ER_CPARTIE, 1, @chk) AS Compte,
                                        j.C_LIBELLE AS Libelle,
                                        ROUND(SUM(CASE WHEN e.ER_CODE = 'D' THEN e.ER_MONT ELSE 0 END), 2) AS DEBIT,
                                        ROUND(SUM(CASE WHEN e.ER_CODE = 'C' THEN e.ER_MONT ELSE 0 END), 2) AS CREDIT,
                                        ROUND(
                                            SUM(CASE WHEN e.ER_CODE = 'D' THEN e.ER_MONT ELSE 0 END) - 
                                            SUM(CASE WHEN e.ER_CODE = 'C' THEN e.ER_MONT ELSE 0 END), 
                                        2) AS SOLDE
                                    FROM FEcriture e
                                    LEFT JOIN FPlanComptable j 
                                        ON SUBSTRING(e.ER_CPARTIE, 1, @chk) COLLATE SQL_Latin1_General_CP1_CI_AS 
                                           = j.C_CODE COLLATE SQL_Latin1_General_CP1_CI_AS
                                    WHERE 
                                        e.ER_EXERC = @Exec
                                        AND e.ER_CPARTIE BETWEEN @CompteDebut AND @CompteFin
                                    GROUP BY 
                                        SUBSTRING(e.ER_CPARTIE, 1, @chk), j.C_LIBELLE
                                    ORDER BY 
                                        Compte                     
                            end 
                            "
            cmd = New SqlCommand(reqbal, con)

            Dim adaptreqbal = New SqlDataAdapter(cmd)
            adaptreqbal.Fill(ds, " reqbal")


            ' MsgBox("Balance")
        Catch ex As Exception
            MessageBox.Show(" reqbal = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        '*************************************************************************************************

        Try

            Dim req As String = "




                create PROCEDURE [dbo].[BalanceCompte]
                    @anne INT,
                    @Exec FLOAT,
                    @CompteDebut NVARCHAR(50),
                    @CompteFin NVARCHAR(50),
                    @chk1 INT,
                    @chk2 INT,
                    @chk3 INT,
                    @chk4 INT,
                    @chk5 INT,
                    @chk8 INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    DROP TABLE IF EXISTS afftout;
                    CREATE TABLE afftout (
                        id INT IDENTITY PRIMARY KEY,
                        DATE VARCHAR(50),
                        ER_JOURNL VARCHAR(50),
                        ER_FOLIO VARCHAR(50),
                        ER_MOIS VARCHAR(50),
                        ER_LIGNE VARCHAR(50),
                        ER_CPARTIE VARCHAR(50),
                        ER_NPIECE VARCHAR(50),
                        ER_LIBELLE VARCHAR(50),
                        TYPE_DEBUT DECIMAL(18, 2), -- Adjust precision and scale as per your needs
                        TYPE_CREDI DECIMAL(18, 2)  -- Adjust precision and scale as per your needs
                    );

                    INSERT INTO afftout
                    EXEC [affTotoSeul] @Exec;

                    DROP TABLE IF EXISTS aa;
                    CREATE TABLE aa (
                        ER_Cpartie VARCHAR(50),
                        er_libelle VARCHAR(50),
                        Nombre FLOAT NULL,
                        TYPE_DEBUT FLOAT NULL,
                        TYPE_Credit FLOAT NULL
                    );

                    IF @chk1 = 1

                    BEGIN
                        INSERT INTO aa 
                        SELECT DISTINCT SUBSTRING(ER_CPARTIE, 1, @chk1), NULL, COUNT(SUBSTRING(ER_CPARTIE, 1, @chk1)), SUM(TYPE_DEBUT) AS TYPE_DEBUT, SUM(TYPE_CREDI) AS TYPE_Credit
                        FROM afftout 
                        WHERE LEN(SUBSTRING(ER_CPARTIE, 1, @chk1)) = @chk1
                        AND [ER_CPARTIE] BETWEEN @CompteDebut + '%' AND @CompteFin + '2%'
                        GROUP BY SUBSTRING(ER_CPARTIE, 1, @chk1)
                        ORDER BY SUBSTRING(ER_CPARTIE, 1, @chk1);
                    END;

                    IF @chk2 = 2
                    BEGIN
                        INSERT INTO aa 
                        SELECT DISTINCT SUBSTRING(ER_CPARTIE, 1, @chk2), NULL, COUNT(SUBSTRING(ER_CPARTIE, 1, @chk2)), SUM(TYPE_DEBUT) AS TYPE_DEBUT, SUM(TYPE_CREDI) AS TYPE_Credit
                        FROM afftout 
                        WHERE LEN(SUBSTRING(ER_CPARTIE, 1, @chk2)) = @chk2
                        AND [ER_CPARTIE] BETWEEN @CompteDebut + '%' AND @CompteFin + '2%'
                        GROUP BY SUBSTRING(ER_CPARTIE, 1, @chk2)
                        ORDER BY SUBSTRING(ER_CPARTIE, 1, @chk2);
                    END;

                    IF @chk3 = 3
                    BEGIN
                        INSERT INTO aa 
                        SELECT DISTINCT SUBSTRING(ER_CPARTIE, 1, @chk3), NULL, COUNT(SUBSTRING(ER_CPARTIE, 1, @chk3)), SUM(TYPE_DEBUT) AS TYPE_DEBUT, SUM(TYPE_CREDI) AS TYPE_Credit
                        FROM afftout 
                        WHERE LEN(SUBSTRING(ER_CPARTIE, 1, @chk3)) = @chk3
                        AND [ER_CPARTIE] BETWEEN @CompteDebut + '%' AND @CompteFin + '2%'
                        GROUP BY SUBSTRING(ER_CPARTIE, 1, @chk3)
                        ORDER BY SUBSTRING(ER_CPARTIE, 1, @chk3);
                    END;

                    IF @chk4 = 4
                    BEGIN
                        INSERT INTO aa 
                        SELECT DISTINCT SUBSTRING(ER_CPARTIE, 1, @chk4), NULL, COUNT(SUBSTRING(ER_CPARTIE, 1, @chk4)), SUM(TYPE_DEBUT) AS TYPE_DEBUT, SUM(TYPE_CREDI) AS TYPE_Credit
                        FROM afftout 
                        WHERE LEN(SUBSTRING(ER_CPARTIE, 1, @chk4)) = @chk4
                        AND [ER_CPARTIE] BETWEEN @CompteDebut + '%' AND @CompteFin + '2%'
                        GROUP BY SUBSTRING(ER_CPARTIE, 1, @chk4)
                        ORDER BY SUBSTRING(ER_CPARTIE, 1, @chk4);
                    END;

                    IF @chk5 = 5
                    BEGIN
                        INSERT INTO aa 
                        SELECT DISTINCT SUBSTRING(ER_CPARTIE, 1, @chk5), NULL, COUNT(SUBSTRING(ER_CPARTIE, 1, @chk5)), SUM(TYPE_DEBUT) AS TYPE_DEBUT, SUM(TYPE_CREDI) AS TYPE_Credit
                        FROM afftout 
                        WHERE LEN(SUBSTRING(ER_CPARTIE, 1, @chk5)) = @chk5
                        AND [ER_CPARTIE] BETWEEN @CompteDebut + '%' AND @CompteFin + '2%'
                        GROUP BY SUBSTRING(ER_CPARTIE, 1, @chk5)
                        ORDER BY SUBSTRING(ER_CPARTIE, 1, @chk5);
                    END;

                    IF @chk8 = 8
                    BEGIN
                        INSERT INTO aa 
                        SELECT DISTINCT SUBSTRING(ER_CPARTIE, 1, @chk8), er_libelle, COUNT(SUBSTRING(ER_CPARTIE, 1, @chk8)), SUM(TYPE_DEBUT) AS TYPE_DEBUT, SUM(TYPE_CREDI) AS TYPE_Credit
                        FROM afftout 
                        WHERE [ER_CPARTIE] BETWEEN @CompteDebut + '%' AND @CompteFin + '2%'
                        GROUP BY SUBSTRING(ER_CPARTIE, 1, @chk8), er_libelle
                        ORDER BY SUBSTRING(ER_CPARTIE, 1, @chk8), er_libelle;
                    END;
	
  
                END;

            "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            '  MsgBox("BalanceCompte")

        Catch ex As Exception
            MessageBox.Show("check your proce [balancecompte] : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        '*************************************************************************************************




        '*************************************************************************************************
        Try

            Dim reqdeld As String = "
                 
                create PROCEDURE [dbo].[delete_duplicates_fecriture]
                AS
                BEGIN
                    SET NOCOUNT ON;

                    ;WITH CTE_Duplicates AS (
                        SELECT 
                            *,
                            ROW_NUMBER() OVER (
                                PARTITION BY 
                                    ER_EXERC,
                                    ER_MOIS,
                                    ER_JOUR,
                                    ER_JOURNL,
                                    ER_FOLIO,
                                    ER_LIGNE,
                                    ER_CODE,
                                    ER_CPARTIE,
                                    ER_MONT,
                                    ER_NPIECE,
                                    ER_LIBELLE
                                ORDER BY (SELECT NULL)
                            ) AS rn
                        FROM FEcriture
                    )
                    DELETE FROM CTE_Duplicates
                    WHERE rn > 1
                END "

            cmd = New SqlCommand(reqdeld, con)

            Dim adaptreqDELET = New SqlDataAdapter(cmd)
            adaptreqDELET.Fill(ds, " reqDELEd")

        Catch ex As Exception
            MessageBox.Show(" reqbalc = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        'MsgBox("Delete_Duplicate_Fecriture")
        '***************************************************************************************



        '***********************************************************************************************
        Try
            Dim reqFIL As String = "

                          
                    create PROCEDURE [dbo].[FilterFecriture]
                        @ER_FOLIO2  NVARCHAR(255),  
                        @ER_MOIS2  NVARCHAR(255),
                        @ER_JOURNL2 NVARCHAR(255),
                        @ER_EXERC2  NVARCHAR(255)
                    AS
                    BEGIN
                        SET NOCOUNT ON;  -- Améliore les performances

                        SELECT    
        
                            ER_JOUR,
		                    ER_ligne,
                            ER_CPARTIE,
                            ER_NPIECE,
                            ER_LIBELLE,
		                    er_exerc,
		                    er_code,
		                    er_mont,
                            SUM(CASE WHEN ER_CODE = 'D' THEN ER_MONT ELSE 0 END) AS DEBIT,
                            SUM(CASE WHEN ER_CODE = 'C' THEN ER_MONT ELSE 0 END) AS CREDIT
		
                        FROM FEcriture 
                        WHERE 
                            CAST(ER_FOLIO AS FLOAT) = @ER_FOLIO2  
                            AND CAST(ER_MOIS AS FLOAT) = @ER_MOIS2    
                            AND ER_JOURNL = @ER_JOURNL2
                            AND CAST(ER_EXERC AS FLOAT) = @ER_EXERC2
                        GROUP BY 
        
                            ER_JOUR,
		                    ER_ligne,
                            ER_CPARTIE,
                            ER_NPIECE,
                            ER_LIBELLE,
		                    ER_EXERC,
		                    er_code,
		                    er_mont;
                    END
                            "



            cmd = New SqlCommand(reqFIL, con)

            Dim adaptreqFIL = New SqlDataAdapter(cmd)
            adaptreqFIL.Fill(ds, " reqFIL")

            '   MsgBox("FilterFecriture")
        Catch ex As Exception
            MessageBox.Show(" reqFIL = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        )
        End Try

        '******************************************************************************
        Try
            Dim reqFILj As String = "
   
               Create PROCEDURE [dbo].[FilterJournaux]
                    @ER_JOURNL2 NVARCHAR(255),
                    @ER_MOIS1   NVARCHAR(255),  
                    @ER_MOIS2   NVARCHAR(255),
                    @ER_EXERC2  NVARCHAR(255)
   
                AS
                BEGIN
                    SET NOCOUNT ON;  -- Améliore les performances

                    SELECT    
        
                        ER_JOUR,
		
                        ER_CPARTIE,
                        ER_NPIECE,
                        ER_LIBELLE,
		                er_exerc,
		                er_code,
		                er_mont,
                        SUM(CASE WHEN ER_CODE = 'D' THEN ER_MONT ELSE 0 END) AS DEBIT,
                        SUM(CASE WHEN ER_CODE = 'C' THEN ER_MONT ELSE 0 END) AS CREDIT
		
                    FROM FEcriture 
                    WHERE 
                        CAST(ER_MOIS AS FLOAT) >= @ER_MOIS1  
                        AND CAST(ER_MOIS AS FLOAT) <= @ER_MOIS2    
                        AND ER_JOURNL = @ER_JOURNL2
                        AND CAST(ER_EXERC AS FLOAT) = @ER_EXERC2
                    GROUP BY 
        
                        ER_JOUR,
		
                        ER_CPARTIE,
                        ER_NPIECE,
                        ER_LIBELLE,
		                ER_EXERC,
		                er_code,
		                er_mont;
                END"
            cmd = New SqlCommand(reqFILj, con)

            Dim adaptreqFIL = New SqlDataAdapter(cmd)
            adaptreqFIL.Fill(ds, " reqFILj")

            '  MsgBox("FilterJournaux")

        Catch ex As Exception
            MessageBox.Show(" reqFILj = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        )
        End Try


        '******************************************************************************
        Try
            Dim reqliv As String = "
                 CREATE PROCEDURE [dbo].[grand_livre]
                        @Exec INT,
                        @CompteDebut NVARCHAR(50),
                        @CompteFin NVARCHAR(50),
                        @mois1 INT,
                        @mois2 INT,
                        @chk1 INT,
                        @chk2 INT,
                        @jour1 INT = 1,
                        @jour2 INT = 31
                    AS
                    BEGIN
                        SET NOCOUNT ON;

                        DECLARE @date1 DATE = DATEFROMPARTS(@Exec, @mois1, @jour1)
                        DECLARE @date2 DATE = DATEFROMPARTS(@Exec, @mois2, @jour2)

                        SELECT 
                            DATEFROMPARTS(e.ER_EXERC, e.ER_MOIS, e.ER_JOUR) AS [Date],
                            e.er_journl,
                            e.er_folio,
                            e.er_ligne,
                            e.ER_CPARTIE COLLATE SQL_Latin1_General_CP1_CI_AS AS ER_CPARTIE,
                            e.er_npiece,
                            e.er_libelle,
                            CASE WHEN e.ER_CODE = 'D' THEN e.ER_MONT ELSE 0 END AS DEBIT,
                            CASE WHEN e.ER_CODE = 'C' THEN e.ER_MONT ELSE 0 END AS CREDIT
                        FROM FEcriture e
                        WHERE 
                            e.ER_exerc = @Exec
                            AND e.ER_CPARTIE BETWEEN @CompteDebut AND @CompteFin
                            AND DATEFROMPARTS(e.ER_EXERC, e.ER_MOIS, e.ER_JOUR) BETWEEN @date1 AND @date2
                        ORDER BY e.ER_exerc,e.ER_MOIS,er_jour, e.er_folio, e.er_ligne
                    END"

            cmd = New SqlCommand(reqliv, con)

            Dim adaptreqliv = New SqlDataAdapter(cmd)
            adaptreqliv.Fill(ds, " reqliv")

            '   MsgBox("grand_livre")
        Catch ex As Exception
            MessageBox.Show(" reqliv = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
    )
        End Try




        '******************************************************************************


        Try
            Dim reqINS As String = "




                            

                            Create proc [dbo].[insert_into_Fecriture]
                            (
                            @0      float,
                            @ER_EXERC3   float,
                            @ER_JOURNL3       nvarchar(255),
                            @ER_AN3    float,
                            @ER_MOIS3    float,
                            @ER_FOLIO3    float,
                            @ER_JOUR3   float,
                            @ER_LIGNE3   float,
                            @ER_CPARTIE3     nvarchar(255),
                            @F103       nvarchar(255),
                            @ER_LIBELLE3      nvarchar(255),
                            @mont3 float ,
                             @choix3 int ,
                            @ER_NPIECE3   nvarchar(255)
                             )as 
                            begin
                                declare @a3 varchar(20) ,@b3 varchar(20)set 
                                @a3='D'  set @b3 = 'C'
                                if @choix3=1
                                    begin
                                       if @ER_MOIS3 > 12  
                                          begin
                                             print 'error de lanne'
                    	                  end
                                       else 
                                            if @ER_JOUR3 > 31 
                    	     	                begin
                                                  print 'error'
                    		                    end
                                            else
                                              insert into FEcriture values(@0,@ER_EXERC3,@ER_JOURNL3,@ER_AN3,@ER_MOIS3,@ER_FOLIO3,@ER_JOUR3,@ER_LIGNE3,
                                                                         @ER_CPARTIE3,@F103,@ER_LIBELLE3,@mont3 ,@a3,@ER_NPIECE3)
                                    end
                                else 
                                    if @choix3=2
                                       begin
                                         if @ER_MOIS3 > 12 
                                           begin
                                             print 'error de lanne'
                    	                   end
                                         else 
                                           if @ER_JOUR3 > 31 
                    	     	             begin
                                               print 'error'
                    		                 end
                                           else
                                             insert into FEcriture values(@0,@ER_EXERC3,@ER_JOURNL3,@ER_AN3,@ER_MOIS3,@ER_FOLIO3,@ER_JOUR3,@ER_LIGNE3,@ER_CPARTIE3,@F103,@ER_LIBELLE3,@mont3,@b3,@ER_NPIECE3)
                                       end
                                    else print 'errer'
                            end


                    "
            cmd = New SqlCommand(reqINS, con)

            Dim adaptreqINS = New SqlDataAdapter(cmd)
            adaptreqINS.Fill(ds, " reqINS")

            '  MsgBox("insert_into_Fecriture")
        Catch ex As Exception
            MessageBox.Show(" reqINS = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        )
        End Try
        '*************************************************************************************
        Try
            Dim reqjrnc As String = "



                                CREATE PROCEDURE [dbo].[Journaux_Choix]
                        @ER_JOURNL2  NVARCHAR(255),  
                        @ER_MOIS1  NVARCHAR(255),
                        @ER_MOIS2 NVARCHAR(255),
                        @ER_EXERC2  NVARCHAR(255)
	
                    AS
                    BEGIN
                        SET NOCOUNT ON;  -- Améliore les performances

                        SELECT    
                            er_exerc,
		                    er_journl,
		                    er_mois,
                            ER_JOUR,
		                    ER_ligne,
                            ER_CPARTIE,
                            ER_NPIECE,
                            ER_LIBELLE,
		                    SUM(CASE WHEN ER_CODE = 'D' THEN ER_MONT ELSE 0 END) AS DEBIT,
                            SUM(CASE WHEN ER_CODE = 'C' THEN ER_MONT ELSE 0 END) AS CREDIT,
		                    er_code,
		                    er_mont
       
		
                        FROM FEcriture 
                        WHERE 
                            CAST(er_mois AS FLOAT) >= @ER_mois1  
                            AND CAST(ER_MOIS AS FLOAT) <= @ER_MOIS2    
                            AND ER_JOURNL = @ER_JOURNL2
                            AND CAST(ER_EXERC AS FLOAT) = @ER_EXERC2
                        GROUP BY 
        
                           er_exerc,
		                    er_journl,
		                    er_mois,
                            ER_JOUR,
		                    ER_ligne,
                            ER_CPARTIE,
                            ER_NPIECE,
                            ER_LIBELLE,
		                    er_code,
		                    er_mont
                    END
                   "
            cmd = New SqlCommand(reqjrnc, con)

            Dim adaptreqjrnc = New SqlDataAdapter(cmd)
            adaptreqjrnc.Fill(ds, " reqjrnc")

            '  MsgBox("Journaux_Choix")
        Catch ex As Exception
            MessageBox.Show(" reqjrnc = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        )
        End Try
        ''----------------------------------------------------------------------------------------------------
        ''///////////////////////////////////////////////////////////////////////////////////////////////////
        ''----------------------------------------------------------------------------------------------------
        ''-------------------------------  [list]------------------------------''
        Try

            Dim req As String = "

                         

                            create proc [dbo].[list](@Exec float )
                            as
                            begin
                            DROP TABLE IF EXISTS afftout
                            create table afftout(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50) ,
                            ER_LIBELLE varchar(50),
                            TYPE_DEBUT bigint ,
                            TYPE_CREDI bigint 
                            );  
                            insert into afftout exec [affTotoSeul] @Exec 

                            select distinct ER_CPARTIE,ER_LIBELLE,TYPE_DEBUT,TYPE_CREDI  from afftout group by ER_CPARTIE,ER_LIBELLE,TYPE_DEBUT,TYPE_CREDI order by TYPE_DEBUT,TYPE_CREDI
                            end
                            
                            "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            '   MsgBox("list")

        Catch ex As Exception
            MessageBox.Show("check your proce [list] : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        '************************************************************************************
        Try
            Dim reqlsyj As String = "

            
                CREATE PROCEDURE [dbo].[list_journal]
                    @Exec FLOAT,
                    @code_Journal VARCHAR(50),
                    @mois1 INT,
                    @mois2 INT
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Résultats + ligne TOTAL
                    SELECT * FROM (
                        -- Partie 1 : Lignes normales
                        SELECT  
                            f.er_jour,
                            f.er_folio,
                            MAX(CASE WHEN f.er_code = 'D' THEN f.er_cpartie ELSE '' END) AS Debit_Cpartie,
                            MAX(CASE WHEN f.er_code = 'C' THEN f.er_cpartie ELSE '' END) AS Credit_Cpartie,
                            MAX(f.ER_LIBELLE) AS ER_LIBELLE,
                            SUM(CASE WHEN f.er_code = 'D' THEN f.ER_mont ELSE 0 END) AS Montant_Debit,
                            SUM(CASE WHEN f.er_code = 'C' THEN f.ER_mont ELSE 0 END) AS Montant_Credit
                        FROM 
                            fecriture f
                        WHERE 
                            f.er_journl = @code_Journal 
                            AND f.er_exerc = @Exec
                            AND f.er_mois BETWEEN @mois1 AND @mois2
                        GROUP BY 
                            f.er_jour,
                            f.er_folio

    
                    ) AS T
                    ORDER BY
                        ISNULL(er_jour, 999999), ISNULL(er_folio, 999999); -- Met la ligne TOTAL à la fin
                    End
                                
                                            "
            cmd = New SqlCommand(reqlsyj, con)

            Dim adaptreqlsyj = New SqlDataAdapter(cmd)
            adaptreqlsyj.Fill(ds, " reqlsyj")

            '  MsgBox("list_journal")
        Catch ex As Exception
            MessageBox.Show(" reqlsyj = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
                        )
        End Try
        '********************************************************************************
        Try
            Dim reqlsyj1 As String = "

                CREATE PROCEDURE [dbo].[list_journal1]
                @annee INT,
                @code_journal_debut VARCHAR(10),
                @code_journal_fin VARCHAR(10)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    -- Met tout dans une table dérivée pour pouvoir trier proprement
                    SELECT *
                    FROM (
                        -- Partie 1 : données par journal
                        SELECT 
                            f.er_journl AS code_journal,
                            j.j_libelle AS libelle,
                            COUNT(*) AS nombre_de_lignes,
                            MAX(CASE WHEN f.er_code = 'D' THEN f.er_cpartie ELSE '' END) AS Debit_Cpartie,
                            MAX(CASE WHEN f.er_code = 'C' THEN f.er_cpartie ELSE '' END) AS Credit_Cpartie,
                            SUM(CASE WHEN f.er_code = 'D' THEN ISNULL(f.ER_mont, 0) ELSE 0 END) AS Total_Debit,
                            SUM(CASE WHEN f.er_code = 'C' THEN ISNULL(f.ER_mont, 0) ELSE 0 END) AS Total_Credit,
                            CAST(
                                SUM(CASE WHEN f.er_code = 'D' THEN ISNULL(f.ER_mont, 0) ELSE 0 END)
                                - SUM(CASE WHEN f.er_code = 'C' THEN ISNULL(f.ER_mont, 0) ELSE 0 END)
                                AS DECIMAL(18,2)
                            ) AS Solde
                        FROM 
                            fecriture f
                        LEFT JOIN 
                            Fjournal j 
                            ON f.er_journl COLLATE French_CI_AS = j.j_code COLLATE French_CI_AS
                        WHERE 
                            f.er_exerc = @annee
                            AND f.er_journl BETWEEN @code_journal_debut AND @code_journal_fin
                        GROUP BY 
                            f.er_journl, j.j_libelle

                        UNION ALL

                        -- Partie 2 : ligne TOTAL GÉNÉRAL
                        SELECT 
                            'TOTAL' AS code_journal,
                            '' AS libelle,
                            COUNT(*) AS nombre_de_lignes,
                            '' AS Debit_Cpartie,
                            '' AS Credit_Cpartie,
                            SUM(CASE WHEN f.er_code = 'D' THEN ISNULL(f.ER_mont, 0) ELSE 0 END),
                            SUM(CASE WHEN f.er_code = 'C' THEN ISNULL(f.ER_mont, 0) ELSE 0 END),
                            CAST(
                                SUM(CASE WHEN f.er_code = 'D' THEN ISNULL(f.ER_mont, 0) ELSE 0 END)
                                - SUM(CASE WHEN f.er_code = 'C' THEN ISNULL(f.ER_mont, 0) ELSE 0 END)
                                AS DECIMAL(18,2)
                            )
                        FROM 
                            fecriture f
                        WHERE 
                            f.er_exerc = @annee
                            AND f.er_journl BETWEEN @code_journal_debut AND @code_journal_fin
                    ) AS T

                    ORDER BY 
                        CASE WHEN code_journal = 'TOTAL' THEN 'ZZZ' ELSE code_journal END;
                END

                 
                                            "
            cmd = New SqlCommand(reqlsyj1, con)

            Dim adaptreqlsyj1 = New SqlDataAdapter(cmd)
            adaptreqlsyj1.Fill(ds, " reqlsyj1")

            '  MsgBox("list_journal1")
        Catch ex As Exception
            MessageBox.Show(" reqlsyj1 = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
                        )
        End Try
        '*************************************************************************************
        Try
            Dim reqljrn As String = "
            
                    CREATE PROCEDURE [dbo].[list_journaux]
                        @annee INT,
                        @code_journal_debut VARCHAR(10),
                        @code_journal_fin VARCHAR(10)
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        SET ANSI_WARNINGS OFF;

                        -- Requête principale sans ligne de total
                        SELECT 
                            f.er_journl AS code_journal,
                            j.j_libelle AS libelle,
                            f.er_mois AS mois,
                            f.er_folio AS folio,
                            COUNT(*) AS nbre_de_lignes,
                            MAX(CASE WHEN f.er_code = 'D' THEN f.er_cpartie ELSE '' END) AS Debit_Cpartie,
                            MAX(CASE WHEN f.er_code = 'C' THEN f.er_cpartie ELSE '' END) AS Credit_Cpartie,
                            SUM(CASE WHEN f.er_code = 'D' THEN ISNULL(f.ER_mont, 0) ELSE 0 END) AS Total_Debit,
                            SUM(CASE WHEN f.er_code = 'C' THEN ISNULL(f.ER_mont, 0) ELSE 0 END) AS Total_Credit,
                            CAST(
                                SUM(CASE WHEN f.er_code = 'D' THEN ISNULL(f.ER_mont, 0) ELSE 0 END) -
                                SUM(CASE WHEN f.er_code = 'C' THEN ISNULL(f.ER_mont, 0) ELSE 0 END)
                                AS DECIMAL(18,2)
                            ) AS Solde
                        FROM 
                            fecriture f
                        LEFT JOIN 
                            Fjournal j ON f.er_journl COLLATE French_CI_AS = j.j_code COLLATE French_CI_AS
                        WHERE 
                            f.er_exerc = @annee
                            AND f.er_journl BETWEEN @code_journal_debut AND @code_journal_fin
                        GROUP BY 
                            f.er_journl, j.j_libelle, f.er_mois, f.er_folio

                        ORDER BY 
                            f.er_journl, f.er_mois, f.er_folio;

                        SET ANSI_WARNINGS ON;
                    END

  
                                            "
            cmd = New SqlCommand(reqljrn, con)

            Dim adaptreqljrn = New SqlDataAdapter(cmd)
            adaptreqljrn.Fill(ds, " reqljrn")

            '  MsgBox("list_journaux")
        Catch ex As Exception
            MessageBox.Show(" reqljrn = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
                        )
        End Try
        '*************************************************************************************
        Try
            Dim reqlstm As String = "
                         Create proc [dbo].[list_month]
                             (@a int , @b int,@Exec float)
                            as
                            begin
                            DROP TABLE IF EXISTS afftout
                            create table afftout(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50) ,
                            ER_LIBELLE varchar(50),
                            TYPE_DEBUT bigint ,
                            TYPE_CREDI bigint 
                            );  
                            insert into afftout exec [affTotoSeulwith_month] @a  , @b ,@Exec 

                            select distinct ER_CPARTIE,ER_LIBELLE,TYPE_DEBUT,TYPE_CREDI  from afftout group by ER_CPARTIE,ER_LIBELLE,TYPE_DEBUT,TYPE_CREDI order by TYPE_DEBUT,TYPE_CREDI
                            end
                           
                                            "
            cmd = New SqlCommand(reqlstm, con)

            Dim adaptreqlstm = New SqlDataAdapter(cmd)
            adaptreqlstm.Fill(ds, " reqlstm")

            '    MsgBox("list_month")
        Catch ex As Exception
            MessageBox.Show(" reqlstm = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
                        )
        End Try

        '*************************************************************************************
        Try
            Dim reqlstn As String = "
            
                            CREATE proc [dbo].[list_number]
                             (@s int,@Exec float)
                            as
                            begin
                            DROP TABLE IF EXISTS aff_list_number
                            create table aff_list_number(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50) ,
                            TYPE_DEBUT__TYPE_CREDI bigint 

                            );  
                            insert into aff_list_number exec [afflistClass] @s ,@Exec 
                            select distinct ER_CPARTIE,  sum(TYPE_DEBUT__TYPE_CREDI) from aff_list_number group by ER_CPARTIE
                            end
                                         
                                            "
            cmd = New SqlCommand(reqlstn, con)

            Dim adaptreqlstn = New SqlDataAdapter(cmd)
            adaptreqlstn.Fill(ds, " reqlstn")

            '  MsgBox("list_number")
        Catch ex As Exception
            MessageBox.Show(" reqlstn = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
                        )
        End Try


        '*************************************************************************************
        Try
            Dim reqUPd As String = "



                 CREATE proc [dbo].[update_into_Fecriture]

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
                        @ER_JOUR int

 
                         as
                        begin

                        declare @a varchar(20) ,@b varchar(20)
                        set @a='D' 
                        set @b='C'

                        if @choix = 1  
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
                        update fecriture set

                        ER_CPARTIE  =@ER_COMPTE,
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
		                        update FEcriture set
                        ER_CPARTIE = @ER_COMPTE,
                        ER_LIBELLE   =@ER_LIBELLE,
                        ER_MONT  =@mont ,
                        ER_CODE  = @b,
                        ER_NPIECE    =@ER_NPIECE
                          where ER_JOURNL  =@ER_JOURNL and ER_MOIS   =@ER_MOIS and ER_FOLIO    =@ER_FOLIO and ER_LIGNE   = @ER_LIGNE and ER_EXERC=@ER_EXERC and ER_JOUR    =@ER_JOUR
                         end
                         end
                 end

 

                            "

            cmd = New SqlCommand(reqUPd, con)

            Dim adaptreqINS = New SqlDataAdapter(cmd)
            adaptreqINS.Fill(ds, " reqUPd")

            '    MsgBox("update_into_Fecriture")
        Catch ex As Exception
            MessageBox.Show(" reqUPd = " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        '-------------------------------  [select_5_columns]	------------------------------''
        Try

            Dim req As String = "
                            CREATE proc [dbo].[select_5_columns]	
                            (@a int,@b int,@c int,@d int,@e int,@Exec float )as
                            begin

                            drop table  if exists tablecreated5
                            create table tablecreated5(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50),
                            ER_LIBELLE varchar(50),
                            TYPE_DEBUT bigint,
                            TYPE_CREDI bigint
                            ); 
                            if @a=1 
                            insert into tablecreated5  exec [afflistClass] @a  ,@Exec
                            if @b=2
                            insert into tablecreated5  exec [afflistClass] @b ,@Exec
                            if @c=3
                            insert into tablecreated5  exec [afflistClass] @c ,@Exec
                            if @d=4
                            insert into tablecreated5  exec [afflistClass] @d ,@Exec
                            if @e=5
                            insert into tablecreated5  exec [afflistClass] @e ,@Exec
                            --select sum(TYPE_CREDI)  from tablecreated5 
                            select distinct ER_CPARTIE, ER_LIBELLE, TYPE_DEBUT,TYPE_CREDI from tablecreated5 group by ER_CPARTIE, ER_LIBELLE,TYPE_DEBUT,TYPE_CREDI order by TYPE_DEBUT,TYPE_CREDI
                            end
                            "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)
            '    MsgBox("select_5_columns")

        Catch ex As Exception
            MessageBox.Show("check your proce [select_5_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''----------------------------------------------------------------------------------------------------
        ''///////////////////////////////////////////////////////////////////////////////////////////////////
        ''----------------------------------------------------------------------------------------------------
        ''-------------------------------  [select_4_columns]	------------------------------''
        Try

            Dim req As String = "
                            CREATE proc [dbo].[select_4_columns]	
                            (@a int,@b int,@c int,@d int,@Exec float )as
                            begin

                            drop table  if exists tablecreated4
                            create table tablecreated4(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50),
                            TYPE_DEBUT varchar(50),
                            TYPE_CREDI varchar(50)
                            ); 
                            insert into tablecreated4 exec [afflistClass] @a,@Exec 
                            insert into tablecreated4  exec [afflistClass] @b,@Exec 
                            insert into tablecreated4  exec [afflistClass] @c,@Exec 
                            insert into tablecreated4  exec [afflistClass] @d,@Exec 
                            select distinct  * from   tablecreated4 
                            end
                            "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)

            '    MsgBox("select_4_columns")
        Catch ex As Exception
            MessageBox.Show("check your proce [select_4_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ''----------------------------------------------------------------------------------------------------
        ''///////////////////////////////////////////////////////////////////////////////////////////////////
        ''----------------------------------------------------------------------------------------------------
        ''-------------------------------  [select_3_columns]	------------------------------''
        Try

            Dim req As String = "
                            CREATE proc [dbo].[select_3_columns]	
                            (@a int,@b int,@c int,@Exec float)as
                            begin

                            drop table  if exists tablecreated3
                            create table tablecreated3(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50),
                            TYPE_DEBUT varchar(50),
                            TYPE_CREDI varchar(50)
                            ); 
                            insert into tablecreated3 exec [afflistClass] @a,@Exec 
                            insert into tablecreated3  exec [afflistClass] @b,@Exec 
                            insert into tablecreated3  exec [afflistClass] @c,@Exec 
                            select distinct  * from   tablecreated3 
                            end
                            "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)


            '    MsgBox("select_3_columns")
        Catch ex As Exception
            MessageBox.Show("check your proce [select_3_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        )
        End Try
        ''----------------------------------------------------------------------------------------------------
        ''///////////////////////////////////////////////////////////////////////////////////////////////////
        ''----------------------------------------------------------------------------------------------------
        ''-------------------------------  [select_2_columns]	------------------------------''
        Try

            Dim req As String = "

                            CREATE proc [dbo].[select_2_columns]	
                            (@a int,@b int,@Exec float)as
                            begin

                            drop table  if exists tablecreated
                            create table tablecreated(
                            id int identity primary key ,
                            ER_CPARTIE varchar(50),
                            TYPE_DEBUT varchar(50),
                            TYPE_CREDI varchar(50)
                            ); 
                            insert into tablecreated exec [afflistClass] @a,@Exec 
                            insert into tablecreated  exec [afflistClass] @b,@Exec 
                            select distinct  * from   tablecreated 
                            end
                            "
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)

            '    MsgBox("select_2_columns")

        Catch ex As Exception
            MessageBox.Show("check your proce [select_2_columns]  : " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
        )
        End Try
        ''----------------------------------------------------------------------------------------------------
        ''///////////////////////////////////////////////////////////////////////////////////////////////////
        ''----------------------------------------------------------------------------------------------------
        ''-------------------------------  [list_number]------------------------------''





        ''////////////////////////////////////////////////////////////////////////////////////////////////////






        '***************************************************************
        '*
        '***************************************************************


        ''////////////////////////////////////////////////////////////////////////////////////////////////////


        ''  insertion del l"annee en cours
        '*************************************************

        Dim connectionString As String = "Votre chaîne de connexion à SQL Server"
        'Dim code_soc As String = "004"
        Dim annee_en_cours As String = DateTime.Now.Year.ToString()
        Dim date_debut As Date = New Date(DateTime.Now.Year, 1, 1)
        Dim date_fin As Date = New Date(DateTime.Now.Year, 12, 31)

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = "INSERT INTO Periode_Soc (code_soc, exercice, date_debut, date_fin) " &
                                      "VALUES (@access.n2, @exercice, @date_debut, @date_fin)"

                Using sqlCommand As New SqlCommand(query, connection)
                    sqlCommand.Parameters.AddWithValue("@code_soc", Access.n2)
                    sqlCommand.Parameters.AddWithValue("@exercice", annee_en_cours)
                    sqlCommand.Parameters.AddWithValue("@date_debut", date_debut)
                    sqlCommand.Parameters.AddWithValue("@date_fin", date_fin)

                    sqlCommand.ExecuteNonQuery()

                    MessageBox.Show("Données insérées avec succès.")
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'insertion des données : " & ex.Message)
        End Try

    End Sub


    Sub add(S_code, S_Nom, S_formme, S_adr1, S_adr2, S_ville, S_codep, S_tel, S_fax, S_adm, S_igr, S_pat, S_rc, S_tva, S_excerc, S_obs)
        Try
            If String.IsNullOrWhiteSpace(S_code) Then
                MessageBox.Show("❌ Le champ Code Société est vide. Impossible de créer la base.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            connecter_soc()

            Dim dialog As DialogResult
            dialog = MessageBox.Show("Do you really want to add?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If dialog = DialogResult.Yes Then
                Try
                    Dim req As String = "exec insert_into_FSociete '" & S_code & "','" & S_Nom & "','" & S_formme & "','" & S_adr1 & "','" & S_adr2 & "','" & S_ville & "','" & S_codep & "','" & S_tel & "','" & S_fax & "','" & S_adm & "','" & S_igr & "','" & S_pat & "','" & S_rc & "','" & S_tva & "','" & S_excerc & "','" & S_obs & "'"
                    cmd = New SqlCommand(req, con)
                    Dim adapter As SqlDataAdapter
                    adapter = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adapter.Fill(dt)
                    aff()
                Catch ex As Exception
                    MessageBox.Show("Error inserting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            Dim dbName As String = "base_compta_" + S_code
            CreateDatabase(dbName, S_code)
        Catch ex As Exception
            MessageBox.Show("Error inserting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


                Try
                    Module1.connecter()
                    Dim req As String = "update_into_FSociete  '" & S_code & "','" & S_Nom & "','" & S_formme & "','" & S_adr1 & "','" & S_adr2 & "','" & S_ville & "','" & S_codep & "','" & S_tel & "','" & S_fax & "','" & S_adm & "','" & S_igr & "','" & S_pat & "','" & S_rc & "','" & S_tva & "','" & S_excerc & "','" & S_obs & "'"
                    cmd = New SqlCommand(req, con)
                    Dim adaptteeer1 As SqlDataAdapter
                    adaptteeer1 = New SqlDataAdapter(cmd)
                    Dim dt = New DataTable()
                    adaptteeer1.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("update" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
                End Try


                MessageBox.Show("تم التعديل بنجاح", "info", MessageBoxButtons.OK, MessageBoxIcon.Information
)
                GroupBox4.Visible = False
                GroupBox2.Visible = True
                TextBox1.Enabled = True
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox6.Enabled = False
                TextBox7.Enabled = False
                TextBox8.Enabled = False
                TextBox10.Enabled = False
                TextBox15.Enabled = False
                TextBox16.Enabled = False
                TextBox11.Enabled = False
                TextBox12.Enabled = False
                TextBox13.Enabled = False
                TextBox14.Enabled = False
                TextBox9.Enabled = False
                TextBox5.Enabled = False
                TextBox1.Clear()

                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox10.Clear()
                TextBox15.Clear()
                TextBox16.Clear()
                TextBox11.Clear()
                TextBox12.Clear()
                TextBox13.Clear()
                TextBox14.Clear()
                TextBox9.Clear()
                TextBox5.Clear()
            End If

        Catch ex As SqlException

            If (ex.Number = 3609) Then

                MessageBox.Show("هذا القسم موجود" + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning
)
            End If
        Catch ee As Exception

            MessageBox.Show("حدث خطأ أثناء أداء هذه العملية" + ee.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Warning
)

        End Try

    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form_Soc.Show()

    End Sub

    Private Sub creat_soc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.WindowState = FormWindowState.Maximized
        'Me.MaximizeBox = True

        'Module1.connecter()
        GroupBox4.Visible = False
        GroupBox2.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox10.Enabled = False
        TextBox15.Enabled = False
        TextBox16.Enabled = False
        TextBox11.Enabled = False
        TextBox12.Enabled = False
        TextBox13.Enabled = False
        TextBox14.Enabled = False
        TextBox9.Enabled = False
        TextBox5.Enabled = False
        aff()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If n1 = 1 Then

            '           add(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox16.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox15.Text, TextBox8.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox9.Text, TextBox10.Text)
            add(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox15.Text, TextBox16.Text)
        End If
        If n1 = 2 Then
            MessageBox.Show(oldValue + "," + newValue)
            'modif(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox16.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox15.Text, TextBox8.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox9.Text, TextBox10.Text)
            modif(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text, TextBox10.Text, TextBox11.Text, TextBox12.Text, TextBox13.Text, TextBox14.Text, TextBox15.Text, TextBox16.Text)
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
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox10.Enabled = True
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True
        TextBox9.Enabled = True
        TextBox5.Enabled = True
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        GroupBox4.Visible = False
        GroupBox2.Visible = True
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox10.Enabled = False
        TextBox15.Enabled = False
        TextBox16.Enabled = False
        TextBox11.Enabled = False
        TextBox12.Enabled = False
        TextBox13.Enabled = False
        TextBox14.Enabled = False
        TextBox9.Enabled = False
        TextBox5.Enabled = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        TextBox15.Clear()
        TextBox16.Clear()
        TextBox11.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox9.Clear()
        TextBox5.Clear()
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
        TextBox6.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox10.Enabled = True
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        TextBox11.Enabled = True
        TextBox12.Enabled = True
        TextBox13.Enabled = True
        TextBox14.Enabled = True
        TextBox9.Enabled = True
        TextBox5.Enabled = True

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

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox15_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox14_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox14.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox15.KeyPress
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class