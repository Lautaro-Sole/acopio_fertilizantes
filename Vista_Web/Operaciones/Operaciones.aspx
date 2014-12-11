<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Operaciones.aspx.cs" Inherits="Vista_Web.Operaciones.Operaciones" %>

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
                            <h1>Operaciones  <small title="Operaciones"> Módulo de Operaciones</small></h1>
                        </div>
                          <div id="Div1" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="cmb_tipomatricula">Tipo de matricula</label>
                            <asp:DropDownList ID="cmb_tipomatricula" runat="server" class="form-control">
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
                              <asp:DropDownList ID="cmb_tipooperacion" runat="server" class="form-control">
                              </asp:DropDownList>
                         </div>
                         
                         <div id="Div5" runat="server" class="form-group">
                              <label id="Label3" runat="server" for="cmb_estado">Estado</label>
                              <asp:DropDownList ID="cmb_estado" runat="server" class="form-control">
                              </asp:DropDownList>
                         </div>
                         
                         <div id="Div6" runat="server" class="form-group">
                              <label for="txt_nombrechofer" class="control-label">Nombre del chofer</label>
                              <asp:TextBox ID="txt_nombrechofer" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>

                         <div id="Div7" runat="server" class="col-lg-8">
                              <label runat="server"> Operaciones </label>
                            <div style="height: 300px; overflow: auto;" class="form-group">
                                <asp:GridView ID="gvOperaciones" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvOperaciones_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvOperaciones_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                                </asp:GridView>
                            </div>
                         </div>

                        <div runat="server" class="form-group">
                            <asp:Button ID="btn_autorizarcierreoperacion" runat="server" OnClick="btn_autorizarcierreoperacion_Click" CssClass="btn btn-default pull-right margin-left-5" Text="Autorizar cierre de operación" />
                            <asp:Button ID="btn_registrarcargadescarga" runat="server" OnClick="btn_registrarcargadescarga_Click" CssClass="btn btn-default pull-right margin-left-5" Text="Registrar carga o descarga" />
                            <asp:Button ID="btn_autorizaroperacion" runat="server" OnClick="btn_autorizaroperacion_Click" CssClass="btn btn-success pull-right" Text="Autorizar operación" /> 
                        </div>

                     </div>
                    </div>
        </ContentTemplate>
      </asp:UpdatePanel>
</asp:Content>
