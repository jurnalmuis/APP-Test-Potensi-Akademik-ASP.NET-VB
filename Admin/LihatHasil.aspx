<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="LihatHasil.aspx.vb" Inherits="Admin_LihatHasil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Lihat Nilai
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Lihat Hasil</h3></div>
    </div>
    <div class="py-4 table-bordered rounded">
        <div id="datasoal" runat="server" class="py-4 table-responsive-md ml-3 mr-3 ">

        </div>
    </div>
</asp:Content>

