
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encuesta.Datos;
using Encuesta.TipoDatos;
using System.Web.UI.HtmlControls;

namespace Encuesta.Presentacion
{
    public partial class FrmPintarEncuesta : System.Web.UI.Page
    {
        Panel DatosPanel = new Panel();


        protected void Page_Load(object sender, EventArgs e)
        {
            pintaPlantillaDos();


        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            //pintaPlantilla();

        }

        public void pintaPlantillaDos()
        {


            string plantillaencuesta = Request.QueryString["Valor"];
            string servicio = Request.QueryString["ValorServicio"];

            DataTable dtpE = DPLANTILLAENCUESTA.traerPlantillaEncuesta(Convert.ToInt32(plantillaencuesta), servicio);



            DataTable dts;



            if (dtpE != null)
            {

                if (dtpE.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtpE.Rows)
                    {

                        if (dr["TIPOREGISTRO"].ToString() == "Pregunta")
                        {
                            Label label = new Label();

                            string campostrlbl = "lbl" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;
                            label.Text = dr["PREGUNTA"].ToString();
                            label.Font.Bold = true;



                            var div = new HtmlGenericControl("br");

                            Panel1.Controls.Add(label);
                            Panel1.Controls.Add(div);

                        }
                        if (dr["TIPOREGISTRO"].ToString() == "Evaluado" && dr["TIPO"].ToString() == "RadioButton")
                        {

                            Label label = new Label();
                            string campostrlbl = "lbl" + "JAGR" + dr["SERVICIO"].ToString() + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;
                            label.Text = dr["VALOR"].ToString();
                            label.Font.Bold = true;
                            label.ForeColor = System.Drawing.Color.Blue;


                            var div = new HtmlGenericControl("br");

                            RadioButtonList radioButtonList = new RadioButtonList();
                            string campostr = "rbt" + "JAGR" + dr["SERVICIO"].ToString() + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostr = campostr.Replace(" ", "1sp4c10");
                            campostr = campostr.Replace(",", "C0m4");
                            campostr = campostr.Replace("?", "Pr3gunt4");

                            radioButtonList.ID = campostr;
                            //"rbt" + "JAGR" + "Blanco" + "JAGR" +dr["PREGUNTA"].ToString()+ "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString();


                            dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(plantillaencuesta), Convert.ToInt32(dr["CAMPO"].ToString()));




                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Horizontal;




                            Panel1.Controls.Add(label);
                            Panel1.Controls.Add(radioButtonList);
                            Panel1.Controls.Add(div);
                        }
                        if (dr["TIPOREGISTRO"].ToString() == "EvaluadoSerBlanco" && dr["TIPO"].ToString() == "RadioButton")
                        {

                            Label label = new Label();
                            string campostrlbl = "lbl" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;
                            label.Text = dr["PREGUNTA"].ToString();
                            label.Font.Bold = true;


                            var div = new HtmlGenericControl("br");

                            RadioButtonList radioButtonList = new RadioButtonList();
                            string campostr = "rbt" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();

                            campostr = campostr.Replace(" ", "1sp4c10");
                            campostr = campostr.Replace(",", "C0m4");
                            campostr = campostr.Replace("?", "Pr3gunt4");
                            radioButtonList.ID = campostr;

                            //"rbt" + "JAGR" + "Blanco" + "JAGR" +dr["PREGUNTA"].ToString()+ "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString();

                            dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(plantillaencuesta), Convert.ToInt32(dr["CAMPO"].ToString()));

                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Vertical;

                            Panel1.Controls.Add(label);
                            Panel1.Controls.Add(radioButtonList);
                            Panel1.Controls.Add(div);
                        }
                        if (dr["TIPOREGISTRO"].ToString() == "EvaluadoNoBlanco" && dr["TIPO"].ToString() == "RadioButton")
                        {

                            Label label = new Label();
                            string campostrlbl = "lbl" + "JAGR" + "Blanco"+ "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;

                            label.Text = dr["VALOR"].ToString();
                            label.Font.Bold = true;
                            label.ForeColor = System.Drawing.Color.Blue;

                            var div = new HtmlGenericControl("br");

                            RadioButtonList radioButtonList = new RadioButtonList();
                            string campostr = "rbt" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostr = campostr.Replace(" ", "1sp4c10");
                            campostr = campostr.Replace(",", "C0m4");
                            campostr = campostr.Replace("?", "Pr3gunt4");


                            radioButtonList.ID = campostr;


                            //"rbt" + "JAGR" + "Blanco" + "JAGR" +dr["PREGUNTA"].ToString()+ "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString();
                            dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(plantillaencuesta), Convert.ToInt32(dr["CAMPO"].ToString()));

                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Horizontal;

                            Panel1.Controls.Add(label);
                            Panel1.Controls.Add(radioButtonList);
                            Panel1.Controls.Add(div);
                        }




                    }
                    //Button btnGuardarEncuesta = new Button();
                    //btnGuardarEncuesta.ID = "btnGuardarEncuesta";
                    //btnGuardarEncuesta.Text = "Guardar";
                    //btnGuardarEncuesta.CssClass = "btm";
                    //btnGuardarEncuesta.Click += new EventHandler(btnGuardarEncuesta_Click);

