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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }


        private void Gestionar_Clientes(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GestionarClientes subWindow = new GestionarClientes();
            subWindow.Show();
        }

        private void Gestionar_Viajes(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GestionarViajes subWindow = new GestionarViajes();
            subWindow.Show();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow subWindow = new MainWindow();
            subWindow.Show();
        }
    }

    
}
