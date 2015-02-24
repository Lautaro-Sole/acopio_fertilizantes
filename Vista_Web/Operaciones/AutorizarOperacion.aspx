<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" EnableViewState="true" CodeBehind="AutorizarOperacion.aspx.cs" Inherits="Vista_Web.Operaciones.AutorizarOperacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container">
                <div runat="server" class="row">
                    <div runat="server" class="col-lg-12">
                        <div class="page-header">
                            <h1>Autorizar operación  <small title="Autorizar operación"> Módulo de Operaciones</small></h1>
                        </div>
                        <div>
                            <ul id="myTab" class="nav nav-tabs" role="tablist">
                              <li class="active"><a href="#alquiler" role="tab" data-toggle="tab" title="Autorizar Operación">Documento</a></li>
                              <li class=""><a href="#documento" role="tab" data-toggle="tab">Alquiler</a></li>
                           </ul>
                            <div class="tab-pane fade active in" id="alquiler">
                            <div class="form-horizontal" role="form">
                                   
                                    <div class="form-group">
                                        &nbsp;
                                        <div class="col-sm-8">
                                            <label  for="txt_capacidadlibreminima" class="control-label">Capacidad libre minima <br /> </label>

                                            <asp:TextBox ID="txt_capacidadlibreminima" runat="server" CssClass="form-control"></asp:TextBox>
                                            &nbsp;
                                            <label for="txt_distanciamaximaempresa" class="control-label">Distancia máxima a la empresa <br /> </label>
                                            <asp:TextBox ID="txt_distanciamaximaempresa" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                         
                                        <div class="col-sm-8">
                                            
                                                    &nbsp;
                                                    &nbsp;
                                                    &nbsp
                                            <asp:Button ID="Button1" runat="server" OnClick="btn_filtrar_Click" Text="Filtrar" class="btn btn-info" />
                                                &nbsp;&nbsp;
                                            <asp:Button ID="Button2" runat="server" OnClick="btn_nuevabusqueda_Click" Text="Nueva Búsqueda" class="btn btn-default" />
                                        </div>
                                            &nbsp;&nbsp;
                                    </div>
                                    <div id="Div4" runat="server" class="col-lg-8">
                                        <label runat="server"> Alquileres <br /> </label>
                                        <div style="height: 300px; overflow: auto;" class="form-group">
                                            <asp:GridView ID="gvAlquileres" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvAlquileres_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvAlquileres_SelectedIndexChanged">
                                                <SelectedRowStyle BackColor="#E8E8E8" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                        </div>
                        <div class="tab-pane fade active in" id="documento">
                                <div class="form-vertical" role="form">
                                    <div class="form-group">
                                        <label for="txt_numerodocumento" class="control-label"> Número de documento <br />
                                            <asp:TextBox ID="txt_numerodocumento" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </label>
                                        &nbsp
                                        <label for="cmb_tipofertilizante" class="control-label">Tipo de fertilizante <br /> 
                                            <asp:DropDownList ID="cmb_tipofertilizante" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="cmb_tipofertilizante_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </label>
                                        &nbsp
                                        <label for="txt_cantidadenkg" class="control-label">Cantidad (en KG) <br /> 
                                            <asp:TextBox ID="txt_cantidadenkg" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                        </label>
                                        &nbsp
                                        <label for="txt_fecha" class="control-label">Fecha y Hora <br />
                                              <asp:TextBox ID="txt_fecha" runat="server" CssClass="form-control">

                                              </asp:TextBox>
                                        </label>
                                   </div>
                                    <%--<asp:Button ID="btn_autorizar" runat="server" OnClick="btn_autorizar_Click" CssClass="btn btn-success pull-right" Text="Autorizar" />--%>
                                </div>
                            </div>
                        </div>
                        &nbsp
                        &nbsp
                        &nbsp
                        &nbsp

                        <div runat="server" class="alert alert-warning" role="alert" visible="false" id="message">
                                <label for="txt_notas" class="control-label">Notas <br /> </label>
                                <asp:TextBox ID="txt_notas" runat="server" CssClass="form-control"></asp:TextBox>
                            &nbsp
                            &nbsp
                                <button runat="server" type="button" class="close" data-dismiss="alert"><span runat="server" aria-hidden="true">&times;</span><span runat="server" class="sr-only">Cerrar</span></button>
                                <asp:Label ID="lb_error" runat="server" Text="Mensaje"></asp:Label>
                            &nbsp
                            &nbsp
                            &nbsp

                                <%--<uc1:Botonera1 ID="botonera1" runat="server" OnClick_Alta="botonera1_Click_Alta" OnClick_Cerrar="botonera1_Click_Cerrar"/>--%>
                            </div>
                        <uc1:Botonera1 ID="botonera2" runat="server" OnClick_Alta="botonera1_Click_Alta" OnClick_Cerrar="botonera1_Click_Cerrar"/>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
