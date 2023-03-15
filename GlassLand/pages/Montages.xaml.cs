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
    /// Interaction logic for Montages.xaml
    /// </summary>
    public partial class Montages : Page
    {
        public static ObservableCollection<Montage> montages;
        public Montages()
        {
            InitializeComponent();

            montages = new ObservableCollection<Montage>(Montage.Find());
            montagesList.ItemsSource = montages;
        }

        public void RefreshList()
        {
            montages = new ObservableCollection<Montage>(Montage.Find());
            montagesList.ItemsSource = montages;
        }

        private bool checkSelected() {
            if (montagesList.SelectedItem == null)
            {
                MessageBox.Show("Please select item");
                return false;
            }
            return true;
        }

        private void declineBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkSelected())
            {
                var m = montagesList.SelectedItem as Montage;
                m.UpdateStatus("Declined");
                RefreshList();
            }
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkSelected())
            {
                var m = montagesList.SelectedItem as Montage;
                m.UpdateStatus("Accepted");
                RefreshList();
            }
        }
    }
}
