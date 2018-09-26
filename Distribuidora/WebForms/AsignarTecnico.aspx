<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true" CodeBehind="AsignarTecnico.aspx.cs" Inherits="Distribuidora.WebForms.AsignarTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Asignar Tecnico A Producto Fabricado</h2>
    <br />
    <div id="divGrdVwProd" runat="server">
        <h3 style="margin-left: 10px; text-decoration: underline">Seleccione un Producto:</h3>
        <br />
        <asp:GridView ID="grdVwProductosFab" runat="server" DataKeyNames="id,idFabricado" CellPadding="4" ForeColor="#333333" GridLines="None" Width="416px" AutoGenerateColumns="False" OnSelectedIndexChanged="grdVwProductosFab_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="IdProd" ShowHeader="False" Visible="False" />
                <asp:BoundField DataField="idFabricado" HeaderText="IdFabricado" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="tiempoFab" HeaderText="Tiempo Previsto de Fabricación" />
                <asp:BoundField DataField="desc" HeaderText="Descripción" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <br />
        <asp:Label ID="lblProductoSeleccionado" runat="server"></asp:Label>
    </div>
    <br />
    <br />
    <div id="divGrdVwTecnicos">
        <h3 style="margin-left: 10px; text-decoration: underline">Seleccione un Tecnico:</h3>
        <br />
        <asp:GridView ID="grdVwTecnicos" runat="server" DataKeyNames="idEmpleado" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="grdVwTecnicos_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="idEmpleado" HeaderText="IdEmpleado" Visible="False" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="email" HeaderText="Email" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
    <br />
    <asp:Label ID="lblTecnicoSeleccionado" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblDescTarea" runat="server" Text="Descripcion de Tarea"></asp:Label>
    <asp:TextBox ID="txtDescTarea" runat="server" Width="127px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDescTarea" runat="server" ControlToValidate="txtDescTarea" EnableClientScript="false" ErrorMessage="Debe ingresar una descripcion." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <br />
    <br />
    <asp:Label ID="lblTiempoRealizacion" runat="server" Text="Tiempo de Realizacion de la Tarea"></asp:Label>
    <asp:TextBox ID="txtTempoRealizacion" runat="server" Width="127px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTiempoRealizacion" runat="server" ControlToValidate="txtTempoRealizacion" EnableClientScript="false" ErrorMessage="Debe ingresar un tiempo de realizacion de la tarea." Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <asp:CompareValidator ID="cmpvTiempoRealizacion" runat="server" ControlToValidate="txtTempoRealizacion" Operator="GreaterThanEqual" ValueToCompare="0" Type="Integer" ErrorMessage="El tiempo de realizacion debe ser mayor a cero. " Font-Bold="true" ForeColor="Red" Display="Dynamic" />
    <br />
    <asp:Button ID="btnAsignarTecnico" runat="server" Text="Asignar Tecnico" Style="margin-top: 20px;" OnClick="btnAsignarTecnico_Click" />
</asp:Content>
