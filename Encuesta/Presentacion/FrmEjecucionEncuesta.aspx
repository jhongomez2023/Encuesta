<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SitePaginPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmEjecucionEncuesta.aspx.cs" Inherits="Encuesta.Presentacion.FrmEjecucionEncuesta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Digitar Encuesta</h1>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Buscar Paciente:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:ImageButton ID="btnBuscarAfiliado" runat="server" ImageUrl="~/Presentacion/Imagenes/xmag_search_find_export_locate_5984.png" OnClick="btnBuscarAfiliado_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Nombre y Apellidos: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtNombre" Enabled="false" runat="server" Width="388px"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Documento: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtDocumentoPaciente" Enabled="false" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Edad: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtEdad" Enabled="false" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Direccion: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtDireccion" Enabled="false" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Telefono: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtTelefono" Enabled="false" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="EAPB: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtEAPB" Enabled="false" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Poblacion Diferencial: "></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtGrupoPob" Enabled="false" runat="server"></asp:TextBox>

            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <b>Seleccione la Encuesta a Realizar: </b>
            </td>
            <td>
                <asp:DropDownList ID="cmbListaEncuestas" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="Label9" runat="server" Text="Servicio:" Font-Bold="True"></asp:Label>

            </td>
            <td>
                <asp:DropDownList ID="cmbServicio" runat="server" OnSelectedIndexChanged="cmbServicio_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>No Aplica</asp:ListItem>
                    <asp:ListItem>Urgencia</asp:ListItem>
                    <asp:ListItem>Cirugia</asp:ListItem>
                    <asp:ListItem>Hospitalizacion</asp:ListItem>
                    <asp:ListItem>Uci</asp:ListItem>
                    <asp:ListItem>Consulta Externa</asp:ListItem>
                </asp:DropDownList>
            </td>

        </tr>


    </table>
    <br />
    <br />

         <%--   <asp:Panel runat="server" ID="pnlPintarEncuesta" ScrollBars="Both" Height="300" BorderColor="#000000" BorderStyle="Ridge" >

            </asp:Panel>--%>
 
                        <%--<asp:Button runat="server" ID="btnGuardarEncuesta" Text="Guardar" class="btm" OnClick="btnGuardarEncuesta_Click" />--%>
                        <asp:Button runat="server" ID="btnGenerarEncuesta" Text="Generar Encuesta" class="btm" OnClick="btnGenerarEncuesta_Click"  />



</asp:Content>
