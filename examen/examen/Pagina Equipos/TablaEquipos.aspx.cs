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

namespace examen.Pagina_Equipos
{
    public partial class TablaEquipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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
           CLSequipo.EquipoID = int.Parse(ID.Text);
            CLSequipo.TipoEquipo = Tipoequipo.Text;
            CLSequipo.Modelo = Modelo.Text;
            CLSequipo.UsuarioID = int.Parse(UsuarioID.Text);

            if (Equipos.AgregarEquipo(CLSequipo.EquipoID,CLSequipo.TipoEquipo,CLSequipo.Modelo,CLSequipo.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Equipo ingresado");
                ID.Text = "";
                Tipoequipo.Text = "";
                Modelo.Text = "";
                UsuarioID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al ingresar Equipo usuario no existentte");
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            CLSequipo.EquipoID = int.Parse(ID.Text);



            if (Equipos.EliminarEquipo(CLSequipo.EquipoID) > 0)
            {
                MostrarAlerta(this, "Equipo Borrado");
                ID.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error al borrar equipo");
            }

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {

            CLSequipo.EquipoID = int.Parse(ID.Text);
            CLSequipo.TipoEquipo = Tipoequipo.Text;
            CLSequipo.Modelo = Modelo.Text;
            CLSequipo.UsuarioID = int.Parse(UsuarioID.Text);

            if (Equipos.ModificarEquipo(CLSequipo.EquipoID, CLSequipo.TipoEquipo, CLSequipo.Modelo, CLSequipo.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Equipo modificado");
                ID.Text = "";
                Tipoequipo.Text = "";
                Modelo.Text = "";
                UsuarioID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar Equipo");
            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {

            CLSequipo.EquipoID = int.Parse(ID.Text);

            if (Equipos.ConsultarEquipo(CLSequipo.EquipoID) > 0)
            {
                MostrarAlerta(this, "Equipo encontrado");
                ID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Equipo no encontrado");
            }


        }
    }
}