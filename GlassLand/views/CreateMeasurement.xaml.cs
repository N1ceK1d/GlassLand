using GlassLand.db;
using GlassLand.pages;
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

namespace GlassLand.views
{
    /// <summary>
    /// Логика взаимодействия для CreateMeasurement.xaml
    /// </summary>
    public partial class CreateMeasurement : System.Windows.Window
    {
        public List<Measurer> Measurers { get; set; }
        public CreateMeasurement()
        {
            InitializeComponent();
            DataContext = this;

            Measurers = Measurer.Find();
        }

        private void creatCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (measurerTb.SelectedItem == null)
            {
                MessageBox.Show("Please select item");

            } 
            else
            {
                var customer = new Measurement()
                {
                    CustomerName = customerName.Text,
                    Measurer = measurerTb.Text,
                    WindowHeight = Convert.ToInt32(windowHeight.Text),
                    WindowWidth = Convert.ToInt32(windowWidth.Text),
                    Address = address.Text,
                    Date = (dateTb.SelectedDate != null) ? (DateTime)dateTb.SelectedDate : DateTime.Now,
                };
                customer.addMeasurment();

                MainMenu.measurementsView.RefreshMeasurementList();
            }
        }
    }
}
