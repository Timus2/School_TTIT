﻿using System;
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
using VISwpf.Common;

namespace VISwpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePositions.xaml
    /// </summary>
    public partial class PagePositions : Page
    {
        public PagePositions()
        {
            InitializeComponent();
            UpdateDataGridPositions();
        }

        private void UpdateDataGridPositions()
        {
            var list = AppDB.GetInstance().Position.ToList();

            DataGridPositions.ItemsSource = list;
        }
    }
}
