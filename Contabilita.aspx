<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contabilita.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblAnno" runat="server" Text="Anno"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAnno" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
                <asp:Button ID="btnVisualizza" runat="server" Text="Visualizza" OnClick="btnVisualizza_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="griglia" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                    <alternatingrowstyle backcolor="#F7F7F7" />
                    <footerstyle backcolor="#B5C7DE" forecolor="#4A3C8C" />
                    <headerstyle backcolor="#4A3C8C" font-bold="True" forecolor="#F7F7F7" />
                    <pagerstyle backcolor="#E7E7FF" forecolor="#4A3C8C" horizontalalign="Right" />
                    <rowstyle backcolor="#E7E7FF" forecolor="#4A3C8C" />
                    <selectedrowstyle backcolor="#738A9C" font-bold="True" forecolor="#F7F7F7" />
                    <sortedascendingcellstyle backcolor="#F4F4FD" />
                    <sortedascendingheaderstyle backcolor="#5A4C9D" />
                    <sorteddescendingcellstyle backcolor="#D8D8F0" />
                    <sorteddescendingheaderstyle backcolor="#3E3277" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
