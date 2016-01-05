using Farmacia_.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.CallCenter
{
    public partial class consultarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();
            String texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Apellido</th></tr></thead>" +
                                "<tbody>";
           foreach (var item in wsb.consultar_catalogo_clientes())
            {
            
                            texto += "<tr>" +
                                 "<td>" + item.id+ "</td><td>" + item.nombre + "</td><td>" + item.nit + "</td>" +
                                 "</tr>";
                
            }

           texto += "</tbody></table>";
           d.Controls.Add(new LiteralControl(texto));
            /*if (!String.IsNullOrEmpty(lista.id_cliente))
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
             * */
        }
    }

}