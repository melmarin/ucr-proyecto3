<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarEstudianteForm.aspx.cs" Inherits="SistemaEscolar.IngresarEstudianteForm" %>

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
            <asp:Label ID="lbMensaje" runat="server" Text="Respuesta"></asp:Label>
        </p>

    <div>
    
    </div>
    </form>
</body>
</html>
