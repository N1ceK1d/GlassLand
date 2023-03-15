using GlassLand.db;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            loginTb.Text = "";
            passwordTb.Password = "";
        }


        private void submitBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = User.Login(loginTb.Text, passwordTb.Password);

            if (null == user)
            {
                MessageBox.Show("Incorrect login or password");
                Clear();
                return;
            }

            //MessageBox.Show($"{this.Parent}");

            MainWindow.ChangePage(new MainMenu());

        }
    }
}
