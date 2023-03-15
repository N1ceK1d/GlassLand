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
    /// Логика взаимодействия для CreateMeasurer.xaml
    /// </summary>
    public partial class CreateMeasurer : System.Windows.Window
    {
        public CreateMeasurer()
        {
            InitializeComponent();
        }

        private void creatMeasurerBtn_Click(object sender, RoutedEventArgs e)
        {
            Measurer.addMeasurer(measurerName.Text);
            MainMenu.measurersView.refreshMeasurers();
        }
    }
}
