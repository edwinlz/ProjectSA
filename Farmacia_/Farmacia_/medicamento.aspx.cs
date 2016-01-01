﻿//using Farmacia_.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farmacia_.Servicio;

namespace Farmacia_
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
            //int codigo = Convert.ToInt32(System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt"));
            String texto = "";
            int codigo = 0;
            bool result = int.TryParse(cod_farmacia.Text, out codigo); //i now = 108

            if (result != false)
            {
                List<ArrayOfString> datos = wsb.consultar_medicamentos(codigo);
                if (datos != null)
                {
                    //obtengo datos de web service
                    List<List<String>> lista = datos.ToList().ConvertAll(x => x.ToList());
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
                        texto = obtener_tabla(lista);
                        d.Controls.Add(new LiteralControl(texto));
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

        public String obtener_tabla(List<List<String>> lista)
        {
            String texto = "";
            if (lista.Count > 0)
            {
                texto = "<table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Descripcion</th><th>Unidades</th></thead>" +
                                "<tbody>";
                for (int i = 0; i < lista.Count; i++)
                {
                    texto += "<tr><td>" + lista[i].ElementAt(3) + "</td><td>" + lista[i].ElementAt(0) + "</td><td>" + lista[i].ElementAt(1) + "</td><td><span class=\"badge\">" + lista[i].ElementAt(2) + "</span></td></tr>";
                }
                texto += "</tbody></table>";
            }
            else
            {
                texto = "<p>No se encontro el medicamento</p>";
            }
            return texto;
        }

        public List<List<String>> buscar_codigo(List<List<String>> lista, String codigo)
        {
            List<List<String>> respuesta = new List<List<String>>();
            for (int t = 0; t < lista.Count; t++)
            {
                if (lista[t].ElementAt(3).Equals(codigo))
                {
                    respuesta.Add(lista[t]);
                }
            }
            return respuesta;
        }

        public List<List<String>> buscar_nombre(List<List<String>> lista, String nombre)
        {
            List<List<String>> respuesta = new List<List<String>>();
            for (int t = 0; t < lista.Count; t++)
            {
                if (lista[t].ElementAt(0).Contains(nombre))
                {
                    respuesta.Add(lista[t]);
                }
            }
            return respuesta;
        }
    }
}