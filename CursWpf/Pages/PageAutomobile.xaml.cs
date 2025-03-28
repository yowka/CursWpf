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
    /// Логика взаимодействия для PageAutomobile.xaml
    /// </summary>
    public partial class PageAutomobile : Page
    {
        DBManager manager = new DBManager();

        public PageAutomobile()
        {
            InitializeComponent();
            ListUser.ItemsSource = null;
            ListUser.Items.Clear();
            List<Automobile> datausers = DBManager.db.Automobile.ToList();
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
                    var automobile = ListUser.SelectedItem as Automobile;
                    DBManager.db.Automobile.Remove(automobile);
                    DBManager.db.SaveChanges();
                    ListUser.ItemsSource = DBManager.db.Automobile.ToList();
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
