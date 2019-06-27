Imports System.Data.SqlClient
Partial Class Admin_EditSoal
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
            If Request.Params("id_Soal") <> "" Then
                nomor.Text = Request.Params("id_soal")
            Else
                Response.Redirect("LihatSoal.aspx")
            End If
            cn = New SqlConnection(cnsql)
            Try
                cn.Open()
                Dim sql As String = "SELECT id_soal,soal,a,b,c,d,kunci,status FROM TB_Tes WHERE id_soal='" & nomor.Text & "' "
                Dim cmd As SqlCommand = New SqlCommand(sql, cn)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    Pertanyaan.InnerHtml = reader.GetString(1)
                    jawabA.Text = reader.GetString(2)
                    jawabB.Text = reader.GetString(3)
                    jawabC.Text = reader.GetString(4)
                    jawabD.Text = reader.GetString(5)
                    kunciJWB.SelectedValue = reader.GetString(6)
                    stSoal.SelectedValue = reader.GetString(7)
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

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "UPDATE TB_Tes SET soal='" & Pertanyaan.InnerHtml & "', a='" & jawabA.Text & "', b='" & jawabB.Text & "', c='" & jawabC.Text & "', d='" & jawabD.Text & "', status='" & stSoal.SelectedValue & "', kunci='" & kunciJWB.SelectedValue & "' WHERE id_soal='" & nomor.Text & "' "

            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            If jmlrec > 0 Then
                pesan.InnerHtml = "Update Data Soal Berhasil"
                Response.Redirect("LihatSoal.aspx")
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

    Protected Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Response.Redirect("LihatSoal.aspx")
    End Sub
End Class
