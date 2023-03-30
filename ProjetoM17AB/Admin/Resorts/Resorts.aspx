<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Resorts.aspx.cs" Inherits="ProjetoM17AB.Admin.Resorts.Resorts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestão de Resorts</h2>
    <asp:GridView ID="gvResorts" runat="server" CssClass="table" />
    <h2>Adicionar Resort</h2>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNResort">Nª Resort:</label>
        <asp:TextBox CssClass="form-control" ID="tbNResort" runat="server"></asp:TextBox>
        <br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbCapacidade">Capacidade:</label>
        <asp:TextBox CssClass="form-control" ID="tbCapacidade" runat="server"></asp:TextBox>
        <br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPrecoNoite">Preço p/noite:</label>
        <asp:TextBox CssClass="form-control" ID="tbPrecoNoite" runat="server"></asp:TextBox>
        <br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPiscina">Piscina:</label>
        <asp:CheckBox CssClass="form-control" ID="cbPiscina" runat="server" />
        <br />
    </div>
    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt" Text="Adicionar" OnClick="bt_Click" />
    <br />
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
