using System.Windows;
using System.Windows.Input;

namespace PrestamosWPF.Views;

/// <summary>
///     Lógica de interacción para MainView.xaml
/// </summary>
public partial class MainView : Window
{
    private bool IsMaximazed;

    public MainView()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) DragMove();
    }

    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (IsMaximazed)
            {
                WindowState = WindowState.Normal;
                Height = 648;
                Width = 1152;

                IsMaximazed = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                IsMaximazed = true;
            }
        }
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}