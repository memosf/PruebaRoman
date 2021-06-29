<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebAplicacionConexiconSQL.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/micodigo.js"></script>
    <script src="js/sweetalert2.all.min.js"></script>
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Probar conexión" Width="791px" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="785px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Consulta con DataReader" Width="791px" />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="122px" Width="792px"></asp:ListBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Consulta con DataSet" Width="790px" />
        <br />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Obtener datos del DataSet" Width="791px" />
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="791px">
        </asp:GridView>
        <br />

        <h2>Insertar nuevo empleado:</h2>
        <p>id:&nbsp;&nbsp;
            <asp:TextBox ID="txtId" runat="server" Width="181px"></asp:TextBox>
        </p>
        nombre:&nbsp;
        <asp:TextBox ID="txtNombre" runat="server" Width="146px"></asp:TextBox>
        <br />
        <br />
        <br />

        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Insertar datos" Width="790px" />
        <br />
        <br />
    </form>
</body>
</html>
