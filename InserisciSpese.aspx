<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InserisciSpese.aspx.cs" Inherits="InserisciSpese" %>

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
                        <asp:Label ID="lblCodiceTipoSpesa" runat="server" Text="Tipo spesa"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoSpesa" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblImporto" runat="server" Text="Importo"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtImporto" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDataSpesa" runat="server" Text="Data spesa"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataSpesa" runat="server" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btInvia" runat="server" Text="Modifica" OnClick="btnInvia_Click" />
        </div>
    </form>
</body>
</html>
