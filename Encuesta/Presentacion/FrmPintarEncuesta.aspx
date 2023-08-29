<%@ Page Title="" Language="C#" MasterPageFile="~/Presentacion/SitePaginPrincipal.Master" AutoEventWireup="true" CodeBehind="FrmPintarEncuesta.aspx.cs" 
    Inherits="Encuesta.Presentacion.FrmPintarEncuesta" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="500" BorderColor="#000000" BorderStyle="Ridge" >

    </asp:Panel>
    
   <asp:Button ID="btnGuardarEncuesta" runat="server" CssClass="btm" Text="Enviar" OnClick="btnGuardarEncuesta_Click"  />
</asp:Content>
