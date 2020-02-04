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
using Wpf_Robitusin.Validation;

namespace Wpf_Robitusin
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        APIhelper ah = new APIhelper();
        LogValidation lv = new LogValidation();
        ProfilePage pp = new ProfilePage();
        
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
            if(lv.UserExists(tb_Login_Username.Text,tb_Login_Password.Text) == true)
            {
                MessageBox.Show("úspěšně přihlášen");
                pp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Zkontrolujte přihlašovací údaje");
            }

        }

        private void bt_Login_ToSignUp_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow rw = new RegisterWindow();
            this.Close();
            rw.Show();
        }
    }
}
