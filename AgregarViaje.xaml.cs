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
    /// Lógica de interacción para AgregarViaje.xaml
    /// </summary>
    public partial class AgregarViaje : Window
    {
        private GestionarViajes gestionarViajes;
        private Componente componente = new Componente();
        public AgregarViaje(GestionarViajes gestionarViajes)
        {
            InitializeComponent();
            this.gestionarViajes = gestionarViajes;

            List<String> origenes = new List<String>();
            origenes.Add("Madrid");
            origenes.Add("Viena");
            origenes.Add("Ámsterdam");
            origenes.Add("Edimburgo");
            origenes.Add("Bruselas");

            List<String> destinos = new List<String>();
            destinos.Add("Barcelona");
            destinos.Add("Roma");
            destinos.Add("Bucarest");
            destinos.Add("Praga");
            destinos.Add("París");

            List<String> tipoHotel = new List<String>();
            tipoHotel.Add("Hotel de Lujo");
            tipoHotel.Add("Hotel Standard");
            tipoHotel.Add("Hotel Barato");

            List<String> tipoTransporte = new List<String>();
            tipoTransporte.Add("Avión");
            tipoTransporte.Add("Autobús");
            tipoTransporte.Add("Tren");

            List<String> tipoViaje = new List<String>();
            tipoViaje.Add("CERRADO");
            tipoViaje.Add("CANCELADO");

            foreach (String ciudad in origenes)
            {
                Origen.Items.Add(ciudad);
            }
               

            foreach (String ciudad in destinos)
            {
                Destino.Items.Add(ciudad);
            }

            foreach (String hotel in tipoHotel)
            {
                TipoHotel.Items.Add(hotel);
            }

            foreach (String transporte in tipoTransporte)
            {
                TipoTransporte.Items.Add(transporte);
            }

            foreach (String viaje in tipoViaje)
            {
                TipoViaje.Items.Add(viaje);
            }

        }

        private void Click_Continuar(object sender, RoutedEventArgs e)
        {
            String origen = Origen.Text;
            String destino = Destino.Text;
            DateTime? fechaIda = FechaIda.SelectedDate;
            DateTime? fechaVuelta = FechaVuelta.SelectedDate;
            String tipoHotel = TipoHotel.Text;
            String tipoTransporte = TipoTransporte.Text;
            String tipoViaje = TipoViaje.Text;

            if (origen != "" &&
                destino != "" &&
                fechaIda != null &&
                fechaVuelta != null &&
                tipoHotel != "" &&
                tipoTransporte != "" &&
                tipoViaje != "")
            {
                if (fechaIda >= fechaVuelta)
                {
                    componente.MostrarMensaje("Error", "La fecha de ida no puede ser posterior a la fecha de vuelta", 2);
                }

                else
                {
                    this.IsEnabled = false;
                    Pagos subWindow = new Pagos(this);
                    subWindow.Closed += subWindow_Closed;
                    subWindow.Show();

                    Viaje viaje = new Viaje(origen, destino, (DateTime)fechaIda, (DateTime)fechaVuelta, tipoHotel, tipoTransporte, tipoViaje);
                    gestionarViajes.comboBox.Items.Add(viaje);
                    componente.MostrarMensaje("Confirmación", "El viaje se ha añadido con éxito", 0);
                    this.Close();
                }
   
            }

            else
            {
                componente.MostrarMensaje("Advertencia", "Seleccione todos los datos para continuar", 1);
            }
        }

        private void Click_Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void subWindow_Closed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }
    }
}
