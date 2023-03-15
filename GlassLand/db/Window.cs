using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class Window
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static void addWindow(string Name)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<db.Window>();

                var sql = @"INSERT INTO Windows 
                            Values ('" + Name + "');";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();


                reader.Close();
            }
        }

        public static void removeWindow(int Id)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<Window>();

                var sql = @"DELETE FROM Windows Where ID = " + Id + ";";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                reader.Close();
            }
        }

        public static List<db.Window> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<db.Window>();

                var sql = @"SELECT 
                                Id,
                                Name
                            FROM Windows;";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    masters.Add(new db.Window
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }

                reader.Close();

                return masters;
            }
        }
    }
}
