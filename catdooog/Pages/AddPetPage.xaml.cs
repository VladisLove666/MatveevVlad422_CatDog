using catdooog.BD;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddPetPage.xaml
    /// </summary>
    public partial class AddPetPage : Page
    {
        private User currentUser;
        private string imagePath;
        private Pet currentPet;

        public AddPetPage(User user)
        {
            InitializeComponent();
            currentUser = user;

        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Выберите изображение питомца"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;
                ImagePathTextBlock.Text = $"Выбрано: {System.IO.Path.GetFileName(imagePath)}";
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string description = DescriptionTextBox.Text;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(imagePath))
            {
                var pet = new Pet
                {
                    Name = name,
                    Description = description,
                    ImagePath = imagePath
                };

                App.db.Pets.Add(pet);
                App.db.SaveChanges();
                MessageBox.Show("Питомец добавлен!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля и выберите изображение.");
            }
        }
    }
}
