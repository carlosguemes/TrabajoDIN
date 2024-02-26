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
        public GestionarClientes()
        {
            InitializeComponent();

            Lista.Items.Add("Carlos");
            Lista.Items.Add("Marcos");
            Lista.Items.Add("Marco");
            Lista.Items.Add("Wences");

        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 subWindow = new Window1();
            subWindow.Show();
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lista.SelectedItem != null)
            {
                MessageBox.Show("Cliente: " + Lista.SelectedItem.ToString(),
                "Información del cliente");
            }
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {

            Lista.Items.Remove(Lista.SelectedItem);
            Componente componente = new Componente();
            componente.HacerAlgo();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Agregar subWindow = new Agregar();
            subWindow.Show();
        }
    }
}
