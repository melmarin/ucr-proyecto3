<%@ Page Title="" Language="C#" MasterPageFile="~/Admi.Master" AutoEventWireup="true" CodeBehind="IngresarGrupoForm.aspx.cs" Inherits="SistemaEscolar.AdmiView.IngresarGrupoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server" Text="Grado"></asp:Label>
&nbsp;
<asp:TextBox ID="tbGrado" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label runat="server" Text="Sección:"></asp:Label>
&nbsp;<asp:TextBox ID="tbSeccion" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Año:"></asp:Label>
&nbsp;
<asp:TextBox ID="tbAno" runat="server"></asp:TextBox>
<br />
<br />
<asp:ListBox ID="lbCursos" runat="server" Height="124px" Width="197px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="btAgregar" runat="server" OnClick="agregar_onClick" Text="&gt;&gt;" />
&nbsp;&nbsp;
<asp:Button ID="btnEliminar" runat="server" OnClick="remover_onClick" Text="&lt;&lt;" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:ListBox ID="lbCursosSeleccionados" runat="server" Height="124px" Width="197px"></asp:ListBox>
<br />
<br />
<asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
</asp:Content>
