Imports System.Data.SqlClient
Partial Class User_Default
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub BTlogin_Click(sender As Object, e As EventArgs) Handles BTlogin.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "SELECT * FROM TB_User WHERE status='Aktif' AND id_user='" & usertxt.Text & "' AND password='" & passtxt.Text & "' "
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim data As SqlDataReader = cmd.ExecuteReader
            If data.HasRows Then
                data.Read()
                Dim u As usr = New usr()
                u.setid(data.GetString(0))
                u.setuserid(data.GetString(2))
                u.setpass(data.GetString(1))
                Session("user-sesi") = u
                pesanerror.InnerHtml = "Welcome"
                Response.Redirect("home.aspx")
            Else
                pesanerror.InnerHtml = "<div class='alert-danger align-content-center card-footer' >Username atau Password Salah!!</div>"
            End If
        Catch ex As Exception
            Response.Write("Ada Kesalahan Akses Database :" & ex.Message)
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("CountdownTimer") = Nothing
    End Sub
End Class
