using System;
using System.Collections;
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
    /// Lógica de interacción para GestionarViajes.xaml
    /// </summary>
    public partial class GestionarViajes : Window
    {

        private Componente componente = new Componente();

        public GestionarViajes()
        {
            InitializeComponent();

            Viaje viajePrueba = new Viaje("Madrid", "Barcelona", DateTime.Now, DateTime.Now.AddDays(7), "Hotel de Lujo", "Avión", "CANCELADO");


            comboBox.Items.Add(viajePrueba);
            comboBox.Items.Add(new Viaje("Madrid", "Barcelona", DateTime.Now, DateTime.Now.AddDays(7), "Hotel de Lujo", "Autobús", "CANCELADO"));
            comboBox.Items.Add(new Viaje("Málaga", "Sevilla", DateTime.Now, DateTime.Now.AddDays(7), "Hotel Barato", "Tren", "CERRADO"));


        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem is Viaje viaje)
            {
                if (componente.AceptarRechazar("Cuidado",
                    "¿Está seguro de que quiere borrar el viaje?").Equals(MessageBoxResult.Yes))
                {
                    comboBox.Items.Remove(viaje);
                    componente.MostrarMensaje("Información", "El viaje se ha eliminado correctamente", 0);
                }

            }

            else
            {
                componente.MostrarMensaje("Advertencia", "Debe seleccionar un viaje", 1);
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            AgregarViaje subWindow = new AgregarViaje(this);
            subWindow.Closed += subWindow_Closed;
            subWindow.Show();
        }

        private void subWindow_Closed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }

        private void Informacion_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem is Viaje viaje)
            {
                componente.MostrarMensaje("Información del viaje", "Viaje: " + viaje.ToString(), 0);
            }

            else
            {
                componente.MostrarMensaje("Advertencia", "Debe seleccionar un viaje", 1);
            }
        }
    }

    public class Viaje
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public string TipoHotel { get; set; }
        public string TipoTransporte { get; set; }
        public string TipoViaje { get; set; }

        // Constructor para inicializar algunas propiedades básicas
        public Viaje(string origen, string destino, DateTime fechaIda, DateTime fechaVuelta, string tipoHotel, string tipoTransporte, string tipoViaje)
        {
            Origen = origen;
            Destino = destino;
            FechaIda = fechaIda;
            FechaVuelta = fechaVuelta;
            TipoHotel = tipoHotel;
            TipoTransporte = tipoTransporte;
            TipoViaje = tipoViaje;
        }

        override
        public String ToString()
        {
            return (Origen + " - " + Destino + "\n" +
                "Ida: " + FechaIda.ToString() + 
                " Vuelta: " + FechaVuelta.ToString() + "\n" + 
                TipoHotel + " - " + 
                TipoTransporte + " --- " + 
                TipoViaje);
        }
    }

}
