using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGames.Models;
using Games.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BoardGames.Services
{
    public class AdventureWorksService
    {
        private azWorkshopSqldbContext db;
        private IMemoryCache cache;

        public AdventureWorksService(azWorkshopSqldbContext context, IMemoryCache memoryCache)
        {
            db = context;
            cache = memoryCache;
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            Address address = null;
            if (!cache.TryGetValue(id, out address))
            {
                address = await db.Address.FirstOrDefaultAsync(p => p.AddressId == id);
                if (address != null)
                {
                    cache.Set(address.AddressId, address,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }

            return address;
        }

        //public Address GetAddressAsync(int id)
        //{
        //    Address address = null;
        //    address = db.Address.FirstOrDefault(p => p.AddressId == id);

        //    return address;
        //}

        public void AddAddress(Address address)
        {
            db.Address.Add(address);
            int i = db.SaveChanges();
            if (i > 0)
            {
                cache.Set(address.AddressId, address, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }
    }
}
