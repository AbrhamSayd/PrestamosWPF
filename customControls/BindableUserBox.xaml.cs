using System;
using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace PrestamosWPF.customControls
{
    /// <summary>
    /// Lógica de interacción para BindableUserBox.xaml
    /// </summary>
    public partial class BindableUserBox : UserControl
    {
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(String), typeof(BindableUserBox));

        public String Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
        public BindableUserBox()
        {
            InitializeComponent();
            
            TxtUser.TextChanged += OnUsernameChanged;
        }

        public void OnUsernameChanged(object sender, RoutedEventArgs e)
        {
            Username = TxtUser.Text;
        }
    }
}
