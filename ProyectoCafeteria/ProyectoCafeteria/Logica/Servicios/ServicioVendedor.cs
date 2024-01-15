using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCafeteria.Logica.Servicios
{
    public class ServicioVendedor
    {
        public const string URL_ESTUDIANTE_BASE = "http://localhost:8080/api/vendedor/";


        public static async Task<string> RegistrarProducto(Vendedor vendedor)
        {
            string mensaje;
            try
            {
                Uri SolicitudUri = new Uri(URL_ESTUDIANTE_BASE);
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(vendedor);
                StringContent contenJson = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.PostAsync(SolicitudUri, contenJson);
                mensaje = RespuestaServidor.TraducirCodigo((int)mensajeRespuestaHttp.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                mensaje = "No se pudo conectar con el servidor";
            }
            return mensaje;
        }

    }
}
