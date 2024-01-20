﻿using ProyectoCafeteria.Datos.Modelo;
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
    /// Lógica de interacción para MenuCliente.xaml
    /// </summary>
    public partial class MenuCliente : Page
    {
        Estudiante usuarioLogueado;
        public MenuCliente(Estudiante usuarioLogueado)
        {
            InitializeComponent();
            this.usuarioLogueado = usuarioLogueado;
            perfilLb.Text = usuarioLogueado.nombre + " " + usuarioLogueado.apellidoPaterno;
        }


        private void ConsultarProductoButton_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU05_ConsultarProducto guiCU11ConsultarProducto = new GUI_CU05_ConsultarProducto(usuarioLogueado);
            contentFrame.Navigate(guiCU11ConsultarProducto);

        }


        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void consultarPedidoButton_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU02_ConsultarPedido guiCU11ConsultarPedido = new GUI_CU02_ConsultarPedido(usuarioLogueado);
            contentFrame.Navigate(guiCU11ConsultarPedido);
        }

        private void ConsultarEstadisticasButton_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU03_ConsultarEstadisticas guiCU03ConsultarEstadisticas = new GUI_CU03_ConsultarEstadisticas();
            contentFrame.Navigate(guiCU03ConsultarEstadisticas);
        }

        private void cerrarSesionButton_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU03_IniciarSesion guiIniciarSesion = new GUI_CU03_IniciarSesion();
            Application.Current.MainWindow.Content = guiIniciarSesion;

        }

        private void ConsultarPerfilButton_Click(object sender, RoutedEventArgs e)
        {


            GUI_CU_ConsultarPerfil consultarPerfil = new GUI_CU_ConsultarPerfil(usuarioLogueado);
            consultarPerfil.Owner = Window.GetWindow(this);
            consultarPerfil.MenuCliente = this;  // Agrega esta línea para pasar la referencia
            consultarPerfil.ShowDialog();
        }

        private void FavProductoButton_Click(object sender, RoutedEventArgs e)
        {
            GUI_CU08_ConsultarFavoritos favProducto = new GUI_CU08_ConsultarFavoritos(usuarioLogueado);
            contentFrame.Navigate(favProducto);
        }

        private void evaluarServicioButton_Click(object sender, RoutedEventArgs e)
        {

            GUI_CU07_EvaluarServicio evaluacion = new GUI_CU07_EvaluarServicio(usuarioLogueado);
            contentFrame.Navigate(evaluacion);
        }
    }
}
