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

namespace CursWpf
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        public WindowRegistration()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            WindowAuthorization windowAuthorization = new WindowAuthorization();
            this.Close();
            windowAuthorization.Show();
        }

        private void Registration_CLick(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length > 0 && txtSurname.Text.Length > 0 && txtLogin.Text.Length>0 && txtPassword.Password.Length>0)
            {
                if (DBManager.Reg(txtName.Text, txtSurname.Text, txtLogin.Text, txtPassword.Password, DBManager.File))
                {
                    WindowAuthorization windowAuthorization = new WindowAuthorization();
                    Close();
                    windowAuthorization.Show();
                }
                else
                {
                    MessageBox.Show("Не верны входные данные");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Registration_CLick(sender, e);
            }
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
