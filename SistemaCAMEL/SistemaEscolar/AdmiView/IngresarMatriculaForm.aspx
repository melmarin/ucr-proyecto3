<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="IngresarMatriculaForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.IngresarMatriculaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Realizar Matrícula</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="Seleccionar estudiante:"></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="ddlEstudiantes" runat="server">
    </asp:DropDownList>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Text="Seleccionar el grupo:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlGrupo" runat="server">
    </asp:DropDownList>
</p>
<asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="Registrar" />
<br />
<br />
<asp:Label ID="lbMensaje" runat="server"></asp:Label>
</asp:Content>
