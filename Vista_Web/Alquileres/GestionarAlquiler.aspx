<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="GestionarAlquiler.aspx.cs" Inherits="Vista_Web.Alquileres.GestionarAlquiler" %>

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
                            <h1>Gestionar Alquiler <small>Módulo Alquileres</small></h1>
                        </div>
                    </div>

                    <div id="Div1" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="exampleInputEmail1">Nombre del cliente</label>
                            <asp:TextBox ID="txt_nombre" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre del cliente"></asp:TextBox>
                            <label runat="server" for="exampleInputEmail1">Capacidad libre minima</label>
                            <asp:TextBox ID="txt_capacidadmin" runat="server" type="text" class="form-control" placeholder="Ingrese la capacidad minima"></asp:TextBox>
                            <label runat="server" for="exampleInputEmail1">Distancia máxima</label>
                            <asp:TextBox ID="txt_distanciamax" runat="server" type="text" class="form-control" placeholder="Ingrese la distancia máxima"></asp:TextBox>
                            &nbsp
                         </div>
                     </div>

                     <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btn_filtrar" runat="server" OnClick="btn_filtrar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Filtrar" />
                        <asp:Button ID="btn_nuevabusqueda" runat="server" OnClick="btn_nuevabusqueda_Click" CssClass="btn btn-default pull-right" Text="Nueva búsqueda" />
                    </div>
                      &nbsp
                    <div id="Div2" runat="server" class="col-lg-4">
                        &nbsp
                        <label runat="server" for="exampleInputEmail1">Alquileres</label>
                         <div style="height: 300px; overflow: auto;" class="form-group">
                           <asp:GridView ID="gvAlquileres" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvAlquileres_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvAlquileres_SelectedIndexChanged">
                             <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                    </div>

                    <div id="Div3" runat="server" class="col-lg-4">
                        <uc1:Botonera1 ID="botonera1" runat="server" OnClick_Alta="botonera1_Click_Alta" OnClick_Baja="botonera1_Click_Baja" OnClick_Modificacion="botonera1_Click_Modificacion" />
                    </div>

                </div>
            </div>

    </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>
