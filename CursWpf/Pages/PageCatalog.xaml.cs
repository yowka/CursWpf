﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для PageCatalog.xaml
    /// </summary>
    public partial class PageCatalog : Page
    {
        public PageCatalog()
        {
            InitializeComponent();
            LoadAutomobiles();
        }
        private void LoadAutomobiles()
        {
                var automobiles = DBManager.db.Automobile
                      .Include(a => a.Brand)
                      .Include(a => a.Color)
                     .Include(a => a.Category)
                     .ToList();
                AutomobilesList.ItemsSource = automobiles.ToList();
        }
    }
}
