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
    /// Логика взаимодействия для Measurers.xaml
    /// </summary>
    public partial class Measurers : Page
    {
        public ObservableCollection<Measurer> measurer { get; set; }
        public Measurers()
        {
            InitializeComponent();
            measurer = new ObservableCollection<Measurer>(Measurer.Find());
            meausurerList.ItemsSource = measurer;
        }

        public void refreshMeasurers()
        {
            measurer = new ObservableCollection<Measurer>(Measurer.Find());
            meausurerList.ItemsSource = measurer;
        }

        private void newMeasurer_Click(object sender, RoutedEventArgs e)
        {
            var view = new CreateMeasurer();

            if (view.ShowDialog() == null)
            {
                MessageBox.Show("Error");
            }
            MainMenu.measurersView.refreshMeasurers();
        }

        private void removeMeasurer_Click(object sender, RoutedEventArgs e)
        {
            var m = this.meausurerList.SelectedItem as Measurer;

            if (m != null)
            {
                Measurer.removeMeasurer(m.Id);
                MainMenu.measurersView.refreshMeasurers();
            }
            else
            {
                MessageBox.Show("Please select measure to remove master");
            }
        }
    }
}
