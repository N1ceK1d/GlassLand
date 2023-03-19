using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class History
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string MasterName { get; set; }
        public string MeasurerName { get; set; }
        public string Window { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public bool addHistory()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();

                string now_date = Date.ToString().Replace('.', '/');

                var sql = $@"SET DATEFORMAT dmy;
                    INSERT INTO History 
                    VALUES (
                    '{CustomerName}', {Address}, {MasterName}, {MeasurerName}, '{Window}', {WindowHeight}, {WindowWidth}, '{Status}', '{now_date}'
                    );
                    ";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                if (command.ExecuteNonQuery() > 0)
                {
                    reader.Close();
                    return true;
                }
                reader.Close();
                return false;
            }
        }

        public int getCount(string Status)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var histories = new List<db.History>();

                var sql = $@"SELECT COUNT(Status) FROM History as h Where Status = '{Status}'";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                int count = 0;

                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }

                reader.Close();

                return count;
            }
        }
        public static List<db.History> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var histories = new List<db.History>();

                var sql = @"SELECT 
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
FROM History;";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    histories.Add(new db.History
                    {
                        CustomerName = reader.GetString(1),
                        Address = reader.GetString(2),
                        MasterName = reader.GetString(3),
                        MeasurerName = reader.GetString(4),
                        Window = reader.GetString(5),
                        WindowHeight = reader.GetInt32(6),
                        WindowWidth = reader.GetInt32(7),
                        Status = reader.GetString(8),
                        Date = reader.GetDateTime(9)
                    });
                }

                reader.Close();

                return histories;
            }
        }
    }
}
