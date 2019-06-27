Imports System.Data.SqlClient
Partial Class Admin_LihatUser
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
       'mengecek session user
        If Session("admin-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        'Mengambil Session
        Dim u As usr = Session("admin-sesi")
        welcm.InnerText = u.getusrid()
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT id_User,nama,status FROM TB_User"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim data As SqlDataReader = cmd.ExecuteReader
            Dim tmp As String = "<table class='table table-sm'>"
            tmp = tmp & "<tr><th scope='col'>ID User</th>"
            tmp = tmp & "<th scope='col'>Nama User</th>"
            tmp = tmp & "<th scope='col'>Status</th>"
            tmp = tmp & "<th scope='col'>Aksi</th></tr>"

            If data.HasRows Then
                While (data.Read)
                    tmp = tmp & "<tr>"
                    tmp = tmp & "<td scope='row'>" & data.GetString(0) & "</td>"
                    tmp = tmp & "<td>" & data.GetString(1) & "</td>"
                    tmp = tmp & "<td class='text-primary'>" & data.GetString(2) & "</td>"
                    tmp = tmp & "<td><a href=DeleteUser.aspx?id_User=" & data.GetString(0) & " class='btn btn-danger btn-sm'>hapus</a>  "
                    tmp = tmp & "<a href=EditUser.aspx?id_User=" & data.GetString(0) & " class='btn btn-warning btn-sm'>Edit</a></td>"
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

    Protected Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Response.Redirect("AddUser.aspx")
    End Sub
End Class
