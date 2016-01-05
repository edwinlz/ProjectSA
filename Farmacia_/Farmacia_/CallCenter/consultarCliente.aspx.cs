using Farmacia_.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Collections;
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


            var cliente = wsb.buscar_cliente(this.nit_cliente.Text);


            String texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Nit</th></tr></thead>" +
                                "<tbody><tr>" +
                                 "<td>" + cliente.id+ "</td><td>" + cliente.nombre+ "</td><td>" + cliente.nit + "</td>" +
                                 "</tr>";
/*

           foreach (var item in wsb.consultar_catalogo_clientes())
            {
            
                            texto += "<tr>" +
                                 "<td>" + item.id+ "</td><td>" + item.nombre + "</td><td>" + item.nit + "</td>" +
                                 "</tr>";
                
            }
            */
           texto += "</tbody></table>";
           d.Controls.Add(new LiteralControl(texto));
        
        }
    }

}