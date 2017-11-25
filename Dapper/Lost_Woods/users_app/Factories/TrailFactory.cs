using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using users_app.Models;

namespace users_app.Factory
{
    public class TrailItemFactory : IFactory<TrailItem>
    {
        private string connectionString;
        public TrailItemFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=user;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(TrailItem item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"INSERT INTO MENUITEM (NAME, PRICE, DESCRIPTION, ISVEGGO, ISAVAILABLE, CATEGORY) VALUES ('{item.Name}', {item.Description}, '{item.Length}', {item.ElevationGain}, {item.Longitude}, '{item.Latitude}')";

                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<TrailItem> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<TrailItem>("SELECT * FROM TrailItem");
            }
        }
        // public User FindByID(int id)
        // {
        //     using (IDbConnection dbConnection = Connection)
        //     {
        //         dbConnection.Open();
        //         return dbConnection.Query<User>("SELECT * FROM users WHERE id = @Id", new { Id = id }).FirstOrDefault();
        //     }
        // }
    }
}