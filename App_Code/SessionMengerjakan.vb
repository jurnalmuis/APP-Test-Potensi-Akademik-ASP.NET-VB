Imports Microsoft.VisualBasic

Public Class SessionMengerjakan
    Private waktu As String
    Public Sub setwaktu(ByVal nSoal As String)
        waktu = nSoal
    End Sub
    Public Function getwaktu() As String
        Return waktu
    End Function
End Class
