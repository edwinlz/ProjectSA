using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Farmacia_
{
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
            int respuesta = wsb.registrar_cliente(nit_cliente.Text, nom_cliente.Text, ape_cliente.Text,tel_cliente.Text, dir_cliente.Text);
            if (respuesta != -1)
            {
                limpiar();
                mostrar_sucess("El cliente ha sido registrado exitosamente <strong>"+respuesta+"</strong>");
            }
            else {
                mostrar_error("Hubo un error al ingresar al cliente");
            }
            
        }

        private void limpiar() {
            nit_cliente.Text = "";
            nom_cliente.Text = "";
            ape_cliente.Text = "";
            tel_cliente.Text = "";
            dir_cliente.Text = "";
        }

        private void mostrar_sucess(String mensaje)
        {

            String texto = "<div class=\"alert alert-success\">"
                    + "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>"
                    + "<strong>Correcto!</strong> " + mensaje
                    + "</div>";
            div_mensajes.Controls.Add(new LiteralControl(texto));

        }

        private void mostrar_error(String mensaje)
        {

            String texto = "<div class=\"alert alert-danger\">"
                    + "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>"
                    + "<strong>Incorrecto!</strong> " + mensaje
                    + "</div>";
            div_mensajes.Controls.Add(new LiteralControl(texto));

        }


    }

    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(), "MessageBox","<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }


}