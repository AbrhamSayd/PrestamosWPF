using System.Windows;
using System.Windows.Controls;

namespace PrestamosWPF.customControls;

/// <summary>
///     Lógica de interacción para BindableUserBox.xaml
/// </summary>
public partial class BindableUserBox : UserControl
{
    public static readonly DependencyProperty UsernameProperty =
        DependencyProperty.Register("Username", typeof(string), typeof(BindableUserBox));

    public BindableUserBox()
    {
        InitializeComponent();

        TxtUser.TextChanged += OnUsernameChanged;
    }

    public string Username
    {
        get => (string)GetValue(UsernameProperty);
        set => SetValue(UsernameProperty, value);
    }

    public void OnUsernameChanged(object sender, RoutedEventArgs e)
    {
        Username = TxtUser.Text;
    }
}