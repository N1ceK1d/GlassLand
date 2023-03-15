using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class Master
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static void addMaster(string Name)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<Master>();

                var sql = @"INSERT INTO Employeers 
                            Values ('" + Name + "', 'Master');";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();


                reader.Close();
            }
        }

        public static void removeMaster(int Id)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<Master>();

                var sql = @"DELETE FROM Employeers Where ID = " + Id + ";";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                reader.Close();
            }
        }

        public static List<Master> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var masters = new List<Master>();

                var sql = @"SELECT 
                                Id,
                                Name
                            FROM Employeers 
                            WHERE Post = 'Master';";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {

                    masters.Add(new Master
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
