<%@ Page Title="" Language="C#" MasterPageFile="~/SitePresencial.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="Farmacia_.Presencial.cliente" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">

            <div class="col-md-3">
                <p class="lead">Clientes</p>

                <div class="list-group">
                    <a class="list-group-item" href="presencial.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                    <a class="list-group-item" href="cliente.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp; Nuevo Cliente</a>
                    <a class="list-group-item" href="consultarCliente.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp; Consultar Cliente</a>
                </div>
            </div>


            <div class="col-md-6">
                <div id="div_mensajes" runat="server"></div>
                <hr />
                <h1>Nuevo Cliente </h1>
                <form id="formulario_1" runat="server">
                    <div class="form-group">
                        <label for="nit_cliente">NIT</label>
                        <asp:TextBox ID="nit_cliente" CssClass="form-control" runat="server" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="nom_cliente">Nombre</label>
                        <asp:TextBox ID="nom_cliente" CssClass="form-control" runat="server" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ape_cliente">Apellido</label>
                        <asp:TextBox ID="ape_cliente" CssClass="form-control" runat="server" placeholder="Opcional"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <div>
                            <label for="tel_cliente">Telefono</label></div>
                        <asp:TextBox ID="tel_cliente" CssClass="form-control" runat="server" placeholder="Opcional"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="dir_cliente">Direccion</label>
                        <asp:TextBox ID="dir_cliente" CssClass="form-control" runat="server" placeholder="Opcional"></asp:TextBox>
                    </div>
                    <!--Boton enviar nuevo cliente-->
                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="Button1_Click" />
                </form>
            </div>
        </div>
</asp:Content>

