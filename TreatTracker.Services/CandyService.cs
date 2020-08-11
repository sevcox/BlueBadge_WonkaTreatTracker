using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreatTracker.Data;
using TreatTracker.Models;
using TreatTracker.Models.CandyModels;
using TreatTracker.Models.StoreModels;

namespace TreatTracker.Services
{
    public class CandyService
    {
        private readonly string _userName;

        public CandyService(string userName)
        {
            _userName = userName;
        }
        public bool CreateCandy(CandyCreate model)
        {
            var entity =
            new Candy()
            {
                TreatName = model.TreatName,
                CandyType = model.CandyType,
                Description = model.Description,
                SecretIngredient = model.SecretIngredient,
                Quantity = model.Quantity,
                Price = model.Price,
                FactoryId = GetFactoryId(),
                CreatedUtc = DateTimeOffset.Now,
                UserCreated = _userName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Candies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool ConnectCandyWithStore(CandyQuantityEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var candy =
                    ctx
                    .Candies
                    .Single(e => e.CandyId == model.CandyId);

                var store =
                    ctx
                    .Stores
                    .Single(e => e.StoreId == model.StoreId);

                candy.Stores.Add(store);
                candy.Quantity -= model.Quantity;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CandyListItem> GetCandies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Candies
                        .Select(
                            e =>
                                new CandyListItem
                                {
                                    CandyId = e.CandyId,
                                    TreatName = e.TreatName,
                                    CandyType = e.CandyType,
                                    Quantity = e.Quantity,
                                    FactoryId = e.FactoryId,
                                }
                        );

                return query.ToArray();
            }
        }
        public CandyDetail GetCandyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Candies
                        .Single(e => e.CandyId == id);
                return
                    new CandyDetail
                    {
                        CandyId = entity.CandyId,
                        TreatName = entity.TreatName,
                        CandyType = entity.CandyType,
                        Description = entity.Description,
                        SecretIngredient = entity.SecretIngredient,
                        Price = entity.Price,
                        Quantity = entity.Quantity,
                        FactoryId = entity.FactoryId,
                        CreatedUtc = entity.CreatedUtc,
                        UserCreated = entity.UserCreated,
                        ModifiedUtc = entity.ModifiedUtc,
                        UserModified = entity.UserModified
                    };
            }
        }
        public bool UpdateCandy(CandyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Candies
                        .Single(e => e.CandyId == model.CandyId);
                entity.TreatName = model.TreatName;
                entity.Quantity = model.Quantity;
                entity.Price = model.Price;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.UserModified = _userName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCandy(int candyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Candies
                        .Single(e => e.CandyId == candyId);

                ctx.Candies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Factory_CandyListItem> GetCandiesByFactoryId(int factoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                     .Factories
                     .Single(e => e.FactoryId == factoryId)
                     .Candies
                     .Select
                     (e =>
                     new Factory_CandyListItem
                     {
                         CandyId = e.CandyId,
                         CandyType = e.CandyType,
                         FactoryId = e.FactoryId,
                         LocationName = e.Factory.LocationName,
                         TreatName = e.TreatName,
                         Quantity = e.Quantity
                     }
                     );
                return query.ToArray();
            }
        }

        public IEnumerable<CandyListItem> GetCandiesByStoreId(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allCandies =
                    ctx
                    .Stores
                    .Single(e => e.StoreId == storeId)
                    .Candies
                    .Select
                    (e =>
                        new CandyListItem
                        {
                            CandyId = e.CandyId,
                            TreatName = e.TreatName,
                            CandyType = e.CandyType,
                            Quantity = e.Quantity,
                            FactoryId = e.FactoryId,
                        }
                    );
                return allCandies.ToArray();
            }
        }

        public int GetFactoryId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx
                    .Users
                    .Single(e => e.UserName == _userName);

                    return user.FactoryId;
            }
        }
    }
}
