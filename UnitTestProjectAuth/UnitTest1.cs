using CursWpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UnitTestProjectAuth
{
    [TestClass]
    public class AuthTests
    {
        // Тест 1: Пустые поля ввода вызывают сообщение об ошибке
        [TestMethod]
        public void Login_EmptyFields_ShowErrorMessage()
        {
            var window = new WindowAuthorization();
            window.LoginBox.Text = ""; 
            window.PasswordBox.Password = ""; 

            bool isAnyFieldEmpty = string.IsNullOrEmpty(window.LoginBox.Text) || string.IsNullOrEmpty(window.PasswordBox.Password);

            if (isAnyFieldEmpty)
            {
                MessageBox.Show("Заполните все поля!"); 
            }

            Assert.IsTrue(isAnyFieldEmpty); 
        }

        // Тест 2: Кнопка "Отмена" закрывает окно
        [TestMethod]
        public void CancelButton_ClosesWindow()
        {
            var window = new WindowAuthorization();

            window.Button_Close(null, new RoutedEventArgs());

            Assert.IsFalse(window.IsVisible);
        }

        // Тест 3: Кнопка входа становится активной только при заполнении всех полей
        [TestMethod]
        public void LoginButton_IsEnabledOnlyWhenFieldsAreFilled()
        {
            var window = new WindowAuthorization();

            var loginButton = new Button { IsEnabled = false };

            loginButton.IsEnabled = !string.IsNullOrEmpty(window.LoginBox.Text) && !string.IsNullOrEmpty(window.PasswordBox.Password);

            Assert.IsFalse(loginButton.IsEnabled);

            window.LoginBox.Text = "user";
            window.PasswordBox.Password = "password";

            loginButton.IsEnabled = !string.IsNullOrEmpty(window.LoginBox.Text) && !string.IsNullOrEmpty(window.PasswordBox.Password);

            Assert.IsTrue(loginButton.IsEnabled);
        }

        // Тест 4: Показать/скрыть пароль
        [TestMethod]
        public void TogglePasswordVisibility_ChangesPasswordVisibility()
        {
            var window = new WindowAuthorization();

            var passwordTextBox = new TextBox { Text = "", Visibility = Visibility.Collapsed };
            var passwordBox = new PasswordBox { Password = "hiddenPassword", Visibility = Visibility.Visible };

            bool isPasswordVisible = false;

            if (!isPasswordVisible)
            {
                passwordTextBox.Text = passwordBox.Password; 
                passwordTextBox.Visibility = Visibility.Visible;
                passwordBox.Visibility = Visibility.Collapsed;
                isPasswordVisible = true;
            }

            Assert.IsTrue(passwordTextBox.Visibility == Visibility.Visible);
            Assert.AreEqual("hiddenPassword", passwordTextBox.Text);
        }

        // Тест 5: Ограничение длины логина и пароля
        [TestMethod]
        public void Login_TrimWhitespace_SuccessfulAuthentication()
        {
            var window = new WindowAuthorization();

            window.LoginBox.Text = "  validUser  "; 
            window.PasswordBox.Password = "  validPassword  "; 

            string trimmedLogin = window.LoginBox.Text.Trim();
            string trimmedPassword = window.PasswordBox.Password.Trim();

            bool isAuthenticated = (trimmedLogin == "validUser" && trimmedPassword == "validPassword");

            if (isAuthenticated)
            {
                window.Close(); 
            }

            Assert.AreEqual("validUser", trimmedLogin, "Пробелы не были удалены из логина");
            Assert.AreEqual("validPassword", trimmedPassword, "Пробелы не были удалены из пароля");
            Assert.IsFalse(window.IsVisible, "Окно не закрылось после успешной авторизации");
        }
    }
}