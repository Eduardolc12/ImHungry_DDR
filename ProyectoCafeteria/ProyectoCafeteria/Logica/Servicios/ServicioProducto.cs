﻿ using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class ServicioProducto
    {
        public const string URL_PRODUCTO_BASE = "http://localhost:8080/api/producto/";

        public static async Task<string> RegistrarProduto(Producto producto)
        {
            string mensaje;
            try
            {
                Uri SolicitudUri = new Uri(URL_PRODUCTO_BASE);
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

        public static async Task<string> ActualizarProducto(Producto producto)
        {
            string mensaje;
            try
            {
                string SolicitudUri = URL_PRODUCTO_BASE + producto.id_producto;
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(producto);
                Console.WriteLine($"Respuesta no exitos" + jsonString);
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



        public static async Task<string> EliminarProducto(Producto producto)
        {
            string mensaje;
            try
            {
                string SolicitudUri = URL_PRODUCTO_BASE +producto.id_producto;
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

        public static async Task<List<Producto>> ConsultarProductos()
        {
            List<Producto> listaProductosAPI = new List<Producto>();
            try
            {
                string SolicitudUri = URL_PRODUCTO_BASE;
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

        public static async Task<Producto> ConsultarProductoVendedorPorNombre(string nombre,string matricula)
        {
          
            try
            {


                HttpClient clienteHttp = new HttpClient();
                string SolicitudUri = URL_PRODUCTO_BASE+nombre+","+matricula;
               
                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonString);
                    JObject estudianteObject = jsonObject["producto"].Value<JObject>();

                
                    var nuevoJsonString = estudianteObject.ToString();
                    Producto producto = new Producto();
                    producto = JsonConvert.DeserializeObject<Producto>(nuevoJsonString);

                    return producto;
                }
                else
                {
                    Console.WriteLine($"Respuesta no exitosa: {mensajeRespuestaHttp.StatusCode}");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error general: {e.Message}");
                return null;
            }
         
        }

        public static async Task<Producto> ConsultarProductoPorNombre(string nombre)
        {

            try
            {


                HttpClient clienteHttp = new HttpClient();
                string SolicitudUri = URL_PRODUCTO_BASE + nombre;

                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.GetAsync(SolicitudUri);
                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonString = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonString);
                    JObject estudianteObject = jsonObject["producto"].Value<JObject>();


                    var nuevoJsonString = estudianteObject.ToString();
                    Producto producto = new Producto();
                    producto = JsonConvert.DeserializeObject<Producto>(nuevoJsonString);

                    return producto;
                }
                else
                {
                    Console.WriteLine($"Respuesta no exitosa: {mensajeRespuestaHttp.StatusCode}");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error general: {e.Message}");
                return null;
            }

        }

    }
}
