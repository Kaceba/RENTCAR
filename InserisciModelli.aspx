<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InserisciModelli.aspx.cs" Inherits="InserisciModelli" %>

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
                    <td><b>Marca</b></td>
                    <td colspan="2"><b>Modello</b></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="txtModello" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnInvia" runat="server" Text="Inserisci" OnClick="btnInvia_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
