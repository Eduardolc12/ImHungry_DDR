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
    /// Lógica de interacción para GUI_CU08_ConsultarFavoritos.xaml
    /// </summary>
    public partial class GUI_CU08_ConsultarFavoritos : Page
    {
        Estudiante usuarioLogueado;
        List<Producto> listaProductosEncontrados;
        Producto productoSeleccionado;
        public GUI_CU08_ConsultarFavoritos(Estudiante usuarioLogueado)
        {
            this.usuarioLogueado = usuarioLogueado;
        
            ConsultarProductos();
            InitializeComponent();
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

       
      
        private void ProductosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.productoSeleccionado = this.ProductosDataGrid.SelectedItem as Producto;

        }

        private async void ConsultarProductos()
        {

            listaProductosEncontrados = await ServicioFavoritos.ConsultarProductoByM(usuarioLogueado.matricula);

            if (listaProductosEncontrados == null) MessageBox.Show("Error al conectarse con el servidor");
            else
            {

                ProductosDataGrid.ItemsSource = listaProductosEncontrados;

            }
        }

        private async void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (productoSeleccionado != null)
            {
                if (MessageBox.Show("Esta seguro de eliminar el producto, esta accion no se puede deshacer", "Eliminar Producto",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var favorito = await ServicioFavoritos.ConsultarFav(productoSeleccionado.id_producto);
                    MessageBox.Show(await ServicioFavoritos.EliminarFavorito(favorito.idFavoritos));
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto primero");
            }
            ConsultarProductos();
        }
    }
}
