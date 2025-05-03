Imports System.Data.Odbc

Public Class dbHelperClass
    Private con As OdbcConnection ' gumagawa ng connection sa data 
    Private cmd As OdbcCommand ' magpatupad ng sql code 
    Private reader As OdbcDataReader ' bumabasa ng resulta

    Public Sub New()
        con = New OdbcConnection("DSN=dbStudentinformations")
    End Sub

    Public Function OpenConnection() As Boolean
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
                MsgBox("Connection Success", vbInformation, "Database")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Database")
            Return False
        Finally
            GC.Collect()
        End Try
        Return False

    End Function

    Public Sub ClosedConnection()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetConnection() As OdbcConnection
        Return con

    End Function

    Public Function ExecuteQuery(ByVal query As String, Optional ByVal parameters As List(Of OdbcParameter) = Nothing) As DataTable
        Dim dt As New DataTable
        Try
            If OpenConnection() Then
                Using cmd As New OdbcCommand(query, con)
                    If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
                        cmd.Parameters.AddRange(parameters.ToArray)
                    End If

                    Using reader As OdbcDataReader = cmd.ExecuteReader
                        dt.Load(reader)
                    End Using

                End Using


            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Databases")
        End Try
        Return dt
    End Function



End Class
