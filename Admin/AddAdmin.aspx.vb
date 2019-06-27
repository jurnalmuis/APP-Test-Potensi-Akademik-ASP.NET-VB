Imports System.Data.SqlClient
Partial Class Admin_AddAdmin
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "Insert INTO TB_Admin(id_admin,password,nama,status) "
            sql = sql & " values('" & nomor.Text & "','" & PassWord.Text & "','" & NamaAdm.Text & "','" & StatusAdmin.SelectedValue & "') "

            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            If jmlrec > 0 Then
                pesan.InnerHtml = "Input Data Admin Berhasil"
                Response.AddHeader("REFRESH", "2;URL=Home.aspx")
            Else
                pesan.InnerHtml = "Input Data Admin Gagal!!!!"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Ada Kendala di Database" & ex.Message
        Finally
            cn.Close()
        End Try
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("home.aspx")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
       'mengecek session user
        If Session("admin-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        'Mengambil Session
        Dim u As usr = Session("admin-sesi")
        welcm.InnerText = u.getusrid()
    End Sub
End Class
