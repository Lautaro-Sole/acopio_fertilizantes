<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" EnableViewState="true" CodeBehind="Operaciones.aspx.cs" Inherits="Vista_Web.Operaciones.OperacionesIntento2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
                        <div class="page-header">
                            <h1>Operaciones  <small title="Operaciones"> Módulo de Operaciones</small></h1>
                        </div>

                        <div id="Div1" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="cmb_tipomatricula">Tipo de matricula</label>
                            <asp:DropDownList ID="cmb_tipomatricula" runat="server" class="form-control" OnSelectedIndexChanged="cmb_tipomatricula_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                         
                        <div id="Div2" runat="server" class="form-group">
                             <label for="txt_numeromatricula" class="control-label">Número de matricula</label>
                             <asp:TextBox ID="txt_numeromatricula" runat="server" CssClass="form-control"></asp:TextBox>
                        </div> 

                        <div id="Div3" runat="server" class="form-group">
                              <label for="txt_nombrecliente" class="control-label">Nombre del cliente</label>
                              <asp:TextBox ID="txt_nombrecliente" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div id="Div4" runat="server" class="form-group">
                              <label id="Label2" runat="server" for="cmb_tipooperacion">Tipo de operación</label>
                              <asp:DropDownList ID="cmb_tipooperacion" runat="server" class="form-control" OnSelectedIndexChanged="cmb_tipooperacion_SelectedIndexChanged">
                              </asp:DropDownList>
                        </div>
                         
                        <div id="Div5" runat="server" class="form-group">
                              <label id="Label3" runat="server" for="cmb_estado">Estado</label>
                              <asp:DropDownList ID="cmb_estado" runat="server" class="form-control" OnSelectedIndexChanged="cmb_estado_SelectedIndexChanged">
                              </asp:DropDownList>
                        </div>
                         
                        <div id="Div6" runat="server" class="form-group">
                              <label for="txt_nombrechofer" class="control-label">Nombre del chofer</label>
                              <asp:TextBox ID="txt_nombrechofer" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div id="Div9" runat="server" class="form-group">
                            <asp:Button ID="btn_filtrar" runat="server" OnClick="btn_filtrar_Click" Text="Filtrar" class="btn btn-info" />
                                &nbsp;&nbsp;
                            <asp:Button ID="btn_nuevabusqueda" runat="server" OnClick="btn_nuevabusqueda_Click" Text="Nueva Búsqueda" class="btn btn-default" />
                        </div>

                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                            <button runat="server" type="button" class="close" data-dismiss="alert">
                                <span runat="server" aria-hidden="true">&times;</span>
                                <span runat="server" class="sr-only">Cerrar</span>
                            </button>
                            <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                        </div>

                        <div id="Div7" runat="server" class="col-lg-8">
                            <label runat="server"> Operaciones </label>
                            <div style="height: 300px; width: 1100px; overflow: auto;" class="form-group">
                                <asp:GridView ID="gvOperaciones" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvOperaciones_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvOperaciones_SelectedIndexChanged">
                                    <SelectedRowStyle BackColor="#E8E8E8" />
                                </asp:GridView>
                            </div>
                            &nbsp;&nbsp
                            <div id="Div10" style="align-content" runat="server" class="form-group">
                                &nbsp;&nbsp
                                <uc1:Botonera1 ID="botonera1" runat="server" OnClick_Alta="botonera1_Click_Alta" OnClick_Baja="botonera1_Click_Baja" OnClick_Cerrar="botonera1_Click_Cerrar" OnClick_Consulta="botonera1_Click_Consulta" OnClick_Modificacion="botonera1_Click_Modificacion" />
                            </div>
                        </div>
                        &nbsp;&nbsp;&nbsp;&nbsp
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Contenido_Especial" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--Modal--%>
            <div class="modal fade" id="modal_cerrar" tabindex="-1" role="dialog" aria-labelledby="Autorizar Cierre" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button id="btn_cerrar_modal" runat="server" type="button" class="close" data-dismiss="modal_cerrar">
                                <span id="Span1" runat="server" aria-hidden="true">&times;</span>
                                <span id="Span2" runat="server" class="sr-only">Cerrar</span>
                            </button>
                            <h4 class="modal-title">Autorizar Cierre</h4>
                        </div>
                        <div class="modal-body">
                            <p>¿Está seguro que desea cerrar la operación?</p>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btn_cancelar_modal" data-dismiss="modal_cerrar" runat="server" Text="Cancelar" class="btn btn-default" OnClick="btn_cancelar_modal_Click" />
                            <asp:Button ID="btn_cerrar_operacion_modal" runat="server" Text="Cerrar Operación" class="btn btn-danger" OnClick="btn_cerrar_operacion_modal_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
