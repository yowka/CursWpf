using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.IO;

namespace CursWpf
{
    /// <summary>
    /// Логика взаимодействия для WindowProfile.xaml
    /// </summary>
    public partial class WindowProfile : Window
    {
        public WindowProfile()
        {
            InitializeComponent();
      
            LoadProfileImage();
        }

        private void Button_back(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_close(object sender, RoutedEventArgs e)
        {
            DBManager.id_employee = 0;
            DBManager.id_buyer = 0;
            foreach (Window window in Application.Current.Windows)
            {
                if (window != this) 
                    window.Close();

            }

            WindowAuthorization windowAuthorization = new WindowAuthorization();
            windowAuthorization.Show();
            this.Close();

        }


        private void Button_add_image(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images (*.jpg, *.png)|*.jpg;*.png",
                Title = "Выберите фото профиля"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    byte[] imageData = File.ReadAllBytes(openFileDialog.FileName);
                    var bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                    ProfileImage.Source = bitmap;

                    // Обновляем фото только для текущего пользователя
                    if (DBManager.id_buyer != 0) // Если вошёл покупатель
                    {
                        var buyer = DBManager.db.Buyer.FirstOrDefault(b => b.id == DBManager.id_buyer);
                        if (buyer != null)
                        {
                            buyer.photo = imageData;
                            DBManager.db.SaveChanges();
                            MessageBox.Show("Фото покупателя обновлено!");
                        }
                    }
                    else if (DBManager.id_employee != 0) // Если вошёл сотрудник
                    {
                        var employee = DBManager.db.Employee.FirstOrDefault(emp => emp.id == DBManager.id_employee);
                        if (employee != null)
                        {
                            employee.photo = imageData;
                            DBManager.db.SaveChanges();
                            MessageBox.Show("Фото сотрудника обновлено!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}");
                }
            }
        }
        private void LoadProfileImage()
        {
            var currentUser = DBManager.db.Buyer.FirstOrDefault(u => u.id == DBManager.id_buyer);
            if (currentUser?.photo != null)
            {
                using (MemoryStream ms = new MemoryStream(currentUser.photo))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    ProfileImage.Source = bitmap;
                }
            }
            var currentEmployee = DBManager.db.Employee.FirstOrDefault(e => e.id == DBManager.id_employee);
            if (currentEmployee?.photo != null)
            {
                using (MemoryStream ms = new MemoryStream(currentEmployee.photo))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    ProfileImage.Source = bitmap;
                }
            }
        }


    }
}
