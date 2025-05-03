Public Class Class2
    Dim db As New dbHelperClass

    Public Function GetCourses() As DataTable
        Dim query As String = "select * from tblCourses"
        Return db.ExecuteQuery(query)
    End Function

End Class