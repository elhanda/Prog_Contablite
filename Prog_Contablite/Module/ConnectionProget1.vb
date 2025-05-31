Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO


Module ConnectionProget1


    Public con As New SqlConnection

    Dim result As Boolean


    Public Function ConnecterHome()
        Try

            Dim chaineDeConnexion As String 'C:\Users\ayoub\Desktop\Data{0}\Data
            chaineDeConnexion = String.Format(" Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contablite\Prog_Contablite\bin\project\Data\Base_Compta_Soc.mdf;Integrated Security=True", New FileInfo(Application.ExecutablePath).DirectoryName)
            con = New SqlConnection(chaineDeConnexion)
            con.Open()
            result = True
        Catch ex As Exception
            con.Close()
            result = False
        Finally
            con.Close()
        End Try
        Return result
    End Function
    Public Function Connectersoc()
        Dim chaineDeConnexion As String ''C:\Users\ayoub\Desktop\Data001{0}\Data
        chaineDeConnexion = String.Format("Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=D:\Prog_Contablite\Prog_Contablite\bin\project\Data\Base_Compta_" & Access.n2 & ".mdf;Integrated Security=True;", New FileInfo(Application.ExecutablePath).DirectoryName)
        con = New SqlConnection(chaineDeConnexion)
        Try
            con.Open()
            result = True
        Catch ex As Exception
            con.Close()
            result = False
        Finally
            con.Close()

        End Try
        Return result
    End Function
End Module
