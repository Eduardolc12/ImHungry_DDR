using Microsoft.Win32;
using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoCafeteria.GUI
{
    /// <summary>
    /// Lógica de interacción para GUI_CU06_RealizarPedido.xaml
    /// </summary>
    public partial class GUI_CU06_RealizarPedido : Window

    {
        Producto productoModificar;
        Pedido pedido;
        string matricula;

        string rutaImagen;
        string nombreImagen;
        string fotoProducto;
        public GUI_CU06_RealizarPedido(Producto productoAModificar, string mstriculaCliente)
        {
            this.productoModificar = productoAModificar;
            this.matricula = mstriculaCliente;
            InitializeComponent();
            CargarInformacionProducto();
        }

        private void CargarInformacionProducto()
        {



            nombreTb.Text = productoModificar.nombre;
            descripcionTb.Text = productoModificar.descripcion;
            cantidadTb.Text = productoModificar.cantidadDisponible.ToString();
            ventaITb.Text = productoModificar.horaVentaInicial.ToString();
            ventafTb1.Text = productoModificar.horaVentaFinal.ToString();
            precioTb1.Text = productoModificar.precio.ToString();
            puntoETb1.Text = productoModificar.puntoEncuentro;



            if (!string.IsNullOrEmpty(productoModificar.foto))
            {
                byte[] imageBytes = Convert.FromBase64String(productoModificar.foto);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                ImageProducto1.Source = bitmapImage;
            }



        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {
                int cantidad =int.Parse(cantidadTb1.Text.Trim());

                if (cantidad <= (productoModificar.cantidadDisponible))
                {

                    Pedido pedido = new Pedido();
                   
                    double total = cantidad* productoModificar.precio;
                    precioTotalTb.Text = total.ToString();
                    pedido.preferencias = preferenciasTb.Text.Trim();
                    pedido.fechaPedido = DateTime.Now;
                    pedido.precioTotal = total;
                    pedido.estado = "Disponible";
                    pedido.matricula = matricula;
                    pedido.id_producto = productoModificar.id_producto;




                    MessageBox.Show(await ServicioPedido.RegistrarPedido(pedido));

                    Producto producto = new Producto();
                    producto.id_producto = productoModificar.id_producto;
                    producto.nombre = productoModificar.nombre;
                    producto.descripcion = productoModificar.descripcion;
                    producto.cantidadDisponible = productoModificar.cantidadDisponible-cantidad;
                    producto.horaVentaInicial = productoModificar.horaVentaInicial;
                    producto.horaVentaFinal = productoModificar.horaVentaFinal;
                    producto.precio = productoModificar.precio;
                    producto.puntoEncuentro = productoModificar.puntoEncuentro;
                    producto.estado = productoModificar.estado;
                    producto.foto = productoModificar.foto;

                    var mensaje = await ServicioProducto.ActualizarProducto(producto);
                    CargarInformacionProducto();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("no puede ingresar mayor cantidad de la disponible");
                    cantidadTb1.Clear();
                    precioTotalTb.Clear();
                }
            }
        }

        public bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex expresionRegularLetras = new Regex(@"[a-zA-z]");
            Regex expresionRegularNumeros = new Regex(@"[0-9]");
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");
            if (string.IsNullOrEmpty(preferenciasTb.Text)) MessageBox.Show("El nombre no puede quedar vacio");
            else if (string.IsNullOrEmpty(cantidadTb.Text)) MessageBox.Show("no puede quedar vacio o contener espacios");

            else if (expresionRegularLetras.IsMatch(cantidadTb.Text) || caracteresEspeciales.IsMatch(cantidadTb.Text)) MessageBox.Show(" solo puede contener numeros");
            else if (expresionRegularLetras.IsMatch(precioTb1.Text) || caracteresEspeciales.IsMatch(precioTb1.Text)) MessageBox.Show("El precio solo puede tener numeros");
            else esFormularioValido = true;

            return true;
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ImagenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ventanaSelectorArchivo = new OpenFileDialog();
            ventanaSelectorArchivo.Filter = "Archivos de Imagen PNG | *.png;";
            ventanaSelectorArchivo.Title = "Cargar Archivo De Imagen";
            if (ventanaSelectorArchivo.ShowDialog() == true)
            {
                this.rutaImagen = ventanaSelectorArchivo.FileName;
                this.nombreImagen = ventanaSelectorArchivo.SafeFileName;

                Uri nuevaUriImagen = new Uri(this.rutaImagen, UriKind.Absolute);
                ImageProducto1.Source = new BitmapImage(nuevaUriImagen);
                this.fotoProducto = ConvertImageToBase64(this.rutaImagen);


            }
        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
        }


        private void ingresarCantidad(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(cantidadTb1.Text.Trim(), out double cantidad))
            {
                double total = cantidad * productoModificar.precio;
                precioTotalTb.Text = total.ToString();
            }
            else
            {
             
            }
        }
    }
}

