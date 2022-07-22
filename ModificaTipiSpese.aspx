<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModificaTipiSpese.aspx.cs" Inherits="ModificaTipiSpese" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtModificaTipiSpese" runat="server"></asp:TextBox>
            <asp:Button ID="btnModifica" runat="server" Text="Modifica" OnClick="btnModifica_Click" />
        </div>
    </form>
</body>
</html>
