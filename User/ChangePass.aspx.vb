Imports System.Data.SqlClient
Partial Class User_ChangePass
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''mengecek session user
        If Session("user-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        ''Mengambil Session
        Dim u As usr = Session("user-sesi")
        welcm.InnerText = u.getusrid()
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim u As usr = Session("user-sesi")
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            If PassWord.Text = Password2.Text Then
                Dim sql As String = "UPDATE TB_User SET password='" & PassWord.Text & "' WHERE id_User='" & u.getid() & "' "

                Dim cmd As SqlCommand = New SqlCommand(sql, cn)
                Dim jmlrec As Integer = cmd.ExecuteNonQuery
                If jmlrec > 0 Then
                    pesan.InnerHtml = "Update Password Berhasil!"
                    Response.AddHeader("REFRESH", "2;URL=home.aspx")
                Else
                    pesan.InnerHtml = "Update Paswword Gagal!!!!!!!!!!!!!"
                End If
            Else
                pesan.InnerHtml = "Password Tidak Cocok!!!!"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Error : " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("home.aspx")
    End Sub
End Class
