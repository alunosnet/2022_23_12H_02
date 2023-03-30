<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="ProjetoM17AB.Admin.Consultas.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Consultas</h2>
    <asp:DropDownList ID="ddConsultas" CssClass="form-control" AutoPostBack="true" 
        OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" runat="server">
        <asp:ListItem Value="0">Resorts Ocupados</asp:ListItem>
        <asp:ListItem Value="1">Resorts com Piscina</asp:ListItem>
        <asp:ListItem Value="2">Utilizadores com Cargo Admin</asp:ListItem>
        <asp:ListItem Value="3">Ordenar resorts pelo o preco</asp:ListItem>
        <asp:ListItem Value="4">Top dos resorts mais alugados</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:GridView CssClass="table" ID="gvConsultas" runat="server"></asp:GridView>
</asp:Content>
