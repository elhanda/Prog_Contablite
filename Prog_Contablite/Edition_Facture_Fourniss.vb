Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Edition_Facture_Fourniss
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter
    Dim value As Integer
    Private sum As Integer
    Private cred As Integer
    Private Id_Niv1 As New List(Of String)
    Private Id_Niveau As String
    Private Id_Niv12 As New List(Of String)
    Private Id_Niveau2 As String
    Private choix As Integer
    Private exer = exec_proc.n1
    Dim y As Integer
    Sub Connecter()
        'If () Then

        Try
            If Connectersoc() = True Then
                Try
                    con.Open()
                    'MsgBox("success")
                Catch ex As Exception
                    'MsgBox("faild")
                    con.Close()
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        'End If
    End Sub
    Dim rs As New Form_Choix.Resizer
    Sub aff_moix(a, b, datedeb, datefin)
        Try
            Dim req As String = ""
            cmd = New SqlCommand(req, con)
            Dim adapttr As SqlDataAdapter
            adapttr = New SqlDataAdapter(cmd)
            Dim dt = New DataTable()
            adapttr.Fill(dt)


        Catch ex As Exception
            MessageBox.Show("error de totaux month proc  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error
)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Fact_Fournisseur_Comptes.Show()
        Me.Hide()

    End Sub

    Private Sub Edition_Facture_Fourniss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            rs.FindAllControls(Me)
            Connecter()

            cmd = New SqlCommand("select * from FFactFrs  where FF_EXERC = " & exer & "   ", con)
            adapt1 = New SqlDataAdapter(cmd)
            adapt1.Fill(ds, " FC_NCOMPTE")
            ComboBox1.DisplayMember = " FC_NCOMPTE"
            ComboBox1.ValueMember = " FC_NCOMPTE"
            ComboBox1.DataSource = ds.Tables(" FC_NCOMPTE")


            cmd = New SqlCommand("select * from FFactFrs where FF_EXERC = " & exer & "   ", con)
            adapt = New SqlDataAdapter(cmd)
            adapt.Fill(ds, " FC_NCOMPTEs")
            ComboBox2.DisplayMember = " FC_NCOMPTE"
            ComboBox2.ValueMember = " FC_NCOMPTE"
            ComboBox2.DataSource = ds.Tables(" FC_NCOMPTEs")

        Catch ex As Exception
            MessageBox.Show("error de load " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
End Class