﻿using System;
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
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public TextBox LoginBox => txtLogin;
        public PasswordBox PasswordBox => txtPassword;
        public WindowAuthorization()
        {

            InitializeComponent();
        }
        
        public void Login_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length > 0 && txtPassword.Password.Length > 0)
            {
                if (DBManager.Auth(txtLogin.Text, txtPassword.Password))
                {
                 
                    MainWindow mainwindow = new MainWindow();
                    Close();
                    mainwindow.Show();
                }
                else
                {
                    MessageBox.Show("Не верный логин/пароль");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        public void Registration_CLick(object sender, RoutedEventArgs e)
        {
            WindowRegistration windowRegistration = new WindowRegistration();
            this.Close();
            windowRegistration.Show();

        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter){
                Login_Click(sender, e);
            }
       
        }

        public void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
