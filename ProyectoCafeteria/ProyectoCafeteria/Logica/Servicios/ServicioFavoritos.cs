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
    internal class ServicioFavoritos
    {
        public const string URL_FAVORITOS_BASE = "http://localhost:8080/api/productosFavoritos/";

        public static async Task<string> RegistrarFavorito(ProductosFavoritos producto)
        {
            string mensaje;
            try
            {
                Uri SolicitudUri = new Uri(URL_FAVORITOS_BASE);
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(producto);
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

        public static async Task<List<Producto>> ConsultarProductoByM(string matricula)
        {
            List<Producto> listaProductosAPI = new List<Producto>();
            try
            {
                string SolicitudUri = URL_FAVORITOS_BASE + matricula;
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    listaProductosAPI = JsonConvert.DeserializeObject<List<Producto>>(jsonString);
                }
                else
                {
                    listaProductosAPI = new List<Producto>();
                    Producto producto = new Producto();
                    listaProductosAPI.Add(producto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                listaProductosAPI = null;
            }
            return listaProductosAPI;
        }

        public static async Task<ProductosFavoritos> ConsultarFav(int id_producto)
        {
            ProductosFavoritos favoritos = new ProductosFavoritos();
            try
            {
                string SolicitudUri = URL_FAVORITOS_BASE +"busqueda/"+id_producto;
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    favoritos = JsonConvert.DeserializeObject<ProductosFavoritos>(jsonString);
                }
                else
                {
                    favoritos = new ProductosFavoritos();
                    ProductosFavoritos producto = new ProductosFavoritos();
                 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               favoritos = null;
            }
            return favoritos;
        }

        public static async Task<string> EliminarFavorito(int idFavoritos )
        {
            string mensaje;
            try
            {
                string SolicitudUri = URL_FAVORITOS_BASE +idFavoritos;
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.DeleteAsync(SolicitudUri);
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
