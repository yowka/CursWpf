using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    public partial class PageBuyer : Page
    {
        DBManager manager = new DBManager();
        public PageBuyer()
        {
            InitializeComponent();

            ListUser.ItemsSource = null;
            ListUser.Items.Clear();
            List<Buyer> datausers = DBManager.db.Buyer.ToList();
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
                    var currentUser = ListUser.SelectedItem as Buyer;
                    DBManager.db.Buyer.Remove(currentUser);
                    DBManager.db.SaveChanges();
                    ListUser.ItemsSource = DBManager.db.Buyer.ToList();
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
