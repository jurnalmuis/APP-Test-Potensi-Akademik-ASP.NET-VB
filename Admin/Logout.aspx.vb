
Partial Class Admin_logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("admin-sesi") = Nothing
        Response.Redirect("default.aspx")
    End Sub
End Class
