using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;

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
            using(var ctx = new ApplicationDbContext())
            {
                var factory =
                    ctx
                    .Candies
                    .Single(f => f.CandyId == id);
                return
                    new FactoryDetail
                    {
                        FactoryId = factory.FactoryId,
                        LocationName = factory.Factory.LocationName,
                        Address = factory.Factory.Address,
                        Manager = factory.Factory.Manager,
                        PhoneNumber = factory.Factory.PhoneNumber
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
                    .Single(f => f.DrinkId == id);
                return
                    new FactoryDetail
                    {
                        FactoryId = factory.FactoryId,
                        LocationName = factory.Factory.LocationName,
                        Address = factory.Factory.Address,
                        Manager = factory.Factory.Manager,
                        PhoneNumber = factory.Factory.PhoneNumber
                    };
            }
        }
    }
}
