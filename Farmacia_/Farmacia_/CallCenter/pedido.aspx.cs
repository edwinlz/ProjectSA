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

        
        public String obtener_tabla(List<Servicio.pedido> lista)
        {
            String texto = "";
            if (lista.Count > 0)
            {
                texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Fecha Pedido</th><th>Nombre Cliente</th></thead>" +
                                "<tbody>";
                for (int i = 0; i < lista.Count; i++)
                {
                    texto += "<tr><td>" + lista[i].fecha + "</td><td>" + lista[i].nombre_cliente+ "</td></tr>";
                }
                texto += "</tbody></table>";
            }
            else
            {
                texto = "<p>No se encontro el medicamento</p>";
            }
            return texto;
        }

        
        protected void Button1_Click1(object sender, EventArgs e)
        {
            d.Controls.Clear();
            int codigo = 0;
            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
            String texto = "";
            bool result = int.TryParse(id_farmacia.Text, out codigo);
            if (result != false)
            {
                Servicio.ArrayOfPedido datos = wsb.consultar_pedidos(codigo);

                if (datos != null)
                {
                    //obtengo datos de web service
                    List<Servicio.pedido> lista = datos.ToList();
                    if (lista.Count > 0)
                    {

                        if (lista.Count > 0)
                        {


                            texto = obtener_tabla(lista);
                            d.Controls.Add(new LiteralControl(texto));
                        }
                        else
                        {
                            d.Controls.Add(new LiteralControl("<p>No hay pedidos en la farmacia con codigo " + this.id_farmacia + "<p>"));
                        }

                    }
                    else
                    {
                        d.Controls.Add(new LiteralControl("<p>No hay pedidos en la farmacia con codigo " + this.id_farmacia + "<p>"));

                    }
                }
                else
                {
                    texto = "<p>Hubo un error al cargar pedidos</p>";
                    d.Controls.Add(new LiteralControl(texto));
                }
            }
            else
            {
                texto = "<p>El codigo de farmacia debe ser un numero</p>";
                d.Controls.Add(new LiteralControl(texto));
            }
        }
    }
}