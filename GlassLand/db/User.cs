using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassLand.db
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public static User Login(string login, string password)
        {
            var user = User.FindOne(login);

            if (null == user)
            {
                return null;
            }

            if (password != user.Password)
            {
                return null;
            }

            return user;
        }

        public static User FindOne(string username)
        {
            using (var connection = Db.Connect())
            {
                connection.Open();

                var command = new SqlCommand($"SELECT * FROM Users WHERE Username = '{username}';", connection);

                var reader = command.ExecuteReader();


                if (reader.HasRows)
                {

                    reader.Read();

                    var user = new User()
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString()
                    };

                    reader.Close();

                    return user;

                }
            }

            return null;
        }
    }
}
