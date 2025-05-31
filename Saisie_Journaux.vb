Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
#Disable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Imports Io
#Enable Warning BC40056 ' L'espace de noms ou le type spécifié dans les Imports 'Io' ne contient aucun membre public ou est introuvable. Vérifiez que l'espace de noms ou le type est défini et qu'il contient au moins un membre public. Vérifiez que le nom de l'élément importé n'utilise pas d'autres alias.
Public Class Saisie_Journaux
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    ReadOnly adapt As SqlDataAdapter
    ReadOnly adapt1 As SqlDataAdapter
    ReadOnly adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter
    Sub Connecter()
        If Connectersoc() Then
            Try
                'MsgBox("success")
            Catch ex As Exception
                MsgBox("faild")
                con.Close()
            End Try
        End If
    End Sub
    Sub Aff()
        Dim req As String = "select J_CODE as 'Code',J_LIBELLE as 'Libelle' ,J_COMPTE as 'COMPTE'  from FJournal order by J_CODE"
        cmd = New SqlCommand(req, con)
        Dim adapttr As SqlDataAdapter
        adapttr = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        adapttr.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub
    Sub Del(id)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then

                Dim req As String = "delete from FJournal where J_CODE=N'" + id + "'"
                cmd = New SqlCommand(req, con)
                Dim adapt1 As SqlDataAdapter
                adapt1 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt1.Fill(dt)
                'grdView.DataSource = dt
                Aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de la suprimation " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Sub Modif(id, Name, ens)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Dim req As String = " 
update FJournal set J_COMPTE=N'" & id & "',J_LIBELLE=N'" & Name & "' where J_CODE =N'" & ens & "'"
                cmd = New SqlCommand(req, con)
                Dim adapt2 As SqlDataAdapter
                adapt2 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt2.Fill(dt)
                Aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de la modification " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Sub Ajj(ens, id, Name)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Dim req As String = " 

                    insert into FJournal values(N'" & ens & "',N'" & id & "',N'" & Name & "')"
                cmd = New SqlCommand(req, con)
                Dim adapt3 As SqlDataAdapter
                adapt3 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt3.Fill(dt)
                Aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de ajoutement  " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Dim rs As New Form_Choix.Resizer

    Public Property Ds1 As DataSet
        Get
            Return ds
        End Get
        Set(value As DataSet)
            ds = value
        End Set
    End Property

    Public Property Rs1 As Form_Choix.Resizer
        Get
            Return rs
        End Get
        Set(value As Form_Choix.Resizer)
            rs = value
        End Set
    End Property

    Private Sub Saisie_Journaux_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()
        Aff()
        Rs1.FindAllControls(Me)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Del(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Modif(TextBox3.Text, TextBox2.Text, TextBox1.Text)

    End Sub

    Private Sub Ajouter_Click(sender As Object, e As EventArgs) Handles Ajouter.Click
        Ajj(TextBox1.Text, TextBox2.Text, TextBox3.Text)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        TextBox1.Text = selecteRow.Cells(0).Value.ToString()
        TextBox2.Text = selecteRow.Cells(1).Value.ToString()
        TextBox3.Text = selecteRow.Cells(2).Value.ToString()
    End Sub

    Private Sub Saisie_Journaux_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Rs1.ResizeAllControls(Me)

    End Sub
    Sub Apersu()
        Try


            Dim dtable = New DataTable()
            With dtable
                .Columns.Add(" C_Code")
                .Columns.Add("C_Type")
                .Columns.Add("C_Libelle")

            End With
            For i As Integer = 0 To DataGridView1.Rows.Count
                dtable = DataGridView1.DataSource
            Next


            'MsgBox(dtable.Rows.Count)

            If dtable.Rows.Count = 0 Then
                MessageBox.Show("No data Found", "CrystalReportWithOracle")
                Return
            End If

            Dim crystal As New Journal_Comptable_Report_Final



            crystal.SetDataSource(dtable)



            GrandLivreReportViewer.CrystalReportViewer1.ReportSource = crystal
            GrandLivreReportViewer.Refresh()
            GrandLivreReportViewer.Show()
        Catch ex As Exception
            MessageBox.Show("Error while printing to Crystal report." & ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Apersu()
    End Sub


End Class