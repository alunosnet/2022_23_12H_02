<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="alugueres.aspx.cs" Inherits="ProjetoM17AB.Admin.Alugueres.Alugueres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Alugueres</h2>
    <asp:GridView CssClass="table" runat="server" ID="gv_alugueres"></asp:GridView>
    <h2>Registar novo Aluguer</h2>
    Resort: <asp:DropDownList CssClass="form-control" runat="server" ID="dd_resort"></asp:DropDownList>
    <br />
    Utilizador:<asp:DropDownList CssClass="form-control" runat="server" ID="dd_utilizador"></asp:DropDownList>
    <br />
    Data entrada:<asp:TextBox CssClass="form-control" runat="server" ID="tb_dataentrada" TextMode="Date"></asp:TextBox>
    <br />
    Data saida:<asp:TextBox CssClass="form-control" runat="server" ID="tb_datasaida" TextMode="Date"></asp:TextBox>
 
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="bt_registar" Text="Alugar" OnClick="bt_registar_Click" />
    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
