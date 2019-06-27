<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="ChangeTimeDurasi.aspx.vb" Inherits="Admin_ChangeTimeDurasi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Ganti Durasi Waktu Mengerjakan
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Update Waktu Mengerjakan</h3></div>
        <div class="row justify-content-center text-danger" runat="server" id="pesan"></div>
    </div>
    <div class="py-4 table-bordered rounded">
        <div class="row mt-2">
            <div class="col-sm-3 text-right">Ganti Waktu Mengerjakan</div>
            <div class="col-sm-3">
                <asp:TextBox ID="timeket" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-sm-3 text-right"></div>
            <div class="col-sm-4">
                <asp:Button ID="btnSimpan" Text="Simpan" CssClass="btn btn-primary" runat="server"/>
                <asp:Button ID="btnBatal" Text="Batal" CssClass="btn btn-danger" runat="server"/>
            </div>
        </div>
        Format Update Waktu =<asp:Label ID="idpesan" runat="server" CssClass="text-danger">&nbsp 00:00:00</asp:Label>
    </div>
</asp:Content>

