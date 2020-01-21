using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Wpf_Robitusin.Validations;
using static Wpf_Robitusin.ApiSettings;

namespace Wpf_Robitusin
{
    /// <summary>
    /// Interakční logika pro RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        RegValidation rv = new RegValidation();
        ApiSettings apiSettings = new ApiSettings();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void bt_Reg_ToLog_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Close();
            mw.Show();
        }

        private void bt_Reg_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bt_Reg_RegOk_Click(object sender, RoutedEventArgs e)
        {
            
            using (var client = new HttpClient())
            {
                User u = new User
                {
                    Id = 5,
                    Username = tb_Reg_Username.Text,
                    Email = tb_Reg_Email.Text,
                    Password = tb_Reg_Password.Text
                };
                client.BaseAddress = new Uri("http://localhost:49497/");
                var response = client.PostAsJsonAsync("api/User/", u).Result;
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
                }else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void tb_Reg_rPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (rv.PassSimlr(tb_Reg_Password.Text, tb_Reg_rPassword.Text) == false)
            {
                Tbl_notSmlr.Visibility = Visibility.Visible;
                Tbl_Smlr.Visibility = Visibility.Hidden;
            }
            else
            {
                Tbl_notSmlr.Visibility = Visibility.Hidden;
                Tbl_Smlr.Visibility = Visibility.Visible;
            }
        }
    }
}
