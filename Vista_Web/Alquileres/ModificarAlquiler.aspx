<%@ Page Title="Modificar Alquiler" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ModificarAlquiler.aspx.cs" Inherits="Vista_Web.Alquileres.ModificarAlquiler" %>


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
                            <h1>Modificar Alquiler <small>Módulo Alquileres</small></h1>
                        </div>
                    </div>

                     <div id="Div1" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="exampleInputEmail1">Nombre del cliente</label>
                            <asp:TextBox ID="txt_nombre" runat="server" type="text" class="form-control" placeholder="Ingrese el nombre del cliente"></asp:TextBox>
                            <label runat="server" for="exampleInputEmail1">Clientes</label>

                            &nbsp

                            <div style="height: 300px; overflow: auto;" class="form-group">
                            <asp:GridView ID="gvClientes" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvClientes_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
                                <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                    </div>
                   </div>

                     <div id="Div2" runat="server" class="col-lg-4">
                            <div runat="server" class="form-group">
                                <label runat="server" for="exampleInputEmail1">Capacidad minima no alquilada</label>
                                <asp:TextBox ID="txt_capacidadmin" runat="server" type="text" class="form-control" placeholder="Ingrese capacidad minima"></asp:TextBox>
                                <label runat="server" for="exampleInputEmail1">Distancia máxima</label>
                                <asp:TextBox ID="txt_distanciamax" runat="server" type="text" class="form-control" placeholder="Ingrese distancia máxima"></asp:TextBox>
                             </div>
                      </div>

                    <div id="Div3" runat="server" class="col-lg-4">
                        <div style="height: 300px; overflow: auto;" class="form-group">
                           <asp:GridView ID="gvAlmacenes" runat="server" AutoGenerateSelectButton="True" CssClass="table table-hover table-responsive table-bordered" OnRowCreated="gvAlmacenes_RowCreated" AllowCustomPaging="True" OnSelectedIndexChanged="gvAlmacenes_SelectedIndexChanged">
                             <SelectedRowStyle BackColor="#E8E8E8" />
                            </asp:GridView>
                        </div>
                    </div>

                    <div id="Div4" runat="server" class="col-lg-4">
                        <label runat="server" for="exampleInputEmail1">Capacidad (en Kg)</label>
                        <asp:TextBox ID="txt_capacidad" runat="server" type="text" class="form-control" placeholder="Ingrese capacidad en Kg"></asp:TextBox>
                        <label runat="server" for="exampleInputEmail1">Fecha y hora de inicio</label>
                         <asp:TextBox ID="txt_fechahorainicio" runat="server" type="text" class="form-control" placeholder="Ingrese fecha y hora"></asp:TextBox>
                         <label runat="server" for="exampleInputEmail1">Fecha y hora de fin</label>                            
                        <asp:TextBox ID="txt_fechahorafin" runat="server" type="text" class="form-control" placeholder="Ingrese fecha y hora"></asp:TextBox>
                        <label runat="server" for="exampleInputEmail1">Capacidad no utilizada</label>
                        <label runat="server" for="exampleInputEmail1"></label>    
                    </div>

                       &nbsp
                       &nbsp
                       &nbsp

                   <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Guardar" />
                        <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar/Volver" />
                    </div>
            </div>
         </div>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

   

