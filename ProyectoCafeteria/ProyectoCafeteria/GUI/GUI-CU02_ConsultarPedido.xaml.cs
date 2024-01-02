using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using ProyectoCafeteria.Utilidades;
using System;
using System.Collections.Generic;
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
   
    public partial class GUI_CU02_ConsultarPedido : Page
    {
        Estudiante empleadoLogueado;
        List<Pedido> listaPedidosEncontrados;
        Pedido pedido;
        public GUI_CU02_ConsultarPedido()
        {
            this.empleadoLogueado = empleadoLogueado;
            InitializeComponent();
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            if(pedido != null)
            {
                /*
                GUI_CU02_ModificarProducto guiCU02ModificarProducto = new GUI_CU02_ModificarProducto(pedido);
                guiCU02ModificarProducto.Owner = Application.Current.MainWindow;
                guiCU02ModificarProducto.ShowDialog();
                */
            }
            else
            {
                MessageBox.Show("Seleccione un producto primero");
            }
            ConsultarPedidos();
        }

       

        private void RegistrarButton_Click(object sender, RoutedEventArgs e)
        {
          
            ConsultarPedidos();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            PedidoDataGrid.ItemsSource = null;
            ConsultarPedidos();
        }

        /*
        private void ProductosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.productoSeleccionado = this.ProductosDataGrid.SelectedItem as Producto;
            if(this.productoSeleccionado != null)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
               
                    bitmap.EndInit();
                    this.ProductoImage.Source = null;
                    this.ProductoImage.Source = bitmap;
                }catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    this.ProductoImage.Source = null;
                }
            }
            else
            {
                this.ProductoImage.Source = null;
            }
        }
        */
        private async void ConsultarPedidos()
        {
           
            string consultaNombre;
            string consultaCategoria;
            string consultaExistencia;

            listaPedidosEncontrados = await ServicioPedido.ConsultarPedidos();

            if (listaPedidosEncontrados == null) MessageBox.Show("Error al conectarse con el servidor");
            else
            {
                
                    PedidoDataGrid.ItemsSource = listaPedidosEncontrados;
               
            }
        }

       

        private void PedidoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
