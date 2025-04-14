using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CursWpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageColor.xaml
    /// </summary>
    public partial class PageColor : Page
    {
        DBManager manager = new DBManager();
        public PageColor()
        {
            InitializeComponent();

            ListUser.ItemsSource = null;
            ListUser.Items.Clear();
            List<Color> datausers = DBManager.db.Color.ToList();
            ListUser.ItemsSource = datausers;
        }

        private void Button_Update(object sender, RoutedEventArgs e)
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
                    var currentUser = ListUser.SelectedItem as Color;
                    DBManager.db.Color.Remove(currentUser);
                    DBManager.db.SaveChanges();
                    ListUser.ItemsSource = DBManager.db.Color.ToList();
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
