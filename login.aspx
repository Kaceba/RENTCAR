<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RENTCAR Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="tableLogin">
            <%-- Titolo della tabella --%>
            <caption id="titoloRiquadro">Portale BROVIA Cars SRL.</caption>
            <tr>
                <%-- Tabella contenente etichette e campi di testo del login --%>
                <td id="titoloTabella"> Login </td>
            </tr>
            <tr>
                <%-- Qui l'utente immetterà l'username --%>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" Placeholder="Username" CssClass="boxTesto"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <%-- Qui l'utente immetterà la password --%>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Placeholder="Password" CssClass="boxTesto"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <%-- Cliccando questo bottone, l'utente invierà i dati al server per la convalida --%>
                <td>
                    <asp:Button ID="btnInvia" runat="server" Text="Accedi" OnClick="btnInvia_Click" />
                </td>
            </tr>
            <tr>
                <%-- Qui verranno mostrati eventuali errori --%>
                <td>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
