using catdooog.BD;
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
    /// Логика взаимодействия для PetListPage.xaml
    /// </summary>
    public partial class PetListPage : Page
    {
        private Users currentUser;

        public PetListPage(Users user)
        {
            InitializeComponent();
            currentUser = user;
            LoadPets();
        }

        private void LoadPets()
        {
            var pets = App.db.Pets.Where(p => p.UserId == currentUser.Id).ToList();
            PetsListView.ItemsSource = pets;
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "По имени")
                {
                    PetsListView.ItemsSource = App.db.Pets.Where(p => p.UserId == currentUser.Id).OrderBy(p => p.Name).ToList();
                }
                else if (selectedItem.Content.ToString() == "По описанию")
                {
                    PetsListView.ItemsSource = App.db.Pets.Where(p => p.UserId == currentUser.Id).OrderBy(p => p.Description).ToList();
                }
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredPets = App.db.Pets
                .Where(p => p.UserId == currentUser.Id &&
                            (p.Name.ToLower().Contains(searchText) || p.Description.ToLower().Contains(searchText)))
                .ToList();
            PetsListView.ItemsSource = filteredPets;
        }

        private void AddPetButton_Click(object sender, RoutedEventArgs e)
        {
            var addPetPage = new AddPetPage(currentUser);
            NavigationService.Navigate(addPetPage);
        }
    }
}
