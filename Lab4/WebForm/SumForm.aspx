<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SumForm.aspx.cs" Inherits="WebForm.SumForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="sumForm" runat="server">
        <div>
            <div>
                <asp:TextBox runat="server" ID="number_one" />
                <br />
                <asp:TextBox runat="server" ID="number_two" />
            </div>
            <asp:Button runat="server" ID="sum" OnClick="Sum_Click" Text="Sum" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="result" />
        </div>
    </form>
<%--    <form id="concatenationForm" runat="server">
        <div>
            <div>
                <asp:TextBox runat="server" ID="str" />
                <asp:TextBox runat="server" ID="dbl" />
            </div>
            <asp:Button runat="server" ID="concat" OnClick="Concat_Click" Text="Concat" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="TextBox3" />
        </div>
    </form>--%>
</body>
</html>
