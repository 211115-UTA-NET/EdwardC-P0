using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class CheckDatabaseRecords
    {
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

                if (username == User && password == Pass)
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

        public bool CheckItemQuantity(int StoreId, int Quantity, string? Name)
        {
            bool result = false;

            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT ItemName, ItemQuantity
                                                        FROM StoreItems
                                                        WHERE StoreId = {StoreId}", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ItemName = reader.GetString(0);
                int ItemQuantity = reader.GetInt32(1);
                if (Name == ItemName)
                {
                    if (0 < Quantity && Quantity <= ItemQuantity)
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            connection.Close();

            return result;
        }

        public bool SearchCustomers(string name)
        {
            bool Found = false;
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand($"SELECT FirstName FROM Customers WHERE FirstName = '{name}';", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string FirstName = reader.GetString(0);
                if (FirstName != null)
                {
                    Found = true;
                }

            }
            connection.Close();

            return Found;
        }
    }


}
