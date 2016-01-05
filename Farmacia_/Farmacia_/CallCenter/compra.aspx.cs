using Farmacia_.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Farmacia_.CallCenter
{
    public partial class compra : System.Web.UI.Page
    {
        static Pablo.WSFarmacia11Client wsb = new Pablo.WSFarmacia11Client();
        private static List<List<string>> compras = new List<List<string>>();
        public static String setTabla1 = "";
        public static String setTabla2 = "";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            d.Controls.Clear();
            var datos = wsb.buscar_cliente(this.nit_cliente.Text);

            if (datos != null)
            {
                dir_cliente.Text = datos.id.ToString();
                mostrar("Cliente registrado");
            }
            else
            {
                mostrar("Cliente no registrado");
            }
        }

        private void mostrar(String texto)
        {
            d.Controls.Add(new LiteralControl("<p class=\"text-success\">" + texto + "</p>"));
            div_mostrar.Controls.Add(new LiteralControl(setTabla1));
            div_mostrar2.Controls.Add(new LiteralControl(setTabla2));
        }

        private static String getStringTablaMedic(List<Pablo.producto> lista)
        {
            if (lista.Count > 0)
            {
                setTabla1 = "<br/><table class=\"table table-bordered\">" +
                                "<thead><tr><th>Codigo</th><th>Nombre</th><th>Descripcion</th><th>Precion unitario</th><th>Accion</th></thead>" +
                                "<tbody>";
                for (int i = 0; i < lista.Count; i++)
                {
                    setTabla1 += "<tr><td>" + lista[i].id+ "</td>"
                                + "<td>" + lista[i].nombre+ "</td>"
                                + "<td>" + lista[i].descripcion + "</td>"
                                + "<td>" + lista[i].precio + "</td>"
                                + "<td><button id=\"btnO" + i + "\" class=\"btn btn-success\"onClick='agregar_codigo(" + lista[i].id+ "); return false;'>Agregar</button></td>"
                          + "</tr>";
                }
                setTabla1 += "</tbody></table>";
            }
            else
            {
                setTabla1 = "<p>No se encontro el medicamento</p>";
            }
            return setTabla1;
        }

        private static string getStringTablaCompras()
        {

            if (compras.Count > 0)
            {
                setTabla2 = "<br/><table class=\"table table-bordered\">" +
                         "<thead><tr><th>Medicamento</th><th>Cantidad</th><th>Accion</th></thead>" +
                         "<tbody>";
                for (int i = 0; i < compras.Count; i++)
                {
                    setTabla2 += "<tr><td>" + compras[i].ElementAt(0) + "</td>"
                                + "<td><span class=\"badge\">" + compras[i].ElementAt(1) + "</span></td>"
                                + "<td><button id=\"btnt2" + i + "\" class=\"btn btn-warning\"onClick='borrar_codigo(" + compras[i].ElementAt(0) + "); return false;'>Borrar</button></td>"
                          + "</tr>";
                }
                setTabla2 += "</tbody></table>";
            }
            else
            {
                setTabla2 = "<p>No hay elementos disponibles</p>";
            }

            return setTabla2;
        }

        public static List<Pablo.producto> buscar_nombre(List<Pablo.producto> lista, String nombre)
        {
            List<Pablo.producto> respuesta = new List<Pablo.producto>();
            for (int t = 0; t < lista.Count; t++)
            {
                if (lista[t].nombre.Contains(nombre))
                {
                    respuesta.Add(lista[t]);
                }
            }
            return respuesta;
        }

        private static int buscar(string codigo)
        {
            int respuesta = 0;
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].ElementAt(0).Equals(codigo))
                {
                    respuesta = 1;
                }
            }
            return respuesta;
        }

        private static void agregar(string codigo)
        {
            if (buscar(codigo) == 0)
            {
                List<string> agree = new List<string>();
                agree.Add(codigo);
                agree.Add("1");
                compras.Add(agree);
            }
            else
            {
                for (int i = 0; i < compras.Count; i++)
                {
                    if (compras[i].ElementAt(0).Equals(codigo))
                    {
                        int cantidad = Convert.ToInt32(compras[i].ElementAt(1));
                        compras[i][1] = Convert.ToString(cantidad + 1);
                    }
                }
            }
        }

        private static void borrar(string codigo)
        {
            List<List<string>> aux = new List<List<string>>();
            for (int i = 0; i < compras.Count; i++)
            {
                if (!compras[i].ElementAt(0).Equals(codigo))
                {
                    aux.Add(compras[i]);
                }
            }
            compras = aux;
        }


        [System.Web.Services.WebMethod]
        public static string GetCurrentTable(string codigo, string accion)
        {
            if (accion.Equals("0"))
            {
                borrar(codigo);
            }
            else if (accion.Equals("1"))
            {
                agregar(codigo);
            }
            return getStringTablaCompras();
        }

        [System.Web.Services.WebMethod]
        public static string GetTablaMedicamentos(string nombre)
        {
            int codigo_farmacia = Convert.ToInt32(System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt")); ;
            String resultado = "";

            var datos = wsb.consultar_catalogo_medicamentos();
            List<Pablo.producto> lista = datos.ToList<Pablo.producto>();

            if (datos != null)
            {
                //obtengo datos de web service
               
                if ( lista.Count> 0)
                {
                    //aplico filtros
                    if (nombre != "")
                    {
                        lista = buscar_nombre(lista, nombre);
                    }

                    //envio resultados
                    resultado = getStringTablaMedic(lista);
                }
                else
                {
                    resultado = "<p>No hay medicamentos para mostrar</p>";
                }
            }
            else
            {
                resultado = "<p>Hubo un error al cargar medicamentos</p>";
            }
            return resultado;
        }

        public void realizar_compra()
        {
            
            int tienda = Convert.ToInt32(System.IO.File.ReadAllText("/Farmacia/codigo_tienda.txt"));
            
            Pablo.cliente datos_cliente = wsb.buscar_cliente(nit_cliente.Text);
            int cliente = Convert.ToInt32(datos_cliente.id);

            int pedido = wsb.agregar_pedido(cliente,Int32.Parse(this.id_callcenter.Text));


            for (int i = 0; i < compras.Count; i++)
            {
                wsb.agregar_detalle_pedido(pedido,Convert.ToInt32(compras[i].ElementAt(0)),Convert.ToInt32(compras[i].ElementAt(1)));

            }

            Pablo.pago valor= wsb.pagar_pedido(pedido,1,false);
            mostrar_aviso("El codigo de compra es <strong>" +pedido + "</strong> Y el total es <strong>Q" + valor.total + "</strong>");
            limpiar();
        
        }

        public void cancelar_compra()
        {
            limpiar();
        }

        public void limpiar()
        {
            nit_cliente.Text = "";
            dir_cliente.Text = "";
            nom_comercial.Text = "";
            div_mostrar.Controls.Add(new LiteralControl(""));
            div_mostrar2.Controls.Add(new LiteralControl(""));
            compras.Clear();
            setTabla1 = "";
            setTabla2 = "";
        }

        public ArrayOfInt obtener_codigos()
        {
            ArrayOfInt resultado = new ArrayOfInt();
            for (int i = 0; i < compras.Count; i++)
            {
                resultado.Add(Convert.ToInt32(compras[i].ElementAt(0)));
            }
            return resultado;
        }

        public ArrayOfInt obtener_unidades()
        {
            ArrayOfInt resultado = new ArrayOfInt();
            for (int i = 0; i < compras.Count; i++)
            {
                resultado.Add(Convert.ToInt32(compras[i].ElementAt(1)));
            }
            return resultado;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            realizar_compra();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            cancelar_compra();
        }

        private void mostrar_aviso(String mensaje)
        {

            String texto = "<div class=\"alert alert-success\">"
                    + "<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>"
                    + "<strong>Correcto!</strong> " + mensaje
                    + "</div>";
            div_mensajes.Controls.Add(new LiteralControl(texto));

        }
    }
}