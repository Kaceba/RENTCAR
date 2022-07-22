<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminaContratti.aspx.cs" Inherits="EliminaContratti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Label ID="lblElimina" runat="server" Text="Sei sicuro di voler eliminare il record?"></asp:Label>
            </p>
            <p>
                <asp:Button ID="btnElimina" runat="server" Text="Ok" OnClick="btnElimina_Click" />
            </p>
        </div>
    </form>
</body>
</html>
