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
                                 <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                 </asp:DropDownList>
                            </div> 
                            <div id="Div3" runat="server" class="form-group">
                                <label runat="server" for="cmb_numeromatricula">Número matricula</label>
                                </div>
                            </div>
                        </div>
                    </div>

        </ContentTemplate>
      </asp:UpdatePanel>
    </asp:Content>