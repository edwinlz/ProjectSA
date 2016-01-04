<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Farmacia_.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/main.css" />
    <link href="css/style.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Lobster' rel='stylesheet' type='text/css' />
    <title>Modulos</title>
</head>
<body>
    <section id="logo-section" class="text-center">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="logo text-center">
                        <h1>La Vida Futura</h1>
                        <span>Seleccione el modulo a usar</span>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="themes-area">
        <div class="container text-center">
            <div class="row">

                <div class="col-md-6">
                    <a href="Presencial/presencial.aspx" class="theme-thum">
                        <img class="img-responsive" src="img/home-1.jpg" alt="elevator" />
                        <h4>Presencial</h4>
                    </a>
                </div>
                <div class="col-md-6">
                    <a href="CallCenter/callcenter.aspx" class="theme-thum">
                        <img class="img-responsive" src="img/home-2.jpg" alt="elevator" />
                        <h4>Call Center</h4>
                    </a>
                </div>

            </div>

        </div>
    </section>


    <footer class="footer">
        <div class="container text-center">
            <p>Copyright &copy; G5 2015</p>
        </div>
    </footer>

</body>
</html>
