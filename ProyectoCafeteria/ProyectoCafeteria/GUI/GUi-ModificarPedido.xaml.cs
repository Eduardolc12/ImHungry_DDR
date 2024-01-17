using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
    /// Lógica de interacción para GUi_ModificarPedido.xaml
    /// </summary>
    public partial class GUi_ModificarPedido : Window
    {
        Pedido pedido;

        public GUi_ModificarPedido(Pedido pedido)
        {
            this.pedido = pedido;
            InitializeComponent();


            CargarInformacionPedido();
        }

        private async void CargarInformacionPedido()
        {



            preferenciasTb.Text = pedido.preferencias;
            fechaTb.Text = pedido.fechaPedido.ToString("yyyy-MM-dd");
            precioTotalTb.Text = pedido.precioTotal.ToString();
            estadoTb.Text = pedido.estado;
            matriculaTb.Text = pedido.matricula;

            Estudiante estudiante = await ServicioEstudiante.ConsultarEstudiante(pedido.matricula);

            if (!string.IsNullOrEmpty(estudiante.fotoPerfil))
            {
                byte[] imageBytes = Convert.FromBase64String(estudiante.fotoPerfil);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                fotoImage.Source = bitmapImage;
            }



        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem estadoSeleccionada = comboEstado.SelectedItem as ComboBoxItem;
            string textoSeleccionado = estadoSeleccionada.Content.ToString();
            if (textoSeleccionado!= "Pendiente")
            {
                

                pedido.estado = estadoTb.Text.Trim();
                pedido.fechaPedido = DateTime.Parse(fechaTb.Text.Trim());
             

                MessageBox.Show(await ServicioPedido.ActualizarPedido(pedido));
                this.Close();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {

            const string mensaje = "No se guardaran los cambios";
         
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show("¿Esta seguro que desea cancelar?",mensaje, buttons);

            // If the no button was pressed ...
            if (result == MessageBoxResult.Yes)
            {
              this.Close();
            }
           
        }

        private void seleccionarEstado(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem estadoSeleccionada = comboEstado.SelectedItem as ComboBoxItem;

            if (estadoSeleccionada != null)
            {
                
                string textoSeleccionado = estadoSeleccionada.Content.ToString();

               
                estadoTb.Text = textoSeleccionado;
            }

        }
    }
}
