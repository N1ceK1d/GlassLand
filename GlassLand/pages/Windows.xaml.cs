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
using GlassLand.db;
using GlassLand.views;

namespace GlassLand.pages
{
    /// <summary>
    /// Логика взаимодействия для Windows.xaml
    /// </summary>
    public partial class Windows : Page
    { 
        public ObservableCollection<db.Window> window { get; set; }
        public Windows()
        {
            InitializeComponent();
            window = new ObservableCollection<db.Window>(db.Window.Find());
            windowsList.ItemsSource = window;
        }

        public void refreshWindows()
        {
            window = new ObservableCollection<db.Window>(db.Window.Find());
            windowsList.ItemsSource = window;
        }

        private void newWindow_Click(object sender, RoutedEventArgs e)
        {
            var view = new CreateWindow();

            if (view.ShowDialog() == null)
            {
                MessageBox.Show("Error");
            }

            MainMenu.windowsView.refreshWindows();
        }

        private void removeWindow_Click(object sender, RoutedEventArgs e)
        {
            var m = this.windowsList.SelectedItem as db.Window;

            if (m != null)
            {
                //var view = new CreateOrder(m);
                //
                //if (view.ShowDialog() == null)
                //{
                //    MessageBox.Show("Error");
                //}

                //"DELETE FROM Employeers Where ID = '" +  + "';"
                db.Window.removeWindow(m.Id);

                MainMenu.windowsView.refreshWindows();
            }
            else
            {
                MessageBox.Show("Please select measure to remove window");
            }
        }
    }
}
