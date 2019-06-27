<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="LihatAdmin.aspx.vb" Inherits="Admin_LihatAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Change Password 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Lihat Admin</h3></div>
        <div class="row justify-content-left text-danger mb-2"><asp:Button ID="btnTambah" Text="Tambah Data" CssClass="btn btn-primary" runat="server"/></div>
    </div>
    <div class="py-4 table-bordered rounded">
        <div id="datasoal" runat="server" class="py-4 table-responsive-md ml-3 mr-3">

        </div>
    </div>
</asp:Content>

