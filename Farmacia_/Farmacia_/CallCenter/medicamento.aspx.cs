//using Farmacia_.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farmacia_.Servicio;

namespace Farmacia_.CallCenter
{
    public partial class medicamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            d.Controls.Clear();
            String texto = "";
            Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();
            if (cod_medicamento.Text != "")
            {
                texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Descripcion</th><th>Precio</th></tr></thead>" +
                                "<tbody>";
                foreach (var item in wsb.consultar_catalogo_medicamentos())
                {

                    if (item.id == Int32.Parse(cod_medicamento.Text))
                    {
                        texto += "<tr>" +
                         "<td>" + item.id + "</td><td>" + item.nombre + "</td><td>" + item.descripcion + "</td><td>" + item.precio + "</td>" +
                         "</tr>";
                    }
                }

                texto += "</tbody></table>";
            }
            else if (nom_comercial.Text != "")
            {
                texto = "<table class=\"table table-bordered\">" +
                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Descripcion</th><th>Precio</th></tr></thead>" +
                "<tbody>";
                foreach (var item in wsb.consultar_catalogo_medicamentos())
                {

                    if (item.nombre.Equals(nom_comercial.Text))
                    {
                        texto += "<tr>" +
                         "<td>" + item.id + "</td><td>" + item.nombre + "</td><td>" + item.descripcion + "</td><td>" + item.precio + "</td>" +
                         "</tr>";
                    }
                }

                texto += "</tbody></table>";
            }
            else 
            {
                texto = "LLene un campo";
            }
            d.Controls.Add(new LiteralControl(texto));
        }

        public String obtener_tabla(List<Servicio.medicamento> lista)
        {
            String texto = "";
            if (lista.Count > 0)
            {
                texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Nombre Producto</th><th>Descripcion</th><th>Codigo</th><th>Precio</th><th>Cantidad Disponible</th></thead>" +
                                "<tbody>";
                for (int i = 0; i < lista.Count; i++)
                {
                    texto += "<tr><td>" + lista[i].nombre.ToString() + "</td><td>" + lista[i].descripcion + "</td><td>" +lista[i].codigo_medicamento+ "</td><td>" + lista[i].precio_unitario + "</td><td><span class=\"badge\">" + lista[i].cantidad_disponible + "</span></td></tr>";
                }
                texto += "</tbody></table>";
            }
            else
            {
                texto = "<p>No se encontro el medicamento</p>";
            }
            return texto;
        }

        public List<Servicio.medicamento> buscar_codigo(List<Servicio.medicamento> lista, String codigo)
        {
            List<Servicio.medicamento> respuesta = new List<Servicio.medicamento>();
            for (int t = 0; t < lista.Count; t++)
            {
                int cod =Int32.Parse(codigo);
                if (lista[t].codigo_medicamento.Equals(cod))
                {
                    respuesta.Add(lista[t]);
                }
            }
            return respuesta;
        }

        public List<Servicio.medicamento> buscar_nombre(List<Servicio.medicamento> lista, String nombre)
        {
            List<Servicio.medicamento> respuesta = new List<Servicio.medicamento>();
            for (int t = 0; t < lista.Count; t++)
            {
                if (lista[t].nombre.Contains(nombre))
                {
                    respuesta.Add(lista[t]);
                }
            }
            return respuesta;
        }
    }
}