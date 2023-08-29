using System;
using Encuesta.Datos;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Encuesta.Presentacion
{
    public partial class FrmExportarResultadoEncuestas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        public void traerResultados()
        {

            try
            {

                DataTable dtResult = DPLANTILLAENCUESTA.GetAllResultado(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));
                gdvResultadoEncuesta.DataSource = dtResult;
                gdvResultadoEncuesta.DataBind();




            }
            catch (Exception ex)
            {

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }

        }
        public void traerResultadosResumido()
        {

            try
            {

                DataTable dtResult = DPLANTILLAENCUESTA.GetAllResultadoResumido(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));
                gdvResultadoEncuestaResumido.DataSource = dtResult;
                gdvResultadoEncuestaResumido.DataBind();




            }
            catch (Exception ex)
            {

                Response.Write(@"<script language='javascript'>alert('" + ex.Message + ex.StackTrace + "')</script>");

            }

        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cmbtipoReporte.Text == "")
            {
                Response.Write(@"<script language='javascript'>alert('Seleccione el tipo de reporte')</script>");
            }
            else
            {
                if (gdvResultadoEncuesta.Visible == true)
                {
                    traerResultados();


                }
                if (gdvResultadoEncuestaResumido.Visible == true)
                {
                    traerResultadosResumido();

                }

            }
        
            

        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            

            if (cmbtipoReporte.Text == "Resumido")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename = ResultadoEncuestas.xls");
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWriter = new System.IO.StringWriter();

                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                gdvResultadoEncuestaResumido.RenderControl(htmlTextWriter);
                Response.Write(stringWriter.ToString());

                Response.End();
            }
            else if (cmbtipoReporte.Text == "Detallado")
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename = ResultadoEncuestas.xls");
                Response.ContentType = "application/vnd.xls";

                System.IO.StringWriter stringWriter = new System.IO.StringWriter();

                HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
                gdvResultadoEncuesta.RenderControl(htmlTextWriter);
                Response.Write(stringWriter.ToString());

                Response.End();
            }
            else
            {

                Response.Write(@"<script language='javascript'>alert('Seleccione un tipo de reporte a Exportar')</script>");
            }

           
         
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void cmbtipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbtipoReporte.Text == "Resumido")
            {

                gdvResultadoEncuestaResumido.Visible = true;

            }
            else
            {
                gdvResultadoEncuestaResumido.Visible = false;
            }

            if (cmbtipoReporte.Text == "Detallado")
            {

                gdvResultadoEncuesta.Visible = true;

            }
            else
            {
                gdvResultadoEncuesta.Visible = false;
            }
        }
    }
}