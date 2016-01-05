using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farmacia_.Servicio;

namespace Farmacia_.CallCenter
{
    public partial class pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        

        
        protected void Button1_Click1(object sender, EventArgs e)
        {
            int code =Int32.Parse(this.id_farmacia.Text);
            busqueda(code);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            busqueda(0);
        }

        private void busqueda(int param) {
            Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();



            String texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Cliente</th><th>Estado</th><th>Fecha</th></tr></thead>" +
                                "<tbody>";
            foreach (var item in wsb.obtener_pedidos(param))
            {

                texto += "<tr>" +
                     "<td>" + item.id + "</td><td>" + item.cliente + "</td><td>" + item.estado + "</td>" +"</td><td>" +item.fecha.ToString()+ "</td>" +
                     "</tr>";

            }

            texto += "</tbody></table>";
            d.Controls.Add(new LiteralControl(texto));
        }
    }
}