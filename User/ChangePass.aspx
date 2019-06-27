﻿<%@ Page Title="" Language="VB" MasterPageFile="~/User/MPUser.master" AutoEventWireup="false" CodeFile="ChangePass.aspx.vb" Inherits="User_ChangePass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     Ganti Password
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
     <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Update Password</h3></div>
        <div class="row justify-content-center text-danger" runat="server" id="pesan"></div>
    </div>
    <div class="py-4 table-bordered rounded">
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Password Baru</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="PassWord" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Ulang Password Baru</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="Password2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right"></div>
                <div class="col-sm-4">
                    <asp:Button ID="btnSimpan" Text="Simpan" CssClass="btn btn-primary" runat="server"/>
                    <asp:Button ID="btnBatal" Text="Batal" CssClass="btn btn-danger" runat="server"/>
                </div>
            </div>
    </div>
</asp:Content>

