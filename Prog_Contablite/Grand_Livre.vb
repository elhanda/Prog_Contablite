Imports System.Drawing.Printing
Imports System.Drawing.Graphics
Public Class Grand_Livre
    Dim i_counter As Integer
    Dim i_start As Integer
    Private Sub Grand_Livre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim index As ListViewItem

        Dim debut As Long
        Dim credit As Long
        ListView1.View = View.Details
        ListView1.GridLines = True
        With ListView1

            For Each index In .Items
                debut = debut + CLng(index.SubItems(7).Text)
                credit = credit + CLng(index.SubItems(8).Text)
            Next
        End With
        ' MessageBox.Show("count : debut : " + CStr(debut) + "  credit  : " + CStr(credit))
        TextBox8.Text = CStr(credit)
        TextBox7.Text = CStr(debut)

        TextBox9.Text = TextBox8.Text - TextBox7.Text
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'PrintDialog1.Document = PrintDocument1
        'PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
        'If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
        '    Dim new_paper As New papersize("", 800, 800)
        '    new_paper.paperName = paperkind.custom
        '    Dim new_margin As New margins
        '    new_margin.Left = 0
        '    new_margin.top = 50
        '    With PrintDocument1
        '        .DefaultPageSettings.PaperSize = new_paper
        '        .DefaultPageSettings.Margins = new_margin
        '        .PrinterSettings.DefaultPageSettings.Landscape = False
        '        .Print()
        '    End With
        'End If
    End Sub



    'Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
    '    'Dim hh As Integer
    '    'Dim linenumber As Integer
    '    'hh = 50
    '    'e.Graphics.DrawString(Label1.Text, New Drawing.Font("time new roman", 10), Brushes.Black, 150, hh)
    '    ''Me.i_counter
    '    'hh += 30
    '    'Dim nn As Integer = hh
    '    'e.Graphics.DrawLine(Pens.Black, 150, nn, 300, nn)
    '    'e.Graphics.Drawsetting("id", New Drawing.Font("Arial", 10), Brushes.Black, 150, hh)
    '    'e.Graphics.DrawString("nama", New Drawing.Font("Arial", 10), Brushes.Black, 150, hh)

    '    'For i_start = 0 To ListView1.Items.Count - 1
    '    '    e.Graphics.DrawString(ListView1.Items(i_counter).Text, New Drawing.Font("Time New roman"), 10),brushes.black,150,hh)
    '    'e.Graphics.DrawString(liveview1.items(i_counter).subitems(1).text, New Drawing.Font("time new roman"), 10),brushes.black,150,hh)

    '    '    linenumber += 1
    '    '    If linenumber = lineperpage Then
    '    '        linenumber = 0
    '    '        i_start = i_counter + 1
    '    '        hh = 50
    '    '        e.HasMorePages = True
    '    '        Exit For
    '    '    End If
    '    'Next

    'End Sub
End Class