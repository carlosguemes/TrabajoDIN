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

namespace Troncal
{
    /// <summary>
    /// Lógica de interacción para Pagos.xaml
    /// </summary>
    public partial class Pagos : Window
    {
        private AgregarViaje agregarViaje;
        private Componente componente = new Componente();


        public Pagos(AgregarViaje agregarViaje)
        {
            InitializeComponent();
            this.agregarViaje = agregarViaje;
                Random random = new Random();
                int numeroAleatorio = random.Next(200, 2001);
                TextoPago.Text = numeroAleatorio.ToString() + " €";      
        }

        private void Click_Continuar(object sender, RoutedEventArgs e)
        {
            
                String modoPago = "";
                if (TarjetaCredito.IsChecked == true)
                {
                    modoPago = " tarjeta de crédito";
                }

                else if (Transferencia.IsChecked == true)
                {
                    modoPago = " transferencia";
                }

                else if (Bizum.IsChecked == true)
                {
                    modoPago = " bizum";
                }

                if (TarjetaCredito.IsChecked == true || Transferencia.IsChecked == true || Bizum.IsChecked == true)
                {
                    agregarViaje.gestionarViajes.comboBox.Items.Add(agregarViaje.viaje);

                    componente.MostrarMensaje("Pago realizado", "Se ha efectuado el pago del viaje " + agregarViaje.viaje.Origen + " - " +
                        agregarViaje.viaje.Destino + " mediante" + modoPago, 0);

                    this.Close();
                    agregarViaje.Close();
                }

                else
                {
                    componente.MostrarMensaje("Error", "Debe introducir un método de pago", 2);
                }
              
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
