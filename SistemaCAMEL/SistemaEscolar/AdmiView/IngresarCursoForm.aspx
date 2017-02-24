<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="IngresarCursoForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.IngresarCursoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Sigla:"></asp:Label>
&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Nombre: "></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Profesor:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlDocentes" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <br />
    <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Ingresar" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
