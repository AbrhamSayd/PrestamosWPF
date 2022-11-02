using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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

namespace PrestamosWPF.Views
{
    /// <summary>
    /// Lógica de interacción para HerramientasFieldsView.xaml
    /// </summary>
    public partial class HerramientasFieldsView : Window
    {
        public HerramientasFieldsView()
        {
            InitializeComponent();
            List <lwcboEst> ListaEstado = new List<lwcboEst>();
            ListaEstado.Add(new lwcboEst { Estado = "Excelente" });
            ListaEstado.Add(new lwcboEst { Estado = "Bueno" });
            ListaEstado.Add(new lwcboEst { Estado = "Regular" });
            ListaEstado.Add(new lwcboEst { Estado = "Malo" });
            lwcboEst.ItemsSource = ListaEstado;

        }
    }
    public class lwcboEst
    {
        public String Estado { get; set; }
    }
}
