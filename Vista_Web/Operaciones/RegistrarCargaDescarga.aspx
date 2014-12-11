﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegistrarCargaDescarga.aspx.cs" Inherits="Vista_Web.Operaciones.RegistrarCargaDescarga" %>

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
                        <div class="page-header" title="Gestión de Usuarios">
                            <h1>Registro de Carga o Descarga <small>Módulo de Operaciones</small></h1>
                        </div>
                    </div>
                    <div id="Div4" runat="server" class="col-lg-4">
                        <div runat="server" class="form-group">
                            <label runat="server" for="exampleInputEmail1">Peso inicial</label>
                            <asp:TextBox ID="txt_pesoinicial" runat="server" type="text" class="form-control" placeholder="Ingrese el peso inicial"></asp:TextBox>
                            <label runat="server" for="exampleInputEmail1">Peso final</label>
                            <asp:TextBox ID="txt_pesofinal" runat="server" type="text" class="form-control" placeholder="Ingrese el peso final"></asp:TextBox>
                            <label runat="server" for="exampleInputEmail1">Notas</label>
                            <asp:TextBox ID="txt_notas" runat="server" type="text" class="form-control" placeholder="Ingrese notas"></asp:TextBox>
                        </div>
                        <div runat="server" class="form-group">
                            <asp:Button ID="btn_cancelar" runat="server" OnClick="btn_cancelar_Click" CssClass="btn btn-default pull-right" Text="Cancelar" />
                            <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" CssClass="btn btn-success pull-right margin-left-5" Text="Guardar" />
                           
                        </div>
                       
                    </div>
                </div>
                </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido_Especial" runat="server">
</asp:Content>
