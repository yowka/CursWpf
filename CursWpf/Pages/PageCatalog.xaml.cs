using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using DocumentFormat.OpenXml.Drawing.Charts;

namespace CursWpf.Pages
{
    
    public partial class PageCatalog : Page
    {
        public PageCatalog()
        {
            InitializeComponent();
            LoadAutomobiles();

        }
        private void LoadAutomobiles()
        {
          
                var automobiles = DBManager.db.Automobile
                      .Include(a => a.Brand)
                      .Include(a => a.Color)
                     .Include(a => a.Category)
                     .ToList();
                AutomobilesList.ItemsSource = automobiles.ToList();
        }
        private void Button_order(object sender, RoutedEventArgs e)
        {
            var currentBuyer = DBManager.db.Buyer.FirstOrDefault(b => b.id == DBManager.id_buyer);
            if (currentBuyer == null)
            {
                MessageBox.Show("Покупатель не найден!");
                return;
            }

            var selectedAuto = (sender as Button).DataContext as Automobile;
            
            try
            {
                DBManager.db.Order.Add(new Order
                {
                    Automobile_ID = selectedAuto.id,
                    Buyer_id = currentBuyer.id,
                    login = currentBuyer.login,
                    gender = currentBuyer.gender,
                    name = currentBuyer.name,
                    surname = currentBuyer.surname
                });
                
                DBManager.db.SaveChanges();
                MessageBox.Show("Заявка успешно оформлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
