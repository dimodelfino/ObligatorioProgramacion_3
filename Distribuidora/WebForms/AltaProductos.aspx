<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true" CodeBehind="AltaProductos.aspx.cs" Inherits="Distribuidora.WebForms.AltaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registrar Producto</h2>
    <br />
    <h3 style="margin-left: 10px; text-decoration: underline">Datos del Producto</h3>
    <br />
    <div runat="server" id="divNombreProducto">
        <asp:Label ID="lblNombreProucto" runat="server" Style="margin-left: 10px" Text="Nombre "></asp:Label>
        <asp:TextBox ID="txtNombreProducto" Style="margin-left: 55px" runat="server" Width="127px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombreProducto" runat="server" ControlToValidate="txtNombreProducto" EnableClientScript="false" ErrorMessage="Debe ingresar un nombre." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    </div>
    <br />
    <asp:Label ID="lblDescProd" Style="margin-left: 10px" runat="server" Text="Descripcion "></asp:Label>
    <asp:TextBox ID="txtDescProd" Style="margin-left: 30px" runat="server" Width="127px"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="rfvDescProd" runat="server" ControlToValidate="txtDescProd" EnableClientScript="false" ErrorMessage="Debe ingresar una descripcion." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <br />
    <br />
    <asp:Label ID="lblCostoProd" Style="margin-left: 10px" runat="server" Text="Costo "></asp:Label>
    <asp:TextBox ID="txtCostoProd" Style="margin-left: 70px" Width="127px" runat="server"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="rfvCostoProd" runat="server" ControlToValidate="txtCostoProd" EnableClientScript="false" ErrorMessage="Debe ingresar un costo." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <asp:CompareValidator ID="cmpvCostoProd" runat="server" ControlToValidate="txtCostoProd" Operator="GreaterThanEqual" ValueToCompare="0" Type="Integer" ErrorMessage="El costo debe ser mayor a cero. " Font-Bold="true" ForeColor="Red" Display="Dynamic"/>
    <br />
    <br />
    <asp:Label ID="lblPrecioSugerido" Style="margin-left: 10px" runat="server" Text="Precio Sugerido "></asp:Label>
    <asp:TextBox ID="txtPrecioSugerido" Style="margin-left: 5px" Width="127px" runat="server"></asp:TextBox>    
    <asp:RequiredFieldValidator ID="rfvPrecioSugerido" runat="server" ControlToValidate="txtPrecioSugerido" EnableClientScript="false" ErrorMessage="Debe ingresar un precio sugerido." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <asp:CompareValidator ID="cmpvPrecioSugerido" runat="server" ControlToValidate="txtPrecioSugerido" Operator="GreaterThanEqual" ValueToCompare="0" Type="Integer" ErrorMessage="El precio sugerido debe ser mayor a cero. " Font-Bold="true" ForeColor="Red" Display="Dynamic"/>
    <br />
    <br />
    <asp:RadioButtonList ID="rbtnListTipoProd" RepeatDirection="Horizontal" runat="server" style="margin-left: 10px" AutoPostBack="True" OnSelectedIndexChanged="rbtnListTipoProd_SelectedIndexChanged" Height="16px" Width="271px">
        <asp:ListItem Text="Fabricado" value="Fabricado" /> 
        <asp:ListItem Text="Importado" Value="Importado" />
    </asp:RadioButtonList>       
    <div runat="server" id="divFabricado">
    <br />
    <br /> 
        <asp:Label ID="lblTiempoFab" Style="margin-left: 10px" runat="server" Text="Tiempo previsto de fabricacion "></asp:Label>
        <asp:TextBox ID="txtTiempoFab" Style="margin-left: 11px" Width="127px" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTiempoFab" runat="server" ControlToValidate="txtTiempoFab" EnableClientScript="false" ErrorMessage="Debe ingresar un tiempo previsto de fabricacion." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
        <asp:CompareValidator ID="cmpvTiempoFab" runat="server" ControlToValidate="txtTiempoFab" Operator="GreaterThanEqual" ValueToCompare="0" Type="Integer" ErrorMessage="El teimpo previsto debe ser mayor a cero. " Font-Bold="true" ForeColor="Red" Display="Dynamic"/>        
    </div>
    <br />
    <br />
    <div runat="server" id="divImportado">
        <asp:Label ID="lblOrigen" Style="margin-left: 10px; margin-right: 167px" runat="server" Text="Origen "></asp:Label>
        <asp:TextBox ID="txtOrigen"  Width="127px" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvOrigen" runat="server" ControlToValidate="txtOrigen" EnableClientScript="false" ErrorMessage="Debe ingresar un origen del producto." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
        <br />
        <br />
        <asp:Label ID="lblCantImp" Style="margin-left: 10px" runat="server" Text="Cantidad minima de importacion "></asp:Label>
        <asp:TextBox ID="txtCantImp" Style="margin-left: 0px" Width="127px" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCantImp" runat="server" ControlToValidate="txtCantImp" EnableClientScript="false" ErrorMessage="Debe ingresar una cantidad minima de importacion." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
        <asp:CompareValidator ID="cmpvCantImp" runat="server" ControlToValidate="txtCantImp" Operator="GreaterThanEqual" ValueToCompare="0" Type="Integer" ErrorMessage="La cantidad debe ser mayor a cero. " Font-Bold="true" ForeColor="Red" Display="Dynamic"/>
    </div>
    <br />
    <asp:Label ID="lblMensajeProducto" runat="server" Style="margin-bottom: 30px; margin-left: 20px;" Text="" Font-Bold="True" Font-Size="0.9em"></asp:Label>
    <br />
    <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" Style="margin-top: 20px; margin-left: 10px" OnClick="btnAgregarProducto_Click"/>
</asp:Content>
