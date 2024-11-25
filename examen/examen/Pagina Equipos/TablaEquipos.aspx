<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TablaEquipos.aspx.cs" Inherits="examen.Pagina_Equipos.TablaEquipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="DTequipos.css" rel="stylesheet" />
    <title>Equipos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>TABLA DE EQUIPOS</h2>
<br />
<br />
<asp:GridView ID="GridView1" class="g" runat="server">
</asp:GridView>
<br />
EquipoID:
<asp:TextBox ID="ID" type="number" runat="server"></asp:TextBox>
<br />
<br />
TipoEquipo:
<asp:TextBox ID="Tipoequipo"  runat="server"></asp:TextBox>
<br />
<br />
Modelo:
<asp:TextBox ID="Modelo" runat="server"></asp:TextBox>
<br />
<br />
UsuarioID:
<asp:TextBox ID="UsuarioID" type="number" runat="server"></asp:TextBox>
<br />
 <br />
<asp:Button ID="Agregar" cssClass="b" runat="server" Text="Agregar" OnClick="Agregar_Click" />

<asp:Button ID="Borrar" CssClass="b" runat="server" Text="Borrar" OnClick="Borrar_Click" />
       
<asp:Button ID="Modificar" cssClass="b" runat="server" Text="Modificar" OnClick="Modificar_Click" />

<asp:Button ID="Consultar" CssClass="b" runat="server" Text="Consultar" OnClick="Consultar_Click" />
        </div>
    </form>
</body>
</html>
