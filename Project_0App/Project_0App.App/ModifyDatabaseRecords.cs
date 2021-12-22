using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0App.App
{
    public class ModifyDatabaseRecords
    {
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
            command.Parameters.AddWithValue("@phoneNumber", userInput[2]);
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
        }//
    }
}
