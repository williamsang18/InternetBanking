<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleCuenta.aspx.cs" Inherits="InternetBanking.Detalle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
            <asp:Label ID="lblDetalle" runat="server" Text="Internet Banking"></asp:Label>
            </h1>
        </div>
        <asp:Menu ID="Menu1" runat="server" Orientaion="Horizontal" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px" style="text-align: justify">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Cuentas" Value="Cuentas"></asp:MenuItem>
                <asp:MenuItem Text="Transferencias entre Cuentas Propias" Value="Transferencias" NavigateUrl="~/CuentaPropia.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Registrar Beneficiario" Value="New Item" NavigateUrl="~/RegistrarBeneficiario.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Pago de Préstamos" Value="Pago de Préstamos" NavigateUrl="~/Prestamo.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Transferencia a Terceros" Value="Transferencia a Terceros" NavigateUrl="~/Terceros.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Transferencia a Otro Banco" Value="Transferencia a Otro Banco" NavigateUrl="~/OtroBanco.aspx"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
        <asp:Label ID="lblN" runat="server" style="font-weight: 700" Text="Numero"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNumero" runat="server" Text="Numero"></asp:Label>
        <p>
            <asp:Label ID="lblE" runat="server" style="font-weight: 700" Text="Estado"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblT" runat="server" style="font-weight: 700" Text="Tipo"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblTipo" runat="server" Text="Tipo"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblB" runat="server" style="font-weight: 700" Text="Balance"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblBalance" runat="server" Text="Balance"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnMovimientos" runat="server" OnClick="btnMovimientos_Click" Text="Ver Movimientos" />
        </p>
        <asp:GridView ID="gvMovimientos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    </form>
</body>
</html>
