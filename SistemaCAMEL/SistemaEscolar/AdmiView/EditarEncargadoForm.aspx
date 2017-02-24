<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="EditarEncargadoForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.EditarEncargadoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p>
            <asp:Label ID="lb_cedula" runat="server" Text="Cedula:"></asp:Label>
            <asp:TextBox ID="tb_cedula" runat="server" ReadOnly="true"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
            </p>
        <p>
            <asp:Label ID="lb_nombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="tb_nombre" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Apellidos" runat="server" Text="Apellidos:"></asp:Label>
            <asp:TextBox ID="tb_apellidos" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lb_telefono" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="tb_telefono" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lb_correo" runat="server" Text="Correo:"></asp:Label>
        <asp:TextBox ID="tb_correo" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="lb_direccion" runat="server" Text="Dirección:"></asp:Label>
            <asp:TextBox ID="tb_direccion" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;&nbsp;
            <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Guardar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
        </p>
    </div>
    <p>
        <asp:Label ID="lbMensaje" runat="server"></asp:Label>
    </p>
</asp:Content>
