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
    /// Логика взаимодействия для CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : System.Windows.Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void createWindowBtn_Click(object sender, RoutedEventArgs e)
        {
            db.Window.addWindow(windowName.Text);
            MainMenu.windowsView.refreshWindows();
        }
    }
}
