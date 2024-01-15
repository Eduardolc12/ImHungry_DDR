using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Datos.Modelo
{
  
    public class Estudiante
    {
        [JsonProperty("matricula")]
        public string matricula { get; set; }

        [JsonProperty("nombre")]
        public string nombre { get; set; }

        [JsonProperty("apellidoPaterno")]
        public string apellidoPaterno { get; set; }

        [JsonProperty("apellidoMaterno")]
        public string apellidoMaterno { get; set; }

        [JsonProperty("correoInstitucional")]
        public string correoInstitucional { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("tipoVendedor")]
        public string tipoVendedor { get; set; }

        [JsonProperty("tipoComprador")]
        public string tipoComprador { get; set; }

        [JsonProperty("fotoPerfil")]
        public string fotoPerfil { get; set; }

        [JsonProperty("fotoCredencial")]
        public string fotoCredencial { get; set; }
    }
}
