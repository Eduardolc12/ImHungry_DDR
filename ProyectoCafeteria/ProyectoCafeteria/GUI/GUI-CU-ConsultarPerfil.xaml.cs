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
    /// Lógica de interacción para GUI_CU_ConsultarPerfil.xaml
    /// </summary>
    public partial class GUI_CU_ConsultarPerfil : Window
    {
        string rutaImagen;
        string rutaImagen1;
        string nombreImagen;
        string nombreImagen1;
        string fotoPerfil;
        string fotoCredencial;
        Estudiante usuarioLogueado;

        public BitmapImage ImagenPerfilActual { get; private set; }
        public MenuEmpleado MenuEmpleado { get; set; }
        public MenuCliente MenuCliente { get; set; }    
        public GUI_CU_ConsultarPerfil(Estudiante usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;

        
        
            matriculaTb.Text = usuarioLogueado.matricula;
            nombreTb.Text = usuarioLogueado.nombre;
            apellidoPaTb.Text = usuarioLogueado.apellidoPaterno;
            apellidoMaTb.Text = usuarioLogueado.apellidoMaterno;
            correoTb.Text =usuarioLogueado.correoInstitucional;
            passBox.Password = usuarioLogueado.password;



            Cargarimagen(usuarioLogueado.matricula);
        }

        private void FotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ventanaSelectorArchivo = new OpenFileDialog();
            ventanaSelectorArchivo.Filter = "Archivos de Imagen PNG | *.png;";
            ventanaSelectorArchivo.Title = "Cargar Archivo De Imagen";
            if (ventanaSelectorArchivo.ShowDialog() == true)
            {
                this.rutaImagen = ventanaSelectorArchivo.FileName;
                this.nombreImagen = ventanaSelectorArchivo.SafeFileName;
                Uri nuevaUriImagen = new Uri(this.rutaImagen, UriKind.Absolute);
                ImagePerfil.Source = new BitmapImage(nuevaUriImagen);
                this.fotoPerfil = ConvertImageToBase64(this.rutaImagen);


            }


        }

        private void CredencialButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ventanaSelectorArchivo = new OpenFileDialog();
            ventanaSelectorArchivo.Filter = "Archivos de Imagen PNG | *.png;";
            ventanaSelectorArchivo.Title = "Cargar Archivo De Imagen";
            if (ventanaSelectorArchivo.ShowDialog() == true)
            {
                this.rutaImagen1 = ventanaSelectorArchivo.FileName;
                this.nombreImagen1 = ventanaSelectorArchivo.SafeFileName;


                Uri nuevaUriImagen = new Uri(this.rutaImagen1, UriKind.Absolute);
                ImageCrendencial.Source = new BitmapImage(nuevaUriImagen);
                this.fotoCredencial = ConvertImageToBase64(this.rutaImagen1);
            }
        }


        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
        }

   



        private async void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            Estudiante estudiante = new Estudiante();
            estudiante.matricula = matriculaTb.Text.Trim();
            estudiante.nombre = nombreTb.Text.Trim();
            estudiante.apellidoPaterno = apellidoPaTb.Text.Trim();
            estudiante.apellidoMaterno = apellidoMaTb.Text.Trim();
            estudiante.correoInstitucional = correoTb.Text.Trim();
            estudiante.password = passBox.Password;
            estudiante.tipoVendedor = usuarioLogueado.tipoVendedor;
            estudiante.tipoComprador = usuarioLogueado.tipoComprador;
            estudiante.fotoPerfil = fotoPerfil;
            estudiante.fotoCredencial = fotoCredencial;

            if (ValidarFormulario() == true)
            {

                MessageBox.Show(await ServicioEstudiante.ActualizarEstudiante(estudiante));
                this.Close();
                

            }
        }


        public bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex expresionRegularLetras = new Regex(@"[a-zA-z]");
            Regex expresionRegularNumeros = new Regex(@"[0-9]");
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            if (string.IsNullOrEmpty(matriculaTb.Text))
            {
                MessageBox.Show("no puede quedar vacio ningún campo");
                return false;
            }
            else if (string.IsNullOrEmpty(nombreTb.Text) || nombreTb.Text.Contains(" "))
            {
                MessageBox.Show("no puede dejar espacios");
                return false;
            }
            else if (caracteresEspeciales.IsMatch(matriculaTb.Text))
            {
                MessageBox.Show("no puede quedar vacio ningún campo");
                return false;
            }
            else if (caracteresEspeciales.IsMatch(nombreTb.Text))
            {
                MessageBox.Show("no puede quedar vacio ningún campo");
                return false;
            }

            else
            {
                esFormularioValido = true;
                return true;
            }


        }

        private void CerrarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuEmpleado != null)
            {
                MenuEmpleado.ImagenMenu = ImagenPerfilActual;
            }


            this.Close();
        }

        public async void Cargarimagen(string matricula)
          
        {
            Estudiante usuarioLogueado1 = await ServicioEstudiante.ConsultarEstudiante(matricula);
            if (!string.IsNullOrEmpty(usuarioLogueado1.fotoPerfil))
            {
                byte[] imageBytes = Convert.FromBase64String(usuarioLogueado1.fotoPerfil);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                ImagePerfil.Source = bitmapImage;
            }

            if (!string.IsNullOrEmpty(usuarioLogueado1.fotoCredencial))
            {
                byte[] imageBytes = Convert.FromBase64String(usuarioLogueado1.fotoCredencial);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                ImageCrendencial.Source = bitmapImage;
            }
        }

    }
}