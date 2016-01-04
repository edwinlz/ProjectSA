using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.Presencial
{
    public partial class pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            registrar_pago();
        }

        private void registrar_pago() {
            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
            int codigo = Convert.ToInt32(cod_compra.Text);
            int tipo = Convert.ToInt32(rbtLstRating.SelectedItem.Value);
            int factura = wsb.registrar_pago(codigo, tipo);
            
            mostrar_aviso("El numero de factura es <strong>" + factura);
            limpiar();
        }

        private void mostrar_aviso(String mensaje)
        {

            String texto = "<div class=\"alert alert-success\">"
                    + "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>"
                    + "<strong>Correcto!</strong> " + mensaje
                    + "</div>";
            div_mensajes.Controls.Add(new LiteralControl(texto));

        }

        private void limpiar() {
            cod_compra.Text = "";
            
        }
    }
}