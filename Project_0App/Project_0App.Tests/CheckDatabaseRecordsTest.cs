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
            var db = new DatabaseConnect();
            List<string> itemNames = new List<string>();
            string items = "Lizard Skins DSP Bar Tape V2 4.6mm, Odyssey Bluebird Single Speed, Shimano Altus FC-M311 Crankset, ";
            string? result = "";

            //Act
            db.AssignItemNameToList(ref itemNames, 1);
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
    }
}
