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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace ProyectoCafeteria.GUI
{
    /// <summary>
    /// Lógica de interacción para GUI_CU01_RegistrarProducto.xaml
    /// </summary>
    public partial class GUI_CU01_RegistrarProducto : Page
    {

        Estudiante usuarioLogueado;
        string rutaImagen;
        string nombreImagen;
        string fotoProducto;
        public GUI_CU01_RegistrarProducto(Estudiante usuarioLogueado)
        {
            InitializeComponent();
        this.usuarioLogueado = usuarioLogueado;

    }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ImagenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ventanaSelectorArchivo = new OpenFileDialog();
            ventanaSelectorArchivo.Filter = "Archivos de Imagen PNG | *.png;";
            ventanaSelectorArchivo.Title = "Cargar Archivo De Imagen";
            if (ventanaSelectorArchivo.ShowDialog() == true)
            {
                this.rutaImagen = ventanaSelectorArchivo.FileName;
                this.nombreImagen = ventanaSelectorArchivo.SafeFileName;
               
                Uri nuevaUriImagen = new Uri(this.rutaImagen, UriKind.Absolute);
                imagenProducto.Source = new BitmapImage(nuevaUriImagen);
                this.fotoProducto = ConvertImageToBase64(this.rutaImagen);
            }
        }



        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarFormulario())
            {

                Producto producto = new Producto();
                producto.nombre = nombreTb.Text.Trim();
                producto.descripcion = descripcionTb.Text.Trim();
                producto.cantidadDisponible = int.Parse(cantidadTb.Text.Trim());
                producto.horaVentaInicial = ventaITb.Text.Trim();
                producto.horaVentaFinal = ventafTb.Text.Trim();
                producto.precio = float.Parse(precioTb.Text.Trim());
                producto.puntoEncuentro = puntoETb.Text.Trim();
                producto.estado = estadoTb.Text.Trim();
                producto.foto = fotoProducto;

                //utilizar el servicio para registrar producto
                MessageBox.Show(await ServicioProducto.RegistrarProduto(producto));


                //utilizar el servicio para obtener la matricula del producto
                Producto producto1 = await ServicioProducto.ConsultarProductoPorNombre(producto.nombre);
              
              
               Vendedor vendedor = new Vendedor();
                vendedor.matricula = usuarioLogueado.matricula;
                vendedor.id_producto= producto1.id_producto;

               //utilizar elv servicio para guardar los proudctos de vendedor
               var mensaje = await ServicioVendedor.RegistrarProducto(vendedor);
                nombreTb.Clear();
                descripcionTb.Clear();
                cantidadTb.Clear();
                ventaITb.Clear();
                ventafTb.Clear();
                precioTb.Clear();
                puntoETb.Clear();
                estadoTb.Clear();
                imagenProducto.Source = null;
                
             
            }
        }

        public bool ValidarFormulario()
        {
            bool esFormularioValido = false;
            Regex expresionRegularLetras = new Regex(@"[a-zA-z]");
            Regex expresionRegularNumeros = new Regex(@"[0-9]");
            Regex caracteresEspeciales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");
            
                        if (string.IsNullOrEmpty(nombreTb.Text)) MessageBox.Show("El nombre no puede quedar vacio");
                        else if (string.IsNullOrEmpty(descripcionTb.Text)) MessageBox.Show("no puede quedar vacio o contener espacios");
                        else if (expresionRegularNumeros.IsMatch(nombreTb.Text) || caracteresEspeciales.IsMatch(nombreTb.Text)) MessageBox.Show("El nombre solo puede contener letras");
                        else if (expresionRegularLetras.IsMatch(precioTb.Text) || caracteresEspeciales.IsMatch(precioTb.Text)) MessageBox.Show("El precio solo puede tener numeros");
             
                       else esFormularioValido = true;
         
            return true;
        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageArray);
        }
    }
}
