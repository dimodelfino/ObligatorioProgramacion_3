<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Master.Master" AutoEventWireup="true" CodeBehind="ListProdPorTipo.aspx.cs" Inherits="Distribuidora.WebForms.ListProdPorTipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista De Productos</h2>
    <br />    
    <h3 style="text-underline-position: below">Seleccione el tipo de producto que desea mostrar</h3>
    <br />
    <div id="divRadioButtons">
        <asp:RadioButtonList ID="rbtnLstTipoProd" RepeatDirection="Horizontal" runat="server" Style="margin-left: 10px" AutoPostBack="True" Height="16px" Width="271px" OnSelectedIndexChanged="rbtnLstTipoProd_SelectedIndexChanged">
            <asp:ListItem Text="Fabricado" Value="Fabricado" />
            <asp:ListItem Text="Importado" Value="Importado" />
            <asp:ListItem Text="Todos" Value="Todos" />
        </asp:RadioButtonList>
    </div>
    <br /><br />
    <div id="divGrdVwFabricados" style="float:left; padding-left:5px;" runat="server">
        <asp:GridView ID="grdVwFabricados" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="desc" HeaderText="Descripcion" />
                <asp:BoundField DataField="costo" HeaderText="Costo" />
                <asp:BoundField DataField="precioSugerido" HeaderText="Precio Sugerido" />
                <asp:BoundField DataField="tiempoFab" HeaderText="Tiempo Previsto De Fabricación" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" BorderWidth="2" BorderColor="black" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" BorderWidth="2" BorderColor="black" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
 
    <div id="divGrdVwImportados" style="float:right; padding-left:3px;" runat="server">
        <asp:GridView ID="GrdVwImportados" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="desc" HeaderText="Descripción" />
                <asp:BoundField DataField="costo" HeaderText="Costo" />
                <asp:BoundField DataField="precioSugerido" HeaderText="Precio Sugerido" />
                <asp:BoundField DataField="origen" HeaderText="Origen" />
                <asp:BoundField DataField="cantImportacion" HeaderText="Cantidad Minima De Importacion" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" BorderWidth="2" BorderColor="black" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" HorizontalAlign="Center" BorderWidth="2" BorderColor="black" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />

            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </div>
</asp:Content>
