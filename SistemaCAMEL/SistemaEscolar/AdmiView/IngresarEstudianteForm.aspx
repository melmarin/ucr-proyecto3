<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="IngresarEstudianteForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.IngresarEstudianteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <p>
        <asp:Label ID="lb_cedula" runat="server" Text="Cedula:"></asp:Label>
        &nbsp;<asp:TextBox ID="tb_cedula" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="lb_nombre" runat="server" Text="Nombre:"></asp:Label>
        &nbsp;<asp:TextBox ID="tb_nombre" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Apellidos" runat="server" Text="Apellidos:"></asp:Label>
        &nbsp;<asp:TextBox ID="tb_apellidos" runat="server"></asp:TextBox>
    </p>
    <p>
            Encargado:&nbsp;
            <asp:DropDownList ID="ddlEncargado" runat="server" OnSelectedIndexChanged="ddlEncargado_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Insertar" />
    </p>
</div>
<p>
    <asp:Label ID="lbMensaje" runat="server"></asp:Label>
</p>
</asp:Content>
