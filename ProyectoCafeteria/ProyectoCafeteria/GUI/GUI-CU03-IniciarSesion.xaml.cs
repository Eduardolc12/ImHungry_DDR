using Google.Protobuf.WellKnownTypes;
using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Lógica de interacción para GUI_CU03_IniciarSesion.xaml
    /// </summary>
    public partial class GUI_CU03_IniciarSesion : Page
    {
        Estudiante usuarioLogueado;
      
        public GUI_CU03_IniciarSesion()
        {
            InitializeComponent();
        }

        private async void IniciarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {
                if (ClaveTrabajadorTextBox.Text.StartsWith("zS"))
                {
                    usuarioLogueado = await ServicioEstudiante.IniciarSesion(ClaveTrabajadorTextBox.Text, ContrasenaPasswordBox.Password);

                  
                    if (usuarioLogueado.matricula != null && usuarioLogueado.tipoVendedor == "si" && usuarioLogueado.tipoComprador == "no")

                    {
                        MenuEmpleado guiMenuEmpleado = new MenuEmpleado(usuarioLogueado);
                        Application.Current.MainWindow.Content = guiMenuEmpleado;


                    }
                    else if (usuarioLogueado != null && usuarioLogueado.tipoVendedor == "no" && usuarioLogueado.tipoComprador == "si")
                    {

                        MenuCliente guiMenuCliente = new MenuCliente(usuarioLogueado);
                        Application.Current.MainWindow.Content = guiMenuCliente;
                    }
                    else if (usuarioLogueado != null && usuarioLogueado.tipoVendedor == "si" && usuarioLogueado.tipoComprador == "si")
                    {
                        ventanaEmergente guiInicio = new ventanaEmergente(usuarioLogueado);
                        guiInicio.Owner = Application.Current.MainWindow;
                        guiInicio.ShowDialog();
                    }
                    else
                    { 

                        MessageBox.Show("Usuario no encontrado o credenciales incorrecatas, intente de nuevo con otras credenciales");
                    }

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado o credenciales incorrecatas, intente de nuevo con otras credenciales");

                }
            }
        }

        private bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            if (string.IsNullOrEmpty(ClaveTrabajadorTextBox.Text)) MessageBox.Show("No ingreso la clave de trabajador ingrese una por favor");
            else if (string.IsNullOrEmpty(ContrasenaPasswordBox.Password)) MessageBox.Show("No ingreso la contraseña ingrese una por favor");
            else esFormularioValido = true;
            return esFormularioValido;
        }

        private void RegistrarseTextBlockHyperlink_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU04_RegistrarCliente guiCU04_RegistrarCliente = new GUI_CU04_RegistrarCliente();
            Application.Current.MainWindow.Content = guiCU04_RegistrarCliente;
        }

        private void ClaveTrabajadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
