<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InserisciContratti.aspx.cs" Inherits="InserisciContratti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlClienti" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="ddlAuto" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtInizioContratto" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:TextBox ID="txtFineContratto" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnInvia" runat="server" Text="Invia" OnClick="btnInvia_Click" />
    </form>
</body>
</html>
