
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class Form2

    Dim con As SqlConnection
    Dim con1 As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Return
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'con.Close()

        Dim req As String = "
        [CreateNewDatabase] " & TextBox1.Text & ""
        cmd = New SqlCommand(req, con1)
        Dim adapttr1 As SqlDataAdapter
        adapttr1 = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        'adapttr1.Fill(dt)
        Return
    End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    Private Sub btnCreateDatabase_Click(ByVal sender As System.Object,
ByVal e As System.EventArgs) Handles btnCreateDatabase.Click
        Dim str As String

        Dim myConn As SqlConnection = New SqlConnection("Server=(localdb)\MSSQLLocalDB;" &
"uid=sa;pwd=;database=master")

        str = "CREATE DATABASE MyDatabase ON PRIMARY " &
"(NAME = MyDatabase_Data, " &
" FILENAME = 'D:\MyFolder\MyDatabaseData.mdf', " &
" SIZE = 2MB, " &
" MAXSIZE = 10MB, " &
" FILEGROWTH = 10%)" &
" LOG ON " &
"(NAME = MyDatabase_Log, " &
" FILENAME = 'D:\MyFolder\MyDatabaseLog.ldf', " &
" SIZE = 1MB, " &
" MAXSIZE = 5MB, " &
" FILEGROWTH = 10%)"

        Dim myCommand As SqlCommand = New SqlCommand(str, myConn)

        Try
            myConn.Open()
            myCommand.ExecuteNonQuery()
            MessageBox.Show("Database is created successfully",
"MyProgram", MessageBoxButtons.OK,
MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            If (myConn.State = ConnectionState.Open) Then
                myConn.Close()
            End If
        End Try

    End Sub

    Private Sub btnCreateDatabase_Click_1(sender As Object, e As EventArgs) Handles btnCreateDatabase.Click

    End Sub
    'End Sub
End Class