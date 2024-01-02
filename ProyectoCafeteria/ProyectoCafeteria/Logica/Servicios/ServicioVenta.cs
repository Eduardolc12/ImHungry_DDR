using Newtonsoft.Json;
using ProyectoCafeteria.Datos.Modelo;
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
        public static async Task<List<Venta>> ConsultarVentas()
        {
            List<Venta> listaVentaAPI = new List<Venta>();
            try
            {
                Uri SolicitudUri = new Uri(URL_VENTA_BASE);
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    listaVentaAPI = JsonConvert.DeserializeObject<List<Venta>>(jsonString);
                }
                else
                {
                    listaVentaAPI = new List<Venta>();
                    Venta venta = new Venta();
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
    }
}
