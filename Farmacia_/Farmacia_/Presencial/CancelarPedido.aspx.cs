using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.Presencial
{
    public partial class CancelarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
                bool result= wsb.cancelar_pedido(Int32.Parse(this.id_pedido.Text));
                if (result)
                {
                    mostrar("Eliminado");

                }
                else {
                    mostrar("Error");
                }
        }

        private void mostrar(String texto)
        {
            d.Controls.Add(new LiteralControl("<p class=\"text-success\">" + texto + "</p>"));
           
        }
    }
}