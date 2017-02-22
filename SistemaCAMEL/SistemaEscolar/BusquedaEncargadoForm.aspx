<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusquedaEncargadoForm.aspx.cs" Inherits="SistemaEscolar.BusquedaEncargadoForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvEncargados" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="cedula" ForeColor="#333333" GridLines="None" Height="161px" ShowFooter="True" style="margin-right: 58px" Width="428px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="cedula" HeaderText="Cédula" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="correo" HeaderText="Correo" />
                <asp:BoundField DataField="direccion" HeaderText="Dirección" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
