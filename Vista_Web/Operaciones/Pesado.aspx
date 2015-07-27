<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Pesado.aspx.cs" Inherits="Vista_Web.Operaciones.RegistrarCargaDescarga" %>

<%@ Register Src="../Botoneras/Botonera1.ascx" TagName="Botonera1" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
     <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container">
                <div runat="server" class="row">
                    <div runat="server" class="col-lg-12">
                        <div id="cabecera" class="page-header" title="Gestión de Usuarios">
                            <h1 id="nombrepagina">Pesado <small>Módulo de Operaciones</small></h1>
                        </div>
                    </div>
                    <div id="Div4" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="txt_peso">Peso Medido</label>
                            <asp:TextBox ID="txt_peso" runat="server" type="text" class="form-control" placeholder="Ingrese el peso medido"></asp:TextBox>
                            <label runat="server" for="txt_notas">Notas</label>
                            <asp:TextBox ID="txt_notas" runat="server" type="text" class="form-control" placeholder="Ingrese notas"></asp:TextBox>
                        </div>
                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                            <button id="Button1" runat="server" type="button" class="close" data-dismiss="alert"><span id="Span1" runat="server" aria-hidden="true">&times;</span><span id="Span2" runat="server" class="sr-only">Cerrar</span></button>
                            <asp:Label ID="lb_error" runat="server" Text="Mensaje" Visible="True"></asp:Label>
                        </div>
                        <div runat="server" class="form-group">
                            <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right margin-left-5" Text="Cancelar" />
                            <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right " Text="Guardar" />
                           
                        </div>
                       
                    </div>
                </div>
                </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido_Especial" runat="server">
</asp:Content>
