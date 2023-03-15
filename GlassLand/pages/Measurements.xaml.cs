using GlassLand.db;
using GlassLand.views;
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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Measurements : Page
    {
        public ObservableCollection<Measurement> measurements { get; }
        public Measurements()
        {
            InitializeComponent();


            
            measurements = new ObservableCollection<Measurement>(Measurement.Find());
            measurementsList.ItemsSource = measurements;
        }

        private void newOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var m = this.measurementsList.SelectedItem as Measurement;

            if (m != null)
            {
                var view = new CreateOrder(m);

                if (view.ShowDialog() == null)
                {
                    MessageBox.Show("Error");
                }

                MainMenu.montagesView.RefreshList();
            } else
            {
                MessageBox.Show("Please select measure to create order");
            }


        }


    }
}
