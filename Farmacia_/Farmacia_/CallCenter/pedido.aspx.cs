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

            string texto = "";
           texto+= busqueda(code);
            texto+=Detalle(code);
            d.Controls.Add(new LiteralControl(texto));
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            
            d.Controls.Add(new LiteralControl(busqueda(0)));
        }

        private string Detalle(int code) {


            Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();



            String texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Producto</th><th>Cantidad</th><th>Precio Unitario</th><th>subtotal</th></tr></thead>" +
                                "<tbody>";
            foreach (var item in wsb.obtener_detalle_pedido(code))
            {

                texto += "<tr>" +
                     "<td>" + item.cliente + "</td><td>" + item.id + "</td><td>" +item.total+ "</td><td>"+item.subTotal+"</td>"+
                     "</tr>";

            }

            texto += "</tbody></table>";

            return texto;
        }

        private string busqueda(int param) {
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
            return texto;
            
        }
    }
}