using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CursWpf.Pages
{
    public partial class PageOrder : Page
    {
        public PageOrder()
        {
            InitializeComponent();
            LoadOrders(); 

        }

        private void LoadOrders()
        {
            var orders = DBManager.db.Order
                .Include(o => o.Automobile)  
                .Include(o => o.Buyer)       
                .ToList();

            ListUser.ItemsSource = orders; 
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            if (ListUser.SelectedItem == null) return;

            var order = (Order)ListUser.SelectedItem;

            var sale = new Sale_automobile
            {
                date = DateTime.Now,
                Automobile_ID = order.Automobile_ID,
                Employee_ID = DBManager.id_employee,
                Buyer_ID = order.Buyer_id,
            };

            DBManager.db.Sale_automobile.Add(sale);
            DBManager.db.Order.Remove(order);
            DBManager.db.SaveChanges();

            LoadOrders();

            MessageBox.Show("Заявка принята и удалена из списка!");
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (ListUser.SelectedItem == null) return;

            var order = (Order)ListUser.SelectedItem;

            DBManager.db.Order.Remove(order);
            DBManager.db.SaveChanges();

            LoadOrders(); 

            MessageBox.Show("Заявка отклонена и удалена из списка!");
        }
    }
}