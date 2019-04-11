using System;
using Xunit;
using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesXUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {

            // Arrange
            int id = 5;
            azWorkshopSqldbContext _context = new azWorkshopSqldbContext();
            IMemoryCache _cache = null;
            AdventureWorksService _service = new AdventureWorksService(_context, _cache);
            AdventureWorksController _controller = new AdventureWorksController(_service);

            // Act
            var notFoundResult =_controller.GetAdress(id);

            // Assert
            Assert.Equal("1226 Shoe St.", notFoundResult.AddressLine1);
        }
    }
}
