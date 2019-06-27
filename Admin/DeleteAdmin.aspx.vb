﻿Imports System.Data.SqlClient
Partial Class Admin_DeleteAdmin
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
        lbidadmin.Text = Request.Params("id_Admin")
    End Sub

    Protected Sub btTidak_Click(sender As Object, e As EventArgs) Handles btTidak.Click
        Response.Redirect("home.aspx")
    End Sub

    Protected Sub btYa_Click(sender As Object, e As EventArgs) Handles btYa.Click
        'membuat koneksi obyek
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sql As String = "Update TB_Admin SET status='Tidak Aktif' WHERE id_admin='" & lbidadmin.Text & "'"

            'buat obyek command untuk mengeksekusi perintah sql
            Dim cmd As SqlCommand = New SqlCommand(sql, cn)
            Dim jmlrec As Integer = cmd.ExecuteNonQuery
            Response.Redirect("home.aspx")
        Catch ex As Exception
            Response.Write("Ada Kesalahan Koneksi ke Database!")
        Finally
            cn.Close()
        End Try
    End Sub
End Class
