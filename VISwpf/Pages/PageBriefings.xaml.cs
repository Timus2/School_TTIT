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
using VISwpf.Common;

namespace VISwpf.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBriefings.xaml
    /// </summary>
    public partial class PageBriefings : Page
    {
        private List<Briefing> listBriefings;
        public PageBriefings()
        {
            InitializeComponent();
            UpdateDataGridBriefings();
        }

        private void UpdateDataGridBriefings()
        {
            var list = AppDB.GetInstance().Briefing.ToList();
            listBriefings = list;
            DataGridBriefings.ItemsSource = listBriefings;
        }
    }
}
