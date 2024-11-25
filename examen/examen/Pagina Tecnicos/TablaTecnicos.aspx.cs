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

namespace examen.Pagina_Tecnicos
{
    public partial class TablaTecnicos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
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
            CLStecnico.TecnicoID = int.Parse(ID.Text);
            CLStecnico.Nombre = Nombre.Text;
            CLStecnico.Especialidad = Especialidad.Text;
          


            if (Tecnicos.AgregarTecnico(CLStecnico.TecnicoID ,CLStecnico.Nombre,CLStecnico.Especialidad ) > 0)
            {
                MostrarAlerta(this, "Tecnico ingresado");
                ID.Text = "";
                Nombre.Text = "";
                Especialidad.Text = "";
                LlenarGrid();

            }
            else
            {
                MostrarAlerta(this, "Error al ingresar tecnico");
            }
        }

        protected void Borrar_Click(object sender, EventArgs e)
        {
            CLStecnico.TecnicoID = int.Parse(ID.Text);
            


            if (Tecnicos.EliminarTecnico(CLStecnico.TecnicoID) > 0)
            {
                MostrarAlerta(this, "Tecnico Borrado");
                ID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al borrar tecnico");
            }

        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            CLStecnico.TecnicoID = int.Parse(ID.Text);
            CLStecnico.Nombre = Nombre.Text;
            CLStecnico.Especialidad = Especialidad.Text;



            if (Tecnicos.ModificarTecnico(CLStecnico.TecnicoID, CLStecnico.Nombre, CLStecnico.Especialidad) > 0)
            {
                MostrarAlerta(this, "tecnico modificado");
                ID.Text = "";
                Nombre.Text = "";
                Especialidad.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Error al modificar Tecnico");
            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
        {

            CLStecnico.TecnicoID = int.Parse(ID.Text);

            if (Tecnicos.ConsultarTecnico(CLSusuario.UsuarioID) > 0)
            {
                MostrarAlerta(this, "Tecnico encontrado");
                ID.Text = "";
                LlenarGrid();
            }
            else
            {
                MostrarAlerta(this, "Tecnico no encontrado");
            }


        }
    }
}