using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;

namespace TreatTracker.Services
{
    public class FactoryService
    {
        private readonly Guid _userId;
        public FactoryService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<FactoryListItem> GetFactories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Factories
                    .Select(
                        e =>
                    new FactoryListItem
                    {
                        FactoryId = e.FactoryId,
                        LocationName = e.LocationName
                    }

                    );

                return query.ToArray();
            }
        }

        public FactoryDetail GetFactoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Factories
                    .Single(e => e.StoreId == id);
                return
                new FactoryDetail
                {
                    FactoryId = entity.FactoryId,
                    LocationName = entity.LocationName,
                    Address = entity.Address,
                    PhoneNumber = entity.PhoneNumber,
                    Manager = entity.Manager
                };
            }
        }
    }
}
