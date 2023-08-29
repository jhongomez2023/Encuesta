using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Encuesta.Datos;

namespace Encuesta.Presentacion
{
    public partial class FrmGraficas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    
        protected  string  ObtenerDatosEAPB()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            
            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosEmpresa(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;
            srtString = "[['EAPB','Total'],";

            foreach (DataRow dr in dtEapb.Rows)
            {

                srtString = srtString + "[";
                srtString = srtString + "'"+dr["EAPB"] +"'"+","+dr["Total"];
                srtString = srtString + "],";

            }
            srtString = srtString + "]";
            return srtString;
        }
        protected string ObtenerDatosGrupoPob()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosGrupoPob(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;
            srtString = "[['GRUPOPOB','Total'],";

            foreach (DataRow dr in dtEapb.Rows)
            {

                srtString = srtString + "[";
                srtString = srtString + "'" + dr["GRUPOPOB"] + "'" + "," + dr["Total"];
                srtString = srtString + "],";

            }
            srtString = srtString + "]";
            return srtString;
        }
        protected string ObtenerDatosPregunta()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosPregunta(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['PREGUNTA','SI','NO','Definitivo SI','Definitivo NO','Probablemente SI','Probablemente NO'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";

                srtString = srtString + "'" + dr["PREGUNTA"] + "'" + "," + dr["SI"]+ "," + dr["NO"] + "," + dr["Definitivo SI"] + "," + dr["Definitivo NO"] + "," 
                    + dr["Probablemente SI"] + "," + dr["Probablemente NO"];
                srtString = srtString + "],";

            }
            srtString = srtString + "]";
            return srtString;
        }

        protected string ObtenerDatosServicioUrgencia()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosServicioUrgencia(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['EVALUADO','Muy Buena','Buena','Regular','Malo','Muy Malo'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";
                srtString = srtString + "'" + dr["EVALUADO"] + "'" + "," + dr["Muy Buena"] + "," + dr["Buena"] + "," + dr["Regular"] + "," + dr["Malo"] + "," + dr["Muy Malo"];
                srtString = srtString + "],";
            }
            srtString = srtString + "]";
            return srtString;
        }
        protected string ObtenerDatosServicioUci()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosServicioUci(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['EVALUADO','Muy Buena','Buena','Regular','Malo','Muy Malo'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";
                srtString = srtString + "'" + dr["EVALUADO"] + "'" + "," + dr["Muy Buena"] + "," + dr["Buena"] + "," + dr["Regular"] + "," + dr["Malo"] + "," + dr["Muy Malo"];
                srtString = srtString + "],";
            }
            srtString = srtString + "]";
            return srtString;
        }

        protected string ObtenerDatosServicioConsultaExterna()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosServicioConsultaExterna(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['EVALUADO','Muy Buena','Buena','Regular','Malo','Muy Malo'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";
                srtString = srtString + "'" + dr["EVALUADO"] + "'" + "," + dr["Muy Buena"] + "," + dr["Buena"] + "," + dr["Regular"] + "," + dr["Malo"] + "," + dr["Muy Malo"];
                srtString = srtString + "],";
            }
            srtString = srtString + "]";
            return srtString;
        }

        protected string ObtenerDatosServicioCirugia()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosServicioCirugia(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['EVALUADO','Muy Buena','Buena','Regular','Malo','Muy Malo'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";
                srtString = srtString + "'" + dr["EVALUADO"] + "'" + "," + dr["Muy Buena"] + "," + dr["Buena"] + "," + dr["Regular"] + "," + dr["Malo"] + "," + dr["Muy Malo"];
                srtString = srtString + "],";
            }
            srtString = srtString + "]";
            return srtString;
        }

        protected string ObtenerDatosServicioHospitalizacion()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosServicioHospitalizacion(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['EVALUADO','Muy Buena','Buena','Regular','Malo','Muy Malo'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";
                srtString = srtString + "'" + dr["EVALUADO"] + "'" + "," + dr["Muy Buena"] + "," + dr["Buena"] + "," + dr["Regular"] + "," + dr["Malo"] + "," + dr["Muy Malo"];
                srtString = srtString + "],";
            }
            srtString = srtString + "]";
            return srtString;
        }
        protected string ObtenerDatosOtrosEvaluados()
        {
            if (txtFechainicial.Text == "")

            {

                txtFechainicial.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            if (txtFechaFinal.Text == "")

            {

                txtFechaFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");


            }
            DataTable dtEapb = DPLANTILLAENCUESTA.graficaAfiEncuestadosOtrosEvaluados(Convert.ToDateTime(txtFechainicial.Text), Convert.ToDateTime(txtFechaFinal.Text));

            string srtString;

            srtString = "[['EVALUADO','Muy Buena','Buena','Regular','Malo','Muy Malo'],";

            foreach (DataRow dr in dtEapb.Rows)
            {
                srtString = srtString + "[";
                srtString = srtString + "'" + dr["EVALUADO"] + "'" + "," + dr["Muy Buena"] + "," + dr["Buena"] + "," + dr["Regular"] + "," + dr["Malo"] + "," + dr["Muy Malo"];
                srtString = srtString + "],";
            }
            srtString = srtString + "]";
            return srtString;
        }






        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {

            pnlgraficas.Visible = true;
        }
    }
}