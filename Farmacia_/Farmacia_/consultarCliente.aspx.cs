using Farmacia_.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_
{
    public partial class consultarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
            ArrayOfString datos = wsb.consultar_cliente(nit_cliente.Text);

            if (datos != null)
            {
                List<String> lista = datos.ToList();
                String texto = "<table class=\"table table-bordered\">" +
               "<thead><tr><th>Codigo</th><th>Nombre</th><th>Direccion</th></tr></thead>" +
               "<tbody><tr>" +
               "<td>" + lista[0] + "</td><td>" + lista[1] + "</td><td>" + lista[2] + "</td>" +
               "</tr></tbody></table>";
                d.Controls.Add(new LiteralControl(texto));

            }
            else
            {
                MessageBox.Show(this, "Error: Hubo un problema al recuperar cliente");
            }
        }
    }

}