using ProyectoCafeteria.Datos.Modelo;
using ProyectoCafeteria.Logica.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
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
            fechaTb.Text = pedido.fechaPedido.ToString();
            precioTotalTb.Text = pedido.precioTotal.ToString();
            estadoTb.Text = pedido.estado;
            matriculaTb.Text = pedido.matricula;
         
            Estudiante estudiante = await ServicioEstudiante.

            if (!string.IsNullOrEmpty(productoAModificar.foto))
            {
                byte[] imageBytes = Convert.FromBase64String(productoAModificar.foto);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.EndInit();
                ImageProducto.Source = bitmapImage;
            }



        }
    }
}
