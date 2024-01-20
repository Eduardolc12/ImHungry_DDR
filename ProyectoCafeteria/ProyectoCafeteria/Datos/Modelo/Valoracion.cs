using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
    internal class Valoracion
    {
     public int id_valoracion {  get; set; }
      public string  descripcion {  get; set; }

      public int calificacion {  get; set; }
      public int id_producto {  get; set; }
    }
}
