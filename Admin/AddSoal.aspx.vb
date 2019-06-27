Imports System.Data.SqlClient
Partial Class Admin_AddSoal
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "Insert INTO TB_Tes(id_soal,soal,a,b,c,d,kunci,status) "
            sql = sql & " values('" & nomor.Text & "','" & Pertanyaan.InnerText & "','" & jawabA.Text & "','" & jawabB.Text & "','" & jawabC.Text & "','" & jawabD.Text & "','" & kunciJWB.SelectedValue & "', 'Aktif')"

            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            If jmlrec > 0 Then
                pesan.InnerHtml = "Input Data Soal Berhasil"
                Response.Redirect("LihatSoal.aspx")
            Else
                pesan.InnerHtml = "Input Data Soal Gagal!!!!"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Ada Kendala di Database" & ex.Message
        Finally
            cn.Close()
        End Try
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
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "Select id_soal from TB_Tes WHERE id_soal in(select max(id_soal) from TB_Tes)"
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim data As SqlDataReader = cmd.ExecuteReader
            Dim tonum As Int32
            If data.HasRows Then
                data.Read()
                tonum = data.GetString(0)
                nomor.Text = tonum + "1"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("LihatSoal.aspx")
    End Sub
End Class
