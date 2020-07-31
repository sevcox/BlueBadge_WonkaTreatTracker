using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;

namespace TreatTracker.Services
{
    public class StoreService
    {
        private readonly Guid _userId;
        public StoreService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<StoreListItem> GetStores()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Stores
                    .Select(
                        e =>
                    new StoreListItem
                    {
                        StoreId = e.StoreId,
                        LocationName = e.LocationName
                    }

                    );

                return query.ToArray();
            }
        }

        public StoreDetail GetStoreById(int id)
        {
            using(var ctx = new ApplicationDbContext)
            {
                var entity =
                    ctx
                    .Stores
                    .Single(e => e.StoreId == id);
                    return
                    new StoreDetail 
                    {
                        StoreId = entity.StoreId,
                        LocationName = entity.LocationName,
                        Address = entity.Address,
                        PhoneNumber = entity.PhoneNumber
                    };

            }
        }

    }
}
