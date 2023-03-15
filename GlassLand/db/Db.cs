using GlassLand.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace GlassLand.db
{
    
    public class Db
    {

        static SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = @"(localdb)\MSSQLLocalDB",
            InitialCatalog = "glassland",
            UserInstance = true,
            IntegratedSecurity = true,
            AttachDBFilename = @"|DataDirectory|\glassland.mdf"
        };
        public Db() {
            
        }

        public static SqlConnection Connect() {
            return new SqlConnection(Settings.Default.glasslandConnectionString);
        }

        public void Disconnect() { }


       
    }
}
