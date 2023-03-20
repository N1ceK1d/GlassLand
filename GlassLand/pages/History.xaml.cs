using GlassLand.db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            CompletedCount.Text = $"Completed: {historyItem.getCount("Completed")}";
            List<string> items = new List<string>() { "All", "New", "Accepted", "Declined", "Completed" };
            StatusItems.ItemsSource = items;
        }

        private bool checkSelected()
        {
            if (StatusItems.SelectedItem == null)
            {
                MessageBox.Show("Please select item");
                return false;
            }
            return true;
        }

        public void RefreshHistory()
        {
            history = new ObservableCollection<db.History>(db.History.Find());
            historyList.ItemsSource = history;
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterItems_Click(object sender, RoutedEventArgs e)
        {
            if(checkSelected())
            {
                history = new ObservableCollection<db.History>(db.History.Filter(StatusItems.Text));
                historyList.ItemsSource = history;
            }
        }
    }
}
