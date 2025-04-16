using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CursWpf.Pages
{
    public partial class PageColor : Page
    {
        DBManager manager = new DBManager();
        public PageColor()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            ListUser.ItemsSource = DBManager.db.Color.ToList();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                ListUser.CommitEdit(DataGridEditingUnit.Row, true);

                var allColors = ListUser.ItemsSource as IEnumerable<Color>;

                foreach (var color in allColors)
                {
                    if (color.id == 0) 
                    {
                        DBManager.db.Color.Add(color); 
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
                        var selectedColor = ListUser.SelectedItem as Color;
                        DBManager.db.Color.Remove(selectedColor);
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