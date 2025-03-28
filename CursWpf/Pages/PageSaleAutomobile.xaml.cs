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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CursWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageSaleAutomobileAutomobile.xaml
    /// </summary>
    public partial class PageSaleAutomobile : Page
    {
        DBManager manager = new DBManager();
        public PageSaleAutomobile()
        {
            InitializeComponent();

            ListUser.ItemsSource = null;
            ListUser.Items.Clear();
            List<Sale_automobile> datausers = DBManager.db.Sale_automobile.ToList();
            ListUser.ItemsSource = datausers;
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            try
            {

                DBManager.db.SaveChanges();
                MessageBox.Show("Изменения сохранены в базе данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (ListUser.SelectedItems != null)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var saleAutomobile = ListUser.SelectedItem as Sale_automobile;
                    DBManager.db.Sale_automobile.Remove(saleAutomobile);
                    DBManager.db.SaveChanges();
                    ListUser.ItemsSource = DBManager.db.Sale_automobile.ToList();
                    MessageBox.Show("Запись успешно удалена!");
                }
            }
            else
            {
                MessageBox.Show("Выделите данные для удаления!");
            }
        }
    }
}
