<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="historico.aspx.cs" Inherits="ProjetoM17AB.User.Alugueres.historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Histórico</h2>
    <asp:GridView CssClass="table" EmptyDataText="Nunca alugou um resort" ID="gvhistorico" runat="server"></asp:GridView>
</asp:Content>
