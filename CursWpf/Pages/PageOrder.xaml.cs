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

            DBManager.db.SaveChanges();

            var items = (List<Order>)ListUser.ItemsSource;
            items.Remove(order);
            ListUser.ItemsSource = null;
            ListUser.ItemsSource = items;

            MessageBox.Show("Заявка принята и удалена из списка!");
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (ListUser.SelectedItem == null) return;

            var order = (Order)ListUser.SelectedItem;

            DBManager.db.SaveChanges();

            var items = (List<Order>)ListUser.ItemsSource;
            items.Remove(order);
            ListUser.ItemsSource = null;
            ListUser.ItemsSource = items;

            MessageBox.Show("Заявка отклонена и удалена из списка!");
        }
    }
}