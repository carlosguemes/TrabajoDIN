using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Lógica de interacción para GestionarClientes.xaml
    /// </summary>
    public partial class GestionarClientes : Window
    {
        public String Nombre { get; set; }
        public String DNI { get; set; }

        private Componente componente = new Componente();

        public GestionarClientes()
        {

            InitializeComponent();

            List<Viajes> viajes = new List<Viajes>();

            Viajes viaje = new Viajes("Madrid", "Barcelona", DateTime.Now, DateTime.Now.AddDays(7), "Hotel de Lujo", "Avión", "CANCELADO");
            Viajes viaje2 = new Viajes("Málaga", "Sevilla", DateTime.Now.AddDays(8), DateTime.Now.AddDays(20), "Hotel Barato", "Tren", "CERRADO");

            viajes.Add(viaje);
            viajes.Add(viaje2);

            Lista.Items.Add(new Cliente("Carlos Güemes", "48246430C", viajes));
            Lista.Items.Add(new Cliente("Marcos García-Seco", "12345678Q", viajes));
            Lista.Items.Add(new Cliente("Marco Martínez", "83745120U", viajes));
            Lista.Items.Add(new Cliente("Óscar Rueda", "29384756T", viajes));

        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si hay un cliente seleccionado
            if (Lista.SelectedItem is Cliente cliente)
            {
                if (componente.AceptarRechazar("Cuidado", 
                    "¿Está seguro de que quiere borrar el cliente?").Equals(MessageBoxResult.Yes)){
                    Lista.Items.Remove(cliente);
                    componente.MostrarMensaje("Información", "El cliente se ha eliminado correctamente", 0);
                }
               
            }

            else
            {
                componente.MostrarMensaje("Advertencia", "Debe seleccionar un cliente", 1);
            }
        }

        private void Informacion_Click(object sender, RoutedEventArgs e)
        {
            if (Lista.SelectedItem is Cliente cliente)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Viajes viajes in cliente.viajes)
                {
                    sb.Append(viajes.ToString());
                    sb.Append("\n\n");
                }

                componente.MostrarMensaje("Información del cliente", "Cliente: " + cliente.ToString() +
                    "\nDNI: " + cliente.DNI +
                    "\n\nViajes: \n" + sb.ToString(), 0);
            }

            else
            {
                componente.MostrarMensaje("Advertencia", "Debe seleccionar un cliente", 1);
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            Agregar subWindow = new Agregar(this);
            subWindow.Closed += subWindow_Closed;
            subWindow.Show();
        }

        private void subWindow_Closed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }
    }

    public class Cliente
    {
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public List<Viajes> viajes { get; set; }

        public Cliente(string nombre, string dni, List<Viajes> viajes)
        {
            Nombre = nombre;
            DNI = dni;
            this.viajes = viajes;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

    public class Viajes
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public string TipoHotel { get; set; }
        public string TipoTransporte { get; set; }
        public string TipoViaje { get; set; }

        // Constructor para inicializar algunas propiedades básicas
        public Viajes(string origen, string destino, DateTime fechaIda, DateTime fechaVuelta, string tipoHotel, string tipoTransporte, string tipoViaje)
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
            return (Origen + " - " + Destino + 
                "\nIda: " + FechaIda.Day + "/" + FechaIda.Month + "/" + FechaIda.Year +
                " -- Vuelta: " + FechaVuelta.Day + "/" + FechaVuelta.Month + "/" + FechaVuelta.Year +
                "\n" + TipoHotel + 
                " - " + TipoTransporte + 
                " --- " + TipoViaje);
        }
    }
}
