using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
    public class Producto
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int cantidadDisponible { get; set; }
        public string horaVentaInicial { get; set; }
        public string horaVentaFinal { get; set; }
        public string puntoEncuentro { get; set; }
        public double precio { get; set; }
        public string estado { get; set; }
        public string foto { get; set; }
    }
}
