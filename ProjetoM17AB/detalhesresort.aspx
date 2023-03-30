<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="detalhesresort.aspx.cs" Inherits="ProjetoM17AB.detalhesresort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Numero de Resort: 
    <asp:Label ID="lbNResort" runat="server" Text="Numero do Resort: "></asp:Label><br />
    Capacidade: 
    <asp:Label ID="lbCapacidade" runat="server" Text="Capacidade: "></asp:Label><br />
    Piscina: 
    <asp:Label ID="lbPiscina" runat="server" Text="Piscina: "></asp:Label><br />
    Preço:
    <asp:Label ID="lbPreco" runat="server" Text="Preço: "></asp:Label><br />
    <%if (Session["perfil"] != null && Session["perfil"].Equals("1")){ %>
    <asp:Button CssClass="btn btn-danger" ID="btReservar" runat="server" Text="Reservar"  />
    <asp:Label runat="server" ID="lbErro" />
    <% } %>
    <br /><a href="/index.aspx">Voltar</a>
</asp:Content>
