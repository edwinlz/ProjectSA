using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farmacia_.Servicio;

namespace Farmacia_.CallCenter
{
    public partial class medicamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar();
        }

        //Carga la lista de medicamentos
        private void cargar()
        {
            d.Controls.Clear();
            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
            int codigo = Int32.Parse(System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt"));
            Servicio.ArrayOfMedicamento datos = wsb.consultar_medicamentos(codigo);

            if (datos != null)
            {
                //obtengo datos de web service
                List<Servicio.medicamento> lista = datos.ToList();
                if (lista.Count > 0)
                {
                    //envio resultados
                    String texto = getTablaMedicamentos(lista);
                    mostrar(texto);
                }
                else {

                    mostrar("<p>No hay medicamentos disponibles</p>");
                }
            }
            else
            {
                mostrar("<p>No hay medicamentos disponibles</p>");               
            }
        }

        private void mostrar(String texto) {
            d.Controls.Add(new LiteralControl(texto));
        }

        //Devuelve cadena de la tabla en formato HTML para la lista de medicamentos
        public String getTablaMedicamentos(List<Servicio.medicamento> lista)
        {
            String texto = "";
            if (lista.Count > 0)
            {
                texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Descripcion</th><th>Precio unitario</th><th>Unidades</th></thead>" +
                                "<tbody>";
                for (int i = 0; i < lista.Count; i++)
                {
                    texto += "<tr><td>" + lista[i].codigo_medicamento + "</td><td>" + lista[i].nombre + "</td><td>" + lista[i].descripcion +"</td><td>" + lista[i].cantidad_disponible + "</td><td><span class=\"badge\">" + lista[i].cantidad_disponible + "</span></td></tr>";
                }
                texto += "</tbody></table>";
            }
            else
            {
                texto = "<p>No se encontro el medicamento</p>";
            }
            return texto;
        }
    }
}