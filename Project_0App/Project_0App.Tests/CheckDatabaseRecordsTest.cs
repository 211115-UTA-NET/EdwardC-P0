using Project_0App.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project_0App.Tests
{
    public class CheckDatabaseRecordsTest
    {
        [Fact]
        public void CheckItemList()
        {
            // Arrange
            var db = new RetrieveDatabaseRecords();
            List<string> itemNames = new List<string>();
            string items = "Shimano Altus FC-M311 Crankset, ";
            string? result = "";

            //Act
            db.RetrieveItemNameToList(ref itemNames, 1);
            for(int i = 0; i < itemNames.Count; i++)
            {
                result += $"{itemNames[i]}, ";
            }

            // Assert
            if (result != null)
                Assert.Equal(items, result);
            else
                throw new NullReferenceException();
        }

        [Fact]
        public void CheckQuantityLessOrEqualItemQuantity()
        {
            // Arrange
            var db = new DatabaseConnect();
            string item = "Shimano Altus FC-M311 Crankset";

            // Act
            var result = db.CheckItemQuantity(1, 5, item);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Eddie")]
        [InlineData("Jackie")]
        public void Find_Customer(string name)
        {
            // Arrange
            CheckDatabaseRecords check = new CheckDatabaseRecords();

            //Act
            bool result = check.SearchCustomers(name);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Cannot_Find_Customer()
        {
            // Arrange
            string? name = "asdf";
            CheckDatabaseRecords check = new CheckDatabaseRecords();

            // Act
            bool result = check.SearchCustomers(name);

            // Asset
            Assert.False(result);
        }
    }
}
