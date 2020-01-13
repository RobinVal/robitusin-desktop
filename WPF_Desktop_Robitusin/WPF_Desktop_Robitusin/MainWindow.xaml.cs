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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Wpf_Desktop_Robitusin
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection con = new MySqlConnection(@"Data Source=localhost;port=3306;database=robitusin;uid=root;password=;CharSet=utf8;Persist Security Info=True");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_Submit_Click(object sender, RoutedEventArgs e)
        {
            string Query = "";
            con.Open();
            MySqlCommand cmd;
            MySqlDataReader MyReader2;
            
            
            if(tb_Password.Text == tb_PasswordCorr.Text)
            {
                User myUser = new User();
                
                myUser.fName = tb_fName.Text;
                myUser.lName = tb_lName.Text;
                myUser.Email = tb_Email.Text;
                myUser.Password = tb_Password.Text;
                
                Query = "INSERT INTO robitusin.user (Username,Email,Password) Values ('" + tb_fName.Text + tb_lName.Text + "','" + tb_Email.Text + "','" + tb_Password.Text + "')";
                cmd = new MySqlCommand(Query, con);
                MyReader2 = cmd.ExecuteReader();
                while (MyReader2.Read())
                {
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Hesla se Neshodují");
            }
            
        }

        private void bt_Reset_Click(object sender, RoutedEventArgs e)
        {
            tb_fName.Text = "";
            tb_lName.Text = "";
            tb_Email.Text = "";
            tb_Password.Text = "";
            tb_PasswordCorr.Text = "";
        }
    }
}
