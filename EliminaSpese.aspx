<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EliminaSpese.aspx.cs" Inherits="EliminaSpese" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                Sei sicuro di voler eliminare il record?
            </p>
            <p>
                <asp:Button ID="btnElimina" runat="server" Text="OK" OnClick="btnElimina_Click" />
            </p>
        </div>
    </form>
</body>
</html>
