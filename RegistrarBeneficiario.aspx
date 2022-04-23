<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarBeneficiario.aspx.cs" Inherits="InternetBanking.RegistrarBeneficiario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            <asp:Label ID="Label1" runat="server" Text="Internet Banking"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Log Out" />
        </h1>
        <asp:Menu ID="Menu1" runat="server" Orientaion="Horizontal" BackColor="#F7F6F3" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#7C6F57" StaticSubMenuIndent="10px" style="text-align: justify">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Cuentas" Value="Cuentas"></asp:MenuItem>
                <asp:MenuItem Text="Transferencias entre Cuentas Propias" Value="Transferencias" NavigateUrl="~/CuentaPropia.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Registrar Beneficiario" Value="New Item" NavigateUrl="~/RegistrarBeneficiario.aspx" Selectable="False"></asp:MenuItem>
                <asp:MenuItem Text="Pago de Préstamos" Value="Pago de Préstamos" NavigateUrl="~/Prestamo.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Transferencia a Terceros" Value="Transferencia a Terceros" NavigateUrl="~/Terceros.aspx"></asp:MenuItem>
                <asp:MenuItem Text="Transferencia a Otro Banco" Value="Transferencia a Otro Banco" NavigateUrl="~/OtroBanco.aspx"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
        <p>
            Número de Cuenta:&nbsp;
            <asp:TextBox ID="tBoxNumeroCuenta" runat="server" OnTextChanged="tBoxNumeroCuenta_TextChanged"></asp:TextBox>
        </p>
        <p>
            Alias:
            <asp:TextBox ID="tBoxAlias" runat="server" OnTextChanged="tBoxAlias_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Width="68px" OnClick="btnRegistrar_Click" />
&nbsp;
            <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" Width="68px" OnClick="btnConfirmar_Click" Visible="False" />
        </p>
        </form>
</body>
</html>
