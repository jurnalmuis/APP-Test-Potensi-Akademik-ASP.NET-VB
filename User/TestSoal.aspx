<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestSoal.aspx.vb" Inherits="User_TestSoal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Potensi Akademik</title>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center mt-3" ><h3>Soal</h3></div>
        <div class="row justify-content-center mt-1">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
                </asp:Timer>
                Sisa Waktu = <asp:Label ID="labeltime" runat="server" Text="" CssClass="alert-danger"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="py-4 table-bordered rounded">
        <table class="table-sm ml-2 table-bordered ">
            <tr>
                <td>
                    Pilih Soal
                </td>
                <td>
                    <asp:Button runat="server" ID="no1" Text="1" Width="35px"/>
                    <asp:Button runat="server" ID="no2" Text="2" Width="35px"/>
                    <asp:Button runat="server" ID="no3" Text="3" Width="35px"/>
                    <asp:Button runat="server" ID="no4" Text="4" Width="35px"/>
                    <asp:Button runat="server" ID="no5" Text="5" Width="35px"/>
                    <asp:Button runat="server" ID="no6" Text="6" Width="35px"/>
                    <asp:Button runat="server" ID="no7" Text="7" Width="35px"/>
                    <asp:Button runat="server" ID="no8" Text="8" Width="35px"/>
                    <asp:Button runat="server" ID="no9" Text="9" Width="35px"/>
                    <asp:Button runat="server" ID="no10" Text="10" Width="35px"/>
                    <%--<br />
                    <asp:Button runat="server" ID="no11" Text="11"  Width="35px" CssClass="mt-2"/>
                    <asp:Button runat="server" ID="no12" Text="12" Width="35px"/>
                    <asp:Button runat="server" ID="no13" Text="13" Width="35px"/>
                    <asp:Button runat="server" ID="no14" Text="14" Width="35px"/>
                    <asp:Button runat="server" ID="no15" Text="15" Width="35px"/>
                    <asp:Button runat="server" ID="no16" Text="16" Width="35px"/>
                    <asp:Button runat="server" ID="no17" Text="17" Width="35px"/>
                    <asp:Button runat="server" ID="no18" Text="18" Width="35px"/>
                    <asp:Button runat="server" ID="no19" Text="19" Width="35px"/>
                    <asp:Button runat="server" ID="no20" Text="20" Width="35px"/>--%>
                </td>
            </tr>
            <tr>
                <td>No <b><asp:label runat="server" ID="nomor"></asp:label></b></td>
                <td>
                     <asp:Label runat="server" ID="SoalText"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>A <asp:RadioButton ID="JawabA" runat="server" GroupName="idgol" Text=""/><asp:Label runat="server" ID="jwbnA"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>B <asp:RadioButton ID="JawabB" runat="server" GroupName="idgol" Text=""/><asp:Label runat="server" ID="jwbnB"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>C <asp:RadioButton ID="JawabC" runat="server" GroupName="idgol" Text=""/><asp:Label runat="server" ID="jwbnC"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>D <asp:RadioButton ID="JawabD" runat="server" GroupName="idgol" Text=""/><asp:Label runat="server" ID="jwbnD"></asp:Label></td>
            </tr>
            <tr>
                <%--<td><asp:Label Text="" runat="server" ID="jawabkalian"></asp:Label></td>--%>
                <%--<td><asp:Button ID="btnSimpanJawab" runat="server" Text="Simpan Jawaban" CssClass="btn btn-primary" /><asp:Button ID="Button1" runat="server" Text="Simpan Jawaban" CssClass="btn btn-primary" /></td>--%>
            </tr>
        </table>
        <div class="row justify-content-center mt-3">
            <asp:Label ID="statusupload" runat="server" CssClass="alert-danger"></asp:Label>
        </div>
        <div class="row justify-content-center mt-2">
            <asp:Button ID="btnSubJawaban" runat="server" Text="Submit Jawaban" CssClass="btn btn-primary"/>
        </div>
    
    </div>
    </form>
</body>
</html>
