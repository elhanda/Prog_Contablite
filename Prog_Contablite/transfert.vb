Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization

Public Class transfert
    Private Sub btnImporter_Click(sender As Object, e As EventArgs) Handles btnImporter.Click

    End Sub
    '    ' Ajoute ce bouton depuis la Toolbox

    '    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        btnImporter.Text = "Importer Ecriture"
    '        btnImporter.Width = 200
    '        btnImporter.Height = 50
    '        btnImporter.Top = 20
    '        btnImporter.Left = 20
    '        Me.Controls.Add(btnImporter)
    '    End Sub


    '    Private Sub btnImporter_Click(sender As Object, e As EventArgs) Handles btnImporter.Click
    '        Try
    '            Dim dbfPath As String = "C:\DBF\"   ' Chemin où se trouve ton ecriture.dbf
    '            Dim dbfFileName As String = "ecriture.dbf"

    '            Dim dbfConnection As New OleDb.OleDbConnection
    '            Dim dbfCommand As New OleDb.OleDbCommand
    '            Dim dbfReader As OleDb.OleDbDataReader

    '            dbfConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & dbfPath & ";Extended Properties=dBASE IV;"
    '            dbfConnection.Open()

    '            'SqlCommand.CommandText = "insert into FEcriture values(@0,@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,
    '            '@ER_JOUR,@ER_LIGNE,@ER_CPARTIE,@F10,@ER_LIBELLE,@mont,@b,@ER_NPIECE)"



    '            dbfCommand = New OleDb.OleDbCommand("SELECT * FROM " & dbfFileName, dbfConnection)
    '            dbfReader = dbfCommand.ExecuteReader()

    '            Dim compteur As Integer = 0

    '            While dbfReader.Read()
    '                ' Lecture des colonnes, adapte ici selon tes vrais champs
    '                Dim ER_EXERC As String = dbfReader("ER_EXERC").ToString()
    '                Dim ER_JOURNL As String = dbfReader("ER_JOURNL").ToString()

    '                Dim montant As Double = 0
    '                Double.TryParse(dbfReader("Montant").ToString(), montant)

    '                Dim datePiece As DateTime
    '                DateTime.TryParse(dbfReader("DatePiece").ToString(), datePiece)

    '                ' Insertion dans ta table fecriture
    '                InsertIntoFecriture(compte, montant, datePiece)

    '                compteur += 1
    '            End While

    '            dbfReader.Close()
    '            dbfConnection.Close()

    '            MessageBox.Show("Import terminé avec succès ✅" & vbCrLf & "Total lignes insérées : " & compteur, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '        Catch ex As Exception
    '            MessageBox.Show("Erreur lors de l'import: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '    End Sub
    '    Private Sub InsertIntoFecriture(compte As String, montant As Double, datePiece As DateTime)
    '        Dim sqlCommand As New SqlClient.SqlCommand
    '        sqlCommand.Connection = con ' ta connexion SQL Server existante (attention, elle doit être ouverte)
    '        'sqlCommand.CommandText = "INSERT INTO fecriture (Compte, Montant, DatePiece) VALUES (@Compte, @Montant, @DatePiece)"

    '        sqlCommand.CommandText = "insert into FEcriture values(@0,@ER_EXERC,@ER_JOURNL,@ER_AN,@ER_MOIS,@ER_FOLIO,
    '                                    @ER_JOUR,@ER_LIGNE,@ER_CPARTIE,@F10,@ER_LIBELLE,@mont,@b,@ER_NPIECE)"



    '        sqlCommand.Parameters.AddWithValue("@ER_EXERC", ER_EXERC)
    '        sqlCommand.Parameters.AddWithValue("@ER_JOURNL", ER_JOURNL)
    '        sqlCommand.Parameters.AddWithValue("@ER_AN", ER_AN)
    '        sqlCommand.Parameters.AddWithValue("@ER_MOIS", ER_MOIS)
    '        sqlCommand.Parameters.AddWithValue("@ER_FOLIO", ER_FOLIO)
    '        sqlCommand.Parameters.AddWithValue("@ER_JOUR", ER_JOUR)

    '        sqlCommand.Parameters.AddWithValue("@ER_LIGNE", ER_LIGNE)
    '        sqlCommand.Parameters.AddWithValue("@ER_CPARTIE", ER_CPARTIE)
    '        sqlCommand.Parameters.AddWithValue("@ER_LIBELLE", ER_LIBELLE)
    '        sqlCommand.Parameters.AddWithValue("@mont", mont)
    '        sqlCommand.Parameters.AddWithValue("@ER_FOLIO", ER_FOLIO)
    '        sqlCommand.Parameters.AddWithValue("@ER_NPIECE", ER_NPIECE)
    '        sqlCommand.ExecuteNonQuery()
    '    End Sub

    '    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '        Me.Close()
    '        Form1.Show()
    '    End Sub
End Class