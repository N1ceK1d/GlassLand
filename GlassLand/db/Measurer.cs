using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class Measurer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static void addMeasurer(string Name)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurers = new List<Measurer>();

                var sql = @"INSERT INTO Employeers 
                            Values ('" + Name + "', 'Measurer');";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();


                reader.Close();
            }
        }

        public static void removeMeasurer(int Id)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurers = new List<Measurer>();

                var sql = @"DELETE FROM Employeers Where ID = " + Id + ";";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                reader.Close();
            }
        }

        public static List<Measurer> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurers = new List<Measurer>();

                var sql = @"SELECT 
                                Id,
                                Name
                            FROM Employeers 
                            WHERE Post = 'Measurer';";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    measurers.Add(new Measurer
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }

                reader.Close();

                return measurers;
            }
        }
    }
}
