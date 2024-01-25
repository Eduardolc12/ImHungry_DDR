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
    public class ServicioVenta
    {
        public const string URL_VENTA_BASE = "http://localhost:8080/api/venta/";

        public static async Task<List<VentaName>> ConsultarVentaBy(string matricula)
        {
            List<VentaName> listaVentaAPI = new List<VentaName>();
            try
            {
                Uri SolicitudUri = new Uri(URL_VENTA_BASE+"busqueda/"+matricula);
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                   
                    listaVentaAPI = JsonConvert.DeserializeObject<List<VentaName>>(jsonString);

                }
                else
                {
                    listaVentaAPI = new List<VentaName>();
                    VentaName venta = new VentaName();
                    listaVentaAPI.Add(venta);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                listaVentaAPI = null;
            }
            return listaVentaAPI;
        }

        public static async Task<string> RegistrarVenta(Venta venta)
        {
            string mensaje;
            try
            {
                Uri SolicitudUri = new Uri(URL_VENTA_BASE);
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(venta);
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
