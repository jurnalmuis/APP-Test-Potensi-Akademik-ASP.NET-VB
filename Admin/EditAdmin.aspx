<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="EditAdmin.aspx.vb" Inherits="Admin_EditAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Edit Admin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Edit Admin</h3></div>
        <div class="row justify-content-center text-danger" runat="server" id="pesan"></div>
    </div>
    <div class="py-4 table-bordered rounded">
            <div class="row mb-2">
                <div class="col-sm-2 text-right">ID Admin</div>
                <div class="col-sm-3">
                    <asp:TextBox ID="nomor" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Nama Admin</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="NamaAdm" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
       
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Status Admin</div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="StatusAdmin" runat="server" CssClass="form-control">
                        <asp:ListItem>Pilih Status</asp:ListItem>
                        <asp:ListItem Value="Aktif">Aktif</asp:ListItem>
                        <asp:ListItem Value="Tidak Aktif">Tidak Aktif</asp:ListItem>
                    </asp:DropDownList>
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

