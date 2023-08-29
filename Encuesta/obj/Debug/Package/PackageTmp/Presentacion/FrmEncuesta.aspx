<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SitePaginPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmEncuesta.aspx.cs" Inherits="Encuesta.Presentacion.FrmEncuesta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Configurar Plantilla </h1>
    <panel id="PanelCrud" runat="server" visible="false">
        <table>

            <tr>
                <td>
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="312px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtIdPlantillaEncuesta" runat="server" Visible="false" Enabled="false"></asp:TextBox>
                </td>

            </tr>
        </table>

    </panel>
    <table>
        <tr>

            <td>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
            </td>
            <td>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            </td>
            <td>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

            </td>
        </tr>
    </table>

    <div style="width: 100%; height: 100px; overflow: auto;">
        <asp:GridView ID="GdVPlantillas" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false"
            GridLines="None" DataKeyNames="CODPLANTILLAENCUESTA,DESCRIPCION"
            OnSelectedIndexChanged="GdVPlantillas_SelectedIndexChanged"
            OnRowCommand="GdVPlantillas_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center">


                    <ItemTemplate>
                        <asp:ImageButton ID="imgSeleccion" runat="server"
                            CommandName="Select" ImageUrl="~/Presentacion/Imagenes/select_ok_accept_15254 (1).png"
                            CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CODPLANTILLAENCUESTA" HeaderText="Cod Plantilla" />
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
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
    <asp:Panel ID="PanelTituloDetalle" runat="server" Visible="false">
        <h1>Configurar Detalle de la Plantilla </h1>

    </asp:Panel>
    <asp:Panel ID="pnldetalleencuesta" runat="server" Visible="false">


        <table>

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Cod. Plantilla"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtCodPlantillaEncuesta" runat="server" Enabled="False"></asp:TextBox>
                </td>

            </tr>

            <tr>

                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cod. Campo"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtCodCampo" Enabled="false" runat="server"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Orden"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtOrden" runat="server" TextMode="Number">0</asp:TextBox>
                    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" />

                    <asp:TextBox ID="txtOrden" runat="server"></asp:TextBox>

                    <ajaxToolkit:NumericUpDownExtender ID="txtOrden_NumericUpDownExtender" runat="server"
                        BehaviorID="txtOrden_NumericUpDownExtender" Maximum="1.7976931348623157E+308" Minimum="0" RefValues=""
                        ServiceDownMethod="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtOrden" Width="100" />--%>

                </td>


            </tr>

            <tr>

                <td>
                    <asp:Label ID="Label4" runat="server" Text="Servicio"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="cmbServicio" runat="server">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Urgencia</asp:ListItem>
                        <asp:ListItem>Cirugia</asp:ListItem>
                        <asp:ListItem>Hospitalizacion</asp:ListItem>
                        <asp:ListItem>Uci</asp:ListItem>
                        <asp:ListItem>Consulta Externa</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>

                <td>
                    <asp:Label ID="Label5" runat="server" Text="Pregunta"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtPregunta" runat="server" TextMode="MultiLine" Width="352px"></asp:TextBox>
                </td>

            </tr>
            <tr>

                <td>
                    <asp:Label ID="Label6" runat="server" Text="Evaluado"></asp:Label>

                </td>
                <td>
                    <asp:TextBox ID="txtEvaluado" runat="server" TextMode="MultiLine" Width="351px"></asp:TextBox>
                </td>

            </tr>
            <tr>

                <td>
                    <asp:Label ID="Label7" runat="server" Text="Tipo"></asp:Label>

                </td>
                <td>
                    <asp:DropDownList ID="txtTipo" runat="server">
                        <asp:ListItem>Alfanumerico</asp:ListItem>
                        <asp:ListItem>Memo</asp:ListItem>
                        <asp:ListItem>RadioButton</asp:ListItem>
                        <asp:ListItem>Lista</asp:ListItem>
                    </asp:DropDownList>
                </td>

            </tr>
        </table>

    </asp:Panel>
    <asp:Panel ID="panelGrilladetalle" runat="server" Visible="false">
        <table>
            <tr>

                <td>
                    <asp:Button ID="btnNuevoDetalle" runat="server" Text="Nuevo" OnClick="btnNuevoDetalle_Click" />
                </td>
                <td>
                    <asp:Button ID="btnEditarDetalle" runat="server" Text="Editar" OnClick="btnEditarDetalle_Click" />
                </td>
                <td>
                    <asp:Button ID="btnGuardarDetalle" runat="server" Text="Guardar" OnClick="btnGuardarDetalle_Click" />

                </td>
                <td>
                    <asp:Button ID="btnCancelarDetalle" runat="server" Text="Cancelar" OnClick="btnCancelarDetalle_Click" />

                </td>
            </tr>
        </table>

        <div class="wrapper">
            
            <div style="width: 100%; height: 300px; overflow: auto;">
                <asp:GridView ID="gdvPlantillaD" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false"
                    GridLines="None" DataKeyNames="CODPLANTILLAENCUESTA,CAMPO,ORDEN,SERVICIO,PREGUNTA,EVALUADO,TIPO" OnSelectedIndexChanged="gdvPlantillaD_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center">


                            <ItemTemplate>
                                <asp:ImageButton ID="imgSeleccion" runat="server"
                                    CommandName="Select" ImageUrl="~/Presentacion/Imagenes/select_ok_accept_15254 (1).png"
                                    CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CODPLANTILLAENCUESTA" HeaderText="Cod Plantilla" />
                        <asp:BoundField DataField="CAMPO" HeaderText="Cod. Campo" />
                        <asp:BoundField DataField="ORDEN" HeaderText="Orden" />
                        <asp:BoundField DataField="SERVICIO" HeaderText="Servicio" />
                        <asp:BoundField DataField="PREGUNTA" HeaderText="Pregunta" />
                        <asp:BoundField DataField="EVALUADO" HeaderText="Evaluado" />
                        <asp:BoundField DataField="TIPO" HeaderText="Tipo Campo" />

                        <%--campo tipo fecha <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" DataFormatString="(0:dd/mm/yyyy)" />--%>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>



            </div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:Panel ID="pnldetallelista" runat="server" Visible="false">
                                <h2>Agregar Lista</h2>
                                <asp:Label ID="Label8" runat="server" Text="Descripcion"></asp:Label>
                                &nbsp;<asp:TextBox ID="txtDescripcionLista" runat="server"></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtIdlista" runat="server" Visible="false"></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtCodPlantillaEncuestaLista" runat="server" Visible="false"></asp:TextBox>
                                &nbsp;<asp:TextBox ID="txtCodCampoEncuestaLista" runat="server" Visible="false"></asp:TextBox>


                            </asp:Panel>

                        </td>
                    </tr>
                    <tr>

                        <td>
                            <asp:Panel ID="Panelbotoneslista" runat="server" Visible="false">
                                <asp:Button ID="btnNuevolista" runat="server" Text="Nuevo" OnClick="btnNuevolista_Click" />
                                <asp:Button ID="btnEditarlista" runat="server" Text="Editar" OnClick="btnEditarlista_Click" />
                                <asp:Button ID="btnGuardarLista" runat="server" Text="Guardar" OnClick="btnGuardarLista_Click" />
                                <asp:Button ID="btnCancelarLista" runat="server" Text="Cancelar" OnClick="btnCancelarLista_Click" />
                            </asp:Panel>
                        </td>

                    </tr>
                    <tr>
                        <td>


                            <asp:GridView ID="gdvplantillalista" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false"
                                GridLines="None" DataKeyNames="IDPLANTILLALISTA,CODPLANTILLAENCUESTA,CAMPO,DESCRIPCION" OnSelectedIndexChanged="gdvplantillalista_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center">


                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgSeleccion" runat="server"
                                                CommandName="Select" ImageUrl="~/Presentacion/Imagenes/select_ok_accept_15254 (1).png"
                                                CommandArgument="<%#((GridViewRow)Container).RowIndex %>" />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IDPLANTILLALISTA" HeaderText="Id. Lista" />
                                    <asp:BoundField DataField="CODPLANTILLAENCUESTA" HeaderText="Cod Plantilla" />
                                    <asp:BoundField DataField="CAMPO" HeaderText="Cod. Campo" />
                                    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />

                                    <%--campo tipo fecha <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" DataFormatString="(0:dd/mm/yyyy)" />--%>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>

                    </tr>





                </table>


            </div>
        </div>

    </asp:Panel>

   
</asp:Content>
