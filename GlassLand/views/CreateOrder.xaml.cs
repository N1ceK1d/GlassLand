using GlassLand.db;
using GlassLand.pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace GlassLand.views
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : System.Windows.Window
    {

        public Measurement measurement;
        public List<Master> Masters { get; set; }
        public List<db.Window> Windows { get; set; }

        public int index;
        public CreateOrder(Measurement m)
        {
            InitializeComponent();
            DataContext = this;
            Masters = Master.Find();
            Windows = db.Window.Find();
            measurement = m;
            index = m.Id;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Montage()
            {
                Master = masterTb.Text,
                Window = windowTb.Text,
                Measurement = measurement,
                Status = "New",
                Date = (dateTb.SelectedDate != null) ? (DateTime)dateTb.SelectedDate : DateTime.Now,
            };

            var history = new db.History()
            {
                CustomerName = Measurement.FindOne(index).CustomerName,
                Address = Measurement.FindOne(index).Address,
                MasterName = masterTb.Text,
                MeasurerName = Measurement.FindOne(index).Measurer,
                Window = windowTb.Text,
                WindowHeight = Convert.ToInt32(Measurement.FindOne(index).WindowHeight),
                WindowWidth = Convert.ToInt32(Measurement.FindOne(index).WindowWidth),
                Status = "New",
                Date = (dateTb.SelectedDate != null) ? (DateTime)dateTb.SelectedDate : DateTime.Now
            };
            
            
            history.addHistory();
            MainMenu.historyView.RefreshHistory();
            customer.Save();

            this.DialogResult = true;
            return;
        }
    }
}
