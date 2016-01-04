<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="medicamento.aspx.cs" Inherits="Farmacia_.Presencial.medicamento" %>

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
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/shop-homepage.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Lobster' rel='stylesheet' type='text/css' />

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
                <p class="lead">Medicamentos</p>

                <div class="list-group">
                    <a class="list-group-item" href="presencial.aspx"><i class="glyphicon glyphicon-home"></i>&nbsp; Home</a>
                    <a class="list-group-item" href="medicamento.aspx"><i class="glyphicon glyphicon-search"></i>&nbsp; Consultar Medicamento</a>
                    <a class="list-group-item" href="medicamentos.aspx"><i class="glyphicon glyphicon-book"></i>&nbsp; Medicamentos</a>
                </div>
            </div>

            <div class="col-md-6">
                <hr />
                <h1>Consultar Medicamento</h1>
                <form role="form" id="formulario_1" runat="server">
                    <div class="form-group">
                        <label for="cod_farmacia">Codigo Farmacia</label>
                        <asp:TextBox ID="cod_farmacia" CssClass="form-control" runat="server" required=""></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="cod_medicamento">Codigo Medicamento</label>
                        <asp:TextBox ID="cod_medicamento" CssClass="form-control" runat="server" placeholder="Opcional"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="nom_comercial">Nombre Comercial</label>
                        <asp:TextBox ID="nom_comercial" CssClass="form-control" runat="server" placeholder="Opcional"></asp:TextBox>
                    </div>

                    <!--Boton enviar nueva consulta-->
                    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="Button1_Click" />
                </form>
                <br />
                <div id="d" runat="server"></div>
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
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/boton.js"></script>

</body>
</html>
