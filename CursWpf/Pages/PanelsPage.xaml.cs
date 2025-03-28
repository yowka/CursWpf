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

namespace CursWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для PanelsPage.xaml
    /// </summary>
    public partial class PanelsPage : Page
    {
        public PanelsPage()
        {
            InitializeComponent();
            
            if (DBManager.roles == 1)
            {
                automobile.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Visible;
                brand.Visibility = Visibility.Collapsed;
                buyer.Visibility = Visibility.Collapsed;
                category.Visibility = Visibility.Collapsed;
                color.Visibility= Visibility.Collapsed;
                sale.Visibility= Visibility.Collapsed;
            }
            if (DBManager.roles == 2)
            {
                automobile.Visibility = Visibility.Visible;
                employee.Visibility = Visibility.Collapsed;
                brand.Visibility = Visibility.Visible;
                buyer.Visibility = Visibility.Visible;
                category.Visibility = Visibility.Visible;
                color.Visibility= Visibility.Visible;
                sale.Visibility= Visibility.Visible;
            }
        }

        private void buyer_Click(object sender, RoutedEventArgs e)
        {
            PageBuyer pageBuyer = new PageBuyer();
            DataFrame.Navigate(pageBuyer);
        }

        private void automobile_Click(object sender, RoutedEventArgs e)
        {
            PageAutomobile pageAutomobile = new PageAutomobile();
            DataFrame.Navigate(pageAutomobile);
        }

        private void brand_Click(object sender, RoutedEventArgs e)
        {
            PageBrand pageBrand = new PageBrand();
            DataFrame.Navigate(pageBrand);
        }

        private void category_Click(object sender, RoutedEventArgs e)
        {
            PageCategory pageCategory = new PageCategory();
            DataFrame.Navigate(pageCategory);
        }

        private void color_Click(object sender, RoutedEventArgs e)
        {
            PageColor pageColor = new PageColor();
            DataFrame.Navigate(pageColor);
        }

        private void sale_Click(object sender, RoutedEventArgs e)
        {
            PageSaleAutomobile pageSale = new PageSaleAutomobile();
            DataFrame.Navigate(pageSale);
        }

        private void employee_Click(object sender, RoutedEventArgs e)
        {
            PageEmployee pageEmployee = new PageEmployee();
            DataFrame.Navigate(pageEmployee);
        }
    }
}
