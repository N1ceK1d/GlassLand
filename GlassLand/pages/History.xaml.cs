using GlassLand.db;
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

namespace GlassLand.pages
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        public ObservableCollection<db.History> history { get; set; }
        public db.History historyItem = new db.History();
        public History()
        {
            InitializeComponent();
            history = new ObservableCollection<db.History>(db.History.Find());
            historyList.ItemsSource = history;
            CompletedCount.Text = $"Completed: {historyItem.getCount("Complete")}";
            CanceledCount.Text = $"Canceled: {historyItem.getCount("Cancel")}";
            List<string> items = new List<string>() { "All", "Completed", "Canceled" };
            StatusItems.ItemsSource = items;
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterItems_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
