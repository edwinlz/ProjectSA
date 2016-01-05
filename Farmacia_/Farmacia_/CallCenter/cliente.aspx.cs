using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.CallCenter
{
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }


        private void Cargar() {
            Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();



            String texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Nit</th></tr></thead>" +
                                "<tbody>";
            foreach (var item in wsb.consultar_catalogo_clientes())
            {

                texto += "<tr>" +
                     "<td>" + item.id + "</td><td>" + item.nombre + "</td><td>" + item.nit + "</td>" +
                     "</tr>";

            }

            texto += "</tbody></table>";
            d.Controls.Add(new LiteralControl(texto));
        

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
               Page.GetType(), "MessageBox", "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}