<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApagarResort.aspx.cs" Inherits="ProjetoM17AB.Admin.Resorts.ApagarResort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Confirmar apagar Resort</h1>
    Nº Resort:<asp:Label  runat="server" ID="lbNResort" CssClass="form-control"></asp:Label>
    <br />Capacidade:<asp:Label runat="server" ID="lbCapacidade" CssClass="form-control"></asp:Label>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btRemover" Text="Remover" OnClick="btRemover_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="btVoltar" Text="Voltar" OnClick="btVoltar_Click" />
    <br /><asp:Label runat="server" ID="lbErro"></asp:Label>
</asp:Content>
