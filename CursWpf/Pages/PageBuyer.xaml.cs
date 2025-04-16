using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CursWpf.Pages
{
    public partial class PageBuyer : Page
    {
        DBManager manager = new DBManager();
        public PageBuyer()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            ListUser.ItemsSource = DBManager.db.Buyer.ToList();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                ListUser.CommitEdit(DataGridEditingUnit.Row, true);

                var allBuyers = ListUser.ItemsSource as IEnumerable<Buyer>;

                foreach (var Buyer in allBuyers)
                {
                    if (Buyer.id == 0)
                    {
                        DBManager.db.Buyer.Add(Buyer);
                    }
                }

                DBManager.db.SaveChanges();
                LoadData();

                MessageBox.Show("Данные успешно сохранены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (ListUser.SelectedItem != null)
            {
                var result = MessageBox.Show("Удалить выбранную запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var selectedBuyer = ListUser.SelectedItem as Buyer;
                        DBManager.db.Buyer.Remove(selectedBuyer);
                        DBManager.db.SaveChanges();
                        LoadData();
                        MessageBox.Show("Запись удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для удаления!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}