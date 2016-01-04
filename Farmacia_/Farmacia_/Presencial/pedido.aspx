<%@ Page Title="" Language="C#" MasterPageFile="~/SitePresencial.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="Farmacia_.Presencial.pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-md-3">
            <p class="lead">Pedidos</p>

            <div class="list-group">
                <a class="list-group-item" href="presencial.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                <a class="list-group-item" href="pedido.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp; Consultar pedido</a>
                <a class="list-group-item" href="#"><i class="glyphicon glyphicon-book"></i>&nbsp; Pedidos</a>
            </div>
        </div>

        <div class="col-md-6">
            <div id="div_mensajes" runat="server"></div>
            <hr />
            <h1>Consultar Pedido </h1>
            <form id="formulario_1" runat="server">
                <div class="form-group">
                    <label for="nit_cliente">Numero de pedido</label>
                    <asp:TextBox ID="nit_cliente" CssClass="form-control" runat="server" required=""></asp:TextBox>
                </div>
                <!--Boton enviar nuevo cliente-->
                <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Submit" />
            </form>
        </div>
    </div>
</asp:Content>
