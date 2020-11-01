<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xmlornek.aspx.cs" Inherits="ASMXClient.connect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btngetir" runat="server" OnClick="btngetir_Click" Text="Verileri Getir" />
            <asp:GridView ID="gvliste" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
