<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Utilizadores.aspx.cs" Inherits="ProjetoM17AB.Admin.Utilizadores.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Utilizadores</h1>
    <asp:GridView CssClass="table" ID="gvUtilizadores" runat="server"></asp:GridView>
    <h1>Adicionar Utilizador</h1>
    Nome:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nome"></asp:TextBox><br />
    Telefone:<asp:TextBox CssClass="form-control" runat="server" ID="tb_telefone"></asp:TextBox><br />
    Nif:<asp:TextBox CssClass="form-control" runat="server" ID="tb_nif"></asp:TextBox><br />
    Email:<asp:TextBox CssClass="form-control" runat="server" ID="tb_email"></asp:TextBox><br />
    Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    Perfil:<asp:DropDownList CssClass="form-control" runat="server" ID="dd_perfil">
                <asp:ListItem Value="0">Admin</asp:ListItem>
                <asp:ListItem Value="1">Cliente</asp:ListItem>
           </asp:DropDownList>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="btguardar" Text="Adicionar" OnClick="btguardar_Click"  /><br />
    <br />
    <asp:Label runat="server" ID="lberro"></asp:Label>
</asp:Content>
