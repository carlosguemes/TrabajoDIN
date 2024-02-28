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
            agregarViaje.gestionarViajes.comboBox.Items.Add(agregarViaje.viaje);
 
            this.Close();
            agregarViaje.Close();
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {

        }
    }
}
