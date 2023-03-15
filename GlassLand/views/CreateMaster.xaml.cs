using GlassLand.db;
using GlassLand.pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlassLand.views
{
    /// <summary>
    /// Логика взаимодействия для CreateMaster.xaml
    /// </summary>
    public partial class CreateMaster : System.Windows.Window
    {
        public CreateMaster()
        {
            InitializeComponent();
        }

        private void creatMasterBtn_Click(object sender, RoutedEventArgs e)
        {
            Master.addMaster(masterName.Text);
            MainMenu.mastersView.refreshMasters();
            //refreshMasters();
        }
    }
}
