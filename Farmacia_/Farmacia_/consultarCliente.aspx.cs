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
            Servicio.cliente lista = wsb.consultar_cliente(nit_cliente.Text);

            if (!String.IsNullOrEmpty(lista.id_cliente))
            {
                    String texto = "<table class=\"table table-bordered\">" +
                               "<thead><tr><th>Codigo</th><th>Nombre</th><th>Apellido</th></tr></thead>" +
                               "<tbody><tr>" +
                               "<td>" + lista.id_cliente + "</td><td>" + lista.nombre + "</td><td>" + lista.apellido + "</td>" +
                               "</tr></tbody></table>";
                    d.Controls.Add(new LiteralControl(texto));
            }
            else
            {
                d.Controls.Add(new LiteralControl("<p>Ocurrio un error al recuperar cliente<p>"));
            }
        }
    }

}