using CursWpf.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
            LoadProfileImage();
      
            this.Focus();
            if (DBManager.roles == 2)
            {
                tables.Visibility = Visibility.Visible;
                sale.Visibility = Visibility.Visible;
                order.Visibility = Visibility.Visible;
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
            PageSaleAutomobile pageSale = new PageSaleAutomobile();
            frame.Navigate(pageSale);
        }
        private void Button_Profile(object sender, RoutedEventArgs e)
        {
            WindowProfile windowProfile = new WindowProfile();
            windowProfile.ShowDialog();
            LoadProfileImage();
        }
        private void Button_Catalog(object sender, RoutedEventArgs e)
        {
            PageCatalog pageCatalog = new PageCatalog();
            frame.Navigate(pageCatalog);
        }
        private void LoadProfileImage()
        {
            if (DBManager.CurrentImage != null)
            {
                ProfileImage.Source = DBManager.CurrentImage;
                return;
            }
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
                    DBManager.CurrentImage = bitmap; 
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
                    DBManager.CurrentImage = bitmap; 
                }
            }

        }

        private void Click_order(object sender, RoutedEventArgs e)
        {
            PageOrder order = new PageOrder();
            frame.Navigate(order);
        }
    }
}
