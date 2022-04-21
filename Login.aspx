<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InternetBanking.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="loginForm" runat="server">
        <h1>
            <asp:Label ID="lblTitulo" runat="server" Text="Internet Banking"></asp:Label>
        </h1>
        <p>
            <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" OnAuthenticate="Login1_Authenticate">
                <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                <TextBoxStyle Font-Size="0.8em" />
                <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
            </asp:Login>
        </p>
    </form>
</body>
</html>
