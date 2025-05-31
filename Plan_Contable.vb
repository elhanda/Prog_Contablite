Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Plan_Contable
    'Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim ds As DataSet = New DataSet()
    ReadOnly adapt As SqlDataAdapter
    ReadOnly adapt1 As SqlDataAdapter
    ReadOnly adapt2 As SqlDataAdapter
    ReadOnly adapt3 As SqlDataAdapter

    Shared Sub Connecter()
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
        Dim req As String = "select C_CODE as 'Compte',C_TYPE as 'Type',C_LIBELLE as 'Libelle'  from FPlanComptable order by C_CODE"
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

                Dim req As String = "delete  from FPlanComptable where C_CODE='" + id + "'"
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
update FPlanComptable set C_TYPE ='" & id & "',C_LIBELLE ='" & Name & "' where C_CODE ='" & ens & "'"
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
    Sub Ajouter(ens, id, Name)
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
                Aff()
            End If
        Catch ex As Exception
            MessageBox.Show("error de ajoutement " + ex.Message)
        Finally

        End Try
    End Sub
    Dim rs As New Form_Choix.Resizer

    Public Property Rs1 As Form_Choix.Resizer
        Get
            Return rs
        End Get
        Set(value As Form_Choix.Resizer)
            rs = value
        End Set
    End Property

    Public Property Ds1 As DataSet
        Get
            Return ds
        End Get
        Set(value As DataSet)
            ds = value
        End Set
    End Property

    Private Sub Plan_Contable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connecter()
        Aff()
        Rs1.FindAllControls(Me)

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
        Del(TextBox2.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Modif(TextBox4.Text, TextBox1.Text, TextBox2.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Ajouter(TextBox2.Text, TextBox4.Text, TextBox1.Text)
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

    Private Sub Plan_Contable_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

            Dim crystal As New Plan_Comptable_report_Final


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