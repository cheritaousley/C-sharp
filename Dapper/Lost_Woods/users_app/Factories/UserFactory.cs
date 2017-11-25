using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using users_app.Models;
using System.Text;


namespace users_app.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=8889;database=user;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }
    public void Add(RegisterViewModel user)
    {
        using (IDbConnection dbConnection = Connection)
        {
            string query = $"INSERT INTO user (first_name, last_name, username, age, email, password) VALUES ('{user.first_name}', '{user.last_name}', '{user.username}', '{user.age}', '{user.email}', '{user.password}')";
            dbConnection.Open();
            dbConnection.Execute(query, user);
        }
    }
    public IEnumerable<User> GetUser(int Id)
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<User>($"SELECT TOP 1 * FROM user where Id = '{Id}' ");
        }
    }
    public User FindByID(string email)
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Query<User>($"SELECT * FROM user WHERE email = '{email}'").FirstOrDefault();
        }
    }
    }
}