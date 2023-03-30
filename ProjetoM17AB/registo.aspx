<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registo.aspx.cs" Inherits="ProjetoM17AB.registo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Registo</h1>
    Nome:<asp:TextBox CssClass="form-control"  runat="server" ID="tbnome"></asp:TextBox><br />
    Email:<asp:TextBox CssClass="form-control"  runat="server" ID="tbemail"></asp:TextBox><br />
    Telefone:<asp:TextBox CssClass="form-control"  runat="server" ID="tbtelefone"></asp:TextBox> <br />
    Nif:<asp:TextBox CssClass="form-control"  runat="server" ID="tbnif"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control"  runat="server" ID="tbpassword" TextMode="Password"></asp:TextBox><br />
    <asp:Button CssClass="btn btn-info" runat="server" ID="btguardar" Text="Registar" OnClick="btguardar_Click" /><br />
    <br />
    <asp:Label  runat="server" ID="lberro"></asp:Label>
</asp:Content>
