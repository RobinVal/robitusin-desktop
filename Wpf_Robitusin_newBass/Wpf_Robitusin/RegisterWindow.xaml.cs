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
using Wpf_Robitusin.Models;
using Wpf_Robitusin.Validation;

namespace Wpf_Robitusin
{
    /// <summary>
    /// Interakční logika pro RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        APIhelper api = new APIhelper();
        RegValidation Rv = new RegValidation();
        
        public RegisterWindow()
        {
            ;
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
            if (Rv.UserExists(tb_Reg_Username.Text))
            {
                MessageBox.Show("Uživatel existuje");
            }
            else
            {
                if (Rv.PassSame(tb_Reg_Password.Text, tb_Reg_rPassword.Text))
                {
                    string regpost = "{\"Username\":\"" + tb_Reg_Username.Text + "\",\"Email\":\"" + tb_Reg_Email.Text + "\",\"Password\":\"" + tb_Reg_Password.Text + "\",}";
                    api.Post(regpost);
                }
                else
                    MessageBox.Show("Hesla se neshodují");
            }
            
           
        }
    }
}
