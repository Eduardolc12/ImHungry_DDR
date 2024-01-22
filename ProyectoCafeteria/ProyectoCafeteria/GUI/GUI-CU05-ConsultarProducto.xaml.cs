using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoCafeteria.GUI
{
    /// <summary>
    /// Lógica de interacción para GUI_CU05_ConsultarProducto.xaml
    /// </summary>
    public partial class GUI_CU05_ConsultarProducto : Page
    {
        Estudiante usuarioLogueado;
        List<Producto> listaProductosEncontrados;
        Producto productoSeleccionado;
        public GUI_CU05_ConsultarProducto(Estudiante usuarioLogueado)
        {
            this.usuarioLogueado = usuarioLogueado;
            InitializeComponent();
        }


        private void PedidoButton_Click(object sender, RoutedEventArgs e)
        {
            if (productoSeleccionado != null)
            {
                GUI_CU06_RealizarPedido guiRealizarPedido = new GUI_CU06_RealizarPedido(productoSeleccionado,usuarioLogueado.matricula);
                guiRealizarPedido.Owner = Application.Current.MainWindow;
                guiRealizarPedido.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un producto primero");
            }
            ConsultarProductos();
        }

        private async void VisualizarButton_Click(object sender, RoutedEventArgs e)
        {
            if (productoSeleccionado != null)
            {
                if (!string.IsNullOrEmpty(productoSeleccionado.foto))
                {
                    byte[] imageBytes = Convert.FromBase64String(productoSeleccionado.foto);
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(imageBytes);
                    bitmapImage.EndInit();
                    imageProducto.Source = bitmapImage;
                }


            }
            else
            {
                MessageBox.Show("Seleccione un producto primero");
            }
            ConsultarProductos();
        }

        private void RegistrarButton_Click(object sender, RoutedEventArgs e)
        {

            ConsultarProductos();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            ProductosDataGrid.ItemsSource = null;
            ConsultarProductos();
        }

        private void ProductosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.productoSeleccionado = this.ProductosDataGrid.SelectedItem as Producto;

        }

        private async void ConsultarProductos()
        {

            listaProductosEncontrados = await ServicioProducto.ConsultarProductos();

            if (listaProductosEncontrados == null) MessageBox.Show("Error al conectarse con el servidor");
            else
            {

                ProductosDataGrid.ItemsSource = listaProductosEncontrados;

            }
        }

        private async void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            Producto producto = new Producto();

            producto.nombre = BusquedaTextBox.Text.Trim();

            if (producto.nombre != null)
            {

                Producto producto1 = await ServicioProducto.ConsultarProductoPorNombre(producto.nombre);
                if (producto1 != null)
                {
                    List<Producto> productoBusqueda = new List<Producto>();

                    productoBusqueda.Add(producto1);
                    ProductosDataGrid.ItemsSource = productoBusqueda;
                }
                else
                {
                    MessageBox.Show("No se encontro un producto con el nombre");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre para la busqueda");
            }
        }

        private async void AñadirButton_Click(object sender, RoutedEventArgs e)
        {
            if (productoSeleccionado != null)
            {
                ProductosFavoritos producto = new ProductosFavoritos();
                producto.matricula = usuarioLogueado.matricula;
                producto.id_producto = productoSeleccionado.id_producto;

                var mensaje = await ServicioFavoritos.RegistrarFavorito(producto);
                MessageBox.Show("Se ha añadido a favoritos");

            }
            else
            {
                MessageBox.Show("Seleccione un producto primero");
            }
        }
    }
}
