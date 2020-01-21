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

namespace Wpf_Desktop_Robitusin
{
    /// <summary>
    /// Interakční logika pro LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Password { get; set; }
        public string UserName { get; set; }


        private IApiSettings _apisettings;
        public LoginWindow(IApiSettings apiSettings)
        {
            InitializeComponent();
            _apisettings = apiSettings;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            if (mw.Activate() == true)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Kontaktujte prosím podporu :)");
            }
        }
        public async Task LogIn()
        {
           var result = await _apisettings.Authenticate(UserName, Password);
        }

        private void bt_Log_Click(object sender, RoutedEventArgs e)
        {
            this.Password = tb_log_Password.Text;
            this.UserName = tb_Log_Username.Text;
        }
    }
}
    
    
