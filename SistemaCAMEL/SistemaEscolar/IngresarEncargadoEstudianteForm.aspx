<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarEncargadoEstudianteForm.aspx.cs" Inherits="SistemaEscolar.IngresarEncargadoEstudianteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form_insertar" runat="server">
    <div>
        <p>
        <asp:Label ID="lb_nombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="tb_nombre" runat="server"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="Apellidos" runat="server" Text="Apellidos:"></asp:Label>
        <asp:TextBox ID="tb_apellidos" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="lb_cedula" runat="server" Text="Cedula:"></asp:Label>
        <asp:TextBox ID="tb_cedula" runat="server"></asp:TextBox>
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
    </div>

    </form>
</body>
</html>