                    //var d = new HtmlGenericControl("br");

                    //Datos.Controls.Add(d);
                    //Datos.Controls.Add(btnGuardarEncuesta);
                }
            }
        }



        public void pintaPlantilla()
        {
            Panel Datos = new Panel();
            Datos.ID = "DatosAlumno";
            Datos.CssClass = "panelDatos";


            string plantillaencuesta = Request.QueryString["Valor"];
            string servicio = Request.QueryString["ValorServicio"];

            DataTable dtpE = DPLANTILLAENCUESTA.traerPlantillaEncuesta(Convert.ToInt32(plantillaencuesta), servicio);



            DataTable dts;



            if (dtpE != null)
            {

                if (dtpE.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtpE.Rows)
                    {

                        if (dr["TIPOREGISTRO"].ToString() == "Pregunta")
                        {
                            Label label = new Label();

                            string campostrlbl = "lbl" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;
                            label.Text = dr["PREGUNTA"].ToString();
                            label.Font.Bold = true;



                            var div = new HtmlGenericControl("br");

                            Datos.Controls.Add(label);
                            Datos.Controls.Add(div);

                        }
                        if (dr["TIPOREGISTRO"].ToString() == "Evaluado" && dr["TIPO"].ToString() == "RadioButton")
                        {

                            Label label = new Label();
                            string campostrlbl = "lbl" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;
                            label.Text = dr["VALOR"].ToString();
                            label.Font.Bold = true;
                            label.ForeColor = System.Drawing.Color.Blue;


                            var div = new HtmlGenericControl("br");

                            RadioButtonList radioButtonList = new RadioButtonList();
                            string campostr = "rbt" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostr = campostr.Replace(" ", "1sp4c10");
                            campostr = campostr.Replace(",", "C0m4");
                            campostr = campostr.Replace("?", "Pr3gunt4");

                            radioButtonList.ID = campostr;
                            //"rbt" + "JAGR" + "Blanco" + "JAGR" +dr["PREGUNTA"].ToString()+ "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString();


                            dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(plantillaencuesta), Convert.ToInt32(dr["CAMPO"].ToString()));




                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Horizontal;




                            Datos.Controls.Add(label);
                            Datos.Controls.Add(radioButtonList);
                            Datos.Controls.Add(div);
                        }
                        if (dr["TIPOREGISTRO"].ToString() == "EvaluadoSerBlanco" && dr["TIPO"].ToString() == "RadioButton")
                        {

                            Label label = new Label();
                            string campostrlbl = "lbl" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;
                            label.Text = dr["PREGUNTA"].ToString();
                            label.Font.Bold = true;


                            var div = new HtmlGenericControl("br");

                            RadioButtonList radioButtonList = new RadioButtonList();
                            string campostr = "rbt" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();

                            campostr = campostr.Replace(" ", "1sp4c10");
                            campostr = campostr.Replace(",", "C0m4");
                            campostr = campostr.Replace("?", "Pr3gunt4");
                            radioButtonList.ID = campostr;

                            //"rbt" + "JAGR" + "Blanco" + "JAGR" +dr["PREGUNTA"].ToString()+ "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString();

                            dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(plantillaencuesta), Convert.ToInt32(dr["CAMPO"].ToString()));

                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Vertical;

                            Datos.Controls.Add(label);
                            Datos.Controls.Add(radioButtonList);
                            Datos.Controls.Add(div);
                        }
                        if (dr["TIPOREGISTRO"].ToString() == "EvaluadoNoBlanco" && dr["TIPO"].ToString() == "RadioButton")
                        {

                            Label label = new Label();
                            string campostrlbl = "lbl" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostrlbl = campostrlbl.Replace(" ", "1sp4c10");
                            campostrlbl = campostrlbl.Replace(",", "C0m4");
                            campostrlbl = campostrlbl.Replace("?", "Pr3gunt4");
                            label.ID = campostrlbl;

                            label.Text = dr["VALOR"].ToString();
                            label.Font.Bold = true;
                            label.ForeColor = System.Drawing.Color.Blue;

                            var div = new HtmlGenericControl("br");

                            RadioButtonList radioButtonList = new RadioButtonList();
                            string campostr = "rbt" + "JAGR" + "Blanco" + "JAGR" + dr["PREGUNTA"].ToString() + "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString() + dr["CNS"].ToString();
                            campostr = campostr.Replace(" ", "1sp4c10");
                            campostr = campostr.Replace(",", "C0m4");
                            campostr = campostr.Replace("?", "Pr3gunt4");


                            radioButtonList.ID = campostr;


                            //"rbt" + "JAGR" + "Blanco" + "JAGR" +dr["PREGUNTA"].ToString()+ "JAGR" + dr["VALOR"].ToString() + "JAGR" + dr["CAMPO"].ToString();
                            dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(plantillaencuesta), Convert.ToInt32(dr["CAMPO"].ToString()));

                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Horizontal;

                            Datos.Controls.Add(label);
                            Datos.Controls.Add(radioButtonList);
                            Datos.Controls.Add(div);
                        }




                    }
                    //Button btnGuardarEncuesta = new Button();
                    //btnGuardarEncuesta.ID = "btnGuardarEncuesta";
                    //btnGuardarEncuesta.Text = "Guardar";
                    //btnGuardarEncuesta.CssClass = "btm";
                    //btnGuardarEncuesta.Click += new EventHandler(btnGuardarEncuesta_Click);

                    //var d = new HtmlGenericControl("br");

                    //Datos.Controls.Add(d);
                    //Datos.Controls.Add(btnGuardarEncuesta);
                }
            }
        }

        protected void btnGuardarEncuesta_Click(object sender, EventArgs e)
        {
            string DocumentoPaciente = Request.QueryString["DocumentoPaciente"];

            if (DocumentoPaciente != "")
            {

                string plantillaencuesta = Request.QueryString["Valor"];
                string servicio = Request.QueryString["ValorServicio"];


                DataTable dtid = DPLANTILLAENCUESTA.traerPlantillaEncuesta(Convert.ToInt32(plantillaencuesta), servicio);

                foreach (DataRow dr in dtid.Rows)
                {


                    if (dr["IDCAMPO"].ToString().StartsWith("rbt"))
                    {
                        RadioButtonList radios = (RadioButtonList)Panel1.FindControl(dr["IDCAMPO"].ToString());

                        if (radios.SelectedIndex > -1)
                        {
                            string seleccionado = radios.ID + "JAGR" + radios.SelectedItem.Text;

                            DRESULTADOENCUESTA.Insertar(seleccionado, DocumentoPaciente, plantillaencuesta);
                        }

                    }
                    


                }

                
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Busque el paciente para guardar la encuesta')</script>");
            }

            Response.Write(@"<script language='javascript'>alert('Encuesta Registrada Correctamente')</script>");

            Response.Redirect("Default.aspx?");
        }
    }
}