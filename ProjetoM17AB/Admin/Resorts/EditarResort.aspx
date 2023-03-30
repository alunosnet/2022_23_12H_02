<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarResort.aspx.cs" Inherits="ProjetoM17AB.Admin.Resorts.EditarResort" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <br />
    <asp:Button runat="server" ID="btAtualizar" CssClass="btn btn-lg btn-success" Text="Atualizar" OnClick="btAtualizar_Click" />
    <asp:Button runat="server" ID="btVoltar" CssClass="btn btn-lg btn-info" Text="Voltar" PostBackUrl="~/Admin/Resorts/Resorts.aspx" />
    <br />
    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
