Imports System.Data.SqlClient
Partial Class Admin_EditUser
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

        If Not IsPostBack Then
            If Request.Params("id_User") <> "" Then
                nomor.Text = Request.Params("id_User")
            Else
                Response.Redirect("LihatUser.aspx")
            End If
            cn = New SqlConnection(cnsql)
            Try
                cn.Open()
                Dim sql As String = "SELECT id_User,nama,status FROM TB_User WHERE id_User='" & nomor.Text & "' "
                Dim cmd As SqlCommand = New SqlCommand(sql, cn)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    NamaUsr.Text = reader.GetString(1)
                    StatusAdmin.SelectedValue = reader.GetString(2)
                    nomor.ReadOnly = True
                Else
                    pesan.InnerHtml = "Tidak Di Temukan record yang dicari!!!"
                End If
                reader.Close()
            Catch ex As Exception
                pesan.InnerHtml = "Error : " & ex.Message
            Finally
                cn.Close()
                cn = Nothing
            End Try
        End If
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("LihatUser.aspx")
    End Sub

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "UPDATE TB_User SET nama='" & NamaUsr.Text & "', status='" & StatusAdmin.SelectedValue & "' WHERE id_User='" & nomor.Text & "' "
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            If jmlrec > 0 Then
                pesan.InnerHtml = "Update Data Soal Berhasil"
                Response.Redirect("LihatUser.aspx")
            Else
                pesan.InnerHtml = "Update Data Soal Gagal!!!!!!!!!!!!!"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Error : " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub
End Class
