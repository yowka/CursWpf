using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClosedXML.Excel;
using Microsoft.Win32;

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

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Сохранить как Excel файл",
                FileName = "Продажи авто.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Продажи авто");
                
                        worksheet.Columns(1, 4).Width = 20;
                
                        worksheet.Cell(1, 1).Value = "Дата продажи";
                        worksheet.Cell(1, 2).Value = "Название авто";
                        worksheet.Cell(1, 3).Value = "Имя сотрудника";
                        worksheet.Cell(1, 4).Value = "Логин покупателя";
                
                        int rowIndex = 2;
                        foreach (var item in ListUser.Items)
                        {
                            var itemType = item.GetType();
                    
                            var dateValue = GetPropertyValue(item, "date")?.ToString() ?? "";
                            var autoTitle = GetPropertyValue(GetPropertyValue(item, "Automobile"), "title")?.ToString() ?? "";
                            var empName = GetPropertyValue(GetPropertyValue(item, "Employee"), "name")?.ToString() ?? "";
                            var buyerLogin = GetPropertyValue(GetPropertyValue(item, "Buyer"), "login")?.ToString() ?? "";

                            worksheet.Cell(rowIndex, 1).Value = dateValue;
                            worksheet.Cell(rowIndex, 2).Value = autoTitle;
                            worksheet.Cell(rowIndex, 3).Value = empName;
                            worksheet.Cell(rowIndex, 4).Value = buyerLogin;
                    
                            rowIndex++;
                        }

                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Данные успешно сохранены в Excel файл!", "Успех", 
                                      MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", 
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private object GetPropertyValue(object obj, string propertyName)
        {
            if (obj == null) return null;
    
            var prop = obj.GetType().GetProperty(propertyName);
            return prop?.GetValue(obj, null);
        }

    }
}
