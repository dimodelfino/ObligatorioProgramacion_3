<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true" CodeBehind="ListadoFabricados.aspx.cs" Inherits="Distribuidora.WebForms.ListadoFabricados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Listado de Productos Fabricados</h2>
    <br />
    <br />
    <div id="divGrdVwListaFabricados" runat="server">
        <asp:gridview id="grdVwListaFabricados" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="desc" HeaderText="Descripción" />
                <asp:BoundField DataField="costo" HeaderText="Costo" />
                <asp:BoundField DataField="precioSugerido" HeaderText="Precio Sugerido" />
                <asp:BoundField DataField="tiempoFab" HeaderText="Tiempo Previsto de Fabricación"/>
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" BorderWidth="2" BorderColor="black"/>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign ="Center" BorderWidth="2" BorderColor="black"/>
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:gridview>
    </div>
</asp:Content>

