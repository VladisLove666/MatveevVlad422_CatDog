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

namespace catdooog.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            var user = App.db.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                var petListPage = new PetListPage(user);
                NavigationService.Navigate(petListPage);
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя.");
            }
        }
    }
}
