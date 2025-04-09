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
using System.Net.NetworkInformation;

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
            LoadUserData();
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

        private void LoadUserData()
        {
            if (DBManager.id_buyer != 0)
            {
                var buyer = DBManager.db.Buyer.FirstOrDefault(b => b.id == DBManager.id_buyer);
                if (buyer != null)
                {
                    txtLogin.Text = buyer.login;
                    txtName.Text = buyer.name;
                    txtSurname.Text = buyer.surname;
                    txtPassword.Password = buyer.password; 
                    txtLastname.Text = buyer.lastname;
                    tbPassword.Text = buyer.password;
                    if (!string.IsNullOrEmpty(buyer.gender))
                    {
                        if (buyer.gender.Equals("M", StringComparison.OrdinalIgnoreCase))
                        {
                            ManChecked.IsChecked = true;
                            WomanChecked.IsChecked = false;
                        }
                        else if (buyer.gender.Equals("W", StringComparison.OrdinalIgnoreCase))
                        {
                            ManChecked.IsChecked = false;
                            WomanChecked.IsChecked = true;
                        }
                    }
                }
            }
            else if (DBManager.id_employee != 0)
            {
                var employee = DBManager.db.Employee.FirstOrDefault(e => e.id == DBManager.id_employee);
                if (employee != null)
                {
                    txtLogin.Text = employee.login;
                    txtName.Text = employee.name;
                    txtSurname.Text = employee.surname;
                    txtPassword.Password = employee.password; 
                    txtLastname.Text= employee.lastname;
                    tbPassword.Text = employee.password;
                    if (!string.IsNullOrEmpty(employee.gender))
                    {
                        if (employee.gender.Equals("M", StringComparison.OrdinalIgnoreCase))
                        {
                            ManChecked.IsChecked = true;
                            WomanChecked.IsChecked = false;
                        }
                        else if (employee.gender.Equals("W", StringComparison.OrdinalIgnoreCase))
                        {
                            ManChecked.IsChecked = false;
                            WomanChecked.IsChecked = true;
                        }
                    }
                }
            }
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

                    if (DBManager.id_buyer != 0) 
                    {
                        var buyer = DBManager.db.Buyer.FirstOrDefault(b => b.id == DBManager.id_buyer);
                        if (buyer != null)
                        {
                            buyer.photo = imageData;
                            DBManager.db.SaveChanges();
                            MessageBox.Show("Фото покупателя обновлено!");
                        }
                    }
                    else if (DBManager.id_employee != 0) 
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
            ProfileImage.Source = bitmap;
            DBManager.CurrentProfileImage = bitmap;
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
        private void OnGenderChecked(object sender, RoutedEventArgs e)
        {
            var currentCheckBox = (CheckBox)sender;

            if (currentCheckBox.IsChecked == true)
            {
                if (currentCheckBox == ManChecked)
                {
                    WomanChecked.IsChecked = false;
                }
                else
                {
                    ManChecked.IsChecked = false;
                }
            }
        }

        private void Button_update(object sender, RoutedEventArgs e)
        {
            dop_info.Visibility = Visibility.Visible;

            txtLogin.IsReadOnly = false;
            txtLogin.Focusable = true;
            txtName.IsReadOnly = false;
            txtName.Focusable = true;
            txtSurname.IsReadOnly = false;
            txtSurname.Focusable = true;
            txtLastname.IsReadOnly = false;
            txtLastname.Focusable = true;
            tbPassword.IsReadOnly = false;
            tbPassword.Focusable = true;

            ManChecked.IsEnabled = true;
            WomanChecked.IsEnabled = true;

            txtLogin.Focus();
        }

        private void Button_save(object sender, RoutedEventArgs e)
        {
            try
            {

                string gender = null;
                if (ManChecked.IsChecked == true)
                    gender = "m";
                else if (WomanChecked.IsChecked == true)
                    gender = "w";

              
                if (DBManager.roles == 3) 
                {
                    var buyer = DBManager.db.Buyer.FirstOrDefault(b => b.id == DBManager.id_buyer);
                    if (buyer != null)
                    {
                        buyer.login = txtLogin.Text;
                        buyer.password = tbPassword.Text;
                        buyer.name = txtName.Text;
                        buyer.surname = txtSurname.Text;
                        buyer.lastname = txtLastname.Text; 
                        buyer.gender = gender; 

                        DBManager.db.SaveChanges(); 
                        MessageBox.Show("Данные успешно сохранены!");
                    }
                }
                else if (DBManager.roles == 2) 
                {
                    var employee = DBManager.db.Employee.FirstOrDefault(emp => emp.id == DBManager.id_employee);
                    if (employee != null)
                    {
                        employee.login = txtLogin.Text;
                        employee.password = tbPassword.Text;
                        employee.name = txtName.Text;
                        employee.surname = txtSurname.Text;
                        employee.lastname = txtLastname.Text;
                        employee.gender = gender;
                        DBManager.db.SaveChanges(); 
                        MessageBox.Show("Данные успешно сохранены!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }
        private bool isPasswordVisible = false;

        private void Button_lock(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                tbPassword.Text = txtPassword.Password;
                tbPassword.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
                btnTogglePassword.Content = "🔒";
            }
            else
            {
                txtPassword.Password = tbPassword.Text;
                txtPassword.Visibility = Visibility.Visible;
                tbPassword.Visibility = Visibility.Collapsed;
                btnTogglePassword.Content = "👁";
            }
        }

    }
}
