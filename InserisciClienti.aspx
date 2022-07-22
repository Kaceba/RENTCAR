<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InserisciClienti.aspx.cs" Inherits="InserisciClienti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblRAGSOC" runat="server" Text="Ragione Sociale:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRAGSOC" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPiva" runat="server" Text="P.IVA:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPiva" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCodFisc" runat="server" Text="Codice Fiscale:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodFisc" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblIndirizzo" runat="server" Text="Indirizzo:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtIndirizzo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCap" runat="server" Text="CAP:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCap" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblCitta" runat="server" Text="Città"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCitta" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtProvincia" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnInvia" runat="server" Text="Invia" OnClick="btnInvia_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
