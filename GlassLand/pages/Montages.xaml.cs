using GlassLand.db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
                var history = new db.History()
                {
                    CustomerName = Measurement.FindOne(m.Id).CustomerName,
                    Address = Measurement.FindOne(m.Id).Address,
                    MasterName = m.Master,
                    MeasurerName = Measurement.FindOne(m.Id).Measurer,
                    Window = m.Window,
                    WindowHeight = Convert.ToInt32(Measurement.FindOne(m.Id).WindowHeight),
                    WindowWidth = Convert.ToInt32(Measurement.FindOne(m.Id).WindowWidth),
                    Status = "Declined",
                    Date = (m.Date != null) ? m.Date : DateTime.Now
                };
                history.addHistory();
                MainMenu.historyView.RefreshHistory();
            }
        }

        private void acceptBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkSelected())
            {
                var m = montagesList.SelectedItem as Montage;
                m.UpdateStatus("Accepted");
                RefreshList();
                var history = new db.History()
                {
                    CustomerName = Measurement.FindOne(m.Id).CustomerName,
                    Address = Measurement.FindOne(m.Id).Address,
                    MasterName = m.Master,
                    MeasurerName = Measurement.FindOne(m.Id).Measurer,
                    Window = m.Window,
                    WindowHeight = Convert.ToInt32(Measurement.FindOne(m.Id).WindowHeight),
                    WindowWidth = Convert.ToInt32(Measurement.FindOne(m.Id).WindowWidth),
                    Status = "Accepted",
                    Date = (m.Date != null) ? m.Date : DateTime.Now
                };
                history.addHistory();
                MainMenu.historyView.RefreshHistory();
            }
        }

        private void completeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkSelected())
            {
                var m = montagesList.SelectedItem as Montage;
                m.UpdateStatus("Completed");
                RefreshList();
                var history = new db.History()
                {
                    CustomerName = Measurement.FindOne(m.Id).CustomerName,
                    Address = Measurement.FindOne(m.Id).Address,
                    MasterName = m.Master,
                    MeasurerName = Measurement.FindOne(m.Id).Measurer,
                    Window = m.Window,
                    WindowHeight = Convert.ToInt32(Measurement.FindOne(m.Id).WindowHeight),
                    WindowWidth = Convert.ToInt32(Measurement.FindOne(m.Id).WindowWidth),
                    Status = "Completed",
                    Date = (m.Date != null) ? m.Date : DateTime.Now
                };
                history.addHistory();
                MainMenu.historyView.RefreshHistory();
            }
        }
    }
}
