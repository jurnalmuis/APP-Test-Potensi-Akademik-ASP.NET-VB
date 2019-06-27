<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="User_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login User</title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row justify-content-center" style="margin-top:130px;">
                <div class="col-md-4">
                    <div class="card" >
                        <h3 class="card-header">Login User</h3>
                        <div class="card-body">
                            
                            <div class="form-group">
                                <label for="tbUsrId">Username</label>
                                <asp:TextBox ID="usertxt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="tbPass">Password</label>
                                <asp:TextBox ID="passtxt" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:Button id="BTlogin" runat="server" CssClass="btn btn-primary" Text=" Login "/>
                        </div>
                        <div id="pesanerror" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
