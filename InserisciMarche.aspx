<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InserisciMarche.aspx.cs" Inherits="InserisciMarche" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
            <asp:Button ID="btnInvia" runat="server" Text="Inserisci Marca" OnClick="btnInvia_Click" />
        </div>
    </form>
</body>
</html>
