using GlassLand.pages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GlassLand.db
{
   
    public class Measurement
    {
        public int Id { get; set; } 
        public string CustomerName { get; set; }
        public double WindowWidth { get; set; }
        public double WindowHeight { get; set; }
        public string Measurer { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }

        public static Measurement FindOne(int id)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurement = new Measurement();

                var sql = @"SELECT 
                                m.Id as Id,
	                            m.CustomerName as CustomerName,
	                            m.WindowWidth as WindowWidth,
	                            m.WindowHeight as WindowHeight,
	                            m.Address as Address,
	                            m.Date as Date,
	                            e.Name as MeasurerName
                            FROM Measurements as m LEFT JOIN Employeers as e ON m.MeasurerId = e.Id";

                var command = new SqlCommand(sql + $" WHERE m.Id = {id}", connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    measurement = new Measurement()
                    {
                        CustomerName = reader.GetString(1),
                        WindowWidth = reader.GetDouble(2),
                        WindowHeight = reader.GetDouble(3),
                        Address = reader.GetString(4),
                        Date = reader.GetDateTime(5),
                        Measurer = reader.GetString(6)
                    };
                }

                reader.Close();

                return measurement;

            }
        }

        public  bool addMeasurment()
        {

            using (var connection = Db.Connect())
            {
                connection.Open();
                var sql = $"SELECT Id FROM Employeers WHERE Name = '{Measurer}'";
                var command = new SqlCommand(sql, connection);
                var reader = command.ExecuteReader();
                int measurerId = -1;

                while (reader.Read())
                {
                    measurerId = reader.GetInt32(0);
                }

                if (measurerId == -1)
                {
                    reader.Close();
                    return false;
                }

                reader.Close();

                string now_date = Date.ToString().Replace('.', '/');

                sql = $@"SET DATEFORMAT dmy;
                    INSERT INTO Measurements 
                    VALUES (
                    '{CustomerName}', {measurerId}, {WindowWidth}, {WindowHeight}, '{Address}', '{now_date}'
                    );
                    ";


                command = new SqlCommand(sql, connection);

                if (command.ExecuteNonQuery() > 0)
                {
                    reader.Close();
                    return true;
                }
                reader.Close();

                return false;
            }
        }

        public static void removeMeasurment(int Id)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurers = new List<Measurement>();

                var sql = @"DELETE FROM Measurements Where ID = " + Id + ";";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                reader.Close();
            }
        }

        public static List<Measurement> Find()
        {
            using (var connection = Db.Connect())
            {
                connection.Open();
                var measurements = new List<Measurement>();

                var sql = @"SELECT 
                                m.Id as Id,
	                            m.CustomerName as CustomerName,
	                            m.WindowWidth as WindowWidth,
	                            m.WindowHeight as WindowHeight,
	                            m.Address as Address,
	                            m.Date as Date,
	                            e.Name as MeasurerName
                            FROM Measurements as m LEFT JOIN Employeers as e ON m.MeasurerId = e.Id;";

                var command = new SqlCommand(sql, connection);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    measurements.Add(new Measurement
                    {
                        Id = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        WindowWidth = reader.GetDouble(2),
                        WindowHeight = reader.GetDouble(3),
                        Address = reader.GetString(4),
                        Date = reader.GetDateTime(5),
                        Measurer = reader.GetString(6),
                    });
                }

                reader.Close();

                return measurements;
            }

        }
    }
}
