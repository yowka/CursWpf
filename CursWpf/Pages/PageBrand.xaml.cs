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
    /// Логика взаимодействия для PageBrand.xaml
    /// </summary>
    public partial class PageBrand : Page
    {
        DBManager manager = new DBManager();
        public PageBrand()
        {
            InitializeComponent();

            ListUser.ItemsSource = null;
            ListUser.Items.Clear();
            List<Brand> datausers = DBManager.db.Brand.ToList();
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
                    var brand = ListUser.SelectedItem as Brand;
                    DBManager.db.Brand.Remove(brand);
                    DBManager.db.SaveChanges();
                    ListUser.ItemsSource = DBManager.db.Brand.ToList();
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
