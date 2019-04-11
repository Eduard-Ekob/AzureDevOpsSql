// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using BoardGames;
using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BoardGames.Tests
{
    [TestFixture]
    public class BoardGamesTests
    {
        [Test]
        public void ReturnAdressEntityById()
        {
            // Assert
            int id = 5;
            azWorkshopSqldbContext context = new azWorkshopSqldbContext();
            IMemoryCache cache = null;
            AdventureWorksService service = new AdventureWorksService(context, cache);
            AdventureWorksController controller = new AdventureWorksController(service);

            // Act
            var address = controller.GetAdress(id);

            // Arrange
            Assert.AreEqual("1226 Shoe St.", address.AddressLine1);            
        }
    }
}
