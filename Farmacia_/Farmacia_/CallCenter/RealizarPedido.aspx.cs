using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.CallCenter
{
    public partial class RealizarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void Button1_Click1(object sender, EventArgs e)
        
        {
        
            d.Controls.Clear();
            int farmacia = 0;

            Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();

            String texto = "";
            bool result = int.TryParse(id_farmacia.Text, out farmacia);
            if (result != false)
            {
                int compra= 0;
                bool result2 = int.TryParse(this.id_compra.Text, out compra);
               if (result2)
                {

                     int resultado =wsb.agregar_pedido(farmacia,compra);
                     if (resultado == -1)
                     {
                         texto = "<p>Error en el registro del pedido</p>";
                         d.Controls.Add(new LiteralControl(texto));

                     }
                     else {

                         texto = "<p>Operaciones Exitosa</p>";
                         d.Controls.Add(new LiteralControl(texto));
                     }

                }
                else {

                    texto = "<p>El codigo de Compra debe ser un numero</p>";
                    d.Controls.Add(new LiteralControl(texto));
                
                }

            }
            else {

                texto = "<p>El codigo de farmacia debe ser un numero</p>";
                d.Controls.Add(new LiteralControl(texto));
            }

        
        }

        
    }
}