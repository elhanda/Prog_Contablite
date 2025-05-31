Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Plan_Contable
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    Dim adapt As SqlDataAdapter
    Dim adapt1 As SqlDataAdapter
    Dim adapt2 As SqlDataAdapter
    Dim adapt3 As SqlDataAdapter

    'Fill :   la propriete SelectCommand.Connection n'a pas ete initialisée
    Sub aff()
        Dim req As String = "select C_CODE,C_TYPE,C_LIBELLE  from FPlanComptable"
        cmd = New SqlCommand(req, con)
        Dim adapttr As SqlDataAdapter
        adapttr = New SqlDataAdapter(cmd)
        Dim dt = New DataTable()
        adapttr.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub
    Sub del(id)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then

                Dim req As String = "delete  from FPlanComptable where C_CODE='" + id + "'"
                cmd = New SqlCommand(req, con)
                Dim adapt1 As SqlDataAdapter
                adapt1 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt1.Fill(dt)
                'grdView.DataSource = dt
                aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de la suprimation " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Sub modif(id, Name, ens)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Dim req As String = " 
update FPlanComptable set C_TYPE ='" & id & "',C_LIBELLE ='" & Name & "' where C_CODE ='" & ens & "'"
                cmd = New SqlCommand(req, con)
                Dim adapt2 As SqlDataAdapter
                adapt2 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt2.Fill(dt)
                aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de la modification " + ex.Message, "info", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub
    Sub ajouter(ens, id, Name)
        Try
            Dim dialog As DialogResult
            dialog = MessageBox.Show("do you reelly whant to add ", "text", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If dialog = DialogResult.Yes Then
                Dim req As String = " 
insert into FPlanComptable values(N'" & ens & "',N'" & id & "',N'" & Name & "',NULL)"
                cmd = New SqlCommand(req, con)
                Dim adapt3 As SqlDataAdapter
                adapt3 = New SqlDataAdapter(cmd)
                Dim dt = New DataTable()
                adapt3.Fill(dt)
                aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de ajoutement " + ex.Message)
        Finally

        End Try
    End Sub
    Private Sub Plan_Contable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module1.connecter()
        aff()

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        TextBox2.Text = selecteRow.Cells(0).Value.ToString()
        TextBox4.Text = selecteRow.Cells(1).Value.ToString()
        TextBox1.Text = selecteRow.Cells(2).Value.ToString()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        del(TextBox2.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        modif(TextBox4.Text, TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ajouter(TextBox2.Text, TextBox4.Text, TextBox1.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub DataGridView1_CellDoubleClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim index As Integer
        index = e.RowIndex
        Dim selecteRow As DataGridViewRow
        selecteRow = DataGridView1.Rows(index)
        TextBox1.Text = selecteRow.Cells(2).Value.ToString()
        TextBox2.Text = selecteRow.Cells(0).Value.ToString()
        TextBox4.Text = selecteRow.Cells(1).Value.ToString()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub
End Class