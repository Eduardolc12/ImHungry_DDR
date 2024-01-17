using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public string preferencias { get; set; }
        public DateTime fechaPedido { get; set; }
        public double precioTotal { get; set; }
        public string estado { get; set; }
        public int id_venta { get; set; }
        public string matricula { get; set; }
        public int id_producto { get; set; }
    }
}
