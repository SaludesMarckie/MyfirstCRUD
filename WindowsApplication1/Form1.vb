Public Class Form1
    Private userDal As New Class3

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim isLoaded As Boolean = userDal.LoadUser(dgvList)
        If Not isLoaded Then
            MsgBox("No record Found", vbInformation, "Database")
        End If
    End Sub
End Class