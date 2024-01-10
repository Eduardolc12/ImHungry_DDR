﻿using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoCafeteria.GUI
{
    /// <summary>
    /// Lógica de interacción para GUI_CU04_RegistrarCliente.xaml
    /// </summary>
    public partial class GUI_CU04_RegistrarCliente : Page
    {
        string rutaImagen;
        string nombreImagen;
        string nombreImagen1;
        string fotoPerfil;
        string fotoCredencial;
        public GUI_CU04_RegistrarCliente()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU03_IniciarSesion guiIniciarSesion = new GUI_CU03_IniciarSesion();
            Application.Current.MainWindow.Content = guiIniciarSesion;
        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)

        {




            if (ValidarFormulario())
            {
                string tipoVendedor = "";
                string tipoComprador = "";
                if (CompraRB.IsChecked == true && VenRB.IsChecked == true)
                {
                    tipoVendedor = "si";
                    tipoComprador = "si";
                }

                else if (CompraRB.IsChecked == true)
                {
                    tipoVendedor = "no";
                    tipoComprador = "si";
                }
                else if (VenRB.IsChecked == true)
                {
                    tipoComprador = "no";
                    tipoVendedor = "si";
                }
                Estudiante estudiante = new Estudiante();
                estudiante.matricula = matriculaTb.Text.Trim();
                estudiante.nombre = nombreTb.Text.Trim();
                estudiante.apellidoPaterno = apellidoPaTb.Text.Trim();
                estudiante.apellidoMaterno = apellidoMaTb.Text.Trim();
                estudiante.correoInstitucional = correoTb.Text.Trim();
                estudiante.password = passBox.Password;
                estudiante.tipoVendedor = tipoVendedor;
                estudiante.tipoComprador = tipoComprador;
                estudiante.fotoPerfil =fotoPerfil;
                estudiante.fotoCredencial = fotoCredencial;

                if(ValidarFormulario()==true){
                   
                MessageBox.Show(await ServicioEstudiante.RegistrarEstudiante(estudiante));

                matriculaTb.Clear();
                nombreTb.Clear();
                apellidoPaTb.Clear();
                apellidoMaTb.Clear();
                correoTb.Clear();
                passBox.Clear();
                passCBox.Clear();
                VenRB.IsChecked = false;
                CompraRB.IsChecked = false;
                ImagePerfil.Source = null;
                ImageCrendencial.Source = null;

                GUI_CU03_IniciarSesion guiIniciarSesion = new GUI_CU03_IniciarSesion();
            Application.Current.MainWindow.Content = guiIniciarSesion;

            }
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

        private void FotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ventanaSelectorArchivo = new OpenFileDialog();
            ventanaSelectorArchivo.Filter = "Archivos de Imagen PNG | *.png;";
            ventanaSelectorArchivo.Title = "Cargar Archivo De Imagen";
            if (ventanaSelectorArchivo.ShowDialog() == true)
            {
                this.rutaImagen = ventanaSelectorArchivo.FileName;
                this.nombreImagen = ventanaSelectorArchivo.SafeFileName;
                LabelPerfil.Content = nombreImagen;
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
                this.rutaImagen = ventanaSelectorArchivo.FileName;
                this.nombreImagen1 = ventanaSelectorArchivo.SafeFileName;
                LabelCredencial.Content = nombreImagen1;

                Uri nuevaUriImagen = new Uri(this.rutaImagen, UriKind.Absolute);
                ImageCrendencial.Source = new BitmapImage(nuevaUriImagen);
                this.fotoCredencial = ConvertImageToBase64(this.rutaImagen);
            }

        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
        }
    }
}
