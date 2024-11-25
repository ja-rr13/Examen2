using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using examen.CapaLogica;
using examen.CapaModelo;

namespace examen.Pagina_Usuarios
{
    public partial class TablaUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexiontablas"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            CLSusuario.UsuarioID = int.Parse(ID.Text);
            CLSusuario.Nombre = Nombre.Text;
            CLSusuario.correo=Correo.Text;
            CLSusuario.telefono = telefono.Text;


            if (Usuarios.AgregarUsuario(CLSusuario.UsuarioID, CLSusuario.Nombre, CLSusuario.correo, CLSusuario.telefono) > 0)
            {
                MostrarAlerta(this,"Usuario ingresado");
                ID.Text = "";
                Nombre.Text = "";
                Correo.Text = "";
                telefono.Text = "";
                LlenarGrid();
            }
            else 
            {
                MostrarAlerta(this, "Error al ingresar usuario");
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            CLSusuario.UsuarioID = int.Parse(ID.Text);
            


            if (Usuarios.EliminarUsuario(CLSusuario.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Usuario Borrado");
                ID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al borrar usuario");
            }

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            CLSusuario.UsuarioID = int.Parse(ID.Text);
            CLSusuario.Nombre = Nombre.Text;
            CLSusuario.correo = Correo.Text;
            CLSusuario.telefono = telefono.Text;


            if (Usuarios.ModificarUsuario(CLSusuario.UsuarioID, CLSusuario.Nombre, CLSusuario.correo, CLSusuario.telefono) > 0)
            {
                MostrarAlerta(this, "Usuario modificado");
                ID.Text = "";
                Nombre.Text = "";
                Correo.Text = "";
                telefono.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar usuario");
            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {
           
            CLSusuario.UsuarioID = int.Parse(ID.Text);

            if (Usuarios.ConsultarUsuario(CLSusuario.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Usuario encontrado");
                ID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Usuario no encontrado");
            }

        
    }
    }
}