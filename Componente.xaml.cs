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

        public void HacerAlgo()
        {
            MessageBox.Show("Hola manin");
        }
    }
}
