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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoCafeteria.GUI
{
    /// <summary>
    /// Lógica de interacción para GUI_CU09_RegistrarVendedor.xaml
    /// </summary>
    public partial class GUI_CU09_RegistrarVendedor : Page
    {
        Estudiante empleadoLogueado;
        public GUI_CU09_RegistrarVendedor(Estudiante empleadoLogueado)
        {
            this.empleadoLogueado = empleadoLogueado;
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {
                Estudiante estudiante = new Estudiante();
                estudiante.matricula = matriculaTb.Text.Trim();
                estudiante.nombre = nombreTb.Text.Trim();
                estudiante.apellidoPaterno = apellidoPaTb.Text.Trim();
                estudiante.apellidoMaterno = apellidoMaTb.Text.Trim();
                estudiante.correoInstitucional = correoTb.Text.Trim();
                estudiante.password = passBox.Password;
                estudiante.password = passCBox.Password;
         
                MessageBox.Show(await ServicioEstudiante.RegistrarEstudiante(estudiante));
                matriculaTb.Clear();
                nombreTb.Clear();
                apellidoPaTb.Clear();
                apellidoMaTb.Clear();
                correoTb.Clear();
                passBox.Clear();
                passCBox.Clear();
               
                
              
            }
        }
        public bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex expresionRegularLetras = new Regex(@"[a-zA-z]");
            Regex expresionRegularNumeros = new Regex(@"[0-9]");
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");
/*
            if (string.IsNullOrEmpty(NombreTextBox.Text)) MessageBox.Show("El nombre no puede quedar vacio");
            else if (string.IsNullOrEmpty(NRCTextBox.Text) || NRCTextBox.Text.Contains(" ")) MessageBox.Show("El nrc no puede quedar vacio o contener espacios");
            else if (expresionRegularNumeros.IsMatch(NombreTextBox.Text) || caracteresEspeciales.IsMatch(NombreTextBox.Text)) MessageBox.Show("El nombre solo puede contener letras");
            else if (expresionRegularLetras.IsMatch(NRCTextBox.Text) || caracteresEspeciales.IsMatch(NRCTextBox.Text)) MessageBox.Show("El NRC solo puede tener numeros");
            else if (NRCTextBox.Text.Length != 6) MessageBox.Show("El nrc debe contener 6 digitos solamente");
            else if (programaEducativoSeleccionado == null) MessageBox.Show("No selecciono el programa educativo, seleccione uno primero");
            else esFormularioValido = true;
*/
            return true;
        }

        private void NombreTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ApellidoPaternoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CargoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
