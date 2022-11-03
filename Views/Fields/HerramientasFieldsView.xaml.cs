using System.Collections.Generic;
using System.Windows;

namespace PrestamosWPF.Views.Fields;

/// <summary>
///     Lógica de interacción para HerramientasFieldsView.xaml
/// </summary>
public partial class HerramientasFieldsView : Window
{
    public HerramientasFieldsView()
    {
        InitializeComponent();
        var ListaEstado = new List<lwcboEst>();
        ListaEstado.Add(new lwcboEst { Estado = "Excelente" });
        ListaEstado.Add(new lwcboEst { Estado = "Bueno" });
        ListaEstado.Add(new lwcboEst { Estado = "Regular" });
        ListaEstado.Add(new lwcboEst { Estado = "Malo" });
        lwcboEst.ItemsSource = ListaEstado;
    }
}

public class lwcboEst
{
    public string Estado { get; set; }
}