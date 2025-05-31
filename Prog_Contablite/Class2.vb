Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Connexion


    Dim con As SqlConnection

    Public chaineDeConnexion As String





    Sub Connecter()
        Dim chaineDeConnexion As String
        'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_Soc.mdf;Integrated Security=True"
        'chaineDeConnexion = "Data Source=desktop-c826ha4 \ localdb#cd9038a6.D: \PROG_CONTABILITE\PROG_CONTABLITE\DATA\BASE_COMPTA_001.MDF;Integrated Security=True"
        chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\DATA\BASE_COMPTA_" + Access.n2 + ".MDF" + ";Integrated Security=True"
        con = New SqlConnection(chaineDeConnexion)
        Try
            con.Open()
        Catch ex As Exception
            Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Sub Connecter_soc()
        Dim chaineDeConnexion As String
        'chaineDeConnexion = "Data Source=DESKTOP-C826HA4\SQLEXPRESS;Initial Catalog=D:\PROG_CONTABLITE\PROG_CONTABLITE\DATA\Base_Compta_Soc.mdf;Integrated Security=True"
        'chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_001.mdf;Integrated Security=True;Connect Timeout=30"
        chaineDeConnexion = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contabilite\Prog_Contablite\Data\Base_Compta_Soc.mdf;Integrated Security=True;Connect Timeout=30"

        con = New SqlConnection(chaineDeConnexion)
        Try
            con.Open()
        Catch ex As Exception
            Console.WriteLine("Erreur de connexion.", "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Class
