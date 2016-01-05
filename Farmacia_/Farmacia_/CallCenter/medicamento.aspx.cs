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
            Servicio.Service1SoapClient wsb = new Servicio.Service1SoapClient();
            int codigo = Convert.ToInt32(System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt"));
            String texto = "";
            
            bool result = int.TryParse(cod_farmacia.Text, out codigo); //i now = 108

            if (result != false)
            {
                
                Servicio.ArrayOfMedicamento datos = wsb.consultar_medicamentos(codigo);
                if (datos != null)
                {
                    //obtengo datos de web service
                    List<Servicio.medicamento> lista = datos.ToList();
                    if (lista.Count > 0)
                    {
                        //aplico filtros
                        if (cod_medicamento.Text != "")
                        {
                            lista = buscar_codigo(lista, cod_medicamento.Text);
                        }

                        if (nom_comercial.Text != "")
                        {
                            lista = buscar_nombre(lista, nom_comercial.Text);
                        }

                        //envio resultados
                        if (lista.Count > 0)
                        {
                            texto = obtener_tabla(lista);
                            d.Controls.Add(new LiteralControl(texto));
                        }
                        else {
                            d.Controls.Add(new LiteralControl("<p>El medicamento indicado no existe<p>"));
                        }

                    }
                    else {
                        d.Controls.Add(new LiteralControl("<p>No hay medicamentos disponibles<p>"));
                    }
                }
                else
                {
                    texto = "<p>Hubo un error al cargar medicamentos</p>";
                    d.Controls.Add(new LiteralControl(texto));
                }
            }
            else
            {
                texto = "<p>El codigo de farmacia debe ser un numero</p>";
                d.Controls.Add(new LiteralControl(texto));
            }
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