<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="presencial.aspx.cs" Inherits="Farmacia_.presencial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Presencial</title>

        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/font-awesome.min.css" rel="stylesheet"/>
        <link href="css/animate.css" rel="stylesheet"/>
        <link href="css/style.css" rel="stylesheet"/>
        <link href='http://fonts.googleapis.com/css?family=Lobster' rel='stylesheet' type='text/css'/>

</head>
<body>
        <!-- Start Logo Section -->
        <section id="logo-section" class="text-center">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="logo text-center">
                            <h1>La Vida Futura</h1>
                            <span>Seleccione la opcion a usar</span>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Logo Section -->
        
        
        <!-- Start Main Body Section -->
        <div class="mainbody-section text-center">
            <div class="container">
                <div class="row">
                    
                    <div class="col-md-4">
                        
                        <div class="menu-item blue">
                            <a href="cliente.aspx" data-toggle="modal">
                                <i class="glyphicon glyphicon-user"></i>
                                <p>Clientes</p>
                            </a>
                        </div>
                        
                        <div class="menu-item green">
                            <a href="compra.aspx" data-toggle="modal">
                                <i class="glyphicon glyphicon-shopping-cart"></i>
                                <p>Compras</p>
                            </a>
                        </div>
                        
                    </div>
                    
                    <div class="col-md-4">
                        
                        <div class="menu-item light-red">
                            <a href="medicamento.aspx" data-toggle="modal">
                                <i class="fa fa-medkit"></i>
                                <p>Medicamentos</p>
                            </a>
                        </div>
                        
                        <div class="menu-item color">
                            <a href="pedido.aspx" data-toggle="modal">
                                <i class="fa fa-envelope-o"></i>
                                <p>Pedidos</p>
                            </a>
                        </div>
                        
                    </div>
                    
                    <div class="col-md-4">
                        
                        <div class="menu-item light-orange">
                            <a href="pago.aspx" data-toggle="modal">
                                <i class="fa fa-money"></i>
                                <p>Pagos</p>
                            </a>
                        </div>
                        
                        <div class="menu-item blue">
                            <a href="configuracion.aspx" data-toggle="modal">
                                <i class="fa fa-cog fa-fw"></i>
                                <p>Configuracion</p>
                            </a>
                        </div>
                        
                    </div>

                </div>
            </div>
        </div>
</body>
</html>
