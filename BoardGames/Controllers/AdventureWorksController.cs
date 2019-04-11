using System.Collections.Generic;
using System.Threading.Tasks;
using BoardGames.Models;
using BoardGames.Services;
using Games.Models;
using Games.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardGames.Controllers
{
    [Route("api/[controller]")]
    public class AdventureWorksController : Controller
    {
        private AdventureWorksService _adventureWorksService;

        public AdventureWorksController(AdventureWorksService service)
        {
            _adventureWorksService = service;
        }

        //GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<Address> GetAdress(int id)
        {
            return await _adventureWorksService.GetAddressAsync(id);
        }

        //[HttpGet("{id}")]
        //public Address GetAdress(int id)
        //{
        //    return _adventureWorksService.GetAddressAsync(id);
        //}

        //POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Address address)
        {
            _adventureWorksService.AddAddress(address);
        }
    }
}
