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
    public class ServicioPedido
    {
        public const string URL_PEDIDO_BASE = "http://localhost:8080/api/pedido/";

        public static async Task<string> RegistrarProduto(Pedido pedido)
        {
            string mensaje;
            try
            {
                Uri SolicitudUri = new Uri(URL_PEDIDO_BASE);
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(pedido);
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

        public static async Task<string> ActualizarPedido(Pedido pedido)
        {
            string mensaje;
            try
            {
                string SolicitudUri = URL_PEDIDO_BASE + pedido.idPedido;
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(pedido);
                StringContent contenJson = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.PutAsync(SolicitudUri, contenJson);
                mensaje = RespuestaServidor.TraducirCodigo((int)mensajeRespuestaHttp.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                mensaje = "No se pudo conectar con el servidor";
            }
            return mensaje;
        }



        public static async Task<string> EliminarPedido(Pedido pedido)
        {
            string mensaje;
            try
            { 

                string SolicitudUri = URL_PEDIDO_BASE + pedido.idPedido;
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

        public static async Task<List<Pedido>> ConsultarPedidos()
        {
            List<Pedido> listaPedidoAPI = new List<Pedido>();
            try
            {
                Uri SolicitudUri = new Uri(URL_PEDIDO_BASE+"all");
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    listaPedidoAPI = JsonConvert.DeserializeObject<List<Pedido>>(jsonString);
                }
                else
                {
                    listaPedidoAPI = new List<Pedido>();
                    Pedido pedido = new Pedido();
                    listaPedidoAPI.Add(pedido);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                listaPedidoAPI = null;
            }
            return listaPedidoAPI;
        }

        public static async Task<List<Pedido>> ConsultarPedidosVendedor(string matricula)
        {
            List<Pedido> listaPedidoAPI = new List<Pedido>();
            try
            {

                string SolicitudUri = URL_PEDIDO_BASE+matricula;
                HttpClient clienteHttp = new HttpClient();
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
               
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                  
                    listaPedidoAPI = JsonConvert.DeserializeObject<List<Pedido>>(jsonString);
                

                }
                else
                {
                    listaPedidoAPI = new List<Pedido>();
                    Pedido pedido = new Pedido();
                    listaPedidoAPI.Add(pedido);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                listaPedidoAPI = null;
            }
            return listaPedidoAPI;
        }
    }
}
