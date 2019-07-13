Imports System.Data.SqlClient
Partial Class User_Home
    Inherits System.Web.UI.Page
    Dim cn As SqlConnection = Nothing
    Dim cnsql As String = ConfigurationManager.ConnectionStrings("consql").ConnectionString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("CountdownTimer") = Nothing
        'mengecek session user
        If Session("user-sesi") Is Nothing Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        'Mengambil Session
        Dim u As usr = Session("user-sesi")
        welcm.InnerText = u.getusrid()
        cn = New SqlConnection(cnsql)
        Try
            cn.Open()
            Dim sqltimer As String = "Select timedurasi From TB_Ket"
            Dim cmdtimer As SqlCommand = New SqlCommand(sqltimer, cn)
            Dim timernya As String = cmdtimer.ExecuteScalar
            batasanwaktu.Text = timernya
            Dim sqlcek As String = "Select COUNT(*) From TB_Nilai WHERE id_User='" & u.getid & "'"
            Dim cmdcek As SqlCommand = New SqlCommand(sqlcek, cn)
            Dim benar As Int16
            benar = cmdcek.ExecuteScalar
            If benar = 1 Then
                Response.Redirect("LihatHasil.aspx")
            End If
        Catch ex As Exception
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Sub

    Protected Sub menujusoal_Click(sender As Object, e As EventArgs) Handles menujusoal.Click
        Response.Redirect("TestSoal.aspx?id_soal=1")
    End Sub
End Class
