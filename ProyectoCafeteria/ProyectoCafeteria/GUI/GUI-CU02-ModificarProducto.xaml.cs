using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using System;
using System.Collections.Generic;
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
        List<string> listaCategorias;
        List<string> listaEnvases;
        List<int> listaPuntosFidelidad;
        public GUI_CU02_ModificarProducto(Producto productoAModificar)
        {
            this.productoAModificar = productoAModificar;
            InitializeComponent();
            LlenarGUIComboBoxes();
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
      
            RutaImagenLabel.Content = productoAModificar.foto;
         
        }

        private void LlenarGUIComboBoxes()
        {
            listaCategorias = new List<string>();
            listaCategorias.Add("Bebida");
            listaCategorias.Add("Postre");
            listaCategorias.Add("Golosina");
            listaCategorias.Add("Platillo");
            listaEnvases = new List<string>();
            listaEnvases.Add("Bolsa");
            listaEnvases.Add("BotellaVidrio");
            listaEnvases.Add("BotellaPlastico");
            listaEnvases.Add("Lata");
            listaEnvases.Add("Ninguno");
            listaPuntosFidelidad = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                listaPuntosFidelidad.Add(i);
            }
           
        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {

                productoAModificar.nombre = nombreTb.Text.Trim();
                productoAModificar.descripcion = descripcionTb.Text.Trim();
                productoAModificar.cantidadDisponible = int.Parse(cantidadTb.Text.Trim());
                productoAModificar.horaVentaInicial = TimeSpan.Parse(ventaITb.Text.Trim());
                productoAModificar.horaVentaFinal = TimeSpan.Parse(ventafTb.Text.Trim());
                productoAModificar.precio = float.Parse(precioTb.Text.Trim());
                productoAModificar.puntoEncuentro = puntoETb.Text.Trim();
                productoAModificar.foto = "http://192.168.1.6:3000/api/Imagenes/ImagenProducto-";
              
                MessageBox.Show(await ServicioProducto.ActualizarProducto(productoAModificar));
                //                this.Close();
            }
        }

        public bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex expresionRegularLetras = new Regex(@"[a-zA-z]");
            Regex expresionRegularNumeros = new Regex(@"[0-9]");
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");
            if (string.IsNullOrEmpty(nombreTb.Text)) MessageBox.Show("El nombre no puede quedar vacio");
            else if (string.IsNullOrEmpty(descripcionTb.Text) || descripcionTb.Text.Contains(" ")) MessageBox.Show("no puede quedar vacio o contener espacios");
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

        }
    }
}
