<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AutorizarOperacion.aspx.cs" Inherits="Vista_Web.Operaciones.AutorizarOperacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="container">
                <div runat="server" class="row">
                    <div runat="server" class="col-lg-12">
                        <div class="page-header">
                            <h1>Autorizar operación  <small title="Autorizar operación"> Módulo de Operaciones</small></h1>
                        </div>
                          <ul id="myTab" class="nav nav-tabs" role="tablist">
                            <li class="active"><a href="#datos" role="tab" data-toggle="tab">Alquiler</a></li>
                            <li class=""><a href="#grupos" role="tab" data-toggle="tab">Documento</a></li>
                            
                        </ul>

                         <div id="myTabContent" class="tab-content small-panel">
                            <div class="tab-pane fade active in" id="datos">
                                <div class="form-horizontal" role="form">
                                    <div class="form-group">
                                        <label for="txt_nombrecliente" class="control-label">Nombre del cliente</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_nombrecliente" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <label for="txt_capacidadlibreminima" class="control-label">Capacidad libre minima</label>
                                        <div class="col-sm-8">
                                            <asp:TextBox ID="txt_capacidadlibreminima" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                         <label for="txt_distanciamaximaempresa" class="control-label">Distancia máxima a la empresa</label>
                                         <div class="col-sm-8">
                                              <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                         </div>
                                   </div>
                            </div>
                            <div id="Div4" runat="server" class="col-lg-8">
                              <label runat="server"> Alquileres</label>
                                <div style="height: 300px; overflow: auto;" class="form-group">
                                    <asp:GridView ID="gvAlquileres" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvAlquileres_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvAlquileres_SelectedIndexChanged">
                                    <SelectedRowStyle BackColor="#E8E8E8" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="Div5" runat="server" class="form-group">
                                    <label for="txt_notas" class="control-label">Notas</label>
                                    <asp:TextBox ID="txt_notas" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                    <div runat="server" class="form-group">
                                        <asp:Button ID="btn_denegar" runat="server" OnClick="btn_denegar_Click" CssClass="btn btn-default pull-right margin-left-5" Text="Denegar" />
                                        <asp:Button ID="btn_autorizar" runat="server" OnClick="btn_autorizar_Click" CssClass="btn btn-success pull-right" Text="Autorizar" />
                                    </div>
                                </div>
                             </div>
                    </div>
                 </div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
