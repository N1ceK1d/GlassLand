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
    /// Логика взаимодействия для Masters.xaml
    /// </summary>
    public partial class Masters : Page
    {

        public ObservableCollection<Master> master { get; set; }
        public Masters()
        {
            InitializeComponent();
            master = new ObservableCollection<Master>(Master.Find());
            mastersList.ItemsSource = master;
        }

        public void refreshMasters()
        {
            master = new ObservableCollection<Master>(Master.Find());
            mastersList.ItemsSource = master;
        }

        private void newMaster_Click(object sender, RoutedEventArgs e)
        {
            //Master.addMaster();
            //refreshMasters();
           
                var view = new CreateMaster();

                if (view.ShowDialog() == null)
                {
                    MessageBox.Show("Error");
                }

                MainMenu.mastersView.refreshMasters();
            
        }

        private void removeMaster_Click(object sender, RoutedEventArgs e)
        {
            var m = this.mastersList.SelectedItem as Master;

            if (m != null)
            {
                //var view = new CreateOrder(m);
                //
                //if (view.ShowDialog() == null)
                //{
                //    MessageBox.Show("Error");
                //}

                //"DELETE FROM Employeers Where ID = '" +  + "';"
                Master.removeMaster(m.Id);

                MainMenu.mastersView.refreshMasters();
            }
            else
            {
                MessageBox.Show("Please select measure to remove master");
            }
        }
    }
}
