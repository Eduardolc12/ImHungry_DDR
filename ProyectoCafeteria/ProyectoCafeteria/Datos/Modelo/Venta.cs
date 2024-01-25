using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
    public class Venta
    {
        public int id_venta { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha_venta { get; set; }
        public double precio_total { get; set; }
        public int idPedido { get; set; }
    }
}
