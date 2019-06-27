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
    End Sub
End Class
