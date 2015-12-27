<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="Farmacia_.compra" %>

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
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/shop-homepage.css" rel="stylesheet" />

</head>
<body>

    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">La Vida Futura</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li>
                        <a href="#">Menu 1</a>
                    </li>
                    <li>
                        <a href="#">Menu 2</a>
                    </li>
                    <li>
                        <a href="#">Menu 3</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>

    <!-- Page Content -->
    <div class="container">

        <div class="row">

            <div class="col-md-3">
                <p class="lead">Clientes</p>
                <div class="list-group">
                    <a href="cliente.aspx" class="list-group-item">Nuevo cliente</a>
                    <a href="consultarCliente.aspx" class="list-group-item">Consultar cliente</a>
                </div>
            </div>

            <div class="col-md-6">
                <form role="form">
                    <div class="form-group">
                        <label for="nit_cliente">NIT</label>
                        <input class="form-control" id="nit_cliente" />
                    </div>
                    <div class="form-group">
                        <label for="nom_cliente">Nombre</label>
                        <input class="form-control" id="nom_cliente" />
                    </div>
                    <div class="form-group">
                        <label for="tel_cliente">Telefono</label>
                        <input class="form-control" id="tel_cliente" />
                    </div>
                    <div class="form-group">
                        <label for="dir_cliente">Direccion</label>
                        <input class="form-control" id="dir_cliente" />
                    </div>

                    <!-- Tipo de pago-->

                    <button type="submit" class="btn btn-default">Submit</button>
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
    <script src="js/jquery.js"></script>
    <script src="js/bootstrap.min.js"></script>

</body>
</html>
