<%@ Page Title="" Language="VB" MasterPageFile="~/User/MPUser.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="User_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Selamat Datang User
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
     <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center mt-3" ><h3>Selamat Datang</h3></div>
        <div class="row justify-content-center mt-3" ><h5>Untuk memulai soal Klik Tombol di bawah ini.</h5></div>
        <div class="row justify-content-center mt-2" ><h5>Waktu Mengerjakan &nbsp<asp:Label ID="batasanwaktu" runat="server" CssClass="alert-info alert-danger"></asp:Label></h5></div>
        <div class="row justify-content-center mt-5" ><asp:Button runat="server" ID="menujusoal" cssclass="btn btn-primary" Text="Mulai Tes"/></div>
    </div>
</asp:Content>

