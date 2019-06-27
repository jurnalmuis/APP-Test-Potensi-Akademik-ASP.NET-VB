<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="LihatSoal.aspx.vb" Inherits="Admin_LihatSoal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Lihat Soal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Lihat Soal</h3></div>
        <div class="row justify-content-left"><asp:Button ID="btnTambah" Text="Tambah Data" CssClass="btn btn-primary" runat="server"/><asp:Button ID="btnKetTime" Text="Edit Ketentuan" CssClass="btn btn-info ml-2" runat="server"/><asp:Button ID="btnKetNilai" Text="Edit Nilai Kelulusan" CssClass="btn btn-danger ml-2" runat="server"/></div>
    </div>
    <div class="py-4 table-bordered rounded">
        <div id="datasoal" runat="server" class="py-4 table-responsive-md ml-3 mr-3">

        </div>
    </div>
</asp:Content>

