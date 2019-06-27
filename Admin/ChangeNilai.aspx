﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="ChangeNilai.aspx.vb" Inherits="Admin_ChangeNilai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Ganti Nilai
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Update Nilai</h3></div>
        <div class="row justify-content-center text-danger" runat="server" id="pesan"></div>
    </div>
    <div class="py-4 table-bordered rounded">
        <div class="row mt-2">
            <div class="col-sm-3 text-right">Ganti Nilai Kelulusan</div>
            <div class="col-sm-3">
                <asp:TextBox ID="NilaiKelulusan" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row mt-2">
            <div class="col-sm-3 text-right"></div>
            <div class="col-sm-4">
                <asp:Button ID="btnSimpan" Text="Simpan" CssClass="btn btn-primary" runat="server"/>
                <asp:Button ID="btnBatal" Text="Batal" CssClass="btn btn-danger" runat="server"/>
            </div>
        </div>
    </div>
</asp:Content>

