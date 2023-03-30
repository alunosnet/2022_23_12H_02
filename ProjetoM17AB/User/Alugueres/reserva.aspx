<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="reserva.aspx.cs" Inherits="ProjetoM17AB.User.Alugueres.reserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registar novo Aluguer</h2>
    <br />
    Data entrada:<asp:TextBox CssClass="form-control" runat="server" ID="tb_dataentrada" TextMode="Date"></asp:TextBox>
    <br />
    Data saida:<asp:TextBox CssClass="form-control" runat="server" ID="tb_datasaida" TextMode="Date"></asp:TextBox>
    <br />
    <asp:Button CssClass="btn btn-lg btn-danger" runat="server" ID="bt_registar" Text="Alugar" OnClick="bt_registar_Click" />
    <asp:Button CssClass="btn btn-lg btn-info" runat="server" ID="bt_cancelar" Text="Cancelar" OnClick="bt_cancelar_Click" />

    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
