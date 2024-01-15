using System;
using System.Threading.Tasks;
using ProyectoCafeteria.Datos.Modelo;
using System.Net.Http;
using ProyectoCafeteria.Utilidades;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ProyectoCafeteria.Logica.Servicios
{
    public class ServicioEstudiante
    {

        public const string URL_ESTUDIANTE_BASE = "http://localhost:8080/api/estudiantes/";

        public static async Task<Estudiante> IniciarSesion(string correoInstitucional, string password)
        {

            Estudiante estudiante1 = new Estudiante();
            estudiante1.correoInstitucional = correoInstitucional;
            estudiante1.password = password;

            try
            {
                Uri solicitudUri = new Uri(URL_ESTUDIANTE_BASE + "login");
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(estudiante1);

                StringContent contenJson = new StringContent(jsonString, Encoding.UTF8, "application/json");

                HttpResponseMessage mensajeRespuestaHttp = await clienteHttp.PostAsync(solicitudUri, contenJson);

                if (mensajeRespuestaHttp.IsSuccessStatusCode)
                {
                    var jsonstring = await mensajeRespuestaHttp.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(jsonstring);
                    JObject estudianteObject = jsonObject["estudiante"].Value<JObject>();

                    // Convertir el objeto "estudiante" a una cadena JSON
                    var nuevoJsonString = estudianteObject.ToString();

                    Estudiante estudiante = new Estudiante();
                    estudiante = JsonConvert.DeserializeObject<Estudiante>(nuevoJsonString);
                    Console.WriteLine($"Respuesta no exitos" + jsonstring);

                    return estudiante; // Devolver el estudiante correctamente deserializado
                }
                else
                {
                    // Manejar el caso de respuesta no exitosa
                    Console.WriteLine($"Respuesta no exitosa: {mensajeRespuestaHttp.StatusCode}");
                    return null;
                }
            }
            catch (Exception e)
            {
                // Manejar otras excepciones
                Console.WriteLine($"Error general: {e.Message}");
                return null;
            }
        }

        public static async Task<string> RegistrarEstudiante(Estudiante estudiante)
        {
            string mensaje;
            try
            {
                Uri SolicitudUri = new Uri(URL_ESTUDIANTE_BASE);
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(estudiante);
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

        public static async Task<string> ActualizarEstudiante(Estudiante estudiante)
        {
            string mensaje;
            try
            {
                string SolicitudUri = URL_ESTUDIANTE_BASE + estudiante.matricula;
                HttpClient clienteHttp = new HttpClient();
                string jsonString = JsonConvert.SerializeObject(estudiante);
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



        public static async Task<string> EliminarEstudiante(Estudiante estudiante)
        {
            string mensaje;
            try
            {
                string SolicitudUri = URL_ESTUDIANTE_BASE + estudiante.matricula;
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
