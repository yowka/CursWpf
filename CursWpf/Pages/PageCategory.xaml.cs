using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CursWpf.Pages
{
    public partial class PageCategory : Page
    {
        DBManager manager = new DBManager();
        public PageCategory()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            ListUser.ItemsSource = DBManager.db.Category.ToList();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                ListUser.CommitEdit(DataGridEditingUnit.Row, true);

                var allCategorys = ListUser.ItemsSource as IEnumerable<Category>;

                foreach (var Category in allCategorys)
                {
                    if (Category.id == 0)
                    {
                        DBManager.db.Category.Add(Category);
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
                        var selectedCategory = ListUser.SelectedItem as Category;
                        DBManager.db.Category.Remove(selectedCategory);
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