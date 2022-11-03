using System.Windows;
using System.Windows.Input;

namespace PrestamosWPF.Views;

/// <summary>
///     Interaction logic for LoginView.xaml
/// </summary>
public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}