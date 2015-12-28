using Farmacia_.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_
{
    public partial class medicamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ws.ServiceSoapClient wsb = new ws.ServiceSoapClient();
            int codigo = Convert.ToInt32(System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt"));
            
            List<ArrayOfString> datos = wsb.consultar_medicamentos(codigo);

            if (datos != null)
            {
                List<List<String>> lista = datos.ToList().ConvertAll(x => x.ToList());

                String texto = "<table class=\"table table-bordered\">" +
               "<thead><tr><th>Nombre</th><th>Descripcion</th><th>Unidades</th></tr></thead>" +
               "<tbody>";
                for (int i = 0; i < lista.Count; i++)
                {
                    texto += "<tr><td>" + lista[i].ElementAt(0) + "</td><td>" + lista[i].ElementAt(1) + "</td><td>" + lista[i].ElementAt(2) + "</td></tr>";
                }

                texto += "</tbody></table>";
                d.Controls.Add(new LiteralControl(texto));
             
            }
            else
            {
                MessageBox.Show(this, "Error: Hubo un problema al recuperar cliente");
            }
             
        }
    }
}