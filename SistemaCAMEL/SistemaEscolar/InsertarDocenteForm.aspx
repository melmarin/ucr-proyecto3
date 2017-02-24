<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarDocenteForm.aspx.cs" Inherits="SistemaEscolar.InsertarDocenteForm" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lbl_cedula" runat="server" Text="Label"></asp:Label>
    
    </div>
        <asp:Label ID="lbl_nombre" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="lbl_apellidos" runat="server" Text="Label"></asp:Label>
        </p>
        <asp:Label ID="lbl_telefono" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="lbl_correo" runat="server" Text="Label"></asp:Label>
        <p>
            
        <asp:Label ID="lbl_direccion" runat="server" Text="Label"></asp:Label>
            
        </p>
        <p>
            
            <asp:TextBox ID="tb_especialidades" runat="server" Height="37px" Width="215px" ></asp:TextBox>
            
            <asp:DropDownList ID="ddlDocentes" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btn_consultar" runat="server" OnClick="btn_consultar_Click" Text="Consultar" />
        </p>
    </form>
</body>
</html>