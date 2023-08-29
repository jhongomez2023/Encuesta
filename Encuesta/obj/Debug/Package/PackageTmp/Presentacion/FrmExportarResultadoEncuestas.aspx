<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SitePaginPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmExportarResultadoEncuestas.aspx.cs" Inherits="Encuesta.Presentacion.FrmExportarResultadoEncuestas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblFechainicial" runat="server"> Fecha Inicial:</asp:Label> 
    &nbsp;<asp:TextBox ID="txtFechainicial" runat="server"></asp:TextBox>
    <ajaxToolkit:CalendarExtender ID="txtFechainicial_CalendarExtender" runat="server" BehaviorID="txtFechainicial_CalendarExtender" TargetControlID="txtFechainicial"   Format="dd/MM/yyyy">
    </ajaxToolkit:CalendarExtender>
    &nbsp;<asp:Label ID="lblFechaFinal" runat="server"> Fecha Final:</asp:Label> 
    &nbsp;<asp:TextBox ID="txtFechaFinal" runat="server"></asp:TextBox>
     <ajaxToolkit:CalendarExtender ID="txtFechaFinal_CalendarExtender" runat="server" BehaviorID="txtFechaFinal_CalendarExtender" TargetControlID="txtFechaFinal"   Format="dd/MM/yyyy">
    </ajaxToolkit:CalendarExtender>
    &nbsp;
    <asp:DropDownList runat="server" ID="cmbtipoReporte" OnSelectedIndexChanged="cmbtipoReporte_SelectedIndexChanged" AutoPostBack="True" >
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>Resumido</asp:ListItem>
        <asp:ListItem>Detallado</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Button  runat="server" ID="btnGenerarReporte" CssClass="btmGenerar" Text="Generar" OnClick="btnGenerarReporte_Click"/>
    &nbsp;
    <asp:Button  runat="server" ID="btnExportar" CssClass="btmExportar" Text="Exportar" OnClick="btnExportar_Click" />

      <div style="width: 100%; height: 500px; overflow: auto;">
    <asp:GridView ID="gdvResultadoEncuesta" runat="server" CellPadding="4" ForeColor="#333333" Visible="False" AutoGenerateColumns="False"
            GridLines="None" DataKeyNames="FECHA,DOCUMENTO,NOMBREAFI,EDAD,DIRECCION,TELEFONO,EAPB,GRUPOPOB,SERVICIO,PREGUNTA,EVALUADO,VALOR" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>

                <asp:BoundField DataField="FECHA" HeaderText="Fecha"  DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="DOCUMENTO" HeaderText="Documento" />
                <asp:BoundField DataField="NOMBREAFI" HeaderText="Nombre Afiliado" />
                <asp:BoundField DataField="EDAD" HeaderText="Edad" />
                <asp:BoundField DataField="DIRECCION" HeaderText="Direccion" />
                <asp:BoundField DataField="TELEFONO" HeaderText="Telefono" />
                <asp:BoundField DataField="EAPB" HeaderText="EAPB" />
                <asp:BoundField DataField="GRUPOPOB" HeaderText="Grupo Poblacional" />
                <asp:BoundField DataField="SERVICIO" HeaderText="Servicio" />
                <asp:BoundField DataField="PREGUNTA" HeaderText="Pregunta" />
                <asp:BoundField DataField="EVALUADO" HeaderText="Evaluado" />
                <asp:BoundField DataField="VALOR" HeaderText="Respuesta" />


                <%--campo tipo fecha <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" DataFormatString="(0:dd/mm/yyyy)" />--%>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Small" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
              <asp:GridView ID="gdvResultadoEncuestaResumido" runat="server" Visible="false" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
            GridLines="None" DataKeyNames="SERVICIO,PREGUNTA,RESPUESTA,CANT" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>

                <asp:BoundField DataField="SERVICIO" HeaderText="Servicio" />
                <asp:BoundField DataField="PREGUNTA" HeaderText="Pregunta" />
                <asp:BoundField DataField="EVALUADO" HeaderText="Evaluado" />
                <asp:BoundField DataField="RESPUESTA" HeaderText="Respuesta" />
                <asp:BoundField DataField="CANT" HeaderText="Total" />


                <%--campo tipo fecha <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" DataFormatString="(0:dd/mm/yyyy)" />--%>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Small" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small"/>
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>


          </div>
</asp:Content>
