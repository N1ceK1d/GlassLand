using FastReport;
using FastReport.Data;
using FastReport.Utils;
using FastReport.Table;
using GlassLand.db;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Fizzler;

namespace GlassLand.pages
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Page
    {
        public ObservableCollection<db.History> history { get; set; }
        public db.History historyItem = new db.History();
        public History()
        {
            InitializeComponent();
            history = new ObservableCollection<db.History>(db.History.Find());
            historyList.ItemsSource = history;
            List<string> items = new List<string>() { "All", "New", "Accepted", "Declined", "Completed" };
            StatusItems.ItemsSource = items;
            CompletedCount.Text = $"Completed: {db.History.getCount()}";
        }

        private bool checkSelected()
        {
            if (StatusItems.SelectedItem == null)
            {
                MessageBox.Show("Please select item");
                return false;
            }
            return true;
        }

        public void RefreshHistory()
        {
            history = new ObservableCollection<db.History>(db.History.Find());
            historyList.ItemsSource = history;
        }

        public void RefreshCount()
        {
            CompletedCount.Text = $"Completed: {db.History.getCount()}";
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var histories = new List<db.History>();

                var sql = @"SELECT 
                (SELECT COUNT(Id) FROM History  WHERE Status = 'Completed') as Completed,
                (SELECT COUNT(Id) FROM History  WHERE Status = 'Declined') as Declined,
                (SELECT COUNT(Id) FROM History  WHERE Status = 'New') as New,
                (SELECT COUNT(Id) FROM History  WHERE Status = 'Accepted') as Accepted,
                Id,
                CustomerName,
                Address,
                MasterName,
                MeasurerName,
                Window,
                WindowHeight,
                WindowWidth,
                Status,
                Date
                FROM History
                ;";

                var command = new SqlCommand(sql, connection);

                Report report = new Report();

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                DataTable dt = new DataTable();
                new SqlDataAdapter(command).Fill(dt);

                dt.TableName = "History";
                dt.WriteXml("ReportDoc.xml");

                DataSet ds = new DataSet();

                ds.ReadXml("ReportDoc.xml");

                report.RegisterData(ds);

                report.GetDataSource("History").Enabled = true;

                ReportPage page = new ReportPage();

                report.Pages.Add(page);
                page.CreateUniqueName();


                GroupHeaderBand group = new GroupHeaderBand();

                page.Bands.Add(group);
                group.CreateUniqueName();
                group.Height = Units.Centimeters * 1;
                group.Condition = "[History.CustomerName].Substring(0,1)";
                group.SortOrder = FastReport.SortOrder.Ascending;


                TextObject groupTxt = new TextObject();

                groupTxt.Parent = group;
                groupTxt.CreateUniqueName();
                groupTxt.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 1);
                groupTxt.Text = "History";
                groupTxt.VertAlign = VertAlign.Center;


                DataBand data = new DataBand();

                group.Data = data;
                data.CreateUniqueName();
                data.DataSource = report.GetDataSource("History");
                data.Height = Units.Centimeters * 0.5f;


                TextObject productText = new TextObject();

                productText.Parent = data;
                productText.CreateUniqueName();
                productText.Bounds = new RectangleF(0, 0, Units.Centimeters * 15, Units.Centimeters * 0.5f);
                productText.Text = "[History.CustomerName] [History.Window] [History.Date] [History.Status]";

                group.GroupFooter = new GroupFooterBand();
                group.GroupFooter.CreateUniqueName();
                group.GroupFooter.Height = Units.Centimeters * 1;


                Total groupTotal = new Total();

                groupTotal.Name = "TotalRows";
                groupTotal.TotalType = TotalType.Count;
                groupTotal.Evaluator = data;
                groupTotal.PrintOn = group.GroupFooter;
                report.Dictionary.Totals.Add(groupTotal);


                TextObject totalText = new TextObject();

                totalText.Parent = group.GroupFooter;
                totalText.CreateUniqueName();
                totalText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 0.5f);
                totalText.Text = "Rows: [TotalRows] Completed: [History.Completed] Declined: [History.Declined]  New: [History.New] Accepted: [History.Accepted]";
                totalText.HorzAlign = HorzAlign.Right;
                totalText.Border.Lines = BorderLines.Top;

                report.Prepare();

                FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();

                export.Export(report);

                report.Show();
            }

        }

        private void FilterItems_Click(object sender, RoutedEventArgs e)
        {
            if(checkSelected())
            {
                history = new ObservableCollection<db.History>(db.History.Filter(StatusItems.Text));
                historyList.ItemsSource = history;
            }
        }
    }
}
