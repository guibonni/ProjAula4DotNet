<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjAula4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Gestão de Cidades / Estados</h1>
    <br />
    <h3>Menu de Opções</h3>

    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BtnEstados" runat="server" Text="Estados" OnClick="BtnEstados_Click" />
            <asp:Button ID="BtnCidades" runat="server" Text="Cidades" OnClick="BtnCidades_Click" />
        </div>
    </form>
</body>
</html>
