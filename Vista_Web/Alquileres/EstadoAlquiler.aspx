<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="EstadoAlquiler.aspx.cs" Inherits="Vista_Web.Alquileres.EstadoAlquileres" %>

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
                        <div class="page-header" title="Gestión de Usuarios">
                            <h1>Estado Alquiler <small>Módulo Alquileres</small></h1>
                        </div>
                    </div>

                    <div id="Div1" runat="server" class="form-group">
                            <label id="Label1" runat="server" for="cmb_tipomatricula">Pagado</label>
                            <asp:DropDownList ID="cmb_pagado" runat="server" class="form-control">
                            </asp:DropDownList>
                        &nbsp
                            <label id="Label2" runat="server" for="cmb_estado">Estado</label>
                            <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                            </asp:DropDownList>
                        &nbsp
                         <label runat="server" for="exampleInputEmail1">Distancia máxima</label>
                         <asp:TextBox ID="txt_distanciamax" runat="server" type="text" class="form-control" placeholder="Ingrese distancia máxima"></asp:TextBox>
                        &nbsp
                         <label runat="server" for="exampleInputEmail1">Capacidad minima</label> 
                         <asp:TextBox ID="txt_capacidadmin" runat="server" type="text" class="form-control" placeholder="Ingrese capacidad minima"></asp:TextBox>   
                    
                    </div>

                    <div id="Div2" runat="server" class="form-group">
                        <asp:Button ID="btn_filtrar" runat="server" OnClick="btn_filtrar_Click" Text="Filtrar" class="btn btn-info" />
                        &nbsp;&nbsp;
                        <asp:Button ID="btn_nuevabusqueda" runat="server" OnClick="btn_nuevabusqueda_Click" Text="Nueva Búsqueda" class="btn btn-default" />
                     </div>

                       <div id="Div3" runat="server" class="col-lg-8">
                              <label runat="server"> Alquileres </label>
                            <div style="height: 300px; overflow: auto;" class="form-group">
                                <asp:GridView ID="gvAlquileres" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvAlquileres_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvAlquileres_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                                </asp:GridView>
                            </div>
                         </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
