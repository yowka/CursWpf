using CursWpf.Pages;
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

namespace CursWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Focus();
            if (DBManager.roles == 2)
            {
                tables.Visibility = Visibility.Visible;
                sale.Visibility = Visibility.Visible;
            }
            if (DBManager.roles == 1)
            {
                employee.Visibility = Visibility.Visible;
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            frame.Navigate(homePage);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            frame.Navigate(homePage);
        }
        private void Click_Employee(object sender, RoutedEventArgs e)
        {
            PanelsPage panelsPage = new PanelsPage();
            frame.Navigate(panelsPage);
        }
        private void Click_Tables(object sender, RoutedEventArgs e)
        {
            PanelsPage panelsPage = new PanelsPage();
            frame.Navigate(panelsPage);
        }
        private void Click_Sale(object sender, RoutedEventArgs e)
        {
        }
        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            WindowProfile windowProfile = new WindowProfile();
            windowProfile.ShowDialog();
        }
        private void Button_Catalog(object sender, RoutedEventArgs e)
        {
            PageCatalog pageCatalog = new PageCatalog();
            frame.Navigate(pageCatalog);
        }

    }
}
