<%@ Page Title="" Language="C#" MasterPageFile="~/SitePresencial.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="Farmacia_.CallCenter.cliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">

            <div class="col-md-3">
                <p class="lead">Clientes</p>

                <div class="list-group">
                    <a class="list-group-item" href="callcenter.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                    <a class="list-group-item" href="cliente.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp; Lista Clientes</a>
                    <a class="list-group-item" href="consultarCliente.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp; Consultar Cliente</a>
                </div>
            </div>


            <div class="col-md-6">
                <div id="div_mensajes" runat="server"></div>
                <hr />
                <h1>Clientes en el Sistema </h1>
                <form id="formulario_1" runat="server">
                   
                    <div class="form-group">
                        <div id="d" runat="server"></div>
                    </div>
                    <!--Boton enviar nuevo cliente-->
                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="Button1_Click" />
                </form>
            </div>
        </div>
</asp:Content>


