using ProyectoCafeteria.Datos.Modelo;
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
using System.Windows.Shapes;

namespace ProyectoCafeteria.GUI
{
    /// <summary>
    /// Lógica de interacción para ventanaEmergente.xaml
    /// </summary>
    public partial class ventanaEmergente : Window
    {

        Estudiante usuarioLogueado;
        public ventanaEmergente(Estudiante usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
        }

        private void PerfilVendedorButton_Click(object sender, RoutedEventArgs e)
        {
            MenuEmpleado guiMenuEmpleado = new MenuEmpleado(usuarioLogueado);
            Application.Current.MainWindow.Content = guiMenuEmpleado;
            this.Close();
        }

        private void PerfilCompradorButton_Click(object sender, RoutedEventArgs e)
        {
            MenuCliente guiMenuCliente = new MenuCliente(usuarioLogueado);
            Application.Current.MainWindow.Content = guiMenuCliente;
            this.Close();
        }
    }
}
