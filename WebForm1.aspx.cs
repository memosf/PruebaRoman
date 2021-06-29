using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ConexionBD;
namespace WebAplicacionConexiconSQL
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ClassAccesoSQL objacc = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objacc = new ClassAccesoSQL("Data Source = ROMANISIDOR; Initial Catalog = BDTIENDA; Integrated Security = true");
                Session["objacc"] = objacc;
            }
            else
            {
                objacc = (ClassAccesoSQL)Session["objacc"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection temp = null;
            string mensaje = "";
            temp = objacc.AbrirConexion(ref mensaje);
            //TextBox1.Text = mensaje;
            if (temp != null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), 
                    "msgbox01", "verAlerta('Conexión correcta ', '"+ mensaje +"', 'success');", true);
                temp.Close(); //Cerrar la conexión
                temp.Dispose(); //Destruir el objeto de conexión

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "msgbox01", "verAlerta(`Conexión incorrecta `, `" + mensaje + "`, `error`);", true);
            }
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlDataReader caja = null;

            SqlConnection cnab = null;

            string m = "";

            cnab = objacc.AbrirConexion(ref m);

            if (cnab != null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "123", "verAlerta('Correcto', '" + m + "', 'success')", true);

                caja = objacc.ConsultarReader("select * from EMPLEADO", cnab, ref m);

                if (caja != null)
                //La consuta es correcta y se leen los datos
                {
                    ListBox1.Items.Clear();
                    while (caja.Read())
                    {
                        ListBox1.Items.Add(caja[0] + " " + caja["NOMBRE"]);

                    }

                }

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                   "1234", "verAlerta('Incorrecto', '" + m + "', 'error')", true);

            }

            cnab.Close();
            cnab.Dispose();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            DataSet contenedor = null;

            SqlConnection cnab = null;

            string m = "";

            cnab = objacc.AbrirConexion(ref m);

            if (cnab != null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "msg123", "verAlerta(`Correcto`, `" + m + "`, `success`)", true);

                contenedor = objacc.ConsultaDS("select * from EMPLEADO", cnab, ref m);

                cnab.Close();
                cnab.Dispose();
                if (contenedor != null)
                //La consuta es correcta y se leen los datos
                {

                    GridView1.DataSource = contenedor.Tables[0];
                    GridView1.DataBind();
                    Session["Tabla1"] = contenedor;

                }

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                   "msg1234", "verAlerta('Incorrecto', '" + m + "', 'error')", true);

            }



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            DataSet temp = Session["Tabla1"] as DataSet;
            ListBox1.Items.Clear();

            ListBox1.Items.Add("Datos recuperados del dataTable 0");



            foreach (DataRow registro in temp.Tables[0].Rows)
            {
                ListBox1.Items.Add(registro[0] + " -- " + registro[1]);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

            SqlParameter first = new SqlParameter("id", SqlDbType.Int);
            SqlParameter second = new SqlParameter("nombre", SqlDbType.NVarChar, 50);

            first.Value = txtId.Text;
            second.Value = txtNombre.Text;

            string sentencia = "Insert Into empleado values(@id, @nombre);";
            SqlConnection conexion = null;
            string mensaje = "";
            Boolean resp = false;
            conexion = objacc.AbrirConexion(ref mensaje);

            resp = objacc.ModificaBDinsegura(sentencia, conexion, ref mensaje);

            if (resp)
            {

                this.ClientScript.RegisterStartupScript(this.GetType(),
                   "msgModificacion", "verAlerta(`Correcto`, `" + mensaje + "`, `success`)", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(),
                    "msgModificacion", "verAlerta(`Error`, `" + mensaje + "`, `error`)", true);
            }
        }
    }
}