using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Wpf_Robitusin.Models;

namespace Wpf_Robitusin
{
    /// <summary>
    /// Interakční logika pro ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Window
    {
        APIhelper apiHandler = new APIhelper();
        public ProfilePage()
        {
            InitializeComponent();
            PanelAddFriend.Visibility = Visibility.Hidden;
        }
        private List<string> listString = new List<string>();
        private List<string> listOfFriends = new List<string>();
        
        public void setName()
        {
            TxtUsername.Text = LoggedUser.Username;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setName();
            AddUsers(apiHandler.GetAllUsers());
            lbAddFriend.ItemsSource = listString;
            lbFriendList.ItemsSource = apiHandler.LoggedUsersFriends();
            lbPanding.ItemsSource = apiHandler.LoggedUsersPendings();
        }
        
        private void btnAddfriend_Click(object sender, RoutedEventArgs e)
        {
            PanelAddFriend.Visibility = Visibility.Visible;
            PanelFriendship.Visibility = Visibility.Hidden;
            PanelPanding.Visibility = Visibility.Hidden;
        }

        private void btCloseAddFriendPanel_Click(object sender, RoutedEventArgs e)
        {
            PanelAddFriend.Visibility = Visibility.Hidden;
        }

        private void lbAddFriend_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbAddFriend.Text = lbAddFriend.SelectedItem.ToString();
        }
        public void AddUsers(List<User> list)
        {
            foreach(User u in list)
            {
                if(u.Username == LoggedUser.Username)
                {

                } else
                {
                    listString.Add(u.Username);
                }
                
            }
        }

        private void btAddFriend_Click(object sender, RoutedEventArgs e)
        {
            string RecieverPath = apiHandler.GetPar(lbAddFriend.SelectedItem.ToString());
            User Reciever = apiHandler.GetUserFromJson(RecieverPath);
            string PathToPost = "{\"SenderId\":\"" + LoggedUser.Id + "\",\"RecieverId\":\"" + Reciever.Id + "\",\"Status\":\"" + 0 + "\",}";
            apiHandler.PostFriendship(PathToPost);
        }

        private void btnFriendship_Click(object sender, RoutedEventArgs e)
        {
            PanelFriendship.Visibility = Visibility.Visible;
            PanelAddFriend.Visibility = Visibility.Hidden;
            PanelPanding.Visibility = Visibility.Hidden;
        }

        private void btnFriendshipConfirm_Click(object sender, RoutedEventArgs e)
        {
            apiHandler.FriendshipConfirmed(lbPanding.SelectedItem.ToString());
            this.Close();
            this.Show();
        }

        private void btnPending_Click(object sender, RoutedEventArgs e)
        {
            PanelPanding.Visibility = Visibility.Visible;
            PanelFriendship.Visibility = Visibility.Hidden;
            PanelAddFriend.Visibility = Visibility.Hidden;
        }

        private void btnFriendshipDeny_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
