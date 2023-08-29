using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encuesta.TipoDatos;
using Encuesta.Datos;
using System.Data;
using System.Web.UI.HtmlControls;


namespace Encuesta.Presentacion
{
    public partial class FrmEjecucionEncuesta : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                traerDatosAfiliado();
                traerEncuestas();
                //pintaPlantilla();

            }

        }

        public void traerDatosAfiliado()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = DAFI.GetAll(txtDocumento.Text);

                if (dt.Rows.Count > 0)
                {
                    txtNombre.Text = dt.Rows[0]["NOMBREAFI"].ToString();
                    txtDocumentoPaciente.Text = dt.Rows[0]["DOCIDAFILIADO"].ToString();
                    txtEdad.Text = dt.Rows[0]["EDAD"].ToString();
                    txtDireccion.Text = dt.Rows[0]["DIRECCION"].ToString();
                    txtTelefono.Text = dt.Rows[0]["TELEFONO"].ToString();
                    txtEAPB.Text = dt.Rows[0]["EAPB"].ToString();
                    txtGrupoPob.Text = dt.Rows[0]["GRUPOPOB"].ToString();
                    cmbServicio.Text = dt.Rows[0]["PROCEDENCIA"].ToString();


                }
                else
                {
                    txtNombre.Text = "";
                    txtDocumentoPaciente.Text = "";
                    txtEdad.Text = "";
                    txtDireccion.Text = "";
                    txtTelefono.Text = "";
                    txtEAPB.Text = "";
                    txtGrupoPob.Text = "";
                    cmbServicio.Text = "No Aplica";
                }


            }
            catch (Exception ex)
            {

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }

        }

        public void traerEncuestas()
        {

            DataTable dtEncuestas =   DPLANTILLAENCUESTA.GetAll();
            if (dtEncuestas != null)
            {


                if (dtEncuestas.Rows.Count > 0)
                {
                    cmbListaEncuestas.DataSource = dtEncuestas;

                    cmbListaEncuestas.DataTextField = "DESCRIPCION";
                    cmbListaEncuestas.DataValueField = "CODPLANTILLAENCUESTA";


                    // Bind the data to the control.
                    cmbListaEncuestas.DataBind();

                    // Set the default selected item, if desired.
                    cmbListaEncuestas.SelectedIndex = 0;

                }
            }


        }
        protected void btnBuscarAfiliado_Click(object sender, ImageClickEventArgs e)
        {
            traerDatosAfiliado();
        }
      

        /*/public void pintaPlantilla()
        {


            DataTable dtpE  = DPLANTILLAENCUESTA.traerPlantillaEncuesta(Convert.ToInt32(cmbListaEncuestas.SelectedValue), cmbServicio.SelectedValue);
               

           
            DataTable dts ;



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

                            phDinamicControls.Controls.Add(label);
                            phDinamicControls.Controls.Add(div);

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


                            if (cmbListaEncuestas.SelectedValue != null)
                            {
                              
                                dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(cmbListaEncuestas.SelectedValue), Convert.ToInt32(dr["CAMPO"].ToString()));              

                            }
                            else
                            {
                                dts = DPLANTILLAENCUESTADVAL.GetAll(1, Convert.ToInt32(dr["CAMPO"].ToString()));

                            }


                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Horizontal;




                            phDinamicControls.Controls.Add(label);
                            phDinamicControls.Controls.Add(radioButtonList);
                            phDinamicControls.Controls.Add(div);
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

                            if (cmbListaEncuestas.SelectedValue != null)
                            {

                                dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(cmbListaEncuestas.SelectedValue), Convert.ToInt32(dr["CAMPO"].ToString()));

                            }
                            else
                            {
                                dts = DPLANTILLAENCUESTADVAL.GetAll(1, Convert.ToInt32(dr["CAMPO"].ToString()));

                            }
                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Vertical;

                            phDinamicControls.Controls.Add(label);
                            phDinamicControls.Controls.Add(radioButtonList);
                            phDinamicControls.Controls.Add(div);
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
                            if (cmbListaEncuestas.SelectedValue == "")
                            {
                                int v = 1;

                                dts = DPLANTILLAENCUESTADVAL.GetAll(v, Convert.ToInt32(dr["CAMPO"].ToString()));

                            }
                            else
                            {

                                dts = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(cmbListaEncuestas.SelectedValue), Convert.ToInt32(dr["CAMPO"].ToString()));

                            }
                            radioButtonList.DataSource = dts;
                            radioButtonList.DataTextField = "DESCRIPCION";
                            radioButtonList.DataValueField = "IDPLANTILLALISTA";

                            // Bind the data to the control.
                            radioButtonList.DataBind();

                            radioButtonList.RepeatDirection = RepeatDirection.Horizontal;

                            phDinamicControls.Controls.Add(label);
                            phDinamicControls.Controls.Add(radioButtonList);
                            phDinamicControls.Controls.Add(div);
                        }
                    }
                }
            }
        } /*/
        protected void cmbServicio_SelectedIndexChanged(object sender, EventArgs e)
        {

            //pintaPlantilla();

        }


        private int QuantityDinamicControls
        {
            get
            {
                return ViewState["Quantity"] != null ? (int)ViewState["Quantity"] : 0;
            }

            set
            {
                ViewState["Quantity"] = value;
            }
        }



        protected void btnGuardarEncuesta_Click(object sender, EventArgs e)
        {
            if (txtDocumentoPaciente.Text != "")
            {

                //string[] controles = HttpContext.Current.Request.Form.AllKeys;

                //for (int i = 0; i < controles.Length; i++)
                //{
                //    if (controles[i].ToUpper().Contains("JAGR"))
                //    {

                //            string StrTexts = null;

                //            StrTexts += controles[i] + "JAGR" + 
                //                HttpContext.Current.Request.Form [i];

                //            DRESULTADOENCUESTA.Insertar(StrTexts, txtDocumentoPaciente.Text, cmbListaEncuestas.SelectedValue);

                //    }



                //}

                /*/   foreach (Control p in phDinamicControls.Controls)
                  {

                      if (p.ID.Contains("JAGR"))
                      {
                          RadioButtonList radios = (RadioButtonList)this.phDinamicControls.FindControl(ID);

                          string seleccionado = radios.ID + "JAGR" + radios.SelectedValue;

                          DRESULTADOENCUESTA.Insertar(seleccionado, txtDocumentoPaciente.Text, cmbListaEncuestas.SelectedValue);

                      }

                  } /*/
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Busque el paciente para guardar la encuesta')</script>");
            }

        }

        protected void btnGenerarEncuesta_Click(object sender, EventArgs e)
        {
            string ValorEncuesta = cmbListaEncuestas.SelectedValue;
            string ValorServicio = cmbServicio.SelectedValue;
            string DocumentoPaciente  = txtDocumentoPaciente.Text;



            Response.Redirect("FrmPintarEncuesta.aspx?Valor=" + ValorEncuesta + "&ValorServicio=" + ValorServicio + "&DocumentoPaciente="+ DocumentoPaciente);
        }
    }
}