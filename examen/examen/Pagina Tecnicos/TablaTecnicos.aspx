<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TablaTecnicos.aspx.cs" Inherits="examen.Pagina_Tecnicos.TablaTecnicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="DTtecnicos.css" rel="stylesheet" />
    <title>Tecnicos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 414px">
            <h2>TABLA DE TECNICOS</h2>
<br />
<br />
<asp:GridView ID="GridView1" CssClass="g" runat="server">
</asp:GridView>
<br />
TcnicoID:
<asp:TextBox ID="ID" type="number" runat="server"></asp:TextBox>
<br />
<br />
Nombre:
<asp:TextBox ID="Nombre"  runat="server"></asp:TextBox>
<br />
<br />
Especialidad:
<asp:TextBox ID="Especialidad" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="Agregar" CssClass="b" runat="server" Text="Agregar" OnClick="Agregar_Click" />

<asp:Button ID="Borrar" CssClass="b" runat="server" Text="Borrar" OnClick="Borrar_Click" />
       
<asp:Button ID="Modificar" CssClass="b" runat="server" Text="Modificar" OnClick="Modificar_Click" />

<asp:Button ID="Consultar" CssClass="b" runat="server" Text="Consultar" OnClick="Consultar_Click" />
        </div>
    </form>
</body>
</html>
