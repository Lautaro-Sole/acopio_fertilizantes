<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistroIngreso.aspx.cs" Inherits="Vista_Web.Operaciones.RegistroIngreso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%--<%@ Register Src="../Botoneras/Botonera1.ascx" TagName="Botonera1" TagPrefix="uc1" %>--%>
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
                            <h1>Registro de Ingreso <small title="Registro de Ingreso">Módulo de Operaciones</small></h1>
                        </div>
                    </div>
                      <div id="Div4" runat="server" class="col-lg-4">
                        <div id="Div2" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="cmb_clientes">Cliente</label>
                            <asp:DropDownList ID="cmb_clientes" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                        <div runat="server" class="form-group">
                            <label runat="server" for="cmb_choferes">Chofer</label>
                            <asp:DropDownList ID="cmb_choferes" runat="server" class="form-control">
                            </asp:DropDownList>
                         </div>
                            <div id="Div1" runat="server" class=" form-group">
                                 <label runat="server" for="cmb_tipomatricula">Tipo de matricula</label>
                                 <asp:DropDownList ID="cmb_tipomatricula" runat="server" class="form-control">
                                 </asp:DropDownList>
                            </div> 
                            <div id="Div3" runat="server" class="form-group">
                                <label runat="server" for="cmb_numeromatricula">Número matricula</label>
                                <asp:TextBox ID="cmb_numeromatricula" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                          <div id="Div5" runat="server" class="col-lg-8">
                              <label runat="server"> Transportes </label>
                            <div style="height: 300px; overflow: auto;" class="form-group">
                                <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvTransportes_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvTransportes_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                                </asp:GridView>
                            </div>
                        
                        </div>
                             <div id="Div6" runat="server" class="form-group">
                                  <label runat="server" for="cmb_tipooperacion">Tipo de operación</label>
                                <asp:DropDownList ID="cmb_tipooperacion" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                            <div id="Div7" runat="server" class="form-group">
                                <label runat="server" for="cmb_permitiringreso">Permitir ingreso</label>
                                <asp:DropDownList ID="cmb_permitiringreso" runat="server" class="form-control">
                                </asp:DropDownList>
                            </div>
                            
                            <div id="Div8" runat="server" class="form-group">
                                <label for="txt_notasrechazo" class="control-label">Notas o razones del rechazo</label>
                                <asp:TextBox ID="txt_notasrechazo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                          <div runat="server" class="form-group">
                            <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right margin-left-5" Text="Cancelar" />
                            <asp:Button ID="btn_registrar" runat="server" OnClick="btn_registrar_Click" CssClass="btn btn-success pull-right" Text="Registrar" />
                          </div>
                  </div>
               </div>
                    </div>

        </ContentTemplate>
      </asp:UpdatePanel>
    </asp:Content>