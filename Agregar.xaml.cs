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
        public Agregar()
        {
            InitializeComponent();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GestionarClientes subWindow = new GestionarClientes();
            subWindow.Show();
        }

        private void Confirmar_Click(object sender, RoutedEventArgs e)
        {
            if (TextNombre.Text != "" && TextApellidos.Text != "" && TextCorreo.Text != "") {
                if (CheckDadoAlta.IsChecked == true)
                {
                    MessageBox.Show(TextNombre.Text + " " + 
                        TextApellidos.Text + "\n" + TextCorreo.Text +  "\n" +
                        "Dado de alta", "Nuevo cliente");
                }

                else
                {
                    MessageBox.Show(TextNombre.Text + " " +
                       TextApellidos.Text + "\n" + TextCorreo.Text, "Nuevo cliente");
                }
            }

            else
            {
                MessageBox.Show("Introduce todos los datos", "Error al recoger datos");
            }
        }
    }
}
