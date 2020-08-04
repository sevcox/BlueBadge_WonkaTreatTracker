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

        //public IEnumerable<Factory_CandyListItem> GetAllCandyByFactory(int id)
        //{
        //    using(var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Factories
        //            .Select(
        //                e =>
        //                new Factory_CandyListItem
        //                {
        //                    FactoryId = e.FactoryId,
        //                    LocationName = e.LocationName,
        //                    CandyId = e.CandyId,
        //                    TreatName = e.TreatName,
        //                    Quantity = e.Quantity
        //                }

        //                );
        //        return query.ToArray();
        //    }
        //}

        //public IEnumerable<Factory_DrinkListItem> GetAllCDrinksByFactory(int id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Factories
        //            .Select(
        //                e =>
        //                new Factory_DrinkListItem
        //                {
        //                    FactoryId = e.FactoryId,
        //                    LocationName = e.LocationName,
        //                    DrinkId = e.DrinkId,
        //                    TreatName = e.TreatName,
        //                    Quantity = e.Quantity
        //                }

        //                );
        //        return query.ToArray();
        //    }
        //}

    }
}
