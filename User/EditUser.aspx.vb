Imports System.Data.SqlClient
Partial Class User_EditUser
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
        welcm.InnerText = u.getusrid()

        If Not IsPostBack Then
            If u.getid <> "" Then
                nomor.Text = u.getid
            Else
                Response.Redirect("home.aspx")
            End If
            cn = New SqlConnection(cnsql)
            Try
                cn.Open()
                Dim sql As String = "SELECT id_User,nama FROM TB_User WHERE id_User='" & u.getid & "' "
                Dim cmd As SqlCommand = New SqlCommand(sql, cn)
                Dim reader As SqlDataReader = cmd.ExecuteReader
                If reader.HasRows Then
                    reader.Read()
                    NamaUser.Text = reader.GetString(1)
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

    Protected Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Dim u As usr = Session("user-sesi")
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "UPDATE TB_User SET nama='" & NamaUser.Text & "' WHERE id_user='" & u.getid() & "' "

            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            If jmlrec > 0 Then
                pesan.InnerHtml = "Update Data Berhasil!"
                Dim unew As usr = New usr()
                unew.setid(u.getid)
                unew.setpass(u.getpass)
                unew.setuserid(NamaUser.Text)
                Session("user-sesi") = unew
                Response.AddHeader("REFRESH", "2;URL=home.aspx")
            Else
                pesan.InnerHtml = "Update Data Gagal!!!!!!!!!!!!!"
            End If
        Catch ex As Exception
            pesan.InnerHtml = "Error : " & ex.Message
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub
End Class
