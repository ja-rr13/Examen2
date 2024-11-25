<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TablaUsuarios.aspx.cs" Inherits="examen.Pagina_Usuarios.TablaUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="Dtusuarios.css" rel="stylesheet" />
    <title>Usuarios</title>
     <style type="text/css">
       
 </style>
   
</head>
<body>
   
    <form  id="form1" runat="server">
      
            <h2>TABLA DE USUARIOS</h2>
            <br />
            <br />
            <asp:GridView ID="GridView1" class="g" runat="server" BorderStyle="Ridge">
            </asp:GridView>
            <br />
            UsuarioID:
            <asp:TextBox ID="ID" type="number" runat="server"></asp:TextBox>
            <br />
            <br />
            Nombre:
            <asp:TextBox ID="Nombre" aling="center" runat="server"></asp:TextBox>
            <br />
            <br />
            CorreoElectronico:
            <asp:TextBox ID="Correo" aling="center" runat="server"></asp:TextBox>
            <br />
            <br />
            NumeroTelefono:
            <asp:TextBox ID="telefono" text-aling="center" runat="server"></asp:TextBox>
            <br />
             <br />
            <asp:Button CssClass="b" ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" BorderStyle="Solid" />

            <asp:Button CssClass="b" ID="Borrar" runat="server" Text="Borrar" OnClick="Borrar_Click" BorderStyle="Solid" />
       
            <asp:Button CssClass="b" ID="Modificar" runat="server" Text="Modificar" OnClick="Modificar_Click" BorderStyle="Solid" />

            <asp:Button CssClass="b" ID="Consultar" runat="server" Text="Consultar" OnClick="Consultar_Click" BorderStyle="Solid" />
       
        

    </form>
    
</body>
</html>
