using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CursWpf.Pages
{
    public partial class PageCatalog : Page
    {
        private List<Automobile> _allAutomobiles;
        private List<Automobile> _filteredAutomobiles;

        public PageCatalog()
        {
            InitializeComponent();
            LoadAutomobiles();
            InitializeFilters();
        }

        private void LoadAutomobiles()
        {
            _allAutomobiles = DBManager.db.Automobile
                .Include(a => a.Brand)
                .Include(a => a.Color)
                .Include(a => a.Category)
                .ToList();

            _filteredAutomobiles = new List<Automobile>(_allAutomobiles);
            AutomobilesList.ItemsSource = _filteredAutomobiles;
        }

        private void InitializeFilters()
        {
            var years = _allAutomobiles
                .Select(a => a.year_of_production)
                .Distinct()
                .OrderByDescending(y => y)
                .ToList();

            var yearItems = new List<string>(years.Select(y => y.ToString()));
            yearItems.Insert(0, "Все года");

            YearFilter.ItemsSource = yearItems;
            YearFilter.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            IEnumerable<Automobile> filtered = _allAutomobiles;

            if (!string.IsNullOrWhiteSpace(TitleFilter.Text))
            {
                filtered = filtered.Where(a =>
                    a.title.Contains(TitleFilter.Text) ||
                    (a.Brand != null && a.Brand.title.Contains(TitleFilter.Text)));
            }

            if (YearFilter.SelectedItem != null && YearFilter.SelectedItem.ToString() != "Все года")
            {
                if (int.TryParse(YearFilter.SelectedItem.ToString(), out int selectedYear))
                {
                    filtered = filtered.Where(a => a.year_of_production == selectedYear);
                }
            }

            if (!string.IsNullOrWhiteSpace(PriceFromFilter.Text) && decimal.TryParse(PriceFromFilter.Text, out decimal minPrice))
            {
                filtered = filtered.Where(a => a.price >= minPrice);
            }

            if (!string.IsNullOrWhiteSpace(PriceToFilter.Text) && decimal.TryParse(PriceToFilter.Text, out decimal maxPrice))
            {
                filtered = filtered.Where(a => a.price <= maxPrice);
            }

            _filteredAutomobiles.Clear();
            _filteredAutomobiles.AddRange(filtered.ToList());

            AutomobilesList.Items.Refresh();
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ResetFilters(object sender, RoutedEventArgs e)
        {
            TitleFilter.Text = string.Empty;
            YearFilter.SelectedIndex = 0;
            PriceFromFilter.Text = string.Empty;
            PriceToFilter.Text = string.Empty;

            ApplyFilters();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true;
            }
        }

        private void Button_order(object sender, RoutedEventArgs e)
        {
            var currentBuyer = DBManager.db.Buyer.FirstOrDefault(b => b.id == DBManager.id_buyer);
            if (currentBuyer == null)
            {
                MessageBox.Show("Покупатель не найден!");
                return;
            }

            var selectedAuto = (sender as Button).DataContext as Automobile;

            try
            {
                DBManager.db.Order.Add(new Order
                {
                    Automobile_ID = selectedAuto.id,
                    Buyer_id = currentBuyer.id,
                    login = currentBuyer.login,
                    gender = currentBuyer.gender,
                    name = currentBuyer.name,
                    surname = currentBuyer.surname
                });

                DBManager.db.SaveChanges();
                MessageBox.Show("Заявка успешно оформлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}