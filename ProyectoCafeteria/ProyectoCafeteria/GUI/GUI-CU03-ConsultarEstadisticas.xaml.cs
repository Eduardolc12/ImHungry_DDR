using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
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
    /// <summary>
    /// Lógica de interacción para GUI_CU03_ConsultarEstadisticas.xaml
    /// </summary>
    public partial class GUI_CU03_ConsultarEstadisticas : Page
    {
        Estudiante usuario;
        List<VentaName> listaVentasEncontradas;
        public GUI_CU03_ConsultarEstadisticas(Estudiante usuario)
        {
            this.usuario = usuario;
            InitializeComponent();
        }

        private async void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            listaVentasEncontradas = await ServicioVenta.ConsultarVentaBy(usuario.matricula);

            if (listaVentasEncontradas == null) MessageBox.Show("Error al conectarse con el servidor");
            else
            {

                estadisticaSf.ItemsSource= listaVentasEncontradas;


            }
        }

        private void VentasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
