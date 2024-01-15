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
    /// Lógica de interacción para GUI_CU02_ModificarProducto.xaml
    /// </summary>
    public partial class GUI_CU02_ModificarProducto : Window
    {
        Producto productoAModificar;
      
        string rutaImagen;
        string nombreImagen;
        string fotoProducto;
        public GUI_CU02_ModificarProducto(Producto productoAModificar)
        {
            this.productoAModificar = productoAModificar;
            InitializeComponent();
           
            CargarInformacionProducto();
        }

        private void CargarInformacionProducto()
        {
            


            nombreTb.Text = productoAModificar.nombre;
            descripcionTb.Text = productoAModificar.descripcion;
            cantidadTb.Text = productoAModificar.cantidadDisponible.ToString();
            ventaITb.Text = productoAModificar.horaVentaInicial.ToString();
            ventafTb.Text = productoAModificar.horaVentaFinal.ToString();
            precioTb.Text = productoAModificar.precio.ToString();
            puntoETb.Text = productoAModificar.puntoEncuentro;
            estadoTb.Text = productoAModificar.estado;
          

            if (!string.IsNullOrEmpty(productoAModificar.foto))
            {
                byte[] imageBytes = Convert.FromBase64String(productoAModificar.foto);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                ImageProducto.Source = bitmapImage;
            }

            

        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {

                productoAModificar.nombre = nombreTb.Text.Trim();
                productoAModificar.descripcion = descripcionTb.Text.Trim();
                productoAModificar.cantidadDisponible = int.Parse(cantidadTb.Text.Trim());
                productoAModificar.horaVentaInicial = ventaITb.Text.Trim();
                productoAModificar.horaVentaFinal = ventafTb.Text.Trim();
                productoAModificar.precio = float.Parse(precioTb.Text.Trim());
                productoAModificar.puntoEncuentro = puntoETb.Text.Trim();
                productoAModificar.estado= estadoTb.Text.Trim();
                productoAModificar.foto = fotoProducto;
              
                MessageBox.Show(await ServicioProducto.ActualizarProducto(productoAModificar));
                CargarInformacionProducto();
                this.Close();
            }
        }

        public bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex expresionRegularLetras = new Regex(@"[a-zA-z]");
            Regex expresionRegularNumeros = new Regex(@"[0-9]");
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");
            if (string.IsNullOrEmpty(nombreTb.Text)) MessageBox.Show("El nombre no puede quedar vacio");
            else if (string.IsNullOrEmpty(descripcionTb.Text)) MessageBox.Show("no puede quedar vacio o contener espacios");
            else if (expresionRegularNumeros.IsMatch(nombreTb.Text) || caracteresEspeciales.IsMatch(nombreTb.Text)) MessageBox.Show("El nombre solo puede contener letras");
            else if (expresionRegularLetras.IsMatch(precioTb.Text) || caracteresEspeciales.IsMatch(precioTb.Text)) MessageBox.Show("El precio solo puede tener numeros");
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
                ImageProducto.Source = new BitmapImage(nuevaUriImagen);
                this.fotoProducto = ConvertImageToBase64(this.rutaImagen);


            }
        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
        }
    }
}
