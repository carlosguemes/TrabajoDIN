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

namespace Troncal
{
    /// <summary>
    /// Lógica de interacción para Componente.xaml
    /// </summary>
    public partial class Componente : UserControl
    {
        public Componente()
        {
            InitializeComponent();
        }

        public void MostrarMensaje(String titulo, String mensaje, int opcionMensaje)
        {
            if (opcionMensaje == 0)
            {
                MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else if (opcionMensaje == 1)
            {
                MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            else if (opcionMensaje == 2)
            {
                MessageBox.Show(mensaje, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public MessageBoxResult AceptarRechazar(String titulo, String mensaje)
        {
            return MessageBox.Show(mensaje, titulo, MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
