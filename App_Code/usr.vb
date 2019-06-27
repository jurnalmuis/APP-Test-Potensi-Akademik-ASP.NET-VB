Imports Microsoft.VisualBasic

Public Class usr
    Private user As String
    Private password As String
    Private id As String

    Public Sub setuserid(ByVal usr As String)
        user = usr
    End Sub
    Public Function getusrid() As String
        Return user
    End Function

    Public Sub setpass(ByVal pwd As String)
        password = pwd
    End Sub

    Public Function getpass() As String
        Return password
    End Function
    Public Sub setid(ByVal id_ As String)
        id = id_
    End Sub
    Public Function getid() As String
        Return id
    End Function
End Class
