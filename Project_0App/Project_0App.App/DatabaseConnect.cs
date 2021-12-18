using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class DatabaseConnect
    {
        public void getStoreLocation() 
        { 
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand("SELECT * FROM StoreLocations;", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int StoreId = reader.GetInt32(0);
                string Location = reader.GetString(1);

                Console.WriteLine($"{StoreId} is at {Location}");
            }
            connection.Close();
        }

        public bool CheckUsernameAndPassword(string? User, string? Pass, ref int id, ref bool manager)
        {
            bool match = false;
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand("SELECT * FROM \"Login\";", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int CustomerId = reader.GetInt32(0);
                string username = reader.GetString(1);
                string password = reader.GetString(2);
                bool IsManager = reader.GetBoolean(3);

                if(username == User && password == Pass)
                {
                    id = CustomerId;
                    manager = IsManager;
                    match = true;
                    break;

                }
            }
            connection.Close();

            return match;
        }
    }
}
