using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encuesta.TipoDatos;
using Encuesta.Datos;
using System.Data;

namespace Encuesta.Presentacion
{
    public partial class FrmEncuesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                traerPlantillasEncuesta();
                traerPlantillasEncuestaD();
                traerPlantillasEncuestadVal();
            }
        }



        public void traerPlantillasEncuesta()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = DPLANTILLAENCUESTA.GetAll();
                GdVPlantillas.DataSource = dt;
                GdVPlantillas.DataBind();


                MostrarGuardarCancelar(false);


            }
            catch (Exception ex)
            {

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }
        }
        public string ValidarDatos()
        {
            string Resultado = "";
            if (txtDescripcion.Text == "")
            {
                Resultado = Resultado + "Descripcion,";
            }


            return Resultado;
        }

        private void MostrarGuardarCancelar(bool b)
        {
            btnGuardar.Visible = b;
            btnCancelar.Visible = b;
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;
            // btnEliminar.Visible = !b;

            GdVPlantillas.Enabled = !b;


            txtDescripcion.Enabled = b;


        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
            PanelCrud.Visible = true;
            txtDescripcion.Text = "";
            txtIdPlantillaEncuesta.Text = "";
            

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdPlantillaEncuesta.Text != "")
            {
                MostrarGuardarCancelar(true);
                PanelCrud.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            PanelCrud.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultado = ValidarDatos();
                if (sResultado == "")
                {

                    if (txtIdPlantillaEncuesta.Text == "")
                    {


                        PLANTILLAENCUESTA plantillaencuesta = new PLANTILLAENCUESTA();
                        plantillaencuesta.DESCRIPCION = txtDescripcion.Text;


                        DPLANTILLAENCUESTA.Insertar(plantillaencuesta);

                        Response.Write(@"<script language='javascript'>alert('Datos guardados Correctamente')</script>");
                        traerPlantillasEncuesta();
                        PanelCrud.Visible = false;


                    }
                    else
                    {
                        PLANTILLAENCUESTA plantillaencuesta = new PLANTILLAENCUESTA();
                        plantillaencuesta.DESCRIPCION = txtDescripcion.Text;
                        plantillaencuesta.CODPLANTILLAENCUESTA = Convert.ToInt32(txtIdPlantillaEncuesta.Text);



                        DPLANTILLAENCUESTA.Actualizar(plantillaencuesta);

                        Response.Write(@"<script language='javascript'>alert('Datos Actualizados Correctamente')</script>");
                        traerPlantillasEncuesta();
                        PanelCrud.Visible = false;


                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('" + "Faltan llenar: " + sResultado + "')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }
        }

        protected void GdVPlantillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GdVPlantillas.SelectedRow;

            //
            // Obtengo el id y el nombre  de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            string id = Convert.ToString(GdVPlantillas.DataKeys[row.RowIndex].Values["CODPLANTILLAENCUESTA"]);

            string nombre = Convert.ToString(GdVPlantillas.DataKeys[row.RowIndex].Values["DESCRIPCION"]);


            txtIdPlantillaEncuesta.Text = id;
            txtDescripcion.Text = nombre;
            if (txtIdPlantillaEncuesta.Text != "")
            {
                traerPlantillasEncuestaD();

                PanelTituloDetalle.Visible = true;
                panelGrilladetalle.Visible = true;
                txtCodPlantillaEncuesta.Text = id;
            }

            gdvplantillalista.DataSource = "";
            gdvplantillalista.DataBind();
        }

        protected void GdVPlantillas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //
                // Se obtiene indice de la row seleccionada
                //
                int index = Convert.ToInt32(e.CommandArgument);

                //
                // Obtengo el id de la entidad que se esta editando
                // en este caso de la entidad Person
                //
                int id = Convert.ToInt32(GdVPlantillas.DataKeys[index].Value);

            }
        }
        private void MostrarGuardarCancelarDetalle(bool b)
        {
            btnGuardarDetalle.Visible = b;
            btnCancelarDetalle.Visible = b;
            btnNuevoDetalle.Visible = !b;
            btnEditarDetalle.Visible = !b;
            // btnEliminar.Visible = !b;

            gdvPlantillaD.Enabled = !b;


            txtEvaluado.Enabled = b;
            cmbServicio.Enabled = b;
            txtPregunta.Enabled = b;
            txtTipo.Enabled = b;
            txtOrden.Enabled = b;





        }
        public void traerPlantillasEncuestaD()
        {
            try
            {
                DataTable dtencuestad = new DataTable();

                dtencuestad = DPLANTILLAENCUESTAD.GetAll(Convert.ToInt32(txtIdPlantillaEncuesta.Text));
                gdvPlantillaD.DataSource = dtencuestad;
                gdvPlantillaD.DataBind();


                MostrarGuardarCancelarDetalle(false);


            }
            catch (Exception ex)
            {

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }
        }


        protected void btnNuevoDetalle_Click(object sender, EventArgs e)
        {
            if (txtIdPlantillaEncuesta.Text != "")
            {
                MostrarGuardarCancelarDetalle(true);
                pnldetalleencuesta.Visible = true;
                txtOrden.Text = "0";               
                txtEvaluado.Text = "";
                cmbServicio.Text = "";
                txtPregunta.Text = "";
                txtCodCampo.Text = "";
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Seleccione una plantilla para agregar detalle')</script>");
            }

        }

        protected void btnEditarDetalle_Click(object sender, EventArgs e)
        {
            if (txtCodCampo.Text != "")
            {
                MostrarGuardarCancelarDetalle(true);
                pnldetalleencuesta.Visible = true;
            }
           

        }
        public string ValidarDatosDetalle()
        {
            string Resultado = "";
            if (txtPregunta.Text == "")
            {
                Resultado = Resultado + "Pregunta, ";
            }
            


            return Resultado;
        }

        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultado = ValidarDatosDetalle();
                if (sResultado == "")
                {

                    if (txtCodCampo.Text == "")
                    {


                        PLANTILLAENCUESTAD plantillaencuestad = new PLANTILLAENCUESTAD();
                        plantillaencuestad.CODPLANTILLAENCUESTA = Convert.ToInt32(txtCodPlantillaEncuesta.Text);
                        plantillaencuestad.ORDEN = Convert.ToInt32(txtOrden.Text);
                        plantillaencuestad.SERVICIO = cmbServicio.SelectedValue;
                        plantillaencuestad.PREGUNTA = txtPregunta.Text;
                        plantillaencuestad.EVALUADO = txtEvaluado.Text;
                        plantillaencuestad.TIPO = txtTipo.SelectedValue;

                        DPLANTILLAENCUESTAD.Insertar(plantillaencuestad);

                        Response.Write(@"<script language='javascript'>alert('Datos guardados Correctamente')</script>");
                        traerPlantillasEncuestaD();
                        pnldetalleencuesta.Visible = false;


                    }
                    else
                    {
                        PLANTILLAENCUESTAD plantillaencuestad = new PLANTILLAENCUESTAD();
                        plantillaencuestad.CODPLANTILLAENCUESTA = Convert.ToInt32( txtCodPlantillaEncuesta.Text);
                        plantillaencuestad.CAMPO = Convert.ToInt32(txtCodCampo.Text);
                        plantillaencuestad.ORDEN = Convert.ToInt32(txtOrden.Text);
                        plantillaencuestad.SERVICIO = cmbServicio.SelectedValue;
                        plantillaencuestad.PREGUNTA = txtPregunta.Text;
                        plantillaencuestad.EVALUADO = txtEvaluado.Text;
                        plantillaencuestad.TIPO = txtTipo.SelectedValue;



                        DPLANTILLAENCUESTAD.Actualizar(plantillaencuestad);

                        Response.Write(@"<script language='javascript'>alert('Datos Actualizados Correctamente')</script>");
                        traerPlantillasEncuestaD();
                        pnldetalleencuesta.Visible = false;


                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('" + "Faltan llenar: " + sResultado + "')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }

        }

        protected void btnCancelarDetalle_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelarDetalle(false);
            pnldetalleencuesta.Visible = false;
        }

        protected void gdvPlantillaD_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gdvPlantillaD.SelectedRow;

            //
            // Obtengo el id y el nombre  de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            string id = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["CODPLANTILLAENCUESTA"]);
            string codCampo = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["CAMPO"]);
            string orden = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["ORDEN"]);
            string servicio = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["SERVICIO"]);
            string pregunta = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["PREGUNTA"]);
            string evaluado = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["EVALUADO"]);
            string tipo = Convert.ToString(gdvPlantillaD.DataKeys[row.RowIndex].Values["TIPO"]);




            txtCodPlantillaEncuesta.Text = id;
            txtCodCampo.Text = codCampo;
            txtOrden.Text = orden;
            cmbServicio.SelectedValue = servicio;
            txtPregunta.Text = pregunta;
            txtEvaluado.Text = evaluado;
            txtTipo.SelectedValue = tipo;

            if (tipo == "Lista" || tipo == "RadioButton")
            {

                txtCodPlantillaEncuestaLista.Text = id;
                txtCodCampoEncuestaLista.Text = codCampo;
            traerPlantillasEncuestadVal();
                Panelbotoneslista.Visible = true;
            }


        }

        protected void gdvplantillalista_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gdvplantillalista.SelectedRow;

            //
            // Obtengo el id y el nombre  de la entidad que se esta editando
            // en este caso de la entidad Person
            //
            string idlista = Convert.ToString(gdvplantillalista.DataKeys[row.RowIndex].Values["IDPLANTILLALISTA"]);
            string id = Convert.ToString(gdvplantillalista.DataKeys[row.RowIndex].Values["CODPLANTILLAENCUESTA"]);
            string codCampo = Convert.ToString(gdvplantillalista.DataKeys[row.RowIndex].Values["CAMPO"]);
            string descripcionlista = Convert.ToString(gdvplantillalista.DataKeys[row.RowIndex].Values["DESCRIPCION"]);



            txtIdlista.Text = idlista;
            txtCodPlantillaEncuestaLista.Text = id;
            txtCodCampoEncuestaLista.Text = codCampo;
            txtDescripcionLista.Text = descripcionlista;
        }


        private void MostrarGuardarCancelarDetalleLista(bool b)
        {
            btnGuardarLista.Visible = b;
            btnCancelarLista.Visible = b;
            btnNuevolista.Visible = !b;
            btnEditarlista.Visible = !b;
            // btnEliminar.Visible = !b;

            gdvplantillalista.Enabled = !b;


            txtDescripcionLista.Enabled = b;
            


        }
        public void traerPlantillasEncuestadVal()
        {
            try
            {
                DataTable dt = new DataTable();

                dt = DPLANTILLAENCUESTADVAL.GetAll(Convert.ToInt32(txtCodPlantillaEncuestaLista.Text), Convert.ToInt32(txtCodCampoEncuestaLista.Text));
                gdvplantillalista.DataSource = dt;
                gdvplantillalista.DataBind();


                MostrarGuardarCancelarDetalleLista(false);


            }
            catch (Exception ex)
            {

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }
        }
        protected void btnNuevolista_Click(object sender, EventArgs e)
        {
            if (txtCodCampoEncuestaLista.Text != "" && txtCodPlantillaEncuestaLista.Text != "")
            {
                MostrarGuardarCancelarDetalleLista(true);
                pnldetallelista.Visible = true;
                txtIdlista.Text = "";
                txtIdPlantillaEncuesta.Text = "";
                txtDescripcionLista.Text = "";
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Seleccione una campo para agregar lista')</script>");
            }
        }

        protected void btnEditarlista_Click(object sender, EventArgs e)
        {
            if (txtIdlista.Text != "")
            {
                MostrarGuardarCancelarDetalleLista(true);
                pnldetallelista.Visible = true;
            }
        }
        public string ValidarDatosDetalleLista()
        {
            string Resultado = "";
            if (txtDescripcionLista.Text == "")
            {
                Resultado = Resultado + "Descripcion Lista, ";
            }



            return Resultado;
        }
        protected void btnGuardarLista_Click(object sender, EventArgs e)
        {

            try
            {
                string sResultado = ValidarDatosDetalleLista();
                if (sResultado == "")
                {

                    if (txtIdlista.Text == "")
                    {


                        PLANTILLAENCUESTADVAL plantillaencuestadval = new PLANTILLAENCUESTADVAL();
                        plantillaencuestadval.CODPLANTILLAENCUESTA = Convert.ToInt32(txtCodPlantillaEncuestaLista.Text);
                        plantillaencuestadval.CAMPO = Convert.ToInt32(txtCodCampoEncuestaLista.Text);
                        plantillaencuestadval.DESCRIPCION = txtDescripcionLista.Text;

                        DPLANTILLAENCUESTADVAL.Insertar(plantillaencuestadval);

                        Response.Write(@"<script language='javascript'>alert('Datos guardados Correctamente')</script>");
                        traerPlantillasEncuestadVal();
                        pnldetallelista.Visible = false;


                    }
                    else
                    {
                        PLANTILLAENCUESTADVAL plantillaencuestadval = new PLANTILLAENCUESTADVAL();
                        plantillaencuestadval.IDPLANTILLALISTA = Convert.ToInt32(txtIdlista.Text);
                        plantillaencuestadval.CODPLANTILLAENCUESTA = Convert.ToInt32(txtCodPlantillaEncuestaLista.Text);
                        plantillaencuestadval.CAMPO = Convert.ToInt32(txtCodCampoEncuestaLista.Text);
                        plantillaencuestadval.DESCRIPCION = txtDescripcionLista.Text;

                        DPLANTILLAENCUESTADVAL.Actualizar(plantillaencuestadval);

                        Response.Write(@"<script language='javascript'>alert('Datos Actualizados Correctamente')</script>");
                        traerPlantillasEncuestadVal();
                        pnldetallelista.Visible = false;


                    }
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('" + "Faltan llenar: " + sResultado + "')</script>");

                }
            }
            catch (Exception ex)
            {
                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }
        }

        protected void btnCancelarLista_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelarDetalleLista(false);
            pnldetallelista.Visible = false;
        }
    }
}