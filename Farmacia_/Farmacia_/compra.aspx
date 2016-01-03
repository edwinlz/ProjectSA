<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compra.aspx.cs" Inherits="Farmacia_.compra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="Proyecto" />
    <meta name="author" content="G5" />

    <title>Farmacia</title>

    <!-- Bootstrap Core CSS and Custom CSS-->
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/shop-homepage.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Lobster' rel='stylesheet' type='text/css' />

    <script src="js/jquery-2.1.1.min.js"></script>

    <script>

        function agregar_codigo(codigo) {
            getCarro(codigo, "1");
        }

        function borrar_codigo(codigo) {
            getCarro(codigo, "0");
        }

        function getCarro(codigo, accion) {
            $.ajax({
                type: "POST",
                url: "compra.aspx/GetCurrentTable",
                data: '{codigo: "' + codigo + '",accion:"' + accion + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: UpdateTablaCarro,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function getMedicamentos() {

            $.ajax({
                type: "POST",
                url: "compra.aspx/GetTablaMedicamentos",
                data: '{nombre: "' + $("#<%=nom_comercial.ClientID%>")[0].value + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: UpdateTablaMedicamento,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function UpdateTablaMedicamento(response) {
            document.getElementById('div_mostrar').innerHTML = response.d;
        }

        function UpdateTablaCarro(response) {
            document.getElementById('div_mostrar2').innerHTML = response.d;
        }

    </script>

</head>
<body>

    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <!-- <a class="navbar-brand" href="#">La Vida Futura</a> -->
                <div class="logo text-center">
                    <h2>La Vida Futura</h2>
                </div>
            </div>
        </div>
        <!-- /.container -->
    </nav>

    <!-- Page Content -->
    <div class="container">
        <div class="row">

            <div class="col-md-3">
                <p class="lead">Compras</p>

                <div class="list-group">
                    <a class="list-group-item" href="presencial.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                    <a class="list-group-item" href="compra.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp; Nueva Compra</a>
                </div>
            </div>

            <div class="col-md-6">

                <div id="div_mensajes" runat="server">
                </div>

                <hr />

                <h1>Nueva Compra </h1>

                <form role="form" id="formulario_1" runat="server">

                    <div class="form-group">
                        <label for="cod_cliente">Datos Cliente</label>
                        <div class="input-group">
                            <asp:TextBox ID="nit_cliente" CssClass="form-control" runat="server" placeholder="Numero de Nit" required=""></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Verificar" OnClick="Button1_Click" />
                            </span>
                        </div>
                        <br />
                        <asp:TextBox ID="dir_cliente" CssClass="form-control" runat="server" placeholder="Direccion"></asp:TextBox>
                        <div id="d" runat="server">
                        </div>
                    </div>
                    <!-- Lista de productos -->
                    <div class="form-group">
                        <label for="cod_cliente">Lista de productos</label>
                        <button type="button" class="btn btn-default btn-sm btn-block" data-toggle="collapse" data-target="#demo">Agregar Medicamento</button>
                        <div id="demo" class="collapse">
                            <br />
                            <div class="input-group">

                                <asp:TextBox ID="nom_comercial" CssClass="form-control" runat="server" placeholder="Nombre comercial"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button id="btn2" class="btn btn-default" runat="server" onclick="getMedicamentos(); return false;">Buscar</button>
                                </span>
                            </div>
                            <div id="div_mostrar" runat="server">
                            </div>
                        </div>

                        <div id="div_mostrar2" runat="server">
                        </div>
                    </div>
                    <!-- Tipo de pago-->

                    <div class="form-group">
                        <label for="cod_cliente">Tipo de pago</label>
                        <asp:RadioButtonList ID="rbtLstRating" runat="server" RepeatDirection="Vertical" RepeatLayout="Table">
                            <asp:ListItem Selected="True" Text="Efectivo" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Tarjeta" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <asp:Button ID="Button3" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" CssClass="btn btn-danger" runat="server" Text="Cancelar" OnClick="Button4_Click" />
                </form>



            </div>

        </div>

    </div>
    <!-- /.container -->

    <div class="container">
        <hr />
        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; G5 2015</p>
                </div>
            </div>
        </footer>

    </div>
    <!-- /.container -->

    <!-- jQuery and Bootstrap Core-->
    <script src="js/bootstrap.min.js"></script>

</body>
</html>
