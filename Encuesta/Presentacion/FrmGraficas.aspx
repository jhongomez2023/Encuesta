<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SitePaginPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmGraficas.aspx.cs" Inherits="Encuesta.Presentacion.FrmGraficas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <%--imprimir panel--%>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlgraficas.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Graficas Encuestas</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <%--GRAFICA EAPB--%>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable(<%=ObtenerDatosEAPB()%>);

            var options = {
                title: 'EAPB'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechartEapb'));

            chart.draw(data, options);
        }
    </script>
    <%--GRAFICA GRUPOPOB--%>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable(<%=ObtenerDatosGrupoPob()%>);

            var options = {
                title: 'Grupo Poblacional'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechartGrupoPob'));

            chart.draw(data, options);
        }
    </script>
     <%--GRAFICA DE SOLO PREGUNTAS CON EVALUACION--%>
    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawStacked);

        function drawStacked() {

            var data = google.visualization.arrayToDataTable(<%=ObtenerDatosOtrosEvaluados()%>);


            var options = {
                title: 'Respuestas',
                chartArea: { width: '50%' },
                isStacked: true,
                hAxis: {
                    title: 'Total Respuestas',
                    minValue: 0,
                },
                vAxis: {
                    title: 'Preguntas'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('piechartOtros'));

            chart.draw(data, options);

        }
    </script>
    <%--GRAFICA DE SOLO PREGUNTAS--%>
    <script type="text/javascript">
            google.charts.load('current', { packages: ['corechart', 'bar'] });
            google.charts.setOnLoadCallback(drawStacked);

            function drawStacked() {

                var data = google.visualization.arrayToDataTable(<%=ObtenerDatosPregunta()%>);


                var options = {
                    title: 'Respuestas',
                    chartArea: { width: '50%' },
                    isStacked: true,
                    hAxis: {
                        title: 'Total Respuestas',
                        minValue: 0,
                    },
                    vAxis: {
                        title: 'Preguntas'
                    }
                };

                var chart = new google.visualization.BarChart(document.getElementById('piechartPregunta'));

                chart.draw(data, options);

            }
        </script>
    <%--GRAFICA DE SERVICIO URGENCIAS--%>
    <script type="text/javascript">
            google.charts.load('current', { packages: ['corechart', 'bar'] });
            google.charts.setOnLoadCallback(drawStacked);

            function drawStacked() {

                var data = google.visualization.arrayToDataTable(<%=ObtenerDatosServicioUrgencia()%>);


                var options = {
                    title: 'Servicio Urgencias',
                    chartArea: { width: '50%' },
                    isStacked: true,
                    hAxis: {
                        title: 'Total Respuestas',
                        minValue: 0,
                    },
                    vAxis: {
                        title: 'Evaluado'
                    }
                };

                var chart = new google.visualization.BarChart(document.getElementById('piechartServicioUrgencias'));

                chart.draw(data, options);

            }
        </script>
    <%--GRAFICA DE HOSPITALIZACION--%>
    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawStacked);

        function drawStacked() {

            var data = google.visualization.arrayToDataTable(<%=ObtenerDatosServicioHospitalizacion()%>);


            var options = {
                title: 'Servicio Hospitalizacion',
                chartArea: { width: '50%' },
                isStacked: true,
                hAxis: {
                    title: 'Total Respuestas',
                    minValue: 0,
                },
                vAxis: {
                    title: 'Evaluado'
                }
            };

            var chart = new google.visualization.BarChart(document.getElementById('piechartServicioHospitalizacion'));

            chart.draw(data, options);

        }
    </script>
    <%--GRAFICA DE UCI--%>
    <script type="text/javascript">
         google.charts.load('current', { packages: ['corechart', 'bar'] });
         google.charts.setOnLoadCallback(drawStacked);

         function drawStacked() {

             var data = google.visualization.arrayToDataTable(<%=ObtenerDatosServicioUci()%>);


             var options = {
                 title: 'Servicio UCI',
                 chartArea: { width: '50%' },
                 isStacked: true,
                 hAxis: {
                     title: 'Total Respuestas',
                     minValue: 0,
                 },
                 vAxis: {
                     title: 'Evaluado'
                 }
             };

             var chart = new google.visualization.BarChart(document.getElementById('piechartServicioUci'));

             chart.draw(data, options);

         }
     </script>
    <%--GRAFICA DE Cirugia--%>
     <script type="text/javascript">
         google.charts.load('current', { packages: ['corechart', 'bar'] });
         google.charts.setOnLoadCallback(drawStacked);

         function drawStacked() {

             var data = google.visualization.arrayToDataTable(<%=ObtenerDatosServicioCirugia()%>);


             var options = {
                 title: 'Servicio Cirugia',
                 chartArea: { width: '50%' },
                 isStacked: true,
                 hAxis: {
                     title: 'Total Respuestas',
                     minValue: 0,
                 },
                 vAxis: {
                     title: 'Evaluado'
                 }
             };

             var chart = new google.visualization.BarChart(document.getElementById('piechartServicioCirugia'));

             chart.draw(data, options);

         }
     </script>
    <%--GRAFICA DE CONSULTA EXTERNA--%>
     <script type="text/javascript">
         google.charts.load('current', { packages: ['corechart', 'bar'] });
         google.charts.setOnLoadCallback(drawStacked);

         function drawStacked() {

             var data = google.visualization.arrayToDataTable(<%=ObtenerDatosServicioConsultaExterna()%>);


             var options = {
                 title: 'Servicio Consulta Externa',
                 chartArea: { width: '50%' },
                 isStacked: true,
                 hAxis: {
                     title: 'Total Respuestas',
                     minValue: 0,
                 },
                 vAxis: {
                     title: 'Evaluado'
                 }
             };

             var chart = new google.visualization.BarChart(document.getElementById('piechartServicioConsultaExterna'));

             chart.draw(data, options);

         }
     </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblFechainicial" runat="server">Fecha Inicial:</asp:Label>
    &nbsp;<asp:TextBox ID="txtFechainicial" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtFechainicial_CalendarExtender" runat="server" BehaviorID="txtFechainicial_CalendarExtender" TargetControlID="txtFechainicial" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
    &nbsp;<asp:Label ID="lblFechaFinal" runat="server"> Fecha Final:</asp:Label>
    &nbsp;<asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" BehaviorID="txtFechaFinal_CalendarExtender" TargetControlID="txtFechaFinal" Format="dd/MM/yyyy"></ajaxToolkit:CalendarExtender>
    &nbsp;
    &nbsp;
    <asp:Button runat="server" ID="btnGenerarReporte" CssClass="btmGenerar" Text="Generar" OnClick="btnGenerarReporte_Click" />
    &nbsp;
    &nbsp;<asp:Button ID="btnPrint" class="btmImprimir" runat="server" Text="Print" OnClientClick="return PrintPanel();" />
    <asp:Panel ID="pnlgraficas" ScrollBars="Both" Height="600" Visible="false" runat="server">

        <div id="piechartEapb" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartGrupoPob" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartOtros" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartPregunta" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartServicioUrgencias" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartServicioHospitalizacion" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartServicioUci" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartServicioCirugia" class="bordesdivGrafica"></div>
        <br />
        <div id="piechartServicioConsultaExterna" class="bordesdivGrafica"></div>

    </asp:Panel>
</asp:Content>
