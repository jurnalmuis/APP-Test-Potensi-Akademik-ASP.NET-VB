<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="DeleteSoal.aspx.vb" Inherits="Admin_Delete_Soal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Hapus Soal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Hapus Soal</h3></div>
        <div class="row justify-content-center text-danger" runat="server" id="pesan"></div>
    </div>
    <div class="py-4 table-bordered rounded ">
        <div class="ml-3">
            Apakah Anda Yakin menghapus record Soal berikut :
            <asp:Label ID="lbidsoal" runat="server" Text="x"></asp:Label>
            ?<br />
            <asp:Button ID="btYa" runat="server" CssClass="btn btn-primary" Text="Ya" />
            <asp:Button ID="btTidak" runat="server" CssClass="btn btn-danger" Text="Tidak" />
        </div>
    </div>
</asp:Content>

