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
        
        public LoginWindow()
        {
            InitializeComponent();
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

        private void bt_Log_Click(object sender, RoutedEventArgs e)
        {
            if(tb_Log_Username.Text != "" || tb_log_Password.Text != "")
            {
                
            }
        }
    }
    
