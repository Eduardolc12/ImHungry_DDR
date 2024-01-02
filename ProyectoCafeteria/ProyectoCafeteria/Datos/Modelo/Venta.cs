using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaVenta { get; set; }
        public double PrecioTotal { get; set; }
    }
}
