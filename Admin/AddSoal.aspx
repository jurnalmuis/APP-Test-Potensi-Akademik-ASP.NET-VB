<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/MPAdmin.master" AutoEventWireup="false" CodeFile="AddSoal.aspx.vb" Inherits="Admin_AddSoal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    Tambahkan Soal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="welcomepart" Runat="Server">
    <div id="welcm" runat="server"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center" style="margin-top:20px;"><h3>Tambah Soal</h3></div>
        <div class="row justify-content-center text-danger" runat="server" id="pesan"></div>
    </div>
    <div class="py-4 table-bordered rounded">
            <div class="row mb-2">
                <div class="col-sm-2 text-right">Nomor Soal</div>
                <div class="col-sm-1">
                    <asp:TextBox ID="nomor" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-2 text-right">Pertanyaan</div>
                <div class="col-sm-10">
                    <textarea id="Pertanyaan" style="width: 500px; height: 100px;" cols="20" rows="2" runat="server"></textarea>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right" >Jawaban A</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="jawabA" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Jawaban B</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="jawabB" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Jawaban C</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="jawabC" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Jawaban D</div>
                <div class="col-sm-4">
                    <asp:TextBox ID="jawabD" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-sm-2 text-right">Kunci Jawaban</div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="kunciJWB" runat="server" CssClass="form-control">
                        <asp:ListItem>Pilih Kunci</asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                        <asp:ListItem Value="C">C</asp:ListItem>
                        <asp:ListItem Value="D">D</asp:ListItem>
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

