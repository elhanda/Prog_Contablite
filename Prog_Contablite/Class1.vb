
Class ListViewItemComparer
        Implements IComparer
        Private col As Integer
        Private sortOrder As SortOrder

        Public Sub New()
            col = 0
            sortOrder = Windows.Forms.SortOrder.Ascending
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
            sortOrder = Windows.Forms.SortOrder.Ascending
        End Sub

        Public Sub New(ByVal column As Integer, ByVal s As SortOrder)
            col = column
            sortOrder = s
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            If sortOrder = Windows.Forms.SortOrder.Ascending Then
                Return String.Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
            Else
                Return String.Compare(CType(y, ListViewItem).SubItems(col).Text, CType(x, ListViewItem).SubItems(col).Text)
            End If
        End Function

    End Class

