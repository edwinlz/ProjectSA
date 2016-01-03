﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="configuracion.aspx.cs" Inherits="Farmacia_.configuracion" %>

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
                <p class="lead">Configuracion</p>

                <div class="list-group">
                    <a class="list-group-item" href="presencial.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                </div>
            </div>

            <div class="col-md-6">
                <div id="div_mensajes" runat="server">

                </div>
                <hr />
                <h1>Configuraciones </h1>
                <br />
                <form role="form" runat="server">

                    <div class="form-group">
                        <div id="mostrar_span" runat="server">

                        </div>
                        <label for="cod_compra">Nuevo codigo de Farmacia</label>
                        <asp:TextBox ID="cod_farmacia" CssClass="form-control" runat="server" required=""></asp:TextBox>
                    </div>

                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="Button1_Click"/>
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
