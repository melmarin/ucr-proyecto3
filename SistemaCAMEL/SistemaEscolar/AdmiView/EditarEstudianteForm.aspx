<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="EditarEstudianteForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.EditarEstudianteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Carné:"></asp:Label>
&nbsp;
        <asp:TextBox ID="tbCarne" runat="server" ReadOnly="true"></asp:TextBox>
        <p>
            <asp:Label ID="lb_cedula" runat="server" Text="Cedula:"></asp:Label>
        &nbsp;<asp:TextBox ID="tb_cedula" runat="server" ReadOnly="true"></asp:TextBox>
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
            <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Guardar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInactivar" runat="server" OnClick="btnInactivar_Click" Text="Dar de baja" />
        </p>
    </div>
    <p>
        <asp:Label ID="lbMensaje" runat="server"></asp:Label>
    </p>
</asp:Content>
