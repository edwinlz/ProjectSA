<%@ Page Title="" Language="C#" MasterPageFile="~/SitePresencial.Master" AutoEventWireup="true" CodeBehind="pedido.aspx.cs" Inherits="Farmacia_.CallCenter.pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-md-3">
            <p class="lead">Pedidos</p>

            <div class="list-group">
                <a class="list-group-item" href="callcenter.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                <a class="list-group-item" href="pedido.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp; Pedidos</a>
                <a class="list-group-item" href="RealizarPedido.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp;Asignar pedido</a>
            </div>
        </div>

        <div class="col-md-6">
            <div id="div_mensajes" runat="server"></div>
            <hr />
            <h1>Consultar Pedido </h1>
            <form id="formulario_1" runat="server">
                <div class="form-group">
                    <label for="nit_cliente">Numero de Farmacia</label>
                    <asp:TextBox ID="id_farmacia" CssClass="form-control" runat="server" required=""></asp:TextBox>
                </div>
                <!--Boton enviar nuevo cliente-->
                <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Buscar" OnClick="Button1_Click1" />
            </form>

            <div id="d" runat="server"></div>

        </div>
    </div>
</asp:Content>
