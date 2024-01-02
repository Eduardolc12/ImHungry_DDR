using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public int idConfiguracionPerfil { get; set; }
        public string nombre { get; set; }
        public string apellidoMaterno { get; set; }
        public string apellidoPaterno { get; set; }
        public string contrasena { get; set; }
        public string claveTrabajador { get; set; }
        public string numeroTelefono { get; set; }
        public string token { get; set; }
        public string correo { get; set; }
        public bool esCuentaConfirmada { get; set; }
        public string cargo { get; set; }
        public int codigoRespuestaServidor { get; set; }
      

    }
}
