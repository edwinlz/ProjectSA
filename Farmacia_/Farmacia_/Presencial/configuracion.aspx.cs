using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.Presencial 
{
    public partial class configuracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrar_actual();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            registrar_pago();
            mostrar_actual();
        }

        private void registrar_pago() {
            File.WriteAllText("/Farmacia/codigo_tienda.txt", cod_farmacia.Text);
            mostrar_aviso("El cambio se ha realizado con exito");
            limpiar();
        }

        private void mostrar_aviso(String mensaje)
        {
            
            String texto = "<div class=\"alert alert-success\">"
                    + "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>"
                    + "<strong>Correcto!</strong> " + mensaje
                    + "</div>";
            div_mensajes.Controls.Add(new LiteralControl(texto));

        }

        private void mostrar_codigo(String numero)
        {
            mostrar_span.Controls.Clear();
            String texto = "<h3>Codigo Actual <span class=\"label label-default\">"+numero+"</span></h3>";
            mostrar_span.Controls.Add(new LiteralControl(texto));
        }

        private void mostrar_actual() 
        {
            String codigo = System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt");
            mostrar_codigo(codigo);
        }

        private void limpiar() {
            cod_farmacia.Text = "";
            
        }
    }
}