using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CursWpf.Pages
{
    public partial class PageEmployee : Page
    {
        DBManager manager = new DBManager();
        public PageEmployee()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            ListUser.ItemsSource = DBManager.db.Employee.ToList();
        }

      
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                ListUser.CommitEdit(DataGridEditingUnit.Row, true);

                var allEmployees = ListUser.ItemsSource as IEnumerable<Employee>;

                foreach (var item in ListUser.Items)
                {
                    if (item is Employee emp && emp.id == 0) 
                    {
                        emp.role_id = 2;
                        DBManager.db.Employee.Add(emp); 
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
                        var selectedEmployee = ListUser.SelectedItem as Employee;
                        DBManager.db.Employee.Remove(selectedEmployee);
                        DBManager.db.SaveChanges();
                        LoadData();
                        MessageBox.Show("Запись удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException dbEx)
                    {
                        // Обработка ошибок связанных данных
                        string errorMessage = "Не удалось удалить запись:\n";
                        var innerException = dbEx.InnerException?.InnerException ?? dbEx.InnerException;
                        errorMessage += innerException?.Message ?? dbEx.Message;

                        MessageBox.Show(errorMessage, "Ошибка удаления",
                                      MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                                      MessageBoxButton.OK, MessageBoxImage.Error);
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