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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Troncal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Componente componente = new Componente();
        public MainWindow()
        {
            InitializeComponent();

            KeyDown += MainWindow_KeyDown;

        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Boton_Confirmar(sender, e);
            }
        }

        private bool esCorrectoDniContrasenya()
        {
            bool valido = false;

            if (TextDni.Text.Length == 9 && TextPassword.Password.Length > 3)
            {
                valido = true;
            }

            return valido;
        }

        private bool esCorrectoDni()
        {
            bool valido = false;
            String cadena = TextDni.Text.ToString();
            char letra = cadena.ToUpper()[cadena.Length - 1];

            int numero = Int32.Parse(cadena.Substring(0, cadena.Length - 1));

            char[] letras = {'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};

            int resto = numero % 23;

            if (letra == letras[resto])
            {
                valido = true;
            }

            return valido;
        }

        private void abreVentanaNueva()
        {
            this.Hide();
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void Boton_Confirmar(object sender, RoutedEventArgs e)
        {
            if (esCorrectoDniContrasenya()) { 
                if (esCorrectoDni())
                {
                    abreVentanaNueva();
                }

                else
                {
                    componente.MostrarMensaje("Error", "El DNI es incorrecto", 2);
                }
                
            }

            else
            {
                componente.MostrarMensaje("Acceso denegado", 
                    "Debe introducir un DNI y la contraseña mayor de 4 caracteres", 1);
            }
            
        }
    }
}
