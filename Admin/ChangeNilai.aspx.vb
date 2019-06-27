Imports System.Data.SqlClient

Partial Class Admin_ChangeNilai
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''mengecek session user
        If Session("admin-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        ''Mengambil Session
        Dim u As usr = Session("admin-sesi")
        welcm.InnerText = u.getusrid()

    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "UPDATE TB_Ket SET nilailulus='" & NilaiKelulusan.Text & "' WHERE id_ket='1' "
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            If jmlrec > 0 Then
                pesan.InnerHtml = "Update Nilai Berhasil!"
                Response.AddHeader("REFRESH", "2;URL=LihatSoal.aspx")
            Else
                pesan.InnerHtml = "Update Nilai Gagal!!!!!!!!!!!!!"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Error : " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("LihatSoal.aspx")
    End Sub
End Class
