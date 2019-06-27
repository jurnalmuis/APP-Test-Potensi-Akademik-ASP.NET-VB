Imports System.Data.SqlClient
Partial Class User_LihatHasil
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'mengecek session user
        If Session("user-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        'Mengambil Session
        Dim u As usr = Session("user-sesi")
        Dim idesr As String
        idesr = u.getid()
        welcm.InnerText = u.getusrid()
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT * FROM TB_Nilai WHERE id_user='" & idesr & "'"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim data As SqlDataReader = cmd.ExecuteReader
            Dim tmp As String = "<table class='table table-sm'>"
            tmp = tmp & "<tr><th scope='col'>ID User</th>"
            tmp = tmp & "<th scope='col'>Nama User</th>"
            tmp = tmp & "<th scope='col'>Benar</th>"
            tmp = tmp & "<th scope='col'>Salah</th>"
            tmp = tmp & "<th scope='col'>Score</th>"
            tmp = tmp & "<th scope='col'>Keterangan</th></tr>"

            If data.HasRows Then
                While (data.Read)
                    tmp = tmp & "<tr>"
                    tmp = tmp & "<td scope='row'>" & data.GetString(1) & "</td>"
                    tmp = tmp & "<td class='text-primary'>" & u.getusrid & "</td>"
                    tmp = tmp & "<td>" & data.Item("benar") & "</td>"
                    tmp = tmp & "<td>" & data.Item("salah") & "</td>"
                    tmp = tmp & "<td>" & data.Item("score") & "</td>"
                    tmp = tmp & "<td>" & data.GetString(5) & "</td>"
                    tmp = tmp & "</tr>"
                End While
                tmp = tmp & "</table>"
                datasoal.InnerHtml = tmp
            End If
        Catch ex As Exception
            Response.Write("Ada Kesalahan Akses Database :" & ex.Message)
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub
End Class
