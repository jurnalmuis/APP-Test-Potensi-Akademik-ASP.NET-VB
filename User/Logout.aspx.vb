
Partial Class User_Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("user-sesi") = Nothing
        Response.Redirect("default.aspx")
    End Sub
End Class
