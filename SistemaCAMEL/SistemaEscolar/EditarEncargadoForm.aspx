<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarEncargadoForm.aspx.cs" Inherits="SistemaEscolar.EditarEncargadoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <p>
        <asp:Label ID="lb_cedula" runat="server" Text="Cedula:"></asp:Label>
        <asp:TextBox ID="tb_cedula" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar por cédula" />
        &nbsp;&nbsp;
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar por cédula" />
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
            <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Insertar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>        
    
    </div>
        <p>
            <asp:Label ID="lbMensaje" runat="server" Text="Respuesta"></asp:Label>
        </p>
    </form>
</body>
</html>
