Imports System.Data.SqlClient
Imports ClosedXML.Excel
Imports System.IO

Module ExportProcedureToExcel

    Sub Main()
        ' Connexion à la base
        Dim connectionString As String = "Server=localhost;Database=base_compta_001;Trusted_Connection=True;"
        Dim query As String = "EXEC list_journaux 2005, '560', 1,12"

        ' Récupération des données
        Dim dt As New DataTable()

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, con)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using

        ' Export vers Excel
        Dim filePath As String = "C:\Exports\Journaux_Export.xlsx"
        Using wb As New XLWorkbook()
            Dim ws = wb.Worksheets.Add(dt, "Liste Journaux")
            wb.SaveAs(filePath)
        End Using

        Console.WriteLine("✅ Export terminé : " & filePath)
        Console.ReadKey()
    End Sub

End Module
