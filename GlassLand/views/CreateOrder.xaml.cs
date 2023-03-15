using GlassLand.db;
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
        public CreateOrder(Measurement m)
        {
            InitializeComponent();
            DataContext = this;
            Masters = Master.Find();
            Windows = db.Window.Find();
            measurement = m;
        }

        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {


            var order = new Montage()
            {
                Master = masterTb.Text,
                Window = windowTb.Text,
                Measurement= measurement,
                Status = "New",
                Date = (dateTb.SelectedDate != null) ? (DateTime)dateTb.SelectedDate : DateTime.Now,
            };

            order.Save();

            this.DialogResult = true;
            return;
        }
    }
}
