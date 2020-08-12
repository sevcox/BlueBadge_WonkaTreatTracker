using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;
using TreatTracker.Models.CandyModels;

namespace TreatTracker.Services
{
    public class FactoryService
    {

        public FactoryService()
        {
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
                    .Single(e => e.FactoryId == id);
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
        public FactoryDetail GetFactoryByCandyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var factory =
                    ctx
                    .Candies
                    .Single(e => e.CandyId == id)
                    .Factory;
                return
                    new FactoryDetail
                    {
                        FactoryId = factory.FactoryId,
                        LocationName = factory.LocationName,
                        Address = factory.Address,
                        Manager = factory.Manager,
                        PhoneNumber = factory.PhoneNumber
                    };
            }
        }
        public FactoryDetail GetFactoryByDrinkId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var factory =
                    ctx
                    .Drinks
                    .Single(e => e.DrinkId == id)
                    .Factory;
                return
                    new FactoryDetail
                    {
                        FactoryId = factory.FactoryId,
                        LocationName = factory.LocationName,
                        Address = factory.Address,
                        Manager = factory.Manager,
                        PhoneNumber = factory.PhoneNumber
                    };
            }
        }
    }
}
