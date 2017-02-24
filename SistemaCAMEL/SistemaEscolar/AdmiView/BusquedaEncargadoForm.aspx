<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="BusquedaEncargadoForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.BusquedaEncargadoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
&nbsp;<asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
&nbsp;<asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnNombre" runat="server" OnClick="btnNombre_Click" Text="Buscar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Cédula:"></asp:Label>
&nbsp;<asp:TextBox ID="tbCedula" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCedula" runat="server" OnClick="btnCedula_Click" Text="Buscar" />
    </p>
    <div>
        <asp:GridView ID="gvEncargados" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="cedula" ForeColor="#333333" GridLines="None" Height="161px" ShowFooter="True" style="margin-right: 58px" Width="599px" OnRowCommand="editarClick" OnSelectedIndexChanged="gvEncargados_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="cedula" HeaderText="Cédula" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="correo" HeaderText="Correo" />
                <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                <asp:ButtonField CommandName="editarClcik" Text="Editar-Eliminar" />
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
</asp:Content>
