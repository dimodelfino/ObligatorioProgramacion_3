<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true" CodeBehind="AltaEmpleado.aspx.cs" Inherits="Distribuidora.AltaEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registrar Empleado</h2>
    <br />
    <h3 style="margin-left: 10px; text-decoration: underline">Datos de Empleado</h3>
    <br />
    <div runat="server" id="divNombreEmpleado">
        <asp:Label ID="lblNombreEmpleado" runat="server" Style="margin-left: 10px" Text="Nombre Completo "></asp:Label>
        <asp:TextBox ID="txtNombreEmpleado" Style="margin-left: 0px" runat="server" Width="127px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombreEmpleado" runat="server" ControlToValidate="txtNombreEmpleado" EnableClientScript="false" ErrorMessage="Debe ingresar un nombre." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    </div>
    <br />
    <asp:Label ID="lblMailEmpleado" Style="margin-left: 10px" runat="server" Text="Email "></asp:Label>
    <asp:TextBox ID="txtMailEmpleado" Style="margin-left: 82px" runat="server" Width="127px"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revMailEmpleado" runat="server" ControlToValidate="txtMailEmpleado" EnableClientScript="false" ErrorMessage="El formato del Email no es correcto." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <asp:RequiredFieldValidator ID="rfvMailEmpleado" runat="server" ControlToValidate="txtMailEmpleado" EnableClientScript="false" ErrorMessage="Debe ingresar un Email." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <br />
    <br />
    <asp:Label ID="lblContrasena" Style="margin-left: 10px" runat="server" Text="Contraseña "></asp:Label>
    <asp:TextBox ID="txtContreasena" TextMode="Password" Style="margin-left: 48px" Width="127px" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revContrasena" runat="server" ControlToValidate="txtContreasena" EnableClientScript="false" ErrorMessage="La contraseña debe tener al menos 3 caracteres." ValidationExpression="^([\S\s]{3,})$" Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <asp:RequiredFieldValidator ID="rfvContrasenaEmpleado" runat="server" ControlToValidate="txtContreasena" EnableClientScript="false" ErrorMessage="Debe ingresar una contraseña." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <br />
    <br />
    <asp:Label ID="lblTecnico" Style="margin-left: 10px" runat="server" Text="Tecnico"></asp:Label>
    <asp:CheckBox ID="chkBxTecnico" runat="server" AutoPostBack="true" Checked="false" Style="margin-left: 67px" Width="127px" />
    <br />
    <br />
    <asp:Label ID="lblMensajeEmpleado" runat="server" Style="margin-bottom: 30px; margin-left: 20px;" Text="" Font-Bold="True" Font-Size="0.9em"></asp:Label>
    <br />
    <asp:Button ID="btnAgregarEmpleado" runat="server" Text="Agregar Empleado" Style="margin-top: 20px; margin-left: 10px" OnClick="btnAgregarEmpleado_Click"/>
</asp:Content>
