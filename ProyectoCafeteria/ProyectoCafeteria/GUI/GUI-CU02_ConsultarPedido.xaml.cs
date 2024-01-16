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
        Estudiante usuarioLogueado;
        List<Pedido> listaPedidosEncontrados;
        Pedido pedido;
        public GUI_CU02_ConsultarPedido()
        {
            this.usuarioLogueado = usuarioLogueado;
            InitializeComponent();
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            if(pedido != null)
            {

                GUi_ModificarPedido modificarPedido = new GUi_ModificarPedido(pedido);
                modificarPedido.Owner = Application.Current.MainWindow;
                modificarPedido.ShowDialog();
               
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
    
        private async void ConsultarPedidos()
        {
           
             
            listaPedidosEncontrados = await ServicioPedido.ConsultarPedidosVendedor(usuarioLogueado.matricula);

            if (listaPedidosEncontrados == null) MessageBox.Show("Error al conectarse con el servidor");
            else
            {
                
                    PedidoDataGrid.ItemsSource = listaPedidosEncontrados;
               
            }
        }

       

        private void PedidoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.pedido = this.PedidoDataGrid.SelectedItem as Pedido;
        }
    }
}
