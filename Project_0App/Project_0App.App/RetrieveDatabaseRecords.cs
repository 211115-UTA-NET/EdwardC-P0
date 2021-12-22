using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class RetrieveDatabaseRecords
    {
        public void RetrieveStoreLocation()
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

        public void RetrieveItemDetails()
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

        public void RetrieveAllStoreItems()
        {
            int numLoop = 1;

            string connectionString = File.ReadAllText("C:/Users/rootb/Revature/Database_File/ConnectBikeShop.txt");
            using SqlConnection connection = new(connectionString);
            connection.Open();
            using IDbCommand command = new SqlCommand(@$"SELECT StoreItems.ItemName, StoreItems.ItemQuantity, StoreLocations.StoreLocation
                                                        FROM StoreItems
                                                        INNER JOIN StoreLocations ON StoreLocations.StoreId = StoreItems.StoreId
                                                        ;", connection);
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

        public void RetrieveItemNameToList(ref List<string> itemNames, int StoreId)
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

        public void RetrieveCustomerInvoices(int CustomerId)
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

        public void RetrieveStoreInvoices(int StoreId)
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

        public void RetrieveALLStoreInvoices()
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
                                                        ;", connection);
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

        
    }
}
