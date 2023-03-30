<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="alugueres.aspx.cs" Inherits="ProjetoM17AB.User.Alugueres.alugueres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Alugar Resort</h2>
    <asp:GridView CssClass="table" EmptyDataText="Não existem resorts disponíveis para alugar" runat="server" ID="gvresorts"></asp:GridView>
</asp:Content>
