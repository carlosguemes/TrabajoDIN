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
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {
        private GestionarClientes gestionaClientes;
        private Componente componente = new Componente();   

        public Agregar(GestionarClientes gestionaClientes)
        {
            InitializeComponent();
            this.gestionaClientes = gestionaClientes;
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GestionarClientes subWindow = new GestionarClientes();
            subWindow.Show();
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = TextNombre.Text;
            String dni = TextDNI.Text;


            if (TextNombre.Text != "" && TextDNI.Text != "") {               
                if (esCorrectoDni())
                {
                    Cliente cliente = new Cliente(nombre, dni, new List<Viajes>());

                    gestionaClientes.Lista.Items.Add(cliente);
                    this.Close();
                }
                else
                {
                    componente.MostrarMensaje("Error", "El DNI es incorrecto", 2);
                }
                
            }

            else
            {
                componente.MostrarMensaje("Error al recoger los datos", "Introduce tu nombre y DNI", 1);
            }
        }

        private bool esCorrectoDni()
        {
            bool valido = false;
            String cadena = TextDNI.Text.ToString();
            char letra = cadena.ToUpper()[cadena.Length - 1];

            int numero = Int32.Parse(cadena.Substring(0, cadena.Length - 1));

            char[] letras = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };

            int resto = numero % 23;

            if (letra == letras[resto])
            {
                valido = true;
            }

            return valido;
        }

        private void subWindow_Closed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }
    }
}
