<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Terceros.aspx.cs" Inherits="InternetBanking.Terceros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                <asp:Label ID="lblDefault" runat="server" Text="Internet Banking"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Log Out" />
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
                <asp:MenuItem Text="Transferencia a Terceros" Value="Transferencia a Terceros" NavigateUrl="~/Terceros.aspx" Selectable="False"></asp:MenuItem>
                <asp:MenuItem Text="Transferencia a Otro Banco" Value="Transferencia a Otro Banco" NavigateUrl="~/OtroBanco.aspx"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#5D7B9D" />
        </asp:Menu>
        <p>
            Cuenta Origen:
            <asp:DropDownList ID="ddlCuentasOrigen" runat="server" OnSelectedIndexChanged="ddlCuentasOrigen_SelectedIndexChanged">
            </asp:DropDownList>
        </p>
        <p>
            Cuenta Destino:
            <asp:TextBox ID="tBoxCuentaDestino" runat="server" OnTextChanged="tBoxCuentaDestino_TextChanged"></asp:TextBox>
        &nbsp;
            <asp:DropDownList ID="ddlBeneficiarios" runat="server" OnSelectedIndexChanged="ddlBeneficiarios_SelectedIndexChanged">
                <asp:ListItem Value="70110273">Jorge</asp:ListItem>
            </asp:DropDownList>
&nbsp;
            <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" OnClick="btnSeleccionar_Click" />
        </p>
        <p>
            Monto:
            <asp:TextBox ID="tBoxMonto" runat="server" OnTextChanged="tBoxMonto_TextChanged"></asp:TextBox>
        </p>
        <asp:Button ID="btnProcesar" runat="server" Text="Procesar" Width="68px" OnClick="btnProcesar_Click" />
&nbsp;
        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" Width="68px" Visible="False" OnClick="btnConfirmar_Click" />
    </form>
</body>
</html>
