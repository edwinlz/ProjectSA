using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Farmacia_
{
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            ws.ServiceSoapClient wsb = new ws.ServiceSoapClient();
            int respuesta = wsb.registrar_cliente(Convert.ToInt32(nit_cliente.Text), nom_cliente.Text, tel_cliente.Text, dir_cliente.Text);
            if (respuesta != -1)
            {
                limpiar();
                MessageBox.Show(this, "Se ingreso cliente: "+respuesta);
            }
            else {
                MessageBox.Show(this, "Error al ingresar cliente");
            }
            
        }

        private void limpiar() {
            nit_cliente.Text = "";
            nom_cliente.Text = "";
            tel_cliente.Text = "";
            dir_cliente.Text = "";
        }


    }

    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(), "MessageBox","<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }


}