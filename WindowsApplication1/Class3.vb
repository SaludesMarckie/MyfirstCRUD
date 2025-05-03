Public Class Class3
    Dim userDal As New Class2

    Public Function LoadUser(ByVal dataGridView As DataGridView) As Boolean
        Dim dt As DataTable = userDal.getCourses()
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            dataGridView.DataSource = dt
            SetColumnHeader(dataGridView, {"ID", "NAME", "CODE"})

            Return True
        Else
            Return False
        End If

    End Function


    Private Sub SetColumnHeader(ByVal dataGridView As DataGridView, ByVal headers As String())
        For i As Integer = 0 To Math.Min(headers.Length - 1, dataGridView.Columns.Count - 1)
            dataGridView.Columns(i).HeaderText = headers(i)
        Next
    End Sub

End Class
