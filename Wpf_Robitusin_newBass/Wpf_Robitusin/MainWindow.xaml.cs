using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using Wpf_Robitusin.Models;

namespace Wpf_Robitusin
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginViewModel loginViewModel = new LoginViewModel();
        public string Username { get; set; }
        public string Password { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_Login_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_Login_SignIn_Click(object sender, RoutedEventArgs e)
        {
            Username = tb_Login_Username.Text;
            Password = tb_Login_Password.Text;

            User myUser = loginViewModel.TryExisting(1); /* Uvnitř je Id pokusného ůčtu viz. LoginViewModel */
            

        }

        private void bt_Login_ToSignUp_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            this.Close();
            rw.Show();
        }
    }
}
