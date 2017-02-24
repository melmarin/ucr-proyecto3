<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="SistemaEscolar.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Usuario:&nbsp;
        <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>
        <br />
        Contraseña:&nbsp;
        <input id="passClave" type="password" runat="server" /><br />
        <br />
        <asp:Label ID="lbMensaje" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Iniciar sesión" />
    </form>
</body>
</html>
