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

                Console.WriteLine($"{StoreId}) {Location}");
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

        public void AddCustomerToDatabase(List<string> userInput, ref int CustomerId)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            
            // Add to Customer Table
            connection.Open();
            using SqlCommand command = new(
                $"INSERT INTO Customers (FirstName, LastName, PhoneNumber, \"Address\") VALUES (@firstName, @lastName, @phoneNumber, @Address);",
                connection);
            command.Parameters.AddWithValue("@firstName", userInput[0]);
            command.Parameters.AddWithValue("@lastName", userInput[1]);
            command.Parameters.AddWithValue("@phoneNumber", Convert.ToInt32(userInput[2]));
            command.Parameters.AddWithValue("@Address", userInput[3]);
            command.ExecuteNonQuery();
            connection.Close();

            // Add to Login Table
            connection.Open();
            using SqlCommand command2 = new(
                $"INSERT INTO \"Login\" (Username, \"Password\", IsManager) VALUES (@Username, @Password, 0);",
                connection);
            command2.Parameters.AddWithValue("@Username", userInput[4]);
            command2.Parameters.AddWithValue("@Password", userInput[5]);
            command2.ExecuteNonQuery();
            connection.Close();

            // get CustomerId from Customers and assign to reference CustomerId
            connection.Open();
            using IDbCommand command3 = new SqlCommand("SELECT * FROM Customers;", connection);
            using IDataReader reader = command3.ExecuteReader();
            while (reader.Read())
            {
                int getId = reader.GetInt32(0);
                string username = reader.GetString(1);

                if (username == userInput[0])
                {
                    CustomerId = getId;
                    break;

                }
            }
            connection.Close();
        }

        public void DisplayOrderDetail()
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand("SELECT * FROM ItemDetails;", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ItemName = reader.GetString(0);
                string ItemDetail = reader.GetString(1);
                decimal Price = reader.GetDecimal(2);

                Console.WriteLine($"Item Name: {ItemName}\nDetail:\n{ItemDetail}\nPrice: ${Price}\n");
            }
            connection.Close();
        }

        public void RetrieveStoreItems(int StoreId)
        {
            int numLoop = 1;

            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT StoreItems.ItemName, StoreItems.ItemQuantity, StoreLocations.StoreLocation
                                                        FROM StoreItems
                                                        INNER JOIN StoreLocations ON StoreLocations.StoreId = StoreItems.StoreId
                                                        WHERE StoreLocations.StoreId = {StoreId};", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ItemName = reader.GetString(0);
                int ItemDetail = reader.GetInt32(1);
                string Location = reader.GetString(2);

                Console.WriteLine($"{numLoop}) Item Name: {ItemName}\n   Quantity: {ItemDetail}\n   Location: {Location}\n");
                numLoop++;
            }
            connection.Close();
        }

        public decimal RetrieveInvoices(int num, string item, int quantity, ref List<decimal> TotalPrices)
        {
            decimal totalPrice = 0;
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT ItemName, Price FROM ItemDetails WHERE ItemName = '{item}'", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ItemName = reader.GetString(0);
                decimal Price = reader.GetDecimal(1);

                Console.WriteLine($"{num}) Item Name: {item}\nQuantity: {quantity}\nPrice: {Price}\nTotal Price: {quantity * Price}\n");
                totalPrice = quantity * Price;
            }
            connection.Close();
            TotalPrices.Add(totalPrice);
            return totalPrice;
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
                if(Name == ItemName)
                {
                    if( 0 < Quantity && Quantity <= ItemQuantity)
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

        public void AssignItemNameToList(ref List<string> itemNames, int StoreId)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand($"SELECT ItemName FROM StoreItems WHERE StoreId = {StoreId}", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string ItemName = reader.GetString(0);
                itemNames.Add(ItemName);
            }
            connection.Close();
        }

        public void DisplayCustomerOrderHistory(int CustomerId)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT Invoices.InvoiceId, InvoiceHistory.InvoiceDate, 
	                                                    InvoiceList.ItemName, InvoiceList.ItemQuantity, 
	                                                    InvoiceList.TotalPrice, StoreLocations.StoreLocation
                                                        FROM Invoices
                                                        INNER JOIN InvoiceHistory ON InvoiceHistory.InvoiceId = Invoices.InvoiceId
                                                        INNER JOIN InvoiceList ON InvoiceList.InvoiceId = Invoices.InvoiceId
                                                        INNER JOIN StoreLocations On StoreLocations.StoreId = Invoices.StoreId
                                                        WHERE Invoices.CustomerId = {CustomerId};", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int InvoiceId = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                string ItemName = reader.GetString(2);
                int ItemQuantity = reader.GetInt32(3);
                decimal TotalPrice = reader.GetDecimal(4);
                string Location = reader.GetString(5);

                Console.WriteLine($"\nInvoice: {InvoiceId}, {date}\n Item Name: {ItemName} ({ItemQuantity}) = ${TotalPrice}\nLocation: {Location}");
            }
            connection.Close();
        }

        public void DisplayStoreOrderHistory(int StoreId)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT Invoices.InvoiceId, InvoiceHistory.InvoiceDate, 
	                                                    InvoiceList.ItemName, InvoiceList.ItemQuantity, 
	                                                    InvoiceList.TotalPrice, StoreLocations.StoreLocation
                                                        FROM Invoices
                                                        INNER JOIN InvoiceHistory ON InvoiceHistory.InvoiceId = Invoices.InvoiceId
                                                        INNER JOIN InvoiceList ON InvoiceList.InvoiceId = Invoices.InvoiceId
                                                        INNER JOIN StoreLocations On StoreLocations.StoreId = Invoices.StoreId
                                                        WHERE Invoices.StoreId = {StoreId};", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int InvoiceId = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                string ItemName = reader.GetString(2);
                int ItemQuantity = reader.GetInt32(3);
                decimal TotalPrice = reader.GetDecimal(4);
                string Location = reader.GetString(5);

                Console.WriteLine($"\nInvoice: {InvoiceId}, {date}\n Item Name: {ItemName} ({ItemQuantity}) = ${TotalPrice}\nLocation: {Location}");
            }
            connection.Close();
        }

        public void DecreaseStoreItems(int storeId, string? itemName, int itemQuantity)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new(
                @$"UPDATE StoreItems
                   SET ItemQuantity = (ItemQuantity - @ItemQuantity)
                   WHERE ItemName = @ItemName AND StoreId = @StoreId;",
                connection);
            command.Parameters.AddWithValue("@ItemQuantity", itemQuantity);
            command.Parameters.AddWithValue("@ItemName", itemName);
            command.Parameters.AddWithValue("@StoreId", storeId);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddInvoicesTable(int customerId, int storeId)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new(
                @$"INSERT Invoices (CustomerId, StoreId)
                   VALUES(@customer, @store) ",
                connection);
            command.Parameters.AddWithValue("@customer", customerId);
            command.Parameters.AddWithValue("@store", storeId);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public int GetLatestInvoiceId()
        {
            int getNum = 0;
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT TOP 1 InvoiceId 
	                                                    FROM Invoices
                                                        ORDER BY InvoiceId DESC", connection);
            using IDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int InvoiceId = reader.GetInt32(0);
                getNum = InvoiceId;
                
            }
            connection.Close();
            return getNum;
        }

        public void AddInvoiceHistory(int invoiceId, DateTime date)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new(
                @$"INSERT InvoiceHistory (InvoiceId, InvoiceDate)
                   VALUES(@InvoiceId, @InvoiceDate) ",
                connection);
            command.Parameters.AddWithValue("@InvoiceId", invoiceId);
            command.Parameters.AddWithValue("@InvoiceDate", date);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddInvoiceList(int invoiceId, string userItem, int userQuantity, decimal TotalPrice)
        {
            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using SqlCommand command = new(
                @$"INSERT InvoiceList (InvoiceId, ItemName, ItemQuantity, TotalPrice)
                   VALUES(@InvoiceId, @ItemName, @ItemQuantity, @TotalPrice) ",
                connection);
            command.Parameters.AddWithValue("@InvoiceId", invoiceId);
            command.Parameters.AddWithValue("@Itemname", userItem);
            command.Parameters.AddWithValue("@ItemQuantity", userQuantity);
            command.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
